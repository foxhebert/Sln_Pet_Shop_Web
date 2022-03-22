///////////////////////MARTES FINDEL DIA


////////////function configInicial() {
////////////    //const intIdMenu = localStorage.getItem('idsubmenu') && !isNaN(localStorage.getItem('idsubmenu')) ? Number(localStorage.getItem('idsubmenu')) : 1
////////////    const formatoFecha = 'DD/MM/YYYY'
////////////    const rangeDateInicial = {
////////////        startDate: moment(),
////////////        endDate: moment(),
////////////    }

////////////    return {
////////////        formatoFecha,
////////////        rangeDateInicial,
////////////    }
////////////}



////////////datatable settings
//////////var _datatableLanguaje = {
//////////    lengthMenu: 'Mostrar _MENU_ Items',
//////////    info: 'Mostrar _START_ a _END_ de _TOTAL_ Items',
//////////    infoEmpty: 'No hay Items para mostrar',
//////////    search: 'Buscar: ',
//////////    sSearchPlaceholder: 'Criterio de búsqueda',
//////////    zeroRecords: 'No se encontraron registros coincidentes',
//////////    infoFiltered: '(Filtrado de _MAX_  Items en total)',
//////////    paginate: {
//////////        previous: 'Anterior',
//////////        next: 'Siguiente'
//////////    }
//////////};

////////////READY FUNCTION
//////////$(document).ready(function () {

//////////    ListarTablaTbBienesActivos();

//////////    //Inicializar el listado
//////////    var table = $('#TablaAtivosEtiquetas').DataTable({
//////////        fixedHeader: {
//////////            header: true,
//////////            footer: true
//////////        },
//////////        language: _datatableLanguaje,
//////////    });
//////////});



////////////===============================================================================================
////////////=============================== Listar TablaActivoFijo() ======================================
////////////===============================================================================================
//////////var _varTablaActivos;
//////////function ListarTablaTbBienesActivos() {
   
//////////    var _chk_anio_invent = 0;
//////////    if ($('#chk_anio_invent_2021').is(':checked') == true) {
//////////        _chk_anio_invent = 1;
//////////    }

//////////    //-------------------------------------------
//////////    let _cbo_local            =  $('#cbo_local').val(); 
//////////    let _cbo_area             =  $('#cbo_area').val(); 
//////////    let _cbo_oficina          =  $('#cbo_oficina').val(); 
//////////    let _cbo_responsable      =  $('#cbo_responsable').val(); 
//////////    let _cbo_tipo_bien        =  $('#cbo_tipo_de_bien').val(); 
//////////    let _txt_buscar           =  $('#txt_buscar').val(); 
//////////    let _cbo_num_colum_etiq   =  4;   //$('#cbo_num_colum_etiq').val();   
//////////    let _cbo_cant_etiq_imp    =  120; //$('#cbo_cant_etiq_imp').val();
//////////    let _chk_anio             =  _chk_anio_invent; //true-false
//////////    let _txt_impresora        =  $('#txt_impresora').text();    

//////////    $.ajax({
//////////        //url: '/Asistencia/GetTablaServicio',
//////////        url: '/Impresion/ListarTbBienesEtiquetas',
//////////        type: 'POST',
//////////        //data: { objSession: SesionMovi, IntActivoFilter: Activo, strfilter: Descipción, intfiltrojer1: TipMenu, intfiltrojer2: TipServicio },
//////////        //data: { objSession: SesionMovi, IntActivoFilter: Activo, strfilter: Descipción, intfiltrojer1: TipMenu, intfiltrojer2: TipServicio, intfiltroClase: iClase, intUso: 0 }, //modificado 18.03.2021
//////////        data: {

//////////            Local  : _cbo_local,
//////////            Area   : _cbo_area,
//////////            Oficina: _cbo_oficina,
//////////            Responsable: _cbo_responsable,
//////////            TipoBien: _cbo_tipo_bien, 
//////////            ActivoSerie: _txt_buscar, 
//////////            NumColumnEtique: _cbo_num_colum_etiq, 
//////////            CantEtiquetsImp: _cbo_cant_etiq_imp, 
//////////            AnioInventario: _chk_anio, 
//////////            Impresora: _txt_impresora

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

//////////            if (typeof _varTablaActivos !== 'undefined') {
//////////                _varTablaActivos.destroy();
//////////            }

//////////            _varTablaActivos = $('#TablaAtivosEtiquetas').DataTable({
//////////                data: response,
//////////                columns: [
                
//////////                    { data: 'codigo' },             
//////////                    //{ data: 'descripcion' },
//////////                    //{ data: 'marca' },
//////////                    //{ data: 'serie' }, 
//////////                    //{ data: 'area' }, 
//////////                    //{ data: 'estado' },
                    
//////////                    //{ data: 'modelo' },
//////////                    //{ data: 'tipo' },       
//////////                    //{ data: 'color' },      
//////////                    //{ data: 'condicion' },  
//////////                    //{ data: 'responsable' },
//////////                    //{ data: 'desarea' },    
//////////                    //{ data: 'local' },    

//////////                    /*
//////////                    area: "RRHH"
//////////                    codigo: "CODIGO"
//////////                    color: "Negro"
//////////                    condicion: "Nueva"
//////////                    desarea: "Almacen"
//////////                    descripcion: "DESCRI"
//////////                    estado: "ESTADO"
//////////                    local: "Principal"
//////////                    marca: "YAMAHA"
//////////                    modelo: "RZ2012"
//////////                    responsable: "Almacenero"
//////////                    serie: "SerieA"
//////////                    tipo: "Tipo2"
//////////                    */                   
                    


//////////                    //{
//////////                    //    sortable: false,
//////////                    //    "render": (data, type, item, meta) => {
//////////                    //        let intIdServicio = item.intIdServicio;
//////////                    //        let strDesServicio = item.strDesServicio;
//////////                    //        return `<button class="btn btn-success btn-xs btn-edit" dataid="${intIdServicio}" ><i class="fa fa-pencil"></i> Editar </button> 
//////////                    //                       <button class="btn btn-primary btn-xs btn-delete" dataid="${intIdServicio}" des_data="${strDesServicio}" data="${item}" ><i class="fa fa-trash-o"></i> Eliminar </button>`;
//////////                    //    }
//////////                    //},

//////////                    //{ data: 'intIdServicio' }
//////////                ],
//////////                lengthMenu: [10, 25, 50],
//////////                order: [],
//////////                responsive: true,
//////////                language: _datatableLanguaje,
//////////                fixedHeader: //true,
//////////                {
//////////                    header: true,
//////////                    footer: true
//////////                },
//////////                columnDefs: [
//////////                    //{
//////////                    //    targets: [7],
//////////                    //    visible: false,
//////////                    //    searchable: false
//////////                    //}
//////////                ],
//////////                dom: 'lBfrtip',
//////////            });


//////////            $('#TablaAtivosEtiquetas  tbody').on('click', 'tr button.btn-delete', function () {
//////////                let ServicioId = $(this).attr("dataid")
//////////                let Descripcion = $(this).attr("des_data")
//////////                if (!isNaN(ServicioId)) {
//////////                    intentEliminarServicio(ServicioId, Descripcion)
//////////                }
//////////            });
//////////        },
//////////        complete: function () {
//////////            $.unblockUI();
//////////        }
//////////    });

  
//////////}


//////////$('#TablaAtivosEtiquetas  tbody').on('click', 'tr button.btn-edit', function () {
//////////    let ServicioId = $(this).attr("dataid")
//////////    if (!isNaN(ServicioId)) {
//////////        editarServicio(ServicioId)
//////////    }
//////////});


///////////*
//////////string Local, string Area, string Oficina, string Responsable, string TipoBien, string ActivoSerie,
//////////    int NumColumnEtiquet, int CantEtiquetsImp, bool AnioInventario, string Impresora
//////////*/



























/////////////////////*
////////////////////let nombreExcel = ""
////////////////////let idProceso = 0
////////////////////let _varTablaMasivo
////////////////////let checkActualizar = false;
////////////////////let bitNuevoExcel = false;
//////////////////////let rutaDirectorioExcel = ""; //añadido 06.04.2021
////////////////////*/

////////////////////function CombosImportacionMasiva() {
////////////////////    validarSession()
////////////////////    var intIdMenu = 0

////////////////////    $.post(
////////////////////        '/Personal/ListarCombosPersonal',
////////////////////        {
////////////////////            intIdMenu, strEntidad: 'IMPORTACIONMASIVA', intIdFiltroGrupo: 0, strGrupo: 'TIPOIMP', strSubGrupo: '',
////////////////////        },
////////////////////        response => {
////////////////////            $('#cboPlantilla').empty()
////////////////////            $('#cboPlantilla').append('<option value="0">Seleccione</option>')
////////////////////            response.forEach(element => {
////////////////////                $('#cboPlantilla').append('<option ruc="' + element.strextra1 + '" value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
////////////////////            })

////////////////////            $('#cboPlantilla').change(function () {
////////////////////            })

////////////////////        });

////////////////////    $.post(
////////////////////        '/Personal/ListarCombosPersonal',
////////////////////        {
////////////////////            intIdMenu, strEntidad: 'IMPORTACIONMASIVA', intIdFiltroGrupo: 0, strGrupo: 'FORMATOFEC', strSubGrupo: '',
////////////////////        },
////////////////////        response => {
////////////////////            $('#cboFormato').empty()
////////////////////            $('#cboFormato').append('<option value="0">Seleccione</option>')
////////////////////            response.forEach(element => {
////////////////////                $('#cboFormato').append('<option ruc="' + element.strextra1 + '" value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
////////////////////            })

////////////////////            $('#cboFormato').change(function () {
////////////////////            })

////////////////////        });

////////////////////}

////////////////////$(".columnHide").click(function () {
////////////////////    var index = $(this)[0].id;
////////////////////    if (typeof _varTablaMasivo !== 'undefined') {
////////////////////        var column = _varTablaMasivo.column(index);

////////////////////        // Toggle the visibility
////////////////////        column.visible(!column.visible());
////////////////////    }
////////////////////})

//////////////////////$("#excelMasivo").click(function (oEvent) {
//////////////////////    var oFile = oEvent.target.files[0];
//////////////////////    console.log("prueba click")
//////////////////////})
////////////////////$("#excelMasivo").change(function (oEvent) {
////////////////////    validarSession()
////////////////////    // Get The File From The Input
////////////////////    var oFile = oEvent.target.files[0];
////////////////////    if (oFile != null) {
////////////////////        //var sFilename = oFile.name;
////////////////////        //// Create A File Reader HTML5
////////////////////        //var reader = new FileReader();

////////////////////        //// Ready The Event For When A File Gets Selected
////////////////////        //reader.onload = function (e) {
////////////////////        //    var data = e.target.result;
////////////////////        //    var cfb = XLS.CFB.read(data, { type: 'binary' });
////////////////////        //    var wb = XLS.parse_xlscfb(cfb);
////////////////////        //    // Loop Over Each Sheet
////////////////////        //    wb.SheetNames.forEach(function (sheetName) {
////////////////////        //        // Obtain The Current Row As CSV
////////////////////        //        var sCSV = XLS.utils.make_csv(wb.Sheets[sheetName]);
////////////////////        //        var oJS = XLS.utils.sheet_to_row_object_array(wb.Sheets[sheetName]);

////////////////////        //        $("#my_file_output").html(sCSV);
////////////////////        //        console.log(oJS)
////////////////////        //    });
////////////////////        //};

////////////////////        //// Tell JS To Start Reading The File.. You could delay this if desired
////////////////////        //reader.readAsBinaryString(oFile);

////////////////////        var formData = new FormData()
////////////////////        formData.append('archivos', oFile)

////////////////////        $.ajax({
////////////////////            url: "/Personal/uploadFilesEmpleado",
////////////////////            type: 'POST',
////////////////////            data: formData,
////////////////////            processData: false,
////////////////////            contentType: false,
////////////////////            success: function (data) {
////////////////////                console.log(data)
////////////////////                //rutaDirectorioExcel = data;//añadido 06.04.2021
////////////////////                $("#btn-import-masivo").attr("disabled", false)
////////////////////            }
////////////////////        });
////////////////////        //INDICAR QUE ACABAN DE ATACHAR NUEVO ARCHIVO
////////////////////        bitNuevoExcel = true;

////////////////////    } else {
////////////////////        $("#btn-import-masivo").attr("disabled", true)
////////////////////    }

////////////////////})

////////////////////$("#btn-import-masivo").click(function () {
////////////////////    validarSession()

////////////////////    let cboPlantilla = $("#cboPlantilla").val()
////////////////////    let cboFormato = $("#cboFormato").val()
////////////////////    checkActualizar = $("#checkActualizar").is(':checked')

////////////////////    if (cboPlantilla == 0) {
////////////////////        new PNotify({
////////////////////            title: 'Tipo Importación',
////////////////////            text: 'Seleccione un tipo de importación',
////////////////////            type: 'info',
////////////////////            delay: 3000,
////////////////////            styling: 'bootstrap3',
////////////////////            addclass: 'dark'
////////////////////        });
////////////////////        return;
////////////////////    }

////////////////////    if (cboFormato == 0) {
////////////////////        new PNotify({
////////////////////            title: 'Formato Fecha',
////////////////////            text: 'Seleccione un formato de fecha',
////////////////////            type: 'info',
////////////////////            delay: 3000,
////////////////////            styling: 'bootstrap3',
////////////////////            addclass: 'dark'
////////////////////        });
////////////////////        return;
////////////////////    }

////////////////////    $.ajax({
////////////////////        url: '/Personal/ImportMasivoEmpleado',
////////////////////        type: 'POST',
////////////////////        data: { cboPlantilla, cboFormato, checkActualizar },
////////////////////        beforeSend: function () {
////////////////////            $.blockUI({
////////////////////                css: {
////////////////////                    border: 'none',
////////////////////                    padding: '15px',
////////////////////                    backgroundColor: '#000',
////////////////////                    '-webkit-border-radius': '10px',
////////////////////                    '-moz-border-radius': '10px',
////////////////////                    opacity: .5,
////////////////////                    color: '#fff'
////////////////////                },
////////////////////                message: 'Procesando...'
////////////////////            });
////////////////////        },
////////////////////        success: function (response) {
////////////////////            if (response.type == "success") {
////////////////////                console.log(response)
////////////////////                let lista = response.objeto
////////////////////                let lista_obs = lista.filter(x => x.FLAGOBSERVADO == true)
////////////////////                let lista_ok = lista.filter(x => x.FLAGOBSERVADO == false)
////////////////////                $("#txtEmpleadosOk").html(lista_ok.length)
////////////////////                $("#txtEmpleadosObs").html(lista_obs.length)
////////////////////                if (lista_obs.length > 0) {
////////////////////                    $("#txtEmpleadosObs").css("color", "red")
////////////////////                } else {
////////////////////                    $("#txtEmpleadosObs").css("color", "#73879C")
////////////////////                }

////////////////////                if (lista_ok.length > 0) {
////////////////////                    $("#btn-save-masivo").attr("disabled", false)
////////////////////                } else {
////////////////////                    $("#btn-save-masivo").attr("disabled", true)
////////////////////                }

////////////////////                $("#txt_titulo_tabla").html("Datos Importados")
////////////////////                $(".divEmpSave").hide()
////////////////////                $(".divEmpUpdate").hide()

////////////////////                if (typeof _varTablaMasivo !== 'undefined') {
////////////////////                    _varTablaMasivo.destroy();
////////////////////                }

////////////////////                _varTablaMasivo = $('#datatable-Masivo').DataTable({
////////////////////                    data: lista,
////////////////////                    columns: [
////////////////////                        { data: "COD_EMP" },
////////////////////                        { data: "COD_EMP_RUC" },
////////////////////                        { data: "COD_EMP_DSC" },
////////////////////                        { data: "COD_LOC" },
////////////////////                        { data: "COD_LOC_DSC" },
////////////////////                        { data: "COD_GER" },
////////////////////                        { data: "COD_GER_DSC" },
////////////////////                        { data: "COD_ARE" },
////////////////////                        { data: "COD_ARE_DSC" },
////////////////////                        { data: "COD_PL" },
////////////////////                        { data: "COD_PL_DSC" },
////////////////////                        { data: "COD_CG" },
////////////////////                        { data: "COD_CG_DSC" },
////////////////////                        { data: "COD_CT" },
////////////////////                        { data: "COD_CT_DSC" },
////////////////////                        { data: "COD_GR" },
////////////////////                        { data: "COD_GR_DSC" },
////////////////////                        { data: "COD_TP" },
////////////////////                        { data: "COD_TP_DSC" },
////////////////////                        { data: "COD_CC" },
////////////////////                        { data: "COD_CC_DSC" },
////////////////////                        { data: "COD_FIS" },
////////////////////                        { data: "COD_RES" },
////////////////////                        { data: "COD_EXT" },
////////////////////                        { data: "COD_TD" },
////////////////////                        { data: "NUMDOC" },
////////////////////                        { data: "NOMBRES" },
////////////////////                        { data: "FECNAC" },
////////////////////                        { data: "GENERO" },
////////////////////                        { data: "FOTOCHECK" },
////////////////////                        { data: "FECADM" },
////////////////////                        { data: "ESTADO" },
////////////////////                        { data: "COD_REG" },
////////////////////                        { data: "COD_HOR" },
////////////////////                        { data: "COD_RES_IM" },
////////////////////                        { data: "COD_RES_CT" },
////////////////////                        { data: "CORREOP" },
////////////////////                        { data: "CUENTA_US" },
////////////////////                        { data: "CUENTA_PF" },
////////////////////                        { data: "COD_VIA" },
////////////////////                        { data: "DIRECCION" },
////////////////////                        { data: "COD_UBI" },
////////////////////                        { data: "CODPENSIONISTA" },
////////////////////                        { data: "CODSALUD" },
////////////////////                        { data: "TELEFONOP" },
////////////////////                        { data: "CONTRATOI" },
////////////////////                        { data: "FECCESE" },
////////////////////                        { data: "COD_CESE" },
////////////////////                        { data: "COD_GLIQ" },
////////////////////                        { data: "COORDENADA" },
////////////////////                        { data: "DIRCOORDENADA" },
////////////////////                        { data: "INTIDPROCESO" },
////////////////////                        {
////////////////////                            sortable: false,
////////////////////                            "render": (data, type, item, meta) => {
////////////////////                                var OBSERVACION = item.OBSERVACION;

////////////////////                                if (OBSERVACION.includes("Empleado ya se encuentra Registrado")) {
////////////////////                                    texto = `<span style="color:red">${OBSERVACION}</span>`
////////////////////                                } else {
////////////////////                                    texto = OBSERVACION
////////////////////                                }

////////////////////                                return `${texto}`;
////////////////////                            }
////////////////////                        },
////////////////////                        { data: "FLAGOBSERVADO" },
////////////////////                        { data: "ESTADO_FINAL" }
////////////////////                    ],
////////////////////                    lengthMenu: [10, 25, 50],
////////////////////                    order: [],
////////////////////                    responsive: true,
////////////////////                    language: _datatableLanguaje,
////////////////////                    columnDefs: [
////////////////////                        {
////////////////////                            targets: [0],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [1],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        //{
////////////////////                        //    targets: [2],
////////////////////                        //    visible: false,
////////////////////                        //    searchable: false
////////////////////                        //},
////////////////////                        {
////////////////////                            targets: [3],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [4],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [5],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [6],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [7],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [8],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [9],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [10],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [11],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [12],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [13],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [14],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [15],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [16],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [17],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [18],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [19],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [20],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [21],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [22],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [23],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        //{
////////////////////                        //    targets: [24],
////////////////////                        //    visible: false,
////////////////////                        //    searchable: false
////////////////////                        //},
////////////////////                        //{
////////////////////                        //    targets: [25],
////////////////////                        //    visible: false,
////////////////////                        //    searchable: false
////////////////////                        //},
////////////////////                        //{
////////////////////                        //    targets: [26],
////////////////////                        //    visible: false,
////////////////////                        //    searchable: false
////////////////////                        //},
////////////////////                        {
////////////////////                            targets: [27],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [28],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        //{
////////////////////                        //    targets: [29],
////////////////////                        //    visible: false,
////////////////////                        //    searchable: false
////////////////////                        //},
////////////////////                        //{
////////////////////                        //    targets: [30],
////////////////////                        //    visible: false,
////////////////////                        //    searchable: false
////////////////////                        //},
////////////////////                        {
////////////////////                            targets: [31],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [32],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [33],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [34],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [35],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [36],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [37],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [38],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [39],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [40],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [41],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [42],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [43],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [44],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [45],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [46],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [47],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [48],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [49],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [50],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [51],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        //{
////////////////////                        //    targets: [52],
////////////////////                        //    visible: false,
////////////////////                        //    searchable: false
////////////////////                        //},
////////////////////                        {
////////////////////                            targets: [53],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        },
////////////////////                        {
////////////////////                            targets: [54],
////////////////////                            visible: false,
////////////////////                            searchable: false
////////////////////                        }
////////////////////                    ],
////////////////////                    dom: 'lBfrtip',
////////////////////                });


////////////////////                //INDICAR QUE ACABAN DE IMPORTAR EL ARCHIVO
////////////////////                bitNuevoExcel = false;


////////////////////            } else {
////////////////////                new PNotify({
////////////////////                    title: 'Importar Empleados',
////////////////////                    text: response.message,
////////////////////                    type: 'info',
////////////////////                    delay: 3000,
////////////////////                    styling: 'bootstrap3',
////////////////////                    addclass: 'dark'
////////////////////                });
////////////////////                return;
////////////////////            }
////////////////////        },
////////////////////        complete: function () {
////////////////////            $.unblockUI();
////////////////////        }
////////////////////    });
////////////////////})

////////////////////$("#btn-save-masivo").click(function () {
////////////////////    validarSession()
////////////////////    //VALIDAR QUE EL ARCHIVO ATACHADO YA HAYA SIDO IMPORTADO AL SQL
////////////////////    if (bitNuevoExcel == false) {
////////////////////        //bitNuevoExcel = true cuando se acaba de atachar un archivo y no se ha importado aún.
////////////////////        swal({
////////////////////            title: "Guardar Empleados",
////////////////////            text: "¿Está seguro de guardar los empleados?",
////////////////////            type: "warning",
////////////////////            showCancelButton: true,
////////////////////            confirmButtonText: "Sí, Guardar",
////////////////////            cancelButtonText: "No, cancelar",
////////////////////        }).then(function (isConfirm) {
////////////////////            validarSession()
////////////////////            $.ajax({
////////////////////                url: '/Personal/GuardarMasivoEmpleado',
////////////////////                type: 'POST',
////////////////////                data: {},
////////////////////                beforeSend: function () {
////////////////////                    $.blockUI({
////////////////////                        css: {
////////////////////                            border: 'none',
////////////////////                            padding: '15px',
////////////////////                            backgroundColor: '#000',
////////////////////                            '-webkit-border-radius': '10px',
////////////////////                            '-moz-border-radius': '10px',
////////////////////                            opacity: .5,
////////////////////                            color: '#fff'
////////////////////                        },
////////////////////                        message: 'Guardando...'
////////////////////                    });
////////////////////                },
////////////////////                success: function (response) {
////////////////////                    if (response.type == "success") {
////////////////////                        console.log(response)
////////////////////                        $("#btn-save-masivo").attr("disabled", true)
////////////////////                        $("#btn-import-masivo").attr("disabled", false)
////////////////////                        $(".divEmpSave").show()
////////////////////                        if (checkActualizar) {
////////////////////                            $(".divEmpUpdate").show()
////////////////////                        }

////////////////////                        $("#txt_titulo_tabla").html("Datos Guardados")

////////////////////                        let lista = response.objeto
////////////////////                        let lista_guardados = lista.filter(x => x.ESTADO_FINAL == 1)
////////////////////                        let lista_actualizados = lista.filter(x => x.ESTADO_FINAL == 2)
////////////////////                        let lista_Noguardados = lista.filter(x => x.ESTADO_FINAL == 3)
////////////////////                        //$("#txtEmpleadosGuardados").html(lista.length);
////////////////////                        $("#txtEmpleadosGuardados").html(lista_guardados.length);
////////////////////                        $("#txtEmpleadosActualizados").html(lista_actualizados.length);

////////////////////                        if (typeof _varTablaMasivo !== 'undefined') {
////////////////////                            _varTablaMasivo.destroy();
////////////////////                        }

////////////////////                        _varTablaMasivo = $('#datatable-Masivo').DataTable({
////////////////////                            data: lista,
////////////////////                            columns: [
////////////////////                                { data: "COD_EMP" },
////////////////////                                { data: "COD_EMP_RUC" },
////////////////////                                { data: "COD_EMP_DSC" },
////////////////////                                { data: "COD_LOC" },
////////////////////                                { data: "COD_LOC_DSC" },
////////////////////                                { data: "COD_GER" },
////////////////////                                { data: "COD_GER_DSC" },
////////////////////                                { data: "COD_ARE" },
////////////////////                                { data: "COD_ARE_DSC" },
////////////////////                                { data: "COD_PL" },
////////////////////                                { data: "COD_PL_DSC" },
////////////////////                                { data: "COD_CG" },
////////////////////                                { data: "COD_CG_DSC" },
////////////////////                                { data: "COD_CT" },
////////////////////                                { data: "COD_CT_DSC" },
////////////////////                                { data: "COD_GR" },
////////////////////                                { data: "COD_GR_DSC" },
////////////////////                                { data: "COD_TP" },
////////////////////                                { data: "COD_TP_DSC" },
////////////////////                                { data: "COD_CC" },
////////////////////                                { data: "COD_CC_DSC" },
////////////////////                                { data: "COD_FIS" },
////////////////////                                { data: "COD_RES" },
////////////////////                                { data: "COD_EXT" },
////////////////////                                { data: "COD_TD" },
////////////////////                                { data: "NUMDOC" },
////////////////////                                { data: "NOMBRES" },
////////////////////                                { data: "FECNAC" },
////////////////////                                { data: "GENERO" },
////////////////////                                { data: "FOTOCHECK" },
////////////////////                                { data: "FECADM" },
////////////////////                                { data: "ESTADO" },
////////////////////                                { data: "COD_REG" },
////////////////////                                { data: "COD_HOR" },
////////////////////                                { data: "COD_RES_IM" },
////////////////////                                { data: "COD_RES_CT" },
////////////////////                                { data: "CORREOP" },
////////////////////                                { data: "CUENTA_US" },
////////////////////                                { data: "CUENTA_PF" },
////////////////////                                { data: "COD_VIA" },
////////////////////                                { data: "DIRECCION" },
////////////////////                                { data: "COD_UBI" },
////////////////////                                { data: "CODPENSIONISTA" },
////////////////////                                { data: "CODSALUD" },
////////////////////                                { data: "TELEFONOP" },
////////////////////                                { data: "CONTRATOI" },
////////////////////                                { data: "FECCESE" },
////////////////////                                { data: "COD_CESE" },
////////////////////                                { data: "COD_GLIQ" },
////////////////////                                { data: "COORDENADA" },
////////////////////                                { data: "DIRCOORDENADA" },
////////////////////                                { data: "INTIDPROCESO" },
////////////////////                                { data: "OBSERVACION" },
////////////////////                                { data: "FLAGOBSERVADO" },
////////////////////                                {
////////////////////                                    sortable: false,
////////////////////                                    "render": (data, type, item, meta) => {
////////////////////                                        var ESTADO_FINAL = item.ESTADO_FINAL;
////////////////////                                        let texto = ''

////////////////////                                        if (ESTADO_FINAL == 1) {
////////////////////                                            texto = '<span style="color:green"><b>REGISTRADO</b></span>'
////////////////////                                        } else if (ESTADO_FINAL == 2) {
////////////////////                                            texto = '<span style="color:black"><b>ACTUALIZADO</b></span>'
////////////////////                                        } else if (ESTADO_FINAL == 3) {
////////////////////                                            texto = '<span style="color:red">NO GUARDADO</span>'
////////////////////                                        }

////////////////////                                        return `${texto}`;
////////////////////                                    }
////////////////////                                }
////////////////////                            ],
////////////////////                            lengthMenu: [10, 25, 50],
////////////////////                            order: [],
////////////////////                            responsive: true,
////////////////////                            language: _datatableLanguaje,
////////////////////                            columnDefs: [
////////////////////                                {
////////////////////                                    targets: [0],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [1],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                //{
////////////////////                                //    targets: [2],
////////////////////                                //    visible: false,
////////////////////                                //    searchable: false
////////////////////                                //},
////////////////////                                {
////////////////////                                    targets: [3],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [4],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [5],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [6],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [7],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [8],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [9],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [10],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [11],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [12],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [13],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [14],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [15],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [16],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [17],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [18],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [19],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [20],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [21],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [22],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [23],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                //{
////////////////////                                //    targets: [24],
////////////////////                                //    visible: false,
////////////////////                                //    searchable: false
////////////////////                                //},
////////////////////                                //{
////////////////////                                //    targets: [25],
////////////////////                                //    visible: false,
////////////////////                                //    searchable: false
////////////////////                                //},
////////////////////                                //{
////////////////////                                //    targets: [26],
////////////////////                                //    visible: false,
////////////////////                                //    searchable: false
////////////////////                                //},
////////////////////                                {
////////////////////                                    targets: [27],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [28],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                //{
////////////////////                                //    targets: [29],
////////////////////                                //    visible: false,
////////////////////                                //    searchable: false
////////////////////                                //},
////////////////////                                //{
////////////////////                                //    targets: [30],
////////////////////                                //    visible: false,
////////////////////                                //    searchable: false
////////////////////                                //},
////////////////////                                {
////////////////////                                    targets: [31],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [32],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [33],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [34],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [35],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [36],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [37],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [38],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [39],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [40],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [41],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [42],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [43],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [44],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [45],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [46],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [47],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [48],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [49],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [50],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                {
////////////////////                                    targets: [51],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                //{
////////////////////                                //    targets: [52],
////////////////////                                //    visible: false,
////////////////////                                //    searchable: false
////////////////////                                //},
////////////////////                                {
////////////////////                                    targets: [53],
////////////////////                                    visible: false,
////////////////////                                    searchable: false
////////////////////                                },
////////////////////                                //{
////////////////////                                //    targets: [54],
////////////////////                                //    visible: false,
////////////////////                                //    searchable: false
////////////////////                                //}
////////////////////                            ],
////////////////////                            dom: 'lBfrtip',
////////////////////                        });

////////////////////                        //$("#excelMasivo").attr('disabled', true) //para limpiar el campo 06.04.2021
////////////////////                        //limpiar
////////////////////                        $("#excelMasivo").val('');
////////////////////                        $("#btn-import-masivo").attr("disabled", true)

////////////////////                    } else {
////////////////////                        new PNotify({
////////////////////                            title: 'Importar Empleados',
////////////////////                            text: response.message,
////////////////////                            type: 'info',
////////////////////                            delay: 3000,
////////////////////                            styling: 'bootstrap3',
////////////////////                            addclass: 'dark'
////////////////////                        });
////////////////////                        return;
////////////////////                    }
////////////////////                },
////////////////////                complete: function () {
////////////////////                    $.unblockUI();
////////////////////                }
////////////////////            });
////////////////////        }, function (dismiss) {
////////////////////            if (dismiss == 'cancel') {
////////////////////                swal("Cancelado", "La Operación fue cancelada", "error");
////////////////////            }
////////////////////        });
////////////////////    } else {

////////////////////        new PNotify({
////////////////////            title: 'Importar Empleados',
////////////////////            text: 'Debe primero Importar el nuevo excel seleccionado.',
////////////////////            type: 'info',
////////////////////            delay: 3000,
////////////////////            styling: 'bootstrap3',
////////////////////            addclass: 'dark'
////////////////////        });
////////////////////        return;
////////////////////    }


////////////////////})

////////////////////$("#cboPlantilla").change(function () {
////////////////////    let idPlanilla = $(this).val()
////////////////////    if (parseInt(idPlanilla) == 1) { //comparando el strCoTipo
////////////////////        //if (idPlanilla == 1128) {
////////////////////        $("#excelMasivo").attr('disabled', false)
////////////////////        $(".divPlantillas").show()
////////////////////    } else {
////////////////////        $("#excelMasivo").attr('disabled', true)
////////////////////        $(".divPlantillas").hide()
////////////////////    }
////////////////////})

////////////////////$(document).ready(function () {
////////////////////    CombosImportacionMasiva()
////////////////////    init_checkBox_styles();

  
////////////////////    TablaInicial();
////////////////////})

////////////////////function TablaInicial() {
////////////////////    _varTablaMasivo = $('#datatable-Masivo').DataTable({
////////////////////        data: {},
////////////////////        columns: [
////////////////////            { data: "COD_EMP" },
////////////////////            { data: "COD_EMP_RUC" },
////////////////////            { data: "COD_EMP_DSC" },
////////////////////            { data: "COD_LOC" },
////////////////////            { data: "COD_LOC_DSC" },
////////////////////            { data: "COD_GER" },
////////////////////            { data: "COD_GER_DSC" },
////////////////////            { data: "COD_ARE" },
////////////////////            { data: "COD_ARE_DSC" },
////////////////////            { data: "COD_PL" },
////////////////////            { data: "COD_PL_DSC" },
////////////////////            { data: "COD_CG" },
////////////////////            { data: "COD_CG_DSC" },
////////////////////            { data: "COD_CT" },
////////////////////            { data: "COD_CT_DSC" },
////////////////////            { data: "COD_GR" },
////////////////////            { data: "COD_GR_DSC" },
////////////////////            { data: "COD_TP" },
////////////////////            { data: "COD_TP_DSC" },
////////////////////            { data: "COD_CC" },
////////////////////            { data: "COD_CC_DSC" },
////////////////////            { data: "COD_FIS" },
////////////////////            { data: "COD_RES" },
////////////////////            { data: "COD_EXT" },
////////////////////            { data: "COD_TD" },
////////////////////            { data: "NUMDOC" },
////////////////////            { data: "NOMBRES" },
////////////////////            { data: "FECNAC" },
////////////////////            { data: "GENERO" },
////////////////////            { data: "FOTOCHECK" },
////////////////////            { data: "FECADM" },
////////////////////            { data: "ESTADO" },
////////////////////            { data: "COD_REG" },
////////////////////            { data: "COD_HOR" },
////////////////////            { data: "COD_RES_IM" },
////////////////////            { data: "COD_RES_CT" },
////////////////////            { data: "CORREOP" },
////////////////////            { data: "CUENTA_US" },
////////////////////            { data: "CUENTA_PF" },
////////////////////            { data: "COD_VIA" },
////////////////////            { data: "DIRECCION" },
////////////////////            { data: "COD_UBI" },
////////////////////            { data: "CODPENSIONISTA" },
////////////////////            { data: "CODSALUD" },
////////////////////            { data: "TELEFONOP" },
////////////////////            { data: "CONTRATOI" },
////////////////////            { data: "FECCESE" },
////////////////////            { data: "COD_CESE" },
////////////////////            { data: "COD_GLIQ" },
////////////////////            { data: "COORDENADA" },
////////////////////            { data: "DIRCOORDENADA" },
////////////////////            { data: "INTIDPROCESO" },
////////////////////            { data: "OBSERVACION" },
////////////////////            { data: "FLAGOBSERVADO" },
////////////////////            { data: "ESTADO_FINAL" }
////////////////////        ],
////////////////////        lengthMenu: [10, 25, 50],
////////////////////        order: [],
////////////////////        responsive: true,
////////////////////        language: _datatableLanguaje,
////////////////////        columnDefs: [
////////////////////            {
////////////////////                targets: [0],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [1],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            //{
////////////////////            //    targets: [2],
////////////////////            //    visible: false,
////////////////////            //    searchable: false
////////////////////            //},
////////////////////            {
////////////////////                targets: [3],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [4],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [5],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [6],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [7],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [8],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [9],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [10],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [11],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [12],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [13],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [14],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [15],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [16],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [17],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [18],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [19],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [20],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [21],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [22],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [23],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            //{
////////////////////            //    targets: [24],
////////////////////            //    visible: false,
////////////////////            //    searchable: false
////////////////////            //},
////////////////////            //{
////////////////////            //    targets: [25],
////////////////////            //    visible: false,
////////////////////            //    searchable: false
////////////////////            //},
////////////////////            //{
////////////////////            //    targets: [26],
////////////////////            //    visible: false,
////////////////////            //    searchable: false
////////////////////            //},
////////////////////            {
////////////////////                targets: [27],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [28],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            //{
////////////////////            //    targets: [29],
////////////////////            //    visible: false,
////////////////////            //    searchable: false
////////////////////            //},
////////////////////            //{
////////////////////            //    targets: [30],
////////////////////            //    visible: false,
////////////////////            //    searchable: false
////////////////////            //},
////////////////////            {
////////////////////                targets: [31],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [32],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [33],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [34],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [35],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [36],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [37],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [38],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [39],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [40],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [41],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [42],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [43],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [44],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [45],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [46],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [47],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [48],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [49],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [50],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [51],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            //{
////////////////////            //    targets: [52],
////////////////////            //    visible: false,
////////////////////            //    searchable: false
////////////////////            //},
////////////////////            {
////////////////////                targets: [53],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            },
////////////////////            {
////////////////////                targets: [54],
////////////////////                visible: false,
////////////////////                searchable: false
////////////////////            }
////////////////////        ],
////////////////////        dom: 'lBfrtip',
////////////////////    });
////////////////////}
