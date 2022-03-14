$(document).ready(function(){
    $(".form_button").on("click",validate);

    function validateEmail(email){
        var regex = /[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?/;
        return regex.test(String(email).toLowerCase());
    }

    function validateNickname(nickname){
        var otherCaseReg = /[!#$%&'*+/=?^_`{|}~]/;
        return !otherCaseReg.test(nickname)
        &&String(nickname).length > 6 
        && String(nickname).length < 20;
    }

    function validatePassword(password){
        var digitReg = /[0-9]/;
        var upperCaseReg = /[A-Z]/;
        var lowerCaseReg = /[a-z]/;
        var otherCaseReg = /[!#$%&'*+/=?^_`{|}~-]/;
        return password.length > 6 
        && digitReg.test(password)
        && lowerCaseReg.test(password)
        && upperCaseReg.test(password)
        && otherCaseReg.test(password);
    }

    function validateName(name){
        var otherCaseReg = /[!#$%&'*+/=?^_`{|}~]/;
        return  !otherCaseReg.test(name) &&
        String(name).length > 0;
    }

    function sendForm(){
        $(".sending_result").text("Успешно!").fadeIn();
    }

    function validate(){
        var login = $("#login").val();
        var $error_login = $(".error_login");
        var isNotValidate = false;
        if(!validateEmail(login)){
            $error_login.text("* Некорректно введённый email").fadeIn();
            isNotValidate = true;
        }
        else{
            $error_login.text("");
        }

        var name = $("#name").val();
        var $error_name = $(".error_name");
        if(!validateName(name)){
            $error_name.text("* Не введено имя").fadeIn();
            isNotValidate = true;
        }
        else{
            $error_name.text("");
        }

        var surname = $("#surname").val();
        var $error_surname = $(".error_surname");
        if(!validateName(surname)){
            $error_surname.text("* Не введена фамилия").fadeIn();
            isNotValidate = true;
        }
        else{
            $error_surname.text("");
        }

        var nickname = $("#nickname").val();
        var $error_nickname = $(".error_nickname");
        if(!validateNickname(nickname)){
            $error_nickname.text("* Придумайте другой никнейм").fadeIn();
            isNotValidate = true;
        }
        else{
            $error_nickname.text("");
        }

        var password = $("#password").val();
        console.log(password);
        var $error_password = $(".error_password");
        if(!validatePassword(password)){
            $error_password.text("* Пароль не соответствует требованиям безопасности").fadeIn();
            isNotValidate = true;
        }
        else{
            $error_password.text("");
        }

        if(isNotValidate){
            $(".sending_result").text(" * Валидация не пройдена. попробуйте ещё раз").fadeIn();
        }
        else{
            sendForm();
        }
        return false;
    }
});