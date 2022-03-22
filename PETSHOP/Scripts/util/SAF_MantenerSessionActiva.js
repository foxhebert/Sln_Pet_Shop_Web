
var keepSessionAlive = false;
var keepSessionAliveUrl = null;



function CheckToKeepSessionAlive() {

    setTimeout("KeepSessionAlive()", 1 * 60 * 1000); //Cada 60 segundos
}

function SetupSessionUpdater(actionUrl) {

    keepSessionAliveUrl = actionUrl;
    var container = $("#body_tc");
    container.mousemove(function () { keepSessionAlive = true; });
    container.keydown(function () { keepSessionAlive = true; });
    CheckToKeepSessionAlive();

}


function KeepSessionAlive() {
    if (keepSessionAlive && keepSessionAliveUrl != null) {
        $.ajax({
            type: "POST",
            url: keepSessionAliveUrl,
            success: function () {
                //$('#mantenerSessionActiva').css('color', 'red');

                //$(".heartbeat").fadeIn(500, function () {
                //    $(".heartbeat").fadeOut(500);
                //});

                keepSessionAlive = false;
            }
        });
    }
    CheckToKeepSessionAlive();
}