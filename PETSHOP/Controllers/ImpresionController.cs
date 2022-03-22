using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CBX_Web_PetShopWeb.wsPersona;
using System.Net;
using System.Configuration;
using System.IO;

//using CBX_Web_PetShopWeb.wsSistema;
using CBX_Web_PetShopWeb.Models;


namespace CBX_Web_PetShopWeb.Controllers
{
    public class ImpresionController : Controller
    {

        private PersonalSrvClient proxy;
        public static int intIdMenuGlo { get; set; }

        //01
        //public static IList<TablaTbBienes> Listado;

        //14.0  VISTA DEL HTML 
        public ActionResult Etiquetas(string intIdMenu)
        {
            if (Auth.isAuthenticated())
            {
                intIdMenuGlo = Convert.ToInt32(intIdMenu);
                return View();
            }

            return RedirectToAction("CerrarSesion", "LoginSiscop");
        }

        //14.1  //ActionResult
        public JsonResult ListarTbBienesEtiquetas(
            string _local, string _area, string _oficina, string _codOficina, string _responsable, string _tipoBien, string _activoSerie,
            string _numColumnEtiquet, string _cantEtiquetsImp, string _anioInventario, string _impresora)
        {
            List<TablaTbBienes> Listado = new List<TablaTbBienes>();
            try
            {
                Session_Movi objSession = new Session_Movi();
                objSession.intIdSesion = Auth.intIdSesion();
                objSession.intIdSoft = Auth.intIdSoft();
                objSession.intIdMenu = intIdMenuGlo;
                objSession.intIdUsuario = Auth.intIdUsuario();

                int local = Convert.ToInt32(_local);
                int area = Convert.ToInt32(_area);
                int oficina = Convert.ToInt32(_oficina);
                int responsable = Convert.ToInt32(_responsable);
                int tipoBien = Convert.ToInt32(_tipoBien);
                string activoSerie = _activoSerie;
                int numColumnEtiquet = Convert.ToInt32(_numColumnEtiquet);
                int cantEtiquetsImp = Convert.ToInt32(_cantEtiquetsImp);
                string anioInventario = _anioInventario; //Convert.ToInt32(_anioInventario);
                string impresora = "epson";

                string strMsgUsuario = "";

                using (proxy = new PersonalSrvClient())
                {
                    Listado = proxy.ListarTbBienesEtiquetas(objSession, local, area, oficina, _codOficina, responsable, tipoBien, activoSerie,
                                                            numColumnEtiquet, cantEtiquetsImp, anioInventario, impresora, ref strMsgUsuario).ToList();

                    proxy.Close();
                }

                var json_ = Json(Listado, JsonRequestBehavior.AllowGet);
                json_.MaxJsonLength = 500000000;

                //return Json(list);
                return json_;
                //return Json(Listado);

            }
            catch (Exception ex)
            {

                Log.AlmacenarLogError(ex, "ImpresionController.cs");
            }

            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);

        }


        //14.2 
        public JsonResult ListarTablasEnCombos(string strNomTablaEntidad)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();

            string strMsgUsuario = "";
            List<TablasEnCombos> Listado = new List<TablasEnCombos>();

            using (proxy = new PersonalSrvClient())
            {
                Listado = proxy.ListarTablasEnCombos(objSession, strNomTablaEntidad, ref strMsgUsuario).ToList();
                proxy.Close();
            }
            return Json(Listado);
        }

        //14.3 
        public JsonResult GetObtenerAnioServer()
        {
            string strMsgUsuario = "";
            string anioDelServ = "";
            string strAnio;

            using (proxy = new PersonalSrvClient())
            {
                strAnio = proxy.ObtenerAnioServer(ref anioDelServ, ref strMsgUsuario);
                proxy.Close();
            }

            return Json(anioDelServ);

        }


        //14.4
        public JsonResult ValidarExistenciaFormato()
        {
            string strMsgUsuario = "";
            string anioDelServ = "";
            string strAnio;

            using (proxy = new PersonalSrvClient())
            {
                strAnio = proxy.ObtenerAnioServer(ref anioDelServ, ref strMsgUsuario);
                proxy.Close();
            }

            return Json(anioDelServ);

        }

        //14.5 CREAR LA CARPETA "FORMATOS" Y TRES ARCHIVOS DE TEXTO DENTRO
        public JsonResult CrearCarpetaFormatos()//getRutaDirImpotraExcel()  //GetRutaFormatos
        {
            CustomResponse result = new CustomResponse();
            string strRutaDir = "";          
            string rutaDirFormatos = "";
            string strRutaDirWebConfig = "rutaFormatos";

            //if (strRutaDir!="") { 
            strRutaDir = ConfigurationManager.AppSettings[strRutaDirWebConfig];
            //}

            if (!String.IsNullOrEmpty(strRutaDir))/*strRutaDir != "" && */
            {
                //Devuelve la ruta de esa carpeta creada(la ruta de la carpeta "formatos")
                //C:\Users\user\source\repos\SISACTIVOFIJO\Sln_CBX_Web_ACTIVOFIJO\CBX_Web_PetShopWeb\formatos\
                rutaDirFormatos = Path.Combine(HttpContext.Request.MapPath(strRutaDir));

                //Genera la ruta en una variable
                string folderPath = rutaDirFormatos;//@"D:\MiFolder"
                if (!Directory.Exists(folderPath))
                {
                    //Crea la carpeta
                    Directory.CreateDirectory(folderPath);
                    Console.WriteLine(folderPath);

                    //Crear los tres archivos de texto
                    FileStream f1 = System.IO.File.Create(rutaDirFormatos + "\\Formato1.txt");
                    FileStream f2 = System.IO.File.Create(rutaDirFormatos + "\\Formato2.txt");
                    FileStream f3 = System.IO.File.Create(rutaDirFormatos + "\\Formato3.txt");

                    //Desenlazarlos del IIS para poder trabajarlos
                    f1.Close();
                    f2.Close();
                    f3.Close();

                }

                result.message = "";
                result.type = "success";

            }
            else
            {
                result.message = "La ruta '" + strRutaDirWebConfig +"' donde debe generarse \n la carpeta 'formatos' no existe o ha sido modificada.";
                result.type   = "info";

            }
            
            return Json(result);
        }


        //14.6 Get Fotmado By Id
        public JsonResult GetRutaFormatoFromTbBienesById(int intIdFormato, string strFormatoSelected, string strNomTablaEntidad)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();

            //MENSAJES
            CustomResponse result = new CustomResponse();

            string strMsgUsuario = "";
            List<TablasEnCombos> Listado = new List<TablasEnCombos>();

            using (proxy = new PersonalSrvClient())
            {
                Listado = proxy.GetRutaFormatoFromTbBienesById(objSession, intIdFormato, strNomTablaEntidad, ref strMsgUsuario).ToList();
                proxy.Close();
            }



            //CAPTURA LA RUTA DEL DIRECTORIO
            string strRutaDirFormatos = "";
            strRutaDirFormatos = ConfigurationManager.AppSettings["rutaFormatos"];
            string rutaDirFormatos = Path.Combine(HttpContext.Request.MapPath(strRutaDirFormatos));

            var txtFormato = Listado[0].strDeEntidad;
            if (txtFormato != "")
            {
                string txtFormatoSplit = txtFormato.Substring(txtFormato.IndexOf("s") + 2);
                string txtFormatoSplit4 = txtFormato.Substring(txtFormato.Length - 4);
                int existe = 0;

                string txtFormatoTxt = txtFormato.Substring(2, txtFormato.Length - 15);
                try
                {

                    string[] arreglo = Directory.GetFiles(rutaDirFormatos, "*.txt");


                    foreach (string i in arreglo)
                    {
                        if (i.Contains(txtFormatoSplit))
                        {
                            existe = 1;

                        }

                    }

                    if (existe == 1)
                    {
                        ////result.type = "success";
                        ////result.message = "El Formato Sí Existe en el Directorio";

                    }
                    else
                    {

                        result.type = "info";
                        result.message = strFormatoSelected + " no existe, por favor crearlo dentro de la carpeta " + txtFormatoTxt + " con el mismo nombre seleccionado.";

                    }

                }
                catch (Exception ex)
                {

                    Log.AlmacenarLogError(ex, "ImpresionController.cs");
                    result.type = "info";
                    result.message = "La carpeta " + "'" + txtFormatoTxt + "'" + " no existe o fue renombrada.";


                }

            }

            else
            {

                result.type = "info";
                result.message = "Para el Formato " +"'"+ strFormatoSelected + "'" + " seleccionado no existe una ruta en el campo de la tabla.";

            }

            return Json(result);//Listado
        }


    }
}
