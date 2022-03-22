using System;
using System.Collections.Generic;
using System.Web.Mvc;
/////////////////////////////DE LAS CARPETAS DEL SERVICE
using Dominio.Repositorio;
using Dominio.Entidades;

namespace CBX_Web_PetShopWeb.Controllers
{
    public class InicioController : Controller
    {

        //////////////////////////////////////////////////////HGM_AÑADIDO_19.08.2021_15:51:08 
        public ImportarExcelBL objImportarExcelBL = new ImportarExcelBL();
        ////////////////////////////////////////////////////

        #region Pagina Principal

        // GET: Inicio
        public ActionResult PaginaPrincipal()
        {
            if (Auth.isAuthenticated())
            {
                return View();
            }
            return RedirectToAction("CerrarSesion", "LoginSiscop");
        }

        //5.2.1.1  ----> de ListarDiasAusencia
        public JsonResult ListarDatosGraficaPie(string fechaInicio, string fechaFin, string strNombreDeTorta)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = 0;
            objSession.intIdUsuario = Auth.intIdUsuario();

            string strMsjUsuario = "";
            string strMsjDB = "";
            int intResult = 1;

            IList<DashboardTortas> ListObj = new List<DashboardTortas>();

            try
            {
                //using (proxy = new PersonalSrvClient())
                //{
                    ListObj = objImportarExcelBL.ListarDatosGraficaPie(objSession, strNombreDeTorta, fechaInicio, fechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                //}
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonaController.cs");
            }

            return Json(ListObj);
        }
        //5.0
        public JsonResult ListarTipoBienes(string fechaInicio, string fechaFin, int intIdPersonal)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = 0;
            objSession.intIdUsuario = Auth.intIdUsuario();

            string strMsjUsuario = "";
            string strMsjDB = "";
            int intResult = 1;

            IList<TSPTAASISTENCIA> ListObj = new List<TSPTAASISTENCIA>();

            try
            {
                //using (proxy = new PersonalSrvClient())
                //{
                    ListObj = objImportarExcelBL.ListarTipoBienes(objSession, intIdPersonal, fechaInicio, fechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                //}
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonaController.cs");
            }

            return Json(ListObj);
        }

        public JsonResult ListarCabeceras(string fechaInicio, string fechaFin, int intIdPersonal)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = 0;
            objSession.intIdUsuario = Auth.intIdUsuario();

            string strMsjUsuario = "";
            string strMsjDB = "";
            int intResult = 1;

            IList<HomeCabe> ListObj = new List<HomeCabe>();

            try
            {
                //using (proxy = new PersonalSrvClient())
                //{
                    ListObj = objImportarExcelBL.ListarCabeceras(objSession, intIdPersonal, fechaInicio, fechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                //}
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonaController.cs");
            }

            return Json(ListObj);
        }

        public JsonResult ListarHorasDescontadas(string fechaInicio, string fechaFin, int intIdPersonal)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = 0;
            objSession.intIdUsuario = Auth.intIdUsuario();

            string strMsjUsuario = "";
            string strMsjDB = "";
            int intResult = 1;

            IList<HorasDesc> ListObj = new List<HorasDesc>();

            try
            {
                //using (proxy = new PersonalSrvClient())
                //{
                    ListObj = objImportarExcelBL.ListarHorasDescontadas(objSession, intIdPersonal, fechaInicio, fechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                //}
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonaController.cs");
            }

            return Json(ListObj);
        }

        public JsonResult ListarHorasExtras(string fechaInicio, string fechaFin, int intIdPersonal)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = 0;
            objSession.intIdUsuario = Auth.intIdUsuario();

            string strMsjUsuario = "";
            string strMsjDB = "";
            int intResult = 1;

            IList<HorasDesc> ListObj = new List<HorasDesc>();
            try
            {
                //using (proxy = new PersonalSrvClient())
                //{
                    ListObj = objImportarExcelBL.ListarHorasExtras(objSession, intIdPersonal, fechaInicio, fechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                //}
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonaController.cs");
            }

            return Json(ListObj);
        }

        public JsonResult ListarAsistenciaDiaria(string fechaInicio, string fechaFin, int intIdPersonal)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = 0;
            objSession.intIdUsuario = Auth.intIdUsuario();

            string strMsjUsuario = "";
            string strMsjDB = "";
            int intResult = 1;

            IList<TSPTAASISTENCIA> ListObj = new List<TSPTAASISTENCIA>();

            try
            {
                //using (proxy = new PersonalSrvClient())
                //{
                ListObj = objImportarExcelBL.ListarAsistenciaDiaria(objSession, intIdPersonal, fechaInicio, fechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                //}
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonaController.cs");
            }

            return Json(ListObj);
        }


        #endregion


        /************

        public JsonResult ListarDiasAusencia(string fechaInicio, string fechaFin, int intIdPersonal)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = 0;
            objSession.intIdUsuario = Auth.intIdUsuario();

            string strMsjUsuario = "";
            string strMsjDB = "";
            int intResult = 1;

            IList<DiaAusen> ListObj = new List<DiaAusen>();

            try
            {
                using (proxy = new PersonalSrvClient())
                {
                    ListObj = proxy.ListarDiasAusencia(objSession, intIdPersonal, fechaInicio, fechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                }
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonaController.cs");
            }

            return Json(ListObj);
        }
         * *************/

    }
}
