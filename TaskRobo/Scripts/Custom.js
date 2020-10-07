$("#FormRegister").submit(() => {

    var email = $("#FormRegister [name = EmailId]").val();
    var password = $("#FormRegister [name = Password]").val();
    var confirmpassword = $("#FormRegister [ name = ConfirmPassword]").val();

    if (email == null || email == "") {
        alert("Enter Email Id");
        return false;
    }

    if (password == null || password == "") {
        alert("Enter Password");
        return false;
    }

    if (password != confirmpassword) {
        alert("Password and Confirm Password does not match");
        return false;
    }

    var emailvalidation = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;

    if (!emailvalidation.test(email)) {
        alert("This is an Invalid Email Id: " + email);
        return false;
    }
});