$(document).ready(function () {
    $("#addNewInterset").click(function () {
        var addInterest = $("#newInterestTextbox").val();
        if (addInterest) {
            var username = $("#hiddenusername").val();
            $.post("/Student/AddNewInterest", { username: username, newInterest: addInterest })
        }

    });

});


