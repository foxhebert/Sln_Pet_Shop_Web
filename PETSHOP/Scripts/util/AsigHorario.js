let _intIdProceso;
var _codigo;
var _nombre;
var _numDoc;
var _intidUniOrg;

function CombosAsigHorario() {

    $.post(
        '/Personal/ListarCombosPersonal',
        { intIdMenu : 0, strEntidad: 'TGUNIDORG', intIdFiltroGrupo: 2, strGrupo: 'JERAR', strSubGrupo: '' },
        (response) => {
            $('#IntIDEmp').empty();
            $('#IntIDEmp').append('<option value="0" selected>Todos</option>');

            response.forEach(element => {
                $('#IntIDEmp').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');

            });

        });

}

function getDateRangePickerPeriodo() {
    const idRange = ".range-datepicker";
    const fechaInicio = $(idRange).data('daterangepicker').startDate.format('DD/MM/YYYY');
    const fechaFin = $(idRange).data('daterangepicker').endDate.format('DD/MM/YYYY');
    return { fInicio: fechaInicio, fFin: fechaFin }
}

$('#IntIDEmp').on('change', function () {
    validarSession()
    traerDatosAsigHorario()
});

$('#filtroAsigHorCom').change(function () {
    validarSession()
    traerDatosAsigHorario()
});

$('.range-datepicker').on('apply.daterangepicker', function (ev, picker) {
    validarSession()
    if (_codigo != null && _nombre != null && _numDoc != null) {
        verHistoricoEmp(_codigo, _nombre, _numDoc);
    }
});

$("#filtroActivo").change(function () {
    validarSession()
    traerDatosAsigHorario()
})

$('#btn-cancelHistorial').on('click', function () {
    validarSession()
    $('.form-hide-AusentisCom').hide();
    $('.form-hide-AusentisCom').hide();
    $('.form-hide-AsighorarioCom').hide();


});

var _varTablaAsigHorarios;
var _varTablaAsigHorariosEmple;
let datahorariogLobal = null;
let datahorariocheck = [];
var datahorariocheckofinal = [];

function CheckDetHor(IntidHor) {

    const dataGlobal = datahorariogLobal;
    if (dataGlobal == null) {
        return false;
    }

    if ($('#Chck' + IntidHor + '').is(':checked') == true) {
        $('#btn-new-AsighorarioCom').removeAttr("disabled");
        if (datahorariogLobal.find(e => e.intIdPerHorario == IntidHor)) {
            let position = datahorariogLobal.findIndex(e => e.intIdPerHorario == IntidHor);  //ln45781 e.intIdPerHorario IntidHor
            if (!isNaN(position)) {
                datahorariocheck.push(datahorariogLobal[position]);
            }
        }
    }

    else if ($('#Chck' + IntidHor + '').is(':checked') == false) {
        const datahorariocheckoR = datahorariocheck;
        if (datahorariocheck.find(e => e.intIdPerHorario == IntidHor)) {
            let position = datahorariocheck.findIndex(e => e.intIdPerHorario == IntidHor);
            if (!isNaN(position)) {
                datahorariocheckoR.splice(position, 1);
                datahorariocheck = datahorariocheckoR;
            }
        }
    }

    var table = $('#datatable-AsighorarioCom').DataTable();
    var info = table.page.info();
    $('#TotalPag').val(info.pages);

    var NumTotalChec = datahorariocheck.length;

    if (NumTotalChec == 0) {
        $('#All_Horarios').iCheck('uncheck');
        $('#btn-new-AsighorarioCom').attr("disabled");
    }

    if (info.recordsTotal == NumTotalChec) {
        $('#All_Horarios').iCheck('check');
    }
}

$('#btn-new-AsighorarioCom').on('click', function () {
    validarSession()
    var primerUO = datahorariocheck[0].intUniOrg
    if (!datahorariocheck.every(item => item.intUniOrg === primerUO)) {
        swal("Asignar Horario", "No puede asignar horario a empleados con diferente Unidad Organizacional", "info");
        return;
    }
    

    $('.form-hide-AsighorarioCom').show();
    $('#VerHist').hide();
    $('#EditHorAsig').hide();
    $('#AsigHor').show();
    $("#fechaAsig").val(moment().format('DD/MM/YYYY'))

    datahorariocheckofinal = [];
    datahorariocheckofinal = datahorariocheck.slice();

    if (datahorariocheckofinal.length == 1) {
        if (typeof _varTablaAsigHorariosEmple !== 'undefined') {
            _varTablaAsigHorariosEmple.destroy();
        }

        _varTablaAsigHorariosEmple = $('#TablaListEmp').DataTable({
            data: datahorariocheckofinal,
            columns: [
                { data: 'strCoPersonal' },
                { data: 'strNombres' },
                { data: 'strNumDoc' },
                { data: 'strDesEmp' },
                { data: 'intIdPerHorario' },
                { data: 'intIdPerHorario' }
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
    else if (datahorariocheckofinal.length > 1) {
        if (typeof _varTablaAsigHorariosEmple !== 'undefined') {
            _varTablaAsigHorariosEmple.destroy();
        }

        _varTablaAsigHorariosEmple = $('#TablaListEmp').DataTable({
            data: datahorariocheckofinal,
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
            order: [],
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

    $.post(
        '/Personal/ListarCombosPersonal',
        { intIdMenu: 0, strEntidad: 'TGHORARIO', intIdFiltroGrupo: primerUO, strGrupo: 'COM', strSubGrupo: '' },
        (response) => {
            $('#IdHorCom').empty();
            $('#IdHorCom').append('<option value="0" selected>Seleccione</option>');
            response.forEach(element => {
                $('#IdHorCom').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');
            });
            $("#IdHorCom").val(0)
        });


});

$('#btn-cancel-AsighorarioCom').on('click', function () {
    validarSession()
    datahorariocheckofinal = [];
    $('.form-hide-AsighorarioCom').hide();

});

$('#TablaListEmp  tbody').on('click', 'tr .btn-del', function () {
    let EmpresaId = $(this).attr("dataid");
    if (!isNaN(EmpresaId)) {
        for (var i = 0; i < datahorariocheckofinal.length; i++) {
            if (datahorariocheckofinal[i].intIdPerHorario == EmpresaId) {
                datahorariocheckofinal.splice(i, 1);
                if (datahorariocheckofinal.length == 1) {
                    if (typeof _varTablaAsigHorariosEmple !== 'undefined') {
                        _varTablaAsigHorariosEmple.destroy();
                    }

                    _varTablaAsigHorariosEmple = $('#TablaListEmp').DataTable({
                        data: datahorariocheckofinal,
                        columns: [
                            { data: 'strCoPersonal' },
                            { data: 'strNombres' },
                            { data: 'strNumDoc' },
                            { data: 'strDesEmp' },
                            { data: 'intIdPerHorario' },
                            { data: 'intIdPerHorario' }
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
                else if (datahorariocheckofinal.length > 1) {
                    if (typeof _varTablaAsigHorariosEmple !== 'undefined') {
                        _varTablaAsigHorariosEmple.destroy();
                    }

                    _varTablaAsigHorariosEmple = $('#TablaListEmp').DataTable({
                        data: datahorariocheckofinal,
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
                        order: [],
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
        console.log(datahorariocheckofinal.length);
    }
});

function traerDatosAsigHorario() {

    var Activo = $("#filtroActivo").val();
    var strFiltro = $('#filtroAsigHorCom').val();
    var IntIdEmp = $('#IntIDEmp option:selected').val();
    let filtrojer_ini = moment().subtract(30, 'year').startOf('year').format('DD/MM/YYYY');
    let filtrojer_fin = moment().subtract(10, "year").endOf("year").format('DD/MM/YYYY');

    $.ajax({
        url: '/Personal/GetTablaAsigHorario',
        type: 'POST',
        data:
        {
            IntActivoFilter: Activo,
            strfilter: strFiltro,
            IntIdEmp: IntIdEmp,
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
            datahorariogLobal = response
            console.log(response);

            if (typeof _varTablaAsigHorarios !== 'undefined') {
                _varTablaAsigHorarios.destroy();
            }

            _varTablaAsigHorarios = $('#datatable-AsighorarioCom').DataTable({
                stateSave: true,
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
                            let intIdUniOrg = item.intUniOrg;

                            //Hebert_24.10.120_12:32:9
                            return `<input 
                                           type="checkbox" 
                                           class="HorInd"  
                                           id="Chck${intIdPerHorario}"
                                           data_strco="${strCoPersonal}" 
                                           data_strNom="${strNombres}"  
                                           data_strNumDoc="${strNumDoc}"                                
                                           data_fecasig="${dttFechAsig}" 
                                           data_strdesemp="${strDesEmp}"  
                                           data_intIdPers="${intIdPerHorario}"
                                           data_intIdUniOrg="${intIdUniOrg}" 
                                           onchange="CheckDetHor(${intIdPerHorario});"                                          
                                     />`;
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
                            let intIdUniOrg = item.intUniOrg;
                            //Listado de Empleado_Primera Columna
                            return `<button class="btn btn-success btn-xs btn-edit"  onclick="VerDetAsigHor('${intIdPerHorario}','${strNombres}','${strNumDoc}','${intIdUniOrg}');"><i class="fa fa-pencil"></i> Ver </button> `;
                        }
                    },
                    { data: 'intIdPerHorario' }

                ],

                lengthMenu: [10, 25, 50],
                order: [],
                responsive: true,
                language: _datatableLanguaje,
                columnDefs:
                    [
                        {
                            targets: [7],
                            visible: false,
                            searchable: false
                        },
                        {
                            targets: [0], //Primera columna [0]
                            data: null,
                            defaultContent: '',
                            orderable: false,
                            className: 'select-checkbox'
                        }
                    ],
                dom: 'lBfrtip',
            });


            //var table = $('#datatable-AsighorarioCom').DataTable();
            //var info = table.page.info();
            //$('#TotalPag').val(info.pages);

            var allPages = _varTablaAsigHorarios.cells().nodes();

            $('#All_Horarios').on('change', function () {

                if ($('#All_Horarios').is(':checked')) {

                    $('#btn-new-AsighorarioCom').removeAttr("disabled");
                    datahorariocheck = datahorariogLobal
                    //$(allPages).find('input[type="checkbox"]').iCheck('check');
                    $(allPages).find('input[type="checkbox"]').prop('checked', true);
                } else {
                    $('#btn-new-AsighorarioCom').attr('disabled');

                    datahorariocheck = []
                    //$(allPages).find('input[type="checkbox"]').iCheck('uncheck');
                    $(allPages).find('input[type="checkbox"]').prop('checked', false);

                }

            });
        },
        complete: function () {
            $.unblockUI();
        }
    });
}

function VerDetAsigHor(intIdPerHorario, strNombres, strNumDoc, intidUniOrg) {
    validarSession()
    _codigo = intIdPerHorario;
    _nombre = strNombres;
    _numDoc = strNumDoc;
    _intidUniOrg = intidUniOrg;
    verHistoricoEmp(intIdPerHorario, strNombres, strNumDoc);
}

function traerDatosAsigHorarioEmple() {

    console.log(datahorariocheckofinal);

    if (typeof _varTablaAsigHorariosEmple !== 'undefined') {
        _varTablaAsigHorariosEmple.destroy();
    }

    if (datahorariocheckofinal.length == 1) {


        _varTablaAsigHorariosEmple = $('#TablaListEmp').DataTable({
            data: datahorariocheckofinal,
            columns: [

                { data: 'strCoPersonal' },
                { data: 'strNombres' },
                { data: 'strNumDoc' },
                { data: 'strDesEmp' },
                { data: 'intIdPerHorario' },
                { data: 'intIdPerHorario' }

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
    else if (datahorariocheckofinal.length > 1) {


        _varTablaAsigHorariosEmple = $('#TablaListEmp').DataTable({
            data: datahorariocheckofinal,
            columns: [

                { data: 'strCoPersonal' },
                { data: 'strNombres' },
                { data: 'strNumDoc' },
                { data: 'strDesEmp' },


                {
                    sortable: false,
                    "render": (data, type, item, meta) => {
                        let intIdPerHorario = item.intIdPerHorario;

                        return `<input type="button" class="btn btn-primary btn-xs btn-del" onClick="EliminarEmp(${intIdPerHorario})" dataid="${intIdPerHorario}" value="Quitar"/> `;
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
                    targets: [5],
                    visible: false,
                    searchable: false
                }
            ],
            dom: 'lBfrtip',
        });
    }



}

var DetalleListEmp2 = new Array();
class DetalleListEmp {
    constructor(codigo, NombreA, DocIden, HorAct, Empresa, intIdPerHorario) {
        this.codigo = codigo
        this.NombreA = NombreA
        this.DocIden = DocIden
        this.HorAct = HorAct
        this.Empresa = Empresa
        this.intIdPerHorario = intIdPerHorario

    }
}
class DetalleListEmpSave {
    constructor(intIdPersonal, intIdSoftw, intIdHorario, dttFecAsig, bitFlEliminado, IntIdUsuarReg, dttFeRegistro) {
        this.intIdPersonal = intIdPersonal
        this.intIdSoftw = intIdSoftw
        this.intIdHorario = intIdHorario
        this.dttFecAsig = dttFecAsig
        this.bitFlEliminado = bitFlEliminado
        this.IntIdUsuarReg = IntIdUsuarReg
        this.dttFeRegistro = dttFeRegistro

    }
}

$(function () {
    $("#finalizar_observados").click(function () {
        //alert('button clicked');
        $('#AsigHor').hide();
    }
    );
});

var detalleListEmpReg = new Array();
var _varTablaAsigHorariosObs;

$('#btn-save-change-AsighorarioCom').on('click', function () {
    validarSession()
    var _IdHorCom = $('#IdHorCom').val();
    var _FechaAsig = $('#fechaAsig').val();

    if (_IdHorCom == 0 || _FechaAsig == '') {
        new PNotify({
            title: 'Asignar Horario',
            text: 'Complete los Campos Obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }

    //CONTAR ENVIADOS
    var NUMENV = datahorariocheckofinal.length;
    console.log(NUMENV);

    $.post(
        '/Personal/IUREGAsigHor',
        { listaDetalleHorAsigEmp: datahorariocheckofinal, intIdHorario: _IdHorCom, dttFecAsig: _FechaAsig },
        (response) => {
            if (response.type == 'success') {
                new PNotify({
                    title: 'Nueva Asignación de Horario',
                    text: response.message,
                    type: response.type,
                    delay: 3000,
                    styling: 'bootstrap3'
                });

                $("#btn-cancel-AsighorarioCom").click()
                traerDatosAsigHorario()
                datahorariocheck = []
                return;
            } else {
                if (response.objeto.length == datahorariocheckofinal.length) {
                    if (response.objeto.length == 1) {
                        new PNotify({
                            title: 'Nueva Asignación de Horario',
                            text: response.objeto[0].strObservacion,
                            type: response.type,
                            delay: 3000,
                            styling: 'bootstrap3'
                        });
                        return;
                    } else {
                        new PNotify({
                            title: 'Nueva Asignación de Horario',
                            text: 'Todos los empleados se encuentran observados, verificar fecha de inicio',
                            type: response.type,
                            delay: 3000,
                            styling: 'bootstrap3'
                        });
                        return;
                    }
                }
                else {
                    if ($.fn.DataTable.isDataTable('#TablaListEmpObserv')) {
                        _varTablaEmpleadosObs.destroy();
                    }

                    $("#totalEmpleados").html(datahorariocheckofinal.length)
                    $("#totalEmpleadosObs").html(response.objeto.length)
                    $("#textoModal").html("empleado ya tiene asignación registrada para la fecha ingresada.")
                    if (response.objeto.length > 1) {
                        $("#textoModal").html("empleados ya tienen asignaciones registradas para la fecha ingresada.")
                    }

                    $("#modaldetalle").modal('show');
                    _varTablaEmpleadosObs = $('#TablaListEmpObserv').DataTable({
                        data: response.objeto,
                        columns: [
                            { data: 'strCodEmpleado' },
                            { data: 'strNomCompleto' },
                            { data: 'strObservacion' }
                        ],
                        lengthMenu: [10, 25, 50],
                        order: [],
                        responsive: true,
                        language: _datatableLanguaje,
                        columnDefs: [],
                        dom: 'lBfrtip',
                    });
                }
                _intIdProceso = response.message
            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });

});

var _TablaDetAsigHor;
function verHistoricoEmp(intIdPerHorario2, strNombres, strNumDoc, intidUniOrg) {

    $('#NombresG').html('<h3>Empleado : ' + strNombres + '</h3>');
    $('#EditHorAsig').hide();

    let filtrojer_ini = $('#campJerar').data('daterangepicker').startDate.format('YYYY/MM/DD')
    let filtrojer_fin = $('#campJerar').data('daterangepicker').endDate.format('YYYY/MM/DD')

    $.post(
        '/Personal/GetTablaAsigHorarioDet',
        {
            intIdPerHor: intIdPerHorario2,
            filtrojer_ini,
            filtrojer_fin
        },
        (response) => {
            console.log(response);
            console.log(response.length);

            if (typeof _TablaDetAsigHor !== 'undefined') {
                _TablaDetAsigHor.destroy();
            }

            _TablaDetAsigHor = $('#TablaHistoricoHor').DataTable({
                data: response,
                columns: [
                    { data: 'strCoHorario' },
                    { data: 'strDescHorario' },
                    { data: 'dttFechAsig' },
                    {
                        sortable: false,
                        "render": (data, type, item, meta) => {
                            var intIdPerHorario = item.intIdPerHorario;
                            var intIdHorario = item.intIdHorario;
                            var strDescHorario = item.strDescHorario;
                            var dttFechAsig = item.dttFechAsig;
                            var strNombres2 = strNombres;
                            var strNumDoc2 = strNumDoc;
                            var intIdUniOrg = item.intUniOrg;

                            return `<button class="btn btn-success btn-xs btn-edit" dataid="${strDescHorario}" des_data="${dttFechAsig}"  onclick="EditarHorDet('${strNombres2}', '${strNumDoc2}','${intIdPerHorario}','${intIdHorario}','${dttFechAsig}');"><i class="fa fa-pencil"></i> Editar </button> 
                                           <button class="btn btn-primary btn-xs btn-delete" dataid="${intIdPerHorario}" des_data="${strDescHorario}" data_fec="${dttFechAsig}"  ><i class="fa fa-trash-o"></i> Eliminar </button>`;
                        }
                    },
                    { data: 'intIdPerHorario' },
                    { data: 'intIdHorario' }

                ],
                lengthMenu: [10, 25, 50],
                order: [], //columna ascendente o descendente ln46004
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


            ////$('#mi_boton').click();
            //////hebert_mpah_22102020_19:11PM
            //$('#TablaHistoricoHor thead tr').append('<th class="sorting_asc" tabindex="0" aria-controls="TablaHistoricoHor" rowspan="1" colspan="1" style="width: 84.8889px;" aria-label="Fecha Inicio: activate to sort column descending" aria-sort="ascending">Fecha Inicio333</th>')


            $('#TablaHistoricoHor tbody').on('click', 'tr button.btn-delete', function () {
                validarSession()
                var intIdPerHorario = $(this).attr("dataid")

                var strDescHorario = $(this).attr("des_data")
                var strfec = $(this).attr("data_fec")

                if (!isNaN(intIdPerHorario)) {


                    $('#EditHorAsig').hide();
                    $('#VerHist').show();
                    $('#AsigHor').hide();

                    swal({
                        title: "Eliminar Horario Asignado",
                        text: "¿Está seguro de eliminar el Horario Asignado ''<strong>" + strDescHorario + "</strong>''  para la fecha " + strfec + "?",
                        type: "warning",
                        showCancelButton: true,
                        confirmButtonText: "Sí, eliminar",
                        cancelButtonText: "No, cancelar",
                    }).then(function (isConfirm) {
                        validarSession()
                        $.post(
                            '/Personal/EliminarAsigHor',
                            { intIdPerHor: intIdPerHorario },
                            (response) => {
                                console.log(response);
                                if (response.type !== '') {
                                    var tipo = 'Eliminado!';
                                    if (response.type === 'error')
                                        tipo = 'NO SE PUEDE ELIMINAR EL REGISTRO';
                                    swal(tipo, response.message, response.type);

                                    if (response.type === 'success')

                                        verHistoricoEmp(intIdPerHorario2, strNombres, strNumDoc);

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


                    $('#btn-cancelHistorial_Edit').on('click', function () {
                        validarSession()
                        $('#EditHorAsig').hide();
                        $('#VerHist').show();

                    });
                }

            });


        });


    $('.form-hide-AsighorarioCom').show();
    $('#VerHist').show();
    $('#AsigHor').hide();
}

function EditarHorDet(strNombres, strNumDoc, intIdPerHorario, intIdHorario, dttFechAsig) {
    validarSession()

    $('#NomEmpEdit').html('Empleado : ' + strNombres + ' - ' + strNumDoc);
    if (!isNaN(intIdPerHorario)) {

        $("#IntIdPe").val(intIdPerHorario);
        $("#fechaAsigEdit").val(dttFechAsig)
        $('#EditHorAsig').show();
        $('#VerHist').hide();
        $('#AsigHor').hide();

        $.post(
            '/Personal/ListarCombosPersonal',
            { intIdMenu: 0, strEntidad: 'TGHORARIO', intIdFiltroGrupo: _intidUniOrg, strGrupo: 'COM', strSubGrupo: '' },
            (response) => {
                $('#IdHorComEdit').empty();
                $('#IdHorComEdit').append('<option value="0" selected>Seleccione</option>');
                response.forEach(element => {
                    $('#IdHorComEdit').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');
                });
                $("#IdHorComEdit").val(intIdHorario);
            });


        $('#btn-cancelHistorial_Edit').on('click', function () {
            validarSession()
            $('#IdHorComEdit').val(0);
            $('#fechaAsigEdit').val('');
            $('#EditHorAsig').hide();
            $('#VerHist').show();

        });
    }

}

function ActualizarAsigDetHor() {
    validarSession() 
    var IntiDHor = $('#IdHorComEdit').val();
    var DttFecAsig = $('#fechaAsigEdit').val();
    var intIdPerHorario = $("#IntIdPe").val();

    if (IntiDHor == 0 || DttFecAsig == '') {

        new PNotify({
            title: 'Asignar Horario',
            text: 'Complete los campos Obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }

    $.post(
        '/Personal/IUAsigHor',
        {
            intIdPerHor: intIdPerHorario
            , intIdHorario: IntiDHor
            , dttFecAsig: DttFecAsig
        },
        (response) => {
            console.log(response);
            if (response.type !== '') {

                if (response.type === 'success') {
                    new PNotify({
                        title: 'Actualizar Horario Asignado',
                        text: response.message,
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'
                    });
                    $('#EditHorAsig').hide();
                    $('#VerHist').hide();
                    traerDatosAsigHorario()
                    return;
                } else {

                    if (response.type === 'error') {
                        new PNotify({
                            title: 'Asignación de Horario',
                            text: response.message,
                            type: 'info',
                            delay: 3000,
                            styling: 'bootstrap3'
                        });
                        return;
                    } else {
                    }
                }
            }
        }
    );



}

$("#btnEmpContinuar").click(function () {
    validarSession()
    $.post('/Personal/IUREGAsigHorPost', { intIdProceso: _intIdProceso },
        (response) => {

            new PNotify({
                title: 'Nueva Asignación de Horario',
                text: response.message,
                type: response.type,
                delay: 3000,
                styling: 'bootstrap3'
            });

            $("#modaldetalle").modal('hide');
            $("#btn-cancel-AsighorarioCom").click()
            traerDatosAsigHorario()
            datahorariocheck = []

        });
});
