function GetSiteURL() {

    var str = window.location.href;
    var res = str.split("/");
    var URL = '';
    if (res[2].toLowerCase() === 'localhost'.toLowerCase() || res[2].toLowerCase() === '127.0.0.1'.toLowerCase()) {
        URL = window.location.protocol + "//" + res[2].toLowerCase() + "/" + res[3].toLowerCase();
    }
    else {
        URL = window.location.protocol + "//" + res[2].toLowerCase() + "/";
    }
    SiteURL = URL;
    return URL;
}


$(document).ready(function () {
    $('#tblpag').DataTable({
        "bPaginate": true,
        "bLengthChange": true,
        "bFilter": true,
        "bInfo": true,
        "bAutoWidth": true,
        "bFixedHeader": true,
    });
});

function ShowMessage(message, messagetype, onClose) {
    var cssclass;
    $("#alert_container").show();
    switch (messagetype) {
        case 'Success':
            cssclass = 'alert-success'
            break;
        case 'Error':
            cssclass = 'alert-danger'
            break;
        case 'Warning':
            cssclass = 'alert-warning'
            break;
        default:
            cssclass = 'alert-info'
    }
    $('#alert_container').html('');
    $('#alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');
    setTimeout(function () { $("#alert_container").hide(); }, 4000);
}