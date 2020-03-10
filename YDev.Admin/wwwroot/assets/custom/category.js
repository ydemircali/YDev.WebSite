var Category = function () {

    $(document).on("click", "#kategori_kaydet", function () {

        var model = {
            Name: $("#name").val(),
            Link: $("#link").val(),
            Id: parseInt($(this).data("category-id"))
        };
        if ($(this).data("category-id") === 0) {
            $("#kategori_kaydet").text("Kaydediliyor");
        }
        else {
            $("#kategori_kaydet").text("Güncelleniyor");
        }

        $.ajax({
            url: "/kategoriKaydet",
            type: "POST",
            data: JSON.stringify(model),
            contentType: "application/json",
            success: function (data) {
                if (data.isSuccess === true) {
                    toastr.success(data.message);
                    setTimeout(function () {
                        document.location.href = "/kategoriler";

                    }, 1000);
                }
                else {

                    toastr.error(data.message);
                    if ($(this).data("category-id") === 0) {
                        $("#kategori_kaydet").text("Kaydet");
                    }
                    else {
                        $("#kategori_kaydet").text("Güncelle");
                    }
                }

            }
        });

    });

    $(document).on("click", ".editCategory", function () {

        var categoryId = $(this).data("category-id");
        var nameId = "name-" + categoryId;
        var linkId = "link-" + categoryId;
        $("#name").val($("#" + nameId).text());
        $("#link").val($("#" + linkId).text());

        $("#kategori_kaydet").attr("data-category-id", categoryId);

        $("#kategori_kaydet").text("Güncelle");
        $("#vazgec").removeClass("hidden");

    });

    $(document).on("click", "#vazgec", function () {
   
        $("#name").val("");
        $("#link").val("");

        $("#kategori_kaydet").attr("category-id", "0");

        $("#kategori_kaydet").text("Kaydet");
        $("#vazgec").addClass("hidden");

    });

    return {
        //main function to initiate the module
        init: function () {

            

        }

    };

}();

jQuery(document).ready(function () {
    Category.init();
});

