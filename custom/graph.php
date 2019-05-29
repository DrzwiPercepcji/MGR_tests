<?php

class Graph
{
    public $vertices = [];
    public $edges = [];

    private $visited = [];
    private $neighborhoods = [];

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

        foreach ($this->vertices as $vertex) {
            $this->visited[$vertex] = false;
        }

        return array_merge(['v0'], $this->internalBFS('v0'));
    }

    private function internalBFS($vertexIndex)
    {
        $this->visited[$vertexIndex] = true;

        $result = [];
        $queue = [];

        foreach ($this->vertices as $vertex) {
            if (@$this->neighborhoods[$vertexIndex][$vertex] && $this->visited[$vertex] == false) {
                $this->visited[$vertex] = true;

                $result[] = $vertex;
                $queue[] = $vertex;
            }
        }

        foreach ($queue as $next) {
            $result = array_merge($result, $this->internalBFS($next));
        }

        return $result;
    }
}