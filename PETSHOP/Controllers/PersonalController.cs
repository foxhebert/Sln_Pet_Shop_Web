//using CBX_Web_PetShopWeb.wsPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CBX_Web_PetShopWeb.Models;
using System.IO;
using System.Configuration;
using System.Text;// 'Encoding' does not exist in the current context

//PARA EL METODO USADO EN WEBSOCKET
using System.Data;
using ExcelDataReader;

/////////////////////////////DE LAS CARPETAS DEL SERVICE
using Dominio.Repositorio;
using Dominio.Entidades;

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Net;
using Dominio.Repositorio.Util;
using Infraestructura.Data.SqlServer;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Transactions;

//using System.Transactions;

using Microsoft.Office.Interop;
//using Microsoft.Office.Interop.Excel;

using Excel = Microsoft.Office.Interop.Excel;
using Marshal = Microsoft.Office.Interop.Excel;

using System.Text.RegularExpressions; //Quitar tildes a un string

//using CsvHelper;//Se instalo con el NuGet






/////////////////////////////DE LAS CARPETAS DEL SERVICE
//using Dominio.Repositorio;
//using Dominio.Entidades;








namespace CBX_Web_PetShopWeb.Controllers
{
    public class PersonalController : Controller
    {


        //////////////////////////////////////////////////////HGM_AÑADIDO_19.08.2021_15:51:08 
        public TSConfiBL objTSConfiBL = new TSConfiBL();
        public UsuarioBL objUsuarioBL = new UsuarioBL();
        public ImportarExcelBL objImportarExcelBL = new ImportarExcelBL();
        public PerfilBL objPerfilBL = new PerfilBL();
        public ReportesBL objReportesBL = new ReportesBL();
        ////////////////////////////////////////////////////

        public static int    intIdMenuGlo { get; set; }
        public static string nombreExcel { get; set; }
        public static int    idProceso { get; set; }
        public static string rutaDirectorioExcel { get; set; }
        public static int    idP { get; set; }

        [HttpPost]
        public JsonResult KeepSessionAlive()
        {
            return new JsonResult { Data = "Success" };
        }


        #region Exportar Datos
        //////////////////////////////////////////////////////////
        //VIEW EXPORTAR DATOS
        //////////////////////////////////////////////////////////
        public ActionResult ExportarDatos(string intIdMenu)
        {
            if (Auth.isAuthenticated())
            {
                intIdMenuGlo = Convert.ToInt32(intIdMenu);
                return View();
            }

            return RedirectToAction("CerrarSesion", "LoginSiscop");
        }

        //////////////////////////////////////////////////////////
        //LISTAS GLOBALES Y ESTATICAS (EXCEL)
        //////////////////////////////////////////////////////////
        public static IList<TMPRODU_EXPORTAR> listaTMPRODU;

        //////////////////////////////////////////////////////////
        //30.1 desde '/Reportes/GenerarListasDeCadaTabla'
        //////////////////////////////////////////////////////////
        public ActionResult GenerarListaExportar(string strArchivoExportado) 
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();
            string strMsgUsuario = "";
            int resultado = 0;

            try
            {

                if (strArchivoExportado == "TMPRODU")
                {

                    listaTMPRODU = objReportesBL.GenerarListaExportarInventario(objSession, strArchivoExportado, ref strMsgUsuario).ToList();
                    resultado = listaTMPRODU.Count;

                }

                if (strArchivoExportado == "TMINVENTARIO")
                {

                    listaTMPRODU = objReportesBL.GenerarListaExportarInventario(objSession, strArchivoExportado, ref strMsgUsuario).ToList();
                    resultado = listaTMPRODU.Count;

                }

            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ProcesoController.cs");
            }

            return Json(resultado);

        }

        //////////////////////////////////////////////////////////
        //30.2 GENERAR ARCHIVOS DE TEXTO
        //////////////////////////////////////////////////////////
        public void GenerarArchivosExportar(string strArchivoExportado, string idRadioCheck, string strCamposOpcionales )
        {
            /****************************************************************************************
             * En este método se genera 01 archivo de texto con dos campos separados por una COMA 
             * Tiene que utilizar una lista previamente en el controlador con los datos a tratar.
             * Ese listado es traido desde la tabla TMPRODU 
             ****************************************************************************************/
             ///OK
            if (strArchivoExportado == "TMINVENTARIO" && idRadioCheck == "chck_txt_coma")
            {

                //La lista "listaBienesDsTxt" pasarlo al documento txt separados por coma 
                System.IO.File.Create(Server.MapPath("~/TMINVENTARIO.txt")).Close();
                //Leemos row por row lo que contiene la lista

                string strNomArchivo = strArchivoExportado + ".txt";

                //1
                if (strCamposOpcionales == "")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         //// join with "," following properties:
                         //item.strCoProdu,
                         //item.intCantidad
                         item.nvcCoProdu
                       , item.intNuRegis
                     ))
                  );
                }

                //2
                if (strCamposOpcionales == ",Almacén,Fecha,Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //3,Fecha,Almacén,Campo Aux.,Ubicación,Terminal
                if (strCamposOpcionales == ",Fecha,Almacén,Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                        //// join with "," following properties:
                        //item.strCoProdu,
                        //item.intCantidad
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //4
                if (strCamposOpcionales == ",Fecha,Almacén,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );

                }
                //5
                if (strCamposOpcionales == ",Fecha,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux

                     ))
                  );

                }
                //6
                if (strCamposOpcionales == ",Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );

                }
                //7
                if (strCamposOpcionales == ",Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                     ))
                  );

                }

                //8
                if (strCamposOpcionales == ",Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //9
                if (strCamposOpcionales == ",Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //10
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //11
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //12
                if (strCamposOpcionales == ",Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //13
                if (strCamposOpcionales == ",Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //14
                if (strCamposOpcionales == ",Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                ///////////////////////////////////////
                //15
                if (strCamposOpcionales == ",Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //16
                if (strCamposOpcionales == ",Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //17
                if (strCamposOpcionales == ",Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //18
                if (strCamposOpcionales == ",Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //19
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //20
                if (strCamposOpcionales == "Almacén,Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //21
                if (strCamposOpcionales == ",Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis  
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //22
                if (strCamposOpcionales == ",Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //23
                if (strCamposOpcionales == ",Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //24
                if (strCamposOpcionales == ",Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //25
                if (strCamposOpcionales == ",Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //26
                if (strCamposOpcionales == ",Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //27
                if (strCamposOpcionales == ",Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //28
                if (strCamposOpcionales == ",Terminal,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //29
                if (strCamposOpcionales == ",Terminal,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //30
                if (strCamposOpcionales == ",Fecha,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //31
                if (strCamposOpcionales == ",Fecha,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //32
                if (strCamposOpcionales == ",Almacén,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //33 
                if (strCamposOpcionales == ",Almacén,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //34
                if (strCamposOpcionales == ",Almacén,Terminal,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo +""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //35
                if (strCamposOpcionales == ",Terminal,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //36
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //37
                if (strCamposOpcionales == ",Fecha,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //38
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //39
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //40
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //41,Terminal,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //42,Terminal,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //43,Ubicación,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //44,Ubicación,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //45,Campo Aux.,Terminal,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //46,Campo Aux.,Almacén,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //47,Campo Aux.,Terminal,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //48,Terminal,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //49,Terminal,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //50,Almacén,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //51,Almacén,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //52,Campo Aux.,Fecha,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //53,Campo Aux.,Ubicación,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //54,Ubicación,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //55,Ubicación,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //56,Fecha,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //57,Fecha,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //58,Fecha,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //59,Campo Aux.,Almacén,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //60,Campo Aux.,Fecha,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //61,Almacén,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //62,Almacén,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //63,Almacén,Fecha,Ubicación
                if (strCamposOpcionales == ",Almacén,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //64,Almacén,Ubicación,Fecha
                if (strCamposOpcionales == ",Almacén,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //65,Fecha,Almacén,Ubicación
                if (strCamposOpcionales == ",Fecha,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //66,Fecha,Ubicación,Almacén
                if (strCamposOpcionales == ",Fecha,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //67,Ubicación,Almacén,Fecha
                if (strCamposOpcionales == ",Ubicación,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //68,Ubicación,Fecha,Almacén
                if (strCamposOpcionales == ",Ubicación,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //69,Almacén,Ubicación,Terminal
                if (strCamposOpcionales == ",Almacén,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //70,Almacén,Terminal,Ubicación
                if (strCamposOpcionales == ",Almacén,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //71,Ubicación,Almacén,Terminal
                if (strCamposOpcionales == ",Ubicación,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //72,Ubicación,Terminal,Almacén
                if (strCamposOpcionales == ",Ubicación,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //73,Terminal,Ubicación,Almacén
                if (strCamposOpcionales == ",Terminal,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //74,Terminal,Almacén,Ubicación
                if (strCamposOpcionales == ",Terminal,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //75,Ubicación,Fecha,Terminal
                if (strCamposOpcionales == ",Ubicación,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //76,Ubicación,Terminal,Fecha
                if (strCamposOpcionales == ",Ubicación,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //77,Fecha,Ubicación,Terminal
                if (strCamposOpcionales == ",Fecha,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //78,Fecha,Terminal,Ubicación
                if (strCamposOpcionales == ",Fecha,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //79,Terminal,Ubicación,Fecha
                if (strCamposOpcionales == ",Terminal,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //80,Terminal,Fecha,Ubicación
                if (strCamposOpcionales == ",Terminal,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //81,Almacén,Fecha,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Almacén,Fecha,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //82,Almacén,Fecha,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Fecha,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //83,Almacén,Ubicación,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Ubicación,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //84,Almacén,Ubicación,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Almacén,Ubicación,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //85,Almacén,Campo Aux.,Fecha,Ubicación
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //86,Almacén,Campo Aux.,Ubicación,Fecha
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //87,Fecha,Almacén,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Almacén,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //88,Fecha,Campo Aux.,Ubicación,Almacén
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //89,Fecha,Campo Aux.,Almacén,Ubicación
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //90,Fecha,Ubicación,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Fecha,Ubicación,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //91,Fecha,Ubicación,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Ubicación,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //92,Campo Aux.,Almacén,Fecha,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //93,Campo Aux.,Almacén,Ubicación,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //94,Campo Aux.,Fecha,Almacén,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //95,Campo Aux.,Fecha,Ubicación,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //96,Campo Aux.,Ubicación,Fecha,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //97,Campo Aux.,Ubicación,Almacén,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //98,Ubicación,Almacén,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Almacén,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //99,Ubicación,Almacén,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Ubicación,Almacén,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //100,Ubicación,Fecha,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Ubicación,Fecha,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //101,Ubicación,Fecha,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Fecha,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //102,Ubicación,Campo Aux.,Almacén,Fecha
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //103,Ubicación,Campo Aux.,Fecha,Almacén
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //104,Ubicación,Campo Aux.,Fecha,Terminal
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //105,Ubicación,Campo Aux.,Terminal,Fecha
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //106,Ubicación,Fecha,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Ubicación,Fecha,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //107,Ubicación,Fecha,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Fecha,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //108,Ubicación,Terminal,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Ubicación,Terminal,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //109,Ubicación,Terminal,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Terminal,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //110,Campo Aux.,Ubicación,Fecha,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //111,Campo Aux.,Ubicación,Terminal,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //112,Campo Aux.,Fecha,Ubicación,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //113,Campo Aux.,Fecha,Terminal,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //114,Campo Aux.,Terminal,Fecha,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //115,Campo Aux.,Terminal,Ubicación,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //116,Fecha,Terminal,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Fecha,Terminal,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //117,Fecha,Terminal,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Terminal,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //118,Fecha,Campo Aux.,Ubicación,Terminal
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //119,Fecha,Campo Aux.,Terminal,Ubicación
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //120,Fecha,Ubicación,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Fecha,Ubicación,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //121,Fecha,Ubicación,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Ubicación,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //122,Terminal,Fecha,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Terminal,Fecha,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //123,Terminal,Fecha,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Fecha,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //124,Terminal,Campo Aux.,Fecha,Ubicación
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //125,Terminal,Campo Aux.,Ubicación,Fecha
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //126,Terminal,Ubicación,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Terminal,Ubicación,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //127,Terminal,Ubicación,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Ubicación,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //128,Terminal,Ubicación,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Terminal,Ubicación,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //129,Terminal,Ubicación,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Ubicación,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //130,Terminal,Campo Aux.,Ubicación,Almacén
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //131,Terminal,Campo Aux.,Almacén,Ubicación
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //132,Terminal,Almacén,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Terminal,Almacén,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //133,Terminal,Almacén,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Almacén,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //134,Ubicación,Terminal,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Ubicación,Terminal,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //135,Ubicación,Terminal,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Terminal,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //136,Ubicación,Campo Aux.,Almacén,Terminal
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //137,Ubicación,Campo Aux.,Terminal,Almacén
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //138,Ubicación,Almacén,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Almacén,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //139,Ubicación,Almacén,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Ubicación,Almacén,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //140,Almacén,Ubicación,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Almacén,Ubicación,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //141,Almacén,Ubicación,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Ubicación,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //142,Almacén,Campo Aux.,Terminal,Ubicación
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //143,Almacén,Terminal,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Almacén,Terminal,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //144,Almacén,Terminal,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Terminal,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //145,Campo Aux.,Almacén,Terminal,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //146,Campo Aux.,Almacén,Ubicación,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //147,Campo Aux.,Terminal,Almacén,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //148,Campo Aux.,Terminal,Ubicación,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //159,Campo Aux.,Ubicación,Almacén,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //150,Campo Aux.,Ubicación,Terminal,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //151,Campo Aux.,Fecha,Almacén,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //152,Campo Aux.,Fecha,Terminal,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //153,Campo Aux.,Almacén,Fecha,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //154,Campo Aux.,Almacén,Terminal,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //155,Campo Aux.,Terminal,Almacén,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //156,Campo Aux.,Terminal,Almacén,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //157,Fecha,Terminal,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Terminal,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //158,Fecha,Terminal,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Fecha,Terminal,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //159,Fecha,Campo Aux.,Almacén,Terminal
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //160,Fecha,Campo Aux.,Terminal,Almacén
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //161,Fecha,Almacén,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Almacén,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //162,Fecha,Almacén,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Fecha,Almacén,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //163,Almacén,Fecha,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Almacén,Fecha,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //164,Almacén,Fecha,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Fecha,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //165,Almacén,Campo Aux.,Fecha,Terminal
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //166,Almacén,Campo Aux.,Terminal,Fecha
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //167,Almacén,Terminal,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Almacén,Terminal,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //168,Terminal,Almacén,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Almacén,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //169,Terminal,Almacén,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Terminal,Almacén,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //170,Terminal,Fecha,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Terminal,Fecha,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //171,Terminal,Fecha,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Fecha,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //172,Terminal,Campo Aux.,Fecha,Almacén
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //173,Terminal,Campo Aux.,Almacén,Fecha
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }


                //////////////////////////////////////////////////////////////DE DOS
                //,Terminal,Ubicación
                if (strCamposOpcionales == ",Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //,Ubicación,Almacén
                if (strCamposOpcionales == ",Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     )), Encoding.UTF8 
                  );
                }
                //220,Campo Aux.,Ubicación,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //221,Almacén,Fecha,Ubicación,Terminal
                if (strCamposOpcionales == ",Almacén,Fecha,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }

                //////////////////////////////////////////////////////////////////
                ////////////
                //////////if (strCamposOpcionales == "")
                //////////{
                //////////    System.IO.File.WriteAllLines(Server.MapPath("~/TMINVENTARIO.txt"), listaTMPRODU
                //////////    .Select(item => string.Join(",",
                //////////         item.nvcCoProdu
                //////////       , item.intNuRegis
                //////////       , item.nvcNoAlmac
                //////////       , item.dttFeRegis
                //////////       , item.nvcCoCampoAux
                //////////       , item.nvcNoUbica
                //////////       , item.intNuTermi
                //////////     ))
                //////////  );
                //////////}
                ////if (strCamposOpcionales == ",Almacén,Campo Aux.,Ubicación,Terminal")
                ////{
                ////}


                //REMOVER TILDES
                string strCamposOpcionalesSinTildes = Regex.Replace(strCamposOpcionales.Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 _ , ]+", "");

                //System.IO.File.AppendAllText(Server.MapPath("~/TBEMPLEADO.txt"), "hgfhfjhjkjkjh", Encoding.UTF8);
                /////////////////////////////////////////////////////////////////////////////////////////////////
                //Creamos una variable en el cual luego obtendremos lo que contiene el archivo de texto 
                string currentContent = String.Empty;
                //Creamos la cabecera del archivo texto(los títulos en la primera fila)
                string newContent = "Producto,Cantidad"+ strCamposOpcionalesSinTildes + "\r\n";
                if (System.IO.File.Exists(Server.MapPath("~/TMINVENTARIO.txt")))
                {
                    //ReadAllText: lee y obtiene todo el contenido existente en el archivo de texto
                    currentContent = System.IO.File.ReadAllText(Server.MapPath("~/TMINVENTARIO.txt"));
                }
                //WriteAllText: añade una linea mas al contenido ya existente en el archivo de texto
                System.IO.File.WriteAllText(Server.MapPath("~/TMINVENTARIO.txt"), newContent + currentContent);
                /////////////////////////////////////////////////////////////////////////////////////////////////

                // Get the file path
                var file = Server.MapPath("~/TMINVENTARIO.txt");
                // Append headers
                Response.AppendHeader("content-disposition", "attachment; filename=TMINVENTARIO.txt");
                // Open/Save dialog
                Response.ContentType = "application/octet-stream"; //--->Descargarlo con el WinOpen
                // Push it!
                Response.TransmitFile(file);


            }

            if (strArchivoExportado == "TMINVENTARIO" && idRadioCheck == "chck_txt_codigo")
            {

                //La lista "listaBienesDsTxt" pasarlo al documento txt separados por coma 
                System.IO.File.Create(Server.MapPath("~/TMINVENTARIO.txt")).Close();
                //Leemos row por row lo que contiene la lista

                string strNomArchivo = strArchivoExportado + ".txt";

                //1
                if (strCamposOpcionales == "")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         //// join with "," following properties:
                         //item.strCoProdu,
                         //item.intCantidad
                         item.nvcCoProdu
                     ))
                  );
                }

                //2
                if (strCamposOpcionales == ",Almacén,Fecha,Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }

                //3,Fecha,Almacén,Campo Aux.,Ubicación,Terminal
                if (strCamposOpcionales == ",Fecha,Almacén,Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         //// join with "," following properties:
                         //item.strCoProdu,
                         //item.intCantidad
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //4
                if (strCamposOpcionales == ",Fecha,Almacén,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );

                }
                //5
                if (strCamposOpcionales == ",Fecha,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux

                     ))
                  );

                }
                //6
                if (strCamposOpcionales == ",Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );

                }
                //7
                if (strCamposOpcionales == ",Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                     ))
                  );

                }

                //8
                if (strCamposOpcionales == ",Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                     ))
                  );
                }
                //9
                if (strCamposOpcionales == ",Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //10
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //11
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //12
                if (strCamposOpcionales == ",Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //13
                if (strCamposOpcionales == ",Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //14
                if (strCamposOpcionales == ",Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                     ))
                  );
                }
                ///////////////////////////////////////
                //15
                if (strCamposOpcionales == ",Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //16
                if (strCamposOpcionales == ",Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //17
                if (strCamposOpcionales == ",Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //18
                if (strCamposOpcionales == ",Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //19
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //20
                if (strCamposOpcionales == "Almacén,Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //21
                if (strCamposOpcionales == ",Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //22
                if (strCamposOpcionales == ",Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //23
                if (strCamposOpcionales == ",Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //24
                if (strCamposOpcionales == ",Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //25
                if (strCamposOpcionales == ",Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //26
                if (strCamposOpcionales == ",Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //27
                if (strCamposOpcionales == ",Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //28
                if (strCamposOpcionales == ",Terminal,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //29
                if (strCamposOpcionales == ",Terminal,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //30
                if (strCamposOpcionales == ",Fecha,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //31
                if (strCamposOpcionales == ",Fecha,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //32
                if (strCamposOpcionales == ",Almacén,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //33 
                if (strCamposOpcionales == ",Almacén,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //34
                if (strCamposOpcionales == ",Almacén,Terminal,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //35
                if (strCamposOpcionales == ",Terminal,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //36
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //37
                if (strCamposOpcionales == ",Fecha,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //38
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //39
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //40
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //41,Terminal,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //42,Terminal,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //43,Ubicación,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //44,Ubicación,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //45,Campo Aux.,Terminal,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //46,Campo Aux.,Almacén,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //47,Campo Aux.,Terminal,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //48,Terminal,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //49,Terminal,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //50,Almacén,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //51,Almacén,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //52,Campo Aux.,Fecha,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //53,Campo Aux.,Ubicación,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //54,Ubicación,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //55,Ubicación,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //56,Fecha,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //57,Fecha,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //58,Fecha,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //59,Campo Aux.,Almacén,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //60,Campo Aux.,Fecha,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //61,Almacén,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //62,Almacén,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //63,Almacén,Fecha,Ubicación
                if (strCamposOpcionales == ",Almacén,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //64,Almacén,Ubicación,Fecha
                if (strCamposOpcionales == ",Almacén,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //65,Fecha,Almacén,Ubicación
                if (strCamposOpcionales == ",Fecha,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //66,Fecha,Ubicación,Almacén
                if (strCamposOpcionales == ",Fecha,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //67,Ubicación,Almacén,Fecha
                if (strCamposOpcionales == ",Ubicación,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //68,Ubicación,Fecha,Almacén
                if (strCamposOpcionales == ",Ubicación,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //69,Almacén,Ubicación,Terminal
                if (strCamposOpcionales == ",Almacén,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //70,Almacén,Terminal,Ubicación
                if (strCamposOpcionales == ",Almacén,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //71,Ubicación,Almacén,Terminal
                if (strCamposOpcionales == ",Ubicación,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //72,Ubicación,Terminal,Almacén
                if (strCamposOpcionales == ",Ubicación,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //73,Terminal,Ubicación,Almacén
                if (strCamposOpcionales == ",Terminal,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //74,Terminal,Almacén,Ubicación
                if (strCamposOpcionales == ",Terminal,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //75,Ubicación,Fecha,Terminal
                if (strCamposOpcionales == ",Ubicación,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //76,Ubicación,Terminal,Fecha
                if (strCamposOpcionales == ",Ubicación,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //77,Fecha,Ubicación,Terminal
                if (strCamposOpcionales == ",Fecha,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //78,Fecha,Terminal,Ubicación
                if (strCamposOpcionales == ",Fecha,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //79,Terminal,Ubicación,Fecha
                if (strCamposOpcionales == ",Terminal,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //80,Terminal,Fecha,Ubicación
                if (strCamposOpcionales == ",Terminal,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //81,Almacén,Fecha,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Almacén,Fecha,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //82,Almacén,Fecha,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Fecha,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //83,Almacén,Ubicación,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Ubicación,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //84,Almacén,Ubicación,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Almacén,Ubicación,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //85,Almacén,Campo Aux.,Fecha,Ubicación
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //86,Almacén,Campo Aux.,Ubicación,Fecha
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //87,Fecha,Almacén,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Almacén,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //88,Fecha,Campo Aux.,Ubicación,Almacén
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //89,Fecha,Campo Aux.,Almacén,Ubicación
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //90,Fecha,Ubicación,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Fecha,Ubicación,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //91,Fecha,Ubicación,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Ubicación,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //92,Campo Aux.,Almacén,Fecha,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //93,Campo Aux.,Almacén,Ubicación,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //94,Campo Aux.,Fecha,Almacén,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //95,Campo Aux.,Fecha,Ubicación,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //96,Campo Aux.,Ubicación,Fecha,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //97,Campo Aux.,Ubicación,Almacén,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //98,Ubicación,Almacén,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Almacén,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //99,Ubicación,Almacén,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Ubicación,Almacén,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //100,Ubicación,Fecha,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Ubicación,Fecha,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //101,Ubicación,Fecha,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Fecha,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //102,Ubicación,Campo Aux.,Almacén,Fecha
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //103,Ubicación,Campo Aux.,Fecha,Almacén
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //104,Ubicación,Campo Aux.,Fecha,Terminal
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //105,Ubicación,Campo Aux.,Terminal,Fecha
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //106,Ubicación,Fecha,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Ubicación,Fecha,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //107,Ubicación,Fecha,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Fecha,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //108,Ubicación,Terminal,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Ubicación,Terminal,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //109,Ubicación,Terminal,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Terminal,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //110,Campo Aux.,Ubicación,Fecha,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //111,Campo Aux.,Ubicación,Terminal,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //112,Campo Aux.,Fecha,Ubicación,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //113,Campo Aux.,Fecha,Terminal,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //114,Campo Aux.,Terminal,Fecha,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //115,Campo Aux.,Terminal,Ubicación,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //116,Fecha,Terminal,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Fecha,Terminal,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //117,Fecha,Terminal,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Terminal,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //118,Fecha,Campo Aux.,Ubicación,Terminal
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //119,Fecha,Campo Aux.,Terminal,Ubicación
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //120,Fecha,Ubicación,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Fecha,Ubicación,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //121,Fecha,Ubicación,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Ubicación,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //122,Terminal,Fecha,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Terminal,Fecha,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //123,Terminal,Fecha,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Fecha,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //124,Terminal,Campo Aux.,Fecha,Ubicación
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //125,Terminal,Campo Aux.,Ubicación,Fecha
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //126,Terminal,Ubicación,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Terminal,Ubicación,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //127,Terminal,Ubicación,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Ubicación,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //128,Terminal,Ubicación,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Terminal,Ubicación,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //129,Terminal,Ubicación,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Ubicación,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //130,Terminal,Campo Aux.,Ubicación,Almacén
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //131,Terminal,Campo Aux.,Almacén,Ubicación
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //132,Terminal,Almacén,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Terminal,Almacén,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //133,Terminal,Almacén,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Almacén,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //134,Ubicación,Terminal,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Ubicación,Terminal,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //135,Ubicación,Terminal,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Terminal,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //136,Ubicación,Campo Aux.,Almacén,Terminal
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //137,Ubicación,Campo Aux.,Terminal,Almacén
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //138,Ubicación,Almacén,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Almacén,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //139,Ubicación,Almacén,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Ubicación,Almacén,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //140,Almacén,Ubicación,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Almacén,Ubicación,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //141,Almacén,Ubicación,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Ubicación,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //142,Almacén,Campo Aux.,Terminal,Ubicación
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //143,Almacén,Terminal,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Almacén,Terminal,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //144,Almacén,Terminal,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Terminal,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //145,Campo Aux.,Almacén,Terminal,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //146,Campo Aux.,Almacén,Ubicación,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //147,Campo Aux.,Terminal,Almacén,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //148,Campo Aux.,Terminal,Ubicación,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //159,Campo Aux.,Ubicación,Almacén,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //150,Campo Aux.,Ubicación,Terminal,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //151,Campo Aux.,Fecha,Almacén,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //152,Campo Aux.,Fecha,Terminal,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //153,Campo Aux.,Almacén,Fecha,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //154,Campo Aux.,Almacén,Terminal,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //155,Campo Aux.,Terminal,Almacén,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //156,Campo Aux.,Terminal,Almacén,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //157,Fecha,Terminal,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Terminal,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //158,Fecha,Terminal,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Fecha,Terminal,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //159,Fecha,Campo Aux.,Almacén,Terminal
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //160,Fecha,Campo Aux.,Terminal,Almacén
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //161,Fecha,Almacén,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Almacén,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //162,Fecha,Almacén,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Fecha,Almacén,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //163,Almacén,Fecha,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Almacén,Fecha,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //164,Almacén,Fecha,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Fecha,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //165,Almacén,Campo Aux.,Fecha,Terminal
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //166,Almacén,Campo Aux.,Terminal,Fecha
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //167,Almacén,Terminal,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Almacén,Terminal,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //168,Terminal,Almacén,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Almacén,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //169,Terminal,Almacén,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Terminal,Almacén,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //170,Terminal,Fecha,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Terminal,Fecha,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //171,Terminal,Fecha,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Fecha,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //172,Terminal,Campo Aux.,Fecha,Almacén
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //173,Terminal,Campo Aux.,Almacén,Fecha
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //////////////////////////////////////////////////////////////DE DOS
                //,Terminal,Ubicación
                if (strCamposOpcionales == ",Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //,Ubicación,Almacén
                if (strCamposOpcionales == ",Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //,Ubicación,Fecha
                if (strCamposOpcionales == ",Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     )), Encoding.UTF8 // System.Text.Encoding.ASCII //, Encoding.UTF32
                  );
                }
                //220,Campo Aux.,Ubicación,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //221,Almacén,Fecha,Ubicación,Terminal   _txt_codigo
                if (strCamposOpcionales == ",Almacén,Fecha,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                /***************************************************************************
                //La lista "listaBienesDsTxt" pasarlo al documento txt separados por coma 
                System.IO.File.Create(Server.MapPath("~/TMINVENTARIO.txt")).Close();
                //Leemos row por row lo que contiene la lista
                System.IO.File.WriteAllLines(Server.MapPath("~/TMINVENTARIO.txt"), listaTMPRODU
                .Select(item => 
                     item.strCoProdu
                  )
                 );
                ************************************************************************/


                //System.IO.File.AppendAllText(Server.MapPath("~/TBEMPLEADO.txt"), "hgfhfjhjkjkjh", Encoding.UTF8);
                /////////////////////////////////////////////////////////////////////////////////////////////////
                //Creamos una variable en el cual luego obtendremos lo que contiene el archivo de texto 
                string currentContent = String.Empty;
                //Creamos la cabecera del archivo texto(los títulos en la primera fila)
                //string newContent = "Producto\r\n";
                if (System.IO.File.Exists(Server.MapPath("~/TMINVENTARIO.txt")))
                {
                    //ReadAllText: lee y obtiene todo el contenido existente en el archivo de texto
                    currentContent = System.IO.File.ReadAllText(Server.MapPath("~/TMINVENTARIO.txt"));
                }
                //WriteAllText: añade una linea mas al contenido ya existente en el archivo de texto
                System.IO.File.WriteAllText(Server.MapPath("~/TMINVENTARIO.txt"),  currentContent);
                /////////////////////////////////////////////////////////////////////////////////////////////////

                // Get the file path
                var file = Server.MapPath("~/TMINVENTARIO.txt");
                // Append headers
                Response.AppendHeader("content-disposition", "attachment; filename=TMINVENTARIO.txt");
                // Open/Save dialog
                Response.ContentType = "application/octet-stream"; //--->Descargarlo con el WinOpen
                // Push it!
                Response.TransmitFile(file);


            }


        }



        ////public void SaveToCSV(List<User> users)
        ////{
        ////    using (var mem = new MemoryStream())
        ////    using (var writer = new StreamWriter(mem))
        ////    using (var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture, false))
        ////    {
        ////        csvWriter.Configuration.Delimiter = ";";

        ////        csvWriter.Configuration.HasHeaderRecord = true;
        ////        csvWriter.Configuration.AutoMap<User>();

        ////        csvWriter.WriteHeader<User>();
        ////        csvWriter.WriteRecords(users);

        ////        writer.Flush();
        ////        var result = Encoding.UTF8.GetString(mem.ToArray());
        ////        Console.WriteLine(result);
        ////    }
        ////}

        //////public void SaveToCSV(User user)
        //////{
        //////    using (var writer = new StringWriter())
        //////    using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture, leaveOpen: true))
        //////    {
        //////        csvWriter.Configuration.Delimiter = ";";
        //////        csvWriter.Configuration.HasHeaderRecord = true;
        //////        csvWriter.Configuration.AutoMap<User>();

        //////        csvWriter.WriteHeader<User>();
        //////        csvWriter.WriteRecord(user);
        //////        csvWriter.Flush();

        //////        var result = writer.ToString();
        //////        Console.WriteLine(result);
        //////    }




        //////}


        //////////////////////////////////////////////////////////
        //30.3 GENERAR CSV SEPARADO POR COMA
        //////////////////////////////////////////////////////////
        public void GenerarArchivosExcel(string strArchivoExportado, string idRadioCheck, string strCamposOpcionales)
        {


            //Excel._Worksheet workSheet = (Excel._Worksheet)_Excel.Worksheets.Add();
            //set columns format to text format
            //workSheet.Columns.NumberFormat = "@";
            //workSheet.Columns.NumberFormat = "@";
            //IWorkbook workbook = Factory.GetWorkbook();
            //IRange cells = workbook.Worksheets[0].Cells;
            //// Format column A as text.
            //cells["A:A"].NumberFormat = "@";
            //// Set A2 to text with a leading '0'.
            //cells["A2"].Value = "01234567890123456789";
            //// Format column C as text (SpreadsheetGear uses 0 based indexes - Excel uses 1 based indexes).
            //cells[0, 2].EntireColumn.NumberFormat = "@";
            //// Set C3 to text with a leading '0'.
            //cells[2, 2].Value = "01234567890123456789";
            //workbook.SaveAs(@"c:\tmp\TextFormat.xlsx", FileFormat.OpenXMLWorkbook);


            if (strArchivoExportado == "TMINVENTARIO" && idRadioCheck == "chck_csv_codigo")
            {

                //La lista "listaBienesDsTxt" pasarlo al documento txt separados por coma 
                System.IO.File.Create(Server.MapPath("~/TMINVENTARIO.csv")).Close();
                //Leemos row por row lo que contiene la lista

                string strNomArchivo = strArchivoExportado + ".csv";

                //1
                if (strCamposOpcionales == "")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         //// join with "," following properties:
                         //item.strCoProdu,
                         //item.intCantidad
                         item.nvcCoProdu
                     ))
                  );
                }
                //2
                if (strCamposOpcionales == ",Almacén,Fecha,Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //3,Fecha,Almacén,Campo Aux.,Ubicación,Terminal
                if (strCamposOpcionales == ",Fecha,Almacén,Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         //// join with "," following properties:
                         //item.strCoProdu,
                         //item.intCantidad
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //4
                if (strCamposOpcionales == ",Fecha,Almacén,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );

                }
                //5
                if (strCamposOpcionales == ",Fecha,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux

                     ))
                  );

                }
                //6
                if (strCamposOpcionales == ",Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );

                }
                //7
                if (strCamposOpcionales == ",Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                     ))
                  );

                }
                //8
                if (strCamposOpcionales == ",Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                     ))
                  );
                }
                //9
                if (strCamposOpcionales == ",Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //10
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //11
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //12
                if (strCamposOpcionales == ",Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //13
                if (strCamposOpcionales == ",Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu    
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //14
                if (strCamposOpcionales == ",Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                     ))
                  );
                }
                //15
                if (strCamposOpcionales == ",Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //16
                if (strCamposOpcionales == ",Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //17
                if (strCamposOpcionales == ",Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //18
                if (strCamposOpcionales == ",Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //19
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //20
                if (strCamposOpcionales == "Almacén,Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //21
                if (strCamposOpcionales == ",Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //22
                if (strCamposOpcionales == ",Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //23
                if (strCamposOpcionales == ",Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //24
                if (strCamposOpcionales == ",Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //25
                if (strCamposOpcionales == ",Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //26
                if (strCamposOpcionales == ",Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //27
                if (strCamposOpcionales == ",Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //28
                if (strCamposOpcionales == ",Terminal,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //29
                if (strCamposOpcionales == ",Terminal,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //30
                if (strCamposOpcionales == ",Fecha,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //31
                if (strCamposOpcionales == ",Fecha,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //32
                if (strCamposOpcionales == ",Almacén,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //33 
                if (strCamposOpcionales == ",Almacén,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //34
                if (strCamposOpcionales == ",Almacén,Terminal,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //35
                if (strCamposOpcionales == ",Terminal,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //36
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //37
                if (strCamposOpcionales == ",Fecha,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //38
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //39
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //40,Campo Aux.,Fecha,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //41,Terminal,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //42,Terminal,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //43,Ubicación,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //44,Ubicación,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //45,Campo Aux.,Terminal,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //46,Campo Aux.,Almacén,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //47,Campo Aux.,Terminal,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //48,Terminal,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //49,Terminal,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //50,Almacén,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //51,Almacén,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //52,Campo Aux.,Fecha,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //53,Campo Aux.,Ubicación,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //54,Ubicación,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //55,Ubicación,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //56,Fecha,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //57,Fecha,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //58,Fecha,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //59,Campo Aux.,Almacén,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //60,Campo Aux.,Fecha,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //61,Almacén,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //62,Almacén,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //63,Almacén,Fecha,Ubicación
                if (strCamposOpcionales == ",Almacén,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //64,Almacén,Ubicación,Fecha
                if (strCamposOpcionales == ",Almacén,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //65,Fecha,Almacén,Ubicación
                if (strCamposOpcionales == ",Fecha,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //66,Fecha,Ubicación,Almacén
                if (strCamposOpcionales == ",Fecha,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //67,Ubicación,Almacén,Fecha
                if (strCamposOpcionales == ",Ubicación,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //68,Ubicación,Fecha,Almacén
                if (strCamposOpcionales == ",Ubicación,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //69,Almacén,Ubicación,Terminal
                if (strCamposOpcionales == ",Almacén,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //70,Almacén,Terminal,Ubicación
                if (strCamposOpcionales == ",Almacén,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //71,Ubicación,Almacén,Terminal
                if (strCamposOpcionales == ",Ubicación,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //72,Ubicación,Terminal,Almacén
                if (strCamposOpcionales == ",Ubicación,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //73,Terminal,Ubicación,Almacén
                if (strCamposOpcionales == ",Terminal,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //74,Terminal,Almacén,Ubicación
                if (strCamposOpcionales == ",Terminal,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //75,Ubicación,Fecha,Terminal
                if (strCamposOpcionales == ",Ubicación,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //76,Ubicación,Terminal,Fecha
                if (strCamposOpcionales == ",Ubicación,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //77,Fecha,Ubicación,Terminal
                if (strCamposOpcionales == ",Fecha,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //78,Fecha,Terminal,Ubicación
                if (strCamposOpcionales == ",Fecha,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //79,Terminal,Ubicación,Fecha
                if (strCamposOpcionales == ",Terminal,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //80,Terminal,Fecha,Ubicación
                if (strCamposOpcionales == ",Terminal,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //81,Almacén,Fecha,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Almacén,Fecha,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //82,Almacén,Fecha,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Fecha,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //83,Almacén,Ubicación,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Ubicación,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //84,Almacén,Ubicación,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Almacén,Ubicación,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //85,Almacén,Campo Aux.,Fecha,Ubicación
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //86,Almacén,Campo Aux.,Ubicación,Fecha
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //87,Fecha,Almacén,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Almacén,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //88,Fecha,Campo Aux.,Ubicación,Almacén
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //89,Fecha,Campo Aux.,Almacén,Ubicación
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //90,Fecha,Ubicación,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Fecha,Ubicación,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //91,Fecha,Ubicación,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Ubicación,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //92,Campo Aux.,Almacén,Fecha,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //93,Campo Aux.,Almacén,Ubicación,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //94,Campo Aux.,Fecha,Almacén,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //95,Campo Aux.,Fecha,Ubicación,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //96,Campo Aux.,Ubicación,Fecha,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //97,Campo Aux.,Ubicación,Almacén,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //98,Ubicación,Almacén,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Almacén,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //99,Ubicación,Almacén,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Ubicación,Almacén,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //100,Ubicación,Fecha,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Ubicación,Fecha,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //101,Ubicación,Fecha,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Fecha,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //102,Ubicación,Campo Aux.,Almacén,Fecha
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //103,Ubicación,Campo Aux.,Fecha,Almacén
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //104,Ubicación,Campo Aux.,Fecha,Terminal
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //105,Ubicación,Campo Aux.,Terminal,Fecha
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //106,Ubicación,Fecha,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Ubicación,Fecha,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //107,Ubicación,Fecha,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Fecha,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //108,Ubicación,Terminal,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Ubicación,Terminal,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //109,Ubicación,Terminal,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Terminal,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //110,Campo Aux.,Ubicación,Fecha,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                        , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //111,Campo Aux.,Ubicación,Terminal,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //112,Campo Aux.,Fecha,Ubicación,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //113,Campo Aux.,Fecha,Terminal,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //114,Campo Aux.,Terminal,Fecha,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //115,Campo Aux.,Terminal,Ubicación,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //116,Fecha,Terminal,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Fecha,Terminal,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //117,Fecha,Terminal,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Terminal,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //118,Fecha,Campo Aux.,Ubicación,Terminal
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //119,Fecha,Campo Aux.,Terminal,Ubicación
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //120,Fecha,Ubicación,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Fecha,Ubicación,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //121,Fecha,Ubicación,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Ubicación,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //122,Terminal,Fecha,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Terminal,Fecha,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //123,Terminal,Fecha,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Fecha,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //124,Terminal,Campo Aux.,Fecha,Ubicación
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //125,Terminal,Campo Aux.,Ubicación,Fecha
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //126,Terminal,Ubicación,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Terminal,Ubicación,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //127,Terminal,Ubicación,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Ubicación,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //128,Terminal,Ubicación,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Terminal,Ubicación,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //129,Terminal,Ubicación,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Ubicación,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //130,Terminal,Campo Aux.,Ubicación,Almacén
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //131,Terminal,Campo Aux.,Almacén,Ubicación
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //132,Terminal,Almacén,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Terminal,Almacén,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //133,Terminal,Almacén,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Almacén,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //134,Ubicación,Terminal,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Ubicación,Terminal,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //135,Ubicación,Terminal,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Terminal,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //136,Ubicación,Campo Aux.,Almacén,Terminal
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //137,Ubicación,Campo Aux.,Terminal,Almacén
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //138,Ubicación,Almacén,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Almacén,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //139,Ubicación,Almacén,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Ubicación,Almacén,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //140,Almacén,Ubicación,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Almacén,Ubicación,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //141,Almacén,Ubicación,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Ubicación,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //142,Almacén,Campo Aux.,Terminal,Ubicación
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //143,Almacén,Terminal,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Almacén,Terminal,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //144,Almacén,Terminal,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Terminal,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //145,Campo Aux.,Almacén,Terminal,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //146,Campo Aux.,Almacén,Ubicación,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //147,Campo Aux.,Terminal,Almacén,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //148,Campo Aux.,Terminal,Ubicación,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //159,Campo Aux.,Ubicación,Almacén,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //150,Campo Aux.,Ubicación,Terminal,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //151,Campo Aux.,Fecha,Almacén,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //152,Campo Aux.,Fecha,Terminal,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //153,Campo Aux.,Almacén,Fecha,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //154,Campo Aux.,Almacén,Terminal,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //155,Campo Aux.,Terminal,Almacén,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                        , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //156,Campo Aux.,Terminal,Almacén,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //157,Fecha,Terminal,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Terminal,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //158,Fecha,Terminal,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Fecha,Terminal,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //159,Fecha,Campo Aux.,Almacén,Terminal
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //160,Fecha,Campo Aux.,Terminal,Almacén
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //161,Fecha,Almacén,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Almacén,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //162,Fecha,Almacén,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Fecha,Almacén,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //163,Almacén,Fecha,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Almacén,Fecha,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //164,Almacén,Fecha,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Fecha,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //165,Almacén,Campo Aux.,Fecha,Terminal
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //166,Almacén,Campo Aux.,Terminal,Fecha
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //167,Almacén,Terminal,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Almacén,Terminal,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //168,Terminal,Almacén,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Almacén,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //169,Terminal,Almacén,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Terminal,Almacén,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //170,Terminal,Fecha,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Terminal,Fecha,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //171,Terminal,Fecha,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Fecha,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //172,Terminal,Campo Aux.,Fecha,Almacén
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //173,Terminal,Campo Aux.,Almacén,Fecha
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }


                //////////////////////////////////////////////////////////////DE DOS
                //,Terminal,Ubicación
                if (strCamposOpcionales == ",Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //,Ubicación,Almacén
                if (strCamposOpcionales == ",Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //,Ubicación,Fecha 
                if (strCamposOpcionales == ",Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     )), Encoding.UTF8 // System.Text.Encoding.ASCII //, Encoding.UTF32
                  );
                }
                //,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     )), Encoding.UTF8 // System.Text.Encoding.ASCII //, Encoding.UTF32
                  );
                }
                //220,Campo Aux.,Ubicación,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //221,Almacén,Fecha,Ubicación,Terminal
                if (strCamposOpcionales == ",Almacén,Fecha,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                /**************************************************************************
                //La lista "listaBienesDsTxt" pasarlo al documento txt separados por coma 
                System.IO.File.Create(Server.MapPath("~/TMINVENTARIO.csv")).Close();
                //Leemos row por row lo que contiene la lista
                System.IO.File.WriteAllLines(Server.MapPath("~/TMINVENTARIO.csv"), listaTMPRODU
                //////////.Select(item =>  string.Join(",",
                //////////     // join with "," following properties:
                //////////     item.strCoProdu
                //////////     //item.intCantidad
                ////////// ))
                ////////// );

                  .Select(item => string.Join(",", "\t" +

                     item.strCoProdu + "\t"
                               //string.Format("\"{0}\"", (item.strCoProdu).ToString())

                 ))
                 );
                *******************************************************************************************/

                //System.IO.File.AppendAllText(Server.MapPath("~/TBEMPLEADO.txt"), "hgfhfjhjkjkjh", Encoding.UTF8);
                /////////////////////////////////////////////////////////////////////////////////////////////////
                //Creamos una variable en el cual luego obtendremos lo que contiene el archivo de texto 
                string currentContent = String.Empty;
                //Creamos la cabecera del archivo texto(los títulos en la primera fila)
                //string newContent = "Producto,Cantidad\r\n";
                if (System.IO.File.Exists(Server.MapPath("~/TMINVENTARIO.csv")))
                {
                    //ReadAllText: lee y obtiene todo el contenido existente en el archivo de texto
                    currentContent = System.IO.File.ReadAllText(Server.MapPath("~/TMINVENTARIO.csv"));
                }
                //WriteAllText: añade una linea mas al contenido ya existente en el archivo de texto
                System.IO.File.WriteAllText(Server.MapPath("~/TMINVENTARIO.csv"),  currentContent);





                /////////////////////////////////////////////////////////////////////////////////////////////////
                ////////////string file2 = @"D:\TMPRODU.xlsx";//
                ////////////Excel.Application ExcelApp = new Excel.Application();
                ////////////Excel.Workbook ExcelWorkbook = ExcelApp.Workbooks.Open(file2);
                ////////////ExcelApp.Visible = true;

                //////////////Looping through all available sheets
                ////////////foreach (Excel.Worksheet ExcelWorksheet in ExcelWorkbook.Sheets)
                ////////////{
                ////////////    //Selecting the worksheet where we want to perform action
                ////////////    ExcelWorksheet.Select(Type.Missing);
                ////////////    ExcelWorksheet.Columns[1].NumberFormat = "@";
                ////////////}

                //////////////saving excel file using Interop
                ////////////ExcelWorkbook.Save();

                //////////////closing file and releasing resources
                ////////////ExcelWorkbook.Close(Type.Missing, Type.Missing, Type.Missing);
                //////////////Marshal.ReleaseComObject(ExcelWorkbook);//Marshal.FinalReleaseComObject(ExcelWorkbook);
                ////////////ExcelApp.Quit();
                //////////////Marshal.FinalReleaseComObject(ExcelApp);

                /////////////////////////////////////////////////////////////////////////////////////////////////


                // Get the file path
                var file = Server.MapPath("~/TMINVENTARIO.csv");
                // Append headers
                Response.AppendHeader("content-disposition", "attachment; filename=TMINVENTARIO.csv");
                // Open/Save dialog
                Response.ContentType = "application/octet-stream"; //--->Descargarlo con el WinOpen
                // Push it!
                Response.TransmitFile(file);


            }

            if (strArchivoExportado == "TMINVENTARIO" && idRadioCheck == "chck_csv_coma")
            {

                //La lista "listaTMPRODU" pasarlo al documento txt separados por coma 
                System.IO.File.Create(Server.MapPath("~/TMINVENTARIO.csv")).Close();
                //Leemos row por row lo que contiene la lista
                string strNomArchivo = strArchivoExportado + ".csv";
                //1
                if (strCamposOpcionales == "")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         //// join with "," following properties:
                         //item.strCoProdu,
                         //item.intCantidad
                         item.nvcCoProdu
                       , item.intNuRegis
                     ))
                  );
                }

                //2
                if (strCamposOpcionales == ",Almacén,Fecha,Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }

                //3,Fecha,Almacén,Campo Aux.,Ubicación,Terminal
                if (strCamposOpcionales == ",Fecha,Almacén,Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                        //// join with "," following properties:
                        //item.strCoProdu,
                        //item.intCantidad
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //4
                if (strCamposOpcionales == ",Fecha,Almacén,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );

                }
                //5
                if (strCamposOpcionales == ",Fecha,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux

                     ))
                  );

                }
                //6
                if (strCamposOpcionales == ",Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );

                }
                //7
                if (strCamposOpcionales == ",Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                     ))
                  );

                }

                //8
                if (strCamposOpcionales == ",Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //9
                if (strCamposOpcionales == ",Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //10
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //11
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //12
                if (strCamposOpcionales == ",Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //13
                if (strCamposOpcionales == ",Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //14
                if (strCamposOpcionales == ",Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                ///////////////////////////////////////
                //15
                if (strCamposOpcionales == ",Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //16
                if (strCamposOpcionales == ",Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //17
                if (strCamposOpcionales == ",Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //18
                if (strCamposOpcionales == ",Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //19
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //20
                if (strCamposOpcionales == "Almacén,Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //21
                if (strCamposOpcionales == ",Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis  
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //22
                if (strCamposOpcionales == ",Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //23
                if (strCamposOpcionales == ",Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //24
                if (strCamposOpcionales == ",Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //25
                if (strCamposOpcionales == ",Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //26
                if (strCamposOpcionales == ",Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //27
                if (strCamposOpcionales == ",Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //28
                if (strCamposOpcionales == ",Terminal,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //29
                if (strCamposOpcionales == ",Terminal,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //30
                if (strCamposOpcionales == ",Fecha,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //31
                if (strCamposOpcionales == ",Fecha,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //32
                if (strCamposOpcionales == ",Almacén,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //33 
                if (strCamposOpcionales == ",Almacén,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //34
                if (strCamposOpcionales == ",Almacén,Terminal,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo +""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //35
                if (strCamposOpcionales == ",Terminal,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //36
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //37
                if (strCamposOpcionales == ",Fecha,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //38
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //39
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //40
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //41,Terminal,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //42,Terminal,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //43,Ubicación,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //44,Ubicación,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //45,Campo Aux.,Terminal,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //46,Campo Aux.,Almacén,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //47,Campo Aux.,Terminal,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //48,Terminal,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //49,Terminal,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //50,Almacén,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //51,Almacén,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //52,Campo Aux.,Fecha,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //53,Campo Aux.,Ubicación,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //54,Ubicación,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //55,Ubicación,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //56,Fecha,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //57,Fecha,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //58,Fecha,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //59,Campo Aux.,Almacén,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //60,Campo Aux.,Fecha,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //61,Almacén,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //62,Almacén,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //63,Almacén,Fecha,Ubicación
                if (strCamposOpcionales == ",Almacén,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //64,Almacén,Ubicación,Fecha
                if (strCamposOpcionales == ",Almacén,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //65,Fecha,Almacén,Ubicación
                if (strCamposOpcionales == ",Fecha,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //66,Fecha,Ubicación,Almacén
                if (strCamposOpcionales == ",Fecha,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //67,Ubicación,Almacén,Fecha
                if (strCamposOpcionales == ",Ubicación,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //68,Ubicación,Fecha,Almacén
                if (strCamposOpcionales == ",Ubicación,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //69,Almacén,Ubicación,Terminal
                if (strCamposOpcionales == ",Almacén,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //70,Almacén,Terminal,Ubicación
                if (strCamposOpcionales == ",Almacén,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //71,Ubicación,Almacén,Terminal
                if (strCamposOpcionales == ",Ubicación,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //72,Ubicación,Terminal,Almacén
                if (strCamposOpcionales == ",Ubicación,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //73,Terminal,Ubicación,Almacén
                if (strCamposOpcionales == ",Terminal,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //74,Terminal,Almacén,Ubicación
                if (strCamposOpcionales == ",Terminal,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //75,Ubicación,Fecha,Terminal
                if (strCamposOpcionales == ",Ubicación,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //76,Ubicación,Terminal,Fecha
                if (strCamposOpcionales == ",Ubicación,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //77,Fecha,Ubicación,Terminal
                if (strCamposOpcionales == ",Fecha,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //78,Fecha,Terminal,Ubicación
                if (strCamposOpcionales == ",Fecha,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //79,Terminal,Ubicación,Fecha
                if (strCamposOpcionales == ",Terminal,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //80,Terminal,Fecha,Ubicación
                if (strCamposOpcionales == ",Terminal,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //81,Almacén,Fecha,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Almacén,Fecha,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //82,Almacén,Fecha,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Fecha,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //83,Almacén,Ubicación,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Ubicación,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //84,Almacén,Ubicación,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Almacén,Ubicación,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //85,Almacén,Campo Aux.,Fecha,Ubicación
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //86,Almacén,Campo Aux.,Ubicación,Fecha
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //87,Fecha,Almacén,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Almacén,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //88,Fecha,Campo Aux.,Ubicación,Almacén
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //89,Fecha,Campo Aux.,Almacén,Ubicación
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //90,Fecha,Ubicación,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Fecha,Ubicación,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //91,Fecha,Ubicación,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Ubicación,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //92,Campo Aux.,Almacén,Fecha,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //93,Campo Aux.,Almacén,Ubicación,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //94,Campo Aux.,Fecha,Almacén,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //95,Campo Aux.,Fecha,Ubicación,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //96,Campo Aux.,Ubicación,Fecha,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //97,Campo Aux.,Ubicación,Almacén,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //98,Ubicación,Almacén,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Almacén,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //99,Ubicación,Almacén,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Ubicación,Almacén,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //100,Ubicación,Fecha,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Ubicación,Fecha,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //101,Ubicación,Fecha,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Fecha,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //102,Ubicación,Campo Aux.,Almacén,Fecha
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //103,Ubicación,Campo Aux.,Fecha,Almacén
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //104,Ubicación,Campo Aux.,Fecha,Terminal
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //105,Ubicación,Campo Aux.,Terminal,Fecha
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //106,Ubicación,Fecha,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Ubicación,Fecha,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //107,Ubicación,Fecha,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Fecha,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //108,Ubicación,Terminal,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Ubicación,Terminal,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //109,Ubicación,Terminal,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Terminal,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //110,Campo Aux.,Ubicación,Fecha,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //111,Campo Aux.,Ubicación,Terminal,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //112,Campo Aux.,Fecha,Ubicación,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //113,Campo Aux.,Fecha,Terminal,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //114,Campo Aux.,Terminal,Fecha,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //115,Campo Aux.,Terminal,Ubicación,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //116,Fecha,Terminal,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Fecha,Terminal,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //117,Fecha,Terminal,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Terminal,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //118,Fecha,Campo Aux.,Ubicación,Terminal
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //119,Fecha,Campo Aux.,Terminal,Ubicación
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //120,Fecha,Ubicación,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Fecha,Ubicación,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //121,Fecha,Ubicación,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Ubicación,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //122,Terminal,Fecha,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Terminal,Fecha,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //123,Terminal,Fecha,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Fecha,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //124,Terminal,Campo Aux.,Fecha,Ubicación
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Fecha,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoUbica
                     ))
                  );
                }
                //125,Terminal,Campo Aux.,Ubicación,Fecha
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //126,Terminal,Ubicación,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Terminal,Ubicación,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //127,Terminal,Ubicación,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Ubicación,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //128,Terminal,Ubicación,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Terminal,Ubicación,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //129,Terminal,Ubicación,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Ubicación,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //130,Terminal,Campo Aux.,Ubicación,Almacén
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //131,Terminal,Campo Aux.,Almacén,Ubicación
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //132,Terminal,Almacén,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Terminal,Almacén,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //133,Terminal,Almacén,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Almacén,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //134,Ubicación,Terminal,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Ubicación,Terminal,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //135,Ubicación,Terminal,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Terminal,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //136,Ubicación,Campo Aux.,Almacén,Terminal
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //137,Ubicación,Campo Aux.,Terminal,Almacén
                if (strCamposOpcionales == ",Ubicación,Campo Aux.,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //138,Ubicación,Almacén,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Ubicación,Almacén,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //139,Ubicación,Almacén,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Ubicación,Almacén,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //140,Almacén,Ubicación,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Almacén,Ubicación,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //141,Almacén,Ubicación,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Ubicación,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //142,Almacén,Campo Aux.,Terminal,Ubicación
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //143,Almacén,Terminal,Campo Aux.,Ubicación
                if (strCamposOpcionales == ",Almacén,Terminal,Campo Aux.,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                     ))
                  );
                }
                //144,Almacén,Terminal,Ubicación,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Terminal,Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //145,Campo Aux.,Almacén,Terminal,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //146,Campo Aux.,Almacén,Ubicación,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }
                //147,Campo Aux.,Terminal,Almacén,Ubicación
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Almacén,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcNoUbica
                     ))
                  );
                }
                //148,Campo Aux.,Terminal,Ubicación,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //159,Campo Aux.,Ubicación,Almacén,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //150,Campo Aux.,Ubicación,Terminal,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //151,Campo Aux.,Fecha,Almacén,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //152,Campo Aux.,Fecha,Terminal,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Fecha,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //153,Campo Aux.,Almacén,Fecha,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //154,Campo Aux.,Almacén,Terminal,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Almacén,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //155,Campo Aux.,Terminal,Almacén,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //156,Campo Aux.,Terminal,Almacén,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Terminal,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }
                //157,Fecha,Terminal,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Terminal,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //158,Fecha,Terminal,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Fecha,Terminal,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //159,Fecha,Campo Aux.,Almacén,Terminal
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Almacén,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.intNuTermi
                     ))
                  );
                }
                //160,Fecha,Campo Aux.,Terminal,Almacén
                if (strCamposOpcionales == ",Fecha,Campo Aux.,Terminal,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //161,Fecha,Almacén,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Fecha,Almacén,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //162,Fecha,Almacén,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Fecha,Almacén,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //163,Almacén,Fecha,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Almacén,Fecha,Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //164,Almacén,Fecha,Terminal,Campo Aux.
                if (strCamposOpcionales == ",Almacén,Fecha,Terminal,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //165,Almacén,Campo Aux.,Fecha,Terminal
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Fecha,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.intNuTermi
                     ))
                  );
                }
                //166,Almacén,Campo Aux.,Terminal,Fecha
                if (strCamposOpcionales == ",Almacén,Campo Aux.,Terminal,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                       , item.dttFeRegis
                     ))
                  );
                }
                //167,Almacén,Terminal,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Almacén,Terminal,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //168,Terminal,Almacén,Fecha,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Almacén,Fecha,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //169,Terminal,Almacén,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Terminal,Almacén,Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //170,Terminal,Fecha,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Terminal,Fecha,Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //171,Terminal,Fecha,Almacén,Campo Aux.
                if (strCamposOpcionales == ",Terminal,Fecha,Almacén,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                       , item.nvcCoCampoAux
                     ))
                  );
                }
                //172,Terminal,Campo Aux.,Fecha,Almacén
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Fecha,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //173,Terminal,Campo Aux.,Almacén,Fecha
                if (strCamposOpcionales == ",Terminal,Campo Aux.,Almacén,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                     ))
                  );
                }

                //////////////////////////////////////////////////////////////DE DOS
                //,Terminal,Ubicación
                if (strCamposOpcionales == ",Terminal,Ubicación")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.intNuTermi
                       , item.nvcNoUbica
                     ))
                  );
                }
                //,Ubicación,Almacén
                if (strCamposOpcionales == ",Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //,Campo Aux.,Almacén
                if (strCamposOpcionales == ",Campo Aux.,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //,Campo Aux.,Terminal
                if (strCamposOpcionales == ",Campo Aux.,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.intNuTermi
                     ))
                  );
                }
                //,Campo Aux.,Fecha
                if (strCamposOpcionales == ",Campo Aux.,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.dttFeRegis
                     ))
                  );
                }
                //,Ubicación,Fecha 
                if (strCamposOpcionales == ",Ubicación,Fecha")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + "" ), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.dttFeRegis
                     ))
                  );
                }
                //,Ubicación,Campo Aux
                if (strCamposOpcionales == ",Ubicación,Campo Aux.")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoUbica
                       , item.nvcCoCampoAux
                     ))//, Encoding.UTF8 // System.Text.Encoding.ASCII //, Encoding.UTF32
                  );
                }
                //220,Campo Aux.,Ubicación,Almacén   //chck_csv_coma 
                if (strCamposOpcionales == ",Campo Aux.,Ubicación,Almacén")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu 
                       , item.intNuRegis
                       , item.nvcCoCampoAux
                       , item.nvcNoUbica
                       , item.nvcNoAlmac
                     ))
                  );
                }
                //221,Almacén,Fecha,Ubicación,Terminal
                if (strCamposOpcionales == ",Almacén,Fecha,Ubicación,Terminal")
                {
                    System.IO.File.WriteAllLines(Server.MapPath("~/" + strNomArchivo + ""), listaTMPRODU
                    .Select(item => string.Join(",",
                         item.nvcCoProdu
                       , item.intNuRegis
                       , item.nvcNoAlmac
                       , item.dttFeRegis
                       , item.nvcNoUbica
                       , item.intNuTermi
                     ))
                  );
                }

                /***********************************************************************
                //La lista "listaBienesDsTxt" pasarlo al documento txt separados por coma 
                System.IO.File.Create(Server.MapPath("~/TMPRODU.csv")).Close();
                //Leemos row por row lo que contiene la lista
                System.IO.File.WriteAllLines(Server.MapPath("~/TMPRODU.csv"), listaTMPRODU
                 .Select(item => string.Join(",", "'" +

                     item.strCoProdu,
                     item.intCantidad
                 ))
                 );
                ************************************************************************/

                //***********************************************************************
                //REMOVER TILDES
                ////string accentedStr="";
                ////byte[] tempBytes;
                ////tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(accentedStr);
                ////string asciiStr = System.Text.Encoding.UTF8.GetString(tempBytes);
                //string strCamposOpcionales = "áéíóúñ";
                //https://es.stackoverflow.com/questions/193060/sacar-tildes-de-una-cadena-en-c
                //https://stackoverflow.com/questions/5327206/regex-match-digits-comma-and-semicolon/5327243
                string strCamposOpcionalesSinTildes = Regex.Replace(strCamposOpcionales.Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 _ , ]+", "");
                //***********************************************************************

                //System.IO.File.AppendAllText(Server.MapPath("~/TBEMPLEADO.txt"), "hgfhfjhjkjkjh", Encoding.UTF8);
                /////////////////////////////////////////////////////////////////////////////////////////////////
                //Creamos una variable en el cual luego obtendremos lo que contiene el archivo de texto 
                string currentContent = String.Empty;
                //Creamos la cabecera del archivo texto(los títulos en la primera fila)
                string newContent = "Producto,Cantidad" + strCamposOpcionalesSinTildes + "\r\n";
                //string newContent = "Producto,Cantidad\r\n";
                if (System.IO.File.Exists(Server.MapPath("~/TMINVENTARIO.csv")))
                {
                    //ReadAllText: lee y obtiene todo el contenido existente en el archivo de texto
                    currentContent = System.IO.File.ReadAllText(Server.MapPath("~/TMINVENTARIO.csv"));
                }
                //WriteAllText: añade una linea mas al contenido ya existente en el archivo de texto
                System.IO.File.WriteAllText(Server.MapPath("~/TMINVENTARIO.csv"), newContent + currentContent);
                /////////////////////////////////////////////////////////////////////////////////////////////////

                // Get the file path
                var file = Server.MapPath("~/TMINVENTARIO.csv");

                // Append headers
                Response.AppendHeader("content-disposition", "attachment; filename=TMINVENTARIO.csv");
                // Open/Save dialog
                Response.ContentType = "application/octet-stream"; //--->Descargarlo con el WinOpen
                // Push it!
                Response.TransmitFile(file);


            }

            if (strArchivoExportado == "TMPRODU" && idRadioCheck == "chck_csv_coma_respaldo_2")
            {

                //La lista "listaBienesDsTxt" pasarlo al documento txt separados por coma 
                System.IO.File.Create(Server.MapPath("~/TMPRODU.csv")).Close();
                //Leemos row por row lo que contiene la lista
                System.IO.File.WriteAllLines(Server.MapPath("~/TMPRODU.csv"), listaTMPRODU
                //////////.Select(item => string.Join(",",
                //////////     // join with "," following properties:
                //////////     string.Format("\"{0}\"", item.strCoProdu),
                //////////     item.intCantidad
                ////////// ))
                ////////// );


                 ////.Select(item => string.Join(",", " " +

                 ////    item.strCoProdu + "\t",
                 ////    item.intCantidad
                 ////))
                 ////);

                 .Select(item => string.Join(",", "'" +

                     item.strCoProdu ,
                     item.intCantidad
                 ))
                 );

                //System.IO.File.AppendAllText(Server.MapPath("~/TBEMPLEADO.txt"), "hgfhfjhjkjkjh", Encoding.UTF8);
                /////////////////////////////////////////////////////////////////////////////////////////////////
                //Creamos una variable en el cual luego obtendremos lo que contiene el archivo de texto 
                string currentContent = String.Empty;
                //Creamos la cabecera del archivo texto(los títulos en la primera fila)
                string newContent = "Producto,Cantidad\r\n";
                if (System.IO.File.Exists(Server.MapPath("~/TMPRODU.csv")))
                {
                    //ReadAllText: lee y obtiene todo el contenido existente en el archivo de texto
                    currentContent = System.IO.File.ReadAllText(Server.MapPath("~/TMPRODU.csv"));
                }
                //WriteAllText: añade una linea mas al contenido ya existente en el archivo de texto
                System.IO.File.WriteAllText(Server.MapPath("~/TMPRODU.csv"), newContent + currentContent);
                /////////////////////////////////////////////////////////////////////////////////////////////////

                // Get the file path
                var file = Server.MapPath("~/TMPRODU.csv");

                //file.Columns.NumberFormat = "@";





                //////////string ResultsFilePath = @"D:\TMPRODU.csv";// @"C:\\Users\\krakhil\\Desktop\\TGUW EXCEL\\TEST";

                //////////Excel.Application ExcelApp = new Excel.Application();
                //////////Excel.Workbook ExcelWorkbook = ExcelApp.Workbooks.Open(ResultsFilePath);//ResultsFilePath
                //////////ExcelApp.Visible = true;

                ////////////Looping through all available sheets
                //////////foreach (Excel.Worksheet ExcelWorksheet in ExcelWorkbook.Sheets)
                //////////{
                //////////    //Selecting the worksheet where we want to perform action
                //////////    ExcelWorksheet.Select(Type.Missing);
                //////////    ExcelWorksheet.Columns[1].NumberFormat = "@";
                //////////}

                ////////////saving excel file using Interop
                //////////ExcelWorkbook.Save();

                //closing file and releasing resources
                //ExcelWorkbook.Close(Type.Missing, Type.Missing, Type.Missing);
                //Marshal.FinalReleaseComObject(ExcelWorkbook);
                //ExcelApp.Quit();
                //Marshal.FinalReleaseComObject(ExcelApp);










                // Append headers
                Response.AppendHeader("content-disposition", "attachment; filename=TMPRODU.csv");
                // Open/Save dialog
                Response.ContentType = "application/octet-stream"; //--->Descargarlo con el WinOpen
                // Push it!
                Response.TransmitFile(file);


            }

            if (strArchivoExportado == "TMPRODU" && idRadioCheck == "chck_csv_coma_respaldo")
            {

                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                Excel.Range chartRange;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                //add data 
                xlWorkSheet.Cells[4, 2] = "";
                xlWorkSheet.Cells[4, 3] = "Student1";
                xlWorkSheet.Cells[4, 4] = "Student2";
                xlWorkSheet.Cells[4, 5] = "Student3";

                xlWorkSheet.Cells[5, 2] = "Term1";
                xlWorkSheet.Cells[5, 3] = "80";
                xlWorkSheet.Cells[5, 4] = "65";
                xlWorkSheet.Cells[5, 5] = "45";

                xlWorkSheet.Cells[6, 2] = "Term2";
                xlWorkSheet.Cells[6, 3] = "78";
                xlWorkSheet.Cells[6, 4] = "72";
                xlWorkSheet.Cells[6, 5] = "60";

                xlWorkSheet.Cells[7, 2] = "Term3";
                xlWorkSheet.Cells[7, 3] = "82";
                xlWorkSheet.Cells[7, 4] = "80";
                xlWorkSheet.Cells[7, 5] = "65";

                xlWorkSheet.Cells[8, 2] = "Term4";
                xlWorkSheet.Cells[8, 3] = "75";
                xlWorkSheet.Cells[8, 4] = "82";
                xlWorkSheet.Cells[8, 5] = "68";

                xlWorkSheet.Cells[9, 2] = "Total";
                xlWorkSheet.Cells[9, 3] = "315";
                xlWorkSheet.Cells[9, 4] = "299";
                xlWorkSheet.Cells[9, 5] = "238";

                xlWorkSheet.get_Range("b2", "e3").Merge(false);

                chartRange = xlWorkSheet.get_Range("b2", "e3");
                chartRange.FormulaR1C1 = "MARK LIST";
                chartRange.HorizontalAlignment = 3;
                chartRange.VerticalAlignment = 3;
                chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                chartRange.Font.Size = 20;

                chartRange = xlWorkSheet.get_Range("b4", "e4");
                chartRange.Font.Bold = true;
                chartRange = xlWorkSheet.get_Range("b9", "e9");
                chartRange.Font.Bold = true;

                chartRange = xlWorkSheet.get_Range("b2", "e9");
                chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

                xlWorkBook.SaveAs("d:\\TMPRODU.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                //releaseObject(xlApp);
                //releaseObject(xlWorkBook);
                //releaseObject(xlWorkSheet);

            }





            /****************************************************************************************
            * En este método solo se genera 01 excels, el del boton "Generar Archivos Excel"
            * Se usan solo 4 listas de las 8 tablas. No las 8, esas se usan en el Exportar con SQL
            ****************************************************************************************/

            //////if (strArchivoExportado == "TMPRODU" && idRadioCheck == "chck_csv_coma")
            //////{
            //////    //GENERAR EXCEL
            //////    MemoryStream ms = new MemoryStream();
            //////    SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
            //////    WorkbookPart wbp = xl.AddWorkbookPart();
            //////    WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
            //////    Workbook wb = new Workbook();
            //////    FileVersion fv = new FileVersion();
            //////    fv.ApplicationName = "Microsoft Office Excel";
            //////    Worksheet ws = new Worksheet();

            //////    //First sheet
            //////    SheetData sd = new SheetData();
            //////    Row r1 = new Row() { RowIndex = 1u };

            //////    //LLENAMOS LA CABECERA
            //////    Cell c1 = new Cell();
            //////    c1.DataType = CellValues.String;
            //////    c1.CellValue = new CellValue("Producto");
            //////    r1.Append(c1);

            //////    Cell c2 = new Cell();
            //////    c2.DataType = CellValues.String;
            //////    c2.CellValue = new CellValue("Cantidad");
            //////    r1.Append(c2);

            //////    sd.Append(r1);

            //////    //LLENAMOS EL DETALLE
            //////    int fila = 1;

            //////    foreach (TMPRODU_EXPORTAR item in listaTMPRODU)
            //////    {
            //////        Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

            //////        Cell cc1 = new Cell();
            //////        cc1.DataType = CellValues.String;
            //////        cc1.CellValue = new CellValue(item.strCoProdu);
            //////        r2.Append(cc1);

            //////        Cell cc2 = new Cell();
            //////        cc2.DataType = CellValues.String;
            //////        cc2.CellValue = new CellValue(item.intCantidad.ToString());
            //////        r2.Append(cc2);

            //////        sd.Append(r2);

            //////        fila++;
            //////    }

            //////    ////////////////////////////////////////////////////////////////////

            //////    ws.Append(sd);

            //////    wsp.Worksheet = ws;
            //////    wsp.Worksheet.Save();
            //////    Sheets sheets = new Sheets();
            //////    Sheet sheet = new Sheet();
            //////    sheet.Name = "TMPRODU";
            //////    sheet.SheetId = 1;
            //////    sheet.Id = wbp.GetIdOfPart(wsp);
            //////    sheets.Append(sheet);
            //////    wb.Append(fv);
            //////    wb.Append(sheets);
            //////    xl.WorkbookPart.Workbook = wb;
            //////    xl.WorkbookPart.Workbook.Save();
            //////    xl.Close();
            //////    //string fileName = "TMPRODU.xls";




            //////    Response.Clear();
            //////    string fileName = "TMPRODU.csv";
            //////    byte[] dt = ms.ToArray();
            //////    Response.ContentType = "text/csv";
            //////    //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //////    //Response.AddHeader("Content-Disposition", "attachment;filename=Plantilla.csv");
            //////    Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
            //////    Response.BinaryWrite(dt);
            //////    Response.End();


            //////    ////////https://es.stackoverflow.com/questions/198678/como-se-puede-exportar-archivo-csv-con-asp-net-c?rq=1
            //////    //////Response.Clear();
            //////    //////Response.ContentType = "text/csv";
            //////    //////Response.AddHeader("Content-Disposition", "attachment;filename=Plantilla.csv");
            //////    //////Response.Write(builder.ToString());
            //////    //////Response.End();



            //////    //////////////Response.Clear();
            //////    //////////////byte[] dt = ms.ToArray();
            //////    ////////////////dtEmpleado = dt; //Para enviar por correo cuando el check "Generar envío de correo" esté habilitado
            //////    //////////////Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //////    //////////////Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
            //////    //////////////Response.BinaryWrite(dt);
            //////    //////////////////////////-------------------------------------
            //////    ////////////////////////var path = @"D:\ExcelsToEmail\TBEMPLEADO.xlsx";
            //////    ////////////////////////System.IO.File.WriteAllBytes(path, dt);
            //////    //////////////////////////---------------------------------------
            //////    //////////////Response.End();

            //////    //var ResponseContentType = Response.ContentType;
            //////    //var ResponseAddHeader = Response.AddHeader;
            //////    //var ResponseBinaryWrite = Response.BinaryWrite(dt);
            //////    //var output = Response.ContentType;
            //////    //var path = @"E:\testpdf.pdf";
            //////    //async Task FileIndex()
            //////    //{
            //////    //    if (response.IsSuccessStatusCode)
            //////    //    {
            //////    //        var output = await response.Content.ReadAsByteArrayAsync();
            //////    //        //var path = @"E:\testpdf.pdf";
            //////    //        var path = @"testpdf.pdf";
            //////    //        System.IO.File.WriteAllBytes(path, output);
            //////    //    }
            //////    //}

            //////}



        }


        #endregion

        #region Importación Masiva Excel
        public ActionResult ListadoDeRegistrosInconsistentes()
        { 
            StreamReader readme = null;    
            try    
            {        
                //readme = File.OpenText(@"C:\path\to\your\.txt\file.txt");
                readme = System.IO.File.OpenText(@"D:\pathcsharp\file_pruebita.txt");
                Console.WriteLine(readme.ReadToEnd());    
            }
    
            // will return an invalid file name error    
            catch (FileNotFoundException errorMsg)
    
            {        
                Console.WriteLine("Error, " + errorMsg.Message);   
            }
    
            // will return an invalid path error    
            catch (Exception errorMsg)    
            {       
                Console.WriteLine("Error, " + errorMsg.Message);   
            }
    
            finally    
            {
       
                if (readme != null)        
                {          
                    readme.Close();       
                }
           
            }

            return Json(readme.ReadToEnd());
        }

        //OBTENER EL IP CON CODIGIGO C#
        public string GetUserIPAddress()
        {
            var context = System.Web.HttpContext.Current;
            string ip = String.Empty;

            if (context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                ip = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            else if (!String.IsNullOrWhiteSpace(context.Request.UserHostAddress))
                ip = context.Request.UserHostAddress;

            if (ip == "::1")
                ip = "127.0.0.1";

            //string ipaddress = Request.UserHostAddress;
            return ip;
        }

        //VISTA DEL HTML DE IMPORTACIÓN
        public ActionResult ImportacionExcel(string intIdMenu)
        {
            if (Auth.isAuthenticated())
            {
                intIdMenuGlo = Convert.ToInt32(intIdMenu);
                return View();
            }

            return RedirectToAction("CerrarSesion", "LoginSiscop");
        }

        //OBTENER LA RUTA EXCELS
        public JsonResult getRutaPlantillasExcel()
        {
            CustomResponse result = new CustomResponse();
            //string strRutaDir = "";
            //string rutaDirExcel = "";
            //string strRutaDirWebConfig = "rutaMasivoExcel";
            //string strRutaDir = "";            
            //strRutaDir = ConfigurationManager.AppSettings["rutaMasivoExcel"];
            //strRutaDir = ConfigurationManager.AppSettings[strRutaDirWebConfig];

            try { 

            ///////////////////////////////////////////////////////////////////////////
            //string carpetaPlantilla = "Plantilla";
            string carpetaImportarExcel = "Importar Excel";
            //string fileNameExcel = "TBBIENES.xlsx";
            string dir = "";
            dir = Server.MapPath("~/") + "Plantillas\\ImportarExcel\\";// + fileNameExcel;

            string dirp = Server.MapPath("~/"+ "Plantillas");

            int verificar = 0;
            ///////////////////////////////////////////////////////////////////////////
            //string path = HttpContext.Server.MapPath("Views");
            string[] subfolders = System.IO.Directory.GetDirectories(dirp);
            //rutaDirExcel = Path.Combine(HttpContext.Request.MapPath(strRutaDir));
            //string[] Files = Directory.GetFiles(rutaDirectorioExcel);
            foreach (string i in subfolders)
            {
                if (i.Contains(carpetaImportarExcel))
                {
                    //System.IO.File.Delete(i);
                    verificar = 1;

                }
                //ELIMINA TODO DE ESA CARPETA
                //System.IO.File.Delete(file);
            }


            if (verificar == 0)
            {
                result.message = "La carpeta '" + carpetaImportarExcel + "' no existe o ha sido modificada.";
                result.type = "error";
            }

            //else if (!dir.Contains(carpetaImportarExcel))
            //{
            //    result.message = "La carpeta '" + carpetaImportarExcel + "' no existe o ha sido modificada.";
            //    result.type = "error";
            //}

            else
            {
                //result.message = "La carpeta '" + carpetaImportarExcel + "' si existe.";
                result.type = "success";

            }

                ////if (!dir.Contains(carpetaPlantilla))
                ////{
                ////    result.message = "La carpeta '" + carpetaPlantilla + "' no existe o ha sido modificada.";
                ////    result.type = "error";
                ////}

                ////else if (!dir.Contains(carpetaImportarExcel))
                ////{
                ////    result.message = "La carpeta '" + carpetaImportarExcel + "' no existe o ha sido modificada.";
                ////    result.type = "error";
                ////}

                ////else
                ////{
                ////    //result.message = "La carpeta '" + carpetaImportarExcel + "' si existe.";
                ////    result.type = "success";

                ////}

            }
            catch(Exception ex) {

                Log.AlmacenarLogError(ex, "PersonalController.cs");
                result.type = "error";
                result.message = "Ha ocurrido un inconveniente con la carpeta 'Plantillas'";
               

            }

            return Json(result);
            //return rutaDirExcel;
        }

        //OBTENER LA RUTA DE "DirImportacionExcel"
        public JsonResult getRutaDirImpotraExcel()
        {

            CustomResponse result = new CustomResponse();
            string strRutaDir = "";
            string rutaDirExcel = "";
            string strRutaDirWebConfig = "rutaMasivoExcel";
            //string strRutaDir = "";            
            //strRutaDir = ConfigurationManager.AppSettings["rutaMasivoExcel"];

            strRutaDir = ConfigurationManager.AppSettings[strRutaDirWebConfig];

            ///////////////////////////////////////////////////////////////////////////
            string fileName = "TBBIENES.xlsx";
            string dir = "";
            dir = Server.MapPath("~/") + "Plantillas\\ImportarExcel\\" + fileName;
            ///////////////////////////////////////////////////////////////////////////

            if (!String.IsNullOrEmpty(strRutaDir))/*strRutaDir != "" && */
            {
                //CREAR LA CARPETA
                rutaDirExcel = Path.Combine(HttpContext.Request.MapPath(strRutaDir));
                string folderPath = rutaDirExcel;//@"D:\MyFolder"
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                result.message = rutaDirExcel;
                result.type = "success";
            }
            else
            {
                result.message = "La ruta '" + strRutaDirWebConfig + "' donde debe generarse \n la carpeta 'DirImportacionExcel' no existe o ha sido modificada.";
                result.type = "info";

            }

            return Json(result);
            //return rutaDirExcel;
        }

        //ELIMINAR EXCEL POR IDPROCESSO DE "DirImportacionExcel"
        public int eliminarExcelDeDirectorio(string idProc)
        {
            /* //Elimina todos los archivos sin impostar ni extension ni nombre
               DirectoryInfo di = new DirectoryInfo(rutaDirectorioExcel);
               foreach (FileInfo file in di.GetFiles())
               {
                   file.Delete();
               }
               */
            
            //ELIMINA TODOS LOS EXCELS QUE EMPIEZAN CON NOMBRE DE IDPROCESO
            string EliminarEstos = idProc;
            string[] Files = Directory.GetFiles(rutaDirectorioExcel);
            foreach (string file in Files)
            {
                if (file.ToUpper().Contains(EliminarEstos.ToUpper()))
                {
                    System.IO.File.Delete(file);
                }
                //ELIMINA TODO DE ESA CARPETA
                System.IO.File.Delete(file);
            }

            return 1;
        }

        //ELIMINAR TODO EXCEL DE "DirImportacionExcel"
        public ActionResult eliminarTodoExcelDeDirImportacionExcel(string srtDirImportacionExcelP)//string res
        {
            string rutaDirectorioExcel_J = srtDirImportacionExcelP;
            //Elimina "Todos los archivos sin importar ni extension ni nombre"
               DirectoryInfo di = new DirectoryInfo(rutaDirectorioExcel_J);
               foreach (FileInfo file in di.GetFiles())
               {
                   file.Delete();
               }

            return Json(1);
        }

        public int IdProcess_(int IDPRoceso)
        {
            //Random random = new Random();
            //idP = random.Next(10000);
            idP = IDPRoceso;
           return 1;
        }

        /*====================================================================================== 
         * 9.0 Subir los Exels desde carpeta original hasta 'DirImportacionExcel' - HG 30.04.21
         * =====================================================================================*/
        public ActionResult uploadFilesToDirImportacion()/*HttpPostedFileBase formData*/
        {
            string IDPROCESO = "aleatorio";
            string NOMBREDEEXCEL = "nombre del excel";

            foreach (string item in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[item] as HttpPostedFileBase;
                string idProcesoAleatorio = item.Substring(item.IndexOf("/")+1);
                IDPROCESO = idProcesoAleatorio;

                string filen_ = file.FileName.Substring(file.FileName.IndexOf("/") + 1, file.FileName.Length);
                string fileName = idProcesoAleatorio  + filen_;// file.FileName;//num.ToString() +  //idP.ToString()
                string UploadPath = ConfigurationManager.AppSettings["rutaMasivoExcel"];

                int ContentLength_ = file.ContentLength;//No perder el tiempo intentando validar si el excel esta vacío con esta línea. Mejor contar si tiene filas.
                string ContentType_ = file.ContentType;
                string FileName_ = file.FileName;

                //////if (file.ContentLength == 0)
                //////    continue;
                //////if (file.ContentLength > 0)
                //////{
                    string path = Path.Combine(HttpContext.Request.MapPath(UploadPath), fileName);
                    string extension = Path.GetExtension(file.FileName);

                    rutaDirectorioExcel = Path.Combine(HttpContext.Request.MapPath(UploadPath));

                    file.SaveAs(path);

                    nombreExcel = fileName;
                    idProceso = idP;
                    NOMBREDEEXCEL = filen_;
                //////}
            }

            //ARCHIVOS EXCEL DENTRO DE UN ARRAY
            //string supportedExtensions = "*.xlsx,*.xls";
            //string[] files = Directory.GetFiles(rutaDirectorioExcel,  IDPROCESO + "*.xlsx,.xls");//".xls", ".xslx"

            string[] filesExcel={"valor de inicializacion"};
            string strExtension = NOMBREDEEXCEL.Substring(NOMBREDEEXCEL.LastIndexOf("."));

            if (strExtension == ".csv")
            {

                filesExcel = Directory.GetFiles(rutaDirectorioExcel, IDPROCESO + "*.csv");

            }
            if (strExtension == ".xls")
            {

                filesExcel = Directory.GetFiles(rutaDirectorioExcel, IDPROCESO + "*.xls");

            }
            if (strExtension == ".xlsx") {

                filesExcel = Directory.GetFiles(rutaDirectorioExcel, IDPROCESO + "*.xlsx");

            }
            if (strExtension == ".txt")
            {

                filesExcel = Directory.GetFiles(rutaDirectorioExcel, IDPROCESO + "*.txt");

            }
            //foreach (string file in files)
            //{
            //    ////System.IO.File.Delete(file);
            //    ////System.IO.File.Delete(file);
            //    ////Console.WriteLine($"{file} is deleted.");
            //    //string filename = Path.GetFileName(file);
            //    //Response.Write(filename);
            //}

            return Json(filesExcel);

        }
   

        //EN EL JS SE COMENTO viernes 04:13pm
        public ActionResult verificarExistenciaExcel(int idProc)
        {
            string[] arreglo = Directory.GetFiles(rutaDirectorioExcel, idProc + "*.xlsx");
            return Json(arreglo);

        }


        /*================================================================================= 
        * Leer cada Excel y verificar si tienen contenido - HG 30.04.21
        * =================================================================================*/
        public DataTable ReadExcelValidarVacion(string nombreExcel_v, int idProceso_v, string RutaMasivoExcels)
        {
            string urlRuta = RutaMasivoExcels + "\\" + nombreExcel_v;
            DataTable table = new DataTable();
            try
            {
                string strExt = urlRuta.Substring(urlRuta.LastIndexOf("."));
                FileStream stream = System.IO.File.Open(urlRuta, FileMode.Open, FileAccess.Read);
                IExcelDataReader excelReader;

                if (strExt == ".xls")
                {
                    //The CreateOpenXMLReader() method is used on 2007 file versions of Excel and the CreateBinaryReader() method is used on earlier version of ...
                    excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                else if (strExt == ".csv")
                {
                    excelReader = ExcelReaderFactory.CreateCsvReader(stream);
                    // excelReader = ExcelReaderFactory.CreateCsvReader(stream, new ExcelReaderConfiguration()
                    //{
                    //    // Gets or sets the encoding to use when the input XLS lacks a CodePage
                    //    // record, or when the input CSV lacks a BOM and does not parse as UTF8. 
                    //    // Default: cp1252 (XLS BIFF2-5 and CSV only)
                    //    FallbackEncoding = Encoding.GetEncoding(1252),

                    //    // Gets or sets the password used to open password protected workbooks.
                    //    Password = "password",

                    //    // Gets or sets an array of CSV separator candidates. The reader 
                    //    // autodetects which best fits the input data. Default: , ; TAB | # 
                    //    // (CSV only)
                    //    AutodetectSeparators = new char[] { ',', ';', '\t', '|', '#' },

                    //    // Gets or sets a value indicating whether to leave the stream open after
                    //    // the IExcelDataReader object is disposed. Default: false
                    //    LeaveOpen = false,

                    //    // Gets or sets a value indicating the number of rows to analyze for
                    //    // encoding, separator and field count in a CSV. When set, this option
                    //    // causes the IExcelDataReader.RowCount property to throw an exception.
                    //    // Default: 0 - analyzes the entire file (CSV only, has no effect on other
                    //    // formats)
                    //    AnalyzeInitialCsvRows = 0,
                    //});
                }

            ////    else if (strExt == ".csv")
            ////    {

            ////        excelReader = ExcelReaderFactory.CreateReader(stream, new ExcelReaderConfiguration()
            ////        {
            ////            // Gets or sets the encoding to use when the input XLS lacks a CodePage
            ////            // record, or when the input CSV lacks a BOM and does not parse as UTF8. 
            ////            // Default: cp1252. (XLS BIFF2-5 and CSV only)
            ////            FallbackEncoding = Encoding.GetEncoding(1252),

            ////            // Gets or sets the password used to open password protected workbooks.
            ////            Password = "password",

            ////            // Gets or sets an array of CSV separator candidates. The reader 
            ////            // autodetects which best fits the input data. Default: , ; TAB | # 
            ////            // (CSV only)
            ////            AutodetectSeparators = new char[] { ',', ';', '\t', '|', '#' };
            ////    });
            ////}

                else
                {
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }

                var conf = new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = false//true
                    }
                };

                DataSet ds = new DataSet();
                ds = excelReader.AsDataSet(conf);
                stream.Close();

                DataTable dtExcelDatos = ds.Tables[0];
                int numCol = dtExcelDatos.Columns.Count;

                if (nombreExcel_v.Contains("PRODU"))
                {
                    table.Columns.Add("strCoProdu", typeof(string));
                    table.Columns.Add("strDeProdu", typeof(string));
                }
                //---------------------------------------------------------------

                //Independiente de la estructura de table
                foreach (DataRow row in dtExcelDatos.Rows)
                {
                    DataRow rows = table.NewRow();

                    if (nombreExcel_v.Contains("TMPRODU"))
                    {
                        rows["strCoProdu"] = row[0];
                        rows["strDeProdu"] = row[1];
                    }

                    table.Rows.Add(rows);
                    //table.Rows.Count;
                    //contador++;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return table;
        }


        /*================================================================================= 
        * 9.5 VALIDAR - Importa hasta la BD los 08 excels en un solo Método
        * =================================================================================*/
        public ActionResult ValidarFilasDeLosExcel(int cboPlantilla, int cboFormato, bool checkActualizar, string pathDelDirectorio_)
        {
            ////Session_Movi objSession = new Session_Movi();
            ////objSession.intIdSesion = Auth.intIdSesion();
            ////objSession.intIdSoft = Auth.intIdSoft();
            ////objSession.intIdMenu = intIdMenuGlo;
            ////objSession.intIdUsuario = Auth.intIdUsuario();
            CustomResponse result = new CustomResponse();

            string RutaMasivoExcels1 = pathDelDirectorio_.Substring(pathDelDirectorio_.IndexOf(".") + 1);
            string nombreExcel_v = pathDelDirectorio_.Substring(pathDelDirectorio_.LastIndexOf("\\") + 1);
            string idProceso_ = nombreExcel_v.Substring(0, nombreExcel_v.LastIndexOf("TM")); //SISACTIVO ES TB
            int idProceso_v = Convert.ToInt32(idProceso_);
            string RutaMasivoExcels = pathDelDirectorio_.Substring(0, pathDelDirectorio_.LastIndexOf("\\") + 1);

            try
            {     
                DataTable dt = ReadExcelValidarVacion(nombreExcel_v, idProceso_v, RutaMasivoExcels);                
                int numberOfRecords = dt.Rows.Count;
                int numberOfColumns = dt.Columns.Count;
                if(numberOfRecords > 0 )
                {
                    //result.type = "info";
                    //result.message = "El Excel " + nombreExcel_v + " No contiene datos";
                }
                else 
                {
                    result.type = "info";
                    result.message = "El Excel " + nombreExcel_v + " No contiene datos";

                }

            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
                result.type = "error";
                if (ex.HResult == -2147024864)
                {
                    result.message = "Tiene que cerrar el Excel " + nombreExcel_v + " que está siendo utilizado en otro lado";
                }
                else if (ex.HResult == -2147024894)
                {
                    result.message = "El Excel " + nombreExcel_v + " no se ha cargado correctamente";
                }
                else
                {
                    result.message = "Ocurrió un inconveniente al validar el archivo Exel " + nombreExcel_v ;
                }

            }

            return Json(result);
        }

         /*================================================================================= 
         * 9.7 ELIMINAR TABLA POR TABLA O TODOS JUNTOS - USADO POR INVENTARIOWEB
         * =================================================================================*/
        public JsonResult LimpiarTablasExcel(bool chckTodos, bool chckEntidad, bool chckLocal, bool chckArea, bool chckOficina, bool chckEmpleado, bool chckEstado, bool chckTipo, bool chckBienes, bool chckTmprodu /*int intIdMenu, int intIdPerfil*/)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();

            CustomResponse result = new CustomResponse();
            string strMsjUsuario = ""; ;
            try
            {
                bool delete = false;
                //using (Seguridad_tsp = new SeguridadSrvClient())
                //using (proxy = new PersonalSrvClient())
                //{
                    delete = objImportarExcelBL.LimpiarTablasExcel(objSession, chckTodos, chckEntidad, chckLocal, chckArea, chckOficina, chckEmpleado, chckEstado, chckTipo, chckBienes, chckTmprodu, ref strMsjUsuario);
                //    proxy.Close();
                //}

                if (strMsjUsuario.Equals(""))
                {
                    result.type = "success";
                    result.message = "Las Tablas seleccionadas se limpiaron correctamente.";
                }
                else
                {
                    result.type = "error";
                    result.message = strMsjUsuario;
                }
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
                result.type = "error";
                result.message = "Ocurrió un inconveniente al limpiar tabla";
            }
            return Json(result);
        }

        /*================================================================================= 
        * 9.1 IMPORTAR EXCEL - Importa hasta la BD los 08 excels en un solo Método
        * =================================================================================*/
        public ActionResult ImportMasivoExcel(int cboPlantilla, int cboFormato, bool checkActualizar, string pathDelDirectorio_)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();

            ////-------------------------------------------------------------
            //List<List> arrListInconsistentes = new List<List>();
            //var arrListInconsistentes = new ArrayList(); // recommended             

            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";
            try
            {
                string nombreExcel_v = pathDelDirectorio_.Substring(pathDelDirectorio_.LastIndexOf("\\") +1);
                string idProceso_ = nombreExcel_v.Substring(0,nombreExcel_v.LastIndexOf("TB"));
                int idProceso_v = Convert.ToInt32(idProceso_);

                    //LINEA SOLO¨PARA PROBAR QUE EXCEL ENTRA PRIMERO
                    //string someText = nombreExcel_v;
                    //System.IO.File.WriteAllLines(@"D:\martes.txt", someText);  
                    //List<List> arrListInconsistentes = new List<List>();

                     List<ResultImportExcel> listExcel = new List<ResultImportExcel>();                    
                    //using (proxy = new PersonalSrvClient())
                    //{
                    listExcel = objImportarExcelBL.ImportExcelMasivoEntidad(objSession, nombreExcel_v, /*arrListInconsistentes, *//*nombreExcel*/ idProceso, cboPlantilla, cboFormato, checkActualizar, rutaDirectorioExcel, ref strMsgUsuario).ToList();
                    //    proxy.Close();
                    //}
                    
                    if (strMsgUsuario == "")
                    {
                        result.type = "success";
                        result.message = "Los datos del Excel fueron llenados de forma correcta";
                        result.objeto = listExcel;

                    /***********************************
                     if (nombreExcel_v.Contains("TBBIENES"))
                     {
                        string filePath = rutaDirectorioExcel + "RegistrosInconsistentes.txt";        //"inconsistencias.log";           
                        List<string> lines = System.IO.File.ReadLines(filePath).ToList();
                        System.IO.File.Delete(filePath);
                        result.objetoLista = lines;

                     }

                     *********************************/
                    ////Eliminar todos los archivo excel con ese IdProceso
                    //DirectoryInfo di = new DirectoryInfo(rutaDirectorioExcel);
                    //foreach (FileInfo file in di.GetFiles().Where(p => p.Name.StartsWith(idProceso_)))//Solo se elimina los de ID PROCESSO
                    //{
                    //    file.Delete();
                    //}'                    
                    //CustomResponse result = new CustomResponse();
                }

                else
                    {
                        result.type = "info";
                        //result.message = strMsgUsuario;
                        result.message = "Hubo inconvenientes al Importar uno de los Excels";

                    //if (strMsgUsuario.Contains("BEGIN y COMMIT"))
                    //{
                    //    result.type = "info";
                    //    //result.message = "Hubo inconvenientes al importar el documento" + nombreExcel_v;
                    //    result.message = nombreExcel_v + " tiene dependencia.";
                    //}

                    }                    

  
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
                result.type = "error";
                result.message = "Ocurrió un inconveniente al importar los datos del excel";
            }

            return Json(result);
        }


        /*================================================================================= 
         * 9.2 GUARDAR RUTA X IP EN LA TABLA TBRUTA DE LA BD:  RegistrarMarcacionConDni
         * =================================================================================*/
        public JsonResult IRutaDirectorioPorIpMasivoExcel(string strDesRuta, string strSessionIp)//,wsAsistencia.Session_Movi objSession//, wsPersona.Session_Movi objSession
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
                //using (proxy = new PersonalSrvClient())
                //{
                    //insert = proxy.IRutaPorIpMasivoExcel(objSession, intTipoOperacion, ObjEmpleadoConDni, ref strMsgUsuario);
                    insert = objImportarExcelBL.IRutaDirectorioPorIpMasivoExcel(objSession, strDesRuta, strSessionIp, ref strMsgUsuario);
                //    proxy.Close();
                //}

                if (insert)
                {
                    result.type = "success";
                }

                else if (!strMsgUsuario.Equals(""))
                {
                    result.type = "info";
                    result.message = strMsgUsuario;
                }

            }
            catch (Exception)
            {
                result.type = "Error Desconocido";
                result.message = "Ocurrió un inconveniente al registrar el Servicio";
            }
            return Json(result);
        }

        #endregion

        #region Inventario Web - Importar Excel

        /*============================================================================================ 
         * Listar Combos
         * ===========================================================================================*/
        public JsonResult ListarCombosPersonal_(string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo)

        {
            string strMsgUsuario = "";
            List<TGTipoEN> lista_Tipo = new List<TGTipoEN>();
           
            lista_Tipo = objImportarExcelBL.ListarCombos(3, 1, 6, strEntidad, intIdFiltroGrupo, strGrupo, strSubGrupo, ref strMsgUsuario).ToList();

           
            return Json(lista_Tipo);
        }

        /*============================================================================================ 
         * 26.1 IMPORTAR EXCEL CSV- Importa hasta la BD el UN excel en un solo Método 23.008.21
         * ===========================================================================================*/
        public ActionResult ImportArchivosExcelInvtWeb(int cboPlantilla, string strFormato, bool checkActualizar, string pathDelDirectorio_)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();
            ////-------------------------------------------------------------
            //List<List> arrListInconsistentes = new List<List>();
            //var arrListInconsistentes = new ArrayList(); // recommended           
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";
            try
            {
                string nombreExcel_v = pathDelDirectorio_.Substring(pathDelDirectorio_.LastIndexOf("\\") + 1);
                string idProceso_ = nombreExcel_v.Substring(0, nombreExcel_v.LastIndexOf("TM"));
                int idProceso_v = Convert.ToInt32(idProceso_);
                //LINEA SOLO¨PARA PROBAR QUE EXCEL ENTRA PRIMERO
                //string someText = nombreExcel_v;
                //System.IO.File.WriteAllLines(@"D:\martes.txt", someText);  
                //List<List> arrListInconsistentes = new List<List>();
                List<ResultImportExcel> listExcel = new List<ResultImportExcel>();
                //using (proxy = new PersonalSrvClient())
                //{
                listExcel = objImportarExcelBL.ImportArchivosExcelInvtWeb(objSession, nombreExcel_v,  idProceso, cboPlantilla, strFormato, checkActualizar, rutaDirectorioExcel, ref strMsgUsuario).ToList();
                //    proxy.Close();
                //}

                if (strMsgUsuario == "")
                {
                    result.type = "success";
                    result.message = "Los datos del Excel fueron llenados de forma correcta";
                    result.objeto = listExcel;

                    /***********************************
                     if (nombreExcel_v.Contains("TBBIENES"))
                     {
                        string filePath = rutaDirectorioExcel + "RegistrosInconsistentes.txt";        //"inconsistencias.log";           
                        List<string> lines = System.IO.File.ReadLines(filePath).ToList();
                        System.IO.File.Delete(filePath);
                        result.objetoLista = lines;

                     }

                     *********************************/
                    ////Eliminar todos los archivo excel con ese IdProceso
                    //DirectoryInfo di = new DirectoryInfo(rutaDirectorioExcel);
                    //foreach (FileInfo file in di.GetFiles().Where(p => p.Name.StartsWith(idProceso_)))//Solo se elimina los de ID PROCESSO
                    //{
                    //    file.Delete();
                    //}'                    
                    //CustomResponse result = new CustomResponse();
                }

                else
                {
                    result.type = "info";
                    //result.message = strMsgUsuario;
                    result.message = "Hubo inconvenientes al Importar uno de los Excels";

                    //if (strMsgUsuario.Contains("BEGIN y COMMIT"))
                    //{
                    //    result.type = "info";
                    //    //result.message = "Hubo inconvenientes al importar el documento" + nombreExcel_v;
                    //    result.message = nombreExcel_v + " tiene dependencia.";
                    //}

                }


            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
                result.type = "error";
                result.message = "Ocurrió un inconveniente al importar los datos del excel";
            }

            return Json(result);
        }


        /*================================================================================= 
         * 26.2.- VALIDAR - Importa hasta la BD los 08 excels en un solo Método
         * =================================================================================*/
        public ActionResult ValidarFilasDeLosExcelInvtWeb(int cboPlantilla, string strFormato, bool checkActualizar, string pathDelDirectorio_)
        {
            ////Session_Movi objSession = new Session_Movi();
            ////objSession.intIdSesion = Auth.intIdSesion();
            ////objSession.intIdSoft = Auth.intIdSoft();
            ////objSession.intIdMenu = intIdMenuGlo;
            ////objSession.intIdUsuario = Auth.intIdUsuario();
            CustomResponse result = new CustomResponse();

            string RutaMasivoExcels1 = pathDelDirectorio_.Substring(pathDelDirectorio_.IndexOf(".") + 1);
            string nombreExcel_v = pathDelDirectorio_.Substring(pathDelDirectorio_.LastIndexOf("\\") + 1);
            string idProceso_ = nombreExcel_v.Substring(0, nombreExcel_v.LastIndexOf("TM")); //SISACTIVO ES TB
            int idProceso_v = Convert.ToInt32(idProceso_);
            string RutaMasivoExcels = pathDelDirectorio_.Substring(0, pathDelDirectorio_.LastIndexOf("\\") + 1);


            string strNombreDeArchivo = nombreExcel_v.Substring(nombreExcel_v.LastIndexOf("T"));

            try
            {


                ////////////////////////////////////////////////
                //PRIMERO: VALIDA CANTIDAD DE COLUMNAS
                ////////////////////////////////////////////////
                int numeroDeColumnas = 0;
                numeroDeColumnas = ReadExcelValidarCantColumasDelExcel(nombreExcel_v, RutaMasivoExcels);
                if (strNombreDeArchivo == "TMPRODU.txt")
                {
                    numeroDeColumnas = 2;

                    //bool txtContenido = ReadExcelValidarTxtVacio(nombreExcel_v, RutaMasivoExcels);
                    //////if (txtContenido == false)
                    //////{
                    //////    result.type = "info";
                    //////    result.message = "El Archivo " + strNombreDeArchivo + " no contiene datos111.";
                    //////}

                }
                if (numeroDeColumnas == 0 )
                {
                    result.type = "info";
                    result.message = "El Excel " + strNombreDeArchivo + " no contiene ninguna columna.";
                }
                else if (numeroDeColumnas == 1)
                {
                    result.type = "info";
                    result.message = "El Excel " + strNombreDeArchivo + " debe contener dos columnas.";
                }
                else if (numeroDeColumnas > 2)
                {
                    result.type = "info";
                    result.message = "El Excel " + strNombreDeArchivo + " no debe contener mas dos columnas.";
                }
                ////////////////////////////////////////////////
                //SEGUNDO: CANT DE REGISTROS O FILAS EN EL EXCEL 
                ////////////////////////////////////////////////
                else
                {

                    DataTable dt = ReadExcelValidarArchivoVacio(nombreExcel_v, idProceso_v, RutaMasivoExcels);
                    int numberOfRecords = dt.Rows.Count;
                    int numberOfColumns = dt.Columns.Count;

                    if (numberOfRecords < 1)
                    {
                        result.type = "info";
                        result.message = "El Archivo " + strNombreDeArchivo + " no contiene datos.";
                    }
                    else
                    {
                        ////CASO CONTRARIO NO HAY MENSAJE Y CONTINUA LA IMPORTACION
                    }


                }

            



            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
                result.type = "error";
                if (ex.HResult == -2147024864)
                {
                    result.message = "Tiene que cerrar el Archivo " + strNombreDeArchivo + " que está siendo utilizado en otro lado";
                }
                else if (ex.HResult == -2147024894)
                {
                    result.message = "El Archivo " + strNombreDeArchivo + " no se ha cargado correctamente";
                }
                else
                {
                    result.message = "Ocurrió un inconveniente al validar el Archivo " + strNombreDeArchivo;
                }

            }

            return Json(result);
        }

        /*================================================================================= 
        * 26.3.- CONTAR CUANTAS COLUMNAS TIENE EL EXCEL CARGADO AL TEMPORAL
        * =================================================================================*/
        public int ReadExcelValidarCantColumasDelExcel(string nombreExcel_v, string RutaMasivoExcels)
        {
            string urlRuta = RutaMasivoExcels + "\\" + nombreExcel_v;
            DataTable table = new DataTable();
            int numCol = 0;
            try
            {
                string strExt = urlRuta.Substring(urlRuta.LastIndexOf("."));

                //CUANDO EL ARCHIVO ES UN TXT SIMPLE SEPARADOS POR LA PRIMARA COMA - AÑADIDO EL 24.08.21 17:04PM
                if (strExt == ".txt")
                {
                    DataTable result = new DataTable();
                    result.Columns.Add(new DataColumn("CodidoProd", typeof(string)));
                    result.Columns.Add(new DataColumn("Producto", typeof(string)));
                    foreach (var line in System.IO.File.ReadLines(urlRuta))
                    {
                        DataRow row = result.NewRow();
                        String[] items = line.Split(new Char[] { ',', '\t' }, 2); //StringSplitOptions.RemoveEmptyEntries
                        result.Rows.Add(items);
                    }
                    //Eliminar la primera fila que no deseo
                    //result.Rows.RemoveAt(0);
                    table = result;

                }
                //CASO CONTRARIO PUEDEN SER CUALQUIERA DE LOS EXCELS CSV XLS o XLSX
                else
                {


                    FileStream stream = System.IO.File.Open(urlRuta, FileMode.Open, FileAccess.Read);
                    IExcelDataReader excelReader;

                    if (strExt == ".xls")
                    {

                        //The CreateOpenXMLReader() method is used on 2007 file versions of Excel and the CreateBinaryReader() method is used on earlier version of ...
                        excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (strExt == ".csv")
                    {
                        excelReader = ExcelReaderFactory.CreateCsvReader(stream);
                    }
                    else
                    {
                        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }

                    var conf = new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = false//true
                        }
                    };

                    DataSet ds = new DataSet();
                    ds = excelReader.AsDataSet(conf);
                    stream.Close();

                    DataTable dtExcelDatos = ds.Tables[0];
                    numCol = dtExcelDatos.Columns.Count;

                }

            }
            catch (Exception ex)
            {
                //{ "Input array is longer than the number of columns in this table."} ERROR DE LOS DATOS DE EXCEL
                throw ex;
            }
            return numCol;
        }

        /*================================================================================= 
        * 26.4.- LEER CADA EXCEL Y VERIFICAR QUE TENGA CONTENIDO
        * =================================================================================*/
        public DataTable ReadExcelValidarArchivoVacio(string nombreExcel_v, int idProceso_v, string RutaMasivoExcels)
        {
            string urlRuta = RutaMasivoExcels + "\\" + nombreExcel_v;
            DataTable table = new DataTable();
            try
            {
                string strExt = urlRuta.Substring(urlRuta.LastIndexOf("."));


                //CUANDO EL ARCHIVO ES UN TXT SIMPLE SEPARADOS POR LA PRIMARA COMA - AÑADIDO EL 24.08.21 17:04PM
                if (strExt == ".txt")
                {
                    //https://stackoverflow.com/questions/30524153/split-file-txt-to-fill-in-datatable-c-sharp //HGMHELPER

                    DataTable result = new DataTable();
                    result.Columns.Add(new DataColumn("CodidoProd", typeof(string)));
                    result.Columns.Add(new DataColumn("Producto", typeof(string)));
                    foreach (var line in System.IO.File.ReadLines(urlRuta))
                    {
                        DataRow row = result.NewRow();
                        String[] items = line.Split(new Char[] { ',', '\t' }, 2); //StringSplitOptions.RemoveEmptyEntries
                        result.Rows.Add(items);
                    }
                    //Eliminar la primera fila que no deseo
                    //result.Rows.RemoveAt(0);
                    table = result;

                }
                //CASO CONTRARIO PUEDEN SER CUALQUIERA DE LOS EXCELS CSV XLS o XLSX
                else
                {


                    FileStream stream = System.IO.File.Open(urlRuta, FileMode.Open, FileAccess.Read);
                    IExcelDataReader excelReader;

                    if (strExt == ".xls")
                    {
                      
                        //The CreateOpenXMLReader() method is used on 2007 file versions of Excel and the CreateBinaryReader() method is used on earlier version of ...
                        excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (strExt == ".csv")
                    {
                        excelReader = ExcelReaderFactory.CreateCsvReader(stream);
                    }
                    else
                    {
                        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }

                    var conf = new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = false//true
                        }
                    };

                    DataSet ds = new DataSet();
                    ds = excelReader.AsDataSet(conf);
                    stream.Close();

                    DataTable dtExcelDatos = ds.Tables[0];
                    int numCol = dtExcelDatos.Columns.Count;

                    if (nombreExcel_v.Contains("PRODU"))
                    {
                        table.Columns.Add("strCoProdu", typeof(string));
                        table.Columns.Add("strDeProdu", typeof(string));
                    }

                    //Independiente de la estructura de table
                    foreach (DataRow row in dtExcelDatos.Rows)
                    {
                        DataRow rows = table.NewRow();

                        if (nombreExcel_v.Contains("TMPRODU"))
                        {
                            rows["strCoProdu"] = row[0];
                            rows["strDeProdu"] = row[1];
                        }

                        table.Rows.Add(rows);

                    }
                }

            }
            catch (Exception ex)
            {
                //{ "Input array is longer than the number of columns in this table."} ERROR DE LOS DATOS DE EXCEL
                throw ex;
            }
            return table;
        }

        /*================================================================================= 
         * 26.5.- LEER EL TXT Y VERIFICAR QUE TENGA CONTENIDO //NO USADO //ELIMINABLE https://stackoverflow.com/questions/4965023/c-sharp-check-if-text-file-has-content
         * =================================================================================*/
        public bool ReadExcelValidarTxtVacio(string nombreExcel_v, string RutaMasivoExcels)
        {
            bool trueFalse=false;//NO TIENE CONTENIDO   
            string urlRuta = RutaMasivoExcels + "\\" + nombreExcel_v;


            FileInfo f = new FileInfo(urlRuta);
            if (f.Length > 0)
                trueFalse = true; //TIENE CONTENIDO                      
           
            return trueFalse;
        }

        ///////*============================================================================================ 
        ////// * PRUEBA
        ////// * ===========================================================================================*/
        //////public ActionResult ImportArchivosExcelInvtWeb_TXT(int cboPlantilla, 
        //////    int strFormato, bool checkActualizar, string rutaDirectorioExcel)
        //////{
        //////    Session_Movi objSession = new Session_Movi();
        //////    objSession.intIdSesion = Auth.intIdSesion();
        //////    objSession.intIdSoft = Auth.intIdSoft();
        //////    objSession.intIdMenu = intIdMenuGlo;
        //////    objSession.intIdUsuario = Auth.intIdUsuario();
        //////    ////-------------------------------------------------------------
        //////    //List<List> arrListInconsistentes = new List<List>();
        //////    //var arrListInconsistentes = new ArrayList(); // recommended           
        //////    CustomResponse result = new CustomResponse();
        //////    string strMsgUsuario = "";
        //////    try
        //////    {

        //////        //DataTable dt = ReadExcelValidarVacion_TXT(nombreExcel_v, idProceso_v, RutaMasivoExcels);

        //////        List<ResultImportExcel> listExcel1 = new List<ResultImportExcel>();

        //////        listExcel1 = objImportarExcelBL.ImportArchivosExcelInvtWeb_TXT(objSession, "TMPRODU",  1, 1, 1, checkActualizar, rutaDirectorioExcel, ref strMsgUsuario).ToList();



        //////    }
        //////    catch (Exception ex)
        //////    {
        //////        Log.AlmacenarLogError(ex, "PersonalController.cs");
        //////        result.type = "error";
        //////        result.message = "Ocurrió un inconveniente al importar los datos del excel";
        //////    }

        //////    return Json(result);
        //////}



        //https://stackoverflow.com/questions/42758337/how-to-read-write-process-txt-file-like-database-in-c-sharp-console
        #endregion

        #region Renombrar Campos
        /*************************
        //10.0  VISTA DEL HTML DE IRENOMBRAR CAMPOS
        public ActionResult RenombrarCampos(string intIdMenu)
        {
            if (Auth.isAuthenticated())
            {
                intIdMenuGlo = Convert.ToInt32(intIdMenu);
                return View();
            }

            return RedirectToAction("CerrarSesion", "LoginSiscop");
        }

        //10.1
        public JsonResult ListarRenombrarCampos(string strfilter)
        {
 

            string strMsgUsuario = "";
            List<RenombrarCampos> ListarRenomCampos = new List<RenombrarCampos>();
            try
            {
                using (proxy = new PersonalSrvClient())
                {
                    ListarRenomCampos = proxy.ListarRenombrarCampos( Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), 2, strfilter, 0, ref strMsgUsuario).ToList();
                    proxy.Close();
                }
                //return Json(ListarCargos);
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
            }

            return Json(ListarRenomCampos);
            //return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);

        }

        //10.2 // No usado
        public ActionResult EditarCargo1(RenombrarCampos objRenombrarCampos)
        {
            string strMsgUsuario = "";
            //List<JerarquiaOrg> lista_Unid_Sup = new List<JerarquiaOrg>();
            List<RenombrarCampos> list_car_det = new List<RenombrarCampos>();

            //using (proxyOrg = new OrganizacionSrvClient())
            using (proxy = new PersonalSrvClient())
            {
                //lista_Unid_Sup = proxyOrg.ListarCampoJerarquía(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), ref strMsgUsuario).ToList();

                //list_car_det = proxy.ConsultarDetalleCargoxCod(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), objCargo.intIdCargo, ref strMsgUsuario).ToList();
                proxy.Close();

            }
            //ViewBag.CampJerar = new SelectList(lista_Unid_Sup, "IntIdJerOrg", "strNomJerOrg");
            object[] Datos = { ViewBag.CampJerar, list_car_det };
            return PartialView("_partialEditarCargo", Datos);
        }

        //10.3  getCamposCargosPorId  Datos Actualizados Satisfactoriamente.
        public JsonResult getCamposPorId(string strCodigo)
        {
            string strMsgUsuario = "";
            List<RenombrarCampos> DatosCampos = new List<RenombrarCampos>();

            try
            {
                using (proxy = new PersonalSrvClient())
                {
                    DatosCampos = proxy.getRenombrarCamposPorId(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), strCodigo, ref strMsgUsuario).ToList();
                    proxy.Close();
                }

                //return Json(DatosCampos);

            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
            }

            return Json(DatosCampos);
            //return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);

        }

        //10.4 
        public JsonResult UpdateCamposRenombrados(RenombrarCampos objCamposRenombrados, int intTipoOperacion)
        {
            wsPersona.Session_Movi objSession = new wsPersona.Session_Movi();
            objSession.intIdSesion            = Auth.intIdSesion();
            objSession.intIdSoft              = Auth.intIdSoft();
            objSession.intIdMenu              = intIdMenuGlo;
            objSession.intIdUsuario           = Auth.intIdUsuario();

            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";

            try
            {
                bool insert = false;

                using (proxy = new PersonalSrvClient())
                {
                    insert = proxy.UpdateCamposRenombrados(objSession, intTipoOperacion, objCamposRenombrados, ref strMsgUsuario);
                    proxy.Close();
                }


                if (insert)
                {
                    result.type = "success";

                    if (intTipoOperacion == 1)
                    {
                        result.message = "Campo Actualizado Satisfactoriamente.";

                    }
                    if (intTipoOperacion == 2)
                    {
                        result.message = "Campos Actualizados Satisfactoriamente.";

                    }
                }

                else if (!strMsgUsuario.Equals(""))
                {
                    result.type = "info";
                    result.message = strMsgUsuario;
                }

            }
            catch (Exception)
            {
                result.type = "Error Desconocido";
                result.message = "Ocurrió un inconveniente al registrar el Servicio";
            }

            return Json(result);
        }

     
        public JsonResult MaestroMaximoCaracteres(string StrNomMan)
        {
            List<ValidacionPorLongitudDeCampo> detConcepto = new List<ValidacionPorLongitudDeCampo>();
            using (proxy = new PersonalSrvClient())
            {
                detConcepto = proxy.MaestroMaximoCaracteres(StrNomMan).ToList();
            }
            return Json(detConcepto);
        }
  

        

        //EJEMPLO
        public JsonResult GetTablaServicio(wsAsistencia.Session_Movi objSession, int IntActivoFilter, string strfilter, int intfiltrojer1, int intfiltrojer2, int intfiltroClase, int intUso)
        {
            string strMsgUsuario = "";

            List<TCSERVICIO> ListarServicios = new List<TCSERVICIO>();
            using (proxyOrg = new AsistenciaSrvClient())
            {
                ListarServicios = proxyOrg.ListarServicios(objSession, IntActivoFilter, strfilter, intfiltrojer1, intfiltrojer2, intfiltroClase, intUso, ref strMsgUsuario).ToList();
                proxyOrg.Close();
            }
            return Json(ListarServicios);
        }

        *************************/


        #endregion Renombrar Campos

        #region PERSONAL SISCOP
        /*
        public ActionResult Empleado(string intIdMenu)
        {
            if (Auth.isAuthenticated())
            {
                intIdMenuGlo = Convert.ToInt32(intIdMenu);
                return View();
            }
            return RedirectToAction("CerrarSesion", "LoginSiscop");
        }

        public ActionResult NuevoEmpleado()
        {
            return PartialView("_partialNuevoEmpleado");
        }

        public ActionResult EditarEmpleado()
        {
            return PartialView("_partialEditarEmpleado");
        }

        public ActionResult GetTablaPersonal(int IntActivoFilter, int intIdUniOrg, string strfilter, string dttfiltrofch1, string dttfiltrofch2)
        {
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";

            try
            {
                List<Dominio.Entidades.PersonalData> ListarPersonal = new List<Dominio.Entidades.PersonalData>();
                //PersonalSrvClient proxyOrg;
                //using (proxyOrg = new PersonalSrvClient())
                //{
                    ListarPersonal = proxyOrg.ListarPersonal(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), IntActivoFilter, intIdUniOrg, strfilter, dttfiltrofch1, dttfiltrofch2, ref strMsgUsuario).ToList();
                //    proxyOrg.Close();
                //}

                //List<List<string>> lista = new List<List<string>>();

                //List<string> list;
                //ListarPersonal.ForEach(x =>
                //{
                //    list = new List<string>();
                //    list.Add(x.intIdPersonal.ToString());
                //    list.Add(x.strNombres);
                //    list.Add(x.strNumDoc);
                //    list.Add(x.dttFecAdmin);
                //    list.Add(x.bitEspecifica_DESC);
                //    lista.Add(list);
                //});

                var jsonResult = Json(ListarPersonal, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonaController.cs");
            }
            result.type = "errorInt";
            result.message = "Ocurrió un inconveniente al listar";

            return Json(result);
        }

        public ActionResult GetMarcadoresPersonal(int intIdMenu, int intIdPersonal)
        {
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";

            try
            {
                List<TGPERMARCDET> Listar = new List<TGPERMARCDET>();
                PersonalSrvClient proxyOrg;
                using (proxyOrg = new PersonalSrvClient())
                {
                    Listar = proxyOrg.ListarMarcadoresPersonal(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), intIdPersonal, ref strMsgUsuario).ToList();
                    proxyOrg.Close();
                }
                var jsonResult = Json(Listar, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
            }

            result.type = "errorInt";
            result.message = "Ocurrió un inconveniente al listar";
            return Json(result);
        }

        public ActionResult GetCorreosPersonal(int intIdMenu, int intIdPersonal)
        {
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";

            try
            {
                List<TGPERCORRDET> Listar = new List<TGPERCORRDET>();
                PersonalSrvClient proxyOrg;
                using (proxyOrg = new PersonalSrvClient())
                {
                    Listar = proxyOrg.ListarCorreosPersonal(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), intIdPersonal, ref strMsgUsuario).ToList();
                    proxyOrg.Close();
                }
                var jsonResult = Json(Listar, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
            }

            result.type = "errorInt";
            result.message = "Ocurrió un inconveniente al listar";
            return Json(result);
        }

        public ActionResult GetTelefonosPersonal(int intIdMenu, int intIdPersonal)
        {
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";

            try
            {
                List<TGPERTELEFDET> Listar = new List<TGPERTELEFDET>();
                PersonalSrvClient proxyOrg;
                using (proxyOrg = new PersonalSrvClient())
                {
                    Listar = proxyOrg.ListarTelefonosPersonal(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), intIdPersonal, ref strMsgUsuario).ToList();
                    proxyOrg.Close();
                }
                var jsonResult = Json(Listar, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
            }

            result.type = "errorInt";
            result.message = "Ocurrió un inconveniente al listar";
            return Json(result);
        }

        public ActionResult GetCoordenadasPersonal(int intIdPersonal)
        {
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";

            try
            {
                List<TGPERCOOR> Listar = new List<TGPERCOOR>();
                PersonalSrvClient proxyOrg;
                using (proxyOrg = new PersonalSrvClient())
                {
                    Listar = proxyOrg.listarCoordenadas(intIdPersonal, ref strMsgUsuario).ToList();
                    proxyOrg.Close();
                }
                var jsonResult = Json(Listar, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
            }

            result.type = "errorInt";
            result.message = "Ocurrió un inconveniente al listar";
            return Json(result);
        }

        public ActionResult GetResponsablesPersonal(int intIdMenu, int intIdPersonal)
        {
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";

            try
            {
                List<TGPERRESPDET> Listar = new List<TGPERRESPDET>();
                PersonalSrvClient proxyOrg;
                using (proxyOrg = new PersonalSrvClient())
                {
                    Listar = proxyOrg.ListarResponsabilidadPersonal(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), intIdPersonal, ref strMsgUsuario).ToList();
                    proxyOrg.Close();
                }
                var jsonResult = Json(Listar, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
            }

            result.type = "errorInt";
            result.message = "Ocurrió un inconveniente al listar";
            return Json(result);
        }

        public JsonResult ListaAsusencias(int intIdPersonal, string fechaInicio, string fechaFin)
        {
            string strMsgUsuario = "";
            List<TGPER_CON_DET> lista_AS = new List<TGPER_CON_DET>();
            try
            {
                using (proxyOrg = new PersonalSrvClient())
                {
                    lista_AS = proxyOrg.ListaAsusencias(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), intIdPersonal, fechaInicio, fechaFin, ref strMsgUsuario).ToList();

                    proxyOrg.Close();
                }
                return Json(lista_AS);
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
            }

            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        }

        public JsonResult ListaPersonalAsistencia(int intIdPersonal, string fechaInicio, string fechaFin)
        {
            string strMsgUsuario = "";
            List<TGPER_CON_DET> lista_AS = new List<TGPER_CON_DET>();

            try
            {
                using (proxyOrg = new PersonalSrvClient())
                {
                    lista_AS = proxyOrg.ListaAsistencias(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), intIdPersonal, fechaInicio, fechaFin, ref strMsgUsuario).ToList();
                    proxyOrg.Close();
                }
                return Json(lista_AS);

            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
            }

            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        }

        public JsonResult ListaPersonalResponsabilidad(int intIdPersonal, string fechaInicio, string fechaFin)
        {
            string strMsgUsuario = "";
            List<TGPER_RESP> lista_RE = new List<TGPER_RESP>();

            try
            {
                using (proxyOrg = new PersonalSrvClient())
                {
                    lista_RE = proxyOrg.ListaPersonalResponsabilidad(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), intIdPersonal, fechaInicio, fechaFin, ref strMsgUsuario).ToList();
                    proxyOrg.Close();
                }
                return Json(lista_RE);
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
            }

            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        }

        public JsonResult ListarCombos(string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo)
        {
            string strMsgUsuario = "";
            List<TGTipoEN> lista_UM = new List<TGTipoEN>();

            try
            {
                using (proxyOrg = new PersonalSrvClient())
                {
                    lista_UM = proxyOrg.ListarCombos(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), strEntidad, intIdFiltroGrupo, strGrupo, strSubGrupo, ref strMsgUsuario).ToList();
                    proxyOrg.Close();
                }
                return Json(lista_UM);

            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
            }

            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        }

        public JsonResult ListarComboJerar(string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo)
        {
            string strMsgUsuario = "";
            List<TGTipoEN> lista_UM = new List<TGTipoEN>();
            try
            {
                using (proxyOrg = new PersonalSrvClient())
                {
                    lista_UM = proxyOrg.ListarComboJerar(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), strEntidad, intIdFiltroGrupo, strGrupo, strSubGrupo, ref strMsgUsuario).ToList();

                    proxyOrg.Close();
                }
                return Json(lista_UM);
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
            }

            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);

        }

        public JsonResult Upload()
        {
            string dir = null;

            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i]; //Cargar Imagen


                int fileSize = file.ContentLength;
                string fileName = file.FileName;
                string mimeType = file.ContentType;
                System.IO.Stream fileContent = file.InputStream;

                var request = System.Web.HttpContext.Current.Request;

                var baseUrl = request.Url.Scheme + "://" + request.Url.Authority;


                dir = Server.MapPath("~/") + "DirEmpleadosRuta\\" + fileName;
                baseUrl = "/DirEmpleadosRuta/" + fileName;
                file.SaveAs(dir);
                return Json(baseUrl);



            }
            return Json(dir);
        }

        public JsonResult ObtenerRegistroEmpleado(int intIdPersonal)
        {
            string strMsgUsuario = "";
            List<Personal> detConcepto = new List<Personal>();

            try
            {
                using (proxyOrg = new PersonalSrvClient())
                {
                    detConcepto = proxyOrg.ObtenerEmpleadoPorsuPK(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), intIdPersonal, ref strMsgUsuario).ToList();
                }
                return Json(detConcepto);
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
            }

            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        }

        public JsonResult ValidarDocIdentidad(int intIdTipDoc, string strNumDoc)
        {

            string strMsgUsuario = "";
            int validaRegistro = 3;
            string strUserNameInput = "";
            string strMensajeError = "";
            object dataResponse = null;

            CustomResponse result = new CustomResponse();
            List<ValidarIdentidad_ENT> litado = new List<ValidarIdentidad_ENT>();

            try
            {

                using (proxy = new PersonalSrvClient())
                {
                    litado = proxy.ValidarDocIdentidad(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), intIdTipDoc, strNumDoc, ref strMsgUsuario).ToList();
                }

                if (litado.Count() > 0)
                {
                    strMensajeError = litado[0].strObservacion;
                    validaRegistro = litado[0].intExiste;
                    dataResponse = litado[0];
                }

                if (strMsgUsuario.Equals("") && validaRegistro == 2)
                {
                    return Json(litado);
                }
                else if (strMsgUsuario.Equals("") && validaRegistro == 1)
                {
                    return Json(litado);
                }
                else if (strMsgUsuario.Equals("") && validaRegistro == 0)
                {
                    result.type = "success";
                    result.message = strMensajeError;
                    result.objeto = dataResponse;
                }

            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
                result.type = "errorInt";
                result.message = "Ocurrió un inconveniente al registrar la Regla de Negocio";
            }

            return Json(result);
        }

        public JsonResult ListarComboGlobal(int intIdMenu, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo)
        {
            string strMsgUsuario = "";
            List<CombosGlobal> detConcepto = new List<CombosGlobal>();

            try
            {
                using (proxyOrg = new PersonalSrvClient())
                {
                    detConcepto = proxyOrg.ListarComboGeneral(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), strEntidad, intIdFiltroGrupo, strGrupo, strSubGrupo, ref strMsgUsuario).ToList();
                }
                return Json(detConcepto);
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
            }
            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        }

        //COMENTADO HG lun08.03.21  --revisar luego quien lo usa para descomentarlo tamb en el SERVICE, en IpersonalSrv.cs
        public JsonResult ListarCaracteresMax(string strMaestro)
        {
            List<MaestroCaracteres> detConcepto = new List<MaestroCaracteres>();

            try
            {
                //using (PackingTsp = new PackingSrvClient())
                using (proxyOrg = new PersonalSrvClient())
                {
                    detConcepto = proxyOrg.MaestroMaxCaracteres(strMaestro).ToList();
                    //detConcepto = PackingTsp.MaestroMaxCaracteres(strMaestro).ToList();
                }
                return Json(detConcepto);
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
            }
            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        }

        //COMENTADO hg_martes_09.02.21
        public JsonResult ListarCombosPersonal7(int intIdMenu, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo)
        {
            string strMsgUsuario = "";
            List<TGTipoEN> lista_Tipo = new List<TGTipoEN>();

            try
            {
                using (proxyOrg = new PersonalSrvClient())
                {
                    lista_Tipo = proxyOrg.ListarCombos(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), strEntidad, intIdFiltroGrupo, strGrupo, strSubGrupo, ref strMsgUsuario).ToList();
                    proxyOrg.Close();
                }
                return Json(lista_Tipo);
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
            }
            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        }

        public JsonResult ListarCamposAdicionales(int intIdMenu, string strNoEntidad)
        {
            string strMsgUsuario = "";
            List<CamposAdicionalesGlobal> lista = new List<CamposAdicionalesGlobal>();

            try
            {
                using (proxyOrg = new PersonalSrvClient())
                {
                    lista = proxyOrg.ListarCamposAdicionales(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), strNoEntidad, ref strMsgUsuario).ToList();
                    proxyOrg.Close();
                }
                return Json(lista);
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
            }
            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        }

        public JsonResult EliminarEmpleado(int intIdMenu, int intIdPersonal)
        {

            CustomResponse result = new CustomResponse();

            string strMsgUsuario = "";
            try
            {
                int intIdUsuario = 1;
                bool boolEstado = false;


                using (proxy = new PersonalSrvClient())
                {
                    boolEstado = proxy.EliminarEmpleado(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), intIdUsuario, intIdPersonal, ref strMsgUsuario);
                    proxy.Close();
                }

                if (strMsgUsuario.Equals("") && boolEstado)
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
                Log.AlmacenarLogError(ex, "PersonalController.cs");
                result.type = "error";
                result.message = "Ocurrió un inconveniente al eliminar el registro";
            }

            return Json(result);
        }

        public JsonResult ActualizarPerfilEmpleado(int intIdMenu, Personal ObjPersonal, List<TGPERCORRDET> listaDetallesPersonalCorreos, List<TGPERTELEFDET> listaDetallesPersonalTelefonos)
        {
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";

            int intIdUsuario = 1;
            int intIdUsuarModif = 0;

            if (listaDetallesPersonalCorreos == null)
                listaDetallesPersonalCorreos = new List<TGPERCORRDET>();
            if (listaDetallesPersonalTelefonos == null)
                listaDetallesPersonalTelefonos = new List<TGPERTELEFDET>();

            try
            {
                bool insert = false;

                using (proxyOrg = new PersonalSrvClient())
                {
                    insert = proxyOrg.ActualizarEmpleado(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), ObjPersonal, listaDetallesPersonalCorreos.ToArray(), listaDetallesPersonalTelefonos.ToArray(), intIdUsuario, intIdUsuarModif, ref strMsgUsuario);
                    proxyOrg.Close();
                }

                if (strMsgUsuario.Equals("") && insert)
                {
                    result.type = "success";
                    result.message = "El registro se actualizó correctamente.";

                }
                else
                {
                    if (strMsgUsuario.Contains("admisión") && strMsgUsuario.Contains("cese"))
                    {
                        result.type = "infoc";
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
                Log.AlmacenarLogError(ex, "PersonalController.cs");
                result.type = "errorInt";
                result.message = "Ocurrió un inconveniente al actualizar la Variable";
            }

            return Json(result);

        }

        public JsonResult RegistrarNuevoEmpleado(int intIdMenu, Personal ObjPersonal, MarcaDni ObjMarcaConDni, List<TGPERCORRDET> listaDetallesPersonalCorreos, List<TGPERTELEFDET> listaDetallesPersonalTelefonos,
            List<TGPERRESPDET> listaDetallesPersonalResponsabilidad, List<TGPERMARCDET> listaDetallesPersonalMarcadores, List<TGPERCOOR> listaCoor,
            bool activaUsuario, bool desactivaUsuario, bool activarAdmin, int intTipoOperacion)
        {
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";

            int intIdUsuario = 1;
            int intIdUsuarModif = 0;

            if (listaDetallesPersonalCorreos == null)
                listaDetallesPersonalCorreos = new List<TGPERCORRDET>();
            if (listaDetallesPersonalTelefonos == null)
                listaDetallesPersonalTelefonos = new List<TGPERTELEFDET>();
            if (listaDetallesPersonalResponsabilidad == null)
                listaDetallesPersonalResponsabilidad = new List<TGPERRESPDET>();
            if (listaDetallesPersonalMarcadores == null)
                listaDetallesPersonalMarcadores = new List<TGPERMARCDET>();
            if (listaCoor == null)
            {
                listaCoor = new List<TGPERCOOR>();
            }
            try
            {
                bool insert = false;

                using (proxyOrg = new PersonalSrvClient())
                {
                    insert = proxyOrg.RegistrarOActualizarEmpleado(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), ObjPersonal, ObjMarcaConDni, listaDetallesPersonalCorreos.ToArray(), listaDetallesPersonalTelefonos.ToArray(),
                        listaDetallesPersonalResponsabilidad.ToArray(), listaDetallesPersonalMarcadores.ToArray(), listaCoor.ToArray(), intIdUsuario, intIdUsuarModif, activaUsuario, desactivaUsuario, activarAdmin, intTipoOperacion, ref strMsgUsuario);
                    proxyOrg.Close();
                }

                if (insert)
                {
                    if (intTipoOperacion == 1)
                    {
                        result.type = "success";
                        result.message = "El registro se insertó satisfactoriamente.";
                    }
                    else
                    {
                        result.type = "success";
                        result.message = "El registro se actualizó correctamente.";
                    }
                    result.extramsg = strMsgUsuario;
                }
                else
                {
                    if (strMsgUsuario.Contains("admisión") && strMsgUsuario.Contains("cese"))
                    {
                        result.type = "infoc";
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
                Log.AlmacenarLogError(ex, "PersonalController.cs");
                result.type = "errorInt";
                result.message = "Ocurrió un inconveniente al registrar la Variable";
            }

            return Json(result);
        }

        public JsonResult ReenviarCorreo(int intIdPersonal)
        {
            wsPersona.Session_Movi objSession = new wsPersona.Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();

            string strMsgUsuario = "";
            Dictionary<string, string> obj = new Dictionary<string, string>();

            try
            {
                using (proxyOrg = new PersonalSrvClient())
                {
                    obj = proxyOrg.ReenviarCorreo(objSession, intIdPersonal, ref strMsgUsuario);
                    proxyOrg.Close();
                }
                return Json(obj);
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
            }
            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        }

        public JsonResult ActivarUsuario(int intIdPersonal)
        {
            wsPersona.Session_Movi objSession = new wsPersona.Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();

            string strMsgUsuario = "";
            string mensaje = "";

            try
            {
                using (proxyOrg = new PersonalSrvClient())
                {
                    mensaje = proxyOrg.ActivarUsuario(objSession, intIdPersonal, ref strMsgUsuario);
                    proxyOrg.Close();
                }
                return Json(mensaje);
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
            }
            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        }
        */
        #endregion


        /**********************COMENTADOS
         * 
         * 
        //CODIGO NO USADO POR ACTIVOFIJO
        public ActionResult GuardarMasivoEmpleado()
        {
            wsPersona.Session_Movi objSession = new wsPersona.Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();

            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";
            try
            {
                List<EmpleadoMasivo> listEmpleado = new List<EmpleadoMasivo>();

                using (proxy = new PersonalSrvClient())
                {
                    listEmpleado = proxy.GuardarMasivoEmpleado(objSession, idProceso, nombreExcel, rutaDirectorioExcel, ref strMsgUsuario).ToList();
                    proxy.Close();
                }

                if (strMsgUsuario == "")
                {
                    result.type = "success";
                    result.message = "Los empleados fueron guardados de forma correcta";
                    result.objeto = listEmpleado;
                }
                else
                {
                    result.type = "info";
                    result.message = strMsgUsuario;
                }

            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
                result.type = "error";
                result.message = "Ocurrió un inconveniente al guardar los empleados";
            }

            return Json(result);
        }

                //List<TbBienesMov> ListarTablaTbBienesPrueba(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, string strTerminal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);


                //18.1 PRUEBA LISTADO ELIMINABLE - Probado con un boton en el mant Etiquetas 
        public JsonResult ListarTablaTbBienesPrueba()
        {

            int intResult=1;
            string strMsjDB = ""; 
            string strMsgUsuario = "";
            List<Dominio.Entidades.TbBienesMov> Listado = new List<Dominio.Entidades.TbBienesMov>();
            try
            {
                //using (proxy = new PersonalSrvClient())
                //{
                    Listado= proxy.ListarTablaTbBienesPrueba(82517, 1, 3,  3029, "", ref intResult, ref strMsjDB, ref strMsgUsuario).ToList();
                //    proxy.Close();
                //}
                ////return Json(ListarCargos);
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
            }
            var json_ = Json(Listado, JsonRequestBehavior.AllowGet);
            json_.MaxJsonLength = 500000000;
            //return Json(list);
            return json_;
            ////return Json(Listado);
            //return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);


        }



        public JsonResult GetTablaGestionConsumo(wsPersona.Session_Movi objSession, string dttFiltroFchI, string dttFiltroFchF, string strDescripcion, int intConsumido, int intTipoServ, int intTipoMenu, int IntIdEmp, int intIdMarcador)
        {
            string strMsgUsuario = "";

            List<wsPersona.Consumo> Listar = new List<wsPersona.Consumo>();
            PersonalSrvClient proxyOrg;
            using (proxyOrg = new PersonalSrvClient())
            {
                Listar = proxyOrg.ListarGestionConsumo(objSession, dttFiltroFchI, dttFiltroFchF, strDescripcion, intConsumido, intTipoServ, intTipoMenu, IntIdEmp, intIdMarcador, ref strMsgUsuario).ToList();
                proxyOrg.Close();
            }
            return Json(Listar);
        }

        #endregion

        */



        /****
//private PersonalSrvClient proxy;
//private PersonalSrvClient proxyOrg;

///////////////////////////////////////////////////////////////
public AccesoMovilBL objAccesoMovilBL = new AccesoMovilBL();
public static IList<TMPRODU_MOVIL> listaTablaTmProdu;
//////////////////////////////////////////////////////////
//PRUEBA ELIMINABLE
//////////////////////////////////////////////////////////
public ActionResult ListarTablaTmProduPrueba()
{
    Session_Movi objSession = new Session_Movi();
    objSession.intIdSesion = Auth.intIdSesion();
    objSession.intIdSoft = Auth.intIdSoft();
    objSession.intIdMenu = intIdMenuGlo;
    objSession.intIdUsuario = Auth.intIdUsuario();
    string strMsjUsuario = "";
    int intResult = 0;
    string strMsjDB = "";
    int resultado = 0;

    try
    {

        listaTablaTmProdu = objAccesoMovilBL.ListarTablaTmProdu(1, 5, 6, 916, "1", ref intResult, ref strMsjDB, ref strMsjUsuario);
            //(objSession, strArchivoExportado, ref strMsgUsuario).ToList();
            //resultado = listaTMPRODU.Count;


    }
    catch (Exception ex)
    {
        Log.AlmacenarLogError(ex, "PersonalController.cs");
    }

    return Json(resultado);

}


        //////////////////////////////////////////////////////////
//PRUEBA ELIMINABLE POST
//////////////////////////////////////////////////////////


$('#btn-prueba-eliminable').on('click', function () {


$.post(
'/Personal/ListarTablaTmProduPrueba',
{
    //sinparametros
},
response => {             
    alert('respuesta exitosa del metodo "ListarTablaTmProduPrueba"');
});

});

*****/




        //////////////////////////////////////////////////////HGM_AÑADIDO_19.08.2021_15:51:08 





        public static byte[] dtBienes;
        public static byte[] dtBienesDs;
        public static byte[] dtOficina;
        public static byte[] dtEmpleado;
        public static byte[] dtLocal;
        public static byte[] dtAreas;
        public static byte[] dtEstado;
        public static byte[] dtTipo;
        public static byte[] dtEntidad;


        public static string txtBienes;
        public static string txtBienesDs;
        public static string txtEmpleado;
        public static string txtOficina;



        //public ImportarExcelBL objImportarExcelBL = new ImportarExcelBL();




        //16.6 //ESTA SIENDO CAMBIADO POR OTRO GENRAL PARA ESCEL Y TXT
        public JsonResult EnviarCuatroExcelsPorCorreo2(string strEmailDestino, string idRadioCheck)
        {
            //OBTENER LA RUTA 
            string strRutaDir = "";
            strRutaDir = ConfigurationManager.AppSettings["rutaGenerarExcelToEmail"];
            string rutaDeExcelsToEmail = Path.Combine(HttpContext.Request.MapPath(strRutaDir));
            //OBJETO SESSION
            Dominio.Entidades.Session_Movi objSession = new Dominio.Entidades.Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();

            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";
            Dictionary<string, string> obj = new Dictionary<string, string>();

            /*msg.Attachments.Add(new Attachment(@"C:\temp\myreport.log"));*/

            try
            {
                //using (proxyRep = new ReportesSrvClient())
                //{
                obj = objImportarExcelBL.ToEmailEnviarExcelPorCorreo2(objSession, strEmailDestino, rutaDeExcelsToEmail
                                                          , dtBienes, dtBienesDs, dtOficina, dtEmpleado, dtLocal
                                                          , dtAreas, dtEstado, dtTipo, dtEntidad
                                                          , txtBienes
                                                          , txtBienesDs
                                                          , txtOficina
                                                          , txtEmpleado
                                                          , idRadioCheck
                                                          , ref strMsgUsuario); //HGM1

                //    proxyRep.Close();

                //}

                if (strMsgUsuario.Contains("Se envió el correo con credenciales."))
                {

                    if (idRadioCheck == "chck_excel2")
                    {
                        result.type = "success";
                        result.message = "El envío del Comprobante de Venta ha sido procesado exitosamente.";
                    }
                    if (idRadioCheck == "chck_excel")
                    {
                        result.type = "success";
                        result.message = "El envío del Comprobante procesado exitosamente.";
                    }
                    else if (idRadioCheck == "chck_excel")
                    {
                        result.type = "success";
                        result.message = "El envío del Comprobante  ha sido procesado exitosamente.";
                    }
                    else
                    {
                        result.type = "success";
                        result.message = "El envío del Comprobante procesado exitosamente.";
                    }

                }

                else
                {
                    result.type = "info";
                    result.message = "Ocurrió un error al enviar el correo"; //"Ocurrio un error al procesar envío";

                }

                return Json(result);

            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PersonalController.cs");
            }
            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        }







    }
}
