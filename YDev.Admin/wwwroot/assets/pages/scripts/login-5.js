var Login = function () {

    $(document).on("click", "#btn_login", function () {

        var model = {
            Email: $("#email").val(),
            Password: $("#password").val()
        };

        $("#btn_login").text("Giriş Yapılıyor");

        $.ajax({
            url: "/Login",
            type: "POST",
            data: JSON.stringify(model),
            contentType: "application/json",
            success: function (data) {
                if (data.isSuccess === true) {
                    toastr.success(data.message);
                    setTimeout(function ()
                    {
                        document.location.href = "/";

                    }, 1000);
                }
                else {

                    toastr.error(data.message);
                }
               
            }
        });
        $("#btn_login").text("Giriş Yap");
    });



    var handleLogin = function () {

        $('#girisForm').validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-block', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            rules: {
                username: {
                    required: true
                },
                password: {
                    required: true
                },
                remember: {
                    required: false
                }
            },

            messages: {
                username: {
                    required: "E-posta zorunludur."
                },
                password: {
                    required: "Şifre zorunludur."
                }
            },

            invalidHandler: function(event, validator) { //display error alert on form submit   
                $('.alert-danger', $('#girisForm')).show();
            },

            highlight: function(element) { // hightlight error inputs
                $(element)
                    .closest('.form-group').addClass('has-error'); // set error class to the control group
            },

            success: function(label) {
                label.closest('.form-group').removeClass('has-error');
                label.remove();
            },

            errorPlacement: function(error, element) {
                error.insertAfter(element.closest('.input-icon'));
            },

            submitHandler: function(form) {
                
            }
        });

        $('#girisForm input').keypress(function(e) {
            if (e.which == 13) {
                if ($('#girisForm').validate().form()) {
                    $('#girisForm').submit(); //form validation success, call ajax form submit
                }
                return false;
            }
        });

        $('.forget-form input').keypress(function(e) {
            if (e.which == 13) {
                if ($('.forget-form').validate().form()) {
                    $('.forget-form').submit();
                }
                return false;
            }
        });

    }

 
  

    return {
        //main function to initiate the module
        init: function() {

            //handleLogin();

            // init background slide images
            $('.login-bg').backstretch([
                "../assets/pages/img/login/bg1.jpg",
                "../assets/pages/img/login/bg2.jpg",
                "../assets/pages/img/login/bg3.jpg"
                ], {
                  fade: 1000,
                  duration: 8000
                }
            );

            $('.forget-form').hide();

        }

    };

}();

jQuery(document).ready(function() {
    Login.init();
});