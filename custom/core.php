<?php
ini_set('memory_limit', '-1');

include './graph.php';

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
    $realVertices[$vertex] = $graph->addVertex('v' . $vertex);
}

foreach ($edges as $edge) {
    $graph->addEdge('v' . $edge[0], 'v' . $edge[1]);
}

echo 'Loading done.' . PHP_EOL;

echo 'Loading time: ' . (microtime(true) - $startTime) .  PHP_EOL;

echo 'Vertices: ' . count($graph->vertices) . PHP_EOL;
echo 'Edges: ' . count($graph->edges) . PHP_EOL;

$startTime = microtime(true);
$bfsResult = $graph->BFS();

echo 'BFS time: ' . (microtime(true) - $startTime) . PHP_EOL;
echo 'BFS elements: ' . count($bfsResult) . PHP_EOL;

foreach (INDEXES as $index) {
    echo $index . ': ' . $bfsResult[$index] . PHP_EOL;
}