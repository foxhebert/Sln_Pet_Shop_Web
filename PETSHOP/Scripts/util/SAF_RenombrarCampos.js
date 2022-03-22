
//BOTON DE PRUEBA PARA EL LISTADO DE TBBIENEs QUE SE CAE CON 94 registros en el TestClient
$('#btn-prueba').on('click', function () {


    $.post(
        '/Personal/ListarTablaTbBienesPrueba',
        {
            //sinparametros
        },
        response => {


            var cantidad = response.length;
            alert(cantidad );
            //alert('Prueba: Respuesta del POST Exitosa');

        });



});



let id_renombrar_unidad;
let _varCampos;
let tipo_opera = 2;


 /***************************************************************************************************
                                            RENOMBRAR CAMPOS   
 ***************************************************************************************************/


$('#btn-cancel-campos').on('click', function () {
    
    $('.form-hide-campos-renombrables').hide();

})


//===============================================================================================
//=============================== LISTAR TODOS LOS CAMPOS =======================================
//===============================================================================================
function TablaRenombrarCampos() {

    var strfiltro = $('#filtroInputRenombre').val();

    $.ajax({
        //url: '/Organizacion/getTablaFiltradaCargos',
        url: '/Personal/ListarRenombrarCampos',
        type: 'POST',
        data: { strfilter: strfiltro, },        
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

            if (typeof _varTablaCampos !== 'undefined') {
                _varTablaCampos.destroy();
            }
            _varTablaCampos = $('#tablaRenombrarCampos').DataTable({
                data: response,
                columns: [

                    { data: 'strCODIGO'    },
                    { data: 'strCAMPO'     },
                    { data: 'strRENOMBRE'  },
                    //{ data: null           },
                    {
                        sortable: false,
                        "render": (data, type, item, meta) => {
                            let intIdCodigo = item.strCODIGO;
                            return `<button class="btn btn-success btn-xs btn-edit" dataid="${intIdCodigo}" ><i class="fa fa-pencil"></i> Editar </button>`;

                        }
                    },
                ],
                lengthMenu: [10, 25, 50],
                responsive: true,
                order: [],
                language: _datatableLanguaje,
                columnDefs: [//ocultar y definir columnas

                    //////////{
                    //////////    targets: [6],//intIdCargo
                    //////////    visible: false,
                    //////////    searchable: true
                    //////////},
                    {
                        targets: [0],
                        visible: false,
                        searchable: true
                    }
                    //,
                    //{
                    //    targets: [3],
                    //    data: null,
                    //    defaultContent: '<button class="btn btn-success btn-xs btn-edit" ><i class="fa fa-pencil"></i> Editar </button>' 
                    //}

                ],
                dom: 'lBfrtip',
            });

            //_varDeTablaCampRenomb = response;

        },
        complete: function () {
            $.unblockUI();

            var table = $('#tablaRenombrarCampos').DataTable();
            if (table.rows().count() == 0) {

                $('#btn-editar-todos').attr('disabled', true)
            }
            else {

                $('#btn-editar-todos').attr('disabled', false)
            }

        }
    });
}

//Limpieza I
function limpiarTodoLabelsAndControles() {

    $('.form-hide-campos-renombrables').hide();
    //LIMPIAR LOS CONTROLES DE ACTUALIZAR TODO
    $('#txt_cptActivo      ').val('');
    $('#txt_cptDescripcion ').val('');
    $('#txt_cptLocal       ').val('');
    $('#txt_cptArea        ').val('');
    $('#txt_cptOficina     ').val('');
    $('#txt_cptAnterior    ').val('');
    $('#txt_cptEmpleado    ').val('');
    $('#txt_cptEstado      ').val('');
    $('#txt_cptMarca       ').val('');
    $('#txt_cptModelo      ').val('');
    $('#txt_cptTipo        ').val('');
    $('#txt_cptColor       ').val('');
    $('#txt_cptSerie       ').val('');
    $('#txt_cptNumMotor    ').val('');
    $('#txt_cptNumChasis   ').val('');
    $('#txt_cptAnio        ').val('');
    $('#txt_cptDimension   ').val('');
    $('#txt_cptPlaca       ').val('');
    $('#txt_cptObservacion ').val('');

    //LIMPIAR LOS LABELS DE ACTUALIZAR TODO
    $('#lbl_cptActivo      ').text('');
    $('#lbl_cptDescripcion ').text('');
    $('#lbl_cptLocal       ').text('');
    $('#lbl_cptArea        ').text('');
    $('#lbl_cptOficina     ').text('');
    $('#lbl_cptAnterior    ').text('');
    $('#lbl_cptEmpleado    ').text('');
    $('#lbl_cptEstado      ').text('');
    $('#lbl_cptMarca       ').text('');
    $('#lbl_cptModelo      ').text('');
    $('#lbl_cptTipo        ').text('');
    $('#lbl_cptColor       ').text('');
    $('#lbl_cptSerie       ').text('');
    $('#lbl_cptNumMotor    ').text('');
    $('#lbl_cptNumChasis   ').text('');
    $('#lbl_cptAnio        ').text('');
    $('#lbl_cptDimension   ').text('');
    $('#lbl_cptPlaca       ').text('');
    $('#lbl_cptObservacion ').text('');

    //LIMPIAR LOS LABE, CONTROL Y VARIABLES DE ACTUALIZAR UNIDAD
    $('#lbl_renombrar_unidad').text('');
    $('#txt_renombrar_unidad').val('');
    id_renombrar_unidad = [];

}

//Onchange Fitro
$('#filtroInputRenombre').keyup(function () {

    validarSession();
    //setTimeout('TablaCargos()', 50);
    TablaRenombrarCampos();

});

//Boton Editar Un Campo
$('#tablaRenombrarCampos  tbody').on('click', 'tr button.btn-edit', function () {
    let identificadorCpt = $(this).attr("dataid")

    //if (!isNaN(ServicioId)) {
    if (identificadorCpt !== null) {
        cargarCampoRenombrarUnidad(identificadorCpt);
        //alert(identificadorCpt);
    }
});

//===============================================================================================
//=============================== CARGAR TODOS LOS CAMPOS =======================================
//===============================================================================================
function cargarCampoRenombrarTodos() {
    //LIMPIAR LOS CONTROLES DE ACTUALIZAR UNA INSERCION
    //$('#lbl_renombrar_unidad').text('');
    //$('#txt_renombrar_unidad').val('');
    //id_renombrar_unidad = [];
    //-----------------------------------------
    //LIMPIAR LOS CONTROLES DE ACTUALIZAR TODO
    limpiarTodoLabelsAndControles();
    //-----------------------------------------
    //$('#btn-save-change-cargo').show()
    //$('.form-hide-campos-renombrables').show();
    var strfiltro = "";

    $.ajax({
        url: '/Personal/ListarRenombrarCampos',
        type: 'POST',
        data: {

            strfilter: strfiltro,
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
                message: 'Cargando...'
            });
        },
        success: function (response) {

            ///////////////////////////////////////////
            console.log(response);
            _varCampos = response;
            ///////////////////////////////////////////

            //////LIMPIAR LOS CONTROLES
            ////$('#txt_cptActivo      ').val('');
            ////$('#txt_cptDescripcion ').val('');
            ////$('#txt_cptLocal       ').val('');
            ////$('#txt_cptArea        ').val('');
            ////$('#txt_cptOficina     ').val('');
            ////$('#txt_cptAnterior    ').val('');
            ////$('#txt_cptEmpleado    ').val('');
            ////$('#txt_cptEstado      ').val('');
            ////$('#txt_cptMarca       ').val('');
            ////$('#txt_cptModelo      ').val('');
            ////$('#txt_cptTipo        ').val('');
            ////$('#txt_cptColor       ').val('');
            ////$('#txt_cptSerie       ').val('');
            ////$('#txt_cptNumMotor    ').val('');
            ////$('#txt_cptNumChasis   ').val('');
            ////$('#txt_cptAnio        ').val('');
            ////$('#txt_cptDimension   ').val('');
            ////$('#txt_cptPlaca       ').val('');
            ////$('#txt_cptObservacion ').val('');

            //LLENAR LOS CONTROLES
            $('#txt_cptActivo      ').val(_varCampos[0]['strRENOMBRE']);
            $('#txt_cptDescripcion ').val(_varCampos[1]['strRENOMBRE']);
            $('#txt_cptLocal       ').val(_varCampos[2]['strRENOMBRE']);
            $('#txt_cptArea        ').val(_varCampos[3]['strRENOMBRE']);
            $('#txt_cptOficina     ').val(_varCampos[4]['strRENOMBRE']);
            $('#txt_cptAnterior    ').val(_varCampos[5]['strRENOMBRE']);
            $('#txt_cptEmpleado    ').val(_varCampos[6]['strRENOMBRE']);
            $('#txt_cptEstado      ').val(_varCampos[7]['strRENOMBRE']);
            $('#txt_cptMarca       ').val(_varCampos[8]['strRENOMBRE']);
            $('#txt_cptModelo      ').val(_varCampos[9]['strRENOMBRE']);
            $('#txt_cptTipo        ').val(_varCampos[10]['strRENOMBRE']);
            $('#txt_cptColor       ').val(_varCampos[11]['strRENOMBRE']);
            $('#txt_cptSerie       ').val(_varCampos[12]['strRENOMBRE']);
            $('#txt_cptNumMotor    ').val(_varCampos[13]['strRENOMBRE']);
            $('#txt_cptNumChasis   ').val(_varCampos[14]['strRENOMBRE']);
            $('#txt_cptAnio        ').val(_varCampos[15]['strRENOMBRE']);
            $('#txt_cptDimension   ').val(_varCampos[16]['strRENOMBRE']);
            $('#txt_cptPlaca       ').val(_varCampos[17]['strRENOMBRE']);
            $('#txt_cptObservacion ').val(_varCampos[18]['strRENOMBRE']);

            ////LIMPIAR LOS LABELS
            //$('#lbl_cptActivo      ').text('');
            //$('#lbl_cptDescripcion ').text('');
            //$('#lbl_cptLocal       ').text('');
            //$('#lbl_cptArea        ').text('');
            //$('#lbl_cptOficina     ').text('');
            //$('#lbl_cptAnterior    ').text('');
            //$('#lbl_cptEmpleado    ').text('');
            //$('#lbl_cptEstado      ').text('');
            //$('#lbl_cptMarca       ').text('');
            //$('#lbl_cptModelo      ').text('');
            //$('#lbl_cptTipo        ').text('');
            //$('#lbl_cptColor       ').text('');
            //$('#lbl_cptSerie       ').text('');
            //$('#lbl_cptNumMotor    ').text('');
            //$('#lbl_cptNumChasis   ').text('');
            //$('#lbl_cptAnio        ').text('');
            //$('#lbl_cptDimension   ').text('');
            //$('#lbl_cptPlaca       ').text('');
            //$('#lbl_cptObservacion ').text('');

            //LLENAR LOS LABELS
            $('#lbl_cptActivo      ').append(_varCampos[0]['strCAMPO']);
            $('#lbl_cptDescripcion ').append(_varCampos[1]['strCAMPO']);
            $('#lbl_cptLocal       ').append(_varCampos[2]['strCAMPO']);
            $('#lbl_cptArea        ').append(_varCampos[3]['strCAMPO']);
            $('#lbl_cptOficina     ').append(_varCampos[4]['strCAMPO']);
            $('#lbl_cptAnterior    ').append(_varCampos[5]['strCAMPO']);
            $('#lbl_cptEmpleado    ').append(_varCampos[6]['strCAMPO']);
            $('#lbl_cptEstado      ').append(_varCampos[7]['strCAMPO']);
            $('#lbl_cptMarca       ').append(_varCampos[8]['strCAMPO']);
            $('#lbl_cptModelo      ').append(_varCampos[9]['strCAMPO']);
            $('#lbl_cptTipo        ').append(_varCampos[10]['strCAMPO']);
            $('#lbl_cptColor       ').append(_varCampos[11]['strCAMPO']);
            $('#lbl_cptSerie       ').append(_varCampos[12]['strCAMPO']);
            $('#lbl_cptNumMotor    ').append(_varCampos[13]['strCAMPO']);
            $('#lbl_cptNumChasis   ').append(_varCampos[14]['strCAMPO']);
            $('#lbl_cptAnio        ').append(_varCampos[15]['strCAMPO']);
            $('#lbl_cptDimension   ').append(_varCampos[16]['strCAMPO']);
            $('#lbl_cptPlaca       ').append(_varCampos[17]['strCAMPO']);
            $('#lbl_cptObservacion ').append(_varCampos[18]['strCAMPO']);

            $('.col-xs-6').show();//Mostrar los demas controles
            $('.unidad').hide();//Esconder solo un control

            $('.form-hide-campos-renombrables').show();

        },

        complete: function () {
            $.unblockUI();
        }
    });

    //let uno = _varCampos[0]['strCODIGO'];
    //$('#lbl_renombrar_unidad').append(element.strCAMPO);
    //$('#txt_renombrar_unidad').val(element.strRENOMBRE);
    //$('#txt_').val(element.strRENOMBRE); 
    

    //intCodigo: data['strCODIGO'],
    //    strCampo   : data['strCAMPO'],
    //        strRenombre: data['strRENOMBRE'], 



    //////////$.post(
    //////////    '/Personal/ListarRenombrarCampos',
    //////////    { strfilter: strfiltro },
    //////////    (response) => {

    //////////        //$('#txtCoServicio').val('');
    //////////        //$('#Moneda').val(0);
    //////////        //$('#txt_cptActivo').val('');
    //////////        $('#lbl_renombrar_unidad').text('');
    //////////        $('#txt_renombrar_unidad').val('');

    //////////        //response.forEach(element => {

    //////////            alert(element.strRENOMBRE);
    //////////            //$('#lbl_renombrar_unidad').append(element.strCAMPO);
    //////////            //$('#txt_renombrar_unidad').val(element.strRENOMBRE);
    //////////            ////$('#txt_cptActivo').val(element.strRENOMBRE);            

    //////////            //$('.form-hide-servicio').show();
    //////////        //});

    //////////        //response.forEach(element => {

    //////////        //    //alert(element.strRENOMBRE);
    //////////        //    $('#lbl_renombrar_unidad').append(element.strCAMPO);
    //////////        //    $('#txt_renombrar_unidad').val(element.strRENOMBRE);
    //////////        //    //$('#txt_cptActivo').val(element.strRENOMBRE);            

    //////////        //    $('.form-hide-servicio').show();
    //////////        //});

    //////////    });

   
}


//===============================================================================================
//=============================== CARGAR UN SOLO CAMPO SELECCIONADO =============================
//===============================================================================================
function cargarCampoRenombrarUnidad(identificadorCpt) {

    //LIMPIAR LOS CONTROLES DE ACTUALIZAR UNA INSERCION
    //$('#lbl_renombrar_unidad').text('');
    //$('#txt_renombrar_unidad').val('');
    //id_renombrar_unidad = [];
    $('.form-hide-campos-renombrables').hide();
    //LIMPIAR LOS CONTROLES DE ACTUALIZAR TODO
    limpiarTodoLabelsAndControles();

    $.post(
        '/Personal/getCamposPorId',
        { strCodigo: identificadorCpt },
        (response) => {

            $('#lbl_renombrar_unidad').text('');
            $('#txt_renombrar_unidad').val('');

            response.forEach(element => {

                //Guardar el identificador del Registro seleccionado en una variable global
                id_renombrar_unidad = element.strCODIGO;               
                $('#lbl_renombrar_unidad').append(element.strCAMPO);
                $('#txt_renombrar_unidad').val(element.strRENOMBRE);
                $('.col-xs-6').hide();//Esconder los demás controles
                $('.unidad').show();  //Mostrar solo un control
                $('.form-hide-campos-renombrables').show();

            });

        });
    

}


//===============================================================================================
//=============================== BOTON GUARDAR CAMPOS (UNIDAD Ó TODOS) =========================
//===============================================================================================
$('#btn-guardar-campos-renombrados').on('click', function () {

    //var labelvacio = $('#lbl_renombrar_unidad').text();
    //alert('label: '+ labelvacio);

    if ($('#lbl_renombrar_unidad').text() !== "")
    {
        //alert('El label no esta vacío, entonces "tipo_opera = 1" para guardar un solo campo');
        tipo_opera = 1; // Actualizar Todos = 2, Actualizar Unidad = 1
    }

    if ($('#lbl_renombrar_unidad').text() == "") {
        //alert('El label está vacío, entonces "tipo_opera = 2" para guardar todos los campos');
        tipo_opera = 2; // Actualizar Todos = 2, Actualizar Unidad = 1
    }
                         
    var _cptActivo        = $('#txt_cptActivo      ').val();  
    var _cptDescripcion   = $('#txt_cptDescripcion ').val();
    var _cptLocal         = $('#txt_cptLocal       ').val();
    var _cptArea          = $('#txt_cptArea        ').val();
    var _cptOficina       = $('#txt_cptOficina     ').val();
    var _cptAnterior      = $('#txt_cptAnterior    ').val();
    var _cptResponsable   = $('#txt_cptEmpleado    ').val();
    var _cptEstado        = $('#txt_cptEstado      ').val();
    var _cptMarca         = $('#txt_cptMarca       ').val();
    var _cptModelo        = $('#txt_cptModelo      ').val();
    var _cptTipo          = $('#txt_cptTipo        ').val();
    var _cptColor         = $('#txt_cptColor       ').val();
    var _cptSerie         = $('#txt_cptSerie       ').val();
    var _cptNumMotor      = $('#txt_cptNumMotor    ').val();
    var _cptNumChasis     = $('#txt_cptNumChasis   ').val();
    var _cptAnio          = $('#txt_cptAnio        ').val();
    var _cptDimension     = $('#txt_cptDimension   ').val();
    var _cptPlaca         = $('#txt_cptPlaca       ').val();
    var _cptObservacion   = $('#txt_cptObservacion ').val();
    //--------------------------------------------------------------
    var _IdCampoUnitario  = id_renombrar_unidad;
    var _CampoUnitario    = $('#txt_renombrar_unidad').val();

    var _objCamposRenombrados = {

         cptActivo       : _cptActivo        
        ,cptDescripcion  : _cptDescripcion 
        ,cptLocal        : _cptLocal       
        ,cptArea         : _cptArea        
        ,cptOficina      : _cptOficina     
        ,cptAnterior     : _cptAnterior    
        ,cptResponsable  : _cptResponsable 
        ,cptEstado       : _cptEstado      
        ,cptMarca        : _cptMarca       
        ,cptModelo       : _cptModelo      
        ,cptTipo         : _cptTipo        
        ,cptColor        : _cptColor       
        ,cptSerie        : _cptSerie       
        ,cptNumMotor     : _cptNumMotor    
        ,cptNumChasis    : _cptNumChasis   
        ,cptAnio         : _cptAnio        
        ,cptDimension    : _cptDimension   
        ,cptPlaca        : _cptPlaca       
        ,cptObservacion  : _cptObservacion
        //-------------------------------------------
        ,codCampoUnitario: _IdCampoUnitario
        ,strcampoUnitario: _CampoUnitario

    }


    $.post(
        '/Personal/UpdateCamposRenombrados',
        { objCamposRenombrados: _objCamposRenombrados, intTipoOperacion: tipo_opera /*2*/ },

        (response) => {
            
            console.log(response);



            if (response.type !== '') {

                if (response.type === 'success') {

                    //if (tipo_opera=){
                    //}
                    ////response_message = 

                    new PNotify({
                        title: 'Renombrar Campos',
                        text: response.message,                        
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'
                    });

                    TablaRenombrarCampos();
                    limpiarTodoLabelsAndControles();
                    $('.form-hide-campos-renombrables').hide();

                } else {

                    if (response.type === 'error')
                    {
                        new PNotify({
                            title: 'Renombrar Campos',
                            text: response.message,
                            type: response.type,
                            delay: 3000,
                            styling: 'bootstrap3'
                        });
                        return;
                    }

                    else {

                        if (response.type === 'info')
                        {
                            new PNotify({
                                title: 'Renombrar Campos',
                                text: response.message,
                                type: response.type,
                                delay: 3000,
                                styling: 'bootstrap3'
                            });
                            return;
                        }

                        else {

                            new PNotify({
                                title: 'Renombrar Campos',
                                text: response.message,
                                type: 'info',
                                delay: 3000,
                                styling: 'bootstrap3'
                            });


                        }

                    }
                }

            }

            /**********************************************************
            ***********************************************************/
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
        });


});




/*
//AUN NO USADO
function cargarDatosRenombrarCampos(data) {

    //$('#btn-save-change-cargo').hide();
    $('#btn-save-change-cargo').show();

    var objDatosRenombrarCampos = {

        intCodigo  : data['strCODIGO'],
        strCampo   : data['strCAMPO'],
        strRenombre: data['strRENOMBRE'],
        //intIdCargo: data['intIdCargo'],
        //strCoCargo: data['strCoCargo'],
        //strDesCargo: data['strDesCargo'],

    }

    console.log(objDatosRenombrarCampos);

    $('.form-hide-campos-renombrables').show();

    $.post(
        '/Organizacion/EditarRenombrarCampos',
        { objRenombrarCampos: objDatosRenombrarCampos },
        (response) => {

            
            $('#btn-update-cargo').show();
            var txtcod = 'strCoCargo';
            var txtdes = 'strDesCargo';

           
            ////////////$.post(
            ////////////    '/Organizacion/ListarCaracteresMax',
            ////////////    { strMaestro: 'TGCARGO' },
            ////////////    (response) => {
            ////////////        response.forEach(element => {
            ////////////            if (element.strColumnName == txtcod) {
            ////////////                $('.Valcod').children("input").attr('maxlength', element.intMaxLength);
            ////////////            }
            ////////////            if (element.strColumnName == txtdes) {
            ////////////                $('.Valdes').children("input").attr('maxlength', element.intMaxLength);
            ////////////            }
            ////////////        });
            ////////////    });
            

        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
}

*/

//////////ESCONDER Y LIMPIAR CONTROLES
////////function limpiarHideControles() {
////////    $('.col-xs-6').hide();
////////    //limpiarHideControles();
////////}















  






