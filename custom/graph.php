<?php

class Graph
{
    public $vertices = [];
    public $edges = [];

    private $queue = [];
    private $visited = [];
    private $neighborhoods = [];

    private $bfsResult = [];

    public function addVertex($id)
    {
        $this->vertices[] = $id;
    }

    public function addEdge($idA, $idB)
    {
        $this->edges[] = [$idA, $idB];
        $this->neighborhoods[$idA][$idB] = true;
        $this->neighborhoods[$idB][$idA] = true;
    }

    public function BFS()
    {
        $this->visited = [];
        $this->bfsResult = [];

        foreach ($this->vertices as $vertex) {
            $this->visited[$vertex] = false;
        }

        $this->bfsResult[] = 'v0';
        $this->internalBFS('v0');

        return $this->bfsResult;
    }

    private function internalBFS($vertexIndex)
    {
        $this->visited[$vertexIndex] = true;

        foreach ($this->neighborhoods[$vertexIndex] as $key => $value) {
            if ($this->visited[$key] == false) {
                $this->visited[$key] = true;
                $this->bfsResult[] = $key;
                $this->queue[] = $key;
            }
        }

        if (!empty($this->queue)) {
            $this->internalBFS(array_shift($this->queue));
        }
    }

    public function printNotListedInBFS()
    {
        foreach ($this->vertices as $vertex) {
            if ($this->visited[$vertex] == false) {
                echo $vertex . PHP_EOL;
            }
        }
    }
}