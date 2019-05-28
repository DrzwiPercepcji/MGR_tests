var cytoscape = require('cytoscape');
var fs = require("fs");

var i;
var startTime;
var endTime;

var cy = cytoscape();

exports.run = function (path, avoidDoubles, uniqueTests, indexes) {
    fs.readFile(path, function (error, buffer) {

        let lines = buffer.toString().split('\r\n');

        let nodes = [];
        let edges = [];

        console.log('Preparing...');

        if (avoidDoubles) {
            for (i = 0; i < lines.length; i++) {
                let splited = lines[i].split('\t');

                if (splited[0] < splited[1]) {
                    nodes.push(splited[0]);
                    nodes.push(splited[1]);
                    edges.push(splited);
                }
            }
        } else {
            for (i = 0; i < lines.length; i++) {
                let splited = lines[i].split('\t');

                nodes.push(splited[0]);
                nodes.push(splited[1]);
                edges.push(splited);
            }
        }

        console.log('Lines: ' + lines.length);

        uniqueNodes = [...new Set(nodes)];

        console.log('Unique nodes: ' + uniqueNodes.length);

        for (i = 0; i < uniqueTests.length; i++) {
            console.log('Unique ' + uniqueTests[i] + ': ' + uniqueNodes[uniqueTests[i]]);
        }

        console.log('Preparing done.');

        startTime = new Date();

        for (i = 0; i < uniqueNodes.length; i++) {
            cy.add({ group: 'nodes', data: { id: 'n' + uniqueNodes[i] } });
        }

        for (i = 0; i < edges.length; i++) {
            cy.add({ group: 'edges', data: { id: 'e' + i, source: 'n' + edges[i][0], target: 'n' + edges[i][1] } });
        }

        console.log('Loading done.');

        endTime = new Date() - startTime;
        console.info('Loading time: %dms', endTime);

        console.log('Nodes: ' + cy.nodes().length);
        console.log('Edges: ' + cy.edges().length);

        bfs(indexes);
        dfs(indexes);
    });
}

function bfs(indexes) {
    startTime = new Date();

    var results = [];
    var bfs = cy.elements().bfs({
        roots: '#n0',
        visit: function (v, e, u, i, depth) {
            if (indexes.includes(i)) {
                results.push(i + ': ' + v.id());
            }
        },
        directed: false
    });

    var path = bfs.path.nodes();

    console.log('BFS done.');

    endTime = new Date() - startTime;
    console.info('BFS time: %dms', endTime);

    console.log('BFS elements: ' + path.length);

    for (i = 0; i < results.length; i++) {
        console.log(results[i]);
    }
}

function dfs(indexes) {
    startTime = new Date();

    var results = [];
    var dfs = cy.elements().dfs({
        roots: '#n0',
        visit: function (v, e, u, i, depth) {
            if (indexes.includes(i)) {
                results.push(i + ': ' + v.id());
            }
        },
        directed: false
    });

    var path = dfs.path.nodes();

    console.log('DFS done.');

    endTime = new Date() - startTime;
    console.info('DFS time: %dms', endTime);

    console.log('DFS elements: ' + path.length);

    for (i = 0; i < results.length; i++) {
        console.log(results[i]);
    }
}