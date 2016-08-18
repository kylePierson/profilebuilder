$(document).ready(function () {

    //-------- edit experience
    $('#edit_div_1').click(function () {
      //  $('#editPreviousExperience').val($('#experienceSpan').val());
        $('.hide').removeClass("hide").addClass("show");
       
        $('.visible').removeClass("visible").addClass("hide");

    });

    //---------edit summary------------
    $('#summaryEditButton').click(function () {
       
        $('.hide').removeClass("hide").addClass("show");
        $('.visible').removeClass("visible").addClass("hide");

    });


    //---------edit contact info ------------
    $('#editContactInfoButton').click(function () {
       
        $('.hide').removeClass("hide").addClass("show");
        $('.visible').removeClass("visible").addClass("hide");

    });

    //---------edit academic degree ------------
    $('#academicDegreeEditButton').click(function () {

        $('.hide').removeClass("hide").addClass("show");
        $('.visible').removeClass("visible").addClass("hide");

    });

});