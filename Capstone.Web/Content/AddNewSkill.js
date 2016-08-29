$(document).ready(function () {
    $("#addStaffButton").click(function () {
            $.post("/Student/CreateStaffUser")           

    });

});
