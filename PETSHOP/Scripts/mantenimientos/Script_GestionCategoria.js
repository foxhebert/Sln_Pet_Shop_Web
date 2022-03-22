
//https://stackoverflow.com/questions/9067892/how-to-align-two-elements-on-the-same-line-without-changing-html
//https://stackoverflow.com/questions/45446910/jquery-datatables-align-center-1-column
//align = "center"

//https://datatables.net/reference/type/column-selector
//https://stackoverflow.com/questions/10675427/how-to-align-td-elements-in-center

$(document).ready(function () {

    //AÑADIDO EN DURO PARA CADA JS DE CADA VENTANA
    $('#fx_13_02_22_menu_actual').html('CATEGORÍAS');
    //$('#fx_13_02_22_menu_actual').html('Categorías');

});

$('#cboActivo').on('change', function () {
    ListadoCategoria();
});

$('#txt-filtro-categoria').keyup(function () {
    ListadoCategoria();
});


var _varTablaCategoria;
function ListadoCategoria() {

    var strActivo_  = $('#cboActivo').val();
    var strFiltro_  = $('#txt-filtro-categoria').val();


    $.post(
        '/Procesos/ListarCategoria',  
        //'/Personal/GetTablaEmpresa',  
        { intIdCategoria: 1, strActivo: strActivo_, strFiltro: strFiltro_},
        (response) => {
            console.log(response);

            if (typeof _varTablaCategoria !== 'undefined') {
                _varTablaCategoria.destroy();
            }
            _varTablaCategoria = $('#TablaCategoria').DataTable({
                data: response,
                columns: [

                    { data: 'intIdCategoria'     },
                    { data: 'strCodigoBarraCate' },
                    { data: 'strCodigoCategoria' },
                    { data: 'strDescCategoria'   },
                    //{ data: 'strTipoEmp' },
                    //{ data: 'strDesEstado' },
                    {
                        sortable: false,
                        "render": (data, type, item, meta) => {
                            let IntIdntificador = item.intIdCategoria;
                            let strDescripcion = item.strDescCategoria;
                            return `<div style="display: flex;"><button class="btn btn-success btn-xs btn-edit" dataid="${IntIdntificador}" ><i class="fa fa-pencil"></i> Editar </button> 
                                           <button class="btn btn-primary btn-xs btn-delete" dataid="${IntIdntificador}" des_data="${strDescripcion}" data="${item}" ><i class="fa fa-trash-o"></i> Eliminar </button></div>`;
                        }
                    }

                ],
                lengthMenu: [10, 25, 50],
                order: [1, 'asc'],
                responsive: true,
                language: _datatableLanguaje,
                'columnDefs': [
                    {
                        targets   : [1],//dos columnas escondidas
                        visible   : false,
                        searchable: false
                    }
                    ,
                    {
                        targets  : [4],//dos columnas escondidas
                        "className": "text-center",
                        "width": "4%"
                    }
                   
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

$('#TablaCategoria  tbody').on('click', 'tr button.btn-delete', function () {

    let Identidier = $(this).attr("dataid")
    let Descripcion = $(this).attr("des_data")
    if (!isNaN(Identidier)) {
        intentEliminarCategoria(Identidier, Descripcion)
    }

});

$('#TablaCategoria tbody').on('click', 'tr button.btn-edit', function () {

    let intId = $(this).attr("dataid");

    if (!isNaN(intId)) {
        editarCategoria(intId);
    }

});

function intentEliminarCategoria(Identifier, Descripcion) {
    swal({
        title: "Eliminar Empresa",
        text: "¿Está seguro de eliminar la Empresa   ''<strong>" + Descripcion + "</strong>''?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sí, eliminar",
        cancelButtonText: "No, cancelar",
    }).then(function (isConfirm) {
        if (isConfirm) {
            yesEliminaCategoria(Identifier);
        } else {
            swal("Cancelado", "La Operación fue cancelada", "error");
        }
    });
}

function yesEliminaCategoria(Identifier) {

    $.post(
        '/Procesos/EliminarCategoria',
        { intIdCategoria: Identifier},
        (response) => {
            console.log(response);
            if (response.type !== '') {
                var tipo = 'Eliminado!';
                if (response.type === 'error')
                    tipo = 'NO SE PUEDE ELIMINAR EL REGISTRO';
                swal(tipo, response.message, response.type);

                if (response.type === 'success')
                    ListadoCategoria();

            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
}

function editarCategoria(intIdCategoria_) {

    $('.form-hide-CATEGORIA').hide();
    //Acción del Boton Guardar
    $('#btn_save_change_Empresa').hide();
    //Acción del Boton Actualizar
    $('#btn_update_Empresa').show();

    //var SesionMovi = {
    //    IntIdMenu: 'M0202',
    //    intIdUsuario: idUsuar,
    //    intIdSoft: idSoftw,
    //    intIdSesion: intIdSe
    //}

    $.post(
        '/Procesos/ObtenerRegistroCategoria',
        { intIdCategoria: intIdCategoria_ },
        (response) => {
            console.log(response);
            response.forEach(element => {

                $('#txt-codigo-categoria').val(element.strCodigoCategoria);
                $('#txt-descripcion-categoria').val(element.strDescCategoria);
                $('#str-activo').val(element.strActivo);
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

                $('.form-hide-CATEGORIA').show();

            });

        });

}

$('#btn-nuevo-registro-CATEGORIA').on('click', function () {

    $('.form-hide-CATEGORIA').show();

    //////////$('#CampTipos').val(0);   //selected
    //////////$('#txt_cod_Empresa').val('');
    //////////$('#txt_desc_Empresa').val('');
    //////////$('#txt_Ruc').val('');
    //////////$('#txt_DirFiscal').val('');
    //////////$('#VistaPrevia').html('<img src = "/DirLogosRuta/person_logo_1.jpg" style="width:100%;height:100%" />');
    //////////$('#txtImagenEmpresa').val('');
    //////////$('#btn_save_change_Empresa').show();
    //////////$('#btn_update_Empresa').hide();


    ////////$.post(
    ////////    '/Proceso/MaestroMaxCaracteres',
    ////////    { StrNomMan: 'TGEMPRESA' },
    ////////    (response) => {
    ////////        response.forEach(element => {


    ////////            if (element.NombreColum == 'strCoEmp') {
    ////////                $('#' + element.NombreColum + '').empty();
    ////////                $('#' + element.NombreColum + '').append(' <label>Código (*)</label>' +
    ////////                    '<input type = "text" id = "txt_cod_Empresa" class= "form-control" placeholder = "Código" ' +
    ////////                    'maxlength="' + element.intNumero + '" onkeyup="this.value=NumText(this.value)"><div id="notifry_error" style="background-color:#4CA4DE;color:white;text-align:center;"></div>');
    ////////            } else if (element.NombreColum == 'strDesEmp') {
    ////////                $('#' + element.NombreColum + '').empty();
    ////////                $('#' + element.NombreColum + '').append('<label>Razón Social (*)</label>' +
    ////////                    '<input type = "text" id = "txt_desc_Empresa" class= "form-control" placeholder = "Razón Social "   maxlength="' + element.intNumero + '" onkeyup="this.value=CaracteresValidos(this.value)"><div id="notifry_errordes" style="background-color:#4CA4DE;color:white;text-align:center;"></div>');
    ////////            } else if (element.NombreColum == 'strRuc') {
    ////////                $('#' + element.NombreColum + '').empty();
    ////////                // $('#' + element.NombreColum + '').append('<input id="txt_Ruc" placeholder = "Ruc" class="form-control" type="number" maxlength="' + element.intNumero + '"  >');
    ////////                $('#' + element.NombreColum + '').append('<input class= "form-control" id="txt_Ruc"' +
    ////////                    'oninput = "javascript: if (this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"' +
    ////////                    'type = "number"  maxlength = "' + element.intNumero + '"  placeholder = "Ruc"><div id="notifry_error_ruc" style="background-color:#4CA4DE;color:white;text-align:center;"></div>');

    ////////            }
    ////////            else if (element.NombreColum == 'strDirFiscal') {
    ////////                $('#' + element.NombreColum + '').empty();
    ////////                $('#' + element.NombreColum + '').append('<input id="txt_DirFiscal" class="form-control" placeholder="Dirección fiscal" maxlength="' + element.intNumero + '"  >');

    ////////                //$("#txt_cod_Empresa").keyup(function () {
    ////////                //    $("#notifry_error").html('');
    ////////                //    document.getElementById("txt_cod_Empresa").style.borderColor = "#CCCCCC";
    ////////                //});

    ////////                //$("#txt_desc_Empresa").keyup(function () {
    ////////                //    $("#notifry_errordes").html('');
    ////////                //    document.getElementById("txt_desc_Empresa").style.borderColor = "#CCCCCC";
    ////////                //});

    ////////                //$("#txt_Ruc").keyup(function () {
    ////////                //    $("#notifry_error_ruc").html('');
    ////////                //    document.getElementById("txt_Ruc").style.borderColor = "#CCCCCC";
    ////////                //});

    ////////            }

    ////////        });
    ////////    });


    //////EstablecerRUC();
    //////init_checkBox_styles();
    ////////switcheryLoad();
    //////CombosEmpresa();
    //////$('.form-hide-Empresa').show();

});


















$('#btn-nuevo-registro-CATEGORIA_o').on('click', function () {

    $('.form-hide-CATEGORIA').show();

    //$('#CampTipos').val(0);   //selected
    //$('#txt_cod_Empresa').val('');
    //$('#txt_desc_Empresa').val('');
    //$('#txt_Ruc').val('');
    //$('#txt_DirFiscal').val('');
    //$('#VistaPrevia').html('<img src = "/DirLogosRuta/person_logo_1.jpg" style="width:100%;height:100%" />');
    //$('#txtImagenEmpresa').val('');
    //$('#btn_save_change_Empresa').show();
    //$('#btn_update_Empresa').hide();


    $.post(
        '/Proceso/MaestroMaxCaracteres',
        { StrNomMan: 'TGEMPRESA' },
        (response) => {
            response.forEach(element => {


                if (element.NombreColum == 'strCoEmp') {
                    $('#' + element.NombreColum + '').empty();
                    $('#' + element.NombreColum + '').append(' <label>Código (*)</label>' +
                        '<input type = "text" id = "txt_cod_Empresa" class= "form-control" placeholder = "Código" ' +
                        'maxlength="' + element.intNumero + '" onkeyup="this.value=NumText(this.value)"><div id="notifry_error" style="background-color:#4CA4DE;color:white;text-align:center;"></div>');
                } else if (element.NombreColum == 'strDesEmp') {
                    $('#' + element.NombreColum + '').empty();
                    $('#' + element.NombreColum + '').append('<label>Razón Social (*)</label>' +
                        '<input type = "text" id = "txt_desc_Empresa" class= "form-control" placeholder = "Razón Social "   maxlength="' + element.intNumero + '" onkeyup="this.value=CaracteresValidos(this.value)"><div id="notifry_errordes" style="background-color:#4CA4DE;color:white;text-align:center;"></div>');
                } else if (element.NombreColum == 'strRuc') {
                    $('#' + element.NombreColum + '').empty();
                    // $('#' + element.NombreColum + '').append('<input id="txt_Ruc" placeholder = "Ruc" class="form-control" type="number" maxlength="' + element.intNumero + '"  >');
                    $('#' + element.NombreColum + '').append('<input class= "form-control" id="txt_Ruc"' +
                        'oninput = "javascript: if (this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"' +
                        'type = "number"  maxlength = "' + element.intNumero + '"  placeholder = "Ruc"><div id="notifry_error_ruc" style="background-color:#4CA4DE;color:white;text-align:center;"></div>');

                }
                else if (element.NombreColum == 'strDirFiscal') {
                    $('#' + element.NombreColum + '').empty();
                    $('#' + element.NombreColum + '').append('<input id="txt_DirFiscal" class="form-control" placeholder="Dirección fiscal" maxlength="' + element.intNumero + '"  >');

                    //$("#txt_cod_Empresa").keyup(function () {
                    //    $("#notifry_error").html('');
                    //    document.getElementById("txt_cod_Empresa").style.borderColor = "#CCCCCC";
                    //});

                    //$("#txt_desc_Empresa").keyup(function () {
                    //    $("#notifry_errordes").html('');
                    //    document.getElementById("txt_desc_Empresa").style.borderColor = "#CCCCCC";
                    //});

                    //$("#txt_Ruc").keyup(function () {
                    //    $("#notifry_error_ruc").html('');
                    //    document.getElementById("txt_Ruc").style.borderColor = "#CCCCCC";
                    //});

                }

            });
        });


    EstablecerRUC();
    init_checkBox_styles();
    //switcheryLoad();
    CombosEmpresa();
    $('.form-hide-Empresa').show();

});













//////var _varTablaEmpresa;

//////function TablaEmpresa() {

//////    var SesionMovi = {
//////        IntIdMenu: 'M0202',
//////        intIdUsuario: idUsuar,
//////        intIdSoft: idSoftw,
//////        intIdSesion: intIdSe
//////    }

//////    var Activo = $('#bitActivo').val();
//////    var Descipción = $('#strCodigos').val();
//////    var Tipo = $('#CampTipo').val();


//////    $.post(
//////        '/Personal/GetTablaEmpresa',  //llama a GetTablaEmpresa una vez
//////        { objSession: SesionMovi, intActivo: Activo, strDescripcion: Descipción, intTipoEmp: Tipo },
//////        (response) => {
//////            console.log(response);

//////            if (typeof _varTablaEmpresa !== 'undefined') {
//////                _varTablaEmpresa.destroy();
//////            }
//////            _varTablaEmpresa = $('#TablaEmpresa').DataTable({
//////                data: response,
//////                columns: [

//////                    { data: 'IntIdEmp' },
//////                    { data: 'strCoEmp' },
//////                    { data: 'strDesEmp' },
//////                    { data: 'strRuc' },
//////                    { data: 'strTipoEmp' },
//////                    { data: 'strDesEstado' },
//////                    //{ data: 'strEmpresaCampo1'}

//////                    {
//////                        sortable: false,
//////                        "render": (data, type, item, meta) => {
//////                            let IntIdEmp = item.IntIdEmp;
//////                            let strDesEmp = item.strDesEmp;
//////                            return `<button class="btn btn-success btn-xs btn-edit" dataid="${IntIdEmp}" ><i class="fa fa-pencil"></i> Editar </button> 
//////                                           <button class="btn btn-primary btn-xs btn-delete" dataid="${IntIdEmp}" des_data="${strDesEmp}" data="${item}" ><i class="fa fa-trash-o"></i> Eliminar </button>`;
//////                        }
//////                    }

//////                ],
//////                lengthMenu: [10, 25, 50],
//////                order: [1, 'asc'],
//////                responsive: true,
//////                language: _datatableLanguaje,
//////                columnDefs: [
//////                    {
//////                        targets: [0],
//////                        visible: false,
//////                        searchable: false
//////                    }
//////                ],
//////                dom: 'lBfrtip',
//////            });


//////            //Estas lineas generaba que al editar llame métodos varias veces para una misma acción
//////            //$('#TablaEmpresa  tbody').on('click', 'tr button.btn-edit', function () {

//////            //    let EmpresaId = $(this).attr("dataid")

//////            //    if (!isNaN(EmpresaId)) {
//////            //        editarEmpresa(EmpresaId)
//////            //    }

//////            //});

//////            $('#TablaEmpresa  tbody').on('click', 'tr button.btn-delete', function () {

//////                let EmpresaId = $(this).attr("dataid")
//////                let Descripcion = $(this).attr("des_data")
//////                if (!isNaN(EmpresaId)) {
//////                    intentEliminarEmpresa(EmpresaId, Descripcion)
//////                }

//////            });

//////        });

//////}
