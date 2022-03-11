$(document).ready(function () {
    LoadGroup();
});
function LoadGroup() {
    var postCall = $.post(GetSiteURL() + "/Country/GetAllCountry");
    postCall.done(function (data) {
        $('#Country').empty();
        $('#Country').select2();
        $("#Country").append("<option value=" + 0 + ">---Select Country Name---</option>");
        for (i = 0; i < data.length; i++) {
            $("#Country").append("<option value=" + data[i].Cid + ">" + data[i].Cname + "</option>");
        }
        if ($("#Cid").val() != "") {
            $('#Country option[value="' + $("#Cid").val() + '"]').attr("selected", "selected");
        }

    }).fail(function () {
        ShowMessage("An unexpected error occcurred while processing request!", "Error");
    });
}
$("#Country").change(function () {
    var Data = $("#Country option:selected").val();
    $('#Cid').val(Data);

});

function SaveState() {
    var test = $('#FState').serialize();
    //"ControllerName/methodname"
    debugger;
    var postCall = $.post(GetSiteURL() + "/State/SaveState", $('#FState').serialize());
    postCall.done(function (data) {
        debugger;
        if (data.Status == true) {
            ShowMessage(data.Message, 'Success');
            setTimeout(function () { window.location.href = GetSiteURL() + '' + data.RedirectURL + ''; }, 200);
            // setTimeout(function () { location.reload(); }, 200);
        }
        else {
            ShowMessage(data.Message, "Error");
        }
    }).fail(function () {
        ShowMessage("UnExpected Error", "Error");
    });

}

function DeleteState(Sid) {
    if (confirm('Are you sure want to delete this?')) {
        var postCall = $.post(GetSiteURL() + "/State/RemoveState", { "Sid": Sid });
        postCall.done(function (data) {
            if (data.Status == true) {
                ShowMessage(data.Message, 'Success');
                setTimeout(function () { window.location.href = GetSiteURL() + '' + data.RedirectURL + ''; }, 2000);
                /*setTimeout(function () { location.reload(); }, 200);*/
            }
            else {
                ShowMessage(data.Message, 'Error');
            }
        }).fail(function () {
            ShowMessage("An unexpected error occcurred while processing request!", "Error");
        });
    }
}