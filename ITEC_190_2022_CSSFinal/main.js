"use strict"

/* If time - put images into array and streamline */

var trig1 = document.getElementById('trig1');
var trig2 = document.getElementById('trig2');
var trig3 = document.getElementById('trig3');
var trig4 = document.getElementById('trig4');
var trig5 = document.getElementById('trig5');
var ban1 = document.getElementById('banner');


trig1.addEventListener("mouseenter", function (event) {
    changeImage(1);
    //ban1.style.opacity = '1';
});
//trig1.addEventListener("mouseleave", function (event) {
//    ban1.style.opacity = '0';
//});
trig2.addEventListener("mouseenter", function (event) {
    changeImage(2);
    //ban1.style.opacity = '1';
});
//trig2.addEventListener("mouseleave", function (event) {
//    ban1.style.opacity = '0';
//});
trig3.addEventListener("mouseenter", function (event) {
    changeImage(3);
    //ban1.style.opacity = '1';
});
//trig3.addEventListener("mouseleave", function (event) {
//    ban1.style.opacity = '0';
//});
trig4.addEventListener("mouseenter", function (event) {
    changeImage(4);
    //ban1.style.opacity = '1';
});
//trig4.addEventListener("mouseleave", function (event) {
//    ban1.style.opacity = '0';
//});
trig5.addEventListener("mouseenter", function (event) {
    changeImage(5);
    //ban1.style.opacity = '1';
});
//trig5.addEventListener("mouseleave", function (event) {
//    ban1.style.opacity = '0';
//});

function changeImage(int) {
    var image = document.getElementById('banner');
    if (int == 1)
        image.src = "Images/burns.jpg";
    if (int == 2)
        image.src = "Images/yankic.jpg";
    if (int == 3)
        image.src = "Images/focus.jpg";
    if (int == 4)
        image.src = "Images/fabio.jpg";
    if (int == 5)
        image.src = "Images/oost1.jpg";
}

window.onload = function () {
    document.forms[0].onsubmit = function () {
        if (this.checkValidity()) alert("No invalid data detected. Will retain data for further testing.");
        return false;
    };
};