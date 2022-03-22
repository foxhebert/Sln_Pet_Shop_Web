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

namespace CBX_Web_PetShopWeb.Rep.Vista
{
    public partial class RepConsumoDiarioCosto : System.Web.UI.Page
    {
        private ReportesSrvClient proxyRep;
        private ReportDocument Rel;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Container.Visible = false;
            //string marca_v = Request.QueryString["marca"];
            //int estado = Int32.Parse(Request.QueryString["estado"]);
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
            List<ReporteDiarioComedor> list = new List<ReporteDiarioComedor>();
            List<int> listEmpleados = ReportesController.listEmpleados;

            using (proxyRep = new ReportesSrvClient())
            {
                try
                {

                    list = proxyRep.ReporteDiarioComedor(objSession, listEmpleados.ToArray(), bitCosto, filtrojer_ini, filtrojer_fin, ref strMsgUsuario, int.Parse(intTipoServicio), int.Parse(intTipoMenu), int.Parse(intMarcador)).ToList();
                    DataTable tb = ConvertDataTable(list);

                    if (list.Count > 0)
                    {
                        Rel = new ReportDocument();

                        if (bitCosto)
                        {

                            Rel.Load(Server.MapPath("~/Rep/CrystalRep/Comedor/RepConsumoDiarioCosto.rpt"));
                        }
                        else
                        {

                            Rel.Load(Server.MapPath("~/Rep/CrystalRep/Comedor/RepConsumoDiario.rpt"));
                        }

                        Rel.SetDataSource(tb);
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
                            ExportExcel(Rel, bitCosto);
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

        public void ExportPDF(ReportDocument Rel, bool bitCosto)
        {

            BinaryReader stream = new BinaryReader(Rel.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat));
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.BinaryWrite(stream.ReadBytes(Convert.ToInt32(stream.BaseStream.Length)));
            //Response.AddHeader("content-disposition", @"attachment;filename=""Reporte Consumo Diario.pdf""");
            if (bitCosto)
            {
                Response.AddHeader("content-disposition", @"attachment;filename=""Reporte Consumo Diario - Costeado.pdf""");
            }
            else
            {
                Response.AddHeader("content-disposition", @"attachment;filename=""Reporte Consumo Diario.pdf""");
            }


            Response.Flush();
            Response.Close();
        }

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

    }
}
