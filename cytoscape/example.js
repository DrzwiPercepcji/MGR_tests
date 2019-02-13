var cytoscape = require('cytoscape');

var cy = cytoscape();

var eles = cy.add([
    { group: 'nodes', data: { id: 'n0' }, position: { x: 100, y: 100 } },
    { group: 'nodes', data: { id: 'n1' }, position: { x: 200, y: 200 } },
    { group: 'nodes', data: { id: 'n2' }, position: { x: 300, y: 300 } },
    { group: 'edges', data: { id: 'e0', source: 'n0', target: 'n1' } },
    { group: 'edges', data: { id: 'e1', source: 'n1', target: 'n2' } },
    { group: 'edges', data: { id: 'e2', source: 'n0', target: 'n2' } }
]);

var aStar = cy.elements().aStar({ root: '#n0', goal: '#n2' });

//ar result = aStar.path.select();

console.log(aStar);