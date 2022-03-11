
function SaveCountry() {


    var test = $('#FCountry').serialize();
    //"ControllerName/methodname"
    debugger;

    var postCall = $.post(GetSiteURL() + "/Country/SaveCountry", $('#FCountry').serialize());
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

function DeleteCountry(Cid) {
    if (confirm('Are you sure want to delete this?')) {
        var postCall = $.post(GetSiteURL() + "/Country/DeleteCountry", { "Cid": Cid });
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


