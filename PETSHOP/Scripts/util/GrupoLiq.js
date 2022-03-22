var _varTablaGrupo;

function getTableGrupoLiq() {

    var cboUniOrg = $("#cboUniOrg").val()
    var cboPlanilla = $("#cboPlanilla").val()
    var filtroGrupoLiq = $("#filtroGrupoLiq").val()
    var filtroActivo = $("#filtroActivo").val()
    var periodoFiltroId = $("#periodoFiltroId").val()

    $.ajax({
        url: '/Proceso/ListarGrupoLiq',
        type: 'POST',
        data:
        {
            filtroUniOrg: cboUniOrg,
            filtroPlanilla: cboPlanilla,
            filtroGrupoLiq: filtroGrupoLiq,
            filtroActivo: filtroActivo,
            filtroPeriodo: periodoFiltroId
        },
        beforeSend: function () {
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
                message: 'Procesando...'
            });
        },
        success: function (response) {
            console.log(response)

            if (typeof _varTablaGrupo !== 'undefined') {
                _varTablaGrupo.destroy();
            }

            _varTablaGrupo = $('#datatable-GrupoLiq').DataTable({
                data: response,
                columns: [
                    { data: 'strCoGrupoLiq' },
                    { data: 'strDesGrupoLiq' },
                    { data: 'strDesPeriodo' },
                    { data: 'strEstadoActivo' },
                    {
                        sortable: false,
                        "render": (data, type, item, meta) => {
                            var intIdGrupoLiq = item.intIdGrupoLiq;
                            var strDesGrupoLiq = item.strDesGrupoLiq;

                            return `<button class="btn btn-success btn-xs btn-edit" onclick="editarGrupoLiq('${intIdGrupoLiq}');"><i class="fa fa-pencil"></i> Editar </button> 
                                    <button class="btn btn-primary btn-xs btn-delete" dataid="${intIdGrupoLiq}" des_data="${strDesGrupoLiq}"><i class="fa fa-trash-o"></i> Eliminar </button>`;
                        }
                    }
                ],
                lengthMenu: [10, 25, 50],
                order: [],
                responsive: true,
                language: _datatableLanguaje,
                columnDefs: [],
                dom: 'lBfrtip',
            });

            $('#datatable-GrupoLiq tbody').on('click', 'tr button.btn-delete', function () {
                validarSession()
                var intIdGrupoLiq = $(this).attr("dataid");
                var strDesGrupoLiq = $(this).attr("des_data");

                if (!isNaN(intIdGrupoLiq)) {

                    swal({
                        title: "Eliminar Grupo de Liquidación",
                        text: "¿Está seguro de eliminar el Grupo de liquidación ''<strong>" + strDesGrupoLiq + "</strong>'' ?",
                        type: "warning",
                        showCancelButton: true,
                        confirmButtonText: "Sí, eliminar",
                        cancelButtonText: "No, cancelar",
                    }).then(function (isConfirm) {
                        validarSession()
                        $.post(
                            '/Proceso/EliminaGrupoLiq',
                            { intIdGrupoLiq: intIdGrupoLiq },
                            (response) => {
                                if (response.type !== '') {
                                    var tipo = 'Eliminado!';
                                    if (response.type === 'error')
                                        tipo = 'NO SE PUEDE ELIMINAR EL REGISTRO';
                                    swal(tipo, response.message, response.type);

                                    if (response.type === 'success') {
                                        $("#btn-cancel-periodo").click()
                                        getTableGrupoLiq();
                                    }
                                }
                            }
                        ).fail(function (result) {
                            alert('ERROR ' + result.status + ' ' + result.statusText);
                        });
                    }, function (dismiss) {
                        if (dismiss == 'cancel') {
                            swal("Cancelado", "La Operación fue cancelada", "error");
                        }
                    });

                }

            });
        },
        complete: function () {
            $.unblockUI();
        }

    });
}

$('#btn-new-grupoliq').on('click', function () {
    validarSession()
    cleanForm()
    $("#btn-save-change-grupoliq").val("Guardar")
    $("#btn-save-change-grupoliq").removeClass();
    $("#btn-save-change-grupoliq").addClass("btn");
    $("#btn-save-change-grupoliq").addClass("btn btn-primary");
    $("#grupoLiqId").val('')
    $('.form-hide-grupoliq').show();
    CamposAdicionalesGrupoLiq()

    $.post(
        '/Proceso/ListarCombosProceso',
        {
            intIdMenu: 0, strEntidad: 'TGJERARQORG', intIdFiltroGrupo: 0, strGrupo: 'DEPEN', strSubGrupo: '',
        },
        response2 => {
            $('#dependenciaJerId').empty()
            $('#dependenciaJerId').append('<option value="0">Seleccione</option>')
            response2.forEach(element => {
                $('#dependenciaJerId').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
            })
        })

});

$("#filtroActivo, #filtroGrupoLiq, #periodoFiltroId, #cboUniOrg, #cboPlanilla").change(function () {
    validarSession()
    getTableGrupoLiq()
})

function CamposAdicionalesGrupoLiq(dato) {

    $.post(
        '/Proceso/ListarCamposAdicionales',
        { strNoEntidad: 'TGGRUPOLIQ' },
        (response) => {
            console.log(response);
            $('#containerCampos').empty();
            response.forEach(element => {
                $('#containerCampos').append(
                    ' <div class="col-md-6 col-sm-6 col-xs-6"><div class="form-group"><label> ' + element.strTitulo
                    + '</label><input id="' + element.strNomCampo + '" type="text" class="form-control " placeholder="Campo Adicional" maxlength="255"/>' + '</div></div>');
            });
            if (dato != null) {
                $('#strGrupoLiqCampo1').val(dato.strGrupoLiqCampo1)
                $('#strGrupoLiqCampo2').val(dato.strGrupoLiqCampo2)
                $('#strGrupoLiqCampo3').val(dato.strGrupoLiqCampo3)
                $('#strGrupoLiqCampo4').val(dato.strGrupoLiqCampo4)
                $('#strGrupoLiqCampo5').val(dato.strGrupoLiqCampo5)
            }
        });
}

function editarGrupoLiq(intIdGrupoLiq) {
    validarSession()
    cleanForm()
    $.post(
        '/Proceso/ObtenerGrupoLiqPorsuPK',
        {
            intIdGrupoLiq: intIdGrupoLiq,
        },
        (response) => {
            console.log(response)

            $.post(
                '/Proceso/ListarCombosProceso',
                {
                    intIdMenu: 0, strEntidad: 'TGPERIODO', intIdFiltroGrupo: response.intIdPlanilla, strGrupo: 'TGPERIODO', strSubGrupo: '',
                },
                response2 => {
                    $('#periodoId').empty()
                    $('#periodoId').append('<option value="0">Seleccione</option>')
                    response2.forEach(element => {
                        if (element.intidTipo == response.intIdPeriodo) {
                            $('#periodoId').append('<option selected value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                        } else {
                            $('#periodoId').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                        }
                    })
                });

            $.post('/Proceso/ListarCombosProceso', {
                intIdMenu: 0, strEntidad: 'TGPLANILLA', intIdFiltroGrupo: response.intIdUniOrg, strGrupo: 'TGPLANILLA', strSubGrupo: '',
            }, response3 => {
                $('#planillaId').empty()
                $('#planillaId').append('<option value="0">Seleccione</option>')
                response3.forEach(element => {
                    if (element.intidTipo == response.intIdPlanilla) {
                        $('#planillaId').append('<option selected value="' + element.intidTipo + '" >' + element.strDeTipo + '</option>')
                    } else {
                        $('#planillaId').append('<option value="' + element.intidTipo + '" >' + element.strDeTipo + '</option>')
                    }
                })
            }).fail(function (result) {
                alert('ERROR ' + result.status + ' ' + result.statusText)
            })

            $.post('/Organizacion/getUnidxJerarquia', { IntIdJerOrg: response.intIdJerOrg }, response4 => {
                $('#unidadOrgId').empty()
                $('#unidadOrgId').append('<option value="0">Seleccione</option>')
                response4.forEach(element => {
                    if (element.intIdUniOrg == response.intIdUniOrg) {
                        $('#unidadOrgId').append('<option selected value="' + element.intIdUniOrg + '" >' + element.strDescripcion + '</option>')
                    } else {
                        $('#unidadOrgId').append('<option value="' + element.intIdUniOrg + '" >' + element.strDescripcion + '</option>')
                    }
                })
            }).fail(function (result) {
                alert('ERROR ' + result.status + ' ' + result.statusText)
            })

            $.post(
                '/Proceso/ListarCombosProceso',
                {
                    intIdMenu: 0, strEntidad: 'TGJERARQORG', intIdFiltroGrupo: 0, strGrupo: 'DEPEN', strSubGrupo: '',
                },
                response5 => {
                    $('#dependenciaJerId').empty()
                    $('#dependenciaJerId').append('<option value="0">Seleccione</option>')
                    response5.forEach(element => {
                        if (element.intidTipo == response.intIdJerOrg) {
                            $('#dependenciaJerId').append('<option selected value="' + element.intidTipo + '" >' + element.strDeTipo + '</option>')
                        } else {
                            $('#dependenciaJerId').append('<option value="' + element.intidTipo + '" >' + element.strDeTipo + '</option>')
                        }
                    })
                })


            if (response.bitFlActivo == true) {
                $("#checkActivoId").html(`<input type="checkbox" class="js-switch" checked id="activoId" /> Activo`)
            } else if (response.bitFlActivo == false) {
                $("#checkActivoId").html(`<input type="checkbox" class="js-switch"  id="activoId" /> Activo`)
            }
            switcheryLoad()

            $("#grupoLiqId").val(response.intIdGrupoLiq)
            $("#btn-save-change-grupoliq").val("Actualizar")
            $("#btn-save-change-grupoliq").removeClass();
            $("#btn-save-change-grupoliq").addClass("btn");
            $("#btn-save-change-grupoliq").addClass("btn btn-success");
            $('#codigoId').val(response.strCoGrupoLiq)
            $('#descripcionId').val(response.strDesGrupoLiq)

            $('#periodoId').val(response.intIdPeriodo)

            var objDatos = {
                strGrupoLiqCampo1: response.strGrupoLiqCampo1,
                strGrupoLiqCampo2: response.strGrupoLiqCampo2,
                strGrupoLiqCampo3: response.strGrupoLiqCampo3,
                strGrupoLiqCampo4: response.strGrupoLiqCampo4,
                strGrupoLiqCampo5: response.strGrupoLiqCampo5
            }

            CamposAdicionalesGrupoLiq(objDatos)
            $('.form-hide-grupoliq').show();
        });
}

function cleanForm() {
    $(".notifry_error").html("")
    $("#checkActivoId").html(`<input type="checkbox" class="js-switch" checked id="activoId" /> Activo`)
    switcheryLoad()
    $('#codigoId').val("")
    $('#descripcionId').val("")
    $('#periodoId').val(0)
    $("#unidadOrgId").val(0)
    $("#planillaId").val(0)
}

$('#btn-save-change-grupoliq').on('click', function () {
    validarSession()
    var tipoOperacion = 1;
    var grupoLiqId = $("#grupoLiqId").val()
    var titulo = ""
    if (grupoLiqId == "") {
        tipoOperacion = 1
        titulo = "Registro Grupo de Liquidación"
    } else {
        tipoOperacion = 2
        titulo = "Actualizar Grupo de Liquidación"
    }

    var activoId = false
    if ($('#activoId').is(':checked')) { activoId = true }

    var codigoId = $('#codigoId').val()
    var descripcionId = $('#descripcionId').val()
    var periodoId = $('#periodoId').val()

    if ($('#strGrupoLiqCampo1').val() == null) {
        var _camp1 = null;
    } else {
        var _camp1 = $('#strGrupoLiqCampo1').val();
    } if ($('#strGrupoLiqCampo2').val() == null) {
        var _camp2 = null;
    } else {
        var _camp2 = $('#strGrupoLiqCampo2').val();
    } if ($('#strGrupoLiqCampo3').val() == null) {
        var _camp3 = null;
    } else {
        var _camp3 = $('#strGrupoLiqCampo3').val();
    } if ($('#strGrupoLiqCampo4').val() == null) {
        var _camp4 = null;
    } else {
        var _camp4 = $('#strGrupoLiqCampo4').val();
    } if ($('#strGrupoLiqCampo5').val() == null) {
        var _camp5 = null;
    } else {
        var _camp5 = $('#strGrupoLiqCampo5').val();
    }

    if (codigoId == "") {
        new PNotify({
            title: 'Ingresar codigo',
            text: 'Completar los campos Obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }
    if (descripcionId == "") {
        new PNotify({
            title: 'Ingresar descripción',
            text: 'Completar los campos Obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }
    if (periodoId == 0) {
        new PNotify({
            title: 'Asignar periodo',
            text: 'Completar los campos Obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }

    var datosGrupoLiq = {
        intIdGrupoLiq: grupoLiqId
        , strCoGrupoLiq: codigoId
        , strDesGrupoLiq: descripcionId
        , intIdPeriodo: periodoId
        , strGrupoLiqCampo1: _camp1
        , strGrupoLiqCampo2: _camp2
        , strGrupoLiqCampo3: _camp3
        , strGrupoLiqCampo4: _camp4
        , strGrupoLiqCampo5: _camp5
        , bitFlActivo: activoId
    }

    console.log(datosGrupoLiq)
    console.log("tipoOP -> " + tipoOperacion)

    $.post(
        '/Proceso/IUGrupoLiq',
        {
            objDatos: datosGrupoLiq,
            intTipoOperacion: tipoOperacion
        },
        (response) => {
            if (response.type == 'success') {
                new PNotify({
                    title: titulo,
                    text: response.message,
                    type: response.type,
                    delay: 3000,
                    styling: 'bootstrap3'
                });
                $("#btn-cancel-grupoliq").click()
                getTableGrupoLiq();
                return;
            }
            else {
                var list = response.message.split("|")
                if (list.length = 2) {
                    var nomMantemiento = 'Grupo Liquidación';
                    var campo = list[1];
                    var msj = list[0];
                    var response = 'info';
                    var deta = 'notifry_error';
                    INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                } else {
                    new PNotify({
                        title: 'Grupo',
                        text: response.message,
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'
                    });
                }
                return;
            }
        }
    );
});

$('#btn-cancel-grupoliq').on('click', function () {
    validarSession()
    $('.form-hide-grupoliq').hide();
});

function CombosGrupoLiq() {
    var intIdMenu = 0

    $.post(
        '/Proceso/ListarCombosProceso',
        {
            intIdMenu, strEntidad: 'TGUNIDORG', intIdFiltroGrupo: 2, strGrupo: 'JERAR', strSubGrupo: 'REPORTE',
        },
        response => {
            $('#cboUniOrg').empty()
            $('#cboUniOrg').append('<option value="0">Seleccione</option>')
            response.forEach(element => {
                $('#cboUniOrg').append('<option ruc="' + element.strextra1 + '" value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
            })

            $('#cboUniOrg').change(function () {
                $("#cboGenerar").attr("disabled", true)
                var intIdUniOrg = $(this).val()

                if (intIdUniOrg != 0) {
                    $.post(
                        '/Proceso/ListarCombosProceso',
                        {
                            intIdMenu, strEntidad: 'TGPLANILLAREGISTRO', intIdFiltroGrupo: intIdUniOrg, strGrupo: 'TGPLANILLAXUNIDAD', strSubGrupo: '',
                        },
                        response => {
                            $('#cboPlanilla').empty()
                            $('#cboPlanilla').append('<option value="0">Seleccione</option>')
                            if (response.length > 0) {
                                response.forEach(element => {
                                    $('#cboPlanilla').append('<option strCo="' + element.strextra1 + '" value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                                })
                                $("#cboPlanilla").attr("disabled", false)
                            } else {
                                $("#cboPlanilla").attr("disabled", true)
                            }

                        });

                }

            })

        });

    $("#cboPlanilla").change(function () {
        let id = $(this).val()
        if (id == '0') {
            $('#periodoFiltroId').empty()
            $('#periodoFiltroId').append('<option value="0">Seleccione</option>')
        } else {
            $.post(
                '/Proceso/ListarCombosProceso',
                {
                    intIdMenu, strEntidad: 'TGPERIODO', intIdFiltroGrupo: id, strGrupo: 'TGPERIODO', strSubGrupo: '',
                },
                response => {
                    $('#periodoFiltroId').empty()
                    $('#periodoFiltroId').append('<option value="0">Seleccione</option>')
                    response.forEach(element => {
                        $('#periodoFiltroId').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                    })
                });
        }
    })

    $('#dependenciaJerId').change(function () {
        let idDependencia = $(this).val()
        if (idDependencia == '0') {
            $('#unidadOrgId').empty()
            $('#unidadOrgId').append('<option value="0">Seleccione</option>')
        }
        $.post('/Organizacion/getUnidxJerarquia', { IntIdJerOrg: idDependencia }, response => {
            $('#unidadOrgId').empty()
            $('#unidadOrgId').append('<option value="0">Seleccione</option>')
            response.forEach(element => {
                $('#unidadOrgId').append('<option value="' + element.intIdUniOrg + '" >' + element.strDescripcion + '</option>')
            })
        }).fail(function (result) {
            alert('ERROR ' + result.status + ' ' + result.statusText)
        })
    })

    $('#unidadOrgId').change(function () {
        let idUnidad = $(this).val()
        if (idUnidad == '0') {
            $('#planillaId').empty()
            $('#planillaId').append('<option value="0">Seleccione</option>')
        }
        $.post('/Proceso/ListarCombosProceso', {
            intIdMenu, strEntidad: 'TGPLANILLAREGISTRO', intIdFiltroGrupo: idUnidad, strGrupo: 'TGPLANILLAXUNIDAD', strSubGrupo: ''
        }, response => {
            $('#planillaId').empty()
            $('#planillaId').append('<option value="0">Seleccione</option>')
            response.forEach(element => {
                $('#planillaId').append('<option value="' + element.intidTipo + '" >' + element.strDeTipo + '</option>')
            })
        }).fail(function (result) {
            alert('ERROR ' + result.status + ' ' + result.statusText)
        })
    })

    $('#planillaId').change(function () {
        var intIdPlanilla = $("#planillaId").val()
        $.post(
            '/Proceso/ListarCombosProceso',
            {
                intIdMenu, strEntidad: 'TGPERIODO', intIdFiltroGrupo: intIdPlanilla, strGrupo: 'TGPERIODO', strSubGrupo: '',
            },
            response => {
                $('#periodoId').empty()
                $('#periodoId').append('<option value="0">Seleccione</option>')
                response.forEach(element => {
                    $('#periodoId').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                })
            });
    })
}

$(document).ready(function () {

    getTableGrupoLiq()

    CombosGrupoLiq()

    var txtCod = 'strCoGrupoLiq';
    var txtdes = 'strDesGrupoLiq';

    $.post(
        '/Organizacion/ListarCaracteresMax',
        { strMaestro: 'TGGRUPOLIQ' },
        (response) => {
            response.forEach(element => {
                if (element.strColumnName == txtCod) {
                    $('#ValCode').children("input").attr('maxlength', element.intMaxLength);
                } if (element.strColumnName == txtdes) {
                    $('#Valdes').children("input").attr('maxlength', element.intMaxLength);
                }

            });
        });

})
