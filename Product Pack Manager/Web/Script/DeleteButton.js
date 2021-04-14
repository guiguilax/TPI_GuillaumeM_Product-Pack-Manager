function hidebutton() {
    var checkBox = document.getElementById("deletecheck");
    var text = document.getElementById("buttondelete");
    if (checkBox.checked == true) {
        text.style.display = "block";
    } else {
        text.style.display = "none";
    }
}
function Prestationselect() {
    console.log("test");
    var checkBox1 = document.getElementById("Radio1_0");
    var checkBox2 = document.getElementById("Radio1_1");
    var checkBox3 = document.getElementById("Radio1_2");

    var Prestationfield = document.getElementById("AddingelementPrestation");
    var Articlesfield = document.getElementById("AddingelementArticles");
    var Hardwarefield = document.getElementById("AddingelementHardware");

    if (checkBox1.checked == true) {
        Prestationfield.style.display = "block";
    } else {
        Prestationfield.style.display = "none";
    }
    if (checkBox2.checked == true) {
        Articlesfield.style.display = "block";
    } else {
        Articlesfield.style.display = "none";
    }
    if (checkBox3.checked == true) {
        Hardwarefield.style.display = "block";
    } else {
        Hardwarefield.style.display = "none";
    }
}
function hiderule() {
    var checkBox = document.getElementById("arrowButton");
    var mydiv = document.getElementById("Morerulediv");
    if (checkBox.checked == true) {
        mydiv.style.display = "block";
    } else {
        mydiv.style.display = "none";
    }
}