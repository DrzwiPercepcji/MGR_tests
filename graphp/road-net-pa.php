<?php
require_once 'vendor/autoload.php';

use \Fhaculty\Graph\Graph as Graph;
use Graphp\Algorithms\Search\BreadthFirst;
use Graphp\Algorithms\Search\DepthFirst;

ini_set('memory_limit', '-1');

const PATH = '../samples/roadNet-PA.txt';
const AVOID_DOUBLES = true;
const INDEXES = [100, 1000, 10000, 100000];

$graph = new Graph();

if ($file = fopen(PATH, 'r')) {

    $vertices = [];
    $edges = [];

    echo 'Preparing...' . PHP_EOL;

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
        }
    }

    $uniqueVertices = array_unique($vertices);

    echo 'Unique vertices: ' . count($uniqueVertices) . PHP_EOL;

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

$startTime = microtime(true);
$bfs = new BreadthFirst($graph->getVertex('v0'));
$bfsResult = $bfs->getVertices()->getIds();

echo 'BFS time: ' . (microtime(true) - $startTime) . PHP_EOL;
echo 'BSF elements: ' . count($bfsResult) . PHP_EOL;

foreach (INDEXES as $index) {
    echo $index . ': ' . $bfsResult[$index] . PHP_EOL;
}

$startTime = microtime(true);
$dfs = new DepthFirst($graph->getVertex('v0'));
$dfsResult = $dfs->getVertices()->getIds();

echo 'DFS time: ' . (microtime(true) - $startTime) . PHP_EOL;
echo 'DSF elements: ' . count($dfsResult) . PHP_EOL;

foreach (INDEXES as $index) {
    echo $index . ': ' . $dfsResult[$index] . PHP_EOL;
}