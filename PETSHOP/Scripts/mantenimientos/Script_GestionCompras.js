/* NUGET: BEGIN LICENSE TEXT
 *
 * Este es un script solo para este mantenimiento
 * Cada script tiene que ir dentro del html de cada ventana 
 */

/**
* Hebert Gonzales
* Copyright 2021 Miniasoft Inc.
* http://www.miniasooft.org/licenses/LICENSE-2.0
*/

/////////////////////////////////////////////////////////////////////////////////
//ICONO LOGO BAILANDO
/////////////////////////////////////////////////////////////////////////////////
var pigTrueFalse = false;
function chanchito(){

    if(pigTrueFalse==false){
        pigTrueFalse = true;
        $('.pigLoader').attr('id', 'loader');
        $('#Capa_1').attr('class', 'loader');
        $('#Capa_1').show();
        $('.pigLoader').show();
    }
    else {
        pigTrueFalse = false;
        $('.pigLoader').removeAttr('id');
        $('#Capa_1').removeAttr('class', 'loader');
        $('#Capa_1').hide();
        $('.pigLoader').hide();
    }

}


/////////////////////////////////////////////////////////////////////////////////
//INICIALIZAR LO NECESARIO AL ENTRAR A ESTE MENU
/////////////////////////////////////////////////////////////////////////////////
 $(document).ready(function () {

      $('.nav_menu').show();
      ////$('#dapp-popup-wrapper').hide(); //Esconder el modal de registrar nuevo
      //En document ready SOLO DEBEN IR EL NOMBRE DE LAS FUNCIONES
      CombosGestionarProductos();
     ListarGestionCompras(par = "NORMAL");  //Cargar El Listado Principal de Compras

      //cargarImagenCuandoNoExiste();
      function cargarImagenCuandoNoExiste() {
          $(".poster").attr("src", "/images/productos/item_default.png");
          //$(".posterMarca").attr("src", imagenMarca);
          //$(".poster").show().transition({ x: '0%', opacity: 1.0 });
          //$('.poster').css('transition', 'opacity 5s ease-in-out');
          //$('.poster').fadeIn(2000).show();
      }

     //AÑADIDO EN DURO PARA CADA JS DE CADA VENTANA
     $('#fx_13_02_22_menu_actual').html('COMPRAS o INGRESOS');

 });

//$(window).load(function () {


//    $('#fx_13_02_22_menu_actual').html('fdfdfd');

//});


 /************************************************************************
      BLOCKER PROCESANDO LOADER (Cuando se realice peticiones a la bd)
 *************************************************************************/
 function blockLoader() {
              //$.blockUI();
              //setTimeout(unBlock, 5000);
    $.blockUI(
                  {
                      css: {
                          border: 'none',
                          padding: '15px',
                          backgroundColor: '#000',
                          '-webkit-border-radius': '10px',
                          '-moz-border-radius': '10px',
                          opacity: .5,
                          color: '#fff',
                          fontSize: '15px'
                      },
                      message: 'Procesando...'
                  });

}

 function unBlockLoader() {
     $.unblockUI();
 }

 /////////////////////////////////////////////////////////////////////////////////
 //INTERCALAR LOS TRES INPUTS DE BUSCAR(Limpia los demás al clickear en uno)
 /////////////////////////////////////////////////////////////////////////////////


 //////////////////////////////////////////////////////////////
 //modal-gensearchrca
 //////////////////////////////////////////////////////////////

$('#closeModal').on('click', function () {

    $('.asideModal').hide();
    $('.asideModal').removeAttr('id', 'dapp-popup-wrapper');
    //$('.classname').removeAttr('id');//https://www.codegrepper.com/code-examples/javascript/remove+id+jquery

});

//HAY DOS ONCLICK PARA ESTE BOTON REVISAR SI AMBOS SON NECESARIOS
$('#btnRegistrarNuevoIngreso').on('click', function () {
    
    $('.asideModal').attr('id', 'dapp-popup-wrapper');
    $('.asideModal').show();

});

$('#myModal').on('shown.bs.modal', function () {
    $('#myInput').trigger('focus');
});

 //update - boton guardar bgp
 $('#btn-guardar-editar').on('click', function () {         

                var _intIdProducto      = parseInt($("#inputHiddenIntIdProducto").val());  
                var _strCodigoBarras    = $("#inputStrCodigoBarras").val();
                var _strCodigoProducto  = $("#inputStrCodigoProducto").val();
                var _strDescProducto    = '1';
                var _intIdMarcaProducto = 1;
                var _decPrecioDeVenta   = 10;
                var _intCantTotalActual = 1;
                var _decMontoProductos  = 1;
                var _strMarcaProducto   = '1';
                var _strRutaImagenMarca = '1';
                var _strRutaImagenProducto = '1';
                var _strDescCategoria      = '1';
                var _strPresentacion       = '1';




                var Producto = {

                      intIdProducto        : _intIdProducto
                    , strCodigoBarras      : _strCodigoBarras
                    , strCodigoProducto    : _strCodigoProducto
                    , strDescProducto      : _strDescProducto
                    , intIdMarcaProducto   : _intIdMarcaProducto
                    , decPrecioDeVenta     : _decPrecioDeVenta
                    , intCantTotalActual   : _intCantTotalActual
                    , decMontoProductos    : _decMontoProductos
                    , strMarcaProducto     : _strMarcaProducto
                    , strRutaImagenMarca   : _strRutaImagenMarca
                    , strRutaImagenProducto: _strRutaImagenProducto
                    , strDescCategoria     : _strDescCategoria
                    , strPresentacion      : _strPresentacion

                }


                var SesionMovi = {
                    IntIdMenu: 'M0202',
                    intIdUsuario: 1,
                    intIdSoft: 1,
                    intIdSesion: 1
                }   

                // style="font-weight: bold;"
                //var name = "Stack Overflow";
                //var content = document.createElement('div');
                //content.innerHTML = ;

                    $.post(
                        '/Procesos/IUProductoController',
                    { ObjProducto: Producto, objSession: SesionMovi, intTipoOperacion: 1 },
                        (response) => {

                            //alert('respuesta exitosa');

                                       swal({
                                            title: 'Editar Producto',
                                            text: 'El código de barras ' + _strCodigoBarras + ' fue grabado \n existosamente' +' para el item ' + _strCodigoProducto +'.' ,
                                            // ',//response.message//$('#cbo_formatos option:selected').text() +
                                            //text:  $('#cbo_formatos option:selected').text() + " no existe, por favor crearlo dentro de la carpeta Formatos "+ +" con el mismo nombre seleccionado",
                                            //timer: 2000,
                                            //icon: "success",
                                            //button: "Aww yiss!",
                                       });

                                       //Swal.fire({
                                       //    position: 'top-end',
                                       //    icon: 'success',
                                       //    title: 'Your work has been saved',
                                       //    showConfirmButton: false,
                                       //    timer: 1500
                                       //})

                            ////swal(_strCodigoProducto , 'El código de barras para este Item ahora es el ' + _strCodigoBarras + '.', "success");

                            ListarGestionCompras(par = "NORMAL");
                            HideFormEditarAnimation();
                            ShowFormListadoAnimation();

                        });





            //    var SesionMovi = {
            //        IntIdMenu: 'M0202',
            //        intIdUsuario: idUsuar,
            //        intIdSoft: idSoftw,
            //        intIdSesion: intIdSe
            //    }

            //    $.post(
            //        '/Procesos/IUProductoController',
            //        { ObjProducto: Producto, objSession: SesionMovi, intTipoOperacion: 1 },
            //        (response) => {
            //            console.log(response);

            //            if (response.type !== '') {


            //                alert('respuesta');

            //                //////////if (response.type === 'success') {
            //                //////////    new PNotify({
            //                //////////        title: 'Nueva Empresa',
            //                //////////        text: response.message,
            //                //////////        type: response.type,
            //                //////////        delay: 3000,
            //                //////////        styling: 'bootstrap3'
            //                //////////    });
            //                //////////    $('.form-hide-Empresa').hide();
            //                //////////    TablaEmpresa();
            //                //////////}
            //                //////////else {  //Cuando el codigo ya esta registrado
            //                //////////    if (response.type === 'error') {
            //                //////////        var nomMantemiento = 'Empresa';
            //                //////////        var campo = 'txt_cod_Empresa';
            //                //////////        var msj = response.message;
            //                //////////        var response = "info";
            //                //////////        var deta = 'notifry_error';
            //                //////////        //Pintar el borde del textbox del error en cuestion (del codigo)
            //                //////////        document.getElementById("txt_cod_Empresa").style.borderColor = "#3498dbe0";
            //                //////////        INFO_MSJ(nomMantemiento, campo, response, msj, deta);
            //                //////////        return;
            //                //////////        //-------------------
            //                //////////        //document.getElementById("txt_cod_Empresa").style.borderColor = "#3498dbe0";
            //                //////////        //new PNotify({
            //                //////////        //    title: 'Información de Unidad Organizacional',
            //                //////////        //    text: 'El código ya está registrado',
            //                //////////        //    type: 'info',
            //                //////////        //    delay: 3000,
            //                //////////        //    styling: 'bootstrap3',
            //                //////////        //    addclass: 'dark'

            //                //////////        //});
            //                //////////        //return;
            //                //////////    }

            //                //////////    else { //Cuando el razon social(o descripcion) ya esta registrado
            //                //////////        if (response.type === 'info') {

            //                //////////            var nomMantemiento = 'Empresa';
            //                //////////            var campo = 'txt_desc_Empresa';
            //                //////////            var msj = response.message;
            //                //////////            var response = "info";
            //                //////////            var deta = 'notifry_errordes';
            //                //////////            //Pintar el borde del textbox del error en cuestion (la razon social)
            //                //////////            document.getElementById("txt_desc_Empresa").style.borderColor = "#3498dbe0";

            //                //////////            INFO_MSJ(nomMantemiento, campo, response, msj, deta);
            //                //////////            return;
            //                //////////        }

            //                //////////        else {
            //                //////////            //new PNotify({
            //                //////////            //    title: 'Nueva Empresa_Linea 42957',
            //                //////////            //    text: response.message,
            //                //////////            //    type: 'info',
            //                //////////            //    delay: 3000,
            //                //////////            //    styling: 'bootstrap3'
            //                //////////            //    });

            //                //////////            var nomMantemiento = 'Empresa';
            //                //////////            var campo = 'txt_Ruc';
            //                //////////            var msj = response.message;
            //                //////////            var response = "info";
            //                //////////            var deta = 'notifry_error_ruc';
            //                //////////            //Pintar el borde del textbox del error en cuestion (la razon social)
            //                //////////            document.getElementById("txt_Ruc").style.borderColor = "#3498dbe0";

            //                //////////            INFO_MSJ(nomMantemiento, campo, response, msj, deta);
            //                //////////            return;





            //                //}

            //                //}


            //                //}

            //            }
            //        }
            //    );

            ////////        .fail(function (result) {
            ////////    alert('ERROR ' + result.status + ' ' + result.statusText);
            ////////});

});


 ////$('#btn-guardar-editar').on('click', function () {

            ////    alert('btn-guardar-editar')




            /////////////////////////////////////////////
            //INTENTO DE CONTROLAR IMAGEN QUE NO EXISTE
            //////////////////////////////////////////////
            //function checkImage(src, good, bad) {
            //    var img = new Image();
            //    img.onload = good;
            //    img.onerror = bad;
            //    img.src = src;
            //}
            //checkImage("http://jsfiddle.net/img/logo.png", function () { alert(this.src + " " + "good"); }, function () { alert("bad"); });

            //checkImage("foo.gif", function () { alert("good"); }, function () { alert(this.src + " " + "bad"); });
            ////function ChangeImage(imagen) {
            //https://stackoverflow.com/questions/8418392/jquery-checking-if-an-image-exists-in-a-folder
            ////    var image = new Image();
            ////    image.onload = function () {
            ////        alert('loaded');
            ////    };
            ////    image.onerror = function () {
            ////        alert('error loading');
            ////    };
            ////    image.src = imagen;  // "http://BrokenPath/Sterling.jpg"
            ////}
            ////ChangeImage(imagenMarca)

 /*ESTA FUNCION TIENE QUE IR ANTES DE CARGAR TODA LA VENTANA Y no tiene que usar JQuery*/
 function cargarImagenCuandoNoExiste(){
                $(".poster").attr("src", "/images/productos/item_default.png");
                //$(".posterMarca").attr("src", imagenMarca);
                //$(".poster").show().transition({ x: '0%', opacity: 1.0 });
                //$('.poster').css('transition', 'opacity 5s ease-in-out');
                //$('.poster').fadeIn(2000).show();
            }

 //SHOW Y HIDE
 function ShowFormListadoAnimation() {
                $('.form-listado').fadeIn(200, function () {

                });
 }  

 function HideFormEditarAnimation() {
                $('.form-editar').fadeOut(200, function () {
 
                });          
 }

 function HideFormListadoAnimation() {
                $('.form-listado').fadeOut(200, function () {
      
                });
 }  

 function ShowFormEditarAnimation() {
                $('.form-editar').fadeIn(200, function () {
                    //$('.poster').fadeIn(2000, function () {

                    //});
                    ////$('#first-div').fadeIn(1500, function () {

                    ////    $('#second-div').fadeIn(3000, function () {
                    ////        $('#third-div').fadeIn(6000, function () {

                    ////        });
                            ////$('.poster').fadeIn(8000, function () {

                            ////});
                    ////    });
                    ////});
                });

                //$('.poster').fadeIn(8000, function () {

                //});
                
            }

 $('#btn-cancelar-editar').on('click', function () {

                $(".form-editar").hide();
                $(".form-listado").show();

});








function btnVerDetallesProd(intIdProducto) {

    /*
    $('.form-hide-Empresa').hide();
    //Acción del Boton Guardar
    $('#btn_save_change_Empresa').hide();
    //Acción del Boton Actualizar
    $('#btn_update_Empresa').show();
    //CombosEmpresa();
    */

    //////////////////////////////////////////////////////////////
    //REGISTRO PK PRODUCTOS PK
    //////////////////////////////////////////////////////////////

    $.post(
        '/Procesos/ObtenerRegistroProductoPorPk',
        { intIdProducto: intIdProducto },
        (response) => {

            console.log(response);
            response.forEach(element => {

                //alert(element.strDescProducto);
                var imagenMarca = element.strRutaImagenMarca;
                var imagenProducto = element.strRutaImagenProducto;
                $(".poster").attr("src", imagenProducto);
                $(".posterMarca").attr("src", imagenMarca);
                //transition: opacity 1s ease-in-out;                        
                $("#h1StrDescProducto").text(element.strDescProducto);
                $(".txtStrDescCategoria").text(element.strDescCategoria);
                $("#inputStrCodigoProducto").val(element.strCodigoProducto);
                //$("#inputDecPrecioDeVenta").val((element.decPrecioDeVenta).toFixed(2)); 
                //$("#h1DecPrecioDeVenta").text((element.decPrecioDeVenta).toFixed(2));
                $("#inputDecPrecioDeVenta").val((element.decPrecioDeVenta));
                $("#h1DecPrecioDeVenta").text((element.decPrecioDeVenta));

                $("#inputHiddenIntIdProducto").val(element.intIdProducto);
                //CANTIDAD ACTUAL
                $("#inputIntCantTotalActual").val(element.intCantTotalActual);
                //PRESENTACION
                $("#inputStrPresentacion").val(element.strPresentacion);
                $("#inputStrCodigoBarras").val(element.strCodigoBarras);
                //$(".form-editar").show();
                HideFormListadoAnimation();
                ShowFormEditarAnimation();

                //Combo Fecha de Ingreso  
                $.post(
                    '/Procesos/ListarCombosGestionar',
                    {
                        strNomTablaEntidad: 'CODIGO_INGRESO', intParametroEntero: element.intIdProducto
                    },
                    response => {
                        $('#cboPorFechaIngreso').empty()
                        $('#cboPorFechaIngreso').append('<option value="0">Seleccione Fecha</option>')
                        response.forEach(element => {
                            $('#cboPorFechaIngreso').append('<option  value="' + element.intIdEntidad + '">' + element.strDescEntidad + '</option>')
                        });

                    });

                //$(".form-listado").hide();
                ////$('#intidEmpresa').val(element.IntIdEmp);
                //////////$('#txt_cod_Empresa').val(element.strCoEmp);
                //////////$('#txt_desc_Empresa').val(element.strDesEmp);
                //////////$('#txt_Ruc').val(element.strRuc);
                //////////$('#txt_DirFiscal').val(element.strDirFiscal);
                //////////$.post(
                //////////    '/Personal/ListarCombosPersonal',
                //////////    { strEntidad: 'TGTIPO', intIdFiltroGrupo: 0, strGrupo: 'EMP', strSubGrupo: 'TIPO' },
                //////////    (response) => {
                //////////        $('#CampTipo').empty();
                //////////        $('#CampTipo').append('<option value="0">Seleccione</option>');
                //////////        response.forEach(element2 => {
                //////////            $('#CampTipos').append('<option value="' + element2.intidTipo + '">' + element2.strDeTipo + '</option>');
                //////////            if (element2.intidTipo == element.intTipoEmp) {
                //////////                $('#CampTipos').val(element.intTipoEmp);
                //////////            }
                //////////        });
                //////////    });
                //////////$('#VistaPrevia').html('<img src = ' + element.imgLogo + ' style="width:100%;height:100%" />');
                //////////$('#txtImagenEmpresa').val(element.imgLogo);
                //$('#strFeriaCampo1').val(element.strFeriaCampo1);
                //$('#strFeriaCampo2').val(element.strFeriaCampo2);
                //$('#strFeriaCampo3').val(element.strFeriaCampo3);
                //$('#strFeriaCampo4').val(element.strFeriaCampo4);
                //$('#strFeriaCampo5').val(element.strFeriaCampo5);
                //$('#strFeria')
                //////////$('#intidEmpresa').val(element.IntIdEmp);
                //////////if (element.bitFlActivo == false) {
                //////////    $('#idche').html(' <input type="checkbox" id="chk-activo-Empresa" class="js-switch" id="chk-activo-JO"/> Activo');
                //////////    // $('#chck_Activo_Var').iCheck('uncheck');
                //////////} else if (element.bitFlActivo == true) {
                //////////    $('#idche').html(' <input type="checkbox" id="chk-activo-Empresa" class="js-switch" id="chk-activo-JO" checked /> Activo');
                //////////    // $('#chck_Activo_Var').iCheck('check');
                //////////}
                //////$('.form-hide-Empresa').show();

            });

        });

};


            ////ToEmailEnviarExcelPorCorreo
            ////function ToEmailEnviarExcelPorCorreo() {
            ////    //strEmailDestino_ = "algun texto";
            ////    ////strExcelExportado
            ////    $.post(
            ////        '/Reportes/ToEmailEnviarExcelPorCorreo',
            ////        {
            ////            strEmailDestino: "algun texto"
            ////        },
            ////        response => {
            ////            alert('se envio');
            ////        });
            ////}


  /*====================================================================
   2.- CONVERTIR ESAS LISTAS A EXCELS Y MANDARLORS AL DIRECTORIO
  ======================================================================*/
  var strExcelExportado_ = "";
 function GenerarListasDeCadaTabla() {

                strExcelExportado_ = "TB_PRODUCTOS";
                //strExcelExportado
                $.post(
                    '/Reportes/GenerarListasDeCadaTabla',
                    {
                        strExcelGenerado: strExcelExportado_
                    },
                    response => {
                        var strExcelGenerado = "TB_PRODUCTOS";
                        //alert('Se Genero lista y excel');
                        //window.open('/Reportes/ToEmailGenerarArchivosExcel?strExcelGenerado=' + strExcelGenerado, '_blank');

                        //////ENVIAR EXCEL AL CORREO
                        $.post(
                            '/Reportes/ToEmailEnviarExcelPorCorreoControlador',
                            {
                                strEmailDestino: "TB_PRODUCTOS"
                            },
                            response => {

                                alert('El correo fue enviado exitsamente.');

                            });

                    });

}






//$('#inputBuscarPorTexto').on('focus', function () {
//    alert('aler')
//    //$(this).find("span").css("display", "inline").fadeOut(1000); //https://api.jquery.com/focusin/

//});

//LLENAR COMBOS
function CombosGestionarProductos() {

    $.post(
        '/Procesos/ListarCombosGestionar',
        {
            strNomTablaEntidad: 'COMBO_MARCAS', intParametroEntero: 0,
        },
        response => {
            $('#cboPorMarca').empty()
            $('#cboPorMarca').append('<option value="0">Todos</option>')
            response.forEach(element => {
                $('#cboPorMarca').append('<option ruc="' + element.strextra1 + '" value="' + element.intIdEntidad + '">' + element.strDescEntidad + '</option>')
            });

            //$('#cboPlantilla').change(function () {
            //})

        });


    $.post(
        '/Procesos/ListarCombosGestionar',
        {
            strNomTablaEntidad: 'COMBO_CATEGORIA', intParametroEntero: 0,
        },
        response => {
            $('#cboPorCategoria').empty()
            $('#cboPorCategoria').append('<option value="0">Todos</option>');
            response.forEach(element => {
                $('#cboPorCategoria').append('<option value="' + element.intIdEntidad + '">' + element.strDescEntidad + '</option>')
            });
        });


}



 /*************************************************************************************
 **************************************************************************************/
 function EnviarExcelsExportadosPorCorreo() {

                ////////$.post(
                ////////    '/Personal/getRutaDirImpotraExcel',
                ////////    {
                ////////        //sinparametros
                ////////    },
                ////////    response => {

                ////////        alert('respuesta exitosa');

                ////////    });

                //
                //var strEmailDestino;

                //COMBO TRAER MARCAS
                $.post(
                    '/Impresion/ListarTablasEnCombos',
                    { strNomTablaEntidad: 'COMBO_MARCAS' },
                    (response) => {

                        response.forEach(element => {

                            //strEmailDestino = element.strDeEntidad;
                            ////alert(strEmailDestino);

                        });

                        //Terminacion si es un correo o varios correos
                        var unoovarios = "";
                        if (strEmailDestino.indexOf(';') > -1) {
                            //alert(unoovarios);
                            unoovarios = "s";
                        }
                        ///INICIAR ENVIO A LOS CORREOS QUE ESTAN EN EL CAMPO "strEmailDestino" DE TSPARAMS
                        //////////$.ajax({
                        //////////    url: '/Reportes/ToEmailEnviarExcelPorCorreo',
                        //////////    type: 'POST',
                        //////////    data: {

                        //////////        strEmailDestino
                        //////////    },
                        //////////    beforeSend: function () {

                        //////////        $.blockUI({
                        //////////            css: {
                        //////////                border: 'none',
                        //////////                padding: '15px',
                        //////////                backgroundColor: '#000',
                        //////////                '-webkit-border-radius': '10px',
                        //////////                '-moz-border-radius': '10px',
                        //////////                opacity: .5,
                        //////////                color: '#fff'
                        //////////            },
                        //////////            message: 'Enviando Correo' + unoovarios + '...'
                        //////////        });


                        //////////    },
                        //////////    success: function (response) {

                        //////////        if (response.type !== '') {

                        //////////            if (response.type === 'success') {

                        //////////                swal({
                        //////////                    title: 'Correos Enviados',
                        //////////                    text: response.message//$('#cbo_formatos option:selected').text() +
                        //////////                    //text:  $('#cbo_formatos option:selected').text() + " no existe, por favor crearlo dentro de la carpeta Formatos "+ +" con el mismo nombre seleccionado",
                        //////////                    //timer: 2000,
                        //////////                });

                        //////////            }

                        //////////            else if (response.type === 'info') {

                        //////////                new PNotify({
                        //////////                    title: 'Configuración',
                        //////////                    text: response.message,
                        //////////                    type: response.type,
                        //////////                    delay: 3000,
                        //////////                    styling: 'bootstrap3'
                        //////////                });

                        //////////            }
                        //////////        }


                        //////////    },
                        //////////    complete: function () {

                        //////////        $.unblockUI();
                        //////////    }
                        //////////});



                    });




}



 //////////////////////////////////////////////////////////
 /// REGISTRAR UN NUEVO PRODUCTO   HGM VIERNES
 //////////////////////////////////////////////////////////
 $('#btn-insertar-nuevo-prroducto').on('click', function () { 

     alert('btn-insertar-nuevo-prroducto');
         /******************************************

         *******************************************/

     //var _intIdProducto = parseInt($("#inputHiddenIntIdProducto").val());
     var _strCodigoBarras = '00000000077777'; //$("#inputStrCodigoBarras").val();
     var _strCodigoProducto = 'PRO7777'; //$("#inputStrCodigoProducto").val();;
     var _strDescProducto = 'DESCRIPCION7777';
     var _intIdMarcaProducto = 1;
     var _decPrecioDeVenta = 777.77;
     var _intCantTotalActual = 7;
     var _decMontoProductos = ( _decPrecioDeVenta * _intCantTotalActual );
     var _strMarcaProducto = 'MARCA SIETE';
     var _strRutaImagenMarca = '/rutaimagenmarca';
     var _strRutaImagenProducto = '/rutaimagen pproducto';
     var _strDescCategoria = 'categoria comida';
     var _strPresentacion = 'en bolsa';

     alert("El monto total en este producto es: " + _decMontoProductos);


     //DE AUI EN ADELANTE FALTA PROGRAMAR 

     var Producto = {

           intIdProducto: _intIdProducto
         , strCodigoBarras: _strCodigoBarras
         , strCodigoProducto: _strCodigoProducto
         , strDescProducto: _strDescProducto
         , intIdMarcaProducto: _intIdMarcaProducto
         , decPrecioDeVenta: _decPrecioDeVenta
         , intCantTotalActual: _intCantTotalActual
         , decMontoProductos: _decMontoProductos
         , strMarcaProducto: _strMarcaProducto
         , strRutaImagenMarca: _strRutaImagenMarca
         , strRutaImagenProducto: _strRutaImagenProducto
         , strDescCategoria: _strDescCategoria
         , strPresentacion: _strPresentacion

     }


     var SesionMovi = {
         IntIdMenu: 'M0202',
         intIdUsuario: 1,
         intIdSoft: 1,
         intIdSesion: 1
     }

     // style="font-weight: bold;"
     //var name = "Stack Overflow";
     //var content = document.createElement('div');
     //content.innerHTML = ;

     $.post(
         '/Procesos/IUProductoController',
         { ObjProducto: Producto, objSession: SesionMovi, intTipoOperacion: 1 },
         (response) => {

             //alert('respuesta exitosa');

             swal({
                 title: 'Editar Producto',
                 text: 'El código de barras ' + _strCodigoBarras + ' fue grabado \n existosamente' + ' para el item ' + _strCodigoProducto + '.',
                 // ',//response.message//$('#cbo_formatos option:selected').text() +
                 //text:  $('#cbo_formatos option:selected').text() + " no existe, por favor crearlo dentro de la carpeta Formatos "+ +" con el mismo nombre seleccionado",
                 //timer: 2000,
                 //icon: "success",
                 //button: "Aww yiss!",
             });

             //Swal.fire({
             //    position: 'top-end',
             //    icon: 'success',
             //    title: 'Your work has been saved',
             //    showConfirmButton: false,
             //    timer: 1500
             //})

             ////swal(_strCodigoProducto , 'El código de barras para este Item ahora es el ' + _strCodigoBarras + '.', "success");

             ListarGestionCompras(par = "NORMAL");
             HideFormEditarAnimation();
             ShowFormListadoAnimation();

         });







 });























 //LLENAR COMBOS 2
 function CombosGestionarProductosNuevo() {

     $.post(
         '/Procesos/ListarCombosGestionar',
         {
             strNomTablaEntidad: 'COMBO_MARCAS', intParametroEntero: 0,
         },
         response => {
             $('#val_intIdMarcaProducto').empty()
             //$('#val_intIdMarcaProducto').append('<option value="0">Seleccione</option>')
             response.forEach(element => {
                 $('#val_intIdMarcaProducto').append('<option ruc="' + element.strextra1 + '" value="' + element.intIdEntidad + '">' + element.strDescEntidad + '</option>')
             })


         });


     $.post(
         '/Procesos/ListarCombosGestionar',
         {
             strNomTablaEntidad: 'COMBO_CATEGORIA', intParametroEntero: 0,
         },
         response => {
             $('#val_strDescCategoria').empty()
             //$('#val_strDescCategoria').append('<option value="0">Seleccione</option>')
             response.forEach(element => {
                 $('#val_strDescCategoria').append('<option value="' + element.intIdEntidad + '">' + element.strDescEntidad + '</option>')
             })
         });


 }




//Funcion onfocusout="setearCodigoItem() no esta siendo usada - revisarlo luego
 function setearCodigoItem() {

     //var x = document.getElementById("val_strCodigoProducto");
     //if (x.value == "") {
     //    //Traer el ultimo codigo de Producto
     //    $.post(
     //        '/Procesos/ListarCombosGestionar',
     //        {
     //            strNomTablaEntidad: 'ULTIMO_CODIGO_PRODUCTO', intParametroEntero: 1
     //        },
     //        response => {

     //            var intPruducto = (response[0].intIdEntidad) + 1;
     //            x.value = "ITEM0" + intPruducto.toString().padStart(4, "0");

     //        });

     //}
     //else {
     //         //$("#val_strCodigoProducto").prop('disabled', true);
     //}


 }

//////////////////////////////////////////////////////////////////////////////////////////////////////////
//GUARDAR NUEVA COMPRA - DESDE CONTROLES DINAMICOS
$('#btn-guardar-compra').on('click', function () {


    /**En este Proceso de Guardar considerar:
     * 1.- 
     * 2.- Cumplir con las validaciones de regla
     * 3.- 
     * **/


    var _strCodigoCompra     = $("#val_strCodigoCompra").val();   
    var _intIdProducto       = let_intIdProductoGesCom;   
    var _strCodigoProducto   = $("#val_strCodigoProducto").val();    
    var _intCantIngresada    = $("#val_intCantIngresada").val();   
    var _decCostoUnitCompra  = $("#val_decCostoUnitCompra").val();   
    var _decMontoTotCompra   = $("#val_decMontoTotCompra").val();   
    var _dttFechaIngreso     = $("#val_dttFechaIngreso").val();  
    var _dttFechaVencimiento = $("#val_dttFechaVencimiento").val();   
    var _strNumDocCompra     = $("#val_strNumDocCompra").val();   
    var _strDesProveedor     = $("#val_strDesProveedor").val();
    var _intStockPrevio      = $("#val_intCantTotalActual").val();

    

    //CODIGO PRODUCTO
    if ($('#val_strCodigoProducto').val() == '') {
        new PNotify({
            title: 'NUEVO INGRESO',
            text: 'Necesita Asociar un Producto al Ingreso de Compra.',
            type: 'info',
            delay: 2500,
            styling: 'bootstrap3',
        });
        $('#inputIngresarIdProducto').focus();
        return;
    }

    //COSTO UNITARIO
    if ($('#val_decCostoUnitCompra').val() == '' || $('#val_decCostoUnitCompra').val() == '0.00') {
        new PNotify({
            title: 'NUEVO INGRESO',
            text: 'Ingrese el Costo Unitario del Producto Comprado',
            type: 'info',
            delay: 2500,
            styling: 'bootstrap3',
        });
        $('#val_decCostoUnitCompra').focus();
        return;
    }

    //CANTIDAD A INGRESAR
    if ($('#val_intCantIngresada').val() == '' || $('#val_intCantIngresada').val() == '0') {
        new PNotify({
            title: 'NUEVO INGRESO',
            text: 'Ingrese la cantidad del Producto Comprado',
            type: 'info',
            delay: 2500,
            styling: 'bootstrap3',
        });
        $('#val_intCantIngresada').focus();
        return;
    }




    var Compra = {
                                  
          intIdCompra           : 0  
        , strCodigoCompra       : _strCodigoCompra    
        , intIdProducto         : _intIdProducto      
        , strCodigoProducto     : _strCodigoProducto  
        , intCantIngresada      : _intCantIngresada   
        , decCostoUnitCompra    : _decCostoUnitCompra   
        , decMontoTotCompra     : _decMontoTotCompra  
        , dttFechaIngreso       : _dttFechaIngreso    
        , dttFechaVencimiento   : _dttFechaVencimiento
        , strNumDocCompra       : _strNumDocCompra    
        , strDesProveedor       : _strDesProveedor    
        , intStockPrevio        : _intStockPrevio    
                                 

    };


    $.post(
        '/Procesos/InsertUpdateCompraGesCom',
        //{ ObjProducto: Producto, objSession: SesionMovi, intTipoOperacion: 8 },
        { ObjCompra: Compra, intTipoOperacion: 1 },
        (response) => {

            ///////////////////////////////////////////////////
            console.log(response);
            var nomMantemiento = 'NUEVO INGRESO';
            if (response.type !== '') {

                if (response.type === 'success') {
                    new PNotify({
                        title: 'NUEVO INGRESO',
                        text: response.message,
                        type: response.type,
                        delay: 2500,
                        styling: 'bootstrap3'
                    });

                    limpiarControlesInputsCompra();
                    ListarGestionCompras(par = "RELOAD");
                    HideFormEditarAnimation();
                    ShowFormListadoAnimation();
                    $('.form-nuevo-producto').hide();
                    $('.form-listado-producto').show();
                    let_intIdProductoGesCom = "";

                }

                else {  //Cuando el codigo ya esta registrado
                    if (response.type === 'error') {


                        var campo = 'txt_cod_Empresa';
                        var msj = response.message;
                        var deta = 'notifry_error';
                        //Pintar el borde del textbox del error en cuestion (del codigo)
                        //////document.getElementById("txt_cod_Empresa").style.borderColor = "#3498dbe0";
                        INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                        return;

                        //-------------------
                        //document.getElementById("txt_cod_Empresa").style.borderColor = "#3498dbe0";
                        //new PNotify({
                        //    title: 'Información de Unidad Organizacional',
                        //    text: 'El código ya está registrado',
                        //    type: 'info',
                        //    delay: 3000,
                        //    styling: 'bootstrap3',
                        //    addclass: 'dark'

                        //});
                        //return;
                    }

                    else { //Cuando el razon social(o descripcion) ya esta registrado
                        if (response.type === 'info') {

                            //var nomMantemiento = 'NUEVO INGRESO';
                            //var campo = 'txt_desc_Empresa';
                            //var msj = response.message;
                            //var response = "info";
                            //var deta = 'notifry_errordes';
                            //Pintar el borde del textbox del error en cuestion (la razon social)
                            //////document.getElementById("txt_desc_Empresa").style.borderColor = "#3498dbe0";

                            INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                            return;
                        }

                        else {
                            //new PNotify({
                            //    title: 'Nueva Empresa_Linea 42957',
                            //    text: response.message,
                            //    type: 'info',
                            //    delay: 3000,
                            //    styling: 'bootstrap3'
                            //    });

                            //var nomMantemiento = 'NUEVO INGRESO';
                            //var campo = 'txt_Ruc';
                            //var msj = response.message;
                            //var response = "info";
                            //var deta = 'notifry_error_ruc';
                            //Pintar el borde del textbox del error en cuestion (la razon social)
                            ////////document.getElementById("txt_Ruc").style.borderColor = "#3498dbe0";

                            INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                            return;

                        }

                    }


                }

            }


            /////////////////////////////////////////////////

        });



});



//////////////////////////////////////////////////////////////////////////////////////////////////////////
//ACTUALIZAR COMPRA  updtcomp
//////////////////////////////////////////////////////////////////////////////////////////////////////////
$('#btn-update-COMPRA').on('click', function () {


    /**En este Proceso de Guardar considerar:
     * 1.- 
     * 2.- Cumplir con las validaciones de regla
     * 3.- 
     * **/

    var _intIdCompra         = let_intIdCompraGesCom;
    var _strCodigoCompra     = $("#val_strCodigoCompra").val();
    var _intIdProducto       = let_intIdProductoGesCom;
    var _strCodigoProducto   = $("#val_strCodigoProducto").val();
    var _intCantIngresada    = $("#val_intCantIngresada").val();
    var _decCostoUnitCompra  = $("#val_decCostoUnitCompra").val();
    var _decMontoTotCompra   = $("#val_decMontoTotCompra").val();
    var _dttFechaIngreso     = $("#val_dttFechaIngreso").val();
    var _dttFechaVencimiento = $("#val_dttFechaVencimiento").val();
    var _strNumDocCompra     = $("#val_strNumDocCompra").val();
    var _strDesProveedor     = $("#val_strDesProveedor").val();
    var _intStockPrevio      = $("#val_intCantTotalActual").val();



    //CODIGO PRODUCTO
    if ($('#val_strCodigoProducto').val() == '' ) {
        new PNotify({
            title: 'EDITAR INGRESO',
            text: 'Necesita Asociar un Producto al Ingreso de Compra.',
            type: 'info',
            delay: 2500,
            styling: 'bootstrap3',
        });
        $('#inputIngresarIdProducto').focus();
        return;
    }

    //COSTO UNITARIO
    if ($('#val_decCostoUnitCompra').val() == '' || $('#val_decCostoUnitCompra').val() == '0.00') {
        new PNotify({
            title: 'EDITAR INGRESO',
            text: 'Ingrese el Costo Unitario del Producto Comprado',
            type: 'info',
            delay: 2500,
            styling: 'bootstrap3',
        });
        $('#val_decCostoUnitCompra').focus();
        return;
    }

    //CANTIDAD A INGRESAR
    if ($('#val_intCantIngresada').val() == '' || $('#val_intCantIngresada').val() == '0') {
        new PNotify({
            title: 'EDITAR INGRESO',
            text: 'Ingrese la cantidad del Producto Comprado',
            type: 'info',
            delay: 2500,
            styling: 'bootstrap3',
        });
        $('#val_intCantIngresada').focus();
        return;
    }

 
    //ALERT DE CONFIRMACION
    swal({

        title: 'INGRESO: "' + _strCodigoCompra + '" ',
        text: "Está seguro que desea actualizar este Ingreso?",
        //text: "Se Actualizará el ingreso:" + _strCodigoCompra  + " ",
        type: "info",
        showCancelButton: true,
        confirmButtonText: 'Actualizar!',//'Sí, Aceptar!',
        cancelButtonText: "Cancelar!",
        closeOnConfirm: false,
        showLoaderOnConfirm: true

    }).then(function (isConfirm) {

        //alert('CONFIRMAR');

        var Compra = {

              intIdCompra         : _intIdCompra  //
            , strCodigoCompra     : _strCodigoCompra
            , intIdProducto       : _intIdProducto
            , strCodigoProducto   : _strCodigoProducto
            , intCantIngresada    : _intCantIngresada
            , decCostoUnitCompra  : _decCostoUnitCompra
            , decMontoTotCompra   : _decMontoTotCompra
            , dttFechaIngreso     : _dttFechaIngreso
            , dttFechaVencimiento : _dttFechaVencimiento
            , strNumDocCompra     : _strNumDocCompra
            , strDesProveedor     : _strDesProveedor
            , intStockPrevio      : _intStockPrevio


        };

        $.post(
            '/Procesos/InsertUpdateCompraGesCom',
            //{ ObjProducto: Producto, objSession: SesionMovi, intTipoOperacion: 8 },
            { ObjCompra: Compra, intTipoOperacion: 2 },
            (response) => {

                ///////////////////////////////////////////////////
                console.log(response);
                var nomMantemiento = 'ACTUALIZAR INGRESO';
                if (response.type !== '') {

                    if (response.type === 'success') {
                        new PNotify({
                            title: 'ACTUALIZAR INGRESO',
                            text: response.message,
                            type: response.type,
                            delay: 2500,
                            styling: 'bootstrap3'
                        });

                        limpiarControlesInputsCompra();
                        ListarGestionCompras(par = "NORMAL");
                        HideFormEditarAnimation();
                        ShowFormListadoAnimation();
                        $('.form-nuevo-producto').hide();
                        $('.form-listado-producto').show();
                        let_intIdProductoGesCom = "";
                        //////$('.form-hide-Empresa').hide();
                        //////TablaEmpresa();

                    }

                    else {  //Cuando el codigo ya esta registrado
                        if (response.type === 'error') {

                            INFO_MSJ(nomMantemiento, '', 'info', response.message, '');
                            return;

                            //-------------------
                            //document.getElementById("txt_cod_Empresa").style.borderColor = "#3498dbe0";
                            //new PNotify({
                            //    title: 'Información de Unidad Organizacional',
                            //    text: 'El código ya está registrado',
                            //    type: 'info',
                            //    delay: 3000,
                            //    styling: 'bootstrap3',
                            //    addclass: 'dark'
                            //});
                            //return;
                        }

                        else { 
                            if (response.type === 'info') {

                                INFO_MSJ(nomMantemiento, '', 'info', response.message, '');
                                return;
                            }

                            else {

                                //var nomMantemiento = 'ACTUALIZAR INGRESO';
                                //var campo = 'txt_Ruc';
                                //var msj = response.message;
                                //var response = "info";
                                //var deta = 'notifry_error_ruc';
                                INFO_MSJ(nomMantemiento, '', 'info', response.message, '');
                                return;

                            }

                        }


                    }

                }


                /////////////////////////////////////////////////

            });

    }, function (dismiss) {
        //if (dismiss == 'cancel') {
        //swal("Cancelado", "La Operación fue cancelada", "error");
        //}
    });




});














/* **********************************************************************************************************
                             CARGAR IMAGEN PRODUCTOS - SCRIPT DESDE EL SISFOOD
************************************************************************************************************* */
$('#CargarImagen').change(function (e) {
    CargarImagen();
});

$('#removerimagen').on('click', function () {
    //alert(11);
    $('#VistaPrevia').html('<img src = "/images/productos/item_default.png" />'); /*style = "width:40%" */
    //$('#txtImagenEmpresa').val('');
    $('#val_strNombreImagenCargada').val('');
    $('#val_strRutaImagenProducto').val('');
    return false;

});

let rootImagenCargadaLocally;
let nameImagenCargadaLocally;
function CargarImagen() {
    var formdata = new FormData(); //FormData object
    var fileInput = document.getElementById('CargarImagen');

    //CODIGO ITEM
    if ($('#val_strCodigoProducto').val() == '') {
        new PNotify({
            title: 'Imagen',
            text: 'Ingresar Código',
            type: 'info',
            delay: 4000,
            styling: 'bootstrap3',
        });
        $('#val_strCodigoProducto').focus();
        return;
    }


    //Checkea si soporta el navegador HTML5.
    if (typeof (fileInput.files) != "undefined") {
        //Inicializa FileReader object.
        var reader = new FileReader();
        //Lee el contenido del Image File.
        reader.readAsDataURL(fileInput.files[0]);
        reader.onload = function (e) {
            //Inicializa el JavaScript Image object.
            var image = new Image();

            //Set the Base64 string return from FileReader as source.
            image.src = e.target.result;

            //Valida el  tamaño y el ancho de la imagen.
            image.onload = function () {
                var height = this.height;
                var width = this.width;
                if (height > 800 || width > 800) {
                    //alert("El tamaño debe se de 240px X 240px ");
                    new PNotify({
                        title: 'Imagen',
                        text: 'El tamaño de la imagen no debe ser mayor a 660px X 600px ',
                        type: 'info',
                        delay: 4000,
                        styling: 'bootstrap3',
                    });
                    //return false;
                    return;
                }

                else {
                    //Iterating through each files selected in fileInput
                    for (i = 0; i < fileInput.files.length; i++) {
                        //Appending each file to FormData object
                        //formdata.append("username", "Groucho");
                        formdata.append(fileInput.files[i].name, fileInput.files[i]);
                        //formdata.append('#val_strCodigoBarras', fileInput.files[i]);
                        //formdata.append('archivos' + '/' + '1254' , fileInput.files[i]);
                    }

                    //////PRIMERO ENVIAMOS EL NOMBRE DE LA IMAGEN COMO UN STRING
                    ////$.post(
                    ////    '/Procesos/CodigoItemJsToController',
                    ////    {
                    ////        codItemFromJs: $('#val_strCodigoProducto').val()
                    ////    },
                    ////    response => {

                    ////        //srtDirIpConCsharp = response;
                    ////        //alert(srtDirIpConCsharp);      

                    ////    });


                    //////////////////////////////////////////////////////////////////////////////////////
                    var xhr = new XMLHttpRequest();
                    //formData.append("username", "Groucho"); //hgm
                    xhr.open('POST', '/Procesos/UploadImagenProducto');
                    xhr.send(formdata);
                    xhr.onreadystatechange = function () {
                        if (xhr.readyState == 4 && xhr.status == 200) {
                            console.log(xhr);
                            //Guardra en una varilable la ruta de la imagen cargada
                            rootImagenCargadaLocally = xhr.responseText;


                            //Obtener solo el nombre de esa imagen
                            const myArray = xhr.responseText.split("/");
                            nameImagenCargadaLocally = (myArray[3]).slice('"', -1);
                            //alert(xhr.responseText); //  "/images/productos/cate_aseo.png"
                            //alert(nameImagenCargadaLocally);


                            //Obtener la extension de la imagen
                            const myArrayExt = xhr.responseText.split(".");
                            extensionImagen = (myArrayExt[1]).slice('"', -1);
                            $("#val_strRutaImagenProducto").val("/images/productos/" + $('#val_strCodigoProducto').val() + '.'+ extensionImagen);
                            $('#val_strNombreImagenCargada').val(rootImagenCargadaLocally);


                            DirLocal = xhr.responseText;

                            $('#VistaPrevia').html('<img id="imgCarga" src=' + rootImagenCargadaLocally + ' style="width:50%;" />');
                            $('#txtImagenEmpresa').val(DirLocal);
                        }
                    };  
                    //////////////////////////////////////////////////////////////////////////////////////

                       

                }
            };

        };
    } else {
        //alert("Su navegador no soporta HTML5.");
        return false;
    }
}


/////////////////////////////////////////////////////////////////////////
// VALDCN DE CONTROLES PARA LOS INPUTS DE REGISTRO DE NUEVO PRODUCTO 
/////////////////////////////////////////////////////////////////////////
//VALIDACION DE CARACTERES DE DESCRIPCION - COPIADO DESDE PERFIL
function validarDescripcionAll(evt) {
    //onkeypress = "validarDescripcion(event)"
    var theEvent = evt || window.event;

    // Handle paste
    if (theEvent.type === 'paste') {
        key = event.clipboardData.getData('text/plain');
    } else {
        // Handle key press
        var key = theEvent.keyCode || theEvent.which;
        key = String.fromCharCode(key);
    }

    //Números, Letras ---> a-z,A-Z, _, - con espacios, slash, guion, guion bajo
    var regex = /[0-9]|[a-z]|[A-Z]|\á|\é|\í|\ó|\ú|\Á|\É|\Í|\Ó|\Ú|\ñ|\Ñ|\_|\/|\-|\s/; 
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}



/////////////////////////////////////////////////////////////////////////
// VALIDACION DE CARACTERES DE CODIGO - BASADO EN PERFIL
/////////////////////////////////////////////////////////////////////////
function validarCodigoAll(evt) {
    //onkeypress = "validarCodigoAll(event)"
    //let k = event ? event.which : window.event.keyCode;
    //if (k == 32) return false;

    var theEvent = evt || window.event;
    // Handle paste
    if (theEvent.type === 'paste') {
        key = event.clipboardData.getData('text/plain');
    } else {
        // Handle key press
        var key = theEvent.keyCode || theEvent.which;
        key = String.fromCharCode(key);
    }
    var regex = /[0-9]|[a-z]|[A-Z]|\_|\/|\-/; //Números, Letras ---> a-z,A-Z, _, - sin espacio, slash, guion, guion bajo
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }

}

function validarSoloNum(evt) {
    //onkeypress = "return  validarSoloNum(event)" //el return  es necesario para el espacio.
    var theEvent = evt || window.event;

    // Handle paste
    if (theEvent.type === 'paste') {
        // alert(1);
        key = event.clipboardData.getData('text/plain');
    } else {
        // alert(3);
        // Handle key press
        var key = theEvent.keyCode || theEvent.which;
        key = String.fromCharCode(key);
    }

    let k = event ? event.which : window.event.keyCode;
    if (k == 32) return false;

    var regex = /[0-9]|\./; //Numeros
    if (!regex.test(key)) {
        // alert(3);
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}

//AÑADIR PORCENTAJE AL SALIR DEL INPUT <input type="text" id="sometext" onfocusout="aniadirPorcentage()">
function aniadirPorcentage() {
    var x = document.getElementById("val_decPorcentajeDescto");
    // var x = document.getElementsByClassName("Descuento");
    // x.value = x.value.toUpperCase();
    if (x.value == "") {
        x.value = "0.00%";
    }
    else {
        // alert(/[%]/i.test(x.value) );
        if (/[%]/i.test(x.value) == false) {

            //para que acepte valores decimales no hay que convertirlo en parrse int
            x.value = (parseFloat(x.value)).toFixed(2) + "%";

        }

    }

}


//INPUT STOCK 01 ------
function setearStock() {
    var x = document.getElementById("val_intCantTotalActual");

    if (x.value == "") {
        x.value = "0";

        //--------------------------------------------------------------
        var xy = document.getElementById("val_decMontoProducto");
        if ($('#val_decPrecioDeVenta').val() == ""
            || $('#val_decPrecioDeVenta').val() == "0"
            || $('#val_decPrecioDeVenta').val() == "0.0"
            || $('#val_decPrecioDeVenta').val() == "0.00"
            || $('#val_intCantTotalActual').val() == ""
            || $('#val_intCantTotalActual').val() == "0") {
            xy.value = "0.00";
        }
        else {
            xy.value = (parseFloat($('#val_decPrecioDeVenta').val() * $('#val_intCantTotalActual').val())).toFixed(2);
        };
          //--------------------------------------------------------------


    }
    else {
    //nada
    }

}



//INPUT STOCK 01 ------
$('#val_intCantTotalActual').on('click', function () {

//DO NADA

});

//INPUT MONTO ------
function setearMonto() {
    var x = document.getElementById("val_decMontoProducto");

    if (x.value == "") {
        x.value = "0.00";

        //--------------------------------------------------------------
        var xy = document.getElementById("val_decMontoProducto");
        if ($('#val_decPrecioDeVenta').val() == ""
            || $('#val_decPrecioDeVenta').val() == "0"
            || $('#val_decPrecioDeVenta').val() == "0.0"
            || $('#val_decPrecioDeVenta').val() == "0.00"
            || $('#val_intCantTotalActual').val() == ""
            || $('#val_intCantTotalActual').val() == "0") {
            xy.value = "0.00";
        }
        else {
            xy.value = (parseFloat($('#val_decPrecioDeVenta').val() * $('#val_intCantTotalActual').val())).toFixed(2);
        };
        //--------------------------------------------------------------


    }
    else {
        //nada
    }

}



//AÑADIR PORCENTAJE AL SALIR DEL INPUT <input type="text" id="sometext" onfocusout="convertValorPrecio()">
function convertValorPrecio() {
    var x = document.getElementById("val_decPrecioDeVenta");
    // var x = document.getElementsByClassName("Descuento");
    if (x.value == "") {
        x.value = "0.00";


        //--------------------------------------------------------------
        var xy = document.getElementById("val_decMontoProducto");
        if (   $('#val_decPrecioDeVenta').val() == ""
            || $('#val_decPrecioDeVenta').val() == "0"
            || $('#val_decPrecioDeVenta').val() == "0.0"
            || $('#val_decPrecioDeVenta').val() == "0.00"
            || $('#val_intCantTotalActual').val() == ""
            || $('#val_intCantTotalActual').val() == "0") {
            xy.value = "0.00";
        }
        else {
            xy.value = (parseFloat($('#val_decPrecioDeVenta').val() * $('#val_intCantTotalActual').val())).toFixed(2);
        };
          //--------------------------------------------------------------


    }
    else {
        x.value = (parseFloat(x.value)).toFixed(2);//para que acepte valores decimales no hay que convertirlo en parrse int
    }

}


function cargarImagenDefaultCuandoNoExiste() {
    $('#VistaPrevia').html('<img src = "/images/productos/image_no_found.png" />');
}


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


/*====================================================================
  FILTROS DE BUSQUEDA PARA EL LISTADO DE COMPRAS
======================================================================*/
$("#inputBuscadorCodBarras").on("click", function () {
    $(".form-editar").hide();
    $(".form-listado").show();
    //Al hacer un click en el "inputBuscadorCodBarras" se limpian los demas controles
    $('#cboPorCategoria').val(0);
    $('#cboPorMarca').val(0);
    $('#cboPorVencimiento').val(0);
    $('#inputBuscarPorTexto').val('');
});

//FUENTE: https://stackoverflow.com/questions/35905507/how-do-i-execute-a-function-after-5-sec-from-last-keyup
var timer;
$("#inputBuscadorCodBarras").on("keyup", function () {
    
    $('.div_spanProItem').show();
    $('.val_spanProItem').html($.trim($("#inputBuscadorCodBarras").val())); 

    clearInterval(timer);
    timer = setTimeout(function () {

        $('#inputBuscarPorTexto').val('');
        $('#cboPorCategoria').val(0);
        $('#cboPorMarca').val(0);
        $('#cboPorVencimiento').val(0);
        ListarGestionCompras(par = "NORMAL");

    }, 300);   //1 * 1000);


});

$('#cboPorMarca').on('change', function () {

    $('.div_spanProItem').hide();
    $(".form-editar").hide();
    $(".form-listado").show();
    $('#inputBuscarPorTexto').val('');
    $('#inputBuscadorCodBarras').val('');
    ListarGestionCompras(par = "NORMAL");
});

$('#cboPorVencimiento').on('change', function () {

    $('.div_spanProItem').hide();
    $(".form-editar").hide();
    $(".form-listado").show();
    $('#inputBuscarPorTexto').val('');
    $('#inputBuscadorCodBarras').val('');
    ListarGestionCompras(par = "NORMAL");
});

$('#cboPorCategoria').on('change', function () {

    $('.div_spanProItem').hide();
    $(".form-editar").hide();
    $(".form-listado").show();
    $('#inputBuscarPorTexto').val('');
    $('#inputBuscadorCodBarras').val('');
    ListarGestionCompras(par = "NORMAL");
});

//SOLO LIMPIA
$("#inputBuscarPorTexto").on("click", function () {

    $('.div_spanProItem').hide(); 
    $(".form-editar").hide();
    $(".form-listado").show();

});


/*************************************************************************************
    CARGAR COMPRA PARA EDITAR
 **************************************************************************************/
var _varTablaList_Compras;
let data_compras = [];
function ListarGestionCompras( par = "NORMAL" ) {

    blockLoader();
    //var strCodigoBarras_    = $.trim($('#inputBuscadorCodBarras').val());
    //var intIdMarcaProducto_ = $('#cboPorMarca').val();
    //var strVencimiento_     = $('#cboPorVencimiento').val();
    //var intIdCategoria_ = $('#cboPorCategoria').val();
    var strCodigoBarras_    = "";
    var intIdMarcaProducto_ = 0;
    var strVencimiento_     = 0;
    var intIdCategoria_     = 0;


    if (par == "NORMAL") {
        strCodigoBarras_    = $.trim($('#inputBuscadorCodBarras').val());
        intIdMarcaProducto_ = $('#cboPorMarca').val();
        strVencimiento_     = $('#cboPorVencimiento').val();
        intIdCategoria_     = $('#cboPorCategoria').val();
    }

    if (par == "RELOAD") {
        //LIMPIAMOS LOS CONTROLES
        $('#cboPorMarca').val('0');
        $('#cboPorCategoria').val('0');
        $('#inputBuscadorCodBarras').val('');
        $('#inputBuscarPorTexto').val('');
        $('.div_spanProItem').hide();
        strCodigoBarras_ = "";
        intIdMarcaProducto_ = 0;
        strVencimiento_ = 0;
        intIdCategoria_ = 0;
    }

    $('.titulo-form-left').html("Producto Asociado a Ingreso de Compra"); 
    $('.titulo-form-left-02').html("");
    $('.titulo-form-left-02').html("Información de Producto a Realizar un Nuevo Ingreso de Compra.");
    $('.titulo-form-rigth').html("");

    $.post(
        '/Procesos/ListarComprasGesCom',
        {
              strCodigoBarras : strCodigoBarras_//7898604433248
            , intIdCategoria  : intIdCategoria_
            , strVencimiento  : strVencimiento_
            , intIdMarcaProducto: intIdMarcaProducto_
            //intResult: "1",
            //strMsjDB: "1",
            //strMsjUsuario: "1",
            //sinparametros
        },
        response => {

            data_compras = response;

            $("#inputBuscadorCodBarras").val('');

            //alert('respuesta exitosa del POST: 7898604433248');
            //DECLARAMOS UNA VARIBLE E INICIALIZAMOS LA TABLA
            if (typeof _varTablaList_Compras !== 'undefined') { _varTablaList_Compras.destroy(); }
            //$('#tabla_gestion_productos').DataTable();

            _varTablaList_Compras = $('#tabla-gestion-compras').DataTable({

                data: data_compras,
                //sDom: "rtipl", //Esconder Search para Filtrar
                //"bFilter": "false",
                //"bSearchable": true,
                //"bVisible": false,
                columns:
                    [

                        { data: 'intIdCompra' },
    
                        {
                            data: 'strCodigoCompra',
                            "render": (data, type, item, meta) => {      

                                return `<span  style  = "color:#337ab7; white-space: nowrap; font-weight: 800; width: 99%;text-align: justify; padding:0px 15px 0px 20px;" 
                                               >` + data + `</span>`;

                            }
                        }, 

                        //{ data: 'intIdProducto' },
                        { data: 'strCodigoBarras' },
                        { data: 'strCodigoProducto' },
                        { data: 'decCostoUnitCompra' },
                        { data: 'intCantIngresada' },
                        { data: 'decMontoTotCompra' },
                        { data: 'strDescMarcaProd' },
                        { data: 'dttFechaIngreso' },


                        /*
                        {
                            data: 'intCantTotalActual',
                            "render": (data, type, item, meta) => {

                                //let data_ = data;

                                // return `<span
                                //  style  = "color:red;white-space: nowrap; width: 99%;text-align: justify; padding:11px 15px 11px 15px;" 
                                //>` + data_ + `</span>`;

                                if (data == 0) {


                                    return `<span  style  = "color:red; white-space: nowrap; width: 99%;text-align: justify; padding:0px 15px 0px 20px;" 
                                               >` + data + `</span>`;


                                }
                                else {
                                    return `<span  style  = "white-space: nowrap; width: 99%;text-align: justify; padding:0px 15px 0px 20px;" >` + data + `</span>`;
                                }


                            }
                        },

                        


                        { data: 'decMontoProducto' },
                        {
                            data: 'strRutaImagenMarca',
                            render: function (data, type, row) {

                                return '<img src="' + data + '" style="height:42px;width:140px;" />';

                                //return '<img src="' + data + '" />';
                                //return '<span>PERU<span/>';
                                //return '<img src="' + data + '" />';
                                //return '<img src="/images/marcas/marca_healthy_miau.png" style="height:45px;width:140px;" />';
                                //return '<img src="http://www.dvd-ppt-slideshow.com/images/ppt-background/background-1.gif" />';
                                //<img src="" />
                                //<img src="~/images/productos/P0010.jpg" />
                                //<img src="/images/marcas/marca_klinKat.jpg" />
                                //<img src="~/images/marcas/marca_healthy_miau.png" />
                            }
                        },



                       */

                        {
                            sortable: false,
                            "render": (data, type, item, meta) => {
                                let intIdComp = item.intIdCompra;
                                //let strDesEmp = item.strDesEmp;
                                return `<button class="btn btn-success btn-xs btn-mostrar d-flex" dataid="${intIdComp}" ><i class="fa fa-eye"></i></button>` +
                                       `<button class="btn btn-success btn-xs btn-edit-compra d-flex" dataid="${intIdComp}" ><i class="fa fa-pencil"></i>Editar</button>` +
                                       `<button class="btn btn-success btn-xs btn-ingreso d-flex" dataid="${intIdComp}" hidden><i class="fa fa-plus"></i></button>`;
                            }

                        }
                        //{
                        //        sortable: false,
                        //        "render": (data, type, item, meta) => {
                        //            let intIdintIdProducto_ = item.intIdProducto;
                        //             return `<button
                        //                    class="btn btn-success btn-xs btn-edit"
                        //                    dataidServ="${intIdintIdProducto_}"
                        //                    id="${intIdintIdProducto_}"><i class="fa fa-pencil"></i>EDITAR</button> `
                        //        }
                        //  },
                        //onclick = 'botonSeleccionar(this,"${intIdintIdProducto_}")

                        //{ data: 'intIdEntrada' },
                        //{ data: 'strCodigo'    },
                        //{ data: 'strProducto' },
                        //{ data: 'strMarca'    },
                        //{ data: 'decPrecUnit' },
                        //{ data: 'decPrecVenta' },
                        //{ data: 'intCantidad' },
                        //{ data: 'decPrecCosto' },
                        //{ data: 'decMonto' },
                        //{ data: 'dttFechIngre' },
                        //////////{
                        //////////    sortable: false,
                        //////////    "render": (data, type, item, meta) => {
                        //////////        let intIdServicio_ = item.id;
                        //////////        let intIdTipServ_ = item.edad;
                        //////////        let intIdTipoMenu_ = item.pais;
                        //////////        let id_intIdServicio = item.id;
                        //////////        return `<button
                        //////////                class="btn btn-success btn-xs btn-edit"
                        //////////                dataidServ="${intIdServicio_}"
                        //////////                id="${id_intIdServicio}"
                        //////////                onclick='botonSeleccionar(this,"${intIdServicio_}")
                        //////////                <i class="fa fa-pencil"></i> SELECCIONAR </button>  `
                        //////////            + `<button
                        //////////                 class="btn btn-success btn-xs btn-delete"
                        //////////                 onclick='botonAnular(this,"${intIdServicio_}")' style="display:none">
                        //////////                 <i class="fa fa-trash-o"></i> ANULAR </button>`;
                        //////////    }
                        //////////},
                        //////////{ data: 'contaddor' },

                    ],

                //onclick='botonSeleccionar(this,"${intIdServicio_}")
                order: [[1, 'desc']], //Las columans comienzan contandose de cero
                columnDefs: [ //ocultar y definir columnas
                    {
                        targets: [2],
                        visible: false,
                        searchable: true
                    },
                    {
                        targets: [9],
                        visible: true,
                        searchable: true,
                        width: "9%", //setear o determinar el ancho de la columna en porcentaje
                        className: "text-center" //centar contenido o elementos de la columna
                    },
                    { bFilter: false, bInfo: false }

                ],

                dom: 'lBfrtip',


            });


            //https://datatables.net/examples/basic_init/dom.html
            //<p>
            //    <input type="text" id="mySearchText" placeholder="Search...">
            //        <button id="mySearchButton">Search</button>
            //</p>
            //$('#mySearchButton').on('keyup click', function () {
            //    _varTablaList_Productos.search($('#mySearchText').val()).draw();
            //});

            //BUSCADOR DESDE UNIMPUT HTML QUE APUNTA AL SEARCH DEL DATATABLE(no filtra anivel sql)
            $('#inputBuscarPorTexto').keyup(function () {

                $('.div_spanProItem').hide();
                _varTablaList_Compras.search($('#inputBuscarPorTexto').val()).draw();

            });

            //https://stackoverflow.com/questions/33236095/how-to-enable-search-for-hidden-column-in-datatable
            //Busca por una especifica columna
            /* $("#tabla_gestion_productos").DataTable().column(0).data().search();*///"example"
            //$("#tbl-data_filter").hide();//.input-sm
            $("#tabla-gestion-compras_filter").hide();            
            unBlockLoader();

        });

}


$('#tabla-gestion-compras  tbody').on('click', 'tr button.btn-mostrar', function () {

    let compra_id = $(this).attr("dataid");
    if (!isNaN(compra_id)) {
        CargarCompraParaMostrar(compra_id);
        let_intIdCompraGesCom = compra_id; //Mantener en esta variable el ID

    }

});



let let_intIdCompraGesCom;
//BOTON EDITAR REGISTRO DEL LISTADO - EDITAR COMPRA
$('#tabla-gestion-compras  tbody').on('click', 'tr button.btn-edit-compra', function () {

    let compra_id = $(this).attr("dataid");
    if (!isNaN(compra_id)) {
        CargarCompraParaEditar(compra_id);
        let_intIdCompraGesCom = compra_id; //Mantener en esta variable el ID

    }

});


//BOTON EDITAR CON FUNCION CARGAR COMPRAS --> Cargar Producto por PK a formulario de inputs dinámicos 
function CargarCompraParaEditar(intIdCompra_) {

    $('.btnGuardar').hide();    
    $('.btnActualizar').show();
    $('.x_panel_filtros').hide();
    $('#val_dttFechaIngreso').attr("type", "date");
    $('#val_dttFechaIngreso').val("");
    $('#val_dttFechaVencimiento').attr("type", "date");
    $('#val_dttFechaVencimiento').val("");
    $('.titulo-form-left').html("Producto Asociado a Ingreso de Compra.");
    $('.titulo-form-left-02').html("(*) Los datos resaltados en azul no son modificables.");
    $('.titulo-form-rigth').html("Ingreso de Compra a Editar");


    //////////////////////////////////////////////////////////////
    //REGISTRO PK PRODUCTOS PK
    //////////////////////////////////////////////////////////////
    $.post(
        '/Procesos/ObtenerCompraPorPkEditarGesCom',
        { intIdCompra: intIdCompra_ },
        (response) => {

            console.log(response);
            response.forEach(element => {

                $('.backgroundLayerOpaque').hide();
                $('#divCodbar').removeClass("divCodbar"); 
                $('body').css('overflow', 'scroll'); /* Show scrollbars */
                $('#inputCapturarCodigoBarras').addClass("CodbarInputDefault"); 
                let_intIdProductoGesCom = element.intIdProducto; 
                let_intIdCompraGesCom = element.intIdCompra;
                $("#val_strCodigoProducto").val(element.strCodigoProducto);
                //$("#val_strCodigoBarras").val(element.strCodigoBarras);
                $("#val_strDescProducto").val(element.strDescProducto);
                //$("#val_strPresentacion").val(element.strPresentacion);
                $("#val_decPrecioDeVenta").val(element.decPrecioDeVenta);
                $("#val_intCantTotalActual").val(element.intStockPrevio);
                //$("#val_intCantTotalActual").val(element.intCantTotalActual);
                //$("#val_strInfoAdicionalProd").val(element.strInfoAdicionalProd);
                //$('#val_strRutaImagenProducto').val(element.strRutaImagenProducto);
                //$('#val_decPorcentajeDescto').val(element.decPorcentajeDescto);
                $('#val_decMontoProducto').val(element.decMontoProducto);
                $('#val_strDescProducto').css('color', '#3d83ed');
                $('#val_strCodigoProducto').css('color', '#272727');//COLOR NEGRO
                $('#val_decPrecioDeVenta').css('color', '#3d83ed');
                $('#val_intCantTotalActual').css('color', '#3d83ed');
                $('.inptBuscPorCodBarDigitado').show();
                //$("#imagenProducto").attr("src", element.strRutaImagenProducto);
                $("#imagenProducto").attr("src", "/images/sistema/logo-prod-box.png");              
                //alert((parseFloat(element.decCostoUnitCompra)).toFixed(2));  // PARSEO CORRECTO  : Un decimal del sql hasta un input html
                //SEGUNDO FORMULARIOO
                $('#val_strCodigoCompra').val(element.strCodigoCompra);   
                $('#val_decCostoUnitCompra').val((parseFloat(element.decCostoUnitCompra)).toFixed(2));   
                $('#val_intCantIngresada').val(element.intCantIngresada);
                //CALCULAR COSTO TOTAL  
                $('#val_decMontoTotCompra').val((parseFloat(element.decCostoUnitCompra * element.intCantIngresada)).toFixed(2));
                $('#txt_spanCantIngresar').html("Cantidad Ingresada");  
                $('#val_strNumDocCompra').val(element.strNumDocCompra);

                //FECHA DE INGRESO
                if (element.dttFechaIngreso == null || element.dttFechaIngreso == "") {

                    $('#val_dttFechaIngreso').attr("type", "date");
                    $('#val_dttFechaIngreso').val(today);

                }
                else {

                    $('#val_dttFechaIngreso').attr("type", "date");
                    $("#val_dttFechaIngreso").val(element.dttFechaIngreso);

                }

                //FECHA VENCIMIENTO
                if (element.dttFechaVencimiento == null || element.dttFechaVencimiento == "") {

                    $('#val_dttFechaVencimiento').attr("type", "text");
                    $('#val_dttFechaVencimiento').val("");
                    $('#chck_dttFechaVencimiento').prop('checked', false);
                    $('#divDttFechaVencimiento').hide();

                }
                else {

                    $('#val_dttFechaVencimiento').attr("type", "date");
                    $("#val_dttFechaVencimiento").val(element.dttFechaVencimiento);
                    $('#chck_dttFechaVencimiento').prop('checked', true);
                    $('#divDttFechaVencimiento').show();

                }

                //PROVEEDOR
                if (element.strDesProveedor == null || element.strDesProveedor == "") {

                    $('#val_strDesProveedor').val("");
                    $('#chck_strDesProveedor').prop('checked', false);
                    $('#divStrDesProveedor').hide();

                }
                else {

                    $("#val_strDesProveedor").val(element.strDesProveedor);
                    $('#chck_strDesProveedor').prop('checked', true);
                    $('#divStrDesProveedor').show();

                }            

                //alert( 'FROM BD: ' + element.dttFechaIngreso + '  ---  FROM JS HOY: ' + today);

                
                /********************************************************************************************************
                //LLENAR COMBO MARCA
                $.post(
                    '/Procesos/ListarCombosGestionar',
                    {
                        strNomTablaEntidad: 'COMBO_MARCAS', intParametroEntero: 0
                    },
                    response => {
                        $('#val_intIdMarcaProducto').empty();
                        response.forEach(element => {
                            $('#val_intIdMarcaProducto').append('<option value="' + element.intIdEntidad + '">' + element.strDescEntidad + '</option>');
                        });
                        $("#val_intIdMarcaProducto").val(element.intIdMarcaProducto);
                        if ($('#val_intIdMarcaProducto option:selected').val() != 1) {
                            $('#textCboMarca').css("font-size", "18px");
                            $('#textCboMarca').css("color", "#CDCBCB");
                        }
                        else {
                            $('#textCboMarca').css("font-size", "22px");
                            $('#textCboMarca').css("color", "#A8A7A7");
                        }

                    });

               *************************************************************************************************** */

                $('.form-nuevo-producto').show();
                $('.form-listado-producto').hide();
                $("#inputCapturarCodigoBarras").focus();
                window.scrollTo(0, 0);

            });

        });

}



//CERRAR MOSTRA DETALLES
$("#btn_mostrar_detalle").on("click", function () {

    $('.div_mostrar_detalle').hide(); 
    $('.backgroundLayerOpaque').hide();
    $('body').css('overflow', 'scroll'); /* Show scrollbars */

});

//BOTON OJITO PARA MOSTRAR DETALLES DE COMPRA
function CargarCompraParaMostrar(intIdCompra_) {


    //////////////////////////////////////////////////////////////
    //REGISTRO PK PRODUCTOS PK
    //////////////////////////////////////////////////////////////
    $.post(
        '/Procesos/ObtenerCompraPorPkEditarGesCom',
        { intIdCompra: intIdCompra_ },
        (response) => {

            console.log(response);
            response.forEach(element => {
                
                $("#vr_strDescProducto").html(element.strDescProducto);
                $("#vr_strCodigoCompra").html(element.strCodigoCompra);
                $("#vr_strCodigoProducto").html(element.strCodigoProducto);
                $("#vr_intStockPrevio").html(element.intStockPrevio);
                $("#vr_intCantIngresada").html(element.intCantIngresada);
                $("#vr_decMontoTotCompra").html(parseFloat(element.decMontoTotCompra).toFixed(2));
                $("#vr_decCostoUnitCompra").html(parseFloat(element.decCostoUnitCompra).toFixed(2));
                $("#vr_dttFechaIngreso").html(element.dttFechaIngreso);
                $("#vr_dttFechaVencimiento").html(element.dttFechaVencimiento);
                $("#vr_strNumDocCompra").html(element.strNumDocCompra);
                $("#vr_strDesProveedor").html(element.strDesProveedor);
                $('#div_mostrar_detalle').show();
                $('.backgroundLayerOpaque').show();
                $('body').css('overflow', 'hidden'); /* Hide scrollbars */

                ////////////$('#divCodbar').removeClass("divCodbar");
                ////////////$('#inputCapturarCodigoBarras').addClass("CodbarInputDefault");
                ////////////let_intIdProductoGesCom = element.intIdProducto; ///9999999
                
                window.scrollTo(0, 0);

            });

        });

}


/////////////////////////////////////////////////////////////////////////////////
// CLICK CON BOTON ENTER 
/////////////////////////////////////////////////////////////////////////////////
var inputdcb = document.getElementById("inputDigitarCodigoBarras");
var inputdid = document.getElementById("inputIngresarIdProducto");
var trueFalseSwal = false; //Para verificar si existe un mensaje Swal abierto

if (inputdcb !== "") {

    inputdcb.addEventListener("keyup", function (event) {


        if (trueFalseSwal == false) {

            // Number 13 is the "Enter" key on the keyboard
            if (event.keyCode === 13) {
                // Cancel the default action, if needed
                event.preventDefault();
                //AÑADIDO UN IF HGM PARA CONTROLAR EL VACIO DEL INPUT
                if ($("#inputDigitarCodigoBarras").val() !== "") {
                    // Trigger the button element with a click
                    document.getElementById("btnBuscarPorCodigoBarrasDigitado").click();
                    trueFalseSwal = true;
                }
                else {

                    swal("Buscar Producto", "Digite un Código de Barras para Iniciar Búsqueda.");
                    trueFalseSwal = true;
                }
            }

        }
        /////////////////////////////////////
        else {

            trueFalseSwal = false;

        }

    });

}

if (inputdid !== "") {

    inputdid.addEventListener("keyup", function (event) {

        if (trueFalseSwal == false) {

            // Number 13 is the "Enter" key on the keyboard
            if (event.keyCode === 13) {
                // Cancel the default action, if needed
                event.preventDefault();
                //AÑADIDO UN IF HGM PARA CONTROLAR EL VACIO DEL INPUT
                if ($("#inputIngresarIdProducto").val() !== "") {
                    // Trigger the button element with a click
                    document.getElementById("btnBuscarPorIdDeProductoGesCom").click();
                    trueFalseSwal = true;
                }
                else {

                    swal("Buscar Producto", "Ingrese un Número de ITEM para Iniciar Búsqueda.");
                    trueFalseSwal = true;

                }

            }


        }

        else {

            trueFalseSwal = false;
            //alert(trueFalse)
        }

    });

}

/////////////////////////////////////////////////////////////////////////////////
//INTERCALAR LOS 02 INPUTS DE BUSCAR(Limpia los demás al clickear en uno)
/////////////////////////////////////////////////////////////////////////////////
$("#inputDigitarCodigoBarras").on("click", function () {
    $("#inputIngresarIdProducto").val('');
});

$("#inputIngresarIdProducto").on("click", function () {
    $("#inputDigitarCodigoBarras").val('');
});

/////////////////////////////////////////////////////////////////////////////////
//ONCHAGNE FECHA DE VENCIMIENTO
/////////////////////////////////////////////////////////////////////////////////
$('#chck_dttFechaVencimiento').on('change', function () {

    if ($('#chck_dttFechaVencimiento').is(':checked')) {

        $('#val_dttFechaVencimiento').attr("type", "date");
        $('#val_dttFechaVencimiento').val(today);
        //$('#lbl_vencimiento').html("Con Vencimiento");        
        $('#divDttFechaVencimiento').show();

    }
    else {

        $('#val_dttFechaVencimiento').attr("type", "text");
        $('#val_dttFechaVencimiento').val("");
        //$('#lbl_vencimiento').html("Sin Vencimiento");
        $('#divDttFechaVencimiento').hide();
        

    }
});

/////////////////////////////////////////////////////////////////////////////////
//ONCHAGNE PROVEEDOR
/////////////////////////////////////////////////////////////////////////////////
$('#chck_strDesProveedor').on('change', function () {

    if ($('#chck_strDesProveedor').is(':checked')) {  

        //$('#lbl_vencimiento').html("Con Vencimiento");        
        $('#val_strDesProveedor').val("Desconocido");
        $('#divStrDesProveedor').show();

    }
    else {

        $('#divStrDesProveedor').hide();
        $('#val_strDesProveedor').val("");


    }
});

let let_intIdProductoGesCom;
/////////////////////////////////////////////////////////////////////////////////
//INPUT BUSCAR PRODUCTO POR ID INGRESADO MANUALMENTE - CON SU RESPECTVA LUPA
/////////////////////////////////////////////////////////////////////////////////
$('#btnBuscarPorIdDeProductoGesCom').on('click', function () {
    //alert(34443)
    //POR ID
    var id_ingresado = $('#inputIngresarIdProducto').val();

    if (id_ingresado == "") {
        id_ingresado = "0";

        swal("Buscar Producto", "Tiene que Ingresar un Número de Item Para Buscar Producto.",
            //{
            //    allowOutsideClick: false,
            //    type: 'info',
            //},
        );
        return false;
    }


    //INICIAMOS EL LOADER
    //blockLoader();  hgm12.01.22
    chanchito();

    //POR CODIGO DE BARRAS
    var strCodigoBarras_ = $('#inputDigitarCodigoBarras').val();
    if (strCodigoBarras_ == "") { strCodigoBarras_ = "0"; }

    $('#contenedor_imagen_producto').append('');

    $.post(
        '/Procesos/ObtenerProductoPorPkGesCom',
        {
              intIdProducto: parseInt(id_ingresado)
            , strCodigoBarras: strCodigoBarras_

        },
        response => {

            data_entradas = response;

            ////alert('PRODUCTO ---> ' + data_entradas[0].strDesProducto + '\n' +
            ////      'MARCA ------> ' + data_entradas[0].strMarcaProd);
            if (response.length > 0) {

                ////////LIMPIAMOS EL ARREGLO A LLENAR(siempre mantendrá un solo registro)
                //////productoEscaneadoByPk = [];

                response.forEach(element => {

                    //alert(response.length);
                    $('#val_strDescProducto').val(element.strDescProducto);
                    $('#val_strCodigoProducto').val(element.strCodigoProducto);
                    $('#val_decPrecioDeVenta').val(element.decPrecioDeVenta);
                    $('#val_intCantTotalActual').val(element.intCantTotalActual);
                    let_intIdProductoGesCom = element.intIdProducto;
                    //$('.titulo-form-left-02').html("Los siguientes datos consultados no son modificables.");
                    $('.titulo-form-left-02').html("(*) Los datos resaltados en azul no son modificables.");
                    $('#inputIngresarIdProducto').val("");
                    $('#inputBuscadorCodBarras').val("");
                    //$('#lbl_vencimiento').html("Con Vencimiento");
                    //alert(element.decPriceBefore);
                    //$('#val_dttFechaIngreso').val(element.dttFechaIngreso);
                    //$('#val_strDescProducto').css('color', '#b0b1ba');
                    //$('#val_strCodigoProducto').css('color', '#b0b1ba');
                    //$('#val_decPrecioDeVenta').css('color', '#b0b1ba');
                    //$('#val_intCantTotalActual').css('color', '#b0b1ba');
                    $('#val_strDescProducto').css('color', '#3d83ed');
                    $('#val_strCodigoProducto').css('color', '#272727');
                    $('#val_decPrecioDeVenta').css('color', '#3d83ed');
                    $('#val_intCantTotalActual').css('color', '#3d83ed');
                    $('#inputDigitarCodigoBarras').val('');                
                    $("#imagenProducto").attr("src", element.strRutaImagenProducto);

                    ////unBlockLoader(); hgm 12.01.22
                    setTimeout(function () { chanchito(); }, 1200);

                });

            }
            else {

                //unBlockLoader();
                swal("Producto", response.message);
                setTimeout(function () { chanchito(); }, 1200);

                ////// //alert('no hay registro');
                //////swal({
                //////     type: 'Producto',
                //////     //html: 'You entered: <strong>' + response.result + '</strong>'
                ////// });

            }
            $('#btnBuscarPorIdDeProductoGesCom').val('');
        });

});

/////////////////////////////////////////////////////////////////////////////////
//INPUT BUSCAR POR CODIGO BARRA DIGITADO MANUALMENTE - CON SU RESPECTVA LUPA
/////////////////////////////////////////////////////////////////////////////////
$('#btnBuscarPorCodigoBarrasDigitado').on('click', function () {
    //alert(33)
    blockLoader();//INICIAMOS EL LOADER
    //POR ID
    var id_ingresado = $('#inputIngresarIdProducto').val();
    if (id_ingresado == "") { id_ingresado = "0"; }
    //POR CODIGO DE BARRAS
    //var strCodigoBarras_ = $('#inputDigitarCodigoBarras').val();
    var strCodigoBarras_ = $.trim($('#inputDigitarCodigoBarras').val());
    if (strCodigoBarras_ == "") { strCodigoBarras_ = "0"; }
    $('#contenedor_imagen_producto').append('');

    $.post(
        '/Procesos/ObtenerProductoPorPkPntVnt',
        {
              intIdProducto: parseInt(id_ingresado)
            , strCodigoBarras: strCodigoBarras_

        },
        response => {

            data_entradas = response;

            if (response.length > 0) {

                //////LIMPIAMOS EL ARREGLO A LLENAR(siempre mantendrá un solo registro)
                ////productoEscaneadoByPk = [];

                response.forEach(element => {

                    //$('#val_strDescProducto').val(element.strDescProducto);
                    $('#val_strDescProducto').val(element.strDescProducto);
                    $('#val_strCodigoProducto').val(element.strCodigoProducto);
                    $('#val_decPrecioDeVenta').val(element.decPrecioDeVenta);
                    $('#val_intCantTotalActual').val(element.intCantTotalActual);
                    let_intIdProductoGesCom = element.intIdProducto;
                    //$('.titulo-form-left-02').html("Los siguientes datos consultados no son modificables.");
                    $('.titulo-form-left-02').html("(*) Los datos resaltados en azul no son modificables.");
                    $('#inputIngresarIdProducto').val("");
                    $('#chck_dttFechaVencimiento').attr('checked', 'checked');
                    $('#val_strDescProducto').css('color', '#3d83ed');
                    $('#val_strCodigoProducto').css('color', '#272727');
                    $('#val_decPrecioDeVenta').css('color', '#3d83ed');
                    $('#val_intCantTotalActual').css('color', '#3d83ed');
                    $('#inputDigitarCodigoBarras').val('');
                    $("#imagenProducto").attr("src", element.strRutaImagenProducto);

                    /*
                    ////////////////////////////////////////////////////////////////////////////////////////////
                    //$('#contenedor_imagen_producto').html('<img src = ' + '/images/productos/' + element.strCodProducto + '.jpg'
                    //    + ' style="width:290px; height:290px; border-radius:15px; "  />');
                    $("#imagenProducto").attr("src", element.strRutaImagenProducto);
                    //$('#contenedor_codigo_producto').html('<label>' + element.strCodigoProducto + '<label>');
                    $('#contenedor_descripcion_producto').html('<label>' + element.strDescProducto + '<label>');
                    $('#lbl_item_producto').html('<label>' + element.strCodigoProducto + '<label>');
                    $('#contenedor_marca_producto').html('<label>' + element.strMarcaProducto + '<label>');
                    //$('#contenedor_precio_producto').html('<label>' + (element.decPrecioDeVenta).toFixed(2) + '<label>');
                    $('.price').html((element.decPrecioDeVenta).toFixed(2));
                    $('.full-price').html((element.decPrecioDeVenta).toFixed(2));
                    $('.qt').html(1);

                    //INPUT NO VISIBLE
                    $("#inputIntIdProducto").attr("value", element.intIdProducto);

                    if (element.intCantTotalActual > 0) {
                        $('#spanDisponibilidad').html('&nbsp;Disponible');
                        $('#dotDisponibilidad').css('background-color', 'green');
                        $('#spanDisponibilidad').css('color', 'green');
                    }

                    if (element.intCantTotalActual <= 0) {
                        $('#spanDisponibilidad').html('&nbsp;Sin Stock');
                        $('#dotDisponibilidad').css('background-color', 'red');
                        $('#spanDisponibilidad').css('color', 'red');
                    }
                      */


                    /*
                    //INSERTAR DETALL EN DEL PRODUCTO TRAIDO EN EL SGTE ARRAY
                    productoEscaneadoByPk.push({

                        "o_intIdProducto": element.intIdProducto
                        , "o_strCodigoBarr": element.strCodigoBarras
                        , "o_strCodigoProd": element.strCodigoProducto
                        , "o_strDescProduc": element.strDescProducto
                        , "o_strDescMarcaP": element.strMarcaProducto
                        , "o_decPrecioDeVe": (element.decPrecioDeVenta).toFixed(2)
                        , "o_intCantTotalA": element.intCantTotalActual
                        , "o_decMontoProdu": (element.decMontoProductos).toFixed(2)
                        , "o_strRutaImgMar": element.strRutaImagenMarca
                        , "o_strRutaImagen": element.strRutaImagenProducto
                        , "o_strDescCatego": element.strDescCategoria
                        , "o_strPresentaci": element.strPresentacion

                    });

                    */

                    unBlockLoader();

                });

            }
            else {

                unBlockLoader();
                swal("Producto", response.message);
                $('#inputDigitarCodigoBarras').val('');
                ////// //alert('no hay registro');
                //////swal({
                //////     type: 'Producto',
                //////     //html: 'You entered: <strong>' + response.result + '</strong>'
                ////// });

            }
        });

});

$("#inputCapturarCodigoBarras").on("keyup", function (evt) {
    //alert('Valor del input ---> ' + $("#inputCapturarCodigoBarras").val());

    if (evt.keyCode != 13) { //QUE EL KEYUP SEA DIFERENTE AL ENTER

        clearInterval(timer);
        timer = setTimeout(function () {

            //if (trueFalseSwal == false) {

            if ($("#inputCapturarCodigoBarras").val() !== "") {
                /////////////////////////////////////////////////////////////////$.trim('  eliminar  vacios ')//Eliminar espacios en blanco
                buscarCapturaCodigoBarras($.trim($("#inputCapturarCodigoBarras").val()));
                /////////////////////////////////////////////////////////////////
            }
            else {

                swal("Buscar Producto", "Utilce el Lector ZEBRA Para Capturar el Código de Barras del Producto.");

            }

        }, 700);//1 * 1000);


    }

});

/////////////////////////////////////////////////////////////////////////////////
//BUSCAR PRODUCTO Y DETALLE CON CODIGO DE BARRAS CAPTURADO EN INPUT (Automático)
/////////////////////////////////////////////////////////////////////////////////
function buscarCapturaCodigoBarras(strCodigoBarras_) {



    //blockLoader();
    chanchito();

    if (strCodigoBarras_ == "") { strCodigoBarras_ = "0"; }

    $.post(
        '/Procesos/ObtenerProductoPorPkPntVnt',
        {
            intIdProducto: 0// parseInt(id_ingresado)
            , strCodigoBarras: strCodigoBarras_

        },
        response => {
            data_entradas = response;

            //if (response.length > 0) {

            //    alert(response.length)
            //    $('.backgroundLayerOpaque').hide();
            //}

            if (response.length > 0) {


                $('.backgroundLayerOpaque').hide();
                $('#divCodbar').removeClass("divCodbar");
                $('body').css('overflow', 'scroll'); /* Show scrollbars */
                $('#inputCapturarCodigoBarras').addClass("CodbarInputDefault"); 
                //$('#glyphicontent').addClass("glyphicon-fullscreen");
                //$('#glyphicontent').removeClass("glyphicon-remove-circle");
                //$('#divCodbar').removeClass("divCodbar");
                //$('body').css('overflow-y', 'hidden');
                //overflow-y: hidden;
                //$(this).addClass("active");



                //LIMPIAMOS EL ARREGLO A LLENAR(siempre mantendrá un solo registro)
                productoEscaneadoByPk = [];

                response.forEach(element => {

                    //alert(response.length);

                    //$('#val_strDescProducto').val(element.strDescProducto);
                    $('#val_strDescProducto').val(element.strDescProducto);
                    $('#val_strCodigoProducto').val(element.strCodigoProducto);
                    $('#val_decPrecioDeVenta').val(element.decPrecioDeVenta);
                    $('#val_intCantTotalActual').val(element.intCantTotalActual);
                    let_intIdProductoGesCom = element.intIdProducto;
                    //$('.titulo-form-left-02').html("Los siguientes datos consultados no son modificables.");
                    $('.titulo-form-left-02').html("(*) Los datos resaltados en azul no son modificables.");
                    $('#inputIngresarIdProducto').val("");
                    $('#chck_dttFechaVencimiento').attr('checked', 'checked');
                    $('#val_strDescProducto').css('color', '#3d83ed');
                    $('#val_strCodigoProducto').css('color', '#272727');
                    $('#val_decPrecioDeVenta').css('color', '#3d83ed');
                    $('#val_intCantTotalActual').css('color', '#3d83ed');
                    $('#inputDigitarCodigoBarras').val('');
                    $("#imagenProducto").attr("src", element.strRutaImagenProducto);

                    //unBlockLoader();
                    setTimeout(function () { chanchito(); }, 1200);
                    //LIMPIAR INPUT CAPTURAR
                    $("#inputCapturarCodigoBarras").val('');

                });
            }
            else {

                //unBlockLoader();
                setTimeout(function () { chanchito(); }, 1200);
                swal("Producto", response.message);
                $("#inputCapturarCodigoBarras").val('');
            }


        });



}











//SETEAR EL COSTO EN DURO AL REALIZAR UN ONFOCUSOUT
function convertValorCostoUnit() {

    var x = document.getElementById("val_decCostoUnitCompra");
    // var x = document.getElementsByClassName("Descuento");
    if (x.value == "") {
        x.value = "0.00";


        ////--------------------------------------------------------------
        //var xy = document.getElementById("val_decMontoProducto");
        //if (   $('#val_decPrecioDeVenta').val() == ""
        //    || $('#val_decPrecioDeVenta').val() == "0"
        //    || $('#val_decPrecioDeVenta').val() == "0.0"
        //    || $('#val_decPrecioDeVenta').val() == "0.00"
        //    || $('#val_intCantTotalActual').val() == ""
        //    || $('#val_intCantTotalActual').val() == "0") {
        //    xy.value = "0.00";
        //}
        //else {
        //    xy.value = (parseFloat($('#val_decPrecioDeVenta').val() * $('#val_intCantTotalActual').val())).toFixed(2);
        //};
        ////--------------------------------------------------------------


    }
    else {
        x.value = (parseFloat(x.value)).toFixed(2);//para que acepte valores decimales no hay que convertirlo en parrse int
    }

}

//AL REALIZAR UN ONCHANGE EN ESTE INPUT
$('#val_intCantIngresada').on('change', function () {

    var xy = document.getElementById("val_decMontoTotCompra");

    if (   $('#val_decCostoUnitCompra').val() == ""
        || $('#val_decCostoUnitCompra').val() == "0"
        || $('#val_decCostoUnitCompra').val() == "0.0"
        || $('#val_decCostoUnitCompra').val() == "0.00"
        || $('#val_intCantIngresada').val() == ""
        || $('#val_intCantIngresada').val() == "0") {
        //$('#textCboMarca').css("font-size", "18px");
        //$('#textCboMarca').css("color", "#CDCBCB");
        //$('#val_decMontoProducto').val("0.00");

        //if (xy.value == "") {
        xy.value = "0.00";
        //}
        //else {
        //    xy.value = (parseFloat(xy.value)).toFixed(2);//para que acepte valores decimales no hay que convertirlo en parrse int
        //}

    }
    else {
        //$('#textCboMarca').css("font-size", "22px");
        //$('#textCboMarca').css("color", "#A8A7A7");
        xy.value = (parseFloat($('#val_decCostoUnitCompra').val() * $('#val_intCantIngresada').val())).toFixed(2);

        //$('#val_decMontoProducto').val($('#val_decPrecioDeVenta').val() * $('#val_intCantTotalActual').val());
    };

});

//AL REALIZAR UN ONCHANGE EN ESTE INPUT
$('#val_decCostoUnitCompra').on('change', function () {

    var xy = document.getElementById("val_decMontoTotCompra");

    if (   $('#val_decCostoUnitCompra').val() == ""
        || $('#val_decCostoUnitCompra').val() == "0"
        || $('#val_decCostoUnitCompra').val() == "0.0"
        || $('#val_decCostoUnitCompra').val() == "0.00"
        || $('#val_intCantIngresada').val() == ""
        || $('#val_intCantIngresada').val() == "0") {

        //if (xy.value == "") {
        xy.value = "0.00";
        //}
        //else {
        //    xy.value = (parseFloat(xy.value)).toFixed(2);//para que acepte valores decimales no hay que convertirlo en parrse int
        //}
    }
    else {
        xy.value = (parseFloat($('#val_decCostoUnitCompra').val() * $('#val_intCantIngresada').val())).toFixed(2);
    };

});

//AL REALIZAR UN ENTER CON EL KEYWORD EN EL INPUT DE CANTIDAD
$("#val_intCantIngresada").on('keyup', function (e) {

    var xy = document.getElementById("val_decMontoTotCompra");
    if (e.key === 'Enter' || e.keyCode === 13) {
        // Do something

        //--------------------------------------------------------------
        //var xy = document.getElementById("val_decMontoProducto");
        if (   $('#val_decCostoUnitCompra').val() == ""
            || $('#val_decCostoUnitCompra').val() == "0"
            || $('#val_decCostoUnitCompra').val() == "0.0"
            || $('#val_decCostoUnitCompra').val() == "0.00"
            || $('#val_intCantIngresada').val() == ""
            || $('#val_intCantIngresada').val() == "0") {
            xy.value = "0.00";

            //alert(1);
        }
        else {
            xy.value = (parseFloat($('#val_decCostoUnitCompra').val() * $('#val_intCantIngresada').val())).toFixed(2);
            //alert(2);
        };
        //--------------------------------------------------------------

    }


});


//AL REALIZAR UN ENTER CON EL KEYWORD EN EL INPUT "Costo Unitario (S/)"
$("#val_decCostoUnitCompra").on('keyup', function (e) {

    var xy = document.getElementById("val_decMontoTotCompra"); //decMontoTotCompra
    var x = document.getElementById("val_decCostoUnitCompra");

    if (e.key === 'Enter' || e.keyCode === 13) {
        // Do something

        //--------------------------------------------------------------
        //var xy = document.getElementById("val_decMontoProducto");
        if (   $('#val_decCostoUnitCompra').val() == ""
            || $('#val_decCostoUnitCompra').val() == "0"
            || $('#val_decCostoUnitCompra').val() == "0.0"
            || $('#val_decCostoUnitCompra').val() == "0.00"
            || $('#val_intCantIngresada').val() == ""
            || $('#val_intCantIngresada').val() == "0") {
            xy.value = "0.00";
            x.value = (parseFloat(x.value)).toFixed(2);
            //alert(1);
        }
        else {            
            x.value = (parseFloat(x.value)).toFixed(2);
            xy.value = (parseFloat($('#val_decCostoUnitCompra').val() * $('#val_intCantIngresada').val())).toFixed(2);
            //alert(2);
        };
        //--------------------------------------------------------------
        //limpiarControlesInsertarProducto

    }


});


//LIMPIAR CONTROLES AL CANCELAR
function limpiarControlesInputsCompra() { 

    $("#inputDigitarCodigoBarras").val('');
    $("#inputIngresarIdProducto").val('');
    $("#val_strCodigoProducto").val('');
    $("#val_strDescProducto").val('');
    $("#val_decPrecioDeVenta").val('');
    $("#val_intCantTotalActual").val('');
    $('.titulo-form-left').html("Información de Producto");
    //$('.titulo-form-left-02').html("Asociar Producto a Nuevo Ingreso de Compra."); //hgmv
    $('.titulo-form-left-02').html(""); //hgmv
    //$('.titulo-form-left-02').html("Consulte el Producto del que desea Realizar un Nuevo Ingreso de Compra.");
    //$('.titulo-form-rigth').html("Ingreso de Nueva Compra");
    $('.titulo-form-rigth').html("Nuevo Ingreso de Compra");
    $("#val_strCodigoCompra").val('');
    $("#val_decMontoTotCompra").val('');
    $('#val_decMontoTotCompra').val("");
    $("#val_decCostoUnitCompra").val('');
    $('#val_decCostoUnitCompra').val("");
    $('#val_intCantIngresada').val("");
    $("#txt_spanCantIngresar").html("Cantidad a Ingresar");
    $('#val_dttFechaIngreso').attr("type", "text");
    $('#val_dttFechaIngreso').val("");
    $('#val_dttFechaVencimiento').attr("type", "text");
    $('#val_dttFechaVencimiento').val("");
    $('#chck_dttFechaVencimiento').prop('checked', false);
    $('#chck_strDesProveedor').prop('checked', false);
    //$('.checkbox').prop('checked', true);
    //$('.checkbox').prop('checked', false);
    $('#divDttFechaVencimiento').hide();
    $('#divStrDesProveedor').hide();
    $("#val_strNumDocCompra").val('');
    $("#lbl_vencimiento").val('');
    $("#val_strDesProveedor").val('');


}


//LIMPIAR CONTROLES (Setear Vaalores) BOTON NUEVO
function setearControlesInsertarNuevaCompra() { //limpiarControlesInsertarProducto

    $("#inputDigitarCodigoBarras").val('');
    $("#inputIngresarIdProducto").val('');
    $("#val_strCodigoProducto").val('');
    $("#val_strDescProducto").val('');
    $("#val_decPrecioDeVenta").val('');
    $("#val_intCantTotalActual").val('');
    //$('.titulo-form-left').html("Producto a Ingresar Compra"); 
    $('.titulo-form-left').html("Producto Asociado a Ingreso de Compra."); 
    //$('.titulo-form-left-02').html("Buscar Producto para Nuevo Ingreso de Compra."); //hgmv
    //$('.titulo-form-rigth').html("Ingreso de Nueva Compra");
    $('.titulo-form-rigth').html("Nuevo Ingreso de Compra");
    $("#val_strCodigoCompra").val('');
    $('#val_decMontoTotCompra').val("0.00");
    $('#val_decCostoUnitCompra').val("0.00");
    $('#val_intCantIngresada').val(0);
    $("#txt_spanCantIngresar").html("Cantidad a Ingresar");
    $('#val_dttFechaIngreso').attr("type", "date");
    $('#val_dttFechaIngreso').val(today);
    $('#val_dttFechaVencimiento').attr("type", "text");
    $('#val_dttFechaVencimiento').val("");
    $('#chck_dttFechaVencimiento').prop('checked', false);
    $('#chck_strDesProveedor').prop('checked', false);
    $('#divDttFechaVencimiento').hide();
    $('#divStrDesProveedor').hide();
    $("#val_strNumDocCompra").val('');
    $("#lbl_vencimiento").val('');
    $("#val_strDesProveedor").val('');


}

$('#tag_remove').on('click', function () {


 

    if ($('.backgroundLayerOpaque').is(":visible") ==  false) {
        // handle non visible state
        //$('#glyphicontent').removeClass("glyphicon-fullscreen");
        //$('#glyphicontent').addClass("glyphicon");
        //$('#glyphicontent').addClass("glyphicon-remove-circle");
        $('.backgroundLayerOpaque').show();
        $('#divCodbar').addClass("divCodbar");
        $('body').css('overflow', 'hidden'); /* Hide scrollbars */
        $('#inputCapturarCodigoBarras').removeClass("CodbarInputDefault");
        $('#inputCapturarCodigoBarras').focus();
    } else {
        // handle visible state
        //$('#glyphicontent').addClass("glyphicon-fullscreen");
        //$('#glyphicontent').removeClass("glyphicon-remove-circle");
        $('.backgroundLayerOpaque').hide();
        $('#divCodbar').removeClass("divCodbar");
        $('body').css('overflow', 'scroll'); /* Show scrollbars */
        $('#inputCapturarCodigoBarras').addClass("CodbarInputDefault");
        $('#inputCapturarCodigoBarras').focus();
    }

    //if ($('.backgroundLayerOpaque').is(":visible") == false) {
    //glyphicontent





}); //5555





//BOTON CANCELAR
$('#btn-cancel-compra').on('click', function () {
    $('body').css('overflow', 'scroll'); /* Show scrollbars */
    limpiarControlesInputsCompra();    
    $('.form-nuevo-producto').hide();
    $('.form-listado-producto').show();
});


//FECHAS JAVASCRIPT
//https://stackoverflow.com/questions/12346381/set-date-in-input-type-date
var now = new Date();
var day = ("0" + now.getDate()).slice(-2);
var month = ("0" + (now.getMonth() + 1)).slice(-2);
var today = now.getFullYear() + "-" + (month) + "-" + (day);
var sinFecha = 1900 + "-" + 12 + "-" + 30;


/* //////////////////////////////////////////////////////////////////////////
 * Registrar un NUEVO INGRESO
 *
 * 
////////////////////////////////////////////////////////////////////////// */
$('#btnRegistrarNuevoIngreso').on('click', function () {  //#btnRegistrarNuevaCompraModal


    $('.backgroundLayerOpaque').show();
    $('#tag_remove').show();
    $('.backgroundLayerOpaque').show();
    $('#divCodbar').addClass("divCodbar");
    $('body').css('overflow', 'hidden'); /* Hide scrollbars */
    $('#inputCapturarCodigoBarras').removeClass("CodbarInputDefault"); //55555 divCodbarInput




    setearControlesInsertarNuevaCompra();
    CombosGestionarProductosNuevo();
    window.scrollTo(0, 0);
    //$('.titulo-form-left').html("Producto a Ingresar Compra");
    $('.titulo-form-left').html("Producto Asociado a Ingreso de Compra"); 
    //$('.titulo-form-left-02').html("Asociar Producto a Nuevo Ingreso de Compra."); //hgmv
    $('.titulo-form-left-02').html(""); //hgmv
    //$('.titulo-form-rigth').html("Ingreso de Nueva Compra");
    $('.titulo-form-rigth').html("Nuevo Ingreso de Compra");
    $('.form-nuevo-producto').show();
    $('.form-listado-producto').hide();
    //$('.guardar-producto').show();
    $('.btnGuardar').show();
    $('.btnActualizar').hide();
    $('.x_panel_filtros').hide();
    $('.inptBuscPorCodBarDigitado').show();
    $('.inptBuscarPorIdCompra').show();
    traerUltimoCodigoDeCompra();
    $("#inputCapturarCodigoBarras").focus();



});


//TRAER ULTIMO_CODIGO_COMPRAS
function traerUltimoCodigoDeCompra() {

    var x = document.getElementById("val_strCodigoCompra");

    if (x.value == "") {
        //Traer el ultimo codigo de Producto
        $.post(
            '/Procesos/ListarCombosGestionar',
            {
                strNomTablaEntidad: 'ULTIMO_CODIGO_COMPRAS', intParametroEntero: 1
            },
            response => {           


                //	COMP00001
                //var intIdeCompra = parseInt(response[0].strDescEntidad) + 1;

                //SUBSTRING A LA PARARA "COMP"
                var strCodigoCompra = (response[0].strDescEntidad).substr(0, 4);
                var strCodigoCompraMasUno = strCodigoCompra + (parseInt((response[0].strDescEntidad).substr(4, 5)) + 1).toString().padStart(5, "0");

                //alert(response[0].strDescEntidad);
                //var intIdeCompraStrCodigoCompra = 
                ////cadena.substr(inicio, cant de caracteres)
                //("COMP00001").substr(4, 5);
                $('#val_strCodigoCompra').val(strCodigoCompraMasUno);
                //$('#val_decCostoUnitCompra').val("0.00");
                //$('#val_intCantIngresada').val(0);
                //$('#val_decMontoTotCompra').val("0.00");
                //$('#val_strNumDocCompra').val("Sin Documento");
                //$('#val_strDesProveedor').val("Desconocido");
                //$('#chck_dttFechaVencimiento').attr('checked', 'checked');
                //$('#lbl_vencimiento').html("Con Vencimiento");
                ////////x.value = "ITEM0" + intIdeCompra.toString().padStart(4, "0");//Setear valor al input ITEM codigo
                //////////var codItem = $('#val_strCodigoProducto').val();
                ////////////$('#val_strRutaImagenProducto').val('/images/productos/' + codItem + '.jpg');
                ////////////$('#val_strCodigoBarras').val('25482450058' + intProducto);
                ////////$('#val_strPresentacion').val('Bolsa 1 Kg.');
                ////////$('#val_strDescProducto').val('Ricocat Gatitos Carne, Pescado y Leche');
                ////////$("#val_decMontoProducto").val('0.00');


            });

    }
    else {
        //$("#val_strCodigoProducto").prop('disabled', true);
    }

}



//////FUNCION NO USADA
////$('#val_strCodigoProducto').on('click', function () {

////           alert(3434343);

////});



/////////////////////////////////////////////////////////////////////////////////
//PERMITIR EN INPUT SOLO NUMEROS - Validación (Desde toma de consumos sisfood)
/////////////////////////////////////////////////////////////////////////////////
function validarInputSoloNumeros(evt) {

    var theEvent = evt || window.event;

    // Handle paste
    if (theEvent.type === 'paste') {
        key = event.clipboardData.getData('text/plain');
        //alert('solo numerso permitidos0');
    } else {
        // Handle key press
        var key = theEvent.keyCode || theEvent.which;
        key = String.fromCharCode(key);
        //alert('solo numerso permitidos1');
    }
    var regex = /[0-9]/;
    //Por cada caracter raro aumentarlo así -- > |\$ o |\Ñ o |\#
    //Para letras y Numeros así ---> /[a-z]|[0-9]|/;
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();

        if (event.keyCode != 13) {
            //alert('Solo ingresar numeros del 1 al 9');
        }

    }
}




////BOTON DE PRUEBA PARA EL LISTADO DE TBBIENEs QUE SE CAE CON 94 registros en el TestClient
//$('#btn_prueba').on('click', function () {



//            alert();

//    //$('#menu_actual_130222').show();
//    $('#menu_actual_130222').hide();


//});
















