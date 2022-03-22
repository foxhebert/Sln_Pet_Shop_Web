/* NUGET: 
 *
 * Este es un script solo para este mantenimiento
 * Cada script js tiene que ir referenciado dentro del html de cada ventana. 
 */

/**
* Hebert Gonzales
* Copyright 2021 Miniasoft Inc.
* http://www.miniasooft.org/licenses/LICENSE-1.0
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
      ListarGestionarProductos();

      //cargarImagenCuandoNoExiste();
      function cargarImagenCuandoNoExiste() {
          $(".poster").attr("src", "/images/productos/item_default.png");
          //$(".posterMarca").attr("src", imagenMarca);
          //$(".poster").show().transition({ x: '0%', opacity: 1.0 });
          //$('.poster').css('transition', 'opacity 5s ease-in-out');
          //$('.poster').fadeIn(2000).show();
      }

     //AÑADIDO EN DURO PARA CADA JS DE CADA VENTANA
     //$('#fx_13_02_22_menu_actual').html('Productos');
     $('#fx_13_02_22_menu_actual').html('PRODUCTOS');

 });


$(document).ready(function () {
    ////var table = $('#tabla_gestion_productos').DataTable();

    ////$('#tabla_gestion_productos tbody')
    ////    .on('mouseenter', 'td', function () {
    ////        var colIdx = table.cell(this).index().column;

    ////        $(table.cells().nodes()).removeClass('highlight');
    ////        $(table.column(colIdx).nodes()).addClass('highlight');
    ////    });
});




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

$('#btnRegistrarNuevoProductoModal').on('click', function () {

    $(".div_intCantTotalActual").hide();
    $(".div_decMontoProducto").hide();
    $('.asideModal').attr('id', 'dapp-popup-wrapper');
    $('.asideModal').show();

});

$('#myModal').on('shown.bs.modal', function () {
    $('#myInput').trigger('focus');
});

 //update - boton guardar nuevo bgp   //NO USADO EN PETSHOPWEB
 $('#btn-guardar-editar').on('click', function () {         

                var _intIdProducto       = parseInt($("#inputHiddenIntIdProducto").val());  
                var _strCodigoBarras     = $("#inputStrCodigoBarras").val();
                var _strCodigoProducto   = $("#inputStrCodigoProducto").val();;
                var _strDescProducto     = '1';
                var _intIdMarcaProducto  = 1;
                var _decPrecioDeVenta    = 10;
                var _intCantTotalActual  = 1;
                var _decMontoProductos  = 1;
                var _strMarcaProducto = '1';
                var _strRutaImagenMarca = '1';
                var _strRutaImagenProducto = '1';
                var _strDescCategoria = '1';
                var _strPresentacion = '1';

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

                                       ListarGestionarProductos();
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
function cargarImagenCuandoNoExiste() {
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




$('#tabla_gestion_productos  tbody').on('click', 'tr button.btn-ver', function () {

     let producto_id = $(this).attr("dataid");
     if (!isNaN(producto_id)) {
         btnVerDetallesProd(producto_id);
     }

});



$('#tabla_gestion_productos  tbody').on('click', 'tr button.btn-ingreso', function () {

    alert('tabla_gestion_productos button.btn-ingreso');
    //$(".form-editar").hide();
    //$(".form-listado").hide();
    let producto_id = $(this).attr("dataid");
    if (!isNaN(producto_id)) {
        btnCargarProductoIngreso(producto_id);
        let_intIdProducto = producto_id; //Mantener en esta variable el ID del producto seleccionado
    }

});


//INGRESAR
$('#tabla_gestion_productos  tbody').on('click', 'tr button.btn-edit', function () {

    //alert('btnVerDetallesProd');
    //$(".form-editar").hide();
    //$(".form-listado").hide();
    let producto_id = $(this).attr("dataid");
    if (!isNaN(producto_id)) {
        btnCargarProductoEditar(producto_id);
        let_intIdProducto = producto_id; //Mantener en esta variable el ID del producto seleccionado
    }

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





$("#inputBuscadorCodBarras").on("click", function () {

    $(".form-editar").hide();
    $(".form-listado").show();
    //Al hacer un click en el "inputBuscadorCodBarras" se limpian los demas controles
    $('#cboPorCategoria').val(0); // $('#cboPorCategoria').val(0).change();
    $('#cboPorMarca').val(0);
    $('#cboPorVencimiento').val(0);
    $('#inputBuscarPorTexto').val('');

});

//FUENTE: https://stackoverflow.com/questions/35905507/how-do-i-execute-a-function-after-5-sec-from-last-keyup
var timer;
$("#inputBuscadorCodBarras").on("keyup", function () {
    //alert("keyup");
    clearInterval(timer);
    timer = setTimeout(function () {
        //$('#tabla_gestion_productos').DataTable();
        //alert('Paso 1 segundos despues del ultimo keyup');
        $('#inputBuscarPorTexto').val('');

        //ESTES TRES SETEOS DE ESOS CONTROLES GENERA UN ONCHAGE QUE GENERA CONFLICTO CON EL IMPUT COD BARRAS Por ello se comenta
        ////$('#cboPorCategoria').val(0).change();
        ////$('#cboPorMarca').val(0);
        ////$('#cboPorVencimiento').val(0);

        ListarGestionarProductos();
        $("#inputBuscadorCodBarras").val('');

    }, 700);//1 * 1000); // era 300 HGM
});


$('#cboPorMarca').on('change', function () {

    $(".form-editar").hide();
    $(".form-listado").show();
    $('#inputBuscarPorTexto').val('');
    $('#inputBuscadorCodBarras').val('');
    ListarGestionarProductos();
});

$('#cboPorVencimiento').on('change', function () {

    $(".form-editar").hide();
    $(".form-listado").show();
    $('#inputBuscarPorTexto').val('');
    $('#inputBuscadorCodBarras').val('');
    ListarGestionarProductos();
});

$('#cboPorCategoria').on('change', function () {

    $(".form-editar").hide();
    $(".form-listado").show();
    $('#inputBuscarPorTexto').val('');
    $('#inputBuscadorCodBarras').val('');
    ListarGestionarProductos();
});

 //$('#inputBuscarPorTexto').focusin(function () {
 //    alert('aler')
 //    //$(this).find("span").css("display", "inline").fadeOut(1000); //https://api.jquery.com/focusin/
 //});

$("#inputBuscarPorTexto").on("click", function () {

    $(".form-editar").hide();
    $(".form-listado").show();
    //$('#inputBuscarPorTexto').val('');
    $('#inputBuscadorCodBarras').val('');
    //$('#cboPorCategoria').val(0).change();
    //$('#cboPorMarca').val(0);
    //$('#cboPorVencimiento').val(0);
    //ListarGestionarProductos();  HGM31

});

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
    CARGAR PRODUCTO LISTADO - MANTENIMIENTO GESTION PRODUCTOS
 **************************************************************************************/
 var _varTablaList_Productos;
 let data_productos = [];
 function ListarGestionarProductos( par = 1 ) {


     blockLoader();

     var strCodigoBarras_    = "";
     var intIdMarcaProducto_ = 0;
     var strVencimiento_     = 0;
     var intIdCategoria_     = 0;


     if (par == 1) {
         //alert("function ListarGestionarProductos(1)");
         strCodigoBarras_    = $.trim($('#inputBuscadorCodBarras').val());
         intIdMarcaProducto_ = $('#cboPorMarca').val();
         strVencimiento_     = $('#cboPorVencimiento').val();
         intIdCategoria_     = $('#cboPorCategoria').val();
     }

     if (par == 2) {
         //LIMPIAMOS LOS CONTROLES
         $('#cboPorMarca').val('0');
         $('#cboPorCategoria').val('0');
         $('#inputBuscadorCodBarras').val('');
         $('#inputBuscarPorTexto').val('');
         strCodigoBarras_ = "";
         intIdMarcaProducto_ = 0;
         strVencimiento_ = 0;
         intIdCategoria_ = 0;
     }


        //alert(strCodigoBarras_);


        $.post(
            '/Procesos/ListarProductosGestPro',
                    {
                          strCodigoBarras: strCodigoBarras_//7898604433248
                        , intIdCategoria: intIdCategoria_
                        , strVencimiento: strVencimiento_
                        , intIdMarcaProducto: intIdMarcaProducto_
                        //intResult: "1",
                        //strMsjDB: "1",
                        //strMsjUsuario: "1",
                        //sinparametros
                    },
            response => {

                        data_productos = response;
                        //alert('respuesta exitosa del POST: 7898604433248');
                        //DECLARAMOS UNA VARIBLE E INICIALIZAMOS LA TABLA
                        if (typeof _varTablaList_Productos !== 'undefined') { _varTablaList_Productos.destroy(); }
                        //$('#tabla_gestion_productos').DataTable();

                _varTablaList_Productos = $('#tabla_gestion_productos').DataTable({

                            data: data_productos,
                            //sDom: "rtipl", //Esconder Search para Filtrar
                            //"bFilter": "false",
                            //"bSearchable": true,
                            //"bVisible": false,
                            columns:
                            [

                                { data: 'intIdProducto' },
                                { data: 'strCodigoBarras' },
                                    //{ data: 'strCodigoProducto' },
                                    //{ data: 'strCodigoProducto' },
                                    {
                                        data: 'strCodigoProducto',
                                        "render": (data, type, item, meta) => {

                                            return `<span  style  = "color:#337ab7; white-space: nowrap; font-weight: 800; width: 99%;text-align: justify; padding:0px 15px 0px 20px;" 
                                               >` + data + `</span>`;

                                        }
                                    }, 

                                { data: 'strDescProducto' },
                                { data: 'strMarcaProducto' },
                                { data: 'decPrecioDeVenta' },

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
                                    //render: function (data, type, row) {
                                   "render": (data, type, item, meta) => {



                                        let strImagen = item.strRutaImagenMarca;

                                        if (data == null || data == "") {

                                            //return '<img src = "/images/marcas/marca_sin_marca.jpg"  style="height:42px;width:140px;"  />';
                                            //return '<img src = "/images/marcas/marca_sin_marca.jpg"  style="height:42px;width:140px;" OnError="setImagenDefaultCuandoNoExiste("' + strImagen + '")" />';
                                            return '<img src = "/images/marcas/marca_sin_marca.jpg"  style="height:42px;width:140px;" />';
                                        }

                                        else {

                                            return '<img src="' + data + '" style="height:42px;width:140px;"  />';
                                            //return '<img src="' + data + '" style="height:42px;width:140px;" OnError="setImagenDefaultCuandoNoExiste("'+ strImagen + '")" />';

                                        }


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

                                {
                                    sortable: false,
                                    "render": (data, type, item, meta) => {
                                        let intIdProducto = item.intIdProducto;
                                        //let strDesEmp = item.strDesEmp;
                                        return `<button class="btn btn-success btn-xs btn-ver d-flex" dataid="${intIdProducto}" hidden><i class="fa fa-eye"></i></button>` +
                                            `<button class="btn btn-success btn-xs btn-edit d-flex" dataid="${intIdProducto}" ><i class="fa fa-pencil"></i>&nbsp;Editar</button>` +
                                               `<button class="btn btn-success btn-xs btn-ingreso d-flex" dataid="${intIdProducto}" hidden><i class="fa fa-plus"></i></button>`;
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
                            order: [[0, 'desc']],//Las columans comienzan contandose de cero
                            columnDefs: [ //ocultar y definir columnas
                                {
                                    targets: [8],
                                    visible: false,
                                    searchable: true
                                 },

                                {
                                    targets: [1],
                                    visible: true,
                                    searchable: true,
                                    width: "100px", //setear el ancho de la columna en px
                                    className: "text-center"
                                },
                                {
                                    targets: [9],
                                    visible: true,
                                    searchable: true,
                                    width: "8%", //setear o determinar el ancho de la columna en porcentaje
                                    className: "text-center" //centar contenido o elementos de la columna
                                },
                                //{ width: "30%", targets: [9] },  //ok
                                { bFilter: false, bInfo: false }

                            ],


                            dom: 'lBfrtip',


                        });







                //var table = ($('#tabla_gestion_productos').DataTable());

                //$('#tabla_gestion_productos tbody')
                //    .on('mouseenter', 'tr', function () {
                //        var colIdx = ($('#tabla_gestion_productos').DataTable()).cell(this).index().column;

                //        $(($('#tabla_gestion_productos').DataTable()).cells().nodes()).removeClass('highlight');
                //        $(($('#tabla_gestion_productos').DataTable()).column(colIdx).nodes()).addClass('highlight');
                //    });


  
            //}



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
                            _varTablaList_Productos.search($('#inputBuscarPorTexto').val()).draw();
                            ////////$('#cboPorCategoria').val(0).change();
                            ////////$('#cboPorMarca').val(0).change();
                            ////////$('#cboPorVencimiento').val(0).change();
                            //$("#tabla_gestion_productos").DataTable().column(0).data($('#inputBuscarPorTexto').val()).search();
                            //if (){
                            //    ListarGestionarProductos();
                            //}
                        });


                        //https://stackoverflow.com/questions/33236095/how-to-enable-search-for-hidden-column-in-datatable
                        //Busca por una especifica columna
                        /* $("#tabla_gestion_productos").DataTable().column(0).data().search();*///"example"
                        //$("#tbl-data_filter").hide();//.input-sm
                $("#tabla_gestion_productos_filter").hide();

                       //$('#inputBuscadorCodBarras').val('');



                 unBlockLoader();


            });
       


 }





//////$('#tabla_gestion_productos tr').hover(function () {
//////    oTable = $('#tabla_gestion_productos').dataTable();
//////    var nNodes = oTable.fnGetNodes();
//////    for (i = 0; i < nNodes.length; i++) {
//////        $(nNodes[i]).removeClass('hoverRowColor');
//////    }

//////    $(this).addClass('hoverRowColor');
//////});

//////$('#tabla_gestion_productos tr').mouseleave(function () {
//////    oTable = $('#tabla_gestion_productos').dataTable();
//////    var nNodes = oTable.fnGetNodes();
//////    for (i = 0; i < nNodes.length; i++) {
//////        $(nNodes[i]).removeClass('hoverRowColor')
//////    }
//////});



            //$('#cboPorMarca').on('change', function () {
            //    alert('cboPorMarca');
            //    //CombosGestionarProductos();
            //});

            //$('#filtroHor').keyup(function () {
            //    validarSession()
            //    TablaHorario();
            //});




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
         , strMarcaProducto : _strMarcaProducto
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

             ListarGestionarProductos();
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



function limpiarControlesInsertarProducto() {

    $(".div_intCantTotalActual").show();
    $(".div_decMontoProducto").show();

    $("#val_intIdProducto").val('');
    $("#val_strCodigoBarras").val('');
    $("#val_strCodigoProducto").val('');
    $("#val_strDescProducto").val('');
    $("#val_intIdMarcaProducto").val('');
    $("#val_decPrecioDeVenta").val('');
    $("#val_intCantTotalActual").val('');
    $("#val_decPorcentajeDescto").val('');
    $("#val_decMontoProducto").val('');
    $("#val_strMarcaProducto").val(1);
    $("#val_strRutaImagenMarca").val('');
    $("#val_strRutaImagenProducto").val('');
    $("#val_strDescCategoria").val('');
    $("#val_strDescCategoria").text(1);
    $("#val_strPresentacion").val('');
    $("#val_strInfoAdicionalProd").val('');
    $("#val_strNombreImagenCargada").val('');
    $('#textCboMarca').css("font-size", "22px");
    $('#textCboMarca').css("color", "#A8A7A7");
    $('#textCboCate').css("font-size", "22px");
    $('#textCboCate').css("color", "#A8A7A7");
    $('#VistaPrevia').html('<img src = "/images/productos/item_default.png" />');

    

}

/* //////////////////////////////////////////////////////////////////////////
 * Registrar un Nuevo Producto
 *
 * 
////////////////////////////////////////////////////////////////////////// */
$('#btnRegistrarNuevoProductoModal').on('click', function () {


    blockLoader();
    //alert();;
    limpiarControlesInsertarProducto();
    CombosGestionarProductosNuevo();
    window.scrollTo(0, 0);
    $('.titulo-form').html("Información de Producto");
    //$('.form-nuevo-producto').show();
    //$('.form-listado-producto').hide();
    $('.guardar-producto').show();
    $('.update-producto').hide();
    $('.x_panel_filtros').hide(); 

    var x = document.getElementById("val_strCodigoProducto");

    if (x.value == "") {
        //Traer el ultimo codigo de Producto
        $.post(
            '/Procesos/ListarCombosGestionar',
            {
                strNomTablaEntidad: 'ULTIMO_CODIGO_PRODUCTO', intParametroEntero: 1
            },
            response => {

                $(".div_intCantTotalActual").hide();
                $(".div_decMontoProducto").hide();

                var intProducto = (response[0].intIdEntidad) + 1;
                x.value = "ITEM0" + intProducto.toString().padStart(4, "0");//Setear valor al input ITEM codigo

                //var codItem = $('#val_strCodigoProducto').val();
                ////$('#val_strRutaImagenProducto').val('/images/productos/' + codItem + '.jpg');
                ////$('#val_strCodigoBarras').val('25482450058' + intProducto);
                //$('#val_strPresentacion').val('Bolsa 1 Kg.');
                //$('#val_strDescProducto').val('Ricocat Gatitos Carne, Pescado y Leche');
                $("#val_decMontoProducto").val('0.00');
                $("#val_intCantTotalActual").val(0);
                //$(".div_intCantTotalActual").hide();
                //$(".div_decMontoProducto").hide();
                //alert();
                $('.form-listado-producto').hide();
                $('.form-nuevo-producto').show();
                unBlockLoader();
            });

    }
    else {
        //$("#val_strCodigoProducto").prop('disabled', true);
    }



});


$('#btn-cancel-producto').on('click', function () {  //HGM22
    limpiarControlesInsertarProducto();
    $('.form-nuevo-producto').hide();
    $('.form-listado-producto').show();
});

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

///////////////////////////////////////////////////////////////////////////////////////////////
//GUARDAR NUEVO PRODUCTO - DESDE CONTROLES DINAMICOS   "bgp  bgnp boton guardar"
///////////////////////////////////////////////////////////////////////////////////////////////
$('#btn-guardar-producto').on('click', function () {

    //$('#btn-guardar-producto, #btn-update-producto').on('click', function () {
    //var idBtnTransaccion = $(".transaccion").attr('id');
    //var intTipoOperacion = 1;
    //if (idBtnTransaccion == 'btn-update-producto') {
    //    alert(idBtnTransaccion);
    //    intTipoOperacion = 2;
    //}
    //alert($('#btn-guardar-producto').attr('id'));
    //alert(this.attr('id'));
    /**En este Proceso de Guardar considerar:
     * 1.- Cambiar el nombre de la imagen seleccionada que ya esta cargada en el Server
     * 2.- Cumplir con las validaciones de regla
     * 3.- 
     * **/
    //como respuesta continuara con el guradado del prodcuto
    //srtDirIpConCsharp = response;
    //alert(srtDirIpConCsharp);  

    
    //var _intIdProducto          = let_intIdProducto;  
    var _strCodigoBarras        = $("#val_strCodigoBarras").val();     //INPUT
    var _strCodigoProducto      = $("#val_strCodigoProducto").val();   //INPUT
    var _strDescProducto        = $("#val_strDescProducto").val();     //INPUT  
    var _intIdMarcaProducto     = $("#val_intIdMarcaProducto").val();  //combo
    var _decPrecioDeVenta       = $("#val_decPrecioDeVenta").val();    //INPUT TEXT   
    var _intCantTotalActual     = $("#val_intCantTotalActual").val();  //INPUT TEXT  
    var _decMontoProductos      = 0; //ENDURO - DESDE ESTE FORMULARIO NO SE ACTUALIZARA EL MONTO 
    var _strMarcaProducto       = $("#val_strMarcaProducto option:selected").text(); //Combo
    var _strRutaImagenMarca     = $("#val_strRutaImagenMarca").val();   //enviar duro
    var _strRutaImagenProducto  = $("#val_strRutaImagenProducto").val();//INPUT 
    var _intIdCategoria         = $("#val_strDescCategoria").val();
    var _strDescCategoria       = $("#val_strDescCategoria option:selected").text();    //COMBO    
    var _strPresentacion        = $("#val_strPresentacion").val();      //INPUT  
    var _strInfoAdicionalProd   = $("#val_strInfoAdicionalProd").val();      //INPUT  
    var _decPorcentajeDescto    = $("#val_decPorcentajeDescto").val();      //INPUT
    var _decMontoProducto       = $("#val_decMontoProducto").val();      //INPUT
    

    if (

           _strDescProducto    == ""
        || _intIdMarcaProducto == ""
        || _decPrecioDeVenta   == ""
        || _intCantTotalActual == ""

    ) {

        //CODIGO DESCRIPCION
        if ($('#val_strDescProducto').val() == '') {
            new PNotify({
                title: 'NUEVO PRODUCTO',
                text: 'Ingresar Descripción de Producto',
                type: 'info',
                delay: 2500,
                styling: 'bootstrap3',
            });
            $('#val_strDescProducto').focus();
            return;
        }
        //PRECIO DE VENTA
        if ($("#val_decPrecioDeVenta").val() == '') {
            new PNotify({
                title: 'NUEVO PRODUCTO',
                text: 'Ingresar Precio de Venta',
                type: 'info',
                delay: 2500,
                styling: 'bootstrap3',
            });
            $('#val_decPrecioDeVenta').focus();
            return;
        }
        //STOCK
        if ($("#val_intCantTotalActual").val() == '') {
            new PNotify({
                title: 'NUEVO PRODUCTO',
                text: 'Ingresar Stock',
                type: 'info',
                delay: 2500,
                styling: 'bootstrap3',
            });
            $('#val_intCantTotalActual').focus();
            return;
        }

    }


    var Producto = {

          intIdProducto         : 1  //AL INSERTAR
        , strCodigoBarras       : _strCodigoBarras
        , strCodigoProducto     : _strCodigoProducto
        , strDescProducto       : _strDescProducto
        , intIdMarcaProducto    : _intIdMarcaProducto
        , decPrecioDeVenta      : _decPrecioDeVenta
        , intCantTotalActual    : _intCantTotalActual
        , decMontoProductos     : _decMontoProductos
        , strMarcaProducto      : _strMarcaProducto
        , strRutaImagenMarca    : _strRutaImagenMarca
        , strRutaImagenProducto : _strRutaImagenProducto
        , intIdCategoria        : _intIdCategoria
        , strDescCategoria      : _strDescCategoria
        , strPresentacion       : _strPresentacion
        , strInfoAdicionalProd  : _strInfoAdicionalProd
        , decPorcentajeDescto   : _decPorcentajeDescto
        , decMontoProducto      : _decMontoProducto

    };


    //alert(nameImagenCargadaLocally)
    //alert( $('#val_strCodigoProducto'))

    //PRIMERO CAMIAMOS EL NOMBRE DE LA IMAGEN RECIENTEMENTE CARGADA LOCAKMENTE
    $.post(
        '/Procesos/ChangeNameImagenProducto',
        {
            initialNameImagen: nameImagenCargadaLocally,  // cate_juguetes.png
            finalNameImagen  : $('#val_strCodigoProducto').val()
        },
        response => {

            nameImagenCargadaLocally = "";

            var SesionMovi = {
                IntIdMenu   : 'M0202',
                intIdUsuario: 1,
                intIdSoft   : 1,
                intIdSesion : 1
            };

            // style="font-weight: bold;"
            //var name = "Stack Overflow";
            //var content = document.createElement('div');
            //content.innerHTML = ;

            $.post(
                '/Procesos/InsertUpdateProductoGestPro', 
                //{ ObjProducto: Producto, objSession: SesionMovi, intTipoOperacion: 8 },
                { ObjProducto: Producto, intTipoOperacion: 1 },
                (response) => {

                    ///////////////////////////////////////////////////
                    console.log(response);
                    var nomMantemiento = "NUEVO PRODUCTO";
                    if (response.type !== '') {

                        if (response.type === 'success') {
                            new PNotify({
                                title: 'NUEVO PRODUCTO',
                                text: response.message,
                                type: response.type,
                                delay: 2500,
                                styling: 'bootstrap3'
                            });

                            ListarGestionarProductos();
                            HideFormEditarAnimation();
                            ShowFormListadoAnimation();
                            limpiarControlesInsertarProducto();
                            $('.form-nuevo-producto').hide();
                            $('.form-listado-producto').show();

                        }
                        else {  //Cuando el codigo ya esta registrado

                            if (response.type === 'error') {

                                INFO_MSJ(nomMantemiento, '', "info", response.message, "");
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

                                    $("#val_strCodigoBarras").focus();
                                    INFO_MSJ(nomMantemiento, '', "info", response.message, "");
                                    return;

                                }

                                else {
                  
                                    INFO_MSJ(nomMantemiento, '', "info", response.message, "");
                                    return;

                                }

                            }


                        }

                    }


                    /////////////////////////////////////////////////






                    //////////swal({
                    //////////    title: 'Editar Producto',
                    //////////    text: 'El código de barras ' + _strCodigoBarras + ' fue grabado \n existosamente' + ' para el item ' + _strCodigoProducto + '.',
                    //////////    // ',//response.message//$('#cbo_formatos option:selected').text() +
                    //////////    //text:  $('#cbo_formatos option:selected').text() + " no existe, por favor crearlo dentro de la carpeta Formatos "+ +" con el mismo nombre seleccionado",
                    //////////    //timer: 2000,
                    //////////    //icon: "success",
                    //////////    //button: "Aww yiss!",
                    //////////});

                    //Swal.fire({
                    //    position: 'top-end',
                    //    icon: 'success',
                    //    title: 'Your work has been saved',
                    //    showConfirmButton: false,
                    //    timer: 1500
                    //})

                    ////swal(_strCodigoProducto , 'El código de barras para este Item ahora es el ' + _strCodigoBarras + '.', "success");
   

                });


        });



});

let let_intIdProducto;
//ACTUALIZAR NUEVO PRODUCTO - DESDE CONTROLES DINAMICOS
$('#btn-update-producto').on('click', function () {

    /**En este Proceso de Guardar considerar:
     * 1.- Cambiar el nombre de la imagen seleccionada que ya esta cargada en el Server
     * 2.- Cumplir con las validaciones de regla
     * 3.- 
     * **/


    var _intIdProducto          = let_intIdProducto; //$("#val_intIdProducto").val();  
    var _strCodigoBarras        = $("#val_strCodigoBarras").val();     //INPUT
    var _strCodigoProducto      = $("#val_strCodigoProducto").val();   //INPUT
    var _strDescProducto        = $("#val_strDescProducto").val();     //INPUT  
    var _intIdMarcaProducto     = $("#val_intIdMarcaProducto").val();  //combo
    var _decPrecioDeVenta       = $("#val_decPrecioDeVenta").val();    //INPUT TEXT   
    var _intCantTotalActual     = $("#val_intCantTotalActual").val();  //INPUT TEXT  
    var _decMontoProducto       = $("#val_decMontoProducto").val(); // DESDE ESTE FORMULARIO tbm SE ACTUALIZARA EL MONTO 
    var _strMarcaProducto       = $("#val_strMarcaProducto option:selected").text(); //Combo
    var _strRutaImagenMarca     = $("#val_strRutaImagenMarca").val();   //enviar duro
    var _strRutaImagenProducto  = $("#val_strRutaImagenProducto").val();//INPUT 
    var _intIdCategoria         = $("#val_strDescCategoria").val();
    var _strDescCategoria       = $("#val_strDescCategoria option:selected").text();    //COMBO    
    var _strPresentacion        = $("#val_strPresentacion").val();      //INPUT  
    var _strInfoAdicionalProd   = $("#val_strInfoAdicionalProd").val();      //INPUT
    var _decPorcentajeDescto    = $("#val_decPorcentajeDescto").val();      //INPUT
    //$('#val_decPorcentajeDescto').val(element.decPorcentajeDescto);



    if (

           _strDescProducto    == ""
        || _intIdMarcaProducto == ""
        || _decPrecioDeVenta   == ""
        || _intCantTotalActual == ""


    ) {


        //CODIGO DESCRIPCION
        if ($('#val_strDescProducto').val() == '') {
            new PNotify({
                title: 'EDITAR PRODUCTO',
                text: 'Ingresar Descripción de Producto',
                type: 'info',
                delay: 2500,
                styling: 'bootstrap3',
            });
            $('#val_strDescProducto').focus();
            return;
        }
        //PRECIO DE VENTA
        if ($("#val_decPrecioDeVenta").val() == '') {
            new PNotify({
                title: 'EDITAR PRODUCTO',
                text: 'Ingresar Precio de Venta',
                type: 'info',
                delay: 2500,
                styling: 'bootstrap3',
            });
            $('#val_decPrecioDeVenta').focus();
            return;
        }
        //STOCK
        if ($("#val_intCantTotalActual").val() == '') {
            new PNotify({
                title: 'EDITAR PRODUCTO',
                text: 'Ingresar Stock',
                type: 'info',
                delay: 2500,
                styling: 'bootstrap3',
            });
            $('#val_intCantTotalActual').focus();
            return;
        }

    }


    var Producto = {

          intIdProducto        : _intIdProducto
        , strCodigoBarras      : _strCodigoBarras
        , strCodigoProducto    : _strCodigoProducto
        , strDescProducto      : _strDescProducto
        , intIdMarcaProducto   : _intIdMarcaProducto
        , decPrecioDeVenta     : _decPrecioDeVenta
        , intCantTotalActual   : _intCantTotalActual
        , decMontoProducto     : _decMontoProducto
        , strMarcaProducto     : _strMarcaProducto
        , strRutaImagenMarca   : _strRutaImagenMarca
        , strRutaImagenProducto: _strRutaImagenProducto
        , intIdCategoria       : _intIdCategoria
        , strDescCategoria     : _strDescCategoria
        , strPresentacion      : _strPresentacion
        , strInfoAdicionalProd : _strInfoAdicionalProd
        , decPorcentajeDescto  : _decPorcentajeDescto

    };


   
    //PRIMERO CAMIAMOS EL NOMBRE DE LA IMAGEN RECIENTEMENTE CARGADA LOCAKMENTE
    $.post(
        '/Procesos/ChangeNameImagenProducto',
        {
            initialNameImagen: nameImagenCargadaLocally,
            finalNameImagen: $('#val_strCodigoProducto').val()
        },
        response => {


            nameImagenCargadaLocally = "";

            var SesionMovi = {
                IntIdMenu: 'M0202',
                intIdUsuario: 1,
                intIdSoft: 1,
                intIdSesion: 1
            };

            // style="font-weight: bold;"
            //var name = "Stack Overflow";
            //var content = document.createElement('div');
            //content.innerHTML = ;

            $.post(
                '/Procesos/InsertUpdateProductoGestPro',
                { ObjProducto: Producto, objSession: SesionMovi, intTipoOperacion: 2 },
                //Esta entrando 3 parametros pero no pasaria nada si en el controlador se recibe solo 2
                //Ademas el orden de los esos parametros no importa
                (response) => {

                    ///////////////////////////////////////////////////
                    console.log(response);
                    var nomMantemiento = 'ACTUALIZAR PRODUCTO';
                  
                    if (response.type !== '') {

                        if (response.type === 'success') {
                            new PNotify({
                                title: 'ACTUALIZAR PRODUCTO',
                                text: response.message,
                                type: response.type,
                                delay: 2500,
                                styling: 'bootstrap3'
                            });

                            ListarGestionarProductos();
                            HideFormEditarAnimation();
                            ShowFormListadoAnimation();
                            limpiarControlesInsertarProducto();
                            $('.form-nuevo-producto').hide();
                            $('.form-listado-producto').show();

                        }

                        else {  //Cuando el codigo ya esta registrado

                            if (response.type === 'error') {

                                //var campo = 'txt_cod_Empresa';
                                //var msj = response.message;
                                //var response = "info";
                                //var deta = 'notifry_error';
                                //Pintar el borde del textbox del error en cuestion (del codigo)
                                ////////document.getElementById("txt_cod_Empresa").style.borderColor = "#3498dbe0";
                                //INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                                //INFO_MSJ(nomMantemiento, campo, response, msj, deta);
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

                        
                                    //var campo = 'txt_desc_Empresa';
                                    //var msj = response.message;
                                    //var response = "info";
                                    //var deta = 'notifry_errordes';
                                    //Pintar el borde del textbox del error en cuestion (la razon social)
                                    ////////document.getElementById("txt_desc_Empresa").style.borderColor = "#3498dbe0";
                                    //INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                                    $("#val_strCodigoBarras").focus();
                                    INFO_MSJ(nomMantemiento, '', "info", response.message, "");

                                    return;
                                }

                                else {
                                 
                                    //var campo = 'txt_Ruc';
                                    //var msj = response.message;
                                    //var response = "info";
                                    //var deta = 'notifry_error_ruc';
                                    //Pintar el borde del textbox del error en cuestion (la razon social)
                                    //////document.getElementById("txt_Ruc").style.borderColor = "#3498dbe0";
                                    //INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                                    INFO_MSJ(nomMantemiento, '', "info", response.message, "");
                                    return;

                                }

                            }


                        }

                    }


                    /////////////////////////////////////////////////

                    ////swal({
                    ////    title: 'Editar Producto',
                    ////    text: 'El código de barras ' + _strCodigoBarras + ' fue grabado \n existosamente' + ' para el item ' + _strCodigoProducto + '.',
                    ////    // ',//response.message//$('#cbo_formatos option:selected').text() +
                    ////    //text:  $('#cbo_formatos option:selected').text() + " no existe, por favor crearlo dentro de la carpeta Formatos "+ +" con el mismo nombre seleccionado",
                    ////    //timer: 2000,
                    ////    //icon: "success",
                    ////    //button: "Aww yiss!",
                    ////});

                    //Swal.fire({
                    //    position: 'top-end',
                    //    icon: 'success',
                    //    title: 'Your work has been saved',
                    //    showConfirmButton: false,
                    //    timer: 1500
                    //})

                    ////swal(_strCodigoProducto , 'El código de barras para este Item ahora es el ' + _strCodigoBarras + '.', "success");



                });



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
                if (height > 900 || width > 900) {
                    //alert("El tamaño debe se de 240px X 240px ");
                    new PNotify({
                        title: 'Imagen',
                        text: 'El tamaño de la imagen no debe ser mayor a 900px X 900px ',
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
// JS DE CONTROLES PARA LOS INPUTS DE REGISTRO DE NUEVO PRODUCTO 
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


//AL REALIZAR UN ENTER CON EL KEYWORD EN EL INPUT DE STOCK
//https://stackoverflow.com/questions/7060750/detect-the-enter-key-in-a-text-input-field
$("#val_intCantTotalActual").on('keyup', function (e) {

    var xy = document.getElementById("val_decMontoProducto");

    if (e.key === 'Enter' || e.keyCode === 13) {
        // Do something

             //--------------------------------------------------------------
            //var xy = document.getElementById("val_decMontoProducto");
            if (   $('#val_decPrecioDeVenta').val() == ""
                || $('#val_decPrecioDeVenta').val() == "0"
                || $('#val_decPrecioDeVenta').val() == "0.0"
                || $('#val_decPrecioDeVenta').val() == "0.00"
                || $('#val_intCantTotalActual').val() == ""
                || $('#val_intCantTotalActual').val() == "0") {
                xy.value = "0.00";

                //alert(1);
            }
            else {
                xy.value = (parseFloat($('#val_decPrecioDeVenta').val() * $('#val_intCantTotalActual').val())).toFixed(2);
                //alert(2);
            };
            //--------------------------------------------------------------

    }


});

//AL REALIZAR UN ENTER CON EL KEYWORD EN EL INPUT 
$("#val_decPrecioDeVenta").on('keyup', function (e) {
    //alert(555)
    var xy = document.getElementById("val_decMontoProducto");
    var x = document.getElementById("val_decPrecioDeVenta");
    //var y = document.getElementById("val_intCantTotalActual");
    if (e.key === 'Enter' || e.keyCode === 13) {
        // Do something

        //--------------------------------------------------------------
        //var xy = document.getElementById("val_decMontoProducto");
        if (   $('#val_decPrecioDeVenta').val() == ""
            || $('#val_decPrecioDeVenta').val() == "0"
            || $('#val_decPrecioDeVenta').val() == "0.0"
            || $('#val_decPrecioDeVenta').val() == "0.00"
            || $('#val_intCantTotalActual').val() == ""
            || $('#val_intCantTotalActual').val() == "0") {
            xy.value = "0.00";
            x.value = (parseFloat(x.value)).toFixed(2);
            //y.value = "0";
            //alert(1);
        }
        else {

            x.value = (parseFloat(x.value)).toFixed(2);
            xy.value = (parseFloat($('#val_decPrecioDeVenta').val() * $('#val_intCantTotalActual').val())).toFixed(2);
            //alert(2);
        };
        //--------------------------------------------------------------

    }


});


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



//Cambiar el tamaño del Texto al realizar un change en el combo MARCA
$('#val_intIdMarcaProducto').on('change', function () {

    if ($('#val_intIdMarcaProducto option:selected').val() != 1) {
        $('#textCboMarca').css("font-size", "18px");
        $('#textCboMarca').css("color", "#CDCBCB");
    }
    else {
        $('#textCboMarca').css("font-size", "22px");
        $('#textCboMarca').css("color", "#A8A7A7");
    };

});

//Cambiar el tamaño del Texto al realizar un change en el combo CATEGORIA
$('#val_strDescCategoria').on('change', function () {

    if ($('#val_strDescCategoria option:selected').val() != 1) {

        $('#textCboCate').css("font-size", "18px");
        $('#textCboCate').css("color", "#CDCBCB");
    }
    else {
        $('#textCboCate').css("font-size", "22px");
        $('#textCboCate').css("color", "#A8A7A7");
    }

});



//AÑADIR MONTO INPUT <input type="text" id="sometext" onfocusout="convertValorPrecio()">
//function aniadirMonto() {
//    var x = document.getElementById("val_decPrecioDeVenta");
//    // var x = document.getElementsByClassName("Descuento");
//    if (x.value == "") {
//        x.value = "0.00";
//    }
//    else {
//        x.value = (parseFloat(x.value)).toFixed(2);//para que acepte valores decimales no hay que convertirlo en parrse int
//    }

//}


$('#val_intCantTotalActual').on('change', function () { 


    var xy = document.getElementById("val_decMontoProducto");

    if (   $('#val_decPrecioDeVenta').val() == ""
        || $('#val_decPrecioDeVenta').val() == "0"
        || $('#val_decPrecioDeVenta').val() == "0.0"
        || $('#val_decPrecioDeVenta').val() == "0.00"
        || $('#val_intCantTotalActual').val() == ""
        || $('#val_intCantTotalActual').val() == "0") {
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
        xy.value = (parseFloat($('#val_decPrecioDeVenta').val() * $('#val_intCantTotalActual').val()   )).toFixed(2);

        //$('#val_decMontoProducto').val($('#val_decPrecioDeVenta').val() * $('#val_intCantTotalActual').val());
    };

});


$('#val_decPrecioDeVenta').on('change', function () {


    var xy = document.getElementById("val_decMontoProducto");

    if (   $('#val_decPrecioDeVenta').val() == ""
        || $('#val_decPrecioDeVenta').val() == "0"
        || $('#val_decPrecioDeVenta').val() == "0.0"
        || $('#val_decPrecioDeVenta').val() == "0.00"
        || $('#val_intCantTotalActual').val() == ""
        || $('#val_intCantTotalActual').val() == "0") {

        //if (xy.value == "") {
            xy.value = "0.00";
        //}
        //else {
        //    xy.value = (parseFloat(xy.value)).toFixed(2);//para que acepte valores decimales no hay que convertirlo en parrse int
        //}
    }
    else {
        xy.value = (parseFloat($('#val_decPrecioDeVenta').val() * $('#val_intCantTotalActual').val())).toFixed(2);
    };

});


function cargarImagenDefaultCuandoNoExiste() {
    $('#VistaPrevia').html('<img src = "/images/productos/image_no_found.png" />');
}

//function setImagenDefaultCuandoNoExiste(strImagen) {
//    alert(); ///2222222
//    $('#' + strImagen + '').html('<img src = "/images/marcas/marca_sin_marca.jpg" />');
//}

//Cargar Productos por PK a formulario de inputs dinámicos para "EDITAR"
function btnCargarProductoEditar(intIdProducto) {

    blockLoader();
    $('.guardar-producto').hide();
    $('.x_panel_filtros').hide();   
 
    //////////////////////////////////////////////////////////////
    //REGISTRO PK PRODUCTOS PK
    //////////////////////////////////////////////////////////////
    $.post(
        '/Procesos/ObtenerProductoPorPkEditarGestPro',
        { intIdProducto: intIdProducto },
        (response) => {

            console.log(response);
            response.forEach(element => {

                $("#val_strCodigoProducto").val(element.strCodigoProducto);
                $("#val_strCodigoBarras").val(element.strCodigoBarras);
                $("#val_strDescProducto").val(element.strDescProducto);
                $("#val_strPresentacion").val(element.strPresentacion);
                $("#val_decPrecioDeVenta").val(element.decPrecioDeVenta);
                $("#val_intCantTotalActual").val(element.intCantTotalActual); 
                $("#val_strInfoAdicionalProd").val(element.strInfoAdicionalProd);
                $('#val_strRutaImagenProducto').val(element.strRutaImagenProducto);
                $('#val_decPorcentajeDescto').val(element.decPorcentajeDescto);
                $('#val_decMontoProducto').val(element.decMontoProducto);

                if (element.strRutaImagenProducto == "" || element.strRutaImagenProducto == null  ) {
                    $('#VistaPrevia').html('<img src = "/images/productos/item_default.png" />');// cmapo imagen null
                }
                else {
                    $('#VistaPrevia').html('<img OnError="cargarImagenDefaultCuandoNoExiste()" src = ' + element.strRutaImagenProducto + ' style="width:50%;" />');
                }
                //$('#VistaPrevia').html('<img src = ' + element.strRutaImagenProducto + ' style="width:100%;height:100%" />');
                //$("#val_strRutaImagenProducto").val("/images/productos/" + $('#val_strCodigoProducto').val() + '.' + extensionImagen);

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

                //LLENAR COMBO CATEGORIA
                $.post(
                    '/Procesos/ListarCombosGestionar',
                    {
                        strNomTablaEntidad: 'COMBO_CATEGORIA', intParametroEntero: 0
                    },
                    response => {
                        $('#val_strDescCategoria').empty();
                        response.forEach(element => {
                            $('#val_strDescCategoria').append('<option value="' + element.intIdEntidad + '">' + element.strDescEntidad + '</option>');
                        });
                        $("#val_strDescCategoria").val(element.intIdCategoria);
                        //$("#val_strCodigoProducto").prop("disabled", true);
                        if ($('#val_strDescCategoria option:selected').val() != 1) {
                            $('#textCboCate').css("font-size", "18px");
                            $('#textCboCate').css("color", "#CDCBCB");
                        }
                        else {
                            $('#textCboCate').css("font-size", "22px");
                            $('#textCboCate').css("color", "#A8A7A7");
                        }
                        $('.form-nuevo-producto').show();
                        $('.form-listado-producto').hide();
                        window.scrollTo(0,0);
                        ////window.scrollTo(xCoord, yCoord);
                        $('.update-producto').show();
                        unBlockLoader();
                    });

                //$('#val_strDescCategoria').on('change', function () {





                //});




                ////var imagenMarca = element.strRutaImagenMarca;
                ////var imagenProducto = element.strRutaImagenProducto;
                ////$(".poster").attr("src", imagenProducto);
                ////$(".posterMarca").attr("src", imagenMarca);
                //////transition: opacity 1s ease-in-out;                        
                ////$("#h1StrDescProducto").text(element.strDescProducto);
                ////$(".txtStrDescCategoria").text(element.strDescCategoria);
                ////$("#inputStrCodigoProducto").val(element.strCodigoProducto);
                ////$("#inputDecPrecioDeVenta").val((element.decPrecioDeVenta).toFixed(2));
                ////$("#h1DecPrecioDeVenta").text((element.decPrecioDeVenta).toFixed(2));

                ////$("#inputHiddenIntIdProducto").val(element.intIdProducto);
                //////CANTIDAD ACTUAL
                ////$("#inputIntCantTotalActual").val(element.intCantTotalActual);
                //////PRESENTACION
                ////$("#inputStrPresentacion").val(element.strPresentacion);
                ////$("#inputStrCodigoBarras").val(element.strCodigoBarras);
                //////$(".form-editar").show();
                ////HideFormListadoAnimation();
                ////ShowFormEditarAnimation();

                /*
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
                */


            });

        });



    //$('.titulo-form').html("Información de Producto");
    //$('.form-nuevo-producto').show();
    //$('.form-listado-producto').hide();
    //$('.guardar-producto').show();
    //$('.update-producto').hide();

}


//Cargar Productos por PK a formulario de inputs dinámicos para "INGRESO"
function btnCargarProductoIngreso(intIdProducto) {

    $('.guardar-producto').hide();
    $('.x_panel_filtros').hide();
    alert()
    //////////////////////////////////////////////////////////////
    //REGISTRO PK PRODUCTOS PK
    //////////////////////////////////////////////////////////////
    $.post(
        '/Procesos/ObtenerProductoPorPkEditarGestPro',
        { intIdProducto: intIdProducto },
        (response) => {

            console.log(response);
            response.forEach(element => {

                $("#val_strCodigoProducto").val(element.strCodigoProducto);
                $("#val_strCodigoBarras").val(element.strCodigoBarras);
                $("#val_strDescProducto").val(element.strDescProducto);
                $("#val_strPresentacion").val(element.strPresentacion);
                $("#val_decPrecioDeVenta").val(element.decPrecioDeVenta);
                $("#val_intCantTotalActual").val(element.intCantTotalActual);
                $("#val_strInfoAdicionalProd").val(element.strInfoAdicionalProd);
                $('#val_strRutaImagenProducto').val(element.strRutaImagenProducto);
                $('#val_decPorcentajeDescto').val(element.decPorcentajeDescto);
                $('#val_decMontoProducto').val(element.decMontoProducto);

                if (element.strRutaImagenProducto == "" || element.strRutaImagenProducto == null) {
                    $('#VistaPrevia').html('<img src = "/images/productos/item_default.png" />');// cmapo imagen null
                }
                else {
                    $('#VistaPrevia').html('<img OnError="cargarImagenDefaultCuandoNoExiste()" src = ' + element.strRutaImagenProducto + ' style="width:50%;" />');
                }
                //$('#VistaPrevia').html('<img src = ' + element.strRutaImagenProducto + ' style="width:100%;height:100%" />');
                //$("#val_strRutaImagenProducto").val("/images/productos/" + $('#val_strCodigoProducto').val() + '.' + extensionImagen);

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

                //LLENAR COMBO CATEGORIA
                $.post(
                    '/Procesos/ListarCombosGestionar',
                    {
                        strNomTablaEntidad: 'COMBO_CATEGORIA', intParametroEntero: 0
                    },
                    response => {
                        $('#val_strDescCategoria').empty();
                        response.forEach(element => {
                            $('#val_strDescCategoria').append('<option value="' + element.intIdEntidad + '">' + element.strDescEntidad + '</option>');
                        });
                        $("#val_strDescCategoria").val(element.intIdCategoria);
                        //$("#val_strCodigoProducto").prop("disabled", true);
                        if ($('#val_strDescCategoria option:selected').val() != 1) {
                            $('#textCboCate').css("font-size", "18px");
                            $('#textCboCate').css("color", "#CDCBCB");
                        }
                        else {
                            $('#textCboCate').css("font-size", "22px");
                            $('#textCboCate').css("color", "#A8A7A7");
                        }
                        $('.form-nuevo-producto').show();
                        $('.form-listado-producto').hide();
                        window.scrollTo(0, 0);
                        ////window.scrollTo(xCoord, yCoord);
                        $('.update-producto').show();
                    });

                //$('#val_strDescCategoria').on('change', function () {





                //});




                ////var imagenMarca = element.strRutaImagenMarca;
                ////var imagenProducto = element.strRutaImagenProducto;
                ////$(".poster").attr("src", imagenProducto);
                ////$(".posterMarca").attr("src", imagenMarca);
                //////transition: opacity 1s ease-in-out;                        
                ////$("#h1StrDescProducto").text(element.strDescProducto);
                ////$(".txtStrDescCategoria").text(element.strDescCategoria);
                ////$("#inputStrCodigoProducto").val(element.strCodigoProducto);
                ////$("#inputDecPrecioDeVenta").val((element.decPrecioDeVenta).toFixed(2));
                ////$("#h1DecPrecioDeVenta").text((element.decPrecioDeVenta).toFixed(2));

                ////$("#inputHiddenIntIdProducto").val(element.intIdProducto);
                //////CANTIDAD ACTUAL
                ////$("#inputIntCantTotalActual").val(element.intCantTotalActual);
                //////PRESENTACION
                ////$("#inputStrPresentacion").val(element.strPresentacion);
                ////$("#inputStrCodigoBarras").val(element.strCodigoBarras);
                //////$(".form-editar").show();
                ////HideFormListadoAnimation();
                ////ShowFormEditarAnimation();

                /*
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
                */


            });

        });



    //$('.titulo-form').html("Información de Producto");
    //$('.form-nuevo-producto').show();
    //$('.form-listado-producto').hide();
    //$('.guardar-producto').show();
    //$('.update-producto').hide();

}










