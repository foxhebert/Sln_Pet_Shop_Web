
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
//using System.Drawing;
using System.Configuration;

//ENVIO A CORREO
using System.Net.Mail;
using System.Net;







namespace CBX_Web_PetShopWeb.Rep.Vista
{

     public partial class RepGenerarCotizacion  : System.Web.UI.Page //RepInventarioPorLineaProduccion //RepAccesoWeb
    {



        //LISTA ESTATICA
        public static List<listado_cabecera_cotiz> listadoCabecera_;

        //LISTADO DESDE EL JS CON UN POST //DeleteRecord
        [System.Web.Services.WebMethod]
        public static void ListaCabeceraCotiz(List<listado_cabecera_cotiz> listadoCabeceraCotiz)
        {
            listadoCabecera_ = listadoCabeceraCotiz;
        }

        //CLASE MODELO PARA EL LISTADO DESDE EL JS
        public class listado_cabecera_cotiz
        {
            public string rucCliente { get; set; }
            public string nomCliente { get; set; }
            public string condVenta  { get; set; }
            public string moneda     { get; set; }
            public string vendedor   { get; set; }
            public string dirCliente { get; set; }
            public string tlfCliente { get; set; }

            //  "rucCliente" : "12315" //_rucCliente,
            //, "nomCliente" : "Hebert" //_nomCliente,
            //, "condVenta"  : "V001" //_condVenta,
            //, "moneda"     : "S" //_moneda,
            //, "vendedor"   : "Vendedor01" //_vendedor,
            //, "dirCliente" : "AV Lima" //_dirEntCliente,
            //, "tlfCliente" : "99999999" //_tlfCliente,

        }






        //LISTA ESTATICA
        public static List<listado_detalle_cotiz> listaDetalleComp;
           
        //List<wsNavautil.Usuario> list = new List<Dominio.Entidades.ASISTENCIA_CRYSTAL>();
        //CLASE MODELO PARA EL LISTADO DESDE EL JS
        public class listado_detalle_cotiz
        {
        public string   idProdu       { get; set; }
        public string   codProdu      { get; set; }
        public string   cantProdu     { get; set; }
        public string   descProdu     { get; set; }
        public string   UM            { get; set; }
        public string   marcaProdu    { get; set; }
        public string   nomfam        { get; set; }
        public string   nomsub        { get; set; }
        public string   nomgrup       { get; set; }
        public string   stockFisico   { get; set; }
        public string   stockDispon   { get; set; }
        public string   dsctPercent   { get; set; }
        public string   precio        { get; set; }
        public string   cost          { get; set; }
        public string   msto          { get; set; }
        public string   moneitem      { get; set; }
        public string   aigv          { get; set; }
        public string   tota          { get; set; }
        public string   totn          { get; set; }
       }
        [System.Web.Services.WebMethod]
        public static void ListaDetalleCotiz(List<listado_detalle_cotiz> listDetalleComprobante)
        {
            listaDetalleComp = listDetalleComprobante;
        }

        private ReportDocument Rel;

        protected void Page_PreInit(object sender, EventArgs e)
        {





            Container.Visible = false;
            //string arrayEncabezadoCrystal
            //int zoomLevel = int.Parse((Request.QueryString["zoomLevel"]));
            //string chkConFoto = Request.QueryString["chkConFoto"];

            string filtroDeReporte = Request.QueryString["filtroDeReporte"];
            string valorSubTotal   = Request.QueryString["valorSubTotal"];
            string valorTotalIgv   = Request.QueryString["valorTotalIgv"];
            string valorTotal      = Request.QueryString["valorTotal"];
            string vendedor        = Request.QueryString["vendedor"];
            string condVenta       = Request.QueryString["condVenta"];
            string moneda          = Request.QueryString["moneda"];
            string validez         = Request.QueryString["validez"];
            string correlativo     = Request.QueryString["correlativo"];
            string dateTimeVenta   = Request.QueryString["dateTimeVenta"];
            string strEmailDestino = Request.QueryString["strEmailDestino"];
            string strMetodoPago   = Request.QueryString["strMetodoPago"];

            ////////añadir parte decimal
            if (!valorSubTotal.Contains("."))
            {
                valorSubTotal = valorSubTotal + ".00";
            }
            if (!valorTotalIgv.Contains("."))
            {
                valorTotalIgv = valorTotalIgv + ".00";
            }
            if (!valorTotal.Contains("."))
            {
                valorTotal = valorTotal + ".00";
            }

            try
            {
                //////////añadido 02.11.2021
                ////////List<Emisor> DatosEmisor = new List<Emisor>();
                ////////DatosEmisor = LoginController.DatosEmisor;
                //////////añadido 02.11.2021

                Controllers.ProcesosController.listado_cabecera_cotiz DatosEncabezado = new Controllers.ProcesosController.listado_cabecera_cotiz();
                DatosEncabezado = Controllers.ProcesosController.DatosEncabezado;

                DataTable tb = ConvertDataTable(listaDetalleComp);

                //////////if (1> 0) //list.Count 
                //////////{

                //https://www.tektutorialshub.com/crystal-reports/how-to-download-and-install-crystal-report-runtime/
                Rel = new ReportDocument();
                Rel.Load(Server.MapPath("~/Rep/CrystalRep/GenerarRecibo/RepGenerarCotizacion.rpt"));
                Rel.SetDataSource(tb);
                //Conseguir el nombre de la carpeta en el server con Webconfig
                string relativePath = ConfigurationManager.AppSettings["rutaLogo"];
                //Conbinar la carpeta con otro string 
                string logoImagen = ""; // Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath + DatosEmisor[0].LOGO);

                //string logoImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath + "tecflex_imagen.png");//comentado 02.11.2021
                //Obtiene la rais y lo combina de frente sin webconfig
                //string pathToFiles = Server.MapPath("/LogoTecflex/tecflex_imagen.png");//comentado 02.11.2021
                //Otener el http del server(del proyecto)
                string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority +
                       Request.ApplicationPath.TrimEnd('/') + logoImagen;


                Rel.SetParameterValue("condVenta", condVenta);
                Rel.SetParameterValue("moneda", moneda);
                Rel.SetParameterValue("vendedor", vendedor);
                Rel.SetParameterValue("valorSubTotal", valorSubTotal);
                Rel.SetParameterValue("valorTotalIgv", valorTotalIgv);
                Rel.SetParameterValue("valorTotal", valorTotal);
                Rel.SetParameterValue("validez", validez);
                Rel.SetParameterValue("correlativo", correlativo);
                Rel.SetParameterValue("dateTimeVenta", dateTimeVenta);
                Rel.SetParameterValue("strMetodoPago", strMetodoPago);


                Rel.SetParameterValue("logoImagen", baseUrl);
                Rel.SetParameterValue("rucEmisor", "01585466665");
                Rel.SetParameterValue("dirEmisor", "Av. Guillermo Prescott 286 - San Isidro");
                Rel.SetParameterValue("tlfEmisor", "945797378");
                Rel.SetParameterValue("wspEmisor", "945797378");
                Rel.SetParameterValue("emailEmisor", "986598734");
                //Rel.SetParameterValue("rucEmisor", DatosEmisor[0].RUC);
                //Rel.SetParameterValue("dirEmisor", DatosEmisor[0].DIRECCION);
                //Rel.SetParameterValue("tlfEmisor", DatosEmisor[0].TLF);
                //Rel.SetParameterValue("wspEmisor", DatosEmisor[0].WSP);
                //Rel.SetParameterValue("emailEmisor", DatosEmisor[0].EMAIL);
                Rel.SetParameterValue("rucCliente", listadoCabecera_[0].rucCliente);
                Rel.SetParameterValue("nomCliente", listadoCabecera_[0].nomCliente);
                Rel.SetParameterValue("dirCliente", listadoCabecera_[0].dirCliente);
                Rel.SetParameterValue("tlfCliente", listadoCabecera_[0].tlfCliente);
                Rel.SetParameterValue("atteCliente", "Gonzales"); //añadido 03.11.2021
                Rel.SetParameterValue("Observacion", "Sin Observción"); //añadido 03.11.2021
                                                                        //Rel.SetParameterValue("atteCliente", listadoCabecera_[0].atteCliente); //añadido 03.11.2021
                                                                        //Rel.SetParameterValue("Observacion", listadoCabecera_[0].Observacion); //añadido 03.11.2021


                if (Request.QueryString["pdf"] != null)
                {
                    ExportPDF(Rel, filtroDeReporte);

                    var folder = Server.MapPath("~/DirTempArchivosPdf");
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    string rutaFile = Server.MapPath("~/" + "DirTempArchivosPdf" + "/" + filtroDeReporte + ".pdf");
                    System.IO.File.Create(rutaFile).Close();

                    Rel.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, rutaFile);
                }

                if (Request.QueryString["excel"] != null)
                {
                    ExportExcel(Rel, filtroDeReporte);
                }

                if (Request.QueryString["correo"] != null)
                {
                    string rutaFile = Server.MapPath("~/" + listadoCabecera_[0].nomCliente + ".pdf");
                    System.IO.File.Create(rutaFile).Close();
                    //var file1 = Server.MapPath("~/DocPdfCreado.pdf");
                    //Rel.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "D:\\ff.pdf");
                    Rel.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, rutaFile);
                }


                if (Request.QueryString["email"] != null)
                {
                    //ExportPDF(Rel, filtroDeReporte);


                    //////Crea una carpeta en el directorio del MapPath
                    ////string subPath = "DirTempArchivosPdf"; //Nombre de la carpeta
                    ////bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));
                    //////Verifica y si no existe lo crea
                    ////if (!exists)
                    ////    System.IO.Directory.CreateDirectory(Server.MapPath(subPath));


                    //https://stackoverflow.com/questions/6152979/how-can-i-create-a-new-folder-in-asp-net-using-c
                    //var folder = Server.MapPath("~/App_Data/uploads/random");
                    var folder = Server.MapPath("~/DirTempArchivosPdf");
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    //Obtenemos la ruta en el MapPath 
                    //string rutaFile = Server.MapPath("~/" + folder + "/" + listadoCabecera_[0].nomCliente + ".pdf");
                    string rutaFile = Server.MapPath("~/" + "DirTempArchivosPdf" + "/" + filtroDeReporte + ".pdf");
                    System.IO.File.Create(rutaFile).Close();
                    //var file1 = Server.MapPath("~/DocPdfCreado.pdf");
                    //Rel.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "D:\\ff.pdf");
                    Rel.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, rutaFile);


                    string c_strEmailDestino = "saracustodioh@gmail.com" + ";" + strEmailDestino;

                    //using (MailMessage mm = new MailMessage("sender@gmail.com", "recipient@gmail.com"))
                    //using (MailMessage mm = new MailMessage("sisactivofijo@gmail.com", "gonzales.hebert@gmail.com; hebertfox@gmail.com"))
                    //using (MailMessage mm = new MailMessage("sisactivofijo@gmail.com", c_strEmailDestino))
                    using (MailMessage mm = new MailMessage("sispetshopweb@gmail.com", c_strEmailDestino))
                    {
                        //mm.Subject = "Crystal Report PDF";
                        mm.Subject = "Comprobante de Venta PetShopWeb";
                        mm.Body = "Archivo Adjunto: " + filtroDeReporte;
                        //mm.Attachments.Add(new Attachment(crystalReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat), "Crystal.pdf"));
                        //Attachment ImageAttachment = new Attachment(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\DirLogos\\logo.png");
                        //mm.Attachments.Add(new Attachment(@"D:\Recibo Petshop.pdf"));
                        mm.Attachments.Add(new Attachment(rutaFile));
                        mm.IsBodyHtml = true;
                        using (SmtpClient smtp = new SmtpClient())
                        {
                            smtp.Host = "smtp.gmail.com";
                            smtp.UseDefaultCredentials = true;
                            smtp.Credentials = new NetworkCredential
                            {
                                //UserName = "sender@gmail.com",
                                UserName = "sispetshopweb@gmail.com",
                                Password = "Admin123*"
                            };
                            smtp.Port = 587;
                            smtp.EnableSsl = true;
                            smtp.Send(mm);
                        }


                        //Cuerpo de correo
                        //msg.Body = datos.ToString();

                        ////msg.IsBodyHtml = true;
                        //using (SmtpClient smtp = new SmtpClient())
                        //{
                        //    smtp.Host = host;
                        //    smtp.Port = Int32.Parse(puerto);
                        //    smtp.EnableSsl = auth;
                        //    smtp.UseDefaultCredentials = true;

                        //    //usuario y clave
                        //    smtp.Credentials = new NetworkCredential(ccorreo, cpass);

                        //    //Envio 
                        //    smtp.Send(msg);

                        //}
                    }




                    ////////////Enviamos al correo
                    //////////try
                    //////////{

                    //////////    MailMessage mm = new MailMessage();
                    //////////    string toemail = BLDashboard.email;
                    //////////    string custnm = BLDashboard.custname;

                    //////////    mm.From = new MailAddress("operations@kaem.in", "Kashif Ahhmed");
                    //////////    mm.To.Add(new MailAddress(toemail, custnm));
                    //////////    mm.IsBodyHtml = true;
                    //////////    string name = BLDashboard.custname;
                    //////////    mm.Subject = "Bill from Indian Restaurant";
                    //////////    //mm.Body = "Testing Crsytel Report Attachment send via Email";

                    //////////    String Body = "<div>Hello " + name + ",<br> Thank you for considersing us for your next Party/Event, here is the Bill for the Party/Event.<br> If any queries you can reach us at 6096464445. <br> Thank You</div>";
                    //////////    mm.Body = Body;
                    //////////    //mm.Attachments.Add(new Attachment(rpt.ExportToStream(ExportFormatType.PortableDocFormat), fileName));  
                    //////////    mm.Attachments.Add(new Attachment("E:\\" + filename));



                    //////////    SmtpClient sc = new SmtpClient("smtp.kaem.in");
                    //////////    sc.Credentials = new NetworkCredential("emailadd", "*********");
                    //////////    sc.Send(mm);
                    //////////    // MailMessage msg = mm.CreateMailMessage("mr.markwhite1@gmail.com", replacements, Body, new System.Web.UI.Control());  
                    //////////    MessageBox.Show("Email successfully sent to " + toemail);
                    //////////}
                    //////////catch (Exception e1)
                    //////////{

                    //////////    MessageBox.Show("Unable to send email to mr.markwhite1@gmail.com due to following error:\n\n" + e1.Message, "Email send error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //////////    //{
                    //////////    //    this.SendEmail(emailId, subject, body, rpt, fileName);
                    //////////    //}
                    //////////}




                }

                //GUARDAR EN UN DIRECTORIO
                //https://social.msdn.microsoft.com/Forums/en-US/325d122f-a9b2-4aa9-84ad-37e793ef3edc/crystal-report-save-as-pdf-in-server-folder?forum=aspmvc
                //https://stackoverflow.com/questions/41628688/how-to-export-crystal-report-to-pdf-and-email-in-c-sharp
                ////////////////////////////////////////////////////////////////////////////////////////////
                ///Question
                //List<Student> studentList = new List<Student>();
                //studentList = GetStudentInfo();
                //ReportDocument details = new ReportDocument();
                //Rel.Load(Server.MapPath("../Report/rptStudent.rpt"));
                //Rel.SetDataSource(tb);
                ////////System.IO.File.Create(Server.MapPath("~/DocPdfCreado.pdf")).Close();
                ////////var file1 = Server.MapPath("~/DocPdfCreado.pdf");
                //////Rel.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "D:\\ff.pdf");
                ////////////////////////////////////////////////////////////////////////////////////////////

                //CustomerReport crystalReport = new CustomerReport();
                //NorthwindEntities entities = new NorthwindEntities();
                //crystalReport.SetDataSource(from customer in entities.Customers.Take(5)
                //                            select customer);
                //crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Crystal");
                //Response.End();

                if (Request.QueryString["pdf"] != null || Request.QueryString["excel"] != null || Request.QueryString[""] != null)
                {

                    //EL OBJETO ReporteInventPorUbicacion TIENE QUE ESTAR EN:     protected global::CrystalDecisions.Web.CrystalReportViewer ReporteInventPorUbicacion;
                    ReporteIdentificador.ReportSource = Rel;
                    ReporteIdentificador.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                    ReporteIdentificador.HasToggleGroupTreeButton = false;


                }
                //////////}
                //////////else
                //////////{
                //////////    Container.Visible = true;
                //////////    txtMensaje.InnerHtml = "La tabla Asistencia no contiene registros.";
                //////////}

            }
            catch (Exception ex)
            {
                //Log.AlmacenarLogError(ex, "RepGenerarCotizacion.aspx.cs");
                Container.Visible = true;
                txtMensaje.InnerHtml = "Ocurrió un problema.";

                //EXCEPTION
                //El servidor SMTP requiere una conexión segura o el cliente no se autenticó.La respuesta del servidor fue: 5.7.0 A...
                //SOLUCION   Activa la opción "Aplicaciones menos seguras" en la cuenta de Gmail
                //https://social.msdn.microsoft.com/Forums/es-ES/986bc157-059c-4f72-9a4c-d8fa0076616d/enviar-email-desde-aspnet?forum=netfxwebes

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

        ////////////////////////////////////////////////////////////
        //CRYSTAL EN PDF
        ////////////////////////////////////////////////////////////
        public void ExportPDF(ReportDocument Rel, string filtroDeReporte)
        {

            BinaryReader stream = new BinaryReader(Rel.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat));
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.BinaryWrite(stream.ReadBytes(Convert.ToInt32(stream.BaseStream.Length)));

            string strFilename = filtroDeReporte +".pdf";
            //Response.AddHeader("content-disposition", @" attachment; filename=""Recibo Petshop.pdf"" ");
            Response.AddHeader("content-disposition", "attachment; filename =\"" + strFilename + "\"");




            /*****************************************Pruebas Inicio************************************************
            //Response.Clear();
            //byte[] dt = ms.ToArray();
            //dtEmpleado = dt; //Para enviar por correo cuando el check "Generar envío de correo" esté habilitado
            //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", strFilename));
            //Response.BinaryWrite(stream.ReadBytes(Convert.ToInt32(stream.BaseStream.Length)));
            //-------------------------------------
            //var path = @"D:\abcd.pdf";

            //System.IO.File.WriteAllBytes(path, stream.ReadBytes(Convert.ToInt32(stream.BaseStream.Length)));
            //---------------------------------------
            //Response.End();

            //3
            System.IO.File.Create(Server.MapPath("~/DocPdfCreado.pdf")).Close();
            var file = Server.MapPath("~/DocPdfCreado.pdf");


            //2
            string savePath = System.Web.HttpContext.Current.Server.MapPath(@"~/") + "TMINVENTARIO" + ".pdf";
            System.IO.File.WriteAllBytes(savePath, stream.ReadBytes(Convert.ToInt32(stream.BaseStream.Length)));
            //File(savePath, "application/force-download", Path.GetFileName(savePath));
            //return RedirectToAction("GetCustomerDetails", "Customer");

            //1
            //https://stackoverflow.com/questions/9806501/save-byte-stream-as-pdf-file-asp-net
            Byte[] bytes = stream.ReadBytes(Convert.ToInt32(stream.BaseStream.Length));
            //FileStream fs = new FileStream(@"D:\prueba\ab111cd.pdf", FileMode.OpenOrCreate);
            FileStream fs = new FileStream(@"D:\prueba\ab111cd.pdf", FileMode.OpenOrCreate);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            //4
            //string pdfFilePath = "c:/pdfdocuments/myfile.pdf";
            string pdfFilePath = "D:/R2022-000009.pdf";
            byte[] bytes2 = System.IO.File.ReadAllBytes(pdfFilePath);

            // munge bytes with whatever pdf software you want, i.e. http://sourceforge.net/projects/itextsharp/
            // bytes = MungePdfBytes(bytes); // MungePdfBytes is your custom method to change the PDF data
            // ...
            // make sure to cleanup after yourself

            // and save back - System.IO.File.WriteAll* makes sure all bytes are written properly - this will overwrite the file, if you don't want that, change the path here to something else
            System.IO.File.WriteAllBytes(file, bytes2);
            ***************************************** Pruebas Fin ************************************************/


            Response.Flush();
            Response.Close();
        }


        /* */
        ////////////////////////////////////////////////////////////
        //CRYSTAL EN EXCEL
        ////////////////////////////////////////////////////////////
        public void ExportExcel(ReportDocument Rel, string filtroDeReporte)
        {
            BinaryReader stream = new BinaryReader(Rel.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel));
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/vnd.ms-excel";
            Response.BinaryWrite(stream.ReadBytes(Convert.ToInt32(stream.BaseStream.Length)));
            Response.AddHeader("content-disposition", @"attachment;filename=""Recibo Petshop.xls""");
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
