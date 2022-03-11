function Login() {
    //var isSuccess = ValidateData('FormItem');
    $.post(GetSiteURL() + 'Login/ValidateUser', $('#formdata').serialize(), function (data) {
        if (data.Status == true) {
            ShowMessage(data.Message, 'Success');
            setTimeout(function () { window.location.href = GetSiteURL() + '' + data.RedirectURL + ''; }, 10);
        }
        else {
            ShowMessage(data.Message, 'Error');
        }
    }).fail(function (xhr) {
        $("#Username").val('');
        $("#Password").val('');
        $("#Username").focus();
        alert('Invalid Username or Password!');
    });
}
