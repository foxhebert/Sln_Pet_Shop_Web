
//
var intIdPersonal_ = 0;

$('.range-datepicker').on('apply.daterangepicker', function (ev, picker) {
    validarSession()
    let filtrojer_ini = $('#campJerar').data('daterangepicker').startDate.format('YYYY/MM/DD')
    let filtrojer_fin = $('#campJerar').data('daterangepicker').endDate.format('YYYY/MM/DD')

    const anioMenor = filtrojer_ini.substr(0, 4)
    const anioMayor = filtrojer_fin.substr(0, 4)

    const mesNumberMenor = parseInt(filtrojer_ini.substr(5, 2))
    const mesNumberMayor = parseInt(filtrojer_fin.substr(5, 2))

    if (anioMenor !== anioMayor && mesNumberMenor === mesNumberMayor) {
        messageResponseMix({ type: 'info', message: 'Debe seleccionar 12 meses' }, 'Perfil')
        return false;
    } else {
        getCabeceras(filtrojer_ini, filtrojer_fin)
        getDiasAusencia(filtrojer_ini, filtrojer_fin)
        getHorasDescontadas(filtrojer_ini, filtrojer_fin)
        getHorasExtras(filtrojer_ini, filtrojer_fin)
        getAsistenciaDiariaEdit(filtrojer_ini, filtrojer_fin)
    }
});

function getDiasAusencia(fechaInicio, fechaFin) {

    $.ajax({
        url: '/Inicio/ListarDiasAusencia',
        type: 'POST',
        data:
        { fechaInicio, fechaFin, intIdPersonal: intIdPersonal_ },
        async: true,
        beforeSend: function () {
            $("#echart_pie2").html("Cargando...")
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
            //    message: 'Procesando...'
            //});
        },
        success: function (response) {
            var leyend = []
            var data = []
            $("#echart_pie2").empty()
            if (response.length > 0) {
                response.forEach(x => {
                    leyend.push(x.strDesConcepto)
                    data.push({ "value": x.intTotalDias, "name": x.strDesConcepto })
                })

                var echartPieCollapse = echarts.init(document.getElementById('echart_pie2'), theme);

                echartPieCollapse.setOption({
                    tooltip: {
                        trigger: 'item',
                        formatter: "{a} <br/>{b} : {c} ({d}%)"
                    },
                    legend: {
                        x: 'center',
                        y: 'bottom',
                        data: leyend,
                    },
                    toolbox: {
                        show: true,
                        feature: {
                            magicType: {
                                show: true,
                                type: ['pie', 'funnel']
                            },
                            restore: {
                                show: true,
                                title: "Restore"
                            },
                            saveAsImage: {
                                show: true,
                                title: "Save Image"
                            }
                        }
                    },
                    calculable: true,
                    series: [{
                        name: 'Detalle',
                        type: 'pie',
                        radius: ['0%', '30%'],
                        avoidLabelOverlap: true,
                        label: {
                            show: false,
                            position: 'center'
                        },
                        emphasis: {
                            label: {
                                show: true,
                                fontSize: '30',
                                fontWeight: 'bold'
                            }
                        },
                        labelLine: {
                            show: false
                        },
                        data: data
                    }]
                });
            } else {
                $("#echart_pie2").html("NO EXISTEN DATOS PARA MOSTRAR")
            }
        },
        complete: function () {
            //$.unblockUI();
        }
    });
}

function getGraficaBienesTipoBienes() { //getAsistenciaDiaria(fechaInicio, fechaFin) {
    var echartBar = echarts.init(document.getElementById('mainPrincipalGraficaBarras'), theme);
    echartGlobalInstance = echartBar
    let strTipo = [];

    ///////////////////////////////////////// FECHA DE INICIALIZACION
    const fechaInicio = moment().startOf('year').format('DD/MM/YYYY') + ' 00:00:00';
    const fechaFin = moment().endOf("year").format('DD/MM/YYYY') + ' 23:59:59';
    ////////////////////$.ajax({
    ////////////////////    url: '/Inicio/ListarTipoBienes',


    $.ajax({
        url: '/Inicio/ListarAsistenciaDiaria',
        type: 'POST',
        data: { intIdPersonal: intIdPersonal_, fechaInicio: fechaInicio, fechaFin: fechaFin },
        async: true,
        beforeSend: function () {
        },
        success: function (response) {

            //Para los tipos de Bienes en el eje X que tiene que aparecer dinamicamente
            var list_inventariados = [];
            var list_noinventariados = [];
            //Para los Titulos de los tipos de Bienes en el eje X
            var titulosEnElEjeX = []
            for (x in response) {
                titulosEnElEjeX.push(response[x].strCodTipo + '\n' + response[x].strDescTipo);
                list_inventariados.push(response[x].asistencia);
                list_noinventariados.push(response[x].faltas);
            }


            //------------------------------------
            ////////////////////var CodTipo = []
            ////////////////////for (x in response)
            ////////////////////    CodTipo.push(response[x].strCodTipo);
            ////////////
            //////////var names = []
            //////////for (x in response)
            //////////    names.push(response[x].strDescTipo);
            //////////var list_strTipo = names;
            ////////////------------------------------------
            //////////var CodTipo = []
            //////////for (x in response)
            //////////    CodTipo.push(response[x].strCodTipo);    



            echartBar.setOption({
                //title: {
                //    text: 'Gráfico de Consumos Anual'
                //},
                tooltip: {
                    trigger: 'axis'
                },
                legend: {
                    bottom: -5,
                    left: 'center',
                    data: ['Inventariados', 'No Inventariados']
                },
                toolbox: {
                    show: false
                },
                calculable: false,
                xAxis: [{
                    type: 'category',
                    name: 'Tipo de Bienes',
                    data: titulosEnElEjeX,

                }],
                yAxis: [{
                    name: 'N° Bienes',
                    type: 'value'
                }],
                series: [{
                    name: 'Inventariados',
                    type: 'bar',
                    data: list_inventariados,
                 }, {
                    name: 'No Inventariados',
                    type: 'bar',
                    data: list_noinventariados,
                    markLine: {
                        data: [

                        ]
                    }
                }]
            });

        },
        complete: function () {
            //$.unblockUI();
        }
    });
}

//////////function getAsistenciaDiariaEdit(fechaInicio, fechaFin) {

//////////    //var meses = ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Set', 'Oct', 'Nov', 'Dic'];
//////////    var meses = ['T01', 'T02', 'T03', 'T04', 'T05', 'T06', 'T07'];

//////////    $.ajax({
//////////        url: '/Inicio/ListarAsistenciaDiaria',
//////////        type: 'POST',
//////////        data: { intIdPersonal: intIdPersonal_, fechaInicio: fechaInicio, fechaFin: fechaFin },
//////////        async: true,
//////////        beforeSend: function () {
//////////            //$.blockUI({
//////////            //    css: {
//////////            //        border: 'none',
//////////            //        padding: '15px',
//////////            //        backgroundColor: '#000',
//////////            //        '-webkit-border-radius': '10px',
//////////            //        '-moz-border-radius': '10px',
//////////            //        opacity: .5,
//////////            //        color: '#fff'
//////////            //    },
//////////            //    message: 'Procesando...'
//////////            //});
//////////        },
//////////        success: function (response) {

//////////            const anioMenor = fechaInicio.substr(0, 4)
//////////            const anioMayor = fechaFin.substr(0, 4)

//////////            const mesNumberMenor = parseInt(fechaInicio.substr(5, 2))
//////////            const mesNumberMayor = parseInt(fechaFin.substr(5, 2))

//////////            const anioGnl = anioMenor.substr(2, 2)

//////////            //const data_X = ['Ene' + anioGnl, 'Feb' + anioGnl, 'Mar' + anioGnl, 'Abr' + anioGnl, 'May' + anioGnl, 'Jun' + anioGnl, 'Jul' + anioGnl, 'Ago' + anioGnl, 'Set' + anioGnl, 'Oct' + anioGnl, 'Nov' + anioGnl, 'Dic' + anioGnl];

//////////            const data_X = ['T01' + anioGnl, 'T02' + anioGnl, 'T03' + anioGnl, 'T04' + anioGnl, 'T05' + anioGnl, 'T06' + anioGnl, 'T07' + anioGnl ];

//////////            if (anioMenor != anioMayor) {
//////////                var listaMenorAsis = []
//////////                var listaMenorInasis = []
//////////                var listaMayorAsis = []
//////////                var listaMayorInasis = []

//////////                var numerador = 0

//////////                for (var i = mesNumberMenor; i <= 12; i++) {
//////////                    listaMenorAsis[i] = 0
//////////                    listaMenorInasis[i] = 0
//////////                    data_X[numerador] = meses[i - 1] + anioMenor.substr(2, 2)
//////////                    numerador++
//////////                }

//////////                for (var i = 1; i <= mesNumberMayor; i++) {
//////////                    listaMayorAsis[i] = 0
//////////                    listaMayorInasis[i] = 0
//////////                    data_X[numerador] = meses[i - 1] + anioMayor.substr(2, 2)
//////////                    numerador++
//////////                }

//////////                response.forEach(element => {
//////////                    if (element.anio == anioMenor) {
//////////                        listaMenorAsis[parseInt(element.mes)] = element.asistencia
//////////                        listaMenorInasis[parseInt(element.mes)] = element.faltas

//////////                    } else if (element.anio == anioMayor) {
//////////                        listaMayorAsis[parseInt(element.mes)] = element.asistencia
//////////                        listaMayorInasis[parseInt(element.mes)] = element.faltas
//////////                    }
//////////                });

//////////                var list_asistencia = listaMenorAsis.concat(listaMayorAsis).filter(function (el) {
//////////                    return el != null;
//////////                });

//////////                var list_inasistencia = listaMenorInasis.concat(listaMayorInasis).filter(function (el) {
//////////                    return el != null;
//////////                });
//////////            } else {
//////////                var list_asistencia = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
//////////                var list_inasistencia = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

//////////                response.forEach(element => {
//////////                    switch (element.mes) {
//////////                        case 01:
//////////                            list_asistencia[0] = element.asistencia;
//////////                            list_inasistencia[0] = element.faltas;
//////////                            break
//////////                        case 02:
//////////                            list_asistencia[1] = element.asistencia;
//////////                            list_inasistencia[1] = element.faltas;
//////////                            break
//////////                        case 03:
//////////                            list_asistencia[2] = element.asistencia;
//////////                            list_inasistencia[2] = element.faltas;
//////////                            break;
//////////                        case 04:
//////////                            list_asistencia[3] = element.asistencia;
//////////                            list_inasistencia[3] = element.faltas;
//////////                            break;
//////////                        case 05:
//////////                            list_asistencia[4] = element.asistencia;
//////////                            list_inasistencia[4] = element.faltas;
//////////                            break;
//////////                        case 06:
//////////                            list_asistencia[5] = element.asistencia;
//////////                            list_inasistencia[5] = element.faltas;
//////////                            break;
//////////                        case 07:
//////////                            list_asistencia[6] = element.asistencia;
//////////                            list_inasistencia[6] = element.faltas;
//////////                            break;
//////////                        case 08:
//////////                            list_asistencia[7] = element.asistencia;
//////////                            list_inasistencia[7] = element.faltas;
//////////                            break;
//////////                        case 09:
//////////                            list_asistencia[8] = element.asistencia;
//////////                            list_inasistencia[8] = element.faltas;
//////////                            break;
//////////                        case 10:
//////////                            list_asistencia[9] = element.asistencia;
//////////                            list_inasistencia[9] = element.faltas;
//////////                            break;
//////////                        case 11:
//////////                            list_asistencia[10] = element.asistencia;
//////////                            list_inasistencia[10] = element.faltas;
//////////                            break;
//////////                        case 12:
//////////                            list_asistencia[11] = element.asistencia;
//////////                            list_inasistencia[11] = element.faltas;
//////////                            break;
//////////                    }
//////////                });

//////////            }

//////////            echartGlobalInstance.setOption({
//////////                xAxis: [{
//////////                    type: 'category',
//////////                    name: 'meses',
//////////                    data: data_X
//////////                }],
//////////                series: [{
//////////                    name: 'Asistencias',
//////////                    type: 'bar',
//////////                    data: list_asistencia,
//////////                    label: {
//////////                        show: true,
//////////                        position: 'insideRight'
//////////                    },
//////////                    //markPoint: {
//////////                    //    data: [{
//////////                    //        type: 'max',
//////////                    //        name: 'MAX'
//////////                    //    }, {
//////////                    //        type: 'min',
//////////                    //        name: 'MIN'
//////////                    //    }]
//////////                    //},
//////////                    markLine: {
//////////                        data: [{
//////////                            type: 'average',
//////////                            name: 'PROMEDIO'
//////////                        }]
//////////                    }
//////////                }, {
//////////                    name: 'Inasistencias',
//////////                    type: 'bar',
//////////                    data: list_inasistencia,
//////////                    label: {
//////////                        show: true,
//////////                        position: 'insideRight'
//////////                    },
//////////                    //markPoint: {
//////////                    //    data: [{
//////////                    //        type: 'max',
//////////                    //        name: 'MAX'
//////////                    //    }, {
//////////                    //        type: 'min',
//////////                    //        name: 'MIN'
//////////                    //    }]
//////////                    //},
//////////                    markLine: {
//////////                        data: [{
//////////                            type: 'average',
//////////                            name: 'PROMEDIO'
//////////                        }]
//////////                    }
//////////                }]
//////////            });

//////////        },
//////////        complete: function () {
//////////            //$.unblockUI();
//////////        }
//////////    });

//////////}


function getCabeceras(fechaInicio, fechaFin) {

    $.ajax({
        url: '/Inicio/ListarCabeceras',
        type: 'POST',
        data:
        { fechaInicio, fechaFin, intIdPersonal: intIdPersonal_ },
        async: true,
        beforeSend: function () {
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
            //    message: 'Procesando...'
            //});
        },
        success: function (response) {
            $(".tile_count").html("")
            if (response.length > 0) {
                response.forEach(x => {

                    var data = "";
                    data += `<div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                            <span class="count_top"><i class="${x.icon === '' ? 'fa fa-user' : x.icon}"></i> ${x.titulo}</span>
                            <div class="count green">${x.valor}</div>
                            <span class="count_bottom">${x.pie}</span>
                        </div>`

                    $(".tile_count").append(data)
                })
            } else {
                $(".tile_count").html("NO EXISTEN DATOS PARA MOSTRAR")
            }
        },
        complete: function () {
            //$.unblockUI();
        }
    });
}

function getHorasDescontadas(fechaInicio, fechaFin) {

    $.ajax({
        url: '/Inicio/ListarHorasDescontadas',
        type: 'POST',
        data:
        { fechaInicio, fechaFin, intIdPersonal: intIdPersonal_ },
        async: true,
        beforeSend: function () {
            $("#echart_pie3").html("Cargando...")
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
            //    message: 'Procesando...'
            //});
        },
        success: function (response) {
            var leyend = []
            var data = []
            $("#echart_pie3").empty()
            if (response.length > 0) {
                console.log(response)
                response.forEach(x => {
                    leyend.push(x.strDesConcepto)
                    data.push({ "value": x.intTotalHrs, "name": x.strDesConcepto, 'value2': x.strTotalHrs })
                })

                var echartPieCollapse = echarts.init(document.getElementById('echart_pie3'), theme);

                echartPieCollapse.setOption({
                    tooltip: {
                        trigger: 'item',
                        //formatter: "{a} <br/>{b} : {c} ({d}%)"
                        formatter: function (params) {
                            return `${params.seriesName}<br />
                              ${params.name}: ${params.data.value2} (${params.percent}%)<br />`;
                        }
                    },
                    legend: {
                        x: 'center',
                        y: 'bottom',
                        data: leyend,
                    },
                    toolbox: {
                        show: true,
                        feature: {
                            magicType: {
                                show: true,
                                type: ['pie', 'funnel']
                            },
                            restore: {
                                show: true,
                                title: "Restore"
                            },
                            saveAsImage: {
                                show: true,
                                title: "Save Image"
                            }
                        }
                    },
                    calculable: true,
                    series: [{
                        name: 'Detalle',
                        type: 'pie',
                        radius: ['0%', '30%'],
                        avoidLabelOverlap: true,
                        label: {
                            show: false,
                            position: 'center'
                        },
                        emphasis: {
                            label: {
                                show: true,
                                fontSize: '30',
                                fontWeight: 'bold'
                            }
                        },
                        labelLine: {
                            show: false
                        },
                        data: data
                    }]
                });
            } else {
                $("#echart_pie3").html("NO EXISTEN DATOS PARA MOSTRAR")
            }
        },
        complete: function () {
            //$.unblockUI();
        }
    });
}

function getHorasExtras(fechaInicio, fechaFin) {

    $.ajax({
        url: '/Inicio/ListarHorasExtras',
        type: 'POST',
        data:
        { fechaInicio, fechaFin, intIdPersonal: intIdPersonal_ },
        async: true,
        beforeSend: function () {
            $("#echart_pie4").html("Cargando...")
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
            //    message: 'Procesando...'
            //});
        },
        success: function (response) {
            var leyend = []
            var data = []
            $("#echart_pie4").empty()
            if (response.length > 0) {
                console.log(response)
                response.forEach(x => {
                    leyend.push(x.strDesConcepto)
                    data.push({ "value": x.intTotalHrs, "name": x.strDesConcepto, 'value2': x.strTotalHrs })
                })

                var echartPieCollapse = echarts.init(document.getElementById('echart_pie4'), theme);

                echartPieCollapse.setOption({
                    tooltip: {
                        trigger: 'item',
                        //formatter: "{a} <br/>{b} : {c} ({d}%)"
                        formatter: function (params) {
                            return `${params.seriesName}<br />
                              ${params.name}: ${params.data.value2} (${params.percent}%)<br />`;
                        }
                    },
                    legend: {
                        x: 'center',
                        y: 'bottom',
                        data: leyend,
                    },
                    toolbox: {
                        show: true,
                        feature: {
                            magicType: {
                                show: true,
                                type: ['pie', 'funnel']
                            },
                            restore: {
                                show: true,
                                title: "Restore"
                            },
                            saveAsImage: {
                                show: true,
                                title: "Save Image"
                            }
                        }
                    },
                    calculable: true,
                    series: [{
                        name: 'Detalle',
                        type: 'pie',
                        radius: ['0%', '30%'],
                        avoidLabelOverlap: true,
                        label: {
                            show: false,
                            position: 'center'
                        },
                        emphasis: {
                            label: {
                                show: true,
                                fontSize: '30',
                                fontWeight: 'bold'
                            }
                        },
                        labelLine: {
                            show: false
                        },
                        data: data
                    }]
                });
            } else {
                $("#echart_pie4").html("NO EXISTEN DATOS PARA MOSTRAR")
            }
        },
        complete: function () {
            //$.unblockUI();
        }
    });
}

$(document).ready(function () {

    ////ListarComboEntidad_NoEjecutable();


    $("#ps_edit_dos, #ps_edit_tres, #ps_edit_uno").bind({
        paste: function (e) {
            e.preventDefault()
            let output = e.originalEvent.clipboardData.getData('text').replaceAll(" ", "")
            $(this).val(output)
        }
    });

    intIdPersonal_ = window.SISCOP.intIdPersonal;

    const fechaInicioAsigHor = moment().startOf('year').format('DD/MM/YYYY') + ' 00:00:00';
    const fechaFinAsigHor = moment().endOf("year").format('DD/MM/YYYY') + ' 23:59:59';

    getCabeceras(fechaInicioAsigHor, fechaFinAsigHor)
    //////////getDiasAusencia(fechaInicioAsigHor, fechaFinAsigHor)
    //////////getHorasDescontadas(fechaInicioAsigHor, fechaFinAsigHor)
    //////////getHorasExtras(fechaInicioAsigHor, fechaFinAsigHor)
    //////getAsistenciaDiaria(fechaInicioAsigHor, fechaFinAsigHor)

    getGraficaBienesTipoBienes();

})



//--------------------------------------------------------------------LISTAR COMBOS
function ListarComboEntidad_NoEjecutable() {

    //TBOFICINA - COMBO
    $.post(
        '/Impresion/ListarTablasEnCombos',
        { strNomTablaEntidad: 'TBENTIDAD' },
        (response) => {

            $('#cbo_entidad').empty();
            $('#cbo_entidad').append('<option value="0">Todos</option>');
            //alert(response);
            response.forEach(element => {

                if (response.length > 1) {
                    $('#cbo_entidad').append('<option value="' + element.intIdEntidad + '">' + element.strDeEntidad + '</option>');
                }
                else {

                    $('#cbo_entidad').append('<option  value="' + element.intIdEntidad + '" selected>' + element.strDeEntidad + '</option>');

                }
            });

        });
}
