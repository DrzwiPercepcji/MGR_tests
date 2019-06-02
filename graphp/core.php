<?php
require_once 'vendor/autoload.php';

use \Fhaculty\Graph\Graph as Graph;
use Graphp\Algorithms\Search\BreadthFirst;
use Graphp\Algorithms\Search\DepthFirst;
use Graphp\Algorithms\ShortestPath\Dijkstra;

ini_set('memory_limit', '-1');

$graph = new Graph();

if ($file = fopen(PATH, 'r')) {

    $vertices = [];
    $edges = [];

    echo 'Preparing...' . PHP_EOL;

    $lines = 0;

    if (AVOID_DOUBLES) {
        while (!feof($file)) {
            $line = fgets($file);
            $splited = explode("\t", $line);

            $splited[0] = (int)$splited[0];
            $splited[1] = (int)$splited[1];

            if ($splited[0] < $splited[1]) {
                $vertices[] = $splited[0];
                $vertices[] = $splited[1];
                $edges[] = $splited;
            }
            $lines++;
        }
    } else {
        while (!feof($file)) {
            $line = fgets($file);
            $splited = explode("\t", $line);

            $splited[0] = (int)$splited[0];
            $splited[1] = (int)$splited[1];

            $vertices[] = $splited[0];
            $vertices[] = $splited[1];
            $edges[] = $splited;

            $lines++;
        }
    }

    echo 'Lines: ' . $lines . PHP_EOL;

    $uniqueVertices = array_values(array_unique($vertices));

    echo 'Unique vertices: ' . count($uniqueVertices) . PHP_EOL;

    foreach (UNIQUE_TESTS as $index) {
        echo 'Unique ' . $index . ': ' . $uniqueVertices[$index] . PHP_EOL;
    }

    echo 'Preparing done.' . PHP_EOL;

    fclose($file);
}

$realVertices = [];

$startTime = microtime(true);

foreach ($uniqueVertices as $vertex) {
    $realVertices[$vertex] = $graph->createVertex('v' . $vertex);
}

foreach ($edges as $edge) {
    $realVertices[$edge[0]]->createEdge($realVertices[$edge[1]]);
}

echo 'Loading done.' . PHP_EOL;

echo 'Loading time: ' . (microtime(true) - $startTime) .  PHP_EOL;

echo 'Vertices: ' . count($graph->getVertices())  . PHP_EOL;
echo 'Edges: ' . count($graph->getEdges()) . PHP_EOL;

if (in_array('bfs', ALGORITHMS)) {
    $startTime = microtime(true);
    $bfs = new BreadthFirst($graph->getVertex('v0'));
    $bfsResult = $bfs->getVertices()->getIds();

    echo 'BFS time: ' . (microtime(true) - $startTime) . PHP_EOL;
    echo 'BFS elements: ' . count($bfsResult) . PHP_EOL;

    foreach (INDEXES as $index) {
        echo $index . ': ' . $bfsResult[$index] . PHP_EOL;
    }
}

if (in_array('dfs', ALGORITHMS)) {
    $startTime = microtime(true);
    $dfs = new DepthFirst($graph->getVertex('v0'));
    $dfsResult = $dfs->getVertices()->getIds();

    echo 'DFS time: ' . (microtime(true) - $startTime) . PHP_EOL;
    echo 'DSF elements: ' . count($dfsResult) . PHP_EOL;

    foreach (INDEXES as $index) {
        echo $index . ': ' . $dfsResult[$index] . PHP_EOL;
    }
}

if (in_array('shortest', ALGORITHMS)) {
    $startTime = microtime(true);
    $shortest = new Dijkstra($graph->getVertex('v0'));
    $shortestResult = $shortest->getEdgesTo($graph->getVertex('v70'));

    echo 'Shortest time: ' . (microtime(true) - $startTime) . PHP_EOL;
    echo 'Shortest elements: ' . count($shortestResult) . PHP_EOL;
}