var Home = function () {

    $(document).on("click", "#ayarlari_kaydet", function () {

        $("#ayarlari_kaydet").text("Kaydediliyor");
        var ayarId = parseInt($(this).data("id"));
        var galeriId = parseInt($("#galleryId").val());

        $.ajax({
            url: "/ayarlariKaydet?Id=" + ayarId + "&galeriId=" + galeriId,
            type: "POST",
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

