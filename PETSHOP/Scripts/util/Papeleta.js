var _TablaDetAusentismo;
var _varTablaEmpleadosObs;
var datahorariocheckofinalAu = [];
var _varTablaAusentismos;
var flgDESM;
var listPapeletasReg = [];
var intIdPapeleta = 0;
var listPapeletasInitial = [];
let datahorariocheckAu = [];
let datahorariocheck = [];
let datahorariogLobalAu = null;
var DocumentosNew = 0;
let intIdEmpleadoSelect = 0;
let _intIdProceso;

var _codigo;
var _nombre;
var _numDoc;


$("#btn-save-change-AusentismosCom").click(function () {
    validarSession()
    var IdConceptoNew = $('#IdConCepNew').val();
    var IdCCostoNew = $('#IdCCostoNew').val();

    var fechaIni = $('#fechaIniNew').val();
    var fechaFin = $('#fechaFinNew').val();
    var HoraIniNew = $('#HoraIniNew').val();
    var HoraFinNew = $('#HoraFinNew').val();
    var ObservacionNew = $('#strObservacionNew').val();

    var BitDiaNew = 0;
    if ($('#BitDiaNew').is(":checked")) { BitDiaNew = 1; }

    var BitCompensaNew = false;
    if ($('#BitCompensaNew').is(":checked")) { BitCompensaNew = true; }

    var BitEspecieValNew = false;
    if ($('#BitEspecieValNew').is(":checked")) { BitEspecieValNew = true; }

    var IntIdTipoDocNew = $('#IdTipoDocNew').val();
    var strCITTNew = $('#txtNroCittNew').val();
    var strEmitidoEnNew = $('#txtEmitidoEnNew').val();
    var strEmitidoPorNew = $('#txtEmitidoPorNew').val();
    var BitSustentadoNew = $('#BitSustentadoNew').val();

    var BitDiaSgt01New = false;
    if ($('#BitDiaSgt01New').is(":checked")) { BitDiaSgt01New = true; }
    var BitDiaSgt02New = false;
    if ($('#BitDiaSgt02New').is(":checked")) { BitDiaSgt02New = true; }

    var strCoTipo = $('#IdConCepNew').find("option:selected").attr('strcotipo')

    if (IdConceptoNew == 0) {

        new PNotify({
            title: 'Asignar el concepto',
            text: 'Completar los campos Obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }
    //if (IdCCostoNew == 0) {

    //    new PNotify({
    //        title: 'Asignar el centro de costo',
    //        text: 'Completar los campos Obligatorios',
    //        type: 'info',
    //        delay: 3000,
    //        styling: 'bootstrap3',
    //        addclass: 'dark'
    //    });

    //    return;
    //}
    if (fechaIni == '' || fechaFin == '') {

        new PNotify({
            title: 'Asignar el las fechas',
            text: 'Completar los campos Obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }

    if (flgDESM && $("#BitEspecieValNew").is(':checked')) {
        if (IntIdTipoDocNew == 0) {

            new PNotify({
                title: 'Asignar el tipo de documento sustentatorio',
                text: 'Completar los campos Obligatorios',
                type: 'info',
                delay: 3000,
                styling: 'bootstrap3',
                addclass: 'dark'
            });

            return;
        }
        if (strCITTNew == '') {

            new PNotify({
                title: 'No permite campos vacios',
                text: 'Completar los campos Obligatorios',
                type: 'info',
                delay: 3000,
                styling: 'bootstrap3',
                addclass: 'dark'
            });

            return;
        }
        //if (strEmitidoEnNew == '') {

        //    new PNotify({
        //        title: 'No permite campos vacios',
        //        text: 'Completar los campos Obligatorios',
        //        type: 'info',
        //        delay: 3000,
        //        styling: 'bootstrap3',
        //        addclass: 'dark'
        //    });

        //    return;
        //}
        //if (strEmitidoPorNew == '') {

        //    new PNotify({
        //        title: 'No permite campos vacios',
        //        text: 'Completar los campos Obligatorios',
        //        type: 'info',
        //        delay: 3000,
        //        styling: 'bootstrap3',
        //        addclass: 'dark'
        //    });

        //    return;
        //}
    }
    if (!$("#BitEspecieValNew").is(':checked')) {
        var IntIdTipoDocNew = '';
        var strCITTNew = '';
        var strEmitidoEnNew = '';
        var strEmitidoPorNew = '';
    }

    if (strCoTipo == '01') {

        if (HoraIniNew == '' || HoraFinNew == '') {

            new PNotify({
                title: 'Asignar la hora inicio y hora fin',
                text: 'Completar los campos Obligatorios',
                type: 'info',
                delay: 3000,
                styling: 'bootstrap3',
                addclass: 'dark'
            });

            return;
        }

        var hora_ini_val = timeStringToFloat(HoraIniNew, 2);
        var hora_fin_val = timeStringToFloat(HoraFinNew, 1);

        if (HoraIniNew == 0 || HoraFinNew == 0) {

            new PNotify({
                title: 'Asignar la hora inicio y hora fin',
                text: 'Completar los campos Obligatorios',
                type: 'info',
                delay: 3000,
                styling: 'bootstrap3',
                addclass: 'dark'
            });

            return;
        }

        if ((BitDiaSgt01New && BitDiaSgt02New) || (!BitDiaSgt01New && !BitDiaSgt02New)) {
            if (hora_ini_val > hora_fin_val) {

                new PNotify({
                    title: 'La Hora fin debe ser mayor a la hora de inicio',
                    text: 'Ingresar el rango de horas correcto',
                    type: 'info',
                    delay: 3000,
                    styling: 'bootstrap3',
                    addclass: 'dark'
                });

                return;
            }
        } else {
            if (BitDiaSgt01New) {
                new PNotify({
                    title: 'La Hora fin debe ser mayor a la hora de inicio',
                    text: 'Ingresar el rango de horas correcto',
                    type: 'info',
                    delay: 3000,
                    styling: 'bootstrap3',
                    addclass: 'dark'
                });

                return;
            }
            else if (BitDiaSgt02New) {
                if (hora_fin_val > hora_ini_val) {

                    new PNotify({
                        title: 'La Hora fin debe ser mayor a la hora de inicio',
                        text: 'Ingresar el rango de horas correcto',
                        type: 'info',
                        delay: 3000,
                        styling: 'bootstrap3',
                        addclass: 'dark'
                    });

                    return;
                }
            }
        }

    }



    if (moment(fechaIni, 'DD-MM-YYYY') > moment(fechaFin, 'DD-MM-YYYY')) {

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

    var listPer = []
    datahorariocheckofinalAu.forEach(element => {
        listPer.push(element.intIdPerHorario)
    });

    var DatosAusentismoNew = {
        intIdPerConcepto: listPer
        , intIdConcepto: IdConceptoNew
        , IntIdCCosto: IdCCostoNew
        , dttFecha: ''
        , timeHoraIni: HoraIniNew
        , timeHoraFin: HoraFinNew
        , strObservacion: ObservacionNew
        , tinDiaPertenen: BitDiaNew
        , bitFlCompensable: BitCompensaNew
        , bitEspeciValor: BitEspecieValNew
        , IntIdTipoDoc: IntIdTipoDocNew
        , strCITT: strCITTNew
        , strNoInstitucion: strEmitidoEnNew
        , strNoDoctor: strEmitidoPorNew
        , bitSustentado: BitSustentadoNew
        , bitDiaSgtIni: BitDiaSgt01New
        , bitDiaSgtFin: BitDiaSgt02New
    }

    console.log(DatosAusentismoNew)

    //$("#archivos").fileinput("upload");

    $.post(
        '/Personal/PreIAusentismos',
        {
            objDatos: DatosAusentismoNew,
            listPersonal: listPer,
            flgDESM: flgDESM,
            dttFechaIni: fechaIni,
            dttFechaFin: fechaFin
        },
        (response) => {
            if (response.type == 'success') {
                new PNotify({
                    title: 'Nuevo Permiso',
                    text: response.message,
                    type: response.type,
                    delay: 3000,
                    styling: 'bootstrap3'
                });

                listPapeletasReg = [];
                response.objeto.forEach(element => {
                    listPapeletasReg.push(element.intCodigo);
                });

                $("#archivosNew").fileinput("upload");

                $("#btn-cancel-AusentismosCom").click()

                return;
            }
            else
            {
                if (response.objeto.length == datahorariocheckAu.length) {
                    if (response.objeto.length == 1) {
                        new PNotify({
                            title: 'Registro Permiso',
                            text: response.objeto[0].strObservacion,
                            type: response.type,
                            delay: 3000,
                            styling: 'bootstrap3'
                        });
                        return;
                    } else {
                        new PNotify({
                            title: 'Registro Permiso',
                            text: 'Todos los empleados se encuentran observados, verificar fechas y/o rangos de horas',
                            type: response.type,
                            delay: 3000,
                            styling: 'bootstrap3'
                        });

                        //$('#btnEmpContinuar').hide();

                        return;
                    }
                }
                else {
                    if ($.fn.DataTable.isDataTable('#TablaListEmpObserv')) {
                        _varTablaEmpleadosObs.destroy();
                    }

                    $("#totalEmpleados").html(datahorariocheckofinalAu.length)
                    $("#totalEmpleadosObs").html(response.objeto.length)
                    $("#textoModal").html("empleado ya tiene permiso registrado para el rango de fechas.")
                    if (response.objeto.length > 1) {
                        $("#textoModal").html("empleados ya tienen permisos registrados para el rango de fechas.")
                    }

                    //if (datahorariocheckofinalAu.length = response.objeto.length) {

                    //    $('#btnEmpContinuar').hide();

                    //}


                    if ($('#totalEmpleados').text() == $('#totalEmpleadosObs').text()) {

                        $('#btnEmpContinuar').hide();

                    }

                    if ($('#totalEmpleados').text() > $('#totalEmpleadosObs').text()) {

                        $('#btnEmpContinuar').show();

                    }

                    if ($('#totalEmpleados').text() < $('#totalEmpleadosObs').text()) {

                        $('#btnEmpContinuar').show();

                    }

                    $("#modaldetalle").modal('show');
                    //////////CODIGO DESARROLLADO PARA LA SOLUCIÓN DEL PUNTO 14 EN EL DOCUMENTO JAVASCRIPT “Papeleta.js”, añadirlo en la línea 380 aproximadamente.
                    //////////INICIO DE SOLUCION PARA LA OBSERVACION  14 HG 30.03.21
                    ////////$(".modal-backdrop").removeClass("in");
                    ////////$(".modal-backdrop").removeClass("fade");
                    ////////$(".modal-backdrop").removeClass("modal-backdrop");
                    ////////$('.modal-backdrop').css('display', 'none');
                    ////////$('.fade').css('display', 'none');
                    ////////$('.in').css('display', 'none');
                    ////////$('#fechaIniNew').css('z-index', '0');
                    ////////$('#fechaFinNew').css('z-index', '0');
                    ////////$('.input-group').css('z-index', '0');
                    ////////$('.paginate_button a').css('z-index', '0');
                    ////////$('.modal-header').css('padding-top', '20px');
                    ////////$('.modal-header').css('background-color', 'transparent');
                    ////////$('.modal-content').css('width', '90%');
                    ////////$('#myModalLabel').css('color', '#73879C');
                    //////////INICIO DE SOLUCION PARA LA OBSERVACION  14 HG 30.03.21


                    _varTablaEmpleadosObs = $('#TablaListEmpObserv').DataTable({
                        data: response.objeto,
                        columns: [
                            { data: 'strCodEmpleado' },
                            { data: 'strNomCompleto' },
                            { data: 'strObservacion' }
                        ],
                        lengthMenu: [10, 25, 50],
                        order: [2, 'asc'],
                        responsive: true,
                        language: _datatableLanguaje,
                        columnDefs: [],
                        dom: 'lBfrtip',
                    });
                }
            }

            _intIdProceso = response.message
            
        }
    );
}) 





$("#btnEmpContinuar").click(function () {
    validarSession()
    $.post('/Personal/IAusentismos', { intIdProceso: _intIdProceso },
        (response) => {
            listPapeletasReg = [];
            response.objeto.forEach(element => {
                listPapeletasReg.push(element);
            });

            new PNotify({
                title: 'Nueva Permiso',
                text: response.message,
                type: response.type,
                delay: 3000,
                styling: 'bootstrap3'
            });

            $("#archivosNew").fileinput("upload");
            $("#modaldetalle").modal('hide');
            $("#btn-cancel-AusentismosCom").click()
        });
});

$("#IdConCep").change(function () {
    validarFormEdit();
})

$("#IdConCepNew").change(function () {
    validarForm();
})

$("#BitEspecieValNew").change(function () {
    if ($(this).is(":checked")) {
        $("#IdTipoDocNew").attr('disabled', false);
        $("#txtNroCittNew").attr('disabled', false);
        $("#txtEmitidoEnNew").attr('disabled', false);
        $("#txtEmitidoPorNew").attr('disabled', false);
    } else {
        $("#IdTipoDocNew").attr('disabled', true);
        $("#txtNroCittNew").attr('disabled', true);
        $("#txtEmitidoEnNew").attr('disabled', true);
        $("#txtEmitidoPorNew").attr('disabled', true);
    }
})

$("#BitEspecieVal").change(function () {
    if ($(this).is(":checked")) {
        $("#IdTipoDoc").attr('disabled', false);
        $("#txtNroCitt").attr('disabled', false);
        $("#txtEmitidoEn").attr('disabled', false);
        $("#txtEmitidoPor").attr('disabled', false);
    } else {
        $("#IdTipoDoc").attr('disabled', true);
        $("#txtNroCitt").attr('disabled', true);
        $("#txtEmitidoEn").attr('disabled', true);
        $("#txtEmitidoPor").attr('disabled', true);
    }
})

$('#fechaIni').on('dp.change', function () {
    var fechaInicio = $("#fechaIni").val();
    $("#fechaFin").val(fechaInicio);
})

$("#filtroAusentCom").change(function () {
    validarSession()
    traerDatosAusentismos()
})

$("#IntIDEmp2").change(function () {
    validarSession()
    traerDatosAusentismos()
})

$("#filtroActivo").change(function () {
    validarSession()
    traerDatosAusentismos()
})

$('.range-datepicker').on('apply.daterangepicker', function (ev, picker) {
    validarSession()
    if (_codigo != null && _nombre != null && _numDoc != null) {
        verHistoricoEmpAusent(_codigo, _nombre, _numDoc);
    }
});

$("#btn-cancelHistorial").on('click', function () {
    validarSession()
    $(".form-hide-AusentisCom").hide()
});

function validarForm() {

    var conElement = $("#IdConCepNew");

    var strcotipo = conElement.find("option:selected").attr('strcotipo')
    var bitdescontable = conElement.find("option:selected").attr('bitdescontable')

    if (strcotipo == '02') {
        $(".horaRow").hide()
        $(".flgBitDia").hide()
    } else {
        $(".horaRow").show()
        $(".flgBitDia").show()
    }

    if (bitdescontable == "true") {
        $(".flgBitDesontable").show()
    } else {
        $(".flgBitDesontable").hide()
    }

    if (datahorariocheckofinalAu.length == 1 && conElement.val() == "17") {
        $(".especieRow").show()
        flgDESM = true;
    } else {
        $(".especieRow").hide()
        flgDESM = false
    }
}

function validarFormEdit() {

    var conElement = $("#IdConCep");

    var strcotipo = conElement.find("option:selected").attr('strcotipo')
    var bitdescontable = conElement.find("option:selected").attr('bitdescontable')

    if (strcotipo == '02') {
        $(".horaRow").hide()
        $(".flgBitDia").hide()
    } else {
        $(".horaRow").show()
        $(".flgBitDia").show()
    }

    if (bitdescontable == "true") {
        $(".flgBitDesontable").show()
    } else {
        $(".flgBitDesontable").hide()
    }

    if (conElement.val() == "17") {
        $(".especieRow").show()
        flgDESM = true;
    } else {
        $(".especieRow").hide()
        flgDESM = false
    }
}

function onlyNumberKey(evt) {
    // Only ASCII charactar in that range allowed 
    var ASCIICode = (evt.which) ? evt.which : evt.keyCode
    if (ASCIICode > 31 && (ASCIICode < 48 || ASCIICode > 57))
        return false;
    return true;
} 

function timeStringToFloat(time, val) {
    var hoursMinutes = time.split(/[.:]/);
    var hours = parseInt(hoursMinutes[0], 10);
    var minutes = hoursMinutes[1] ? parseInt(hoursMinutes[1], 10) : 0;
    return hours + minutes / 60;
}

function VerDetAusent(intIdPerHorario, strNombres, strNumDoc) {
    validarSession()
    $('#EditAusent').hide();
    _codigo = intIdPerHorario;
    _nombre = strNombres;
    _numDoc = strNumDoc;
    verHistoricoEmpAusent(intIdPerHorario, strNombres, strNumDoc);
}

function ActualizarAusentismos() {
    validarSession()
    var data = $('#archivos').fileinput('getFrames', '.file-preview-initial').children('.file-details-cell').find('.explorer-caption')

    var listPapeletas = [];

    for (var i = data.length >>> 0; i--;) {
        listPapeletas.push(data[i].innerHTML);
    }

    var intIdPerHorario = $('#intID').val();

    var IdConcepto = $('#IdConCep').val();
    var IdCentroCosto = $('#IdCCosto').val();

    var fechaIniEdit = $('#fechaIni').val();
    var fechaFinEdit = $('#fechaFin').val();
    var HoraIni = $('#HoraIni').val();
    var HoraFin = $('#HoraFin').val();

    var Observacion = $('#strObservacion').val();

    var BitDia = 0;
    if ($('#BitDia').is(":checked")) { BitDia = 1; }

    var BitCompensa = false;
    if ($('#BitCompensa').is(":checked")) { BitCompensa = true; }

    var BitEspecieVal = false;
    if ($('#BitEspecieVal').is(":checked")) { BitEspecieVal = true; }

    var BitDiaSgt01 = false;
    if ($('#BitDiaSgt01').is(":checked")) { BitDiaSgt01 = true; }
    var BitDiaSgt02 = false;
    if ($('#BitDiaSgt02').is(":checked")) { BitDiaSgt02 = true; }


    var IntIdTipoDoc = $('#IdTipoDoc').val();
    var strCITT = $('#txtNroCitt').val();
    var strEmitidoEn = $('#txtEmitidoEn').val();
    var strEmitidoPor = $('#txtEmitidoPor').val();
    var BitSustentado = $('#BitSustentado').val();

    var strCoTipo = $('#IdConCep').find("option:selected").attr('strcotipo')

    if (IdConcepto == 0) {

        new PNotify({
            title: 'Asignar el concepto',
            text: 'Completar los campos Obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }
    //if (IdCentroCosto == 0) {

    //    new PNotify({
    //        title: 'Asignar el centro de costo',
    //        text: 'Completar los campos Obligatorios',
    //        type: 'info',
    //        delay: 3000,
    //        styling: 'bootstrap3',
    //        addclass: 'dark'
    //    });

    //    return;
    //}
    if (fechaIni == '' || fechaFin == '') {

        new PNotify({
            title: 'Asignar el las fechas',
            text: 'Completar los campos Obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }
    if (HoraIniNew == '' || HoraFinNew == '') {

        new PNotify({
            title: 'Asignar la hora inicio y hora fin',
            text: 'Completar los campos Obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }


    if (strCoTipo == '01') {
        if (HoraIni == '' || HoraFin == '') {

            new PNotify({
                title: 'Asignar la hora inicio y hora fin',
                text: 'Completar los campos Obligatorios',
                type: 'info',
                delay: 3000,
                styling: 'bootstrap3',
                addclass: 'dark'
            });

            return;
        }

        var hora_ini_val = timeStringToFloat(HoraIni, 2);
        var hora_fin_val = timeStringToFloat(HoraFin, 1);

        if (HoraIni == 0 || HoraFin == 0) {

            new PNotify({
                title: 'Asignar la hora de inicio y hora fin',
                text: 'Completar los campos Obligatorios',
                type: 'info',
                delay: 3000,
                styling: 'bootstrap3',
                addclass: 'dark'
            });

            return;
        }
        if ((BitDiaSgt01 && BitDiaSgt02) || (!BitDiaSgt01 && !BitDiaSgt02)) {
            if (hora_ini_val > hora_fin_val) {

                new PNotify({
                    title: 'La Hora fin debe ser mayor a la hora de inicio',
                    text: 'Ingresar el rango de horas correcto',
                    type: 'info',
                    delay: 3000,
                    styling: 'bootstrap3',
                    addclass: 'dark'
                });

                return;
            }
        } else {
            if (BitDiaSgt01) {
                new PNotify({
                    title: 'La Hora fin debe ser mayor a la hora de inicio',
                    text: 'Ingresar el rango de horas correcto',
                    type: 'info',
                    delay: 3000,
                    styling: 'bootstrap3',
                    addclass: 'dark'
                });

                return;
            }
            else if (BitDiaSgt02) {
                if (hora_fin_val > hora_ini_val) {

                    new PNotify({
                        title: 'La Hora fin debe ser mayor a la hora de inicio',
                        text: 'Ingresar el rango de horas correcto',
                        type: 'info',
                        delay: 3000,
                        styling: 'bootstrap3',
                        addclass: 'dark'
                    });

                    return;
                }
            }
        }

    }

    if ($("#BitEspecieVal").is(':checked')) {
        if (IntIdTipoDoc == 0) {

            new PNotify({
                title: 'Asignar el tipo de documento sustentatorio',
                text: 'Completar los campos Obligatorios',
                type: 'info',
                delay: 3000,
                styling: 'bootstrap3',
                addclass: 'dark'
            });

            return;
        }
        if (strCITT == '') {

            new PNotify({
                title: 'Ingresar el N° CITT',
                text: 'Completar los campos Obligatorios',
                type: 'info',
                delay: 3000,
                styling: 'bootstrap3',
                addclass: 'dark'
            });

            return;
        }
    }
    
    if (!$("#BitEspecieVal").is(':checked')) {
        var IntIdTipoDoc = '';
        var strCITT = '';
        var strEmitidoEn = '';
        var strEmitidoPor = '';
    }


    if (moment(fechaIniEdit, 'DD-MM-YYYY') > moment(fechaFinEdit, 'DD-MM-YYYY')) {

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





    var DatosAusentismo = {
        intIdPerConcepto: intIdPerHorario
        , intIdPersonal: intIdEmpleadoSelect
        , intIdConcepto: IdConcepto
        , IntIdCCosto: IdCentroCosto
        , dttFecha: fechaIniEdit
        , timeHoraIni: HoraIni
        , timeHoraFin: HoraFin
        , strObservacion: Observacion
        , tinDiaPertenen: BitDia
        , bitFlCompensable: BitCompensa
        , bitEspeciValor: BitEspecieVal
        , IntIdTipoDoc: IntIdTipoDoc
        , strCITT: strCITT
        , strNoInstitucion: strEmitidoEn
        , strNoDoctor: strEmitidoPor
        , bitSustentado: BitSustentado
        , bitDiaSgtIni: BitDiaSgt01
        , bitDiaSgtFin: BitDiaSgt02
    }

    console.log(DatosAusentismo);
    console.log(flgDESM);
    $.post(
        '/Personal/UAusentismos',
        {
            objDatos: DatosAusentismo,
            flgDESM: flgDESM
        },
        (response) => {
            if (response.type == 'success') {
                new PNotify({
                    title: 'Actualizar Permiso',
                    text: response.message,
                    type: response.type,
                    delay: 3000,
                    styling: 'bootstrap3'
                });

                intIdPapeleta = intIdPerHorario;

                $.post(
                    '/Personal/ComprobarDocumentos',
                    {
                        intIdPapeleta: intIdPerHorario,
                        listPapeletas: listPapeletas
                    },
                    (response) => {
                        $("#archivos").fileinput("upload");
                        $('#EditAusent').hide();
                        $('#VerHistAuse').hide();
                    });

            } else {
                new PNotify({
                    title: 'Asignación de Permiso',
                    text: response.message,
                    type: response.type,
                    delay: 3000,
                    styling: 'bootstrap3'
                });
            }
        }
    );

}

function verHistoricoEmpAusent(intIdPerHorario2, strNombres, strNumDoc) {
    intIdEmpleadoSelect = intIdPerHorario2
    $('#NombresG').html('<h3>Empleado : ' + strNombres + '</h3>');

    let filtrojer_ini = $('#campJerar').data('daterangepicker').startDate.format('YYYY/MM/DD')
    let filtrojer_fin = $('#campJerar').data('daterangepicker').endDate.format('YYYY/MM/DD')

    $.ajax({
        url: '/Personal/GetTablaAusentismoDet',
        type: 'POST',
        data:
        {
            intIdPerHor: intIdPerHorario2,
            filtrojer_ini,
            filtrojer_fin
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
            console.log(response);
            if (typeof _TablaDetAusentismo !== 'undefined') {
                _TablaDetAusentismo.destroy();
            }

            _TablaDetAusentismo = $('#TablaHistoricoConc').DataTable({
                data: response,
                columns: [
                    { data: 'strCoConcepto' },
                    { data: 'strDesConcepto' },
                    { data: 'dttFecha' },
                    {
                        sortable: false,
                        "render": (data, type, item, meta) => {
                            var intIdPerConcepto = item.intIdPerConcepto;
                            var intIdConcepto = item.intIdConcepto;
                            var strDesConcepto = item.strDesConcepto;
                            var dttFecha = item.dttFecha;
                            var strNombres2 = strNombres;
                            var strNumDoc2 = strNumDoc;

                            return `<button class="btn btn-success btn-xs btn-edit" dataid="${strDesConcepto}" des_data="${dttFecha}"  onclick="EditarAusentismoDet('${strNombres2}', '${strNumDoc2}','${intIdPerConcepto}');"><i class="fa fa-pencil"></i> Editar </button> 
                                    <button class="btn btn-primary btn-xs btn-delete" dataid="${intIdPerConcepto}" des_data="${strDesConcepto}" data_dfec="${dttFecha}" ><i class="fa fa-trash-o"></i> Eliminar </button>`;
                        }
                    },
                    { data: 'intIdPerConcepto' },
                    { data: 'intIdConcepto' }
                ],
                lengthMenu: [10, 25, 50],
                order: [],
                responsive: true,
                language: _datatableLanguaje,
                columnDefs: [
                    {
                        targets: [4],
                        visible: false,
                        searchable: false
                    }, {
                        targets: [5],
                        visible: false,
                        searchable: false
                    }
                ],
                dom: 'lBfrtip',
            });

            $('#TablaHistoricoConc tbody').on('click', 'tr button.btn-delete', function () {
                validarSession()
                var intIdPerHorario = $(this).attr("dataid");

                var strDesConcepto = $(this).attr("des_data");
                var strfeca = $(this).attr("data_dfec");

                if (!isNaN(intIdPerHorario)) {


                    $('#EditHorAsig').hide();
                    $('#FormEditartAuse').hide();
                    $('#VerHist').show();
                    $('#AsigHor').hide();

                    swal({
                        title: "Eliminar Permiso",
                        text: "¿Está seguro de eliminar el Permiso ''<strong>" + strDesConcepto + "</strong>''   para la fecha  " + strfeca + "?",
                        type: "warning",
                        showCancelButton: true,
                        confirmButtonText: "Sí, eliminar",
                        cancelButtonText: "No, cancelar",
                    }).then(function (isConfirm) {
                        validarSession()
                        if (isConfirm) {
                            $.post(
                                '/Personal/EliminarAusentismo',
                                { intIdPerCom: intIdPerHorario },
                                (response) => {
                                    console.log(response);
                                    if (response.type !== '') {
                                        var tipo = 'Eliminado!';
                                        if (response.type === 'error')
                                            tipo = 'NO SE PUEDE ELIMINAR EL REGISTRO';
                                        swal(tipo, response.message, response.type);

                                        if (response.type === 'success')

                                            verHistoricoEmpAusent(intIdPerHorario2, strNombres, strNumDoc);

                                    }
                                }
                            ).fail(function (result) {
                                alert('ERROR ' + result.status + ' ' + result.statusText);
                            });
                        } else {
                            swal("Cancelado", "La Operación fue cancelada", "error");
                        }
                    });


                    $('#btn-cancelHistorial_Edit').on('click', function () {
                        validarSession()
                        $('.form-hide-AusentisCom').show();
                        $('#FormEditartAuse').hide();
                        $('#VerHist').show();

                    });
                }

            });
        },
        complete: function () {
            $.unblockUI();
        }
    });

    //mostrar listado de historial de Ausentismos:
    $('.form-hide-AusentisCom').show();
    //  $('#EditAusent').hide();
    $('#FormEditartAuse').show(); //13.08.2020
    $('#VerHistAuse').show();
    $('#NuevoAuse').hide();

}

function EditarAusentismoDet(strNombres2, strNumDoc2, intIdPerConcepto) {
    validarSession()

    $.post(
        '/Personal/ObtenerAusentismoPorsuPK',
        {
            intId: intIdPerConcepto,

        },
        (response) => {
            console.log(response);

            $('#NomEmpEdit').html('Empleado : ' + strNombres2 + ' - ' + strNumDoc2);

            $('#IdConCep').val(response.intIdConcepto);
            $('#IdTipoDoc').val(response.IntIdTipoDoc);
            $('#IdCCosto').val(response.IntIdCCosto);
            //campos de texto y número.
            $("#fechaIni").val(response.dttFecha);
            $("#fechaFin").val(response.dttFecha);
            $("#strObservacion").val(response.strObservacion);
            $("#txtNroCitt").val(response.strCITT);
            $("#txtEmitidoEn").val(response.strNoInstitucion);
            $("#txtEmitidoPor").val(response.strNoDoctor);

            if (response.bitFlCompensable == true) {
                $("#BitCompensa").iCheck('check');
            } else if (response.bitFlCompensable == false) {
                $('#BitCompensa').iCheck('uncheck');
            }

            if (response.tinDiaPertenen == true) {
                $('#BitDia').iCheck('check');
            } else if (response.tinDiaPertenen == false) {
                $('#BitDia').iCheck('uncheck');
            }

            $("#HoraIni").val(response.timeHoraIni);
            $("#HoraFin").val(response.timeHoraFin);

            $("#intID").val(response.intIdPerConcepto);

            validarFormEdit()

            if (response.bitEspeciValor) {
                $("#BitEspecieVal").prop("checked", true);
                $("#IdTipoDoc").attr('disabled', false);
                $("#txtNroCitt").attr('disabled', false);
                $("#txtEmitidoEn").attr('disabled', false);
                $("#txtEmitidoPor").attr('disabled', false);
            } else {
                $("#BitEspecieVal").prop("checked", false);
                $("#IdTipoDoc").attr('disabled', true);
                $("#txtNroCitt").attr('disabled', true);
                $("#txtEmitidoEn").attr('disabled', true);
                $("#txtEmitidoPor").attr('disabled', true);
            }

            if (response.bitDiaSgtIni) {
                $("#BitDiaSgt01").prop("checked", true);
            } else {
                $("#BitDiaSgt01").prop("checked", false);
            }

            if (response.bitDiaSgtFin) {
                $("#BitDiaSgt02").prop("checked", true);
            } else {
                $("#BitDiaSgt02").prop("checked", false);
            }

            var archivos = [];
            var jsonArchivos = [];

            response.listDocumentos.forEach(element => {
                //archivos += `<a href='${element}' download><img src='${element}' height='120px' class='file-preview-image'></a>`
                archivos.push(element.strRutaDocumento);
                var archivo = { caption: element.strNomDocumento, filename: element.strRutaDocumento, url: 'deleteFile', key: 1 }
                jsonArchivos.push(archivo)
            })

                //"<a href='/DirArchivosPapeleta/Sketchpad.png' download><img src='/DirArchivosPapeleta/Sketchpad.png' height='120px' class='file-preview-image' onClick='test()'></a>"
                //{ caption: "Sketchpad.png", height: "120px", downloadUrl: "/DirArchivosPapeleta/Sketchpad.png", key: "Sketchpad.png"}

            
            if (DocumentosNew) {
                $("#archivos").fileinput('destroy');
            }

            $("#archivos").fileinput({
                language: "es",
                uploadUrl: 'uploadFilesEdit',
                theme: "explorer-fas",
                showUpload: false,
                showRemove: false,
                overwriteInitial: false,
                initialPreviewDownloadUrl: '{filename}',
                initialPreview: archivos,
                initialPreviewConfig: jsonArchivos,
                preferIconicPreview: true, // this will force thumbnails to display icons for following file extensions
                previewFileIconSettings: { // configure your icon file extensions
                    'doc': '<i class="fas fa-file-word text-primary"></i>',
                    'xls': '<i class="fas fa-file-excel text-success"></i>',
                    'ppt': '<i class="fas fa-file-powerpoint text-danger"></i>',
                    'pdf': '<i class="fas fa-file-pdf text-danger"></i>',
                    'zip': '<i class="fas fa-file-archive text-muted"></i>',
                    'htm': '<i class="fas fa-file-code text-info"></i>',
                    'txt': '<i class="fas fa-file-alt text-info"></i>',
                    'mov': '<i class="fas fa-file-video text-warning"></i>',
                    'mp3': '<i class="fas fa-file-audio text-warning"></i>',
                    // note for these file types below no extension determination logic 
                    // has been configured (the keys itself will be used as extensions)
                    'jpg': '<i class="fas fa-file-image text-danger"></i>',
                    'gif': '<i class="fas fa-file-image text-muted"></i>',
                    'png': '<i class="fas fa-file-image text-primary"></i>'
                },
                previewFileExtSettings: { // configure the logic for determining icon file extensions
                    'doc': function (ext) {
                        return ext.match(/(doc|docx)$/i);
                    },
                    'xls': function (ext) {
                        return ext.match(/(xls|xlsx)$/i);
                    },
                    'ppt': function (ext) {
                        return ext.match(/(ppt|pptx)$/i);
                    },
                    'zip': function (ext) {
                        return ext.match(/(zip|rar|tar|gzip|gz|7z)$/i);
                    },
                    'htm': function (ext) {
                        return ext.match(/(htm|html)$/i);
                    },
                    'txt': function (ext) {
                        return ext.match(/(txt|ini|csv|java|php|js|css)$/i);
                    },
                    'mov': function (ext) {
                        return ext.match(/(avi|mpg|mkv|mov|mp4|3gp|webm|wmv)$/i);
                    },
                    'mp3': function (ext) {
                        return ext.match(/(mp3|wav)$/i);
                    }
                },
                uploadExtraData: function (previewId, index) {
                    return { 'intIdPapeleta': JSON.stringify(intIdPapeleta) };
                }
            }).on("filebatchselected", function (event, files) {
                $(".kv-file-upload").remove();
                $(".fileinput-remove").remove();
                });


            DocumentosNew = 1
        });

    $('.form-hide-AusentisCom').show();
    $('#EditAusent').show();
    $('#FormEditartAuse').hide(); //13.08.2020
    $('#VerHistAuse').hide();
    $('#NuevoAuse').hide();

    console.log("MOSTRAR DATOS2");

    $('#btn-cancelHistorial_Edit').on('click', function () {
        validarSession()
        $('#strObservacion').val('');
        $('#txtNroCitt').val('');
        $('#txtEmitidoEn').val('');
        $('#txtEmitidoPor').val('');
        $('#EditAusent').hide();
        $('#FormEditartAuse').hide();
        $('#VerHistAuse').show();
    });



}

function CheckDetHorAuse(IntidHor) {
    const dataGlobalAu = datahorariogLobalAu;
    if (dataGlobalAu == null) {
        return false;
    }

    if ($('#Chck' + IntidHor + '').is(':checked') == true) {
        if (datahorariogLobalAu.find(e => e.intIdPerHorario == IntidHor)) {
            let position = datahorariogLobalAu.findIndex(e => e.intIdPerHorario == IntidHor);
            if (!isNaN(position)) {
                datahorariocheckAu.push(datahorariogLobalAu[position]);
            }
        }
    } else if ($('#Chck' + IntidHor + '').is(':checked') == false) {
        const datahorariocheckoR = datahorariocheckAu;
        if (datahorariocheckAu.find(e => e.intIdPerHorario == IntidHor)) {
            let position = datahorariocheckAu.findIndex(e => e.intIdPerHorario == IntidHor);
            if (!isNaN(position)) {
                datahorariocheckoR.splice(position, 1);
                datahorariocheckAu = datahorariocheckoR;
            }

        }
    }


    var table = $('#datatable-AusentismosCom').DataTable();
    var info = table.page.info();
    $('#TotalPag').val(info.pages);


    var NumTotalChec = datahorariocheckAu.length;
    if (NumTotalChec == 0) {
        $('#All_Horarios_Ause').iCheck('uncheck');
        $('#btn-new-AusentisCom').attr("disabled", true);

    } else {
        $('#btn-new-AusentisCom').attr("disabled", false);
    }
    console.log(NumTotalChec + 'sss');
    if (info.recordsTotal == NumTotalChec) {
        $('#All_Horarios_Ause').iCheck('check');
    }

    function cleanForm() {
        $("#IdConCepNew").val('');
        $("#IdCCostoNew").val(0);

        $('#HoraIniNew').val('00:00');
        $('#HoraFinNew').val('00:00');

        $("#strObservacionNew").val('');
        
        $("#BitDiaNew").prop("checked", false);
        $("#BitCompensaNew").prop("checked", false);

        $("#BitEspecieValNew").prop("checked", false);
        $("#IdTipoDocNew").val('');
        $("#txtNroCittNew").val('');
        $("#txtEmitidoEnNew").val('');
        $("#txtEmitidoPorNew").val('');
        $("#IdTipoDocNew").attr('disabled', true);
        $("#txtNroCittNew").attr('disabled', true);;
        $("#txtEmitidoEnNew").attr('disabled', true);
        $("#txtEmitidoPorNew").attr('disabled', true);

        $("#BitDiaSgt01").prop("checked", false)
        $("#BitDiaSgt02").prop("checked", false)

        $("#archivosNew").fileinput('clear');
    }

    $('#btn-new-AusentisCom').on('click', function () {
        validarSession()
        $('.form-hide-AusentisCom').show();
        $('#VerHistAuse').hide();
        $('#FormEditartAuse').hide();
        $('#EditAusent').hide();

        cleanForm()

        $(".horaRow").hide()
        $(".flgBitDia").hide()

        validarForm();

        $('#fechaIniNew').val(moment().format('DD/MM/YYYY'));
        $('#fechaFinNew').val(moment().format('DD/MM/YYYY'));
        $('#HoraIniNew').val('08:00');
        $('#HoraFinNew').val('09:00');

        $('#NuevoAuse').show();

        datahorariocheckofinalAu = [];
        datahorariocheckofinalAu = datahorariocheckAu.slice();
        if (datahorariocheckofinalAu.length == 1) {
            if (typeof _varTablaAsigHorariosEmple !== 'undefined') {
                _varTablaAsigHorariosEmple.destroy();
            }

            _varTablaAsigHorariosEmple = $('#TablaListEmpAuse').DataTable({
                "searching": false,
                "paging": false,
                "ordering": false,
                "info": false,
                data: datahorariocheckofinalAu,
                columns: [
                    { data: 'strCoPersonal' },
                    { data: 'strNombres' },
                    { data: 'strNumDoc' },
                    { data: 'strDesEmp' },

                    { data: 'intIdPerHorario' },
                    { data: 'intIdPerHorario' }
                ],
                lengthMenu: [10, 25, 50],
                order: [1, 'asc'],
                responsive: true,
                language: _datatableLanguaje,
                columnDefs: [
                    {
                        targets: [4],
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [5],
                        visible: false,
                        searchable: false
                    }
                ],
                dom: 'lBfrtip',
            });

        }
        else if (datahorariocheckofinalAu.length > 1) {
            if (typeof _varTablaAsigHorariosEmple !== 'undefined') {
                _varTablaAsigHorariosEmple.destroy();
            }
            _varTablaAsigHorariosEmple = $('#TablaListEmpAuse').DataTable({
                data: datahorariocheckofinalAu,
                columns: [
                    { data: 'strCoPersonal' },
                    { data: 'strNombres' },
                    { data: 'strNumDoc' },
                    { data: 'strDesEmp' },
                    {
                        sortable: false,
                        "render": (data, type, item, meta) => {
                            let intIdPerHorario = item.intIdPerHorario;

                            return `<input type="button" class="btn btn-danger btn-xs btn-del"  dataid="${intIdPerHorario}" value="Quitar"/> `;
                        }
                    },
                    { data: 'intIdPerHorario' }


                ],
                lengthMenu: [10, 25, 50],
                order: [1, 'asc'],
                responsive: true,
                language: _datatableLanguaje,
                columnDefs: [
                    {
                        targets: [5],
                        visible: false,
                        searchable: false
                    }
                ],
                dom: 'lBfrtip',
            });



        }


    });

    $('#btn-cancel-AusentismosCom').on('click', function () {
        validarSession()
        datahorariocheckofinalAu = [];
        $('.form-hide-AusentisCom').hide();

    });

    $('#TablaListEmpAuse  tbody').on('click', 'tr .btn-del', function () {
        let EmpresaId = $(this).attr("dataid");

        if (!isNaN(EmpresaId)) {

            for (var i = 0; i < datahorariocheckofinalAu.length; i++) {

                if (datahorariocheckofinalAu[i].intIdPerHorario == EmpresaId) {

                    datahorariocheckofinalAu.splice(i, 1);

                    if (datahorariocheckofinalAu.length == 1) {
                        if (typeof _varTablaAsigHorariosEmple !== 'undefined') {
                            _varTablaAsigHorariosEmple.destroy();
                        }

                        _varTablaAsigHorariosEmple = $('#TablaListEmpAuse').DataTable({
                            "searching": false,
                            "paging": false,
                            "ordering": false,
                            "info": false,
                            data: datahorariocheckofinalAu,
                            columns: [
                                { data: 'strCoPersonal' },
                                { data: 'strNombres' },
                                { data: 'strNumDoc' },
                                { data: 'strDesEmp' },
                                { data: 'intIdPerHorario' },
                                { data: 'intIdPerHorario' }
                            ],
                            lengthMenu: [10, 25, 50],
                            order: [1, 'asc'],
                            responsive: true,
                            language: _datatableLanguaje,
                            columnDefs: [
                                {
                                    targets: [4],
                                    visible: false,
                                    searchable: false
                                },
                                {
                                    targets: [5],
                                    visible: false,
                                    searchable: false
                                }
                            ],
                            dom: 'lBfrtip',
                        });

                    }
                    else if (datahorariocheckofinalAu.length > 1) {
                        if (typeof _varTablaAsigHorariosEmple !== 'undefined') {
                            _varTablaAsigHorariosEmple.destroy();
                        }

                        _varTablaAsigHorariosEmple = $('#TablaListEmpAuse').DataTable({
                            data: datahorariocheckofinalAu,
                            columns: [
                                { data: 'strCoPersonal' },
                                { data: 'strNombres' },
                                { data: 'strNumDoc' },
                                { data: 'strDesEmp' },
                                {
                                    sortable: false,
                                    "render": (data, type, item, meta) => {
                                        let intIdPerHorario = item.intIdPerHorario;

                                        return `<input type="button" class="btn btn-danger btn-xs btn-del"  dataid="${intIdPerHorario}" value="Quitar"/> `;
                                    }
                                },
                                { data: 'intIdPerHorario' }


                            ],
                            lengthMenu: [10, 25, 50],
                            order: [1, 'asc'],
                            responsive: true,
                            language: _datatableLanguaje,
                            columnDefs: [
                                {
                                    targets: [5],
                                    visible: false,
                                    searchable: false
                                }
                            ],
                            dom: 'lBfrtip',
                        });


                    }

                }
            }
        }

        validarForm()

    });
}

function CombosAusentismos() {

    const { intIdMenu } = configEmpleadoInicial()

    $.post(
        '/Personal/ListarCombosPersonal',
        { intIdMenu, strEntidad: 'TGCCOSTO', intIdFiltroGrupo: 0, strGrupo: 'TGCCOSTO', strSubGrupo: '' },
        (response) => {
            $('#IdCCostoNew').empty();
            $('#IdCCostoNew').append('<option value="0" selected>Seleccione</option>');
            response.forEach(element => {
                $('#IdCCostoNew').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');
            });

            // Nuevo
            $('#IdCCosto').empty();
            $('#IdCCosto').append('<option value="0" selected>Seleccione</option>');
            response.forEach(element => {
                $('#IdCCosto').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');
            });

        });

    $.post(
        '/Personal/ListarCombosPersonal',
        { intIdMenu, strEntidad: 'TGUNIDORG', intIdFiltroGrupo: 2, strGrupo: 'JERAR', strSubGrupo: '' },
        (response) => {
            $('#IntIDEmp2').empty();
            $('#IntIDEmp2').append('<option value="0" selected>Todos</option>');

            response.forEach(element => {
                $('#IntIDEmp2').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');

            });

        });

    //combo2: Concepto
    $.post(
        '/Personal/ListarCombosPersonal',
        { intIdMenu, strEntidad: 'TGCONCEPTO', intIdFiltroGrupo: 0, strGrupo: 'AUSENTISMO', strSubGrupo: 'AUSENTISMO' },
        (response) => {
            // Editar
            $('#IdConCep').empty();
            $('#IdConCep').append('<option value="" selected>Seleccione</option>');
            response.forEach(element => {
                $('#IdConCep').append('<option bitDescontable=' + element.bitFlActivo + ' strCoTipo=' + element.strCoTipo + ' value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');
            });

            // Nuevo
            $('#IdConCepNew').empty();
            $('#IdConCepNew').append('<option value="" selected>Seleccione</option>');
            response.forEach(element => {
                $('#IdConCepNew').append('<option bitDescontable=' + element.bitFlActivo + ' strCoTipo=' + element.strCoTipo + ' value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');
            });
        });


    //combo3: Tipos de Doc. Sustentatorio
    $.post(
        '/Personal/ListarCombosPersonal',
        { intIdMenu, strEntidad: 'TGTIPO', intIdFiltroGrupo: 0, strGrupo: 'PAPELETA', strSubGrupo: 'DM' },
        (response) => {
             // Editar
            $('#IdTipoDoc').empty();
            $('#IdTipoDoc').append('<option value="" selected>Seleccione</option>');
            response.forEach(element => {
                $('#IdTipoDoc').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');
            });

             // Nuevo
            $('#IdTipoDocNew').empty();
            $('#IdTipoDocNew').append('<option value="" selected>Seleccione</option>');
            response.forEach(element => {
                $('#IdTipoDocNew').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');
            });

        });


}

function traerDatosAusentismos() {
    var Activos = $("#filtroActivo").val();
    var strFiltro = $('#filtroAusentCom').val();
    var idEmp = $('#IntIDEmp2 option:selected').val();
    let filtrojer_ini = moment().subtract(30, 'year').startOf('year').format('DD/MM/YYYY');
    let filtrojer_fin = moment().subtract(10, "year").endOf("year").format('DD/MM/YYYY');

    $.ajax({
        url: '/Personal/GetTablaAsigHorario',
        type: 'POST',
        data:
        {
            IntActivoFilter: Activos,
            strfilter: strFiltro,
            IntIdEmp: idEmp,
            dttfiltrofch1: filtrojer_ini,
            dttfiltrofch2: filtrojer_fin
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
            console.log(response);
            datahorariogLobalAu = response

            if (typeof _varTablaAusentismos !== 'undefined') {
                _varTablaAusentismos.destroy();
            }

            _varTablaAusentismos = $('#datatable-AusentismosCom').DataTable({
                data: response,
                columns: [
                    {
                        sortable: false,
                        "render": (data, type, item, meta) => {
                            let strCoPersonal = item.strCoPersonal;
                            let strNombres = item.strNombres;
                            let strNumDoc = item.strNumDoc;
                            let dttFechAsig = item.dttFechAsig;
                            let strDesEmp = item.strDesEmp;
                            let intIdPerHorario = item.intIdPerHorario;
                            
                            return `<input type="checkbox" class="HorInd"  id="Chck${intIdPerHorario}"
                                data_strco="${strCoPersonal}" data_strNom="${strNombres}"  data_strNumDoc="${strNumDoc}"
                                data_fecasig="${dttFechAsig}" data_strdesemp="${strDesEmp}"  data_intIdPers="${intIdPerHorario}"  onChange="CheckDetHorAuse(${intIdPerHorario})"/>`;
                        }
                    },
                    { data: 'strCoPersonal' },
                    { data: 'strNombres' },
                    { data: 'strNumDoc' },
                    { data: 'dttFechAsig' },
                    { data: 'strDesEmp' },
                    {
                        sortable: false,
                        "render": (data, type, item, meta) => {
                            let intIdPerHorario = item.intIdPerHorario;
                            let strNombres = item.strNombres;
                            let strNumDoc = item.strNumDoc;

                            return `<button class="btn btn-success btn-xs btn-edit"  onclick="VerDetAusent('${intIdPerHorario}','${strNombres}','${strNumDoc}');"><i class="fa fa-pencil"></i> Ver </button> `;
                        }
                    },
                    { data: 'intIdPerHorario' }
                ],
                lengthMenu: [10, 25, 50],
                order: [],
                responsive: true,
                language: _datatableLanguaje,
                columnDefs: [
                    {
                        targets: [7],
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [0],
                        data: null,
                        defaultContent: '',
                        orderable: false,
                        className: 'select-checkbox'
                    }],
                dom: 'lBfrtip',
            });

            var allPagesAu = _varTablaAusentismos.cells().nodes();
            $('#All_Horarios_Ause').on('change', function () {

                if ($('#All_Horarios_Ause').is(':checked')) {

                    $('#btn-new-AusentisCom').attr('disabled', false);
                    datahorariocheckAu = datahorariogLobalAu
                    //$(allPages).find('input[type="checkbox"]').iCheck('check');
                    $(allPagesAu).find('input[type="checkbox"]').prop('checked', true);
                } else {
                    $('#btn-new-AusentisCom').attr('disabled', true);

                    datahorariocheckAu = []
                    //$(allPages).find('input[type="checkbox"]').iCheck('uncheck');
                    $(allPagesAu).find('input[type="checkbox"]').prop('checked', false);

                }


            });
        },
        complete: function () {
            $.unblockUI();
        }
    });

}

$(document).ready(function () {

    $("#archivosNew").fileinput({
        language: "es",
        uploadUrl: 'UploadFiles',
        theme: "explorer-fas",
        showUpload: false,
        showRemove: false,
        preferIconicPreview: true, // this will force thumbnails to display icons for following file extensions
        previewFileIconSettings: { // configure your icon file extensions
            'doc': '<i class="fas fa-file-word text-primary"></i>',
            'xls': '<i class="fas fa-file-excel text-success"></i>',
            'ppt': '<i class="fas fa-file-powerpoint text-danger"></i>',
            'pdf': '<i class="fas fa-file-pdf text-danger"></i>',
            'zip': '<i class="fas fa-file-archive text-muted"></i>',
            'htm': '<i class="fas fa-file-code text-info"></i>',
            'txt': '<i class="fas fa-file-alt text-info"></i>',
            'mov': '<i class="fas fa-file-video text-warning"></i>',
            'mp3': '<i class="fas fa-file-audio text-warning"></i>',
            // note for these file types below no extension determination logic 
            // has been configured (the keys itself will be used as extensions)
            'jpg': '<i class="fas fa-file-image text-danger"></i>',
            'gif': '<i class="fas fa-file-image text-muted"></i>',
            'png': '<i class="fas fa-file-image text-primary"></i>'
        },
        previewFileExtSettings: { // configure the logic for determining icon file extensions
            'doc': function (ext) {
                return ext.match(/(doc|docx)$/i);
            },
            'xls': function (ext) {
                return ext.match(/(xls|xlsx)$/i);
            },
            'ppt': function (ext) {
                return ext.match(/(ppt|pptx)$/i);
            },
            'zip': function (ext) {
                return ext.match(/(zip|rar|tar|gzip|gz|7z)$/i);
            },
            'htm': function (ext) {
                return ext.match(/(htm|html)$/i);
            },
            'txt': function (ext) {
                return ext.match(/(txt|ini|csv|java|php|js|css)$/i);
            },
            'mov': function (ext) {
                return ext.match(/(avi|mpg|mkv|mov|mp4|3gp|webm|wmv)$/i);
            },
            'mp3': function (ext) {
                return ext.match(/(mp3|wav)$/i);
            }
        },
        uploadExtraData: function (previewId, index) {
            return { 'dato': JSON.stringify(listPapeletasReg) };
        }
    }).on("filebatchselected", function(event, files) {
            $(".fileinput-remove").remove();
            $(".kv-file-upload").remove();
        });

    CombosAusentismos();
    traerDatosAusentismos();

    $('#fechaIni').datetimepicker({
        viewMode: 'days',
        format: 'DD/MM/YYYY'
    });

    $('#fechaFin').datetimepicker({
        viewMode: 'days',
        format: 'DD/MM/YYYY'
    });

    $('#fechaIniNew').datetimepicker({
        viewMode: 'days',
        format: 'DD/MM/YYYY'
    });

    $('#fechaFinNew').datetimepicker({
        viewMode: 'days',
        format: 'DD/MM/YYYY'
    });

})
