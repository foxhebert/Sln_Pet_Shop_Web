

const formatoFecha = 'DD/MM/YYYY'
let BitCheckAutentica = false;
let listaDeImpresoras;
let idRadioCheck;


/////////////////////////////////////////////////////////////////////////////////////////////
//ENVIAR POR CORREO LOS 04 EXCELS, ó 04 TXTs ó AMBOS TIPOS DE DOCUMENTOS EXPORTADOS
/////////////////////////////////////////////////////////////////////////////////////////////
$('#paper-plane-button-enviar-a-correos').on('click', function () {

       idRadioCheck = $(".disabled_enviar:checked").attr('id');
       
       if (typeof idRadioCheck == 'undefined') {
       
           new PNotify({
               title:'Envio de Correos',
               text: 'Seleccione una opción de envío.',
               type: 'info',
               delay: 3000,
               styling: 'bootstrap3',
               addclass: 'dark'
           });
       
           return;
       }    
       
       if (idRadioCheck == 'chck_excel') {
           //alert(idRadiocheck);
           Enviar_EXCELS_A_VARIOS_Correos();
       }
       if (idRadioCheck == 'chck_txt') {
           Enviar_EXCELS_A_VARIOS_Correos();
           //alert(idRadiocheck);
           //Enviar_TXT_A_VARIOS_Correos();
       }
       if (idRadioCheck == 'chck_todos') {
           //alert(idRadiocheck);
           //Enviar_EXCELS_A_VARIOS_Correos();
           Enviar_TXT_A_VARIOS_Correos();
       }

});


/////////////////////////////////////////////////////////////////////////////////////////////
//ACTUALIZAR
/////////////////////////////////////////////////////////////////////////////////////////////
$('#btn-update-configuracion').on('click', function () {
    ActualizarConfiguracionSaf();
});

/////////////////////////////////////////////////////////////////////////////////////////////
//ACTUALIZAR  Actualizar la tabla TSPARAMS - MANT. CONFIGURACION
/////////////////////////////////////////////////////////////////////////////////////////////
function ActualizarConfiguracionSaf()
{
    var SesionMovi = {
        IntIdMenu: 'M0314',
        intIdUsuario: idUsuar,
        intIdSoft: idSoftw,
        intIdSesion: intIdSe
    }

    ////////////////////////////////////////////////////////////////////////////
    //02
    var chk_prmAddOfic = "0";
    if ($('#chk_prmAddOfic').is(':checked') == true) {
        chk_prmAddOfic = "1";
    }
    //03
    var chk_prmAddResp = "0";
    if ($('#chk_prmAddResp').is(':checked') == true) {
        chk_prmAddResp = "1";
    }
    //04
    var chk_prmFilUbica = "0";
    if ($('#chk_prmFilUbica').is(':checked') == true) {
            chk_prmFilUbica = "1";
    }
    //06
    var chk_prmAreaxLocal = "0";
    if ($('#chk_prmAreaxLocal').is(':checked') == true) {
        chk_prmAreaxLocal = "1";
    }
    //08
    var chk_prmOutExcelxLocal = "0";
    if ($('#chk_prmOutExcelxLocal').is(':checked') == true) {
        chk_prmOutExcelxLocal = "1";
    }
    //
    var cbo_prmModaTrab = $('#cbo_prmModaTrab').val();
    if ($('#cbo_prmModaTrab').val() == 0 ) {
        cbo_prmModaTrab = "0";
    }
    else {

        cbo_prmModaTrab = "1";
    }

    var prmSalidaApp        =  $('#nueva_contrasena_1').val();     
    var prmAddOfic          =  chk_prmAddOfic;
    var prmAddResp          =  chk_prmAddResp;
    var prmFilUbica         =  chk_prmFilUbica;
    var prmOpcOpera         =  0;//chk_prmOpcOpera; ------Al final ---> EN DURO
    var prmAreaxLocal       =  chk_prmAreaxLocal;
    var prmModaTrab         =  cbo_prmModaTrab;
    var prmOutExcelxLocal   =  chk_prmOutExcelxLocal;
    var prmImpresora        =  $('#txt_prmImpresora').val();

    //alert('prmOutExcelxLocal  ' + prmOutExcelxLocal);
    //alert('chk_prmAreaxLocal  ' + prmAreaxLocal);

    //Ingresar Contraseña
    if (prmSalidaApp === "" && $('#ckbRequiereAutenticacion').is(':checked') == true) {
        new PNotify({
            title: 'Autenticación de Contraseña',
            text: "La contraseña es obligatoria.",
            type: "info",
            delay: 3000,
            styling: 'bootstrap3'
        });
        //$("#txt_prmSalidaApp").effect("highlight", { color: '#b8c5d275' }, 2000);
        return;
    }

    //Confirmar contraseña
    if ($('#nueva_contrasena_1').val() !== $('#nueva_contrasena_2').val()) {
        new PNotify({
            title: 'Configuración General',
            //text: "La Contraseñas no Coinciden.",
            text: "La contraseña no cumple con las políticas.",
            type: "error",
            delay: 3000,
            styling: 'bootstrap3'
        });

        //$("#txt_prmSalidaApp").effect("highlight", { color: '#b8c5d275' }, 2000).fadeIn('fast', function () { $("#txt_prmSalidaApp_confirmar").effect("highlight", { color: '#b8c5d275' }, 5250); });

        return;
    }

    let detalleSub=[];
    for (x in detalleSubs)
        detalleSub.push(detalleSubs[x].strEmail);//(x.strEmail); //detalleSubs[i];

    var strEmailDestino = detalleSub.join(";");


    swal({
        title: "Actualizar Configuración",
        text: "¿Está seguro de guardar los cambios?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sí",
        cancelButtonText: "No",
        allowOutsideClick: false, //añadido 25/03/2021
    }).then(function (isConfirm) {
        if (isConfirm) {      

            $.post(
                '/Configuracion/ActualizarDetalleConfigSaf',
                {
                      objSesion: SesionMovi
                    , prmSalidaApp
                    , prmAddOfic
                    , prmAddResp
                    , prmFilUbica
                    , prmOpcOpera
                    , prmAreaxLocal
                    , prmModaTrab
                    , prmOutExcelxLocal
                    , prmImpresora
                    , strEmailDestino
                    , strParametro: ''

                },
                (response) => {

                    console.log(response);
                    if (response.type !== '') {

                        if (response.type === 'success') {
                            new PNotify({
                                title: 'Actualización de Configuración del Sistema',
                                text: response.message,
                                type: response.type,
                                delay: 3000,
                                styling: 'bootstrap3'
                            });

                            document.getElementById("botonShowContasena_1").innerHTML = '<i class="fa fa-eye"></i>';
                            document.getElementById("nueva_contrasena_1").type = "password";
                            document.getElementById("botonShowContasena_2").innerHTML = '<i class="fa fa-eye"></i>';
                            document.getElementById("nueva_contrasena_2").type = "password";


                        }

                        else {
                            new PNotify({
                                title: 'Configuración',
                                text: response.message,
                                type: response.type,
                                delay: 3000,
                                styling: 'bootstrap3'
                            });
                            return;
                        }

                    }
                }
            ).fail(function (result) {
                alert('ERROR ' + result.status + ' ' + result.statusText);
            });
        }
    }, function (dismiss) {
            if (dismiss === 'cancel') { // you might also handle 'close' or 'timer' if you used those
            } if (dismiss === 'overlay') {
                //ignorar
            } else {
                throw dismiss;
            }
        }
        );
}


$('#botonShowContasena_1').html('');
$('#botonShowContasena_1').append('<i class="fa fa-eye"></i>');
$('#botonShowContasena_2').html('');
$('#botonShowContasena_2').append('<i class="fa fa-eye"></i>');

/////////////////////////////////////////////////////////////////////////////////////////////
//4.- Habilitar Controles contraseña
/////////////////////////////////////////////////////////////////////////////////////////////
$('#ckbRequiereAutenticacion').on('ifChanged', function () {

    if ($('#ckbRequiereAutenticacion').is(':checked') == true) {
        //////$('#txt_prmSalidaApp').attr('disabled', false);
        //////$('#txt_prmSalidaApp_confirmar').attr('disabled', false);
        //////$('#buttomShowPass1').attr('disabled', false);
        //////$('#buttomShowPass2').attr('disabled', false);
        ////////BitCheckAutentica = true;

        $('#nueva_contrasena_1').attr('disabled', false);
        $('#nueva_contrasena_2').attr('disabled', false);
        $('#botonShowContasena_1').attr('disabled', false);
        $('#botonShowContasena_2').attr('disabled', false);

        //INPUT 2 ps_edit_dos
        //OJO 2 buttomshowpassedit2
        //INPUT 2 ps_edit_tres  
        //OJO 2 buttomshowpassedit3
    }

    if ($('#ckbRequiereAutenticacion').is(':checked') == false) {

        $('#nueva_contrasena_1').val("");
        $('#nueva_contrasena_2').val("");
        $('#nueva_contrasena_1').attr('disabled', true);
        $('#nueva_contrasena_2').attr('disabled', true);
        $('#botonShowContasena_1').attr('disabled', true);
        $('#botonShowContasena_2').attr('disabled', true);

        $('#botonShowContasena_1').html('');
        $('#botonShowContasena_1').append('<i class="fa fa-eye"></i>');
        $('#botonShowContasena_2').html('');
        $('#botonShowContasena_2').append('<i class="fa fa-eye"></i>');

        //document.getElementById("buttomshowpassedit2").innerHTML = '<i class="fa fa-eye"></i>';
        //document.getElementById("nueva_contrasena_1").type = "password";
        //document.getElementById("buttomshowpassedit3").innerHTML = '<i class="fa fa-eye"></i>';
        //document.getElementById("nueva_contrasena_2").type = "password";

    }

    /*
    else
    {
        //INPUT 2 ps_edit_dos  #txt_prmSalidaApp
        //INPUT 2 ps_edit_tres  #txt_prmSalidaApp_confirmar

        $('#ps_edit_dos').val("");
        $('#ps_edit_tres').val("");

        $('#ps_edit_dos').attr('disabled', true);
        $('#ps_edit_tres').attr('disabled', true);
        $('#buttomshowpassedit2').attr('disabled', true);
        $('#buttomshowpassedit3').attr('disabled', true);


        //////$('#txt_prmSalidaApp').val("");
        //////$('#txt_prmSalidaApp_confirmar').val("");
        //////$('#txt_prmSalidaApp').attr('disabled', true);
        //////$('#txt_prmSalidaApp_confirmar').attr('disabled', true);
        //////$('#buttomShowPass1').attr('disabled', true);
        //////$('#buttomShowPass2').attr('disabled', true);
        ////////$('#txtContraseRemitente_').val("");
        ////////$('#txtContraseRemitente_').attr('disabled', true);
        ////////$('#buttomshowpass').attr('disabled', true);
        ////////BitCheckAutentica = false;
    }

    */
});

/////////////////////////////////////////////////////////////////////////////////////////////
//5.- Validar longitud de campos
/////////////////////////////////////////////////////////////////////////////////////////////
function ValidarCaracteresMaxlength() {

   $.post(
       '/Personal/MaestroMaximoCaracteres',
       { StrNomMan: 'TSPARAMS' },
       (response) => {
           response.forEach(element => {
   
               if (element.NombreColumna === 'prmSalidaApp') {

                   $('#' + element.NombreColumna + '').empty();
                   //$('#' + element.NombreColumna + '').append('<input type="password" id="ps_edit_dos" validationpass="false" class="form-control" maxlength="' + element.intNumero + '" autocomplete="current-password" placeholder="Contraseña" name="nuevacontraseña" onkeypress="return avoidSpaceInput(event)"><button id="buttomshowpassedit2" onclick="mostrarClaveEdit2(this)" type="button" class="buttom-show"><i class="fa fa-eye"></i></button>');
                   $('#' + element.NombreColumna + '').append('<input type="password" id="nueva_contrasena_1" validationpass="false" class="form-control" maxlength="' + element.intNumero + '" autocomplete="current-password" placeholder="Contraseña" name="nuevacontraseña" onkeypress="return avoidSpaceInput(event)"><button id="botonShowContasena_1" onclick="mostrarContrasenaConfi_1(this)" type="button" class="buttom-show"><i class="fa fa-eye"></i></button>');
                   //---> id="nueva_contrasena_1"  era id="ps_edit_dos"
                   //---> botonShowContasena_1     era  buttomshowpassedit2
                   $('#' + element.NombreColumna + '_confirmar' + '').empty();
                   //$('#' + element.NombreColumna + '_confirmar' + '').append('<input type="password" id="ps_edit_tres" validationpass="false" class="form-control" maxlength="' + element.intNumero + '"  required="" autocomplete="current-password" placeholder="Confirmar Contraseña" name="contraseña" onkeypress="return avoidSpaceInput(event)"><button id="buttomshowpassedit3" onclick="mostrarClaveEdit3(this)" type="button" class="buttom-show"><i class="fa fa-eye"></i></button>');
                   $('#' + element.NombreColumna + '_confirmar' + '').append('<input type="password" id="nueva_contrasena_2" validationpass="false" class="form-control" maxlength="' + element.intNumero + '"  required="" autocomplete="current-password" placeholder="Confirmar Contraseña" name="contraseña" onkeypress="return avoidSpaceInput(event)"><button id="botonShowContasena_2" onclick="mostrarContrasenaConfi_2(this)" type="button" class="buttom-show"><i class="fa fa-eye"></i></button>');

                   
               }


               //CONEXION BASE DE DATOS
               else if (element.NombreColumna === 'strServidor') {

                   $('#' + element.NombreColumna + '').empty();
                   $('#' + element.NombreColumna + '').append('<label>Servidor</label> <input type="text" id="txt_strServidor" class="form-control" maxlength="' + element.intNumero + '" placeholder="" onkeypress="return validarCampoIp(event)">');

               }

               else if
                (element.NombreColumna === 'strBaseDatos') {

                   $('#' + element.NombreColumna + '').empty();
                   $('#' + element.NombreColumna + '').append('<label>Base de Datos</label> <input type="text" id="txt_strBaseDatos" class="form-control" maxlength="' + element.intNumero + '" placeholder="" onkeypress="return avoidSpaceInput(event)">');
               }

               else if
                (element.NombreColumna === 'strUsuario') {

                   $('#' + element.NombreColumna + '').empty();
                   $('#' + element.NombreColumna + '').append('<label>Usuario </label> <input type="text" id="txt_strUsuario" class="form-control" maxlength="' + element.intNumero + '"  placeholder="" maxlength="50" required="" autocomplete="current-password" onkeypress="return avoidSpaceInput(event)">');
               }


               else if
                (element.NombreColumna === 'strDirExcelCarga') {

                   $('#' + element.NombreColumna + '').empty();
                   $('#' + element.NombreColumna + '').append('<input type="text" id="txt_strDirExcelCarga" class="form-control" maxlength="' + element.intNumero + '" placeholder="" required="" autocomplete="current-password" onkeypress="return avoidSpaceInput(event)">');
               }

               else if
                (element.NombreColumna === 'strExcelGenerado') {

                   $('#' + element.NombreColumna + '').empty();
                   $('#' + element.NombreColumna + '').append('<input type="text" id="txt_strExcelGenerado" class="form-control" maxlength="' + element.intNumero + '" placeholder="" required="" autocomplete="current-password" onkeypress="return avoidSpaceInput(event)">');
               }



   
           });

           //CargarConfiguracionConexionBaseDatos();
   
       });


   
}

/////////////////////////////////////////////////////////////////////////////////////////////
//CONTROL CONTRASEÑA 1
/////////////////////////////////////////////////////////////////////////////////////////////
function mostrarContrasenaConfi_1() {//--->mostrarClaveEdit2()
    const el = document.getElementById("botonShowContasena_1"); //---> buttomshowpassedit2
    const x = document.getElementById("nueva_contrasena_1");//---> id="nueva_contrasena_1"  id="ps_edit_dos"
    if (x.type === "password") {
        x.type = "text";
        el.innerHTML = '<i class="fa fa-eye-slash"></i>';
    } else {
        x.type = "password";
        el.innerHTML = '<i class="fa fa-eye"></i>';
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////
//CONTROL CONTRASEÑA 2
/////////////////////////////////////////////////////////////////////////////////////////////
function mostrarContrasenaConfi_2() {//mostrarClaveEdit3()
    const el = document.getElementById("botonShowContasena_2");//buttomshowpassedit3
    const x = document.getElementById("nueva_contrasena_2");//---> id="nueva_contrasena_2"  id="ps_edit_tes"
    if (x.type === "password") {
        x.type = "text";
        el.innerHTML = '<i class="fa fa-eye-slash"></i>';
    } else {
        x.type = "password";
        el.innerHTML = '<i class="fa fa-eye"></i>';
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////
//NUEVA CONTRASEÑA
/////////////////////////////////////////////////////////////////////////////////////////////
$('#nueva_contrasena_1').keyup(function () {
    // set password variable
    var pswd = $(this).val();
    var estate = false;
    var estateEspecial = false;
    //validate the length
    if (pswd.length < 8) {
        $('#length').show();
    } else {
        $('#length').hide();
    }

    //validate letra
    if (pswd.match(/[a-z]/)) {
        $('#letter').hide()
    } else {
        $('#letter').show();
    }

    //validate capital letter
    if (pswd.match(/[A-Z]/)) {
        $('#capital').hide();
    } else {
        $('#capital').show();
    }

    //validate number
    if (pswd.match(/\d/)) {
        $('#number').hide();
    } else {
        $('#number').show();
    }

    //validate number \@@
    if (pswd.includes('@') || pswd.includes('#') || pswd.includes('$') || pswd.includes('%') || pswd.includes('/') || pswd.includes('_') || pswd.includes('-') || pswd.includes('.') || pswd.includes('(') || pswd.includes(')') || pswd.includes('*') || pswd.includes('+')) {
        $('#especial').hide();
        estateEspecial = true;
    } else {
        $('#especial').show();
    }

    if (pswd.length >= 8 && pswd.match(/[a-z]/) && pswd.match(/[A-Z]/) && pswd.match(/\d/) && estateEspecial) {
        estate = true;
    }


    $(this).attr('validationpass', estate)
    if (estate) {
        $('#contraseValidate1').hide();
    } else {
        $('#contraseValidate1').show();
    }

})

$('#nueva_contrasena_2').keyup(function () {
 
    // set password variable
    var pswd = $(this).val();
    var estate = false;
    //validate the length
    //validate letra
    if (pswd == $("#nueva_contrasena_1").val()) {
        $('#igual').hide()
        estate = true;
    } else {
        $('#igual').show()
    }

    $(this).attr('validationpass', estate)
    if (estate) {
        $('#contraseValidate2').hide();
    } else {
        $('#contraseValidate2').show();
    }

})

/////////////////////////////////////////////////////////////////////////////////////////////
//LIMPIAR CONTROLES
/////////////////////////////////////////////////////////////////////////////////////////////
function limpiarControles() {

    //$('#checkBienes').prop('checked', this.checked); .prop('checked', this.checked);
    //$('#ckbRequiereAutenticacion').prop('unchecked', this.unchecked);
    $('#ckbRequiereAutenticacion').iCheck('uncheck');
    $('#nueva_contrasena_1').val('');
    $('#nueva_contrasena_2').val('');
    $('#chk_prmAddOfic').iCheck('uncheck');
    $('#chk_prmAddResp').iCheck('uncheck');
    $('#chk_prmFilUbica').iCheck('uncheck');
    $('#chk_prmAreaxLocal').iCheck('uncheck');
    $('#chk_prmOutExcelxLocal').iCheck('uncheck');
    $('#txt_prmImpresora').val('');
    $('#cbo_prmModaTrab').val(0);
    

}

/////////////////////////////////////////////////////////////////////////////////////////////
//6.- Configuracion Inicial
/////////////////////////////////////////////////////////////////////////////////////////////
function ConfiguracionCargaInicial() {
    //validarSession()
    //------------------------------
    limpiarControles();

    var intIdMenu = 0

    var SesionMovi = {
        IntIdMenu: 'M0314',
        intIdUsuario: idUsuar,
        intIdSoft: idSoftw,
        intIdSesion: intIdSe
    }

    //Aquí traer Lista de datos a mostrar en cada configuración
    $.post(
        //'/Configuracion/GetTablaConfiguracion',
        '/Configuracion/ListarConfigInicialSaf',
        { objSesion: SesionMovi, strCoConfi: '' },
        (response) => {

            response.forEach(element => {

                //----------------------------------------Contraseña
                if (element.prmSalidaApp !== "") {

                    $('#ckbRequiereAutenticacion').iCheck('check');
                    //$('#ckbRequiereAutenticacion').prop("checked", true);
                    $('#nueva_contrasena_1').val(element.prmSalidaApp);
                    $('#nueva_contrasena_2').val(element.prmSalidaApp);
                }

                else {
                    //$('#ckbRequiereAutenticacion').prop('checked', this.checked);
                    $('#ckbRequiereAutenticacion').iCheck('uncheck');
                    $('#nueva_contrasena_1').attr('disabled', true);
                    $('#nueva_contrasena_2').attr('disabled', true);
                }

                //----------------------------------------Oficina
                if (element.prmAddOfic == "1") {
                    $('#chk_prmAddOfic').iCheck('check');
                }
                else {
                    $('#chk_prmAddOfic').iCheck('uncheck');
                }

                //----------------------------------------Empleado
                if (element.prmAddResp == "1") {
                    $('#chk_prmAddResp').iCheck('check');
                }
                else {
                    $('#chk_prmAddResp').iCheck('uncheck');
                }

                //----------------------------------------Ubicacion
                if (element.prmFilUbica == "1") {
                    $('#chk_prmFilUbica').iCheck('check');
                }
                else {
                    $('#chk_prmFilUbica').iCheck('uncheck');
                }

                //----------------------------------------Area Por Local
                if (element.prmAreaxLocal == "1") {
                    $('#chk_prmAreaxLocal').iCheck('check');
                }
                else {
                    $('#chk_prmAreaxLocal').iCheck('uncheck');
                }
                //----------------------------------------Archivo Por Local
                if (element.prmOutExcelxLocal == "1") {
                    $('#chk_prmOutExcelxLocal').iCheck('check');
                }
                else {
                    $('#chk_prmOutExcelxLocal').iCheck('uncheck');
                }
                //----------------------------------------Impresora
                $('#txt_prmImpresora').val(element.prmImpresora);
                $('#cbo_prmModaTrab').val(parseInt(element.prmModaTrab));

                //var prmSalidaApp        =  $('#txt_prmSalidaApp').val();     
                //var prmAddOfic          =  chk_prmAddOfic;
                //var prmAddResp          =  chk_prmAddResp;
                //var prmFilUbica         =  chk_prmFilUbica;
                //var prmOpcOpera         =  0;
                //var prmAreaxLocal       =  chk_prmAreaxLocal;
                //var prmModaTrab         =  $('#cbo_prmModaTrab').val();
                //var prmOutExcelxLocal   =  chk_prmOutExcelxLocal;
                //var prmImpresora        =  $('#txt_prmImpresora').val();


                /********************************************************************

                ********************************************************************/


            });
        });



            TablaListarAgregarCorreos();
           

   


}

/////////////////////////////////////////////////////////////////////////////////////////////
//        VALIDAR CAMPO AGREGAR CORREO - 01
/////////////////////////////////////////////////////////////////////////////////////////////
function validateEmail(email) {
    const re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}

/////////////////////////////////////////////////////////////////////////////////////////////
//        VALIDAR CAMPO AGREGAR CORREO - 02
/////////////////////////////////////////////////////////////////////////////////////////////
function validate() {

    const $result = $("#result");
    const email = $("#txt_email_remitente").val();
    $result.text("");

    if (validateEmail(email)) {
        //$result.text(email + " es válido");
        //$result.css("color", "green");
    }

    else {
        //$result.text(email + " is not valid :(");
        //$result.css("color", "red");

        new PNotify({
            title: 'Agregar Correo',
            //text: email + ' no es válido',
            text: 'El Correo Electrónico Ingresado No es Válido.',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return false;

    }

    return true;
}

$("#validate").on("click", validate);




/*==============================================================
      LISTAR TABLA DE CORREOS AGREGADOS MANT. CONFIGURACION
================================================================*/
var _varTablaSubsiDet;// = $('#tabla-correos').DataTable();
var strEmailDestino;
function TablaListarAgregarCorreos() {//TablarReglaNegComSub3

    //var table = $('#tabla-correos').DataTable();

    //TRAER LOS CORREOS DESTINATARIOS
    $.post(
        '/Impresion/ListarTablasEnCombos',
        { strNomTablaEntidad: 'EMAIL_DESTINO' },
        (response) => {

            response.forEach(element => {

                strEmailDestino = element.strDeEntidad;

            });


            //CONSTUCTOR - AGREGAR CORREO AL ENTRAR AL MENU
            class TBCORREOS {
                constructor(

                    intEmail_,
                    strEmail_

                ) {
                    this.intEmail = intEmail_
                    this.strEmail = strEmail_
                }
            }





            //var strEmailDestino = strEmailDestino//"empleado_01@codbar.com; empleado_02@codbar.com;empleado_01@codbar.com";
            stringEmails.length = 0;//Limpiar el array
            stringEmails = strEmailDestino.split(";");

            detalleSubs.length = 0;//Limpiar el array
            var index;
            var intList = 1;
            for (index = 0; index < stringEmails.length; ++index) {

                detalleSubs.push(new TBCORREOS(intList, stringEmails[index]));
                intList = ++intList;

            }


            if (strEmailDestino == "") {

                $('#CHECK_TODOS_CORREOS').prop("disabled", true);
                detalleSubs.length = 0;

                /////////////////////////////////////////////////////////////////////////VACIO
                _varTablaSubsiDet = $('#tabla-correos').DataTable();

                if (typeof _varTablaSubsiDet !== 'undefined') {
                    _varTablaSubsiDet.destroy();
                }

                _varTablaSubsiDet = $('#tabla-correos').DataTable({
                    data: detalleSubs,
                    columns: [

                        {

                            sortable: false,
                            "render": (data, type, item, meta) => {
                                let intIdEmail = item.intEmail

                                return `<input type="checkbox" 
                                           class="icheckbox_flat-blue"
                                           id="Chck${intIdEmail}"
                                           data_intId="${intIdEmail}"
                                           data_intIdCorreo="${intIdEmail}"
                                           onChange="CheckedItemOneByOneFromListado(${intIdEmail})" 
                                           "                                           
                                        >`;
                            }



                        },

                        { data: 'strEmail' },

                        {
                            sortable: false,
                            "render": (data, type, item, meta) => {

                                let IntIdEmail = item.intEmail;

                                return `<button onclick='quitarFilaDeTablaSubsidio(this,"${IntIdEmail}")' class="btn btn-primary  btn-xs btn-delete" dataidServ="${IntIdEmail}"><i class="fa fa-trash-o"></i> ELiminar </button>  ` +
                                       `<button class="btn btn-primary btn-xs btn-resend" dataid="${item.strEmail}"><i style="cursor: pointer;" class="fa fa-paper-plane" aria-hidden="true"></i></button>`;

                            }
                        },


                    ],
                    lengthMenu: [5, 10, 25, 50],
                    order: [],
                    responsive: true,
                    language: _datatableLanguaje,
                    columnDefs: [

                    ],
                    dom: 'lBfrtip',
                });

                var table = $('#tabla-correos').DataTable();
                $("#total").html(table.rows().count())
                $('#txt_email_remitente').focus();
                $('#tabla-correos_filter .input-sm').css("width", "90px");
                $('#tabla-correos_filter').css("top", "470px");
                $('#tabla-correos_length select[name="tabla-correos_length"]').css("width", "60px");
                /////////////////////////////////////////////////////////////////////////VACIO


                ////////////    _varTablaSubsiDet.destroy();
                ////////////    //_varTablaSubsiDet = $('#tabla-correos').DataTable();
                ////////////    //AJUSTAR EL BUSACADOR "Search" con CSS BY JQUERY HGM 10.06.21
                ////////////    $('#txt_email_remitente').focus();
                ////////////    $('#tabla-correos_filter .input-sm').css("width", "90px");
                ////////////    $('#tabla-correos_filter').css("top", "470px");
                ////////////    $('#tabla-correos_length select[name="tabla-correos_length"]').css("width", "60px");

            }


            else {

                $('#CHECK_TODOS_CORREOS').prop("disabled", false);
                _varTablaSubsiDet = $('#tabla-correos').DataTable();

                if (typeof _varTablaSubsiDet !== 'undefined') {
                    _varTablaSubsiDet.destroy();
                }

                _varTablaSubsiDet = $('#tabla-correos').DataTable({
                    data: detalleSubs,
                    columns: [

                        {

                            sortable: false,
                            "render": (data, type, item, meta) => {
                                let intIdEmail = item.intEmail

                                return `<input type="checkbox" 
                                           class="icheckbox_flat-blue"
                                           id="Chck${intIdEmail}"
                                           data_intId="${intIdEmail}"
                                           data_intIdCorreo="${intIdEmail}"
                                           onChange="CheckedItemOneByOneFromListado(${intIdEmail})" 
                                           "                                           
                                        >`;
                            }



                        },

                        { data: 'strEmail' },

                        {
                            sortable: false,
                            "render": (data, type, item, meta) => {

                                let IntIdEmail = item.intEmail;

                                return `<button onclick='quitarFilaDeTablaSubsidio(this,"${IntIdEmail}")' class="btn btn-primary  btn-xs btn-delete" dataidServ="${IntIdEmail}"><i class="fa fa-trash-o"></i> ELiminar </button>  ` +

                                    `<button class="btn btn-primary btn-xs btn-resend" dataid="${item.strEmail}"><i style="cursor: pointer;" class="fa fa-paper-plane" aria-hidden="true"></i></button>`;

                            }
                        },


                        ////{
                        ////    sortable: false,
                        ////    render: (data, type, item, meta) => {
                        ////        return `<button class="btn btn-success btn-xs btn-edit" dataid="${item.intIdPersonal}" ><i class="fa fa-pencil"></i> Editar </button>
                        ////                        <button class="btn btn-primary btn-xs btn-delete" dataid="${item.intIdPersonal}" des_data="${item.strNombres}"  ><i class="fa fa-trash-o"></i> Eliminar </button>
                        ////                        <button class="btn btn-primary btn-xs btn-resend" dataid="${item.intIdPersonal}"><i style="cursor: pointer;" class="fa fa-paper-plane" aria-hidden="true"></i></button>
                        ////                        `
                        ////    },
                        ////},

                        ////{
                        ////    sortable: false,
                        ////    "render": (data, type, item, meta) => {
                        ////        let IntIdServ = item.intIdServicio;
                        ////        let strCoServ = item.strCoServicio;
                        ////        let StrDesServ = item.strDesServicio;
                        ////        let strDesTipSer = item.strDesTipServicio;
                        ////        let strDesTipMen = item.strDesTipMenu;
                        ////        return ` <label class="btn btn-primary btn-xs btn-añadir "  dataidServ="${IntIdServ}" ` +
                        ////            `datacose="${strCoServ}" datadesse="${StrDesServ}" ` +
                        ////            `datadestiser="${strDesTipSer}" datadestipmen="${strDesTipMen}" ` +
                        ////            ` > Agregar </label>`;
                        ////    }
                        ////}



                    ],
                    lengthMenu: [5, 10, 25, 50],
                    order: [],//1, 'asc'
                    responsive: true,
                    language: _datatableLanguaje,
                    columnDefs: [//ocultar y definir columnas 
                        //{
                        //    targets: [0],
                        //    visible: false,
                        //    searchable: false
                        //}
                    ],
                    dom: 'lBfrtip',
                });

                //////Esconde Cabecera de filtros
                ////$('#TablaDetReg_info').hide();
                ////$('#TablaDetReg_filter').hide();
                ////$('#TablaDetReg_length').hide();
                ////////$.unblockUI();            

                //AL cargarse la tabla el contador por default
                var table = $('#tabla-correos').DataTable();
                $("#total").html(table.rows().count())

                ////if (_varTablaSubsiDet.length < 1) {
                ////    $('#CHECK_TODOS_CORREOS').prop("disabled", false);
                ////}
                ////else {
                ////    $('#CHECK_TODOS_CORREOS').prop("disabled", true);
                ////}
                //    
                //alert('Rows ' + table.rows().count() + ' are selected'););
                //AJUSTAR PALABRAS DEMASIADO LARGAS EN EL LISTADO HGM
                //$('tbody tr td .child').css("color", "red");
                //$('tbody tr td').css("color", "green");
                //$('#tabla-correos_filter').css("top", "470px");
                //$('#tabla-correos_filter').css("top", "470px");
                //AJUSTAR EL BUSACADOR "Search" con CSS BY JQUERY HGM 10.06.21
                $('#txt_email_remitente').focus();
                $('#tabla-correos_filter .input-sm').css("width", "90px");
                $('#tabla-correos_filter').css("top", "470px");
                $('#tabla-correos_length select[name="tabla-correos_length"]').css("width", "60px");


            }

        });


}


/*====================================================================
      CHECKEAR CON CHECK "TODOS" DEL LISTADO DE MANT. CONFIGURACION
======================================================================*/
var intCorreos_checked = [];
$('#CHECK_TODOS_CORREOS').on('change', function () {

    intCorreos_checked = []; //Limpiar el array de check unitario

    //////////$(document).on('change', '.HorInd', function (event) {
    //////////    validarSession()
    //////////    let selectFilter = _tableCalculoManual.rows({ search: 'applied' }).nodes().to$().find('input:checked').length
    //////////    $("#seleccionados").html(selectFilter)
    //////////});

    var filasFiltradasDelListado = $("#tabla-correos").DataTable().rows({ filter: 'applied' }).nodes();//, search: 'applied' 
    if ($('#CHECK_TODOS_CORREOS').is(':checked')) {

        //Validar si el correo ya existe en la lista
        ////for (var i = 0; i < detalleSubs.length; i++) {
        ////    if (detalleSubs[i].strEmail === $(filasFiltradasDelListado[i]).find("td:eq(0) input").attr('data_intidpers') ) {
        ////        detalleSubs.splice(i, 1);
        ////        detalleSubs;
        ////    }
        ////}
        
        //////////////************************************************************************************
        for (var i = 0; i < filasFiltradasDelListado.length; i++) {

            intCorreos_checked.push(parseInt($(filasFiltradasDelListado[i]).find("td:eq(0) input").attr('data_intIdCorreo')));
            //////Obtener el ID de personal de cada fila de la PRIMERA COLUMNA e insertarlo en el objeto
            ////detalleSubs.push({ intEmail: $(filasFiltradasDelListado[i]).find("td:eq(0) input").attr('data_intIdCorreo') });
            ////detalleSubs;
        }

        ////////var names = []
        //////////for (x in filasFiltradasDelListado)
        //////////    names.push(filasFiltradasDelListado[x].strDescTipo);
        ////////var list_strTipo = names;
        //alert('cheched todos');
        //Marcar como seleccionado todos los inputs
        $(filasFiltradasDelListado).find('input[type="checkbox"]').prop('checked', true);



    }

    else {
        //dataConsumoGlobal2 = []; //Se limpia el array
        $(filasFiltradasDelListado).find('input[type="checkbox"]').prop('checked', false);

    }

    //CONTADOR DE CHECKEADOS
    var len = $(filasFiltradasDelListado).find("input:checkbox:checked").length;//LENGTH DE CHEKADAS
    $("#correos-seleccionados").html(len);
    var lentotal = $(filasFiltradasDelListado).find("input:checkbox").length;
    $("#total").html(lentotal);
    ////////////CONTADOR DE CHECKEADOS
    //////////var len = $(filasFiltradasDelListado).find("input:checkbox:checked").length;//LENGTH DE CHEKADAS
    ////////////alert(len);
    //////////$("#seleccionados2").html(len);

});


/*===================================================================
      CHECKEAR "ONE BY ONE" DEL LISTADO DE MANT. CONFIGURACION
=====================================================================*/
function CheckedItemOneByOneFromListado(intIdConsumo_p) {

    //////////////////////////////////////////////////////////////////////////////////////
    //Guarda en una variable a todos los registros que existen(tmb filtadas en la tabla y de todas las paginas)
    var filasFiltradasDelListado = $("#tabla-correos").DataTable().rows({ filter: 'applied' }).nodes();

    //Selecciona todos esos registros que tienen un input:checkbox:checked
    var lengthCheckados = $(filasFiltradasDelListado).find("input:checkbox:checked").length;
    //alert(lengthCheckados);
    //////////$("#seleccionados2").html(lengthCheckados);

    if (lengthCheckados < filasFiltradasDelListado.length) {
        //////////$("#seleccionados2").html(lengthCheckados);
        $('#CHECK_TODOS_CORREOS').prop('checked', false);
    }

    else if (lengthCheckados = filasFiltradasDelListado.length) {
        //////////$("#seleccionados2").html(lengthCheckados);
        $('#CHECK_TODOS_CORREOS').prop('checked', true);
    }

    //alert('Cantidad de items Checkeados: ' + intCorreos_checked.length);
    if ($('#Chck' + intIdConsumo_p + '').is(':checked') == true) {

        //Agregar el Item chekeado al Arreglo/Objeto "intCorreos_checked"
        intCorreos_checked.push(intIdConsumo_p);

        //if (dataConsumoGlobal_tmp.find(e => e.intIdConsumo == intIdConsumo_p)) {
        //    let position = dataConsumoGlobal_tmp.findIndex(e => e.intIdConsumo == intIdConsumo_p);
        //    if (!isNaN(position)) {
        //        dataConsumoGlobal.push(dataConsumoGlobal_tmp[position]);
        //    }
        //}
       

    }
    
    else if ($('#Chck' + intIdConsumo_p + '').is(':checked') == false) {


        //intCorreos_checked.splice(intIdConsumo_p);
        ////////////var array = [1, 2, 3, 4, 5, 6, 7, 8, 9, 0];
        //////////var filtrado = intCorreos_checked.filter(function (valoraaliminar, index, arr) {
        //////////    return valoraaliminar = intIdConsumo_p;
        //////////});
        //////////intCorreos_checked = filtrado;

        for (var i = 0; i < intCorreos_checked.length; i++) {

            if (intCorreos_checked[i] === intIdConsumo_p) {

                intCorreos_checked.splice(i, 1);
            }

        }


        //if (dataConsumoGlobal.find(e => e.intIdConsumo == intIdConsumo_p)) {
        //    let position = dataConsumoGlobal.findIndex(e => e.intIdConsumo == intIdConsumo_p);
        //    if (!isNaN(position)) {
        //        dataConsumoGlobal.splice(position, 1);
        //    }
        //}
        
    }


    //CONTADOR DE CHECKEADOS
    var len = $(filasFiltradasDelListado).find("input:checkbox:checked").length;//LENGTH DE CHEKADAS
    $("#correos-seleccionados").html(len);
    var lentotal = $(filasFiltradasDelListado).find("input:checkbox").length;
    $("#total").html(lentotal);


    //////////alert(intCorreos_checked.length + ' checkeados');    
    //intCorreos_checked.push(parseInt($(filasFiltradasDelListado[i]).find("td:eq(0) input").attr('data_intIdCorreo')));
    //////////////////////////////////////////////////////////////////////////////////////
}


/*===========================================================================================
    KEYUP DEPENDENCIA A LOS CHECKEADOS CUANDO SE BUSCA EN EL TEXTBOX "Search" DEL LISTADO
=============================================================================================*/
$(document).on('keyup', "#tabla-correos_filter input", function (event) {


    let texto = $(this).val()

    let selectFilter = _varTablaSubsiDet.rows({ search: 'applied' }).nodes().to$().find('input:checked').length//Chekceados

    if (!texto == "") {

        var totalFilter = _varTablaSubsiDet.rows({ order: 'index', search: 'applied' }).nodes().length//Filtrados
        $("#correos-seleccionados").html(selectFilter)
        $("#total").html(totalFilter)

    }

    else {

        var sinfiltro = $("#tabla-correos").DataTable().rows({ filter: 'applied' }).nodes().length;
        $("#correos-seleccionados").html(selectFilter)
        $("#total").html(sinfiltro);
    }

    //CAMBIAR LOS SELECCIONADOS en el objeto usado para enviar correos donde se almacena el str

    //let selectFilter1 = _varTablaSubsiDet.rows({ search: 'applied' }).nodes().to$().find('input:checked').Array();//Chekceados

    ////intCorreos_checked



    //01

    ////// Get the selected
    ////var row = $("#tabla-correos").column(0).checkboxes.selected();
    ////// Create variable for the ids array
    ////var selected_items = [];
    ////// Loop through to get the selected id
    ////$.each(row, function (index, rowId) {
    ////    //this add selected ID as object into array
    ////    selected_items.push({ id: rowId });
    ////});

   //////////////// var filasFiltradasDelListado = $("#tabla-correos").DataTable().rows({ filter: 'applied' }).nodes();
   //////////////// let valor = [];
   //////////////// //valor = $(filasFiltradasDelListado).find("input:checked").attr('data_intidcorreo');

   //////////////// //var valor = $(filasFiltradasDelListado).find("td:eq(0) input").attr('data_intidcorreo');

   //////////////// //02  
   ////////////////valor = $('#tabla-correos').DataTable().column(0).find("input").attr('data_intidcorreo').data().toArray();

    //////var tbl = $('#tabla-correos').DataTable();   
        
    //////var selectedIds = tbl.columns().checkboxes.selected()[0];
    ////////console.log(selectedIds)

    //////selectedIds.forEach(function (selectedId) {
    //////    alert(selectedId);
    //////});

    ////////////////////////////////var filasFiltradasDelListado = $("#tabla-correos").DataTable().rows({ filter: 'applied' }).nodes();

    ////////////////////////////////var len = $(filasFiltradasDelListado).find("input:checkbox:checked").val();//LENGTH DE CHEKADAS


    ////////////////////////////////var count = $('#tabla-correos').DataTable().rows('.selected').count();

    ////////////////////////////////var checked_rows = $('#tabla-correos').DataTable().rows('.selected').data();

    ////////////////////////////////for (var i = 0; i < checked_rows.length; i++) {
    ////////////////////////////////    console.log(checked_rows[i]);
    ////////////////////////////////}




    //datatable has to be initialized to a variable
    //////////////////var myTable = $('#tabla-correos').dataTable();

    ////////////////////checkboxes should have a general class to traverse
    //////////////////var rowcollection = myTable.$("input:checked", { "page": "all" }).attr('data_intidcorreo');

    //////////////////rowcollection.forEach(function (selectedId) {
    //////////////////    alert(selectedId);
    //////////////////});

    ////////////////////Now loop through all the selected checkboxes to perform desired actions
    //////////////////rowcollection.each(function (index, elem) {
    //////////////////    //You have access to the current iterating row
    //////////////////    var checkbox_value = $(elem).val();
    //////////////////    //Do something with 'checkbox_value'
    //////////////////});


    //////////02
    ////////var table = $('#tabla-correos').DataTable();
    ////////var plainArray = table
    ////////    .column(1)
    ////////    .data()
    ////////    .toArray();


    var selected_items = [];
    intCorreos_checked = [];

    let a_select = _varTablaSubsiDet.rows({ search: 'applied' }).nodes().to$().find('input[type="checkbox"]:checked');
    let a_select111 = $(_varTablaSubsiDet.cells().nodes()).find('input[type="checkbox"]:checked');
    a_select.toArray().forEach(x => {

        //var numberPattern = /\d+/g; 
        //'something102asdfkj1948948'.match(numberPattern)

        selected_items = $(x)[0].attributes['data_intidcorreo'].nodeValue;
        //dataPersonal.push({ intIdPersonal: $(x).attr('data_intidpers') })
        intCorreos_checked.push(parseInt(selected_items));

    })



    //APLICAR EL ONCHANGE AL CHECKBOX "TODOS"
    if (selectFilter < totalFilter) {
        //////////$("#seleccionados2").html(lengthCheckados);
        $('#CHECK_TODOS_CORREOS').prop('checked', false);
    }
    else if (selectFilter = totalFilter) {
        //////////$("#seleccionados2").html(lengthCheckados);
        $('#CHECK_TODOS_CORREOS').prop('checked', true);
    }



});


var operacion = "";
/*=================================================================================
      AGREGAR CON EL BOTON/ICONO "+" UN CORREO AL LISTADO DE MANT. CONFIGURACION
===================================================================================*/
var detalleSubs = new Array();
let stringEmails = new Array();
$('#btn-agregar-correo').on('click', function () {

    var agregar_email_remitente = $('#txt_email_remitente').val();

    //Campo "correo" vacío
    if (agregar_email_remitente == "") {

        new PNotify({
            title: 'Agregar Correo',
            text: 'Tiene que Ingresar un Correo Electrónico.',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }

    //Validar si lo ingresado es un texto del tipo "Correo Electrónico"
    let validate_ = validate(true);

    if (validate_== false) {

        return;
    }

    //Validar si el correo ya existe en la lista
    for (var i = 0; i < detalleSubs.length; i++) {

        if (detalleSubs[i].strEmail === agregar_email_remitente) {

            new PNotify({
                title: 'Agregar Correo',
                text: 'El Correo ' + '"' + agregar_email_remitente + '"' +' ya existe.',
                type: 'info',
                delay: 3000,
                styling: 'bootstrap3',
                addclass: 'dark'
            });

            return;           
        }
    }
    

    //CONSTUCTOR - AGREGAR CORREO
    class AGREGAR_CORREOS {
        constructor(

            intEmail_,
            strEmail_

        ) {
            this.intEmail = intEmail_
            this.strEmail = strEmail_
        }
    }


    var maximoIdExistente = Math.max.apply(Math, detalleSubs.map(function (o) { return o.intEmail; }));
    //alert(maximoIdExistente);
    //Al id maximi que existe le aumentamos uno para el correo nuevo aadido
    var intNewId = maximoIdExistente + 1;//Pendiente cambiar este ID

    detalleSubs.push(new AGREGAR_CORREOS(intNewId, agregar_email_remitente));

    ////TablaListarAgregarCorreos();
    operacion = "Agregar Correo";
    ActualizarCampoStrEmailDestino(operacion);

    ////$('#txt_email_remitente').val('');

    //var strEmailDestino = "empleado_01@codbar.com; empleado_02@codbar.com;empleado_01@codbar.com";
    //stringEmails.length = 0;//Limpiar el array
    //stringEmails = strEmailDestino.split(";");
    //detalleSubs.length = 0;//Limpiar el array
    //var index;
    //var intList = 1;
    //for (index = 0; index < stringEmails.length; ++index) {
    //    detalleSubs.push(new TBCORREOS(intList, stringEmails[index]));
    //    intList = ++intList;
    //}


    //stringEmails.forEach(function (entry) {
    //    detalleSubs.push(new TGREGLANEG_SUBSIDIO_DET(stringEmails));
    //});
    //var index;
    //var a = ["a", "b", "c"];
    //for (index = 0; index < a.length; ++index) {
    //    console.log(a[index]);
    //    detalleSubs.push(new TGREGLANEG_SUBSIDIO_DET( 2 , a[index]));
    //}

    ////TablarReglaNegComSub();
    //console.log(detalleSubs);
    /************************************************    
    var str = "This is an amazing sentence.";
    var words = str.split(" ");
    console.log(words);
    //["This", "is", "an", "amazing", "sentence."]
   *************************************************/

  /*************************************************/


});


/*===========================================================================
    E1.- ELIMINAR/REMOVER CON BOTON "Eliminar" UNA SOLA FILA SELECCIONADA 
==============================================================================*/
function quitarFilaDeTablaSubsidio(e, id_a_eliminar) {


    for (var i = 0; i < detalleSubs.length; i++) {

        if (detalleSubs[i].intEmail === parseInt(id_a_eliminar)) {

            str_correo_a_eliminar = detalleSubs[i].strEmail;
            //detalleSubs.splice(i, 1);
            //alert(str_correo_a_eliminar);
        }

    }


    /////////////////////////////////INI CONFIRM
    swal({
        title: "Eliminar Correo",
        text: '¿Está seguro que desea eliminar el correo: ' + '\n' + '"' + str_correo_a_eliminar + '" '+'?',
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sí",
        cancelButtonText: "No",
        allowOutsideClick: false,
    }).then(function (isConfirm) {
        if (isConfirm) {

 /////////////////////////////////INI CONFIRM

    for (var i = 0; i < detalleSubs.length; i++) {

        if (detalleSubs[i].intEmail === parseInt(id_a_eliminar)) {

            detalleSubs.splice(i, 1);
        }

    }

    /////////////////////////////
    EliminarCorreoSeleccionado();
    /////////////////////////////

 /////////////////////////////////FIN CONFIRM
            }
        }, function (dismiss) {
            if (dismiss === 'cancel') { // you might also handle 'close' or 'timer' if you used those
            } if (dismiss === 'overlay') {
                //ignorar
            } else {
                throw dismiss;
            }
        }
        );

  
    ////////const FuncionArray = (element) => element.intEmail === ide;
    ////////var index = detalleSubs.findIndex(FuncionArray);
    ////////if (index > -1) {
    ////////    detalleSubs.splice(index, 1)
    ////////    //$(e).parents('tr').remove(); //RETIRA LA FILA CON ESE ITEM DE LA TABLA
    ////////} //RETIRA EL ITEM DEL ARRAY

}


/*================================================================================
    E2.- ELIMINAR/REMOVER VARIOS CORREOS CON ICONO "-", SELECTED CON LOS CHECKS  
==================================================================================*/
$('#btn-quitar-correo').on('click', function () {
    ////////////alert(intCorreos_checked.length);
    //Cuando no se ha seleccionado ningun Check
    if (intCorreos_checked.length < 1) {

        new PNotify({
            title: 'Remover Correo',
            text: 'Tiene que Seleccionar un Correo Electrónico.',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }

    intCorreos_checked;//lista de ids a eliminar
    //detalleSubs = [];//elementos a eliminar
    //Devuelve un nuevo array con los id eliminados
    var newArrayConIdsEliminados = detalleSubs.filter(function (obj) {
        return intCorreos_checked.indexOf(obj.intEmail) === -1;
    });
    console.log(newArrayConIdsEliminados);
    intCorreos_checked = [];
    detalleSubs = newArrayConIdsEliminados;

    //Eliminar los seleccionados --> Este tipo de for tiene un bug que no llega a eliminar un elemento
    ////for (var i = 0; i < detalleSubs.length; i++) {

    ////    //var obj = detalleSubs[i];
    ////    if (intCorreos_checked.indexOf(detalleSubs[i].intEmail) !== -1) {
    ////        detalleSubs.splice(i, 1);
    ////    }
    ////    i--;//To fix the bug
    ////}

    //for (x in intCorreos_checked) {
    //    var obj = detalleSubs[x];
    //    if (intCorreos_checked.indexOf(obj.intEmail) !== -1) {
    //        detalleSubs.splice(x, 1);
    //    }
    //}   

    EliminarCorreoSeleccionado();



});


/*================================================================================
    E3.- IMINAR "UNO O VARIOS" CON ICONOS "-" "+" - FUNCION PRINCIPAL
==================================================================================*/
function EliminarCorreoSeleccionado() {

    var SesionMovi = {
        IntIdMenu: 'M0314',
        intIdUsuario: idUsuar,
        intIdSoft: idSoftw,
        intIdSesion: intIdSe
    }

    //Valores en duro. Solo se modificará un Campo
    var prmSalidaApp = "";
    var prmAddOfic = "1";
    var prmAddResp = "1";
    var prmFilUbica = "1";
    var prmOpcOpera = 0;
    var prmAreaxLocal = "1";
    var prmModaTrab = "0";
    var prmOutExcelxLocal = "1";
    var prmImpresora = "";;


    let detalleSub = [];
    for (x in detalleSubs)
        detalleSub.push(detalleSubs[x].strEmail);
    var strEmailDestino = detalleSub.join(";");


    $.post(
        '/Configuracion/ActualizarDetalleConfigSaf',
        {
            objSesion: SesionMovi
            , prmSalidaApp
            , prmAddOfic
            , prmAddResp
            , prmFilUbica
            , prmOpcOpera
            , prmAreaxLocal
            , prmModaTrab
            , prmOutExcelxLocal
            , prmImpresora
            , strEmailDestino
            , strParametro: 'ELIMINAR_CORREO_S'

        },
        (response) => {


            console.log(response);
            if (response.type !== '') {
                //alert('222');
                if (response.type === 'success') {


                    var tipo = 'Eliminado!';
                    if (response.type === 'error')
                        tipo = 'NO SE PUEDE ELIMINAR EL REGISTRO';
                    swal(tipo, response.message, response.type);

                    ////////////swal({
                    ////////////    title: 'Eliminar Correo',
                    ////////////    text: response.message,
                    ////////////});

                    //Deschekear Check "Todos"
                    $('#CHECK_TODOS_CORREOS').prop('checked', false);

                    intCorreos_checked = [];
                    TablaListarAgregarCorreos();

                    //let selectFilter = _varTablaSubsiDet.rows({ search: 'applied' }).nodes().to$().find('input:checked').length//Chekceados
                    $("#correos-seleccionados").html(0)


                }

                else {
                    new PNotify({
                        title: 'Eliminar Correo',
                        text: response.message,
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'
                    });
                    return;
                }


                if (response.type !== '') {

                    if (response.type === 'success') {


                    }

                    else if (response.type === 'info') {

                        new PNotify({
                            title: 'Configuración',
                            text: response.message,
                            type: response.type,
                            delay: 3000,
                            styling: 'bootstrap3'
                        });

                    }
                }

            }


        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });


}


/*==================================================================================
    A.- ENVIAR A UNO SOLO CORREO LOS EXCLES - MANT. CONFIGURACION
====================================================================================*/
$(`#tabla-correos tbody`).on('click', `tr button.btn-resend`, function () {
    var strEmailDestino = $(this).attr('dataid');

    idRadioCheck = $(".disabled_enviar:checked").attr('id');

    if (typeof idRadioCheck == 'undefined') {

        new PNotify({
            title: 'Envio de Correos',
            text: 'Seleccione una opción de envío.',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }
    else {

        //alert('continua envio unitario');
        GetListasDeTablasParaEnviarCorreo(strEmailDestino);
    }


})


/*==================================================================================
    B.- ENVIAR A VARIOS CORREOS LOS EXCLES - MANT. CONFIGURACION
====================================================================================*/
function Enviar_DOCUMENTOS_A_VARIOS_Correos() {    


    idRadioCheck = $(".disabled_enviar:checked").attr('id');

    if (typeof idRadioCheck == 'undefined') {

        new PNotify({
            title: 'Envio de Correos',
            text: 'Seleccione una opción de envío.',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }   


    if (intCorreos_checked.length < 1) {
        new PNotify({
            title:'Envio de Correos',
            text: "Tiene que seleccionar por lo menos un correo.",
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }

    //https://stackoverflow.com/questions/59676015/how-to-push-values-to-new-array-by-comparing-2-arrays
    //Filtrar en un nuevo arreglo los que se vaya seleccionado con los checks
    var newArray = new Array();
    detalleSubs.forEach(function (mainObject) {
        for (let i = 0; i < intCorreos_checked.length; i++) {
            if (intCorreos_checked[i] === mainObject.intEmail) {
                newArray.push(mainObject.strEmail);
            }
        }
    });


    //https://www.codegrepper.com/code-examples/javascript/opposite+of+split+in+javascript
    //Unir los correos seleccionados con punto y coma para usarlos en el parametro
    var strEmailsCheckeados = newArray.join(";");

    //Iniciamos ejecucion de Envio a los correos checkeados
    GetListasDeTablasParaEnviarCorreo(strEmailsCheckeados);

}





////////////////////////////////////////////////////////////////////////////////////////////////
//CONVERSION DE TIEMPO 
////////////////////////////////////////////////////////////////////////////////////////////////
var secondsToTime = function (s) {

    function addZ(n) {
        return (n < 10 ? '0' : '') + n;
    }

    var ms = s % 1000;
    s = (s - ms) / 1000;
    var secs = s % 60;
    s = (s - secs) / 60;
    var mins = s % 60;
    var hrs = (s - mins) / 60;

    return addZ(hrs) + 'h:' + addZ(mins) + 'm:' + addZ(secs) + 's';
};
//Variables Globales
var ajaxTime;

/*==================================================================================
    1.- TRAER LAS NUEVE TABLAS COMO LISTAS HASTA "ReportesCOntroller"  
====================================================================================*/
function GetListasDeTablasParaEnviarCorreo(strEmailDestino) {

    //$.blockUI({
    //    css: {
    //        border: 'none',
    //        padding: '15px',
    //        backgroundColor: '#000',
    //        '-webkit-border-radius': '10px',
    //        '-moz-border-radius': '10px',
    //        opacity: .5,
    //        color: '#fff'
    //    },
    //    message: 'Procesando Documentos...'
    //});

    var ajaxTimeComienzaConteo = new Date().getTime();
    ajaxTime = ajaxTimeComienzaConteo;
    totalTime = secondsToTime(new Date().getTime() - ajaxTime);
    //$("#tiempo").html(totalTime);
    $("#progresLoader").html("2%");
    $("#progresLoader").width("2%");


    $.post(
        '/Reportes/GetListasDeTablasParaEnviarCorreo',
        {
            strExcelExportado: "TBBIENES"
        },
         response => {
             totalTime = secondsToTime(new Date().getTime() - ajaxTime);
             //$("#tiempo").html(totalTime);
             $("#progresLoader").html("8%");
             $("#progresLoader").width("8%");
            $.post(
                '/Reportes/GetListasDeTablasParaEnviarCorreo',
                {
                    strExcelExportado: "TBBIENESDS"
                },
                response => {
                    $("#progresLoader").html("18%");
                    $("#progresLoader").width("18%");
                    $.post(
                        '/Reportes/GetListasDeTablasParaEnviarCorreo',
                        {
                            strExcelExportado: "TBOFICINA"
                        },
                        response => {
                            $("#progresLoader").html("27%");
                            $("#progresLoader").width("27%");
                            $.post(
                                '/Reportes/GetListasDeTablasParaEnviarCorreo',
                                {
                                    strExcelExportado: "TBEMPLEADO"
                                },
                                response => {
                                    $("#progresLoader").html("35%");
                                    $("#progresLoader").width("35%");
                                    ///////////////////////////////////////////////////////////////// 
                                    ////////DEPENDIENDO DEL CHECK SE CONTROLA CUAL DOCUMENTO SE ENVIA
                                    /////////////////////////////////////////////////////////////////                                    
                                    if (idRadioCheck == 'chck_excel') {
                                        GenerarBytesExcelParaEnviarPorCorreo(strEmailDestino);
                                    }
                                    if (idRadioCheck == 'chck_txt') {
                                        GenerarStringFilesParaEnviarTxt(strEmailDestino);
                                    }
                                    if (idRadioCheck == 'chck_todos') {
                                        GenerarBytesExcelAndStringsTxt(strEmailDestino);
                                    }
                                    /////////////////////////////////////////////////////////////////                                    

                                });

                        });

                });

         });


    return true;

}


/*==================================================================================
    2.- CONVERTIR ESAS LISTAS A BYTES PARA LUEGO LLEVARLO AL SERVICE
====================================================================================*/
function GenerarBytesExcelParaEnviarPorCorreo(strEmailDestino) {

    $.post(
        '/Reportes/GenerarBytesExcelParaEnviarPorCorreo',
        {
            strExcelExportado: "TBBIENES"
        },
        response => { 
            $("#progresLoader").html("41%");
            $("#progresLoader").width("41%");
            //strExcelExportado = "TBBIENESDS";
            $.post(
                '/Reportes/GenerarBytesExcelParaEnviarPorCorreo',
                {
                    strExcelExportado: "TBBIENESDS"
                },
                response => {
                    $("#progresLoader").html("49%");
                    $("#progresLoader").width("49%");
                    //strExcelExportado = "TBOFICINA";
                    $.post(
                        '/Reportes/GenerarBytesExcelParaEnviarPorCorreo',
                        {
                            strExcelExportado: "TBOFICINA"
                        },
                        response => {
                            $("#progresLoader").html("54%");
                            $("#progresLoader").width("54%");
                            //strExcelExportado = "TBEMPLEADO";
                            $.post(
                                '/Reportes/GenerarBytesExcelParaEnviarPorCorreo',
                                {
                                    strExcelExportado: "TBEMPLEADO"
                                },
                                response => {
                                    $("#progresLoader").html("62%");
                                    $("#progresLoader").width("62%");
                                    $.unblockUI();
                                    /////////////////////////////////////////////////
                                    comenzarEnvioDeCorreo(strEmailDestino)
                                    /////////////////////////////////////////////////

                                });

                        });

                });

        });

}


/*==================================================================================
    3.- COMENZAR ENVIO DE LOS 04 EXCELS AL CORREO SELECCIONADO
====================================================================================*/
function comenzarEnvioDeCorreo(strEmailDestino) {

    // let strEmailDestino = parseInt($(this).attr('dataid'));/*/*// detalleSubs; //"empleado_01@codbar.com; empleado_02@codbar.com;empleado_01@codbar.com";
    ////var strEmailDestino = $(this).attr('dataid');
    var unoovarios = "";
    if (strEmailDestino.indexOf(';') > -1) {
        ////alert(unoovarios);
        var unoovarios = "s";
    }

    $.ajax({
        //url: '/Reportes/EnviarCuatroExcelsPorCorreo', Se cambio por el siguiente
        url: '/Reportes/EnviarDocumentosExportadosPorCorreo', //(string strEmailDestino, string idRadioCheck)
        type: 'POST',
        data: {

            strEmailDestino,
            idRadioCheck 
        },
        beforeSend: function () {

            $("#progresLoader").html("78%");
            $("#progresLoader").width("78%");

            //$.blockUI({
            //    css: {
            //        border: 'none',
            //        padding: '15px',
            //        backgroundColor: '#000',
            //        '-webkit-border-radius': '10px',
            //        '-moz-border-radius': '10px',
            //        opacity: .5,
            //        color: '#fff'
            //    },
            //    message: 'Enviando Correo' + unoovarios + '...' // $.unblockUI();
            //});
        },
        success: function (response) {

            //TablaListarAgregarCorreos();
            ////intCorreos_checked = [];

            if (response.type !== '') {

                if (response.type === 'success') {

                    swal({
                        title: 'Correos Enviados',
                        text: response.message,//$('#cbo_formatos option:selected').text() + 
                        //text:  $('#cbo_formatos option:selected').text() + " no existe, por favor crearlo dentro de la carpeta Formatos "+ +" con el mismo nombre seleccionado",
                        //timer: 2000,
                    });

                    $("#progresLoader").html("100%");
                    $("#progresLoader").width("100%");
                }

                else if (response.type === 'info') {

                    new PNotify({
                        title: 'Configuración',
                        text: response.message,
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'
                    });

                    $("#progresLoader").html("100%");
                    $("#progresLoader").width("100%");

                }
            }

            ////////////////////// 
            ////////////////////$.post(
            ////////////////////    '/Reportes/eliminarTodoExcel',//'/Personal/eliminarTodoExcel',
            ////////////////////    {
            ////////////////////        //sinparametros
            ////////////////////    },
            ////////////////////    response => {
            ////////////////////        ////alert('Eliminacion Exitosa');
            ////////////////////    });


        },
        complete: function () {

            $.unblockUI();
        }
    })


}


/*==================================================================================
    4.-  Actualizar el Listado "Correos"y la Tabla TSPARAMS - MANT. CONFIGURACION
====================================================================================*/
function ActualizarCampoStrEmailDestino(operacion) {
    ////////alert('ActualizarCampoStrEmailDestino');
    var SesionMovi = {
        IntIdMenu: 'M0314',
        intIdUsuario: idUsuar,
        intIdSoft: idSoftw,
        intIdSesion: intIdSe
    }

    //Valores en duro. Solo se modificará un Campo
    var prmSalidaApp      = "";
    var prmAddOfic        = "1";
    var prmAddResp        = "1";
    var prmFilUbica       = "1";
    var prmOpcOpera       =  0;
    var prmAreaxLocal     = "1";
    var prmModaTrab       = "0";
    var prmOutExcelxLocal = "1";
    var prmImpresora      = "";;


    let detalleSub = [];
    for (x in detalleSubs)
        detalleSub.push(detalleSubs[x].strEmail);

    var strEmailDestino = detalleSub.join(";");

    ///////////////////////////////////////////////////////INI CONFIRM
    //////////////////////swal({
    //////////////////////    title: "Actualizar Correos",
    //////////////////////    text: "¿Está seguro de guardar los cambios?",
    //////////////////////    type: "warning",
    //////////////////////    showCancelButton: true,
    //////////////////////    confirmButtonText: "Sí",
    //////////////////////    cancelButtonText: "No",
    //////////////////////    allowOutsideClick: false,
    //////////////////////}).then(function (isConfirm) {
    //////////////////////    if (isConfirm) {

/////////////////////////////////////////////////////////INI POST
            $.post(
                '/Configuracion/ActualizarDetalleConfigSaf',
                {
                      objSesion: SesionMovi
                    , prmSalidaApp
                    , prmAddOfic
                    , prmAddResp
                    , prmFilUbica
                    , prmOpcOpera
                    , prmAreaxLocal
                    , prmModaTrab
                    , prmOutExcelxLocal
                    , prmImpresora
                    , strEmailDestino
                    , strParametro: 'AGREGAR_CORREO'

                },
                (response) => {


                    console.log(response);
                    if (response.type !== '') {

                        if (response.type === 'success') {

                            ////swal({
                            ////    title: operacion,
                            ////    text: response.message,
                            ////});

                            new PNotify({
                                title: 'Agregar Correo',
                                text: response.message,
                                type: response.type,
                                delay: 3000,
                                styling: 'bootstrap3'
                            });

                            $('#txt_email_remitente').val('');
                            $('#CHECK_TODOS_CORREOS').prop('checked', false);
                            TablaListarAgregarCorreos();

                        }

                        else {
                            new PNotify({
                                title: 'Actualización de Correos',
                                text: response.message,
                                type: response.type,
                                delay: 3000,
                                styling: 'bootstrap3'
                            });
                            return;
                        }


                        if (response.type !== '') {

                            if (response.type === 'success') {


                            }

                            else if (response.type === 'info') {

                                new PNotify({
                                    title: 'Configuración',
                                    text: response.message,
                                    type: response.type,
                                    delay: 3000,
                                    styling: 'bootstrap3'
                                });

                            }
                        }

                    }


                }
            ).fail(function (result) {
                alert('ERROR ' + result.status + ' ' + result.statusText);
            });
/////////////////////////////////////////////////////////FIN POST

    //////////////////////    }
    //////////////////////}, function (dismiss) {
    //////////////////////    if (dismiss === 'cancel') { // you might also handle 'close' or 'timer' if you used those
    //////////////////////    } if (dismiss === 'overlay') {
    //////////////////////        //ignorar
    //////////////////////    } else {
    //////////////////////        throw dismiss;
    //////////////////////    }
    //////////////////////}
    //////////////////////);
    ///////////////////////////////////////////////////////FIN CONFIRM


}


/*==================================================================================
    5.-  CONSEGUIR LISTA DE IMPRESORAS - MANT. CONFIGURACION
====================================================================================*/
$('#btn-listar-impresoras').on('click', function () {

    $.blockUI({
        css: {
            border: 'none',
            padding: '15px',
            backgroundColor: '#000',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: .5,
            color: '#fff'
        },
        message: 'Procesando' // 
    });


    $('#option_lista_impresoras').empty();

    $.post(
        '/Configuracion/ListarImpresorasSaf',
        {
            //sinparametros
        },
        response => {            

            listaDeImpresoras = response;

            if (listaDeImpresoras.length < 1) {

                new PNotify({
                    title: 'Configuración',
                    text: 'No existe ninguna Impresora instalada en esta PC .',
                    type: 'info',
                    delay: 2000,
                    styling: 'bootstrap3',
                    addclass: 'dark'
                });
                //$('#prop_cerrar_modal').click();
                return;
            }

            else {
                //MOSTRAR IMPRESORAS DENTRO DEL TEXTAREA POR CADA OBSERVADO
                var i = 0;
                for (i = 0; i < listaDeImpresoras.length; i++) {
                
                        var text = listaDeImpresoras[i];// + "<br>";
                        $("#option_lista_impresoras").append('<option >' + text +'</option>');             
                         //listaInconsist = [];             
                }

                $('#option_lista_impresoras').show();
                $('#prop_abrir_modal').click();                
                
            }
            $.unblockUI();

    
        });  


});


/*==================================================================================
    6.-  SELECCIONAR IMPRESORA - MANT. CONFIGURACION
====================================================================================*/
$('#btn-seleccionar-impresora').on('click', function () {

    var PrinterText = $('#option_lista_impresoras :selected').text();

    if (PrinterText == "") {

        new PNotify({
            title: 'Configuración',
            text: 'Seleccione una Impresora.',
            type: 'info',
            delay: 2000,
            styling: 'bootstrap3',
            //addclass: 'dark'
        });
        return;
    }
    //alert(PrinterText);

    $('#txt_prmImpresora').val(PrinterText);

    //https://stackoverflow.com/questions/11821261/how-to-get-all-selected-values-from-select-multiple-multiple

});


/////////////////////////////////////////////////////////////////////////////////////////////
// REQUERIMIENTO -----> CONEXION A BASE DE DATOS
//  7.-  Check Ratio Onchange Contraseña Validaciones
/////////////////////////////////////////////////////////////////////////////////////////////
$('#txt_strContrasenia').attr('disabled', 'disabled');
$('#buttomshowpass').attr('disabled', 'disabled');
$('#chck_windows').on('ifChanged', function () {
    //Windows Checkeado SI se Ingresa Contraseña
    if ($('#chck_windows').is(':checked') == true) {
        //alert('windows true, Ingrese solo usuario');
        $('#txt_strUsuario').removeAttr('disabled');
        $('#txt_strContrasenia').attr('disabled', 'disabled');
        $('#buttomshowpass').attr('disabled', 'disabled');
    }
    //SQL Checkeado NO se Ingresa Contraseña
    if ($('#chck_windows').is(':checked') == false) {
        //alert('windows false. Ingrese Clave y Usuario');
        $('#txt_strUsuario').removeAttr('disabled');
        $('#txt_strContrasenia').removeAttr('disabled');
        $('#txt_strContrasenia').val('');
        $('#buttomshowpass').removeAttr('disabled');
    }

});
$('#chck_sql').on('ifChanged', function () {

    //Windows Checkeado SI se Ingresa Contraseña
    if ($('#chck_windows').is(':checked') == true) {
        //alert('windows true, Ingrese solo usuario');
        $('#txt_strUsuario').removeAttr('disabled');
        $('#txt_strContrasenia').attr('disabled', 'disabled');
        $('#buttomshowpass').attr('disabled', 'disabled');
    }
    //SQL Checkeado NO se Ingresa Contraseña
    if ($('#chck_windows').is(':checked') == false) {
        //alert('windows false. Ingrese Clave y Usuario');
        $('#txt_strUsuario').removeAttr('disabled');
        $('#txt_strContrasenia').removeAttr('disabled');
        $('#txt_strContrasenia').val('');
        $('#buttomshowpass').removeAttr('disabled');
    }

});
function mostrarPass() {
    const el = document.getElementById("buttomshowpass");
    const x = document.getElementById("txt_strContrasenia");

    if (x.type === "password") {
        x.type = "text";
        el.innerHTML = '<i class="fa fa-eye-slash"></i>';
    }

    else {
        x.type = "password";
        el.innerHTML = '<i class="fa fa-eye"></i>';
    }

}

//Usado también en toma de consumos SISFOOD 18.03.21
function validarCampoIp(evt) {

    var theEvent = evt || window.event;

    // Handle paste
    if (theEvent.type === 'paste') {
        key = event.clipboardData.getData('text/plain');
    } else {
        // Handle key press
        var key = theEvent.keyCode || theEvent.which;
        key = String.fromCharCode(key);
    }
    var regex = /[0-9]|\.|\,/;
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }


}

/*La función "validarCampoCosto" usada como  onkeypress="validarCampoCosto(event)"
  dentro del input id="strMontoCosto" lo que  permitirá:
. bloquear la barra espaciadora, permitir solamente digitos y un punto   
. restringir letras, restringir caracteres especiales     
  FUENTE: https://stackoverflow.com/questions/469357/html-text-input-allow-only-numeric-input  
 */


///////////////////////////////////////////////////////////
// 9.- BOTON ACEPTAR (Guarda en TSPARAMS los valores)
///////////////////////////////////////////////////////////
$('#btn-aceptar-guardar').on('click', function () {

    //AUTENTICACION CHECKS
    var ChckStrAutenticacion = "0"; //WINDOWS
    if ($('#chck_sql').is(':checked') == true) {
        ChckStrAutenticacion = "1"; //SQL
    }

    var _strServidor = $('#txt_strServidor').val();
    var _strBaseDatos = $('#txt_strBaseDatos').val();
    var _strUsuario = $('#txt_strUsuario').val();
    var _strContrasenia = $('#txt_strContrasenia').val();
    var _strAutenticacion = ChckStrAutenticacion;
    var _strDirExcelCarga = $('#txt_strDirExcelCarga').val();
    var _strExcelGenerado = $('#txt_strExcelGenerado').val();


    if ($('#chck_sql').is(':checked') == true) {

        //VALIDACIONES
        if (
            _strServidor == "" ||
            _strBaseDatos == "" ||
            _strUsuario == "" ||
            _strDirExcelCarga == "" ||
            _strExcelGenerado == "" ||
            _strContrasenia == ""

        )
        {
            new PNotify({
                title: 'Conexión a Base de Datos SQL',
                text: "Complete Todos los Campos Obligatorios",
                type: "error",
                delay: 3000,
                styling: 'bootstrap3',
                addclass: 'dark'
            });

            return;
        }

    }


    var SesionMovi =
        {
            IntIdMenu: 'M0314',
            intIdUsuario: idUsuar,
            intIdSoft: idSoftw,
            intIdSesion: intIdSe
        }


    $.post(
        '/Configuracion/GuardarConexionBaseDatosSqlSaf',
        {
            objSesion: SesionMovi
            , strServidor: _strServidor
            , strBaseDatos: _strBaseDatos
            , strUsuario: _strUsuario
            , strContrasenia: _strContrasenia
            , strAutenticacion: _strAutenticacion
            , strDirExcelCarga: _strDirExcelCarga
            , strExcelGenerado: _strExcelGenerado

        },
        response => {

            console.log(response);
            if (response.type !== '') {

                if (response.type === 'success') {
                    new PNotify({
                        title: 'Conexión a Base de Datos SQL',
                        text: response.message,
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'
                    });

                    CargarConfiguracionConexionBaseDatos();


                }

                else {
                    new PNotify({
                        title: 'Configuración',
                        text: response.message,
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'
                    });
                    return;
                }

            }



        });



});


///////////////////////////////////////////////////////////
// 10.- BOTON PROBAR
///////////////////////////////////////////////////////////
$('#btn-probar-conexion-sql').on('click', function () {


    $.post(
        '/Configuracion/ProbarConexionBaseDatosSql',
        {
            //sinparametros
        },
        response => {

            //alert('btn-probar-conexion-sql Respuesta Exitosa del POST');

            if (response.type === 'success') {

                swal({
                    title: 'Prueba de Conexión',
                    text: response.message,//$('#cbo_formatos option:selected').text() + 
                    //text:  $('#cbo_formatos option:selected').text() + " no existe, por favor crearlo dentro de la carpeta Formatos "+ +" con el mismo nombre seleccionado",
                    //timer: 2000,
                });

                ////new PNotify({
                ////    title: 'Conexión a Base de Datos SQL',
                ////    text: response.message,
                ////    type: response.type,
                ////    delay: 3000,
                ////    styling: 'bootstrap3'
                ////});

            }

            else if (response.type === 'info') {

                new PNotify({
                    title: 'Conexión a Base de Datos SQL',
                    text: response.message,
                    type: response.type,
                    delay: 3000,
                    styling: 'bootstrap3'
                });
                return;
            }

            else {

                new PNotify({
                    title: 'Conexión a Base de Datos SQL',
                    text: response.message,
                    type: response.type,
                    delay: 3000,
                    styling: 'bootstrap3'
                });
                return;
            }


        });



});


///////////////////////////////////////////////////////////
// 11.- CARGAR CONFIGURACIONES CONEXION BASE DE DATOS
///////////////////////////////////////////////////////////
function CargarConfiguracionConexionBaseDatos(){

    //id = "strServidor"
    //id = "strBaseDatos"
    //id = "strUsuario"
    //id = "strDirExcelCarga"
    //id = "strExcelGenerado"
    //limpiarControlesConexionBaseDatos();

    var intIdMenu = 0

    var SesionMovi = {
        IntIdMenu: 'M0314',
        intIdUsuario: idUsuar,
        intIdSoft: idSoftw,
        intIdSesion: intIdSe
    }

    $.post(
        '/Configuracion/ListarConfigConexionBaseDeDatos',
        { objSesion: SesionMovi, strCoConfi: '' },
        (response) => {

            response.forEach(element => {


                $('#txt_strServidor').val(element.strServidor);
                $('#txt_strBaseDatos').val(element.strBaseDatos);
                $('#txt_strUsuario').val(element.strUsuario);                
                //$('#txt_strAutenticacion').val(element.strAutenticacion);
                $('#txt_strDirExcelCarga').val(element.strDirExcelCarga);
                $('#txt_strExcelGenerado').val(element.strExcelGenerado);


                
                if (element.strAutenticacion == "1") {

                    $('#chck_sql').iCheck('check');
                    $('#chck_windows').iCheck('uncheck');
                    $('#txt_strContrasenia').val(element.strContrasenia);
                    $('#txt_strContrasenia').removeAttr('disabled');
                    $('#buttomshowpass').removeAttr('disabled');

                }

                if (element.strAutenticacion == "0") {
                    $('#chck_sql').iCheck('uncheck');
                    $('#chck_windows').iCheck('check');
                    $('#txt_strContrasenia').attr('disabled', 'disabled');
                    $('#buttomshowpass').attr('disabled', 'disabled');
                    $('#buttomshowpass').attr('disabled', 'disabled'); 
                }


                /*******************************************************************
                strServidor
                strBaseDatos
                strUsuario
                strContrasenia
                strAutenticacion
                strDirExcelCarga
                strExcelGenerado
                ********************************************************************/

            });
        });

}

/////////////////////////////////////////////////////////////////////////////////////////////
//U:18.- CONVERTIR LAS LISTAS EN BYTES Y STRINGS PARA LUEGO LLEVARLOS AL SERVICE
/////////////////////////////////////////////////////////////////////////////////////////////
function GenerarBytesExcelAndStringsTxt(strEmailDestino) {

   var strExcelExportado = "TBBIENES";
    $.post(
        '/Reportes/GenerarBytesExcelParaEnviarPorCorreo',
        {
            strExcelExportado: strExcelExportado
        },
        response => {
            $("#progresLoader").html("41%");
            $("#progresLoader").width("41%");
            strExcelExportado = "TBBIENESDS";
            $.post(
                '/Reportes/GenerarBytesExcelParaEnviarPorCorreo',
                {
                    strExcelExportado: strExcelExportado
                },
                response => {
                    $("#progresLoader").html("49%");
                    $("#progresLoader").width("49%");
                    strExcelExportado = "TBOFICINA";
                    $.post(
                        '/Reportes/GenerarBytesExcelParaEnviarPorCorreo',
                        {
                            strExcelExportado: strExcelExportado
                        },
                        response => {
                            $("#progresLoader").html("54%");
                            $("#progresLoader").width("54%");
                            strExcelExportado = "TBEMPLEADO";
                            $.post(
                                '/Reportes/GenerarBytesExcelParaEnviarPorCorreo',
                                {
                                    strExcelExportado: strExcelExportado
                                },
                                response => {

                                    $("#progresLoader").html("62%");
                                    $("#progresLoader").width("62%");
                                    //////////////////////////////////////////////////////FIN GENERAR BYTES EXCEL
 
                                    //////////////////////////////////////////////////////INICIO GENERAR STRINGS TXT
                                    $.post(
                                        '/Reportes/GenerarStringFilesParaEnviarTxtPorCorreo',
                                        {
                                            strTxtExportado: "TBBIENES"
                                        },
                                        response => {
                                            $("#progresLoader").html("65%");
                                            $("#progresLoader").width("65%");
                                             $.post(
                                                '/Reportes/GenerarStringFilesParaEnviarTxtPorCorreo',
                                                {
                                                    strTxtExportado: "TBBIENESDS"
                                                },
                                                response => {
                                                    $("#progresLoader").html("69%");
                                                    $("#progresLoader").width("69%");
                                                    $.post(
                                                        '/Reportes/GenerarStringFilesParaEnviarTxtPorCorreo',
                                                        {
                                                            strTxtExportado: "TBOFICINA"
                                                        },
                                                        response => {
                                                            $("#progresLoader").html("72%");
                                                            $("#progresLoader").width("72%");
                                                            $.post(
                                                                '/Reportes/GenerarStringFilesParaEnviarTxtPorCorreo',
                                                                {
                                                                    strTxtExportado: "TBEMPLEADO"
                                                                },
                                                                response => {
                                                                    $("#progresLoader").html("75%");
                                                                    $("#progresLoader").width("75%");
                                                                    $.unblockUI();
                                                                    /////////////////////////////////////////////////
                                                                    comenzarEnvioDeCorreo(strEmailDestino)
                                                                    /////////////////////////////////////////////////

                                                                });

                                                        });

                                                });

                                        });
                                    //////////////////////////////////////////////////////FIN GENERAR STRINGS TXT




                                });

                        });

                });

        });

}

/////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////
function GenerarStringFilesParaEnviarTxt(strEmailDestino) {

    $.post(
        '/Reportes/GenerarStringFilesParaEnviarTxtPorCorreo',
        {
            strTxtExportado: "TBBIENES"
        },
        response => {
            $("#progresLoader").html("41%");
            $("#progresLoader").width("41%");
            $.post(
                '/Reportes/GenerarStringFilesParaEnviarTxtPorCorreo',
                {
                    strTxtExportado: "TBBIENESDS"
                },
                response => {
                    $("#progresLoader").html("49%");
                    $("#progresLoader").width("49%");
                    $.post(
                        '/Reportes/GenerarStringFilesParaEnviarTxtPorCorreo',
                        {
                            strTxtExportado: "TBOFICINA"
                        },
                        response => {
                            $("#progresLoader").html("54%");
                            $("#progresLoader").width("54%");
                            $.post(
                                '/Reportes/GenerarStringFilesParaEnviarTxtPorCorreo',
                                {
                                    strTxtExportado: "TBEMPLEADO"
                                },
                                response => {
                                    $("#progresLoader").html("68%");
                                    $("#progresLoader").width("68%");
                                    $.unblockUI();
                                    /////////////////////////////////////////////////
                                    //alert(strEmailDestino);
                                    comenzarEnvioDeCorreo(strEmailDestino);
                                    /////////////////////////////////////////////////

                                });

                        });

                });

        });

}











/*==================================================================================

/////////////////////////////////////////////////////////////////////////////////////////////
//ENVIAR POR CORREO SOLAMENTE LOS 04 DOCUMENTOS EN FORMATO TXTs EXPORTADOS
/////////////////////////////////////////////////////////////////////////////////////////////
function Enviar_TXT_A_VARIOS_Correos_NO_USADO() {

    if (intCorreos_checked.length < 1) {
        new PNotify({
            title:'Envio de Correos',
            text: "Tiene que seleccionar por lo menos un correo.",
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }

    //https://stackoverflow.com/questions/59676015/how-to-push-values-to-new-array-by-comparing-2-arrays
    //Filtrar en un nuevo arreglo los que se vaya seleccionado con los checks
    var newArray = new Array();
    detalleSubs.forEach(function (mainObject) {
        for (let i = 0; i < intCorreos_checked.length; i++) {
            if (intCorreos_checked[i] === mainObject.intEmail) {
                newArray.push(mainObject.strEmail);
            }
        }
    });


    //https://www.codegrepper.com/code-examples/javascript/opposite+of+split+in+javascript
    //Unir los correos seleccionados con punto y coma para usarlos en el parametro de la funcion
    var strEmailsCheckeados = newArray.join(";");
    alert(strEmailsCheckeados);
    //Iniciamos ejecución de Envio a los correos checkeados
    //Primero: Traemos las listas al Controlador
    GenerarListasParaEnvioDeFormatosTxt(strEmailsCheckeados);

}


/////////////////////////////////////////////////////////////////////////////////////////////
//TRAER/GET LAS LISTAS (HASTA EL CONTROLLER) DE LAS 04 TABLAS PARA GENERAR LOS FORMATOS TXT
/////////////////////////////////////////////////////////////////////////////////////////////
function GenerarListasParaEnvioDeFormatosTxt(strEmailsCheckeados) {


    $.blockUI({
        css: {
            border: 'none',
            padding: '15px',
            backgroundColor: '#000',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: .5,
            color: '#fff'
        },
        message: 'Procesando Formatos .Txt...'
    });

    var strTxtExportado_ = "TBBIENES";
    $.post(
        '/Reportes/GetListasDeCadaTablaTxt',
        {
            strTxtExportado: strTxtExportado_
        },
        response => {

            //alert('CountListaBienes' + response);

            strTxtExportado_ = "TBBIENESDS";
            $.post(
                '/Reportes/GetListasDeCadaTablaTxt',
                {
                    strTxtExportado: strTxtExportado_
                },
                response => {
                    CountListaBienesDs = response;

                    //alert('CountListaBienesDs' + response );

                    strTxtExportado_ = "TBOFICINA";
                    $.post(
                        '/Reportes/GetListasDeCadaTablaTxt',
                        {
                            strTxtExportado: strTxtExportado_
                        },
                        response => {

                            //alert('CountListaOficina' + response);

                            strTxtExportado_ = "TBEMPLEADO";
                            $.post(
                                '/Reportes/GetListasDeCadaTablaTxt',
                                {
                                    strTxtExportado: strTxtExportado_
                                },
                                response => {

                                    //alert('CountListaEmpleado' + response);


                                    /////////////////////////////////////////////////
                                    GenerarFormatosTxtParaEnviar(strEmailDestino);
                                    /////////////////////////////////////////////////




                                    ///////////////////////////////////////////
                                    //GenerarFormatoDeTexto(); //alert('Listas de excel en el controlador');////////
                                    ///////////////////////////////////////////
                                    setTimeout(function () {

                                        $.unblockUI();

                                    }, 1000);



                                    new PNotify({
                                        title: 'Importación Masiva Excel',
                                        text: 'La Exportación de los documentos Excel ha finalizado.',
                                        type: 'info',
                                        delay: 2000,
                                        styling: 'bootstrap3'
                                    });

                                    ////////////////////////////////////////////////////////////
                                    ////SI EL CHECK ESTA HABILITADO SE ENVIA AL/LOS CORREO(s)
                                    //if ($('#chk_envio_de_coreo').is(':checked') == true) {
                                    //    ////alert('EnviarExcelsExportadosPorCorreo');
                                    //    ////////////////EnviarExcelsExportadosPorCorreo();
                                    //    //enviarExcelsPorCorreo();
                                    //}
                                    ////////////////////////////////////////////////////////////


                                });

                        });

                });

        });


}











// NO USADO
function PRUEBA_ELIMINABLE() {

    alert('PRUEBA_ELIMINABLE');

    var strExcel = "TBBIENES";

    $.post(
        '/Reportes/ToEmailGenerarListasDeCadaTabla',
        {
            strExcelExportado: strExcel
        },
        response => {

            alert('GenerarFilesTxtParaEnviarPorCorreo');

            var strTxtExportado = "TBBIENES";
            $.post(
                '/Reportes/GenerarFilesTxtParaEnviarPorCorreo',
                {
                    strTxtExportado: strTxtExportado
                },
                response => {


                    $.post(
                        '/Reportes/EnviarDocumentosExportadosPorCorreo',
                        {
                            strEmailDestino: "mail", strTipoDeFiles: "1"
                        },
                        response => {

                            alert();

                        });

                });

        });





    //strExcelExportado_ = "TBBIENES";
    //$.post(
    //    '/Reportes/GetListasDeCadaTablaTxt',
    //    {
    //        strTxtExportado: strExcelExportado_
    //    },
    //    response => {

    //        CountListaBienes = response;

    //        strExcelExportado_ = "TBBIENESDS";
    //        $.post(
    //            '/Reportes/GetListasDeCadaTablaTxt',
    //            {
    //                strTxtExportado: strExcelExportado_
    //            },
    //            response => {




    //            });

    //    });

}


// No usado

====================================================================================*/






//--------------------------------------------------------------------------------3 Mostrar Contraseñas


/*******************************************************************************************
$(document).ready(function () {
    const intIdPersonal = window.SISCOP.intIdPersonal
    CargaInicial();
})
***********************************************************************************/


/*=================================================================================
      Actualizar el Listado "Correos"y la Tabla TSPARAMS - MANT. CONFIGURACION
===================================================================================*/
/*
function ActualizarCampoStrEmailDestino(operacion) {
    ////////alert('ActualizarCampoStrEmailDestino');
    var SesionMovi = {
        IntIdMenu: 'M0314',
        intIdUsuario: idUsuar,
        intIdSoft: idSoftw,
        intIdSesion: intIdSe
    }

    //Valores en duro. Solo se modificará un Campo
    var prmSalidaApp      = "";
    var prmAddOfic        = "1";
    var prmAddResp        = "1";
    var prmFilUbica       = "1";
    var prmOpcOpera       =  0;
    var prmAreaxLocal     = "1";
    var prmModaTrab       = "0";
    var prmOutExcelxLocal = "1";
    var prmImpresora      = "";;


    let detalleSub = [];
    for (x in detalleSubs)
        detalleSub.push(detalleSubs[x].strEmail);

    var strEmailDestino = detalleSub.join(";");


    swal({
        title: "Actualizar Correos",
        text: "¿Está seguro de guardar los cambios?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sí",
        cancelButtonText: "No",
        allowOutsideClick: false, 
    }).then(function (isConfirm) {
        if (isConfirm) {



*/