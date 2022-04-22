"use strict"

//Functions for AR Devices
function hololens() {
    document.getElementById("floatImg1").innerHTML = "<div class='player'><iframe class='player-iframe' frameBorder='0' src='https://www.youtube.com/embed/eqFqtAJMtYE'></iframe>";
}

function magicleap() {
    document.getElementById("floatImg2").innerHTML = "<div class='player'><iframe class='player-iframe' frameBorder='0' src='https://www.youtube.com/embed/3riUny4XWSg'></iframe>";
}

var acc1 = document.getElementsByClassName("accordion1");
var i;

for (i = 0; i < acc1.length; i++) {
    acc1[i].addEventListener("click", function () {
        /* Toggle between adding and removing the "active" class,
        to highlight the button that controls the panel */
        this.classList.toggle("active");

        /* Toggle between hiding and showing the active panel */
        var panel1 = this.nextElementSibling;
        if (panel1.style.display === "block") {
            panel1.style.display = "none";
        } else {
            panel1.style.display = "block";
        }
    });
}

var acc2 = document.getElementsByClassName("accordion2");
var x;
for (x = 0; x < acc2.length; x++) {
    acc2[x].addEventListener("click", function () {
        /* Toggle between adding and removing the "active" class,
        to highlight the button that controls the panel */
        this.classList.toggle("active");

        /* Toggle between hiding and showing the active panel */
        var panel2 = this.nextElementSibling;
        if (panel2.style.display === "block") {
            panel2.style.display = "none";
        } else {
            panel2.style.display = "block";
        }
    });
}