$(document).ready(function () {
    $("#addNewInterest").click(function () {
        var newInterest = $("#newInterestTextbox").val();
        if (newInterest) {
            var username = $("#hiddenusername1").val();
            var href = "/Student/DeleteStudentInterest?interest=" + newInterest + "&username=" + username;
            var linkHtml = '<a href=' + href + '>Delete</a>';
            $("#interestList").append("<li>" + newInterest + "&nbsp;&nbsp;&nbsp;" + '<span style="position:absolute; right:50px">' + linkHtml + "</span></li>")
            $.post("/Student/AddNewInterest", { username: username, addInterest: newInterest })
        }

    });

});


