var Contact = function () {

    $(document).on("click", "#contact_save", function () {

        var model = {
            Name: $("#name").val(),
            ContactType: parseInt($("#contactType").val()),
            Address: $("#address").val(),
            Country: $("#country").val(),
            City:    $("#city").val(),
            Town:    $("#town").val(),
            Phone:   $("#phone").val(),
            Fax:     $("#fax").val(),
            EMail:   $("#email").val(),
            MapUrl:  $("#mapUrl").val(),
            Id: parseInt($(this).data("contact-id"))
        };
        if ($(this).data("contact-id") === 0) {
            $("#contact_save").text("Kaydediliyor");
        }
        else {
            $("#contact_save").text("Güncelleniyor");
        }

        $.ajax({
            url: "/adresKaydet",
            type: "POST",
            data: JSON.stringify(model),
            contentType: "application/json",
            success: function (data) {
                if (data.isSuccess === true) {
                    toastr.success(data.message);
                    setTimeout(function () {
                        document.location.href = "/iletisim";

                    }, 1000);
                }
                else {

                    toastr.error(data.message);
                    if ($(this).data("contact-id") === 0) {
                        $("#contact_save").text("Kaydet");
                    }
                    else {
                        $("#contact_save").text("Güncelle");
                    }
                }

            }
        });

    });

    $(document).on("click", ".editContact", function () {

        var contactId = $(this).data("contact-id");
        var contact = $(this).data("contact");

        $("#name").val(contact.Name);
        $("#contactType").val(contact.ContactType);
        $("#address").val(contact.Address);
        $("#country").val(contact.Country);
        $("#city").val(contact.City);
        $("#town").val(contact.Town);
        $("#phone").val(contact.Phone);
        $("#fax").val(contact.Fax);
        $("#email").val(contact.EMail);

        $("#contact_save").attr("data-contact-id", contactId);
        $("#contact_save").text("Güncelle");
        $("#vazgec").removeClass("hidden");

    });

    $(document).on("click", "#vazgec", function () {
   
        $("#name").val("");
        $("#contactType").val("");
        $("#address").val("");
        $("#country").val("");
        $("#city").val("");
        $("#town").val("");
        $("#phone").val("");
        $("#fax").val("");
        $("#email").val("");

        $("#contact_save").attr("category-id", "0");
        $("#contact_save").text("Kaydet");
        $("#vazgec").addClass("hidden");

    });

    return {
        //main function to initiate the module
        init: function () {

            

        }

    };

}();

jQuery(document).ready(function () {
    Contact.init();
});

