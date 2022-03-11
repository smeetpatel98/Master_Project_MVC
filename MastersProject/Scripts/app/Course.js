
function SaveCourse() {
    var test = $('#FCourse').serialize();
    //"ControllerName/methodname"
    debugger;

    var postCall = $.post(GetSiteURL() + "/Course/SaveCourse", $('#FCourse').serialize());
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

function RemoveCourse(Courseid) {
    if (confirm('Are you sure want to delete this?')) {
        var postCall = $.post(GetSiteURL() + "/Course/RemoveCourse", { "Courseid": Courseid });
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

function savecourse1() {
    var test = $('#FStudentGroup').serialize();
    var course = $('#Coursename').val();
    debugger;
    var postCall = $.post(GetSiteURL() + "/Course/SaveCourse", { "Coursename": course });
    postCall.done(function (data) {
        if (data.Status == true) {
            ShowMessage(data.Message, 'Success');
            $("#save").closest("form").button();
        }
        else {
            ShowMessage(data.Message, "Error");
        }
    }).fail(function () {
        ShowMessage("UnExpected Error", "Error");
    });


}