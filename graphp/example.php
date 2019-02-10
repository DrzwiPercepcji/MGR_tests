<?php
require_once 'vendor/autoload.php';

use \Fhaculty\Graph\Graph as Graph;

$graph = new Graph();

// create some cities
$rome = $graph->createVertex('Rome');
$madrid = $graph->createVertex('Madrid');
$cologne = $graph->createVertex('Cologne');

// build some roads
$cologne->createEdgeTo($madrid);
$madrid->createEdgeTo($rome);
// create loop
$rome->createEdgeTo($rome);

foreach ($rome->getVerticesEdgeFrom() as $vertex) {
    echo $vertex->getId().' leads to rome'.PHP_EOL;
    // result: Madrid and Rome itself
}