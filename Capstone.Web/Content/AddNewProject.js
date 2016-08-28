$(document).ready(function () {
    $("#addNewProject").click(function () {
        var newTitle = $("#newTitleTextbox").val();
        var newSummary = $("#newSummaryTextbox").val();
        if (newTitle) {
            var username = $("#hiddenusername1").val();
            var href = "/Student/DeleteProject?title=" + newTitle + "&username=" + username;
            var linkHtml = '<a href=' + href + '>Delete</a>';
            $("#projectList").append("<li>" + newTitle + "&nbsp;&nbsp;&nbsp;" + linkHtml + "<br />"+newSummary+"</li>")
            $.post("/Student/AddProject", { username: username, projectTitle: newTitle, summary: newSummary })
        }

    });

});