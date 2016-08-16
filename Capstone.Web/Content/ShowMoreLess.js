$(document).ready(function () {
   
    //$('#newsFeedStudent ul:lt(3)').show().slice(0, 3).each(function (index) {
    //    index.show();
    //});
    $('#newsFeedStudent ul:lt(3)').removeClass("hide");
    $('#showLess').hide();
  
    $('#loadMore').click(function () {
        $('#loadMore').hide();

        $('#newsFeedStudent ul').removeClass("hide");
    });

});