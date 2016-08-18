$(document).ready(function () {
    $("#addNewSkill").click(function () {
        var newSkill = $("#newSkillTextbox").val();
        if (newSkill) {
            var username = $("#hiddenusername").val();
            $.post("/Student/AddNewSkill", { username: username, addSkill: newSkill })
        }

    });

});
