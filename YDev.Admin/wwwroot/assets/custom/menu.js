var Menu = function () {

    var updateOutput = function (e) {
        var list = e.length ? e : $(e.target),
            output = list.data('output');
        if (window.JSON) {
            output.val(window.JSON.stringify(list.nestable('serialize'))); //, null, 2));
        } else {
            output.val('JSON browser support required for this demo.');
        }
    };


    return {
        //main function to initiate the module
        init: function () {

            // activate Nestable for list 1
            //$('#nestable_list_1').nestable({
            //    group: 1
            //})
            //    .on('change', updateOutput);

            // activate Nestable for list 2
            $('#nestable_list_2').nestable({
                group: 1
            })
                .on('change', updateOutput);

            // activate Nestable for list 3
            $('#nestable_list_3').nestable({
                group: 1
            })
                .on('change', updateOutput);

            // output initial serialised data
            //updateOutput($('#nestable_list_1').data('output', $('#nestable_list_1_output')));
            updateOutput($('#nestable_list_2').data('output', $('#nestable_list_2_output')));
            updateOutput($('#nestable_list_3').data('output', $('#nestable_list_3_output')));

            $('#menu_kaydet').on('click', function (e) {
                var menuJson = $('#nestable_list_3_output').val();

                $.ajax({
                    url: "/MenuKaydet",
                    type: "POST",
                    data: menuJson,
                    contentType: "application/json",
                    success: function (data) {
                        if (data.isSuccess === true) {
                            toastr.success(data.message);
                        }
                        else {
                            toastr.error(data.message);
                        }

                    }
                });

            });

            $('#kategori_ekle').on('click', function (e) {
                var menuJson = $('#nestable_list_3_output').val();
                var categoryId = $("#categoryId").val();

                $.ajax({
                    url: "/MenuKategoriEkle?categoryId=" + categoryId,
                    type: "POST",
                    data: menuJson,
                    contentType: "application/json",
                    success: function (data) {
                        if (data.isSuccess === true) {
                            toastr.success(data.message);
                            document.location.href = "/menu"
                        }
                        else {
                            toastr.error(data.message);
                        }

                    }
                });

            });


            $('.removeMenu').on('click', function (e) {
                var menuJson = $('#nestable_list_3_output').val();
                var menuId = $(this).data("id");

                $.ajax({
                    url: "/MenuSil?menuId=" + menuId,
                    type: "POST",
                    data: menuJson,
                    contentType: "application/json",
                    success: function (data) {
                        if (data.isSuccess === true) {
                            toastr.success(data.message);
                            document.location.href = "/menu"
                        }
                        else {
                            toastr.error(data.message);
                        }

                    }
                });

            });



            $('#menu_kaydet_alt').on('click', function (e) {
                var menuJson = $('#nestable_list_2_output').val();

                $.ajax({
                    url: "/AltMenuKaydet",
                    type: "POST",
                    data: menuJson,
                    contentType: "application/json",
                    success: function (data) {
                        if (data.isSuccess === true) {
                            toastr.success(data.message);
                        }
                        else {
                            toastr.error(data.message);
                        }

                    }
                });

            });

            $('#kategori_ekle_alt').on('click', function (e) {
                var menuJson = $('#nestable_list_2_output').val();
                var categoryId = $("#categoryIdAlt").val();

                $.ajax({
                    url: "/AltMenuKategoriEkle?categoryId=" + categoryId,
                    type: "POST",
                    data: menuJson,
                    contentType: "application/json",
                    success: function (data) {
                        if (data.isSuccess === true) {
                            toastr.success(data.message);
                            document.location.href = "/menu"
                        }
                        else {
                            toastr.error(data.message);
                        }

                    }
                });

            });


            $('.removeMenuAlt').on('click', function (e) {
                var menuJson = $('#nestable_list_2_output').val();
                var menuId = $(this).data("id");

                $.ajax({
                    url: "/AltMenuSil?menuId=" + menuId,
                    type: "POST",
                    data: menuJson,
                    contentType: "application/json",
                    success: function (data) {
                        if (data.isSuccess === true) {
                            toastr.success(data.message);
                            document.location.href = "/menu"
                        }
                        else {
                            toastr.error(data.message);
                        }

                    }
                });

            });

        }

    }

}();

jQuery(document).ready(function () {
    Menu.init();
});