var _varTablaPeriodo;
var bCerrado = false;
//funcion 11.03.2021
function Bloquear(bit) {

    if (bit == 1) {
        $('#dependenciaJerId').attr("disabled", true);
        $('#unidadOrgId').attr("disabled", true);
        $('#planillaId').attr("disabled", true);
        $('#proyectoId').attr("disabled", true);
        $('#fechaIniID').attr("disabled", true);
        $('#fechaFinId').attr("disabled", true);
        $('#fechaCierreId').attr("disabled", true);
        $('#anioId').attr("disabled", true);
        $('#mesId').attr("disabled", true);
    } else {
        $('#dependenciaJerId').attr("disabled", false);
        $('#unidadOrgId').attr("disabled", false);
        $('#planillaId').attr("disabled", false);
        $('#proyectoId').attr("disabled", false);
        $('#fechaIniID').attr("disabled", false);
        $('#fechaFinId').attr("disabled", false);
        //$('#fechaCierreId').attr("disabled", false);
        $('#anioId').attr("disabled", false);
        $('#mesId').attr("disabled", false);
    }
}

function editarPeriodo(intIdPeriodo) {
    validarSession()
    cleanForm()
    $.post(
        '/Proceso/ObtenerPeriodoPorsuPK',
        {
            intIdPeriodo: intIdPeriodo,
        },
        (response) => {
            console.log(response)

            $.post(
                '/Proceso/ListarCombosProceso',
                {
                    intIdMenu: 0, strEntidad: 'TGJERARQORG', intIdFiltroGrupo: 0, strGrupo: 'DEPEN', strSubGrupo: '',
                },
                response2 => {
                    $('#dependenciaJerId').empty()
                    $('#dependenciaJerId').append('<option value="0">Seleccione</option>')
                    response2.forEach(element => {
                        if (element.intidTipo == response.intIdDependencia) {
                            $('#dependenciaJerId').append('<option selected value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                        } else {
                            $('#dependenciaJerId').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                        }
                    })

                    $.post('/Organizacion/getUnidxJerarquia', { IntIdJerOrg: response.intIdDependencia }, response3 => {
                        $('#unidadOrgId').empty()
                        $('#unidadOrgId').append('<option value="0">Seleccione</option>')
                        response3.forEach(element => {
                            if (element.intIdUniOrg == response.intIdUnidadOrg) {
                                $('#unidadOrgId').append('<option selected value="' + element.intIdUniOrg + '" >' + element.strDescripcion + '</option>')
                            } else {
                                $('#unidadOrgId').append('<option value="' + element.intIdUniOrg + '" >' + element.strDescripcion + '</option>')
                            }
                        })

                        $.post('/Proceso/ListarCombosProceso', {
                            intIdMenu: 0, strEntidad: 'TGPLANILLAREGISTRO', intIdFiltroGrupo: response.intIdUnidadOrg, strGrupo: 'TGPLANILLAXUNIDAD', strSubGrupo: ''
                        }, response4 => {
                            $('#planillaId').empty()
                            $('#planillaId').append('<option value="0">Seleccione</option>')
                            response4.forEach(element => {
                                if (element.intidTipo == response.intIdPlani) {
                                    $('#planillaId').append('<option selected value="' + element.intidTipo + '" >' + element.strDeTipo + '</option>')
                                } else {
                                    $('#planillaId').append('<option value="' + element.intidTipo + '" >' + element.strDeTipo + '</option>')
                                }
                            })
                        }).fail(function (result) {
                            alert('ERROR ' + result.status + ' ' + result.statusText)
                        })


                    }).fail(function (result) {
                        alert('ERROR ' + result.status + ' ' + result.statusText)
                    })

                });

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

            $("#periodoId").val(response.intIdPeriodo)
            $("#btn-save-change-periodo").val("Actualizar")
            $("#cbsit").attr("disabled", false); //añadido 11.03.2021
            $("#btn-save-change-periodo").removeClass();
            $("#btn-save-change-periodo").addClass("btn");
            $("#btn-save-change-periodo").addClass("btn btn-success");
            if (response.bitFlActivo == true) {
                $("#checkActivoId").html(`<input type="checkbox" class="js-switch" checked id="activoId" /> Activo`)
            } else if (response.bitFlActivo == false) {
                $("#checkActivoId").html(`<input type="checkbox" class="js-switch"  id="activoId" /> Activo`)
            }
            //añadido 25.02.2021 -ES
            if (response.bitFlProyectado === true) {
                $('#proyectoId').iCheck('check')
                $("#fechaCierreId").attr('disabled', false);
            } else {
                $("#proyectoId").iCheck('uncheck');
                $("#fechaCierreId").attr('disabled', true);
            }
            //fin

            //añadido 25.02.2021 -ES
            if (response.bitCerrado === true) {
                // $("#btn-save-change-periodo").attr("disabled", true);
                Bloquear(1);
                $('#cbsit').val("1"); //añadido 11.03.2021
                new PNotify({
                    title: 'Periodo Cerrado',
                    text: 'Un Periodo "Cerrado" no puede ser modificado completamente.',
                    type: 'info',
                    delay: 3000,
                    styling: 'bootstrap3',
                    addclass: 'dark'
                });
            } else {
                //$("#btn-save-change-periodo").attr("disabled", false)
                Bloquear(0);
                $('#cbsit').val("0"); //añadido 11.03.2021
                if (response.intCalculado = 1) {
                    new PNotify({
                        title: 'Periodo Calculado',
                        text: 'Si modificas las fechas de este periodo, deberás volver a procesarlo.',
                        type: 'info',
                        delay: 3000,
                        styling: 'bootstrap3',
                        addclass: 'dark'
                    });
                }
            }//fin
            switcheryLoad()
            $("#dependenciaJerId").val(response.intIdDependencia)
            $("#unidadOrgId").val(response.intIdUnidadOrg)
            $('#codigoId').val(response.strCoPeriodo)
            $('#descripcionId').val(response.strDesPeriodo)


            $('#planillaId').val(response.intIdPlani)
            //$("#proyectoId").val()
            $('#fechaIniID').val(response.dttFeIniPerio)
            $('#fechaFinId').val(response.dttFeFinPerio)
            $("#fechaCierreId").val(response.dttFeCiePerio)
            $('#mesId').val(response.intMes)
            $('#anioId').val(response.intAnioFiscal)
            bCerrado = response.bitCerrado;//añadido 25.02.2021

            var objDatos = {
                strPeriodoCampo1: response.strPeriodoCampo1,
                strPeriodoCampo2: response.strPeriodoCampo2,
                strPeriodoCampo3: response.strPeriodoCampo3,
                strPeriodoCampo4: response.strPeriodoCampo4,
                strPeriodoCampo5: response.strPeriodoCampo5
            }

            CamposAdicionalesPeriodo(objDatos)
            $('.form-hide-periodo').show();
        });
}

function getTablePeriodo(filtrojer_ini_var = null, filtrojer_fin_var = null) {

    var filtroPeriodo = $("#filtroPeriodo").val()
    var filtroActivo = $("#filtroActivo").val()
    var filtroSituacion = $("#filtroSituacion").val()
    var intIdPlanilla = $("#cboPlanilla").val();

    let filtrojer_ini = filtrojer_ini_var ? filtrojer_ini_var : null;
    let filtrojer_fin = filtrojer_fin_var ? filtrojer_fin_var : null;

    $.ajax({
        url: '/Proceso/ListarPeriodo',
        type: 'POST',
        data:
        {
            filtroPeriodo: filtroPeriodo,
            filtroActivo: filtroActivo,
            filtroSituacion: filtroSituacion,
            filtrojer_ini: filtrojer_ini,
            filtrojer_fin: filtrojer_fin,
            intIdPlanilla
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

            if (typeof _varTablaPeriodo !== 'undefined') {
                _varTablaPeriodo.destroy();
            }

            _varTablaPeriodo = $('#datatable-Periodo').DataTable({
                data: response,
                columns: [
                    { data: 'strCoPeriodo' },
                    { data: 'strDesPeriodo' },
                    { data: 'strMesAnio' },
                    { data: 'strDesPlani' },
                    { data: 'strDependencia' },
                    { data: 'strEstadoCerrado' },
                    { data: 'strEstadoActivo' },
                    {
                        sortable: false,
                        "render": (data, type, item, meta) => {
                            var intIdPeriodo = item.intIdPeriodo;
                            var strDesPeriodo = item.strDesPeriodo;
                            var Cerrado = item.strEstadoCerrado;//añadido

                            return `<button class="btn btn-success btn-xs btn-edit" onclick="editarPeriodo('${intIdPeriodo}');"><i class="fa fa-pencil"></i> Editar </button> 
                                    <button class="btn btn-primary btn-xs btn-delete" dataid="${intIdPeriodo}" des_data="${strDesPeriodo}" Cerrado_data="${Cerrado}"><i class="fa fa-trash-o"></i> Eliminar </button>`;

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

            $('#datatable-Periodo tbody').on('click', 'tr button.btn-delete', function () {
                validarSession()
                var intIdPeriodo = $(this).attr("dataid");
                var strDesPeriodo = $(this).attr("des_data");
                var bCerrado = $(this).attr("Cerrado_data");

                //añadido 25.02.2021 es
                if (bCerrado == "Cerrado") {
                    swal({
                        title: "Periodo Cerrado NO ELIMINABLE",
                        text: "Los Periodos Cerrados no se pueden eliminar.",
                        type: "error",
                        confirmButtonText: "OK",
                    });
                } else {
                    //fin
                    if (!isNaN(intIdPeriodo)) {
                        swal({
                            title: "Eliminar Periodo de pago",
                            text: "¿Está seguro de eliminar el periodo de pago ''<strong>" + strDesPeriodo + "</strong>'' ?",
                            type: "warning",
                            showCancelButton: true,
                            confirmButtonText: "Sí, eliminar",
                            cancelButtonText: "No, cancelar",
                        }).then(function (isConfirm) {
                            validarSession()
                            $.post(
                                '/Proceso/EliminarPeriodo',
                                { intIdPeriodo: intIdPeriodo },
                                (response) => {
                                    if (response.type !== '') {
                                        var tipo = 'Eliminado!';
                                        if (response.type === 'error')
                                            tipo = 'NO SE PUEDE ELIMINAR EL REGISTRO';
                                        swal(tipo, response.message, response.type);

                                        if (response.type === 'success') {
                                            $("#btn-cancel-periodo").click()
                                            let filtrojer_ini = $('#filtroFecha').data('daterangepicker').startDate.format('DD/MM/YYYY') + ' 00:00:00';
                                            let filtrojer_fin = $('#filtroFecha').data('daterangepicker').endDate.format('DD/MM/YYYY') + ' 23:59:59';
                                            getTablePeriodo(filtrojer_ini, filtrojer_fin);
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
                }//
            });

        },
        complete: function () {
            $.unblockUI();
        },
    });
}

function cleanForm() {

    $("#checkActivoId").html(`<input type="checkbox" class="js-switch" checked id="activoId" /> Activo`)
    switcheryLoad()
    $("#dependenciaJerId").val(0)
    $("#unidadOrgId").html('<option value="0" selected>Seleccione</option>')
    $('#codigoId').val("")
    $('#descripcionId').val("")
    $('#planillaId').val(0)
    $("#proyectoId").iCheck('uncheck');
    $("#fechaCierreId").attr('disabled', true);
    $('#fechaIniID').val(moment().format('DD/MM/YYYY'))
    $('#fechaFinId').val(moment().add(1, 'day').format('DD/MM/YYYY'))
    $('#fechaCierreId').val("")
    $('#mesId').val("0")
    $('#anioId').val("")
}

$('#proyectoId').change(function () {
    if ($(this).is(':checked')) {
        $("#fechaCierreId").attr('disabled', false);
        $("#fechaCierreId").val($("#fechaFinId").val());
    }
    else {
        $("#fechaCierreId").attr('disabled', true);
        $("#fechaCierreId").val('');
    }
});

$('#btn-new-periodo').on('click', function () {
    validarSession()
    cleanForm()
    $("#btn-save-change-periodo").val("Guardar")
    $("#btn-save-change-periodo").removeClass();
    $("#btn-save-change-periodo").addClass("btn");
    $("#btn-save-change-periodo").addClass("btn btn-primary");
    $("#periodoId").val("")
    $('#sit').val("Abierto")
    $('.form-hide-periodo').show();
    CamposAdicionalesPeriodo()
    $("#anioId").val(moment().format('YYYY'))
    $("#mesId").val(moment().format('M'))
    $("#cbsit").attr("disabled", true); //añadido 11.03.2021

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

function CamposAdicionalesPeriodo(dato) {

    $.post(
        '/Proceso/ListarCamposAdicionales',
        { strNoEntidad: 'TGPERIODO' },
        (response) => {
            console.log(response);
            $('#containerCampos').empty();
            response.forEach(element => {
                $('#containerCampos').append(
                    ' <div class="col-md-6 col-sm-6 col-xs-6"><div class="form-group"><label> ' + element.strTitulo
                    + '</label><input id="' + element.strNomCampo + '" type="text" class="form-control " placeholder="Campo Adicional" maxlength="255"/>' + '</div></div>');
            });
            if (dato != null) {
                $('#strPeriodoCampo1').val(dato.strPeriodoCampo1)
                $('#strPeriodoCampo2').val(dato.strPeriodoCampo2)
                $('#strPeriodoCampo3').val(dato.strPeriodoCampo3)
                $('#strPeriodoCampo4').val(dato.strPeriodoCampo4)
                $('#strPeriodoCampo5').val(dato.strPeriodoCampo5)
            }
        });
}

function eliminarPeriodo() {

    swal({
        title: "Eliminar Periodo",
        text: "Está seguro de eliminar el registro?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sí, eliminar",
        cancelButtonText: "No, cancelar",
    }).then(function (isConfirm) {
        if (isConfirm) {
            swal("Eliminado!", "El registro fue eliminado correctamente", "success");
        } else {
            swal("Cancelado", "La operación fue cancelada :)", "error");
        }
    });

}

$('#btn-save-change-periodo').on('click', function () {
    validarSession()
    var tipoOperacion = 1;
    var bCierre = false;//añadido 11/03/2021
    var periodoId = $("#periodoId").val()
    if (periodoId == "") {
        tipoOperacion = 1
    } else {
        tipoOperacion = 2
        if ($("#cbsit").val() == 1) {//añadido 11/03/2021
            bCierre = true; //añadido 11/03/2021
        }//añadido 11/03/2021
    }
    $("#cbsit").attr("disabled", true); //añadido 11.03.2021
    var titulo = ""
    if (tipoOperacion == 1) {
        titulo = "Registro Periodo de Pago"
    } else {
        titulo = "Actualizar Periodo de Pago"
    }

    ////añadir Valida Cierre 25.02.2021
    //if (bCerrado & tipoOperacion==2) {
    //    new PNotify({
    //        title: 'Periodo Cerrado',
    //        text: 'Un Periodo "Cerrado" no puede ser modificado.',
    //        type: 'info',
    //        delay: 3000,
    //        styling: 'bootstrap3',
    //        addclass: 'dark'
    //    });

    //    //validarSession()
    //    //$('.form-hide-periodo').hide();
    //    return;
    //}//fin


    var activoId = false
    if ($('#activoId').is(':checked')) { activoId = true }
    var proyectoId = false
    if ($('#proyectoId').is(':checked')) { proyectoId = true }

    var dependenciaJerId = $("#dependenciaJerId").val()
    var unidadOrgId = $("#unidadOrgId").val()
    var codigoId = $('#codigoId').val()
    var descripcionId = $('#descripcionId').val()
    var planillaId = $('#planillaId').val()


    var fechaIniID = $('#fechaIniID').val()
    var fechaFinId = $('#fechaFinId').val()
    var fechaCierreId = $('#fechaCierreId').val()


    var mesId = $('#mesId').val()
    var anioId = $('#anioId').val()

    if ($('#strPeriodoCampo1').val() == null) {
        var _camp1 = null;
    } else {
        var _camp1 = $('#strPeriodoCampo1').val();
    } if ($('#strPeriodoCampo2').val() == null) {
        var _camp2 = null;
    } else {
        var _camp2 = $('#strPeriodoCampo2').val();
    } if ($('#strPeriodoCampo3').val() == null) {
        var _camp3 = null;
    } else {
        var _camp3 = $('#strPeriodoCampo3').val();
    } if ($('#strPeriodoCampo4').val() == null) {
        var _camp4 = null;
    } else {
        var _camp4 = $('#strPeriodoCampo4').val();
    } if ($('#strPeriodoCampo5').val() == null) {
        var _camp5 = null;
    } else {
        var _camp5 = $('#strPeriodoCampo5').val();
    }

    if (codigoId == "") {
        new PNotify({
            title: 'Ingresar código',//corregido
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
    if (planillaId == 0) {
        new PNotify({
            title: 'Asignar planilla',
            text: 'Completar los campos Obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }
    if (fechaIniID == '' || fechaFinId == '') {

        new PNotify({
            title: 'Asignar las fechas',
            text: 'Completar los campos Obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }
    if (moment(fechaIniID.split("/").reverse().join("-")).isAfter(fechaFinId.split("/").reverse().join("-"))) {

        new PNotify({
            title: 'La fecha de inicio es mayor que la fecha fin',
            text: 'Ingresar el rango de fechas correcto',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }
    if (proyectoId) {
        if (fechaCierreId == '') {
            new PNotify({
                title: 'Asignar la fecha de cierre',
                text: 'Completar los campos Obligatorios',
                type: 'info',
                delay: 3000,
                styling: 'bootstrap3',
                addclass: 'dark'
            });
            return;
        }
        if (fechaCierreId < fechaIniID || fechaFinId < fechaCierreId) {
            new PNotify({
                title: 'Fecha de cierre se encuentra fuera del rango de fechas',
                text: 'Completar los campos Obligatorios',
                type: 'info',
                delay: 3000,
                styling: 'bootstrap3',
                addclass: 'dark'
            });
            return;
        }
    } else {
        fechaCierreId = fechaFinId //COREGIDO 25.02.2021
    }
    if (mesId == 0) {
        new PNotify({
            title: 'Asignar mes',
            text: 'Completar los campos Obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }
    if (anioId == 0) {
        new PNotify({
            title: 'Ingresar año',
            text: 'Completar los campos Obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }

    var datosPeriodo = {
        intIdPeriodo: periodoId
        , intIdDependencia: dependenciaJerId
        , intIdUnidadOrg: unidadOrgId
        , strCoPeriodo: codigoId
        , strDesPeriodo: descripcionId
        , intIdPlani: planillaId
        , bitFlProyectado: proyectoId
        , bitFlActivo: activoId
        , dttFeIniPerio: fechaIniID
        , dttFeFinPerio: fechaFinId
        , dttFeCiePerio: fechaCierreId
        , intMes: mesId
        , intAnioFiscal: anioId
        , strPeriodoCampo1: _camp1
        , strPeriodoCampo2: _camp2
        , strPeriodoCampo3: _camp3
        , strPeriodoCampo4: _camp4
        , strPeriodoCampo5: _camp5
        , bitCerrado: bCierre//añadido 11/03/2021
    }

    console.log(datosPeriodo)
    console.log("tipoOP -> " + tipoOperacion)

    $.post(
        '/Proceso/IUperiodo',
        {
            objDatos: datosPeriodo,
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
                $("#btn-cancel-periodo").click()
                let filtrojer_ini = $('#filtroFecha').data('daterangepicker').startDate.format('DD/MM/YYYY') + ' 00:00:00';
                let filtrojer_fin = $('#filtroFecha').data('daterangepicker').endDate.format('DD/MM/YYYY') + ' 23:59:59';
                getTablePeriodo(filtrojer_ini, filtrojer_fin);
                return;
            }
            else {
                var list = response.message.split("|")
                if (list.length = 2) {
                    var nomMantemiento = 'Periodo Pago';
                    var campo = list[1];
                    var msj = list[0];
                    var response = 'info';
                    var deta = 'notifry_error';
                    INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                } else {
                    new PNotify({
                        title: 'Periodo Pago',
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

$('#btn-cancel-periodo').on('click', function () {
    validarSession()
    $('.form-hide-periodo').hide();
});

$('.range-datepicker').on('apply.daterangepicker', function (ev, picker) {
    validarSession()
    let filtrojer_ini = $('#filtroFecha').data('daterangepicker').startDate.format('DD/MM/YYYY') + ' 00:00:00'
    let filtrojer_fin = $('#filtroFecha').data('daterangepicker').endDate.format('DD/MM/YYYY') + ' 23:59:59'
    getTablePeriodo(filtrojer_ini, filtrojer_fin)
});

$("#buscarId").change(function () {
    validarSession()
    let filtrojer_ini = $('#filtroFecha').data('daterangepicker').startDate.format('DD/MM/YYYY') + ' 00:00:00'
    let filtrojer_fin = $('#filtroFecha').data('daterangepicker').endDate.format('DD/MM/YYYY') + ' 23:59:59'
    getTableCambiosDI(filtrojer_ini, filtrojer_fin)
})

$("#empresaId").change(function () {
    validarSession()
    let filtrojer_ini = $('#filtroFecha').data('daterangepicker').startDate.format('DD/MM/YYYY') + ' 00:00:00'
    let filtrojer_fin = $('#filtroFecha').data('daterangepicker').endDate.format('DD/MM/YYYY') + ' 23:59:59'
    getTableCambiosDI(filtrojer_ini, filtrojer_fin)
})

$("#filtroActivo").change(function () {
    validarSession()
    let filtrojer_ini = $('#filtroFecha').data('daterangepicker').startDate.format('DD/MM/YYYY') + ' 00:00:00'
    let filtrojer_fin = $('#filtroFecha').data('daterangepicker').endDate.format('DD/MM/YYYY') + ' 23:59:59'
    getTablePeriodo(filtrojer_ini, filtrojer_fin)
})

$("#filtroSituacion").change(function () {
    validarSession()
    let filtrojer_ini = $('#filtroFecha').data('daterangepicker').startDate.format('DD/MM/YYYY') + ' 00:00:00'
    let filtrojer_fin = $('#filtroFecha').data('daterangepicker').endDate.format('DD/MM/YYYY') + ' 23:59:59'
    getTablePeriodo(filtrojer_ini, filtrojer_fin)
})

$("#filtroPeriodo").change(function () {
    validarSession()
    let filtrojer_ini = $('#filtroFecha').data('daterangepicker').startDate.format('DD/MM/YYYY') + ' 00:00:00'
    let filtrojer_fin = $('#filtroFecha').data('daterangepicker').endDate.format('DD/MM/YYYY') + ' 23:59:59'
    getTablePeriodo(filtrojer_ini, filtrojer_fin)
})

$("#cboPlanilla").change(function () {
    validarSession()
    let filtrojer_ini = $('#filtroFecha').data('daterangepicker').startDate.format('DD/MM/YYYY') + ' 00:00:00'
    let filtrojer_fin = $('#filtroFecha').data('daterangepicker').endDate.format('DD/MM/YYYY') + ' 23:59:59'
    getTablePeriodo(filtrojer_ini, filtrojer_fin)


})

function CombosAusentismos() {
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
                validarSession()
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

            //Añadido HG 07.04.21 

            if ($('#planillaId').val() == 0) {
                new PNotify({
                    title: 'Periodo de Pago',
                    text: 'Se debe crear una Planilla para la Unid. Organizacional Seleccionada',
                    type: 'info',
                    delay: 3000,
                    styling: 'bootstrap3',
                    addclass: 'dark'
                });
                return;
            }

        }).fail(function (result) {
            alert('ERROR ' + result.status + ' ' + result.statusText)
        })
    })


}

$(document).ready(function () {

    const fechaInicioAsigHor = moment().startOf('year').format('DD/MM/YYYY') + ' 00:00:00';
    const fechaFinAsigHor = moment().endOf("year").format('DD/MM/YYYY') + ' 23:59:59';

    getTablePeriodo(fechaInicioAsigHor, fechaFinAsigHor)

    CombosAusentismos();

    $('#fechaIniID').datetimepicker({
        viewMode: 'days',
        format: 'DD/MM/YYYY'
    });

    $('#fechaFinId').datetimepicker({
        viewMode: 'days',
        format: 'DD/MM/YYYY'
    });

    $('#fechaCierreId').datetimepicker({
        viewMode: 'days',
        format: 'DD/MM/YYYY'
    });

    var txtCod = 'strCoPeriodo';
    var txtdes = 'strDesPeriodo';

    $.post(
        '/Organizacion/ListarCaracteresMax',
        { strMaestro: 'TGPERIODO' },
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
