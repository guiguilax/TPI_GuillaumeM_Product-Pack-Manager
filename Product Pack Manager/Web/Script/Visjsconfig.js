function starting() {
    //display the first dropdownlist
    document.getElementById("AddingelementPrestation").style.display = "block";
    //remove the newwork if one already exist 
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
            //the way the network will be display
            layout: {
                hierarchical: {
                    sortMethod: "directed",
                    shakeTowards: "leaves",
                },
            },
            //physics use between node 
            physics: {
                hierarchicalRepulsion: {
                    avoidOverlap: 0.8
                },
            },
            //type of edges
            edges: {
                smooth: true,
                arrows: { to: true },
            },
            //use to know if cursor is on the edge
            interaction: {
                hover: true,
            },
        };
        network = new vis.Network(container, data, options);
    }
    draw();
    //use to displya the edge label when mouse hover
    network.on("hoverEdge", function (e) {
        this.body.data.edges.update({
            id: e.edge,
            font: {
                size: 14,
            },
        });
    });
    //use to hide label
    network.on("blurEdge", function (e) {
        this.body.data.edges.update({
            id: e.edge,
            font: {
                size: 0,
            },
        });
    });
}
