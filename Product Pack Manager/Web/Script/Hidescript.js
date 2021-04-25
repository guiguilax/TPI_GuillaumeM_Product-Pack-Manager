//hide the delete button
function hidebutton() {
    var checkBox = document.getElementById("deletecheck");
    var text = document.getElementById("buttondelete");
    if (checkBox.checked == true) {
        text.style.display = "block";
    } else {
        text.style.display = "none";
    }
}
//display only one dropdown at the time 
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
//hide rule for better readability 
function hiderule() {
    var checkBox = document.getElementById("arrowButton");
    var mydiv = document.getElementById("Morerulediv");
    if (checkBox.checked == true) {
        mydiv.style.display = "block";
    } else {
        mydiv.style.display = "none";
    }
}
//on the press of the button display either element either Link
function switchright() {
    var element = document.getElementById("Midzone");
    var link = document.getElementById("rightzone");
    if (element.style.display == "block") {
        element.style.display = "none";
        link.style.display = "block";
    } else {
        link.style.display = "none";
        element.style.display = "block";
    }
}