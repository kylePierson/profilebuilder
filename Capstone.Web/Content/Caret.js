$(document).ready(function () {

    $("#skillsDropdown").on("click", function () {
        var current = $("#skillsCaret");
        if (current.hasClass("open")) {
            current.removeClass("open");
            console.log(current.hasClass("open"));
        }
        else {
            current.addClass("open");
            console.log(current.hasClass("open"));
        }
    });

    $("#interestsDropdown").on("click", function () {
        var current = $("#interestsCaret");
        if (current.hasClass("open")) {
            current.removeClass("open");
            console.log(current.hasClass("open"));
        }
        else {
            current.addClass("open");
            console.log(current.hasClass("open"));
        }
    });

    $("#summaryDropdown").on("click", function () {
        var current = $("#summaryCaret");
        if (current.hasClass("open")) {
            current.removeClass("open");
            console.log(current.hasClass("open"));
        }
        else {
            current.addClass("open");
            console.log(current.hasClass("open"));
        }
    });

    $("#projectsDropdown").on("click", function () {
        var current = $("#projectsCaret");
        if (current.hasClass("open")) {
            current.removeClass("open");
            console.log(current.hasClass("open"));
        }
        else {
            current.addClass("open");
            console.log(current.hasClass("open"));
        }
    });

    $("#infoDropdown").on("click", function () {
        var current = $("#infoCaret");
        if (current.hasClass("open")) {
            current.removeClass("open");
            console.log(current.hasClass("open"));
        }
        else {
            current.addClass("open");
            console.log(current.hasClass("open"));
        }
    });

    //document.getElementById('skillsDropdown').addEventListener('click', function () {
    //    [].slice.call(document.getElementsById('skillsCaret')).forEach(function (arrow) {
    //        arrow.classList.toggle('open');
    //    });
    //}, false);

    //document.getElementById('dropdown').addEventListener('click', function () {
    //    [].slice.call(document.getElementsById('skillsCaret')).forEach(function (arrow) {
    //        arrow.classList.toggle('open');
    //    });
    //}, false);

    //document.getElementById('dropdown').addEventListener('click', function () {
    //    [].slice.call(document.getElementsById('skillsCaret')).forEach(function (arrow) {
    //        arrow.classList.toggle('open');
    //    });
    //}, false);

    //document.getElementById('dropdown').addEventListener('click', function () {
    //    [].slice.call(document.getElementsById('skillsCaret')).forEach(function (arrow) {
    //        arrow.classList.toggle('open');
    //    });
    //}, false);

});