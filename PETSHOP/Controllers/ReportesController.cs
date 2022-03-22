using CBX_Web_PetShopWeb.swReportes;
using CBX_Web_PetShopWeb.wsOrganizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TGTipoEN = CBX_Web_PetShopWeb.swReportes.TGTipoEN;
using Planilla = CBX_Web_PetShopWeb.swReportes.Planilla;
using System.Data;
using System.Reflection;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Net;
using System.Configuration;
using CBX_Web_PetShopWeb.Models;









///////////////////////////////////DE LAS CARPETAS DEL SERVICE
//////using Dominio.Repositorio;
//////using Dominio.Entidades;


namespace CBX_Web_PetShopWeb.Controllers
{
    public class ReportesController : Controller
    {

        private OrganizacionSrvClient proxyOrg;
        private ReportesSrvClient proxyRep;
        public static int intIdMenuGlo { get; set; }
        public static List<int> listEmpleados;
        public static List<int> listConceptos;
        public static int cantEnListaExcels { get; set; }


        //[HttpPost]
        ////[System.Web.Services.WebMethod]
        //public static void SaveImage(string base64image)
        //{
        //    if (string.IsNullOrEmpty(base64image))
        //        return;

        //    var t = base64image.Substring(22);  // remove data:image/png;base64,

        //    byte[] bytes = Convert.FromBase64String(t);

        //    System.Drawing.Image image;
        //    using (MemoryStream ms = new MemoryStream(bytes))
        //    {
        //        image = System.Drawing.Image.FromStream(ms);
        //    }
        //    var randomFileName = Guid.NewGuid().ToString().Substring(0, 4) + ".png";
        //    //var fullPath = Path.Combine(Server.MapPath("~/Content/img/"), randomFileName);
        //    //image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);
        //}


        public JsonResult SaveImage(string base64image, string imagenDashboardHead)
        {
            CustomResponse result = new CustomResponse();
            //string strMsgUsuario = "";
            //if (string.IsNullOrEmpty(base64image)) { 
            //    return;
            //}
            var t = base64image.Substring(22);  // remove data:image/png;base64,
            byte[] bytes = Convert.FromBase64String(t);

            System.Drawing.Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = System.Drawing.Image.FromStream(ms);
            }
            var randomFileName = Guid.NewGuid().ToString().Substring(0, 4) + ".png";

            var fullPath = Path.Combine(Server.MapPath("~/Content/img/"), imagenDashboardHead);
            image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);

            //Devolver la Ruta
            result.message = fullPath; 

            return Json(fullPath);
        }


        /*****
        //14.5 CREAR LA CARPETA "FORMATOS" Y TRES ARCHIVOS DE TEXTO DENTRO
        public JsonResult GuardarImagenTemporalmente()//getRutaDirImpotraExcel()  //GetRutaFormatos
        {
            CustomResponse result = new CustomResponse();
            string strRutaDir = "";
            string rutaDirFormatos = "";
            string strRutaDirWebConfig = "rutaImages";

            //if (strRutaDir!="") { 
            //Devuelve la CARPETA IMAGES
            strRutaDir = ConfigurationManager.AppSettings[strRutaDirWebConfig];
            //}

            if (!String.IsNullOrEmpty(strRutaDir))//strRutaDir != "" && 
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
                result.message = "La ruta '" + strRutaDirWebConfig + "' donde debe generarse \n la carpeta 'formatos' no existe o ha sido modificada.";
                result.type = "info";

            }

            return Json(result);
        }
        *******************/

        //////////////14.5 CREAR LA CARPETA FORMATOS Y TRES ARCHIVOS DE TEXTO DENTRO
        ////////////public string GuardarImagenTemporalmente()//getRutaDirImpotraExcel()  GetRutaFormatos
        ////////////{
        ////////////    string strRutaDir = "";
        ////////////    if (strRutaDir !="") {
        ////////////        strRutaDir = ConfigurationManager.AppSettings[rutaFormatos];
        ////////////    }
        ////////////    string rutaDirFormatos = Path.Combine(HttpContext.Request.MapPath(strRutaDir));

        ////////////    //Genera la ruta en una variable
        ////////////    string folderPath = rutaDirFormatos;//@DMyFolder
        ////////////    if (!Directory.Exists(folderPath))
        ////////////    {
        ////////////        //Crea la carpeta
        ////////////        Directory.CreateDirectory(folderPath);       
        ////////////        Console.WriteLine(folderPath);

        ////////////        FileStream f1 = System.IO.File.Create(rutaDirFormatos + "Formato1.txt");
        ////////////        FileStream f2 = System.IO.File.Create(rutaDirFormatos + "Formato2.txt");
        ////////////        FileStream f3 = System.IO.File.Create(rutaDirFormatos + "Formato3.txt");

        ////////////        f1.Close();
        ////////////        f2.Close();
        ////////////        f3.Close();

        ////////////    }
        ////////////    //Devuelve la ruta de esa carpeta creada(la ruta de la carpeta formatos)
        ////////////    return
        ////////////} 


        //20.1 OBTENER LA RUTA DE "FORMATOS"  ---> Aun no hay nada en el js
        //public string CrearCarpetaFormatos()//getRutaDirImpotraExcel()  //GetRutaFormatos
        //{
        //    string strRutaDir = "";
        //    //if (strRutaDir!="") { 
        //    strRutaDir = ConfigurationManager.AppSettings["rutaFormatos"];
        //    //}
        //    string rutaDirFormatos = Path.Combine(HttpContext.Request.MapPath(strRutaDir));

        //    //Genera la ruta en una variable
        //    string folderPath = rutaDirFormatos;//@"D:\MyFolder"
        //    if (!Directory.Exists(folderPath))
        //    {
        //        //Crea la carpeta
        //        Directory.CreateDirectory(folderPath);
        //        Console.WriteLine(folderPath);

        //    }
        //    //Devuelve la ruta de esa carpeta creada
        //    return rutaDirFormatos;
        //}






        //TAMBIEN REVISAR: https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.createdirectory?view=net-5.0

        ////////00.1 PRUEBA
        //////public JsonResult descargarExcelSinWinOpen()
        //////{

        //////    int intResult = 1;
        //////    //string strMsjDB = "";

        //////   return Json(intResult);


        //////}


        //IWebDriver driver = new PhantomJSDriver();
        //driver.Navigate().GoToUrl("http://www.google.com");
        //((ITakesScreenshot) driver).GetScreenshot().SaveAsFile("image.png", ImageFormat.Png);

        #region ENVIAR EXCELS A CORREOS - Mant. Configuracion - SISACTIVOFIJO

        //16.5.1
        public static IList<TablasGenerarExcel> ToEmailListaBienes;
        //16.5.2
        public static IList<TablasGenerarExcel> ToEmailListaOficina;
        //16.5.3
        public static IList<TablasGenerarExcel> ToEmailListaEmpleado;
        //16.5.4
        public static IList<TablasGenerarExcel> ToEmailListaLocal;
        //16.5.5
        public static IList<TablasGenerarExcel> ToEmailListaAreas;
        //16.5.6
        public static IList<TablasGenerarExcel> ToEmailListaEstado;
        //16.5.7
        public static IList<TablasGenerarExcel> ToEmailListaTipo;
        //16.5.8
        public static IList<TablasGenerarExcel> ToEmailListaEntidad;
        //16.5.9
        public static IList<TablasGenerarExcel> ToEmailListaBienesDs;

        public static byte[] dtBienes;
        public static byte[] dtBienesDs;
        public static byte[] dtOficina;
        public static byte[] dtEmpleado;
        public static byte[] dtLocal;
        public static byte[] dtAreas; 
        public static byte[] dtEstado;
        public static byte[] dtTipo;
        public static byte[] dtEntidad;

        //16.2 
        public void GenerarBytesExcelParaEnviarPorCorreo(string strExcelExportado)
        {
           
            string strRutaDir = "";
            strRutaDir = ConfigurationManager.AppSettings["rutaGenerarExcelToEmail"];
            string rutaDirPath = Path.Combine(HttpContext.Request.MapPath(strRutaDir));

            if (strExcelExportado == "TBBIENES")
            {
                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("Activo");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("Descripción");
                r1.Append(c2);

                Cell c3 = new Cell();
                c3.DataType = CellValues.String;
                c3.CellValue = new CellValue("Anterior");
                r1.Append(c3);

                Cell c4 = new Cell();
                c4.DataType = CellValues.String;
                c4.CellValue = new CellValue("CodLocal");
                r1.Append(c4);

                Cell c5 = new Cell();
                c5.DataType = CellValues.String;
                c5.CellValue = new CellValue("CodArea");
                r1.Append(c5);

                Cell c6 = new Cell();
                c6.DataType = CellValues.String;
                c6.CellValue = new CellValue("CodOficina");
                r1.Append(c6);

                Cell c7 = new Cell();
                c7.DataType = CellValues.String;
                c7.CellValue = new CellValue("CodEmpleado");
                r1.Append(c7);

                Cell c8 = new Cell();
                c8.DataType = CellValues.String;
                c8.CellValue = new CellValue("CodEstado");
                r1.Append(c8);

                Cell c9 = new Cell();
                c9.DataType = CellValues.String;
                c9.CellValue = new CellValue("Marca");
                r1.Append(c9);

                Cell c10 = new Cell();
                c10.DataType = CellValues.String;
                c10.CellValue = new CellValue("Modelo");
                r1.Append(c10);

                Cell c11 = new Cell();
                c11.DataType = CellValues.String;
                c11.CellValue = new CellValue("Serie");
                r1.Append(c11);

                Cell c12 = new Cell();
                c12.DataType = CellValues.String;
                c12.CellValue = new CellValue("CodTipo");
                r1.Append(c12);

                Cell c13 = new Cell();
                c13.DataType = CellValues.String;
                c13.CellValue = new CellValue("Color");
                r1.Append(c13);

                Cell c14 = new Cell();
                c14.DataType = CellValues.String;
                c14.CellValue = new CellValue("Año");
                r1.Append(c14);

                Cell c15 = new Cell();
                c15.DataType = CellValues.String;
                c15.CellValue = new CellValue("NumMotor");
                r1.Append(c15);

                Cell c16 = new Cell();
                c16.DataType = CellValues.String;
                c16.CellValue = new CellValue("NumChasis");
                r1.Append(c16);

                Cell c17 = new Cell();
                c17.DataType = CellValues.String;
                c17.CellValue = new CellValue("Dimensión");
                r1.Append(c17);

                Cell c18 = new Cell();
                c18.DataType = CellValues.String;
                c18.CellValue = new CellValue("Placa");
                r1.Append(c18);

                Cell c19 = new Cell();
                c19.DataType = CellValues.String;
                c19.CellValue = new CellValue("Observación");
                r1.Append(c19);

                Cell c20 = new Cell();
                c20.DataType = CellValues.String;
                c20.CellValue = new CellValue("FecCreación");
                r1.Append(c20);

                Cell c21 = new Cell();
                c21.DataType = CellValues.String;
                c21.CellValue = new CellValue("FecModificación");
                r1.Append(c21);

                Cell c22 = new Cell();
                c22.DataType = CellValues.String;
                c22.CellValue = new CellValue("NumPda");
                r1.Append(c22);

                Cell c23 = new Cell();
                c23.DataType = CellValues.String;
                c23.CellValue = new CellValue("FlgInventario");
                r1.Append(c23);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasGenerarExcel item in ToEmailListaBienes)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.Activo);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.Descripcion);
                    r2.Append(cc2);

                    Cell cc3 = new Cell();
                    cc3.DataType = CellValues.String;
                    cc3.CellValue = new CellValue(item.Anterior);
                    r2.Append(cc3);

                    Cell cc4 = new Cell();
                    cc4.DataType = CellValues.String;
                    cc4.CellValue = new CellValue(item.CodLocal);
                    r2.Append(cc4);

                    Cell cc5 = new Cell();
                    cc5.DataType = CellValues.String;
                    cc5.CellValue = new CellValue(item.CodArea);
                    r2.Append(cc5);

                    Cell cc6 = new Cell();
                    cc6.DataType = CellValues.String;
                    cc6.CellValue = new CellValue(item.CodOficina);//ubicacion
                    r2.Append(cc6);

                    Cell cc7 = new Cell();
                    cc7.DataType = CellValues.String;
                    cc7.CellValue = new CellValue(item.CodResponsable);
                    r2.Append(cc7);

                    Cell cc8 = new Cell();
                    cc8.DataType = CellValues.String;
                    cc8.CellValue = new CellValue(item.CodEstado);
                    r2.Append(cc8);

                    Cell cc9 = new Cell();
                    cc9.DataType = CellValues.String;
                    cc9.CellValue = new CellValue(item.Marca);
                    r2.Append(cc9);


                    Cell cc10 = new Cell();
                    cc10.DataType = CellValues.String;
                    cc10.CellValue = new CellValue(item.Modelo);
                    r2.Append(cc10);

                    Cell cc11 = new Cell();
                    cc11.DataType = CellValues.String;
                    cc11.CellValue = new CellValue(item.Serie);
                    r2.Append(cc11);

                    Cell cc12 = new Cell();
                    cc12.DataType = CellValues.String;
                    cc12.CellValue = new CellValue(item.CodTipo);
                    r2.Append(cc12);

                    Cell cc13 = new Cell();
                    cc13.DataType = CellValues.String;
                    cc13.CellValue = new CellValue(item.Color);
                    r2.Append(cc13);

                    Cell cc14 = new Cell();
                    cc14.DataType = CellValues.String;
                    cc14.CellValue = new CellValue(item.Anio.ToString());
                    r2.Append(cc14);

                    Cell ccc15 = new Cell();
                    ccc15.DataType = CellValues.String;
                    ccc15.CellValue = new CellValue(item.NumMotor);
                    r2.Append(ccc15);

                    Cell ccc16 = new Cell();
                    ccc16.DataType = CellValues.String;
                    ccc16.CellValue = new CellValue(item.NumChasis);
                    r2.Append(ccc16);

                    Cell ccc17 = new Cell();
                    ccc17.DataType = CellValues.String;
                    ccc17.CellValue = new CellValue(item.Dimension);
                    r2.Append(ccc17);

                    Cell ccc18 = new Cell();
                    ccc18.DataType = CellValues.String;
                    ccc18.CellValue = new CellValue(item.Placa);
                    r2.Append(ccc18);

                    Cell ccc19 = new Cell();
                    ccc19.DataType = CellValues.String;
                    ccc19.CellValue = new CellValue(item.Observacion);
                    r2.Append(ccc19);

                    Cell ccc20 = new Cell();
                    ccc20.DataType = CellValues.String;
                    ccc20.CellValue = new CellValue(item.FecCreacion);
                    r2.Append(ccc20);

                    Cell ccc21 = new Cell();
                    ccc21.DataType = CellValues.String;
                    ccc21.CellValue = new CellValue(item.FecModificacion);
                    r2.Append(ccc21);

                    Cell ccc22 = new Cell();
                    ccc22.DataType = CellValues.String;
                    ccc22.CellValue = new CellValue(item.NumPda);
                    r2.Append(ccc22);

                    Cell ccc23 = new Cell();
                    ccc23.DataType = CellValues.String;
                    ccc23.CellValue = new CellValue(item.FlgInventario);
                    r2.Append(ccc23);

                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////

                ws.Append(sd);
                //ws2.Append(sd2);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBBIENES";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                //Sheet sheet2 = new Sheet();
                //sheet2.Name = "TBBIENES";
                //sheet2.SheetId = 2;
                //sheet2.Id = wbp.GetIdOfPart(wsp2);
                sheets.Append(sheet);
                //sheets.Append(sheet2);
                wb.Append(fv);
                wb.Append(sheets);

                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();
                //string fileName = "TBBIENES.xlsx";
                Response.Clear();
                byte[] dt = ms.ToArray();
                /*
                //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                //----------------------------------------------
                //var path = @"D:\ExcelsToEmail\TBBIENES.xlsx";
                var path = @"" + rutaDirPath + "TBBIENES.xlsx";                
                System.IO.File.WriteAllBytes(path, dt);
                //----------------------------------------------
                Response.BinaryWrite(dt);
                Response.End();
                */                
                dtBienes = dt; 
                

            }

            if (strExcelExportado == "TBBIENESDS")
            {
                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("Activo");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("Descripción");
                r1.Append(c2);

                Cell c3 = new Cell();
                c3.DataType = CellValues.String;
                c3.CellValue = new CellValue("Anterior");
                r1.Append(c3);

                Cell c4 = new Cell();
                c4.DataType = CellValues.String;
                c4.CellValue = new CellValue("CodLocal");
                r1.Append(c4);

                Cell c5 = new Cell();
                c5.DataType = CellValues.String;
                c5.CellValue = new CellValue("CodArea");
                r1.Append(c5);

                Cell c6 = new Cell();
                c6.DataType = CellValues.String;
                c6.CellValue = new CellValue("CodOficina");
                r1.Append(c6);

                Cell c7 = new Cell();
                c7.DataType = CellValues.String;
                c7.CellValue = new CellValue("CodEmpleado");
                r1.Append(c7);

                Cell c8 = new Cell();
                c8.DataType = CellValues.String;
                c8.CellValue = new CellValue("CodEstado");
                r1.Append(c8);

                Cell c9 = new Cell();
                c9.DataType = CellValues.String;
                c9.CellValue = new CellValue("Marca");
                r1.Append(c9);

                Cell c10 = new Cell();
                c10.DataType = CellValues.String;
                c10.CellValue = new CellValue("Modelo");
                r1.Append(c10);

                Cell c11 = new Cell();
                c11.DataType = CellValues.String;
                c11.CellValue = new CellValue("Serie");
                r1.Append(c11);

                Cell c12 = new Cell();
                c12.DataType = CellValues.String;
                c12.CellValue = new CellValue("CodTipo");
                r1.Append(c12);

                Cell c13 = new Cell();
                c13.DataType = CellValues.String;
                c13.CellValue = new CellValue("Color");
                r1.Append(c13);

                Cell c14 = new Cell();
                c14.DataType = CellValues.String;
                c14.CellValue = new CellValue("Año");
                r1.Append(c14);

                Cell c15 = new Cell();
                c15.DataType = CellValues.String;
                c15.CellValue = new CellValue("NumMotor");
                r1.Append(c15);

                Cell c16 = new Cell();
                c16.DataType = CellValues.String;
                c16.CellValue = new CellValue("NumChasis");
                r1.Append(c16);

                Cell c17 = new Cell();
                c17.DataType = CellValues.String;
                c17.CellValue = new CellValue("Dimensión");
                r1.Append(c17);

                Cell c18 = new Cell();
                c18.DataType = CellValues.String;
                c18.CellValue = new CellValue("Placa");
                r1.Append(c18);

                Cell c19 = new Cell();
                c19.DataType = CellValues.String;
                c19.CellValue = new CellValue("Observación");
                r1.Append(c19);

                Cell c20 = new Cell();
                c20.DataType = CellValues.String;
                c20.CellValue = new CellValue("DesLocal");
                r1.Append(c20);

                Cell c21 = new Cell();
                c21.DataType = CellValues.String;
                c21.CellValue = new CellValue("DesArea");
                r1.Append(c21);

                Cell c22 = new Cell();
                c22.DataType = CellValues.String;
                c22.CellValue = new CellValue("DesOficina");
                r1.Append(c22);

                Cell c23 = new Cell();
                c23.DataType = CellValues.String;
                c23.CellValue = new CellValue("DesEmpleado");
                r1.Append(c23);

                Cell c24 = new Cell();
                c24.DataType = CellValues.String;
                c24.CellValue = new CellValue("DesEstado");
                r1.Append(c24);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasGenerarExcel item in ToEmailListaBienesDs)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.Activo);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.Descripcion);
                    r2.Append(cc2);

                    Cell cc3 = new Cell();
                    cc3.DataType = CellValues.String;
                    cc3.CellValue = new CellValue(item.Anterior);
                    r2.Append(cc3);

                    Cell cc4 = new Cell();
                    cc4.DataType = CellValues.String;
                    cc4.CellValue = new CellValue(item.CodLocal);
                    r2.Append(cc4);

                    Cell cc5 = new Cell();
                    cc5.DataType = CellValues.String;
                    cc5.CellValue = new CellValue(item.CodArea);
                    r2.Append(cc5);

                    Cell cc6 = new Cell();
                    cc6.DataType = CellValues.String;
                    cc6.CellValue = new CellValue(item.CodOficina);//ubicacion----
                    r2.Append(cc6);

                    Cell cc7 = new Cell();
                    cc7.DataType = CellValues.String;
                    cc7.CellValue = new CellValue(item.CodResponsable);
                    r2.Append(cc7);

                    Cell cc8 = new Cell();
                    cc8.DataType = CellValues.String;
                    cc8.CellValue = new CellValue(item.CodEstado);
                    r2.Append(cc8);

                    Cell cc9 = new Cell();
                    cc9.DataType = CellValues.String;
                    cc9.CellValue = new CellValue(item.Marca);
                    r2.Append(cc9);


                    Cell cc10 = new Cell();
                    cc10.DataType = CellValues.String;
                    cc10.CellValue = new CellValue(item.Modelo);//--10
                    r2.Append(cc10);

                    Cell cc11 = new Cell();
                    cc11.DataType = CellValues.String;
                    cc11.CellValue = new CellValue(item.Serie);
                    r2.Append(cc11);

                    Cell cc12 = new Cell();
                    cc12.DataType = CellValues.String;
                    cc12.CellValue = new CellValue(item.CodTipo);
                    r2.Append(cc12);

                    Cell cc13 = new Cell();
                    cc13.DataType = CellValues.String;
                    cc13.CellValue = new CellValue(item.Color);
                    r2.Append(cc13);

                    Cell cc14 = new Cell();
                    cc14.DataType = CellValues.String;
                    cc14.CellValue = new CellValue(item.Anio.ToString());
                    r2.Append(cc14);

                    Cell ccc15 = new Cell();
                    ccc15.DataType = CellValues.String;
                    ccc15.CellValue = new CellValue(item.NumMotor);//--15
                    r2.Append(ccc15);

                    Cell ccc16 = new Cell();
                    ccc16.DataType = CellValues.String;
                    ccc16.CellValue = new CellValue(item.NumChasis);
                    r2.Append(ccc16);

                    Cell ccc17 = new Cell();
                    ccc17.DataType = CellValues.String;
                    ccc17.CellValue = new CellValue(item.Dimension);
                    r2.Append(ccc17);

                    Cell ccc18 = new Cell();
                    ccc18.DataType = CellValues.String;
                    ccc18.CellValue = new CellValue(item.Placa);
                    r2.Append(ccc18);

                    Cell ccc19 = new Cell();
                    ccc19.DataType = CellValues.String;
                    ccc19.CellValue = new CellValue(item.Observacion);//--19
                    r2.Append(ccc19);

                    Cell ccc20 = new Cell();
                    ccc20.DataType = CellValues.String;
                    ccc20.CellValue = new CellValue(item.DesLocal);
                    r2.Append(ccc20);

                    Cell ccc21 = new Cell();
                    ccc21.DataType = CellValues.String;
                    ccc21.CellValue = new CellValue(item.DesArea);
                    r2.Append(ccc21);

                    Cell ccc22 = new Cell();
                    ccc22.DataType = CellValues.String;
                    ccc22.CellValue = new CellValue(item.DesOficina);
                    r2.Append(ccc22);

                    Cell ccc23 = new Cell();
                    ccc23.DataType = CellValues.String;
                    ccc23.CellValue = new CellValue(item.DesEmpleado);
                    r2.Append(ccc23);

                    Cell ccc24 = new Cell();
                    ccc24.DataType = CellValues.String;
                    ccc24.CellValue = new CellValue(item.DesEstado);
                    r2.Append(ccc24);

                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////

                ws.Append(sd);

                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBBIENESDS";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);
                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();
                //string fileName = "TBBIENESDS.xlsx";
                Response.Clear();
                byte[] dt = ms.ToArray();

                /*
                //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                //----------------------------------------------
                var path = @"" + rutaDirPath + "TBBIENESDS.xlsx";
                System.IO.File.WriteAllBytes(path, dt);
                //----------------------------------------------
                Response.BinaryWrite(dt);
                Response.End();
                */

                dtBienesDs = dt; 


            }

            if (strExcelExportado == "TBOFICINA")
            {
                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("Local");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("Área");
                r1.Append(c2);

                Cell c3 = new Cell();
                c3.DataType = CellValues.String;
                c3.CellValue = new CellValue("Oficina");
                r1.Append(c3);

                Cell c4 = new Cell();
                c4.DataType = CellValues.String;
                c4.CellValue = new CellValue("Descripción");
                r1.Append(c4);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasGenerarExcel item in ToEmailListaOficina)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.CodLocal);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.CodArea);
                    r2.Append(cc2);

                    Cell cc3 = new Cell();
                    cc3.DataType = CellValues.String;
                    cc3.CellValue = new CellValue(item.CodOficina);
                    r2.Append(cc3);

                    Cell cc4 = new Cell();
                    cc4.DataType = CellValues.String;
                    cc4.CellValue = new CellValue(item.DesOficina);
                    r2.Append(cc4);

                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////

                ws.Append(sd);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBOFICINA";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);
                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();
                //string fileName = "TBOFICINA.xlsx";
                Response.Clear();
                byte[] dt = ms.ToArray();
                /*
                //Para Crear Excel desde el Navegador
                //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                Response.BinaryWrite(dt);
                //----------------------------------------------
                var path = @"" + rutaDirPath + "TBOFICINA.xlsx";
                System.IO.File.WriteAllBytes(path, dt);
                //----------------------------------------------
                Response.End();
                */
                dtOficina = dt;

            }

            if (strExcelExportado == "TBEMPLEADO")
            {
                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("Local");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("Área");
                r1.Append(c2);

                Cell c3 = new Cell();
                c3.DataType = CellValues.String;
                c3.CellValue = new CellValue("Empleado");
                r1.Append(c3);

                Cell c4 = new Cell();
                c4.DataType = CellValues.String;
                c4.CellValue = new CellValue("Descripción");
                r1.Append(c4);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasGenerarExcel item in ToEmailListaEmpleado)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.CodLocal);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.CodArea);
                    r2.Append(cc2);

                    Cell cc3 = new Cell();
                    cc3.DataType = CellValues.String;
                    cc3.CellValue = new CellValue(item.CodResponsable);
                    r2.Append(cc3);

                    Cell cc4 = new Cell();
                    cc4.DataType = CellValues.String;
                    cc4.CellValue = new CellValue(item.DesEmpleado);
                    r2.Append(cc4);

                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////

                ws.Append(sd);

                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBEMPLEADO";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);
                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();
                //string fileName = "TBEMPLEADO.xlsx";
                Response.Clear();
                byte[] dt = ms.ToArray();

                /*
                //Para Crear Excel desde el Navegador
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                Response.BinaryWrite(dt);
                //-------------------------------------
                var path = @"" + rutaDirPath + "TBEMPLEADO.xlsx";
                System.IO.File.WriteAllBytes(path, dt);
                //---------------------------------------
                Response.End();
                */
                dtEmpleado = dt;


            }

            if (strExcelExportado == "TBLOCAL")
            {
                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("Código");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("Descripción");
                r1.Append(c2);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasGenerarExcel item in ToEmailListaLocal)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.CodLocal);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.DesLocal);
                    r2.Append(cc2);


                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////

                ws.Append(sd);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBLOCAL";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);
                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();
                //string fileName = "TBLOCAL.xlsx";
                Response.Clear();
                byte[] dt = ms.ToArray();

                /*
                //Para Crear Excel desde el Navegador
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                Response.BinaryWrite(dt);
                System.IO.MemoryStream stream1 = new System.IO.MemoryStream(dt, true);               
                //-------------------------------------
                var path = @"" + rutaDirPath + "TBLOCAL.xlsx";
                System.IO.File.WriteAllBytes(path, dt);
                //---------------------------------------
                Response.End();
                */

                dtLocal = dt;


            }

            if (strExcelExportado == "TBAREAS")
            {
                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("Local");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("Código");
                r1.Append(c2);

                Cell c3 = new Cell();
                c3.DataType = CellValues.String;
                c3.CellValue = new CellValue("Descripción");
                r1.Append(c3);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasGenerarExcel item in ToEmailListaAreas)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.CodLocal);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.CodArea);
                    r2.Append(cc2);

                    Cell cc3 = new Cell();
                    cc3.DataType = CellValues.String;
                    cc3.CellValue = new CellValue(item.DesArea);
                    r2.Append(cc3);


                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////

                ws.Append(sd);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBAREAS";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);
                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();
                //string fileName = "TBAREAS.xlsx";
                Response.Clear();
                byte[] dt = ms.ToArray();

                /*
               //Para Crear Excel desde el Navegador
               Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
               Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
               Response.BinaryWrite(dt);
               //----------------------------------------------
               var path = @"" + rutaDirPath + "TBAREAS.xlsx";
               System.IO.File.WriteAllBytes(path, dt);
               //----------------------------------------------
               Response.End();
               */

                dtAreas = dt;
        

            }

            if (strExcelExportado == "TBESTADO")
           {
               //GENERAR EXCEL
               MemoryStream ms = new MemoryStream();
               SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
               WorkbookPart wbp = xl.AddWorkbookPart();
               WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
               Workbook wb = new Workbook();
               FileVersion fv = new FileVersion();
               fv.ApplicationName = "Microsoft Office Excel";
               Worksheet ws = new Worksheet();

               //First sheet
               SheetData sd = new SheetData();
               Row r1 = new Row() { RowIndex = 1u };

               //LLENAMOS LA CABECERA
               Cell c1 = new Cell();
               c1.DataType = CellValues.String;
               c1.CellValue = new CellValue("Codigo");
               r1.Append(c1);

               Cell c2 = new Cell();
               c2.DataType = CellValues.String;
               c2.CellValue = new CellValue("Descripcion");
               r1.Append(c2);

               sd.Append(r1);

               //LLENAMOS EL DETALLE
               int fila = 1;

               foreach (TablasGenerarExcel item in ToEmailListaEstado)
               {
                   Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                   Cell cc1 = new Cell();
                   cc1.DataType = CellValues.String;
                   cc1.CellValue = new CellValue(item.CodEstado);
                   r2.Append(cc1);

                   Cell cc2 = new Cell();
                   cc2.DataType = CellValues.String;
                   cc2.CellValue = new CellValue(item.DesEstado);
                   r2.Append(cc2);

                   sd.Append(r2);

                   fila++;
               }

               ////////////////////////////////////////////////////////////////////

               ws.Append(sd);
               wsp.Worksheet = ws;
               wsp.Worksheet.Save();
               Sheets sheets = new Sheets();
               Sheet sheet = new Sheet();
               sheet.Name = "TBESTADO";
               sheet.SheetId = 1;
               sheet.Id = wbp.GetIdOfPart(wsp);
               sheets.Append(sheet);
               wb.Append(fv);
               wb.Append(sheets);
               xl.WorkbookPart.Workbook = wb;
               xl.WorkbookPart.Workbook.Save();
               xl.Close();
               //string fileName = "TBESTADO.xlsx";
               Response.Clear();
               byte[] dt = ms.ToArray();
               /*
               //Para Crear Excel desde el Navegador
               Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
               Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
               Response.BinaryWrite(dt);                
               //----------------------------------------------
               var path = @"" + rutaDirPath + "TBESTADO.xlsx";
               System.IO.File.WriteAllBytes(path, dt);
               //----------------------------------------------
               Response.End();
               */

                dtEstado = dt;

            }

            if (strExcelExportado == "TBTIPO")
            {
                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("Codigo");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("Descripcion");
                r1.Append(c2);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasGenerarExcel item in ToEmailListaTipo)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.CodTipo);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.DesTipo);
                    r2.Append(cc2);

                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////

                ws.Append(sd);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBTIPO";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);
                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();
                //string fileName = "TBTIPO.xlsx";
                Response.Clear();
                byte[] dt = ms.ToArray();

                /*
                //Para Crear Excel desde el Navegador
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                Response.BinaryWrite(dt);
                //----------------------------------------------
                var path = @"" + rutaDirPath + "TBTIPO.xlsx";
                System.IO.File.WriteAllBytes(path, dt);
                
                //----------------------------------------------
                Response.End();
                */

                dtTipo = dt;

            }

            if (strExcelExportado == "TBENTIDAD")
            {
                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("Codigo");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("Descripcion");
                r1.Append(c2);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasGenerarExcel item in ToEmailListaEntidad)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.CodEntidad);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.DesEntidad);
                    r2.Append(cc2);

                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////

                ws.Append(sd);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBENTIDAD";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);
                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();
                //string fileName = "TBENTIDAD.xlsx";
                Response.Clear();
                byte[] dt = ms.ToArray();

                /*
                //Para Crear Excel desde el Navegador
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                Response.BinaryWrite(dt);
                Response.End();
                //----------------------------------------------
                //Para Crear Excel hasta una ruta en un directorio
                var path = @"" + rutaDirPath + "TBENTIDAD.xlsx";
                System.IO.File.WriteAllBytes(path, dt);
                //----------------------------------------------
                */

                //----------------------------------------------
                //Para guardar el excel en codio byte[] y mantenerlo como variable
                dtEntidad = dt;  //TBENTIDAD.xlsx
                //----------------------------------------------


            }


        }

         
        //Variables String para almacenar las listas en txt que se enviaran al Correo
        public static string txtBienes;
        public static string txtBienesDs;
        public static string txtEmpleado;
        public static string txtOficina;
        //16.3 Martes.17.08.2021
        public void GenerarStringFilesParaEnviarTxtPorCorreo(string strTxtExportado)
        {               

            if (strTxtExportado == "TBBIENES")
            {
                //string UploadPath = ConfigurationManager.AppSettings["rutaMasivoExcel"];
                //string path = Path.Combine(HttpContext.Request.MapPath(UploadPath), fileName);
                //string extension = Path.GetExtension(file.FileName);
                //rutaDirectorioExcel = Path.Combine(HttpContext.Request.MapPath(UploadPath));
                //////https://www.delftstack.com/es/howto/csharp/how-to-create-a-folder-in-csharp/
                //// //OBTENER LA RUTA DE "DirImportacionExcel"       
                ////    string strRutaDir = "";
                ////    strRutaDir = ConfigurationManager.AppSettings["rutaMasivoExcel"];
                ////    string folderPath = Path.Combine(HttpContext.Request.MapPath(strRutaDir));
                ////    //string folderPath = rutaDirExcel;//@"D:\MyFolder"
                ////    if (!Directory.Exists(folderPath))
                ////    {
                ////        Directory.CreateDirectory(folderPath);                        
                ////        //Console.WriteLine(folderPath);
                ////    }
                //////return folderPath;



                //La lista "listaBienesTxt" pasarlo al documento txt separados por punto y coma 
                System.IO.File.Create(Server.MapPath("~/TBBIENES.txt")).Close();
                System.IO.File.WriteAllLines(Server.MapPath("~/TBBIENES.txt"), ToEmailListaBienes
                .Select(item => string.Join(";",
                  item.Activo,
                  item.Descripcion,
                  item.Anterior,
                  item.CodLocal,
                  item.CodArea,
                  item.CodOficina,
                  item.CodResponsable,
                  item.CodEstado,
                  item.Marca,
                  item.Modelo,
                  item.Serie,
                  item.CodTipo,
                  item.Color,
                  item.Anio,
                  item.NumMotor,
                  item.NumChasis,
                  item.Dimension,
                  item.Placa,
                  item.Observacion,
                  item.FecCreacion,
                  item.FecModificacion,
                  item.NumPda,
                  item.FlgInventario
                ))
                );

                /////////////////////////////////////////////////////////////////////////////////////////////////
                string currentContent = String.Empty;
                string newContent = "Activo;Descripción;Anterior;CodLocal;CodArea;CodOficina;CodEmpleado;CodEstado;Marca;Modelo;Serie;CodTipo;Color;Año;NumMotor;NumChasis;Dimensión;Placa;Observación;FecCreación;FecModificación;NumPda;FlgInventario\r\n";
                if (System.IO.File.Exists(Server.MapPath("~/TBBIENES.txt")))
                {
                    currentContent = System.IO.File.ReadAllText(Server.MapPath("~/TBBIENES.txt"));
                    txtBienes = newContent + currentContent;
                }
                /////////////////////////////////////////////////////////////////////////////////////////////////
            }

            if (strTxtExportado == "TBBIENESDS")
            {
                System.IO.File.Create(Server.MapPath("~/TBBIENESDS.txt")).Close();
                System.IO.File.WriteAllLines(Server.MapPath("~/TBBIENESDS.txt"), ToEmailListaBienesDs
                .Select(item => string.Join(";",
                   item.Activo,
                   item.Descripcion,
                   item.Anterior,
                   item.CodLocal,
                   item.CodArea,
                   item.CodOficina,
                   item.CodResponsable,
                   item.CodEstado,
                   item.Marca,
                   item.Modelo,
                   item.Serie,
                   item.CodTipo,
                   item.Color,
                   item.Anio,
                   item.NumMotor,
                   item.NumChasis,
                   item.Dimension,
                   item.Placa,
                   item.Observacion,
                   item.DesLocal,
                   item.DesArea,
                   item.DesOficina,
                   item.DesEmpleado
                ))
                );

                /////////////////////////////////////////////////////////////////////////////////////////////////
                string currentContent = String.Empty;          
                string newContent = "Activo;Descripción;Anterior;CodLocal;CodArea;CodOficina;CodEmpleado;CodEstado;Marca;Modelo;Serie;CodTipo;Color;Año;NumMotor;NumChasis;Dimensión;Placa;Observación;DesLocal;DesArea;DesOficina;DesEmpleado\r\n";
                if (System.IO.File.Exists(Server.MapPath("~/TBBIENESDS.txt")))
                {
                    currentContent = System.IO.File.ReadAllText(Server.MapPath("~/TBBIENESDS.txt"));
                    txtBienesDs = newContent + currentContent;
                }

                byte[] dtBienesDs2= dtBienesDs; 
            }

            if (strTxtExportado == "TBOFICINA")
            {

                System.IO.File.Create(Server.MapPath("~/TBOFICINA.txt")).Close();
                System.IO.File.WriteAllLines(Server.MapPath("~/TBOFICINA.txt"), ToEmailListaOficina
                .Select(item => string.Join(";",
                     item.CodLocal,
                     item.CodArea,
                     item.CodOficina,
                     item.DesOficina
                 ))
                 );

                string currentContent = String.Empty;
                string newContent = "Local;Área;Oficina;Descripción\r\n";
                if (System.IO.File.Exists(Server.MapPath("~/TBOFICINA.txt")))
                {
                    currentContent = System.IO.File.ReadAllText(Server.MapPath("~/TBOFICINA.txt"));
                    txtOficina = newContent + currentContent;
                }

            }
          
            if (strTxtExportado == "TBEMPLEADO")
           {

               //La lista "listaBienesDsTxt" pasarlo al documento txt separados por punto y coma 
               System.IO.File.Create(Server.MapPath("~/TBEMPLEADO.txt")).Close();
               //Leemos row por row lo que contiene la lista
               System.IO.File.WriteAllLines(Server.MapPath("~/TBEMPLEADO.txt"), ToEmailListaEmpleado
               .Select(item => string.Join(";",
                    item.CodLocal,
                    item.CodArea,
                    item.CodResponsable,
                    item.DesEmpleado
                ))
                );

               string currentContent = String.Empty;
               string newContent = "Local;Área;Empleado;Descripción\r\n";
               if (System.IO.File.Exists(Server.MapPath("~/TBEMPLEADO.txt")))
               {
                    currentContent = System.IO.File.ReadAllText(Server.MapPath("~/TBEMPLEADO.txt"));
                    txtEmpleado = newContent + currentContent;
                }


           }

        }

        //16.5
        public ActionResult GetListasDeTablasParaEnviarCorreo(string strExcelExportado)
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
                if (strExcelExportado == "TBBIENES")
                {

                    using (proxyRep = new ReportesSrvClient())
                    {
                        ToEmailListaBienes = proxyRep.ToEmailGenerarArchivosExcel(objSession, strExcelExportado, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = ToEmailListaBienes.Count;

                }

                if (strExcelExportado == "TBBIENESDS")
                {

                    using (proxyRep = new ReportesSrvClient())
                    {
                        ToEmailListaBienesDs = proxyRep.ToEmailGenerarArchivosExcel(objSession, strExcelExportado, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = ToEmailListaBienesDs.Count;
                }

                if (strExcelExportado == "TBOFICINA")
                {

                    using (proxyRep = new ReportesSrvClient())
                    {
                        ToEmailListaOficina = proxyRep.ToEmailGenerarArchivosExcel(objSession, strExcelExportado, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = ToEmailListaOficina.Count;
                }

                if (strExcelExportado == "TBEMPLEADO")
                {

                    using (proxyRep = new ReportesSrvClient())
                    {
                        ToEmailListaEmpleado = proxyRep.ToEmailGenerarArchivosExcel(objSession, strExcelExportado, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = ToEmailListaEmpleado.Count;

                }

                if (strExcelExportado == "TBLOCAL")
                {

                    using (proxyRep = new ReportesSrvClient())
                    {
                        ToEmailListaLocal = proxyRep.ToEmailGenerarArchivosExcel(objSession, strExcelExportado, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = ToEmailListaLocal.Count;

                }

                if (strExcelExportado == "TBAREAS")
                {

                    using (proxyRep = new ReportesSrvClient())
                    {
                        ToEmailListaAreas = proxyRep.ToEmailGenerarArchivosExcel(objSession, strExcelExportado, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = ToEmailListaAreas.Count;

                }

                if (strExcelExportado == "TBESTADO")
                {

                    using (proxyRep = new ReportesSrvClient())
                    {
                        ToEmailListaEstado = proxyRep.ToEmailGenerarArchivosExcel(objSession, strExcelExportado, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = ToEmailListaEstado.Count;

                }

                if (strExcelExportado == "TBTIPO")
                {

                    using (proxyRep = new ReportesSrvClient())
                    {
                        ToEmailListaTipo = proxyRep.ToEmailGenerarArchivosExcel(objSession, strExcelExportado, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = ToEmailListaTipo.Count;

                }

                if (strExcelExportado == "TBENTIDAD")
                {

                    using (proxyRep = new ReportesSrvClient())
                    {
                        ToEmailListaEntidad = proxyRep.ToEmailGenerarArchivosExcel(objSession, strExcelExportado, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = ToEmailListaEntidad.Count;

                }


            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ProcesoController.cs");
            }

            return Json(resultado);

        }

        //16.6 //ESTA SIENDO CAMBIADO POR OTRO GENRAL PARA ESCEL Y TXT
        public JsonResult EnviarCuatroExcelsPorCorreo( string strEmailDestino, string idRadioCheck)
        {
            //OBTENER LA RUTA 
            string strRutaDir = "";
            strRutaDir = ConfigurationManager.AppSettings["rutaGenerarExcelToEmail"];
            string rutaDeExcelsToEmail = Path.Combine(HttpContext.Request.MapPath(strRutaDir));
            //OBJETO SESSION
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion  = Auth.intIdSesion();
            objSession.intIdSoft    = Auth.intIdSoft();
            objSession.intIdMenu    = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();

            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";
            Dictionary<string, string> obj = new Dictionary<string, string>();

            try
            {
                using (proxyRep = new ReportesSrvClient())
                {
                    obj = proxyRep.ToEmailEnviarExcelPorCorreo(objSession, strEmailDestino, rutaDeExcelsToEmail
                                                              , dtBienes, dtBienesDs, dtOficina, dtEmpleado , dtLocal
                                                              , dtAreas, dtEstado, dtTipo, dtEntidad
                                                              , txtBienes
                                                              , txtBienesDs
                                                              , txtOficina
                                                              , txtEmpleado
                                                              , idRadioCheck
                                                              , ref strMsgUsuario);

                    proxyRep.Close();

                }

                if (strMsgUsuario.Contains("Se envió el correo con credenciales."))
                {
                    if (idRadioCheck == "chck_excel") {
                    result.type = "success";
                    result.message = "El envío de los Excel ha sido procesado exitosamente.";
                    }
                    else if (idRadioCheck == "chck_excel")
                    {
                        result.type = "success";
                        result.message = "El envío de los Formatos Txt ha sido procesado exitosamente.";
                    }
                    else
                    {
                        result.type = "success";
                        result.message = "El envío de los Excel y de los Formatos Txt ha sido procesado exitosamente.";
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

        //16.7 MARTES 17.08.2021 EXCEL Y TXT
        public JsonResult EnviarDocumentosExportadosPorCorreo(string strEmailDestino, string idRadioCheck)
        {
            ////OBTENER LA RUTA 
            //string strRutaDir = "";
            //strRutaDir = ConfigurationManager.AppSettings["rutaGenerarExcelToEmail"];
            //string rutaDeExcelsToEmail = Path.Combine(HttpContext.Request.MapPath(strRutaDir));
            //OBJETO SESSION
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";
            Dictionary<string, string> obj = new Dictionary<string, string>();

            try
            {

                using (proxyRep = new ReportesSrvClient())
                {
                    obj = proxyRep.ToEmailEnviarExcelPorCorreo(
                                                                objSession 
                                                              , strEmailDestino
                                                              , "rutaDeExcelsToEmail"
                                                              , dtBienes
                                                              , dtBienesDs
                                                              , dtOficina
                                                              , dtEmpleado
                                                              , dtLocal
                                                              , dtAreas
                                                              , dtEstado
                                                              , dtTipo
                                                              , dtEntidad
                                                              , txtBienes
                                                              , txtBienesDs
                                                              , txtOficina
                                                              , txtEmpleado
                                                              , idRadioCheck
                                                              , ref strMsgUsuario); 
                                                             
                    proxyRep.Close();

                }

                if (strMsgUsuario.Contains("Se envió el correo con credenciales."))
                {
                    result.type = "success";
                    result.message = "El envío de los Excel ha sido procesado exitosamente.";

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

        //LISTAS GLOBALES Y ESTATICAS EXCEL CON DATA SQL
        //16.7.1
        public static IList<TablasExcelsConDataSQL> ListaConDataSQLBienes;
        //16.7.2           
        public static IList<TablasExcelsConDataSQL> ListaConDataSQLOficina;
        //16.7.3           
        public static IList<TablasExcelsConDataSQL> ListaConDataSQLEmpleado;
        //16.7.4         
        public static IList<TablasExcelsConDataSQL> ListaConDataSQLLocal;
        //16.7.5          
        public static IList<TablasExcelsConDataSQL> ListaConDataSQLAreas;
        //16.7.6          
        public static IList<TablasExcelsConDataSQL> ListaConDataSQLEstado;
        //16.7.7           
        public static IList<TablasExcelsConDataSQL> ListaConDataSQLTipo;
        //16.7.8           
        public static IList<TablasExcelsConDataSQL> ListaConDataSQLEntidad;

        //16.7
        public ActionResult GenerarExcelsConDataSQLListas(string strNombreExcelConDataSQL)
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
                if (strNombreExcelConDataSQL == "TBBIENES")//16.7.1
                {

                    using (proxyRep = new ReportesSrvClient())
                    {
                        ListaConDataSQLBienes = proxyRep.GenerarExcelsConDataSQLListas(objSession, strNombreExcelConDataSQL, ref strMsgUsuario).ToList();
                        proxyRep.Close();


                    }
                    resultado = ListaConDataSQLBienes.Count;

                }

                if (strNombreExcelConDataSQL == "TBOFICINA")//16.7.2
                {

                    using (proxyRep = new ReportesSrvClient())
                    {
                        ListaConDataSQLOficina= proxyRep.GenerarExcelsConDataSQLListas(objSession, strNombreExcelConDataSQL, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = ListaConDataSQLOficina.Count;
                }

                if (strNombreExcelConDataSQL == "TBEMPLEADO")//16.7.3
                {

                    using (proxyRep = new ReportesSrvClient())
                    {
                        ListaConDataSQLEmpleado = proxyRep.GenerarExcelsConDataSQLListas(objSession, strNombreExcelConDataSQL, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = ListaConDataSQLEmpleado.Count;

                }

                if (strNombreExcelConDataSQL == "TBLOCAL")
                {

                    using (proxyRep = new ReportesSrvClient())//16.7.4
                    {
                        ListaConDataSQLLocal = proxyRep.GenerarExcelsConDataSQLListas(objSession, strNombreExcelConDataSQL, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = ListaConDataSQLLocal.Count;

                }

                if (strNombreExcelConDataSQL == "TBAREAS")//16.7.5
                {

                    using (proxyRep = new ReportesSrvClient())
                    {
                        ListaConDataSQLAreas = proxyRep.GenerarExcelsConDataSQLListas(objSession, strNombreExcelConDataSQL, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = ListaConDataSQLAreas.Count;

                }

                if (strNombreExcelConDataSQL == "TBESTADO")//16.7.6
                {

                    using (proxyRep = new ReportesSrvClient())
                    {
                        ListaConDataSQLEstado = proxyRep.GenerarExcelsConDataSQLListas(objSession, strNombreExcelConDataSQL, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = ListaConDataSQLEstado.Count;

                }

                if (strNombreExcelConDataSQL == "TBTIPO")//16.7.7
                {

                    using (proxyRep = new ReportesSrvClient())
                    {
                        ListaConDataSQLTipo = proxyRep.GenerarExcelsConDataSQLListas(objSession, strNombreExcelConDataSQL, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = ListaConDataSQLTipo.Count;

                }

                if (strNombreExcelConDataSQL == "TBENTIDAD")//16.7.8
                {

                    using (proxyRep = new ReportesSrvClient())
                    {
                        ListaConDataSQLEntidad = proxyRep.GenerarExcelsConDataSQLListas(objSession, strNombreExcelConDataSQL, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = ListaConDataSQLEntidad.Count;

                }



            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ProcesoController.cs");
            }

            return Json(resultado);

        }

        //16.8
        public void GenerarExcelsConDataSQLDescarga(string strNombreExcelConDataSQL)
        {
            /*Aqui se generan y se descargan en el navegador los 8 excels*/
            string strRutaDir = "";
            strRutaDir = ConfigurationManager.AppSettings["rutaGenerarExcelConDataSQL"];//rutaGenerarExcelConDataSQL no va el  DirGenerarExcelConDataSQL
            string rutaDirPath = Path.Combine(HttpContext.Request.MapPath(strRutaDir));


            if (strNombreExcelConDataSQL == "TBBIENES")
            {

                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("strCodActivo");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("strDescripcion");
                r1.Append(c2);

                Cell c3 = new Cell();
                c3.DataType = CellValues.String;
                c3.CellValue = new CellValue("strCodAnterior");
                r1.Append(c3);

                Cell c4 = new Cell();
                c4.DataType = CellValues.String;
                c4.CellValue = new CellValue("strCodLocal");
                r1.Append(c4);

                Cell c5 = new Cell();
                c5.DataType = CellValues.String;
                c5.CellValue = new CellValue("strCodArea");
                r1.Append(c5);

                Cell c6 = new Cell();
                c6.DataType = CellValues.String;
                c6.CellValue = new CellValue("strCodOficina");
                r1.Append(c6);

                Cell c7 = new Cell();
                c7.DataType = CellValues.String;
                c7.CellValue = new CellValue("strCodEmpleado");
                r1.Append(c7);

                Cell c8 = new Cell();
                c8.DataType = CellValues.String;
                c8.CellValue = new CellValue("CodEstado");
                r1.Append(c8);

                Cell c9 = new Cell();
                c9.DataType = CellValues.String;
                c9.CellValue = new CellValue("strCodEstado");
                r1.Append(c9);

                Cell c10 = new Cell();
                c10.DataType = CellValues.String;
                c10.CellValue = new CellValue("strDescModelo");
                r1.Append(c10);

                Cell c11 = new Cell();
                c11.DataType = CellValues.String;
                c11.CellValue = new CellValue("strDescSerie");
                r1.Append(c11);

                Cell c12 = new Cell();
                c12.DataType = CellValues.String;
                c12.CellValue = new CellValue("strCodTipo");
                r1.Append(c12);

                Cell c13 = new Cell();
                c13.DataType = CellValues.String;
                c13.CellValue = new CellValue("strDescColor");
                r1.Append(c13);

                Cell c14 = new Cell();
                c14.DataType = CellValues.String;
                c14.CellValue = new CellValue("intAnio");
                r1.Append(c14);

                Cell c15 = new Cell();
                c15.DataType = CellValues.String;
                c15.CellValue = new CellValue("strDescNumMotor");
                r1.Append(c15);

                Cell c16 = new Cell();
                c16.DataType = CellValues.String;
                c16.CellValue = new CellValue("strDescNumChasis");
                r1.Append(c16);

                Cell c17 = new Cell();
                c17.DataType = CellValues.String;
                c17.CellValue = new CellValue("strDescDimension");
                r1.Append(c17);

                Cell c18 = new Cell();
                c18.DataType = CellValues.String;
                c18.CellValue = new CellValue("strDescPlaca");
                r1.Append(c18);

                Cell c19 = new Cell();
                c19.DataType = CellValues.String;
                c19.CellValue = new CellValue("strDescObservacion");
                r1.Append(c19);

                Cell c20 = new Cell();
                c20.DataType = CellValues.String;
                c20.CellValue = new CellValue("dttFeCrea");
                r1.Append(c20);

                Cell c21 = new Cell();
                c21.DataType = CellValues.String;
                c21.CellValue = new CellValue("dttFeModi");
                r1.Append(c21);

                Cell c22 = new Cell();
                c22.DataType = CellValues.String;
                c22.CellValue = new CellValue("strPda");
                r1.Append(c22);

                Cell c23 = new Cell();
                c23.DataType = CellValues.String;
                c23.CellValue = new CellValue("strFlag");
                r1.Append(c23);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasExcelsConDataSQL item in ListaConDataSQLBienes)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.strCodActivo);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.strDescripcion);
                    r2.Append(cc2);

                    Cell cc3 = new Cell();
                    cc3.DataType = CellValues.String;
                    cc3.CellValue = new CellValue(item.strCodAnterior);
                    r2.Append(cc3);

                    Cell cc4 = new Cell();
                    cc4.DataType = CellValues.String;
                    cc4.CellValue = new CellValue(item.strCodLocal);
                    r2.Append(cc4);

                    Cell cc5 = new Cell();
                    cc5.DataType = CellValues.String;
                    cc5.CellValue = new CellValue(item.strCodArea);
                    r2.Append(cc5);

                    Cell cc6 = new Cell();
                    cc6.DataType = CellValues.String;
                    cc6.CellValue = new CellValue(item.strCodOficina);//ubicacion
                    r2.Append(cc6);

                    Cell cc7 = new Cell();
                    cc7.DataType = CellValues.String;
                    cc7.CellValue = new CellValue(item.strCodEmpleado);
                    r2.Append(cc7);

                    Cell cc8 = new Cell();
                    cc8.DataType = CellValues.String;
                    cc8.CellValue = new CellValue(item.strCodEstado);
                    r2.Append(cc8);

                    Cell cc9 = new Cell();
                    cc9.DataType = CellValues.String;
                    cc9.CellValue = new CellValue(item.strDescMarca);
                    r2.Append(cc9);


                    Cell cc10 = new Cell();
                    cc10.DataType = CellValues.String;
                    cc10.CellValue = new CellValue(item.strDescModelo);
                    r2.Append(cc10);

                    Cell cc11 = new Cell();
                    cc11.DataType = CellValues.String;
                    cc11.CellValue = new CellValue(item.strDescSerie);
                    r2.Append(cc11);

                    Cell cc12 = new Cell();
                    cc12.DataType = CellValues.String;
                    cc12.CellValue = new CellValue(item.strCodTipo);
                    r2.Append(cc12);

                    Cell cc13 = new Cell();
                    cc13.DataType = CellValues.String;
                    cc13.CellValue = new CellValue(item.strDescColor);
                    r2.Append(cc13);

                    Cell cc14 = new Cell();
                    cc14.DataType = CellValues.String;
                    cc14.CellValue = new CellValue(item.intAnio);
                    r2.Append(cc14);

                    Cell ccc15 = new Cell();
                    ccc15.DataType = CellValues.String;
                    ccc15.CellValue = new CellValue(item.strDescNumMotor);
                    r2.Append(ccc15);

                    Cell ccc16 = new Cell();
                    ccc16.DataType = CellValues.String;
                    ccc16.CellValue = new CellValue(item.strDescNumChasis);
                    r2.Append(ccc16);

                    Cell ccc17 = new Cell();
                    ccc17.DataType = CellValues.String;
                    ccc17.CellValue = new CellValue(item.strDescDimension);
                    r2.Append(ccc17);

                    Cell ccc18 = new Cell();
                    ccc18.DataType = CellValues.String;
                    ccc18.CellValue = new CellValue(item.strDescPlaca);
                    r2.Append(ccc18);

                    Cell ccc19 = new Cell();
                    ccc19.DataType = CellValues.String;
                    ccc19.CellValue = new CellValue(item.strDescObservacion);
                    r2.Append(ccc19);

                    Cell ccc20 = new Cell();
                    ccc20.DataType = CellValues.String;
                    ccc20.CellValue = new CellValue(item.dttFeCrea);
                    r2.Append(ccc20);

                    Cell ccc21 = new Cell();
                    ccc21.DataType = CellValues.String;
                    ccc21.CellValue = new CellValue(item.dttFeModi);
                    r2.Append(ccc21);

                    Cell ccc22 = new Cell();
                    ccc22.DataType = CellValues.String;
                    ccc22.CellValue = new CellValue(item.strPda);
                    r2.Append(ccc22);

                    Cell ccc23 = new Cell();
                    ccc23.DataType = CellValues.String;
                    ccc23.CellValue = new CellValue(item.strFlag);
                    r2.Append(ccc23);

                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////
                ws.Append(sd);
                //ws2.Append(sd2);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBBIENES";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                //Sheet sheet2 = new Sheet();
                //sheet2.Name = "TBBIENES";
                //sheet2.SheetId = 2;
                //sheet2.Id = wbp.GetIdOfPart(wsp2);
                sheets.Append(sheet);
                //sheets.Append(sheet2);
                wb.Append(fv);
                wb.Append(sheets);

                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();
                
                Response.Clear();
                string fileName = "TBBIENES.xlsx";
                byte[] dt = ms.ToArray();

                
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                Response.BinaryWrite(dt);
                Response.End();
                //----------------------------------------------
                //var path = @"" + rutaDirPath + "TBBIENES.xlsx";                
                //System.IO.File.WriteAllBytes(path, dt);
                //----------------------------------------------
                /*//----------------------------------------------
                //var path = @"D:\ExcelsToEmail\TBBIENES.xlsx";
                var path = @"" + rutaDirPath + "TBBIENES.xlsx";                
                System.IO.File.WriteAllBytes(path, dt);
                //---------------------------------------------- */
                //dtBienes = dt;

              



            }         

            if (strNombreExcelConDataSQL == "TBOFICINA")
            {
                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("strCodLocal");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("strCodArea");
                r1.Append(c2);

                Cell c3 = new Cell();
                c3.DataType = CellValues.String;
                c3.CellValue = new CellValue("strCodOficina");
                r1.Append(c3);

                Cell c4 = new Cell();
                c4.DataType = CellValues.String;
                c4.CellValue = new CellValue("strDescOficina");
                r1.Append(c4);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasExcelsConDataSQL item in ListaConDataSQLOficina)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.strCodLocal);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.strCodArea);
                    r2.Append(cc2);

                    Cell cc3 = new Cell();
                    cc3.DataType = CellValues.String;
                    cc3.CellValue = new CellValue(item.strCodOficina);
                    r2.Append(cc3);

                    Cell cc4 = new Cell();
                    cc4.DataType = CellValues.String;
                    cc4.CellValue = new CellValue(item.strDescOficina);
                    r2.Append(cc4);

                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////
                ws.Append(sd);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBOFICINA";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);
                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();                
                Response.Clear();
                byte[] dt = ms.ToArray();

                //Para Crear Excel desde el Navegador con el Windows.Open()
                string fileName = "TBOFICINA.xlsx";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                Response.BinaryWrite(dt);

                //Para Generarlo dentro de un directorio
                ////var path = @"" + rutaDirPath + "TBOFICINA.xlsx";
                ////System.IO.File.WriteAllBytes(path, dt);

                Response.End();

                //Para enviarlo por Email
                //dtOficina = dt;

            }

            if (strNombreExcelConDataSQL == "TBEMPLEADO")
            {
                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("strCodLocal");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("strCodArea");
                r1.Append(c2);

                Cell c3 = new Cell();
                c3.DataType = CellValues.String;
                c3.CellValue = new CellValue("strCodEmpleado");
                r1.Append(c3);

                Cell c4 = new Cell();
                c4.DataType = CellValues.String;
                c4.CellValue = new CellValue("strDescEmpleado");
                r1.Append(c4);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasExcelsConDataSQL item in ListaConDataSQLEmpleado)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.strCodLocal);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.strCodArea);
                    r2.Append(cc2);

                    Cell cc3 = new Cell();
                    cc3.DataType = CellValues.String;
                    cc3.CellValue = new CellValue(item.strCodEmpleado);
                    r2.Append(cc3);

                    Cell cc4 = new Cell();
                    cc4.DataType = CellValues.String;
                    cc4.CellValue = new CellValue(item.strDescEmpleado);
                    r2.Append(cc4);

                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////

                ws.Append(sd);

                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBEMPLEADO";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);
                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();               
                Response.Clear();
                byte[] dt = ms.ToArray();

                //Para Crear Excel desde el Navegador con el Windows.Open()
                string fileName = "TBEMPLEADO.xlsx";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                Response.BinaryWrite(dt);

                //-------------------------------------
                //var path = @"" + rutaDirPath + "TBEMPLEADO.xlsx";
                //System.IO.File.WriteAllBytes(path, dt);
                //---------------------------------------
                Response.End();

                ////dtEmpleado = dt;


            }

            if (strNombreExcelConDataSQL == "TBLOCAL")
            {
                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("strCodLocal");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("strDescLocal");
                r1.Append(c2);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasExcelsConDataSQL item in ListaConDataSQLLocal)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.strCodLocal);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.strDescLocal);
                    r2.Append(cc2);

                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////

                ws.Append(sd);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBLOCAL";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);
                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();                
                Response.Clear();
                byte[] dt = ms.ToArray();

                //Para Crear Excel desde el Navegador con el Windows.Open()
                string fileName = "TBLOCAL.xlsx";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                Response.BinaryWrite(dt);
                System.IO.MemoryStream stream1 = new System.IO.MemoryStream(dt, true);

                //----------------------------------------------
                ////var path = @"" + rutaDirPath + "TBLOCAL.xlsx";
                ////System.IO.File.WriteAllBytes(path, dt);
                //----------------------------------------------
                Response.End();               

                //dtLocal = dt;

            }

            if (strNombreExcelConDataSQL == "TBAREAS")
            {
                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("strCodLocal");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("strCodArea");
                r1.Append(c2);

                Cell c3 = new Cell();
                c3.DataType = CellValues.String;
                c3.CellValue = new CellValue("strDescArea");
                r1.Append(c3);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasExcelsConDataSQL item in ListaConDataSQLAreas)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.strCodLocal);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.strCodArea);
                    r2.Append(cc2);

                    Cell cc3 = new Cell();
                    cc3.DataType = CellValues.String;
                    cc3.CellValue = new CellValue(item.strDescArea);
                    r2.Append(cc3);

                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////

                ws.Append(sd);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBAREAS";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);
                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();                
                Response.Clear();
                byte[] dt = ms.ToArray();

                //Para Crear Excel desde el Navegador con el Windows.Open()
                string fileName = "TBAREAS.xlsx";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                Response.BinaryWrite(dt);
                //----------------------------------------------
                ////var path = @"" + rutaDirPath + "TBAREAS.xlsx";
                ////System.IO.File.WriteAllBytes(path, dt);
                //----------------------------------------------
                Response.End();             

                //dtAreas = dt;


            }

            if (strNombreExcelConDataSQL == "TBESTADO")
            {
                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("strCodEstado");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("strDescEstado");
                r1.Append(c2);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasExcelsConDataSQL item in ListaConDataSQLEstado)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.strCodEstado);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.strDescEstado);
                    r2.Append(cc2);

                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////

                ws.Append(sd);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBESTADO";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);
                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();                
                Response.Clear();
                byte[] dt = ms.ToArray();

                ////////////Para Crear Excel desde el Navegador con el Windows.Open()
                string fileName = "TBESTADO.xlsx";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                Response.BinaryWrite(dt);
                //----------------------------------------------
                ////var path = @"" + rutaDirPath + "TBESTADO.xlsx";
                ////System.IO.File.WriteAllBytes(path, dt);
                //----------------------------------------------
                Response.End();

                //dtEstado = dt;

            }

            if (strNombreExcelConDataSQL == "TBTIPO")
            {
                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("strCodTipo");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("strDescTipo");
                r1.Append(c2);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasExcelsConDataSQL item in ListaConDataSQLTipo)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.strCodTipo);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.strDescTipo);
                    r2.Append(cc2);

                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////

                ws.Append(sd);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBTIPO";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);
                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();                
                Response.Clear();
                byte[] dt = ms.ToArray();

                //Para Crear Excel desde el Navegador con el Windows.Open()
                string fileName = "TBTIPO.xlsx";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                Response.BinaryWrite(dt);

                //----------------------------------------------
                //////var path = @"" + rutaDirPath + "TBTIPO.xlsx";
                //////System.IO.File.WriteAllBytes(path, dt);                
                //----------------------------------------------
                Response.End();                

                ////dtTipo = dt;

            }

            if (strNombreExcelConDataSQL == "TBENTIDAD")
            {
                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("strCodEntidad");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("strDescEntidad");
                r1.Append(c2);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasExcelsConDataSQL item in ListaConDataSQLEntidad)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.strCodEntidad);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.strDescEntidad);
                    r2.Append(cc2);

                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////

                ws.Append(sd);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBENTIDAD";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);
                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();                
                Response.Clear();
                byte[] dt = ms.ToArray();

                //Para Crear Excel desde el Navegador con el Windows.Open()
                string fileName = "TBENTIDAD.xlsx";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                Response.BinaryWrite(dt);
                Response.End();

                //----------------------------------------------
                //Para Crear Excel hasta una ruta en un directorio
                ////var path = @"" + rutaDirPath + "TBENTIDAD.xlsx";
                ////System.IO.File.WriteAllBytes(path, dt);
                //----------------------------------------------                

                //----------------------------------------------
                //Para guardar el excel en codio byte[] y mantenerlo como variable
                //dtEntidad = dt;  //TBENTIDAD.xlsx
                //----------------------------------------------


            }


        }

        #endregion


        #region Mant. EXPORTAR FORMATO DE TEXTO TXT - SISACTIVOFIJO
        //LISTAS GLOBALES Y ESTATICAS (PARA FORMATO TXT)
        public static IList<TablasGenerarTxt> listaBienesTxt;
        public static IList<TablasGenerarTxt> listaBienesDsTxt;
        public static IList<TablasGenerarTxt> listaOficinaTxt;
        public static IList<TablasGenerarTxt> listaEmpleadoTxt;
        public static IList<TablasGenerarTxt> listaEmpleadoTxtTitulo;

        //12.6 Archivos de Texto
        public ActionResult GetListasDeCadaTablaTxt(string strTxtExportado)
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
                if (strTxtExportado == "TBBIENES")
                {

                    using (proxyRep = new ReportesSrvClient())
                    {
                        listaBienesTxt = proxyRep.GenerarArchivosTxt(objSession, strTxtExportado, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = listaBienesTxt.Count;

                }
                if (strTxtExportado == "TBBIENESDS")
                {

                    using (proxyRep = new ReportesSrvClient())
                    {
                        listaBienesDsTxt = proxyRep.GenerarArchivosTxt(objSession, strTxtExportado, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = listaBienesDsTxt.Count;
                }
                if (strTxtExportado == "TBOFICINA")
                {

                    using (proxyRep = new ReportesSrvClient())
                    {
                        listaOficinaTxt = proxyRep.GenerarArchivosTxt(objSession, strTxtExportado, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = listaOficinaTxt.Count;
                }
                if (strTxtExportado == "TBEMPLEADO")
                {

                    using (proxyRep = new ReportesSrvClient())
                    {
                        listaEmpleadoTxt = proxyRep.GenerarArchivosTxt(objSession, strTxtExportado, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = listaEmpleadoTxt.Count;

                }

            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ProcesoController.cs");
            }

            return Json(resultado);

        }

        //12.7 Archivos de Texto
        public void GenerarFormatoArchivoDeTextoTxt(string strTxtExportado)
        {
            /****************************************************************************************
             * En este método solo  genera 04 archivos de texto con el botón 
             * "Formato Archivo de Texto".  Se usan solamente las cuatro listas: listaBienesTxt; 
             * listaBienesDsTxt; listaOficinaTxt; listaEmpleadoTxt; y no las 8 que son para el excel SQL.
             ****************************************************************************************/

            if (strTxtExportado == "TBBIENES")
            {
                //////////////////////////////////////////////////
                //////AÑADIR A LA LISTA PRIMERAS FILAS (titulos)
                //////////////////////////////////////////////////
                ////listaBienesTxt[0].Activo = "Activo";
                ////listaBienesTxt[0].Descripcion = "Descripción";
                ////listaBienesTxt[0].Anterior = "Anterior";
                ////listaBienesTxt[0].CodLocal = "CodLocal";
                ////listaBienesTxt[0].CodArea = "CodArea";
                ////listaBienesTxt[0].CodOficina = "CodOficina";
                ////listaBienesTxt[0].CodResponsable = "CodEmpleado";
                ////listaBienesTxt[0].CodEstado = "CodEstado";
                ////listaBienesTxt[0].Marca = "Marca";
                ////listaBienesTxt[0].Modelo = "Modelo";
                ////listaBienesTxt[0].Serie = "Serie";
                ////listaBienesTxt[0].CodTipo = "CodTipo";
                ////listaBienesTxt[0].Color = "Color";
                ////listaBienesTxt[0].Anio = "Año";
                ////listaBienesTxt[0].NumMotor = "NumMotor";
                ////listaBienesTxt[0].NumChasis = "NumChasis";
                ////listaBienesTxt[0].Dimension = "Dimensión";
                ////listaBienesTxt[0].Placa = "Placa";
                ////listaBienesTxt[0].Observacion = "Observación";
                ////listaBienesTxt[0].FecCreacion = "FecCreación";
                ////listaBienesTxt[0].FecModificacion = "FecModificación";
                ////listaBienesTxt[0].NumPda = "NumPda";
                ////listaBienesTxt[0].FlgInventario = "FlgInventario";

                //La lista "listaBienesTxt" pasarlo al documento txt separados por punto y coma 
                System.IO.File.Create(Server.MapPath("~/TBBIENES.txt")).Close();
                System.IO.File.WriteAllLines(Server.MapPath("~/TBBIENES.txt"), listaBienesTxt
                .Select(item => string.Join(";",
                // join with "," following properties:

                item.Activo,
                item.Descripcion,
                item.Anterior,
                item.CodLocal,
                item.CodArea,
                item.CodOficina,
                item.CodResponsable,
                item.CodEstado,
                item.Marca,
                item.Modelo,
                item.Serie,
                item.CodTipo,
                item.Color,
                item.Anio,
                item.NumMotor,
                item.NumChasis,
                item.Dimension,
                item.Placa,
                item.Observacion,
                item.FecCreacion,
                item.FecModificacion,
                item.NumPda,
                item.FlgInventario

                ))
                );
                //https://docs.microsoft.com/en-us/dotnet/api/system.io.file.writealllines?view=net-5.0
                //https://www.codeproject.com/Questions/1136020/How-to-add-new-column-in-existing-list-in-Csharp
                //https://www.sololearn.com/Discuss/922250/how-can-i-append-some-text-to-the-beginning-of-file
                /////////////////////////////////////////////////////////////////////////////////////////////////
                //Creamos una variable en el cual luego obtendremos lo que contiene el archivo de texto 
                string currentContent = String.Empty;
                //Creamos la cabecera del archivo texto(los títulos en la primera fila)
                string newContent = "Activo;Descripción;Anterior;CodLocal;CodArea;CodOficina;CodEmpleado;CodEstado;Marca;Modelo;Serie;CodTipo;Color;Año;NumMotor;NumChasis;Dimensión;Placa;Observación;FecCreación;FecModificación;NumPda;FlgInventario\r\n";
                if (System.IO.File.Exists(Server.MapPath("~/TBBIENES.txt")))
                {
                    //ReadAllText lee u obtiene todo el contenido existente en el archivo de texto
                    currentContent = System.IO.File.ReadAllText(Server.MapPath("~/TBBIENES.txt"));
                }
                //WriteAllText le sumamos o añade una linea mas al contenido ya existente en el archivo de texto
                System.IO.File.WriteAllText(Server.MapPath("~/TBBIENES.txt"), newContent + currentContent);
                /////////////////////////////////////////////////////////////////////////////////////////////////
                // Get the file path
                var file = Server.MapPath("~/TBBIENES.txt");
                // Append headers
                Response.AppendHeader("content-disposition", "attachment; filename=TBBIENES.txt");
                // Open/Save dialog
                Response.ContentType = "application/octet-stream"; //--->Descargarlo con el WinOpen
                // Push it!
                Response.TransmitFile(file);

            }

            if (strTxtExportado == "TBBIENESDS")
            {
                ////GENERAR ARCHIVO DE TEXTO TBBIENESDS
                //listaBienesDsTxt[0].Activo        =    "Activo"          ;
                //listaBienesDsTxt[0].Descripcion   =    "Descripción"     ;
                //listaBienesDsTxt[0].Anterior      =    "Anterior"        ;
                //listaBienesDsTxt[0].CodLocal      =    "CodLocal"        ;
                //listaBienesDsTxt[0].CodArea       =    "CodArea"         ;
                //listaBienesDsTxt[0].CodOficina    =    "CodOficina"      ;
                //listaBienesDsTxt[0].CodResponsable=    "CodEmpleado"     ;
                //listaBienesDsTxt[0].CodEstado     =    "CodEstado"       ;
                //listaBienesDsTxt[0].Marca         =    "Marca"           ;
                //listaBienesDsTxt[0].Modelo        =    "Modelo"          ;
                //listaBienesDsTxt[0].Serie         =    "Serie"           ;
                //listaBienesDsTxt[0].CodTipo       =    "CodTipo"         ;
                //listaBienesDsTxt[0].Color         =    "Color"           ;
                //listaBienesDsTxt[0].Anio          =    "Año"             ;
                //listaBienesDsTxt[0].NumMotor      =    "NumMotor"        ;
                //listaBienesDsTxt[0].NumChasis     =    "NumChasis"       ;
                //listaBienesDsTxt[0].Dimension     =    "Dimensión"       ;
                //listaBienesDsTxt[0].Placa         =    "Placa"           ;
                //listaBienesDsTxt[0].Observacion   =    "Observación"     ;
                //listaBienesDsTxt[0].DesLocal      =    "DesLocal"        ;
                //listaBienesDsTxt[0].DesArea       =    "DesArea"         ;
                //listaBienesDsTxt[0].DesOficina    =    "DesOficina"      ;
                //listaBienesDsTxt[0].DesEmpleado   =    "DesEmpleado"     ;
                //listaBienesDsTxt[0].DesEstado     =    "DesEstado"       ;


                //La lista "listaBienesDsTxt" pasarlo al documento txt separados por punto y coma 
                System.IO.File.Create(Server.MapPath("~/TBBIENESDS.txt")).Close();
                System.IO.File.WriteAllLines(Server.MapPath("~/TBBIENESDS.txt"), listaBienesDsTxt
                .Select(item => string.Join(";",
                // join with "," following properties:

                item.Activo          ,     
                item.Descripcion     ,
                item.Anterior        ,
                item.CodLocal        ,
                item.CodArea         ,
                item.CodOficina      ,
                item.CodResponsable  ,
                item.CodEstado       ,
                item.Marca           ,
                item.Modelo          ,
                item.Serie           ,
                item.CodTipo         ,
                item.Color           ,
                item.Anio            ,
                item.NumMotor        ,
                item.NumChasis       ,
                item.Dimension       ,
                item.Placa           ,
                item.Observacion     ,
                item.DesLocal        ,
                item.DesArea         ,
                item.DesOficina      ,
                item.DesEmpleado     

                ))
                );

                /////////////////////////////////////////////////////////////////////////////////////////////////
                //Creamos una variable en el cual luego obtendremos lo que contiene el archivo de texto 
                string currentContent = String.Empty;
                //Creamos la cabecera del archivo texto(los títulos en la primera fila)                
                string newContent = "Activo;Descripción;Anterior;CodLocal;CodArea;CodOficina;CodEmpleado;CodEstado;Marca;Modelo;Serie;CodTipo;Color;Año;NumMotor;NumChasis;Dimensión;Placa;Observación;DesLocal;DesArea;DesOficina;DesEmpleado\r\n";
                if (System.IO.File.Exists(Server.MapPath("~/TBBIENESDS.txt")))
                {
                    //ReadAllText lee u obtiene todo el contenido existente en el archivo de texto
                    currentContent = System.IO.File.ReadAllText(Server.MapPath("~/TBBIENESDS.txt"));
                }
                //WriteAllText le sumamos o añade una linea mas al contenido ya existente en el archivo de texto
                System.IO.File.WriteAllText(Server.MapPath("~/TBBIENESDS.txt"), newContent + currentContent);
                /////////////////////////////////////////////////////////////////////////////////////////////////

                // Get the file path
                var file = Server.MapPath("~/TBBIENESDS.txt");
                // Append headers
                Response.AppendHeader("content-disposition", "attachment; filename=TBBIENESDS.txt");
                // Open/Save dialog
                Response.ContentType = "application/octet-stream"; //--->Descargarlo con el WinOpen
                // Push it!
                Response.TransmitFile(file);
            }

            if (strTxtExportado == "TBOFICINA")
            {

                //Pasar la lista "listaBienesDsTxt" al documento txt separados por punto y coma 
                System.IO.File.Create(Server.MapPath("~/TBOFICINA.txt")).Close();
                System.IO.File.WriteAllLines(Server.MapPath("~/TBOFICINA.txt"), listaOficinaTxt
                .Select(item => string.Join(";",
                     // join with "," following properties:

                     item.CodLocal,
                     item.CodArea,
                     item.CodOficina,
                     item.DesOficina

                 ))
                 );

                /////////////////////////////////////////////////////////////////////////////////////////////////
                //Creamos una variable en el cual luego obtendremos lo que contiene el archivo de texto 
                string currentContent = String.Empty;
                //Creamos la cabecera del archivo texto(los títulos en la primera fila)
                string newContent = "Local;Área;Oficina;Descripción\r\n";
                if (System.IO.File.Exists(Server.MapPath("~/TBOFICINA.txt")))
                {
                    //ReadAllText lee u obtiene todo el contenido existente en el archivo de texto
                    currentContent = System.IO.File.ReadAllText(Server.MapPath("~/TBOFICINA.txt"));
                }
                //WriteAllText le sumamos o añade una linea mas al contenido ya existente en el archivo de texto
                System.IO.File.WriteAllText(Server.MapPath("~/TBOFICINA.txt"), newContent + currentContent);
                /////////////////////////////////////////////////////////////////////////////////////////////////

                // Get the file path
                var file = Server.MapPath("~/TBOFICINA.txt");
                // Append headers
                Response.AppendHeader("content-disposition", "attachment; filename=TBOFICINA.txt");
                // Open/Save dialog
                Response.ContentType = "application/octet-stream"; //--->Descargarlo con el WinOpen
                // Push it!
                Response.TransmitFile(file);

            }

            if (strTxtExportado == "TBEMPLEADO")
            {

                //La lista "listaBienesDsTxt" pasarlo al documento txt separados por punto y coma 
                System.IO.File.Create(Server.MapPath("~/TBEMPLEADO.txt")).Close();
                //Leemos row por row lo que contiene la lista
                System.IO.File.WriteAllLines(Server.MapPath("~/TBEMPLEADO.txt"), listaEmpleadoTxt
                .Select(item => string.Join(";",
                     // join with "," following properties:

                     item.CodLocal,
                     item.CodArea,
                     item.CodResponsable,
                     item.DesEmpleado
                    
                 ))
                 );

                //System.IO.File.AppendAllText(Server.MapPath("~/TBEMPLEADO.txt"), "hgfhfjhjkjkjh", Encoding.UTF8);
                /////////////////////////////////////////////////////////////////////////////////////////////////
                //Creamos una variable en el cual luego obtendremos lo que contiene el archivo de texto 
                string currentContent = String.Empty;
                //Creamos la cabecera del archivo texto(los títulos en la primera fila)
                string newContent = "Local;Área;Empleado;Descripción\r\n";
                if (System.IO.File.Exists(Server.MapPath("~/TBEMPLEADO.txt")))
                {
                    //ReadAllText lee u obtiene todo el contenido existente en el archivo de texto
                    currentContent = System.IO.File.ReadAllText(Server.MapPath("~/TBEMPLEADO.txt"));
                }
                //WriteAllText le sumamos o añade una linea mas al contenido ya existente en el archivo de texto
                System.IO.File.WriteAllText(Server.MapPath("~/TBEMPLEADO.txt"), newContent + currentContent);
                /////////////////////////////////////////////////////////////////////////////////////////////////

                // Get the file path
                var file = Server.MapPath("~/TBEMPLEADO.txt");
                // Append headers
                Response.AppendHeader("content-disposition", "attachment; filename=TBEMPLEADO.txt");
                // Open/Save dialog
                Response.ContentType = "application/octet-stream"; //--->Descargarlo con el WinOpen
                // Push it!
                Response.TransmitFile(file);


            }

            if (strTxtExportado == "TBOFICINA_TXT")
            {
                /***************************************************************************************************************
                *https://stackoverflow.com/questions/57908516/write-list-to-txt-file-separating-everything-with-a-comma
                *https://social.msdn.microsoft.com/Forums/es-ES/ed14635e-02fd-4ada-88bc-d3e065ad4a03/responsecontenttype-exportar-a-txt-excel-y-pdf?forum=netfxwebes Color columna
                *https://stackoverflow.com/questions/25718526/how-to-generate-txt-file-then-force-download-in-asp-net-web-forms
                *https://stackoverflow.com/questions/4745994/how-can-i-add-to-a-lists-first-position
                *https://stackoverflow.com/questions/18104392/adding-values-to-member-fields-of-object-in-listt-at-same-index
                ****************************************************************************************************************/
                //GENERAR ARCHIVO DE TEXTO

                //////////////////////////////////////////////
                //AÑADIR A LA LISTA PRIMERAS FILAS (titulos)
                //////////////////////////////////////////////
                listaOficina[0].CodLocal = "Local";
                listaOficina[0].CodArea = "Área";
                listaOficina[0].CodOficina = "Oficina";
                listaOficina[0].DesOficina = "Descripción";

                // La lista pasarlo al documento txt separados por comas that you're having
                System.IO.File.Create(Server.MapPath("~/TBOFICINA.txt")).Close();
                System.IO.File.WriteAllLines(Server.MapPath("~/TBOFICINA.txt"), listaOficinaTxt
                .Select(item => string.Join(";",
                // join with "," following properties:
                /////////////////////////////////
                item.CodLocal,
                item.CodArea,
                item.CodOficina,
                item.DesOficina
                /////////////////////////////////

             ))
             );
                // Get the file path
                var file = Server.MapPath("~/TBOFICINA.txt");
                // Append headers
                Response.AppendHeader("content-disposition", "attachment; filename=TBOFICINA.txt");
                // Open/Save dialog
                Response.ContentType = "application/octet-stream"; //--->Descargarlo con el WinOpen
                // Push it!
                Response.TransmitFile(file);


            }


        }

        #endregion


        #region Mant. EXPORTAR EXCEL - SISACTIVOFIJO
        //LISTAS GLOBALES Y ESTATICAS (EXCEL)
        public static IList<TablasGenerarExcel> listaBienes;
        public static IList<TablasGenerarExcel> listaBienesDs;
        public static IList<TablasGenerarExcel> listaOficina;
        public static IList<TablasGenerarExcel> listaEmpleado;

        //12.0 VENTANA VIEW
        public ActionResult ReportesExcel(string intIdMenu)
        {
            if (Auth.isAuthenticated())
            {
                intIdMenuGlo = Convert.ToInt32(intIdMenu);
                return View();
            }
            return RedirectToAction("CerrarSesion", "LoginSiscop");
        }

        //12.1
        public ActionResult GenerarListasDeCadaTabla(string strExcelExportado)
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
                if (strExcelExportado == "TBBIENES")
                {
                   
                    using (proxyRep = new ReportesSrvClient())
                    {
                        listaBienes = proxyRep.GenerarArchivosExcel(objSession, strExcelExportado, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = listaBienes.Count;

                }
                if (strExcelExportado == "TBBIENESDS")
                {

                    using (proxyRep = new ReportesSrvClient())
                    {
                        listaBienesDs = proxyRep.GenerarArchivosExcel(objSession, strExcelExportado, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = listaBienesDs.Count;
                }
                if (strExcelExportado == "TBOFICINA")
                {

                    using (proxyRep = new ReportesSrvClient())
                    {
                        listaOficina = proxyRep.GenerarArchivosExcel(objSession, strExcelExportado, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = listaOficina.Count;
                }
                if (strExcelExportado == "TBEMPLEADO")
                {

                    using (proxyRep = new ReportesSrvClient())
                    {
                        listaEmpleado = proxyRep.GenerarArchivosExcel(objSession, strExcelExportado, ref strMsgUsuario).ToList();
                        proxyRep.Close();

                    }
                    resultado = listaEmpleado.Count;

                }

            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ProcesoController.cs");
            }
           
            return Json(resultado);

        }

        //12.2
        public ActionResult ObtCantExceList()
        {
            return Json(cantEnListaExcels);
        }

        //12.3 
        public void GenerarArchivosExcel(string strExcelExportado)
        {
            /****************************************************************************************
            * En este método solo se genera 04 excels, el del boton "Generar Archivos Excel"
            * Se usan solo 4 listas de las 8 tablas. No las 8, esas se usan en el Exportar con SQL
            ****************************************************************************************/

            if (strExcelExportado == "TBBIENES")
            {

                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("Activo");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("Descripción");
                r1.Append(c2);

                Cell c3 = new Cell();
                c3.DataType = CellValues.String;
                c3.CellValue = new CellValue("Anterior");
                r1.Append(c3);

                Cell c4 = new Cell();
                c4.DataType = CellValues.String;
                c4.CellValue = new CellValue("CodLocal");
                r1.Append(c4);

                Cell c5 = new Cell();
                c5.DataType = CellValues.String;
                c5.CellValue = new CellValue("CodArea");
                r1.Append(c5);

                Cell c6 = new Cell();
                c6.DataType = CellValues.String;
                c6.CellValue = new CellValue("CodOficina");
                r1.Append(c6);

                Cell c7 = new Cell();
                c7.DataType = CellValues.String;
                c7.CellValue = new CellValue("CodEmpleado");
                r1.Append(c7);

                Cell c8 = new Cell();
                c8.DataType = CellValues.String;
                c8.CellValue = new CellValue("CodEstado");
                r1.Append(c8);

                Cell c9 = new Cell();
                c9.DataType = CellValues.String;
                c9.CellValue = new CellValue("Marca");
                r1.Append(c9);

                Cell c10 = new Cell();
                c10.DataType = CellValues.String;
                c10.CellValue = new CellValue("Modelo");
                r1.Append(c10);

                Cell c11 = new Cell();
                c11.DataType = CellValues.String;
                c11.CellValue = new CellValue("Serie");
                r1.Append(c11);

                Cell c12 = new Cell();
                c12.DataType = CellValues.String;
                c12.CellValue = new CellValue("CodTipo");
                r1.Append(c12);

                Cell c13 = new Cell();
                c13.DataType = CellValues.String;
                c13.CellValue = new CellValue("Color");
                r1.Append(c13);

                Cell c14 = new Cell();
                c14.DataType = CellValues.String;
                c14.CellValue = new CellValue("Año");
                r1.Append(c14);

                Cell c15 = new Cell();
                c15.DataType = CellValues.String;
                c15.CellValue = new CellValue("NumMotor");
                r1.Append(c15);

                Cell c16 = new Cell();
                c16.DataType = CellValues.String;
                c16.CellValue = new CellValue("NumChasis");
                r1.Append(c16);

                Cell c17 = new Cell();
                c17.DataType = CellValues.String;
                c17.CellValue = new CellValue("Dimensión");
                r1.Append(c17);

                Cell c18 = new Cell();
                c18.DataType = CellValues.String;
                c18.CellValue = new CellValue("Placa");
                r1.Append(c18);

                Cell c19 = new Cell();
                c19.DataType = CellValues.String;
                c19.CellValue = new CellValue("Observación");
                r1.Append(c19);

                Cell c20 = new Cell();
                c20.DataType = CellValues.String;
                c20.CellValue = new CellValue("FecCreación");
                r1.Append(c20);

                Cell c21 = new Cell();
                c21.DataType = CellValues.String;
                c21.CellValue = new CellValue("FecModificación");
                r1.Append(c21);

                Cell c22 = new Cell();
                c22.DataType = CellValues.String;
                c22.CellValue = new CellValue("NumPda");
                r1.Append(c22);

                Cell c23 = new Cell();
                c23.DataType = CellValues.String;
                c23.CellValue = new CellValue("FlgInventario");
                r1.Append(c23);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasGenerarExcel item in listaBienes)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.Activo);
                    r2.Append(cc1);
                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.Descripcion);
                    r2.Append(cc2);
                    Cell cc3 = new Cell();
                    cc3.DataType = CellValues.String;
                    cc3.CellValue = new CellValue(item.Anterior);
                    r2.Append(cc3);
                    Cell cc4 = new Cell();
                    cc4.DataType = CellValues.String;
                    cc4.CellValue = new CellValue(item.CodLocal);
                    r2.Append(cc4);
                    Cell cc5 = new Cell();
                    cc5.DataType = CellValues.String;
                    cc5.CellValue = new CellValue(item.CodArea);
                    r2.Append(cc5);
                    Cell cc6 = new Cell();
                    cc6.DataType = CellValues.String;
                    cc6.CellValue = new CellValue(item.CodOficina);//ubicacion
                    r2.Append(cc6);
                    Cell cc7 = new Cell();
                    cc7.DataType = CellValues.String;
                    cc7.CellValue = new CellValue(item.CodResponsable);
                    r2.Append(cc7);
                    Cell cc8 = new Cell();
                    cc8.DataType = CellValues.String;
                    cc8.CellValue = new CellValue(item.CodEstado);
                    r2.Append(cc8);
                    Cell cc9 = new Cell();
                    cc9.DataType = CellValues.String;
                    cc9.CellValue = new CellValue(item.Marca);
                    r2.Append(cc9);
                    Cell cc10 = new Cell();
                    cc10.DataType = CellValues.String;
                    cc10.CellValue = new CellValue(item.Modelo);
                    r2.Append(cc10);
                    Cell cc11 = new Cell();
                    cc11.DataType = CellValues.String;
                    cc11.CellValue = new CellValue(item.Serie);
                    r2.Append(cc11);
                    Cell cc12 = new Cell();
                    cc12.DataType = CellValues.String;
                    cc12.CellValue = new CellValue(item.CodTipo);
                    r2.Append(cc12);
                    Cell cc13 = new Cell();
                    cc13.DataType = CellValues.String;
                    cc13.CellValue = new CellValue(item.Color);
                    r2.Append(cc13);
                    Cell cc14 = new Cell();
                    cc14.DataType = CellValues.String;
                    cc14.CellValue = new CellValue(item.Anio.ToString());
                    r2.Append(cc14);
                    Cell ccc15 = new Cell();
                    ccc15.DataType = CellValues.String;
                    ccc15.CellValue = new CellValue(item.NumMotor);
                    r2.Append(ccc15);
                    Cell ccc16 = new Cell();
                    ccc16.DataType = CellValues.String;
                    ccc16.CellValue = new CellValue(item.NumChasis);
                    r2.Append(ccc16);
                    Cell ccc17 = new Cell();
                    ccc17.DataType = CellValues.String;
                    ccc17.CellValue = new CellValue(item.Dimension);
                    r2.Append(ccc17);
                    Cell ccc18 = new Cell();
                    ccc18.DataType = CellValues.String;
                    ccc18.CellValue = new CellValue(item.Placa);
                    r2.Append(ccc18);
                    Cell ccc19 = new Cell();
                    ccc19.DataType = CellValues.String;
                    ccc19.CellValue = new CellValue(item.Observacion);
                    r2.Append(ccc19);
                    Cell ccc20 = new Cell();
                    ccc20.DataType = CellValues.String;
                    ccc20.CellValue = new CellValue(item.FecCreacion);
                    r2.Append(ccc20);
                    Cell ccc21 = new Cell();
                    ccc21.DataType = CellValues.String;
                    ccc21.CellValue = new CellValue(item.FecModificacion);
                    r2.Append(ccc21);
                    Cell ccc22 = new Cell();
                    ccc22.DataType = CellValues.String;
                    ccc22.CellValue = new CellValue(item.NumPda);
                    r2.Append(ccc22);
                    Cell ccc23 = new Cell();
                    ccc23.DataType = CellValues.String;
                    ccc23.CellValue = new CellValue(item.FlgInventario);
                    r2.Append(ccc23);

                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////

                ws.Append(sd);
                //ws2.Append(sd2);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBBIENES";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                //Sheet sheet2 = new Sheet();
                //sheet2.Name = "TBBIENES";
                //sheet2.SheetId = 2;
                //sheet2.Id = wbp.GetIdOfPart(wsp2);
                sheets.Append(sheet);
                //sheets.Append(sheet2);
                wb.Append(fv);
                wb.Append(sheets);

                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();
                string fileName = "TBBIENES.xlsx";
                Response.Clear();
                byte[] dt = ms.ToArray();
                dtBienes = dt; //Para enviar por correo cuando el check "Generar envío de correo" esté habilitado
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                Response.BinaryWrite(dt);
                Response.End();

            }

            if (strExcelExportado == "TBBIENESDS")
            {
                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("Activo");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("Descripción");
                r1.Append(c2);

                Cell c3 = new Cell();
                c3.DataType = CellValues.String;
                c3.CellValue = new CellValue("Anterior");
                r1.Append(c3);

                Cell c4 = new Cell();
                c4.DataType = CellValues.String;
                c4.CellValue = new CellValue("CodLocal");
                r1.Append(c4);

                Cell c5 = new Cell();
                c5.DataType = CellValues.String;
                c5.CellValue = new CellValue("CodArea");
                r1.Append(c5);

                Cell c6 = new Cell();
                c6.DataType = CellValues.String;
                c6.CellValue = new CellValue("CodOficina");
                r1.Append(c6);

                Cell c7 = new Cell();
                c7.DataType = CellValues.String;
                c7.CellValue = new CellValue("CodEmpleado");
                r1.Append(c7);

                Cell c8 = new Cell();
                c8.DataType = CellValues.String;
                c8.CellValue = new CellValue("CodEstado");
                r1.Append(c8);

                Cell c9 = new Cell();
                c9.DataType = CellValues.String;
                c9.CellValue = new CellValue("Marca");
                r1.Append(c9);

                Cell c10 = new Cell();
                c10.DataType = CellValues.String;
                c10.CellValue = new CellValue("Modelo");
                r1.Append(c10);

                Cell c11 = new Cell();
                c11.DataType = CellValues.String;
                c11.CellValue = new CellValue("Serie");
                r1.Append(c11);

                Cell c12 = new Cell();
                c12.DataType = CellValues.String;
                c12.CellValue = new CellValue("CodTipo");
                r1.Append(c12);

                Cell c13 = new Cell();
                c13.DataType = CellValues.String;
                c13.CellValue = new CellValue("Color");
                r1.Append(c13);

                Cell c14 = new Cell();
                c14.DataType = CellValues.String;
                c14.CellValue = new CellValue("Año");
                r1.Append(c14);

                Cell c15 = new Cell();
                c15.DataType = CellValues.String;
                c15.CellValue = new CellValue("NumMotor");
                r1.Append(c15);

                Cell c16 = new Cell();
                c16.DataType = CellValues.String;
                c16.CellValue = new CellValue("NumChasis");
                r1.Append(c16);

                Cell c17 = new Cell();
                c17.DataType = CellValues.String;
                c17.CellValue = new CellValue("Dimensión");
                r1.Append(c17);

                Cell c18 = new Cell();
                c18.DataType = CellValues.String;
                c18.CellValue = new CellValue("Placa");
                r1.Append(c18);

                Cell c19 = new Cell();
                c19.DataType = CellValues.String;
                c19.CellValue = new CellValue("Observación");
                r1.Append(c19);

                Cell c20 = new Cell();
                c20.DataType = CellValues.String;
                c20.CellValue = new CellValue("DesLocal");
                r1.Append(c20);

                Cell c21 = new Cell();
                c21.DataType = CellValues.String;
                c21.CellValue = new CellValue("DesArea");
                r1.Append(c21);

                Cell c22 = new Cell();
                c22.DataType = CellValues.String;
                c22.CellValue = new CellValue("DesOficina");
                r1.Append(c22);

                Cell c23 = new Cell();
                c23.DataType = CellValues.String;
                c23.CellValue = new CellValue("DesEmpleado");
                r1.Append(c23);

                Cell c24 = new Cell();
                c24.DataType = CellValues.String;
                c24.CellValue = new CellValue("DesEstado");
                r1.Append(c24);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasGenerarExcel item in listaBienesDs)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.Activo);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.Descripcion);
                    r2.Append(cc2);

                    Cell cc3 = new Cell();
                    cc3.DataType = CellValues.String;
                    cc3.CellValue = new CellValue(item.Anterior);
                    r2.Append(cc3);

                    Cell cc4 = new Cell();
                    cc4.DataType = CellValues.String;
                    cc4.CellValue = new CellValue(item.CodLocal);
                    r2.Append(cc4);

                    Cell cc5 = new Cell();
                    cc5.DataType = CellValues.String;
                    cc5.CellValue = new CellValue(item.CodArea);
                    r2.Append(cc5);

                    Cell cc6 = new Cell();
                    cc6.DataType = CellValues.String;
                    cc6.CellValue = new CellValue(item.CodOficina);//ubicacion----
                    r2.Append(cc6);

                    Cell cc7 = new Cell();
                    cc7.DataType = CellValues.String;
                    cc7.CellValue = new CellValue(item.CodResponsable);
                    r2.Append(cc7);

                    Cell cc8 = new Cell();
                    cc8.DataType = CellValues.String;
                    cc8.CellValue = new CellValue(item.CodEstado);
                    r2.Append(cc8);

                    Cell cc9 = new Cell();
                    cc9.DataType = CellValues.String;
                    cc9.CellValue = new CellValue(item.Marca);
                    r2.Append(cc9);


                    Cell cc10 = new Cell();
                    cc10.DataType = CellValues.String;
                    cc10.CellValue = new CellValue(item.Modelo);//--10
                    r2.Append(cc10);

                    Cell cc11 = new Cell();
                    cc11.DataType = CellValues.String;
                    cc11.CellValue = new CellValue(item.Serie);
                    r2.Append(cc11);

                    Cell cc12 = new Cell();
                    cc12.DataType = CellValues.String;
                    cc12.CellValue = new CellValue(item.CodTipo);
                    r2.Append(cc12);

                    Cell cc13 = new Cell();
                    cc13.DataType = CellValues.String;
                    cc13.CellValue = new CellValue(item.Color);
                    r2.Append(cc13);

                    Cell cc14 = new Cell();
                    cc14.DataType = CellValues.String;
                    cc14.CellValue = new CellValue(item.Anio.ToString());
                    r2.Append(cc14);

                    Cell ccc15 = new Cell();
                    ccc15.DataType = CellValues.String;
                    ccc15.CellValue = new CellValue(item.NumMotor);//--15
                    r2.Append(ccc15);

                    Cell ccc16 = new Cell();
                    ccc16.DataType = CellValues.String;
                    ccc16.CellValue = new CellValue(item.NumChasis);
                    r2.Append(ccc16);

                    Cell ccc17 = new Cell();
                    ccc17.DataType = CellValues.String;
                    ccc17.CellValue = new CellValue(item.Dimension);
                    r2.Append(ccc17);

                    Cell ccc18 = new Cell();
                    ccc18.DataType = CellValues.String;
                    ccc18.CellValue = new CellValue(item.Placa);
                    r2.Append(ccc18);

                    Cell ccc19 = new Cell();
                    ccc19.DataType = CellValues.String;
                    ccc19.CellValue = new CellValue(item.Observacion);//--19
                    r2.Append(ccc19);

                    Cell ccc20 = new Cell();
                    ccc20.DataType = CellValues.String;
                    ccc20.CellValue = new CellValue(item.DesLocal);
                    r2.Append(ccc20);

                    Cell ccc21 = new Cell();
                    ccc21.DataType = CellValues.String;
                    ccc21.CellValue = new CellValue(item.DesArea);
                    r2.Append(ccc21);

                    Cell ccc22 = new Cell();
                    ccc22.DataType = CellValues.String;
                    ccc22.CellValue = new CellValue(item.DesOficina);
                    r2.Append(ccc22);

                    Cell ccc23 = new Cell();
                    ccc23.DataType = CellValues.String;
                    ccc23.CellValue = new CellValue(item.DesEmpleado);
                    r2.Append(ccc23);

                    Cell ccc24 = new Cell();
                    ccc24.DataType = CellValues.String;
                    ccc24.CellValue = new CellValue(item.DesEstado);
                    r2.Append(ccc24);

                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////

                ws.Append(sd);

                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBBIENESDS";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);
                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();
                string fileName = "TBBIENESDS.xlsx";
                Response.Clear();
                byte[] dt = ms.ToArray();
                dtBienesDs = dt; //Para enviar por correo cuando el check "Generar envío de correo" esté habilitado
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                Response.BinaryWrite(dt);
                Response.End();

            }

            if (strExcelExportado == "TBOFICINA")
            {
                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("Local");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("Área");
                r1.Append(c2);

                Cell c3 = new Cell();
                c3.DataType = CellValues.String;
                c3.CellValue = new CellValue("Oficina");
                r1.Append(c3);

                Cell c4 = new Cell();
                c4.DataType = CellValues.String;
                c4.CellValue = new CellValue("Descripción");
                r1.Append(c4);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasGenerarExcel item in listaOficina)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.CodLocal);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.CodArea);
                    r2.Append(cc2);

                    Cell cc3 = new Cell();
                    cc3.DataType = CellValues.String;
                    cc3.CellValue = new CellValue(item.CodOficina);
                    r2.Append(cc3);

                    Cell cc4 = new Cell();
                    cc4.DataType = CellValues.String;
                    cc4.CellValue = new CellValue(item.DesOficina);
                    r2.Append(cc4);

                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////

                ws.Append(sd);

                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBOFICINA";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);
                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();
                string fileName = "TBOFICINA.xlsx";
                Response.Clear();
                byte[] dt = ms.ToArray();
                dtOficina = dt; //Para enviar por correo cuando el check "Generar envío de correo" esté habilitado
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                Response.BinaryWrite(dt);
                //----------------------------------------------
                var path = @"D:\ExcelsToEmail\TBOFICINA.xlsx";
                System.IO.File.WriteAllBytes(path, dt);
                //----------------------------------------------
                Response.End();

            }

            if (strExcelExportado == "TBEMPLEADO")
            {
                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("Local");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("Área");
                r1.Append(c2);

                Cell c3 = new Cell();
                c3.DataType = CellValues.String;
                c3.CellValue = new CellValue("Empleado"); //Código
                r1.Append(c3);

                Cell c4 = new Cell();
                c4.DataType = CellValues.String;
                c4.CellValue = new CellValue("Descripción");
                r1.Append(c4);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasGenerarExcel item in listaEmpleado)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.CodLocal);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.CodArea);
                    r2.Append(cc2);

                    Cell cc3 = new Cell();
                    cc3.DataType = CellValues.String;
                    cc3.CellValue = new CellValue(item.CodResponsable);
                    r2.Append(cc3);

                    Cell cc4 = new Cell();
                    cc4.DataType = CellValues.String;
                    cc4.CellValue = new CellValue(item.DesEmpleado);
                    r2.Append(cc4);

                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////

                ws.Append(sd);

                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBEMPLEADO";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);
                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();
                string fileName = "TBEMPLEADO.xlsx";
                Response.Clear();
                byte[] dt = ms.ToArray();
                dtEmpleado = dt; //Para enviar por correo cuando el check "Generar envío de correo" esté habilitado
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                Response.BinaryWrite(dt);
                ////////////-------------------------------------
                //////////var path = @"D:\ExcelsToEmail\TBEMPLEADO.xlsx";
                //////////System.IO.File.WriteAllBytes(path, dt);
                ////////////---------------------------------------
                Response.End();

                //var ResponseContentType = Response.ContentType;
                //var ResponseAddHeader = Response.AddHeader;
                //var ResponseBinaryWrite = Response.BinaryWrite(dt);
                //var output = Response.ContentType;
                //var path = @"E:\testpdf.pdf";
                //async Task FileIndex()
                //{
                //    if (response.IsSuccessStatusCode)
                //    {
                //        var output = await response.Content.ReadAsByteArrayAsync();
                //        //var path = @"E:\testpdf.pdf";
                //        var path = @"testpdf.pdf";
                //        System.IO.File.WriteAllBytes(path, output);
                //    }
                //}

            }

            if (strExcelExportado == "TBLOCAL")
            {
                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("Código");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("Descripción");
                r1.Append(c2);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasGenerarExcel item in listaEmpleado)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.CodLocal);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.DesLocal);
                    r2.Append(cc2);


                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////

                ws.Append(sd);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBLOCAL";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);
                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();
                string fileName = "TBLOCAL.xlsx";
                Response.Clear();
                byte[] dt = ms.ToArray();

                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                Response.BinaryWrite(dt);
                ////////////-------------------------------------
                //////////var path = @"D:\ExcelsToEmail\TBLOCAL.xlsx";
                //////////System.IO.File.WriteAllBytes(path, dt);
                ////////////---------------------------------------
                Response.End();

            }

            if (strExcelExportado == "TBAREAS")
            {
                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("Local");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("Código");
                r1.Append(c2);

                Cell c3 = new Cell();
                c3.DataType = CellValues.String;
                c3.CellValue = new CellValue("Descripción");
                r1.Append(c3);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasGenerarExcel item in listaEmpleado)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.CodLocal);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.CodArea);
                    r2.Append(cc2);

                    Cell cc3 = new Cell();
                    cc3.DataType = CellValues.String;
                    cc3.CellValue = new CellValue(item.DesArea);
                    r2.Append(cc3);


                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////

                ws.Append(sd);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBAREAS";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);
                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();
                string fileName = "TBAREAS.xlsx";
                Response.Clear();
                byte[] dt = ms.ToArray();

                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                Response.BinaryWrite(dt);
                //////////////----------------------------------------------
                ////////////var path = @"D:\ExcelsToEmail\TBAREAS.xlsx";
                ////////////System.IO.File.WriteAllBytes(path, dt);
                //////////////----------------------------------------------
                Response.End();

            }

            if (strExcelExportado == "TBESTADO")
            {
                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("Codigo");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("Descripcion");
                r1.Append(c2);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasGenerarExcel item in listaEmpleado)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.CodEstado);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.DesEstado);
                    r2.Append(cc2);

                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////

                ws.Append(sd);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBESTADO";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);
                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();
                string fileName = "TBESTADO.xlsx";
                Response.Clear();
                byte[] dt = ms.ToArray();

                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                Response.BinaryWrite(dt);
                //////////////----------------------------------------------
                ////////////var path = @"D:\ExcelsToEmail\TBESTADO.xlsx";
                ////////////System.IO.File.WriteAllBytes(path, dt);
                //////////////----------------------------------------------
                Response.End();

            }

            if (strExcelExportado == "TBTIPO")
            {
                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("Codigo");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("Descripcion");
                r1.Append(c2);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasGenerarExcel item in listaEmpleado)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.CodTipo);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.DesTipo);
                    r2.Append(cc2);

                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////

                ws.Append(sd);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBTIPO";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);
                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();
                string fileName = "TBTIPO.xlsx";
                Response.Clear();
                byte[] dt = ms.ToArray();

                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                Response.BinaryWrite(dt);
                //////////////----------------------------------------------
                ////////////var path = @"D:\ExcelsToEmail\TBTIPO.xlsx";
                ////////////System.IO.File.WriteAllBytes(path, dt);
                //////////////----------------------------------------------
                Response.End();

            }

            if (strExcelExportado == "TBENDIDAD")
            {
                //GENERAR EXCEL
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument xl = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = xl.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();

                //First sheet
                SheetData sd = new SheetData();
                Row r1 = new Row() { RowIndex = 1u };

                //LLENAMOS LA CABECERA
                Cell c1 = new Cell();
                c1.DataType = CellValues.String;
                c1.CellValue = new CellValue("Codigo");
                r1.Append(c1);

                Cell c2 = new Cell();
                c2.DataType = CellValues.String;
                c2.CellValue = new CellValue("Descripcion");
                r1.Append(c2);

                sd.Append(r1);

                //LLENAMOS EL DETALLE
                int fila = 1;

                foreach (TablasGenerarExcel item in listaEmpleado)
                {
                    Row r2 = new Row() { RowIndex = (UInt32)fila + 1 };

                    Cell cc1 = new Cell();
                    cc1.DataType = CellValues.String;
                    cc1.CellValue = new CellValue(item.CodEntidad);
                    r2.Append(cc1);

                    Cell cc2 = new Cell();
                    cc2.DataType = CellValues.String;
                    cc2.CellValue = new CellValue(item.DesEntidad);
                    r2.Append(cc2);

                    sd.Append(r2);

                    fila++;
                }

                ////////////////////////////////////////////////////////////////////

                ws.Append(sd);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = "TBENDIDAD";
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);
                xl.WorkbookPart.Workbook = wb;
                xl.WorkbookPart.Workbook.Save();
                xl.Close();
                string fileName = "TBENDIDAD.xlsx";
                Response.Clear();
                byte[] dt = ms.ToArray();

                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                Response.BinaryWrite(dt);
                ////////////////----------------------------------------------
                //////////////var path = @"D:\ExcelsToEmail\TBENDIDAD.xlsx";
                //////////////System.IO.File.WriteAllBytes(path, dt);
                ////////////////----------------------------------------------
                Response.End();

            }


        }

        //12.4
        public ActionResult IniciarGenerarArchivosExcel(string strExcelExportado)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();
            string strMsgUsuario = "";

            IList<TablasGenerarExcel> listaExcel = new List<TablasGenerarExcel>();

            try
            {
                using (proxyRep = new ReportesSrvClient())
                {
                    listaExcel = proxyRep.GenerarArchivosExcel(objSession, strExcelExportado, ref strMsgUsuario).ToList();

                    proxyRep.Close();

                }
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ProcesoController.cs");
            }

            return Json(listaExcel);

        }

        //16.5  Prueba Eliminable
        public static void ExportToExcel(DataTable dt)
        {
            StreamWriter wr = new StreamWriter(@"D:\\" + "PRUEBA" + ".xls");
            try
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    wr.Write(dt.Columns[i].ToString().ToUpper() + "\t");
                }

                wr.WriteLine();

                //write rows to excel file
                for (int i = 0; i < (dt.Rows.Count); i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Rows[i][j] != null)
                        {
                            wr.Write(Convert.ToString(dt.Rows[i][j]) + "\t");
                        }
                        else
                        {
                            wr.Write("\t");
                        }
                    }
                    //go to next line
                    wr.WriteLine();
                }
                //close file
                wr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion ReportesExel


        // GET: Reportes
        public ActionResult Reportes(string intIdMenu)
        {
            if (Auth.isAuthenticated())
            {
                intIdMenuGlo = Convert.ToInt32(intIdMenu);
                return View();
            }
            return RedirectToAction("CerrarSesion", "LoginSiscop");
        }

        public JsonResult GetCampJerare(int IntIdJerOrg)
        {
            string strMsgUsuario = "";
            List<UnidadOrg> lista_Unid_Sup = new List<UnidadOrg>();

            try
            {
                using (proxyOrg = new OrganizacionSrvClient())
                {
                    lista_Unid_Sup = proxyOrg.ListarCampoUnidSup(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), IntIdJerOrg, ref strMsgUsuario).ToList();
                    proxyOrg.Close();
                    return Json(lista_Unid_Sup);
                }
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReportesController.cs");
            }
            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        }

        public JsonResult ConsultaReporte(int cboUniOrg, string filtroCalculo, int cboPlanilla, int cboCategoria, bool cesado, int estado, List<int> listGrupoLiq)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();

            string strMsjUsuario = "";
            IList<Reporte> lista = new List<Reporte>();

            try
            {
                using (proxyRep = new ReportesSrvClient())
                {
                    if (listGrupoLiq == null)
                    {
                        listGrupoLiq = new List<int>();
                    }
                    lista = proxyRep.ConsultaReporte(objSession, cboUniOrg, filtroCalculo, cboPlanilla, cboCategoria, cesado, estado, listGrupoLiq.ToArray(), ref strMsjUsuario);
                }
                return Json(lista);
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReportesController.cs");
            }
            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        }

        public JsonResult GetCampPlanilla(List<int> lstIntIdUniOrg)
        {
            if (lstIntIdUniOrg == null)
                lstIntIdUniOrg = new List<int>();
            string strMsgUsuario = "";
            List<Planilla> lista_Planilla = new List<Planilla>();

            try
            {
                using (proxyRep = new ReportesSrvClient())
                {
                    lstIntIdUniOrg.ForEach(x => {
                        var tmp = proxyRep.ListarCampoPlanilla(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(), x, ref strMsgUsuario).ToList();
                        lista_Planilla.AddRange(tmp);
                    });
                    proxyRep.Close();
                }

                return Json(lista_Planilla);

            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReportesController.cs");
            }
            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        }

        public JsonResult GetCampFizcalizacion()
        {
            string strMsgUsuario = "";
            List<TGTipoEN> lista_Fizcalizacion = new List<TGTipoEN>();

            try
            {
                using (proxyRep = new ReportesSrvClient())
                {
                    lista_Fizcalizacion = proxyRep.ListarCampoFizcalizacion(Auth.intIdSesion(), intIdMenuGlo, Auth.intIdSoft(),ref strMsgUsuario).ToList();
                    proxyRep.Close();

                    return Json(lista_Fizcalizacion);
                }
            }
            catch (Exception ex)
            { 
                Log.AlmacenarLogError(ex, "ReportesController.cs");
            }

            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        }

        public ActionResult Graficos(string intIdMenu)
        {
            if (Auth.isAuthenticated())
            {
                intIdMenuGlo = Convert.ToInt32(intIdMenu);
                return View();
            }

            return RedirectToAction("CerrarSesion", "LoginSiscop");
        }

        public JsonResult GetReportes()
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = intIdMenuGlo;
            objSession.intIdUsuario = Auth.intIdUsuario();

            string strMsjUsuario = "";
            IList<ReporteM> lista = new List<ReporteM>();
            try
            {
                using (proxyRep = new ReportesSrvClient())
                {
                    lista = proxyRep.GetReportes(objSession, ref strMsjUsuario);
                }

                return Json(lista);
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReportesController.cs");
            }

            return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        }

        public static DataTable ConvertDataTable<TItemType>(List<TItemType> list)
        {
            DataTable convertedData = new DataTable();

            // Get List Item Properties info
            Type itemType = typeof(TItemType);
            PropertyInfo[] publicProperties =
                // Only public non inherited properties
                itemType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            // Create Table Columns
            foreach (PropertyInfo property in publicProperties)
            {
                // DataSet does not support System.Nullable<>
                if (property.PropertyType.IsGenericType &&
                    property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    // Set the column datatype as the nullable value type
                    convertedData.Columns.Add(property.Name, property.PropertyType.GetGenericArguments()[0]);
                }
                else
                {
                    convertedData.Columns.Add(property.Name, property.PropertyType);
                }
            }

            // Convert the Data
            foreach (TItemType item in list)
            {
                object[] rowData = new object[convertedData.Columns.Count];
                int rowDataIndex = 0;
                // Iterate through Item Properties
                foreach (PropertyInfo property in publicProperties)
                {
                    // Add a single cell data
                    rowData[rowDataIndex] = property.GetValue(item, null);
                    rowDataIndex++;
                }
                convertedData.Rows.Add(rowData);
            }

            return convertedData;
        }

        public void llenarListaEmpleados(List<int> lista, List<int> lista2)
        {
            listEmpleados = lista;
            listConceptos = lista2;
        }

        #region ReportesComedor
        public ActionResult ReportesComedor(string intIdMenu)
        {
            if (Auth.isAuthenticated())
            {
                intIdMenuGlo = Convert.ToInt32(intIdMenu);
                return View();
            }
            return RedirectToAction("CerrarSesion", "LoginSiscop");
        }
        #endregion ReportesComedor

        #region ENVIAR CORREO - SISACTIVOFIJO

        ////////////ELIMINAR LO QUE EXISTE EN EL DIRECTORIO "DirGenerarExcelToEmail" //NO se pudo eliminar debido al IIS Express
        //////////public ActionResult eliminarTodoExcel()
        //////////{
        //////////    //OBTENER LA RUTA 
        //////////    string strRutaDir = "";
        //////////    strRutaDir = ConfigurationManager.AppSettings["rutaGenerarExcelToEmail"];
        //////////    string rutaDeExcelsToEmail = Path.Combine(HttpContext.Request.MapPath(strRutaDir));

        //////////    //ELIMINAR TODO LO QUE EXISTE EN ESA RUTA
        //////////    string rutaDeExcelsToEmail_ = rutaDeExcelsToEmail;
        //////////    //Elimina "Todos los archivos sin importar ni extension, ni nombre"
        //////////    DirectoryInfo di = new DirectoryInfo(rutaDeExcelsToEmail_);
        //////////    foreach (FileInfo file in di.GetFiles())
        //////////    {
        //////////        file.Delete();
        //////////    }

        //////////    return Json(1);

        //////////}


        #endregion








        ////////////////////////////////////////////////////////////HGM_AÑADIDO_19.08.2021_15:51:08 

        //////public ImportarExcelBL objImportarExcelBL = new ImportarExcelBL();




        ////////16.6 //ESTA SIENDO CAMBIADO POR OTRO GENRAL PARA ESCEL Y TXT
        //////public JsonResult EnviarCuatroExcelsPorCorreo2(string strEmailDestino, string idRadioCheck)
        //////{
        //////    //OBTENER LA RUTA 
        //////    string strRutaDir = "";
        //////    strRutaDir = ConfigurationManager.AppSettings["rutaGenerarExcelToEmail"];
        //////    string rutaDeExcelsToEmail = Path.Combine(HttpContext.Request.MapPath(strRutaDir));
        //////    //OBJETO SESSION
        //////    Dominio.Entidades.Session_Movi objSession = new Dominio.Entidades.Session_Movi();
        //////    objSession.intIdSesion = Auth.intIdSesion();
        //////    objSession.intIdSoft = Auth.intIdSoft();
        //////    objSession.intIdMenu = intIdMenuGlo;
        //////    objSession.intIdUsuario = Auth.intIdUsuario();

        //////    CustomResponse result = new CustomResponse();
        //////    string strMsgUsuario = "";
        //////    Dictionary<string, string> obj = new Dictionary<string, string>();

        //////    /*msg.Attachments.Add(new Attachment(@"C:\temp\myreport.log"));*/

        //////    try
        //////    {
        //////        //using (proxyRep = new ReportesSrvClient())
        //////        //{
        //////            obj = objImportarExcelBL.ToEmailEnviarExcelPorCorreo(objSession, strEmailDestino, rutaDeExcelsToEmail
        //////                                                      , dtBienes, dtBienesDs, dtOficina, dtEmpleado, dtLocal
        //////                                                      , dtAreas, dtEstado, dtTipo, dtEntidad
        //////                                                      , txtBienes
        //////                                                      , txtBienesDs
        //////                                                      , txtOficina
        //////                                                      , txtEmpleado
        //////                                                      , idRadioCheck
        //////                                                      , ref strMsgUsuario); //HGM1

        //////        //    proxyRep.Close();

        //////        //}

        //////        if (strMsgUsuario.Contains("Se envió el correo con credenciales."))
        //////        {
        //////            if (idRadioCheck == "chck_excel")
        //////            {
        //////                result.type = "success";
        //////                result.message = "El envío de los Excel ha sido procesado exitosamente.";
        //////            }
        //////            else if (idRadioCheck == "chck_excel")
        //////            {
        //////                result.type = "success";
        //////                result.message = "El envío de los Formatos Txt ha sido procesado exitosamente.";
        //////            }
        //////            else
        //////            {
        //////                result.type = "success";
        //////                result.message = "El envío de los Excel y de los Formatos Txt ha sido procesado exitosamente.";
        //////            }

        //////        }

        //////        else
        //////        {
        //////            result.type = "info";
        //////            result.message = "Ocurrió un error al enviar el correo"; //"Ocurrio un error al procesar envío";

        //////        }

        //////        return Json(result);

        //////    }
        //////    catch (Exception ex)
        //////    {
        //////        Log.AlmacenarLogError(ex, "PersonalController.cs");
        //////    }
        //////    return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
        //////}








    }
}
