





/*
------------------------------------------
    JavaScript INDEX
    ===================

    1. General functions
    2. Horario Functions
    3. Marcador Functions
    4. Centro de Costos Functions
    5. Planilla
    6. Grupo
    7. Tipo Personal
    8. Categoría
    9. Cargo
    10. Unidad Organizacional
    11. Jerarquía Organizacional
    12. Feriado
    13. Variable
    14. Empleado
    15. Cambio Documento de Identidad
    16. Perfil
    17. Periodo de Pago
    18. Grupo de Liquidación
    19. Pagina Principal
    20. Papeleta de Salida
    21. Campos Adicionales I
    22. Jornada diaria(Se remplazará código del SITE)
    23. Regla de Negocio
    24. Cálculo Manual
    25. Reportes
    26. Campos Adicionales II
    27. Empleado
    28. Mantenimiento Servicio ()
    29. Mantenimiento Regla de Negocio Comedor (de sisfd)

*/

const queryString = window.location.search;
const urlParams = new URLSearchParams(queryString);
const product = urlParams.get('intIdMenu')

const capitalize = (s) => {
    if (typeof s !== 'string') return ''
    return s.charAt(0).toUpperCase() + s.slice(1)
}

window.SISCOP.profile.forEach(e => {
    var item = e.menu.find(x => x.intIdMenu === parseInt(product))
    if (item) {
        $("#PadreMenu_txt").html(item.strNomMenu)
        $("#HijoMenu_txt").html(item.strSubMenu)
    }
})

//all ready functions
$(document).ready(function () {
    //if (typeof Date.prototype.GetHora !== 'function') { timeStamp.prototype.GetHora = function () { if (this === null) return ''; return ('00' + this. .getHours()).slice(-2) + ":" + ('00' + this.getMinutes()).slice(-2); } }
    //global functions
    init_sidebar();//INICIALIZAR LA BARRA DE MENUS LATERALES IZQUIERDO 123hgm
    navCurrentHistory();
    init_ProgresBar();
    init_InputMask();
    init_TagsInput();
    switcheryLoad();
    cargarDaterangePicker();
    init_daterangepicker();
    //añadido pruebas 10.03.2021 ES:
    init_daterangepicker_custom();
    init_checkBox_styles();
    init_datatables_net();
    init_SmartWizard();
    init_compose();
    init_charts();
    //calcu_one();
    calcu_two();
    calcu_third();
    calcu_one_reportes();
    //calcu_two_reportes();
    //calcu_third_reportes();
    //habilitar_check();
    DescargarUnidades();


    let arrayCheckedConsumos = [];
    let dataConsumoGlobal = null;
    let dataConsumoGlobal7 = null;
    let datahorariocheck3 = [];
    let dataCheckConsumos = [];
    let dataConsumosCheckBackup = [];
});






let arrayCheckedConsumos = [];
let dataCheckConsumos = [];

function GetCampJerar() {
    $.post(
        '/Organizacion/GetCampJerar',
        {},
        (response) => {
            response.forEach(element => {
                $('#campJerar').append(
                    ' <option value="' + element.IntIdJerOrg + '">' + element.strNomJerOrg + '</option>'
                );
            });
        }
    );
}

/* 1. General functions */
/*---------------------------------------------- */
/**
 * Resize function without multiple trigger
 *
 * Usage:
 * $(window).smartresize(function(){
 *     // code here
 * });
 */
(function ($, sr) {
    // debouncing function from John Hann
    // http://unscriptable.com/index.php/2009/03/20/debouncing-javascript-methods/
    var debounce = function (func, threshold, execAsap) {
        var timeout;

        return function debounced() {
            var obj = this, args = arguments;
            function delayed() {
                if (!execAsap)
                    func.apply(obj, args);
                timeout = null;
            }

            if (timeout)
                clearTimeout(timeout);
            else if (execAsap)
                func.apply(obj, args);

            timeout = setTimeout(delayed, threshold || 100);
        };
    };

    // smartresize
    jQuery.fn[sr] = function (fn) { return fn ? this.bind('resize', debounce(fn)) : this.trigger(sr); };

})(jQuery, 'smartresize');
/**
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

const APPCONFIG = {
    "loaderHtml": `<div class="container-loadin"><div class="loading-circle-app-div"><div class="loading-circle-app"></div></div></div>`,
    "config": {
        "dateFormat": "DD/MM/YYYY",
    }
}

//miercoles17.03.21
var CURRENT_URL = window.location.href.split('#')[0].split('?')[0],
    $BODY = $('body'),
    $MENU_TOGGLE = $('#menu_toggle'),
    $SIDEBAR_MENU = $('#sidebar-menu'),
    $SIDEBAR_FOOTER = $('.sidebar-footer'),
    $LEFT_COL = $('.left_col'),
    $RIGHT_COL = $('.right_col'),
    $NAV_MENU = $('.nav_menu'),
    $FOOTER = $('footer');


///////////////////////////////////////////////////////////////////////////////////////////01_HMG_05.07.21
var CURRENT_URL_MENU = window.location.href.split('#')[0].split('?')[1]; 
var id = $('.side-menu a[href*="' + CURRENT_URL_MENU + '"]').attr("id");
var ul_visible_or_not = false;
///////////////////////////////////////////////////////////////////////////////////////////

// Sidebar Barra de Menu Lateral Izquierdo
function init_sidebar() { 

    ///////////////////////////////////////////////////////////////////////////////////////////02_HMG_05.07.21
    //$('.side-menu a[href*="' + CURRENT_URL_MENU + '"]').css("background-color", "");//#1abb9c
    $('#' + id + 'LI').addClass('active');
    $('#' + id + 'UL').css("display", "block");
    ///////////////////////////////////////////////////////////////////////////////////////////

    // TODO: This is some kind of easy fix, maybe we can improve this
    var setContentHeight = function () {
        // reset height
        $RIGHT_COL.css('min-height', $(window).height());

        var bodyHeight    = $BODY.outerHeight(),
            footerHeight  = $BODY.hasClass('footer_fixed') ? -10 : $FOOTER.height(),
            leftColHeight = $LEFT_COL.eq(1).height() + $SIDEBAR_FOOTER.height(),
            contentHeight = bodyHeight < leftColHeight ? leftColHeight : bodyHeight;

        // normalize content
        contentHeight -= $NAV_MENU.height() + footerHeight;

        $RIGHT_COL.css('min-height', contentHeight);
    };


    //1.- MENUS DESPLEGABLES
    $SIDEBAR_MENU.find('a').on('click', function (ev) {
        console.log('clicked - sidebar_menu');
        //alert('clicked - sidebar_menu');

        ///////////////////////////////////////////////////////////////////////////////////////////03_HGM_05.07.21
        if ($('#' + id + 'UL').is(':visible') == true) {
            ul_visible_or_not = true;
            //alert(ul_visible_or_not);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////

        var $li = $(this).parent();

        if ($li.is('.active')) {

            $li.removeClass('active active-sm');
            $('ul:first', $li).slideUp(function () {
                setContentHeight();
            });

        }
        else {
            // prevent closing menu if we are on child menu
            if (!$li.parent().is('.child_menu')) {

                if (ul_visible_or_not == false) {

                    $SIDEBAR_MENU.find('li').removeClass('active active-sm');
                    $SIDEBAR_MENU.find('li ul').slideUp();//----> Esconde menu con transision
                }

            } else {
                if ($BODY.is(".nav-sm")) {
                    $li.parent().find("li").removeClass("active active-sm");
                    $li.parent().find("li ul").slideUp();
                }
            }
            
            $li.addClass('active');
            $('ul:first', $li).slideDown(function () { //----> Muestra menu con transision
                    setContentHeight();
            });

            
        }
    });


    //2.- SUBMENUS(de cada mantenimiento contenidos en los MENUS DESPLEGABLES )
    // toggle small or large menu //miercoles17.03.21
    $MENU_TOGGLE.on('click', function () {
        console.log('clicked - menu toggle');

        if ($BODY.hasClass('nav-md')) {
            $(".site_title img").attr("src", "/images/logo_short.jpg");
            $(".site_title").addClass("p-0")
            $SIDEBAR_MENU.find('li.active ul').hide();
            $SIDEBAR_MENU.find('li.active').addClass('active-sm').removeClass('active');
        } else {
            //COMENTADO LAS CUATRO LINEAS PARA ESCONDER EL MENU PEQUEÑO - ESCONDIDO PARA MINIASOFT
            $(".site_title img").attr("src", "/images/logo_layout.png");
            $(".site_title").removeClass("p-0")
            $SIDEBAR_MENU.find('li.active-sm ul').show();
            $SIDEBAR_MENU.find('li.active-sm').addClass('active').removeClass('active-sm');
        }

        //$BODY.toggleClass('nav-md nav-sm'); //COMENTADO PARA ESCONDIDO PARA MINIASOFT
        //$BODY.toggleClass('nav-sm-esconder nav-sm-mostrar');

        setContentHeight();

        $('.dataTable').each(function () { $(this).dataTable().fnDraw(); });
    });

    // check active menu
    $SIDEBAR_MENU.find('a[href="' + CURRENT_URL + '"]').parent('li').addClass('current-page');

    $SIDEBAR_MENU.find('a').filter(function () {
        return this.href == CURRENT_URL;
    }).parent('li').addClass('current-page').parents('ul').slideDown(function () {
        setContentHeight();
    }).parent().addClass('active');

    // recompute content when resizing
    $(window).smartresize(function () {
        setContentHeight();
    });

    setContentHeight();

    //fixed sidebar
    if ($.fn.mCustomScrollbar) {
        $('.menu_fixed').mCustomScrollbar({
            autoHideScrollbar: true,
            theme: 'minimal',
            mouseWheel: { preventDefault: true }
        });
    }


};
//Fin Sidebar




//MINIASOFT TOGGLE MENU
$(function () {
    $('#iconomenu').on('click', function () {
        //alert();
        $('#sidebar-menu').toggle();
    });
});



// Progressbar
function init_ProgresBar() {
    if ($(".progress .progress-bar")[0]) {
        $('.progress .progress-bar').progressbar();
    }
}
// /Progressbar

/* SMART WIZARD */

function init_SmartWizard() {

    if (typeof ($.fn.smartWizard) === 'undefined') { return; }

    $('#wizard').smartWizard({
        selected: 0,
        //labelNext: 'Siguiente',
        //labelPrevious: 'Anterior',
        //labelFinish: 'Último',
        enableFinishButton: true,
        enableAllSteps: true
    });

    $('#wizard_verticle').smartWizard({
        transitionEffect: 'slide'
    });

    $('.buttonNext').hide();//.addClass('btn btn-success');
    $('.buttonPrevious').hide();//.addClass('btn btn-primary');
    $('.buttonFinish').hide();//.addClass('btn btn-default');

};

/* INPUT MASK */

function init_InputMask() {
    if (typeof ($.fn.inputmask) === 'undefined') { return; }
    $(":input").inputmask();
};

//Preview Image
function ShowPreview(input) {
    if (input.files && input.files[0]) {
        var ImageDir = new FileReader();
        ImageDir.onload = function (e) {
            $('#impPrev').attr('src', e.target.result);
        }
        ImageDir.readAsDataURL(input.files[0]);
    }
}


//tags input
function init_TagsInput() {

    if (typeof $.fn.tagsInput !== 'undefined') {

        $('#tags_1').tagsInput({
            width: 'auto'
        });
        $('#tags_2').tagsInput({
            width: 'auto'
        });



    }

};


//Navegation History current
function navCurrentHistory() {
    //count elements child of class breadcrumb
    var cantChild = $('.breadcrumb > a').length;
    cantChild = (cantChild - 1) * 10;  //(cantidad de elementos -1 ) * el tamaño de cada item de la clase .breadcrumb__step =>Default value=10%;
    cantChild = 100 - cantChild;    //100% (total del espacio) - tamño de items.
    /* console.log(cantChild); */
    //$('.breadcrumb a:last-child').css('width', cantChild + '%');
}

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
            var switchery = new Switchery(html, {
                color: '#26B99A'
            });
        });
    }

}

//Datatables.net formating
function init_datatables_net() {
    $('.datatables-net-format').dataTable({
        lengthMenu: [10, 25, 50],
        responsive: true,
        language: {
            lengthMenu: 'Mostrar _MENU_ Items',
            info: 'Mostrar _START_ a _END_ de _TOTAL_ Items',
            infoEmpty: 'No hay Items para mostrar',
            search: 'Buscar: ',
            sSearchPlaceholder: 'Criterio de búsqueda',
            zeroRecords: 'No se encontraron registros coincidentes',
            infoFiltered: '(Filtrado de _MAX_ totales Items)',
            paginate: {
                previous: 'Anterior',
                next: 'Siguiente'
            }
        }
    });
}

////////////
////////////
function init_datatables_net_nuevo() {
    $('.datatables-net-format').dataTable({
        lengthMenu: [10, 25, 50],
        responsive: true,
        language: {
            lengthMenu: 'Mostrar _MENU_ Items',
            info: 'Mostrar _START_ a _END_ de _TOTAL_ Items',
            infoEmpty: 'No hay Items para mostrar',
            search: 'Buscar: ',
            sSearchPlaceholder: 'Criterio de búsqueda',
            zeroRecords: 'No se encontraron registros coincidentes',
            infoFiltered: '(Filtrado de _MAX_ totales Items)',
            paginate: {
                previous: 'Anterior',
                next: 'Siguiente'
            }
        }
    });
}


function init_daterangepicker_custom(idDatepicker = 'rangedatepickergeneral', rangeDateInicial = { startDate: moment(), endDate: moment() }, dateFormato = 'DD/MM/YYYY', ) {

    var dateCurrent = moment().format(dateFormato);

    if (typeof ($.fn.daterangepicker) === 'undefined') { return; }

    var cb = function (start, end, label) {
        console.log(start.toISOString(), end.toISOString(), label);
        $(`#${idDatepicker} span`).html(start.format(dateFormato) + ' - ' + end.format(dateFormato));
    };

    var optionSet1 = {
        startDate: rangeDateInicial.startDate,
        endDate: rangeDateInicial.endDate,
        minDate: '01/01/2000',
        maxDate: '12/31/2030',
        dateLimit: {
            months: 12 * 15
        },
        linkedCalendars: false,
        showDropdowns: true,
        showWeekNumbers: false,
        timePicker: false,
        timePickerIncrement: 1,
        timePicker12Hour: true,
        ranges: {
            'Hoy': [moment(), moment()],
            'Ayer': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
            'Últimos 7 días': [moment().subtract(6, 'days'), moment()],
            'últimos 30 días': [moment().subtract(29, 'days'), moment()],
            'Este Mes': [moment().startOf('month'), moment().endOf('month')],
            'último Mes': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')],
            'último Año': [moment().subtract(0, 'year').startOf('year'), moment().subtract(0, 'year').endOf('year')]
        },
        opens: 'left',
        buttonClasses: ['btn btn-default'],
        applyClass: 'btn-small btn-primary',
        cancelClass: 'btn-small',
        format: dateFormato,
        separator: ' to ',
        locale: {
            applyLabel: 'Consultar',
            cancelLabel: 'Cancelar',
            fromLabel: 'From',
            toLabel: 'To',
            customRangeLabel: 'Elegir Rango',
            daysOfWeek: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            firstDay: 1,
            format: dateFormato
        }
    };


    $(`#${idDatepicker} span`).html(rangeDateInicial.startDate.format(dateFormato) + ' - ' + rangeDateInicial.endDate.format(dateFormato));

    $(`#${idDatepicker}`).daterangepicker(optionSet1, cb);
    $(`#${idDatepicker}`).on('show.daterangepicker', function () {
        //console.log("show event fired");
    });
    $(`#${idDatepicker}`).on('hide.daterangepicker', function () {
        //console.log("hide event fired");
    });
    $(`#${idDatepicker}`).on('apply.daterangepicker', function (ev, picker) {
        // console.log("Fechas Aplicadas: " + picker.startDate.format(dateFormato) + " to " + picker.endDate.format(dateFormato));

    });
    $(`#${idDatepicker}`).on('cancel.daterangepicker', function (ev, picker) {
        //console.log("cancel event fired");
    });
    $('#options1').click(function () {
        $(`#${idDatepicker}`).data('daterangepicker').setOptions(optionSet1, cb);
    });
    $('#options2').click(function () {
        $(`#${idDatepicker}`).data('daterangepicker').setOptions(optionSet2, cb);
    });
    $('#destroy').click(function () {
        $(`#${idDatepicker}`).data('daterangepicker').remove();
    });

}


function init_daterangepicker() {

    
    //startDate.
    var dateCurrent = moment().format('DD/MM/YYYY').substr(-4, 4);
    fechaInicio = '01/01/' + dateCurrent; // moment().subtract(0, "day").format("DD/MM/YYYY");
    fechaFin = '31/12/' + dateCurrent; // moment().subtract(0, "day").format("DD/MM/YYYY"); 

    if (typeof ($.fn.daterangepicker) === 'undefined') { return; }

    var cb = function (start, end, label) {
        console.log(start.toISOString(), end.toISOString(), label);
        $('.range-datepicker span').html(start.format('DD/MM/YYYY') + ' - ' + end.format('DD/MM/YYYY'));
    };

    var optionSet1 = {
        //startDate: moment(),
        //endDate: moment(),
        startDate: fechaInicio,
        endDate: fechaFin,
        minDate: '01/01/2010',
        maxDate: '12/31/2030',
        dateLimit: {
            months: 12
        },
        linkedCalendars: false,
        showDropdowns: true,
        showWeekNumbers: false,
        timePicker: false,
        timePickerIncrement: 1,
        timePicker12Hour: true,
        ranges: {
            'Hoy': [moment(), moment()],// ], HGM 08.03.21 FECHAS DATAPICKER moment().format("DD/MM/YYYY"), moment().format("DD/MM/YYYY")
            //moment().startOf('day').format("DD/MM/YYYY"), moment().add(0, "day").endOf('day').format("DD/MM/YYYY")
            'Ayer': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
            'Últimos 7 días': [moment().subtract(6, 'days'), moment()],
            'últimos 30 días': [moment().subtract(29, 'days'), moment()],
            'Este Mes': [moment().startOf('month'), moment().endOf('month')],
            'último Mes': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')],
            'último Año': [moment().subtract(0, 'year').startOf('year'), moment().subtract(0, 'year').endOf('year')]
        },
        opens: 'left',
        buttonClasses: ['btn btn-default'],
        applyClass: 'btn-small btn-primary',
        cancelClass: 'btn-small',
        format: 'DD/MM/YYYY',
        separator: ' to ',
        language: 'es',
        locale: {
            applyLabel: 'Consultar',
            cancelLabel: 'Cancelar',
            fromLabel: 'From',
            toLabel: 'To',
            customRangeLabel: 'Elegir Rango',
            daysOfWeek: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            firstDay: 1,
            format: 'DD/MM/YYYY'
        }
    };

    $('.range-datepicker span').html(fechaInicio + ' - ' + fechaFin);

    $('.range-datepicker').daterangepicker(optionSet1, cb);
    $('.range-datepicker').on('showCalendar.daterangepicker', function () {
        //$(".calendar.left").find("td.available:contains('10')").click()
        //$(".calendar.left").hide()
        console.log("show event fired TEST");
    });
    $('.range-datepicker').on('hide.daterangepicker', function () {
        console.log("hide event fired");
    });
    $('.range-datepicker').on('apply.daterangepicker', function (ev, picker) {
        console.log("Fechas Aplicadas: " + picker.startDate.format('DD/MM/YYYY') + " to " + picker.endDate.format('DD/MM/YYYY'));

    });
    $('.range-datepicker').on('cancel.daterangepicker', function (ev, picker) {
        console.log("cancel event fired");
    });
    $('#options1').click(function () {
        $('.range-datepicker').data('daterangepicker').setOptions(optionSet1, cb);
    });
    $('#options2').click(function () {
        $('.range-datepicker').data('daterangepicker').setOptions(optionSet2, cb);
    });
    $('#destroy').click(function () {
        $('.range-datepicker').data('daterangepicker').remove();
    });

}

//datatable settings
var _datatableLanguaje = {
    lengthMenu: 'Mostrar _MENU_ Items',
    info: 'Mostrar _START_ a _END_ de _TOTAL_ Items',
    infoEmpty: 'No hay Items para mostrar',
    search: 'Buscar: ',
    sSearchPlaceholder: 'Criterio de búsqueda',
    zeroRecords: 'No se encontraron registros coincidentes',
    infoFiltered: '(Filtrado de _MAX_  Items en total)',
    paginate: {
        previous: 'Anterior',
        next: 'Siguiente'
    }
};

//Theme Charts
var theme = {
    color: [
        '#26B99A', '#34495E', '#BDC3C7', '#3498DB',
        '#9B59B6', '#8abb6f', '#759c6a', '#bfd3b7'
    ],

    title: {
        itemGap: 8,
        textStyle: {
            fontWeight: 'normal',
            color: '#408829'
        }
    },

    dataRange: {
        color: ['#1f610a', '#97b58d']
    },

    toolbox: {
        color: ['#408829', '#408829', '#408829', '#408829']
    },

    tooltip: {
        backgroundColor: 'rgba(0,0,0,0.5)',
        axisPointer: {
            type: 'line',
            lineStyle: {
                color: '#408829',
                type: 'dashed'
            },
            crossStyle: {
                color: '#408829'
            },
            shadowStyle: {
                color: 'rgba(200,200,200,0.3)'
            }
        }
    },

    dataZoom: {
        dataBackgroundColor: '#eee',
        fillerColor: 'rgba(64,136,41,0.2)',
        handleColor: '#408829'
    },
    grid: {
        borderWidth: 0
    },

    categoryAxis: {
        axisLine: {
            lineStyle: {
                color: '#408829'
            }
        },
        splitLine: {
            lineStyle: {
                color: ['#eee']
            }
        }
    },

    valueAxis: {
        axisLine: {
            lineStyle: {
                color: '#408829'
            }
        },
        splitArea: {
            show: true,
            areaStyle: {
                color: ['rgba(250,250,250,0.1)', 'rgba(200,200,200,0.1)']
            }
        },
        splitLine: {
            lineStyle: {
                color: ['#eee']
            }
        }
    },
    timeline: {
        lineStyle: {
            color: '#408829'
        },
        controlStyle: {
            normal: { color: '#408829' },
            emphasis: { color: '#408829' }
        }
    },

    k: {
        itemStyle: {
            normal: {
                color: '#68a54a',
                color0: '#a9cba2',
                lineStyle: {
                    width: 1,
                    color: '#408829',
                    color0: '#86b379'
                }
            }
        }
    },
    map: {
        itemStyle: {
            normal: {
                areaStyle: {
                    color: '#ddd'
                },
                label: {
                    textStyle: {
                        color: '#c12e34'
                    }
                }
            },
            emphasis: {
                areaStyle: {
                    color: '#99d2dd'
                },
                label: {
                    textStyle: {
                        color: '#c12e34'
                    }
                }
            }
        }
    },
    force: {
        itemStyle: {
            normal: {
                linkStyle: {
                    strokeColor: '#408829'
                }
            }
        }
    },
    chord: {
        padding: 4,
        itemStyle: {
            normal: {
                lineStyle: {
                    width: 1,
                    color: 'rgba(128, 128, 128, 0.5)'
                },
                chordStyle: {
                    lineStyle: {
                        width: 1,
                        color: 'rgba(128, 128, 128, 0.5)'
                    }
                }
            },
            emphasis: {
                lineStyle: {
                    width: 1,
                    color: 'rgba(128, 128, 128, 0.5)'
                },
                chordStyle: {
                    lineStyle: {
                        width: 1,
                        color: 'rgba(128, 128, 128, 0.5)'
                    }
                }
            }
        }
    },
    gauge: {
        startAngle: 225,
        endAngle: -45,
        axisLine: {
            show: true,
            lineStyle: {
                color: [[0.2, '#86b379'], [0.8, '#68a54a'], [1, '#408829']],
                width: 8
            }
        },
        axisTick: {
            splitNumber: 10,
            length: 12,
            lineStyle: {
                color: 'auto'
            }
        },
        axisLabel: {
            textStyle: {
                color: 'auto'
            }
        },
        splitLine: {
            length: 18,
            lineStyle: {
                color: 'auto'
            }
        },
        pointer: {
            length: '90%',
            color: 'auto'
        },
        title: {
            textStyle: {
                color: '#333'
            }
        },
        detail: {
            textStyle: {
                color: 'auto'
            }
        }
    },
    textStyle: {
        fontFamily: 'Arial, Verdana, sans-serif'
    }
};

/*---------------------------------------------- */
/**2. Horario Functions */
/**------------------------------------------------ */



function init_calendar() {

    if (typeof ($.fn.fullCalendar) === 'undefined') { return; }
    console.log('init_calendar');

    var date = new Date(),
        d = date.getDate(),
        m = date.getMonth(),
        y = date.getFullYear(),
        started,
        categoryClass;

    var calendar = $('#calendar').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay,listMonth'
        },
        selectable: true,
        selectHelper: true,
        select: function (start, end, allDay) {
            $('#fc_create').click();

            started = start;
            ended = end;

            $(".antosubmit").on("click", function () {
                var title = $("#title").val();
                if (end) {
                    ended = end;
                }

                categoryClass = $("#event_type").val();

                if (title) {
                    calendar.fullCalendar('renderEvent', {
                        title: title,
                        start: started,
                        end: end,
                        allDay: allDay
                    },
                        true // make the event "stick"
                    );
                }

                $('#title').val('');

                calendar.fullCalendar('unselect');

                $('.antoclose').click();

                return false;
            });
        },
        eventClick: function (calEvent, jsEvent, view) {
            $('#fc_edit').click();
            $('#title2').val(calEvent.title);

            categoryClass = $("#event_type").val();

            $(".antosubmit2").on("click", function () {
                calEvent.title = $("#title2").val();

                calendar.fullCalendar('updateEvent', calEvent);
                $('.antoclose2').click();
            });

            calendar.fullCalendar('unselect');
        },
        editable: true,

    });

};



/**------------------------------------------------ */
/**4. Centro de Costos Functions */
/**------------------------------------------------ */


/**------------------------------------------ */
/**--------------5. Planilla----------------- */
/**------------------------------------------ */



/**------------------------------------------------------ */
/**6. Grupo */
/**----------------------------------------------- */



/**---------------------------------------------- */
/**7. Tipo Personal */
/**------------------------------------------------------ */
$('#filActiTipoPer').on('change', function () {
    validarSession()
    TablaTipoPersonal();
});

$('#cboDepenTipoPer').on('change', function () {
    validarSession()
    TablaTipoPersonal();
});

$('#filtroTipoPer').keyup(function () {
    validarSession()
    TablaTipoPersonal();
});

$('#btn-new-tipoPerso').on('click', function () {
    validarSession()
    $('.form-hide-tipoPerso').show();
    $('#btn-update-tipoPerso').hide();
    $('#btn-save-change-tipoPerso').show();
    $.post(
        '/Organizacion/NuevoTipoPersonal',
        {},
        (response) => {
            if (response !== '') {
                $('.form-hide-tipoPerso .x_content').empty();
                $('.form-hide-tipoPerso .x_content').html(response);
                $('.form-hide-tipoPerso').show();
                BuscarUnidades();
                switcheryLoad();//checked verde

                //MaxCaracteres
                var txtCod = 'strCoTiPers';
                var txtdes = 'strDesTiPers';

                $.post(
                    '/Organizacion/ListarCaracteresMax',
                    { strMaestro: 'TGTIPOPERSON' },
                    (response) => {
                        response.forEach(element => {

                            if (element.strColumnName == txtCod) {

                                $('#ValCode').children("input").attr('maxlength', element.intMaxLength);
                            } if (element.strColumnName == txtdes) {
                                $('#Valdes').children("input").attr('maxlength', element.intMaxLength);

                            }
                        });
                    });


            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
});

var _varTablaTipoPersonal;

function TablaTipoPersonal() {
    var filtrosActivo = $('#filActiTipoPer').val();
    var filtrojer = $('#cboDepenTipoPer').val();
    var strfiltro = $('#filtroTipoPer').val();

    $.ajax({
        url: '/Organizacion/getTablaFiltradaTipoPerson',
        type: 'POST',
        data: {
            IntActivoFilter: filtrosActivo, strfilter: strfiltro, intfiltrojer: filtrojer
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

            if (typeof _varTablaTipoPersonal !== 'undefined') {
                _varTablaTipoPersonal.destroy();
            }
            _varTablaTipoPersonal = $('#tablaTipoPersonal').DataTable({
                data: response,
                columns: [

                    { data: 'strCoTiPers' },
                    { data: 'strDesTiPers' },
                    { data: 'strNomJerOrg' },
                    { data: 'strDescripcion' },
                    { data: 'FlActivo.strEstadoActivo' },
                    { data: null },
                    { data: 'IntIdTiPers' },
                    { data: 'bitFlActivo' },
                    { data: 'strTiPersCampo1' },
                    { data: 'strTiPersCampo2' },
                    { data: 'strTiPersCampo3' },
                    { data: 'strTiPersCampo4' },
                    { data: 'strTiPersCampo5' },
                    { data: 'IntIdUniOrg' },
                ],
                lengthMenu: [10, 25, 50],
                responsive: true,
                order: [],
                language: _datatableLanguaje,
                columnDefs: [//ocultar y definir columnas
                    {
                        targets: [6],//intIdCargo
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [7],//bitFlActivo
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [8],//strCargoCampo1
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [9],//strCargoCampo2
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [10],//strCargoCampo3
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [11],//strCargoCampo4
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [12],//strCargoCampo5
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [13],//intIdUniOrg
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [5],
                        data: null,
                        defaultContent: '<button class="btn btn-success btn-xs btn-edit" ><i class="fa fa-pencil"></i> Editar </button>' +
                            '<button class="btn btn-primary btn-xs btn-delete"><i class="fa fa-trash-o"></i> Eliminar </button>'
                    }
                ],
                dom: 'lBfrtip',
            });


            $('#tablaTipoPersonal tbody').on('click', 'tr button.btn-edit', function () {
                validarSession()
                var data = _varTablaTipoPersonal.row($(this).parents('tr')).data();
                if (data == null) {
                    data = null;
                    var data = _varTablaTipoPersonal.row($(this).parents('li')).data();
                    cardarDatosTipoper(data);
                } else {
                    var data = _varTablaTipoPersonal.row($(this).parents('tr')).data();
                    cardarDatosTipoper(data);
                }
            });

            $('#tablaTipoPersonal tbody').on('click', 'tr button.btn-delete', function () {
                validarSession()
                var data = _varTablaTipoPersonal.row($(this).parents('tr')).data();

                if (data == null) {
                    data = null;

                    var data = _varTablaTipoPersonal.row($(this).parents('li')).data();
                    intentEliminarTipoPersonal(data['IntIdTiPers'], data['strDesTiPers']);

                } else {

                    var data = _varTablaTipoPersonal.row($(this).parents('tr')).data();
                    intentEliminarTipoPersonal(data['IntIdTiPers'], data['strDesTiPers']);

                }


            });

        },
        complete: function () {
            $.unblockUI();
        }
    });
}

function intentEliminarTipoPersonal(idTipoPerson, strNomPerson) {

    swal({
        title: "Eliminar Tipo de Personal",
        text: "¿Está seguro de eliminar el Tipo de Personal   ''<strong>" + strNomPerson + "</strong>''   ?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sí, eliminar",
        cancelButtonText: "No, cancelar",
    }).then(function (isConfirm) {
        validarSession()
        if (isConfirm) {
            yesEliminaTipoPerson(idTipoPerson);
        } else {
            swal("Cancelado", "La Operación fue cancelada", "error");
        }
    });
}

function yesEliminaTipoPerson(idTipoPerson) {

    $.post(
        '/Organizacion/EliminarTipoPerson',
        { intIdTipo: idTipoPerson },
        (response) => {
            console.log(response);
            if (response.type !== '') {
                var tipo = 'Eliminado!';
                if (response.type === 'error')
                    tipo = 'NO SE PUEDE ELIMINAR EL REGISTRO';
                swal(tipo, response.message, response.type);

                if (response.type === 'success')
                    TablaTipoPersonal('', '', '');
            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
}

function cardarDatosTipoper(data) {

    $('#btn-update-tipoPerso').show();
    $('#btn-save-change-tipoPerso').hide();

    var objDatosTipoPer = {
        IntIdTiPers: data['IntIdTiPers'],
        strCoTiPers: data['strCoTiPers'],
        strDesTiPers: data['strDesTiPers'],
        strNomJerOrg: data['strNomJerOrg'],
        strDescripcion: data['strDescripcion'],
        intIdUniOrg: data['IntIdUniOrg'],

        strEstadoActivo: data['FlActivo']['strEstadoActivo'],
        bitFlActivo: data['FlActivo']['bitFlActivo'],

        strTiPersCampo1: data['strTiPersCampo1'],
        strTiPersCampo2: data['strTiPersCampo2'],
        strTiPersCampo3: data['strTiPersCampo3'],
        strTiPersCampo4: data['strTiPersCampo4'],
        strTiPersCampo5: data['strTiPersCampo5']


    }


    ////////$.post(
    ////////    '/Organizacion/EditarTipoPerso',
    ////////    { ObjTipoper: objDatosTipoPer },
    ////////    (response) => {
    ////////        if (response !== '') {
    ////////            $('.form-hide-tipoPerso .x_content').empty();
    ////////            $('.form-hide-tipoPerso .x_content').html(response);
    ////////            $('.form-hide-tipoPerso').show();
    ////////            switcheryLoad();
    ////////            init_checkBox_styles();
    ////////            //  onchange_jerarquia();
    ////////            $('#txt-cod-TiPers').val(objDatosTipoPer.strCoTiPers);
    ////////            $('#txt-desc-TiPers').val(objDatosTipoPer.strDesTiPers);
    ////////            $('#txtIdTipPers').val(objDatosTipoPer.IntIdTiPers);


    ////////            //if (objDatosCargo.strEstadoActivo == 'Activo') {
    ////////            //    $('#chk-activo-Cargo ').prop('checked', true);
    ////////            //    alert($('#chk-activo-Cargo').is(':checked'));
    ////////            //    blnActivo = true;

    ////////            //} else {

    ////////            //    $('#chk-activo-Cargo ').prop('unchecked', true);
    ////////            //    alert($('#chk-activo-Cargo').is(':checked'));
    ////////            //    blnActivo = false;
    ////////            //}


    ////////            if (objDatosTipoPer.strEstadoActivo == 'Activo') {
    ////////                $('#11').html('<label>Activo</label> <input type = "checkbox" id = "chk-activo-TiPers" class= "js-switch" checked /><script>switcheryLoad();</script >');

    ////////            } else {
    ////////                $('#11').html('<label>Activo</label> <input type = "checkbox" id = "chk-activo-TiPers" class= "js-switch" unchecked /><script>switcheryLoad();</script >');

    ////////            }

    ////////            ////Bloque de Campos Adicionales

    ////////            $.post(
    ////////                '/Organizacion/CamposAdicionales',
    ////////                { strEntidad: 'TGTIPOPERSON' },
    ////////                (response) => {

    ////////                    console.log(response);
    ////////                    $('#containerCamposea').empty();
    ////////                    response.forEach(element => {
    ////////                        //alert(element.strTitulo);

    ////////                        $('#containerCamposea').append(
    ////////                            ' <div class="col-md-6 col-sm-6 col-xs-6"><div class="form-group"><label> ' + element.strTitulo
    ////////                            + '</label><input id="' + element.strNomCampo + '" type="text" class="form-control " placeholder="Campo Adicional" maxlength="255"/>' + '</div></div>');


    ////////                    });

    ////////                    $('#strTiPersCampo1').val(objDatosTipoPer.strTiPersCampo1);
    ////////                    $('#strTiPersCampo2').val(objDatosTipoPer.strTiPersCampo2);
    ////////                    $('#strTiPersCampo3').val(objDatosTipoPer.strTiPersCampo3);
    ////////                    $('#strTiPersCampo4').val(objDatosTipoPer.strTiPersCampo4);
    ////////                    $('#strTiPersCampo5').val(objDatosTipoPer.strTiPersCampo5);
    ////////                });


    ////////            //Bloque de llenados de CBO

    ////////            $("#cboJerarquia option").filter(function () {
    ////////                return this.text == objDatosTipoPer.strNomJerOrg;
    ////////            }).attr('selected', true);

    ////////            var id = $('#cboJerarquia option:selected').val();
    ////////            if (id == 0 || !id) {
    ////////                $('#cbounidsupe').empty();
    ////////                $('#cbounidsupe').attr('disabled', true);

    ////////                return;
    ////////            }
    ////////            $.post(
    ////////                '/Organizacion/getUnidxJerarquia',
    ////////                { IntIdJerOrg: id },
    ////////                (response) => {

    ////////                    if (true) {

    ////////                        response.forEach(element => {

    ////////                            $('#cbounidsupe').attr('disabled', false);
    ////////                            $('#cbounidsupe').append('<option value="' + element.intIdUniOrg + '" >' + element.strDescripcion + '</option>');
    ////////                            if (element.intIdUniOrg == objDatosTipoPer.intIdUniOrg) {
    ////////                                $("#cbounidsupe option").filter(function () {
    ////////                                    return this.text == objDatosTipoPer.strDescripcion;
    ////////                                }).attr('selected', true);
    ////////                            }


    ////////                        });

    ////////                    }
    ////////                }
    ////////            ).fail(function (result) {
    ////////                alert('ERROR ' + result.status + ' ' + result.statusText);
    ////////            });
    ////////            $('#cbounidsupe').empty();


    ////////            var txtcod = 'strCoTiPers';
    ////////            var txtdes = 'strDesTiPers';

    ////////            $.post(
    ////////                '/Organizacion/ListarCaracteresMax',
    ////////                { strMaestro: 'TGTIPOPERSON' },
    ////////                (response) => {
    ////////                    response.forEach(element => {
    ////////                        if (element.strColumnName == txtcod) {
    ////////                            $('.Valcod').children("input").attr('maxlength', element.intMaxLength);
    ////////                        }
    ////////                        if (element.strColumnName == txtdes) {
    ////////                            $('.Valdes').children("input").attr('maxlength', element.intMaxLength);
    ////////                        }
    ////////                    });
    ////////                });


    ////////        }
    ////////    }
    ////////).fail(function (result) {
    ////////    alert('ERROR ' + result.status + ' ' + result.statusText);
    ////////});
}

function CamposAdicionalesTipoPersonal() {

    $.post(
        '/Organizacion/CamposAdicionales',
        { strEntidad: 'TGTIPOPERSON' },
        (response) => {

            console.log(response);
            $('#containerCamposea').empty();
            response.forEach(element => {
                //alert(element.strTitulo);

                $('#containerCamposea').append(
                    ' <div class="col-md-6 col-sm-6 col-xs-6"><div class="form-group"><label> ' + element.strTitulo
                    + '</label><input id="' + element.strNomCampo + '" type="text" class="form-control " placeholder="Campo Adicional" maxlength="255"/>' + '</div></div>');


            });
        });
}

$('#btn-save-change-tipoPerso').on('click', function () {
    validarSession()
    //Datos del Tipo de Personal

    var _uorg = $('#cbounidsupe option:selected').val();   //selected
    var _codigo = $('#txt-cod-TiPers').val();
    var _desc = $('#txt-desc-TiPers').val();
    var _activo = $('#chk-activo-TiPers').is(':checked');
    var _camp1 = $('#strTiPersCampo1').val();
    var _camp2 = $('#strTiPersCampo2').val();
    var _camp3 = $('#strTiPersCampo3').val();
    var _camp4 = $('#strTiPersCampo4').val();
    var _camp5 = $('#strTiPersCampo5').val();

    if (_codigo === '' || _desc === '' || _uorg === '') {
        new PNotify({
            title: 'Nuevo Tipo de Personal',
            text: 'Complete los campos obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        $('#notifry_error').html('');
        $('#notifry_errordes').html('');
        return;
    }

    if (!$('#txt-cod-TiPers')[0].validity.valid) {
        new PNotify({
            title: 'Codigo(*)',
            text: 'Ingrese solo números y letras sin espacios en blanco.',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }


    if (_uorg === '') {
        _uorg = null;
    }

    var tipoPerson = {

        strCoTiPers: _codigo,
        strDesTiPers: _desc,
        intIdUniOrg: _uorg,
        strTiPersCampo1: _camp1,
        strTiPersCampo2: _camp2,
        strTiPersCampo3: _camp3,
        strTiPersCampo4: _camp4,
        strTiPersCampo5: _camp5,
        bitFlActivo: _activo,

    }
    $.post(
        '/Organizacion/RegistrarNuevoTipoPerson',
        { tipoPerson: tipoPerson },
        (response) => {
            console.log(response);
            if (response.type !== '') {

                if (response.type === 'success') {
                    new PNotify({
                        title: 'Nuevo Tipo de Personal',
                        text: response.message,
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'
                    });
                    TablaTipoPersonal();
                    $('.form-hide-tipoPerso').hide();
                    return;
                }
                else {
                    var list = response.message.split("|")
                    if (list.length == 2) {
                        var nomMantemiento = 'Tipo Personal';
                        var campo = list[1];
                        var msj = list[0];
                        var response = 'info';
                        var deta = 'notifry_error';
                        INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                    } else {
                        new PNotify({
                            title: 'Tipo Personal',
                            text: response.message,
                            type: response.type,
                            delay: 3000,
                            styling: 'bootstrap3'
                        });
                    }
                    return;
                }
            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });

});
$('#btn-cancel-tipoPerso').on('click', function () {
    validarSession()
    $('.form-hide-tipoPerso').hide();
});
$('#btn-update-tipoPerso').on('click', function () {
    validarSession()
    //Datos de la categoria


    var _uorg = $('#cbounidsupe option:selected').val();   //selected
    var _codigo = $('#txt-cod-TiPers').val();
    var _desc = $('#txt-desc-TiPers').val();
    var _activo = $('#chk-activo-TiPers').is(':checked');
    var _camp1 = $('#strTiPersCampo1').val();
    var _camp2 = $('#strTiPersCampo2').val();
    var _camp3 = $('#strTiPersCampo3').val();
    var _camp4 = $('#strTiPersCampo4').val();
    var _camp5 = $('#strTiPersCampo5').val();
    var _idcate = $('#txtIdTipPers').val();

    if (_codigo === '' || _desc === '' || _uorg === '') {
        new PNotify({
            title: 'Actualizacion de Tipo de Personal',
            text: 'Complete los campos obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        $('#notifry_error').html('');
        $('#notifry_errordes').html('');
        return;
    }

    if (!$('#txt-cod-TiPers')[0].validity.valid) {
        new PNotify({
            title: 'Codigo(*)',
            text: 'Ingrese solo números y letras sin espacios en blanco.',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }


    if (_uorg === '') {
        _uorg = null;
    }

    var tipoPerson = {
        IntIdTiPers: _idcate,
        strCoTiPers: _codigo,
        strDesTiPers: _desc,
        intIdUniOrg: _uorg,
        strTiPersCampo1: _camp1,
        strTiPersCampo2: _camp2,
        strTiPersCampo3: _camp3,
        strTiPersCampo4: _camp4,
        strTiPersCampo5: _camp5,
        bitFlActivo: _activo,

    }
    $.post(
        '/Organizacion/ActualizarTipoPerso',
        { objDatos: tipoPerson },
        (response) => {
            console.log(response);
            if (response.type !== '') {

                if (response.type === 'success') {
                    new PNotify({
                        title: 'Actualización de Tipo Personal',
                        text: response.message,
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'
                    });
                    TablaTipoPersonal();
                    $('.form-hide-tipoPerso').hide();
                } else {
                    var list = response.message.split("|")
                    if (list.length == 2) {
                        var nomMantemiento = 'Tipo Personal';
                        var campo = list[1];
                        var msj = list[0];
                        var response = 'info';
                        var deta = 'notifry_error';
                        INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                    } else {
                        new PNotify({
                            title: 'Tipo Personal',
                            text: response.message,
                            type: response.type,
                            delay: 3000,
                            styling: 'bootstrap3'
                        });
                    }
                    return;
                }
            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
});
/**------------------------------------------------------ */
/**8. Categoría */
/**------------------------------------------------------ */
$('#filActiCate').on('change', function () {
    validarSession()
    TablaCategoria();
});
$('#cboDepenCate').on('change', function () {
    validarSession()
    TablaCategoria();
});
$('#filtroCate').keyup(function () {
    validarSession()
    TablaCategoria();
});
$('#btn-new-categoria').on('click', function () {
    validarSession()
    $('.form-hide-categoria').show();
    $('#btn-update-categoria').hide();
    $('#btn-save-change-categoria').show();
    $.post(
        '/Organizacion/NuevaCategoria',
        {},
        (response) => {
            if (response !== '') {
                $('.form-hide-categoria .x_content').empty();
                $('.form-hide-categoria .x_content').html(response);
                $('.form-hide-categoria').show();

                switcheryLoad();//checked verde
                CamposAdicionalesCategorias();

                var txtCod = 'strCoCateg';
                var txtdes = 'strDesCateg';

                $.post(
                    '/Organizacion/ListarCaracteresMax',
                    { strMaestro: 'TGCATEGORIA' },
                    (response) => {
                        response.forEach(element => {
                            if (element.strColumnName == txtCod) {
                                $('#ValCode').children("input").attr('maxlength', element.intMaxLength);
                            } if (element.strColumnName == txtdes) {
                                $('#Valdes').children("input").attr('maxlength', element.intMaxLength);
                            }
                        });
                    });
            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
});
$('#btn-save-change-categoria').on('click', function () {
    validarSession()
    //Datos de la categoria

    var _uorg = $('#cbounidsupe option:selected').val();   //selected
    var _codigo = $('#txt-cod-Categoria').val();
    var _desc = $('#txt-desc-Categoria').val();
    var _activo = $('#chk-activo-Categoria').is(':checked');
    var _camp1 = $('#strCategoriaCampo1').val();
    var _camp2 = $('#strCategoriaCampo2').val();
    var _camp3 = $('#strCategoriaCampo3').val();
    var _camp4 = $('#strCategoriaCampo4').val();
    var _camp5 = $('#strCategoriaCampo5').val();

    if (_codigo === '' || _desc === '' || _uorg === '') {
        new PNotify({
            title: 'Nueva Categoría',
            text: 'Complete los campos obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        $('#notifry_error').html('');
        $('#notifry_errordes').html('');

        return;
    }

    if (_uorg === '') {
        _uorg = null;
    }

    var Categoria = {

        strCoCateg: _codigo,
        strDesCateg: _desc,
        intIdUniOrg: _uorg,
        strCateCampo1: _camp1,
        strCateCampo2: _camp2,
        strCateCampo3: _camp3,
        strCateCampo4: _camp4,
        strCateCampo5: _camp5,
        bitFlActivo: _activo,

    }

    $.post(
        '/Organizacion/RegistrarNuevaCategoria',
        { Categoria: Categoria },
        (response) => {
            console.log(response);
            if (response.type !== '') {

                if (response.type === 'success') {
                    new PNotify({
                        title: 'Nueva Categoría',
                        text: response.message,
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'
                    });
                    TablaCategoria();
                    $('.form-hide-categoria').hide();
                }
                else {
                    var list = response.message.split("|")
                    if (list.length == 2) {
                        var nomMantemiento = 'Categoría';
                        var campo = list[1];
                        var msj = list[0];
                        var response = 'info';
                        var deta = 'notifry_error';
                        INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                    } else {
                        new PNotify({
                            title: 'Categoría',
                            text: response.message,
                            type: response.type,
                            delay: 3000,
                            styling: 'bootstrap3'
                        });
                    }
                    return;
                }
            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });

});
$('#btn-cancel-categoria').on('click', function () {
    validarSession()
    $('.form-hide-categoria').hide();
});
var _varTablaCategoria;
function TablaCategoria() {
    var filtrosActivo = $('#filActiCate').val();
    var filtrojer = $('#cboDepenCate').val();
    var strfiltro = $('#filtroCate').val();

    $.ajax({
        url: '/Organizacion/GetTablaFiltradaCategorias',
        type: 'POST',
        data: {
            IntActivoFilter: filtrosActivo, strfilter: strfiltro, intfiltrojer: filtrojer
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
            if (typeof _varTablaCategoria !== 'undefined') {
                _varTablaCategoria.destroy();
            }
            _varTablaCategoria = $('#tablaCategoria').DataTable({
                data: response,
                columns: [

                    { data: 'strCoCateg' },
                    { data: 'strDesCateg' },
                    { data: 'strNomJerOrg' },
                    { data: 'strDescripcion' },
                    { data: 'FlActivo.strEstadoActivo' },
                    { data: null },
                    { data: 'intIdCateg' },
                    { data: 'bitFlActivo' },
                    { data: 'strCateCampo1' },
                    { data: 'strCateCampo2' },
                    { data: 'strCateCampo3' },
                    { data: 'strCateCampo4' },
                    { data: 'strCateCampo5' },
                    { data: 'intIdUniOrg' },
                ],
                lengthMenu: [10, 25, 50],
                responsive: true,
                order: [],
                language: _datatableLanguaje,
                columnDefs: [//ocultar y definir columnas
                    {
                        targets: [6],//intIdCargo
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [7],//bitFlActivo
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [8],//strCargoCampo1
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [9],//strCargoCampo2
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [10],//strCargoCampo3
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [11],//strCargoCampo4
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [12],//strCargoCampo5
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [13],//intIdUniOrg
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [5],
                        data: null,
                        defaultContent: '<button class="btn btn-success btn-xs btn-edit" ><i class="fa fa-pencil"></i> Editar </button>' +
                            '<button class="btn btn-primary btn-xs btn-delete"><i class="fa fa-trash-o"></i> Eliminar </button>'
                    }
                ],
                dom: 'lBfrtip',
            });

            $('#tablaCategoria tbody').on('click', 'tr button.btn-delete', function () {
                validarSession()
                var data = _varTablaCategoria.row($(this).parents('tr')).data();

                if (data == null) {
                    data = null;

                    var data = _varTablaCategoria.row($(this).parents('li')).data();
                    intentEliminarCategoria(data['intIdCateg'], data['strDesCateg']);

                } else {

                    var data = _varTablaCategoria.row($(this).parents('tr')).data();
                    intentEliminarCategoria(data['intIdCateg'], data['strDesCateg']);

                }


            });

        },
        complete: function () {
            $.unblockUI();
        }
    });
}
/**
$('#tablaCategoria tbody').on('click', 'tr button.btn-edit', function () {
    validarSession()
    var data = _varTablaCategoria.row($(this).parents('tr')).data();
    if (data == null) {
        data = null;
        var data = _varTablaCategoria.row($(this).parents('li')).data();
        cardarDatosCategoria(data);
    } else {
        var data = _varTablaCategoria.row($(this).parents('tr')).data();
        cardarDatosCategoria(data);
    }
});

function intentEliminarCategoria(idCategoria, strNomCategoria) {

    swal({
        title: "Eliminar Categoría",
        text: "¿Está seguro de eliminar la categoría    ''<strong>" + strNomCategoria + "</strong>''   ?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sí, eliminar",
        cancelButtonText: "No, cancelar",
    }).then(function (isConfirm) {
        validarSession()
        if (isConfirm) {
            yesEliminaCategoria(idCategoria);
        } else {
            swal("Cancelado", "La Operación fue cancelada", "error");
        }
    });
}


function yesEliminaCategoria(idCategoria) {

    $.post(
        '/Organizacion/EliminarCategoria',
        { intIdCategoria: idCategoria },
        (response) => {
            console.log(response);
            if (response.type !== '') {
                var tipo = 'Eliminado!';
                if (response.type === 'error')
                    tipo = 'NO SE PUEDE ELIMINAR EL REGISTRO';
                swal(tipo, response.message, response.type);

                if (response.type === 'success')
                    TablaCategoria('', '', '');
            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
}
**/

function cardarDatosCategoria(data) {

    $('#btn-update-categoria').show();
    $('#btn-save-change-categoria').hide();

    var objDatosCategoria = {
        intIdCateg: data['intIdCateg'],
        strCoCateg: data['strCoCateg'],
        strDesCateg: data['strDesCateg'],
        strNomJerOrg: data['strNomJerOrg'],
        strDescripcion: data['strDescripcion'],
        intIdUniOrg: data['intIdUniOrg'],

        strEstadoActivo: data['FlActivo']['strEstadoActivo'],
        bitFlActivo: data['FlActivo']['bitFlActivo'],

        strCateCampo1: data['strCateCampo1'],
        strCateCampo2: data['strCateCampo2'],
        strCateCampo3: data['strCateCampo3'],
        strCateCampo4: data['strCateCampo4'],
        strCateCampo5: data['strCateCampo5']


    }

    console.log(objDatosCategoria);

    $.post(
        '/Organizacion/EditarCategoria',
        { objCategoria: objDatosCategoria },
        (response) => {
            if (response !== '') {
                $('.form-hide-categoria .x_content').empty();
                $('.form-hide-categoria .x_content').html(response);
                $('.form-hide-categoria').show();
                switcheryLoad();
                init_checkBox_styles();
                //  onchange_jerarquia();
                $('#txt-cod-Categoria').val(objDatosCategoria.strCoCateg);
                $('#txt-desc-Categoria').val(objDatosCategoria.strDesCateg);
                $('#txtIdCate').val(objDatosCategoria.intIdCateg);


                //if (objDatosCargo.strEstadoActivo == 'Activo') {
                //    $('#chk-activo-Cargo ').prop('checked', true);
                //    alert($('#chk-activo-Cargo').is(':checked'));
                //    blnActivo = true;

                //} else {

                //    $('#chk-activo-Cargo ').prop('unchecked', true);
                //    alert($('#chk-activo-Cargo').is(':checked'));
                //    blnActivo = false;
                //}


                if (objDatosCategoria.strEstadoActivo == 'Activo') {
                    $('#11').html('<label>Activo</label> <input type = "checkbox" id = "chk-activo-Categoria" class= "js-switch" checked /><script>switcheryLoad();</script >');

                } else {
                    $('#11').html('<label>Activo</label> <input type = "checkbox" id = "chk-activo-Categoria" class= "js-switch" unchecked /><script>switcheryLoad();</script >');

                }

                ////Bloque de Campos Adicionales

                $.post(
                    '/Organizacion/CamposAdicionales',
                    { strEntidad: 'TGCATEGORIA' },
                    (response) => {

                        console.log(response);
                        $('#containerCampos').empty();
                        response.forEach(element => {

                            $('#containerCamposea').append(
                                ' <div class="col-md-6 col-sm-6 col-xs-6"><div class="form-group"><label> ' + element.strTitulo
                                + '</label><input id="' + element.strNomCampo + '" type="text" class="form-control " placeholder="Campo Adicional" maxlength="255"/>' + '</div></div>');

                        });

                        $('#strCategoriaCampo1').val(objDatosCategoria.strCateCampo1);
                        $('#strCategoriaCampo2').val(objDatosCategoria.strCateCampo2);
                        $('#strCategoriaCampo3').val(objDatosCategoria.strCateCampo3);
                        $('#strCategoriaCampo4').val(objDatosCategoria.strCateCampo4);
                        $('#strCategoriaCampo5').val(objDatosCategoria.strCateCampo5);
                    });


                //Bloque de llenados de CBO

                $("#cboJerarquia option").filter(function () {
                    return this.text == objDatosCategoria.strNomJerOrg;
                }).attr('selected', true);

                var id = $('#cboJerarquia option:selected').val();
                if (id == 0 || !id) {
                    $('#cbounidsupe').empty();
                    $('#cbounidsupe').attr('disabled', true);

                    return;
                }
                $.post(
                    '/Organizacion/getUnidxJerarquia',
                    { IntIdJerOrg: id },
                    (response) => {

                        if (true) {

                            response.forEach(element => {

                                $('#cbounidsupe').attr('disabled', false);
                                $('#cbounidsupe').append('<option value="' + element.intIdUniOrg + '" >' + element.strDescripcion + '</option>');
                                if (element.intIdUniOrg == objDatosCategoria.intIdUniOrg) {
                                    $("#cbounidsupe option").filter(function () {
                                        return this.text == objDatosCategoria.strDescripcion;
                                    }).attr('selected', true);
                                }


                            });

                        }
                    }
                ).fail(function (result) {
                    alert('ERROR ' + result.status + ' ' + result.statusText);
                });
                $('#cbounidsupe').empty();


                var txtcod = 'strCoCateg';
                var txtdes = 'strDesCateg';

                $.post(
                    '/Organizacion/ListarCaracteresMax',
                    { strMaestro: 'TGCATEGORIA' },
                    (response) => {
                        response.forEach(element => {
                            if (element.strColumnName == txtcod) {
                                $('.Valcod').children("input").attr('maxlength', element.intMaxLength);
                            }
                            if (element.strColumnName == txtdes) {
                                $('.Valdes').children("input").attr('maxlength', element.intMaxLength);
                            }
                        });
                    });


            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
}

function CamposAdicionalesCategorias() {

    $.post(
        '/Organizacion/CamposAdicionales',
        { strEntidad: 'TGCATEGORIA' },
        (response) => {

            console.log(response);
            $('#containerCamposea').empty();
            response.forEach(element => {

                $('#containerCamposea').append(
                    ' <div class="col-md-6 col-sm-6 col-xs-6"><div class="form-group"><label> ' + element.strTitulo
                    + '</label><input id="' + element.strNomCampo + '" type="text" class="form-control " placeholder="Campo Adicional" maxlength="255"/>' + '</div></div>');


            });
        });
}
$('#btn-update-categoria').on('click', function () {
    validarSession()
    //Datos de la categoria

    var _uorg = $('#cbounidsupe option:selected').val();   //selected
    var _codigoCate = $('#txt-cod-Categoria').val();
    var _descCate = $('#txt-desc-Categoria').val();
    var _activo = $('#chk-activo-Categoria').is(':checked');
    var _camp1 = $('#strCategoriaCampo1').val();
    var _camp2 = $('#strCategoriaCampo2').val();
    var _camp3 = $('#strCategoriaCampo3').val();
    var _camp4 = $('#strCategoriaCampo4').val();
    var _camp5 = $('#strCategoriaCampo5').val();
    var _idcate = $('#txtIdCate').val();

    if (_codigoCate === '' || _descCate === '' || _uorg === '') {
        new PNotify({
            title: 'Actualizacion de Categoria',
            text: 'Complete los campos obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        $('#notifry_error').html('');
        $('#notifry_errordes').html('');

        return;
    }

    if (!$('#txt-cod-Categoria')[0].validity.valid) {
        new PNotify({
            title: 'Codigo(*)',
            text: 'Ingrese solo números y letras sin espacios en blanco.',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }

    if (_uorg === '') {
        _uorg = null;
    }

    var Categoria = {
        intIdCateg: _idcate,
        strCoCateg: _codigoCate,
        strDesCateg: _descCate,
        intIdUniOrg: _uorg,
        strCateCampo1: _camp1,
        strCateCampo2: _camp2,
        strCateCampo3: _camp3,
        strCateCampo4: _camp4,
        strCateCampo5: _camp5,
        bitFlActivo: _activo,
    }
    $.post(
        '/Organizacion/ActualizarCategoria',
        { objDatos: Categoria },
        (response) => {
            console.log(response);
            if (response.type !== '') {

                if (response.type === 'success') {
                    new PNotify({
                        title: 'Actualización de Categoría',
                        text: response.message,
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'
                    });
                    TablaCategoria();
                    $('.form-hide-categoria').hide();
                }
                else {
                    var list = response.message.split("|")
                    if (list.length == 2) {
                        var nomMantemiento = 'Categoría';
                        var campo = list[1];
                        var msj = list[0];
                        var response = 'info';
                        var deta = 'notifry_error';
                        INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                    } else {
                        new PNotify({
                            title: 'Categoría',
                            text: response.message,
                            type: response.type,
                            delay: 3000,
                            styling: 'bootstrap3'
                        });
                    }
                    return;
                }
            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });

});

function init_compose() {

    if (typeof ($.fn.slideToggle) === 'undefined') { return; }

    init_EasyPieChart();
    $('#compose, .compose-close').click(function () {
        $('.compose').slideToggle();
    });
};
function init_EasyPieChart() {

    if (typeof ($.fn.easyPieChart) === 'undefined') { return; }

    $('.chart').easyPieChart({
        easing: 'easeOutElastic',
        delay: 3000,
        barColor: '#26B99A',
        trackColor: '#fff',
        scaleColor: false,
        lineWidth: 20,
        trackWidth: 16,
        lineCap: 'butt',
        onStep: function (from, to, percent) {
            $(this.el).find('.percent').text(Math.round(percent));
        }
    });
    var chart = window.chart = $('.chart').data('easyPieChart');
    $('.js_update').on('click', function () {
        chart.update(Math.random() * 200 - 100);
    });

    //hover and retain popover when on popover content
    var originalLeave = $.fn.popover.Constructor.prototype.leave;
    $.fn.popover.Constructor.prototype.leave = function (obj) {
        var self = obj instanceof this.constructor ?
            obj : $(obj.currentTarget)[this.type](this.getDelegateOptions()).data('bs.' + this.type);
        var container, timeout;

        originalLeave.call(this, obj);

        if (obj.currentTarget) {
            container = $(obj.currentTarget).siblings('.popover');
            timeout = self.timeout;
            container.one('mouseenter', function () {
                //We entered the actual popover – call off the dogs
                clearTimeout(timeout);
                //Let's monitor popover content instead
                container.one('mouseleave', function () {
                    $.fn.popover.Constructor.prototype.leave.call(self, self);
                });
            });
        }
    };

    $('body').popover({
        selector: '[data-popover]',
        trigger: 'click hover',
        delay: {
            show: 50,
            hide: 400
        }
    });

};
function init_charts() {
    if (typeof (Chart) === 'undefined') { return; }
    Chart.defaults.global.legend = {
        enabled: false
    };

    if ($('#canvas_line').length) {

        var canvas_line_00 = new Chart(document.getElementById("canvas_line"), {
            type: 'line',
            data: {
                labels: ["January", "February", "March", "April", "May", "June", "July"],
                datasets: [{
                    label: "My First dataset",
                    backgroundColor: "rgba(38, 185, 154, 0.31)",
                    borderColor: "rgba(38, 185, 154, 0.7)",
                    pointBorderColor: "rgba(38, 185, 154, 0.7)",
                    pointBackgroundColor: "rgba(38, 185, 154, 0.7)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(220,220,220,1)",
                    pointBorderWidth: 1,
                    data: [31, 74, 6, 39, 20, 85, 7]
                }, {
                    label: "My Second dataset",
                    backgroundColor: "rgba(3, 88, 106, 0.3)",
                    borderColor: "rgba(3, 88, 106, 0.70)",
                    pointBorderColor: "rgba(3, 88, 106, 0.70)",
                    pointBackgroundColor: "rgba(3, 88, 106, 0.70)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(151,187,205,1)",
                    pointBorderWidth: 1,
                    data: [82, 23, 66, 9, 99, 4, 2]
                }]
            },
        });

    }


    if ($('#canvas_line1').length) {

        var canvas_line_01 = new Chart(document.getElementById("canvas_line1"), {
            type: 'line',
            data: {
                labels: ["January", "February", "March", "April", "May", "June", "July"],
                datasets: [{
                    label: "My First dataset",
                    backgroundColor: "rgba(38, 185, 154, 0.31)",
                    borderColor: "rgba(38, 185, 154, 0.7)",
                    pointBorderColor: "rgba(38, 185, 154, 0.7)",
                    pointBackgroundColor: "rgba(38, 185, 154, 0.7)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(220,220,220,1)",
                    pointBorderWidth: 1,
                    data: [31, 74, 6, 39, 20, 85, 7]
                }, {
                    label: "My Second dataset",
                    backgroundColor: "rgba(3, 88, 106, 0.3)",
                    borderColor: "rgba(3, 88, 106, 0.70)",
                    pointBorderColor: "rgba(3, 88, 106, 0.70)",
                    pointBackgroundColor: "rgba(3, 88, 106, 0.70)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(151,187,205,1)",
                    pointBorderWidth: 1,
                    data: [82, 23, 66, 9, 99, 4, 2]
                }]
            },
        });

    }


    if ($('#canvas_line2').length) {

        var canvas_line_02 = new Chart(document.getElementById("canvas_line2"), {
            type: 'line',
            data: {
                labels: ["January", "February", "March", "April", "May", "June", "July"],
                datasets: [{
                    label: "My First dataset",
                    backgroundColor: "rgba(38, 185, 154, 0.31)",
                    borderColor: "rgba(38, 185, 154, 0.7)",
                    pointBorderColor: "rgba(38, 185, 154, 0.7)",
                    pointBackgroundColor: "rgba(38, 185, 154, 0.7)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(220,220,220,1)",
                    pointBorderWidth: 1,
                    data: [31, 74, 6, 39, 20, 85, 7]
                }, {
                    label: "My Second dataset",
                    backgroundColor: "rgba(3, 88, 106, 0.3)",
                    borderColor: "rgba(3, 88, 106, 0.70)",
                    pointBorderColor: "rgba(3, 88, 106, 0.70)",
                    pointBackgroundColor: "rgba(3, 88, 106, 0.70)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(151,187,205,1)",
                    pointBorderWidth: 1,
                    data: [82, 23, 66, 9, 99, 4, 2]
                }]
            },
        });

    }


    if ($('#canvas_line3').length) {

        var canvas_line_03 = new Chart(document.getElementById("canvas_line3"), {
            type: 'line',
            data: {
                labels: ["January", "February", "March", "April", "May", "June", "July"],
                datasets: [{
                    label: "My First dataset",
                    backgroundColor: "rgba(38, 185, 154, 0.31)",
                    borderColor: "rgba(38, 185, 154, 0.7)",
                    pointBorderColor: "rgba(38, 185, 154, 0.7)",
                    pointBackgroundColor: "rgba(38, 185, 154, 0.7)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(220,220,220,1)",
                    pointBorderWidth: 1,
                    data: [31, 74, 6, 39, 20, 85, 7]
                }, {
                    label: "My Second dataset",
                    backgroundColor: "rgba(3, 88, 106, 0.3)",
                    borderColor: "rgba(3, 88, 106, 0.70)",
                    pointBorderColor: "rgba(3, 88, 106, 0.70)",
                    pointBackgroundColor: "rgba(3, 88, 106, 0.70)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(151,187,205,1)",
                    pointBorderWidth: 1,
                    data: [82, 23, 66, 9, 99, 4, 2]
                }]
            },
        });

    }


    if ($('#canvas_line4').length) {

        var canvas_line_04 = new Chart(document.getElementById("canvas_line4"), {
            type: 'line',
            data: {
                labels: ["January", "February", "March", "April", "May", "June", "July"],
                datasets: [{
                    label: "My First dataset",
                    backgroundColor: "rgba(38, 185, 154, 0.31)",
                    borderColor: "rgba(38, 185, 154, 0.7)",
                    pointBorderColor: "rgba(38, 185, 154, 0.7)",
                    pointBackgroundColor: "rgba(38, 185, 154, 0.7)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(220,220,220,1)",
                    pointBorderWidth: 1,
                    data: [31, 74, 6, 39, 20, 85, 7]
                }, {
                    label: "My Second dataset",
                    backgroundColor: "rgba(3, 88, 106, 0.3)",
                    borderColor: "rgba(3, 88, 106, 0.70)",
                    pointBorderColor: "rgba(3, 88, 106, 0.70)",
                    pointBackgroundColor: "rgba(3, 88, 106, 0.70)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(151,187,205,1)",
                    pointBorderWidth: 1,
                    data: [82, 23, 66, 9, 99, 4, 2]
                }]
            },
        });

    }


    // Line chart

    if ($('#lineChart').length) {

        var ctx = document.getElementById("lineChart");
        var lineChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: ["January", "February", "March", "April", "May", "June", "July"],
                datasets: [{
                    label: "My First dataset",
                    backgroundColor: "rgba(38, 185, 154, 0.31)",
                    borderColor: "rgba(38, 185, 154, 0.7)",
                    pointBorderColor: "rgba(38, 185, 154, 0.7)",
                    pointBackgroundColor: "rgba(38, 185, 154, 0.7)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(220,220,220,1)",
                    pointBorderWidth: 1,
                    data: [31, 74, 6, 39, 20, 85, 7]
                }, {
                    label: "My Second dataset",
                    backgroundColor: "rgba(3, 88, 106, 0.3)",
                    borderColor: "rgba(3, 88, 106, 0.70)",
                    pointBorderColor: "rgba(3, 88, 106, 0.70)",
                    pointBackgroundColor: "rgba(3, 88, 106, 0.70)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(151,187,205,1)",
                    pointBorderWidth: 1,
                    data: [82, 23, 66, 9, 99, 4, 2]
                }]
            },
        });

    }

    // Bar chart

    if ($('#mybarChart').length) {

        var ctx = document.getElementById("mybarChart");
        var mybarChart = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: ["January", "February", "March", "April", "May", "June", "July"],
                datasets: [{
                    label: '# of Votes 1',
                    backgroundColor: "#26B99A",
                    data: [51, 30, 40, 28, 92, 50, 45]
                }, {
                    label: '# of Votes',
                    backgroundColor: "#03586A",
                    data: [41, 56, 25, 48, 72, 34, 12]
                }]
            },

            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                }
            }
        });

    }


    // Doughnut chart

    if ($('#canvasDoughnut').length) {

        var ctx = document.getElementById("canvasDoughnut");
        var data = {
            labels: [
                "Dark Grey",
                "Purple Color",
                "Gray Color",
                "Green Color",
                "Blue Color"
            ],
            datasets: [{
                data: [120, 50, 140, 180, 100],
                backgroundColor: [
                    "#455C73",
                    "#9B59B6",
                    "#BDC3C7",
                    "#26B99A",
                    "#3498DB"
                ],
                hoverBackgroundColor: [
                    "#34495E",
                    "#B370CF",
                    "#CFD4D8",
                    "#36CAAB",
                    "#49A9EA"
                ]

            }]
        };

        var canvasDoughnut = new Chart(ctx, {
            type: 'doughnut',
            tooltipFillColor: "rgba(51, 51, 51, 0.55)",
            data: data
        });

    }

    // Radar chart

    if ($('#canvasRadar').length) {

        var ctx = document.getElementById("canvasRadar");
        var data = {
            labels: ["Eating", "Drinking", "Sleeping", "Designing", "Coding", "Cycling", "Running"],
            datasets: [{
                label: "My First dataset",
                backgroundColor: "rgba(3, 88, 106, 0.2)",
                borderColor: "rgba(3, 88, 106, 0.80)",
                pointBorderColor: "rgba(3, 88, 106, 0.80)",
                pointBackgroundColor: "rgba(3, 88, 106, 0.80)",
                pointHoverBackgroundColor: "#fff",
                pointHoverBorderColor: "rgba(220,220,220,1)",
                data: [65, 59, 90, 81, 56, 55, 40]
            }, {
                label: "My Second dataset",
                backgroundColor: "rgba(38, 185, 154, 0.2)",
                borderColor: "rgba(38, 185, 154, 0.85)",
                pointColor: "rgba(38, 185, 154, 0.85)",
                pointStrokeColor: "#fff",
                pointHighlightFill: "#fff",
                pointHighlightStroke: "rgba(151,187,205,1)",
                data: [28, 48, 40, 19, 96, 27, 100]
            }]
        };

        var canvasRadar = new Chart(ctx, {
            type: 'radar',
            data: data,
        });

    }


    // Pie chart
    if ($('#pieChart').length) {

        var ctx = document.getElementById("pieChart");
        var data = {
            datasets: [{
                data: [120, 50, 140, 180, 100],
                backgroundColor: [
                    "#455C73",
                    "#9B59B6",
                    "#BDC3C7",
                    "#26B99A",
                    "#3498DB"
                ],
                label: 'My dataset' // for legend
            }],
            labels: [
                "Dark Gray",
                "Purple",
                "Gray",
                "Green",
                "Blue"
            ]
        };

        var pieChart = new Chart(ctx, {
            data: data,
            type: 'pie',
            otpions: {
                legend: false
            }
        });

    }


    // PolarArea chart

    if ($('#polarArea').length) {

        var ctx = document.getElementById("polarArea");
        var data = {
            datasets: [{
                data: [120, 50, 140, 180, 100],
                backgroundColor: [
                    "#455C73",
                    "#9B59B6",
                    "#BDC3C7",
                    "#26B99A",
                    "#3498DB"
                ],
                label: 'My dataset'
            }],
            labels: [
                "Dark Gray",
                "Purple",
                "Gray",
                "Green",
                "Blue"
            ]
        };

        var polarArea = new Chart(ctx, {
            data: data,
            type: 'polarArea',
            options: {
                scale: {
                    ticks: {
                        beginAtZero: true
                    }
                }
            }
        });

    }
}




function INFO_MSJ(nomMantemiento, campo, response, msj, deta) {

    if ($('#cboJerarquia op1917tion:selected').val() !== '') {
        $(".notifry_error").html('');
        $('#notifry_error').html('');
        $('#notifry_errordes').html('');
        //$('#notifry_errorpla').html('');
        //$('#notifry_errorext').html('');
        new PNotify({
            //title: 'Información de111 ' + nomMantemiento + '', //COMENTADO DOM.27.02.2022
            title: '' + nomMantemiento + '',
            text: msj,
            type: response,
            delay: 3000,
            styling: 'bootstrap3'
        });

        $('#' + campo + '').focus();
        if (nomMantemiento == "Unidad Organizacional" || nomMantemiento == "Marcador" || nomMantemiento == "Jerarquía Organizacional" ||
            nomMantemiento == "Cargo" || nomMantemiento == "Categoría" || nomMantemiento == "Tipo Personal" || nomMantemiento == "Grupo" ||
            nomMantemiento == "Planilla" || nomMantemiento == "Centro de Costo" || nomMantemiento == "Marcador" || nomMantemiento == "Grupo Liquidación" ||
            nomMantemiento == "Feriado" || nomMantemiento == "Variable" || nomMantemiento == "Horario" || nomMantemiento == "Regla de Negocio" ||
            nomMantemiento == "Jornada" || nomMantemiento == "Periodo Pago") {
            $("#" + campo).next().html('' + msj + '');
        } else {
            $('#' + deta + '').html('' + msj + '');
        }
        $('#' + campo + '').val('');

    }

    else {
        $('#notifry_error').html('');
        $('#notifry_errordes').html('');
        $('#notifry_errorpla').html('');
        $('#notifry_errorext').html('');
        new PNotify({
            title: 'Información de222 ' + nomMantemiento + '',
            text: msj,
            type: response,
            delay: 3000,
            styling: 'bootstrap3',

        });

        $('#' + deta + '').html('');

    }
}


$(function () {
    $('#datetimepicker3').datetimepicker({
        format: 'LT'
    });
});



function messageResponseMix(data, title) {
    if (data.type === 'success') {
        new PNotify({
            title: title,
            text: data.message,
            type: 'success',
            delay: 3000,
            styling: 'bootstrap3',
        })
    } else if (data.type === 'error') {
        new PNotify({
            title: title,
            text: data.message,
            type: 'error',
            delay: 3000,
            styling: 'bootstrap3',
        })
    } else if (data.type === 'info') {
        new PNotify({
            title: title,
            text: data.message,
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark',
        })
    } else if (data.type === 'infoc') {
        new PNotify({
            title: title,
            text: data.message,
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
        })
    } else {
        new PNotify({
            title: title,
            text: data.message,
            type: 'error',
            delay: 3000,
            styling: 'bootstrap3',
        })
    }
}

function getDateRangePickerEmpleado() {
    const { formatoFecha } = configEmpleadoInicial()
    const idRange = '#filtroFechaRangeEmpleado'
    const fechaInicio = $(idRange)
        .data('daterangepicker')
        .startDate.format(formatoFecha)
    const fechaFin = $(idRange)
        .data('daterangepicker')
        .endDate.format(formatoFecha)
    return { fInicio: fechaInicio, fFin: fechaFin }
}

$('#filActiEmpleado').on('change', function () {
    validarSession()
    const date = getDateRangePickerEmpleado()
    traerDatosEmpleados(date.fInicio, date.fFin)
})

$('#filtroEmpleado').on('change', function () {
    validarSession()
    const date = getDateRangePickerEmpleado()
    traerDatosEmpleados(date.fInicio, date.fFin)
})

$('#filtroFechaRangeEmpleado').on('apply.daterangepicker', function (ev, picker) {
    validarSession()
    const { formatoFecha } = configEmpleadoInicial()
    const filtrojer_ini2 = picker.startDate.format(formatoFecha)
    const filtrojer_fin2 = picker.endDate.format(formatoFecha)
    traerDatosEmpleados(filtrojer_ini2, filtrojer_fin2)
})



async function NuevoEmpleadoVista(editar) {
    const dataVista = await $.post('/Personal/NuevoEmpleado', {})
    if (dataVista !== '') {
        $('.form-hide-empleado .x_content').empty()
        $('.form-hide-empleado .x_content').html(dataVista)
        switcheryLoad()
        init_checkBox_styles()
        cargarDaterangePicker()
        init_daterangepicker()

        //Inicio de código para solucionar observación 1.2  HG 03.03.2021        
        $.post('/Personal/GetHabGeo', {},
            (response) => {
                if (response) {
                    $("#wizarpaso5").show();
                } else {
                    $("#wizarpaso5").hide();
                    $('.wizard_steps').find('li:eq(4)').remove();// Se añadió esta linea
                    $(".p-3").hide();
                    $("#step-5").hide();
                    
                }
            }
        )
        //Fin de código para solucionar observación 1.2  HG 03.03.2021
        
        const dataCboEmpresa = await $.post('/Personal/ListarCombos', {
            intIdMenu: 0,
            strEntidad: 'TGPERSONAL',
            intIdFiltroGrupo: 0,
            strGrupo: 'EMPRESA',
            strSubGrupo: '',
        })
        if (dataCboEmpresa.length) {
            $('#cboEmpresa').empty()
            $('#cboEmpresa').attr('disabled', false)
            $('#cboEmpresa').append('<option value="0">Seleccione</option>')
            dataCboEmpresa.forEach(element => {
                $('#cboEmpresa').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
            })
        }

        $("#cboLocal").change(function () {
            let id = $(this).val()
            $.post('/Personal/ListarComboGlobal', {
                intIdMenu: 1,
                strEntidad: 'TGMARCADORREGISTRO',
                intIdFiltroGrupo: id,
                strGrupo: 'TGMARCADOR',
                strSubGrupo: 'U',
            }, response => {
                $('#marcadorMultiple').empty()
                response.forEach(item => {
                    $('#marcadorMultiple').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')

                })

                new PNotify({
                    title: '',
                    text: 'Verificar si el Local seleccionado tiene Marcador',
                    type: 'info',
                    delay: 1500,
                    styling: 'bootstrap3',
                    addclass: 'dark'
                });

            })

            //NUEVO HG 03.03.21
            //if ($('#marcadorMultiple').val() == '') {
            //    //alert("El Local seleccionado no tiene Marcador");

                //new PNotify({
                //    title: 'Advertencia',
                //    text: 'Verificar si el Local seleccionado tiene Marcador',
                //    type: 'info',
                //    delay: 1500,
                //    styling: 'bootstrap3',
                //    addclass: 'dark'
                //});

            //}
        })

        $("#cboEmpresa").change(function () {

            var intidUniOrg = $(this).val()

            $.post(
                '/Personal/ListarCombos',
                {
                    intIdMenu: 1,
                    strEntidad: 'TGPERSONAL',
                    intIdFiltroGrupo: intidUniOrg,
                    strGrupo: 'LOCAL',
                    strSubGrupo: ''
                },
                response => {
                    $('#cboLocal').empty()
                    $('#cboLocal').attr('disabled', false)
                    $('#cboLocal').append('<option value="0">Seleccione</option>')
                    response.forEach(element => {
                        $('#cboLocal').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                    })
                })

            $.post(
                '/Personal/ListarComboGlobal',
                {
                    intIdMenu: 1,
                    strEntidad: 'TGCARGOREGISTRO',
                    intIdFiltroGrupo: intidUniOrg,
                    strGrupo: 'TGCARGO',
                    strSubGrupo: ''
                },
                response => {
                    $('#cargoEmpleado').empty()
                    $('#cargoEmpleado').append('<option value="0">Seleccione</option>')
                    response.forEach(element => {
                        $('#cargoEmpleado').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                    })
                })

            $.post(
                '/Personal/ListarComboGlobal',
                {
                    intIdMenu: 1,
                    strEntidad: 'TGPLANILLAREGISTRO',
                    intIdFiltroGrupo: intidUniOrg,
                    strGrupo: 'TGPLANILLA',
                    strSubGrupo: ''
                },
                response => {
                    $('#planillaEmpleado').empty()
                    $('#planillaEmpleado').append('<option value="0">Seleccione</option>')
                    response.forEach(element => {
                        $('#planillaEmpleado').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                    })
                })

            $.post(
                '/Personal/ListarComboGlobal',
                {
                    intIdMenu: 1,
                    strEntidad: 'TGCATEGORIAREGISTROEMPLEADO',
                    intIdFiltroGrupo: intidUniOrg,
                    strGrupo: 'TGCATEGORIAEMPLEADO',
                    strSubGrupo: ''
                },
                response => {
                    $('#categoriaEmpleado').empty()
                    $('#categoriaEmpleado').append('<option value="0">Seleccione</option>')
                    response.forEach(element => {
                        $('#categoriaEmpleado').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                    })
                })

            $.post(
                '/Personal/ListarComboGlobal',
                {
                    intIdMenu: 1,
                    strEntidad: 'TGTIPOPERSONREGISTRO',
                    intIdFiltroGrupo: intidUniOrg,
                    strGrupo: 'TGTIPOPERSON',
                    strSubGrupo: ''
                },
                response => {
                    $('#tipoDePersonal').empty()
                    $('#tipoDePersonal').append('<option value="0">Seleccione</option>')
                    response.forEach(element => {
                        $('#tipoDePersonal').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                    })
                })

            $.post(
                '/Personal/ListarComboGlobal',
                {
                    intIdMenu: 1,
                    strEntidad: 'TGGRUPOREGISTRO',
                    intIdFiltroGrupo: intidUniOrg,
                    strGrupo: 'TGGRUPO',
                    strSubGrupo: ''
                },
                response => {
                    $('#tgGrupoRegistro').empty()
                    $('#tgGrupoRegistro').append('<option value="0">Seleccione</option>')
                    response.forEach(element => {
                        $('#tgGrupoRegistro').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                    })
                })

            $.post(
                '/Personal/ListarComboGlobal',
                {
                    intIdMenu: 1,
                    strEntidad: 'TGCCOSTOREGISTRO',
                    intIdFiltroGrupo: intidUniOrg,
                    strGrupo: 'TGCCOSTO',
                    strSubGrupo: ''
                },
                response => {
                    $('#centroDeCosto').empty()
                    $('#centroDeCosto').append('<option value="0">Seleccione</option>')
                    response.forEach(element => {
                        $('#centroDeCosto').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                    })
                })

            $('#marcadorMultiple').empty()
        })

        CombosEmpleado()

        $('#btn-save-change-empleado').prop('disabled', true)
        if (typeof $.fn.smartWizard != 'undefined') {
            $('#wizardEmpleado').smartWizard({
                selected: 0,
                enableFinishButton: true,
                enableAllSteps: true,
                onLeaveStep: leaveAStepCallbackEmpleadoRegistro,
                onFinish: onFinishCallbackEmpleado,
            })
            $('#wizard_verticle').smartWizard({
                transitionEffect: 'slide',
            })

            $('.buttonNext').hide() //.addClass('btn btn-success');
            $('.buttonPrevious').hide() //.addClass('btn btn-primary');
            $('.buttonFinish').hide() //.addClass('btn btn-default');
        }

        $('#CargarImagen').change(function (e) {
            const o = document.getElementById('CargarImagen')
            let foto = o.files[0]
            if (o.files.length == 0 || !/\.(jpeg|jpg|png|svg)$/i.test(foto.name)) {
                messageResponseMix({ type: 'infoc', message: 'Ingrese una imagen con alguno de los siguientes formatos: .jpeg/.jpg/.png.' }, 'Nuevo Empleado')
            } else {
                const img = new Image()
                img.onload = function () {
                    let widthImg = Number(this.width.toFixed(0))
                    let heightImg = Number(this.height.toFixed(0))
                    if (widthImg <= 200 && heightImg <= 200) {
                        messageResponseMix({ type: 'infoc', message: 'Las medidas deben ser mínimo: 200 x 200 px' }, 'Nuevo Empleado')
                    } else {
                        CargoImagenEmpleado()
                    }
                }

                img.src = URL.createObjectURL(foto)
            }
        })
        document.getElementById('delete').onclick = function () {
            $('#VistaPrevia').html('<img src = "/DirLogosRuta/person_logo.jpg" />')
            $('#txtRutaEmple').val('')
            return false
        }
    }
}

async function mostrarFormNuevoEmpleado(estad) {
    const { loaderHtml } = APPCONFIG
    $(`#loaderEditPersonal`).show()
    $(`#loaderEditPersonal`).html(`<div class="loaderContenedor"><div class="min-height-300">${loaderHtml}</div></div>`)
    const { intIdMenu } = configEmpleadoInicial()
    const dataVista = await NuevoEmpleadoVista(false)

    const camposAdicionales = await $.post('/Personal/ListarCamposAdicionales', { intIdMenu: intIdMenu, strNoEntidad: 'TGPERSONAL' })

    if (camposAdicionales.length) {
        $('#contendorCamposPersonal').empty()
        camposAdicionales.forEach(element => {
            let columHtml = `<div class="col-md-6 col-sm-6 col-xs-6">
                                <div class="form-group">
                                    <label> ${element.strTitulo}</label>
                                    <input id="${element.strNomCampo}" type="text" class="form-control " placeholder="${element.strTitulo}" maxlength="255"/>
                                </div>
                            </div>`
            $('#contendorCamposPersonal').append(columHtml)
        })
    }

    const dataCaracter = await $.post('/Personal/ListarCaracteresMax', {
        strMaestro: 'TGPERSONAL',
    })

    if (dataCaracter.length) {
        dataCaracter.forEach(item => {
            if (item.strColumnName == 'strFotocheck') {
                setMaxLengthInput('fotocheckPersonal', item.intMaxLength)
            } else if (item.strColumnName == 'strNombres') {
                setMaxLengthInput('txtNombres', item.intMaxLength)
            } else if (item.strColumnName == 'strApePaterno') {
                setMaxLengthInput('txtApePat', item.intMaxLength)
            } else if (item.strColumnName == 'strApeMaterno') {
                setMaxLengthInput('txtApeMat', item.intMaxLength)
            } else if (item.strColumnName == 'strDireccion') {
                setMaxLengthInput('TXTTIPVIA', item.intMaxLength)
            } else if (item.strColumnName == 'strPersoCampo1') {
                setMaxLengthInput('strPersonalCampo1', item.intMaxLength)
            } else if (item.strColumnName == 'strPersoCampo2') {
                setMaxLengthInput('strPersonalCampo2', item.intMaxLength)
            } else if (item.strColumnName == 'strPersoCampo3') {
                setMaxLengthInput('strPersonalCampo3', item.intMaxLength)
            } else if (item.strColumnName == 'strPersoCampo4') {
                setMaxLengthInput('strPersonalCampo4', item.intMaxLength)
            } else if (item.strColumnName == 'strPersoCampo5') {
                setMaxLengthInput('strPersonalCampo5', item.intMaxLength)
            } else if (item.strColumnName == 'strCodExterior') {
                setMaxLengthInput('codigoExterno', item.intMaxLength)
            } else if (item.strColumnName == 'strCodPensionista') {
                setMaxLengthInput('codigoPensionista', item.intMaxLength)
            } else if (item.strColumnName == 'strCodSalud') {
                setMaxLengthInput('codigoDeSalud', item.intMaxLength)
            }
        })
    }

    $(".disabled_Doc").attr("disabled", true)

    if (typeof _vartablaGeo !== 'undefined') {
        _vartablaGeo.destroy();
    }

    _vartablaGeo = $('#tableGeo').DataTable({
        searching: false,
        paging: false,
        info: false,
        ordering: false,
        language: {
            lengthMenu: 'Mostrar _MENU_ Filas',
            info: '(*) Las Casillas en X no se grabarán',
            infoEmpty: 'No hay Items para mostrar',
            search: '',
            sSearchPlaceholder: '',
            zeroRecords: '',
            infoFiltered: '',
            paginate: {
                previous: 'Anterior',
                next: 'Siguiente'
            }
        },
    });

    $("#txtNumGeo").val(1)

    $("#tableGeoBody").empty();

    $('#cboGeoArea').on('ifChanged', function () {
        if ($("#cboGeoArea").is(':checked')) {
            //$("#txtNumGeo").attr("disabled", false)
            $("#btnNuevaGeoArea").attr("disabled", false)
            getIndexGeo()
        } else {
            //$("#txtNumGeo").attr("disabled", true)
            $("#btnNuevaGeoArea").attr("disabled", true)
        }
    })

    $("#btn-limpiar-Intrevalos").on("click", function () {
        $("#txtCoor").val("")
        $("#txtNumGeo").val(1)
        $("#txtDireccionCoor").val("")
        $("#cboGeoArea").iCheck('unCheck')
    })

    $("#btn-clear-Geo").on("click", function () {
        $("#tableGeoBody").empty();
    })

    $("#btnNuevaGeoArea").on("click", function () {
        getIndexGeo()
    })

    function getIndexGeo() {
        $("#txtCoor").val("")
        $("#txtDireccionCoor").val("")
        if ($("#tableGeoBody tr").length == 0) {
            $("#txtNumGeo").val(1)
        } else {
            var index = 0
            $("#tableGeoBody tr").each(x => {
                var dato = $($("#tableGeoBody tr")[x]).find(".intGeoArea").html()
                if (dato != "") {
                    index = parseInt(dato)
                }
            })
            $("#txtNumGeo").val(index + 1)
        }
    }

    $("#btn-add-Geo").on("click", function () {
        var Geo = $("#txtCoor").val()
        var geoArea = false;
        var dir = $("#txtDireccionCoor").val()
        $("#txtCoor").val("")
        $("#txtDireccionCoor").val("")
        var index = ""
        var btnCoord = ""
        if ($("#cboGeoArea").is(':checked')) {
            geoArea = true;
            index = $("#txtNumGeo").val()
            btnCoord = `<span class="btn btn-success btn-xs btnAgregarCoor"> <i class="fa fa-plus"></i> </span>`
        }

        $("#tableGeoBody").append(`
            <tr class="GeoDetalle">
            <td class="intGeoArea">${index}</td>
            <td class="geo">${Geo}</td>
            <td class="geoDir">${dir}</td>
            <td><span class="btn btn-danger btn-xs btnQuitarCoor"> quitar </span>${btnCoord}</td>
            <td class="geoArea" hidden>${geoArea}</td>
            </tr>
        `)
    })

    $('#activarUsuarioAdmin').attr('disabled', true);
    $(`#loaderEditPersonal`).hide()
    $('.form-hide-empleado').show()
}

$('#btn-new-empleado').on('click', function () {
    validarSession()
    //$('.form-hide-empleado').show()
    $('#btn-save-change-empleado').show()
    $('#btn-editar-empleado').hide()
    activaUsuario = false;
    desactivaUsuario = false;
    activarAdmin = false;
    mostrarFormNuevoEmpleado(false)
})

function leaveAStepCallbackEmpleado(obj, context) {
    //alert('Leaving step ' + context.fromStep + ' to go to step ' + context.toStep)
    if (context.toStep == 4) {
        $('#btn-save-change-empleado').prop('disabled', false)
        //$('#btn-editar-empleado').prop('disabled', false)
    }
    return validateSteps(context.fromStep) // return false to stay on step and true to continue navigation
}


//COMENTADO HG 03.03.21
//function leaveAStepCallbackEmpleadoRegistro(obj, context) {
//    //alert('Leaving step ' + context.fromStep + ' to go to step ' + context.toStep)
//    if (context.toStep == 4) {
//        $('#btn-save-change-empleado').prop('disabled', false)
//        //$('#btn-editar-empleado').prop('disabled', false)
//    }
//    return validateStepsEmpleado(context.fromStep) // return false to stay on step and true to continue navigation
//}


//AÑADIDO HG 03.03.21
function leaveAStepCallbackEmpleadoRegistro(obj, context) {

     if (context.fromStep > context.toStep ) {
    
            return true;
     }
    
     if (context.fromStep == 1 && context.toStep == 2) {
    
         return validateStepsEmpleado(1);
     }
    
     if (context.fromStep == 1 && context.toStep == 3) {
    
         return validateStepsEmpleado(2);
    
     }
    
     if (context.fromStep == 1 && context.toStep == 4) {
    
         return validateStepsEmpleado(3);
    
     }    

     if (context.fromStep == 2 && context.toStep == 3) {

         return validateStepsEmpleado(2);
     }

     if (context.fromStep == 2 && context.toStep == 4) {

         return validateStepsEmpleado(3);
     }

     if (context.fromStep == 3 && context.toStep == 4 ) {

         return validateStepsEmpleado(3);
     }

     if (context.toStep == 4) {

        $('#btn-save-change-empleado').prop('disabled', false)
     }

    //else if (context.toStep > context.fromStep) {//toStep: PASO CLICKEADO, fromStep: PASO DESDE DONDE SE ESTA CLICKEANDO

    //    //REALIZA LA VALIDACION DE LOS CONTROLES PARA DEVOLVERME TRUE ó FALSE
    //    return validateStepsEmpleado(context.fromStep);
    //    //TRUE : QUE SI SE PUEDE IR A ESE PASO CLICKEADO
    //    //FALSE: QUE NO SE PUEDE IR AL PASO CLICKEADO
    //}
    //else {
    //    return true;
    //}
}






function onFinishCallbackEmpleado(objs, context) {
    if (validateAllSteps()) {
        //$('form').submit()
        $('#btn-save-change-empleado').prop('disabled', false)
        // $('#btn-editar-empleado').prop('disabled', false)
    }
}

function validateStepsEmpleado(stepnumber) {
    const { intIdMenu, formatoFecha } = configEmpleadoInicial()
    const titleToast = 'Nuevo Empleado'

    //Añadido HG 03.03.21
    var ResponsableInmediato = $('#select2-cboResponsableInmediato-container').text();
    var ResponsableContractual = $('#select2-cboResponsableContractual-container').text();
    
    var isStepValid = true

    // validate step 1
    if (stepnumber == 1) {
        if (
            $('#TipoDoc').val() != 0 &&
            $('#txtNumDoc').val().length > 1 &&
            $('#txtApePat').val().length > 1 &&
            $('#txtApeMat').val().length > 1 &&
            $('#txtNombres').val().length > 1 &&
            $('#txtFechaNac').val().length > 1 &&
            $("input[name='generoEmpleado']:radio").is(':checked') &&
            $('#Email_Emple').val().length > 4 &&
            ValidateEmail(getValueControl('#Email_Emple')) &&
            $('#celularEmpleado').val().length > 8
        ) {
            isStepValid = true
        } else {
            messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
            isStepValid = false
        }
    }

    else if (stepnumber == 2) {
        if (
            $('#fotocheckPersonal').val().length > 3 &&
            $('#txtFechaAdmi').val().length > 4 &&
            $('#comboFiscalizacion').val() != 0 &&
            $('#nivelDeResponsabilidad').val() != 0 &&
            $('#cargoEmpleado').val() != 0 &&
            $('#planillaEmpleado').val() != 0 &&
            $('#cboDependencia').val() != 0 &&
            $('#unidadOrganizacionalCbo').val() != 0
        ) {
            isStepValid = true
        } else {
            messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
            isStepValid = false
        }
    }


    else if (stepnumber == 3) {
        if (ResponsableContractual != "×Seleccione" && ResponsableInmediato != "×Seleccione") { //($("#cboResponsableInmediato option").length = 1 || $('#cboResponsableInmediato').val() != 0) && ($("#cboResponsableContractual option").length = 1 || $('#cboResponsableContractual').val() != 0) ||
            isStepValid = true
            $('#btn-save-change-empleado').prop('disabled', false)
        } else {
            messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios (Responsables)' }, titleToast)
            isStepValid = false
        }
    }

    else if (stepnumber == 4) {
        if (($('#reglaDeNegocio option').length = 1 || $('#reglaDeNegocio').val() != 0) && ($('#tgHorarioFijo option').length = 1 || $('#tgHorarioFijo').val() != 0) && getValueControl('#marcadorMultiple').length >= 1) {
            isStepValid = true
            $('#btn-save-change-empleado').prop('disabled', false)
        } else {
            messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios (Regla, Horario y/o Marcador)' }, titleToast)
            isStepValid = false
        }
    }

    return isStepValid
}
// Your Step validation logic
function validateSteps(stepnumber) {
    const { intIdMenu, formatoFecha } = configEmpleadoInicial()
    const titleToast = 'Editar Empleado'

    var isStepValid = true
    // validate step 1
    if (stepnumber == 1) {
        if (
            $('#txtApePat').val().length > 1 &&
            $('#txtApeMat').val().length > 1 &&
            $('#txtNombres').val().length > 1 &&
            $('#txtFechaNac').val().length > 1 &&
            $("input[name='generoEmpleado']:radio").is(':checked') &&
            $('#Email_Emple').val().length > 4 &&
            ValidateEmail(getValueControl('#Email_Emple')) &&
            $('#celularEmpleado').val().length > 8
        ) {
            isStepValid = true
        } else {
            messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
            isStepValid = false
        }
    } else if (stepnumber == 2) {
        if (
            $('#fotocheckPersonal').val().length > 3 &&
            $('#txtFechaAdmi').val().length > 4 &&
            $('#comboFiscalizacion').val() != 0 &&
            $('#nivelDeResponsabilidad').val() != 0 &&
            $('#cargoEmpleado').val() != 0 &&
            $('#planillaEmpleado').val() != 0 &&
            $('#cboDependencia').val() != 0 &&
            $('#unidadOrganizacionalCbo').val() != 0
        ) {
            isStepValid = true
        } else {
            messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
            isStepValid = false
        }
    } else if (stepnumber == 3) {
        if (($("#cboResponsableInmediato option").length = 1 || $('#cboResponsableInmediato').val() != 0) && ($("#cboResponsableContractual option").length = 1 || $('#cboResponsableContractual').val() != 0)) {
            isStepValid = true
        } else {
            messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios (Responsables)' }, titleToast)
            isStepValid = false
        }
    } else if (stepnumber == 4){
        if (($('#reglaDeNegocio option').length = 1 || $('#reglaDeNegocio').val() != 0) && ($('#tgHorarioFijo option').length = 1 || $('#tgHorarioFijo').val() != 0) && getValueControl('#marcadorMultiple').length >= 1) {
            isStepValid = true
        } else {
            messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios (Regla, Horario y/o Marcador)' }, titleToast)
            isStepValid = false
        }
    }
    return isStepValid
}
function validateAllSteps() {
    var isStepValid = true
    // all step validation logic
    return isStepValid
}

function CargoImagenEmpleado() {
    const formdata = new FormData()
    const fileInput = document.getElementById('CargarImagen')
    formdata.append(fileInput.files[0].name, fileInput.files[0])
    const nameFile = fileInput.files[0].name
    var xhr = new XMLHttpRequest()

    xhr.open('POST', '/Personal/Upload')
    xhr.send(formdata)
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            DirLocal = xhr.responseText
            $('#VistaPrevia').html('<img id="imgCarga"  src=' + DirLocal + ' class="img-rounded img-logo-empleado" />')
            $('#txtRutaEmple').val(nameFile)
        }
    }

    return false
}
// mostrar--
async function EditarEmpleadoVista(idItemPersonalEdit, intIdUniOrg, intidPlanilla, intIdLocal) {
    const { intIdMenu } = configEmpleadoInicial()
    $('.form-hide-empleado .x_content').empty()
    $('.form-hide-empleado .x_content').html('')
    try {
        const resultForm = await $.ajax({ url: '/Personal/EditarEmpleado', type: 'POST', data: {} })
        if (resultForm !== '') {
            $('.form-hide-empleado .x_content').empty()
            $('.form-hide-empleado .x_content').html(resultForm)
            $('#wizard .form-hide-empleado').hide()
            $('#btn-editar-empleado').hide()
            $('.form-hide-empleado').hide()
            switcheryLoad()
            init_checkBox_styles()
            cargarDaterangePicker()
            init_daterangepicker()

            //Inicio de código para solucionar observación 1.2  HG 03.03.2021 
            $.post('/Personal/GetHabGeo', {},
                (response) => {
                    if (response) {
                        $("#wizarpaso5").show();
                    } else {
                        $("#wizarpaso5").hide();
                        $('.wizard_steps').find('li:eq(4)').remove();
                        $(".p-3").hide();
                        $("#step-5").hide();
                    }
                }
            )
            //Fin de código para solucionar observación 1.2  HG 03.03.2021

            //$('#btn-editar-empleado').prop('disabled', true)
            if (typeof $.fn.smartWizard != 'undefined') {
                $('#wizardEmpleado').smartWizard({
                    selected: 0,
                    keyNavigation: false,
                    enableFinishButton: true,
                    enableAllSteps: true,
                    onLeaveStep: leaveAStepCallbackEmpleado,
                    onFinish: onFinishCallbackEmpleado,
                })
                $('#wizard_verticle').smartWizard({
                    transitionEffect: 'slide',
                })

                $('.buttonNext').hide() //.addClass('btn btn-success');
                $('.buttonPrevious').hide() //.addClass('btn btn-primary');
                $('.buttonFinish').hide() //.addClass('btn btn-default');
            }
        }

        $('#CargarImagen').change(function (e) {
            const o = document.getElementById('CargarImagen')
            let foto = o.files[0]
            if (o.files.length == 0 || !/\.(jpeg|jpg|png|svg)$/i.test(foto.name)) {
                messageResponseMix({ type: 'infoc', message: 'Ingrese una imagen con alguno de los siguientes formatos: .jpeg/.jpg/.png.' }, 'Editar Empleado')
            } else {
                const img = new Image()
                img.onload = function () {
                    let widthImg = Number(this.width.toFixed(0))
                    let heightImg = Number(this.height.toFixed(0))
                    if (widthImg <= 200 && heightImg <= 200) {
                        messageResponseMix({ type: 'infoc', message: 'Las medidas deben ser mínimo: 200 x 200 px' }, 'Editar Empleado')
                    } else {
                        CargoImagenEmpleado()
                    }
                }

                img.src = URL.createObjectURL(foto)
            }
        })

        document.getElementById('delete').onclick = function () {
            $('#VistaPrevia').html('<img src = "/DirLogosRuta/person_logo.jpg" />')
            $('#txtRutaEmple').val('')
            return false
        }

        // $('#tagsEmail').importTags('')
        // $('#tagsTelefono').importTags('')

        const camposAdicionales = await $.post('/Personal/ListarCamposAdicionales', { intIdMenu: intIdMenu, strNoEntidad: 'TGPERSONAL' })

        if (camposAdicionales.length) {
            $('#contendorCamposPersonal').empty()
            camposAdicionales.forEach(element => {
                let columHtml = `<div class="col-md-6 col-sm-6 col-xs-6">
                                    <div class="form-group">
                                        <label> ${element.strTitulo}</label>
                                        <input id="${element.strNomCampo}" type="text" class="form-control " placeholder="${element.strTitulo}" maxlength="255"/>
                                    </div>
                                </div>`
                $('#contendorCamposPersonal').append(columHtml)
            })
        }

        const caracteresMax = await $.post('/Personal/ListarCaracteresMax', {
            intIdMenu: intIdMenu,
            strMaestro: 'TGPERSONAL',
        })
        if (caracteresMax.length > 0) {
            caracteresMax.forEach(item => {
                if (item.strColumnName == 'strFotocheck') {
                    setMaxLengthInput('fotocheckPersonal', item.intMaxLength)
                } else if (item.strColumnName == 'strNombres') {
                    setMaxLengthInput('txtNombres', item.intMaxLength)
                } else if (item.strColumnName == 'strApePaterno') {
                    setMaxLengthInput('txtApePat', item.intMaxLength)
                } else if (item.strColumnName == 'strApeMaterno') {
                    setMaxLengthInput('txtApeMat', item.intMaxLength)
                } else if (item.strColumnName == 'strDireccion') {
                    setMaxLengthInput('TXTTIPVIA', item.intMaxLength)
                } else if (item.strColumnName == 'strPersoCampo1') {
                    setMaxLengthInput('strPersonalCampo1', item.intMaxLength)
                } else if (item.strColumnName == 'strPersoCampo2') {
                    setMaxLengthInput('strPersonalCampo2', item.intMaxLength)
                } else if (item.strColumnName == 'strPersoCampo3') {
                    setMaxLengthInput('strPersonalCampo3', item.intMaxLength)
                } else if (item.strColumnName == 'strPersoCampo4') {
                    setMaxLengthInput('strPersonalCampo4', item.intMaxLength)
                } else if (item.strColumnName == 'strPersoCampo5') {
                    setMaxLengthInput('strPersonalCampo5', item.intMaxLength)
                } else if (item.strColumnName == 'strCodExterior') {
                    setMaxLengthInput('codigoExterno', item.intMaxLength)
                } else if (item.strColumnName == 'strCodPensionista') {
                    setMaxLengthInput('codigoPensionista', item.intMaxLength)
                } else if (item.strColumnName == 'strCodSalud') {
                    setMaxLengthInput('codigoDeSalud', item.intMaxLength)
                }
            })
        }

        const tipoDocData = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: intIdMenu,
            strEntidad: 'TSTIPDOC02',
            intIdFiltroGrupo: 0,
            strGrupo: 'PER',
            strSubGrupo: '',
        })
        if (tipoDocData !== '') {
            $('#TipoDoc').empty()
            $('#TipoDoc').attr('disabled', false)
            tipoDocData.forEach(element => {
                $('#TipoDoc').append('<option value="' + element.intId + '" maxdata="' + element.strCodigo + '"  >' + element.strDescripcion + '</option>')
            })
        }

        const dataTipVia = await $.post('/Personal/ListarCombos', {
            intIdMenu: intIdMenu,
            strEntidad: 'TGTIPO_VIA',
            intIdFiltroGrupo: 0,
            strGrupo: '',
            strSubGrupo: '',
        })
        if (dataTipVia.length) {
            $('#TipVia').empty()
            $('#TipVia').attr('disabled', false)
            $('#TipVia').append('<option value="">Via</option>')
            dataTipVia.forEach(element => {
                $('#TipVia').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
            })
        }

        const dataCboPais = await $.post('/Personal/ListarCombos', {
            intIdMenu: intIdMenu,
            strEntidad: 'TGPAIS',
            intIdFiltroGrupo: 0,
            strGrupo: 'EXISTE',
            strSubGrupo: '',
        })
        if (dataCboPais.length) {
            $('#CboPais').empty()
            $('#CboPais').attr('disabled', false)
            $('#CboPais').append('<option value="">Seleccione</option>')

            dataCboPais.forEach(element => {
                $('#CboPais').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
            })
        }

        const dataCorreosPersonal = await $.post('/Personal/GetCorreosPersonal', {
            intIdMenu: 1,
            intIdPersonal: idItemPersonalEdit,
        })
        if (dataCorreosPersonal.length) {
            let dataCorreosInsert = ''
            dataCorreosPersonal.forEach(element => {
                if (element.bitFlPrincipal) {
                    $('#Email_Emple').val(element.strCorreo)
                } else {
                    dataCorreosInsert += element.strCorreo + ','
                }
            })
            if (dataCorreosInsert != '') {
                let cadenaEmail = dataCorreosInsert.slice(0, -1)
                $('#TagEmailContainer').html(`<input id="tagsEmail" type="text" class="tags form-control tagsEmailGet" value="${cadenaEmail}" /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
                //$('#tagsEmail').importTags(cadenaEmail)
            } else {
                $('#TagEmailContainer').html(`<input id="tagsEmail" type="text" class="tags form-control tagsEmailGet" value="" /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
            }
        } else {
            $('#TagEmailContainer').html(`<input id="tagsEmail" type="text" class="tags form-control tagsEmailGet" value="" /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
        }

        const dataTelefonosPersonal = await $.post('/Personal/GetTelefonosPersonal', {
            intIdMenu: 1,
            intIdPersonal: idItemPersonalEdit,
        })
        if (dataTelefonosPersonal.length) {
            let dataTelefonosInsert = ''
            dataTelefonosPersonal.forEach(element => {
                if (element.bitFlPrincipal) {
                    $('#celularEmpleado').val(element.strNumero)
                } else {
                    dataTelefonosInsert += element.strNumero + ','
                }
            })
            if (dataTelefonosInsert != '') {
                let cadenaTekl = dataTelefonosInsert.slice(0, -1)
                $('#tagTelefonosContainer').html(`<input id="tagsTelefono" type="text" class="tags form-control tagsTelefonoGet" value="${cadenaTekl}"  /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
                //$('#tagsTelefono').importTags(cadenaTekl)
            } else {
                $('#tagTelefonosContainer').html(`<input id="tagsTelefono" type="text" class="tags form-control tagsTelefonoGet" value=""  /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
            }
        } else {
            $('#tagTelefonosContainer').html(`<input id="tagsTelefono" type="text" class="tags form-control tagsTelefonoGet" value=""  /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
        }

        var mailformatEmail = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/

        $('#tagsEmail').tagsInput({
            width: 'auto',
            defaultText: 'Correos',
            placeholderColor: '#666666',
            pattern: mailformatEmail,
            interactive: true,
        })
        $('#tagsTelefono').tagsInput({
            width: 'auto',
            defaultText: 'Teléfonos',
            placeholderColor: '#666666',
            pattern: /^\d{9}$/,
            interactive: true,
        })

        const dataFiscalizacion = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGTIPO1REGISTROTIPOFISCALIZACION',
            intIdFiltroGrupo: 0,
            strGrupo: 'PER',
            strSubGrupo: '',
        })
        if (dataFiscalizacion.length) {
            $('#comboFiscalizacion').empty()
            $('#comboFiscalizacion').append('<option value="0">Seleccione</option>')
            dataFiscalizacion.forEach(item => {
                $('#comboFiscalizacion').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataResponsabilidad = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGTIPO1REGISTRO',
            intIdFiltroGrupo: 0,
            strGrupo: 'PER',
            strSubGrupo: '',
        })
        if (dataResponsabilidad.length) {
            $('#nivelDeResponsabilidad').empty()
            $('#nivelDeResponsabilidad').append('<option value="0">Seleccione</option>')
            dataResponsabilidad.forEach(item => {
                $('#nivelDeResponsabilidad').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataCargoEmpleado = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGCARGOREGISTRO',
            intIdFiltroGrupo: intIdUniOrg,
            strGrupo: 'TGCARGO',
            strSubGrupo: 'U',
        })
        if (dataCargoEmpleado.length) {
            $('#cargoEmpleado').empty()
            $('#cargoEmpleado').append('<option value="0">Seleccione</option>')
            dataCargoEmpleado.forEach(item => {
                $('#cargoEmpleado').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataPlanillaEmpleado = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGPLANILLAREGISTRO',
            intIdFiltroGrupo: intIdUniOrg,
            strGrupo: 'TGPLANILLA',
            strSubGrupo: 'U',
        })
        if (dataPlanillaEmpleado.length) {
            $('#planillaEmpleado').empty()
            $('#planillaEmpleado').append('<option value="0">Seleccione</option>')
            dataPlanillaEmpleado.forEach(item => {
                $('#planillaEmpleado').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataCategoriaEmpleado = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGCATEGORIAREGISTROEMPLEADO',
            intIdFiltroGrupo: intIdUniOrg,
            strGrupo: 'TGCATEGORIAEMPLEADO',
            strSubGrupo: 'U',
        })
        if (dataCategoriaEmpleado.length) {
            $('#categoriaEmpleado').empty()
            $('#categoriaEmpleado').append('<option value="0">Seleccione</option>')
            dataCategoriaEmpleado.forEach(item => {
                $('#categoriaEmpleado').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataTipoDePersonal = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGTIPOPERSONREGISTRO',
            intIdFiltroGrupo: intIdUniOrg,
            strGrupo: 'TGTIPOPERSON',
            strSubGrupo: 'U',
        })
        if (dataTipoDePersonal.length) {
            $('#tipoDePersonal').empty()
            $('#tipoDePersonal').append('<option value="0">Seleccione</option>')
            dataTipoDePersonal.forEach(item => {
                $('#tipoDePersonal').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataTgGrupoRegistro = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGGRUPOREGISTRO',
            intIdFiltroGrupo: intIdUniOrg,
            strGrupo: 'TGGRUPO',
            strSubGrupo: 'U',
        })
        if (dataTgGrupoRegistro.length) {
            $('#tgGrupoRegistro').empty()
            $('#tgGrupoRegistro').append('<option value="0">Seleccione</option>')
            dataTgGrupoRegistro.forEach(item => {
                $('#tgGrupoRegistro').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataCentroDeCosto = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGCCOSTOREGISTRO',
            intIdFiltroGrupo: intIdUniOrg,
            strGrupo: 'TGCCOSTO',
            strSubGrupo: 'U',
        })
        if (dataCentroDeCosto.length) {
            $('#centroDeCosto').empty()
            $('#centroDeCosto').append('<option value="0">Seleccione</option>')
            dataCentroDeCosto.forEach(item => {
                $('#centroDeCosto').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataCboEmpresa = await $.post('/Personal/ListarCombos', {
            intIdMenu: intIdMenu,
            strEntidad: 'TGPERSONAL',
            intIdFiltroGrupo: 0,
            strGrupo: 'EMPRESA',
            strSubGrupo: 'U',
        })
        if (dataCboEmpresa.length) {
            $('#cboEmpresa').empty()
            $('#cboEmpresa').attr('disabled', false)
            $('#cboEmpresa').append('<option value="0">Seleccione</option>')
            dataCboEmpresa.forEach(element => {
                $('#cboEmpresa').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
            })
        }

        const dataCboDependencia = await $.post('/Personal/ListarCombos', {
            intIdMenu: intIdMenu,
            strEntidad: 'TGJERARQORG',
            intIdFiltroGrupo: 0,
            strGrupo: 'DEPEN',
            strSubGrupo: 'EMPRESADEPEN',
        })

        if (dataCboDependencia.length) {
            $('#cboDependencia').empty()
            $('#cboDependencia').attr('disabled', false)
            $('#cboDependencia').append('<option value="0">Seleccione</option>')
            dataCboDependencia.forEach(element => {
                $('#cboDependencia').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
            })
        }

        const dataRespoDetalle = await $.post('/Personal/GetResponsablesPersonal', {
            intIdMenu: 1,
            intIdPersonal: idItemPersonalEdit,
        })
        let intIdTipoRespInmediato = null
        let intIdTipoRespContractual = null
        if (dataRespoDetalle.length) {
            dataRespoDetalle.forEach(item => {
                if (item.intIdTipoResp == 10) {
                    intIdTipoRespContractual = item.intIdPerResp
                } else {
                    intIdTipoRespInmediato = item.intIdPerResp
                }
            })
        }

        const datacboResponsableInmediato = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: intIdMenu,
            strEntidad: 'TGPERSONALINMEDIATOOLIDERAZGO',
            intIdFiltroGrupo: intIdUniOrg,
            strGrupo: 'TGPERSONAL',
            strSubGrupo: 'U',
        })
        if (datacboResponsableInmediato.length) {
            $('#cboResponsableInmediato').empty()
            $('#cboResponsableInmediato').append('<option value="0">Seleccione</option>')
            $('#cboResponsableInmediato').attr('disabled', false)
            datacboResponsableInmediato.forEach(element => {
                $('#cboResponsableInmediato').append('<option value="' + element.intId + '"   >' + element.strDescripcion + '</option>')
                if (intIdTipoRespInmediato == element.intId) {
                    $('#cboResponsableInmediato').val(intIdTipoRespInmediato)
                    console.log("test")
                }
            })
            $('#cboResponsableInmediato').select2({
                language: {

                    noResults: function () {

                        return "No hay resultado";
                    },
                    searching: function () {

                        return "Buscando..";
                    }
                },
                placeholder: 'Seleccione',
                allowClear: true,
            })
        }

        const dataCboResponsableContractual = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: intIdMenu,
            strEntidad: 'TGPERSONALCONTRACTUAL',
            intIdFiltroGrupo: intIdUniOrg,
            strGrupo: 'TGPERSONAL',
            strSubGrupo: 'U',
        })
        if (dataCboResponsableContractual.length) {
            $('#cboResponsableContractual').empty()
            $('#cboResponsableContractual').append('<option value="0">Seleccione</option>')
            $('#cboResponsableContractual').attr('disabled', false)
            dataCboResponsableContractual.forEach(element => {
                $('#cboResponsableContractual').append('<option value="' + element.intId + '"   >' + element.strDescripcion + '</option>')
                if (intIdTipoRespContractual == element.intId) {
                    $('#cboResponsableContractual').val(intIdTipoRespContractual)
                }
            })
            $('#cboResponsableContractual').select2({
                language: {

                    noResults: function () {

                        return "No hay resultado";
                    },
                    searching: function () {

                        return "Buscando..";
                    }
                },
                placeholder: 'Seleccione',
                allowClear: true,
            })
        }

        //
        const dataReglaDeNegocio = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGREGLANEGREGISTRO',
            intIdFiltroGrupo: intIdUniOrg,
            strGrupo: 'TGREGLANEG',
            strSubGrupo: 'U',
        })
        if (dataReglaDeNegocio.length) {
            $('#reglaDeNegocio').empty()
            $('#reglaDeNegocio').append('<option value="0">Seleccione</option>')
            dataReglaDeNegocio.forEach(item => {
                $('#reglaDeNegocio').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataTgHorarioFijo = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGHORARIOREGISTRO',
            intIdFiltroGrupo: intIdUniOrg,
            strGrupo: 'TGHORARIO',
            strSubGrupo: 'U',
        })

        if (dataTgHorarioFijo.length) {
            $('#tgHorarioFijo').empty()
            $('#tgHorarioFijo').append('<option value="0">Seleccione</option>')
            dataTgHorarioFijo.forEach(item => {
                $('#tgHorarioFijo').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataMarcadorMultiple = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGMARCADORREGISTRO',
            intIdFiltroGrupo: intIdLocal,
            strGrupo: 'TGMARCADOR',
            strSubGrupo: 'U',
        })
        if (dataMarcadorMultiple.length) {
            $('#marcadorMultiple').empty()
            //$('#marcadorMultiple').append('<option value="0">Seleccione</option>');
            dataMarcadorMultiple.forEach(item => {
                $('#marcadorMultiple').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataMotivoDeCese = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGMOTIVOREGISTRO',
            intIdFiltroGrupo: 0,
            strGrupo: 'TGMOTIVO',
            strSubGrupo: '',
        })

        if (dataMotivoDeCese.length) {
            $('#mativoDeCese').empty()
            $('#mativoDeCese').append('<option value="0">Seleccione</option>')
            dataMotivoDeCese.forEach(item => {
                $('#mativoDeCese').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataTgTgGrupoliq = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGGRUPOLIQREGISTRO',
            intIdFiltroGrupo: intidPlanilla,
            strGrupo: 'TGGRUPOLIQ',
            strSubGrupo: 'U',
        })
        if (dataTgTgGrupoliq.length) {
            $('#tgTgGrupoliq').empty()
            $('#tgTgGrupoliq').append('<option value="0">Seleccione</option>')
            dataTgTgGrupoliq.forEach(item => {
                $('#tgTgGrupoliq').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataMarcadoresLista = await $.post('/Personal/GetMarcadoresPersonal', {
            intIdMenu: 1,
            intIdPersonal: idItemPersonalEdit,
        })
        if (dataMarcadoresLista.length) {
            const newArr = dataMarcadoresLista.map(function (val, index) {
                return val.intIdMarcador
            })
            $('#marcadorMultiple').val(newArr)
        }

    } catch (error) {
        console.error(error)
    }
}

async function editarEmpleado(idItemEdit) {
    const { intIdMenu } = configEmpleadoInicial()
    const { loaderHtml } = APPCONFIG
    $(`#loaderEditPersonal`).show()
    $(`#loaderEditPersonal`).html(`<div class="loaderContenedor"><div class="min-height-300">${loaderHtml}</div></div>`)

    const dataEmpleado = await $.post('/Personal/ObtenerRegistroEmpleado', { intIdPersonal: idItemEdit }, response => { })
    const estadoDeCargaVista = await EditarEmpleadoVista(idItemEdit, dataEmpleado[0].intIdUniOrgSup, dataEmpleado[0].intIdPlanilla, dataEmpleado[0].intIdLocal)
    validarEmpleadoControlesEmpleadop()
    console.log(dataEmpleado)
    if (dataEmpleado.length) {
        const data = dataEmpleado[0]

        const INTIDTPEVAL = data.intIdUbigeo
        const INTIDSUPUBI = data.intIdUbigSup
        const INTIDSUPUBIREGION = data.intIdUbiSupReg
        const intIdProvinciaMostrar = data.intIdUbiReg
        const intIdRegionMostrar = data.intIdUbiPais
        const intIdJerOrgLista = data.intIdJerOrg
        const intIdUniOrgLista = data.intIdUniOrg
        const intIdUniOrgSupLista = data.intIdUniOrgSup
        const intIdLocalLista = data.intIdLocal


        $("#cboEmpresa").val(intIdUniOrgSupLista)
        $('#cboDependencia').val(intIdJerOrgLista)
        $('#CboPais').val(data.intIdUbiSupPais)
        $('#intTipoOperacion').val('2')
        $('#intIdPersonalReg').val(data.intIdPersonal)
        $('#codigoDeRegistro').val(data.strCoPersonal.trim() + '-' + data.strNumRegis.trim())
        $('#codPersonalHideen').val(data.strCoPersonal)
        $('#numRegistroPersonalHideen').val(data.strNumRegis.trim())
        $('#fechaDeCeseValidar').val(data.dttFecCese)
        $('#fechaDefechaAdmision').val(data.dttFecAdmin)
        $('#TipoDoc').val(data.intIdTipDoc)
        $('#TipoDoc').prop('disabled', true)
        $('#txtNumDoc').val(data.strNumDoc)
        $('#txtNumDoc').prop('disabled', true)
        $('#txtApePat').val(data.strApePaterno)
        $('#txtApeMat').val(data.strApeMaterno)
        $('#txtNombres').val(data.strNombres)
        $('#txtFechaNac').val(data.dttFecNacim)
        $('#TipVia').val(data.intIdTipoVia)
        $('#TXTTIPVIA').val(data.strDireccion)
        $('#txtFechaAdmi').val(data.dttFecAdmin)
        $('#fotocheckPersonal').val(data.strFotocheck)
        $('#strPersonalCampo1').val(data.strPersoCampo1)
        $('#strPersonalCampo2').val(data.strPersoCampo2)
        $('#strPersonalCampo3').val(data.strPersoCampo3)
        $('#strPersonalCampo4').val(data.strPersoCampo4)
        $('#strPersonalCampo5').val(data.strPersoCampo5)
        if (data.bitflSexo == true) {
            $('#chck_mas').iCheck('check')
        } else if (data.bitflSexo == false) {
            $('#chck_fem').iCheck('check')
        }
        if (data.bitFlActivo == false) {
            $('#checkEstadoEmpleado').html(`<input type="checkbox" class="js-switch"  id="estadoEmpleadoActivo" /> Activo`)
            switcheryLoad()
        } else if (data.bitFlActivo == true) {
            $('#checkEstadoEmpleado').html(`<input type="checkbox" class="js-switch" checked id="estadoEmpleadoActivo" /> Activo`)
            switcheryLoad()
        }
        $('#CboPais').val(data.intIdUbiSupPais)
        $('#fotocheckPersonal').val(data.strFotocheck)
        $('#txtIntidUbigeo').val(data.intIdUbigeo)
        $('#Mensaje_Info').css('color', 'green')
        if (data.imgFoto != null) {
            Imagen_GC(data.imgFoto, "Empleado");//añadido 26.03.2021
            //$('#VistaPrevia').html(`<img id="imgCarga"  src="/DirEmpleadosRuta/${data.imgFoto}" class="img-rounded img-logo-empleado"/>`)
            $('#txtRutaEmple').val(data.imgFoto)
        } else {
            $('#VistaPrevia').html(`<img id="imgCarga"  src="/images/person_logo.jpg" class="img-rounded img-logo-empleado"/>`)
            $('#txtRutaEmple').val('')
        }
        $('#nivelDeResponsabilidad').val(data.intIdTipoResp)
        $('#comboFiscalizacion').val(data.intIdTipFisc)
        $('#planillaEmpleado').val(data.intIdPlanilla)
        $('#cargoEmpleado').val(data.intIdCargo)
        $('#categoriaEmpleado').val(data.intIdCateg)
        $('#tipoDePersonal').val(data.intIdTiPers)
        $('#centroDeCosto').val(data.intIdCCosto)
        $('#codigoExterno').val(data.strCodExterior)
        $('#codigoDeSalud').val(data.strCodSalud)
        $('#codigoPensionista').val(data.strCodPensionista)
        $('#tgGrupoRegistro').val(data.intIdGrupo)

        if (data.bitContratoInd) {
            $('#contradoIndeterminado').iCheck('check')
        }
        if (data.bitFlfotomovil) {
            $('#cboTomarFoto').iCheck('check')
        }
        if (data.dttFecCese != '') {
            $('#fechaCeseChecbox').iCheck('check')
            $('#txtFechaCese').val(data.dttFecCese)
            $('#mativoDeCese').val(data.intIdMotiCese)
            $('#tgTgGrupoliq').val(data.intIdGrupoLiq)

            $('#tgTgGrupoliq').attr('disabled', false)
            $('#txtFechaCese').attr('disabled', false)
            $('#mativoDeCese').attr('disabled', false)
        }
        $('#reglaDeNegocio').val(data.intIdReglaNeg)
        $('#tgHorarioFijo').val(data.intIdHorario)
        if (data.bitActivarUsuario === true) {
            $('#activarUsuarioCbo').iCheck('check')
            $('#activarUsuarioAdmin').attr('disabled', false);
        } else {
            $('#activarUsuarioAdmin').attr('disabled', true);
            $('#cboPerfilAdmin').attr('disabled', true);
        }
        activaUsuario = data.bitActivarUsuario
        desactivaUsuario = data.bitActivarUsuario
        activarAdmin = data.bitPerfilAdmin

        if (data.bitPerfilAdmin === true) {
            $('#activarUsuarioAdmin').iCheck('check')
            $('#cboPerfilAdmin').attr('disabled', false);
        } else {
            $('#cboPerfilAdmin').attr('disabled', true);
        }

        $.post(
            '/Personal/ListarCombos',
            {
                intIdMenu: intIdMenu,
                strEntidad: 'TGPERFIL',
                intIdFiltroGrupo: 0,
                strGrupo: 'PERFILEMPLEADO',
                strSubGrupo: 'U',
            },
            response => {
                $('#cboPerfilAdmin').empty()
                $('#cboPerfilAdmin').append('<option value="0">Seleccione</option>')
                response.forEach(item => {
                    $('#cboPerfilAdmin').append('<option value="' + item.intidTipo + '">' + item.strDeTipo + '</option>')
                    if (item.intidTipo == data.intIdPerfil) {
                        $('#cboPerfilAdmin').val(item.intidTipo)
                    }
                })
            }
        )

        $.post(
            '/Personal/ListarCombos',
            {
                strEntidad: 'TGUBIGEO',
                intIdFiltroGrupo: INTIDSUPUBI,
                strGrupo: 'DIST',
                strSubGrupo: '',
            },
            response => {
                $('#CboDistrito').empty()
                $('#CboDistrito').attr('disabled', false)
                $('#CboDistrito').append('<option value="">Seleccione</option>')
                response.forEach(element => {
                    $('#CboDistrito').append('<option value="' + element.intidTipo + '" >' + element.strDeTipo + '</option>')
                    if (element.intidTipo == INTIDTPEVAL) {
                        $('#CboDistrito').val(element.intidTipo)
                        $('#txtUbigeo').val(element.strDeTipo)
                        $('#txtUbigeo').attr('disabled', true)
                    }
                })
            }
        )

        $.post(
            '/Personal/ListarCombos',
            {
                strEntidad: 'TGUBIGEO',
                intIdFiltroGrupo: INTIDSUPUBIREGION,
                strGrupo: 'REG',
                strSubGrupo: '',
            },
            response => {
                $('#CboProvincia').empty()
                $('#CboProvincia').attr('disabled', false)
                $('#CboProvincia').append('<option value="">Seleccione</option>')
                response.forEach(element => {
                    $('#CboProvincia').append('<option value="' + element.intidTipo + '" >' + element.strDeTipo + '</option>')
                    if (element.intidTipo == intIdProvinciaMostrar) {
                        $('#CboProvincia').val(element.intidTipo)
                    }
                })
            }
        )

        $.post(
            '/Personal/ListarCombos',
            {
                strEntidad: 'TGUBIGEO',
                intIdFiltroGrupo: data.intIdUbiSupPais,
                strGrupo: 'DEPART',
                strSubGrupo: '',
            },
            response => {
                $('#CboRegion').empty()
                $('#CboRegion').attr('disabled', false)
                $('#CboRegion').append('<option value="">Seleccione</option>')
                response.forEach(element => {
                    $('#CboRegion').append('<option value="' + element.intidTipo + '" >' + element.strDeTipo + '</option>')
                    if (element.intidTipo == intIdRegionMostrar) {
                        $('#CboRegion').val(element.intidTipo)
                    }
                })
            }
        )

        const dataCboEmpresa = await $.post('/Personal/ListarCombos', {
            intIdMenu: intIdMenu,
            strEntidad: 'TGPERSONAL',
            intIdFiltroGrupo: intIdUniOrgSupLista,
            strGrupo: 'LOCAL',
            strSubGrupo: 'U',
        })
        if (dataCboEmpresa.length) {
            $('#cboLocal').empty()
            $('#cboLocal').attr('disabled', false)
            $('#cboLocal').append('<option value="0">Seleccione</option>')
            dataCboEmpresa.forEach(element => {
                $('#cboLocal').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                if (intIdLocalLista == element.intidTipo) {
                    $("#cboLocal").val(element.intidTipo)
                }
            })
        }

        $.post('/Personal/ListarCombos', {
            strEntidad: 'TGPERFIL',
            intIdFiltroGrupo: intIdUniOrgLista,
            strGrupo: 'UNIORG2',
            strSubGrupo: 'U'
        }, response => {
            $('#unidadOrganizacionalCbo').empty()
            $('#unidadOrganizacionalCbo').attr('disabled', false)
            $('#unidadOrganizacionalCbo').append('<option value="0">Seleccione</option>')
            response.forEach(element => {
                $('#unidadOrganizacionalCbo').append('<option value="' + element.intidTipo + '" >' + element.strDeTipo + '</option>')
                if (intIdUniOrgLista == element.intidTipo) {
                    $('#unidadOrganizacionalCbo').val(element.intidTipo)
                }
            })
        })
    }



    //MARCA CON DNI lunes22 //HG 23.03.21 Marcación con DNI POST Carga los controles //<!-- AÑADIDO HG 23.03.21 HEBERT23-->
    const dataEmpleadoMarcaDni = await $.post('/Personal/ObtenerRegistroEmpleadoMarcaDni', { intIdPersonal: idItemEdit }, response => { })
    console.log(dataEmpleadoMarcaDni);
    if (dataEmpleado.length) {
        const data = dataEmpleadoMarcaDni[0]

        if (data.bitHabilitarMarcaDNI) {

            $('#CheckboxVigenciaMarcaConDni').iCheck('check');
            $('#txtFechaFinVegencia').val(data.dttFechaFinVegencia);
            $('#txtFechaInicioVegencia').val(data.dttFechaInicioVegencia);
        }

        if (data.bitHabilitarSupervisorCom) {

            $('#CheckboxHabilitarSupervisorDeCom').iCheck('check');

        }


    };

    $("#cboLocal").change(function () {
        let id = $(this).val()
        $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGMARCADORREGISTRO',
            intIdFiltroGrupo: id,
            strGrupo: 'TGMARCADOR',
            strSubGrupo: 'U',
        }, response => {
            $('#marcadorMultiple').empty()
            response.forEach(item => {
                $('#marcadorMultiple').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
           

            })
            })

             //FORM EDITAR HG 03.03.21 Añadido
        //if ($('#marcadorMultiple').val() == '') {

            new PNotify({
                title: '',
                text: 'Verificar si el Local seleccionado no tiene Marcador',
                type: 'info',
                delay: 1500,
                styling: 'bootstrap3',
                addclass: 'dark'
            });

        //}
    })

    $("#cboEmpresa").change(function () {

        var intidUniOrg = $(this).val()

        $.post(
            '/Personal/ListarCombos',
            {
                intIdMenu: 1,
                strEntidad: 'TGPERSONAL',
                intIdFiltroGrupo: intidUniOrg,
                strGrupo: 'LOCAL',
                strSubGrupo: 'U'
            },
            response => {
                $('#cboLocal').empty()
                $('#cboLocal').attr('disabled', false)
                $('#cboLocal').append('<option value="0">Seleccione</option>')
                response.forEach(element => {
                    $('#cboLocal').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                })
            })

        $.post(
            '/Personal/ListarComboGlobal',
            {
                intIdMenu: 1,
                strEntidad: 'TGCARGOREGISTRO',
                intIdFiltroGrupo: intidUniOrg,
                strGrupo: 'TGCARGO',
                strSubGrupo: 'U'
            },
            response => {
                $('#cargoEmpleado').empty()
                $('#cargoEmpleado').append('<option value="0">Seleccione</option>')
                response.forEach(element => {
                    $('#cargoEmpleado').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                })
            })

        $.post(
            '/Personal/ListarComboGlobal',
            {
                intIdMenu: 1,
                strEntidad: 'TGPLANILLAREGISTRO',
                intIdFiltroGrupo: intidUniOrg,
                strGrupo: 'TGPLANILLA',
                strSubGrupo: 'U'
            },
            response => {
                $('#planillaEmpleado').empty()
                $('#planillaEmpleado').append('<option value="0">Seleccione</option>')
                response.forEach(element => {
                    $('#planillaEmpleado').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                })
            })

        $.post(
            '/Personal/ListarComboGlobal',
            {
                intIdMenu: 1,
                strEntidad: 'TGCATEGORIAREGISTROEMPLEADO',
                intIdFiltroGrupo: intidUniOrg,
                strGrupo: 'TGCATEGORIAEMPLEADO',
                strSubGrupo: 'U'
            },
            response => {
                $('#categoriaEmpleado').empty()
                $('#categoriaEmpleado').append('<option value="0">Seleccione</option>')
                response.forEach(element => {
                    $('#categoriaEmpleado').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                })
            })

        $.post(
            '/Personal/ListarComboGlobal',
            {
                intIdMenu: 1,
                strEntidad: 'TGTIPOPERSONREGISTRO',
                intIdFiltroGrupo: intidUniOrg,
                strGrupo: 'TGTIPOPERSON',
                strSubGrupo: 'U'
            },
            response => {
                $('#tipoDePersonal').empty()
                $('#tipoDePersonal').append('<option value="0">Seleccione</option>')
                response.forEach(element => {
                    $('#tipoDePersonal').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                })
            })

        $.post(
            '/Personal/ListarComboGlobal',
            {
                intIdMenu: 1,
                strEntidad: 'TGGRUPOREGISTRO',
                intIdFiltroGrupo: intidUniOrg,
                strGrupo: 'TGGRUPO',
                strSubGrupo: 'U'
            },
            response => {
                $('#tgGrupoRegistro').empty()
                $('#tgGrupoRegistro').append('<option value="0">Seleccione</option>')
                response.forEach(element => {
                    $('#tgGrupoRegistro').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                })
            })

        $.post(
            '/Personal/ListarComboGlobal',
            {
                intIdMenu: 1,
                strEntidad: 'TGCCOSTOREGISTRO',
                intIdFiltroGrupo: intidUniOrg,
                strGrupo: 'TGCCOSTO',
                strSubGrupo: 'U'
            },
            response => {
                $('#centroDeCosto').empty()
                $('#centroDeCosto').append('<option value="0">Seleccione</option>')
                response.forEach(element => {
                    $('#centroDeCosto').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                })
            })

        $('#marcadorMultiple').empty()

    })

    // intIdJerOrgLista
    $(`#loaderEditPersonal`).hide()
    $('#wizard .form-hide-empleado').show()
    $('#btn-save-change-empleado').hide()
    $('#btn-editar-empleado').show()
    $('.form-hide-empleado').show()

    $('#cboDependencia').change(function () {
        let idDependencia = $(this).val()
        if (idDependencia == '0') {
            messageResponseMix({ type: 'info', message: 'Seleccione una Dependencia ' }, 'Registro Empleado')
            return false
        }
        $.post('/Personal/ListarCombos', {
            strEntidad: 'TGPERFIL',
            intIdFiltroGrupo: idDependencia,
            strGrupo: 'UNIORG',
            strSubGrupo: ''
        }, response => {
            $('#unidadOrganizacionalCbo').empty()
            $('#unidadOrganizacionalCbo').attr('disabled', false)
            $('#unidadOrganizacionalCbo').append('<option value="0">Seleccione</option>')
            response.forEach(element => {
                $('#unidadOrganizacionalCbo').append('<option value="' + element.intidTipo + '" >' + element.strDeTipo + '</option>')
            })
        })
    })
    $('#fechaCeseChecbox').on('ifChanged', function () {
        if ($('#fechaCeseChecbox').is(':checked') == true) {
            $('#tgTgGrupoliq').attr('disabled', false)
            $('#txtFechaCese').attr('disabled', false)
            $('#mativoDeCese').attr('disabled', false)
        } else if ($('#fechaCeseChecbox').is(':checked') == false) {
            $('#tgTgGrupoliq').attr('disabled', true)
            $('#tgTgGrupoliq').val(0)
            $('#txtFechaCese').attr('disabled', true)
            $('#txtFechaCese').val("")
            $('#mativoDeCese').attr('disabled', true)
            $('#mativoDeCese').val("")
        }
    })

    $("#planillaEmpleado").change(function () {
        let id = $(this).val()
        $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGGRUPOLIQREGISTRO',
            intIdFiltroGrupo: id,
            strGrupo: 'TGGRUPOLIQ',
            strSubGrupo: 'U',
        },
            (response) => {
                $('#tgTgGrupoliq').empty()
                $('#tgTgGrupoliq').append('<option value="0">Seleccione</option>')
                response.forEach(item => {
                    $('#tgTgGrupoliq').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
                })
            }
        )
    })

    $('#activarUsuarioCbo').on('ifChanged', function () {
        if ($('#activarUsuarioCbo').is(':checked') == true) {
            $('#activarUsuarioAdmin').attr('disabled', false)
        } else if ($('#activarUsuarioCbo').is(':checked') == false) {
            $('#activarUsuarioAdmin').iCheck('uncheck')
            $('#activarUsuarioAdmin').attr('disabled', true)
        }
        $('#cboPerfilAdmin').attr('disabled', true)
        $('#cboPerfilAdmin').val(0)
    })

    $('#activarUsuarioAdmin').on('ifChanged', function () {
        if ($('#activarUsuarioAdmin').is(':checked') == true) {
            $('#cboPerfilAdmin').attr('disabled', false)
        } else if ($('#activarUsuarioAdmin').is(':checked') == false) {
            $('#cboPerfilAdmin').attr('disabled', true)
            $('#cboPerfilAdmin').attr('disabled', true)
            $('#cboPerfilAdmin').val(0)
        }
    })


    $('#CboPais').on('change', function () {
        var Valxpais = $('#CboPais').val()

        $.post(
            '/Personal/ListarCombos',
            {
                intIdMenu: intIdMenu,
                strEntidad: 'TGUBIGEO',
                intIdFiltroGrupo: Valxpais,
                strGrupo: 'DEPART',
                strSubGrupo: '',
            },
            response => {
                $('#CboRegion').empty()
                $('#CboRegion').attr('disabled', false)
                $('#CboRegion').append('<option value="">Seleccione</option>')

                response.forEach(element => {
                    $('#CboRegion').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                })
            }
        )
    })

    $('#CboRegion').on('change', function () {
        var Valxpais = $('#CboRegion').val()
        $.post(
            '/Personal/ListarCombos',
            {
                intIdMenu: intIdMenu,
                strEntidad: 'TGUBIGEO',
                intIdFiltroGrupo: Valxpais,
                strGrupo: 'REG',
                strSubGrupo: '',
            },
            response => {
                $('#CboProvincia').empty()
                $('#CboProvincia').attr('disabled', false)
                $('#CboProvincia').append('<option value="">Seleccione</option>')

                response.forEach(element => {
                    $('#CboProvincia').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                })
            }
        )
    })

    $('#CboProvincia').on('change', function () {
        var Valxpais = $('#CboProvincia').val()
        $.post(
            '/Personal/ListarCombos',
            {
                intIdMenu: intIdMenu,
                strEntidad: 'TGUBIGEO',
                intIdFiltroGrupo: Valxpais,
                strGrupo: 'DIST',
                strSubGrupo: '',
            },
            response => {
                $('#CboDistrito').empty()
                $('#CboDistrito').attr('disabled', false)
                $('#CboDistrito').append('<option value="">Seleccione</option>')
                response.forEach(element => {
                    $('#CboDistrito').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                })
            }
        )
    })

    if (typeof _vartablaGeo !== 'undefined') {
        _vartablaGeo.destroy();
    }

    _vartablaGeo = $('#tableGeo').DataTable({
        searching: false,
        paging: false,
        info: false,
        ordering: false,
        language: {
            lengthMenu: 'Mostrar _MENU_ Filas',
            info: '(*) Las Casillas en X no se grabarán',
            infoEmpty: 'No hay Items para mostrar',
            search: '',
            sSearchPlaceholder: '',
            zeroRecords: '',
            infoFiltered: '',
            paginate: {
                previous: 'Anterior',
                next: 'Siguiente'
            }
        },
    });

    $("#txtNumGeo").val(1)

    $("#tableGeoBody").empty();

    const datacoordenadas = await $.post('/Personal/getcoordenadaspersonal', {
        intIdPersonal: idItemEdit
    })
    console.log(datacoordenadas)
    if (datacoordenadas.length) {
        datacoordenadas.forEach(e => {

            var btnCoord = ""
            if (e.bitFlGeoArea) {
                btnCoord = `<span class="btn btn-success btn-xs btnAgregarCoor"> <i class="fa fa-plus"></i></span>`
            }

            $("#tableGeoBody").append(`
            <tr class="GeoDetalle">
            <td class="intGeoArea">${e.intIdGeoArea}</td>
            <td class="geo">${e.strCoord}</td>
            <td class="geoDir">${e.strDireccionCoord}</td>
            <td><span class="btn btn-danger btn-xs btnQuitarCoor"> quitar </span>${btnCoord}</td>
            <td class="geoArea" hidden>${e.bitFlGeoArea}</td>
            </tr>
        `)
        })
    }


    $('#cboGeoArea').on('ifChanged', function () {
        if ($("#cboGeoArea").is(':checked')) {
            //$("#txtNumGeo").attr("disabled", false)
            $("#btnNuevaGeoArea").attr("disabled", false)
            getIndexGeo()
        } else {
            //$("#txtNumGeo").attr("disabled", true)
            $("#btnNuevaGeoArea").attr("disabled", true)
        }
    })

    $("#btn-limpiar-Intrevalos").on("click", function () {
        $("#txtCoor").val("")
        $("#txtNumGeo").val(1)
        $("#txtDireccionCoor").val("")
        $("#cboGeoArea").iCheck('unCheck')
    })

    $("#btn-clear-Geo").on("click", function () {
        $("#tableGeoBody").empty();
    })

    $("#btnNuevaGeoArea").on("click", function () {
        getIndexGeo()
    })

    function getIndexGeo() {
        $("#txtCoor").val("")
        $("#txtDireccionCoor").val("")
        if ($("#tableGeoBody tr").length == 0) {
            $("#txtNumGeo").val(1)
        } else {
            var index = 0
            $("#tableGeoBody tr").each(x => {
                var dato = $($("#tableGeoBody tr")[x]).find(".intGeoArea").html()
                if (dato != "") {
                    index = parseInt(dato)
                }
            })
            $("#txtNumGeo").val(index + 1)
        }
    }

    $("#btn-add-Geo").on("click", function () {
        var Geo = $("#txtCoor").val()
        var geoArea = false;
        var dir = $("#txtDireccionCoor").val()
        $("#txtCoor").val("")
        $("#txtDireccionCoor").val("")
        var index = ""
        var btnCoord = ""
        if ($("#cboGeoArea").is(':checked')) {
            geoArea = true;
            index = $("#txtNumGeo").val()
            btnCoord = `<span class="btn btn-success btn-xs btnAgregarCoor"> <i class="fa fa-plus"></i> </span>`
        }

        $("#tableGeoBody").append(`
            <tr class="GeoDetalle">
            <td class="intGeoArea">${index}</td>
            <td class="geo">${Geo}</td>
            <td class="geoDir">${dir}</td>
            <td><span class="btn btn-danger btn-xs btnQuitarCoor"> quitar </span>${btnCoord}</td>
            <td class="geoArea" hidden>${geoArea}</td>
            </tr>
        `)



        $(".btnAgregarCoor").on("click", function () {
            var index = parseInt($(this).parents("tr").find(".intGeoArea").html())
            $("#txtNumGeo").val(index)
            $("#cboGeoArea").iCheck('Check')
        })


    })

}

$(document).on("click", ".btnAgregarCoor", function () {
    var index = parseInt($(this).parents("tr").find(".intGeoArea").html())
    $("#cboGeoArea").iCheck('Check')
    $("#txtNumGeo").val(index)
})

$(document).on("click", ".btnQuitarCoor", function () {

    var GeoArea = $(this).parents("tr").find(".intGeoArea").html()
    var elemento = this;
    if (GeoArea == "" || GeoArea == "0") {
        $(this).parents("tr").remove()
    } else {
        if ($("#tableGeoBody").find(".intGeoArea:contains(" + GeoArea + ")").length == 2) {
            swal({
                title: "Eliminar Coordenada",
                text: "¿Está seguro de eliminar la Coordenada?, Si lo hace esta se volvera una coordenada individual",
                type: "warning",
                showCancelButton: true,
                confirmButtonText: "Sí, eliminar",
                cancelButtonText: "No, cancelar",
            }).then(function (isConfirm) {
                swal("Eliminado", "Se elimino la coordenada", "success");
                $(elemento).parents("tr").remove()
                var tr = $("#tableGeoBody").find(".intGeoArea:contains(" + GeoArea + ")").parent("tr")
                tr.find(".btnAgregarCoor").remove()
                tr.find(".geoArea").html("false")
                $("#tableGeoBody").find(".intGeoArea:contains(" + GeoArea + ")").html("")
            }, function (dismiss) {
                swal("Cancelado", "La Operación fue cancelada", "error");
            });
        } else {
            $(this).parents("tr").remove()
        }
    }
})

function eliminarEmpleado(idItemDelete, textInfo = '¿Esta seguro de eliminar el registro?') {
    const { intIdMenu, tituloEliminarRegistro } = configEmpleadoInicial()
    swal({
        title: tituloEliminarRegistro,
        text: textInfo,
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sí, eliminar',
        cancelButtonText: 'No, cancelar',
    })
        .then(isConfirm => {
            validarSession()
            $.post('/Personal/EliminarEmpleado', { intIdMenu: intIdMenu, intIdPersonal: idItemDelete }, respo => {

                if (respo.type !== '') {
                    var tipo = 'Eliminado!';
                    if (respo.type === 'error') {
                        tipo = 'NO SE PUEDE ELIMINAR EL REGISTRO';
                    }
                    if (respo.type === 'success') {
                        traerDatosEmpleados()
                        $('.form-hide-empleado').hide()
                        $('#btn-save-change-empleado').show()
                        $('#btn-editar-empleado').hide()
                    }
                    swal(tipo, respo.message, respo.type);
                }
            })
        })
        .catch(err => {
            swal('Cancelado', 'La Operación fue cancelada', 'error')
        })
}

function ValidateEmail(email) {
    const mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/
    if (email.match(mailformat)) {
        return true
    }
    return false
}

function getValueControl(idControl) {
    let data = $(idControl).val()
    if (data.length > 0) {
        //data.trim()
    }
    return data
}

function focusControl(idControl) {
    return $(idControl).focus()
}


function registrarOActualizar(tipoOperacionPass) {
    const { intIdMenu, formatoFecha } = configEmpleadoInicial()
    let titleToast = 'Nuevo Empleado'
    if (tipoOperacionPass == 2) {
        titleToast = 'Editar Empleado'
    }

    let cboResponsableInmediato = $('#cboResponsableInmediato').val()
    let cboResponsableContractual = $('#cboResponsableContractual').val()

    const otrosCorreosData = $.map($('#TagEmailContainer .tagsinput span span'), function (e, i) {
        return $(e)
            .text()
            .trim()
    })
    const otrosTelefonosData = $.map($('#tagTelefonosContainer .tagsinput span span'), function (e, i) {
        return $(e)
            .text()
            .trim()
    })

    const otrosCorreos = otrosCorreosData.filter(item => {
        return ValidateEmail(item) === true
    })

    let generoEstado = false
    let contradoIndeterminado = false
    let estadoActivoPersonal = false
    let activarUsuarioCbo = false
    let usuarioAdmin = false
    let bitFlfotomovil = false
    let intIdPerfil = 0


    let estadoHabilitarMarcaDNI = false
    let estadoHabilitarSupervisorDeCom = false


    if ($('.radioMasculino').is(':checked')) {
        generoEstado = true
    }

    if ($('#contradoIndeterminado').is(':checked')) {
        contradoIndeterminado = true
    }

    if ($('#estadoEmpleadoActivo').is(':checked')) {
        estadoActivoPersonal = true
    }

    if ($('#activarUsuarioCbo').is(':checked')) {
        activarUsuarioCbo = true
    }

    if ($('#activarUsuarioAdmin').is(':checked')) {
        usuarioAdmin = true
        intIdPerfil = $('#cboPerfilAdmin').val()
    }


    if ($('#cboTomarFoto').is(':checked')) {
        bitFlfotomovil = true
    }


    var dttFechaInicioVegencia_ = '';
    var dttFechaFinVegencia_ = '';


    //Añadido HG 19.03.21 - Para Toma de Consumos con DNI 
    if ($('#CheckboxVigenciaMarcaConDni').is(':checked')) {

        estadoHabilitarMarcaDNI = true
        dttFechaInicioVegencia_ = $('#txtFechaInicioVegencia').val();
        dttFechaFinVegencia_ = $('#txtFechaFinVegencia').val();

    }

    //<!-- AÑADIDO HG 23.03.21 HEBERT23-->
    if ($('#CheckboxHabilitarSupervisorDeCom').is(':checked')) {

        estadoHabilitarSupervisorDeCom = true
    }


    if (getValueControl('#TipoDoc') == '0' && $("#TipoDoc option").length > 1) {
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Tipo Documento)' }, titleToast)
        focusControl('#TipoDoc')
        return false
    } else if (getValueControl('#txtNumDoc').length < 1) {
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Número Documento)' }, titleToast)
        focusControl('#txtNumDoc')
        return false
    } else if (getValueControl('#txtApePat').length < 1) {
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Apellido Paterno)' }, titleToast)
        focusControl('#txtApePat')
        return false
    } else if (getValueControl('#txtApeMat').length < 1) {
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Apellido Materno)' }, titleToast)
        focusControl('#txtApeMat')
        return false
    } else if (getValueControl('#txtNombres').length < 1) {
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Nombres)' }, titleToast)
        focusControl('#txtNombres')
        return false
    } else if (getValueControl('#txtFechaNac').length < 1) {
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Fecha de Nacimiento)' }, titleToast)
        focusControl('#txtFechaNac')
        return false
    } else if (!$("input[name='generoEmpleado']:radio").is(':checked')) {
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Género)' }, titleToast)
        return false
    } else if (getValueControl('#Email_Emple').length < 1 && !ValidateEmail(getValueControl('#Email_Emple'))) {
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Email)' }, titleToast)
        focusControl('#Email_Emple')
        return false
    } else if (getValueControl('#celularEmpleado').length < 1) {
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Celular)' }, titleToast)
        focusControl('#celularEmpleado')
        return false
    } else if (getValueControl('#fotocheckPersonal').length < 1) {
        $('#wizard').smartWizard('goToStep', 2)
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Fotocheck)' }, titleToast)
        focusControl('#fotocheckPersonal')
        return false
    } else if (getValueControl('#txtFechaAdmi').length < 1) {
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Fecha de Admisión)' }, titleToast)
        focusControl('#txtFechaAdmi')
        return false
    } else if (getValueControl('#marcadorMultiple').length <= 0) {
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Marcador)' }, titleToast)
        focusControl('#marcadorMultiple')
        return false
    }

    let marcadorMultiple = getValueControl('#marcadorMultiple')
    let otrosCorreosInsert = []
    otrosCorreosInsert.push({
        intIdPerCorr: 0,
        intIdPersonal: 0,
        strCorreo: getValueControl('#Email_Emple'),
        bitFlPrincipal: true,
        bitFlEliminado: false,
    })
    otrosCorreos.forEach(item => {
        otrosCorreosInsert.push({
            intIdPerCorr: 0,
            intIdPersonal: 0,
            strCorreo: item,
            bitFlPrincipal: false,
            bitFlEliminado: false,
        })
    })

    let otrosTelefonosInsert = []
    otrosTelefonosInsert.push({
        intIdPerTele: 0,
        intIdPersonal: 0,
        strNumero: getValueControl('#celularEmpleado'),
        bitFlPrincipal: true,
        strAnexo: ' ',
        bitFlEliminado: false,
    })
    otrosTelefonosData.forEach(item => {
        otrosTelefonosInsert.push({
            intIdPerTele: 0,
            intIdPersonal: 0,
            strNumero: item,
            bitFlPrincipal: false,
            strAnexo: '',
            bitFlEliminado: false,
        })
    })

    let otrosMarcadoresInsert = []
    marcadorMultiple.forEach(item => {
        otrosMarcadoresInsert.push({
            intIdPerMarc: false,
            intIdPersonal: 0,
            intIdSoft: 0,
            intIdMarcador: item,
            dttFecAsig: moment().format(formatoFecha),
            bitFlEliminado: false,
        })
    })

    let otrosResponsabilidadInsert = []

    if (cboResponsableInmediato != 0 && cboResponsableInmediato != null) {
        otrosResponsabilidadInsert.push({
            intIdPerRespDet: 0,
            intIdPersonal: 0,
            intIdPerResp: cboResponsableInmediato,
            intIdTipoResp: 9,
            bitVigente: true,
            bitFlEliminado: false,
            intIdUsuarReg: 1,
        })
    }

    if (cboResponsableContractual != 0 && cboResponsableContractual != null) {
        otrosResponsabilidadInsert.push({
            intIdPerRespDet: 0,
            intIdPersonal: 0,
            intIdPerResp: cboResponsableContractual,
            intIdTipoResp: 10,
            bitVigente: true,
            bitFlEliminado: false,
            intIdUsuarReg: 1,
        })
    }

    let imagePersonal = null
    let numRegistroPersonalHideen = '000'
    let strCoPersonalRegistro = '000'
    let subsidioPorAlimentacion = false
    let liniaDeCreditos = false

    if ($('#txtRutaEmple').val() != '') {
        imagePersonal = $('#txtRutaEmple').val()
    }

    if ($('#codPersonalHideen').val() != '') {
        strCoPersonalRegistro = $('#codPersonalHideen').val()
    }

    if ($('#numRegistroPersonalHideen').val() != '') {
        numRegistroPersonalHideen = $('#numRegistroPersonalHideen').val()
    }

    if ($('#subsidioPorAlimentacion').is(':checked')) {
        subsidioPorAlimentacion = true
    }
    if ($('#liniaDeCreditos').is(':checked')) {
        liniaDeCreditos = true
    }

    var comboFiscalizacion = $('#comboFiscalizacion').val()
    if (comboFiscalizacion == 0 && $("#comboFiscalizacion option").length > 1) {
        new PNotify({
            title: titleToast,
            text: 'Seleccione una Fizcalización',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }

    var nivelDeResponsabilidad = $('#nivelDeResponsabilidad').val()
    if (nivelDeResponsabilidad == 0 && $("#nivelDeResponsabilidad option").length > 1) {
        new PNotify({
            title: titleToast,
            text: 'Seleccione un Nivel de Responsabilidad',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }

    var unidadOrganizacionalCbo = $('#unidadOrganizacionalCbo').val()
    if (unidadOrganizacionalCbo == 0 && $("#unidadOrganizacionalCbo option").length > 1) {
        new PNotify({
            title: titleToast,
            text: 'Seleccione una Unidad Organizacional',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }

    var cargoEmpleado = $('#cargoEmpleado').val()
    if (cargoEmpleado == 0 && $("#cargoEmpleado option").length > 1) {
        new PNotify({
            title: titleToast,
            text: 'Seleccione un Cargo',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }

    var planillaEmpleado = $('#planillaEmpleado').val()
    if (planillaEmpleado == 0 && $("#planillaEmpleado option").length > 1) {
        new PNotify({
            title: titleToast,
            text: 'Seleccione una Planilla',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }

    var categoriaEmpleado = $('#categoriaEmpleado').val()
    //if (categoriaEmpleado == 0 && $("#categoriaEmpleado option").length > 1) {
    //    new PNotify({
    //        title: titleToast,
    //        text: 'Seleccione una Categoria',
    //        type: 'info',
    //        delay: 3000,
    //        styling: 'bootstrap3',
    //        addclass: 'dark'
    //    });

    //    return;
    //}

    var tipoDePersonal = $('#tipoDePersonal').val()
    //if (tipoDePersonal == 0 && $("#tipoDePersonal option").length > 1) {
    //    new PNotify({
    //        title: titleToast,
    //        text: 'Seleccione un Tipo de Personal',
    //        type: 'info',
    //        delay: 3000,
    //        styling: 'bootstrap3',
    //        addclass: 'dark'
    //    });

    //    return;
    //}

    var tgGrupoRegistro = $('#tgGrupoRegistro').val()
    //if (tgGrupoRegistro == 0 && $("#tgGrupoRegistro option").length > 1) {
    //    new PNotify({
    //        title: titleToast,
    //        text: 'Seleccione un Grupo',
    //        type: 'info',
    //        delay: 3000,
    //        styling: 'bootstrap3',
    //        addclass: 'dark'
    //    });

    //    return;
    //}

    var centroDeCosto = $('#centroDeCosto').val()
    //if (centroDeCosto == 0 && $("#centroDeCosto option").length > 1) {
    //    new PNotify({
    //        title: titleToast,
    //        text: 'Seleccione un Centro de Costo',
    //        type: 'info',
    //        delay: 3000,
    //        styling: 'bootstrap3',
    //        addclass: 'dark'
    //    });

    //    return;
    //}



    //RECOGER LAS FECHAS DE LOS CONTROLES Y USAR EL MOMENT()
    var txtFechaInicioVegencia_ = $('#txtFechaInicioVegencia').val();
    var txtFechaInicioVegencia_mas_uno = moment(txtFechaInicioVegencia_).add('m', 60).format('YYYY-MM-DD HH:mm:ss');
    var txtFechaFinVegencia_ = $('#txtFechaFinVegencia').val();


    //QUE LA FECHA DE INICIO NO SEA MAYOR QUE LA HORA FINAL
    if ($('#CheckboxVigenciaMarcaConDni').is(':checked') == true) {

        if (txtFechaInicioVegencia_ == '' || txtFechaFinVegencia_ == '') {

            new PNotify({
                title: 'Habilitar Marcación con DNI',
                text: 'Revisar las fechas de vigencia',
                type: 'info',
                delay: 3000,
                styling: 'bootstrap3',
                addclass: 'dark'
            });
            return;
        }

    }


    //QUE LA FECHA DE INICIO NO SEA MAYOR QUE LA HORA FINAL
    if (moment(txtFechaInicioVegencia_).isAfter(txtFechaFinVegencia_)) {

        new PNotify({
            title: 'Habilitar Marcación con DNI',
            text: 'La fecha de inicio es mayor que la fecha fin',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }


    //FECHA Y HORA SON IGUALES
    if (moment(txtFechaInicioVegencia_).isSame(txtFechaFinVegencia_)) {

        new PNotify({
            title: 'Habilitar Marcación con DNI',
            text: 'La fecha de inicio no debe ser igual a la fecha fin',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }


    //QUE LA HORA FINAL SEA UNA HORA MAYOR AL INICIAL
    if (moment(txtFechaInicioVegencia_mas_uno).isAfter(txtFechaFinVegencia_)) {

        new PNotify({
            title: 'Habilitar Marcación con DNI',
            text: 'El tiempo de la Vigencia tiene es mínimo una hora',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }




    var reglaDeNegocio = $('#reglaDeNegocio').val()
    if (reglaDeNegocio == 0 && $("#reglaDeNegocio option").length > 1) {
        new PNotify({
            title: titleToast,
            text: 'Seleccione una Regla de Negocio',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }

    var tgHorarioFijo = $('#tgHorarioFijo').val()
    if (tgHorarioFijo == 0 && $("#tgHorarioFijo option").length > 1) {
        new PNotify({
            title: titleToast,
            text: 'Seleccione un Horario Fijo',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }

    var intIdUniOrgSup = $('#cboEmpresa').val()
    if (intIdUniOrgSup == 0 && $("#cboEmpresa option").length > 1) {
        new PNotify({
            title: titleToast,
            text: 'Seleccione una Empresa',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }

    var intIdLocal = $('#cboLocal').val()
    if (intIdLocal == 0 && $("#cboLocal option").length > 1) {
        new PNotify({
            title: titleToast,
            text: 'Seleccione un Local',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }

    if (usuarioAdmin && intIdPerfil == 0) {
        new PNotify({
            title: titleToast,
            text: 'Seleccione un Perfil Administrador',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }


    let geoDetalle = []
    if ($(".GeoDetalle").length > 0) {
        $(".GeoDetalle").each(function (index) {
            var geoArea = $(this).find(".geoArea").html()
            var coor = $(this).find(".geo").html()
            var geoDir = $(this).find(".geoDir").html()
            var intGeo = $(this).find(".intGeoArea").html()

            geoDetalle.push({
                intIdPersonal: $('#intIdPersonalReg').val(),
                strCoord: coor,
                strDireccionCoord: geoDir,
                bitFlGeoArea: geoArea,
                intIdGeoArea: intGeo
            })

        });
    }

    if (activaUsuario == false && activarUsuarioCbo == true) {
        activaUsuario = true
    } else {
        activaUsuario = false
    }

    if (desactivaUsuario == true && activarUsuarioCbo == false) {
        desactivaUsuario = true
    } else {
        desactivaUsuario = false
    }

    if (activarAdmin != usuarioAdmin) {
        activarAdmin = true
    } else {
        activarAdmin = false
    }

    const params = {
        intIdMenu: intIdMenu,
        ObjPersonal: {
            intIdPersonal: $('#intIdPersonalReg').val(),
            strCoPersonal: strCoPersonalRegistro,
            strNumRegis: numRegistroPersonalHideen,
            strFotocheck: $('#fotocheckPersonal').val(),
            intIdTipDoc: $('#TipoDoc').val(),
            strNumDoc: $('#txtNumDoc').val(),
            strNombres: $('#txtNombres').val(),
            strApePaterno: $('#txtApePat').val(),
            strApeMaterno: $('#txtApeMat').val(),
            dttFecNacim: $('#txtFechaNac').val(),
            bitflSexo: generoEstado,
            intIdTipoVia: $('#TipVia').val() != '0' ? $('#TipVia').val() : null,
            strDireccion: $('#TXTTIPVIA').val().length ? $('#TXTTIPVIA').val() : null,
            intIdUbigeo: $('#txtIntidUbigeo').val() != '0' ? $('#txtIntidUbigeo').val() : null,
            imgFoto: imagePersonal,
            intIdUniOrg: unidadOrganizacionalCbo,
            intIdPlanilla: planillaEmpleado,
            intIdCargo: cargoEmpleado,
            intIdCateg: categoriaEmpleado,
            intIdTiPers: tipoDePersonal,
            intIdGrupo: tgGrupoRegistro,
            intIdCCosto: centroDeCosto,
            intIdTipFisc: comboFiscalizacion,
            intIdTipoResp: nivelDeResponsabilidad,
            bitContratoInd: contradoIndeterminado,
            dttFecAdmin: $('#txtFechaAdmi').val(),
            dttFecCese: $('#txtFechaCese').val() != '' || $('#txtFechaCese').val() != ' ' ? $('#txtFechaCese').val() : null, //'09/11/2021', //tgTgGrupoliq
            intIdMotiCese: $('#mativoDeCese').val() != '0' ? $('#mativoDeCese').val() : null,
            intIdGrupoLiq: $('#tgTgGrupoliq').val() != '0' ? $('#tgTgGrupoliq').val() : null,
            bitFlSubsidio: null,
            bitFlLinCred: false,
            strPersoCampo1: $('#strPersonalCampo1').val(),
            strPersoCampo2: $('#strPersonalCampo2').val(),
            strPersoCampo3: $('#strPersonalCampo3').val(),
            strPersoCampo4: $('#strPersonalCampo4').val(),
            strPersoCampo5: $('#strPersonalCampo5').val(),
            bitFlActivo: estadoActivoPersonal,

            strCodExterior: $('#codigoExterno').val(),
            strCodPensionista: $('#codigoPensionista').val(),
            strCodSalud: $('#codigoDeSalud').val(),
            bitSubsidioAlimentacion: subsidioPorAlimentacion,
            bitLineaCredito: liniaDeCreditos,
            intIdReglaNeg: reglaDeNegocio != '0' ? reglaDeNegocio : null,
            intIdHorario: tgHorarioFijo != '0' ? tgHorarioFijo : null,
            bitActivarUsuario: activarUsuarioCbo,
            intIdUniOrgSup,
            intIdLocal,
            bitPerfilAdmin: usuarioAdmin,
            intIdPerfil,
            bitFlfotomovil
        },

        //Inicio Añadido un Nuevo Objeto ObjMarcaConDni HG 19.02.21 ====================================================================
        ObjMarcaConDni: {

            bitHabilitarMarcaDNI: estadoHabilitarMarcaDNI,
            dttFechaInicioVegencia: dttFechaInicioVegencia_,                //Añadido HG 19.03.21 - Para Toma de Consumos con DNI
            dttFechaFinVegencia: dttFechaFinVegencia_,                      //Añadido HG 19.03.21 - Para Toma de Consumos con DNI
            bitHabilitarSupervisorCom: estadoHabilitarSupervisorDeCom,

        },
        //Fin de Añadido un Nuevo Objeto ObjMarcaConDni HG 19.02.21 ====================================================================



        listaDetallesPersonalCorreos: otrosCorreosInsert,
        listaDetallesPersonalTelefonos: otrosTelefonosInsert,
        listaDetallesPersonalResponsabilidad: otrosResponsabilidadInsert,
        listaDetallesPersonalMarcadores: otrosMarcadoresInsert,
        intTipoOperacion: tipoOperacionPass,
        listaCoor: geoDetalle,
        activaUsuario,
        desactivaUsuario,
        activarAdmin
    }

    console.log(params)
    $.post('/Personal/RegistrarNuevoEmpleado', params, respo => {
        if (tipoOperacionPass == 1) {
            messageResponseMix(respo, 'Nuevo Empleado')
        } else {
            messageResponseMix(respo, 'Editar Empleado')
        }

        if (respo.extramsg != null && respo.extramsg .includes("correo")) {
            new PNotify({
                title: 'Info Correo',
                text: respo.extramsg,
                type: 'info',
                delay: 3000,
                styling: 'bootstrap3',
                addclass: 'dark'
            });
        }

        if (respo.type === 'success') {
            $('.form-hide-empleado .x_content').empty()
            $('.form-hide-empleado .x_content').html('')
            $('.form-hide-empleado').hide()
            traerDatosEmpleados()
        }
    })
}

$('#btn-save-change-empleado').on('click', function () {
    validarSession()
    const titleToast = 'Nuevo Empleado'
    if (($('#reglaDeNegocio option').length = 1 || $('#reglaDeNegocio').val() != 0) && ($('#tgHorarioFijo option').length = 1 || $('#tgHorarioFijo').val() != 0) && getValueControl('#marcadorMultiple').length >= 1) {
        registrarOActualizar(1)
    } else {
        messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
    }
})

$('#btn-editar-empleado').on('click', function () {
    validarSession()
    const titleToast = 'Editar Empleado'
    if (($('#reglaDeNegocio option').length = 1 || $('#reglaDeNegocio').val() != 0) && ($('#tgHorarioFijo option').length = 1 || $('#tgHorarioFijo').val() != 0) && getValueControl('#marcadorMultiple').length >= 1) {
        registrarOActualizar(2)
    } else {
        messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
    }
})

$('#btn-cancel-empleado').on('click', function () {
    validarSession()
    $('.form-hide-empleado').hide()
    $('#btn-save-change-empleado').show()
    $('#btn-editar-empleado').hide()
})

$(`#TablaPersonal tbody`).on('click', `tr button.btn-edit`, function () {
    validarSession()
    let intIdPersonal = $(this).attr('dataid')
    editarEmpleado(intIdPersonal)
})

$(`#TablaPersonal tbody`).on('click', `tr button.btn-delete`, function () {
    validarSession()
    let intIdPersonal = $(this).attr('dataid')
    let nombreEmpleado = $(this).attr('des_data')
    eliminarEmpleado(intIdPersonal, `¿Está seguro de eliminar el empleado "${nombreEmpleado}"?`)
})

$(`#TablaPersonal tbody`).on('click', `tr button.btn-resend`, function () {
    validarSession()
    let intIdPersonal = parseInt($(this).attr('dataid'))
    $.ajax({
        url: '/Personal/ReenviarCorreo',
        type: 'POST',
        data: {
            intIdPersonal
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
            if (response["activo"] == "no") {
                swal({
                    title: "Reenviar correo",
                    text: "Empleado no tiene usuario activo, ¿Desea activarlo?",
                    type: 'info',
                    showCancelButton: true,
                    confirmButtonText: 'Sí, activar',
                    cancelButtonText: 'No, cancelar',
                })
                    .then(isConfirm => {
                        validarSession()
                        $.post('/Personal/ActivarUsuario', { intIdPersonal }, respo => {
                            new PNotify({
                                title: 'Reenviar Correo',
                                text: respo,
                                type: 'info',
                                delay: 3000,
                                styling: 'bootstrap3',
                                addclass: 'dark'
                            });
                        })
                    })
                    .catch(err => {
                        swal('Cancelado', 'La Operación fue cancelada', 'error')
                    })
            } else {
                new PNotify({
                    title: 'Reenviar Correo',
                    text: response["mensaje"],
                    type: 'info',
                    delay: 3000,
                    styling: 'bootstrap3',
                    addclass: 'dark'
                });
            }


        },
        complete: function () {
            $.unblockUI();
        }
    })



})

var activaUsuario = false;
var desactivaUsuario = false;
var activarAdmin = false;
$(document).ready(function () {
    const { dataTableId, formatoFecha, rangeDateInicial } = configEmpleadoInicial()
    if ($(`#${dataTableId}`).length) {

        $.post(
            '/Personal/ListarCombosPersonal',
            { intIdMenu: 0, strEntidad: 'TGUNIDORG', intIdFiltroGrupo: 2, strGrupo: 'JERAR', strSubGrupo: '' },
            (response) => {
                $('#intIdUniOrg').empty();
                $('#intIdUniOrg').append('<option value="0" selected>Todos</option>');

                response.forEach(element => {
                    $('#intIdUniOrg').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');

                });

            });

        $('#intIdUniOrg').change(function () {
            validarSession()
            const date = getDateRangePickerEmpleado()
            traerDatosEmpleados(date.fInicio, date.fFin)
        })

        traerDatosEmpleados(rangeDateInicial.startDate.format(formatoFecha), rangeDateInicial.endDate.format(formatoFecha))
    }
})

function configMiFichaInicial() {
    const intIdMenu = localStorage.getItem('idsubmenu') && !isNaN(localStorage.getItem('idsubmenu')) ? Number(localStorage.getItem('idsubmenu')) : 1
    const contenedorIdInicial = 'miFichaPersonal'
    const formatoFecha = 'DD/MM/YYYY'
    const rangeDateInicial = {
        startDate: moment().subtract(10, 'year'),
        endDate: moment(),
    }
    return {
        intIdMenu,
        contenedorIdInicial,
        formatoFecha,
        rangeDateInicial,
    }
}
function getDocumentElementById(id) {
    return document.getElementById(id)
}

function getAdicionalControlEditarPersonal() {
    const { intIdMenu, formatoFecha, rangeDateInicial } = configMiFichaInicial()

    axios
        .post('/Personal/ListarCombos', {
            intIdMenu: intIdMenu,
            strEntidad: 'TGTIPO_VIA',
            intIdFiltroGrupo: 0,
            strGrupo: '',
            strSubGrupo: '',
        })
        .then((resp) => {
            const dataTipVia = resp.data
            if (dataTipVia.length) {
                $('#TipVia').empty()
                $('#TipVia').attr('disabled', false)
                $('#TipVia').append('<option value="">Via</option>')
                dataTipVia.forEach((element) => {
                    $('#TipVia').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                })
            }
        })
        .catch((error) => {
            console.log(error)
        })

    axios
        .post('/Personal/ListarCombos', {
            intIdMenu: intIdMenu,
            strEntidad: 'TGPAIS',
            intIdFiltroGrupo: 0,
            strGrupo: 'EXISTE',
            strSubGrupo: '',
        })
        .then((resp) => {
            const dataCboPais = resp.data
            if (dataCboPais.length) {
                $('#CboPais').empty()
                $('#CboPais').attr('disabled', false)
                $('#CboPais').append('<option value="">Seleccione</option>')

                dataCboPais.forEach((element) => {
                    $('#CboPais').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                })
            }
        })
        .catch((error) => {
            console.log(error)
        })
}

function getTimeConceptoHoras(string) {

    var x = string.indexOf('(')
    var y = string.substr(x + 1)

    var salida = y.replace(')', '');

    return salida
}


function getHorasByMin(m) {
    var minutes = m % 60
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var hours = Math.floor(m / 60)
    hours = hours < 10 ? '0' + hours : hours;
    return hours + ":" + minutes
}

var _vartableResponsabilidad;
var _vartablePapeleta;
var fechaInicio;
var fechaFin;


async function updatePersonalPerfil(intIdPersonal) {
    const titleToast = 'Editar Perfil'
    ActualizarPerfilEmpleado(titleToast, intIdPersonal);

    //alert('error al intentar actualizar')
}

function validarFecha(fecha) {
    var array = fecha.split("/", 3)
    var d = array[0]
    var m = array[1]
    var a = array[2]
    var ok = true;
    if ((a < 1900) || (a > 2050) || (m < 1) || (m > 12) || (d < 1) || (d > 31))
        ok = false;
    else {
        if ((a % 4 != 0) && (m == 2) && (d > 28))
            ok = false;
        else {
            if ((((m == 4) || (m == 6) || (m == 9) || (m == 11)) && (d > 30)) || ((m == 2) && (d > 29)))
                ok = false;
        }
    }
    return ok;
}

function ActualizarPerfilEmpleado(titleToast, intIdPersonal) {

    const { intIdMenu, formatoFecha } = configEmpleadoInicial()

    if (getValueControl('#TipVia').length == '') {
        messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
        focusControl('#TipVia')
        return false
    }
    if (getValueControl('#TXTTIPVIA').length < 4) {
        messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
        focusControl('#TXTTIPVIA')
        return false
    }
    if (getValueControl('#txtFechaNac').length < 4) {
        messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
        focusControl('#txtFechaNac')
        return false
    }
    if (!validarFecha(getValueControl('#txtFechaNac'))) {
        messageResponseMix({ type: 'info', message: 'Fecha incorrecta' }, titleToast)
        focusControl('#txtFechaNac')
        return false
    }
    else if (getValueControl('#CboPais') == '') {
        messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
        $('#CboPais').focus()
        return false
    }
    else if (getValueControl('#CboRegion') == '') {
        messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
        $('#CboRegion').focus()
        return false
    }
    else if (getValueControl('#CboProvincia') == '') {
        messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
        $('#CboProvincia').focus()
        return false
    }
    else if (getValueControl('#CboDistrito') == '') {
        messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
        $('#CboDistrito').focus()
        return false
    }
    else if (getValueControl('#Email_Emple').length < 4 || !ValidateEmail(getValueControl('#Email_Emple'))) {
        messageResponseMix({ type: 'info', message: 'Correo no tiene el formato correcto' }, titleToast)
        focusControl('#Email_Emple')
        return false
    }
    else if (getValueControl('#celularEmpleado').length < 6) {
        messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
        focusControl('#celularEmpleado')
        return false
    }

    const otrosCorreosData = $.map($('#TagEmailContainer .tagsinput span span'), function (e, i) {
        return $(e)
            .text()
            .trim()
    })

    const otrosTelefonosData = $.map($('#tagTelefonosContainer .tagsinput span span'), function (e, i) {
        return $(e)
            .text()
            .trim()
    })

    const otrosCorreos = otrosCorreosData.filter(item => {
        return ValidateEmail(item) === true
    })


    let otrosCorreosInsert = []
    otrosCorreosInsert.push({
        intIdPerCorr: 0,
        intIdPersonal: 0,
        strCorreo: getValueControl('#Email_Emple'),
        bitFlPrincipal: true,
        bitFlEliminado: false,
    })
    otrosCorreos.forEach(item => {
        otrosCorreosInsert.push({
            intIdPerCorr: 0,
            intIdPersonal: 0,
            strCorreo: item,
            bitFlPrincipal: false,
            bitFlEliminado: false,
        })
    })

    let otrosTelefonosInsert = []
    otrosTelefonosInsert.push({
        intIdPerTele: 0,
        intIdPersonal: 0,
        strNumero: getValueControl('#celularEmpleado'),
        bitFlPrincipal: true,
        strAnexo: ' ',
        bitFlEliminado: false,
    })
    otrosTelefonosData.forEach(item => {
        otrosTelefonosInsert.push({
            intIdPerTele: 0,
            intIdPersonal: 0,
            strNumero: item,
            bitFlPrincipal: false,
            strAnexo: '',
            bitFlEliminado: false,
        })
    })

    const params = {
        intIdMenu: intIdMenu,
        ObjPersonal: {
            intIdPersonal: intIdPersonal,
            dttFecNacim: $('#txtFechaNac').val(),
            intIdTipoVia: $('#TipVia').val() != '0' ? $('#TipVia').val() : null,
            strDireccion: $('#TXTTIPVIA').val().length ? $('#TXTTIPVIA').val() : null,
            intIdUbigeo: $('#txtIntidUbigeo').val() != '0' ? $('#txtIntidUbigeo').val() : null,
        },
        listaDetallesPersonalCorreos: otrosCorreosInsert,
        listaDetallesPersonalTelefonos: otrosTelefonosInsert
    }

    console.log(params)


    $.post('/Personal/ActualizarPerfilEmpleado', params, respo => {
        messageResponseMix(respo, 'Editar Empleado')

        if (respo.type === 'success') {
            //$('.form-hide-empleado .x_content').empty()
            //$('.form-hide-empleado .x_content').html('')
            //$('.form-hide-empleado').hide()
            //traerDatosEmpleados()
            $('#myModalEditar').modal('hide')
            getPersonalPerfil2(intIdPersonal)
        }
    })

}

async function getPersonalPerfil2(intIdPersonalId) {
    const { intIdMenu, formatoFecha, rangeDateInicial } = configMiFichaInicial()
    const { loaderHtml } = APPCONFIG
    const intIdPersonal = intIdPersonalId
    //getAdicionalControlEditarPersonal()
    try {
        const idRange = ".range-datepicker";
        //const fechaInicio = $(idRange).data('daterangepicker').startDate.format('DD/MM/YYYY');
        //const fechaFin = $(idRange).data('daterangepicker').endDate.format('DD/MM/YYYY');
        const anio = $(idRange).data('daterangepicker').startDate.format('DD/MM/YYYY').substr(-4, 4);
        fechaInicio = '01/01/' + anio
        fechaFin = '31/12/' + anio

        $(".rangoFechaIni").html('Enero 01, ' + anio)
        $(".rangoFechaFin").html('Diciembre 31, ' + anio)

        const dataUser = await axios.post('/Personal/GetPersonalData', { intIdMenu, intIdPersonal })
        const dataCorreos = await axios.post('/Personal/GetCorreosPersonal', { intIdMenu, intIdPersonal })
        const dataTelefonos = await axios.post('/Personal/GetTelefonosPersonal', { intIdMenu, intIdPersonal })

        if (dataUser.data.length) {
            document.querySelectorAll('.loading-item-p').forEach((el) => {
                el.classList.remove('skeleton-loader', 'h23x100', 'h22x79', 'dplayinitial', 'bg-loader')
            })

            const user = dataUser.data[0]
            const INTIDTPEVAL = user.intIdUbigeo
            const INTIDSUPUBI = user.intIdUbigSup
            const INTIDSUPUBIREGION = user.intIdUbiSupReg
            const intIdProvinciaMostrar = user.intIdUbiReg
            const intIdRegionMostrar = user.intIdUbiPais
            const intIdJerOrgLista = user.intIdJerOrg
            const intIdUniOrgLista = user.intIdUniOrg

            getDocumentElementById('direccionPersonal').innerHTML = `<i class="fa fa-map-marker user-profile-icon"></i> ${user.strDir} <br> ${user.strDirUbi}`
            getDocumentElementById('fechaNacimientoPersonal').innerHTML = `<strong>Fecha de Nacimiento:</strong> ${user.dttFecNacim}`
        }

        if (dataCorreos.data.length) {
            const dataCorreosArray = dataCorreos.data
            let dataCorreosInsert = ''
            $('#tituloCorreoPersonal').html(`<li><i class="glyphicon glyphicon-envelope"></i> Otros Emails:</li>`)
            $('#dataCorreoPersonal').empty()
            dataCorreosArray.forEach((item) => {
                if (item.bitFlPrincipal) {
                    getDocumentElementById('correoPrincipalPersonal').innerHTML = `<i class="fa fa-envelope user-profile-icon"></i> ${item.strCorreo}`
                } else {
                    $('#dataCorreoPersonal').append(`<li>${item.strCorreo}</li><br>`)
                }
            })
        } else {
            $('#TagEmailContainer').html(`<input id="tagsEmail" type="text" class="tags form-control tagsEmailGet" value="" /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
        }

        if (dataTelefonos.data.length) {
            const dataTelefonosArray = dataTelefonos.data
            let dataTelefonosInsert = ''
            $('#tituloTelefonoPersonal').html(`<li><i class="glyphicon glyphicon-phone-alt"></i> Otros Telefonos:</li>`)
            $('#dataTelefonoPersonal').empty()
            dataTelefonosArray.forEach((item) => {
                if (item.bitFlPrincipal) {
                    getDocumentElementById('telefonoPrincipalPersonal').innerHTML = `<i class="glyphicon glyphicon-phone-alt"></i> ${item.strNumero}`
                } else {
                    $('#dataTelefonoPersonal').append(`<li>${item.strNumero}</li><br>`)
                }
            })
        } else {
            $('#tagTelefonosContainer').html(`<input id="tagsTelefono" type="text" class="tags form-control tagsTelefonoGet" value=""  /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
        }
        var mailformatEmail = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/
    } catch (error) {
        console.log(error)
    }
}


$(document).ready(function () {
    const { intIdMenu, contenedorIdInicial, formatoFecha, rangeDateInicial } = configMiFichaInicial()
    if ($(`#${contenedorIdInicial}`).length) {
        //const intIdPersonal = window.SISCOP.intIdPersonal
        //getPersonalPerfil(intIdPersonal)
        var today = new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate());
        $('#FechaNac').datetimepicker({
            maxDate: today,
            viewMode: 'days',
            format: formatoFecha
        })

    }
})







/**------------------------------------------------------*//*ln_30840_all*/
/**28. Mantenimiento Servicio (de sisfd) */
/**------------------------------------------------------*//*ln_32888_all*/
/*******************************************/
/***************3.2-Servicio****************/
/********* Mantenimiento Servicio **********/
/*******************************************/

























/*************************************************/
/******** Mantenimiento Toma de Consumos *********/
/*************************************************/
/*
 ===============================================================================================
 =============================== MANTENIMIENTO TOMA DE CONSUMO =================================mtcon
 ===============================================================================================
*/


var CantTotalSC; var TotalSC; var CantTotalS; var TotalS; var Confi; //Variables de Carrito de Compras

function traerComboMarcadorDeTipoDni() {
    validarSession()//AÑADIDO 07.04.2021
    $.post( //traer el ID(PK) del Marcador llamado DNI -->Usar al momento de grabar el consumo.
        '/Personal/ListarCombos',
        {
            intIdMenu : 0,
            strEntidad: 'TGMARCADOR',
            intIdFiltroGrupo: 0, // intIdUniOrg,
            strGrupo : 'INTERNO',
            strSubGrupo: 'DNI',
        },
        response => {
            $('#txt_NumeroDeMarcadorDeTipoDni').empty();
            $('#int_NumeroDeMarcadorDeTipoDni').empty();
            response.forEach(element => {
                $('#txt_NumeroDeMarcadorDeTipoDni').append(element.strDeTipo);
                $('#int_NumeroDeMarcadorDeTipoDni').append(element.intidTipo);
            })
        })

    var SesionMovi = {
        IntIdMenu: 'M0305',
        intIdUsuario: idUsuar,
        intIdSoft: idSoftw,
        intIdSesion: intIdSe
    }

    $.post( //traer el ID(PK) del Marcador llamado DNI -->Usar al momento de grabar el consumo.
        '/Personal/GetTSConfi',
        {
            objSession: SesionMovi,
            strCoConfi: 'HAB_TEMPORIZADOR_TOMACONSUMO',
        },
        response => {
            Confi = response.strValorConfi;
            //RESULTADO: El valor está expresado en Si=1 y No=0.
        })

    CantTotalSC = 0; TotalSC = 0; CantTotalS = 0; TotalS = 0;
}


//===============================================================================================
//================================ MODAL MARCADOR ===============================================
//===============================================================================================

var NumeroMarcadorVisor; // 07.04.2021 variable global
function modalIngreseMarcador() {
    validarSession();//AÑADIDO 07.04.2021
    $.post(
        '/LoginSiscop/getNumMarcadorTomaConsumo',
        {},
        (response) => {
            console.log(response);
            NumeroMarcadorVisor = response;

            if (parseInt(NumeroMarcadorVisor) === 0) {//añadido 07/04/2021
                $('#seleccioneUnMarcador').empty();
                $('#seleccioneUnMarcador').append('Tiene que Seleccionar un Marcador');
                modal.style.display = "block";
            } else {
                modal.style.display = "none";
                NewValidaPreModal(NumeroMarcadorVisor);
            }
        });
    // Get the modal
    var modal = document.getElementById("myModal");
    // Get the button that opens the modal
    var btn = document.getElementById("myBtn");
    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("close")[0];
    // When the user clicks the button, open the modal
    //btn.onclick = function () {

    //}
    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }

    //01.-  COMBO EMPRESA
    var intidUniOrg = 0;//166;// $(this).val()
    $.post(
        '/Personal/ListarCombos',
        {
            intIdMenu: 0,
            strEntidad: 'TGPERSONAL',
            intIdFiltroGrupo: intidUniOrg,
            strGrupo: 'EMPRESA',
            strSubGrupo: ''
        },
        response => {
            $('#cboEmpresa').empty()
            $('#cboEmpresa').attr('disabled', false)
            $('#cboEmpresa').append('<option value="0">Seleccione</option>')
            response.forEach(element => {
                $('#cboEmpresa').append(`<option value="${element.intidTipo}">${element.strDeTipo}</option>`)
            })
        })

    //Configuración de Impresión
    var SesionMovi = {
        IntIdMenu: 'M0305',
        intIdUsuario: idUsuar,
        intIdSoft: idSoftw,
        intIdSesion: intIdSe
    }

    $.post(
        '/Personal/GetTSConfi',
        {
            objSession: SesionMovi,
            strCoConfi: 'HAB_IMPR_TICKET_COMEDOR',
        },
        response => {
            ConfiImpr = response.strValorConfi;
            //RESULTADO: El valor está expresado en Si=1 y No=0.
        })
}

//03.- COMBO MARCADOR 
$("#cboLocal").change(function () {
    validarSession()//AÑADIDO 07.04.2021
    var intIdUniOrg = $(this).val();

    $.post(
        '/Personal/ListarCombos',
        {
            intIdMenu: 0,
            strEntidad: 'TGMARCADOR',
            intIdFiltroGrupo: intIdUniOrg,
            strGrupo: 'TGMARCADOR',
            strSubGrupo: 'TOMACONSUMO',
        },
        response => {
            $('#cboMarcador').empty()
            $('#cboMarcador').append('<option value="0" selected>Seleccione</option>')
            response.forEach(element => {
                $('#cboMarcador').append(`<option value="${element.intidTipo}">${element.strDeTipo}</option>`)
            })
        })

})

//2.- COMBO LOCAL
$("#cboEmpresa").change(function () {
    validarSession()//AÑADIDO 07.04.2021
    var intid = $(this).val()

    $.post(
        '/Personal/ListarCombos',
        {
            intIdMenu: 0,
            strEntidad: 'TGPERSONAL',
            intIdFiltroGrupo: intid,
            strGrupo: 'LOCAL',
            strSubGrupo: ''
        },
        response => {
            $('#cboLocal').empty()
            $('#cboLocal').attr('disabled', false)
            $('#cboLocal').append('<option value="0">Seleccione</option>')
            response.forEach(element => {
                $('#cboLocal').append(`<option value="${element.intidTipo}">${element.strDeTipo}</option>`)
            })
        })

})

//VALIDAR CAMPO DNI
$("#dni_Empleado_input").keyup(function (event) {
    validarSession()//AÑADIDO 07.04.2021
    if (event.keyCode === 13) {
        if (($("#dni_Empleado_input").val().length) < 8) {
            $('#dni_Empleado_input_error').empty();
            $('#dni_Empleado_input_error').append('EL DNI DEBE CONTENER 8 CARACTERES');
            $('#dni_Empleado_input_error').css('color', 'red');

            var $body = jQuery('#dni_Empleado_input_error')
            $body.fadeOut(300, function () {
                $body.fadeIn(300);
            });
        }
        else {
            $('#dni_Empleado_input_error').empty();
            $('#dni_Empleado_input_error').append('SE COMPLETÓ LOS 8 CARACTERES');
            $('#dni_Empleado_input_error').css('color', 'green');
            $("#btn-insertar-marcacion-con-dni").click();
        }
    }
});

//KEYUP KEYDOWN
$("#dni_Empleado_input").keypress(function () {
    validarSession()//AÑADIDO 07.04.2021
    if (($("#dni_Empleado_input").val().length) < 8) {
        $('#dni_Empleado_input_error').empty();
        $('#dni_Empleado_input_error').append('EL DNI DEBE CONTENER 8 CARACTERES');
        $('#dni_Empleado_input_error').css('color', 'red');

        var $body = jQuery('#dni_Empleado_input_error')
        $body.fadeOut(300, function () {
            $body.fadeIn(300);
        });
        return;
    }
    else {
        $('#dni_Empleado_input_error').empty();
        $('#dni_Empleado_input_error').append('SE COMPLETÓ LOS 8 CARACTERES');
        $('#dni_Empleado_input_error').css('color', 'green');
     }
});

//===============================================================================================
//=============================== BOTON INGRESAR CON DNI ========================================
//===============================================================================================
$('#btn-insertar-marcacion-con-dni').on('click', function () { 
    validarSession()//AÑADIDO 07.04.2021
    $('#dni_Empleado_input_error').empty();

    if (($("#dni_Empleado_input").val().length) == 0 || $("#dni_Empleado_input").val() == null) {
        swal({
            title: "Toma de Consumos",
            text: "Tiene que ingresar el número de DNI",
            timer: 2000,
        });
        return;
    }
    else {
         if (($("#dni_Empleado_input").val().length) < 8) {
             $('#dni_Empleado_input_error').empty();
             $('#dni_Empleado_input_error').append('EL DNI DEBE CONTENER 8 CARACTERES');
             $('#dni_Empleado_input_error').css('color', 'red');
         
             var $body = jQuery('#dni_Empleado_input_error')
             $body.fadeOut(300, function () {
                 $body.fadeIn(300);
             });
             return;
         }
         else {
             $('#dni_Empleado_input_error').empty();
             $('#dni_Empleado_input_error').append('SE COMPLETÓ LOS 8 CARACTERES');
             $('#dni_Empleado_input_error').css('color', 'green');
         }
    }
    
    var _intIdAsistencia = 0;
    var _strNumDocumento = $('#dni_Empleado_input').val();   

    var _intNumTerminalRelac = $('#numeroMarcadorDelVisor').text();//Numero de DNI numeroMarcadorDelVisor
    var _dttFechaMarca = moment().format('DD/MM/YYYY HH:mm:ss')

    var MarcacionConDni = {
         intIdAsistencia     : _intIdAsistencia 
        ,strNumDocumento     : _strNumDocumento 
        ,dttFechaMarca       : _dttFechaMarca
        ,intNumTerminalRelac : _intNumTerminalRelac 
        ,bitMarcaDNI         : true//_bitMarcaDNI  
    }

    var SesionMovi = {
        IntIdMenu: 'M0305',
        intIdUsuario: idUsuar,
        intIdSoft: idSoftw,
        intIdSesion: intIdSe
    }

    //return;
    $.post(
        '/Personal/RegistrarMarcacionConDni',
        { ObjEmpleadoConDni: MarcacionConDni, intTipoOperacion: 1, objSession: SesionMovi },
        (response) => {
            if (response.type !== '') {
                if (response.type === 'success') {
                    $('#dni_Empleado_input').val(''); 
                    $('#dni_Empleado_input_error').empty();
                } else if (response.type === 'info')
                {
                    swal({
                        title: "Estimado Empleado",
                        text: response.message,
                    });
                    $('#dni_Empleado_input').val('');
                    $('#dni_Empleado_input_error').empty();
                }
                else {
                }
            }
        }

    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });

});

$('#btn-update-marcadorToma').on('click', function () {

    validarSession()//AÑADIDO 22.04.2021 HG
    var modal = document.getElementById("myModal");
    var btn = document.getElementById("myBtn");
    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("close")[0];
    // When the user clicks the button, open the modal
    //btn.onclick = function () {

    //}
    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }

    //01.-  COMBO EMPRESA
    var intidUniOrg = 0;//166;// $(this).val()
    $.post(
        '/Personal/ListarCombos',
        {
            intIdMenu: 0,
            strEntidad: 'TGPERSONAL',
            intIdFiltroGrupo: intidUniOrg,
            strGrupo: 'EMPRESA',
            strSubGrupo: ''
        },
        response => {
            $('#cboEmpresa').empty()
            $('#cboEmpresa').attr('disabled', false)
            $('#cboEmpresa').append('<option value="0">Seleccione</option>')
            response.forEach(element => {
                $('#cboEmpresa').append(`<option value="${element.intidTipo}">${element.strDeTipo}</option>`)
            })
        })

    //Configuración de Impresión
    var SesionMovi = {
        IntIdMenu: 'M0305',
        intIdUsuario: idUsuar,
        intIdSoft: idSoftw,
        intIdSesion: intIdSe
    }

    $.post(
        '/Personal/GetTSConfi',
        {
            objSession: SesionMovi,
            strCoConfi: 'HAB_IMPR_TICKET_COMEDOR',
        },
        response => {
            ConfiImpr = response.strValorConfi;
            //RESULTADO: El valor está expresado en Si=1 y No=0.
        })

    $('#seleccioneUnMarcador').empty();
    modal.style.display = "block";
    return;
});

//===============================================================================================
//================================ ON CLICK idEmpleadoConsumo ===================================
//===============================================================================================
function esconder_pantalla_modo_espera() {
    validarSession();//AÑADIDO 22.04.2021 HG
    $("#contenedor_superior_top_nav").hide(); //Menu de opcion Salir del sistema
    $('#pantalla_bienvenida_modo_espera').fadeOut('slow').delay(5000).hide(); //HIDE TIENE QUE IR DE LA MANO CON FADEOUT
    $('#table-lista-servicios-disponibles').hide();
    $('#TbServiciosDiv').hide();//añadido 20.03.2021
    //añadido 19.03.2021
    $('#table-lista-servicios-complementarios').hide();
    $('#TbcomplementariosDiv').hide(); //añadido 20.03.2021
    //fin
    $('#Contenedor_Toma_Consumos').show();//modificado 26.03.2021
    $('#idTemporizador').hide();//añadido 20.03.2021
    $('#contenedor_padre_datos_comensal').show();
    $('#contenedor_padre_datos_comensal').appendTo('#contenedor_superior_top_nav2');

    CantTotalSC = 0; TotalSC = 0; CantTotalS = 0; TotalS = 0;
}

////===============================================================================================
////================================ FUNCION boton_trigger_visor() ================================ modo de espera visor
////===============================================================================================
function boton_trigger_visor() {
    validarSession(); //AÑADIDO 07.04.2021
    var idEmpleadoConsumo_ = $('#input_idAsistencia').val();
    $('#input_idAsistencia').empty();// Añadido/HGM  13.04.21
    $('#input_idAsistencia').val('0');// Añadido/HGM  13.04.21
    //añadido 14/04/2021 ES
    console.log("==========================================");
    //var idEmpleadoConsumo_ = mi_variable_global_;
    console.log("Variable global :");
    console.log(mi_variable_global_);
    console.log("==========================================");


    //Código Del Marcador Impreso en el Label Que Usa el WebObserver 
    var txt_codigo_marcador_observer = $('#codigo_marcador').text();
    var TxtNumeroMarcadorEnVisor = $('#numeroMarcadorDelVisor').text();

    if (txt_codigo_marcador_observer == TxtNumeroMarcadorEnVisor) {
        if (!isNaN(idEmpleadoConsumo_)) {
            DatosEmpleadoTomaConsumoVisor(idEmpleadoConsumo_);
        }
    } else {
        $('#idTemporizador').hide();//modificado 26.03.2021
    }

};







