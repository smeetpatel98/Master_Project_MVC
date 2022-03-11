$(document).ready(function () {
    LoadGroup1();
    
});
function LoadGroup1() {
    var postCall = $.post(GetSiteURL() + "/Country/GetAllCountry");
    postCall.done(function (data) {
        $('#Country').empty();
        $('#Country').select2();
        $("#Country").append("<option value=" + 0 + ">---Select Country Name---</option>");
        if (data != null) {
        for (i = 0; i < data.length; i++) {
            $("#Country").append("<option value='" + data[i].Cid + "'>" + data[i].Cname + "</option>");
            }
        }
        if ($("#Cid").val() != "") {
            $('#Country option[value="' + $("#Cid").val() + '"]').attr("selected", "selected");
            LoadGroup($("#Cid").val());
        }
    }).fail(function () {
        ShowMessage("An unexpected error occcurred while processing request!", "Error");
    });
}
$("#Country").change(function () {
    var Data = $("#Country option:selected").val();
    $('#Cid').val(Data);
    LoadGroup(Data);

});

function LoadGroup(Cid) {
    var postCall = $.post(GetSiteURL() + "/State/StateeData", { "Cid": Cid });
    postCall.done(function (data) {
        $('#State').empty();
        $('#State').select2();
        $("#State").append("<option value=" + 0 + ">---Select State Name---</option>");
        for (i = 0; i < data.length; i++) {
            $("#State").append("<option value=" + data[i].Sid + ">" + data[i].Sname + "</option>");
        }
        if ($("#Sid").val() != "") {
            $('#State option[value="' + $("#Sid").val() + '"]').attr("selected", "selected");
            
        }

    }).fail(function () {
        ShowMessage("An unexpected error occcurred while processing request!", "Error");
    });
}
$("#State").change(function () {
    var Data = $("#State option:selected").val();
    $('#Sid').val(Data);
});


function SaveCity() {
    var test = $('#FCity').serialize();
    //"ControllerName/methodname"
    debugger;
    var postCall = $.post(GetSiteURL() + "/City/SaveCity", $('#FCity').serialize());
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

function RemoveCity(Cityid) {
    if (confirm('Are you sure want to delete this?')) {
        var postCall = $.post(GetSiteURL() + "/City/RemoveCity", { "Cityid": Cityid });
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