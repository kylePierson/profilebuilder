$(function () {

    $('#btnFileUpload1').fileupload({
        url: 'FileUploadHandler1.ashx?upload=start',
        add: function (e, data) {
            console.log('add', data);
            data.submit();
        },

        success: function (response, status) {

            console.log('success', response);
        },
        error: function (error) {

            console.log('error', error);
        }
    });

    $('#btnFileUpload2').fileupload({
        url: 'FileUploadHandler2.ashx?upload=start',
        add: function (e, data) {
            console.log('add', data);

            data.submit();
        },

        success: function (response, status) {


            console.log('success', response);
        },
        error: function (error) {

            console.log('error', error);
        }
    });

    $('#btnFileUpload3').fileupload({
        url: 'FileUploadHandler3.ashx?upload=start',
        add: function (e, data) {
            console.log('add', data);

            data.submit();
        },

        success: function (response, status) {
            $('#progressbar').hide();

            console.log('success', response);
        },
        error: function (error) {
            $('#progressbar').hide();

            console.log('error', error);
        }
    });
});