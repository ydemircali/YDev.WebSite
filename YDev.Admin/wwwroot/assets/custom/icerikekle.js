var IcerikEkle = function () {

    $(document).on("click", "#icerik_kaydet", function () {

        var model = {
            Title: $("#title").val(),
            MenuId: parseInt($("#menuId").val()),
            CoverImage: $("#coverImage").val(),
            Spot: $("#spot").val(),
            Url: $("#url").val(),
            Html: $("#summernote_1").summernote('code'),
            Id: parseInt($(this).data("content-id"))
        };
        if ($(this).data("content-id") === 0) {
            $("#icerik_kaydet").text("Kaydediliyor");
        }
        else {
            $("#icerik_kaydet").text("Güncelleniyor");
        }
        
        $.ajax({
            url: "/icerikKaydet",
            type: "POST",
            data: JSON.stringify(model),
            contentType: "application/json",
            success: function (data) {
                if (data.isSuccess === true) {
                    toastr.success(data.message);
                    setTimeout(function () {
                        document.location.href = "/icerikler";

                    }, 1000);
                }
                else {

                    toastr.error(data.message);
                    if ($(this).data("content-id") === 0) {
                        $("#icerik_kaydet").text("Kaydet");
                    }
                    else {
                        $("#icerik_kaydet").text("Güncelle");
                    }
                }

            }
        });

    });

    $(document).on("click", "#icerik_temizle", function () {

        $('#summernote_1').summernote('reset');

    });

    $('.removeContent').confirmation({

        onConfirm: function () {

            var contentId = parseInt($(this).data("content-id"));

            $.ajax({
                url: "/icerikSil?contentId=" + contentId,
                type: "POST",
                success: function (data) {
                    if (data.isSuccess === true) {
                        toastr.success(data.message);
                        setTimeout(function () {
                            document.location.href = "/icerikler";

                        }, 1000);
                    }
                    else {

                        toastr.error(data.message);
                        if ($(this).data("content-id") === 0) {
                            $("#icerik_kaydet").text("Kaydet");
                        }
                        else {
                            $("#icerik_kaydet").text("Güncelle");
                        }
                    }

                }
            });

        },

        onCancel: function () {

        }
    });

    return {
        //main function to initiate the module
        init: function () {

            $('#summernote_1').summernote("code",$("#summernoteHtml").data("value"));  

        }

    };

}();

jQuery(document).ready(function () {
    IcerikEkle.init();
});

