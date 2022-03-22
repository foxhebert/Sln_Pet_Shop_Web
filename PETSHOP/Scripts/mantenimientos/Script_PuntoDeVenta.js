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

        $('#Capa_1').fadeOut(200);
        $('.pigLoader').fadeOut(200);

        //$('.pigLoader').removeAttr('id');
        //$('#Capa_1').removeAttr('class', 'loader');
        //$('#Capa_1').hide();
        //$('.pigLoader').hide();
    }


}

$(document).ready(function () {

    $('#div_producto_consultado').show();
    //AÑADIDO EN DURO PARA CADA JS DE CADA VENTANA
    //$('#fx_13_02_22_menu_actual').html('Punto de Venta');
    $('#fx_13_02_22_menu_actual').html('PUNTO DE VENTA');
    //        $(".btn-default").on("click", function () {
    //        $(".btn-group").removeClass("open").addClass("open");
    //});
     $("#inputCapturarCodigoBarras").focus();
    //Apenar se abre la ventana el puntero blinker aparece en este campo
     //$("#inputIngresarIdProducto").focus();

     //MOSTRAR EL MENU TOGGLE (tiene que ir en el ready de todos los mantenimientos)
     $('.nav_menu').show();

            //$(".remove").click(function () {
            //    var el = $(this);
            //    el.parent().parent().addClass("removed");
            //    window.setTimeout(
            //        function () {
            //            el.parent().parent().slideUp('fast', function () {
            //                el.parent().parent().remove();
            //                if ($(".product").length == 0) {
            //                    if (check) {
            //                        $("#cart").html("<h1>The shop does not function, yet!</h1><p>If you liked my shopping cart, please take a second and heart this Pen on <a href='https://codepen.io/ziga-miklic/pen/xhpob'>CodePen</a>. Thank you!</p>");
            //                    } else {
            //                        $("#cart").html("<h1>No products!</h1>");
            //                    }
            //                }
            //                changeTotal();
            //            });
            //        }, 200);
            //});

     $(".qt-plus").click(function () {

                $(".qt").html(parseInt($(".qt").html()) + 1);
                //$(this).parent().children(".qt").html(parseInt($(this).parent().children(".qt").html()) + 1);
       

                //$(this).parent().children(".full-price").addClass("added");
                //$(".full-price").addClass("added");

                var el = $(this);
                //window.setTimeout(function () { el.parent().children(".full-price").removeClass("added"); changeVal(el); }, 150);
                window.setTimeout(function () { $(".full-price").removeClass("added"); changeVal(el); }, 150);
            });

     $(".qt-minus").click(function () {

                child = $(".qt");
                //child = $(this).parent().children(".qt");

                if (parseInt(child.html()) > 1) {
                    child.html(parseInt(child.html()) - 1);
                }

                //$(".full-price").addClass("minused");
                //$(this).parent().children(".full-price").addClass("minused");

                var el = $(this);
                window.setTimeout(function () { $(".full-price").removeClass("minused"); changeVal(el); }, 150);
                //window.setTimeout(function () { el.parent().children(".full-price").removeClass("minused"); changeVal(el); }, 150);
            });

     window.setTimeout(function () { $(".is-open").removeClass("is-open") }, 1200);

     $(".btn").click(function () {
         check = true;
         $(".remove").click();
     });
});

 document.getElementById('b3').onclick = function () {
              //$(".sweet-alert").css("background-color", "transparent");
              $(".fix").css("background-color", "transparent");
              // $(".succes").css("background-color","transparent");
              $(".b3").css("background-color", "blue");
              $(".sweet-overlay").css("background-color", "rgba(0, 0, 0, 0.4)");
              // $(".sweet-alert .icon.success:before").css("background-color","transparent");
              // swal({
              //   position: 'top-end',
              //   icon: 'success',
              //   title: 'Your work has been saved',
              //   showConfirmButton: false,
              //   timer: 1500
              // })
              // .sweet-alert .icon.success {
              //     border-color: #A5DC86;
              // }


              //$(".sweet-overlay").show();
              

              swal("Good job!", "Procesado Correctamente!", "success");

              
              $(".sweet-alert p").hide();
              $(".sweet-alert h2").hide();
              $(".sa-fix").hide();
              $(".confirm").hide();
              //$(".sa-button-container").hide();              
              $(".sa-line").css("background-color", "#52e200");
              $(".sa-fix").css("background-color", "transparent");
              $(".sweet-alert .sa-icon.sa-success").css("border-color", "#52e200");
              //$(".sweet-alert").toggleClass('sweet-alert-temporal');
              $(".sweet-alert").css("background-color", "transparent");
              $('.sweet-alert .sa-icon.sa-success').toggleClass('before2');
              $('.sweet-alert .sa-icon.sa-success').toggleClass('after2');
              $(".sweet-alert .sa-icon.success:after").css("background-color","transparent");
              $(".sa-icon").removeClass('animate')


              setTimeout(function () {

                  $(".sa-icon").hide();
                  $(".sweet-alert").hide();
                  $(".sweet-alert p").hide();
                  $(".sweet-alert h2").hide();
                  $(".confirm").hide();
                  $(".sweet-overlay").fadeOut("slow", function () {
                      // Animation complete.
                  });
                  $(".sweet-overlay").hide();
                  $(".sa-icon").removeClass('before2');
                  $(".sa-icon").removeClass('after2');
                  $(".sweet-alert").css("background-color", "#ffffff");
                  $("body").css("overflow-y", "scroll");
                  

                  //$(".sa-button-container").hide();
                      ///* background-color: #ffffff;
                  //$(".sweet-alert").toggleClass('sweet-alert-temporal')

              }, 1400);




          };

document.getElementById('b6').onclick = function () {

    $(".sweet-alert").css("background-color", "blue");
    $(".b6").css("background-color", "blue");
    $(".sweet-overlay").css("background-color", "rgba(0, 0, 0, 0.6)");


    swal({
        title: "Sweet!",
        text: "Here's a custom image.",
        imageUrl: 'https://i.imgur.com/4NZ6uLY.jpg'
    });


};

 //<!--MODAL CENTARDO DEL DRIVE -- >
function cerrarMensajeModalFx() {

    $(".lb-k").hide();
    $("#outPopUp").hide();

}


 /************************************************************************
      BLOCKER PROCESANDO LOADER (Cuando se realice peticiones a la bd)
 *************************************************************************/
function blockLoader() {
    //$.blockUI();
    //setTimeout(unBlock, 5000);
    //alert();
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



//////////////////////////////////////////////////////
// Alert despues de 12 digitos
//////////////////////////////////////////////////////
//FUENTE: https://stackoverflow.com/questions/35905507/how-do-i-execute-a-function-after-5-sec-from-last-keyup
var timer;
$("#inputCapturarCodigoBarras").on("keyup", function (evt) {
    //alert('Valor del input ---> ' +$("#inputCapturarCodigoBarras").val())

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

            //}
            ///////////////////////////////////////
            //else {

            //    trueFalseSwal = false;

            //}


        }, 300);//1 * 1000);


    }

});

//////////////////////////////////////////////////////////////////////////////////////////////
// CLICK CON BOTON ENTER  https://www.w3schools.com/howto/howto_js_trigger_button_enter.asp
//////////////////////////////////////////////////////////////////////////////////////////////
// Get the input field
var input2 = document.getElementById("inputDigitarCodigoBarras");
var input3 = document.getElementById("inputIngresarIdProducto");
var trueFalseSwal = false; //Para verificar si existe un mensaje Swal abierto

if (input2 !== "") {

    input2.addEventListener("keyup", function (event) {


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

if (input3 !== "") {

    input3.addEventListener("keyup", function (event) {

        if (trueFalseSwal == false) {

            // Number 13 is the "Enter" key on the keyboard
            if (event.keyCode === 13) {
                // Cancel the default action, if needed
                event.preventDefault();

                //alert($(".sweet-alert.visible").length);
                //swal.close();
                //alert($(".sweet-alert.visible").length );

                //AÑADIDO UN IF HGM PARA CONTROLAR EL VACIO DEL INPUT
                if ($("#inputIngresarIdProducto").val() !== "") {
                    // Trigger the button element with a click
                    document.getElementById("btnBuscarPorIdDeProducto").click();
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

//if ($("#inputIngresarIdProducto").val() !== "") {
//    input = $("#inputIngresarIdProducto").val();
//}
// Execute a function when the user releases a key on the keyboard


/////////////////////////////////////////////////////////////////////////////////
//INTERCALAR LOS TRES INPUTS DE BUSCAR(Limpia los demás al clickear en uno)
/////////////////////////////////////////////////////////////////////////////////
$("#inputCapturarCodigoBarras").on("click", function () {
    $("#inputCapturarCodigoBarras").val('');
    $("#inputDigitarCodigoBarras").val('');
    $("#inputIngresarIdProducto").val('');
});
$("#inputDigitarCodigoBarras").on("click", function () {
    $("#inputCapturarCodigoBarras").val('');
    $("#inputIngresarIdProducto").val('');
});
$("#inputIngresarIdProducto").on("click", function () {
    $("#inputCapturarCodigoBarras").val('');
    $("#inputDigitarCodigoBarras").val('');
});



function cargarImagenDefaultSiNoExiste() {
    $("#imagenProducto").attr("src", "/images/productos/item_default.png");
    //$(".posterMarca").attr("src", imagenMarca);
    //$(".poster").show().transition({ x: '0%', opacity: 1.0 });
    //$('.poster').css('transition', 'opacity 5s ease-in-out');
    //$('.poster').fadeIn(2000).show();
}

/////////////////////////////////////////////////////////////////////////////////
//INPUT BUSCAR PRODUCTO POR ID INGRESADO MANUALMENTE - CON SU RESPECTVA LUPA
/////////////////////////////////////////////////////////////////////////////////
$('#btnBuscarPorIdDeProducto').on('click', function () {

    //if ($('#inputIngresarIdProducto').val() == "") { alert('ingresar prod'); }
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


        //https://stackoverflow.com/questions/51535155/sweetalert2-allowoutsideclick-not-working-on-toast-mode-and-close-button-not-app
        //////swal({
        //////    title: 'Successddd!',
        //////    type: 'info',
        //////    //type: 'success',
        //////    //toast: true,
        //////    //////html: response.message,
        //////    ////showCloseButton: true,
        //////    ////showCancelButton: true,
        //////    ////allowEscapeKey: true,
        //////    ////allowOutsideClick: true,
        //////    //////focusConfirm: false,
        //////    ////confirmButtonText: 'Continue Shopping',
        //////    ////confirmButtonAriaLabel: 'Continue Shopping',
        //////    ////cancelButtonText: '<a href="' + 'WWW22222222222222222' + '" style="color:white;">View Cart and Checkout</a>',
        //////    ////cancelButtonColor: '#ff6d02',
        //////    ////cancelButtonAriaLabel: 'Cart',
        //////});


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
        '/Procesos/ObtenerProductoPorPkPntVnt',
        {
              intIdProducto  : parseInt(id_ingresado)
            , strCodigoBarras: strCodigoBarras_

        },
        response => {

            data_entradas = response;

            $('#inputIngresarIdProducto').val("");

            ////alert('PRODUCTO ---> ' + data_entradas[0].strDesProducto + '\n' +
            ////      'MARCA ------> ' + data_entradas[0].strMarcaProd);
            if (response.length > 0) {

                //LIMPIAMOS EL ARREGLO A LLENAR(siempre mantendrá un solo registro)
                productoEscaneadoByPk = [];

                response.forEach(element => {
                    //alert(element.strRutaImagenProducto);

                    if (element.strRutaImagenProducto == "" || element.strRutaImagenProducto == null) {
                        //alert(000);
                        $('#imagenProducto').attr("src", "/images/productos/item_default.png");// campo imagen null o vacio
                    }
                    else {

                        $("#imagenProducto").attr("src", element.strRutaImagenProducto);
                        //alert(11111);
                        //$('#imagenProducto').html('<img OnError="cargarImagenDefaultSiNoExiste()" src = ' + element.strRutaImagenProducto + ' style="width:50%;" />');
                    }



                    //alert(response.length);
                    ////////////////////////////////////////////////////////////////////////////////////////////
                    //$('#contenedor_imagen_producto').html('<img src = ' + '/images/productos/' + element.strCodProducto + '.jpg'
                    //    + ' style="width:290px; height:290px; border-radius:15px; "  />');
                    //////////$("#imagenProducto").attr("src", element.strRutaImagenProducto);
                    //$('#contenedor_codigo_producto').html('<label>' + element.strCodigoProducto + '<label>');
                    $('#contenedor_descripcion_producto').html('<label>' + element.strDescProducto + '<label>');
                    $('#lbl_item_producto').html('<label id="lbl_cod_producto">' + element.strCodigoProducto + '<label>');
                    $('#contenedor_marca_producto').html('<label>' + element.strMarcaProducto + '<label>');
                    //$('#contenedor_precio_producto').html('<label>' + (element.decPrecioDeVenta).toFixed(2) + '<label>');
                    //////$('.price').html((element.decPrecioDeVenta).toFixed(2));
                    //////$('.full-price').html((element.decPrecioDeVenta).toFixed(2));
                    $('.price').html(element.decPrecioDeVenta);
                    $('.full-price').html(element.decPrecioDeVenta);
                    $('.qt').html(1);

                    //INPUT NO VISIBLE  12345
                    $("#inputIntIdProducto").attr("value", element.intIdProducto);

                    if (element.intCantTotalActual > 0) {
                        $('#spanDisponibilidad').html('&nbsp;Disponible (' + element.intCantTotalActual + ')');
                        $('#dotDisponibilidad').css('background-color', 'green');
                        $('#spanDisponibilidad').css('color', 'green');
                    }

                    if (element.intCantTotalActual <= 0) {
                        $('#spanDisponibilidad').html('&nbsp;Sin Stock');
                        $('#dotDisponibilidad').css('background-color', 'red');
                        $('#spanDisponibilidad').css('color', 'red');
                    }

                    //INSERTAR DETALLEN DEL PRODUCTO TRAIDO EN EL SGTE ARRAY
                    productoEscaneadoByPk.push({

                          "o_intIdProducto": element.intIdProducto
                        , "o_strCodigoBarr": element.strCodigoBarras
                        , "o_strCodigoProd": element.strCodigoProducto
                        , "o_strDescProduc": element.strDescProducto
                        , "o_strDescMarcaP": element.strMarcaProducto
                        //, "o_decPrecioDeVe": (element.decPrecioDeVenta).toFixed(2)
                        , "o_decPrecioDeVe": element.decPrecioDeVenta
                        , "o_intCantTotalA": element.intCantTotalActual
                        //, "o_decMontoProdu": (element.decMontoProductos).toFixed(2)
                        , "o_decMontoProdu": element.decMontoProductos
                        , "o_strRutaImgMar": element.strRutaImagenMarca
                        , "o_strRutaImagen": element.strRutaImagenProducto
                        , "o_strDescCatego": element.strDescCategoria
                        , "o_strPresentaci": element.strPresentacion

                    });

                    ////unBlockLoader(); hgm 12.01.22
                    setTimeout(function () { chanchito(); }, 1200);

                });

            }
            else {

                //unBlockLoader();hgm 12.01.22
                swal("Producto", response.message);
                setTimeout(function () { chanchito(); }, 1200);

                ////// //alert('no hay registro');
                //////swal({
                //////     type: 'Producto',
                //////     //html: 'You entered: <strong>' + response.result + '</strong>'
                ////// });

            }
        });

});


/////////////////////////////////////////////////////////////////////////////////
//INPUT BUSCAR POR CODIGO BARRA DIGITADO MANUALMENTE - CON SU RESPECTVA LUPA
/////////////////////////////////////////////////////////////////////////////////
$('#btnBuscarPorCodigoBarrasDigitado').on('click', function () {

    blockLoader();//INICIAMOS EL LOADER
    //POR ID
    var id_ingresado = $('#inputIngresarIdProducto').val();
    if (id_ingresado == "") { id_ingresado = "0"; }
    //POR CODIGO DE BARRAS
    var strCodigoBarras_ = $('#inputDigitarCodigoBarras').val();
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

                //LIMPIAMOS EL ARREGLO A LLENAR(siempre mantendrá un solo registro)
                productoEscaneadoByPk = [];

                response.forEach(element => {

                    ////////////////////////////////////////////////////////////////////////////////////////////
                    //$('#contenedor_imagen_producto').html('<img src = ' + '/images/productos/' + element.strCodProducto + '.jpg'
                    //    + ' style="width:290px; height:290px; border-radius:15px; "  />');
                    $("#imagenProducto").attr("src", element.strRutaImagenProducto);
                    //$('#contenedor_codigo_producto').html('<label>' + element.strCodigoProducto + '<label>');
                    $('#contenedor_descripcion_producto').html('<label>' + element.strDescProducto + '<label>');
                    $('#lbl_item_producto').html('<label>' + element.strCodigoProducto + '<label>');
                    $('#contenedor_marca_producto').html('<label>' + element.strMarcaProducto + '<label>');
                    //$('#contenedor_precio_producto').html('<label>' + (element.decPrecioDeVenta).toFixed(2) + '<label>');
                
                    //$('.price').html((element.decPrecioDeVenta).toFixed(2));
                    //$('.full-price').html((element.decPrecioDeVenta).toFixed(2));

                    $('.price').html(element.decPrecioDeVenta);
                    $('.full-price').html(element.decPrecioDeVenta);
                    $('.qt').html(1);

                    //INPUT NO VISIBLE
                    $("#inputIntIdProducto").attr("value", element.intIdProducto);

                    if (element.intCantTotalActual > 0) {
                        //$('#spanDisponibilidad').html('&nbsp;Disponible');
                        $('#spanDisponibilidad').html('&nbsp;Disponible (' + element.intCantTotalActual + ')');
                        $('#dotDisponibilidad').css('background-color', 'green');
                        $('#spanDisponibilidad').css('color', 'green');
                    }

                    if (element.intCantTotalActual <= 0) {
                        $('#spanDisponibilidad').html('&nbsp;Sin Stock');
                        $('#dotDisponibilidad').css('background-color', 'red');
                        $('#spanDisponibilidad').css('color', 'red');
                    }

                    //INSERTAR DETALL EN DEL PRODUCTO TRAIDO EN EL SGTE ARRAY
                    productoEscaneadoByPk.push({

                          "o_intIdProducto": element.intIdProducto
                        , "o_strCodigoBarr": element.strCodigoBarras
                        , "o_strCodigoProd": element.strCodigoProducto
                        , "o_strDescProduc": element.strDescProducto
                        , "o_strDescMarcaP": element.strMarcaProducto
                        //, "o_decPrecioDeVe": (element.decPrecioDeVenta).toFixed(2)
                        , "o_decPrecioDeVe": element.decPrecioDeVenta
                        , "o_intCantTotalA": element.intCantTotalActual
                        //, "o_decMontoProdu": (element.decMontoProductos).toFixed(2)
                        , "o_decMontoProdu": element.decMontoProductos
                        , "o_strRutaImgMar": element.strRutaImagenMarca
                        , "o_strRutaImagen": element.strRutaImagenProducto
                        , "o_strDescCatego": element.strDescCategoria
                        , "o_strPresentaci": element.strPresentacion

                    });

                    unBlockLoader();

                });

            }
            else {

                unBlockLoader();
                swal("Producto", response.message);
                ////// //alert('no hay registro');
                //////swal({
                //////     type: 'Producto',
                //////     //html: 'You entered: <strong>' + response.result + '</strong>'
                ////// });

            }
        });

});

/////////////////////////////////////////////////////////////////////////////////
//BUSCAR PRODUCTO Y DETALLE CON CODIGO DE BARRAS CAPTURADO EN INPUT (Automático)
/////////////////////////////////////////////////////////////////////////////////
function buscarCapturaCodigoBarras(strCodigoBarras_) {

    blockLoader();
    if (strCodigoBarras_ == "") { strCodigoBarras_ = "0"; }

    $.post(
        '/Procesos/ObtenerProductoPorPkPntVnt',
        {
            intIdProducto: 0// parseInt(id_ingresado)
            , strCodigoBarras: strCodigoBarras_

        },
        response => {
            data_entradas = response;

            if (response.length > 0) {

                //LIMPIAMOS EL ARREGLO A LLENAR(siempre mantendrá un solo registro)
                productoEscaneadoByPk = [];

                response.forEach(element => {

                    //alert(response.length);
                    ////////////////////////////////////////////////////////////////////////////////////////////
                    $("#imagenProducto").attr("src", element.strRutaImagenProducto);
                    //$('#contenedor_codigo_producto').html('<label>' + element.strCodigoProducto + '<label>');
                    $('#contenedor_descripcion_producto').html('<label>' + element.strDescProducto + '<label>');
                    $('#lbl_item_producto').html('<label>' + element.strCodigoProducto + '<label>');
                    $('#contenedor_marca_producto').html('<label>' + element.strMarcaProducto + '<label>');
                    //$('.price').html((element.decPrecioDeVenta).toFixed(2));
                    //$('.full-price').html((element.decPrecioDeVenta).toFixed(2));
                    $('.price').html(element.decPrecioDeVenta);
                    $('.full-price').html(element.decPrecioDeVenta);
                    $('.qt').html(1);

                    //INPUT NO VISIBLE PARA GUARDAR EL ID
                    $("#inputIntIdProducto").attr("value", element.intIdProducto);

                    if (element.intCantTotalActual > 0) {
                        $('#spanDisponibilidad').html('&nbsp;Disponible (' + element.intCantTotalActual + ')');
                        //$('#spanDisponibilidad').html('&nbsp;Disponible');
                        $('#dotDisponibilidad').css('background-color', 'green');
                        $('#spanDisponibilidad').css('color', 'green');
                    }

                    if (element.intCantTotalActual <= 0) {
                        $('#spanDisponibilidad').html('&nbsp;Sin Stock');
                        $('#dotDisponibilidad').css('background-color', 'red');
                        $('#spanDisponibilidad').css('color', 'red');
                    }


                    //INSERTAR DETALLE DEL PRODUCTO TRAIDO EN EL SGTE ARRAY
                    //(recordar que hay tres formas de accion de cargado para este array)
                    productoEscaneadoByPk.push({

                          "o_intIdProducto": element.intIdProducto
                        , "o_strCodigoBarr": element.strCodigoBarras
                        , "o_strCodigoProd": element.strCodigoProducto
                        , "o_strDescProduc": element.strDescProducto
                        , "o_strDescMarcaP": element.strMarcaProducto
                        , "o_decPrecioDeVe": element.decPrecioDeVenta
                        , "o_intCantTotalA": element.intCantTotalActual
                        , "o_decMontoProdu": element.decMontoProductos
                        , "o_strRutaImgMar": element.strRutaImagenMarca
                        , "o_strRutaImagen": element.strRutaImagenProducto
                        , "o_strDescCatego": element.strDescCategoria
                        , "o_strPresentaci": element.strPresentacion

                    });

                    unBlockLoader();

                    //LIMPIAR INPUT CAPTURAR
                    $("#inputCapturarCodigoBarras").val('');

                });
            }
            else {

                unBlockLoader();
                swal("Producto", response.message);

            }


        });



}


function overlaySweetalert() {


    $(".fix").css("background-color", "transparent");
    // $(".succes").css("background-color","transparent");
    $(".b3").css("background-color", "blue");
    $(".sweet-overlay").css("background-color", "rgba(0, 0, 0, 0.7)");

    swal("Good job!", "Procesado Correctamente!", "success");

    //////$(".sweet-alert p").hide();
    //$(".sweet-alert p").css("color", "white");
    $(".sweet-alert h2").hide();
    $(".sa-fix").hide();
    $(".confirm").hide();
    //$(".sa-button-container").hide();
    $(".sa-line").css("background-color", "#52e200");
    $(".sa-fix").css("background-color", "transparent");
    $(".sweet-alert .sa-icon.sa-success").css("border-color", "#52e200");
    //$(".sweet-alert").toggleClass('sweet-alert-temporal');
    $(".sweet-alert").css("background-color", "transparent");
    $('.sweet-alert .sa-icon.sa-success').toggleClass('before2');
    $('.sweet-alert .sa-icon.sa-success').toggleClass('after2');
    $(".sweet-alert .sa-icon.success:after").css("background-color", "transparent");
    $(".sa-icon").removeClass('animate')


    setTimeout(function () {

        $(".sa-icon").hide();
        $(".sweet-alert").hide();
        $(".sweet-alert p").show();
        $(".sweet-alert h2").show();
        $(".confirm").hide();
        $(".sweet-overlay").fadeOut("fast", function () {
            // Animation complete.
            $(".sweet-overlay").hide();
        });
        //
        $(".sa-icon").removeClass('before2');
        $(".sa-icon").removeClass('after2');
        $(".sweet-alert").css("background-color", "#ffffff");
        $("body").css("overflow-y", "scroll");
        $(".sweet-overlay").css("background-color", "rgba(0, 0, 0, 0.4)");

        //$(".sa-button-container").hide();
        ///* background-color: #ffffff;
        //$(".sweet-alert").toggleClass('sweet-alert-temporal')

    }, 1400);



}


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


/*********************************************************************************************
Esta función se usa como onkeypress="validarInputSoloNumeros(event)"
dentro del input al que se desea aplicar, lo que permitirá:
. bloquear la barra espaciadora,
. permitir solamente ciertos caracteres que se determinan aquí,
. como restringir solo letras
. o restringir solo algunos caracteres especiales.
FUENTE: https://stackoverflow.com/questions/469357/html-text-input-allow-only-numeric-input
*********************************************************************************************/


$('#btn_cancelar_venta_pntvnt').on('click', function () {
    //alert('Solo ingresar numeros del 1 al 9');

    //ALERT DE CONFIRMACION
    swal({

        title: "ANULAR VENTA",
        text: "Esta seguro que desea anular esta venta?",
        type: "info",
        showCancelButton: true,
        confirmButtonText: 'Aceptar!',//'Sí, Aceptar!',
        cancelButtonText: "Cancelar!",
        closeOnConfirm: false,
        showLoaderOnConfirm: true

    }).then(function (isConfirm) {


        //$("#calcTable tr").remove(); //Remover todas las filas de una tabla
        $("#calcTable tr>td").remove(); 
        //$("#calcTable tbody").children().remove(); //Remover todas las filas de una tabla menos el encabexado
        //productoEscaneadoByPk = [];  //No se debe limpiar ya que aqui se guardo lo que se consulto
        ventas = []; //Aqui van todo lo que se visualiza en el listado
        listaDetalleProductosVenta.length = 0;
        listaDetalleComprobante.length = 0;
        $('#valueTot').text("00.00");
        $('.igvTotDeLista').html("00.00");
        $('.subTotDeLista').html("00.00");

        //Habilitar los controles de búsqueda
        $('#inputCapturarCodigoBarras').attr('disabled', false);
        $('#inputDigitarCodigoBarras').attr('disabled', false);
        $('#inputIngresarIdProducto').attr('disabled', false);
        $('#btnBuscarPorIdDeProducto').attr('disabled', false);
        $('#btnBuscarPorCodigoBarrasDigitado').attr('disabled', false);
        $('#div_producto_consultado').show();
        $('#btn_cancelar_venta_pntvnt').hide();
        //alert(listaDetalleProductosVenta.length);

    }, function (dismiss) {
        //if (dismiss == 'cancel') {
        //swal("Cancelado", "La Operación fue cancelada", "error");
        //}
    });



});




/////////////////////////////////////////////////////////////////////////////////
// ARRAY listaDetalleProductosVenta PARA ENVIAR LISTADO DE VENTA, PARA UN UPDATE
/////////////////////////////////////////////////////////////////////////////////
var listaDetalleProductosVenta = new Array();
class TB_PRODUCTOS_VENTAS {

    constructor(intField_1, strField_2, strField_3, decField_4, intField_5, decField_6) {

        this.intIdProducto     = intField_1;
        this.strCodigoBarras   = strField_2;
        this.strDescProducto   = strField_3;
        this.decPrecioDeVenta  = decField_4;
        this.intCantidadVenta  = intField_5;
        this.decMontoVentaProd = decField_6;

    }
}


/////////////////////////////////////////////////////////////////////////////////
//LIATA lstResultProcesoVenta PARA MANEJAR EL RESULTADO DEL PROCESO DE VENTA(Aun no usado)
/////////////////////////////////////////////////////////////////////////////////
var lstResultProcesarVenta = new Array();
class RESULT_PROCESAR_VENTA {

    constructor(intField_1, strField_2) {

        this.intIdProducto = intField_1;
        this.intRstVendido = strField_2;

    }
}



let let_NombreReciboGenerado;
let let_FechaHoraVenta;
/////////////////////////////////////////////////////////////////////////////////
// BOTON PARA ENVIAR EN UN ARREGLO LOS PRODUCTOS LISTADOS Y REALIZAR UN UPDATE - VENDER
/////////////////////////////////////////////////////////////////////////////////
$('#btn_procesar_venta_pntvnt').on('click', function () {  // btn-update-producto


    //swal({
    //    title: "An input!",
    //    text: "Write something interesting:",
    //    type: "input",
    //    showCancelButton: true,
    //    closeOnConfirm: false,
    //    inputPlaceholder: "Write something"
    //}, function (inputValue) {
    //    if (inputValue === false) return false;
    //    if (inputValue === "") {
    //        swal.showInputError("You need to write something!");
    //        return false
    //    }
    //    swal("Nice!", "You wrote: " + inputValue, "success");
    //});

    ////////swal({ //https://lipis.github.io/bootstrap-sweetalert/
    ////////    title: "Ajax request example",
    ////////    text: "Submit to run ajax request",
    ////////    type: "info",
    ////////    showCancelButton: true,
    ////////    closeOnConfirm: false,
    ////////    showLoaderOnConfirm: true
    ////////}, function () {
    ////////    setTimeout(function () {
    ////////        swal("Ajax request finished!");
    ////////    }, 2000);
    ////////});


    ////////swal({

    ////////    title: "Finalizar Venta5555",
    ////////    text: "Esta seguro de procesar esta venta?",
    ////////    confirmButtonText: 'Si, Aceptar!',//'Sí, Aceptar!',
    ////////    cancelButtonText: "No, Cancelar!",
    ////////    type: "info",
    ////////    showCancelButton: true,
    ////////    closeOnConfirm: false,
    ////////    showLoaderOnConfirm: true

    ////////}, function () {

    ////////    alert(3455);

    ////////    ////var _codigo = $('#txt_codigo_Perfil').val();
    ////////    ////var _activo = $('#chk-activo-Perfil').is(':checked');



    ////////    ////////$('#AutoLlenado').each((index, item) => {
    ////////    ////////    var label = $(item).find('label');
    ////////    ////////    var _check = $(label).find('input.Mens');
    ////////    ////////    if ($(_check).is(':checked')) {
    ////////    ////////        var intIdMenu = $(_check).attr('id');
    ////////    ////////        alert(intIdMenu);
    ////////    ////////        if (intIdMenu !== 0) {
    ////////    ////////            listaDetallesPerfiles.push(new TT_TSPERFIL_MENU(0, 0, 4, intIdMenu, 0));
    ////////    ////////        }
    ////////    ////////    }
    ////////    ////////});

    ////////    //listaDetalleProductosVenta.push(new TB_PRODUCTOS(5, '0', '4', 1, '0'));

    ////////}
    ////////    //)

    ////////    //    .fail(function (result) {
    ////////    //    alert('ERROR ' + result.status + ' ' + result.statusText);

    ////////    //}
    ////////);


    //listaDetalleProductosVenta

    //Lista Vacia
    if (listaDetalleProductosVenta.length == 0) {
        new PNotify({
            title: 'PROCESAR VENTA',
            text: 'Agregar por lo menos un producto a la lista.',
            type: 'info',
            delay: 2500,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }


    //ALERT DE CONFIRMACION
    swal({

        title: "PROCESAR VENTA",
        text: "Esta seguro de procesar esta venta?",
        type: "info",
        showCancelButton: true,
        confirmButtonText: 'Aceptar!',//'Sí, Aceptar!',
        cancelButtonText: "Cancelar!",
        closeOnConfirm: false,
        showLoaderOnConfirm: true

    }).then(function (isConfirm) {

        //alert('isConfirm');

         var VentaCabe = {

           intIdVentaCabe      :  0     
          ,strCodVenta         :  " "     
          ,strRucCliente       :  ""
          ,strNomCliente       :  ""
          ,strApeCliente       :  ""
          ,strMoneda           :  ""
          ,strDirCliente       :  ""
          ,strTelCliente       :  ""
          ,decMontoTotDeVenta  :  ""
          ,dttDateTimeVenta    :  ""
          ,strMedioDePago      :  ""
          ,decPagoConIzipay    :  ""

    };


        //GESTVENT
        $.post(
            '/Procesos/InsertUpdateFromPuntoVenta',
            {
                  intTipoOperacion   : 1
                , strOperacion       : "GENERAR_IDCABE"
                , intIdVentaCabe     : 0
                , objVentaCabe       : VentaCabe
                , lstDetalleProducto : listaDetalleProductosVenta
                , lstRstVta          : lstResultProcesarVenta         

            },
            (response) => {


                $('#btn_procesar_venta_pntvnt').hide();
                $('#btn_cancelar_venta_pntvnt').hide();
                $('#btn_continuar_venta_pntvnt').show();
                $('.enviarCorreoRecibo').hide();
               
                //Deshabilitar los controles de búsqueda
                $('#inputCapturarCodigoBarras').attr('disabled', true);
                $('#inputDigitarCodigoBarras').attr('disabled', true);
                $('#inputIngresarIdProducto').attr('disabled', true);
                $('#btnBuscarPorIdDeProducto').attr('disabled', true);
                $('#btnBuscarPorCodigoBarrasDigitado').attr('disabled', true);
                $('#div_producto_consultado').hide();
                $('#btn_cancelar_venta_pntvnt').attr('disabled', true);
       
                //$('#btn_procesar_venta_pntvnt').text('CONTINUAR VENTA');//Para llenar el Formulario de la Cabecera
                //CASO 01: EL Json Contiene un OBJETO con las llaves: type, extramsg, ...
                //Este caso es cuando todos los items de .a losta se han insertado correctamente
                //https://stackoverflow.com/questions/20804163/check-if-a-key-exists-inside-a-json-objecttype
                if (response.hasOwnProperty('type') || response.hasOwnProperty('extramsg') || response.hasOwnProperty('message')) {

                    //alert('CASO 01: EL Json Contiene un OBJETO con las llaves type, extramsg, ...');     
                    //$('#inputchck').addClass('inputchck'); //CHECK VERDE
                    $('.inputchck').prop('checked', true);

                    //Guardar el ID de la venta cabe 
                    let_intIdVentaCabe = response.intIdentifier;

                    //alert(let_intIdVentaCabe + '   ' + 'qqqqqqq');
                }


                //CASO 02: EL Json No contiene un OBJETO la llaves type, extramsg, ... sino un ARRAY de tipo lista
                //Este caso se da cuando uno o mas de los items no se han insertado
                //--> https://stackoverflow.com/questions/951483/how-to-check-if-a-json-response-element-is-an-array
                if (response.constructor === Array) {

                    response.forEach(item => {

                        if (item.intRstVendido == 2) {

                            $('#chck' + item.intIdProducto).prop('checked', true);
                            $('#chck' + item.intIdProducto).addClass('inputchck2');//CHECK NARANJA
                            //alert('1');
                        }
                        else {

                            $('#chck'  + item.intIdProducto).prop('checked', true);
                            $('#chck' + item.intIdProducto).addClass('inputchck'); //CHECK VERDE
                            //alert('2');

                        }

                        //Guardar el ID de la venta cabe 
                        let_intIdVentaCabe = item.intIdVentaCabe;
                        //alert(let_intIdVentaCabe + '   ' + 'hhhhhhhhhhhhh');
                
                        //$('#cboPerfilAdmin').append('<option value="' + item.intidTipo + '">' + item.strDeTipo + '</option>')
                        //if (item.intidTipo == data.intIdPerfil) {
                        //    $('#cboPerfilAdmin').val(item.intidTipo)
                        //}
                    });


                }


                //Traer el Numero de Recibo de Venta(Por el Momento sera el mismo ID de Venta desde VENTA_CABECERA)
                //--------------------------------------------------------------------------------------------------
                $.post(
                    '/Procesos/ListarCombosGestionar',
                    {
                        strNomTablaEntidad: 'GENERAR_NOMBRE_RECIBO', intParametroEntero: 1
                    },
                    response => {

                        if (response.length > 0) {
                            //alert(response[0].strDescEntidad);
                            let_NombreReciboGenerado = response[0].strDescEntidad;
                            //let_LastCodigoVenta = $("#val_txtCodigoMarca").val(response[0].strDescEntidad);
                        }

                        $.post(
                            '/Procesos/ListarCombosGestionar',
                            {
                                strNomTablaEntidad: 'FECHA_HORA_VENTA', intParametroEntero: 1
                            },
                            response => {

                                if (response.length > 0) {
                                    //alert(response[0].strDescEntidad);
                                    let_FechaHoraVenta = response[0].strDescEntidad;
                                }

                            });




                    });

                //--------------------------------------------------------------------------------------------------



                //var bodyJson = response.json();
                //tests["Response should not be an array"] = !Array.isArray(bodyJson['testA']); // false
                ////tests["Response should not be an array"] = !Array.isArray(bodyJson['testB']);  // true



                //alert('console.log(response)');
                console.log(response);
                ////////swal("Venta Procesada", "La venta se ha procesado exitosamente.");

                /*++++++++++++++++++++++++
                setTimeout(function () {

                    overlaySweetalert();
                    //chanchito();
                    //setTimeout(function () {chanchito();}, 3000);
                    //swal("Ajax request finished!");                            

                }, 500);

                +++++++++++++++++++++++++++++*/

                //////////////////////////CAMBIAR COLOR DEL CHECK
                //$('#chck' + 'ITEM00007').addClass('inputchck2');



            });



    }, function (dismiss) {
        //if (dismiss == 'cancel') {
            //swal("Cancelado", "La Operación fue cancelada", "error");
        //}
    });


});  ///FIN BOTON UDDATE



$('#btn_continuar_venta_pntvnt').on('click', function () {  // btn-update-producto

    //MOSTRAR MODAL CON JQUERY --> Ya no se usara modal para esta parte, perop si esta reutilizando el content del modal
    //https://stackoverflow.com/questions/13183630/how-to-open-a-bootstrap-modal-window-using-jquery
    ////$('.bs-example-modal-new').modal('toggle');  //Comentado

    $('#div_producto_consultado').hide();
    $('#div_continuar_venta').show();
    $('#btn_procesar_venta_pntvnt').hide();
    $('#btn_continuar_venta_pntvnt').hide();
    $('#btn_finalizar_venta_pntvnt').hide();
    $('#btn_generar_recibo_pdf').show();


    //$('#myModal').modal('show');
    //$('#myModal').modal('hide');
    //$('.fade bs-example-modal-new').modal({
    //    show: 'true'
    //}); 


    ////$.post(
    ////    '/Procesos/UpdateProductoFromPuntoVenta',
    ////    {
    ////        ObjDatos: Datos
    ////        , lstDetalleProducto: listaDetalleProductosVenta
    ////        , lstRstVta: lstResultProcesarVenta

    ////    },
    ////    (response) => {


    ////        $('#btn_procesar_venta_pntvnt').hide();
    ////        $('#btn_continuar_venta_pntvnt').hide();

    ////        //CASO 01: EL Json Contiene un OBJETO con las llaves: type, extramsg, ...
    ////        //https://stackoverflow.com/questions/20804163/check-if-a-key-exists-inside-a-json-objecttype
    ////        if (response.hasOwnProperty('type') || response.hasOwnProperty('extramsg') || response.hasOwnProperty('message')) {

    ////            //alert('CASO 01: EL Json Contiene un OBJETO con las llaves type, extramsg, ...');     
    ////            //$('#inputchck').addClass('inputchck'); //CHECK VERDE
    ////            $('.inputchck').prop('checked', true);

    ////            //alert('0');

    ////        }


    ////        //CASO 02: EL Json No contiene un OBJETO la llaves type, extramsg, ... sino un ARRAY de tipo lista
    ////        //--> https://stackoverflow.com/questions/951483/how-to-check-if-a-json-response-element-is-an-array
    ////        if (response.constructor === Array) {

    ////            response.forEach(item => {

    ////                if (item.intRstVendido == 2) {

    ////                    $('#chck' + item.intIdProducto).prop('checked', true);
    ////                    $('#chck' + item.intIdProducto).addClass('inputchck2');//CHECK NARANJA
    ////                    //alert('1');
    ////                }
    ////                else {

    ////                    $('#chck' + item.intIdProducto).prop('checked', true);
    ////                    $('#chck' + item.intIdProducto).addClass('inputchck'); //CHECK VERDE
    ////                    //btn_procesar_venta_pntvnt  88888888
    ////                    //alert('2');

    ////                }


    ////            });


    ////        }

    ////        console.log(response);
    ////        ////////swal("Venta Procesada", "La venta se ha procesado exitosamente.");

    ////        /*++++++++++++++++++++++++
    ////        setTimeout(function () {

    ////            overlaySweetalert();
    ////            //chanchito();
    ////            //setTimeout(function () {chanchito();}, 3000);
    ////            //swal("Ajax request finished!");                            

    ////        }, 500);

    ////        +++++++++++++++++++++++++++++*/
    ////        //////////////////////////CAMBIAR COLOR DEL CHECK
    ////        //$('#chck' + 'ITEM00007').addClass('inputchck2');


    ////    });


});  ///FIN BOTON UDDATE



//btn_cancelar_venta_pntvnt
//btn_procesar_venta_pntvnt
//btn_continuar_venta_pntvnt
//btn_finalizar_venta_pntvnt
//btn_generar_recibo_crystal



$('#btn_finalizar_venta_pntvnt').on('click', function () {  // btn-update-producto

    //MOSTRAR MODAL CON JQUERY --> Ya no se usara modal para esta parte, perop si esta reutilizando el content del modal
    //https://stackoverflow.com/questions/13183630/how-to-open-a-bootstrap-modal-window-using-jquery
    ////$('.bs-example-modal-new').modal('toggle');  //Comentado

    $('#div_producto_consultado').show();
    $('#div_continuar_venta').hide(); //falta limpiar los controles de este div     1111111
    $('#btn_continuar_venta_pntvnt').hide();
    $('#btn_finalizar_venta_pntvnt').hide();
    $('#btn_generar_recibo_pdf').hide(); 
    $('#btn_procesar_venta_pntvnt').show();

    $('#val_strEmailDestino').attr('disabled', false);
    $('#val_strEmailDestino').val("");
    $('#btn_enviar_correo_recibo_pdf').attr('disabled', false);


    $("#calcTable tr>td").remove();
    ventas = []; 
    listaDetalleProductosVenta.length = 0;
    listaDetalleComprobante.length = 0;
    $('#valueTot').text("00.00");
    $('.igvTotDeLista').html("00.00");
    $('.subTotDeLista').html("00.00");

    //Habilitar los controles de búsqueda
    $('#inputCapturarCodigoBarras').attr('disabled', false);
    $('#inputDigitarCodigoBarras').attr('disabled', false);
    $('#inputIngresarIdProducto').attr('disabled', false);
    $('#btnBuscarPorIdDeProducto').attr('disabled', false);
    $('#btnBuscarPorCodigoBarrasDigitado').attr('disabled', false);
    $('#div_producto_consultado').show();
    let_NombreReciboGenerado = "";
    let_FechaHoraVenta = "";
    let_intIdVentaCabe = "";

});  ///FIN BOTON UDDATE

//////////////////////////////////////////////FIN DEL PROCESO DE UPDATE



//$(".qt-plus").css("background-color", "rgba(124, 196, 188, 0.5)");
//$(".subtotal").css("background-color", "rgba(124, 196, 188, 0.5)");
var check = false;

//function changeVal(el) {
//    var qt = parseFloat(el.parent().children(".qt").html());
//    var price = parseFloat(el.parent().children(".price").html());
//    var eq = Math.round(price * qt * 100) / 100;

//    el.parent().children(".full-price").html(eq.toFixed(2));

//    changeTotal();
//}

function changeVal(el) {

    var qt = parseFloat($(".qt").html());
    var price = parseFloat($(".price").html());
    var eq = Math.round(price * qt * 100) / 100;

    $(".full-price").html(eq.toFixed(2));

    changeTotal();
}

function changeTotal() {

    var price = 0;

    $(".full-price").each(function (index) {
        price += parseFloat($(".full-price").eq(index).html());
    });

    price = Math.round(price * 0.82 * 100) / 100
    var tax = Math.round(price * 1.18 * 100) / 100
    var shipping = parseFloat($(".shipping span").html());
    //var fullPrice = Math.round((price + tax + shipping) * 100) / 100;
    var fullPrice = Math.round((price + tax) * 100) / 100;
    if (price == 0) {
        fullPrice = 0;
    }

    $(".subtotal span").html(price.toFixed(2));
    $(".tax span").html(tax.toFixed(2));
    $(".total span").html(fullPrice.toFixed(2));
}


    //// A $( document ).ready() block.
    //$( document ).ready(function() {
    //console.log( "ready!" );
    //$('.nav_menu').hide();

    //});

 //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//var _descProducto = '';
function buscarValor() {
    //$('#calcTable tr').each(function () {
    //    if (!this.rowIndex) return; // skip first row
    //    var customerId = this.cells[0].innerHTML;
    //    alert(customerId);
    //});
    ventas = [];
}


        /********************************************

        var army = ["Marcos", "DeltaForce", "Seals", "SWAT", "HeadHunters"];

        if (army.indexOf("Marcos") !== -1) {
            alert("Yes, the value exists!")
        }
        else {
            alert("No, the value is absent.")
        }
        ******************************************/


//<!--ACCION CON EL BOTONCITO AGREGAR o AÑADIR -->   
////////////////////////////////////////////////////////////////////////////////
// ARRAY "listaDetalleProductosVenta" PARA ENVIAR LISTADO VENTAS PARA UN UPDATE
////////////////////////////////////////////////////////////////////////////////
var ventas = []; //
let productoEscaneadoByPk = []; //jslet2407210948
// CREAR PRIMERA TABLA --> SEGUNDO BOTON
$('#btnAgreagarNuevoProducto').on("click", function () {

    var _itemCodProd = $('#lbl_item_producto').text();

    //https://sweetalert2.github.io/recipe-gallery/login-form.html
    //////$('#calcTable tr').each(function () {
    //////    // skip first row if (!this.rowIndex) return;
    //////    var customerId = this.cells[0].innerHTML;
    //////    if (_itemCodProd != customerId.toString() || _itemCodProd != "" ){

    ///////////////////////////////////////////////////////////
    //var tipo = 'ALERTA MENSAJE!';
    if (_itemCodProd == "" || _itemCodProd == "ITEM00000") {



        new PNotify({
            title: 'AÑADIR PRODUCTO',
            text: 'Primero consulte el Producto que desea agregar al listado.',
            type: 'info',
            delay: 2500,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        $('#inputCapturarCodigoBarras').focus();
        return;
        

        //////////FUENTE: https://jsfiddle.net/ad3quksn/130/
        /*************************************************** se comenta
        swal({
            title: 'Escanear Producto',
            input: 'text',
            //html: `< img src= "~/images/productos/P0013.jpg" />`,
            //html: `jioijojijop`,
            showCancelButton: true,
            allowOutsideClick: false,
            animation: false
        }).then(function (result) {
            if (result) {
                ////alert(result.value)
                //swal({
                //    type: 'success',
                //    html: 'You entered: <strong>' + result + '</strong>'
                //});
            }
        }).catch(swal.noop);


        ***************************************************/


        //              Swal.fire({
        //                  title: '<span></span>Escanear Producto',
        //                  html: `<input type="text" id="login" class="swal2-input" placeholder="Username">`,
        //                  confirmButtonText: 'Sign in',
        //                  focusConfirm: false,
        //                  preConfirm: () => {
        //                      const login = Swal.getPopup().querySelector('#login').value
        //                      if (!login || !password) {
        //                          //Swal.showValidationMessage(`Please enter login and password`)
        //                      }
        //                      //return { login: login, password: password }
        //                  }
        //              }).then((result) => {
        //                  Swal.fire(`
        //  Login: ${result.value.login}
        //  Password: ${result.value.password}
        //`.trim())
        //              })

        //////////const test = () => {
        //////////    swal({
        //////////        title: 'Test',
        //////////        customClass: 'swal-height'
        //////////    });
        //////////};
        //swal("Hello world!");
        //alert("Tiene que Escanear un Producto");
        //swal(tipo, 'Escanee un Producto', 'info');
        //Swal.fire('Any fool can use a computer')
        //https://stackoverflow.com/questions/40379733/sweetalert2-execute-function-after-timer
        //////////Swal.fire({
        //////////    title: 'Auto close alert!',
        //////////    text: 'I will close in 2 seconds.',
        //////////    timer: 2000
        //////////}).then(function () {
        //////////    alert('done');
        //////////})
        //////////Swal.fire({
        //////////    title: 'Buscar Producto',
        //////////    input: 'text',
        //////////    inputAttributes: {
        //////////        autocapitalize: 'off'
        //////////    },
        //////////    showCancelButton: true,
        //////////    confirmButtonText: 'Look up',
        //////////    showLoaderOnConfirm: true,
        //////////    preConfirm: (login) => {
        //////////        return fetch(`//api.github.com/users/${login}`)
        //////////            .then(response => {
        //////////                if (!response.ok) {
        //////////                    throw new Error(response.statusText)
        //////////                }
        //////////                return response.json()
        //////////            })
        //////////            .catch(error => {
        //////////                Swal.showValidationMessage(
        //////////                    `Request failed: ${error}`
        //////////                )
        //////////            })
        //////////    },
        //////////    allowOutsideClick: () => !Swal.isLoading()
        //////////}).then((result) => {
        //////////    if (result.isConfirmed) {
        //////////        Swal.fire({
        //////////            title: `${result.value.login}'s avatar`,
        //////////            imageUrl: result.value.avatar_url
        //////////        })
        //////////    }
        //////////})




    }
    else if (ventas.indexOf(_itemCodProd) !== -1) {
        //alert('El Producto ' + _itemCodProd + ' ya está en la lista')
        //swal(_itemCodProd, 'Ya tienes agregado este Producto en la lista.', 'info'); //CON ICONO
        swal(_itemCodProd, 'Ya tienes agregado este Producto en la lista.'); //SIN ICONO

    }
    else if (productoEscaneadoByPk[0].o_intCantTotalA <= 0) {

        if (productoEscaneadoByPk[0].o_intCantTotalA == 0) {

            //alert('El Producto no tiene stock')
            swal(_itemCodProd, 'Este Producto no cuenta con stock disponible.');

        }
        else {
            swal(_itemCodProd, 'El Stock de este Producto es negativo o falta definir.');
        }

        //swal(_itemCodProd, 'Este Producto ya existe en la lista.', 'info');

    }
    //'<span style="font-weight: bold;">'
    else if ($('.qt').text() > productoEscaneadoByPk[0].o_intCantTotalA) {

        //Bold text swal  FUENTE:https://stackoverflow.com/questions/48872448/how-to-make-text-bold-with-sweetalert-in-2018
        //var name = "Stack Overflow";
        var content1 = document.createElement('div');
        content1.innerHTML = 'Hello <strong>' + productoEscaneadoByPk[0].o_intCantTotalA + '</strong>';

        if (productoEscaneadoByPk[0].o_intCantTotalA == 1) {
            var msj1 = 'Este Producto solo cuenta con ' + productoEscaneadoByPk[0].o_intCantTotalA + ' \n Unidad disponible en Stock.';

            ////var name = "Stack Overflow";
            ////var content = document.createElement('h1');
            ////content.innerHTML = 'Hello <strong>' + name + '</strong>';
            ////swal({
            ////    title: 'Hello',
            ////    content: content,
            ////    //icon: "success",
            ////})


            swal(_itemCodProd, msj1);
        }
        else {
            var msj2 = 'Este Producto solo cuenta con ' + productoEscaneadoByPk[0].o_intCantTotalA + ' \n Unidades disponibles en Stock.';
            swal(_itemCodProd, msj2);
        }

    }


    ////////////SI PASO LAS VALIDACIONES ENTONCES SE AGREGA AL LISTADO
    else {
  
        var _descProducto = $('#contenedor_descripcion_producto').text();
        //var _precioProducto = $('#contenedor_precio_producto').text();
        var varDecMontoVentaXProd = $('.full-price').text();
        var varIntCantidadVenta = parseInt($('.qt').text());

        var numVal = 23;// parseInt(_precioProducto);//7750518000711

        //INSERTAR AL ARRAY TODO LO QUE PASA AL LISTADO
        var varIdProducto = parseInt($('#inputIntIdProducto').val());
        var varDecPrecioDeVenta = (productoEscaneadoByPk[0].o_decPrecioDeVe);


        /////////////////////////////////////////////////////////////////////////// PARA EL PROCESO DE UPDATE LAS TABLAS DE LA BD
        listaDetalleProductosVenta.push(new TB_PRODUCTOS_VENTAS(    //535353

               varIdProducto
            , _itemCodProd
            , _descProducto
            , varDecPrecioDeVenta  //en js tomarlo com string
            , varIntCantidadVenta
            , varDecMontoVentaXProd

        ));


        ////////////////////////////////////////////////////////////////////////// PARA EL COMPROBANTE CRYSTAL REPORT
        listaDetalleComprobante.push(
            new TT_PRODUCTOS(

                  varIdProducto
                , _itemCodProd //'ITEM0001' 
                , varIntCantidadVenta.toString()
                , _descProducto   // "Arena de Gato Pedigree"  
                , "Und"   //_unidMedida
                , "20.5"  //_marcaProdu
                , "20.5"  //_nomfamLinea
                , "20.5"  //_nomsubLinea
                , "20.5"  //_nomgrupTipo
                , "20.5"  //_stkFisico
                , "20.5"  //_stkDispon
                , "20.5"  //_dsctPercent
                , varDecPrecioDeVenta //"20.5"  //_precio.toFixed(3)
                , "20.5"  //_cost
                , "20.5"  //_msto
                , "S"     //_moneitem
                , "18.1"  //_aigv
                , (varDecPrecioDeVenta * varIntCantidadVenta).toFixed(2).toString()
                , varDecMontoVentaXProd//"20.5"  

            ));


                //alert((varDecPrecioDeVenta * varIntCantidadVenta).toFixed(2).toString());


        $('#sum').parent().parent().remove();

        var html = '<tr style=" background-color:#3d9d7a;color:#606060;" >';/* #4caf50*/
        html += '<td style="width:50px; ">';
        html += '' + _itemCodProd;
        html += '</td>';
        //DESCRIPCION
        html += '<td style="width:400px;">';
        html += '' + _descProducto;
        html += '</td>';
        //MARCA
        html += '<td style="color:#606060;">';
        html += productoEscaneadoByPk[0].o_strDescMarcaP;
        html += '</td>';
        //CANTIDAD ASIGNADA
        html += '<td>';
        html += '<span class="cantUnit">' + varIntCantidadVenta + '</span> u.';
        html += '</td>';
        //PRE_VENTA
        html += '<td>';
        html += '<span id="decPrecioDeVe">' + productoEscaneadoByPk[0].o_decPrecioDeVe + '</span>';
        html += '</td>';
        //MONTO CALCULADO
        html += '<td bgcolor="#40475b" style="color:#606060;">';
        html += ' S/ <span class="toplamc">' + varDecMontoVentaXProd + '</span>';
        html += '</td>';

        //CHECK  
        html += '<td bgcolor="#40475b" style="color:#606060;">';
        html += '<span class="toplamc11"> <input type="checkbox" id="chck' + varIdProducto + '" class="inputchck"  > <label for= "chck' + varIdProducto + '" ></label > </span>';
        //html += '<span class="toplamc11"> <input type="checkbox" id="chck' + _itemCodProd +'" class=""  checked> <label for= "chck' + _itemCodProd +'" ></label > </span>';
        html += '</td>';

        html += '</tr>';


        //SEGUNDA LINEA TR
        html += '<tr style="background-color:#40475b;color:#606060;">';
        html += '<td>';
        html += '';
        html += '</td>';
        html += '<td>';
        html += '';
        html += '</td>';
        html += '<td   style="font-weight:bold;"   >';
        html += 'SUMA TOTAL:';
        html += '</td>';
        html += '<td>';
        html += '<span id="cantTotal"></span> u.';
        html += '</td>';

        html += '<td colspan="1" style="color:#606060;">'; // COLSPAN ??
        html += '</td>';

        html += '<td colspan="2" style="color:#606060;">';
        html += 'S/';
        html += '<span  id="sum" style="font-weight:bold; font-size:18px;"  ></span>';
        html += '</td>';
        html += '</tr>';

        $('#calcTable').append(html);

        var sum = 0;
        $('.toplamc').each(function () {
            sum += parseFloat($(this).text());
        });

        $('#sum').text(sum.toFixed(2));

        $('#valueTot').text(sum.toFixed(2));


        var cantTot = 0;

        $('.cantUnit').each(function () {
            cantTot += parseInt($(this).text());
        });

        $('#cantTotal').text(cantTot);

        ventas.push(_itemCodProd);



        //PARA VISUALIZAR EL TOTAL Y EL IGV TOTAL
        //////var valorIgv = 1.18;
        //////let SubTotal = 0.0000;
        //////for (var i = 0; i < listaDetalleComprobante.length; i++) {
        //////    SubTotal += roundDosDecimales(listaDetalleComprobante[i].tota);
        //////}
        ////////VALORES TOTALES CALCULADOS
        //////var _valorTotal = SubTotal; 
        //////var _valorSubTotal = SubTotal / valorIgv;
        //////var _valorTotalIgv = _valorTotal - _valorSubTotal;
        ////////VALORES TOTALES CALCULADOS
        ////////var valorSubTotal = roundDosDecimales(_valorSubTotal.toFixed(2)).toString();
        ////////var valorTotal = roundDosDecimales(_valorTotalIgv.toFixed(2)).toString();
        //////var valorTotalIgv = roundDosDecimales(_valorTotalIgv.toFixed(2)).toString();


        //listaDetalleComprobante
        $('.igvTotDeLista').html( ( sum - sum / 1.18 ).toFixed(2) );
        $('.subTotDeLista').html( ( sum - ( sum - sum / 1.18) ).toFixed(2) );


        }


         
    //limpiar 1234
    $('#lbl_item_producto').html('ITEM00000');
    $('#contenedor_descripcion_producto').html('CONSULTAR PRODUCTO');
    $('.price').html('00.00');
    $('.full-price').html('00.00');
    $('.qt').html(1);
    $('#imagenProducto').attr("src", "/images/sistema/pv_barcodetopc_oscuro.png");
    $('#spanDisponibilidad').html('&nbsp;Disponibilidad');
    $('#dotDisponibilidad').css('background-color', 'blue');
    $('#spanDisponibilidad').css('color', 'blue');
    $('#btn_cancelar_venta_pntvnt').show();
    $('#btn_cancelar_venta_pntvnt').attr('disabled', false);



    //item = item + 1;

    // }

    ///////////////////////////////////////////////////////////////////
    //////////}
    //////////else {

    //////////alert('El Producto ' + customerId.toString() + ' ya está en la lista');

    //////////}

    ////////});


    //hgm css
    //$(".fix").css('content', '"\2714"');
    //$('#' + id + 'LI').addClass('active');
    //$('#' + id + 'UL').css("display", "block");
    //$(".site_title").removeClass("p-0")

    //$('.inputchck').addClass('inputchck2');

    //$('#chck' + 'ITEM00007' ).addClass('inputchck2');//OK

    //id = "chck' + _itemCodProd +'"

});

$('#testeSWAL').on("click", TestSweetAlert);

function TestSweetAlert() {
    swal({
        title: 1 + ' Issues for test',
        text: "A custom <span style='color:red;'>html</span> message.",
        html: true,
        type: "info",
        customClass: 'swal-wide',
        showCancelButton: true,
        showConfirmButton: false
    });
};


/**************************************************************/
var listaDetalleComprobante = new Array();
var arrayCabeceraComprobante = [];
/**************************************************************/

/* ///////////////////////////////////////////////////////////////////////
  TRES OPCIONES DE BOTONES PARA GENERAR LOS TRES TIPOS DE REPORTE
  1. CRYSTAL = ""    2. PDF = '&pdf=1'    3. EXCEL = '&excel=1'
/////////////////////////////////////////////////////////////////////////*/
//$('#btn-reporte-CRYSTAL').on('click', () => {
//    generarReporteComprobante('');
//});
$('#btn_generar_recibo_crystal').on('click', () => {
    generarReporteComprobante('');
});
$('#btn_generar_recibo_pdf').on('click', () => {
    //generarReporteComprobante('&pdf=1');
    updateCabeceraFromPntVnt();
});
$('#btn-reporte-EXCEL').on('click', () => {
    generarReporteComprobante('&excel=1');
});

$('#btn_enviar_correo_recibo_pdf').on('click', () => {
    //generarReporteComprobante('&email=1');
    enviarReciboPdfCorreo();
});


/*///////////////////////////////////////////////////////////////////////
  FUNCION GENERAR REPORTES CRYSTAL/PDF/EXCEL(usado por los tres botones)
///////////////////////////////////////////////////////////////////////*/
function generarReporteComprobante(tipoReporte) { //generarReporteCotizacion

     //alert("CABECERA ----> " + arrayCabeceraComprobante.length);
    //alert(tipoReporte);
    

    //if (tipoReporte == "&email=1") {


    //    if ($('#val_strEmailDestino').val() == "") {
    //        new PNotify({
    //            title: 'ENVIAR RECIBO POR CORREO',
    //            text: 'Ingrese el correo de destinatario.',
    //            type: 'info',
    //            delay: 2500,
    //            styling: 'bootstrap3',
    //            addclass: 'dark'
    //        });
    //        return;
    //    }


    //}


    if ($('#val_strNomCliente').val() == "" || $('#payment_method').val() == "") {
        new PNotify({
            title: 'GENERAR COMPRONANTE',
            text: 'Seleccione un método de Pago.',
            type: 'info',
            delay: 2500,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }
    //alert($('#vl_strNombreUsuarioSesion').text())

    arrayCabeceraComprobante.push({
          "rucCliente": $('#val_strRucCliente').val() 
        , "nomCliente": $('#val_strNomCliente').val() + ' ' + $('#val_strApeCliente').val()
        , "condVenta" : "23434234353" //_condVenta,
        , "moneda"    : $('#payment_method').val()
        , "vendedor"  : $('#vl_strNombreUsuarioSesion').text()
        , "dirCliente": $('#val_strDirCliente').val()
        , "tlfCliente": $('#val_strTelCliente').val()
    });




    //alert("CABECERA ----> " + arrayCabeceraComprobante.length);
    //alert("DETALLE  ----> " + listaDetalleComprobante.length);
    //Encabezado Vacia
    if (arrayCabeceraComprobante.length == 0) {
        //$.ambiance({
        //    message: 'Seleccionar un cliente del "Listado de Clientes".',
        //    title: "Añadir Producto a Cotizar",
        //    type: "error",
        //    timeout: 5,
        //    width: 500
        //});
        $('#contend-table-cliente').focus();
        return;
    }

    //Lista Detalle Vacia
    if (listaDetalleComprobante.length == 0) {
        //$.ambiance({
        //    message: 'Añadir por lo menos un item al "Listado de Productos a Cotizar".',
        //    title: "Añadir Producto a Cotizar",
        //    type: "error",
        //    timeout: 5,
        //    width: 500
        //});
        return;
    }

    var valorIgv = 1.18; //response[0].cboDes;
    let SubTotal = 0.0000;

    for (var i = 0; i < listaDetalleComprobante.length; i++) {
        SubTotal += roundDosDecimales(listaDetalleComprobante[i].tota);
    }

    ////VALORES TOTALES CALCULADOS
    //var _valorSubTotal = SubTotal
    //var _valorTotal = _valorSubTotal * valorIgv;
    //var _valorTotalIgv = _valorTotal - _valorSubTotal;


    //VALORES TOTALES CALCULADOS
    var _valorTotal    = SubTotal; //_valorSubTotal * valorIgv;
    var _valorSubTotal = SubTotal / valorIgv;
    var _valorTotalIgv = _valorTotal - _valorSubTotal;

    //VALORES TOTALES CALCULADOS
    var valorSubTotal = roundDosDecimales(_valorSubTotal.toFixed(2)).toString();
    var valorTotal    = roundDosDecimales(_valorTotalIgv.toFixed(2)).toString();
    var valorTotalIgv = roundDosDecimales(_valorTotal.toFixed(2)).toString();

    //alert(valorSubTotal );
    //alert(valorTotal    );
    //alert(valorTotalIgv);

    ////ENVIO DEL ENCABEZADO Y PIE DE PAGINA
    $.ajax({
        type: "POST",
        url: "/Rep/Vista/RepGenerarCotizacion.aspx/ListaCabeceraCotiz",
        data: JSON.stringify({ 'listadoCabeceraCotiz': arrayCabeceraComprobante, }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {

            //ENVIO DEL DETALLE
            $.ajax({
                type: "POST",
                url: "/Rep/Vista/RepGenerarCotizacion.aspx/ListaDetalleCotiz",
                data: JSON.stringify({ 'listDetalleComprobante': listaDetalleComprobante }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {

                    //filtroDeReporte_ = "Generar_Cotizacion";




                    ////String para el nombre del recibo
                    //var d = new Date();
                    //d.toLocaleString();       // -> "2/1/2013 7:37:08 AM"
                    //d.toLocaleDateString();   // -> "2/1/2013"
                    //d.toLocaleTimeString();   // -> "7:38:05 AM"

                    //var hora = d.getHours();
                    //var ampm = (hora >= 12) ? "PM" : "AM";

                    //filtroDeReporte_ = let_NombreReciboGenerado + '_' + d.toLocaleTimeString().replace(/:/g, "") + '_' + ampm; //https://pt.stackoverflow.com/questions/47639/removendo-caracteres-com-jquery


                    filtroDeReporte_ = let_NombreReciboGenerado; //https://pt.stackoverflow.com/questions/47639/removendo-caracteres-com-jquery



                    var splited = let_NombreReciboGenerado.split(' ');
                    //console.log(splited[3]);
                    // expected output: "fox"
                    _correlativo = splited[1];  //El tercero elemento del split

                    window.open('/Rep/Vista/RepGenerarCotizacion.aspx?filtroDeReporte='
                        + filtroDeReporte_

                        //+ roundDosDecimales(valorSubTotal.toFixed(2)).toString() //'&valorSubTotal=' + "50.5" //
                        //+ roundDosDecimales(valorTotalIgv.toFixed(2)).toString() // '&valorTotalIgv=' + "10.5" 
                        //+ roundDosDecimales(valorTotal.toFixed(2)).toString()    //'&valorTotal=' + "10.5" // 
                        + '&valorSubTotal=' + valorSubTotal
                        + '&valorTotalIgv=' + valorTotal
                        + '&valorTotal='    + valorTotalIgv
                        + '&vendedor='      + $('#vl_strNombreUsuarioSesion').text() // _vendedor
                        + '&condVenta='     + "AL CONTADO" // _condVenta
                        + '&moneda='        + "S"    // _moneda
                        + '&validez='       + "10"   // _validez
                        + '&correlativo='   +  _correlativo
                        + '&dateTimeVenta=' + let_FechaHoraVenta
                        + '&strEmailDestino=' + $('#val_strEmailDestino').val()
                        + '&strMetodoPago=' + $('#payment_method').val()

                        + tipoReporte                //---> CRYSTAL = "" , PDF = '&pdf=1' , EXCEL = '&excel=1'
                    );


                    arrayCabeceraComprobante.length = 0;
                    $('#btn_finalizar_venta_pntvnt').show();

                    //Habilitamos el enviar por correo el PDF generado

                    //btn_generar_recibo_pdf
                    //enviarCorreoRecibo
                    $('.enviarCorreoRecibo').show();



                },
                failure: function () {

                    alert("Failure!");
                }
            });


        },
        failure: function () {
            //alert("Failure!");
        }
    });


};


let let_intIdVentaCabe;
function updateCabeceraFromPntVnt() { 

    if ($('#val_strNomCliente').val() == "" || $('#payment_method').val() == "") {
        new PNotify({
            title: 'GENERAR COMPRONANTE',
            text: 'Seleccione un método de Pago.',
            type: 'info',
            delay: 2500,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }

   var _intIdVentaCabe      = let_intIdVentaCabe;
   var _strCodVenta         = " ";//$('#val_strEmailDestino').val();
   var _strRucCliente       = $('#val_strRucCliente').val();
   var _strNomCliente       = $('#val_strNomCliente').val();
   var _strApeCliente       = $('#val_strApeCliente').val();
   var _strMoneda           = " "; //$('#val_strEmailDestino').val();
   var _strDirCliente       = $('#val_strDirCliente').val();
   var _strTelCliente       = $('#val_strTelCliente').val();
   var _decMontoTotDeVenta  = " ";//$('#val_strEmailDestino').val();
   var _dttDateTimeVenta    = " ";//$('#val_strEmailDestino').val();
   var _strMedioDePago      = $('#payment_method').val();
   var _decPagoConIzipay    = "";//$('#val_strEmailDestino').val();


          
    var VentaCabe = {

           intIdVentaCabe      :  _intIdVentaCabe       
          ,strCodVenta         :  _strCodVenta       
          ,strRucCliente       :  _strRucCliente     
          ,strNomCliente       :  _strNomCliente     
          ,strApeCliente       :  _strApeCliente     
          ,strMoneda           :  _strMoneda         
          ,strDirCliente       :  _strDirCliente     
          ,strTelCliente       :  _strTelCliente     
          ,decMontoTotDeVenta  :  _decMontoTotDeVenta
          ,dttDateTimeVenta    :  _dttDateTimeVenta  
          ,strMedioDePago      :  _strMedioDePago    
          , decPagoConIzipay   :  _decPagoConIzipay  

    };




    //GESTVENT
    $.post(
        '/Procesos/InsertUpdateFromPuntoVenta',
        {
                  intTipoOperacion   : 2
                , strOperacion       : "UPDATE_CLIENTE"
                , intIdVentaCabe     : let_intIdVentaCabe
                , objVentaCabe       : VentaCabe
                , lstDetalleProducto : listaDetalleProductosVenta
                , lstRstVta          : lstResultProcesarVenta   

        },
        (response) => {


            //CASO 01: EL Json Contiene un OBJETO con las llaves: type, extramsg, ...
            //https://stackoverflow.com/questions/20804163/check-if-a-key-exists-inside-a-json-objecttype
            if (response.hasOwnProperty('type') || response.hasOwnProperty('extramsg') || response.hasOwnProperty('message')) {

                //alert('CASO 01: EL Json Contiene un OBJETO con las llaves type, extramsg, ...');     

                if (response.type !== '') {

                    if (response.type === 'success') {

                        //Despues de Actualizarse en la BD la Cabecera se genera el PDF(Recibo)
                        generarReporteComprobante('&pdf=1');

                        //swal({
                        //    title: 'GUARDAR RECIBO',
                        //    text: response.message
                        //});

                    }

                    else if (response.type === 'info') {

                        new PNotify({
                            title: 'GENERAR COMPROBANTE',
                            text: "Ocurrió un inconveniente al Generar el Comprobante",//response.message,
                            type: response.type,
                            delay: 2500,
                            styling: 'bootstrap3'
                        });

                    }
                }



            }


            //CASO 02: EL Json No contiene un OBJETO la llaves type, extramsg, ... sino un ARRAY de tipo lista
            //--> https://stackoverflow.com/questions/951483/how-to-check-if-a-json-response-element-is-an-array
            if (response.constructor === Array) {


                alert('CASO 02: EL Json No contiene un OBJETO la llaves type, extramsg, ... sino un ARRAY de tipo lista');  
                //response.forEach(item => {

                //    if (item.intRstVendido == 2) {

                //        $('#chck' + item.intIdProducto).prop('checked', true);
                //        $('#chck' + item.intIdProducto).addClass('inputchck2');//CHECK NARANJA
                //        //alert('1');
                //    }
                //    else {

                //        $('#chck' + item.intIdProducto).prop('checked', true);
                //        $('#chck' + item.intIdProducto).addClass('inputchck'); //CHECK VERDE
                //        //btn_procesar_venta_pntvnt  88888888
                //        //alert('2');

                //    }

             
                //});


            }


            //Traer el Numero de Recibo de Venta(Por el Momento sera el mismo ID de Venta desde VENTA_CABECERA)
            //--------------------------------------------------------------------------------------------------
    
            //--------------------------------------------------------------------------------------------------



            //var bodyJson = response.json();
            //tests["Response should not be an array"] = !Array.isArray(bodyJson['testA']); // false
            ////tests["Response should not be an array"] = !Array.isArray(bodyJson['testB']);  // true



            //alert('console.log(response)');
            console.log(response);

        });


}





//Llenamos en un objeto para llevarlo al aspx
arrayCabeceraComprobante = [];
//arrayCabeceraComprobante.push({
//      "rucCliente": "12315" //_rucCliente,
//    , "nomCliente": "Hebert" //_nomCliente,
//    , "condVenta" : "V001" //_condVenta,
//    , "moneda"    : "S" //_moneda,
//    , "vendedor"  : "Vendedor01" //_vendedor,
//    , "dirCliente": "AV Lima" //_dirEntCliente,
//    , "tlfCliente": "99999999" //_tlfCliente,
//});


//CONSTRUCTOR
class TT_PRODUCTOS {
    constructor
        (
        _idProdu
        , _codProdu
        , _cantProdu
        , _descProdu
        , _unidMedida
        , _marcaProdu
        , _nomfam
        , _nomsub
        , _nomgrup
        , _stkFisico
        , _stkDispon
        , _dsctPercent
        , _precio
        , _cost
        , _msto
        , _moneitem
        , _aigv
        , _tota
        , _totn





        ) {
        this.idProdu = _idProdu
        this.codProdu = _codProdu
        this.cantProdu = _cantProdu
        this.descProdu = _descProdu
        this.UM = _unidMedida
        this.marcaProdu = _marcaProdu
        this.nomfam = _nomfam
        this.nomsub = _nomsub
        this.nomgrup = _nomgrup
        this.stockFisico = _stkFisico
        this.stockDispon = _stkDispon
        this.dsctPercent = _dsctPercent
        this.precio = _precio
        this.cost = _cost
        this.msto = _msto
        this.moneitem = _moneitem
        this.aigv = _aigv
        this.tota = _tota
        this.totn = _totn

    }
}



/**
        listaDetalleComprobante.push(   //HGM3
            new TT_PRODUCTOS(
                  "20.5"  //_idProdu
                , "20.5"  //_codProducto
                , "20.5"  //_cantProducto.toString()
                , "Arena de Gato Pedigree"  //_descProdu
                , "Und"   //_unidMedida
                , "20.5"  //_marcaProdu
                , "20.5"  //_nomfamLinea
                , "20.5"  //_nomsubLinea
                , "20.5"  //_nomgrupTipo
                , "20.5"  //_stkFisico
                , "20.5"  //_stkDispon
                , "20.5"  //_dsctPercent
                , "20.5"  //_precio.toFixed(3)
                , "20.5"  //_cost
                , "20.5"  //_msto
                , "S"     //_moneitem
                , "18.1"  //_aigv
                , "20.5"  //_totaSinIgv
                , "20.5"  //_totnConIgv

            ));

**/





/***********************************************************************************************
                                 ENVIO AL CORREO DE LOS EXCEL EXPORTADOS
************************************************************************************************/
function EnviarExcelsExportadosPorCorreo2() {

    //alert();


    var strEmailDestino = "";

    strEmailDestino = $('#txtStrEmailDestino').val();

    if (strEmailDestino == "") {

        strEmailDestino = "gonzales.hebert@gmail.com"; //element.strDeEntidad;  &('#txtStrEmailDestino').val();

    }

    //TRAER LOS CORREOS DESTINATARIOS
    //////$.post(
    //////    '/Impresion/ListarTablasEnCombos',
    //////    { strNomTablaEntidad: 'EMAIL_DESTINO' },
    //////    (response) => {

    //response.forEach(element => {
    ////alert(strEmailDestino);
    //});

    //Terminacion si es un correo o varios correos

    if (typeof strEmailDestino === null || typeof strEmailDestino === "undefined" || strEmailDestino == "") {
        new PNotify({
            title: 'Enviar Correo',
            text: 'No existe ningún correo en la lista de destintarios.',
            type: 'info',
            delay: 2500,
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

    var idRadioCheck = "chck_excel2";
    ///INICIAR ENVIO A LOS CORREOS QUE ESTAN EN EL CAMPO "strEmailDestino" DE TSPARAMS
    $.ajax({
        url: '/Personal/EnviarCuatroExcelsPorCorreo2',
        type: 'POST',
        data: {

            strEmailDestino, idRadioCheck
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
                        title: 'Enviar a Correo',
                        text: response.message//$('#cbo_formatos option:selected').text() + 

                    });

                }

                else if (response.type === 'info') {

                    new PNotify({
                        title: 'Configuración',
                        text: response.message,
                        type: response.type,
                        delay: 2500,
                        styling: 'bootstrap3'
                    });

                }
            }


        },
        complete: function () {

            $.unblockUI();
        }
    });



    ////});




}

function roundDosDecimales(num) {
    var m = Number((Math.abs(num) * 100).toPrecision(15));
    return Math.round(m) / 100 * Math.sign(num);
}

function redondearDosDecimales(num) {
    return +(Math.round(num + "e+2") + "e-2");
}


var urchoice = document.getElementById('payment_method');
function chosePaymentMethod(method) {
    urchoice.value = method;
    return;
}








function enviarReciboPdfCorreo() {

    if ($('#val_strEmailDestino').val() == "") {
        new PNotify({
            title: 'ENVIAR RECIBO POR CORREO',
            text: 'Ingrese el correo de destinatario.',
            type: 'info',
            delay: 2500,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }



    blockLoader();

    //PUNTO DE VENTA
    $.post(
        '/Procesos/fctEnviarReciboPdfCorreo',
        {
              filtroDeReporte: let_NombreReciboGenerado
            , strEmailDestino: $('#val_strEmailDestino').val()

        },
        (response) => {


            unBlockLoader();

            if (response.hasOwnProperty('type') || response.hasOwnProperty('extramsg') || response.hasOwnProperty('message')) {

                //alert('CASO 01: EL Json Contiene un OBJETO con las llaves type, extramsg, ...');     
               
                swal("ENVIO DE COMPROBANTE POR CORREO", response.message);
            }


            //CASO 02: EL Json No contiene un OBJETO la llaves type, extramsg, ... sino un ARRAY de tipo lista
            if (response.constructor === Array) {

                //alert('CASO 02: EL Json No contiene un OBJETO la llaves type, extramsg, ... sino un ARRAY de tipo lista');  


                response.forEach(item => {

                    //////if (item.intRstVendido == 2) {

                    //////    $('#chck' + item.intIdProducto).prop('checked', true);
                    //////    $('#chck' + item.intIdProducto).addClass('inputchck2');//CHECK NARANJA
                    //////    //alert('1');
                    //////}
                    //////else {

                    //////    $('#chck' + item.intIdProducto).prop('checked', true);
                    //////    $('#chck' + item.intIdProducto).addClass('inputchck'); //CHECK VERDE
                    //////    //btn_procesar_venta_pntvnt  88888888
                    //////    //alert('2');

                    //////}

                });


            }



        });



}



