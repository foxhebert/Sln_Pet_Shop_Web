//using CBX_Web_PetShopWeb.wsSeguridad;
//using CBX_Web_PetShopWeb.wsPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CBX_Web_PetShopWeb.Models;
using Dominio.Repositorio;
using Dominio.Entidades;

namespace CBX_Web_PetShopWeb.Controllers
{
    public class SeguridadController : Controller
    {
        //private SeguridadSrvClient Seguridad_tsp;
        //private PersonalSrvClient proxyOrg;
        //////////////////////////////////////////////////////HGM_AÑADIDO_19.08.2021_15:51:08 
        public TSConfiBL objTSConfiBL = new TSConfiBL();
        public UsuarioBL objUsuarioBL = new UsuarioBL();
        public ImportarExcelBL objImportarExcelBL = new ImportarExcelBL();
        public PerfilBL objPerfilBL = new PerfilBL();
        public GlobalBL objGlobalBL = new GlobalBL();        
        ////////////////////////////////////////////////////
        public static int intIdMenuGlo { get; set; }

        #region Perfil_SAF
        //1.1.0 
        public ActionResult Perfil(string intIdMenu)
        {
            if (Auth.isAuthenticated())
            {
                intIdMenuGlo = Convert.ToInt32(intIdMenu);
                return View();
            }
            return RedirectToAction("CerrarSesion", "LoginSiscop");
        }
        //1.1.2  OK
        public JsonResult GetTablaPerfil(int intActivo, string strDescripcion)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();

            string strMsgUsuario = "";
            try
            {
                List<TS_PERFIL> ListarPerfil = new List<TS_PERFIL>();
                //SeguridadSrvClient Seguridad_tsp;
                //using (Seguridad_tsp = new SeguridadSrvClient())
                //{
                    ListarPerfil = objPerfilBL.ListarPerfil(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), intActivo, strDescripcion, ref strMsgUsuario).ToList();
                //    Seguridad_tsp.Close();
                //}
                return Json(ListarPerfil);
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "SeguridadController.cs");
            }

            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        }
        //1.1.3 
        public JsonResult EliminarPerfil( int intIdPerfil)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();

            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";
            try
            {
                bool delete = false;

                //using (Seguridad_tsp = new SeguridadSrvClient())
                //{
                    delete = objPerfilBL.EliminarPerfil(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), Auth.intIdUsuario(), intIdPerfil, ref strMsgUsuario);
                //    Seguridad_tsp.Close();
                //}

                if (strMsgUsuario.Equals("") && delete)
                {
                    result.type = "success";
                    result.message = "El registro fue eliminado correctamente";
                }
                else
                {
                    result.type = "error";
                    result.message = strMsgUsuario;
                }
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "SeguridadController.cs");
                result.type = "error";
                result.message = "Ocurrió un inconveniente al eliminar el registro";
            }
            return Json(result);
        }
        //1.1.4 
        public JsonResult ObtenerListadoSubMenus(int intActivo, string strDescripcion)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();

            try
            {
                string strMsgUsuario = "";
                List<TS_MENU> detConcepto = new List<TS_MENU>();
                //using (Seguridad_tsp = new SeguridadSrvClient())
                //{
                    detConcepto = objPerfilBL.ListarMenuSubMenus(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), intActivo, strDescripcion, ref strMsgUsuario).ToList();
                //}
                return Json(detConcepto);
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "SeguridadController.cs");
            }
            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        }
        //1.1.5 
        public JsonResult ObtenerRegistroPerfil( int IntIdPerfil)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();

            try
            {
                string strMsgUsuario = "";
                List<TS_PERFIL> detConcepto = new List<TS_PERFIL>();
                //using (Seguridad_tsp = new SeguridadSrvClient())
                //{
                    detConcepto = objPerfilBL.ObtenerRegistroPerfil(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), IntIdPerfil, ref strMsgUsuario).ToList();
                //}
                return Json(detConcepto);
            }
            catch (Exception ex)
            {

                Log.AlmacenarLogError(ex, "SeguridadController.cs");
            }
            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        }
        //1.1.6 
        public JsonResult InsertUpdatePerfil( TS_PERFIL ObjPerfil, List<TT_TSPERFIL_MENU> listaDetallesPerfil,int intTipoOperacion)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();

            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";

            try
            {
                bool insert = false;

                //using (Seguridad_tsp = new SeguridadSrvClient())
                //{
                    insert = objPerfilBL.InsertarOrUpdatePerfil(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), 
                        ObjPerfil, listaDetallesPerfil, Auth.intIdUsuario(), intTipoOperacion, ref strMsgUsuario); //listaDetallesPerfil.ToArray()
                //    Seguridad_tsp.Close();
                //}

                if (strMsgUsuario.Equals("") && insert)
                {
                    result.type = "success";
                    if (intTipoOperacion == 1)
                    {
                        result.message = "El registro se insertó satisfactoriamente.";
                    }
                    else
                    {
                        result.message = "El registro se actualizó satisfactoriamente.";
                    }
                }
                else
                {
                    if (strMsgUsuario.Contains("código"))
                    {
                        result.type = "codigo";
                        result.message = strMsgUsuario;
                    }
                    else
                    {
                        if (strMsgUsuario.Contains("descripción"))
                        {
                            result.type = "descripcion";
                            result.message = strMsgUsuario;
                        }
                        else
                        {
                            result.type = "error";
                            result.message = strMsgUsuario;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "SeguridadController.cs");
                result.type = "errorInt";
                if (intTipoOperacion == 1)
                {
                    result.message = "Ocurrió un inconveniente al insertar el Perfil";
                }
                else
                {
                    result.message = "Ocurrió un inconveniente al actualizar el Perfil";
                }
            }
            return Json(result);
        }

        #endregion

        #region Usuarios_SAF

        public ActionResult Usuarios(string intIdMenu)
        {
            if (Auth.isAuthenticated())
            {
                intIdMenuGlo = Convert.ToInt32(intIdMenu);
                return View();
            }
            return RedirectToAction("CerrarSesion", "LoginSiscop");
        }

        public JsonResult GetTablaUsuario(int intActivo, string strDescripcion, int intPerfil)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();
            string strMsgUsuario = "";

            try
            {
                List<TG_USUARIO> ListarPerfil = new List<TG_USUARIO>();
                //SeguridadSrvClient Seguridad_tsp;
                //using (Seguridad_tsp = new SeguridadSrvClient())
                //{
                    ListarPerfil = objUsuarioBL.ListarUsuarios(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), intActivo, strDescripcion, intPerfil, ref strMsgUsuario).ToList();
                //    Seguridad_tsp.Close();
                //}
                return Json(ListarPerfil);
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "SeguridadController.cs");
            }
            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        }

        public JsonResult EliminarUsuario(int intIdUsu)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();

            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";

            try
            {
                bool delete = false;
                //using (Seguridad_tsp = new SeguridadSrvClient())
                //{
                    delete = objUsuarioBL.EliminarUsuario(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), Auth.intIdUsuario(), intIdUsu, ref strMsgUsuario);
                //    Seguridad_tsp.Close();
                //}

                if (strMsgUsuario.Equals("") && delete)
                {
                    result.type = "success";
                    result.message = "El registro fue eliminado correctamente";
                }
                else
                {
                    result.type = "error";
                    result.message = strMsgUsuario;
                }
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "SeguridadController.cs");
                result.type = "error";
                result.message = "Ocurrió un inconveniente al eliminar el registro";
            }
            return Json(result);
        }

        public JsonResult ObtenerRegistroUsuario( int IntIdUsuar)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();

            string strMsgUsuario = "";
            try
            {
                List<TG_USUARIO> detConcepto = new List<TG_USUARIO>();
                //using (Seguridad_tsp = new SeguridadSrvClient())
                //{
                    detConcepto = objUsuarioBL.ObtenerRegistroUsuario(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), IntIdUsuar, ref strMsgUsuario).ToList();
                //}
                return Json(detConcepto);
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "SeguridadController.cs");
            }
            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        }

        public JsonResult InsertUpdateUsuario( TG_USUARIO ObjUsuario, List<TSUSUAR_PERFI> listaDetallesUsuarioPerfil, List<TT_TSUSUAR_FILTRO> listaDetallesUsuarioFiltro, int intTipoOperacion)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();

            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";

            if (listaDetallesUsuarioPerfil == null)
                listaDetallesUsuarioPerfil = new List<TSUSUAR_PERFI>();
            if (listaDetallesUsuarioFiltro == null)
                listaDetallesUsuarioFiltro = new List<TT_TSUSUAR_FILTRO>();

            try
            {
                bool insert = false;
                //using (Seguridad_tsp = new SeguridadSrvClient())
                //{
                    insert = objUsuarioBL.InsertOrUpdateUsuario(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), ObjUsuario, listaDetallesUsuarioPerfil, listaDetallesUsuarioFiltro, Auth.intIdUsuario(), intTipoOperacion, ref strMsgUsuario); //.ToArray() .ToArray()
                //    Seguridad_tsp.Close();
                //}

                if (strMsgUsuario.Equals("") && insert)
                {
                    result.type = "success";
                    if (intTipoOperacion == 1)
                    {
                        result.message = "El registro se insertó satisfactoriamente.";
                    }
                    else
                    {
                        result.message = "El registro se actualizó satisfactoriamente.";
                    }
                }
                else
                {
                    if (strMsgUsuario.Contains("usuario"))
                    {
                        result.type = "usuario";
                        result.message = strMsgUsuario;
                    }
                    else
                    {
                        result.type = "error";
                        result.message = strMsgUsuario;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "SeguridadController.cs");
                result.type = "errorInt";
                if (intTipoOperacion == 1)
                {
                    result.message = "Ocurrió un inconveniente al insertar el Usuario";
                }
                else
                {
                    result.message = "Ocurrió un inconveniente al actualizar el Usuario";
                }
            }
            return Json(result);
        }

        #endregion

        #region Maestro Caracteres
        //Maestro Caracteres Para los Mant. Perfil y Usuarios
        public JsonResult getMaestroCaracteres(string strTableName)
        {
            try
            {
                //modificado, para usar el proxyOrg del Servicio Persona y no Packing.
                List<MaestroCaracteres> ListarCaracteres = new List<MaestroCaracteres>();
                //using (proxyOrg = new PersonalSrvClient())
                //{
                    ListarCaracteres = objGlobalBL.MaestroMaxCaracteres(strTableName).ToList(); //desde wsPacking;
                //    proxyOrg.Close();
                //}
                return Json(ListarCaracteres);
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "SeguridadController.cs");
            }
            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        }

        #endregion

    }
}
