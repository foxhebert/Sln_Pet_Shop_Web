//Variables Globales
var ajaxTime;
let intRespuesta;
let listaExcel;
var strExcelExportado = "";
let ContarListaEnExcels;
let NumElemetosEnTabla;
var totalTime;
let CountListaBienes;
let CountListaBienesDs;
let CountListaOficina;
let NumExcelExportados = 0;
let CountListaEmpleado;

//PARA LOS 8 EXCEL DESDE EL BOTON "Generar Excel Con DataSQl"
var strNombreExcel_ = "";
let cantDeRegistrosTBBIENES;
let cantDeRegistrosTBOFICINA;  
let cantDeRegistrosTBEMPLEADO; 
let cantDeRegistrosTBLOCAL;   
let cantDeRegistrosTBAREAS;    
let cantDeRegistrosTBESTADO;   
let cantDeRegistrosTBTIPO;     
let cantDeRegistrosTBENTIDAD;  
let NumExcelContador = 0;
////////////////////////////////////////////////////
let strCamposOpcionales;




//////////////////////////////////////////////////////////////////////////////////
//SELECCIONAR SUBMENU POR SUBMENU UN POR UNO
let camposOpcionales = [];
let combinacionLabels = [];
//////////////////////////////////////////////////////////////////////////////////
$('.flatHijo').on('click', function () {

    //https://stackoverflow.com/questions/54322396/cant-find-the-closest-label-with-jquery
    //$label = $('label[for="' + this.id.replace("-value", "") + '"]');
    var labelText = $('label[for="' + this.id + '"]').text();
    //alert(labelText);
    //camposOpcionales = [];
    ////camposOpcionales.push(labelText);//(x.strEmail); //detalleSubs[i];
    //https://stackoverflow.com/questions/61997123/how-to-delete-a-value-from-array-if-exist-or-push-it-to-array-if-not-exists
    if (!camposOpcionales.includes(labelText)) {          //checking weather array contain the id
        camposOpcionales.push(labelText);               //adding to array because value doesnt exists
    } else {
        camposOpcionales.splice(camposOpcionales.indexOf(labelText), 1);  //deleting
    }


    //////////COGER COMBINACION
    ////////var numero = (this.id);

    ////////var intIdMenu = numero.slice(13);
    //////////alert(intIdMenu);

    ////////if (!combinacionLabels.includes(numerosCombinacion)) {          //checking weather array contain the id
    ////////    combinacionLabels.push(labelText);               //adding to array because value doesnt exists
    ////////} else {
    ////////    combinacionLabels.splice(combinacionLabels.indexOf(numero), 1);  //deleting
    ////////}


    ////var item = "tom";
    ////var array = []
    ////if (!array.find(item))
    ////    array.push(item)

    //AL ACCIONAR EL GENERAR LOS EXCEL SE DISPARA LA CAPTURA DE LO QUE CONTIENE EL "camposOpcionales""
    //////let camposOpcionales_ = [];
    ////////for (x in detalleSubs)
    //////camposOpcionales_.push(labelText);//(x.strEmail); //detalleSubs[i];
    //////var strCamposOpcionales = camposOpcionales_.join(",");
    //////alert(strCamposOpcionales);



    //Coge a todos los hijos o submenus
    //alert('this.id de la clase .flatHijo ---> ' + this.id);
    var intIdMenu_s = (this.id).split('_');
    //alert(intIdMenu_s);
    var cantSubMenusVisTot = $('.p-2 .mt-4').find("input[class='flatHijo']:visible");
    //alert('cantSubMenusVisTot --->' + cantSubMenusVisTot.length);
    var cantSubMenusVisChecked = $('.p-2 .mt-4').find("input[class='flatHijo']:visible:checked");
    //alert('cantSubMenusChecked --->' + cantSubMenusVisChecked.length);

    if (cantSubMenusVisTot.length == cantSubMenusVisChecked.length) {
        //alert($('.p-2 .mb-3').find('input:visible').attr('id'));
        $($('.p-2 .mb-3').find('input:visible')).prop('checked', true).attr('checked', 'checked');
        $($('.p-2 .mb-3').find('input:visible')).attr('validationpass_u', 'todoscheck');
    }
    else {
        //alert($('.p-2 .mb-3').find('input:visible').attr('id'));
        $($('.p-2 .mb-3').find('input:visible')).prop('checked', false).removeAttr('checked');
        $($('.p-2 .mb-3').find('input:visible')).attr('validationpass_u', 'todosuncheck');
    }

});
//////////////////////////////////////////////////////////////////////////////////

//$('select option:selected').data('label');
//var cantSubMenusVisTot = $('.p-2 .mt-4').find("input[class='flatHijo']:visible");


//////////////////////////////////////////////////////////////////////////////////
//CHECKEAR Y DESCHECKEAR CON OPCION EL "Seleccionar Todos" 
//////////////////////////////////////////////////////////////////////////////////
$('.flatPadre').on('click', function () {



    //if (!camposOpcionales.includes(labelText)) {          //checking weather array contain the id
    //    camposOpcionales.push(labelText);               //adding to array because value doesnt exists
    //} else {
    //    camposOpcionales.splice(camposOpcionales.indexOf(labelText), 1);  //deleting
    //}

    //alert('this.id de la clase .flatPadre ---> ' + this.id);
    var intIdMenu_s = (this.id).split('_');
    var validationpass_u = $('#' + this.id + '').attr("validationpass_u");
    //alert('validationpass_u --->' + validationpass_u);
    //alert(intIdMenu_s);
    var inputTodos = $(".p-2 .mt-4 .icheck-material-blue ").find("input[id^='" + intIdMenu_s[1] + "_submenuid']");
    //alert(intIdMenu_s[1]);

    if (validationpass_u == 'todosuncheck') {

        $(this).attr('validationpass_u', 'todoscheck')

        for (var i = 0; i < inputTodos.length; i++) {

            var intIdMenu_ = $(inputTodos[i]).attr('id');

            //EL ID DEL SUBMENU DEL FOR
            //alert('submenu ' + $('#' + intIdMenu_ + '').is(':checked'));



            if ($('#' + intIdMenu_ + '').is(':checked') == false) {

                $('#' + intIdMenu_ + '').prop("checked", "checked");

                //alert('añadir ' + labelText);
                //camposOpcionales.push(labelText); //añadiendo
            }
            else {
                //alert('si esta checeado dejarlo asi');
                //alert('eliminar ' + labelText);
                //camposOpcionales.splice(camposOpcionales.indexOf(labelText), 1);  //deleting
            }


            //GET THE TEXT OF EACH LABEL CAMPOS OPCIONALES
            var labelText = $('label[for="' + intIdMenu_ + '"]').text();
            if (!camposOpcionales.includes(labelText)) {          //checking weather array contain the id
                camposOpcionales.push(labelText);               //adding to array because value doesnt exists
            }


        }

    }

    else {

        $(this).attr('validationpass_u', 'todosuncheck')
        for (var i = 0; i < inputTodos.length; i++) {
            var intIdMenu_ = $(inputTodos[i]).attr('id');
            //EL ID DEL SUBMENU DEL FOR
            //alert('submenu ' + $('#' + intIdMenu_ + '').is(':checked'));
            $('#' + intIdMenu_ + '').prop('checked', false).removeAttr('checked');
        }

        //ELIMINAR TODOS LOS LABELS DE "CAMPOS OPCIONALES"
        camposOpcionales = [];
    

    }

});
//////////////////////////////////////////////////////////////////////////////////




/////////////////////////////////////////////////////////////////////////////////////////////
//ENVIAR POR CORREO LOS 04 EXCELS, ó 04 TXTs ó AMBOS TIPOS DE DOCUMENTOS EXPORTADOS
/////////////////////////////////////////////////////////////////////////////////////////////
$('#paper-plane-button-enviar-a-correos').on('change', function () {

    idRadioCheck = $(".disabled_enviar:checked").attr('id');

    //if (typeof idRadioCheck == 'undefined') {

    //    new PNotify({
    //        title: 'Envio de Correos',
    //        text: 'Seleccione una opción de envío.',
    //        type: 'info',
    //        delay: 3000,
    //        styling: 'bootstrap3',
    //        addclass: 'dark'
    //    });

    //    return;
    //}

    if (idRadioCheck == 'chck_txt_coma') {
        //alert(idRadiocheck);
        Enviar_EXCELS_A_VARIOS_Correos();
    }
    if (idRadioCheck == 'chck_txt_codigo') {
        Enviar_EXCELS_A_VARIOS_Correos();
        //alert(idRadiocheck);
        //Enviar_TXT_A_VARIOS_Correos();
    }
    if (idRadioCheck == 'chck_csv_coma') {
        //alert(idRadiocheck);
        //Enviar_EXCELS_A_VARIOS_Correos();
        Enviar_TXT_A_VARIOS_Correos();
    }
    if (idRadioCheck == 'chck_csv_codigo') {
        Enviar_EXCELS_A_VARIOS_Correos();
        //alert(idRadiocheck);
        //Enviar_TXT_A_VARIOS_Correos();
    }

});



//////function GenerarListasDeTablas111() {
//////    alert('GenerarListasDeTablas()'); //GenerarListaExportar
//////}

////////////////////////////////////////////////////////////////////////////////////////////////
//TRAER LAS CUATRO TABLAS COMO LISTAS HASTA EL CONTROLADOR
////////////////////////////////////////////////////////////////////////////////////////////////
let idRadioCheck;    
var strArchivoExportado_;
var strCamposOpcionales_;
function GenerarListasDeTabla() {

    //:checked
    ////////////////////////////////////////////////CON CAMPOS OPCIONALES

    if (camposOpcionales.length > 0 && camposOpcionales.length < 4){
    //Agregar una coma delante del array 
        strCamposOpcionales_ = "," + camposOpcionales.join(",");
    }
    else if (camposOpcionales.length == 4) {//PARA REORDENAR LOS CAMPOS OPCIONALES Y NO SE TENGA QUE CONDICIONAR EL DESORDEN EN EL C#

        //alert(camposOpcionales.length);
        camposOpcionales = [];

        var inputTodos = $(".p-2 .mt-4 .icheck-material-blue ").find("input[id^='M02_submenuid']:checked");
        for (var i = 0; i < inputTodos.length; i++) {

            var intIdMenu_ = $(inputTodos[i]).attr('id');
            //GET THE TEXT OF EACH LABEL CAMPOS OPCIONALES
            var labelText = $('label[for="' + intIdMenu_ + '"]').text();
            camposOpcionales.push(labelText); //adding to array because value doesnt exists      

        }
        strCamposOpcionales_ = "," + camposOpcionales.join(",");
        //alert(strCamposOpcionales_);
    }
    else if (camposOpcionales.length == 5) {//PARA REORDENAR LOS CAMPOS OPCIONALES Y NO SE TENGA QUE CONDICIONAR EL DESORDEN EN EL C#

        //alert(camposOpcionales.length);
        camposOpcionales = [];

        var inputTodos = $(".p-2 .mt-4 .icheck-material-blue ").find("input[id^='M02_submenuid']");
        for (var i = 0; i < inputTodos.length; i++) {

            var intIdMenu_ = $(inputTodos[i]).attr('id');
            //GET THE TEXT OF EACH LABEL CAMPOS OPCIONALES
            var labelText = $('label[for="' + intIdMenu_ + '"]').text();    
            camposOpcionales.push(labelText); //adding to array because value doesnt exists      

        }
        strCamposOpcionales_ = "," + camposOpcionales.join(",");
        //alert(strCamposOpcionales_);
    }
    else {

        strCamposOpcionales_ = "";

    }
    //alert(strCamposOpcionales_);

    //strCamposOpcionales: strCamposOpcionales_
    ////////////////////////////////////////////////

    $("#btn-generar-archivos").attr("disabled", true); //btn-exportar-archivos_excel

    //Para decidir cual opcion de documento generar
    idRadioCheck = $(".disabled_enviar:checked").attr('id');

    $("#message").html('');
    $("#num-excels-generados").html("0/0");
    $("#procesados").html("--/--");
    $("#progresLoader").html("");
    $("#progresLoader").width("");

    var ajaxTimeComienzaConteo = new Date().getTime();
    ajaxTime = ajaxTimeComienzaConteo;
    totalTime = secondsToTime(new Date().getTime() - ajaxTime);
    $("#tiempo").html(totalTime);
    strArchivoExportado_ = "TMINVENTARIO";
    $.post(
        '/Personal/GenerarListaExportar', /*GenerarListasDeCadaTabla*/
        {
            strArchivoExportado: strArchivoExportado_
        },
        response => {
            CountListaTmProdu = response;
            //alert(response + 'registros');



            if (typeof idRadioCheck == 'undefined') {

                new PNotify({
                    title: 'Envio de Correos',
                    text: 'Seleccione una opción de Tipo de Archivo a generar.',
                    type: 'info',
                    delay: 2500,
                    styling: 'bootstrap3',
                    addclass: 'dark'
                });
                $("#btn-generar-archivos").attr("disabled", false);
                return;
            }

            ///////////////////////////////////////////////////////////////// 
            // DEPENDIENDO DEL CHECK RADIO SE CONTROLA CUAL ARCHIVO SE GENERA
            ///////////////////////////////////////////////////////////////// 
            if (idRadioCheck == 'chck_txt_coma') {
                //alert(idRadioCheck);
                //alert(strCamposOpcionales);
                GenerarWindowOpenArchivoTXTComa();
            }
            if (idRadioCheck == 'chck_txt_codigo') {                
                //alert(idRadioCheck);
                GenerarWindowOpenArchivoTXTCodigo();
            }
            if (idRadioCheck == 'chck_csv_coma') {
                //alert(idRadioCheck);
                GenerarWindowOpenArchivoCSVComa();
            }
            if (idRadioCheck == 'chck_csv_codigo') {
                //alert(idRadioCheck);
                GenerarWindowOpenArchivoCSVCodigo();
            }


            setTimeout(function () {
                $("#progresLoader").html("100%");
                $("#progresLoader").width("100%");
                $("#progresLoader").removeClass('active');

            }, 4000);

            totalTime = secondsToTime(new Date().getTime() - ajaxTime);
            $("#tiempo").html(totalTime);
            //////$("#progresLoader").removeClass("progress-bar-animated")
            $("#btn-generar-archivos").attr("disabled", false);

            //////////$("#message").append('Obteniendo datos para ' + strExcelExportado_ + ': ' + CountListaBienes.toString() + ' Registros.');
            ////////////if (CountListaBienes < 1) {
            ////////////    $("#message").append('\nNo se encontró datos para ' + strExcelExportado_ + '.');
            ////////////}
            //////////totalTime = secondsToTime(new Date().getTime() - ajaxTime);
            //////////$("#tiempo").html(totalTime);
            //////////$("#progresLoader").html("3%");
            //////////$("#progresLoader").width("3%");


            
            /***********************************************
            strExcelExportado_ = "TBBIENESDS";
            $.post(
                '/Reportes/GenerarListasDeCadaTabla',
                {
                    strExcelExportado: strExcelExportado_
                },
                response => {
                    CountListaBienesDs = response;
                    $("#message").append('\nObteniendo datos para ' + strExcelExportado_ + ': ' + CountListaBienesDs.toString() + ' Registros.');
                    //if (CountListaBienesDs < 1) {
                    //    $("#message").append('\nNo se encontró datos para ' + strExcelExportado_ + '.');
                    //}
                    totalTime = secondsToTime(new Date().getTime() - ajaxTime);
                    $("#tiempo").html(totalTime);
                    $("#progresLoader").html("12%");
                    $("#progresLoader").width("12%");
                    strExcelExportado_ = "TBOFICINA";
                    $.post(
                        '/Reportes/GenerarListasDeCadaTabla',
                        {
                            strExcelExportado: strExcelExportado_
                        },
                        response => {
                            CountListaOficina = response;
                            $("#message").append('\nObteniendo datos para ' + strExcelExportado_ + ': ' + CountListaOficina.toString() + ' Registros.');
                            //if (CountListaOficina < 1) {
                            //    $("#message").append('\nNo se encontró datos para ' + strExcelExportado_ + '.');
                            //}
                            totalTime = secondsToTime(new Date().getTime() - ajaxTime);
                            $("#tiempo").html(totalTime);
                            $("#progresLoader").html("24%");
                            $("#progresLoader").width("24%");
                            strExcelExportado_ = "TBEMPLEADO";
                            $.post(
                                '/Reportes/GenerarListasDeCadaTabla',
                                {
                                    strExcelExportado: strExcelExportado_
                                },
                                response => {

                                    CountListaEmpleado = response;
                                    $("#message").append('\nObteniendo datos para ' + strExcelExportado_ + ': ' + CountListaEmpleado.toString() + ' Registros.');
                                    //if (CountListaEmpleado < 1 ) {
                                    //    $("#message").append('\nNo se encontró datos para ' + strExcelExportado_ + '.');
                                    //}
                                    $("#message").append('\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ');
                                    $("#progresLoader").html("36%");
                                    $("#progresLoader").width("36%");
                                    ///////////////////////////////////////////
                                    GenerarWindowOpenExcel(); //alert('Listas de excel en el controlador');////////
                                    ///////////////////////////////////////////
                                    //FIN DE TODO EL PROCESO



                                    ////02
                                    //var chk_envio_de_coreo = "0";
                                    //if ($('#chk_envio_de_coreo').is(':checked') == true) {
                                    //    chk_envio_de_coreo = "1";
                                    //}


                                    setTimeout(function () {
                                        $("#progresLoader").html("100%");
                                        $("#progresLoader").width("100%");
                                        $("#progresLoader").removeClass('active');

                                    }, 4000);

                                    totalTime = secondsToTime(new Date().getTime() - ajaxTime);
                                    $("#tiempo").html(totalTime);
                                    //////$("#progresLoader").removeClass("progress-bar-animated")
                                    $("#btn-exportar-archivos_excel").attr("disabled", false);

                                    new PNotify({
                                        title: 'Importación Masiva Excel',
                                        text: 'La Exportación de los documentos Excel ha finalizado.',
                                        type: 'info',
                                        delay: 2000,
                                        styling: 'bootstrap3'
                                    });

                                    ////////////////////////////////////////////////////////////
                                    //SI EL CHECK ESTA HABILITADO SE ENVIA AL/LOS CORREO(s)
                                    if ($('#chk_envio_de_coreo').is(':checked') == true) {
                                        ////alert('EnviarExcelsExportadosPorCorreo');
                                        EnviarExcelsExportadosPorCorreo();
                                        //enviarExcelsPorCorreo();
                                    }
                                    ////////////////////////////////////////////////////////////


                                });

                        });

                });

            ***********************************************/

        });

}

////////////////////////////////////////////////////////////////////////////////////////////////
//Ejecutar los Window.Open para descargar los archivos excel en el Navegador con el Download
////////////////////////////////////////////////////////////////////////////////////////////////
function GenerarWindowOpenArchivoTXTComa() {

    //------------------------------------------------------------------------- idRadioCheck == 'chck_txt_coma'
    //if (NombreExcelGenerar[3] == "TBEMPLEADO") {

        if (CountListaTmProdu > 0) {
            strArchivoExportado_ = "TMINVENTARIO";
            $("#message").append('\nGenerando Archivo de Texto delimitado por (",") ' + strArchivoExportado_ + '.txt . . .');
            $("#message").append('\nTotal a exportar : ' + CountListaTmProdu.toString() + ' Registros.');

            window.open('/Personal/GenerarArchivosExportar?strArchivoExportado=' + strArchivoExportado_ + '&idRadioCheck=' + idRadioCheck + '&strCamposOpcionales=' + strCamposOpcionales_, '_blank');
            NumExcelExportados = ++NumExcelExportados;
            $("#num-excels-generados").html(NumExcelExportados + "/4");
            $("#progresLoader").html("90%");
            $("#progresLoader").width("90%");
            $("#progresLoader").addClass('active');
        }
    //}

    /**
        //-------------------------------------------------------------------------
    if (NombreExcelGenerar[0] == "TBBIENES") {

        if (CountListaBienes != 0) {
            strExcelExportado_ = "TBBIENES";
            $("#message").append('\nGenerando Archivo con Formato ' + strExcelExportado_ + '.txt' + ' . . .');
            window.open('/Reportes/GenerarFormatoArchivoDeTextoTxt?strTxtExportado=' + strExcelExportado_, '_blank');
            NumExcelExportados = ++NumExcelExportados;
            $("#num-excels-generados").html(NumExcelExportados + "/4");

            $("#progresLoader").html("51%");
            $("#progresLoader").width("51%");
            $("#progresLoader").addClass('active');
        }
    }

    **/

    $("#message").append('\n');
    $("#message").append('\n- - - - - - - - - - - - - - - - -  La Exportación del archivo ' + strArchivoExportado_ + '.txt ha finalizado!!   - - - - - - - - - - - - - - - - - ');
    $("#message").append('\n');

    NumExcelExportados = 0;

    setTimeout(function () {
        //313

        $("#progresLoader").html("100%");
        $("#progresLoader").width("100%");
        $("#progresLoader").removeClass('active');
        totalTime = secondsToTime(new Date().getTime() - ajaxTime);
        $("#tiempo").html(totalTime);

    }, 3000);


}

function GenerarWindowOpenArchivoTXTCodigo() {

    //-------------------------------------------------------------------------
    //if (NombreExcelGenerar[3] == "TBEMPLEADO") {

    if (CountListaTmProdu > 0) {
        strArchivoExportado_ = "TMINVENTARIO";
        $("#message").append('\nGenerando Archivo de Texto Solo Código ' + strArchivoExportado_ + '.txt . . .');
        $("#message").append('\nTotal a exportar : ' + CountListaTmProdu.toString() + ' Registros.');
        //window.open('/Personal/GenerarArchivosExportar?strArchivoExportado=' + strArchivoExportado_ + '&idRadioCheck=' + idRadioCheck, '_blank');
        window.open('/Personal/GenerarArchivosExportar?strArchivoExportado=' + strArchivoExportado_ + '&idRadioCheck=' + idRadioCheck + '&strCamposOpcionales=' + strCamposOpcionales_ ,  '_blank');
        NumExcelExportados = ++NumExcelExportados;
        $("#num-excels-generados").html(NumExcelExportados + "/4");
        $("#progresLoader").html("90%");
        $("#progresLoader").width("90%");
        $("#progresLoader").addClass('active');
    }

    //}

    $("#message").append('\n');
    $("#message").append('\n- - - - - - - - - - - - - - - - -   La Exportación del archivo ' + strArchivoExportado_ + '.txt ha finalizado!!   - - - - - - - - - - - - - - - - - ');
    $("#message").append('\n');
    NumExcelExportados = 0;
    setTimeout(function () {
        //313

        $("#progresLoader").html("100%");
        $("#progresLoader").width("100%");
        $("#progresLoader").removeClass('active');
        totalTime = secondsToTime(new Date().getTime() - ajaxTime);
        $("#tiempo").html(totalTime);

    }, 3000);


}

function GenerarWindowOpenArchivoCSVComa() {

    if (CountListaTmProdu > 0) {
        strArchivoExportado_ = "TMINVENTARIO";
        $("#message").append('\nGenerando Archivo CSV (Delimitado por ', ') ' + strArchivoExportado_ + '.csv . . .');
        $("#message").append('\nTotal a exportar  : ' + CountListaTmProdu.toString() + ' Registros.');
        //$("#message").append('\nCampos Opcionales : ' + strCamposOpcionales_.substring(1) + ' ');
        
        //window.open('/Personal/GenerarArchivosExcel?strArchivoExportado=' + strArchivoExportado_ + '&idRadioCheck=' + idRadioCheck, '_blank');
        window.open('/Personal/GenerarArchivosExcel?strArchivoExportado=' + strArchivoExportado_ + '&idRadioCheck=' + idRadioCheck + '&strCamposOpcionales=' + strCamposOpcionales_, '_blank');
        NumExcelExportados = ++NumExcelExportados;
        $("#num-excels-generados").html(NumExcelExportados + "/4");
        $("#progresLoader").html("90%");
        $("#progresLoader").width("90%");
        $("#progresLoader").addClass('active');
    }

    $("#message").append('\n');
    $("#message").append('\n- - - - - - - - - - - - - - - - -   La Exportación del archivo ' + strArchivoExportado_ + '.csv ha finalizado!!   - - - - - - - - - - - - - - - - - ');
    $("#message").append('\n');
    NumExcelExportados = 0;
    setTimeout(function () {

        $("#progresLoader").html("100%");
        $("#progresLoader").width("100%");
        $("#progresLoader").removeClass('active');
        totalTime = secondsToTime(new Date().getTime() - ajaxTime);
        $("#tiempo").html(totalTime);

    }, 3000);


}

function GenerarWindowOpenArchivoCSVCodigo() {


    if (CountListaTmProdu > 0) {
        strArchivoExportado_ = "TMINVENTARIO";
        $("#message").append('\nGenerando Archivo  CSV (Solo Còdigo) ' + strArchivoExportado_ + '.csv . . .');
        $("#message").append('\nTotal a exportar : ' + CountListaTmProdu.toString() + ' Registros.');
        //window.open('/Personal/GenerarArchivosExcel?strArchivoExportado=' + strArchivoExportado_ + '&idRadioCheck=' + idRadioCheck, '_blank');
        window.open('/Personal/GenerarArchivosExcel?strArchivoExportado=' + strArchivoExportado_ + '&idRadioCheck=' + idRadioCheck + '&strCamposOpcionales=' + strCamposOpcionales_, '_blank');
        NumExcelExportados = ++NumExcelExportados;
        $("#num-excels-generados").html(NumExcelExportados + "/4");
        $("#progresLoader").html("90%");
        $("#progresLoader").width("90%");
        $("#progresLoader").addClass('active');
    }


    $("#message").append('\n');
    $("#message").append('\n- - - - - - - - - - - - - - - - -   La Exportación del archivo ' + strArchivoExportado_+'.csv ha finalizado!!   - - - - - - - - - - - - - - - - - ');
    $("#message").append('\n');
    NumExcelExportados = 0;
    setTimeout(function () {

        $("#progresLoader").html("100%");
        $("#progresLoader").width("100%");
        $("#progresLoader").removeClass('active');
        totalTime = secondsToTime(new Date().getTime() - ajaxTime);
        $("#tiempo").html(totalTime);

    }, 3000);


}



////////////////////////////////////////////////////////////////////////////////////////////////
//CONVERSION DE TIEMPO 
////////////////////////////////////////////////////////////////////////////////////////////////
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
};

////////////////////////////////////////////////////////////////////////////////////////////////
//TRAER LAS CUATRO TABLAS COMO LISTAS HASTA EL CONTROLADOR
////////////////////////////////////////////////////////////////////////////////////////////////
function GenerarListasExcel() {

    $("#btn-exportar-archivos_excel").attr("disabled", true);

    $("#message").html('');
    $("#num-excels-generados").html("0/0");
    $("#procesados").html("--/--");
    $("#progresLoader").html("");
    $("#progresLoader").width("");

    var ajaxTimeComienzaConteo = new Date().getTime();
    ajaxTime = ajaxTimeComienzaConteo;
    totalTime = secondsToTime(new Date().getTime() - ajaxTime);
    $("#tiempo").html(totalTime);
    strExcelExportado_ = "TBBIENES";
    $.post(
        '/Reportes/GenerarListasDeCadaTabla',
        {
            strExcelExportado: strExcelExportado_
        },
        response => {
            CountListaBienes = response;
            $("#message").append('Obteniendo datos para ' + strExcelExportado_ + ': ' + CountListaBienes.toString() +' Registros.');
            //if (CountListaBienes < 1) {
            //    $("#message").append('\nNo se encontró datos para ' + strExcelExportado_ + '.');
            //}
            totalTime = secondsToTime(new Date().getTime() - ajaxTime);
            $("#tiempo").html(totalTime);
            $("#progresLoader").html("3%");
            $("#progresLoader").width("3%");
            strExcelExportado_ = "TBBIENESDS";
            $.post(
                '/Reportes/GenerarListasDeCadaTabla',
                {
                    strExcelExportado: strExcelExportado_
                },
                response => {  
                    CountListaBienesDs = response;
                    $("#message").append('\nObteniendo datos para ' + strExcelExportado_ + ': ' + CountListaBienesDs.toString() + ' Registros.');
                    //if (CountListaBienesDs < 1) {
                    //    $("#message").append('\nNo se encontró datos para ' + strExcelExportado_ + '.');
                    //}
                    totalTime = secondsToTime(new Date().getTime() - ajaxTime);
                    $("#tiempo").html(totalTime);
                    $("#progresLoader").html("12%");
                    $("#progresLoader").width("12%");
                    strExcelExportado_ = "TBOFICINA";
                    $.post(
                        '/Reportes/GenerarListasDeCadaTabla',
                        {
                            strExcelExportado: strExcelExportado_
                        },
                        response => {
                            CountListaOficina = response;
                            $("#message").append('\nObteniendo datos para ' + strExcelExportado_ + ': ' + CountListaOficina.toString() + ' Registros.');
                            //if (CountListaOficina < 1) {
                            //    $("#message").append('\nNo se encontró datos para ' + strExcelExportado_ + '.');
                            //}
                            totalTime = secondsToTime(new Date().getTime() - ajaxTime);
                            $("#tiempo").html(totalTime);
                            $("#progresLoader").html("24%");
                            $("#progresLoader").width("24%");
                            strExcelExportado_ = "TBEMPLEADO";
                            $.post(
                                '/Reportes/GenerarListasDeCadaTabla',
                                {
                                    strExcelExportado: strExcelExportado_
                                },
                                response => {

                                    CountListaEmpleado = response;
                                    $("#message").append('\nObteniendo datos para ' + strExcelExportado_ + ': ' + CountListaEmpleado.toString() + ' Registros.');
                                    //if (CountListaEmpleado < 1 ) {
                                    //    $("#message").append('\nNo se encontró datos para ' + strExcelExportado_ + '.');
                                    //}
                                    $("#message").append('\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ');
                                    $("#progresLoader").html("36%");
                                    $("#progresLoader").width("36%");
                                    ///////////////////////////////////////////
                                    GenerarWindowOpenExcel(); //alert('Listas de excel en el controlador');////////
                                    ///////////////////////////////////////////
                                    //FIN DE TODO EL PROCESO



                                    ////02
                                    //var chk_envio_de_coreo = "0";
                                    //if ($('#chk_envio_de_coreo').is(':checked') == true) {
                                    //    chk_envio_de_coreo = "1";
                                    //}


                                    setTimeout(function () {
                                        $("#progresLoader").html("100%");
                                        $("#progresLoader").width("100%");
                                        $("#progresLoader").removeClass('active');
                                        
                                    }, 4000);

                                    totalTime = secondsToTime(new Date().getTime() - ajaxTime);
                                    $("#tiempo").html(totalTime);
                                    //////$("#progresLoader").removeClass("progress-bar-animated")
                                    $("#btn-exportar-archivos_excel").attr("disabled", false);

                                    new PNotify({
                                        title: 'Importación Masiva Excel',
                                        text: 'La Exportación de los documentos Excel ha finalizado.',
                                        type: 'info',
                                        delay: 2000,
                                        styling: 'bootstrap3'
                                    });

                                    ////////////////////////////////////////////////////////////
                                    //SI EL CHECK ESTA HABILITADO SE ENVIA AL/LOS CORREO(s)
                                    if ($('#chk_envio_de_coreo').is(':checked') == true) {
                                        ////alert('EnviarExcelsExportadosPorCorreo');
                                        EnviarExcelsExportadosPorCorreo();
                                        //enviarExcelsPorCorreo();
                                    }
                                    ////////////////////////////////////////////////////////////


                                });

                        });

                });

        });

}

////////////////////////////////////////////////////////////////////////////////////////////////
//Ejecutar los Window.Open para descargar los cuatro excel en el Navegador con el Download
////////////////////////////////////////////////////////////////////////////////////////////////
function GenerarWindowOpenExcel(){

    let NombreExcelGenerar = ["TBBIENES", "TBBIENESDS", "TBOFICINA", "TBEMPLEADO"];

    let _TBBIENES   = NombreExcelGenerar[0]; 
    let _TBBIENESDS = NombreExcelGenerar[1]; 
    let _TBOFICINA  = NombreExcelGenerar[2]; 
    let _TBEMPLEADO = NombreExcelGenerar[3]; 
    //-------------------------------------------------------------------------
    if (NombreExcelGenerar[0] == "TBBIENES" ){

         if (CountListaBienes != 0) {
             strExcelExportado_ = "TBBIENES";
             $("#message").append('\nGenerando Archivo con Formato ' + strExcelExportado_ + ' . . .');
             window.open('/Reportes/GenerarArchivosExcel?strExcelExportado=' + strExcelExportado_, '_blank');
             NumExcelExportados = ++NumExcelExportados; 
             $("#num-excels-generados").html(NumExcelExportados + "/4");

             $("#progresLoader").html("51%");
             $("#progresLoader").width("51%");
             $("#progresLoader").addClass('active');
         }
         //else {        
         
         //       $("#message").append('\nNo se encontró datos para ' + strExcelExportado_ +'.');   
         //}
         //if (CountListaBienes = 0 && strExcelExportado_ == "TBBIENES") {
         
         //    $("#message").append('\nNo se encontró datos para ' + strExcelExportado_ + '.');  
         //}

    }

    //-------------------------------------------------------------------------
    if (NombreExcelGenerar[1] == "TBBIENESDS") {
        if (CountListaBienesDs != 0) {
            strExcelExportado_ = "TBBIENESDS";
            $("#message").append('\nGenerando Archivo con Formato ' + strExcelExportado_ + ' . . .');
            window.open('/Reportes/GenerarArchivosExcel?strExcelExportado=' + strExcelExportado_, '_blank');
            NumExcelExportados = ++NumExcelExportados;
            $("#num-excels-generados").html(NumExcelExportados + "/4");
            $("#progresLoader").html("64%");
            $("#progresLoader").width("64%");
            $("#progresLoader").addClass('active');
        }
        //else {
        
        //    $("#message").append('\nNo se encontró datos para ' + strExcelExportado_ + '.');
        //}
        //if (CountListaBienesDs = 0 && strExcelExportado_ == "TBBIENESDS") {
        
        //    $("#message").append('\nNo se encontró datos para ' + strExcelExportado_ + '.');
        //}
    }

    //-------------------------------------------------------------------------
    if (NombreExcelGenerar[2] == "TBOFICINA") {

        if (CountListaOficina != 0) {
            strExcelExportado_ = "TBOFICINA";
            $("#message").append('\nGenerando Archivo con Formato ' + strExcelExportado_ + ' . . .');
            window.open('/Reportes/GenerarArchivosExcel?strExcelExportado=' + strExcelExportado_, '_blank');
            NumExcelExportados = ++NumExcelExportados;
            $("#num-excels-generados").html(NumExcelExportados + "/4");
            $("#progresLoader").html("82%");
            $("#progresLoader").width("82%");
            $("#progresLoader").addClass('active');
        }
        //else {

        //    $("#message").append('\nNo se encontró datos para ' + strExcelExportado_ + '.');
        //}
        //if (CountListaOficina = 0 && strExcelExportado_ == "TBOFICINA") {

        //    $("#message").append('\nNo se encontró datos para ' + strExcelExportado_ + '.');
        //}
    }
    //-------------------------------------------------------------------------
    if (NombreExcelGenerar[3] == "TBEMPLEADO") {

        if (CountListaEmpleado != 0) {
            strExcelExportado_ = "TBEMPLEADO";
            $("#message").append('\nGenerando Archivo con Formato ' + strExcelExportado_ + ' . . .');
            window.open('/Reportes/GenerarArchivosExcel?strExcelExportado=' + strExcelExportado_, '_blank');
            NumExcelExportados = ++NumExcelExportados;
            $("#num-excels-generados").html(NumExcelExportados + "/4");
            $("#progresLoader").html("95%");
            $("#progresLoader").width("95%");
            $("#progresLoader").addClass('active');
        }
        //else {

        //    $("#message").append('\nNo se encontró datos para ' + strExcelExportado_ + '.');
        //}
        //if (CountListaEmpleado = 0 && strExcelExportado_ == "TBEMPLEADO") {

        //    $("#message").append('\nNo se encontró datos para ' + strExcelExportado_ + '.');
        //}
    }
    $("#message").append('\n');
    $("#message").append('\n- - - - - - - - - - - - - - - - -   La Exportación de los documentos Excel ha finalizado!!   - - - - - - - - - - - - - - - - - ');
    $("#message").append('\n');             


    NumExcelExportados = 0;

}

/***********************************************************************************************
                         ENVIO AL CORREO DE LOS EXCEL EXPORTADOS
************************************************************************************************/
function EnviarExcelsExportadosPorCorreo(){


    var strEmailDestino;

    //TRAER LOS CORREOS DESTINATARIOS
    $.post(
        '/Impresion/ListarTablasEnCombos',
        { strNomTablaEntidad: 'EMAIL_DESTINO' },
        (response) => {

            response.forEach(element => {

                strEmailDestino = element.strDeEntidad;
                ////alert(strEmailDestino);

            });

            //Terminacion si es un correo o varios correos

            if (typeof strEmailDestino === null || typeof strEmailDestino === "undefined" || strEmailDestino == "") {
                new PNotify({
                    title: 'Enviar Correo',
                    text: 'No existe ningún correo en la lista de destintarios.',
                    type: 'info',
                    delay: 3000,
                    styling: 'bootstrap3',
                    addclass: 'dark'
                });
                return;
            }

            else {
                var unoovarios = "";
                if (strEmailDestino.indexOf(';') > -1) {
                    //alert(unoovarios);
                    unoovarios = "s";
                }

            }


            ///INICIAR ENVIO A LOS CORREOS QUE ESTAN EN EL CAMPO "strEmailDestino" DE TSPARAMS
            $.ajax({
                url: '/Reportes/EnviarCuatroExcelsPorCorreo',
                type: 'POST',
                data: {

                    strEmailDestino
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
                        message: 'Enviando Correo' + unoovarios + '...'
                    });


                },
                success: function (response) {

                    if (response.type !== '') {

                        if (response.type === 'success') {

                            swal({
                                title: 'Correos Enviados',
                                text: response.message//$('#cbo_formatos option:selected').text() + 
                                //text:  $('#cbo_formatos option:selected').text() + " no existe, por favor crearlo dentro de la carpeta Formatos "+ +" con el mismo nombre seleccionado",
                                //timer: 2000,
                            });

                        }

                        else if (response.type === 'info') {

                            new PNotify({
                                title: 'Configuración',
                                text: response.message,
                                type: response.type,
                                delay: 3000,
                                styling: 'bootstrap3'
                            });

                        }
                    }


                },
                complete: function () {

                    $.unblockUI();
                }
            });



        });




}


////////////////////////////////////////////////////////////////////////////////////////////////
/// REPORTES EN CRYSTAL PDF
////////////////////////////////////////////////////////////////////////////////////////////////
$("#btn-Generar-PDF-Report-Saf").click(function () {
    //exportExcelPdf("&pdf=1");
    var tipoDeReporte = $("#cbo-tipo-reporte option:selected").val();

    if (tipoDeReporte == "" || tipoDeReporte == 0) {

        new PNotify({
            title: 'Reportes',
            text: 'Seleccione un Tipo de Reporte',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }

    else {

        var strExcelExportado = "";

        if (tipoDeReporte == "1") {
            strExcelExportado = "TBBIENES"
            //alert('PDF TBBIENES');
            window.open('/Rep/Vista/RepExcelsExportados.aspx?strExcelExportado=' + strExcelExportado + '&pdf=1');
        }
        else if (tipoDeReporte == "2") {
            strExcelExportado = "TBBIENESDS"
            //alert('TBBIENESDS');
            window.open('/Rep/Vista/RepExcelsExportados.aspx?strExcelExportado=' + strExcelExportado + '&pdf=1');
        }
        else if (tipoDeReporte == "3") {
            strExcelExportado = "TBOFICINA"
            //alert('TBOFICINA');
            window.open('/Rep/Vista/RepExcelsExportados.aspx?strExcelExportado=' + strExcelExportado + '&pdf=1');
        }
        else if (tipoDeReporte == "4") {
            strExcelExportado = "TBEMPLEADO"
            //alert('PDF TBEMPLEADO');
            window.open('/Rep/Vista/RepExcelsExportados.aspx?strExcelExportado=' + strExcelExportado + '&pdf=1');
        }
    }

})

////////////////////////////////////////////////////////////////////////////////////////////////
/// REPORTES EN CRYSTAL
////////////////////////////////////////////////////////////////////////////////////////////////
$("#btn-Generar-CRYSTAL-Report-Saf").click(function () {

    var tipoDeReporte = $("#cbo-tipo-reporte option:selected").val();

    if (tipoDeReporte == "" || tipoDeReporte == 0) {

        new PNotify({
            title: 'Reportes',
            text: 'Seleccione un Tipo de Reporte',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }

    else {

        var strExcelExportado = "";

        if (tipoDeReporte == "1") {
            strExcelExportado = "TBBIENES"
            //alert('CRYSTAL TBBIENES');
            window.open('/Rep/Vista/RepExcelsExportados.aspx?strExcelExportado=' + strExcelExportado + '');
        }
        else if (tipoDeReporte == "2") {
            strExcelExportado = "TBBIENESDS"
            //alert('CRYSTAL TBBIENESDS');
            window.open('/Rep/Vista/RepExcelsExportados.aspx?strExcelExportado=' + strExcelExportado + '');
        }
        else if (tipoDeReporte == "3") {
            strExcelExportado = "TBOFICINA"
            //alert('CRYSTAL TBOFICINA');
            window.open('/Rep/Vista/RepExcelsExportados.aspx?strExcelExportado=' + strExcelExportado + '');
        }
        else if (tipoDeReporte == "4") {
            strExcelExportado = "TBEMPLEADO"
            //alert('CRYSTAL TBEMPLEADO');
            window.open('/Rep/Vista/RepExcelsExportados.aspx?strExcelExportado=' + strExcelExportado + '');
        }

    }

});

////////////////////////////////////////////////////////////////////////////////////////////////
// NUEVO REQUERIMIENTO VIERNES 25.06.2021 desde  GenerarListasExcelToEmail(strEmailDestino)
// 1.- TRAER LAS OCHO TABLAS COMO LISTAS HASTA EL "ReportesController"  
////////////////////////////////////////////////////////////////////////////////////////////////
function GenerarListasExcelConDataSQL() { //strEmailDestino

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
    //    message: 'Procesando Documentos Excel...'
    //});

    //$("#btn-exportar-archivos_excel").attr("disabled", true);

    $("#message").html('');
    $("#num-excels-generados").html("0/0");
    $("#procesados").html("--/--");
    $("#progresLoader").html("");
    $("#progresLoader").width("");

    var ajaxTimeComienzaConteo = new Date().getTime();
    ajaxTime = ajaxTimeComienzaConteo;
    totalTime = secondsToTime(new Date().getTime() - ajaxTime);
    $("#tiempo").html(totalTime);

    strNombreExcel_ = "TBBIENES";

    $.post(
        '/Reportes/GenerarExcelsConDataSQLListas',
        {
            strNombreExcelConDataSQL: strNombreExcel_
        },  
        response => {

            //MENSAJE EN EL TEXTBOX/////////////////////////////////01
            cantDeRegistrosTBBIENES = response;
            $("#message").append('\nObteniendo datos para ' + strNombreExcel_ + ': ' + cantDeRegistrosTBBIENES.toString() + ' Registros.');

            //if (cantDeRegistrosTBBIENES < 1) {
            //    $("#message").append('\nNo se encontró datos para ' + strNombreExcel_ + '.');
            //}
            totalTime = secondsToTime(new Date().getTime() - ajaxTime);
            $("#tiempo").html(totalTime);
            $("#progresLoader").html("3%");
            $("#progresLoader").width("3%");
            $("#progresLoader").addClass('active')/////////////////////////////ADDCLASSA ACTIVE
            strNombreExcel_ = "TBOFICINA";
             $.post(
                 '/Reportes/GenerarExcelsConDataSQLListas',
                 {
                     strNombreExcelConDataSQL: strNombreExcel_
                 },
                 response => {

                     //MENSAJE EN EL TEXTBOX/////////////////////////////////02
                     cantDeRegistrosTBOFICINA = response;
                     $("#message").append('\nObteniendo datos para ' + strNombreExcel_ + ': ' + cantDeRegistrosTBOFICINA.toString() + ' Registros.');
                     //if (cantDeRegistrosTBOFICINA < 1) {
                     //    $("#message").append('\nNo se encontró datos para ' + strNombreExcel_ + '.');
                     //}
                     totalTime = secondsToTime(new Date().getTime() - ajaxTime);
                     $("#tiempo").html(totalTime);
                     $("#progresLoader").html("12%");
                     $("#progresLoader").width("12%");

                     strNombreExcel_ = "TBEMPLEADO";
                     $.post(
                         '/Reportes/GenerarExcelsConDataSQLListas',
                         {
                             strNombreExcelConDataSQL: strNombreExcel_
                         },
                         response => {

                             //MENSAJE EN EL TEXTBOX/////////////////////////////////03
                             cantDeRegistrosTBEMPLEADO = response;
                             $("#message").append('\nObteniendo datos para ' + strNombreExcel_ + ': ' + cantDeRegistrosTBEMPLEADO.toString() + ' Registros.');
                             //if (cantDeRegistrosTBEMPLEADO < 1) {
                             //    $("#message").append('\nNo se encontró datos para ' + strNombreExcel_ + '.');
                             //}
                             totalTime = secondsToTime(new Date().getTime() - ajaxTime);
                             $("#tiempo").html(totalTime);
                             $("#progresLoader").html("24%");
                             $("#progresLoader").width("24%");

                             strNombreExcel_ = "TBLOCAL";
                             $.post(
                                 '/Reportes/GenerarExcelsConDataSQLListas',
                                 {
                                     strNombreExcelConDataSQL: strNombreExcel_
                                 },
                                 response => {

                                     //MENSAJE EN EL TEXTBOX/////////////////////////////////04
                                     cantDeRegistrosTBLOCAL = response;
                                     $("#message").append('\nObteniendo datos para ' + strNombreExcel_ + ': ' + cantDeRegistrosTBLOCAL.toString() + ' Registros.');
                                     //if (cantDeRegistrosTBLOCAL < 1) {
                                     //    $("#message").append('\nNo se encontró datos para ' + strNombreExcel_ + '.');
                                     //}
                                     totalTime = secondsToTime(new Date().getTime() - ajaxTime);
                                     $("#tiempo").html(totalTime);
                                     $("#progresLoader").html("36%");
                                     $("#progresLoader").width("36%");

                                     strNombreExcel_ = "TBAREAS";
                                     $.post(
                                         '/Reportes/GenerarExcelsConDataSQLListas',
                                         {
                                             strNombreExcelConDataSQL: strNombreExcel_
                                         },
                                         response => {

                                             //MENSAJE EN EL TEXTBOX/////////////////////////////////05
                                             cantDeRegistrosTBAREAS = response;
                                             $("#message").append('\nObteniendo datos para ' + strNombreExcel_ + ': ' + cantDeRegistrosTBAREAS.toString() + ' Registros.');
                                             //if (cantDeRegistrosTBAREAS < 1) {
                                             //    $("#message").append('\nNo se encontró datos para ' + strNombreExcel_ + '.');
                                             //}
                                             totalTime = secondsToTime(new Date().getTime() - ajaxTime);
                                             $("#tiempo").html(totalTime);
                                             $("#progresLoader").html("48%");
                                             $("#progresLoader").width("48%");

                                             strNombreExcel_ = "TBESTADO";
                                             $.post(
                                                 '/Reportes/GenerarExcelsConDataSQLListas',
                                                 {
                                                     strNombreExcelConDataSQL: strNombreExcel_
                                                 },
                                                 response => {

                                                     //MENSAJE EN EL TEXTBOX/////////////////////////////////06
                                                     cantDeRegistrosTBESTADO = response;
                                                     $("#message").append('\nObteniendo datos para ' + strNombreExcel_ + ': ' + cantDeRegistrosTBESTADO.toString() + ' Registros.');
                                                     //if (cantDeRegistrosTBESTADO < 1) {
                                                     //    $("#message").append('\nNo se encontró datos para ' + strNombreExcel_ + '.');
                                                     //}
                                                     totalTime = secondsToTime(new Date().getTime() - ajaxTime);
                                                     $("#tiempo").html(totalTime);
                                                     $("#progresLoader").html("60%");
                                                     $("#progresLoader").width("60%");
                                                     strNombreExcel_ = "TBTIPO";
                                                     $.post(
                                                         '/Reportes/GenerarExcelsConDataSQLListas',
                                                         {
                                                             strNombreExcelConDataSQL: strNombreExcel_
                                                         },
                                                         response => {
                                                             //MENSAJE EN EL TEXTBOX/////////////////////////////////07
                                                             cantDeRegistrosTBTIPO = response;
                                                             $("#message").append('\nObteniendo datos para ' + strNombreExcel_ + ': ' + cantDeRegistrosTBTIPO.toString() + ' Registros.');
                                                             //if (cantDeRegistrosTBTIPO < 1) {
                                                             //    $("#message").append('\nNo se encontró datos para ' + strNombreExcel_ + '.');
                                                             //}
                                                             totalTime = secondsToTime(new Date().getTime() - ajaxTime);
                                                             $("#tiempo").html(totalTime);
                                                             $("#progresLoader").html("72%");
                                                             $("#progresLoader").width("72%");
                                                             strNombreExcel_ = "TBENTIDAD";
                                                             $.post(
                                                                 '/Reportes/GenerarExcelsConDataSQLListas',
                                                                 {
                                                                     strNombreExcelConDataSQL: strNombreExcel_
                                                                 },
                                                                 response => {

                                                                     //MENSAJE EN EL TEXTBOX/////////////////////////////////06
                                                                     cantDeRegistrosTBENTIDAD = response;
                                                                     $("#message").append('\nObteniendo datos para ' + strNombreExcel_ + ': ' + cantDeRegistrosTBENTIDAD.toString() + ' Registros.');
                                                                     //if (cantDeRegistrosTBENTIDAD < 1) {
                                                                     //    $("#message").append('\nNo se encontró datos para ' + strNombreExcel_ + '.');
                                                                     //}
                                                                     totalTime = secondsToTime(new Date().getTime() - ajaxTime);
                                                                     $("#tiempo").html(totalTime);
                                                                     $("#progresLoader").html("82%");
                                                                     $("#progresLoader").width("82%");


                                                                     $("#message").append('\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ');

                                                                     GenerarWindowOpenExcelDataSQL();

                                                                
                                                                     new PNotify({
                                                                         title: 'Excel con data SQL',
                                                                         text: 'La Descarga de los documentos Excel ha finalizado.',
                                                                         type: 'info',
                                                                         delay: 2000,
                                                                         styling: 'bootstrap3'
                                                                     });

                                                                     setTimeout(function () {
                                                                         //313

                                                                         $("#progresLoader").html("100%");
                                                                         $("#progresLoader").width("100%");
                                                                         $("#progresLoader").removeClass('active');
                                                                         totalTime = secondsToTime(new Date().getTime() - ajaxTime);
                                                                         $("#tiempo").html(totalTime);

                                                                     }, 3000);


                                                                 });


                                                         });


                                                 });

                                         });


                                 });


                         });

                 });

         });       


    return true;

}

////////////////////////////////////////////////////////////////////////////////////////////////
//DATA SQL - Ejecutar los Window.Open para descargar los cuatro excel en el Navegador con el Download
////////////////////////////////////////////////////////////////////////////////////////////////
function GenerarWindowOpenExcelDataSQL() {
    

    //Comienza en cero
    NumExcelContador = 0;
    //Limpiamos lo que habia ene l contador
    $("#num-excels-generados").html(NumExcelContador + "/8");


    let NombreExcelGenerar_SQL = ["TBBIENES", "TBOFICINA", "TBEMPLEADO", "TBLOCAL", "TBAREAS", "TBESTADO", "TBTIPO", "TBENTIDAD",];

    let _TBBIENES_SQL = NombreExcelGenerar_SQL[0];
    let _TBOFICINA_SQL = NombreExcelGenerar_SQL[1];
    let _TBEMPLEADO_SQL = NombreExcelGenerar_SQL[2];
    let _TBLOCAL_SQL = NombreExcelGenerar_SQL[3];
    let _TBAREAS_SQL = NombreExcelGenerar_SQL[4];
    let _TBESTADO_SQL = NombreExcelGenerar_SQL[5];
    let _TBTIPO_SQL = NombreExcelGenerar_SQL[6];
    let _TBENTIDAD_SQL = NombreExcelGenerar_SQL[7];

    //-------------------------------------------------------------------------
    if (NombreExcelGenerar_SQL[0] == "TBBIENES") {

        if (cantDeRegistrosTBBIENES != 0) {
            //var strNombreExcel_ = "TBBIENES";
            $("#message").append('\nGenerando Archivo con Formato ' + NombreExcelGenerar_SQL[0] + ' . . .');
            window.open('/Reportes/GenerarExcelsConDataSQLDescarga?strNombreExcelConDataSQL=' + NombreExcelGenerar_SQL[0], '_blank');

            NumExcelContador = ++NumExcelContador;
            $("#num-excels-generados").html(NumExcelContador + "/8");
            $("#progresLoader").html("84%");
            $("#progresLoader").width("84%");
        }

        if (cantDeRegistrosTBBIENES == 0) {

            $("#message").append('\n' + NombreExcelGenerar_SQL[0] + ' no se ha generado porque no tiene datos' + '.');

        }

    }

    //-------------------------------------------------------------------------
    if (NombreExcelGenerar_SQL[1] == "TBOFICINA") {

        if (cantDeRegistrosTBOFICINA != 0) {
            //var strNombreExcel_ = "TBBIENES";
            $("#message").append('\nGenerando Archivo con Formato ' + NombreExcelGenerar_SQL[1] + ' . . .');
            window.open('/Reportes/GenerarExcelsConDataSQLDescarga?strNombreExcelConDataSQL=' + NombreExcelGenerar_SQL[1], '_blank');
            NumExcelContador = ++NumExcelContador;
            $("#num-excels-generados").html(NumExcelContador + "/8");
            $("#progresLoader").html("86%");
            $("#progresLoader").width("86%");
        }
        if (cantDeRegistrosTBOFICINA == 0) {

            $("#message").append('\n' + NombreExcelGenerar_SQL[1] + ' no se ha generado porque no tiene datos' + '.');

        }

    }

    //-------------------------------------------------------------------------
    if (NombreExcelGenerar_SQL[2] == "TBEMPLEADO") {

        if (cantDeRegistrosTBEMPLEADO != 0) {

            $("#message").append('\nGenerando Archivo con Formato ' + NombreExcelGenerar_SQL[2] + ' . . .');
            window.open('/Reportes/GenerarExcelsConDataSQLDescarga?strNombreExcelConDataSQL=' + NombreExcelGenerar_SQL[2], '_blank');
            NumExcelContador = ++NumExcelContador;
            $("#num-excels-generados").html(NumExcelContador + "/8");
            $("#progresLoader").html("88%");
            $("#progresLoader").width("88%");
        }
        if (cantDeRegistrosTBEMPLEADO == 0) {

            $("#message").append('\n' + NombreExcelGenerar_SQL[2] + ' no se ha generado porque no tiene datos' + '.');

        }

    }

    if (NombreExcelGenerar_SQL[3] == "TBLOCAL") {

        if (cantDeRegistrosTBLOCAL != 0) {

            $("#message").append('\nGenerando Archivo con Formato ' + NombreExcelGenerar_SQL[3] + ' . . .');
            window.open('/Reportes/GenerarExcelsConDataSQLDescarga?strNombreExcelConDataSQL=' + NombreExcelGenerar_SQL[3], '_blank');
            NumExcelContador = ++NumExcelContador;
            $("#num-excels-generados").html(NumExcelContador + "/8");
            $("#progresLoader").html("90%");
            $("#progresLoader").width("90%");

        }
        if (cantDeRegistrosTBLOCAL == 0) {

            $("#message").append('\n' + NombreExcelGenerar_SQL[3] + ' no se ha generado porque no tiene datos' + '.');

        }

    }

    if (NombreExcelGenerar_SQL[4] == "TBAREAS") {

        if (cantDeRegistrosTBAREAS != 0) {

            $("#message").append('\nGenerando Archivo con Formato ' + NombreExcelGenerar_SQL[4] + ' . . .');
            window.open('/Reportes/GenerarExcelsConDataSQLDescarga?strNombreExcelConDataSQL=' + NombreExcelGenerar_SQL[4], '_blank');
            NumExcelContador = ++NumExcelContador;
            $("#num-excels-generados").html(NumExcelContador + "/8");
            $("#progresLoader").html("92%");
            $("#progresLoader").width("92%");

        }
        if (cantDeRegistrosTBAREAS == 0) {

            $("#message").append('\n' + NombreExcelGenerar_SQL[4] + ' no se ha generado porque no tiene datos' + '.');

        }

    }

    if (NombreExcelGenerar_SQL[5] == "TBESTADO") {

        if (cantDeRegistrosTBESTADO != 0) {

            $("#message").append('\nGenerando Archivo con Formato ' + NombreExcelGenerar_SQL[5] + ' . . .');
            window.open('/Reportes/GenerarExcelsConDataSQLDescarga?strNombreExcelConDataSQL=' + NombreExcelGenerar_SQL[5], '_blank');
            NumExcelContador = ++NumExcelContador;
            $("#num-excels-generados").html(NumExcelContador + "/8");
            $("#progresLoader").html("94%");
            $("#progresLoader").width("94%");

        }
        if (cantDeRegistrosTBESTADO == 0) {

            $("#message").append('\n' + NombreExcelGenerar_SQL[5] + ' no se ha generado porque no tiene datos' + '.');

        }

    }

    if (NombreExcelGenerar_SQL[6] == "TBTIPO") {

        if (cantDeRegistrosTBTIPO != 0) {

            $("#message").append('\nGenerando Archivo con Formato ' + NombreExcelGenerar_SQL[6] + ' . . .');
            window.open('/Reportes/GenerarExcelsConDataSQLDescarga?strNombreExcelConDataSQL=' + NombreExcelGenerar_SQL[6], '_blank');
            NumExcelContador = ++NumExcelContador;
            $("#num-excels-generados").html(NumExcelContador + "/8");
            $("#progresLoader").html("96%");
            $("#progresLoader").width("96%");

        }
        if (cantDeRegistrosTBTIPO == 0) {

            $("#message").append('\n' + NombreExcelGenerar_SQL[6] + ' no se ha generado porque no tiene datos' + '.');

        }

    }

    if (NombreExcelGenerar_SQL[7] == "TBENTIDAD") {

        if (cantDeRegistrosTBENTIDAD != 0) {
            $("#message").append('\nGenerando Archivo con Formato ' + NombreExcelGenerar_SQL[7] + ' . . .');
            window.open('/Reportes/GenerarExcelsConDataSQLDescarga?strNombreExcelConDataSQL=' + NombreExcelGenerar_SQL[7], '_blank');
            NumExcelContador = ++NumExcelContador;
            $("#num-excels-generados").html(NumExcelContador + "/8");
            $("#progresLoader").html("98%");
            $("#progresLoader").width("98%");

        }
        if (cantDeRegistrosTBENTIDAD == 0) {

            $("#message").append('\n' + NombreExcelGenerar_SQL[7] + ' no se ha generado porque no tiene datos' + '.');

        }


    }



    if (
        cantDeRegistrosTBBIENES == 0
        && cantDeRegistrosTBOFICINA == 0
        && cantDeRegistrosTBEMPLEADO == 0
        && cantDeRegistrosTBLOCAL == 0
        && cantDeRegistrosTBAREAS == 0
        && cantDeRegistrosTBESTADO == 0
        && cantDeRegistrosTBTIPO == 0
        && cantDeRegistrosTBENTIDAD == 0
    ) {
        $("#message").append('\n');
        $("#message").append('\n- - - - - - - - - - - - - - - -    No se ha Generado ningún excel con Data SQL   - - - - - - - - - - - - - - - - ');
        $("#message").append('\n');
    }

    else {
        $("#message").append('\n');
        $("#message").append('\n- - - - - - - - - - - - - - - -   Los Excel con data SQL se han Generado Exitosamente !!   - - - - - - - - - - - - - - - - ');
        $("#message").append('\n');
    }



}


/*==============================================================================================
    II.- CONVERTIR ESAS LISTAS A EXCELS Y MANDARLORS AL DIRECTORIO
    ---> Se creo directorio pero al final se desestimó, se termino enviandolos como Bytes en C#
================================================================================================*/
var strExcelName = "";
function GenerarExcelsConDataSQLDescargaEnDirectorio() {

    strExcelName = "TBBIENES";

    $.post(
        '/Reportes/GenerarExcelsConDataSQLDescargaEnDirectorio',
        {
            strNombreExcelConDataSQL: strExcelName
        },
        response => {            

                strExcelName = "TBOFICINA";
                $.post(
                    '/Reportes/GenerarExcelsConDataSQLDescargaEnDirectorio',
                    {
                        strNombreExcelConDataSQL: strExcelName
                    },
                    response => {

                        strExcelName = "TBEMPLEADO";
                        $.post(
                            '/Reportes/GenerarExcelsConDataSQLDescargaEnDirectorio',
                            {
                                strNombreExcelConDataSQL: strExcelName
                            },
                            response => {

                                strExcelName = "TBLOCAL";
                                $.post(
                                    '/Reportes/GenerarExcelsConDataSQLDescargaEnDirectorio',
                                    {
                                        strNombreExcelConDataSQL: strExcelName
                                    },
                                    response => {

                                        strExcelName = "TBAREAS";
                                        $.post(
                                            '/Reportes/GenerarExcelsConDataSQLDescargaEnDirectorio',
                                            {
                                                strNombreExcelConDataSQL: strExcelName
                                            },
                                            response => {


                                                strExcelName = "TBESTADO";
                                                $.post(
                                                    '/Reportes/GenerarExcelsConDataSQLDescargaEnDirectorio',
                                                    {
                                                        strNombreExcelConDataSQL: strExcelName
                                                    },
                                                    response => {

                                                        strExcelName = "TBTIPO";
                                                        $.post(
                                                            '/Reportes/GenerarExcelsConDataSQLDescargaEnDirectorio',
                                                            {
                                                                strNombreExcelConDataSQL: strExcelName
                                                            },
                                                            response => {

                                                                strExcelName = "TBENTIDAD";
                                                                $.post(
                                                                    '/Reportes/GenerarExcelsConDataSQLDescargaEnDirectorio',
                                                                    {
                                                                        strNombreExcelConDataSQL: strExcelName
                                                                    },
                                                                    response => {

                                                                        $.unblockUI();


                                                                      

                                                                    });

                                                            });


                                                    });

                                            });


                                    });


                            });

                    });

          

        });


}


////////////////////////////////////////////////////////////////////////////////////////////////
//TRAER LAS CUATRO TABLAS COMO LISTAS HASTA EL CONTROLADOR para luego usarlo con el Window.open
////////////////////////////////////////////////////////////////////////////////////////////////
function GetListasDeCadaTablaTxt() {    

    $("#btn-exportar-archivos_excel").attr("disabled", true);
    $("#message").html('');
    $("#num-excels-generados").html("0/0");
    $("#procesados").html("--/--");
    $("#progresLoader").html("");
    $("#progresLoader").width("");

    var ajaxTimeComienzaConteo = new Date().getTime();
    ajaxTime = ajaxTimeComienzaConteo;
    totalTime = secondsToTime(new Date().getTime() - ajaxTime);
    $("#tiempo").html(totalTime);
    strExcelExportado_ = "TBBIENES";
    $.post(
        '/Reportes/GetListasDeCadaTablaTxt',
        {
            strTxtExportado: strExcelExportado_
        },
        response => {

            CountListaBienes = response;
            $("#message").append('Obteniendo datos para ' + strExcelExportado_ + ': ' + CountListaBienes.toString() + ' Registros.');
            //if (CountListaBienes < 1) {
            //    $("#message").append('\nNo se encontró datos para ' + strExcelExportado_ + '.');
            //}
            totalTime = secondsToTime(new Date().getTime() - ajaxTime);
            $("#tiempo").html(totalTime);
            $("#progresLoader").html("3%");
            $("#progresLoader").width("3%");
            strExcelExportado_ = "TBBIENESDS";
            $.post(
                '/Reportes/GetListasDeCadaTablaTxt',
                {
                    strTxtExportado: strExcelExportado_
                },
                response => {
                    CountListaBienesDs = response;
                    $("#message").append('\nObteniendo datos para ' + strExcelExportado_ + ': ' + CountListaBienesDs.toString() + ' Registros.');
                    //if (CountListaBienesDs < 1) {
                    //    $("#message").append('\nNo se encontró datos para ' + strExcelExportado_ + '.');
                    //}
                    totalTime = secondsToTime(new Date().getTime() - ajaxTime);
                    $("#tiempo").html(totalTime);
                    $("#progresLoader").html("12%");
                    $("#progresLoader").width("12%");
                    strExcelExportado_ = "TBOFICINA";
                    $.post(
                        '/Reportes/GetListasDeCadaTablaTxt',
                        {
                            strTxtExportado: strExcelExportado_
                        },
                        response => {
                            CountListaOficina = response;
                            $("#message").append('\nObteniendo datos para ' + strExcelExportado_ + ': ' + CountListaOficina.toString() + ' Registros.');
                            //if (CountListaOficina < 1) {
                            //    $("#message").append('\nNo se encontró datos para ' + strExcelExportado_ + '.');
                            //}
                            totalTime = secondsToTime(new Date().getTime() - ajaxTime);
                            $("#tiempo").html(totalTime);
                            $("#progresLoader").html("24%");
                            $("#progresLoader").width("24%");
                            strExcelExportado_ = "TBEMPLEADO";
                            $.post(
                                '/Reportes/GetListasDeCadaTablaTxt',
                                {
                                    strTxtExportado: strExcelExportado_
                                },
                                response => {

                                    CountListaEmpleado = response;
                                    $("#message").append('\nObteniendo datos para ' + strExcelExportado_ + ': ' + CountListaEmpleado.toString() + ' Registros.');
                                    //if (CountListaEmpleado < 1 ) {
                                    //    $("#message").append('\nNo se encontró datos para ' + strExcelExportado_ + '.');
                                    //}
                                    $("#message").append('\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ');
                                    $("#progresLoader").html("36%");
                                    $("#progresLoader").width("36%");
                                    ///////////////////////////////////////////
                                    GenerarFormatoDeTexto(); //GenerarWindowOpenExcel(); //alert('Listas de excel en el controlador');////////
                                    ///////////////////////////////////////////
                                    //FIN DE TODO EL PROCESO
                                    ////02
                                    //var chk_envio_de_coreo = "0";
                                    //if ($('#chk_envio_de_coreo').is(':checked') == true) {
                                    //    chk_envio_de_coreo = "1";
                                    //}

                                    setTimeout(function () {
                                        $("#progresLoader").html("100%");
                                        $("#progresLoader").width("100%");
                                        $("#progresLoader").removeClass('active');

                                    }, 4000);

                                    totalTime = secondsToTime(new Date().getTime() - ajaxTime);
                                    $("#tiempo").html(totalTime);
                                    //////$("#progresLoader").removeClass("progress-bar-animated")
                                    $("#btn-exportar-archivos_excel").attr("disabled", false);

                                    new PNotify({
                                        title: 'Importación Masiva Excel',
                                        text: 'La Exportación de los documentos en Formayo de Texto ha finalizado.',
                                        type: 'info',
                                        delay: 2000,
                                        styling: 'bootstrap3'
                                    });

                                    ////////////////////////////////////////////////////////////
                                    //SI EL CHECK ESTA HABILITADO SE ENVIA AL/LOS CORREO(s)
                                    if ($('#chk_envio_de_coreo').is(':checked') == true) {
                                        ////alert('EnviarExcelsExportadosPorCorreo');
                                        ////////////////EnviarExcelsExportadosPorCorreo();
                                        //enviarExcelsPorCorreo();
                                    }
                                    ////////////////////////////////////////////////////////////


                                });

                        });

                });

        });

}


////////////////////////////////////////////////////////////////////////////////////////////////
//Ejecutar los Window.open para descargar los 04 TXT en el Navegador con el Download
////////////////////////////////////////////////////////////////////////////////////////////////
function GenerarFormatoDeTexto() {

    let NombreExcelGenerar = ["TBBIENES", "TBBIENESDS", "TBOFICINA", "TBEMPLEADO"];

    //-------------------------------------------------------------------------
    if (NombreExcelGenerar[0] == "TBBIENES") {

        if (CountListaBienes != 0) {
            strExcelExportado_ = "TBBIENES";
            $("#message").append('\nGenerando Archivo con Formato ' + strExcelExportado_ + '.txt' + ' . . .');
            window.open('/Reportes/GenerarFormatoArchivoDeTextoTxt?strTxtExportado=' + strExcelExportado_, '_blank');
            NumExcelExportados = ++NumExcelExportados;
            $("#num-excels-generados").html(NumExcelExportados + "/4");

            $("#progresLoader").html("51%");
            $("#progresLoader").width("51%");
            $("#progresLoader").addClass('active');
        }


    }
    //-------------------------------------------------------------------------
    if (NombreExcelGenerar[1] == "TBBIENESDS") {
        if (CountListaBienesDs != 0) {
            strExcelExportado_ = "TBBIENESDS";
            $("#message").append('\nGenerando Archivo con Formato ' + strExcelExportado_ + '.txt' + ' . . .');
            window.open('/Reportes/GenerarFormatoArchivoDeTextoTxt?strTxtExportado=' + strExcelExportado_, '_blank');
            NumExcelExportados = ++NumExcelExportados;
            $("#num-excels-generados").html(NumExcelExportados + "/4");
            $("#progresLoader").html("64%");
            $("#progresLoader").width("64%");
            $("#progresLoader").addClass('active');
        }

    }
    //-------------------------------------------------------------------------
    if (NombreExcelGenerar[2] == "TBOFICINA") {

        if (CountListaOficina != 0) {
            strExcelExportado_ = "TBOFICINA";
            $("#message").append('\nGenerando Archivo con Formato ' + strExcelExportado_ + '.txt' + ' . . .');
            window.open('/Reportes/GenerarFormatoArchivoDeTextoTxt?strTxtExportado=' + strExcelExportado_, '_blank');
            NumExcelExportados = ++NumExcelExportados;
            $("#num-excels-generados").html(NumExcelExportados + "/4");
            $("#progresLoader").html("82%");
            $("#progresLoader").width("82%");
            $("#progresLoader").addClass('active');
        }

    }
    //-------------------------------------------------------------------------
    if (NombreExcelGenerar[3] == "TBEMPLEADO") {

        if (CountListaEmpleado != 0) {
            strExcelExportado_ = "TBEMPLEADO";
            $("#message").append('\nGenerando Archivo con Formato ' + strExcelExportado_ + '.txt' + ' . . .');
            window.open('/Reportes/GenerarFormatoArchivoDeTextoTxt?strTxtExportado=' + strExcelExportado_, '_blank');
            NumExcelExportados = ++NumExcelExportados;
            $("#num-excels-generados").html(NumExcelExportados + "/4");
            $("#progresLoader").html("95%");
            $("#progresLoader").width("95%");
            $("#progresLoader").addClass('active');
        }

    }
    /*
    //-------------------------------------------------------------------------
    if (NombreExcelGenerar[4] == "TBOFICINA_TXT") {

        if (CountListaOficina != 0) {
            strExcelExportado_ = "TBOFICINA_TXT";
            $("#message").append('\nGenerando Archivo con Formato ' + strExcelExportado_ + ' . . .');
            window.open('/Reportes/GenerarFormatoArchivoDeTextoTxt?strTxtExportado=' + strExcelExportado_, '_blank');
            NumExcelExportados = ++NumExcelExportados;
            $("#num-excels-generados").html(NumExcelExportados + "/4");
            $("#progresLoader").html("82%");
            $("#progresLoader").width("82%");
            $("#progresLoader").addClass('active');
        }

    }
    //------------------------------------------------------------------------- * */



    $("#message").append('\n');
    $("#message").append('\n- - - - - - La Exportación de los documentos con Formato ".txt" ha finalizado!!   - - - - - - - - - - - - - - - - - ');
    $("#message").append('\n');


    NumExcelExportados = 0;

}












