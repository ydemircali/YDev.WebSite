var Home = function () {

    $(document).on("click", "#ayarlari_kaydet", function () {

        $("#ayarlari_kaydet").text("Kaydediliyor");

        var model = {
            HomeGalleryId: parseInt($("#galleryId").val()),
            Slogan: $("#slogan").val(),
            Id: parseInt($(this).data("id"))
        }; 

        $.ajax({
            url: "/ayarlariKaydet",
            type: "POST",
            data: JSON.stringify(model),
            contentType: "application/json",
            success: function (data) {
                if (data.isSuccess === true) {
                    toastr.success(data.message);
                    setTimeout(function () {
                        document.location.href = "/";

                    }, 1000);
                }
                else {

                    toastr.error(data.message);
                    $("#ayarlari_kaydet").text("Kaydet");
                }

            }
        });

    });


    return {
        //main function to initiate the module
        init: function () {



        }

    };

}();

jQuery(document).ready(function () {
    Home.init();
});

