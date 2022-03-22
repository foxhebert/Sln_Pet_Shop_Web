var intIdPersonal_ = 0;
var titulosEnElEjeXCrystal = new Array();
var list_inventariadosCrystal = [];
var list_noinventariadosCrystal = [];
var arrayEncabezadoCrystal = [];

$('.range-datepicker').on('apply.daterangepicker', function (ev, picker) {
    validarSession()
    let filtrojer_ini = $('#campJerar').data('daterangepicker').startDate.format('YYYY/MM/DD')
    let filtrojer_fin = $('#campJerar').data('daterangepicker').endDate.format('YYYY/MM/DD')

    const anioMenor = filtrojer_ini.substr(0, 4)
    const anioMayor = filtrojer_fin.substr(0, 4)

    const mesNumberMenor = parseInt(filtrojer_ini.substr(5, 2))
    const mesNumberMayor = parseInt(filtrojer_fin.substr(5, 2))

    if (anioMenor !== anioMayor && mesNumberMenor == mesNumberMayor) {
        messageResponseMix({ type: 'info', message: 'Debe seleccionar 12 meses' }, 'Perfil')
        return false;
    } else {
        getCabeceras(filtrojer_ini, filtrojer_fin)
        //getDiasAusencia(filtrojer_ini, filtrojer_fin)
        getHorasDescontadas(filtrojer_ini, filtrojer_fin)
        getHorasExtras(filtrojer_ini, filtrojer_fin)
        getAsistenciaDiariaEdit(filtrojer_ini, filtrojer_fin)


    }
});

//function getDiasAusencia(fechaInicio, fechaFin) {

//    //////////$.ajax({
//    //////////    url: '/Inicio/ListarDiasAusencia',
//    //////////    type: 'POST',
//    //////////    data:
//    //////////    { fechaInicio, fechaFin, intIdPersonal: intIdPersonal_ },
//    //////////    async: true,
//    //////////    beforeSend: function () {
//    //////////        $("#echart_pie2").html("Cargando...")
//    //////////        //$.blockUI({
//    //////////        //    css: {
//    //////////        //        border: 'none',
//    //////////        //        padding: '15px',
//    //////////        //        backgroundColor: '#000',
//    //////////        //        '-webkit-border-radius': '10px',
//    //////////        //        '-moz-border-radius': '10px',
//    //////////        //        opacity: .5,
//    //////////        //        color: '#fff'
//    //////////        //    },
//    //////////        //    message: 'Procesando...'
//    //////////        //});
//    //////////    },
//    //////////    success: function (response) {
//            var leyend = []
//            var data = []
//            $("#echart_pie2").empty()
//            ////////////if (response.length > 0) {
//            ////////////    response.forEach(x => {
//            ////////////        leyend.push(x.strDesConcepto)
//            ////////////        data.push({ "value": x.intTotalDias, "name": x.strDesConcepto })
//            ////////////    })

//            data.push({ "value": 20, "name": "inventariados" });
//            data.push({ "value": 30, "name": "no inventariados" });

//            if (5 > 0) {

//                var echartPieCollapse = echarts.init(document.getElementById('echart_pie2'), theme);            


//                echartPieCollapse.setOption({
//                    tooltip: {
//                        trigger: 'item',
//                        formatter: "{a} <br/>{b} : {c} ({d}%)"
//                    },
//                    legend: {
//                        x: 'center',
//                        y: 'bottom',
//                        data: ['uno','dos', 'tres'] , //leyend
//                    },
//                    toolbox: {
//                        show: true,
//                        feature: {
//                            magicType: {
//                                show: true,
//                                type: ['pie', 'funnel']
//                            },
//                            restore: {
//                                show: true,
//                                title: "Restore"
//                            },
//                            saveAsImage: {
//                                show: true,
//                                title: "Save Image"
//                            }
//                        }
//                    },
//                    calculable: true,
//                    series: [{
//                        name: 'Detalle',
//                        type: 'pie',
//                        radius: ['0%', '30%'],
//                        avoidLabelOverlap: true,
//                        label: {
//                            show: false,
//                            position: 'center'
//                        },
//                        emphasis: {
//                            label: {
//                                show: true,
//                                fontSize: '30',
//                                fontWeight: 'bold'
//                            }
//                        },
//                        labelLine: {
//                            show: false
//                        },
//                        data: data// [20,30,40]// 
//                    }]
//                });
//            } else {
//                $("#echart_pie2").html("NO EXISTEN DATOS PARA MOSTRAR")
//            }
//    //////////    },
//    //////////    complete: function () {
//    //////////        //$.unblockUI();
//    //////////    }
//    //////////});
//}


let listGetPieBienes = [];
let listGetPieTipos = [];
let listGetPieImpresos = [];
let leyendaTipos = [];
let leyendaBienes = [];
let leyendaImpresos = [];
/////////////////////////////////////////////////////////////
//01 PIE BIENES
/////////////////////////////////////////////////////////////
function getPieBienes() {

    $("#echart_pie_bienes").empty();
    //alert('listGetPieBienes[0].value  ' + listGetPieBienes[0].value) && listGetPieBienes[0].value !== "0" && listGetPieBienes[1].value !== "0"
    //alert('Total de Bienes Sin Inventario --->' + listGetPieBienes[0].value + '  ' + 'Total de Bienes Sin Inventario --->' + listGetPieBienes[1].value);

    var mayoracero = false;
    if (listGetPieBienes[0].value == "0" && listGetPieBienes[1].value == "0") {

        mayoracero = true;
        
    }

    //alert(mayoracero);

    if (listGetPieBienes.length > 0 && mayoracero == false) {

        var echartPieCollapse = echarts.init(document.getElementById('echart_pie_bienes'), theme);

        echartPieCollapse.setOption({

            tooltip: {
                trigger: 'item',
                formatter: "{a} <br/>{b} : {c} ({d}%)"
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

            legend: {
                bottom: 10,
                left: 'center',
                data: leyendaBienes //['Inventariados', 'No Inventariados']
            },

            series: [
                {
                    type: 'pie',
                    radius: '45%',
                    center: ['45%', '45%'],
                    selectedMode: 'single',
                    data: listGetPieBienes,
                    //data: [
                    //    { value: 735, name: 'Inventariados' },
                    //    { value: 510, name: 'No Inventariados' },

                    //],
                    emphasis: {
                        itemStyle: {
                            shadowBlur: 10,
                            shadowOffsetX: 0,
                            shadowColor: 'rgba(0, 0, 0, 0.5)'
                        }
                    }
                }
            ]

        });
    } else {
        $("#echart_pie_bienes").html("NO EXISTEN DATOS PARA MOSTRAR")
    }

}


/////////////////////////////////////////////////////////////
//01 PIE TIPOS
/////////////////////////////////////////////////////////////
function getPieTipos() {

    $.ajax({
        url: '/Inicio/ListarDatosGraficaPie',
        type: 'POST',
        data:
        { fechaInicio, fechaFin, strNombreDeTorta: 'getPieTipos' }, 
        async: true,
        beforeSend: function () {
            $("#echart_pie_tipos").html("Cargando...")
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
    $("#echart_pie_tipos").empty();
    //alert('getPieTipos'+response.length);
    if (response.length > 0) {

        //response.forEach(x => {
        //    leyend.push(x.strDesConcepto)
        //    data.push({ "value": x.intTotalDias, "name": x.strDesConcepto })
        //})

        //////response.forEach(x => {
        ////    listGetPieTipos.push({
        ////        "value": x.intValorUno ,
        ////        "name" : x.intValorDos
        ////    });
        //////}); 


        //////response.forEach(x => {
        ////    listGetPieTipos.push({
        ////        "value": x.intValorUno,
        ////        "name": x.intValorDos
        ////    });
        //////}); 

        listGetPieTipos.push({
            "value": response[0].intValorUno, "name": "Con \nInven- \ntario" + ' \n ' + '(' + (response[0].intValorUno).toString() + ')'      //+ response[0].intValorUno
        });

        listGetPieTipos.push({
            "value": response[0].intValorDos, "name": "Sin \nInven- \ntario" + ' \n ' + '(' +(response[0].intValorDos).toString() + ')' 
        });

        
        leyendaTipos.push("Con \nInven- \ntario" + ' \n ' + '(' + (response[0].intValorUno).toString() + ')' )
        leyendaTipos.push("Sin \nInven- \ntario" + ' \n ' + '(' + (response[0].intValorDos).toString() + ')')


        //////////////////////////////////////////////////////////////////////PIE TIPOS
        arrayEncabezadoCrystal.push({
              "strTitulo": "Tipos"
            , "strValor": (response[0].intValorUno).toString()
            , "strCalculadoFecha": (response[0].intValorDos).toString()
            , "strTipoBienesX": "Gráficas Circulares",
            "strNumeroBienesY": "B",
        });
         //////////////////////////////////////////////////////////////////////



        //arrayEncabezadoCrystal[0].strValor

    //data.push({ "value": 20, "name": "inventariados" });
    //data.push({ "value": 30, "name": "no inventariados" });

    ////if (5 > 0) {

        var echartPieCollapse = echarts.init(document.getElementById('echart_pie_tipos'), theme);


        echartPieCollapse.setOption({




            tooltip: {
                trigger: 'item',
                emphasis: { focus: 'data' },
                formatter: "{a} <br/>{b} : {c} ({d}%)"
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

            legend: {
                bottom: 10,
                left: 'center',
                data: leyendaTipos, // ['Inventariados', 'No Inventariados'] //
            },

            series: [
                {
                    type: 'pie',
                    radius: '45%',
                    center: ['45%', '45%'],
                    //emphasis: { focus: 'data' },
                    //label: {
                    //    formatter: '{b}: {@2012} ({d}%)'
                    //},
                    selectedMode: 'single',
                    data: listGetPieTipos,

                    //data: [
                    //    { value: 735, name: 'Inventariados' },
                    //    { value: 510, name: 'No Inventariados' },

                    //],

                    emphasis: {
                        itemStyle: {
                            shadowBlur: 10,
                            shadowOffsetX: 0,
                            shadowColor: 'rgba(0, 0, 0, 0.5)'
                        }
                    }
                }
            ]

        });
    }

    else {
        $("#echart_pie_tipos").html("NO EXISTEN DATOS PARA MOSTRAR")
    }
        },
        complete: function () {
            $.unblockUI();
        }
    });

   
}


/////////////////////////////////////////////////////////////
//02 PIE ETIQUETAS IMPRESAS
/////////////////////////////////////////////////////////////
function getPieEtiquetasImpresas() {

    $.ajax({
        url: '/Inicio/ListarDatosGraficaPie',
        type: 'POST',
        data:
        { fechaInicio, fechaFin, strNombreDeTorta: 'getPieEtiquetasImpresas' }, 
        async: true,
        beforeSend: function () {
            $("#echart_pie_impresos").html("Cargando...")
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
    $("#echart_pie_impresos").empty()

    if (response.length > 0) {
        ////////////    response.forEach(x => {
        ////////////        leyend.push(x.strDesConcepto)
        ////////////        data.push({ "value": x.intTotalDias, "name": x.strDesConcepto })
        ////////////    })
        //data.push({ "value": 20, "name": "inventariados" });
        //data.push({ "value": 30, "name": "no inventariados" });
        //if (5 > 0) {
        //var listGetPieEtiquetas = [];
        //listGetPieEtiquetas.push({
        //    "value": response[0].intValorUno,
        //    "name": "Impresos" //+ response[0].intValorUno
        //});
        //listGetPieEtiquetas.push({
        //    "value": response[0].intValorDos,
        //    "name": "No Impresos"
        //});

        listGetPieImpresos.push({
            "value": response[0].intValorUno, "name": "Impresos" + ' \n ' + '(' + (response[0].intValorUno).toString() + ')'      //+ response[0].intValorUno
        });
        listGetPieImpresos.push({
            "value": response[0].intValorDos, "name": "No\nImpresos" + ' \n ' + '(' + (response[0].intValorDos).toString() + ')'
        });

        leyendaImpresos.push("Impresos" + ' \n ' + '(' + (response[0].intValorUno).toString() + ')');
        leyendaImpresos.push("No\nImpresos" + ' \n ' + '(' + (response[0].intValorDos).toString() + ')');

        //////////////////////////////////////////////////////////////////////PIE ETIQUETAS IMPRESAS
        arrayEncabezadoCrystal.push({
              "strTitulo": "Etiquetas Impresas"
            , "strValor": (response[0].intValorUno).toString()
            , "strCalculadoFecha": (response[0].intValorDos).toString()
            , "strTipoBienesX": "Gráficas Circulares",
            "strNumeroBienesY": "B",
        });
         //////////////////////////////////////////////////////////////////////


        var echartPieCollapse = echarts.init(document.getElementById('echart_pie_impresos'), theme);

        echartPieCollapse.setOption({
            tooltip: {
                trigger: 'item',
                formatter: "{a} <br/>{b} : {c} ({d}%)"
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
            legend: {
                bottom: 10,
                left: 'center',
                data: leyendaImpresos// ['Impresos', 'No Impresos']
            },
            series: [
                {
                    type: 'pie',
                    radius: '45%',
                    center: ['45%', '45%'],
                    selectedMode: 'single',
                    data: listGetPieImpresos,

                    //[
                    //    { value: 735, name: 'Impresos' },
                    //    { value: 510, name: 'No Impresos' },

                    //],

                    emphasis: {
                        itemStyle: {
                            shadowBlur: 10,
                            shadowOffsetX: 0,
                            shadowColor: 'rgba(0, 0, 0, 0.5)'
                        }
                    }
                }
            ]

        });
    } else {
        $("#echart_pie_impresos").html("NO EXISTEN DATOS PARA MOSTRAR")
    }
        },
        complete: function () {
            $.unblockUI();
        }
    });

}

function getGraficaBienesTipoBienes() { //getAsistenciaDiaria(fechaInicio, fechaFin) {
    var echartBar = echarts.init(document.getElementById('mainPrincipalGraficaBarras'), theme);

    ////////////////////////////////////////////////////
    window.addEventListener('resize', function () {
        echartBar.resize();
    })
    ////////////////////////////////////////////////////

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
                titulosEnElEjeX.push(response[x].strCodTipo + '\n' + response[x].strDescTipo); // 
                //titulosEnElEjeX.push([{ "1": "1" }, {"1":1}, {"1": 1 },{ "1":1}]); // + '\n' + response[x].strDescTipo
                list_inventariados.push(response[x].coninventario); //
                list_noinventariados.push(response[x].sininventario);   
            }


            /////////////////////////////////////////////////////////////////////////
            // CAPTURARAR LO QUE VA EN EL EJE X EN UN ARRAY
            /////////////////////////////////////////////////////////////////////////
            for (x in response) {
                arrayEncabezadoCrystal.push({
                    "strTitulo": response[x].strCodTipo + '    ' + response[x].strDescTipo,
                    "strValor": response[x].coninventario,
                    "strCalculadoFecha": response[x].sininventario, "strTipoBienesX": "Gráfica de Barras",
                    "strNumeroBienesY": "C",
                });
            }
            //////////////////////////////////////////////////////////////////////////



            echartBar.setOption({


                ////grid: {// Control the size of the graph, just adjust the following values,
                ////    x: 100,//Control the distance between the x-axis text and the bottom
                ////    y2: 200 // y2 can control the rightmost distance of the slanted text prison, place the slanted text beyond the display area
                ////},
                //////////xAxis: [{
                //////////    type: 'category',
                //////////    //data: ['2015-2016', '2016-2017', '2017-2018', '2018-2019']
                //////////    axisLabel: {
                //////////        interval: 0, //Force text generation interval
                //////////        rotate: 45, //Text rotates counterclockwise by 45°
                //////////        textStyle: {//Text style
                //////////            color: "black",
                //////////            fontSize: 16,
                //////////            fontFamily: 'Microsoft YaHei'
                //////////        }
                //////////    }

                //////////}],

                //title: {
                //    text: 'Gráfico de Consumos Anual'
                //},
                tooltip: {
                    trigger: 'axis'
                },
                //VALORES ENCIMA
                label: {
                    normal: {
                        show: true,
                        fontSize: 80,
                        position: 'top'
                    }
                },
                legend: {
                    bottom: -5,
                    left: 'center',
                    data: ['Con Inventario', 'Sin Inventario']
                },
                toolbox: {
                    show: false
                },
                //toolbox: {
                //    show: true,
                //    feature: {
                //        dataView: { show: true, readOnly: false },
                //        magicType: { show: true, type: ['line', 'bar'] },
                //        restore: { show: true },
                //        saveAsImage: { show: true }
                //    }
                //},
                calculable: false,

                //grid: {// Control the size of the graph, just adjust the following values,
                //    x: 100,//Control the distance between the x-axis text and the bottom
                //    y2: 200 // y2 can control the rightmost distance of the slanted text prison, place the slanted text beyond the display area
                //},

                xAxis: [{
                    bottom: -25,
                    left: -10,
                    type: 'category',
                    name: '  Tipo   \n   de \nBienes',
                    data: titulosEnElEjeX,







                    //axisLabel: {
                    //    interval: 0, //Force text generation interval
                    //    rotate: 45, //Text rotates counterclockwise by 45°
                    //    textStyle: {//Text style
                    //        color: "black",
                    //        fontSize: 16,
                    //        fontFamily: 'Microsoft YaHei'
                    //    }
                    //}

                    //axisLabel: {
                    //    rotate: -90, // <<<<<<<<<<<<<< this option!
                    //},

                    //axisLabel: {
                    //    Interval: 0, // ​​horizontal axis information is all displayed
                    //    Rotate: -90, // - 30 degree angle display    
                    //},
                    //axisLabel: {
                    //    interval:90,
                    //    formatter: function (val) {
                    //        return val.split("").join("\n");
                    //    }
                    //}

                },

                ],
                yAxis: [{
                    name: 'N° Bienes',
                    type: 'value'
                }],

                series: [{
                    name: 'Con Inventario',
                    type: 'bar',
                    data: list_inventariados,
                    markPoint: {
                        data:
                        //data: [2.0, 4.9, 7.0, 23.2, 25.6, 76.7, 135.6, 162.2, 32.6, 20.0, 6.4, 3.3]
                        [{
                            //type: 'max',
                            //name: 'MAX'
                        },
                        {
                            //type: 'min',
                            //name: 'MIN'
                        }]
                    },
                },

                {
                    name: 'Sin Inventario',
                    type: 'bar',
                    data: list_noinventariados,
                    markPoint: {
                        data:
                        [{
                            //type: 'max',
                            //name: 'MAX'
                        }, {
                            //type: 'min',
                            //name: 'MIN'
                        }]
                    },

                    }]


            });

        },
        complete: function () {
            //$.unblockUI();
        }
    });
}

function getCabeceras(fechaInicio, fechaFin) {

    arrayEncabezadoCrystal = [];

    $.ajax({
        url: '/Inicio/ListarCabeceras',
        type: 'POST',
        data:
        { fechaInicio, fechaFin, intIdPersonal: intIdPersonal_ },
        async: true,
        beforeSend: function () {

        },
        success: function (response) {
            $(".tile_count").html("")
            if (response.length > 0) {
                response.forEach(x => {

                    //titulosEnElEjeXCystal.push(x.titulo, x.valor);


                    ////CONSTUCTOR - AGREGAR CORREO
                    //class CONSTRUCTOR_ENCABEZADO {
                    //    constructor(
                    //        xtitulo_,
                    //        xvalor_
                    //    ) {
                    //        this.titulo = xtitulo_
                    //        this.valor = xvalor_
                    //    }
                    //}
                    //var intNewId = maximoIdExistente + 1;
                    //arrayEncabezadoCrystal.push(new CONSTRUCTOR_ENCABEZADO(x.titulo, x.valor));



                    ////////////////////////////////////////////////////////////////////////////////Encabezados Totalizados
                    arrayEncabezadoCrystal.push({
                        "strTitulo": x.titulo, "strValor": x.valor
                        , "strCalculadoFecha": (x.pie).slice(30, 40)
                        , "strTipoBienesX": "Resumen Totalizado",
                        "strNumeroBienesY": "A", });
                    ////////////////////////////////////////////////////////////////////////////////

                    var data = "";
                    data += `<div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                            <span class="count_top"><i class="${x.icon == '' ? 'fa fa-user' : x.icon}"></i> ${x.titulo}</span>
                            <div class="count green">${x.valor}</div>
                            <span class="count_bottom">${x.pie}</span>
                        </div>`

                    $(".tile_count").append(data)
                })

                ////////////////////////////////////////////////////////////////////////////////
                //CAPTURAR VALORES PARA EL REPORTE DE RESUMEN
                ////////////////////////////////////////////////////////////////////////////////
                //arrayEncabezadoCrystal.push({
                //    "strTitulo": "", "strValor": "", "strCalculadoFecha": ""
                //    , "strTipoBienesX": "Gráfica de Barras",
                //    "strNumeroBienesY": "C",
                //}); 
                //arrayEncabezadoCrystal.push({
                //    "strTitulo": "Resumen de Inventario de Bienes por Tipo", "strValor": "", "strCalculadoFecha": ""
                //    , "strTipoBienesX": "BIENES_Vs_TIPO",
                //    "strNumeroBienesY": "C",
                //});  
                arrayEncabezadoCrystal.push({
                    "strTitulo": "                 TIPO DE BIENES",
                    "strValor": "                     " + "N° BIENES",
                    "strCalculadoFecha": "",
                    "strTipoBienesX": "Gráfica de Barras",
                    "strNumeroBienesY": "C",
                });              
                arrayEncabezadoCrystal.push({
                    "strTitulo": "= = = = = = = = = = = = = = = = = = = = = = = = ",
                    "strValor": "= = = = = = = = = = = = = = = = = = = = =   ",
                    "strCalculadoFecha": "",
                    "strTipoBienesX": "---------------",
                    "strNumeroBienesY": "C", 
                });  



                //arrayEncabezadoCrystal.push({
                //    "strTitulo": "strTitulo------",
                //    "strValor": "strValor---",
                //    "strCalculadoFecha": "strCalculadoFecha---",
                //    "strTipoBienesX": "strTipoBienesX5",
                //    "strNumeroBienesY": "C",
                //}); 
                ////arrayEncabezadoCrystal.push({
                ////    "strTitulo": "", "strValor": "CON INVENTARIO", "strCalculadoFecha": "SIN INVENTARIO"
                ////    , "strTipoBienesX": "-------",
                ////    "strNumeroBienesY": "C", }); 
                ////////////////////////////////////////////////////////////////////////////////





                ////////////////////////////////////////////////////////////////////////////////
                //CAPTURAR LOS VALORES PARA EL GRAFICO DEL PRIMER PIE (BIENES)
                ////////////////////////////////////////////////////////////////////////////////
                listGetPieBienes.push({
                    "value": arrayEncabezadoCrystal[0].strValor, "name": "Con \nInven- \ntario" + ' \n ' + '(' + (arrayEncabezadoCrystal[0].strValor).toString() + ')' 
                    //"value": arrayEncabezadoCrystal[0].strValor,
                    //"name": "Inventariados"
                }); 
                listGetPieBienes.push({
                    "value": arrayEncabezadoCrystal[1].strValor, "name": "Sin \nInven- \ntario" + ' \n ' + '(' + (arrayEncabezadoCrystal[1].strValor).toString() + ')' 
                    //"value": arrayEncabezadoCrystal[1].strValor,
                    //"name": "No Inventariados"
                }); 
                leyendaBienes.push("Con \nInven- \ntario" + ' \n ' + '(' + (arrayEncabezadoCrystal[0].strValor).toString() + ')')
                leyendaBienes.push("Sin \nInven- \ntario" + ' \n ' + '(' + (arrayEncabezadoCrystal[1].strValor).toString() + ')')
                getPieBienes();


                ////////////////////////////////////////////////////////////////////////////////PIE BIENES
                arrayEncabezadoCrystal.push({
                    "strTitulo": "Bienes",
                    "strValor": (arrayEncabezadoCrystal[0].strValor).toString()
                    , "strCalculadoFecha": (arrayEncabezadoCrystal[1].strValor).toString()
                    , "strTipoBienesX": "Gráficas Circulares",
                    "strNumeroBienesY": "B",
                });
                ////////////////////////////////////////////////////////////////////////////////

                ////////////////////////////////////////////////////////////////////////////////PIE TIPOS
                //////////arrayEncabezadoCrystal.push({
                //////////    "strTitulo": "Tipos",
                //////////    "strValor": (arrayEncabezadoCrystal[0].strValor).toString()
                //////////    , "strCalculadoFecha": (arrayEncabezadoCrystal[1].strValor).toString()
                //////////    , "strTipoBienesX": "Gráficas Circulares",
                //////////    "strNumeroBienesY": "B",
                //////////});
                ////////////////////////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////////////////////////////PIE ETIQUETAS IMPRESAS
                ////arrayEncabezadoCrystal.push({
                ////    "strTitulo": "Etiquetas Impresas",
                ////    "strValor": (arrayEncabezadoCrystal[0].strValor).toString()
                ////    , "strCalculadoFecha": (arrayEncabezadoCrystal[1].strValor).toString()
                ////    , "strTipoBienesX": "Gráficas Circulares",
                ////    "strNumeroBienesY": "B",
                ////});
                ////////////////////////////////////////////////////////////////////////////////////






            } else {
                $(".tile_count").html("NO EXISTEN DATOS PARA MOSTRAR")
            }

            //////////////////////////////////////////
            //for (x in response) {

            //    titulosEnElEjeXCystal.push(response[x].strCodTipo + '\n' + response[x].strDescTipo);
            //    list_inventariadosCystal.push(response[x].coninventario);
            //    list_noinventariadosCystal.push(response[x].sininventario);
            //}



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
    ////getDiasAusencia(fechaInicioAsigHor, fechaFinAsigHor)
    //////////getHorasDescontadas(fechaInicioAsigHor, fechaFinAsigHor)
    //////////getHorasExtras(fechaInicioAsigHor, fechaFinAsigHor)
    //////getAsistenciaDiaria(fechaInicioAsigHor, fechaFinAsigHor)

    //PARA SISACTIVOFIJO
    getGraficaBienesTipoBienes();
    //getPieBienes();
    getPieTipos();
    getPieEtiquetasImpresas();


})



var adicional = "&pdf=1"; //Para PDF
var listGraficoDashboard = new Array();
//////////////////////////////////////////////////////////////////
//REPORTE RESUMEN DE DASHBOARD CRYSTAL
//////////////////////////////////////////////////////////////////
$('#btn-generar-report-resumen-dashboard-crystal-SAF').on('click', function () {

    //////https://stackoverflow.com/questions/31722687/pass-the-argument-from-ajax-function-to-aspx-cs-filelist
    $.ajax({
        type: "POST",
        url: "/Rep/Vista/RepVentanaPrincipal.aspx/ListaJSDashboard",
        data: JSON.stringify({ 'listadoVentanaPricipal': arrayEncabezadoCrystal }), // '{"id":"' + 123 + '"}',//change your code here
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {

            filtroDeReporte = "ReporteResumenDeDashboard"
            window.open('/Rep/Vista/RepVentanaPrincipal.aspx?filtroDeReporte=' + filtroDeReporte + '&zoomLevel=' + '80' +  '');
            //$.unblockUI();
        },
        failure: function () {
            //alert("Failure!");
        }
    });

});


//////////////////////////////////////////////////////////////////
//REPORTE RESUMEN DE DASHBOARD PDF
//////////////////////////////////////////////////////////////////
$('#btn-generar-report-resumen-dashboard-pdf-SAF').on('click', function () {

    //////https://stackoverflow.com/questions/31722687/pass-the-argument-from-ajax-function-to-aspx-cs-filelist
    $.ajax({
        type: "POST",
        url: "/Rep/Vista/RepVentanaPrincipal.aspx/ListaJSDashboard",
        data: JSON.stringify({ 'listadoVentanaPricipal': arrayEncabezadoCrystal }), 
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {

            filtroDeReporte = "ReporteResumenDeDashboard"
            window.open('/Rep/Vista/RepVentanaPrincipal.aspx?filtroDeReporte=' + filtroDeReporte + '&zoomLevel=' + '80' + adicional, '');
        },
        failure: function () {
            //alert("Failure!");
        }
    });

});


//////////////////////////////////////////////////////////////////
//REPORTE GRAFICO DE DASHBOARD CRYSTAL
//////////////////////////////////////////////////////////////////
$('#btn-generar-report-grafico-dashboard-crystal-SAF').on('click', function () {

    var ratio = (screen.availWidth / document.documentElement.clientWidth);
    //alert(ratio);
    var zoomLevelPantalla = Number(ratio.toFixed(1).replace(".", "") + "0");
    //alert(zoomLevelPantalla);

    if (zoomLevelPantalla < 70) {
        $('.right_col').addClass("right_colclass");
        $('body').addClass("bodyClass");
    }
    if (zoomLevelPantalla == 70) {
        $('.right_col').addClass("right_colclass");
        $('body').addClass("bodyClass");
    }
    if (zoomLevelPantalla == 80 ) {
        $('.right_col').addClass("right_colclass");
        $('body').addClass("bodyClass");
    }
    if (zoomLevelPantalla == 90) {
        $('.right_col').addClass("right_colclass90");
        $('body').addClass("bodyClass90");
    }
    if (zoomLevelPantalla == 100) {

        $('.right_col').addClass("right_colclass100");
        $('body').addClass("bodyClass100");
    }
    if (zoomLevelPantalla == 110) {

        $('.right_col').addClass("right_colclass110");
        $('body').addClass("bodyClass110");
    }

    else {
        //$('.right_col').addClass("right_colclass2");
        //$('body').addClass("bodyClass2");
    }

    //var width, mediaQuery;
    //width = document.body.clientWidth;
    //mediaQuery = '(max-width: ' + width + 'px) and (min-width: ' + width + 'px)';
    //return !window.matchMedia(mediaQuery).matches;
    //document.body.style.zoom = screen.logicalXDPI / screen.deviceXDPI;

        ////var scale = 'scale(1.2)';
        ////document.body.style.webkitTransform =       // Chrome, Opera, Safari
        ////document.body.style.msTransform =          // IE 9
        ////document.body.style.transform = scale;     // General

           //$.blockUI({
           //     css: {
           //         border: 'none',
           //         padding: '15px',
           //         backgroundColor: '#000',
           //         '-webkit-border-radius': '10px',
           //         '-moz-border-radius': '10px',
           //         opacity: .5,
           //         color: '#fff'
           //     },
           //     message: 'Procesando...'
           // });

    //jQuery('#btn-generar-report-grafico-dashboard-crystal-SAF').hide();  
    //jQuery('#btn-generar-report-resumen-dashboard-crystal-SAF').hide();  
    
    jQuery('.esconder-botones').hide(); 

    var nombreImgDashboardHead_ = "nombreDashboardHead.png"
    //let region = document.querySelector("body"); // whole screen
    let region = $(".right_col")//Capturamos el div deseado, al gusto del cliente

    html2canvas(region, {
        onrendered: function (canvas) {
            let pngUrl = canvas.toDataURL(); // png in dataURL format
            let img = document.querySelector(".screen");
            img.src = pngUrl;

            // here you can allow user to set bug-region
            // and send it with 'pngUrl' to server
            var photoBase64Captured = document.getElementById("base64image").src;

            $.post(
                '/Reportes/SaveImage',
                //"",
                {
                    base64image        : photoBase64Captured,
                    imagenDashboardHead: nombreImgDashboardHead_,
                 
                    //imagenDashboardHead: imagenGraficaBarras_,
                },
                response => {

                    jQuery('.esconder-botones').show(); 
                    //Eliminar imagen de la division
                    img.src = "";
                    //$(".screen").html("")
                    //jQuery('.screen').removeAttr('src')
                    //jQuery('.screen').show();                   
                    //img.src = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAApgAAAKYB3X3/OAAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAANCSURBVEiJtZZPbBtFFMZ/M7ubXdtdb1xSFyeilBapySVU8h8OoFaooFSqiihIVIpQBKci6KEg9Q6H9kovIHoCIVQJJCKE1ENFjnAgcaSGC6rEnxBwA04Tx43t2FnvDAfjkNibxgHxnWb2e/u992bee7tCa00YFsffekFY+nUzFtjW0LrvjRXrCDIAaPLlW0nHL0SsZtVoaF98mLrx3pdhOqLtYPHChahZcYYO7KvPFxvRl5XPp1sN3adWiD1ZAqD6XYK1b/dvE5IWryTt2udLFedwc1+9kLp+vbbpoDh+6TklxBeAi9TL0taeWpdmZzQDry0AcO+jQ12RyohqqoYoo8RDwJrU+qXkjWtfi8Xxt58BdQuwQs9qC/afLwCw8tnQbqYAPsgxE1S6F3EAIXux2oQFKm0ihMsOF71dHYx+f3NND68ghCu1YIoePPQN1pGRABkJ6Bus96CutRZMydTl+TvuiRW1m3n0eDl0vRPcEysqdXn+jsQPsrHMquGeXEaY4Yk4wxWcY5V/9scqOMOVUFthatyTy8QyqwZ+kDURKoMWxNKr2EeqVKcTNOajqKoBgOE28U4tdQl5p5bwCw7BWquaZSzAPlwjlithJtp3pTImSqQRrb2Z8PHGigD4RZuNX6JYj6wj7O4TFLbCO/Mn/m8R+h6rYSUb3ekokRY6f/YukArN979jcW+V/S8g0eT/N3VN3kTqWbQ428m9/8k0P/1aIhF36PccEl6EhOcAUCrXKZXXWS3XKd2vc/TRBG9O5ELC17MmWubD2nKhUKZa26Ba2+D3P+4/MNCFwg59oWVeYhkzgN/JDR8deKBoD7Y+ljEjGZ0sosXVTvbc6RHirr2reNy1OXd6pJsQ+gqjk8VWFYmHrwBzW/n+uMPFiRwHB2I7ih8ciHFxIkd/3Omk5tCDV1t+2nNu5sxxpDFNx+huNhVT3/zMDz8usXC3ddaHBj1GHj/As08fwTS7Kt1HBTmyN29vdwAw+/wbwLVOJ3uAD1wi/dUH7Qei66PfyuRj4Ik9is+hglfbkbfR3cnZm7chlUWLdwmprtCohX4HUtlOcQjLYCu+fzGJH2QRKvP3UNz8bWk1qMxjGTOMThZ3kvgLI5AzFfo379UAAAAASUVORK5CYII=";

                    ////////////////////////////////////////////////////////////////                    
                    /*RECIEN SE ENVIA AL CRYSTAL*/
                    listGraficoDashboard.push({

                          "strIdImagen": "zoomLevelPantalla"
                        , "strDescripcion": "strDescripcion_nada"
                        , "byteImagenData": "byteImagenData_nada"
                        , "strPathImagen": response  //"~/Content/img/" + nombreImgDashboardHead_////---> "D:\\Koala.jpg"

                    });

                    $.ajax({
                        type: "POST",
                        url: "/Rep/Vista/RepVentanaPrincipal.aspx/ReportDashboardPrincipal",
                        data: JSON.stringify({ 'listGraficoDashboard': listGraficoDashboard }), // '{"id":"' + 123 + '"}',//change your code here
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {                         

                            listGraficoDashboard.length = 0;
                            window.open('/Rep/Vista/RepVentanaPrincipal.aspx?filtroDeReporte=' + "ReporteGraficoDeDashboard" + '&zoomLevel=' + zoomLevelPantalla +  '');
                            //$('#menu_toggle').click();
                            $('.right_col').removeClass("right_colclass");
                            $('body').removeClass("bodyClass");
                            $('.right_col').removeClass("right_colclass100");
                            $('body').removeClass("bodyClass100");
                            $('.right_col').removeClass("right_colclass110");
                            $('body').removeClass("bodyClass110");
                            $('.right_col').removeClass("right_colclass90");
                            $('body').removeClass("bodyClass90");


                        },
                        failure: function () {

                            alert("Failure!");

                        }
                    });                    
                    //////////////////////////////////////////////////////////////////////

                });



        },
    });

        /////////////////////////////////////////////////////////
        //var file = document.getElementById("base64image").src;
        //var formdata = new FormData();
        //formdata.append("base64image", file);

        //$.ajax({
        //    url: "@Url.Action("SaveImage")",
        //    type: "POST",
        //    data: formdata,
        //    processData: false,
        //    contentType: false
        //});

    //$.post(
    //    "/Rep/Vista/RepVentanaPrincipal.aspx/SaveImage",
    //    { base64: photoBase64Captured },
    //    function (data) {
    //    var result = $.parseJSON(data);
    //    if (data != null) {
    //    }
    //    });

    //var formdata = new FormData();
    //formdata.append("base64image", file);
    //$.ajax({
    //    type: "POST",
    //    url: "/Rep/Vista/RepVentanaPrincipal.aspx/SaveImage",
    //    data: formdata, // '{"id":"' + 123 + '"}',//change your code here JSON.stringify({ pngUrl }), 
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //    success: function () {

    //        //alert('REPORTE_DASHBOARD_PRINCIPAL');
    //        //window.open('/Rep/Vista/RepVentanaPrincipal.aspx?strExcelExportado=' + "REPORTE_DASHBOARD_PRINCIPAL" + '');

    //    },
    //    failure: function () {

    //        alert("Failure!");

    //    }
    //});
    //$.ajax({
    //    url: "/Rep/Vista/RepVentanaPrincipal.aspx/SaveImage",
    //    //url: "@Url.Action("SaveImage")",
    //    type: "POST",
    //    data: formdata,
    //    processData: false,
    //    contentType: false
    //});
});


//////////////////////////////////////////////////////////////////
//REPORTE GRAFICO DE DASHBOARD PDF
//////////////////////////////////////////////////////////////////
$('#btn-generar-report-grafico-dashboard-pdf-SAF').on('click', function () {

    var ratio = (screen.availWidth / document.documentElement.clientWidth);
    var zoomLevelPantalla = Number(ratio.toFixed(1).replace(".", "") + "0");

    if (zoomLevelPantalla > 69 && zoomLevelPantalla < 90) {
        $('.right_col').addClass("right_colclass");
        $('body').addClass("bodyClass");
    }
    if (zoomLevelPantalla == 90) {
        $('.right_col').addClass("right_colclass90");
        $('body').addClass("bodyClass90");
    }
    if (zoomLevelPantalla == 100) {

        $('.right_col').addClass("right_colclass100");
        $('body').addClass("bodyClass100");
    }
    else {

    }

   //alert(zoomLevelPantalla)
    //jQuery('#btn-generar-report-grafico-dashboard-pdf-SAF').hide();
    //jQuery('#btn-generar-report-resumen-dashboard-pdf-SAF').hide();
    jQuery('.esconder-botones').hide(); 
    var nombreImgDashboardHead_ = "nombreDashboardHead.png"
    //let region = document.querySelector("body"); // whole screen
    let region = $(".right_col")//Capturamos el div deseado, al gusto del cliente

    html2canvas(region, {
        onrendered: function (canvas) {
            let pngUrl = canvas.toDataURL(); // png in dataURL format
            let img = document.querySelector(".screen");
            img.src = pngUrl;
            // here you can allow user to set bug-region
            // and send it with 'pngUrl' to server
            var photoBase64Captured = document.getElementById("base64image").src;

            $.post(
                '/Reportes/SaveImage',
                //"",
                {
                    base64image: photoBase64Captured,
                    imagenDashboardHead: nombreImgDashboardHead_,
                },
                response => {

                    //jQuery('#btn-generar-report-grafico-dashboard-pdf-SAF').show();
                    //jQuery('#btn-generar-report-resumen-dashboard-pdf-SAF').show();
                    jQuery('.esconder-botones').show(); 
                    //Eliminar imagen de la division
                    img.src = "";

                    //////////////////////////////////////////////////////////////// INICIO AJAX                   
                    /*RECIEN SE ENVIA AL CRYSTAL*/
                    listGraficoDashboard.push({
                        "strIdImagen": "strIdImage_nada"
                        , "strDescripcion": "strDescripcion_nada"
                        , "byteImagenData": "byteImagenData_nada"
                        , "strPathImagen": response 

                    });

                    $.ajax({
                        type: "POST",
                        url: "/Rep/Vista/RepVentanaPrincipal.aspx/ReportDashboardPrincipal",
                        data: JSON.stringify({ 'listGraficoDashboard': listGraficoDashboard }), 
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {

                            listGraficoDashboard.length = 0;
                            window.open('/Rep/Vista/RepVentanaPrincipal.aspx?filtroDeReporte=' + "ReporteGraficoDeDashboard" + '&zoomLevel=' + zoomLevelPantalla + adicional,'');
                            $('.right_col').removeClass("right_colclass");
                            $('body').removeClass("bodyClass");
                            $('.right_col').removeClass("right_colclass100");
                            $('body').removeClass("bodyClass100");
                            $('.right_col').removeClass("right_colclass90");
                            $('body').removeClass("bodyClass90");
                        },
                        failure: function () {

                            alert("Failure!");

                        }
                    });
                    //////////////////////////////////////////////////////////////// FIN AJAX

                });



        },
    });

});






 /**
  * *************************************************************************************

////series: series.map((item, index) => Object.assign(item, {
////    type: 'bar',
////    stack: true,
////    label: {
////        show: index === series.length - 1,
////        formatter: genFormatter(series),
////        fontSize: 20,
////        color: 'black',
////        position: 'top'
////    },
////})),
  

$('#btn-generar-report-grafico-dashboard-SAF11111111111').on('click', function () {

    var file = document.getElementById("base64image").src;
    var formdata = new FormData();
    formdata.append("base64image", file);
    //let pngUrl;

    ////let region = document.querySelector("body"); // whole screen
    ////html2canvas(region, {
    ////    onrendered: function (canvas) {
    ////        pngUrl = canvas.toDataURL(); // png in dataURL format
    ////        let img = document.querySelector(".screen");
    ////        img.src = pngUrl;

    // here you can allow user to set bug-region
    // and send it with 'pngUrl' to server
    listGraficoDashboard.push({

        "strIdImagen": "strIdImagen--"
        , "strDescripcion": "strDescripcion--"
        , "byteImagenData": JSON.stringify(file.toString())//"data:image/png;base64,i"
        , "strPathImagen": "D:\\Koala.jpg"

    });

    $.ajax({
        type: "POST",
        url: "/Rep/Vista/RepVentanaPrincipal.aspx/ReportDashboardPrincipal",
        data: JSON.stringify({ 'listGraficoDashboard': listGraficoDashboard }), // '{"id":"' + 123 + '"}',//change your code here
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {

            //alert('REPORTE_DASHBOARD_PRINCIPAL');
            window.open('/Rep/Vista/RepVentanaPrincipal.aspx?filtroDeReporte=' + "ReporteResumenDeDashboard" + adicional, '');

        },
        failure: function () {

            alert("Failure!");

        }
    });

    ////    },
    ////});

});


function reportPRUEBA1() {
   
        let region = document.querySelector("body"); // whole screen
        html2canvas(region, {
        onrendered: function (canvas) {
        let pngUrl = canvas.toDataURL(); // png in dataURL format
                let img = document.querySelector(".screen");
                img.src = pngUrl;

                // here you can allow user to set bug-region
                // and send it with 'pngUrl' to server


                $.ajax({
                    type: "POST",
                    url: "/Rep/Vista/RepVentanaPrincipal.aspx/SaveImage",
                    data: pngUrl.toString() , // '{"id":"' + 123 + '"}',//change your code here JSON.stringify({ pngUrl }), 
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function () {

                        //alert('REPORTE_DASHBOARD_PRINCIPAL');
                        //window.open('/Rep/Vista/RepVentanaPrincipal.aspx?strExcelExportado=' + "REPORTE_DASHBOARD_PRINCIPAL" + '');

                    },
                    failure: function () {

                        alert("Failure!");

                    }
                });


                //$.ajax({
                //    url: "/Rep/Vista/RepVentanaPrincipal.aspx/SaveImage",
                //    type: "POST",
                //    data: pngUrl,
                //    processData: false,
                //    contentType: false
                //});


            },
        });

        /////////////////////////////////////////////////////////
        //var file = document.getElementById("base64image").src;

        //var formdata = new FormData();
        //formdata.append("base64image", file);

        //$.ajax({
        //    url: "@Url.Action("SaveImage")",
        //    type: "POST",
        //    data: formdata,
        //    processData: false,
        //    contentType: false
        //});

}

 ************************************************************************************* */




/********************************************************************
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

*********************************************************************/






