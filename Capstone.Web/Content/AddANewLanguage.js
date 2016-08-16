function onSkillAdded(){
    location.reload();

}

$(document).ready(function () {
    $("#addskill").click(function () {
        var newSkill = $("#newLanguageTextbox").val();
        if (newSkill) {
            var username = $("#hiddenusername").val();
            $.post("/Employer/AddSkillInterested", {username: username, interest: newSkill}, onSkillAdded)
        }
             
    });

});
