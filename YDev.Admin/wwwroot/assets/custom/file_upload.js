$(document).on("click", "#btn_file_upload", function () {

    var input = document.getElementById("select_file");
    var files = input.files;
    var formData = new FormData();

    for (var i = 0; i != files.length; i++) {
        formData.append("files", files[i]);
    }

    formData.append("content", $("#content").val());
    formData.append("url", $("#url").val());

    if (files.length > 0 || $("#url").val().length > 10) {

        $("#btn_file_upload").text("Lütfen Bekleyin");
        $("#btn_file_upload").attr("disabled", true);
        
        $.ajax(
            {
                url: "/FileUpload",
                data: formData,
                processData: false,
                contentType: false,
                type: "POST",
                success: function (data) {
                    if (data.isSuccess === true) {
                        toastr.success(data.message);
                        setTimeout(function () {
                            document.location.href = "/resimvideo";
                        }, 500);
                    }
                    else {
                        toastr.success(data.message);
                        $("#btn_file_upload").text("Kaydet");
                        $("#btn_file_upload").attr("disabled", false);
                    }
                  
                    
                }
            }
        );
    }

});

document.getElementById('links').onclick = function (event) {
    var className = $(event.target).attr('class');

    if (className === undefined)
    {
        event = event || window.event;
        var target = event.target || event.srcElement,
            link = target.src ? target.parentNode : target,
            options = { index: link, event: event },
            links = this.getElementsByTagName('a');
        blueimp.Gallery(links, options);
    }
};

$(document).on("click", "#delete-files", function () {
    var items = [];
    $("input:checked").each(function (index) {
        items.push($(this).data("id"));
    });

    if (items.length > 0) {
        $.ajax(
            {
                url: "deleteFiles",
                data: { 'filesRequest': items.join() },
                method: "POST",
                dataType:"json",
                success: function (data) {
                    toastr.success("Silme işlemi başarılı");
                    setTimeout(function () {
                        document.location.href = "/resimvideo";
                    }, 500);
                }
            }
        );
    }

});