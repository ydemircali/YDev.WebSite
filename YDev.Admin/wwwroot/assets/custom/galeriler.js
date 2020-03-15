var Galeriler = function () {

    $(document).on("click", "#galeri_kaydet", function () {

        var model = {
            Title: $("#title").val(),
            Content: $("#content").val(),
            Id: parseInt($(this).data("galeri-id"))
        };
        if ($(this).data("galeri-id") === 0) {
            $("#galeri_kaydet").text("Kaydediliyor");
        }
        else {
            $("#galeri_kaydet").text("Güncelleniyor");
        }

        $.ajax({
            url: "/galeriKaydet",
            type: "POST",
            data: JSON.stringify(model),
            contentType: "application/json",
            success: function (data) {
                if (data.isSuccess === true) {
                    toastr.success(data.message);
                    setTimeout(function () {
                        document.location.href = "/galeriler";

                    }, 1000);
                }
                else {

                    toastr.error(data.message);
                    if ($(this).data("galeri-id") === 0) {
                        $("#galeri_kaydet").text("Kaydet");
                    }
                    else {
                        $("#galeri_kaydet").text("Güncelle");
                    }
                }

            }
        });

    });

    $(document).on("click", ".editGaleri", function () {

        var categoryId = $(this).data("galeri-id");
        $("#title").val($(this).data("title"));
        $("#content").val($(this).data("content"));

        $("#galeri_kaydet").attr("data-galeri-id", categoryId);

        $("#galeri_kaydet").text("Güncelle");
        $("#vazgec").removeClass("hidden");

    });

    $(document).on("click", "#vazgec", function () {
   
        $("#title").val("");
        $("#content").val("");

        $("#galeri_kaydet").attr("galeri-id", "0");

        $("#galeri_kaydet").text("Kaydet");
        $("#vazgec").addClass("hidden");

    });

    $(document).on("click", "#medyaEkle", function () {

        var galeriId = parseInt($(this).data("galeri-id"))
        var model = {
            MediaId: parseInt($("#mediaId").val()),
            GalleryId: galeriId
        };

        $("#medyaEkle").text("Ekleniyor");

        $.ajax({
            url: "/galeriMedyaKaydet",
            type: "POST",
            data: JSON.stringify(model),
            contentType: "application/json",
            success: function (data) {
                if (data.isSuccess === true) {
                    toastr.success(data.message);
                    setTimeout(function () {
                        document.location.href = "/galeriDetay?galeriId=" + galeriId;

                    }, 1000);
                }
                else {

                    toastr.error(data.message);
                    $("#medyaEkle").text("<i class='fa fa-arrow-down'></i>Ekle");
                }

            }
        });

    });

    $(document).on("click", ".deleteMediaGallery", function () {

        var galeriMediaId = parseInt($(this).data("id"))
        var galeriId = parseInt($(this).data("galeri-id"))

        $("#deleteMediaGallery").attr("disabled", true);

        $.ajax({
            url: "/galeriMedyaSil?galeriMedyaId=" + galeriMediaId,
            type: "POST",
            contentType: "application/json",
            success: function (data) {
                if (data.isSuccess === true) {
                    toastr.success(data.message);
                    setTimeout(function () {
                        document.location.href = "/galeriDetay?galeriId=" + galeriId;

                    }, 1000);
                }
                else {
                    toastr.error(data.message);
                    $("#deleteMediaGallery").attr("disabled", false);
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
    Galeriler.init();
});

