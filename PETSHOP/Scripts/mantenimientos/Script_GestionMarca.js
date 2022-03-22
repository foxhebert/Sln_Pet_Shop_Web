
/////////////////////////////////////////////////////////////////////////////////
//INICIALIZAR LO NECESARIO AL ENTRAR A ESTE MENU
/////////////////////////////////////////////////////////////////////////////////
$(document).ready(function () {

    ListarMarca();
    //AÑADIDO EN DURO PARA CADA JS DE CADA VENTANA
    //$('#fx_13_02_22_menu_actual').html('Marcas');
    $('#fx_13_02_22_menu_actual').html('MARCAS');

});

$('#cboActivo').on('change', function () {
    //ListarMarca();
});

$('#txt-filtro-marca').keyup(function () {
    ListarMarca();
});

//BOTON CANCELAR
$('#btn-cancel-marca').on('click', function () {
    $('.form-hide-MARCA').hide();
});


var _varTablaMarca;
function ListarMarca() {

    //var SesionMovi = {
    //    IntIdMenu: 'M0202',
    //    intIdUsuario: idUsuar,
    //    intIdSoft: idSoftw,
    //    intIdSesion: intIdSe
    //}

    var strActivo_  = $('#cboActivo').val();
    var strFiltro_  = $('#txt-filtro-marca').val();


    $.post(
        '/Procesos/ListarMarca',  
        //'/Personal/GetTablaEmpresa',  
        { intIdMarca: 1, strActivo: strActivo_, strFiltro: strFiltro_},
        (response) => {
            console.log(response);

            if (typeof _varTablaMarca !== 'undefined') {
                _varTablaMarca.destroy();
            }
            _varTablaMarca = $('#TablaMarca').DataTable({
                data: response,
                columns: [

                    { data: 'intIdMarca'     },
                    { data: 'strCodigoMarca' },
                    { data: 'strDescMarca'   },
                    { data: 'strRutaImgMarca'   },
                    {
                        sortable: false,
                        "render": (data, type, item, meta) => {
                            let IntIdntificador = item.intIdMarca;
                            let strDescripcion = item.strDescMarca;
                            //return `<div style="display: flex;"><button class="btn btn-success btn-xs btn-edit-marca " dataid="${IntIdntificador}" ><i class="fa fa-pencil"></i> Editar </button> 
                            return `<div class="text-center" ><button class="btn btn-success btn-xs btn-edit-marca " dataid="${IntIdntificador}" ><i class="fa fa-pencil"></i> Editar </button> 
                                           <button class="btn btn-primary btn-xs btn-delete  " dataid="${IntIdntificador}" des_data="${strDescripcion}" data="${item}" ><i class="fa fa-trash-o"></i> Eliminar </button></div>`;
                        }
                    }

                ],
                lengthMenu: [10, 25, 50],
                order: [1, 'asc'],
                responsive: true,
                language: _datatableLanguaje,
                'columnDefs': [
                    {
                        targets   : [3],//dos columnas escondidas
                        visible   : false,
                        searchable: false
                    },
                    {
                        targets: [4],
                        visible: true,
                        searchable: true,
                        width: "25%"  //, //setear o determinar el ancho de la columna en porcentaje
                        //className: "text-center" //centar contenido o elementos de la columna
                    }
                    //,
                    //{
                    //    targets  : [4],//dos columnas escondidas
                    //    "className": "text-center",
                    //    "width": "4%"
                    //}
                   
                ],

                //'columnDefs': [
                //    {
                //        "targets": 0, // your case first column
                //        "className": "text-center",
                //        "width": "4%"
                //    },
                //    {
                //        "targets": 2,
                //        "className": "text-right",
                //    }
                //]

                dom: 'lBfrtip',
            });


        });

}

$('#TablaMarca  tbody').on('click', 'tr button.btn-delete', function () {

    let Identifier = $(this).attr("dataid")
    let descripcion = $(this).attr("des_data")
    if (!isNaN(Identifier)) {
        intentEliminarMarca(Identifier, descripcion)
    }

});

$('#TablaMarca tbody').on('click', 'tr button.btn-edit-marca', function () {
    //alert(222222);
    let intId = $(this).attr("dataid");

    if (!isNaN(intId)) {
        editarMarca(intId);
    }

});

function intentEliminarMarca(Identifier, Descripcion) {
    swal({
        title: "ELIMINAR MARCA",
        text: "¿Está seguro de eliminar la Marca   ''<strong>" + Descripcion + "</strong>''?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Eliminar",
        cancelButtonText: "Cancelar",
    }).then(function (isConfirm) {
        if (isConfirm) {
            yesEliminaMarca(Identifier);
        } else {
            swal("Cancelado", "La Operación fue cancelada", "error");
        }
    });
}

function yesEliminaMarca(identifier) {


    $.post(
        '/Procesos/EliminarMarcaGesMar',
        { intIdMarca: identifier},
        (response) => {
            console.log(response);
            if (response.type !== '') {
                var tipo = 'Eliminado!';
                if (response.type === 'error')
                    tipo = 'NO SE PUEDE ELIMINAR EL REGISTRO';
                swal(tipo, response.message, response.type);

                if (response.type === 'success')
                    ListarMarca();

            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
}


let let_intIdMarcaGesMar;
function editarMarca(intIdMarca_) {

   
    //Acción del Boton Guardar
    $('#btn_save_new_marca').hide();
    //Acción del Boton Actualizar
    $('#btn_update_marca').show();


    $.post(
        '/Procesos/ObtenerRegistroMarcaPorPk',
        { intIdMarca: intIdMarca_ },
        (response) => {
            console.log(response);
            response.forEach(element => {

                let_intIdMarcaGesMar = element.intIdMarca;
                $('#val_txtCodigoMarca').val(element.strCodigoMarca);
                $('#val_txtDescMarca').val(element.strDescMarca);
                //$('#str-activo').val(element.strActivo);
                ////////$('#txt_DirFiscal').val(element.strDirFiscal);

                //$.post(
                //    '/Personal/ListarCombosPersonal',
                //    { strEntidad: 'TGTIPO', intIdFiltroGrupo: 0, strGrupo: 'EMP', strSubGrupo: 'TIPO' },
                //    (response) => {
                //        $('#CampTipo').empty();
                //        $('#CampTipo').append('<option value="0">Seleccione</option>');
                //        response.forEach(element2 => {
                //            $('#CampTipos').append('<option value="' + element2.intidTipo + '">' + element2.strDeTipo + '</option>');
                //            if (element2.intidTipo == element.intTipoEmp) {
                //                $('#CampTipos').val(element.intTipoEmp);
                //            }
                //        });

                //    });


                ////////$('#VistaPrevia').html('<img src = ' + element.imgLogo + ' style="width:100%;height:100%" />');
                ////////$('#txtImagenEmpresa').val(element.imgLogo);
                ////////$('#intidEmpresa').val(element.IntIdEmp);

                ////////if (element.bitFlActivo == false) {

                ////////    $('#idche').html(' <input type="checkbox" id="chk-activo-Empresa" class="js-switch" id="chk-activo-JO"/> Activo');
                ////////    // $('#chck_Activo_Var').iCheck('uncheck');


                ////////} else if (element.bitFlActivo == true) {
                ////////    $('#idche').html(' <input type="checkbox" id="chk-activo-Empresa" class="js-switch" id="chk-activo-JO" checked /> Activo');
                ////////}

                $('.form-hide-MARCA').show();

            });

        });

}



//function taerUltimaMarca(){

//    $.post(
//        '/Procesos/ListarCombosGestionar',
//        {
//            strNomTablaEntidad: 'ULTIMO_CODIGO_MARCA', intParametroEntero: 1
//        },
//        response => {

//            //alert(response[0].intIdMarca);

//            //$("#val_intCantTotalActual").val(response[0].intIdMarca);


//            return true;
       
//        });

//}




let trueFalse = false;
$('#btn-new-marca').on('click', function () {

    //var res = taerUltimaMarca(false);

    //if (res ) {

    //    return;
    //}
    //alert(111);
    //$('#CampTipos').val(0);   //selected
    //$('#txt_cod_Empresa').val('');
    //$('#txt_desc_Empresa').val('');
    //$('#txt_Ruc').val('');
    //$('#txt_DirFiscal').val('');
    //$('#VistaPrevia').html('<img src = "/DirLogosRuta/descarga(1)_1.jpg" style="width:100%;height:100%" />');
    //$('#txtImagenEmpresa').val('');


    //trueFalse

        $.post(
        '/Procesos/ListarCombosGestionar',
        {
            strNomTablaEntidad: 'ULTIMO_CODIGO_MARCA', intParametroEntero: 1
        },
            response => {


                if (response.length > 0) {
                    //alert(response[0].strDescEntidad);
                    $("#val_txtCodigoMarca").val(response[0].strDescEntidad);
                }

                $('#btn_save_new_marca').show();
                $('#btn_update_marca').hide();
                $('.form-hide-MARCA').show();


            });


    //////$.post(
    //////    '/Proceso/MaestroMaxCaracteres',
    //////    { StrNomMan: 'TGEMPRESA' },
    //////    (response) => {
    //////        response.forEach(element => {


    //////            if (element.NombreColum == 'strCoEmp') {
    //////                $('#' + element.NombreColum + '').empty();
    //////                $('#' + element.NombreColum + '').append(' <label>Código (*)</label>' +
    //////                    '<input type = "text" id = "txt_cod_Empresa" class= "form-control" placeholder = "Código" ' +
    //////                    'maxlength="' + element.intNumero + '" onkeyup="this.value=NumText(this.value)"><div id="notifry_error" style="background-color:#4CA4DE;color:white;text-align:center;"></div>');
    //////            } else if (element.NombreColum == 'strDesEmp') {
    //////                $('#' + element.NombreColum + '').empty();
    //////                $('#' + element.NombreColum + '').append('<label>Razón Social (*)</label>' +
    //////                    '<input type = "text" id = "txt_desc_Empresa" class= "form-control" placeholder = "Razón Social "   maxlength="' + element.intNumero + '" onkeyup="this.value=CaracteresValidos(this.value)"><div id="notifry_errordes" style="background-color:#4CA4DE;color:white;text-align:center;"></div>');
    //////            } else if (element.NombreColum == 'strRuc') {
    //////                $('#' + element.NombreColum + '').empty();
    //////                // $('#' + element.NombreColum + '').append('<input id="txt_Ruc" placeholder = "Ruc" class="form-control" type="number" maxlength="' + element.intNumero + '"  >');
    //////                $('#' + element.NombreColum + '').append('<input class= "form-control" id="txt_Ruc"' +
    //////                    'oninput = "javascript: if (this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"' +
    //////                    'type = "number"  maxlength = "' + element.intNumero + '"  placeholder = "Ruc"><div id="notifry_error_ruc" style="background-color:#4CA4DE;color:white;text-align:center;"></div>');

    //////            }
    //////            else if (element.NombreColum == 'strDirFiscal') {
    //////                $('#' + element.NombreColum + '').empty();
    //////                $('#' + element.NombreColum + '').append('<input id="txt_DirFiscal" class="form-control" placeholder="Dirección fiscal" maxlength="' + element.intNumero + '"  >');

    //////                //$("#txt_cod_Empresa").keyup(function () {
    //////                //    $("#notifry_error").html('');
    //////                //    document.getElementById("txt_cod_Empresa").style.borderColor = "#CCCCCC";
    //////                //});

    //////                //$("#txt_desc_Empresa").keyup(function () {
    //////                //    $("#notifry_errordes").html('');
    //////                //    document.getElementById("txt_desc_Empresa").style.borderColor = "#CCCCCC";
    //////                //});

    //////                //$("#txt_Ruc").keyup(function () {
    //////                //    $("#notifry_error_ruc").html('');
    //////                //    document.getElementById("txt_Ruc").style.borderColor = "#CCCCCC";
    //////                //});

    //////            }

               

    //////        });
    //////    });





});


//////////////////////////////////////////////////////////////////
//BOTON GUARDAR
//////////////////////////////////////////////////////////////////
$('#btn_save_new_marca').on('click', function () {

    var _codigo = $('#val_txtCodigoMarca').val();
    var _descrp = $('#val_txtDescMarca').val();
    //var _activo = $('#switcher-c').is(':checked');

    if (_codigo === '' || _descrp === '') {
        new PNotify({
            title: 'NUEVA MARCA',
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

    
    var Marca = {

          intIdMarca          : 1 //AL INSERTAR      
        , strCodigoMarca      : _codigo    
        , strDescMarca        : _descrp      
        , strRutaImagenMarca  : ""//_strRutaImagenMarca  _codigo
        , bitFlEliminado      : 0 //_bitFlEliminado  

    };




    $.post(
        '/Procesos/InsertUpdateMarcaGesMar',
        { ObjMarca: Marca, intTipoOperacion: 1 },
        (response) => {

            ///////////////////////////////////////////////////
            console.log(response);
            if (response.type !== '') {

                if (response.type === 'success') {
                    new PNotify({
                        title: 'NNUEVA MARCA',
                        text: response.message,
                        type: response.type,
                        delay: 2500,
                        styling: 'bootstrap3'
                    });

                    //ListarGestionarProductos();
                    //HideFormEditarAnimation();
                    //ShowFormListadoAnimation();
                    //limpiarControlesInsertarProducto();
                    ListarMarca();
                    $('.form-hide-MARCA').hide();
                    //$('.form-listado-producto').show();
                    //////$('.form-hide-Empresa').hide();
                    //////TablaEmpresa();

                }

                else {  //Cuando el codigo ya esta registrado
                    if (response.type === 'error') {

                        //var nomMantemiento = 'Producto';
                        //var campo = 'txt_cod_Empresa';
                        //var msj = response.message;
                        //var response = "info";
                        //var deta = 'notifry_error';
                        //Pintar el borde del textbox del error en cuestion (del codigo)
                        //////document.getElementById("txt_cod_Empresa").style.borderColor = "#3498dbe0";
                        INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                        return;

                        //-------------------
                        //document.getElementById("txt_cod_Empresa").style.borderColor = "#3498dbe0";
                        //new PNotify({
                        //    title: 'Información de Unidad Organizacional',
                        //    text: 'El código ya está registrado',
                        //    type: 'info',
                        //    delay: 3000,
                        //    styling: 'bootstrap3',
                        //    addclass: 'dark'

                        //});
                        //return;
                    }

                    else { //Cuando el razon social(o descripcion) ya esta registrado
                        if (response.type === 'info') {

                            //var nomMantemiento = 'Empresa';
                            //var campo = 'txt_desc_Empresa';
                            //var msj = response.message;
                            //var response = "info";
                            //var deta = 'notifry_errordes';
                            //Pintar el borde del textbox del error en cuestion (la razon social)
                            //////document.getElementById("txt_desc_Empresa").style.borderColor = "#3498dbe0";

                            INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                            return;
                        }

                        else {
                            //new PNotify({
                            //    title: 'Nueva Empresa_Linea 42957',
                            //    text: response.message,
                            //    type: 'info',
                            //    delay: 3000,
                            //    styling: 'bootstrap3'
                            //    });

                            //var nomMantemiento = 'Empresa';
                            //var campo = 'txt_Ruc';
                            //var msj = response.message;
                            //var response = "info";
                            //var deta = 'notifry_error_ruc';
                            //Pintar el borde del textbox del error en cuestion (la razon social)
                            ////////document.getElementById("txt_Ruc").style.borderColor = "#3498dbe0";

                            INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                            return;

                        }

                    }


                }

            }


            /////////////////////////////////////////////////
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });

});



//////////////////////////////////////////////////////////////////
//BOTON ACTUALIZAR
//////////////////////////////////////////////////////////////////
$('#btn_update_marca').on('click', function () {

    var _codigo = $('#val_txtCodigoMarca').val();
    var _descrp = $('#val_txtDescMarca').val();
    //var _activo = $('#switcher-c').is(':checked');

    if (_codigo === '' || _descrp === '') {
        new PNotify({
            title: 'NUEVA MARCA',
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


    var Marca = {

          intIdMarca: let_intIdMarcaGesMar //AL INSERTAR      
        , strCodigoMarca: _codigo
        , strDescMarca: _descrp
        , strRutaImagenMarca: ""//_strRutaImagenMarca  _codigo
        , bitFlEliminado: 0 //_bitFlEliminado  

    };




    $.post(
        '/Procesos/InsertUpdateMarcaGesMar',
        { ObjMarca: Marca, intTipoOperacion: 2 },
        (response) => {

            ///////////////////////////////////////////////////
            console.log(response);
            if (response.type !== '') {

                if (response.type === 'success') {
                    new PNotify({
                        title: 'ACTUALIZAR MARCA',
                        text: response.message,
                        type: response.type,
                        delay: 2500,
                        styling: 'bootstrap3'
                    });

                    //ListarGestionarProductos();
                    //HideFormEditarAnimation();
                    //ShowFormListadoAnimation();
                    //limpiarControlesInsertarProducto();
                    ListarMarca();
                    $('.form-hide-MARCA').hide();
                    //$('.form-listado-producto').show();
                    //////$('.form-hide-Empresa').hide();
                    //////TablaEmpresa();

                }

                else {  //Cuando el codigo ya esta registrado
                    if (response.type === 'error') {

                        //var nomMantemiento = 'Producto';
                        //var campo = 'txt_cod_Empresa';
                        //var msj = response.message;
                        //var response = "info";
                        //var deta = 'notifry_error';
                        //Pintar el borde del textbox del error en cuestion (del codigo)
                        //////document.getElementById("txt_cod_Empresa").style.borderColor = "#3498dbe0";
                        INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                        return;

                        //-------------------
                        //document.getElementById("txt_cod_Empresa").style.borderColor = "#3498dbe0";
                        //new PNotify({
                        //    title: 'Información de Unidad Organizacional',
                        //    text: 'El código ya está registrado',
                        //    type: 'info',
                        //    delay: 3000,
                        //    styling: 'bootstrap3',
                        //    addclass: 'dark'

                        //});
                        //return;
                    }

                    else { //Cuando el razon social(o descripcion) ya esta registrado
                        if (response.type === 'info') {

                            //var nomMantemiento = 'Empresa';
                            //var campo = 'txt_desc_Empresa';
                            //var msj = response.message;
                            //var response = "info";
                            //var deta = 'notifry_errordes';
                            //Pintar el borde del textbox del error en cuestion (la razon social)
                            //////document.getElementById("txt_desc_Empresa").style.borderColor = "#3498dbe0";

                            INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                            return;
                        }

                        else {
                            //new PNotify({
                            //    title: 'Nueva Empresa_Linea 42957',
                            //    text: response.message,
                            //    type: 'info',
                            //    delay: 3000,
                            //    styling: 'bootstrap3'
                            //    });

                            //var nomMantemiento = 'Empresa';
                            //var campo = 'txt_Ruc';
                            //var msj = response.message;
                            //var response = "info";
                            //var deta = 'notifry_error_ruc';
                            //Pintar el borde del textbox del error en cuestion (la razon social)
                            ////////document.getElementById("txt_Ruc").style.borderColor = "#3498dbe0";

                            INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                            return;

                        }

                    }


                }

            }


            /////////////////////////////////////////////////
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });

});




//////////////////////////////////////////////////////////////////////////////////////////////////////////////













