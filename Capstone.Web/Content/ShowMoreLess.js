$(document).ready(function () {
    $('#newsFeedStudent ul li:lt(4)').show();
    $('#showLess').hide();
  
    //var shown = 8;
    //$('#loadMore').click(function () {
    //    $('#loadMore').hide();
    //    $('#showLess').show();
    //    shown = $('#newsFeedStudent li:visible').size() + 4;
    //    if (shown < items) { $('#newsFeedStudent li:lt(' + shown + ')').show(); }
    //    else {
    //        $('#newsFeedStudent li:lt(' + shown + 4 + ')').show();
    //        $('#loadMore').hide();
    //    }
    //});
    //$('#showLess').click(function () {
    //    $('#newsFeedStudent li').not(':lt(8)').hide();
    //});
});