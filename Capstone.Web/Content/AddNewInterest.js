$(document).ready(function () {
    $("#addNewInterset").click(function () {
        var interest = $("#newInterestTextbox").val();
        if (interest) {
            var username = $("#hiddenusername1").val();
            $.post("/Student/AddNewInterest", { username: username, newInterest: interest })
        }

    });

});


