using CBX_Web_PetShopWeb.Models;
using CBX_Web_PetShopWeb.wsConfiguracion;
using CBX_Web_PetShopWeb.wsSistema;
using CBX_Web_PetShopWeb.wsSeguridad;//añadido 22.04.2021
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Management;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace CBX_Web_PetShopWeb.Controllers
{
    public class ConfiguracionController : Controller
    {

        private ConfiguracionSrvClient proxy;
        public static int intIdMenuGlo { get; set; }

        public JsonResult ValidarSession()
        {
            //if (ValidarConexWCF())//Existe comunicacion con el Publicado WCF
            //{
                if (!Auth.isAuthenticated())
                {
                    return Json(true);
                }


            return Json(false);

            //}
            //else
            //{
            //    return Json(true);
            //}
        }



        //HGM_COMENTADO
        /*
        //añadido 22.04.2021 para validar Conexión con el Publicado del Servidor únicamente.
        private SeguridadSrvClient SeguWCF;

        public bool ValidarConexWCF()
        {
            string version = "";
            try
            {
                using (SeguWCF = new SeguridadSrvClient())
                {
                    version = SeguWCF.wsVersion();
                    return true; //Si conecta al Servicio
                }
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ConfiguracionController.cs: Exception");
                version = "Verificar Web Service";//añadido 22.04.2021
                return false; //No conecta al Servicio
            }
        }

        */

        #region Mant. CONFIGURACION - SISACTIVOFIJO

        //11.3
        public JsonResult ListarImpresorasSaf()
        {
            string[] ImpresorasList = new string[] {}; 
            var printerQuery = new System.Management.ManagementObjectSearcher("SELECT * from Win32_Printer");
            foreach (var printer in printerQuery.Get())
            {
                var name = printer.GetPropertyValue("Name");
                var status = printer.GetPropertyValue("Status");
                var isDefault = printer.GetPropertyValue("Default");
                var isNetworkPrinter = printer.GetPropertyValue("Network");
                ImpresorasList = new List<string>(ImpresorasList) { name.ToString() }.ToArray();
            }

            return Json(ImpresorasList);

         }

        //11.1 GetTablaConfiguracion
        public JsonResult ListarConfigInicialSaf(wsConfiguracion.Session_Movi objSesion, string strCoConfi)
        {
            string strMsgUsuario = "";
            List<wsConfiguracion.TSParamsSaf> lista = new List<wsConfiguracion.TSParamsSaf>();
            try
            {
                using (proxy = new ConfiguracionSrvClient())
                {
                    lista = proxy.ListarConfigInicialSaf(objSesion, strCoConfi, ref strMsgUsuario).ToList();
                    proxy.Close();
                }
                return Json(lista);

            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ConfiguracionController.cs");
            }
            return Json(lista);
            //return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);

        }

        //11.2
        [HttpPost]
        public JsonResult ActualizarDetalleConfigSaf(wsConfiguracion.Session_Movi objSesion, string prmSalidaApp, 
            string prmAddOfic, string prmAddResp, string prmFilUbica, string prmOpcOpera, 
            string prmAreaxLocal, string prmModaTrab, string prmOutExcelxLocal, string prmImpresora, string strEmailDestino, string strParametro )
        {
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";

            try
            {
                bool update = false;

                using (proxy = new ConfiguracionSrvClient())
                { 
                    update = proxy.ActualizarDetalleConfigSaf(objSesion, prmSalidaApp, prmAddOfic, prmAddResp, prmFilUbica, 
                        prmOpcOpera, prmAreaxLocal, prmModaTrab, prmOutExcelxLocal, prmImpresora, strEmailDestino, strParametro, ref strMsgUsuario);
                    proxy.Close();
                }

                if (strMsgUsuario.Equals("") && update)
                {

                    if (strParametro == "AGREGAR_CORREO" && update)
                    {
                        result.type = "success";
                        result.message = "El Correo Añadido se ha Guardado Satisfactoriamente.";// "La actualización se realizó satisfactoriamente.";
                    }

                    else if (strParametro == "ELIMINAR_CORREO_S" && update)
                    {
                        result.type = "success";
                        result.message = "El correo se ha eliminado satisfactoriamente.";
                    }

                    else
                    {
                        result.type = "success";
                        result.message = "Todas las Configuraciones se Actualizaron Satisfactoriamente.";

                    }
                }
                else
                {
                    result.type = "info";
                    result.message = strMsgUsuario;
                }

            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ConfiguracionController.cs");
                result.type = "error";
                result.message = "Ocurrió un inconveniente al actualizar configuraciones";
            }

            return Json(result);
        }

        //11.3
        [HttpPost]
        public JsonResult GuardarConexionBaseDatosSqlSaf (wsConfiguracion.Session_Movi objSesion 
            ,string strServidor      
            ,string strBaseDatos     
            ,string strUsuario       
            ,string strContrasenia   
            ,string strAutenticacion 
            ,string strDirExcelCarga
            ,string strExcelGenerado 
            )
        {
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";

            try
            {
                bool update = false;

                using (proxy = new ConfiguracionSrvClient())
                {
                    update = proxy.GuardarConexionBaseDatosSqlSaf
                        (
                          objSesion
                        , strServidor      
                        , strBaseDatos     
                        , strUsuario       
                        , strContrasenia   
                        , strAutenticacion 
                        , strDirExcelCarga
                        , strExcelGenerado
                        , ref strMsgUsuario                        
                        );

                    proxy.Close();
                }

                if (strMsgUsuario.Equals("") && update)
                {

                    result.type = "success";
                    result.message = "Las Configuraciones Conexión a Base de Datos SQL se Guardaron Satisfactoriamente.";

                  
                }
                else
                {
                    result.type = "info";
                    result.message = strMsgUsuario;
                }

            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ConfiguracionController.cs");
                result.type = "error";
                result.message = "Ocurrió un inconveniente al guardar configuraciones";
            }

            return Json(result);
        }

        //11.4 
        public JsonResult ListarConfigConexionBaseDeDatos(wsConfiguracion.Session_Movi objSesion, string strCoConfi)
        {
            string strMsgUsuario = "";
            List<wsConfiguracion.TSParamsSaf> lista = new List<wsConfiguracion.TSParamsSaf>();
            try
            {
                using (proxy = new ConfiguracionSrvClient())
                {
                    lista = proxy.ListarConfigConexionBaseDeDatos(objSesion, strCoConfi, ref strMsgUsuario).ToList();
                    proxy.Close();
                }
                return Json(lista);

            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ConfiguracionController.cs");
            }
            return Json(lista);

        }


        //11.5 PRUEBA DE CONEXION BASE DE DATOS
        public JsonResult ProbarConexionBaseDatosSql()
        {
            CustomResponse result = new CustomResponse();

            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerConnection"].ConnectionString);
                connection.Open();
                if ((connection.State & ConnectionState.Open) > 0)
                {

                    result.type = "success";
                    result.message = "La Prueba de Conexión a la Base de Datos Local fue Satisfactoria.";
                    connection.Close();
                }
                else
                {
                    result.type = "info";
                    result.message = "La Conexión Falló.";

                }
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ConfiguracionController.cs");
                result.type = "error";
                result.message = "Ocurrió un inconveniente al probar la conexión";
            }

            return Json(result);
        }


        #endregion


        #region Campos Adicionales

        public ActionResult CamposAdicionales(string intIdMenu)
        {

            if (Auth.isAuthenticated())
            {
                intIdMenuGlo = Convert.ToInt32(intIdMenu);
                return View();
            }

            return RedirectToAction("CerrarSesion", "LoginSiscop");

        }
        public ActionResult NuevoCamposAdicionales()
        {
            string strMsgUsuario = "";
            List<Entidade> lista_Enti = new List<Entidade>();


            using (proxy = new ConfiguracionSrvClient())
            {
                lista_Enti = proxy.ListaraEntidades(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), ref strMsgUsuario).ToList();
                proxy.Close();
            }
            ViewBag.CampEnd = new SelectList(lista_Enti, "intIdEntid", "strNomEntid");
            object[] Datos = { ViewBag.CampEnd};

            return PartialView("_PartialNuevoCampoAdicional",Datos);
        }
        public JsonResult GetCampEntidades()
        {
            string strMsgUsuario = "";
            List<Entidade> lista_Enti = new List<Entidade>();

            try
            {
                using (proxy = new ConfiguracionSrvClient())
                {
                    lista_Enti = proxy.ListaraEntidades(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), ref strMsgUsuario).ToList();
                    proxy.Close();
                }
                return Json(lista_Enti);

            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ConfiguracionController.cs");
            }

            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);

        }

        #endregion Campos Adicionales

        #region Configuracion

        public ActionResult Configuracion(string intIdMenu)
        {
            if (Auth.isAuthenticated())
            {
                intIdMenuGlo = Convert.ToInt32(intIdMenu);
                return View();
            }

            return RedirectToAction("CerrarSesion", "LoginSiscop");
        }

        public JsonResult GetTablaConfiguracion(wsConfiguracion.Session_Movi objSesion, string strCoConfi)
        { 
            string strMsgUsuario = "";
            List<wsConfiguracion.TSConfi> lista = new List<wsConfiguracion.TSConfi>();
            try
            {
                using (proxy = new ConfiguracionSrvClient())
                {
                    lista = proxy.ListarConfig(objSesion, strCoConfi, ref strMsgUsuario).ToList();
                    proxy.Close();
                }
                return Json(lista);

            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ConfiguracionController.cs");
            }

            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);

        }

        [HttpPost]
        public JsonResult ActualizarConfiguracion(wsConfiguracion.Session_Movi objSesion, List<wsConfiguracion.TSConfi> detalleConfig)

        {
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";

            try
            {
                bool update = false;
                if (detalleConfig == null)
                    detalleConfig = new List<wsConfiguracion.TSConfi>();

                using (proxy = new ConfiguracionSrvClient())
                {

                    update = proxy.ActualizarConfig(objSesion, detalleConfig.ToArray(), ref strMsgUsuario);
                    proxy.Close();
                }

                if (strMsgUsuario.Equals("") && update)
                {
                    result.type = "success";
                    result.message = "Las configuraciones se actualizaron correctamente";
                }
                else
                {
                    result.type = "info";
                    result.message = strMsgUsuario;
                }

            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ConfiguracionController.cs");
                result.type = "error";
                result.message = "Ocurrió un inconveniente al actualizar configuraciones";
            }

            return Json(result);
        }

        #endregion Configuracion

    }
}
