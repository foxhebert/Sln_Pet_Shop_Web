﻿var _tableReporte;
var dataPersonal;
var dataPersonal_tmp;
var _listaPeriodo = [];
var _listaGrupoLiq = [];
var _listaConcepto = [];
var _planilla = "";


function CombosPeriodo() {
    var intIdMenu = 0

    $.post(
        '/Reportes/GetReportes',
        {},
        response => {
            $('#cboReporte').empty()
            $('#cboReporte').append('<option value="0">Seleccione</option>')
            response.forEach(element => {
                if (element.ListHijos.length > 0) {
                    $('#cboReporte').append('<option class="optionGroup" strCo="' + element.strCoReporte + '" value="' + element.intIdReporte + '">' + element.strDesReporte + '</option>')

                    element.ListHijos.forEach(e => {
                        $('#cboReporte').append(`<option class="optionChild" strCo="${e.strCoReporte}" value="${e.intIdReporte}">&nbsp;&nbsp;&nbsp;&nbsp;&bull;${e.strDesReporte}</option>`)
                    })

                } else {
                    $('#cboReporte').append('<option class="optionGroup" strCo="' + element.strCoReporte + '" value="' + element.intIdReporte + '">' + element.strDesReporte + '</option>')
                }
            })
        });

    $.post(
        '/Personal/ListarCombosProceso',//Proceso
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
                        '/Personal/ListarCombosProceso',//Proceso
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

                    $.post(
                        '/Personal/ListarCombosProceso',//Proceso
                        {
                            intIdMenu, strEntidad: 'TGCATEGORIA', intIdFiltroGrupo: intIdUniOrg, strGrupo: 'TGCATEGORIA', strSubGrupo: '',
                        },
                        response => {
                            $('#cboCategoria').empty()
                            $('#cboCategoria').append('<option value="0">Seleccione</option>')
                            if (response.length > 0) {
                                response.forEach(element => {
                                    $('#cboCategoria').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                                })
                                $("#cboCategoria").attr("disabled", false)
                            } else {
                                $("#cboCategoria").attr("disabled", true)
                            }

                        });

                    $.post(
                        '/Personal/ListarCombosProceso',//Proceso
                        {
                            intIdMenu: 0, strEntidad: 'TGMARCADOR', intIdFiltroGrupo: intIdUniOrg, strGrupo: 'TGMARCADOR', strSubGrupo: 'REPORTECOM',
                        },
                        response => {
                            $('#cboMarcador').empty()
                            $('#cboMarcador').append('<option value="0" selected>Todos</option>')
                            response.forEach(element => {
                                $('#cboMarcador').append(`<option value="${element.intidTipo}">${element.strDeTipo}</option>`)
                            })
                        });

                }

            })

        });
    //nuevo  16.03.2021
    $.post(
        '/Personal/ListarCombosProceso',//Proceso
        {
            intIdMenu, strEntidad: 'TGUNIDORG', intIdFiltroGrupo: 0, strGrupo: 'CONSECIONARIA', strSubGrupo: 'REPORTE', //concesionaria
        },
        response => {
            $('#cboConcesionaria').empty()
            $('#cboConcesionaria').append('<option value="0">Seleccione</option>')
            response.forEach(element => {
                $('#cboConcesionaria').append('<option ruc="' + element.strextra1 + '" value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
            })

        });//fin


    $.post(
        '/Personal/ListarCombosPersonal_',
        { strEntidad: 'TGTIPO', intIdFiltroGrupo: 0, strGrupo: 'COMEDOR', strSubGrupo: 'TIPOSERV' },
        (response) => {

            $('#TipServicios').empty();
            $('#TipServicios').append('<option value="0" >Todos</option>');

            response.forEach(element => {
                $('#TipServicios').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');
            });

        });

    $.post(
        '/Personal/ListarCombosPersonal_',
        { strEntidad: 'TGTIPO', intIdFiltroGrupo: 0, strGrupo: 'COMEDOR', strSubGrupo: 'TIPOMENU' },
        (response) => {

            $('#TipMenus').empty();
            $('#TipMenus').append('<option  value="0">Todos</option>');
            response.forEach(element => {

                $('#TipMenus').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');

            });

        });


}

function allConceptos(element) {
    if (element.checked) {
        $(".flatConcepto").prop('checked', true);
    } else {
        $(".flatConcepto").prop('checked', false);
        _listaConcepto = []
    }
}

function getIdPeriodo() {
    return _listaPeriodo.map(function (x) {
        return x.id;
    })
}

function limpiarOpciones() {
    $(".divFecha").hide()
    $(".divPeriodo").hide()
    $(".divanio").hide()
    $(".divGrafico").hide()
    $("#txtNomReporte").html("")
    $(".divConcepto").hide()
    $(".divMarcador").hide()
    $(".TipServicios").hide()
    $(".TipMenus").hide()
    $(".cboConcesionaria").hide() // nuevo 16.03.2021
}

$("#cboGenerar").click(function () {
    exportExcelPdf("")
})

$("#btnExcel").click(function () {
    exportExcelPdf("&excel=1")
})

$("#btnPdf").click(function () {
    exportExcelPdf("&pdf=1")
})

function exportExcelPdf(adicional) {
    validarSession();
    var intIdReporte = $("#cboReporte").val()

    if (intIdReporte == 0) {
        new PNotify({
            title: 'Seleccione Reporte',
            text: 'Completar los campos Obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }

    if (dataPersonal.length == 0) {
        new PNotify({
            title: 'Seleccione Empleados',
            text: 'Debe seleccionar al menos un empleado',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }

    var lista = []
    dataPersonal.forEach(element => {
        lista.push(element.intIdPersonal)
    });

    var lista2 = []
    _listaConcepto.forEach(element => {
        lista2.push(element)
    });

    var marca = false
    if ($('#chkMarcas').is(":checked")) {
        marca = true
    }

    var bitCosto = false
    if ($('#chkCostos').is(":checked")) {
        bitCosto = true
    }

    var filtrojer_ini = $('#filtroFecha').data('daterangepicker').startDate.format('DD/MM/YYYY') + ' 00:00:00'
    var filtrojer_fin = $('#filtroFecha').data('daterangepicker').endDate.format('DD/MM/YYYY') + ' 23:59:59'
    var codigo = $("#cboReporte option:selected").attr('strCo')

    var intMarcador = $("#cboMarcador").val()
    var intTipoServicio = $("#TipServicios").val()
    var intTipoMenu = $("#TipMenus").val()

    var DesServicio = "";
    var DesMarcador = $("#cboMarcador option:selected").text()

    if (intTipoServicio == 0 && intTipoMenu == 0) {
        DesServicio = "Todos";
    } else if (intTipoServicio == 0 && intTipoMenu != 0) {
        DesServicio = $("#TipMenus option:selected").text()
    } else if (intTipoServicio != 0 && intTipoMenu == 0) {
        DesServicio = $("#TipServicios option:selected").text() + ' - ' + $("#TipMenus option:selected").text()
    } else {
        DesServicio = $("#TipServicios option:selected").text() + ' - ' + $("#TipMenus option:selected").text()
    }



    $.post('/Reportes/llenarListaEmpleados',
        { lista, lista2 },
        function (response) {

            if (codigo == "RC01" || codigo == "RC03") {
                if (codigo == "RC01") {
                    window.open('/Rep/Vista/RepConsumoDiarioCosto.aspx?bitCosto=' + bitCosto + '&intMarcador=' + intMarcador + '&intTipoServicio=' + intTipoServicio + '&intTipoMenu=' + intTipoMenu + '&DesMarcador=' + DesMarcador + '&DesServicio=' + DesServicio + '&filtrojer_ini=' + filtrojer_ini + '&filtrojer_fin=' + filtrojer_fin + adicional, '');
                }
                if (codigo == "RC03") {
                    window.open('/Rep/Vista/RepConsumoDetalladoCosto.aspx?bitCosto=' + bitCosto + '&intMarcador=' + intMarcador + '&intTipoServicio=' + intTipoServicio + '&intTipoMenu=' + intTipoMenu + '&DesMarcador=' + DesMarcador + '&DesServicio=' + DesServicio + '&filtrojer_ini=' + filtrojer_ini + '&filtrojer_fin=' + filtrojer_fin + adicional, '');
                }
            }
            //SEGUNDO RPT
            else if (codigo == "RC02") {

                if ($("#cboPeriodo").val() == 0) {
                    new PNotify({
                        title: 'Periodo',
                        text: 'Seleccione un periodo',
                        type: 'info',
                        delay: 3000,
                        styling: 'bootstrap3',
                        addclass: 'dark'
                    });
                    return;
                }

                var intPeriodo = parseInt($("#cboPeriodo").val())
                var fecIni = $("#cboPeriodo option:selected").attr("fecini")
                var fecFin = $("#cboPeriodo option:selected").attr("fecFin")
                //HG 08.03.21
                window.open('/Rep/Vista/RepConsumoTotalCosto.aspx?intPeriodo=' + intPeriodo + '&bitCosto=' + bitCosto + '&intMarcador=' + intMarcador + '&intTipoServicio=' + intTipoServicio + '&intTipoMenu=' + intTipoMenu + '&DesMarcador=' + DesMarcador + '&DesServicio=' + DesServicio + '&fecIni=' + fecIni + '&fecFin=' + fecFin + adicional, ' ');
            }//añadido 16.03.2021
            else if (codigo == "RC04") {
                if ($("#cboConcesionaria").val() == 0) {
                    new PNotify({
                        title: 'Concesionaria',
                        text: 'Seleccione una Concesionaria',
                        type: 'info',
                        delay: 3000,
                        styling: 'bootstrap3',
                        addclass: 'dark'
                    });
                    return;
                }
                var intConcesionaria = parseInt($("#cboConcesionaria").val())//nuevo 16.03.2021
                window.open('/Rep/Vista/RepConcesionarioDiarioCosto.aspx?intConcesionaria=' + intConcesionaria + '&intMarcador=' + intMarcador + '&intTipoServicio=' + intTipoServicio + '&intTipoMenu=' + intTipoMenu + '&DesMarcador=' + DesMarcador + '&DesServicio=' + DesServicio + '&filtrojer_ini=' + filtrojer_ini + '&filtrojer_fin=' + filtrojer_fin + adicional, '');
            } else if (codigo == "RC05") {

                if ($("#cboPeriodo").val() == 0) {
                    new PNotify({
                        title: 'Periodo',
                        text: 'Seleccione un periodo',
                        type: 'info',
                        delay: 3000,
                        styling: 'bootstrap3',
                        addclass: 'dark'
                    });
                    return;
                }
                if ($("#cboConcesionaria").val() == 0) {
                    new PNotify({
                        title: 'Concesionaria',
                        text: 'Seleccione una Concesionaria',
                        type: 'info',
                        delay: 3000,
                        styling: 'bootstrap3',
                        addclass: 'dark'
                    });
                    return;
                }

                var intPeriodo = parseInt($("#cboPeriodo").val())
                var intConcesionaria = parseInt($("#cboConcesionaria").val())//nuevo 16.03.2021
                var fecIni = $("#cboPeriodo option:selected").attr("fecini")
                var fecFin = $("#cboPeriodo option:selected").attr("fecFin")

                window.open('/Rep/Vista/RepConcesionarioTotalCosto.aspx?intPeriodo=' + intPeriodo + '&intConcesionaria=' + intConcesionaria + '&intMarcador=' + intMarcador + '&intTipoServicio=' + intTipoServicio + '&intTipoMenu=' + intTipoMenu + '&DesMarcador=' + DesMarcador + '&DesServicio=' + DesServicio + '&fecIni=' + fecIni + '&fecFin=' + fecFin + adicional, ' ');
            }//fin

        });
}

$("#txtAnio").change(function () {
    validarSession()
    var txtAnio = $('#txtAnio')

    if (!txtAnio[0].validity.valid) {
        new PNotify({
            title: 'Año',
            text: 'Seleccionar un año valido',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        $("#txtAnio").val("")
        return;
    }

    var intAnio = parseInt(txtAnio.val())
    var intIdPlanilla = $("#cboPlanilla").val()

    $.post(
        '/Personal/ListarCombosProceso',//Proceso
        {
            intIdMenu: 0, strEntidad: 'TGPERIODO', intIdFiltroGrupo: intAnio, strGrupo: 'TGPERIODOXANIO', strSubGrupo: intIdPlanilla,
        },
        response => {
            $('#cboPeriodo').empty()
            $('#cboPeriodo').append('<option value="0">Seleccione</option>')
            response.forEach(element => {
                $('#cboPeriodo').append(`<option fecIni="${element.strextra1}" fecFin="${element.strextra2}" value="${element.intidTipo}">${element.strDeTipo}</option>`)
            })
        });

})

$("#cboCategoria").change(function () {
    validarSession()
    getEmpleados()
})

$("#filtroCalculo").change(function () {
    validarSession()
    getEmpleados();
})

$('#cboPlanilla').on('change', function () {
    validarSession();
    var id = $('#cboPlanilla option:selected').val();
    _planilla = $('#cboPlanilla option:selected').html();
    $('#GrupoLiqui').attr('disabled', true);
    $("#cboGenerar").attr("disabled", true)
    $("#periodosCalculados").html('')
    if (id == 0) {
        $('#Periodo_Pago').attr('disabled', true);
        $('.btnPeriodo').attr('disabled', true);
        return;
    } else {
        $('#Periodo_Pago').attr('disabled', false);
        $('.btnPeriodo').attr('disabled', false);
        $("#btnCalcular").attr('disabled', true);
        //dataPersonal = [];
    }

    $.post(
        '/Personal/ListarCombosProceso',//Proceso
        { intIdMenu: 0, strEntidad: 'TGGRUPOLIQPLANILLA', intIdFiltroGrupo: id, strGrupo: 'TGGRUPOLIQPLANILLA', strSubGrupo: '' },
        (response) => {
            $('#chekeameGruposLiquidacion').empty();
            if (response.length > 0) {
                response.forEach(element => {
                    $('#chekeameGruposLiquidacion').append(`<li role="presentation" ><label>` +
                        '&nbsp;<input id="' + element.intidTipo + '"type="checkbox" class= "flat" name="restore">&nbsp;' + element.strDeTipo +
                        '</label></li >');
                    //init_checkBox_styles();
                });
                $("#GrupoLiqui").attr('disabled', false)
            } else {
                $("#GrupoLiqui").attr('disabled', true)
            }


            $("input.flat").click(function () {
                validarSession()
                _listaGrupoLiq = []
                $("#chekeameGruposLiquidacion input.flat:checked").each(function (index) {
                    _listaGrupoLiq.push(parseInt($(this).attr('id')));
                });
                getEmpleados();
            });
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });

    getEmpleados();
});

$(".columnHide").click(function () {
    validarSession();//AÑADIDO HG 22.04.2021
    var index = $(this)[0].id;
    if (typeof _tableReporte !== 'undefined') {
        var column = _tableReporte.column(index);

        // Toggle the visibility
        column.visible(!column.visible());
    }
})

$("#chkCesado").click(function () {
    validarSession()
    getEmpleados()
})

$("#cboEstadoActivo").change(function () {
    validarSession()
    getEmpleados()
})

$("#cboReporte").change(function () {
    validarSession()
    if ($(this).val() == 0) {
        limpiarOpciones()
    } else {
        limpiarOpciones()
        var codigo = $(this).children("option:selected").attr('strCo')

        $("#txtNomReporte").html($(this).children("option:selected").html())

        ////AÑADIDO PARA COMEDOR HG 05.02.21
        //else
        if (codigo == "RC01" || codigo == "RC03") {
            $(".divFecha").show()
            $(".divCostos").show()
            $("#chkCostos").prop('checked', false);
            $(".divMarcador").show()
            $(".divTServ").show()
            $(".divTMen").show()
            $(".divConces").hide() // nuevo
        }
        //AÑADIDO PARA COMEDOR HG 05.02.21
        else if (codigo == "RC02") {
            //----------------------------------------------------
            $(".divFecha").hide()
            $("#txtAnio").val(moment().format('YYYY'))
            $(".divPeriodo").show()
            $(".divanio").show();
            $(".divMarcador").show()
            $(".divTServ").show()
            $(".divTMen").show()
            $(".divCostos").show();
            $(".divConces").hide() // nuevo
            let intIdPlanilla = $("#cboPlanilla").val()
            $.post(
                '/Personal/ListarCombosProceso',//Proceso
                {
                    intIdMenu: 0, strEntidad: 'TGPERIODO', intIdFiltroGrupo: moment().format('YYYY'), strGrupo: 'TGPERIODOXANIO', strSubGrupo: intIdPlanilla,
                },
                response => {
                    $('#cboPeriodo').empty()
                    $('#cboPeriodo').append('<option value="0">Seleccione</option>')
                    response.forEach(element => {
                        $('#cboPeriodo').append(`<option fecIni="${element.strextra1}" fecFin="${element.strextra2}" value="${element.intidTipo}">${element.strDeTipo}</option>`)
                    })
                });

        }
        else if (codigo == "RC04") {
            //----------------------------------------------------
            $(".divFecha").show()
            $(".divCostos").hide()//modificado
            //$("#chkCostos").prop('checked', false);// modificado
            $(".divMarcador").show()
            $(".divTServ").show()
            $(".divTMen").show()
            $(".divConces").show() // nuevo

        } else if (codigo == "RC05") {
            //----------------------------------------------------
            $(".divFecha").hide()
            $("#txtAnio").val(moment().format('YYYY'))
            $(".divanio").show();
            $(".divPeriodo").show()
            $(".divMarcador").show()
            $(".divTServ").show()
            $(".divTMen").show()
            $(".divCostos").hide();//modificado
            $(".divConces").show() // nuevo
            let intIdPlanilla = $("#cboPlanilla").val()
            $.post(
                '/Personal/ListarCombosProceso',//Proceso
                {
                    intIdMenu: 0, strEntidad: 'TGPERIODO', intIdFiltroGrupo: moment().format('YYYY'), strGrupo: 'TGPERIODOXANIO', strSubGrupo: intIdPlanilla,
                },
                response => {
                    $('#cboPeriodo').empty()
                    $('#cboPeriodo').append('<option value="0">Seleccione</option>')
                    response.forEach(element => {
                        $('#cboPeriodo').append(`<option fecIni="${element.strextra1}" fecFin="${element.strextra2}" value="${element.intidTipo}">${element.strDeTipo}</option>`)
                    })
                });

        }


    }
})

function getEmpleados() {
    var cboUniOrg = $("#cboUniOrg").val()
    var cboPlanilla = $("#cboPlanilla").val()

    if (cboUniOrg == 0) {
        new PNotify({
            title: 'Seleccione Unidad Org.',
            text: 'Completar los campos Obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }

    if (cboPlanilla == 0) {
        new PNotify({
            title: 'Seleccione Planilla',
            text: 'Completar los campos Obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }

    var filtroCalculo = $("#filtroCalculo").val()
    var cboCategoria = $("#cboCategoria").val()
    var estado = $("#cboEstadoActivo").val()
    var cesado = false
    if ($('#chkCesado').is(":checked")) {
        cesado = true
    }

    $.ajax({
        url: '/Reportes/ConsultaReporte',
        type: 'POST',
        data: {
            cboUniOrg, filtroCalculo, cboPlanilla, cboCategoria, cesado, estado, listGrupoLiq: _listaGrupoLiq
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
            //dataPersonal = []
            dataPersonal_tmp = response
            //dataPersonal = response
            planilla = $('#cboPlanilla option:selected').html()
            $("#cboGenerar").attr("disabled", false)

            if ($.fn.dataTable.isDataTable('#TablaReporte')) {
                _tableReporte.destroy();
            }

            _tableReporte = $('#TablaReporte').DataTable({
                data: response,
                columns: [
                    {
                        sortable: false,
                        "render": (data, type, item, meta) => {
                            let intIdPersonal = item.intIdPersonal;
                            return `<input type="checkbox" class="HorInd"  id="Chck${intIdPersonal}" data_intIdPers="${intIdPersonal}"  onChange="CheckDetCal(${intIdPersonal})"/>`;
                        }
                    },
                    { data: 'strFotocheck' },
                    { data: 'strNomCompleto' },
                    { data: 'strNumDoc' },
                    { data: 'strCoReg' },
                    { data: 'strDesPlani' },
                    { data: 'strDesUniOrg' },
                    { data: 'strDesFis' },
                    { data: 'strDesGrupoLiq' },
                    { data: 'dttFecCese' },
                ],
                lengthMenu: [10, 25, 50],
                order: [],
                responsive: true,
                language: _datatableLanguaje,
                columnDefs: [
                    {
                        targets: [0],
                        data: null,
                        defaultContent: '',
                        orderable: false,
                        className: 'select-checkbox'
                    },
                    {
                        targets: [3],
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [5],
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [6],
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [8],
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [9],
                        visible: false,
                        searchable: false
                    }
                ],
                dom: 'lBfrtip',
            });

            $(".columnHide").prop("checked", false)
            $("#All_Calcular").iCheck('uncheck');
            dataPersonal = [];
            console.log(response.length);

            if (response.length > 0) {
                $("#All_Calcular").attr("disabled", false)
            } else { $("#All_Calcular").attr("disabled", true)}
        },
        complete: function () {
            $.unblockUI();
        }

    });
}

$('#All_Calcular').on('change', function () {
    validarSession();//AÑADIDO HG 22.04.2021

    var allPagesCal = _tableReporte.cells().nodes();
    let all_filter_ = _tableReporte.cells({ order: 'index', search: 'applied' }).nodes();
    let all_filter = _tableReporte.cells({ order: 'index', search: 'applied' }).nodes().to$().find(':checkbox');
    console.log("Filas: " + _tableReporte.rows().count());
    class GeneralP {
        constructor(intIdPersonal) {
            this.intIdPersonal = intIdPersonal 
        }
    }


    //dataPersonal = [];

    if ($('#All_Calcular').is(':checked')) {
        //FILTRADO OPCION B
        console.log(all_filter.toArray());
        dataPersonal = [];

        all_filter.toArray().forEach(x => {
            let ival = $(x).attr('data_intIdPers');
            dataPersonal.push({ intIdPersonal: ival })
        });

        //all_filter.toArray().forEach(x => {
        //    let ival = $(x).attr('data_intIdPers');
        //    dataPersonal.push({ intIdPersonal: ival })
        //});
        //console.log(dataPersonal);


        //all_filter.toArray().forEach(x => {
        //    dataPersonal.push({ intIdPersonal: $(x).attr('data_intIdPers') })
        //})
        $(all_filter_).find('input[type="checkbox"]').prop('checked', true);
    } else {
        dataPersonal = []
        //$(allPages).find('input[type="checkbox"]').iCheck('uncheck');
        $(allPagesCal).find('input[type="checkbox"]').prop('checked', false);

    }
            //console.log(dataPersonal);
    let total = _tableReporte.rows().nodes().length
    let totalFilter = _tableReporte.rows({ order: 'index', search: 'applied' }).nodes().length
    let select = _tableReporte.rows().nodes().to$().find('input:checked').length
    $("#seleccionados").html(select)

});

function CheckDetCal(intIdPer) {
    validarSession();//AÑADIDO HG 22.04.2021
    if (dataPersonal_tmp == null) {
        return false;
    }
    console.log("Filas: " + _tableReporte.rows().count());
    console.log(dataPersonal.length);

    let total = _tableReporte.rows().count()
    let totalFilter = _tableReporte.rows({ order: 'index', search: 'applied' }).count()


    if ($('#Chck' + intIdPer + '').is(':checked') == true) {
        if (dataPersonal_tmp.find(e => e.intIdPersonal == intIdPer)) {
            let position = dataPersonal_tmp.findIndex(e => e.intIdPersonal == intIdPer);
            if (!isNaN(position)) {
                dataPersonal.push(dataPersonal_tmp[position]);
            }
        }
    } else if ($('#Chck' + intIdPer + '').is(':checked') == false) {
        if (dataPersonal.find(e => e.intIdPersonal == intIdPer)) {
            let position = dataPersonal.findIndex(e => e.intIdPersonal == intIdPer);
            if (!isNaN(position)) {
                dataPersonal.splice(position, 1);
            }

        }
    }

    if (total === totalFilter) {
        //evaluar check todos
        if (dataPersonal.length == total) {
            $('#All_Calcular').prop('checked', true);
        }
        if (dataPersonal.length == 0) {
            $('#All_Calcular').prop('checked', false);
        }
    } else {
        if (dataPersonal.length == totalFilter) {
            $('#All_Calcular').prop('checked', true);
        }
        if (dataPersonal.length == 0) {
            $('#All_Calcular').prop('checked', false);
        }
    }

    //let selectFilter = _tableReporte.rows({ search: 'applied' }).nodes().to$().find('input:checked').length
    let select = _tableReporte.rows().nodes().to$().find('input:checked').length
    $("#seleccionados").html(select)
}


$(document).ready(function () {

    CombosPeriodo()
    dataPersonal = [];
    _tableReporte = $('#TablaReporte').DataTable({
        data: {},
        columns: [
            {
                sortable: false,
                "render": (data, type, item, meta) => {
                    let intIdPersonal = item.intIdPersonal;
                    return `<input type="checkbox" class="HorInd"  id="Chck${intIdPersonal}" data_intIdPers="${intIdPersonal}"  onChange="CheckDetCal(${intIdPersonal})"/>`;
                }
            },
            { data: 'strFotocheck' },
            { data: 'strNomCompleto' },
            { data: 'strNumDoc' },
            { data: 'strCoReg' },
            { data: 'strDesPlani' },
            { data: 'strDesUniOrg' },
            { data: 'strDesFis' },
            { data: 'strDesGrupoLiq' },
            { data: 'dttFecCese' },
        ],
        lengthMenu: [10, 25, 50],
        order: [],
        responsive: true,
        language: _datatableLanguaje,
        columnDefs: [
            {
                targets: [0],
                data: null,
                defaultContent: '',
                orderable: false,
                className: 'select-checkbox'
            },
            {
                targets: [3],
                visible: false,
                searchable: false
            },
            {
                targets: [5],
                visible: false,
                searchable: false
            },
            {
                targets: [6],
                visible: false,
                searchable: false
            },
            {
                targets: [8],
                visible: false,
                searchable: false
            },
            {
                targets: [9],
                visible: false,
                searchable: false
            }
        ],
        dom: 'lBfrtip',
    });

})
