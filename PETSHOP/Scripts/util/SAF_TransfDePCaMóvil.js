

navigator.usb.getDevices()
    .then(devices => {
        console.log("Total devices: " + devices.length);
        devices.forEach(device => {
            console.log("Product name: " + device.productName + ", serial number " + device.serialNumber);
            alert('MOVIL USB CONECTADO');
        });
    });
//FUENTE: https://developer.mozilla.org/en-US/docs/Web/API/USB/getDevices


let args = [];
/**/
$('#btn-verificar-android-conectado').on('click', function () {

    $.post(
        //'/Transferencia/VerificarAndroidConectado2',
        //'/Transferencia/RegisterUsbDeviceNotification',
        '/Transferencia/botonBuscarUsbConectad',  
        {
           args //sinparametros
        },
        response => {

            //srtDirIpConCsharp = response;
            //alert(srtDirIpConCsharp);      

        });

});



//SWITCH
$('#switch_activoinactivo').html('<input type="checkbox" id="chk-switch_activoinactivo" class=" js-switch"  /> ');
$('#txt_conectado_desconectado').html('<label style="font-size:18px;" id="texto_activo_inactivo">MOVIL DESCONECTADO</label>');//<input type="checkbox" class=" js-switch" id="activo_mantenimiento" checked style="float:right;" />
$('#texto_activo_inactivo').css("color", "#949b9a");
$("#btn-verificar-android-conectado").attr("disabled", true);
switcheryLoad(); 


//INTERCABIAR TEXTOS SWITCH CONECTADO/DESCONECTADO ANDROID
//------------------------------------------------------------
$('#chk-switch_activoinactivo').on('change', function () {

    if ($("#chk-switch_activoinactivo").prop('checked') === true) {
            $("#texto_activo_inactivo").empty();
            $("#texto_activo_inactivo").append("  " + "MOVIL CONECTADO");
            $('#texto_activo_inactivo').css("color", "#26b99a");
            $("#btn-verificar-android-conectado").attr("disabled", false);
            
        }

    else if ($("#chk-switch_activoinactivo").prop('checked') === false) {
            $("#texto_activo_inactivo").empty();
            $("#texto_activo_inactivo").append("MOVIL DESCONECTADO");
            $('#texto_activo_inactivo').css("color", "#949b9a");
            $("#btn-verificar-android-conectado").attr("disabled", true);
        }
});


//icheck
function init_checkBox_styles() {
    if ($("input.flat")[0]) {
        $(document).ready(function () {
            $('input.flat').iCheck({
                checkboxClass: 'icheckbox_flat-blue',
                radioClass: 'iradio_flat-blue'
            });
        });
    }
}

// Switchery
function switcheryLoad() {

    if ($(".js-switch")[0]) {
        var elems = Array.prototype.slice.call(document.querySelectorAll('.js-switch'));
        elems.forEach(function (html) {
            //var switchery = new Switchery(html, {
            //    color: '#26B99A'
            //});
        });
    }

}
/*
$('#btn-verificar-android-conectado').on('click', function () {

    //function getMobileOperatingSystem() {
        var userAgent = navigator.userAgent || navigator.vendor || window.opera;

        if (userAgent.match(/iPad/i) || userAgent.match(/iPhone/i) || userAgent.match(/iPod/i)) {
            return 'ios';
        }
        else if (userAgent.match(/Android/i)) {
            return 'android';
        }
        else {
            return 'unknown';
        }
    //}



    ////var ua = navigator.userAgent.toLowerCase();
    ////var isAndroid = ua.indexOf("android") > -1; //&& ua.indexOf("mobile");
    ////if (isAndroid) {
    ////    alert('coneccion');
    ////    // Do something!
    ////    // Redirect to Android-site?
    ////    window.location = 'http://android.davidwalsh.name';
    ////}
});

*/
