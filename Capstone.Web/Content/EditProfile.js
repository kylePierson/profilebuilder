$(document).ready(function () {

    //-------- edit experience
    $('#previousExperienceEditButton').click(function () {
        $("#previousExperienceEditButton").hide();
      
        $("[data-title='experience'].hide").removeClass("hide").addClass("show");     
        $("[data-title='experience'].visible").removeClass("visible").addClass("hide");
        

    });

    //---------edit summary------------
    $('#summaryEditButton').click(function () {
        var data = $("[data-title='summary'].visible").val()

       $("[data-title='summary'].hide").removeClass("hide").addClass("show");
       $("[data-title='summary'].visible").removeClass("visible").addClass("hide");
       $("#summaryEditButton").hide();

    });


    //---------edit contact info ------------
    $('#editContactInfoButton').click(function () {
       
        $("[data-title='contact'].hide").removeClass("hide").addClass("show");
        $("[data-title='contact'].visible").removeClass("visible").addClass("hide");

    });

    //---------edit academic degree ------------
    $('#academicDegreeEditButton').click(function () {
        
        $("[data-title='degree'].hide").removeClass("hide").addClass("show");
        $("[data-title='degree'].visible").removeClass("visible").addClass("hide");
        $('#academicDegreeEditButton').hide();
    });

});