$(document).ready(function () {
    $("#addNewSkill").click(function () {
        var newSkill = $("#newSkillTextbox").val();
        if (newSkill) {
            var username = $("#hiddenusername").val();
            var href = "/Student/DeleteStudentSkill?skill=" + newSkill + "&username=" + username;
            var linkHtml = '<a href=' + href + '>Delete</a>';
            $("#skillList").append("<li>" + newSkill + "&nbsp;&nbsp;&nbsp;" + '<span style="position:absolute; right:50px">' + linkHtml + "</span></li>")
            $.post("/Student/AddNewSkill", { username: username, addSkill: newSkill })
        }
    });

});
