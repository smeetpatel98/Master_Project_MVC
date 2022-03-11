$(document).ready(function () {
    LoadGroup();
});
function LoadGroup() {
    var postCall = $.post(GetSiteURL() + "/Course/GetAllCourse");
    postCall.done(function (data) {
        $('#Course').empty();
        $('#Course').select2();
        $("#Course").append("<option value=" + 0 + ">---Select Course Name---</option>");
        for (i = 0; i < data.length; i++) {
            $("#Course").append("<option value=" + data[i].Courseid + ">" + data[i].Coursename + "</option>");
        }
        if ($("#Courseid").val() != "") {
            $('#Course option[value="' + $("#Courseid").val() + '"]').attr("selected", "selected");
        }

    }).fail(function () {
        ShowMessage("An unexpected error occcurred while processing request!", "Error");
    });
}
$("#Course").change(function () {
    var Data = $("#Course option:selected").val();
    $('#Courseid').val(Data);

});

function SaveClass() {
    var test = $('#FClass').serialize();
                                  //"ControllerName/methodname"
    debugger;
    var postCall = $.post(GetSiteURL() + "/Class/SaveClass", $('#FClass').serialize());
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

function RemoveClass(Classid) {
    if (confirm('Are you sure want to delete this?')) {
        var postCall = $.post(GetSiteURL() + "/Class/RemoveClass", { "Classid": Classid });
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

function saveclass1() {
    var test = $('#FStudentGroup').serialize();
    var classs = $('#Classname').val();
    debugger;
    var postCall = $.post(GetSiteURL() + "/Class/SaveClass", { "Classname": classs });
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