//////////var _varTablaCambioDI;

//////////function getTableCambiosDI(filtrojer_ini_var = null, filtrojer_fin_var = null) {

//////////    var buscarId = $("#buscarId").val()
//////////    var empresaId = parseInt($("#empresaId").val())

//////////    let filtrojer_ini = filtrojer_ini_var ? filtrojer_ini_var : null;
//////////    let filtrojer_fin = filtrojer_fin_var ? filtrojer_fin_var : null;

//////////    $.ajax({
//////////        url: '/Personal/ListarCambioDI',
//////////        type: 'POST',
//////////        data: {
//////////            buscarId: buscarId,
//////////            empresaId: empresaId,
//////////            filtrojer_ini: filtrojer_ini,
//////////            filtrojer_fin: filtrojer_fin
//////////        },
//////////        beforeSend: function () {
//////////            $.blockUI({
//////////                css: {
//////////                    border: 'none',
//////////                    padding: '15px',
//////////                    backgroundColor: '#000',
//////////                    '-webkit-border-radius': '10px',
//////////                    '-moz-border-radius': '10px',
//////////                    opacity: .5,
//////////                    color: '#fff'
//////////                },
//////////                message: 'Procesando...'
//////////            });
//////////        },
//////////        success: function (response) {
//////////            console.log(response)

//////////            if (typeof _varTablaCambioDI !== 'undefined') {
//////////                _varTablaCambioDI.destroy();
//////////            }

//////////            _varTablaCambioDI = $('#datatable-CambiosDI').DataTable({
//////////                data: response,
//////////                columns: [
//////////                    { data: 'strNumDocNew' },
//////////                    { data: 'strNomCompleto' },
//////////                    { data: 'strNumDocAnt' },
//////////                    { data: 'strUniOrg' },
//////////                    { data: 'strNomUsuarReg' },
//////////                    { data: 'dttFeRegistro' },
//////////                ],
//////////                lengthMenu: [10, 25, 50],
//////////                order: [],
//////////                responsive: true,
//////////                language: _datatableLanguaje,
//////////                columnDefs: [],
//////////                dom: 'lBfrtip',
//////////            });
//////////        },
//////////        complete: function () {
//////////            $.unblockUI();
//////////        }
//////////    })
//////////}

//////////function cleanForm() {
//////////    $("#newTipoDocId").attr('disabled', true)
//////////    $("#newNumDocId").attr('disabled', true)

//////////    $("#newTipoDocId").val(0)
//////////    $("#newNumDocId").val("")
//////////    $('#apeId').val("")
//////////    $('#nomId').val("")
//////////    $('#codEmpId').val("")
//////////    $('#numRegId').val("")
//////////    $('#fotocheckId').val("")
//////////    $('#uniOrgId').val("")
//////////    $('#txtfechaNacId').val("")
//////////}

//////////function getCambioDI() {
//////////    $.post(
//////////    '/Personal/ListarComboGlobal',
//////////    {
//////////        intIdMenu: 0,
//////////        strEntidad: 'TSTIPDOC02',
//////////        intIdFiltroGrupo: 0,
//////////        strGrupo: 'PER',
//////////        strSubGrupo: '',
//////////    },
//////////    response => {
//////////        response.forEach(element => {
//////////            $('#TipoDoc').append('<option value="' + element.intId + '" maxdata="' + element.strCodigo + '"  >' + element.strDescripcion + '</option>')
//////////            $('#newTipoDocId').append('<option value="' + element.intId + '" maxdata="' + element.strCodigo + '"  >' + element.strDescripcion + '</option>')
//////////        })
//////////    })

//////////    $('#TipoDoc').change(function() {
//////////        const valorDoc = $(this).val()
//////////        $('#txtNumDoc').val('')
//////////        let maxdata = $('option:selected', this).attr('maxdata')

//////////        if (valorDoc == '' || valorDoc == '0') {
//////////            messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, 'Cambio de Documento')
//////////            $('#txtNumDoc').prop('disabled', true)
//////////            $('#txtNumDoc').removeAttr('maxlength')
//////////            $('#txtNumDoc').removeAttr('minlength')
//////////        } else {
//////////            if (maxdata == '0') {
//////////                $('#txtNumDoc').removeAttr('maxlength')
//////////                $('#txtNumDoc').removeAttr('minlength')
//////////            } else {
//////////                $('#txtNumDoc').attr('maxlength', maxdata)
//////////                $('#txtNumDoc').attr('minlength', maxdata)
//////////            }
//////////        }
//////////    })

//////////    $('#newTipoDocId').change(function () {
//////////        const valorDoc = $(this).val()
//////////        $('#newNumDocId').val('')
//////////        let maxdata = $('option:selected', this).attr('maxdata')

//////////        if (valorDoc == '' || valorDoc == '0') {
//////////            messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, 'Cambio de Documento')
//////////            $('#newNumDocId').prop('disabled', true)
//////////            $('#newNumDocId').removeAttr('maxlength')
//////////            $('#newNumDocId').removeAttr('minlength')
//////////        } else {
//////////            if (maxdata == '0') {
//////////                $('#newNumDocId').removeAttr('maxlength')
//////////                $('#newNumDocId').removeAttr('minlength')
//////////            } else {
//////////                $('#newNumDocId').attr('maxlength', maxdata)
//////////                $('#newNumDocId').attr('minlength', maxdata)
//////////            }
//////////        }
//////////    })

//////////    $('#txtNumDoc').keypress(function (e) {
//////////        validarSession()
//////////        if (e.which == 13) {
//////////            if ($('#TipoDoc').val() == '0') {
//////////                messageResponseMix({ type: 'info', message: 'Seleccione un tipo de documento' }, 'Cambio de Documento')
//////////                $('#TipoDoc').focus()
//////////                return false
//////////            }

//////////            var NumDoc = $('#txtNumDoc').val()

//////////            if (NumDoc == '') {
//////////            } else if (NumDoc !== '') {

//////////                var intIdTipDocConsulta = $('#TipoDoc').val()

//////////                $.post(
//////////                    '/Personal/ValidarDocCambioIdentidad',
//////////                    {
//////////                        intIdTipDoc: Number(intIdTipDocConsulta),
//////////                        strNumDoc: NumDoc,
//////////                    },
//////////                    response => {
//////////                        if (response.objeto == null) {
//////////                            if (response.type) {
//////////                                new PNotify({
//////////                                    title: 'Numero de Documento',
//////////                                    text: response.message,
//////////                                    type: response.type,
//////////                                    delay: 3000,
//////////                                    styling: 'bootstrap3',
//////////                                    addclass: 'dark'
//////////                                });
//////////                            }
//////////                            cleanForm()
//////////                        } else {
//////////                            let dataObject = response.objeto
//////////                            //let fechaMostrarPorDefecto = moment().format('DD/MM/YYYY')

//////////                            $('#msgVerifDoc').html('&nbsp;&nbsp;&nbsp;<i class="fa fa-lock" style="color:green;font-size:25px;" id="HabNumDoc"></i>')


//////////                            $("#TipoDoc").attr('disabled', true)
//////////                            $("#txtNumDoc").attr('disabled', true)
//////////                            $("#newTipoDocId").attr('disabled', false)
//////////                            $("#newNumDocId").attr('disabled', false)

//////////                            $("#intIdPersonal").val(dataObject.intIdPersonal)
//////////                            $('#apeId').val(dataObject.strApellidos)
//////////                            $('#nomId').val(dataObject.strNombres)
//////////                            $('#codEmpId').val(dataObject.strCoPersonal)
//////////                            $('#numRegId').val(dataObject.strNumRegis)
//////////                            $('#fotocheckId').val(dataObject.strFotocheck)
//////////                            $('#uniOrgId').val(dataObject.strUniOrg)
//////////                            $('#txtfechaNacId').val(dataObject.dttFecNacim)



//////////                            $('#HabNumDoc').on('click', function () {
//////////                                swal({
//////////                                    title: 'Cambiar Doc. Identidad',
//////////                                    text: 'Se perderá toda la información ingresada',
//////////                                    type: 'warning',
//////////                                    showCancelButton: true,
//////////                                    confirmButtonText: 'Sí, cambiar',
//////////                                    cancelButtonText: 'No, cancelar',
//////////                                }).then(function (isConfirm) {
//////////                                    if (isConfirm) {
//////////                                        $("#TipoDoc").attr('disabled', false)
//////////                                        $("#txtNumDoc").attr('disabled', false)
//////////                                        $("#newTipoDocId").attr('disabled', true)
//////////                                        $("#newNumDocId").attr('disabled', true)

//////////                                        $("#TipoDoc").val(0)
//////////                                        $("#txtNumDoc").val('')

//////////                                        $('#msgVerifDoc').html('&nbsp;&nbsp;&nbsp;<i class="fa fa-unlock" style="color:red;font-size:25px;"></i>')

//////////                                        cleanForm()
//////////                                    } else {
//////////                                        swal('Cancelled', 'Your imaginary file is safe :)', 'error')
//////////                                    }
//////////                                })
//////////                            })

//////////                        }
//////////                    })
//////////            }

//////////        }
//////////    })

//////////    $('#fechaNacId').datetimepicker({
//////////        viewMode: 'days',
//////////        format: 'DD/MM/YYYY'
//////////    });

//////////}

//////////$('.range-datepicker').on('apply.daterangepicker', function (ev, picker) {
//////////    validarSession()
//////////    let filtrojer_ini = $('#fechaRegistroId').data('daterangepicker').startDate.format('DD/MM/YYYY') + ' 00:00:00'
//////////    let filtrojer_fin = $('#fechaRegistroId').data('daterangepicker').endDate.format('DD/MM/YYYY') + ' 23:59:59'
//////////    getTableCambiosDI(filtrojer_ini, filtrojer_fin)
//////////});

//////////$("#buscarId").change(function () {
//////////    validarSession()
//////////    let filtrojer_ini = $('#fechaRegistroId').data('daterangepicker').startDate.format('DD/MM/YYYY') + ' 00:00:00'
//////////    let filtrojer_fin = $('#fechaRegistroId').data('daterangepicker').endDate.format('DD/MM/YYYY') + ' 23:59:59'
//////////    getTableCambiosDI(filtrojer_ini, filtrojer_fin)
//////////})

//////////$("#empresaId").change(function () {
//////////    validarSession()
//////////    let filtrojer_ini = $('#fechaRegistroId').data('daterangepicker').startDate.format('DD/MM/YYYY') + ' 00:00:00'
//////////    let filtrojer_fin = $('#fechaRegistroId').data('daterangepicker').endDate.format('DD/MM/YYYY') + ' 23:59:59'
//////////    getTableCambiosDI(filtrojer_ini, filtrojer_fin)
//////////})

//////////$(document).ready(function () {

//////////    const fechaInicioAsigHor = moment().startOf('year').format('DD/MM/YYYY') + ' 00:00:00';
//////////    const fechaFinAsigHor = moment().endOf("year").format('DD/MM/YYYY') + ' 23:59:59';

//////////    $.post(
//////////        '/Personal/ListarCombosPersonal',
//////////        { intIdMenu: 0, strEntidad: 'TGUNIDORG', intIdFiltroGrupo: 2, strGrupo: 'JERAR', strSubGrupo: '' },
//////////        (response) => {
//////////            $('#empresaId').empty();
//////////            $('#empresaId').append('<option value="0" selected>Todos</option>');

//////////            response.forEach(element => {
//////////                $('#empresaId').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');

//////////            });

//////////        });

//////////    getTableCambiosDI(fechaInicioAsigHor, fechaFinAsigHor)

//////////    $('#btn-new-cambioDI').on('click', function () {
//////////        validarSession()
//////////        $('.form-hide-cambioDI').show();
//////////        $.post(
//////////            '/Personal/NuevoCambioDI',
//////////            {},
//////////            (response) => {
//////////                if (response !== '') {
//////////                    $('.form-hide-cambioDI .x_content').empty();
//////////                    $('.form-hide-cambioDI .x_content').html(response);
//////////                    getCambioDI()
//////////                    $('.form-hide-cambioDI').show();
//////////                }
//////////            });
//////////    });

//////////    $('#btn-save-change-cambioDI').on('click', function () {
//////////        validarSession()
//////////        var intIdPerso = $('#intIdPersonal').val()
//////////        var intIdTipDocAnt = $('#TipoDoc').val()
//////////        var strNumDocAnt = $('#txtNumDoc').val()
//////////        var intIdTipDocNue = $('#newTipoDocId').val()
//////////        var strNumDocNue = $('#newNumDocId').val()
//////////        var strFechaNac = $('#txtfechaNacId').val()

//////////        if (strFechaNac == '') {
//////////            messageResponseMix({ type: 'info', message: 'Seleccione un tipo de documento' }, 'Cambio Documento Identidad')
//////////            $('#newTipoDocId').focus()
//////////            return false
//////////        }

//////////        if (intIdTipDocNue == '0') {
//////////            messageResponseMix({ type: 'info', message: 'Seleccione un tipo de documento' }, 'Cambio Documento Identidad')
//////////            $('#newTipoDocId').focus()
//////////            return false
//////////        }

//////////        if (strNumDocNue == "") {
//////////            messageResponseMix({ type: 'info', message: 'Ingrese número de documento' }, 'Cambio Documento Identidad')            
//////////            $('#newNumDocId').focus()
//////////            return false
//////////        }

//////////        var personalCDI = {
//////////            intIdPerso: intIdPerso
//////////            , intIdTipDocAnt: intIdTipDocAnt
//////////            , strNumDocAnt: strNumDocAnt
//////////            , intIdTipDocNue: intIdTipDocNue
//////////            , strNumDocNue: strNumDocNue
//////////            , strFechaNac: strFechaNac
//////////        }

//////////        console.log(personalCDI)

//////////        $.post(
//////////            '/Personal/ActualizarCambioDI',
//////////            {
//////////                personalCDI: personalCDI
//////////            },
//////////            (response) => {
//////////                if (response.type == 'success' || response.type == 'info') {

//////////                    $('.form-hide-cambioDI .x_content').empty();
//////////                    $('.form-hide-cambioDI').hide();

//////////                    let filtrojer_ini = $('#fechaRegistroId').data('daterangepicker').startDate.format('DD/MM/YYYY') + ' 00:00:00'
//////////                    let filtrojer_fin = $('#fechaRegistroId').data('daterangepicker').endDate.format('DD/MM/YYYY') + ' 23:59:59'

//////////                    getTableCambiosDI(filtrojer_ini, filtrojer_fin)

//////////                    if (response.type == 'info') {
//////////                        new PNotify({
//////////                            title: 'Cambio de Documento de Identidad',
//////////                            text: 'El documento de identidad fue cambiado satisfactoriamente',
//////////                            type: 'success',
//////////                            delay: 1000,
//////////                            styling: 'bootstrap3'
//////////                        });
//////////                    }

//////////                    new PNotify({
//////////                        title: 'Cambio de Documento de Identidad',
//////////                        text: response.message,
//////////                        type: response.type,
//////////                        delay: 1000,
//////////                        styling: 'bootstrap3'
//////////                    });
//////////                } else {
//////////                    new PNotify({
//////////                        title: 'Cambio de Documento de Identidad',
//////////                        text: response.message,
//////////                        type: response.type,
//////////                        delay: 1000,
//////////                        styling: 'bootstrap3'
//////////                    });
//////////                }
//////////            });
//////////    });

//////////    $('#btn-cancel-cambioDI').on('click', function () {
//////////        validarSession()
//////////        $('.form-hide-cambioDI').hide();
//////////    });
//////////})
