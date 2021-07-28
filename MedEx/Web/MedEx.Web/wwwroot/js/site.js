// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// image validation

jQuery.validator.addMethod("dimention", function (value, element, param) {
    var width = $(element).data('imageWidth');
    var height = $(element).data('imageHeight');
    if (width == param[0] && height == param[1]) {
        return true;
    } else {
        return false;
    }
}, 'Image must be 340x340 pixels.');

jQuery.validator.addClassRules("nameExistErrClass", {
    dimention: [340, 340]
});
$('#files').change(function () {
    $('#files').removeData('imageWidth');
    $('#files').removeData('imageHeight');
    var file = this.files[0];
    var tmpImg = new Image();
    tmpImg.src = window.URL.createObjectURL(file);
    tmpImg.onload = function () {
        width = tmpImg.naturalWidth,
            height = tmpImg.naturalHeight;
        $('#files').data('imageWidth', width);
        $('#files').data('imageHeight', height);
    }
});

$('#img-form').validate({
    errorLabelContainer: '#errors',
    wrapper: 'li',
    submitHandler: function () {
        alert("successful submit");
        return false;
    }
});
