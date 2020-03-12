var Social = function () {

    $(document).on("click", "#btn_saveSocial", function () {

        var model = [];

        $(".socialAccount").each(function (index) {

            var item = {
                Id: parseInt($(this).data("id")),
                SocialName: $(this).data("name"),
                Url: $(this).data("url"),
                Account: $(this).val()
            };

            model.push(item);
        });

        $("#btn_saveSocial").text("Kaydediliyor");

        $.ajax({
            url: "/socialSave",
            type: "POST",
            data: JSON.stringify(model),
            contentType: "application/json",
            success: function (data) {
                if (data.isSuccess === true) {
                    toastr.success(data.message);
                    setTimeout(function () {
                        document.location.href = "/sosyalmedya";

                    }, 1000);
                }
                else {

                    toastr.error(data.message);
                    $("#btn_saveSocial").text("Kaydet");
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
    Social.init();
});

