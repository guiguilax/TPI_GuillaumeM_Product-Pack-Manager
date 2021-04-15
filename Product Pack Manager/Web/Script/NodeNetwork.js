function starting() {
    var network = null;
    function draw() {
        if (network !== null) {
            network.destroy();
            network = null;
        }


        // create the network
        var container = document.getElementById("mynetwork");
        var data = {
            nodes: nodes,
            edges: edges,
        };
        var options = {
            layout: {
                hierarchical: {
                    sortMethod: "directed",
                    shakeTowards: "leaves",
                },
            },
            edges: {
                smooth: true,
                arrows: { to: true },
            },
        };
        network = new vis.Network(container, data, options);
    }
    draw();
}
