var Slider = function () {

    $(document).on("click", "#slider_kaydet", function () {

        var model = {
            Content: $("#content").val(),
            Order: parseInt($("#order").val()),
            Time: parseInt($("#time").val()),
            MediaUrl: $("#mediaUrl").val(),
            Link: $("#link").val(),
            Id: parseInt($(this).data("slider-id"))
        };
        if ($(this).data("slider-id") === 0) {
            $("#slider_kaydet").text("Kaydediliyor");
        }
        else {
            $("#slider_kaydet").text("Güncelleniyor");
        }

        $.ajax({
            url: "/sliderKaydet",
            type: "POST",
            data: JSON.stringify(model),
            contentType: "application/json",
            success: function (data) {
                if (data.isSuccess === true) {
                    toastr.success(data.message);
                    setTimeout(function () {
                        document.location.href = "/sliderlar";

                    }, 1000);
                }
                else {

                    toastr.error(data.message);
                    if ($(this).data("slider-id") === 0) {
                        $("#slider_kaydet").text("Kaydet");
                    }
                    else {
                        $("#slider_kaydet").text("Güncelle");
                    }
                }

            }
        });

    });

    $('.removeSlider').confirmation({

        onConfirm: function () {

            var sliderId = parseInt($(this).data("slider-id"));

            $.ajax({
                url: "/sliderSil?Id=" + sliderId,
                type: "POST",
                success: function (data) {
                    if (data.isSuccess === true) {
                        toastr.success(data.message);
                        setTimeout(function () {
                            document.location.href = "/sliderlar";

                        }, 1000);
                    }
                    else {

                        toastr.error(data.message);
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

        }

    };

}();

jQuery(document).ready(function () {
    Slider.init();
});

