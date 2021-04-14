function hidebutton() {
    var checkBox = document.getElementById("deletecheck");
    var text = document.getElementById("buttondelete");
    if (checkBox.checked == true) {
        text.style.display = "block";
    } else {
        text.style.display = "none";
    }
}