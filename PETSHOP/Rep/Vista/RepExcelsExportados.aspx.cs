using CBX_Web_PetShopWeb.Controllers;
using CBX_Web_PetShopWeb.swReportes;
using CrystalDecisions.CrystalReports.Engine;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Traer lista de la Ventana Principal
using System.Web.Mvc;




namespace CBX_Web_PetShopWeb.Rep.Vista
{

    //public class PersonalController : Controller
    //{

    //}

     public partial class RepExcelsExportados : System.Web.UI.Page 
    {
        private ReportesSrvClient proxyRep;
        private ReportDocument Rel;

        //LISTAS GLOBALES Y ESTATICAS
        public static IList<ReporteExcelsExportados> listaBienes;
        public static IList<ReporteExcelsExportados> listaBienesDs;
        public static IList<ReporteExcelsExportados> listaOficina;
        public static IList<ReporteExcelsExportados> listaEmpleado;


        //LISTA ESTATICA
        public static List<listado_ventana_principal> listadoVentanaPricipal_;

        //////LISTADO DESDE EL JS CON UN POST
        [System.Web.Services.WebMethod]
        public static void ListaJSDashboard(List<listado_ventana_principal> listadoVentanaPricipal)
        {

            listadoVentanaPricipal_ = listadoVentanaPricipal; 

        }

        //CLASE MODELO 
        public class listado_ventana_principal
        {
            public string strTitulo         { get; set; }
            public string strValor          { get; set; }
            public string strCalculadoFecha { get; set; }
            
        }



        //[System.Web.Services.WebMethod]
        //public static void DeleteRecord(int id)
        //{
        //    var abc = "prueba";
        //}
        //[System.Web.Services.WebMethod]
        //public int reportVentanaPrincipal_SAF(IList<object> arrayEncabezadoCrystal)
        //{
        //    //int intResult = 1;
        //    //string strMsjDB = "";
        //    return 1;// Json(intResult);
        //}
        //[System.Web.Services.WebMethod]
        //public static string SendMyEmail(string EmailFromAddress, string EmailFromName, string EmailSubject, string EmailBody)
        //{
        //    //return "data from server: " + Environment.NewLine +
        //    //        "EmailFromAddress = " + EmailFromAddress + Environment.NewLine +
        //    //        "from = " + EmailFromName + Environment.NewLine +
        //    //        "from = " + EmailSubject + Environment.NewLine +
        //    //        "from = " + EmailBody;
        //}


        protected void Page_PreInit(object sender, EventArgs e)
        {
            Container.Visible = false;
            //string arrayEncabezadoCrystal
            string  strExcelExportado = Request.QueryString["strExcelExportado"];
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = 0;
            string strMsgUsuario = "";
            List<ReporteExcelsExportados> list = new List<ReporteExcelsExportados>();

            using (proxyRep = new ReportesSrvClient())
            {
                try
                {

                    {

                             if (strExcelExportado == "TBBIENES")
                        {
                            list = proxyRep.ReporteDeExcelsExportados(objSession, strExcelExportado, ref strMsgUsuario).ToList();
                            DataTable tb = ConvertDataTable(list);

                            if (list.Count > 0)
                            {
                                Rel = new ReportDocument();
                                Rel.Load(Server.MapPath("~/Rep/CrystalRep/ExcelExportados/RepTBBIENES.rpt"));
                                Rel.SetDataSource(tb);
                                if (Request.QueryString["pdf"] != null)
                                {
                                    ExportPDF(Rel, strExcelExportado);
                                }
                                ReporteExcelExp.ReportSource = Rel;
                                ReporteExcelExp.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                                ReporteExcelExp.HasToggleGroupTreeButton = false;
                            }
                            else
                            {
                                Container.Visible = true;
                                txtMensaje.InnerHtml = strExcelExportado + " no tiene datos.";
                            }

                        }
                        else if (strExcelExportado == "TBBIENESDS")
                        {
                            list = proxyRep.ReporteDeExcelsExportados(objSession, strExcelExportado, ref strMsgUsuario).ToList();
                            DataTable tb = ConvertDataTable(list);

                            if (list.Count > 0)
                            {
                                Rel = new ReportDocument();
                                Rel.Load(Server.MapPath("~/Rep/CrystalRep/ExcelExportados/RepTBBIENESDS.rpt"));
                                Rel.SetDataSource(tb);
                                if (Request.QueryString["pdf"] != null)
                                {
                                    ExportPDF(Rel, strExcelExportado);
                                }
                                ReporteExcelExp.ReportSource = Rel;
                                ReporteExcelExp.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                                ReporteExcelExp.HasToggleGroupTreeButton = false;
                            }
                            else
                            {
                                Container.Visible = true;
                                txtMensaje.InnerHtml = strExcelExportado + " no tiene datos.";
                            }
                        }
                        else if (strExcelExportado == "TBOFICINA")
                        {
                            list = proxyRep.ReporteDeExcelsExportados(objSession, strExcelExportado, ref strMsgUsuario).ToList();
                            DataTable tb = ConvertDataTable(list);
                            if (list.Count > 0)
                            {
                                Rel = new ReportDocument();
                                Rel.Load(Server.MapPath("~/Rep/CrystalRep/ExcelExportados/RepTBOFICINA.rpt"));
                                Rel.SetDataSource(tb);
                                ReporteExcelExp.ReportSource = Rel;
                                if (Request.QueryString["pdf"] != null)
                                {
                                    ExportPDF(Rel, strExcelExportado);
                                }
                                ReporteExcelExp.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                                ReporteExcelExp.HasToggleGroupTreeButton = false;
                            }
                            else
                            {
                                Container.Visible = true;
                                txtMensaje.InnerHtml = strExcelExportado + " no tiene datos.";
                            }
                        }
                        else if (strExcelExportado == "TBEMPLEADO")
                        {
                            list = proxyRep.ReporteDeExcelsExportados(objSession, strExcelExportado, ref strMsgUsuario).ToList();
                            DataTable tb = ConvertDataTable(list);
                            if (list.Count > 0)
                            {
                                Rel = new ReportDocument();
                                Rel.Load(Server.MapPath("~/Rep/CrystalRep/ExcelExportados/RepTBEMPLEADO.rpt"));
                                Rel.SetDataSource(tb);
                                if (Request.QueryString["pdf"] != null)
                                {
                                    ExportPDF(Rel, strExcelExportado);
                                }
                                ReporteExcelExp.ReportSource = Rel;
                                ReporteExcelExp.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                                ReporteExcelExp.HasToggleGroupTreeButton = false;
                            }
                            else
                            {
                                Container.Visible = true;
                                txtMensaje.InnerHtml = strExcelExportado + " no tiene datos.";
                            }

                        }


                        else if (strExcelExportado == "REPORTE_VENTANA_PRINCIPAL")
                        {
                            //list = proxyRep.ReporteDeExcelsExportados(objSession, strExcelExportado, ref strMsgUsuario).ToList();
                            DataTable tb = ConvertDataTable(listadoVentanaPricipal_);
                            if (listadoVentanaPricipal_.Count > 0)
                            {
                                Rel = new ReportDocument();
                                Rel.Load(Server.MapPath("~/Rep/CrystalRep/VentanaPrincipal/RepVentanaPrincipal.rpt"));
                                Rel.SetDataSource(tb);
                                if (Request.QueryString["pdf"] != null)
                                {
                                    ExportPDF(Rel, strExcelExportado);
                                }
                                ReporteExcelExp.ReportSource = Rel;
                                ReporteExcelExp.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                                ReporteExcelExp.HasToggleGroupTreeButton = false;
                            }
                            else
                            {
                                Container.Visible = true;
                                txtMensaje.InnerHtml = strExcelExportado + " no tiene datos.";
                            }

                        }


                    }

                }
                catch (Exception ex)
                {
                    Container.Visible = true;
                    txtMensaje.InnerHtml = "Ocurrió un problema.";
                    Log.AlmacenarLogError(ex, "RepExcelsExportados.aspx.cs");
                }
            }
        }


        /*******************************************************************


        protected void Page_PreInit(object sender, EventArgs e)
        {
            Container.Visible = false;
            string bCosto = Request.QueryString["bitCosto"];
            string intMarcador = Request.QueryString["intMarcador"];
            string intTipoServicio = Request.QueryString["intTipoServicio"];
            string intTipoMenu = Request.QueryString["intTipoMenu"];
            string DesMarcador = Request.QueryString["DesMarcador"];
            string DesServicio = Request.QueryString["DesServicio"];

            string filtrojer_ini = Request.QueryString["filtrojer_ini"];
            string filtrojer_fin = Request.QueryString["filtrojer_fin"];

            bool bitCosto = bool.Parse(bCosto);

            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = 0;

            string strMsgUsuario = "";
            List<ReporteExcelExportado> list = new List<ReporteExcelExportado>();
            List<int> listEmpleados = ReportesController.listEmpleados;

            using (proxyRep = new ReportesSrvClient())
            {
                try
                {
                    ////list = proxyRep.ReporteDiarioComedor(objSession, listEmpleados.ToArray(), bitCosto, filtrojer_ini, filtrojer_fin, ref strMsgUsuario, int.Parse(intTipoServicio), int.Parse(intTipoMenu), int.Parse(intMarcador)).ToList();
                    list = proxyRep.ReporteExcelExportado(objSession, listEmpleados.ToArray(), bitCosto, filtrojer_ini, filtrojer_fin, ref strMsgUsuario, int.Parse(intTipoServicio), int.Parse(intTipoMenu), int.Parse(intMarcador)).ToList();
                    ////////////DataTable tb = ConvertDataTable(list);

                    if (list.Count > 0)
                    {
                        Rel = new ReportDocument();

                        if (bitCosto)
                        {
                            //COLOCAL EL RPT DE TBBIENES
                            //Rel.Load(Server.MapPath("~/Rep/CrystalRep/Comedor/RepConsumoDiarioCosto.rpt"));
                        }
                        else
                        {

                            //Rel.Load(Server.MapPath("~/Rep/CrystalRep/Comedor/RepConsumoDiario.rpt"));
                        }

                        //////////Rel.SetDataSource(tb);
                        Rel.SetParameterValue("FecIni", Convert.ToDateTime(filtrojer_ini));
                        Rel.SetParameterValue("FecFin", Convert.ToDateTime(filtrojer_fin));


                        Rel.SetParameterValue("DesMarcador", DesMarcador);
                        Rel.SetParameterValue("DesServicio", DesServicio);


                        if (Request.QueryString["pdf"] != null)
                        {
                            ExportPDF(Rel, bitCosto);
                        }
                        if (Request.QueryString["excel"] != null)
                        {
                            //////////ExportExcel(Rel, bitCosto);
                        }

                        ReporteDiario.ReportSource = Rel;
                        ReporteDiario.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                        ReporteDiario.HasToggleGroupTreeButton = false;
                    }
                    else
                    {
                        Container.Visible = true;
                        txtMensaje.InnerHtml = "No existen datos.";
                    }
                }
                catch (Exception ex)
                {
                    Container.Visible = true;
                    txtMensaje.InnerHtml = "Ocurrió un problema.";
                    Log.AlmacenarLogError(ex, "RepConsumoDiarioCosto.aspx.cs");
                }
            }
        }



        *******************************************************************/


        protected void Page_Unload(object sender, EventArgs e)
        {
            if (Rel != null)
            {
                if (Rel.IsLoaded)
                {
                    Rel.Close();
                    Rel.Dispose();
                }
            }
        }

        public void ExportPDF(ReportDocument Rel, string strExcelExportado)
        {

            BinaryReader stream = new BinaryReader(Rel.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat));
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.BinaryWrite(stream.ReadBytes(Convert.ToInt32(stream.BaseStream.Length)));
  
            if (strExcelExportado == "TBBIENES")
            {
                Response.AddHeader("content-disposition", @" attachment; filename=""Reporte TBBIENES.pdf"" ");
            }
            if (strExcelExportado == "TBBIENESDS")
            {
                Response.AddHeader("content-disposition", @" attachment; filename=""Reporte TBBIENESDS.pdf"" ");
            }
            if (strExcelExportado == "TBOFICINA")
            {
                Response.AddHeader("content-disposition", @" attachment; filename=""Reporte TBOFICINA.pdf"" ");
            }
            if (strExcelExportado == "TBEMPLEADO")
            {
                Response.AddHeader("content-disposition", @" attachment; filename=""TBEMPLEADO.pdf"" ");
            }

            Response.Flush();
            Response.Close();
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



        /**
public void ExportExcel(ReportDocument Rel, bool bitCosto)
{
    BinaryReader stream = new BinaryReader(Rel.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel));
    Response.ClearContent();
    Response.ClearHeaders();
    Response.ContentType = "application/vnd.ms-excel";
    Response.BinaryWrite(stream.ReadBytes(Convert.ToInt32(stream.BaseStream.Length)));
    //Response.AddHeader("content-disposition", @"attachment;filename=""Reporte Consumo Diario.xls""");
    if (bitCosto)
    {
        Response.AddHeader("content-disposition", @"attachment;filename=""Reporte Consumo Diario - Costeado.xls""");
    }
    else
    {
        Response.AddHeader("content-disposition", @"attachment;filename=""Reporte Consumo Diario.xls""");
    }
    Response.Flush();
    Response.Close();
}

**/

    }
}
