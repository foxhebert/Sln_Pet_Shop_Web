/**********Mantenimiento Usuario************/
/***************1.2-Usuario*****************/
/*******************************************/


/////////////////////////////////////////////////////////////////////////////////
//INICIALIZAR LO NECESARIO AL ENTRAR A ESTE MENU
/////////////////////////////////////////////////////////////////////////////////
$(document).ready(function () {

    //AÑADIDO EN DURO PARA CADA JS DE CADA VENTANA
    $('#fx_13_02_22_menu_actual').html('USUARIO');

});

//////////////////////////////////////////////////////////////////
// VALIDACION DE CARACTERES DE CAMPOS 
//////////////////////////////////////////////////////////////////
function validarCodigoDescripcion(evt) {     
    //onkeypress = "validarCodigoDescripcion(event)" 
    var theEvent = evt || window.event;

    // Handle paste
    if (theEvent.type === 'paste') {
        key = event.clipboardData.getData('text/plain');
    } else {
        // Handle key press
        var key = theEvent.keyCode || theEvent.which;
        key = String.fromCharCode(key);
    }
    var regex = /[0-9]|[a-z]|[A-Z]|\_|\-/; //Numeros, Letras ---> a-z,A-Z, _ , -
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}

//////////////////////////////////////////////////////////////////
//ESCONDER MOSTRAR CONTRASEÑA CON EL OJO
//////////////////////////////////////////////////////////////////
function mostrarPassword() {
    var cambio = document.getElementById("txt_contrasenia");
    if (cambio.type == "password") {
        cambio.type = "text";
        $('#ViewPass').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
        //$('#ViewPass').removeClass('glyphicon glyphicon-eye-close').addClass('glyphicon glyphicon-eye-open');
    } else {
        cambio.type = "password";
        $('#ViewPass').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
        //$('#ViewPass').removeClass('glyphicon glyphicon-eye-open').addClass('glyphicon glyphicon-eye-close');
    }
}

//////////////////////////////////////////////////////////////////
//BOTON CANCELAR 
//////////////////////////////////////////////////////////////////
$('#btn-cancel-Usuario').on('click', function () {
    $('.form-hide-Usuario').hide();
});

//////////////////////////////////////////////////////////////////
//CONTROLES DE FILTROS DEL LISTADO (inputs, filtros)
//////////////////////////////////////////////////////////////////
$('#ActivoUsuario').on('change', function() {
    TablaUsuario();
});
$('#CampPerfiles').on('change', function() {
    TablaUsuario();
});
$('#filtroUsuario').keyup(function() {
    TablaUsuario();
});

//////////////////////////////////////////////////////////////////
//CAMBIAR LOS SWITCH AL CARGAR EDITAR
//////////////////////////////////////////////////////////////////
function changeSwitchery(elemento, checked) {
    if ((elemento.is(':checked') && checked == false) || (!elemento.is(':checked') && checked == true)) {
        elemento.parent().find('.switchery').trigger('click');
    }
}

//////////////////////////////////////////////////////////////////
//COMBOS
//////////////////////////////////////////////////////////////////
function CombosUsuario() {

    $.post(
        '/Personal/ListarCombosPersonal_',
        { strEntidad: 'TGPERFIL', intIdFiltroGrupo: 0, strGrupo: 'PERFIL', strSubGrupo: '' },
        (response) => {
            $('#CampPerfil').empty();
            $('#CampPerfiles').empty();
            $('#CampPerfil').append('<option >Seleccione</option>');
            $('#CampPerfiles').append('<option value="0">Seleccione</option>');
            response.forEach(element => {
                $('#CampPerfil').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');
                $('#CampPerfiles').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');

            });

        });


}

//////////////////////////////////////////////////////////////////
//LISTARDO DE USUARIOS
//////////////////////////////////////////////////////////////////
var _varTablaUsuario;
function TablaUsuario() {

    var Activo = $('#ActivoUsuario').val();
    var Descipción = $('#filtroUsuario').val();
    var Tipo = $('#CampPerfiles').val();


    $.post(
        '/Seguridad/GetTablaUsuario',
        { intActivo: Activo, strDescripcion: Descipción, intPerfil: Tipo },
        (response) => {
            console.log(response);

            if (typeof _varTablaUsuario !== 'undefined') {
                _varTablaUsuario.destroy();
            }
            _varTablaUsuario = $('#tablaUsuarios').DataTable({
                data: response,
                columns: [

                    { data: 'intIdUsuar' },
                    { data: 'strUsUsuar' },
                    { data: 'strNoUsuar' },
                    { data: 'strstrDesPerfil' },
                    //{ data: 'strDesEmp' },
                    { data: 'strEstadoActivo' },
                    {
                        sortable: false,
                        "render": (data, type, item, meta) => {
                            let intIdUsuar = item.intIdUsuar;
                            let strNoUsuar = item.strNoUsuar;
                            return `<button class="btn btn-success btn-xs btn-edit" dataid="${intIdUsuar}" ><i class="fa fa-pencil"></i> Editar </button> 
                                           <button class="btn btn-primary btn-xs btn-delete" dataid="${intIdUsuar}" des_data="${strNoUsuar}" data="${item}" ><i class="fa fa-trash-o"></i> Eliminar </button>`;
                        }
                    }


                ],
                lengthMenu: [10, 25, 50],
                order: [0, 'asc'],
                responsive: true,
                language: _datatableLanguaje,
                columnDefs: [
                    {
                        targets: [0],
                        visible: false,
                        searchable: false
                    }
                ],
                dom: 'lBfrtip',
            });


            $('#tablaUsuarios  tbody').on('click', 'tr button.btn-delete', function() {


                let intIdUsuar = $(this).attr("dataid")
                let strNoUsuar = $(this).attr("des_data")
                if (!isNaN(intIdUsuar)) {
                    intentEliminarUsuario(intIdUsuar, strNoUsuar)
                }

            });


        });

}

//////////////////////////////////////////////////////////////////
//BOTON EDITAR UN REGISTRO DE USUARIO
//////////////////////////////////////////////////////////////////
$('#tablaUsuarios  tbody').on('click', 'tr button.btn-edit', function () {


    let intIdUsuar = $(this).attr("dataid");

    ////$.blockUI({
    ////    css: {
    ////        border: 'none',
    ////        padding: '15px',
    ////        backgroundColor: '#000',
    ////        '-webkit-border-radius': '10px',
    ////        '-moz-border-radius': '10px',
    ////        opacity: .5,
    ////        color: '#fff'
    ////    },
    ////    message: 'Procesando...'
    ////});


    $('.form-hide-Usuario').hide();

    $.post(

        '/Seguridad/getMaestroCaracteres',
        { strTableName: 'TSUSUARIO' },
        (response) => {
            response.forEach(element => {
                //alert('/Seguridad/getMaestroCaracteres');
                if (element.strColumnName == 'strUsUsuar') {
                    $('#' + element.strColumnName + '').empty();
                    $('#' + element.strColumnName + '').append('<label>Usuario (*)</label><input type = "text"   class= "form-control" id = "txt_codigo_Usuario" placeholder = "Código" maxlength="' + element.intMaxLength + '"  onkeypress = "validarCodigoDescripcion(event)"  ><div id="notifry_error" style="background-color:#4CA4DE;color:white;text-align:center;"></div>');
                }
                else if (element.strColumnName == 'strCoPassw') {
                    $('#' + element.strColumnName + '').empty();

                    $('#' + element.strColumnName + '').append('<label>Contraseña (*)</label><div class="controls"><div class="input-prepend input-group"><input type = "password"  validationpass_u = "false" class= "form-control" id ="txt_contrasenia" placeholder = "contraseña" maxlength="' + element.intMaxLength + '"  >' + // onkeypress = "validarCodigoDescripcion(event)" 
                        '<span id="ojitoMuestraEscondeClave" class="input-group-addon btn btn-login" onclick="mostrarPassword()"><i id="ViewPass" class="fa fa-eye" ></i></span></div></div><div id="notifry_errordes" style="background-color:#4CA4DE;color:white;text-align:center;"></div>' +//);   class="glyphicon glyphicon-eye-close"
                        '<div id="claveValidar_usu" >' +
                        '<h5>La contraseña debería cumplir con las siguientes políticas:</h5>' +
                        '<ul>' +
                        '<li id="capital_usu">Debe tener al menos <strong>una Mayúscula</strong><br /></li>' +
                        '<li id="letter_usu">Debe tener al menos <strong>una Minúscula</strong><br /></li>' +
                        '<li id="number_usu">Debe tener al menos <strong>un Número</strong><br /></li>' +
                        '<li id="especial_usu">Debe tener al menos <strong>un Caracter Especial (@@ # $ % () * - _ / .)</strong><br /></li>' +
                        '<li id="length_usu">Debe ser como mínimo <strong>8 dígitos</strong><br /></li>' +
                        '</ul > ' +
                        '</div > ');

                }
                else if (element.strColumnName == 'strNoUsuar') {
                    $('#' + element.strColumnName + '').empty();

                    $('#' + element.strColumnName + '').append('<label>Nombre (*) </label><input type = "text" class= "form-control" id = "txt_Nombre_Usuario" placeholder = "Nombre" maxlength="' + element.intMaxLength + '" ><div id="notifry_errornom" style="background-color:#4CA4DE;color:white;text-align:center;"></div>');
                    $("#txt_codigo_Usuario").keyup(function () {
                        $('#notifry_error').html('');
                        document.getElementById("txt_codigo_Usuario").style.borderColor = "#CCCCCC";
                    });
                    $("#txt_contrasenia").keyup(function () {
                        $('#notifry_errordes').html('');
                        document.getElementById("txt_contrasenia").style.borderColor = "#CCCCCC";
                    });

                }

           

            });



            //////////////////////////////////////////////////////////////////
            // VALIDACION DE CAMPO CONTRASEÑA(independiente de todo js) Va despues del cargado de los Inputs
            //////////////////////////////////////////////////////////////////
            $('#txt_contrasenia').keyup(function () {

                // set password variable
                var pswd = $(this).val();
                var estate = false;
                var estateEspecial = false;
                //validate the length
                if (pswd.length < 8) {
                    $('#length_usu').show();
                } else {
                    $('#length_usu').hide();
                }

                //validate letras
                if (pswd.match(/[a-z]/)) {
                    $('#letter_usu').hide()
                } else {
                    $('#letter_usu').show();
                }

                //validate capital letter
                if (pswd.match(/[A-Z]/)) {
                    $('#capital_usu').hide();
                } else {
                    $('#capital_usu').show();
                }

                //validate number
                if (pswd.match(/\d/)) {
                    $('#number_usu').hide();
                } else {
                    $('#number_usu').show();
                }

                //validate number \@@
                if (pswd.includes('@') || pswd.includes('#') || pswd.includes('$') || pswd.includes('%') || pswd.includes('/') || pswd.includes('_') || pswd.includes('-') || pswd.includes('.') || pswd.includes('(') || pswd.includes(')') || pswd.includes('*') || pswd.includes('+')) {
                    $('#especial_usu').hide();
                    estateEspecial = true;
                } else {
                    $('#especial_usu').show();
                }

                //Si cumple todas las condiciones el atributo del imput se cambia a true luego usado al GUARDAR
                if (pswd.length >= 8 && pswd.match(/[a-z]/) && pswd.match(/[A-Z]/) && pswd.match(/\d/) && estateEspecial) {
                    estate = true;
                }

                //VALIDAR ESTADO
                $(this).attr('validationpass_u', estate)
                if (estate) {
                    $('#claveValidar_usu').hide();
                } else {
                    $('#claveValidar_usu').show();
                }

            }).
                focus(function () {
                    let estate = $(this).attr('validationpass_u')
                    if (estate) {
                        $('#claveValidar_usu').hide();
                    } else {
                        $('#claveValidar_usu').show();
                    }
                }).blur(function () {
                    $('#claveValidar_usu').hide();
                });

            //////////////////////////////////////////////////////////////////
            //Despues de haberse dibujado los controles se ejecutará:
            if (!isNaN(intIdUsuar)) {

                editarUsuario(intIdUsuar)
            }            
            //////////////////////////////////////////////////////////////////
           

        });

   





});

//////////////////////////////////////////////////////////////////
//INTENTAR ELIMINAR USUARIO
//////////////////////////////////////////////////////////////////
function intentEliminarUsuario(intIdUsuar, strNoUsuar) {
    swal({
        title: "Eliminar Usuario",
        text: "¿Está seguro de eliminar el Usuario ''<strong>" + strNoUsuar + "</strong>''?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sí, eliminar",
        cancelButtonText: "No, cancelar",
    }).then(function(isConfirm) {
        if (isConfirm) {
            yesEliminaUsuario(intIdUsuar);
        } else {
            swal("Cancelado", "La Operación fue cancelada", "error");
        }
    });
}

//////////////////////////////////////////////////////////////////
//YES ELIMINAR USUARIO
//////////////////////////////////////////////////////////////////
function yesEliminaUsuario(intIdUsuar) {

 
    $.post(
        '/Seguridad/EliminarUsuario',
        { /*objSession: SesionMovi,*/ intIdUsu: intIdUsuar },
        (response) => {
            console.log(response);
            if (response.type !== '') {
                var tipo = 'Eliminado!';
                if (response.type === 'error')
                    tipo = 'NO SE PUEDE ELIMINAR EL REGISTRO';
                swal(tipo, response.message, response.type);

                if (response.type === 'success')
                    TablaUsuario();

            }
        }
    ).fail(function(result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
}

//////////////////////////////////////////////////////////////////
//BOTON EDITAR USUARIO
//////////////////////////////////////////////////////////////////
function editarUsuario(intIdUsuar) {

    $('.form-hide-Usuario').hide();
    $('#btn-save-change-Usuario').hide();
    $('#btn-update-Usuario').show();

    $.post(
        '/Seguridad/ObtenerRegistroUsuario',
        { IntIdUsuar: intIdUsuar },  //objSession: SesionMovi,
        (response) => {

            console.log(response);
            response.forEach(element => {

                $('#txt_codigo_Usuario').val(element.strUsUsuar);
                $('#txt_contrasenia').val(element.strCoPassw);
                $('#txt_Nombre_Usuario').val(element.strNoUsuar);
                //alert(element.intIdPerfil);
                $('#CampPerfil').val(element.intIdPerfil);
                $('#intidUsuario').val(element.intIdUsuar);
                
                
                var elementoSwitch = $('#chk-activo-Usuario');
                if (element.bitFlActivo == false) {

                    changeSwitchery(elementoSwitch, false);

                 }
                else if (element.bitFlActivo == true) {

                    changeSwitchery(elementoSwitch, true);

                }

                $('.form-hide-Usuario').show();
                //////$.unblockUI();

            });

        });



}

//////////////////////////////////////////////////////////////////
//BOTON NUEVO USUARIO
//////////////////////////////////////////////////////////////////
$('#btn-new-Usuario').on('click', function() {

    $('.form-hide-Usuario').hide();
    $('#btn-save-change-Usuario').show();
    $('#btn-update-Usuario').hide();
    $('#txt_codigo_Usuario').val('');
    $('#txt_contrasenia').val('');
    $('#txt_Nombre_Usuario').val('');
    $('#CampPerfil option:selected').val(0);


    //var elementoSwitch = $('#chk-activo-Usuario');
    changeSwitchery($('#chk-activo-Usuario'), true);


  //alert()

    $.post(
        //'/Proceso/MaestroMaxCaracteres',
        '/Seguridad/getMaestroCaracteres',
        { strTableName: 'TSUSUARIO' },
        (response) => {
            response.forEach(element => {
                //alert('/Seguridad/getMaestroCaracteres');
                if (element.strColumnName == 'strUsUsuar') {
                    $('#' + element.strColumnName + '').empty();
                    $('#' + element.strColumnName + '').append('<label>Usuario (*)</label><input type = "text"   class= "form-control" id = "txt_codigo_Usuario" placeholder = "Código" maxlength="' + element.intMaxLength + '"  onkeypress = "validarCodigoDescripcion(event)"  ><div id="notifry_error" style="background-color:red;color:white;text-align:center;"></div>');
                }
                else if (element.strColumnName == 'strCoPassw') {
                    $('#' + element.strColumnName + '').empty();

                    $('#' + element.strColumnName + '').append('<label>Contraseña (*)</label><div class="controls"><div class="input-prepend input-group"><input type = "password"  validationpass_u = "false" class= "form-control" id ="txt_contrasenia" placeholder = "contraseña" maxlength="' + element.intMaxLength + '"  >' + // onkeypress = "validarCodigoDescripcion(event)" 
                        '<span id="ojitoMuestraEscondeClave" class="input-group-addon btn btn-login" onclick="mostrarPassword()"><i id="ViewPass" class="fa fa-eye" ></i></span></div></div><div id="notifry_errordes" style="background-color:#4CA4DE;color:white;text-align:center;"></div>' +//);   class="glyphicon glyphicon-eye-close"

                    //$('#' + element.strColumnName + '').append(
                        '<div id="claveValidar_usu" >' +
                        //style="border: thin solid gray;padding: 1%; "
                        '<h5>La contraseña debería cumplir con las siguientes políticas:</h5>' +
                        '<ul>' +
                        '<li id="capital_usu">Debe tener al menos <strong>una Mayúscula</strong><br /></li>' +
                        '<li id="letter_usu">Debe tener al menos <strong>una Minúscula</strong><br /></li>' +   
                        //'<li id="letter_usu">Debe tener al menos <strong>una Minúscula</strong><br /></li>' + 
                        '<li id="number_usu">Debe tener al menos <strong>un Número</strong><br /></li>' +
                        '<li id="especial_usu">Debe tener al menos <strong>un Caracter Especial (@@ # $ % () * - _ / .)</strong><br /></li>' +
                        '<li id="length_usu">Debe ser como mínimo <strong>8 dígitos</strong><br /></li>' +
                        '</ul > ' +

                        '</div > ');


                }
                else if (element.strColumnName == 'strNoUsuar') {
                    $('#' + element.strColumnName + '').empty();
                   
                    $('#' + element.strColumnName + '').append('<label>Nombre (*)</label><input type = "text" class= "form-control" id = "txt_Nombre_Usuario" placeholder = "Nombre" maxlength="' + element.intMaxLength + '" ><div id="notifry_errornom" style="background-color:#4CA4DE;color:white;text-align:center;"></div>');
                    $("#txt_codigo_Usuario").keyup(function() {
                        $('#notifry_error').html('');
                        document.getElementById("txt_codigo_Usuario").style.borderColor = "#CCCCCC";
                    });
                    $("#txt_contrasenia").keyup(function() {
                        $('#notifry_errordes').html('');
                        document.getElementById("txt_contrasenia").style.borderColor = "#CCCCCC";
                    });

                }

            });



            //////////////////////////////////////////////////////////////////
            // VALIDACION DE CAMPO CONTRASEÑA(independiente de todo js) Va despues del cargado de los Inputs
            //////////////////////////////////////////////////////////////////
            $('#txt_contrasenia').keyup(function () {

                // set password variable
                var pswd = $(this).val();
                var estate = false;
                var estateEspecial = false;
                //validate the length
                if (pswd.length < 8) {
                    $('#length_usu').show();
                } else {
                    $('#length_usu').hide();
                }

                //validate letras
                if (pswd.match(/[a-z]/)) {
                    $('#letter_usu').hide()
                } else {
                    $('#letter_usu').show();
                }

                //validate capital letter
                if (pswd.match(/[A-Z]/)) {
                    $('#capital_usu').hide();
                } else {
                    $('#capital_usu').show();
                }

                //validate number
                if (pswd.match(/\d/)) {
                    $('#number_usu').hide();
                } else {
                    $('#number_usu').show();
                }

                //validate number \@@
                if (pswd.includes('@') || pswd.includes('#') || pswd.includes('$') || pswd.includes('%') || pswd.includes('/') || pswd.includes('_') || pswd.includes('-') || pswd.includes('.') || pswd.includes('(') || pswd.includes(')') || pswd.includes('*') || pswd.includes('+')) {
                    $('#especial_usu').hide();
                    estateEspecial = true;
                } else {
                    $('#especial_usu').show();
                }

                //Si cumple todas las condiciones el atributo del imput se cambia a true luego usado al GUARDAR
                if (pswd.length >= 8 && pswd.match(/[a-z]/) && pswd.match(/[A-Z]/) && pswd.match(/\d/) && estateEspecial) {
                    estate = true;
                }

                //VALIDAR ESTADO
                $(this).attr('validationpass_u', estate)
                if (estate) {
                    $('#claveValidar_usu').hide();
                } else {
                    $('#claveValidar_usu').show();
                }

            }).
                focus(function () {
                    let estate = $(this).attr('validationpass_u')
                    if (estate) {
                        $('#claveValidar_usu').hide();
                    } else {
                        $('#claveValidar_usu').show();
                    }
                }).blur(function () {
                       $('#claveValidar_usu').hide();
                });

            //////////////////////////////////////////////////////////////////
            //FORMULARIO NUEVO
            //////////////////////////////////////////////////////////////////
            $('.form-hide-Usuario').show();



                    //.append('<label>Contraseña (*)</label><input type = "text" class= "form-control" id = "txt_descripcion_Usuario" placeholder = "Descripción" maxlength="' + element.intNumero + '"><div id="notifry_errordes" style="background-color:#4CA4DE;color:white;text-align:center;"></div>');
                    //function mostrarPassword() {
                    //    var cambio = document.getElementById("txt_descripcion_Usuario");
                    //    if (cambio.type == "password") {
                    //        cambio.type = "text";
                    //        $('#ViewPass').removeClass('glyphicon glyphicon-eye-close').addClass('glyphicon glyphicon-eye-open');
                    //    } else {
                    //        cambio.type = "password";
                    //        $('#ViewPass').removeClass('glyphicon glyphicon-eye-open').addClass('glyphicon glyphicon-eye-close');
                    //    }
                    //}




        });

    CombosUsuario();

  
 

});

//////////////////////////////////////////////////////////////////
//CONSTRUCTORES
//////////////////////////////////////////////////////////////////
var listaDetallesUsuarioFiltros = new Array();
var listaDetallesUsuarioPerfiles = new Array();
class TT_TSUSUAR_FILTRO {

    constructor(intIdUsFiltro, intIdUsuar, intIdEmp, intIdLocal, intIdArea, bitFlActivo, bitFlEliminado) {

        this.intIdUsFiltro = intIdUsFiltro
        this.intIdUsuar = intIdUsuar
        this.intIdEmp = intIdEmp
        this.intIdLocal = intIdLocal
        this.intIdArea = intIdArea
        this.bitFlActivo = bitFlActivo
        this.bitFlEliminado = bitFlEliminado

    }
}

class TT_TSUSUAR_PERFI {

    constructor(intIdUsPerf, intIdUsuar, intIdPerfil, bitFlPrincipal, bitFlActivo, bitFlEliminado) {

        this.intIdUsPerf = intIdUsPerf
        this.intIdUsuar = intIdUsuar
        this.intIdPerfil = intIdPerfil
        this.bitFlPrincipal = bitFlPrincipal
        this.bitFlActivo = bitFlActivo
        this.bitFlEliminado = bitFlEliminado

    }
}

//////////////////////////////////////////////////////////////////
//BOTON GUARDAR USUARIO
//////////////////////////////////////////////////////////////////
$('#btn-save-change-Usuario').on('click', function() {

    var _usuario = $('#txt_codigo_Usuario').val();
    var _contraseña = $('#txt_contrasenia').val();
    var _nombre = $('#txt_Nombre_Usuario').val();
    var _perfil = $('#CampPerfil option:selected').val();
    var _activo = $('#chk-activo-Usuario').is(':checked');
    var validationpass_u = $("#txt_contrasenia").attr("validationpass_u");

    if (
           _usuario === ''
        || _contraseña === ''
        || _nombre === '') {

        new PNotify({
            title: 'Nuevo Usuario',
            text: 'Complete los campos obligatorios',
            type: 'info',
            delay: 2500,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        $('#notifry_error').html('');
        $('#notifry_errordes').html('');

        return;
    }


    if (
           _perfil === ''
        || _perfil == 'undefined'
        || _perfil == 0
        || _perfil == "0") {

        new PNotify({
            title: 'Nuevo Usuario',
            text: 'Seleccione un Perfil',
            type: 'info',
            delay: 2500,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        $('#notifry_error').html('');
        $('#notifry_errordes').html('');

        return;
    }

    if (validationpass_u == "false" ) {
        new PNotify({
            title: 'Nuevo Usuario',
            text: 'Su contraseña no cumple con la política.',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        $("#txt_contrasenia").focus();
        $('#notifry_error').html('');
        $('#notifry_errordes').html('');

        return;
    }

 
    //Datos de Usuario
    var Usuario = {

        strUsUsuar: _usuario,
        strCoPassw: _contraseña,
        strNoUsuar: _nombre,
        tinFlEstado: 1,
        bitFlActivo: _activo,
        strMotivoEst: 'N.H.M',
        dttFchBloqueo: '24/03/2000',
        dttFchUltPass: '24/03/2000',
        dttFchCaduca: '24/03/2000',
        intIdPersonal: 1,
    }

    //Datos de TSUSUAR_PERFI
    listaDetallesUsuarioPerfiles = [];
    listaDetallesUsuarioPerfiles.push(new TT_TSUSUAR_PERFI(null, null, _perfil, 1, 1, 0));
    listaDetallesUsuarioFiltros = [];

    $.post(
        '/Seguridad/InsertUpdateUsuario',
        {
            ObjUsuario: Usuario,
            listaDetallesUsuarioPerfil: listaDetallesUsuarioPerfiles,
            listaDetallesUsuarioFiltro: listaDetallesUsuarioFiltros,
            intTipoOperacion: 1
        },
        (response) => {
            console.log(response);
            if (response.type !== '') {

                if (response.type === 'success') {
                    new PNotify({
                        title: 'Nuevo Usuario',
                        text: response.message,
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'
                    });
                    listaDetallesUsuarioPerfiles = [];
                    $('.form-hide-Usuario').hide();
                    TablaUsuario();
                } else {

                    if (response.type === 'usuario') {
                        var nomMantemiento = 'Usuario';
                        var campo = 'txt_codigo_Usuario';
                        var msj = response.message;
                        var response = "info";
                        var deta = 'notifry_error';
                        document.getElementById("txt_codigo_Usuario").style.borderColor = "#3498dbe0";
                        INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                        return;

                    } else {

                        if (response.type === 'externo') {

                            var nomMantemiento = 'Usuario';
                            var campo = 'txt_Nombre_Usuario';
                            var msj = response.message;
                            var response = "info";
                            var deta = 'notifry_errordes';
                            INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                            return;
                        } else {

                            new PNotify({
                                title: 'Nuevo Usuario',
                                text: response.message,
                                type: 'info',
                                delay: 3000,
                                styling: 'bootstrap3'
                            });


                        }

                    }
                }

            }
        }
    ).fail(function(result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
        });




});

//////////////////////////////////////////////////////////////////
//BOTON ACTUALIZAR
//////////////////////////////////////////////////////////////////
$('#btn-update-Usuario').on('click', function() {

    var _usuario = $('#txt_codigo_Usuario').val();
    var _contraseña = $('#txt_contrasenia').val();
    var _nombre = $('#txt_Nombre_Usuario').val();
    var _perfil = $('#CampPerfil option:selected').val();
    //var _filtro = $('#Confiltro').is(':checked');
    var _activo = $('#chk-activo-Usuario').is(':checked');
    var _intIdUsu = $('#intidUsuario').val();

    if (_usuario === ''
        || _contraseña === ''
        || _nombre === ''
        || _perfil === 'Seleccione'
        || _perfil === ''
        || _perfil == 'undefined'
        || _perfil == 0
        || _perfil == "0") {

        new PNotify({
            title: 'Nuevo Usuario',
            text: 'Complete los campos obligatorios',
            type: 'info',
            delay: 2500,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        $('#notifry_error').html('');
        $('#notifry_errordes').html('');

        return;
    }

    //Datos de Usuario
    var Usuario = {

        strUsUsuar: _usuario,
        strCoPassw: _contraseña,
        strNoUsuar: _nombre,
        tinFlEstado: 1,
        bitFlActivo: _activo,
        strMotivoEst: 'N.H.M',
        dttFchBloqueo: '24/03/2000',
        dttFchUltPass: '24/03/2000',
        dttFchCaduca: '24/03/2000',
        intIdPersonal: 1,
        intIdUsuar: _intIdUsu,
    }

    //Datos de TSUSUAR_PERFI
    listaDetallesUsuarioPerfiles=[];
    listaDetallesUsuarioPerfiles.push(new TT_TSUSUAR_PERFI(null, null, _perfil, 1, 1, 0));
    listaDetallesUsuarioFiltros = [];

    $.post(
        '/Seguridad/InsertUpdateUsuario',
        {
            ObjUsuario: Usuario,
            listaDetallesUsuarioPerfil: listaDetallesUsuarioPerfiles,
            listaDetallesUsuarioFiltro: listaDetallesUsuarioFiltros,
            intTipoOperacion: 2
        },
        (response) => {

            console.log(response);
            if (response.type !== '') {

                if (response.type === 'success') {
                    new PNotify({
                        title: 'Actualizar Usuario',
                        text: response.message,
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'
                    });
                    $('.form-hide-Usuario').hide();
                    TablaUsuario();
                } else {

                    if (response.type === 'usuario') {
                        var nomMantemiento = 'Usuario';
                        var campo = 'txt_codigo_Usuario';
                        var msj = response.message;
                        var response = "info";
                        var deta = 'notifry_error';
                        INFO_MSJ(nomMantemiento, campo, response, msj, deta);

                        document.getElementById("txt_codigo_Usuario").style.borderColor = "#3498dbe0";

                        return;

                    } else {

                        if (response.type === 'externo') {

                            var nomMantemiento = 'Usuario';
                            var campo = 'txt_Nombre_Usuario';
                            var msj = response.message;
                            var response = "info";
                            var deta = 'notifry_errordes';
                            INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                            return;
                        } else {

                            new PNotify({
                                title: 'Nuevo Usuario',
                                text: response.message,
                                type: 'info',
                                delay: 3000,
                                styling: 'bootstrap3'
                            });


                        }

                    }
                }

            }
        }
    ).fail(function(result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });

});
