$(document).ready(function () {
    LoadGroup1();
});
function LoadGroup1() {
    var postCall = $.post(GetSiteURL() + "/Course/GetAllCourse");
    postCall.done(function (data) {
        $('#Course').empty();
        $('#Course').select2();
        $("#Course").append("<option value=" + 0 + ">---Select Course Name---</option>");
        for (i = 0; i < data.length; i++) {
            $("#Course").append("<option value=" + data[i].Courseid + ">" + data[i].Coursename + "</option>");
        }
        if ($("#Cid").val() != "") {
            $('#Course option[value="' + $("#Courseid").val() + '"]').attr("selected", "selected");
            LoadGroup($("#Courseid").val());
        }

    }).fail(function () {
        ShowMessage("An unexpected error occcurred while processing request!", "Error");
    });
}
$("#Course").change(function () {
    var Data = $("#Course option:selected").val();
    $('#Courseid').val(Data);
    LoadGroup(Data);

});

function LoadGroup(Courseid) {
    var postCall = $.post(GetSiteURL() + "/Class/cdata", { "Courseid": Courseid });
    postCall.done(function (data) {
        $('#Class').empty();
        $('#Class').select2();
        $("#Class").append("<option value=" + 0 + ">---Select Class Name---</option>");
        for (i = 0; i < data.length; i++) {
            $("#Class").append("<option value=" + data[i].Classid + ">" + data[i].Classname + "</option>");
        }
        if ($("#Classid").val() != "") {
            $('#Class option[value="' + $("#Classid").val() + '"]').attr("selected", "selected");
        }

    }).fail(function () {
        ShowMessage("An unexpected error occcurred while processing request!", "Error");
    });
}
$("#Class").change(function () {
    var Data = $("#Class option:selected").val();
    $('#Classid').val(Data);

});


function SaveSubject() {
    var test = $('#FSubject').serialize();
    //"ControllerName/methodname"
    debugger;
    var postCall = $.post(GetSiteURL() + "/Subject/SaveSubject", $('#FSubject').serialize());
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

function RemoveSubjectList(Subjectid) {
    if (confirm('Are you sure want to delete this?')) {
        var postCall = $.post(GetSiteURL() + "/Subject/RemoveSubject", { "Subjectid": Subjectid });
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


function savesubject1() {
    var test = $('#FStudentGroup').serialize();
    var subject = $('#Subjectname').val();
    debugger;
    var postCall = $.post(GetSiteURL() + "/Subject/SaveSubject", { "Subjectname": subject });
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