let nombreExcel = ""
let idProceso = 0
let idProc;// = 0;
let _varTablaMasivo
let checkActualizar = false; checkLimpiarCargar
let bitNuevoExcel = false;
let srtDirImportacionExcel = "";
let direccion_ip;
let trueFalse = false;
let numeroexcelverificados = [];
let numeroexcelvacios = []; //NUNERO DE EXCEL OBSERVADOS VACIOS
let nonbresdelosexcel = [];
var ajaxTime;
var srtDirImportacionExcelP;
let srtDirIpConCsharp;
let listaInconsist;
var sumaRegistrosInsertados;
var sumaRegistrosActualizados;
var sumaRegistrosInconsistentes;
var sumaRegistrosLeidos;
var mensajeRegistrosInconsistente;
let chooseFileActivado = 0;
let srtDirImportacionMsjError = "";




$(document).ready(function () { 



    /////////////////////////////////////////////////////////////////////////////
    //MANTENER SESSION ACTIVA (apunta al otro js y al personal controller)
    /////////////////////////////////////////////////////////////////////////////
    SetupSessionUpdater('/Personal/KeepSessionAlive');

    ////FUENTE:https://www.geeksforgeeks.org/how-to-get-client-ip-address-using-javascript/
    //$.getJSON("https://api.ipify.org?format=json",
    //    function (data) {   
    //        direccion_ip = data.ip;
    //        //alert(direccion_ip);
    //    })


    //CONSEGUIR LA RUTA POR PRIMERA VEZ
    $.post(
        '/Personal/getRutaDirImpotraExcel',
        {
            //sinparametros
        },
        response => {



            if (response.type === 'success') {

                //No se hace nada, No muestra mensaje

                //alert('getRutaDirImpotraExcel');
                srtDirImportacionExcel = response.message;
                //alert(response);
                //alert(response.message);
                //Para eliminar todo lo que ahi existe por primera vez
                srtDirImportacionExcelP = response.message;

                chooseFileActivado = 1 ;

                //alert(srtDirImportacionExcelP);
                ////ELIMINAR TODO DE EXCEL AL ENTRAR EN ESTA VENTANA
                $.post('/Personal/eliminarTodoExcelDeDirImportacionExcel',
                    { srtDirImportacionExcelP },
                    response => {
                        console.log(response)
                    });

            }

            else {


                srtDirImportacionMsjError = response.message;

                swal({
                    //title: "Etiquetas",
                    text: srtDirImportacionMsjError,
                });

                
                chooseFileActivado = 0;

            }



        });


    //CONSEGUIR LA IP CON C#
    $.post(
        '/Personal/GetUserIPAddress',
            {
                //sinparametros
            },
        response => {
       
                srtDirIpConCsharp = response;       
                //alert(srtDirIpConCsharp);      
       
            });  
       
});


//CHECHEAR DESCHECKEAR LIMPIAR TABLAS
$('.flatpadre').change(function () {

    $('.flathijo').prop('checked', this.checked);
});
//------------------------------------------------------------>
$('.flathijo').change(function () {

    if ($('.flathijo:checked').length == $('.flathijo').length) {
        $('.flatpadre').prop('checked', true);
    }
    else {
        $('.flatpadre').prop('checked', false);
    }

});
//------------------------------------------------------------>OFICINA
$('#checkEntidad').change(function () {

    $('#checkBienes').prop('checked', this.checked); /*.prop('checked', this.checked);*/

});
//------------------------------------------------------------>LOCAL
$('#checkLocal').change(function () {

    $('#checkArea').prop('checked', this.checked);
    $('#checkOficina').prop('checked', this.checked);
    $('#checkEmpleado').prop('checked', this.checked);
    $('#checkBienes').prop('checked', this.checked);

});
//------------------------------------------------------------>AREA
$('#checkArea').change(function () {

    $('#checkOficina').prop('checked', this.checked);
    $('#checkEmpleado').prop('checked', this.checked);
    $('#checkBienes').prop('checked', this.checked);

    //$('#checkOficina').prop('disabled', true);
    //$('#checkEmpleado').prop('disabled', true);
    //$('#checkBienes').prop('disabled', true);
});
//------------------------------------------------------------>OFICINA
$('#checkOficina').change(function () {

    $('#checkBienes').prop('checked', this.checked);

});
//------------------------------------------------------------>EMPLEADO
$('#checkEmpleado').change(function () {

    $('#checkBienes').prop('checked', this.checked);

});
//------------------------------------------------------------>ESTADO
$('#checkEstado').change(function () {

    $('#checkBienes').prop('checked', this.checked);

});
//------------------------------------------------------------>TIPO
$('#checkTipo').change(function () {

    $('#checkBienes').prop('checked', this.checked);

});


//ELIMINAR TODO DE CARPETA 'DIRIMPORTACIONEXCEL' AL SALIR DEL SISTEMA
$('#CerrarSesion_').click(function () {
    //alert('clicked');
    eliminarTodoExcelDeDirImportacionExcel();
});

//CONVERSION DE TIEMPO 
var secondsToTime = function (s) {

    function addZ(n) {
        return (n < 10 ? '0' : '') + n;
    }

    var ms = s % 1000;
    s = (s - ms) / 1000;
    var secs = s % 60;
    s = (s - secs) / 60;
    var mins = s % 60;
    var hrs = (s - mins) / 60;

    return addZ(hrs) + 'h:' + addZ(mins) + 'm:' + addZ(secs) + 's';
}

function CombosImportacionMasiva() {
    validarSession()
    var intIdMenu = 0

    $.post(
        '/Personal/ListarCombosPersonal',
        {
            intIdMenu, strEntidad: 'IMPORTACIONMASIVA', intIdFiltroGrupo: 0, strGrupo: 'TIPOIMP', strSubGrupo: '',
        },
        response => {
            $('#cboPlantilla').empty()
            $('#cboPlantilla').append('<option value="0">Seleccione</option>')
            response.forEach(element => {
                $('#cboPlantilla').append('<option ruc="' + element.strextra1 + '" value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
            })

            $('#cboPlantilla').change(function () {
            })

        });

    $.post(
        '/Personal/ListarCombosPersonal',
        {
            intIdMenu, strEntidad: 'IMPORTACIONMASIVA', intIdFiltroGrupo: 0, strGrupo: 'FORMATOFEC', strSubGrupo: '',
        },
        response => {
            $('#cboFormato').empty()
            $('#cboFormato').append('<option value="0">Seleccione</option>')
            response.forEach(element => {
                $('#cboFormato').append('<option ruc="' + element.strextra1 + '" value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
            })

            $('#cboFormato').change(function () {
            })

        });

}

$(".columnHide").click(function () {
    var index = $(this)[0].id;
    if (typeof _varTablaMasivo !== 'undefined') {
        var column = _varTablaMasivo.column(index);

        // Toggle the visibility
        column.visible(!column.visible());
    }
})

//Obtener la ruta de 'DIRIMPORTACIONEXCEL'
function getRutaDirImpotraExcel() {

    $.post(
        '/Personal/getRutaDirImpotraExcel', 
        {
            //parametros
        },
        response => {       

            srtDirImportacionExcel = response;
       
        });           

}

//GUARDAR RUTA DEL DIRECTORIO y IP EN LA BD
function GuardarRutaDirectorioPorIpExcel() {

    var _strDesRuta = srtDirImportacionExcel;// srt.substr(0, 100); //"C:\\Users\Documents\\TECFLEX\\PruebasEcxel";
    var _strSessionIp = srtDirIpConCsharp;//direccion_ip ;

    //if (typeof _strDesRuta === "undefined" || _strDesRuta == "" ) {
    //    new PNotify({
    //        title: 'Importación Masiva Excel',
    //        text: 'No existe ningún el directorio.',
    //        type: 'info',
    //        delay: 3000,
    //        styling: 'bootstrap3',
    //        addclass: 'dark'
    //    });

    //    return false;
    //}  
     
    //if (typeof _strSessionIp === "undefined" || _strIpSession == "") {
    //    new PNotify({
    //        title: 'Importación Masiva Excel',
    //        text: 'No se puede capturar la ip del equipo.',
    //        type: 'info',
    //        delay: 3000,
    //        styling: 'bootstrap3',
    //        addclass: 'dark'
    //    });

    //    return false;
    //} 


    $.post(
        '/Personal/IRutaDirectorioPorIpMasivoExcel', //RutaDirectorioExcel
        {
            strDesRuta: _strDesRuta, strSessionIp: _strSessionIp,
        },
        response => {

            //trueFalse = true;

        });

    //trueFalse = true;

}


/*let trueFalse = false;*/
//===============================================================================================
//===== CARGAR LOS EXCELS A LA CARPETA TEMPORAL DEL SISTEMA 'DirImportacionExcel'
//===============================================================================================
var excelsEnDirImportacionExcel = new Array(); 
$("#excelMasivo").change(function (oEvent) {

    validarSession();
    //Si la ruta para crear existe entonces este botón no caragrá los excels
   if (chooseFileActivado == 0) {
               
        swal({

            text: srtDirImportacionMsjError,

        });

        $("#excelMasivo").val('');
        return;

   }

   //En caso si exista la ruta, se creará la carpeta.
   else {

        //CREAR LA CARPETA 
        $.post(
            '/Personal/getRutaDirImpotraExcel',
            {
                //sinparametros
            },

            response => {


               $("#progresLoader").html("");
               $("#progresLoader").width("");
               $("#procesados").html("--/--")
               $("#tiempo").html("--:--:--")
               nonbresdelosexcel = [];

    
    //GENERAR EL ID PROCESO CON UN RANDOM
    IDPRoceso = Math.floor(Math.random() * 10000) + 1;
    idProc = IDPRoceso;

    //eliminarExcelDeDirectorio(); //Eliminar los excels con el IDPROCESO HGM 
    $('#message').css('color', 'black');

    GuardarRutaDirectorioPorIpExcel(); //HGM 


    /************************************************
    trueFalse = GuardarRutaDirectorioPorIpExcel();
    alert(trueFalse);
    if (!trueFalse) { return; }
    *************************************************/

    // Get The File From The Input
    $("#btn-import-masivo").attr("disabled", true);
    $("#checkLimpiarCargar").attr("disabled", true);
    $("#checkLimpiarCargar").prop('checked', false);

    excelsEnDirImportacionExcel = [];
    var cant_xlsx_xls_origen = oEvent.target.files.length;

    //VERIFICAR SI TIENE EL MISMO NOMBRE
    let obj_xlsx = oEvent.target.files;

    for (var i = 0, iLen = obj_xlsx.length; i < iLen; i++) {

        if (obj_xlsx[i].name === "") { return obj_xlsx[i].name; }

        nonbresdelosexcel.push(obj_xlsx[i].name);
    }


    if (cant_xlsx_xls_origen < 8) {
        new PNotify({
            title: 'Importación Masiva Excel',
            text: 'Tiene que seleccionar los 8 archivos necesarios para la Importación.',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        nonbresdelosexcel = [];
        $("#message").html('');
        $("#excelMasivo").val('');
        return;
    }

    if (cant_xlsx_xls_origen > 8) {
        new PNotify({
            title: 'Importación Masiva Excel',
            text: 'No se puede cargar más de 8 Archivos.',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        nonbresdelosexcel = [];
        $("#message").html('');
        $("#excelMasivo").val('');
        return;
    }


    //VERIFICAR SI LOS NOMBRES SON CORRECTOS
    var nomCorrectos_XLS = ["TBAREAS.xls", "TBBIENES.xls", "TBEMPLEADO.xls", "TBENTIDAD.xls", "TBESTADO.xls", "TBLOCAL.xls", "TBOFICINA.xls", "TBTIPO.xls"];
    var nomCorrectos_XLSX = ["TBAREAS.xlsx", "TBBIENES.xlsx", "TBEMPLEADO.xlsx", "TBENTIDAD.xlsx", "TBESTADO.xlsx", "TBLOCAL.xlsx", "TBOFICINA.xlsx", "TBTIPO.xlsx"];

    let true_false_xls = false;
    let true_false_xlsx = false;
    ///=================================================
    if (nomCorrectos_XLS.sort().join(',') === nonbresdelosexcel.sort().join(',')) {

        true_false_xls = true;
        //alert('Sí se puede continuar con la carga de los excels XLS');//Ya que ambos arrays tienes los mismos elementos
    }

    if (nomCorrectos_XLSX.sort().join(',') === nonbresdelosexcel.sort().join(',')) {

        true_false_xlsx = true;
        //alert('Sí se puede continuar con la carga de los excels XLSX');//Ya que ambos arrays tienes los mismos elementos
    }

    //if (true_false_xls == true || true_false_xlsx == true)
    //{
    //    alert('Sí tienen los mismos nombres');
    //}

    //SI LOS EXCEL SELECCIONADOS NO TIENEN LOS NOMBRES CORRECTOS ENTONCES LA CARGA SE DETIENE
    if (true_false_xls == false && true_false_xlsx == false) {
        //alert('Hay algun documento que no tiene nombre correcto');
        new PNotify({
            title: 'Importación Masiva Excel',
            text: 'Existe algún Excel que no tiene el nombre correcto',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        nonbresdelosexcel = [];
        $("#message").html('');
        $("#excelMasivo").val('');
        return;
    }


    //SI LOS EXCEL SELECCIONADOS TIENEN LOS NOMBRES CORRECTOS ENTONCES LA CARGA PROCEDE
    if (true_false_xls == true || true_false_xlsx == true) {

        nonbresdelosexcel = [];//Se limpia los nombres  en caso se desee selecionar nuevamente otros documentos

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
            message: 'Cargando Documentos...'
        });

        //var DirectorioGeneral = oEvent.target.files[0].mozFullPath;    
        //let IDPRoceso = Math.floor(Math.random() * 10000) + 1; //1-10000
        //IDPRoceso = Math.floor(Math.random() * 10000) + 1; 
        /* Se comenta poruque generar error en el tiempo de copiado de archivos
           Y se reemplaza el mismo random en el otro post ajax
        $.post('/Personal/IdProcess_',
            { IDPRoceso: IDPRoceso},
            response => {
                console.log(response)
            });
        */

        /////////////////////////////////////////////////////////////////////
        // ENVIAR UNO POR UNO LOS EXCELS CAPTURADOS CON EL CHOOSE FILE
        /////////////////////////////////////////////////////////////////////
        var i = 0;
        for (i = 0; i < cant_xlsx_xls_origen; i++) {

            var oFile = oEvent.target.files[i];
            if (oFile != null) {

                //alert(oFile.name)
                //idProc = IDPRoceso;
                var formData = new FormData()
                formData.append('archivos' + '/' + IDPRoceso, oFile);//, oIDPRoceso);
                //formData.append('archivos' , oFile);
                //formData.append("partner", IDPRoceso);  
                //var locale = "hola";
                //var parameter = {
                //    formData,
                //    locale: locale
                //};  



                //$('#btn-prueba').on('click', function () {


                    //////////$.post(
                    //////////    '/Personal/uploadFilesToDirImportacion',
                    //////////    {
                    //////////       formData,
                    //////////    },
                    //////////    response => {


                    //////////        alert('respuesta exitosa');

                    //////////    });



                //});

                $.ajax({
                    url: "/Personal/uploadFilesToDirImportacion",
                    type: 'POST',
                    data: formData,
                    //data: JSON.stringify(parameter),
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        console.log(data)

                        //alert(data[0]);
                        //alert('list:', data.files(""));
                        //var second = data[1].count;
                        //rutaDirectorioExcel = data;//añadido 06.04.2021
                        //$("#btn-import-masivo").attr("disabled", false)
                        //rutaDirectorioExcel = [];
                        //rutaDirectorioExcel = data;//añadido 06.04.2021

                        excelsEnDirImportacionExcel = data;
                        pathDelDirectorio = data[0]; //AREA -----cargo
                        pathDelDirectorio2 = data[1]; //BIENES----Esta tabla tiene que ser la última en el orden de guardar en la BD
                        pathDelDirectorio3 = data[2]; //EMPLEADO--cargo
                        pathDelDirectorio4 = data[3]; //ENTIDAD---cargo
                        pathDelDirectorio5 = data[4]; //ESTADO
                        pathDelDirectorio6 = data[5]; //LOCAL
                        pathDelDirectorio7 = data[6]; //OFICINA--cargo
                        pathDelDirectorio8 = data[7]; //TIPO

                        $("#message").html('');
                        //alert(cant_xlsx_xls_origen + '  ' + excelsEnDirImportacionExcel.length);
                        var asubir = cant_xlsx_xls_origen.toString();
                        var subidos = (excelsEnDirImportacionExcel.length).toString();
                        if (asubir == subidos) {

                            //Reordenar los elementos del arreglo: La tabla TBBIENES de la posición 1 hasta la posición 7
                            const swapPositions = (array, a, b) => {
                                [array[a], array[b]] = [array[b], array[a]]
                            }

                            //REORDENANDO LOS ARCHIVOS PARA SER ENVIADOS AL CONTROLADOR/SERVICE Y BD
                            swapPositions(excelsEnDirImportacionExcel, 1, 7);
                            swapPositions(excelsEnDirImportacionExcel, 2, 5);
                            swapPositions(excelsEnDirImportacionExcel, 0, 3);
                            swapPositions(excelsEnDirImportacionExcel, 1, 2);
                            swapPositions(excelsEnDirImportacionExcel, 2, 6);
                            swapPositions(excelsEnDirImportacionExcel, 2, 3);
                            swapPositions(excelsEnDirImportacionExcel, 4, 5);


                            $("#procesados").html("")
                            $("#procesados").html("0/8")
                            $("#tiempo").html("00h:00m:00s")
                            $("#btn-import-masivo").attr("disabled", false);
                            $("#checkLimpiarCargar").attr("disabled", false);
                            //CUANDO SE HAYAN CARGADO LOS 8 EXCELS
                            if (i > 6) {

                                $.unblockUI();
                            }


                        }


                    }
                });

                //INDICAR QUE ACABAN DE ATACHAR NUEVO ARCHIVO
                bitNuevoExcel = true;
            }

        }


    }





            });

    }//FIN DEL ELSE

})

//ELIMINAR DOCUMENTOS EXCEL QUE SE CARGARON A 'DIRIMPORTACIONEXCEL' CON EL CHOOSE FILE
function eliminarExcelDeDirectorio() {

   $.post('/Personal/eliminarExcelDeDirectorio',
       { idProc },
       response => {   
           console.log(response)   
       });
   
   $("#excelMasivo").val('');
   
}

//ELIMINAR TODO EXCEL QUE SE CARGARON A 'DIRIMPORTACIONEXCEL' CON EL CHOOSE FILE
function eliminarTodoExcelDeDirImportacionExcel() {

    if (srtDirImportacionExcelP !== "") {

        $.post('/Personal/eliminarTodoExcelDeDirImportacionExcel',
            { srtDirImportacionExcelP },
            response => {
                console.log(response)
            });
       
    }
    else {

        //No hace nada
    }
}

//LIMPIAR TABLAS DEPENDIENDO DEL CHECK SELECCIONADO
function LimpiarTablas() {

    $("#progresLoader").html("");
    $("#progresLoader").width("");
    //alert('desea limpiar');
    let chckTodos     = $("#checkTodos").is(':checked');
    let chckEntidad   = $("#checkEntidad").is(':checked');
    let chckLocal     = $("#checkLocal").is(':checked');
    let chckArea      = $("#checkArea").is(':checked');
    let chckOficina   = $("#checkOficina").is(':checked');
    let chckEmpleado  = $("#checkEmpleado").is(':checked');
    let chckEstado    = $("#checkEstado").is(':checked');
    let chckTipo      = $("#checkTipo").is(':checked');
    let chckBienes    = $("#checkBienes").is(':checked'); 

    //var tablasEliminar = "";
    //if (chckEntidad  == true && chckBienes == true) { tablaEliminar = "TBENTIDAD y TBBIENES" }
    //if (chckLocal    == true && chckBienes == true) { tablaEliminar = "TBLOCAL, TBAREA, TBOFICINA, TBEMPLEADO y TBBIENES" }
    //if (chckArea     == true) { tablaEliminar = "TBAREA, TBOFICINA, TBEMPLEADO y TBBIENES" }
    //if (chckOficina  == true) { tablaEliminar = "TBOFICINA y TBBIENES " }
    //if (chckEmpleado == true) { tablaEliminar = "TBEMPLEADO y TBBIENES " }
    //if (chckEstado   == true) { tablaEliminar = "TBESTADO y TBBIENES" }
    //if (chckTipo     == true) { tablaEliminar = "TBTIPO y TBBIENES" }
    ////if (chckBienes   == true) { tablaEliminar = "TBBIENES" }

    swal({
        title: "Limpiar Tablas",
        //text: "Al limpiar las tablas seleccionadas, \nlos datos que éstas contienen se eliminarán.",
        text: "Al Confirmar esta operación, los datos\n de la tablas seleccionadas se eliminarán.",
        //text: "Al Confirmar la operación se eliminaran los datos en la base de datos de :"+
        //       "\n"+tablaEliminar,
        type: "info",
        showCancelButton: true,
        confirmButtonText: "Sí, Continuar",
        cancelButtonText: "No, cancelar",
    }).then(function (isConfirm) {
       
    //////////////////////////////////////////////////////////////////
    //SI SE CONFIRMA ELIMINACION ENTONCES SE EJECUTARA LO SIGUIENTE :
    //////////////////////////////////////////////////////////////////
        $.ajax({
            url: '/Personal/LimpiarTablasExcel',
            type: 'POST',
            data: { chckTodos, chckEntidad, chckLocal, chckArea, chckOficina, chckEmpleado, chckEstado, chckTipo, chckBienes },
            beforeSend: function () {
                
                $("#message").html('');
                //$("#message").append('\nLimpiando . . .');
            },

            success: function (response) {

                if (response.type == "success") {

                    console.log(response)

                    new PNotify({
                        title: 'Limpiar Tablas',
                        text: response.message, 
                        type: 'info',
                        delay: 3000,
                        styling: 'bootstrap3',
                    });

                    $('#cerrar_modal').click();
                    $("#message").html('');                    
                    return;

                    //new PNotify({
                    //    title: 'Actualización Jerarquía Organizacional',
                    //    text: response.message,
                    //    type: response.type,
                    //    delay: 3000,
                    //    styling: 'bootstrap3'
                    //});
                    //}
                    //lista.forEach(element => {
                    //    //sumaRegistrosInsertados = sumaRegistrosInsertados + (element.intInsertado);
                    //})
                    //$("#txt_titulo_tabla").html("Datos Importados");

                }

                else {
                    $("#message").append('\n' + response.message);
                    return;
                }
            },

            complete: function (response) {

                $('.flathijo').prop('checked', false);
                $('.flatpadre').prop('checked', false);
                $('#cerrar_modal').click();

                //var totalTime = secondsToTime(new Date().getTime() - ajaxTime);
            }

        });


    //////////////////////////////////////////////////////////////////
    //FIN DE EJECUCION
    //////////////////////////////////////////////////////////////////


    }, function (dismiss) {
        if (dismiss == 'cancel') {
            swal("Cancelado", "La Operación fue cancelada", "error");
        }
    });

 


}


//$.ajax({
//    url: "http://something/whatever.docx",
//    method: "HEAD",
//    statusCode: {
//        404: function () {
//            alert('not found');
//        },
//        200: function () {
//            alert("foundfile exists");
//        }
//    }
//});


//$("#info_rightclick_left").click(function () {
//    if ($("#pagination_previous").length) {
//        window.location = $("#pagination_previous a").attr("href");
//    } else {
//        alert("NOO");
//    }
//});


//////Descargar plantillas en un solo click
//$("a.linky").on('click', function (event) {
//    //CONSEGUIR LA IP CON C#
//    $.post(
//        '/Personal/getRutaPlantillasExcel',
//        {
//            //sinparametros
//        },
//        response => {
//            srtDirIpConCsharp = response.message;
//            alert(srtDirIpConCsharp);  
//        });
//    //alert("por descargar plantillas");
//});


var srtDirIpMensaje = "";
var trueFalseHREF = false;
function descargarPlantillaExcel() {

        //fileNameExcel = 

        $.post(
        '/Personal/getRutaPlantillasExcel',
        {
            //fileNameExcel, //sinparametros
        },
        response => {

             srtDirIpMensaje = response.message;
             //alert(srtDirIpMensaje);    
  
             
             if (response.type === 'success') {
              //do stuffs
              //This will tell browser to follow the link.
                 trueFalseHREF = true;
             
             }             
             else {
             
                 swal({
                     //title: "Etiquetas",
                     text: srtDirIpMensaje,
                 });
             
              //do stuffs
              //This will cancel the default behaviour of the browser.
              //Abort the effect of href
                 trueFalseHREF = false;
             }

        }); 

        return trueFalseHREF;
}


$('#checkLimpiarCargar').change(function () {

    //$('#checkBienes').prop('checked', this.checked);
    if ($('#checkLimpiarCargar').is(':checked') == true) {
        new PNotify({
            title: 'Importación Masiva Excel',
            text: "Esta opción permite eliminar los datos de todas las tablas antes de la importación",
            type: 'info',
            delay: 5000,
            styling: 'bootstrap3',

        });
    }
    else {

    }

});

/*=================================================================
      BLOQUE DE LOS 08 MÉTODOS PARA CADA EXCEL A IMPORTAR
===================================================================*/
function IMPORTAR_TBENTIDAD_01() {

    let cboPlantilla = 1;
    let cboFormato = 1129;
    checkActualizar = $("#checkLimpiarCargar").is(':checked');
    pathDelDirectorio_ = excelsEnDirImportacionExcel[0];
    var pathDelDirectorio_1 = pathDelDirectorio_;
    let nomExcel_ = "TBENTIDAD.xlxs"; //pathDelDirectorio_1.slice(103, 120);
    $("#message").html('');

    //CASO 01: Si el FLAT "Limpiar y guardar" esta checkeado, entonces limpiamos todas las tablas antes de Importar.
    if ($('#checkLimpiarCargar').is(':checked') == true) {

        let chckTodos     = $("#checkLimpiarCargar").is(':checked');  
        let chckEntidad   = false;
        let chckLocal     = false;
        let chckArea      = false;
        let chckOficina   = false;
        let chckEmpleado  = false;
        let chckEstado    = false;
        let chckTipo      = false;
        let chckBienes    = false;
        
        $.ajax({
        url: '/Personal/LimpiarTablasExcel',
        type: 'POST',
        data: { chckTodos, chckEntidad, chckLocal, chckArea, chckOficina, chckEmpleado, chckEstado, chckTipo, chckBienes },
        beforeSend: function () {

            var totalTime = secondsToTime(new Date().getTime() - ajaxTime);
            $("#message").append('Limpiando . . .');
        },
        success: function (response) {

            if (response.type == "success") {

                console.log(response)
                let lista = response.objeto
                $("#excelMasivo").val('');
                $("#message").html('');
                $("#message").append('Se ha eliminado los datos todas las Tablas . . . ');
                $("#message").append('\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ');
                //cantExcelsEnDir = response.length;
                //if (cantExcelsEnDir > 0) {
                //    new PNotify({
                //        title: 'Importación Masiva Excel',
                //        text: 'Se ha Eliminado los Datos de la(s) Tabla(s) Seleccionada(s)',
                //        type: 'info',
                //        delay: 3000,
                //        styling: 'bootstrap3',
                //        addclass: 'dark'
                //    });
                //    return;
                //}
                //////lista.forEach(element => {
                //////    //sumaRegistrosInsertados = sumaRegistrosInsertados + (element.intInsertado);
                //////})
                //$("#txt_titulo_tabla").html("Datos Importados");

                ////////////////////////////////////////////////////////////////////////////////////////////
                //CUANDO SE HAYAN LIMPIADO LAS TABLAS RECIEN COMENZARÁ LA IMPORTACIÓN
                $.ajax({
                    url: '/Personal/ImportMasivoExcel',
                    type: 'POST',
                    data: { cboPlantilla, cboFormato, checkActualizar, pathDelDirectorio_ },
                    beforeSend: function () {

                        var totalTime = secondsToTime(new Date().getTime() - ajaxTime);
                        //$("#message").html('');
                        $("#tiempo").html(totalTime)
                        $('#message').css('color', 'blue');
                        $("#progresLoader").html("3%");
                        $("#progresLoader").width("3%");
                        $("#progresLoader").addClass('active');
                        $('#message').css('color', 'green');
                        $("#message").append('\nLa Importación de ' + nomExcel_ + ' se está procesando . . .');

                    },

                    success: function (response) {

                        if (response.type == "success") {

                            console.log(response)
                            let lista = response.objeto
                            $("#excelMasivo").val('');

                            lista.forEach(element => {

                                sumaRegistrosInsertados = element.intInsertado;
                                sumaRegistrosActualizados = element.intActualizado;
                                sumaRegistrosInconsistentes = element.intInconsistente;
                                sumaRegistrosLeidos = (element.intInsertado + element.intActualizado + element.intInconsistente);
                                $('#message').css('color', 'blue');
                                $("#message").append('\nNombre: ' + element.strNombreTabla + ' | ' + 'Insertado = ' + element.intInsertado + ' | ' + 'Actualizado = ' + element.intActualizado + ' | ' + ' Inconsistentes = ' + element.intInconsistente + ' | ' + 'Total Procesados = ' + (element.intInsertado + element.intActualizado + element.intInconsistente));
                                $("#message").append('\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ');
                                IMPORTAR_TBLOCAL_02();

                            })


                            $("#txt_titulo_tabla").html("Datos Importados");
                            $(".divEmpSave").hide();
                            $(".divEmpUpdate").hide();

                        }

                        else {
                            $("#message").append('\n' + response.message);
                            //var mensaje_de_error = 'TB' + response.message.split("TB").pop();
                            //$("#message").append('\nLa importación no será posible porque ' + mensaje_de_error);
                            $("#excelMasivo").val('');
                            $("#btn-import-masivo").attr("disabled", true);
                            $("#excelMasivo").attr("disabled", false);
                            $("#boton_limpar_manualmente").attr("disabled", false);
                            $("#checkLimpiarCargar").attr("disabled", false);
                            return;
                        }
                    },

                    complete: function (response) {

                        var totalTime = secondsToTime(new Date().getTime() - ajaxTime);
                        $("#tiempo").html(totalTime)
                        $('#message').css('color', 'blue');
                        $("#procesados").html("")
                        $("#procesados").html("1/8")
                        $("#progresLoader").html("12%");
                        $("#progresLoader").width("12%");
                        $("#progresLoader").addClass('active');

                    }

                });
                ////////////////////////////////////////////////////////////////////////////////////////////

            }

            else {
                $("#message").append('\n' + response.message);
                return;
            }
        },

        complete: function (response) {

            //PROCESO COMPLETADO
        }

    });

    }


    //CASO 02: CUANDO EL FLAT "Limpiar y guardar" NO ESTA CHECKEADO IMPORTAMOS DE FRENTE
    else{

    $.ajax({
        url: '/Personal/ImportMasivoExcel',
        type: 'POST',
        data: { cboPlantilla, cboFormato, checkActualizar, pathDelDirectorio_ },
        beforeSend: function () {

            var totalTime = secondsToTime(new Date().getTime() - ajaxTime);
            $("#tiempo").html(totalTime)
            $('#message').css('color', 'blue');
            $("#progresLoader").html("3%");
            $("#progresLoader").width("3%");            
            $("#progresLoader").addClass('active');
            $('#message').css('color', 'green');
            $("#message").append('La Importación de ' + nomExcel_ + ' se está procesando . . .');

        },

        success: function (response) {

            if (response.type == "success") {

                console.log(response)
                let lista = response.objeto
                $("#excelMasivo").val('');

                lista.forEach(element => {

                    sumaRegistrosInsertados = element.intInsertado;
                    sumaRegistrosActualizados = element.intActualizado;
                    sumaRegistrosInconsistentes = element.intInconsistente;
                    sumaRegistrosLeidos = (element.intInsertado + element.intActualizado + element.intInconsistente);
                    //mensajeRegistrosInconsistente = element.strInconsistente;
                    $('#message').css('color', 'blue');
                    $("#message").append('\nNombre: ' + element.strNombreTabla + ' | ' + 'Insertado = ' + element.intInsertado + ' | ' + 'Actualizado = ' + element.intActualizado + ' | ' + ' Inconsistentes = ' + element.intInconsistente + ' | ' + 'Total Procesados = ' + (element.intInsertado + element.intActualizado + element.intInconsistente));
                    //if (mensajeRegistrosInconsistente != "")
                    //{
                    //    $("#message").append('\n ' + mensajeRegistrosInconsistente);
                    //}

                    $("#message").append('\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ');
                    IMPORTAR_TBLOCAL_02();  


                })

                
                $("#txt_titulo_tabla").html("Datos Importados");
                $(".divEmpSave").hide();
                $(".divEmpUpdate").hide();

            }

            else {
                $("#message").append('\n' + response.message);
                //var mensaje_de_error = 'TB' + response.message.split("TB").pop();
                //$("#message").append('\nLa importación no será posible porque ' + mensaje_de_error);
                $("#excelMasivo").val('');
                $("#btn-import-masivo").attr("disabled", true);
                $("#excelMasivo").attr("disabled", false);
                $("#boton_limpar_manualmente").attr("disabled", false);
                $("#checkLimpiarCargar").attr("disabled", false);
                return;
            }
        },

        complete: function (response) { 

            var totalTime = secondsToTime(new Date().getTime() - ajaxTime);
            $("#tiempo").html(totalTime)
            $('#message').css('color', 'blue');
            $("#procesados").html("")
            $("#procesados").html("1/8")
            $("#progresLoader").html("12%");
            $("#progresLoader").width("12%");
            $("#progresLoader").addClass('active');

        }

    });

    }

}

function IMPORTAR_TBLOCAL_02() {

    //var line1 = $("#message").val().split('\n');
    //line1.splice(0, 1);
    //$("#message").val(line1.join("\n"));
    let cboPlantilla = 1;
    let cboFormato = 1129;
    checkActualizar = $("#checkLimpiarCargar").is(':checked');
    pathDelDirectorio_ = excelsEnDirImportacionExcel[1];
    var pathDelDirectorio_1 = pathDelDirectorio_;
    let nomExcel_ = "TBLOCAL.xlxs"; //pathDelDirectorio_1.slice(103, 120);

    $.ajax({
        url: '/Personal/ImportMasivoExcel',
        type: 'POST',
        data: { cboPlantilla, cboFormato, checkActualizar, pathDelDirectorio_ },
        beforeSend: function () {

            var totalTime = secondsToTime(new Date().getTime() - ajaxTime);
            $("#tiempo").html(totalTime)
            $('#message').css('color', 'blue');
            $("#progresLoader").html("15%")
            $("#progresLoader").width("15%")
            $("#progresLoader").addClass('active')
            $('#message').css('color', 'green');
            $("#message").append('\nLa Importación de ' + nomExcel_ + ' se está procesando . . .');
        },

        success: function (response) {

            if (response.type == "success") {

                console.log(response)
                let lista = response.objeto
                $("#excelMasivo").val('');

                lista.forEach(element => {

                    sumaRegistrosInsertados = sumaRegistrosInsertados + (element.intInsertado);
                    sumaRegistrosActualizados = sumaRegistrosActualizados + (element.intActualizado);
                    sumaRegistrosInconsistentes = sumaRegistrosInconsistentes + (element.intInconsistente);
                    sumaRegistrosLeidos = sumaRegistrosLeidos + (element.intInsertado + element.intActualizado + element.intInconsistente);
                    //mensajeRegistrosInconsistente = element.strInconsistente;
                    $('#message').css('color', 'blue');
                    $("#message").append('\nNombre: ' + element.strNombreTabla + ' | ' + 'Insertado = ' + element.intInsertado + ' | ' + 'Actualizado = ' + element.intActualizado + ' | ' + ' Inconsistentes = ' + element.intInconsistente + ' | ' + 'Total Procesados = ' + (element.intInsertado + element.intActualizado + element.intInconsistente));
                    $("#message").append('\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ');
                    IMPORTAR_TBAREAS_03();

                })

                $("#txt_titulo_tabla").html("Datos Importados");
                $(".divEmpSave").hide();
                $(".divEmpUpdate").hide();

            }

            else {
                $("#message").append('\n' + response.message);
                //var mensaje_de_error = 'TB' + response.message.split("TB").pop();
                //$("#message").append('\nLa importación no será posible porque ' + mensaje_de_error);
                $("#excelMasivo").val('');
                $("#btn-import-masivo").attr("disabled", true);
                $("#excelMasivo").attr("disabled", false);
                $("#boton_limpar_manualmente").attr("disabled", false);
                $("#checkLimpiarCargar").attr("disabled", false);
                return;
            }
        },

        complete: function (response) {

            var totalTime = secondsToTime(new Date().getTime() - ajaxTime);
            $("#tiempo").html(totalTime)
            $('#message').css('color', 'blue');
            $("#procesados").html("")
            $("#procesados").html("2/8")
            $("#progresLoader").html("24%");
            $("#progresLoader").width("24%");
            $("#progresLoader").addClass('active');
        }

    });


}

function IMPORTAR_TBAREAS_03() {

    let cboPlantilla = 1;
    let cboFormato = 1129;
    checkActualizar = $("#checkLimpiarCargar").is(':checked');
    pathDelDirectorio_ = excelsEnDirImportacionExcel[2];//(excelsEnDirImportacionExcel[i]).toString();
    var pathDelDirectorio_1 = pathDelDirectorio_;
    let nomExcel_ = "TBAREAS.xlxs"; //pathDelDirectorio_1.slice(103, 120); //Sacamos del Path solamente el nombre del excel 
    //var line2 = $("#message").val().split('\n');
    //line2.substring(line2.indexOf("\n") - 1);

    //G_TBAREAS = excelsEnDirImportacionExcel[0]; //TBAREAS 
    //G_TBTIPO = excelsEnDirImportacionExcel[1]; //TBTIPO
    //G_TBBIENES = excelsEnDirImportacionExcel[2]; //TBBIENES
    //G_TBOFICINA = excelsEnDirImportacionExcel[3]; //TBOFICINA
    //G_TBEMPLEADO = excelsEnDirImportacionExcel[4]; //TBEMPLEADO
    //G_TBLOCAL = excelsEnDirImportacionExcel[5]; //TBLOCAL
    //G_TBENTIDAD = excelsEnDirImportacionExcel[6]; //TBENTIDAD
    //G_TBESTADO = excelsEnDirImportacionExcel[7]; //TBESTADO

    // TBAREAS
    $.ajax({
        url: '/Personal/ImportMasivoExcel',
        type: 'POST',
        data: { cboPlantilla, cboFormato, checkActualizar, pathDelDirectorio_ },
        beforeSend: function () {

            var totalTime = secondsToTime(new Date().getTime() - ajaxTime);
            $("#tiempo").html(totalTime)
            $('#message').css('color', 'blue');
            $("#progresLoader").html("26%");
            $("#progresLoader").width("26%");
            $("#progresLoader").addClass('active');
            $('#message').css('color', 'green');
            $("#message").append('\nLa Importación de ' + nomExcel_ + ' se está procesando . . .');

        },
        success: function (response) {

            if (response.type == "success") {

                console.log(response)
                let lista = response.objeto
                $("#excelMasivo").val('');

                lista.forEach(element => {

                    sumaRegistrosInsertados = sumaRegistrosInsertados + (element.intInsertado);
                    sumaRegistrosActualizados = sumaRegistrosActualizados + (element.intActualizado);
                    sumaRegistrosInconsistentes = sumaRegistrosInconsistentes + (element.intInconsistente);
                    sumaRegistrosLeidos = sumaRegistrosLeidos + (element.intInsertado + element.intActualizado + element.intInconsistente);
                    //mensajeRegistrosInconsistente = element.strInconsistente;
                    $('#message').css('color', 'blue');
                    $("#message").append('\nNombre: ' + element.strNombreTabla + ' | ' + 'Insertado = ' + element.intInsertado + ' | ' + 'Actualizado = ' + element.intActualizado + ' | ' + ' Inconsistentes = ' + element.intInconsistente + ' | ' + 'Total Procesados = ' + (element.intInsertado + element.intActualizado + element.intInconsistente));
                    $("#message").append('\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ');
                    IMPORTAR_TBOFICINA_04();

                })

                $("#txt_titulo_tabla").html("Datos Importados");
                $(".divEmpSave").hide();
                $(".divEmpUpdate").hide();

            }

            else {

                //Viernes
                $("#message").append('\n' + response.message);
                //$("#message").append('\nEL PROCESO HA TERMINADO SIN IMPORTARSE TODOS LOS EXCEL!!');
                //var mensaje_de_error = 'TB' + response.message.split("TB").pop();
                //$("#message").append('\nLa importación no será posible porque ' + mensaje_de_error);
                $("#excelMasivo").val('');
                $("#btn-import-masivo").attr("disabled", true);
                $("#excelMasivo").attr("disabled", false);
                $("#boton_limpar_manualmente").attr("disabled", false);
                $("#checkLimpiarCargar").attr("disabled", false);
                return;
            }
        },

        complete: function (response) {

            var totalTime = secondsToTime(new Date().getTime() - ajaxTime);
            $("#tiempo").html(totalTime)
            $('#message').css('color', 'blue');
            $("#procesados").html("")
            $("#procesados").html("3/8")
            $("#progresLoader").html("36%");
            $("#progresLoader").width("36%");
            $("#progresLoader").addClass('active');

        }

    });

}

function IMPORTAR_TBOFICINA_04() {

    let cboPlantilla = 1;
    let cboFormato = 1129;
    checkActualizar = $("#checkLimpiarCargar").is(':checked');
    pathDelDirectorio_ = excelsEnDirImportacionExcel[3];
    var pathDelDirectorio_1 = pathDelDirectorio_;
    let nomExcel_ = "TBOFICINA.xlxs";  //pathDelDirectorio_1.slice(103, 120);

    $.ajax({
        url: '/Personal/ImportMasivoExcel',
        type: 'POST',
        data: { cboPlantilla, cboFormato, checkActualizar, pathDelDirectorio_ },
        beforeSend: function () {

            var totalTime = secondsToTime(new Date().getTime() - ajaxTime);
            $("#tiempo").html(totalTime)
            $('#message').css('color', 'blue');
            $("#progresLoader").html("38%");
            $("#progresLoader").width("38%");
            $("#progresLoader").addClass('active');
            $('#message').css('color', 'green');
            $("#message").append('\nLa Importación de ' + nomExcel_ + ' se está procesando . . .');
        },

        success: function (response) {

            if (response.type == "success") {

                console.log(response)
                let lista = response.objeto
                $("#excelMasivo").val('');

                lista.forEach(element => {

                    sumaRegistrosInsertados = sumaRegistrosInsertados + (element.intInsertado);
                    sumaRegistrosActualizados = sumaRegistrosActualizados + (element.intActualizado);
                    sumaRegistrosInconsistentes = sumaRegistrosInconsistentes + (element.intInconsistente);
                    sumaRegistrosLeidos = sumaRegistrosLeidos + (element.intInsertado + element.intActualizado + element.intInconsistente);
                    $('#message').css('color', 'blue');
                    $("#message").append('\nNombre: ' + element.strNombreTabla + ' | ' + 'Insertado = ' + element.intInsertado + ' | ' + 'Actualizado = ' + element.intActualizado + ' | ' + ' Inconsistentes = ' + element.intInconsistente + ' | ' + 'Total Procesados = ' + (element.intInsertado + element.intActualizado + element.intInconsistente));
                    $("#message").append('\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ');
                    IMPORTAR_TBEMPLEADO_05();

                })

                $("#txt_titulo_tabla").html("Datos Importados");
                $(".divEmpSave").hide();
                $(".divEmpUpdate").hide();

            }

            else {
                $("#message").append('\n' + response.message);
                //$("#message").append('\nEL PROCESO HA TERMINADO SIN IMPORTARSE TODOS LOS EXCEL!!');
                //var mensaje_de_error = 'TB' + response.message.split("TB").pop();
                //$("#message").append('\nLa importación no será posible porque ' + mensaje_de_error);
                $("#excelMasivo").val('');
                $("#btn-import-masivo").attr("disabled", true);
                $("#excelMasivo").attr("disabled", false);
                $("#boton_limpar_manualmente").attr("disabled", false);
                $("#checkLimpiarCargar").attr("disabled", false);
                return;
            }
        },

        complete: function (response) {

            var totalTime = secondsToTime(new Date().getTime() - ajaxTime);
            $("#tiempo").html(totalTime)
            $('#message').css('color', 'blue');
            $("#procesados").html("")
            $("#procesados").html("4/8")
            $("#progresLoader").html("48%");
            $("#progresLoader").width("48%");
            $("#progresLoader").addClass('active');

        }

    });

}

function IMPORTAR_TBEMPLEADO_05() {

    let cboPlantilla = 1;
    let cboFormato = 1129;
    checkActualizar = $("#checkLimpiarCargar").is(':checked');
    pathDelDirectorio_ = excelsEnDirImportacionExcel[4];
    var pathDelDirectorio_1 = pathDelDirectorio_;
    let nomExcel_ = "TBEMPLEADO.xlxs"; //pathDelDirectorio_1.slice(103, 120);

    $.ajax({
        url: '/Personal/ImportMasivoExcel',
        type: 'POST',
        data: { cboPlantilla, cboFormato, checkActualizar, pathDelDirectorio_ },
        beforeSend: function () {

            var totalTime = secondsToTime(new Date().getTime() - ajaxTime);
            $("#tiempo").html(totalTime)
            $('#message').css('color', 'blue');
            $("#progresLoader").html("52%");
            $("#progresLoader").width("52%");
            $("#progresLoader").addClass('active');
            $('#message').css('color', 'green');
            $("#message").append('\nLa Importación de ' + nomExcel_ + ' se está procesando . . .');
        },

        success: function (response) {

            if (response.type == "success") {

                console.log(response)
                let lista = response.objeto
                $("#excelMasivo").val('');

                lista.forEach(element => {

                    sumaRegistrosInsertados = sumaRegistrosInsertados + (element.intInsertado);
                    sumaRegistrosActualizados = sumaRegistrosActualizados + (element.intActualizado);
                    sumaRegistrosInconsistentes = sumaRegistrosInconsistentes + (element.intInconsistente);
                    sumaRegistrosLeidos = sumaRegistrosLeidos + (element.intInsertado + element.intActualizado + element.intInconsistente);
                    $('#message').css('color', 'blue');
                    $("#message").append('\nNombre: ' + element.strNombreTabla + ' | ' + 'Insertado = ' + element.intInsertado + ' | ' + 'Actualizado = ' + element.intActualizado + ' | ' + ' Inconsistentes = ' + element.intInconsistente + ' | ' + 'Total Procesados = ' + (element.intInsertado + element.intActualizado + element.intInconsistente));
                    $("#message").append('\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ');
                    IMPORTAR_TBESTADO_06();

                })

                $("#txt_titulo_tabla").html("Datos Importados");
                $(".divEmpSave").hide();
                $(".divEmpUpdate").hide();

            }

            else {

                $("#message").append('\n' + response.message);
                //$("#message").append('\nEL PROCESO HA TERMINADO SIN IMPORTARSE TODOS LOS EXCEL!!');
                //var mensaje_de_error = 'TB' + response.message.split("TB").pop();
                //$("#message").append('\nLa importación no será posible porque ' + mensaje_de_error);
                $("#excelMasivo").val('');
                $("#btn-import-masivo").attr("disabled", true);
                $("#excelMasivo").attr("disabled", false);
                $("#boton_limpar_manualmente").attr("disabled", false);
                $("#checkLimpiarCargar").attr("disabled", false);
                return;
            }
        },

        complete: function (response) {

            var totalTime = secondsToTime(new Date().getTime() - ajaxTime);
            $("#tiempo").html(totalTime)
            $('#message').css('color', 'blue');
            $("#procesados").html("")
            $("#procesados").html("5/8")
            $("#progresLoader").html("62%");
            $("#progresLoader").width("62%");
            $("#progresLoader").addClass('active');
            
        }

    });

}

function IMPORTAR_TBESTADO_06() {

    let cboPlantilla = 1;
    let cboFormato = 1129;
    checkActualizar = $("#checkLimpiarCargar").is(':checked');
    pathDelDirectorio_ = excelsEnDirImportacionExcel[5];
    var pathDelDirectorio_1 = pathDelDirectorio_;
    let nomExcel_ = "TBESTADO.xlxs"; //pathDelDirectorio_1.slice(103, 120);

    $.ajax({
        url: '/Personal/ImportMasivoExcel',
        type: 'POST',
        data: { cboPlantilla, cboFormato, checkActualizar, pathDelDirectorio_ },
        beforeSend: function () {

            var totalTime = secondsToTime(new Date().getTime() - ajaxTime);
            $("#tiempo").html(totalTime)
            $('#message').css('color', 'blue');
            $("#progresLoader").html("64%");
            $("#progresLoader").width("64%");
            $("#progresLoader").addClass('active');
            $('#message').css('color', 'green');
            $("#message").append('\nLa Importación de ' + nomExcel_ + ' se está procesando . . .');
        },

        success: function (response) {

            if (response.type == "success") {

                console.log(response)
                let lista = response.objeto
                $("#excelMasivo").val('');

                lista.forEach(element => {

                    sumaRegistrosInsertados = sumaRegistrosInsertados + (element.intInsertado);
                    sumaRegistrosActualizados = sumaRegistrosActualizados + (element.intActualizado);
                    sumaRegistrosInconsistentes = sumaRegistrosInconsistentes + (element.intInconsistente);
                    sumaRegistrosLeidos = sumaRegistrosLeidos + (element.intInsertado + element.intActualizado + element.intInconsistente);
                    $('#message').css('color', 'blue');
                    $("#message").append('\nNombre: ' + element.strNombreTabla + ' | ' + 'Insertado = ' + element.intInsertado + ' | ' + 'Actualizado = ' + element.intActualizado + ' | ' + ' Inconsistentes = ' + element.intInconsistente + ' | ' + 'Total Procesados = ' + (element.intInsertado + element.intActualizado + element.intInconsistente));
                    $("#message").append('\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ');
                    IMPORTAR_TBTIPO_07();

                })

                $("#txt_titulo_tabla").html("Datos Importados");
                $(".divEmpSave").hide();
                $(".divEmpUpdate").hide();

            }

            else {

                $("#message").append('\n' + response.message);
                //$("#message").append('\nEL PROCESO HA TERMINADO SIN IMPORTARSE TODOS LOS EXCEL!!');
                //var mensaje_de_error = 'TB' + response.message.split("TB").pop();
                //$("#message").append('\nLa importación no será posible porque ' + mensaje_de_error);
                $("#excelMasivo").val('');
                $("#btn-import-masivo").attr("disabled", true);
                $("#excelMasivo").attr("disabled", false);
                $("#boton_limpar_manualmente").attr("disabled", false);
                $("#checkLimpiarCargar").attr("disabled", false);
                return;
            }
        },

        complete: function (response) {

            var totalTime = secondsToTime(new Date().getTime() - ajaxTime);
            $("#tiempo").html(totalTime)
            $('#message').css('color', 'blue');
            $("#procesados").html("")
            $("#procesados").html("6/8")
            $("#progresLoader").html("74%");
            $("#progresLoader").width("74%");
            $("#progresLoader").addClass('active');

        }

    });

}

function IMPORTAR_TBTIPO_07() {

    let cboPlantilla = 1;
    let cboFormato = 1129;
    checkActualizar = $("#checkLimpiarCargar").is(':checked');
    pathDelDirectorio_ = excelsEnDirImportacionExcel[6];
    var pathDelDirectorio_1 = pathDelDirectorio_;
    let nomExcel_ = "TBTIPO.xlxs"; //pathDelDirectorio_1.slice(103, 120);

    $.ajax({
        url: '/Personal/ImportMasivoExcel',
        type: 'POST',
        data: { cboPlantilla, cboFormato, checkActualizar, pathDelDirectorio_ },
        beforeSend: function () {

            var totalTime = secondsToTime(new Date().getTime() - ajaxTime);
            $("#tiempo").html(totalTime)
            $('#message').css('color', 'blue');
            $("#progresLoader").html("77%");
            $("#progresLoader").width("77%");
            $("#progresLoader").addClass('active');
            $('#message').css('color', 'green');
            $("#message").append('\nLa Importación de ' + nomExcel_ + ' se está procesando . . .');
        },

        success: function (response) {

            if (response.type == "success") {

                console.log(response)
                let lista = response.objeto
                $("#excelMasivo").val('');
                lista.forEach(element => {

                    sumaRegistrosInsertados = sumaRegistrosInsertados + (element.intInsertado);
                    sumaRegistrosActualizados = sumaRegistrosActualizados + (element.intActualizado);
                    sumaRegistrosInconsistentes = sumaRegistrosInconsistentes + (element.intInconsistente);
                    sumaRegistrosLeidos = sumaRegistrosLeidos + (element.intInsertado + element.intActualizado + element.intInconsistente);
                    //mensajeRegistrosInconsistente = element.strInconsistente;
                    $('#message').css('color', 'blue');
                    //$("#message").append('\nNombre: ' + element.strNombreTabla + ' | ' + 'Insertado: ' + element.intInsertado + ' | ' + 'Actualizado: ' + element.intActualizado + ' | ' + 'Total Procesados: ' + (element.intInsertado + element.intActualizado));
                    //$('#message1').empty('');
                    $("#message").append('\nNombre: ' + element.strNombreTabla + ' | ' + 'Insertado = ' + element.intInsertado + ' | ' + 'Actualizado = ' + element.intActualizado + ' | ' + ' Inconsistentes = ' + element.intInconsistente + ' | ' + 'Total Procesados = ' + (element.intInsertado + element.intActualizado + element.intInconsistente));
                    //$("#message1").append('Nombre: ' + element.strNombreTabla + ' | ' + 'Insertado: ' + element.intInsertado + ' | ' + 'Actualizado: ' + element.intActualizado + ' | ' + 'Total Procesados: ' + (element.intInsertado + element.intActualizado));
                    //var texto = $('#message1').val();
                    //var txt = $("#message");
                    //var text = txt.val().trim("\n");
                    //var valuelist = text.split("\n");
                    //var string_to_replace = texto;
                    //valuelist[valuelist.length - 1] = string_to_replace;
                    //txt.val(valuelist.join("\n"));
                    //$("#message").append('\n------------------------------------------------------------------------------------------------------------');
                    $("#message").append('\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ');
                    IMPORTAR_TBBIENES_08();

                })

                $("#txt_titulo_tabla").html("Datos Importados");
                $(".divEmpSave").hide();
                $(".divEmpUpdate").hide();

            }

            else {

                $("#message").append('\n' + response.message);
                //$("#message").append('\nEL PROCESO HA TERMINADO SIN IMPORTARSE TODOS LOS EXCEL!!');
                //var mensaje_de_error = 'TB' + response.message.split("TB").pop();
                //$("#message").append('\nLa importación no será posible porque ' + mensaje_de_error);
                $("#excelMasivo").val('');
                $("#btn-import-masivo").attr("disabled", true);
                $("#excelMasivo").attr("disabled", false);
                $("#boton_limpar_manualmente").attr("disabled", false);
                $("#checkLimpiarCargar").attr("disabled", false);
                return;
            }
        },

        complete: function (response) {

            var totalTime = secondsToTime(new Date().getTime() - ajaxTime);
            $("#tiempo").html(totalTime)
            $('#message').css('color', 'blue');
            $("#procesados").html("")
            $("#procesados").html("7/8")
            $("#progresLoader").html("87%");
            $("#progresLoader").width("87%");
            $("#progresLoader").addClass('active');

        }

    });

}

function IMPORTAR_TBBIENES_08() {

    let cboPlantilla = 1;
    let cboFormato = 1129;
    checkActualizar = $("#checkLimpiarCargar").is(':checked');
    pathDelDirectorio_ = excelsEnDirImportacionExcel[7];
    var pathDelDirectorio_1 = pathDelDirectorio_;
    let nomExcel_ = "TBBIENES.xlxs"; //pathDelDirectorio_1.slice(103, 120);

    $.ajax({
        url: '/Personal/ImportMasivoExcel',
        type: 'POST',
        data: { cboPlantilla, cboFormato, checkActualizar, pathDelDirectorio_ },
        beforeSend: function () {

            var totalTime = secondsToTime(new Date().getTime() - ajaxTime);
            $("#tiempo").html(totalTime)
            $('#message').css('color', 'blue');
            $("#progresLoader").html("90%");
            $("#progresLoader").width("90%");
            $("#progresLoader").addClass('active');
            $('#message').css('color', 'green');
            $("#message").append('\nLa Importación de ' + nomExcel_ + ' se está procesando . . .');
        },

        success: function (response) {

            if (response.type == "success") {

                console.log(response)
                let lista = response.objeto
                $("#excelMasivo").val('');
                
                lista.forEach(element => {

                    sumaRegistrosInsertados = sumaRegistrosInsertados + (element.intInsertado);
                    sumaRegistrosActualizados = sumaRegistrosActualizados + (element.intActualizado);
                    sumaRegistrosInconsistentes = sumaRegistrosInconsistentes + (element.intInconsistente);
                    sumaRegistrosLeidos = sumaRegistrosLeidos + (element.intInsertado + element.intActualizado + element.intInconsistente);
                    mensajeRegistrosInconsistente = element.strInconsistente;
                    //console(element.arrListInconsistentes);
                    $('#message').css('color', 'blue');
                    $("#message").append('\nNombre: ' + element.strNombreTabla + ' | ' + 'Insertado = ' + element.intInsertado + ' | ' + 'Actualizado = ' + element.intActualizado + ' | ' + ' Inconsistentes = ' + element.intInconsistente + ' | ' + 'Total Procesados = ' + (element.intInsertado + element.intActualizado + element.intInconsistente));
                    $("#message").append('\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ');
                    //$("#message").append('\n************************************************************************');
                    //$("#message").append('\nRESUMEN ' + ' ---> ' + 'TOTAL INSERTADOS: ' + sumaRegistrosInsertados + ' | ' + 'TOTAL ACTUALIZADOS: ' + sumaRegistrosActualizados + ' | ' + 'TOTAL LEÍDOS: ' + sumaRegistrosLeidos);

                    //////////////////////////////////////////////////////////////
                       //$("#message").append('\n' + element.strInconsistente);
                    //////////////////////////////////////////////////////////////

                    //eliminarExcelDeDirectorio();

                })


                 listaInconsist = response.objetoLista


                $("#txt_titulo_tabla").html("Datos Importados");
                $(".divEmpSave").hide();
                $(".divEmpUpdate").hide();
            
            }

            else {

                $("#message").append('\n' + response.message);
                //$("#message").append('\nEL PROCESO HA TERMINADO SIN IMPORTARSE TODOS LOS EXCEL!!');
                //var mensaje_de_error = 'TB' + response.message.split("TB").pop();
                //$("#message").append('\nLa importación no será posible porque ' + mensaje_de_error);
                $("#excelMasivo").val('');
                $("#btn-import-masivo").attr("disabled", true);
                $("#excelMasivo").attr("disabled", false);
                $("#boton_limpar_manualmente").attr("disabled", false);
                $("#checkLimpiarCargar").attr("disabled", false);
                return;
            }
        },

        complete: function (response) {

            var totalTime = secondsToTime(new Date().getTime() - ajaxTime);
            $("#tiempo").html(totalTime)
            $('#message').css('color', 'blue');
            $("#procesados").html(""); 
            $("#procesados").html("8/8");

            //$("#message").append('\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  - - - --------------------------------------------------------------------');
            $("#message").append('\n*************************************************************************************');
            $("#message").append('\n************************** DETALLE DE REGISTROS PROCESADOS ***************************'); //RESUMEN TOTALIZADO
            $("#message").append('\n*************************************************************************************');
            $("#message").append('\n. TOTAL INSERTADOS      :   ' + sumaRegistrosInsertados);
            $("#message").append('\n. TOTAL ACTUALIZADOS :   ' + sumaRegistrosActualizados);
            $("#message").append('\n. TOTAL OBSERVADOS    :   ' + sumaRegistrosInconsistentes );
            $("#message").append('\n. TOTAL LEÍDOS                :   ' + sumaRegistrosLeidos);
            $("#message").append('\n*************************************************************************************');
            $("#message").append('\n');
            $("#message").append('\n*************** LA IMPORTACIÓN DE LOS DOCUMENTOS EXCEL HA FINALIZADO!!****************');
            $("#message").append('\n');


            $("#progresLoader").removeClass("progress-bar-animated") 
            $("#progresLoader").html("100%");
            $("#progresLoader").width("100%");
            $("#progresLoader").addClass('active');
            $("#excelMasivo").attr("disabled", false);
            $("#boton_limpar_manualmente").attr("disabled", false);
            $("#checkLimpiarCargar").attr("disabled", false);


            new PNotify({
                title: 'Importación Masiva Excel',
                text: 'La Importación de los documentos Excel ha finalizado!!',
                type: 'info',
                delay: 3000,
                styling: 'bootstrap3',
            });


            $("#progresLoader").removeClass('active');


/****************************************************************************************
            $("#message").append('\n*************************************************************************************');
            $("#message").append('\n**************************** DETALLE DE REGISTROS OBSERVADS **************************');
            $("#message").append('\n*************************************************************************************');

            
                //FOR DENTRO DEL TEXTAREA POR CADA OBSERVADO
                var i=0;
                for (i = 0; i < listaInconsist.length; i++) {
                    var text = listaInconsist[i];// + "<br>";
                    $("#message").append('\n' + text);
                }

            
                listaInconsist = [];
                $("#message").append('\n');
                $('#checkLimpiarCargar').prop('checked', false);

  */

            //ALIMINAR TODO DEL DIRECTORIO
            eliminarExcelDeDirectorio();

        }

    });

}


//===============================================================================================
//======== BOTON QUE: VALIDA-->IMPORTA y GUARDA LOS EXCELS FROM 'DIRIMPORTACIONEXCEL' TO BD
//===============================================================================================
$("#btn-import-masivo").click(function () {
    validarSession(); 

   // let continuarParar = true ;
   // if ($('#checkLimpiarCargar').is(':checked') == true) {
   // swal({
   //     title: "Importar Excel",
   //     //text: "Al limpiar las tablas seleccionadas, \nlos datos que éstas contienen se eliminarán.",
   //     text: "Antes de importar los datos\n de todas las tablas se eliminarán.",
   //     //text: "Al Confirmar la operación se eliminaran los datos en la base de datos de :"+
   //     //       "\n"+tablaEliminar,
   //     type: "info",
   //     showCancelButton: true,
   //     confirmButtonText: "Sí, Continuar",
   //     cancelButtonText: "No, cancelar",
   // }).then(function (isConfirm) {

   //     //////////////////////////////////////////////////////////////////
   //     //SI SE CONFIRMA ELIMINACION ENTONCES SE EJECUTARA LO SIGUIENTE :
   //     //////////////////////////////////////////////////////////////////

   //     continuarParar = true;
   //     alert('continua');      

   //     //////////////////////////////////////////////////////////////////
   //     //FIN DE EJECUCION
   //     //////////////////////////////////////////////////////////////////

   // }, function (dismiss) {
   //     if (dismiss == 'cancel') {
   //         swal("Cancelado", "La Operación fue cancelada", "error");
   //         continuarParar = false;
   //         alert(continuarParar);
   //         if (!continuarParar) { return; }
   //     }
   //     });
   //}
   // alert('paso alerta');

    let cboPlantilla = 1;//NO USADO EN SISFD COMENTAR LUEGO
    let cboFormato = 1129;//NO USADO EN SISFD COMENTAR LUEGO  
    checkActualizar = $("#checkLimpiarCargar").is(':checked');//NO USADO EN SISFD COMENTAR LUEGO
    var cantExcelSubidos = excelsEnDirImportacionExcel.length;
    numeroexcelvacios = []; //limpiar contador


    ////////////////////////////////////////ELIMINAR
    //$.post(
    //    '/Personal/GetUserIPAddress',
    //    {
    //        //sinparametros
    //    },
    //    response => {

    //        srtDirIpConCsharp = response;
    //        //alert(srtDirIpConCsharp);      

    //    }); 


    //////////BLOQUE DE VAIDACIONES 
    //var srt = excelsEnDirImportacionExcel[0];
    ////alert(srt.indexOf('TB'));
    //alert(srt.substr(100, 103));    
    //alert(cantExcelSubidos);

    //NO EXISTE EXCELS CARGADOS
    if (cantExcelSubidos < 1) {
        new PNotify({
            title: 'Importación Masiva Excel',
            text: 'No existe ningún archivo excel para realizar la transacción.',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'

        });
        nonbresdelosexcel = [];
        eliminarExcelDeDirectorio();
        excelsEnDirImportacionExcel = [];
        return;
    }  


    // NO ESTAN CARGADOS LOS 8 EXCELS
    if ( cantExcelSubidos < 8 ) {
        new PNotify({
            title: 'Importación Masiva Excel',
            text: 'Vuelva a cargar los 8 archivos completos para realizar la Importación.',
            //text: 'Le faltan' + ' ' + (8 - cantExcelSubidos) + ' ' + 'archivos de los 8 necesarios para realizar la transacción.' ,
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        nonbresdelosexcel = [];
        eliminarExcelDeDirectorio();
        excelsEnDirImportacionExcel = [];
        return;
    }  
    
    //$("#message").append('Preparando Documentos para la Importación...');
    //FOR PARA VALIDACION DE ESCEL VACIOS
    let excelsValidados = 0;
    let excelsValidados_ = "";
    let excelsVacios = 0;

    for (var i = 0; i < excelsEnDirImportacionExcel.length; i++) {
       
        pathDelDirectorio_ = (excelsEnDirImportacionExcel[i]).toString();
        var pathDelDirectorio_1 = pathDelDirectorio_;
        let nomExcel_ = pathDelDirectorio_1.slice(103, 120); //Sacamos del Path solamente el nombre del excel

        if (i < 1) { $("#message").append('Preparando Documentos para la Importación...') }
        

        //AJAX PARA CADA EXCEL CON UN SOLO BOTON - ESTE EL EL PUNTO INICIAL EN DONDE COMIENZA CON LA VALIDACION
        $.ajax({
            url: '/Personal/ValidarFilasDeLosExcel',
            type: 'POST',
            data: { cboPlantilla, cboFormato, checkActualizar, pathDelDirectorio_ },
            beforeSend: function () {

                var ajaxTimeComienzaConteo = new Date().getTime();
                ajaxTime = ajaxTimeComienzaConteo;
                //$("#message").append('\nPreparando Documentos para la Importación...');
                //$("#message").append('\nSe inició el proceso de importación de ' + nomExcel_);

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
                 //     message: 'Cargando Documentos...'
                 // });


            },
            success: function (response) {

                if (response.type == "success") {

                    console.log(response)
                    let lista = response.objeto
                    $("#excelMasivo").val('');
                    $("#message").html('');

                    lista.forEach(element => {                        

                        $("#message").append('\nExcel Procesado :' + element.strNombreTabla);
                    })

                    $("#message").append('\n-----------------------------------------------------------');
                    $("#txt_titulo_tabla").html("Datos Importados");
                    $(".divEmpSave").hide();
                    $(".divEmpUpdate").hide();
                    //Insertar en el TEXTAREA  el detalle de la tabla que se está importando
                    //INDICAR QUE ACABAN DE IMPORTAR EL ARCHIVO
                    //bitNuevoExcel = true;//false;

                }


                else {

                    var mensaje_de_error = "";

                    if (response.message != null) {

                        mensaje_de_error = 'TB' + response.message.split("TB").pop();

                        $('#message').css('color', 'blue'); 
                        //$("#message").append('\nLa importación no será posible porque ' + mensaje_de_error);
                        $("#message").append('\n' + response.message);
                        excelsVacios = ++excelsVacios;
                        //alert('vacios ' + excelsVacios)
                        numeroexcelvacios.push({ numex: excelsVacios }); 
                    }

                    $("#excelMasivo").val('');
                    $("#btn-import-masivo").attr("disabled", true); 
                    $("#excelMasivo").attr("disabled", true);
                    $("#boton_limpar_manualmente").attr("disabled", true);
                    $("#checkLimpiarCargar").attr("disabled", true);

                    excelsValidados = ++excelsValidados;
                    excelsValidados_ = excelsValidados.toString();
                    //alert(excelsValidados);//Numero de veces
                    //numeroexcelverificados.push({ numex: excelsValidados }); 
                    //SI NO EXISTEN EXCEL VACIOS CONTINUA EL PROCESO Y SE INSERTAN LOS EXCELS ======================= SI SE INSERTA
                    if (numeroexcelvacios.length < 1 && excelsValidados > 7) {

                        //alert('Se verificó que todos los Excels contienen datos, entonces puede continuar con la Importación');//============================================================


                        //////////////////////////////////////////////////////////////
                                          IMPORTAR_TBENTIDAD_01(); //01
                        //////////////////////////////////////////////////////////////



                    }


                    else if (numeroexcelvacios.length > 0 && excelsValidados > 7) { //=============================== REVISE LOS EXCEL VACIOS

                        new PNotify({
                            title: 'Importación Masiva Excel',
                            //text: 'Verifique el/los documento(s) y vuelva a cargarlo(s).',
                            text: 'Volver a cargar los Excel y/o verifique que tengan datos.',
                            type: 'info',
                            delay: 4000,
                            styling: 'bootstrap3',
                            addclass: 'dark'
                        });

                        $("#message").append('\n---------------------------------------------------------------');
                        $("#message").append('\nPor favor vuelva a cargar los documentos Excel');
                        eliminarExcelDeDirectorio();
                        excelsEnDirImportacionExcel = [];
                        $("#excelMasivo").attr("disabled", false);
                        $("#boton_limpar_manualmente").attr("disabled", false);
                        $("#checkLimpiarCargar").attr("disabled", false);

                    }      


                }
            },

            complete: function (response) {


            }

        });

    }


})

$("#excelMasivo").attr('disabled', false); //Boton choose file
$("#boton_limpar_manualmente").attr("disabled", false);
$("#checkLimpiarCargar").attr("disabled", true);
$(".divPlantillas").hide(); //Opcion Descargar : Plantilla y Anexos





