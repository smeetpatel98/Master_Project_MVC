$(document).ready(function () {
    LoadGroup1();
    //LoadGroup2();
    //LoadGroup3();
    LoadCountry();
    /*LoadState();*/
});
                   /*--------------------- *//*CourseJS*//*----------------------------------*/
function LoadGroup1() {
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
            LoadGroup2($("#Courseid").val());
        }

    }).fail(function () {
        ShowMessage("An unexpected error occcurred while processing request!", "Error");
    });
}
$("#Course").change(function () {
    var Data = $("#Course option:selected").val();
    $('#Courseid').val(Data);
    LoadGroup2(Data);

});

function LoadGroup2(Courseid) {
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
            LoadGroup3($("#Classid").val());
        }

    }).fail(function () {
        ShowMessage("An unexpected error occcurred while processing request!", "Error");
    });
}
$("#Class").change(function () {
    var Data = $("#Class option:selected").val();
    $('#Classid').val(Data);
    LoadGroup3(Data);
});

function LoadGroup3(Classid) {
    var postCall = $.post(GetSiteURL() + "/Subject/Sdata", {"Classid": Classid });
    postCall.done(function (data) {
        $('#Subject').empty();
        $('#Subject').select2();
        $("#Subject").append("<option value=" + 0 + ">---Select Subject Name---</option>");
        for (i = 0; i < data.length; i++) {
            $("#Subject").append("<option value=" + data[i].Subjectid + ">" + data[i].Subjectname + "</option>");
        }
        if ($("#Subjectid").val() != "") {
            $('#Subject option[value="' + $("#Subjectid").val() + '"]').attr("selected", "selected");
        }
    }).fail(function () {
        ShowMessage("An unexpected error occcurred while processing request!", "Error");
    });
}
$("#Subject").change(function () {
    var Data = $("#Subject option:selected").val();
    $('#Subjectid').val(Data);

});

                /*--------------------- *//*CountryJS*//*----------------------------------*/
function LoadCountry() {
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
            LoadState($("#Cid").val());
        }

    }).fail(function () {
        ShowMessage("An unexpected error occcurred while processing request!", "Error");
    });
}
$("#Country").change(function () {
    var Data = $("#Country option:selected").val();
    $('#Cid').val(Data);
    LoadState(Data);
});

function LoadState(Cid) {
    var postCall = $.post(GetSiteURL() + "/State/StateeData", { "Cid": Cid });
    postCall.done(function (data) {
        debugger
        $('#State').empty();
        $('#State').select2();
        $("#State").append("<option value=" + 0 + ">---Select State Name---</option>");
        for (i = 0; i < data.length; i++) {
            $("#State").append("<option value=" + data[i].Sid + ">" + data[i].Sname + "</option>");
        }
        if ($("#Sid").val() != "") {
            $('#State option[value="' + $("#Sid").val() + '"]').attr("selected", "selected");
            LoadCity($("#Sid").val());
        }

    }).fail(function () {
        ShowMessage("An unexpected error occcurred while processing request!", "Error");
    });
}
$("#State").change(function () {
    var Data = $("#State option:selected").val();
    $('#Sid').val(Data);
    LoadCity(Data);
});

function LoadCity(Sid) {
    var postCall = $.post(GetSiteURL() + "/City/cdata", { "Sid": Sid });
    postCall.done(function (data) {
        $('#City').empty();
        $('#City').select2();
        $("#City").append("<option value=" + 0 + ">---Select City Name---</option>");
        for (i = 0; i < data.length; i++) {
            $("#City").append("<option value=" + data[i].Cityid + ">" + data[i].Cityname + "</option>");
        }
        if ($("#Cityid").val() != "") {
            $('#City option[value="' + $("#Cityid").val() + '"]').attr("selected", "selected");
        }
    }).fail(function () {
        ShowMessage("An unexpected error occcurred while processing request!", "Error");
    });
}
$("#City").change(function () {
    var Data = $("#City option:selected").val();
    $('#Cityid').val(Data);

});

/*--------------------------------Save And Delete MethodJS--------------------------------------*/
function SaveStudent() {
    var test = $('#FStudentGroup').serialize();
    //"ControllerName/methodname"
    debugger;
    var postCall = $.post(GetSiteURL() + "/StudentList/SaveStudent", $('#FStudentGroup').serialize());
    postCall.done(function (data) {
        debugger;
        if (data.Status == true) {
            ShowMessage(data.Message, 'Success');
            setTimeout(function () { window.location.href = GetSiteURL() + '' + data.RedirectURL + ''; }, 200);          
        }
        else {
            ShowMessage(data.Message, "Error");
        }
    }).fail(function () {
        ShowMessage("UnExpected Error", "Error");
    });

}

function RemoveStudentList(Studentid) {
    if (confirm('Are you sure want to delete this?')) {
        var postCall = $.post(GetSiteURL() + "/StudentList/RemoveStudentList", { "Studentid": Studentid });
        postCall.done(function (data) {
            if (data.Status == true) {
                ShowMessage(data.Message, 'Success');
                setTimeout(function () { window.location.href = GetSiteURL() + '' + data.RedirectURL + ''; }, 2000);               
            }
            else {
                ShowMessage(data.Message, 'Error');
            }
        }).fail(function () {
            ShowMessage("An unexpected error occcurred while processing request!", "Error");
        });
    }
}

$(function () {
    $("#datepicker").datepicker({
        autoclose: true,
        todayHighlight: true,
        dateFormat: "dd-mm-yy",
        changemonth: true,
        changeyear: true
    }).datepicker('update', new Date());
});
