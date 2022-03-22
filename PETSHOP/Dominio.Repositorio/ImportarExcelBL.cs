using Dominio.Entidades;
using Dominio.Repositorio.Util;
using Infraestructura.Data.SqlServer;
using System;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Configuration;
using ExcelDataReader;

namespace Dominio.Repositorio
{
    public class ImportarExcelBL
    {
        private ImportarExcelDAO objDao = new ImportarExcelDAO();
        private UsuarioDAO objUsuario = new UsuarioDAO();

        #region IMPORTAR EXCEL CSV, XLX, XLSX

        /////////////////////////////////////////////////////////////////////////////////////////////
        // 26.1 IMPORTAR EXCEL TMPRODU CSV, XLX, XLSX
        /////////////////////////////////////////////////////////////////////////////////////////////
        public List<ResultImportExcel> ImportArchivosExcelInvtWeb(Session_Movi session, string nombreExcel, int idProceso, int cboPlantilla, string strFormato, bool checkActualizar, string rutaDirectorioExcel, ref string strMsjUsuario)
        {
            List<ResultImportExcel> listObj = new List<ResultImportExcel>();
            try
            {
                int insertadoActualizado = 0;
                string strConInconsistencia = "";
                int regInsertados = 0;
                int regActualizados = 0;
                int regInconsistentes = 0;
                int intResult = 0;
                string strMsjDB = "";
                string RutaMasivoEntidad = rutaDirectorioExcel;
                bool existe = VerificarRuta(RutaMasivoEntidad);
                List<string> arrListInconsistentes = new List<string>();

                if (existe == true)
                {
                    //Log.AlmacenarLogMensaje("[BL]" + nombreExcel);//PARA PRUEBAS
                    if (File.Exists(RutaMasivoEntidad + "\\" + nombreExcel))
                    {
                        //if (checkActualizar == true)
                        //{
                        //  objDao.LimpiarTablasExcel(session, true, false, false, false, false, false, false, false, false, ref intResult, ref strMsjDB, ref strMsjUsuario);
                        //}
                        DataTable dt = ReadExcelInvtWeb(nombreExcel, idProceso, RutaMasivoEntidad);

                        //if (checkActualizar == true)
                        //{
                        //    //condicion Flag Limpiar y Cargar
                        //    //objDao.LimpiarTablas_(1,1,1,1,1,1,1,1)
                        //    //objDao.LimpiarTablasExcel(session, chckTodos, chckEntidad, chckLocal, chckArea, chckOficina, chckEmpleado, chckEstado, chckTipo, chckBienes, ref intResult, ref strMsjDB, ref strMsjUsuario);
                        //    objDao.LimpiarTablasExcel(session, true , true, true, true, true, true, true, true, true, ref intResult, ref strMsjDB, ref strMsjUsuario);
                        //}

                        //9.1.6 - TBLOCAL
                        if (nombreExcel.Contains("TMPRODU"))
                        {
                            intResult = objDao.ImportArchivosExcelInvtWeb(session, dt, "TMPRODU", insertadoActualizado, idProceso, cboPlantilla, strFormato, checkActualizar, rutaDirectorioExcel, ref intResult, ref strMsjDB, ref strMsjUsuario, ref regInsertados, ref regActualizados, ref regInconsistentes, ref strConInconsistencia, ref arrListInconsistentes);

                            ResultImportExcel ObjBienes = new ResultImportExcel();
                            ObjBienes.intInsertado = regInsertados;
                            ObjBienes.intActualizado = regActualizados;
                            ObjBienes.intInconsistente = regInconsistentes;
                            ObjBienes.strInconsistente = strConInconsistencia;
                            ObjBienes.strNombreTabla = "TMPRODU";
                            listObj.Add(ObjBienes);
                        }

                    }
                    else
                    {
                        Log.AlmacenarLogMensaje("El excel importado no existe en el Servidor " + nombreExcel);
                        strMsjDB = "Vuelva a seleccionar el archivo a importar e inténtelo nuevamente.";
                    }
                }
                else
                {
                    Log.AlmacenarLogMensaje("Corrija la Ruta de Importación de Excel (rutaEmpleadoMasivo del webconfig): " + RutaMasivoEntidad);
                    strMsjDB = "La Ruta del Directorio de Importación Masiva configurado en el Servidor no Existe.";
                }

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ImportArchivosExcelInvtWeb] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }


            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ImportArchivosExcelInvtWeb)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ImportArchivosExcelInvtWeb)");
            }
            return listObj;
        }


        /////////////////////////////////////////////////////////////////////////////////////////////
        // TXT_PRUEBA 1
        /////////////////////////////////////////////////////////////////////////////////////////////
        public List<ResultImportExcel> ImportArchivosExcelInvtWeb_TXT(Session_Movi session, 
            string nombreExcel, int idProceso, int cboPlantilla, int cboFormato, bool checkActualizar, string rutaDirectorioExcel, ref string strMsjUsuario)
        {
            List<ResultImportExcel> listObj = new List<ResultImportExcel>();

            try
            {
                //int insertadoActualizado = 0;
                //string strConInconsistencia = "";
                //int regInsertados = 0;
                //int regActualizados = 0;
                //int regInconsistentes = 0;
                //int intResult = 0;
                //string strMsjDB = "";
                //string RutaMasivoEntidad = rutaDirectorioExcel;
                //bool existe = VerificarRuta(RutaMasivoEntidad);
                List<string> arrListInconsistentes = new List<string>();

                DataTable dt = ReadExcelInvtWeb_TXT(nombreExcel, idProceso, rutaDirectorioExcel);


            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ImportArchivosExcelInvtWeb)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ImportArchivosExcelInvtWeb)");
            }
            return listObj;
        }


        /////////////////////////////////////////////////////////////////////////////////////////////
        //TXT PRUEBA 2
        /////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable ReadExcelInvtWeb_TXT(string nombreExcel, int idProceso,  string rutaDirectorioExcel)
        {
           
            string urlRuta = @"D:\TMPRODU.txt"; // rutaDirectorioExcel; // + "\\" + nombreExcel;
            DataTable table = new DataTable();
            try
            {
                string strExt = urlRuta.Substring(urlRuta.LastIndexOf("."));

                if (strExt == ".txt")
                {
                    //https://stackoverflow.com/questions/30524153/split-file-txt-to-fill-in-datatable-c-sharp //HGMHELPER

                    DataTable result = new DataTable();


                    result.Columns.Add(new DataColumn("CodidoProd", typeof(string)));
                    result.Columns.Add(new DataColumn("Producto", typeof(string)));

                    ////table.Columns.Add("CodidoProd", typeof(string));
                    ////table.Columns.Add("Producto", typeof(string));
                    //table.Columns.Add("columnaNoValida", typeof(string));

                    foreach (var line  in File.ReadLines(urlRuta))
                    {
                        DataRow row = result.NewRow();

                        //SOLUCION A MAS DE DOS COMAS https://stackoverflow.com/questions/30587956/how-to-split-string-before-first-comma
                        ////////TODO: you may want tabulation ('\t') separator as well as space
                        String[] items = line.Split(new Char[] { ',', '\t' }, 2); //StringSplitOptions.RemoveEmptyEntries

                        //String[] splitted = line.Split(",", 2); // will be matched 1 times. 

                        ////items[0];  //before the first comma. `abc`
                        ////items[1]  //the whole String after the first comma. `cde,def,fgh`


                        //////// Columns adjusting: you don't need exactly 3 columns  
                        //////////for (int i = result.Columns.Count; i < items.Length; ++i)
                        //////    //Agrega el titulo de por columna que existe 
                        //////    //result.Columns.Add(String.Format("COL {0}", i + 1));

                        //row.ItemArray = items;
                        result.Rows.Add(items);

                        ////row["CodidoProd"] = row[0];
                        ////row["Producto"] = row[1];


                    }

                    //Eliminar la primera fila que no me sirve
                    //DataTable dt2 = table.Clone();
                    //dt2.Rows.Remove(dt2.Rows[0]);

                    result.Rows.RemoveAt(0);
                    table = result;




                    //return result;

                    //////DataTable tbl = new DataTable();

                    //////for (int col = 0; col < 2; col++)
                    //////    tbl.Columns.Add(new DataColumn("Column" + (col + 1).ToString()));


                    //////string[] lines = System.IO.File.ReadAllLines(urlRuta);

                    ////foreach (string line in lines)
                    ////{
                    ////    var cols = line.Split(',');
                    ////    DataRow dr = tbl.NewRow();
                    ////    for (int cIndex = 0; cIndex < 3; cIndex++)
                    ////    {
                    ////        dr[cIndex] = cols[cIndex];
                    ////    }
                    ////    tbl.Rows.Add(dr);
                    ////}
                    ////return tbl;

                    ////////DataSet ds = new DataSet();
                    //////////ds = excelReader.AsDataSet(conf);
                    //////////stream.Close();

                    //////////DataSet ds = new DataSet();
                    //////////ds.ReadTx(fileName);

                    ////////DataTable dtExcelDatos = ds.Tables[0];
                    ////////int numCol = dtExcelDatos.Columns.Count;//Numero de columnas del excel
                    ////////                                        //tbImport = LlenarTableMasivo(dtExcelDatos, idProceso, nombreExcel);
                    ////////                                        //int numCol = dt.Columns.Count;
                    ////////                                        //DataTable table = new DataTable();
                    ////////                                        //---------------------------------------------------------------
                    ////////if (nombreExcel.Contains("TMPRODU"))
                    ////////{
                    ////////    table.Columns.Add("CodidoProd", typeof(string));
                    ////////    table.Columns.Add("Producto", typeof(string));
                    //////////}
                    //////////---------------------------------------------------------------

                    //////////Independiente de la estructura de table
                    ////////foreach (DataRow row in dtExcelDatos.Rows)
                    ////////{
                    ////////    DataRow rows = table.NewRow();
                    ////////    //if (nombreExcel.Contains("TMPRODU"))
                    ////////    //{
                    ////////        rows["CodidoProd"] = row[0];
                    ////////        rows["Producto"] = row[1];
                    ////////    //}
                    ////////    table.Rows.Add(rows);

                    ////////}




                }

                else
                {



                    FileStream stream = File.Open(urlRuta, FileMode.Open, FileAccess.Read);
                    IExcelDataReader excelReader;

                    if (strExt == ".xls")
                        excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                    else if (strExt == ".csv")
                        excelReader = ExcelReaderFactory.CreateCsvReader(stream);
                    else
                        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                    var conf = new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    };

                    DataSet ds = new DataSet();
                    ds = excelReader.AsDataSet(conf);
                    stream.Close();

                    DataTable dtExcelDatos = ds.Tables[0];
                    int numCol = dtExcelDatos.Columns.Count;//Numero de columnas del excel
                                                            //tbImport = LlenarTableMasivo(dtExcelDatos, idProceso, nombreExcel);
                                                            //int numCol = dt.Columns.Count;
                                                            //DataTable table = new DataTable();
                                                            //---------------------------------------------------------------
                    if (nombreExcel.Contains("TMPRODU"))
                    {
                        table.Columns.Add("CodidoProd", typeof(string));
                        table.Columns.Add("Producto", typeof(string));
                    }
                    //---------------------------------------------------------------

                    //Independiente de la estructura de table
                    foreach (DataRow row in dtExcelDatos.Rows)
                    {
                        DataRow rows = table.NewRow();
                        if (nombreExcel.Contains("TMPRODU"))
                        {
                            rows["CodidoProd"] = row[0];
                            rows["Producto"] = row[1];
                        }
                        table.Rows.Add(rows);

                    }

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            //table.Rows.RemoveAt(0);
            return table;
        }


        /////////////////////////////////////////////////////////////////////////////////////////////
        //LEER EXCEL Y CONVERTIRLO EN TABLA "Inventario Web"
        /////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable ReadExcelInvtWeb(string nombreExcel, int idProceso, string RutaMasivoEntidad)
        {

            string urlRuta = RutaMasivoEntidad + "\\" + nombreExcel;
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
                    foreach (var line in File.ReadLines(urlRuta))
                    {
                        DataRow row = result.NewRow();
                        String[] items = line.Split(new Char[] { ',', '\t' }, 2, StringSplitOptions.RemoveEmptyEntries); //StringSplitOptions.RemoveEmptyEntries
                        result.Rows.Add(items);
                    }

                    //Eliminar la primera fila que no deseo
                    //result.Rows.RemoveAt(0);
                    table = result;

                }
                //CASO CONTRARIO PUEDEN SER CUALQUIERA DE LOS EXCELS CSV XLS o XLSX
                else
                {                   
                    FileStream stream = File.Open(urlRuta, FileMode.Open, FileAccess.Read);
                    IExcelDataReader excelReader;

                    if (strExt == ".xls")
                        excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                    else if (strExt == ".csv")
                        excelReader = ExcelReaderFactory.CreateCsvReader(stream);
                    else
                        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                    var conf = new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = false //true
                        }
                    };

                    DataSet ds = new DataSet();
                    ds = excelReader.AsDataSet(conf);
                    stream.Close();

                    DataTable dtExcelDatos = ds.Tables[0];
                    int numCol = dtExcelDatos.Columns.Count;//Numero de columnas del excel
                                                            //tbImport = LlenarTableMasivo(dtExcelDatos, idProceso, nombreExcel);
                                                            //int numCol = dt.Columns.Count;
                                                            //DataTable table = new DataTable();
                                                            //---------------------------------------------------------------
                    if (nombreExcel.Contains("TMPRODU"))
                    {
                        table.Columns.Add("CodidoProd", typeof(string));
                        table.Columns.Add("Producto", typeof(string));
                    }
                    //---------------------------------------------------------------

                    //Independiente de la estructura de table
                    foreach (DataRow row in dtExcelDatos.Rows)
                    {
                        DataRow rows = table.NewRow();
                        if (nombreExcel.Contains("TMPRODU"))
                        {
                            rows["CodidoProd"] = row[0];
                            rows["Producto"] = row[1];
                        }
                        table.Rows.Add(rows);

                    }

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return table;
        }

        #endregion







        //17.1 ENVIAR EXCELS POR CORREO 
        public Dictionary<string, string> ToEmailEnviarExcelPorCorreo2(Session_Movi objSession,
              string strEmailDestino, string rutaDeExcelsToEmail
            , byte[] dtBienes, byte[] dtBienesDs, byte[] dtOficina, byte[] dtEmpleado, byte[] dtLocal
            , byte[] dtAreas, byte[] dtEstado, byte[] dtTipo, byte[] dtEntidad
            , string txtBienes, string txtBienesDs, string txtOficina
            , string txtEmpleado, string idRadioCheck
            , ref string strMsjUsuario)
        {

            Dictionary<string, string> obj = new Dictionary<string, string>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                //ToEmailReenviarCorreoEmpleado(objSession, strEmailDestino, rutaDeExcelsToEmail, 2, false, ref intResult, ref strMsjDB, ref strMsjUsuario);
                ToEmailEnviarExcelPorCorreoII2(objSession, strEmailDestino, rutaDeExcelsToEmail
                                        , dtBienes, dtBienesDs, dtOficina, dtEmpleado, dtLocal
                                        , dtAreas, dtEstado, dtTipo, dtEntidad
                                        , txtBienes, txtBienesDs, txtOficina, txtEmpleado, "chck_excel2"  //idRadioCheck
                                        , 2, false, ref intResult, ref strMsjDB, ref strMsjUsuario);

                obj.Add("mensaje", strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ToEmailEnviarExcelPorCorreo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ToEmailEnviarExcelPorCorreo)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ToEmailEnviarExcelPorCorreo)");
            }
            return obj;
        }






        //17.1.1
        private int ToEmailEnviarExcelPorCorreoII2(Session_Movi objSession
                          , string strEmailDestino, string rutaDeExcelsToEmail
                          , byte[] dtBienes, byte[] dtBienesDs, byte[] dtOficina, byte[] dtEmpleado
                          , byte[] dtLocal, byte[] dtAreas, byte[] dtEstado, byte[] dtTipo, byte[] dtEntidad
                          , string txtBienes, string txtBienesDs
                          , string txtOficina, string txtEmpleado, string idRadioCheck
                          , int intTipoOperacion, bool desactivaUsuario,
                            ref int intResult, ref string strMsjDB, ref string strMsjUsuario
            )
        {
            List<EnCorreo> lsCorreoDatos = objDao.obtenerDatosCorreo(objSession, ref intResult, ref strMsjDB, ref strMsjUsuario);
            string host = lsCorreoDatos[0].strhost;
            string puerto = lsCorreoDatos[0].strpuerto;
            string ccorreo = lsCorreoDatos[0].strccorreo;
            string cpass = lsCorreoDatos[0].strcpass;
            string cde = lsCorreoDatos[0].strremitente;
            bool   auth = lsCorreoDatos[0].bitAutentificacion;

            MailMessage msg = new MailMessage();

            try
            {
                // Create file attachment
                Attachment ImageAttachment = new Attachment(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\DirLogos\\logo.png");

                // Set the ContentId of the attachment, used in body HTML
                ImageAttachment.ContentId = "logo";
                ////msg.Attachments.Add(ImageAttachment);


                ///////////////////////////////////////////////////////////////////////////////////
                //msg.Attachments.Add(new Attachment(@"C:\temp\myreport.log"));
                msg.Attachments.Add(new Attachment(@"D:\Recibo Petshop.pdf"));
                ///////////////////////////////////////////////////////////////////////////////////

                //Cuerpo del Mensaje
                StringBuilder datos = ToEmailHtmlMessageBody2(idRadioCheck); //HGM2
                string addresses = strEmailDestino;

                //Enviar todos los correos de la lista traida del campo "strEmailDestino" de TSPARAMS
                foreach (var addressCorreos in addresses.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    msg.To.Add(addressCorreos);
                }

                //Receptores
                //msg.To.Add(new MailAddress(obj.strCorreo));
                //msg.To.Add(new MailAddress("ereyes@tecflex.com"));
                //msg.CC.Add(new MailAddress("esuyon@tecflex.com"));
                //msg.CC.Add(new MailAddress("programador04@tecflex.com"));

                //Remitente
                msg.From = new MailAddress(ccorreo);

                //Titulo
                //msg.Subject = "Documentos Excel de SisactivoFijo";


                //idRadioCheck --> Segun este valor el mensaje dira que tipo de documentos fueron enviados 
                if (idRadioCheck == "chck_excel2")
                {
                    msg.Subject = "Recibo de Compra PetShopApp";
                    //msg.Subject = "Documentos Excel de SisactivoFijo";
                }
                ////else if (idRadioCheck == "chck_txt")
                ////{
                ////    msg.Subject = "Documentos en Formato de Texto de SisactivoFijo";
                ////}
                ////else // idRadioCheck == "chck_todos"
                ////{
                ////    msg.Subject = "Documentos Excel y Formato de Texto de SisactivoFijo";
                ////}

                //Cuerpo de correo
                msg.Body = datos.ToString();

                msg.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = host;
                    smtp.Port = Int32.Parse(puerto);
                    smtp.EnableSsl = auth;
                    smtp.UseDefaultCredentials = true;

                    //usuario y clave
                    smtp.Credentials = new NetworkCredential(ccorreo, cpass);

                    //Envio 
                    smtp.Send(msg);

                }

                intResult = 1;
                strMsjUsuario = "Se envió el correo con credenciales.";


            }

            catch (Exception ex)
            {
                intResult = 3;
                strMsjUsuario = "Ocurrió un error al enviar el correo";
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");

            }

            return intResult;
        }

        //17.1.2 
        private StringBuilder ToEmailHtmlMessageBody2(string idRadioCheck)
        {
            StringBuilder strB = new StringBuilder();

            int intResult = 0;
            string strMsjDB = "";
            string strMsjUsuario = "";

            TEXTO_DEL_CORREO objTexto;

            //idRadioCheck --> Segun este valor el mensaje dira que tipo de documentos fueron enviados 
            if (idRadioCheck == "chck_excel")
            {

                objTexto = objDao.GetTextoCorreoSisActivo("ENVIAR_SOLO_EXCELS", 1, 0, false, ref intResult, ref strMsjDB, ref strMsjUsuario);
            }
            else if (idRadioCheck == "chck_txt")
            {
                objTexto = objDao.GetTextoCorreoSisActivo("ENVIAR_SOLO_TXT", 1, 0, false, ref intResult, ref strMsjDB, ref strMsjUsuario);
            }
            else if (idRadioCheck == "chck_excel2")
            {
                objTexto = objDao.GetTextoCorreoSisActivo("ENVIAR_SOLO_TXT2", 1, 0, false, ref intResult, ref strMsjDB, ref strMsjUsuario);
            }
            else // idRadioCheck == "chck_todos"
            {
                objTexto = objDao.GetTextoCorreoSisActivo("ENVIAR_TODOS_EXCEL_TXT", 1, 0, false, ref intResult, ref strMsjDB, ref strMsjUsuario);
            }



            strB.AppendLine("<html>");
            strB.AppendLine("<body>");
            //strB.AppendLine("<img src=cid:logo />");
            strB.AppendLine("<br>");
            strB.AppendLine("<div>");

            strB.AppendLine("<span style='font-size: large;'>" + "SISTEMA PETSHOP WEB ©2021 " /*objTexto.saludo*/ + "</span>");
            strB.AppendLine("</div>");
            strB.AppendLine("<br>");
            strB.AppendLine("<div>");

            strB.AppendLine("</div>");
            strB.AppendLine("<br>");
            strB.AppendLine("<div>");
            //strB.AppendLine(objTexto.despedida);
            strB.AppendLine("Se adjunta el Recibo de Compras.");
            strB.AppendLine("Gracias por su visita.");
            strB.AppendLine("</div>");

            strB.AppendLine("<br>");
            strB.AppendLine("<br>");
            strB.AppendLine("<br>");
            strB.AppendLine("</div>");

            strB.AppendLine("</div>");
            strB.AppendLine("</body>");
            strB.AppendLine("</html>");

            return strB;
        }














        #region EXCELS POR CORREO (Mant. Configuracion - SisactivoFijo)

        //17.1 ENVIAR EXCELS POR CORREO 
        public Dictionary<string, string> ToEmailEnviarExcelPorCorreo(Session_Movi objSession,
              string strEmailDestino, string rutaDeExcelsToEmail
            , byte[] dtBienes, byte[] dtBienesDs , byte[] dtOficina, byte[] dtEmpleado, byte[] dtLocal
            , byte[] dtAreas, byte[] dtEstado, byte[] dtTipo, byte[] dtEntidad
            , string txtBienes, string txtBienesDs, string txtOficina 
            , string txtEmpleado, string idRadioCheck
            , ref string strMsjUsuario)
        {

            Dictionary<string, string> obj = new Dictionary<string, string>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                //ToEmailReenviarCorreoEmpleado(objSession, strEmailDestino, rutaDeExcelsToEmail, 2, false, ref intResult, ref strMsjDB, ref strMsjUsuario);
                ToEmailEnviarExcelPorCorreoII(objSession, strEmailDestino, rutaDeExcelsToEmail
                                        , dtBienes, dtBienesDs, dtOficina, dtEmpleado,  dtLocal
                                        , dtAreas, dtEstado,  dtTipo, dtEntidad
                                        , txtBienes, txtBienesDs, txtOficina, txtEmpleado, idRadioCheck
                                        , 2, false, ref intResult, ref strMsjDB, ref strMsjUsuario);

                obj.Add("mensaje", strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ToEmailEnviarExcelPorCorreo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ToEmailEnviarExcelPorCorreo)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ToEmailEnviarExcelPorCorreo)");
            }
            return obj;
        }


        //17.1.1
        private int ToEmailEnviarExcelPorCorreoII(Session_Movi objSession 
                          , string strEmailDestino, string  rutaDeExcelsToEmail
                          , byte[] dtBienes, byte[] dtBienesDs, byte[] dtOficina, byte[] dtEmpleado 
                          , byte[] dtLocal, byte[] dtAreas, byte[] dtEstado, byte[] dtTipo, byte[] dtEntidad
                          , string txtBienes, string txtBienesDs
                          , string txtOficina, string txtEmpleado, string idRadioCheck
                          , int intTipoOperacion,  bool  desactivaUsuario, 
                            ref int  intResult, ref string  strMsjDB, ref string  strMsjUsuario
            )
        {
            List<EnCorreo> lsCorreoDatos = objDao.obtenerDatosCorreo(objSession, ref intResult, ref strMsjDB, ref strMsjUsuario);
            string host    = lsCorreoDatos[0].strhost;
            string puerto  = lsCorreoDatos[0].strpuerto;
            string ccorreo = lsCorreoDatos[0].strccorreo;
            string cpass   = lsCorreoDatos[0].strcpass;
            string cde     = lsCorreoDatos[0].strremitente;
            bool   auth    = lsCorreoDatos[0].bitAutentificacion;

            MailMessage msg = new MailMessage();

            try
            {
                // Create file attachment
                Attachment ImageAttachment = new Attachment(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\DirLogos\\logo.png");
         
                // Set the ContentId of the attachment, used in body HTML
                ImageAttachment.ContentId = "logo";
                ////msg.Attachments.Add(ImageAttachment);


                /********************************************************************************
                    ATACHAR los 04 Excels a partir de los Bytes[] traidos desde el controlador
                *********************************************************************************/
                if (idRadioCheck == "chck_excel")
                {
                    //EXCEL TBBIENES
                    System.IO.MemoryStream stream1 = new System.IO.MemoryStream(dtBienes, true);
                    stream1.Write(dtBienes, 0, dtBienes.Length);
                    stream1.Position = 0;
                    msg.Attachments.Add(new Attachment(stream1, "TBBIENES.xlsx"));

                    //EXCEL TBBIENESDS
                    System.IO.MemoryStream stream2 = new System.IO.MemoryStream(dtBienesDs, true);
                    stream2.Write(dtBienesDs, 0, dtBienesDs.Length);
                    stream2.Position = 0;
                    msg.Attachments.Add(new Attachment(stream2, "TBBIENESDS.xlsx"));

                    //EXCEL TBOFICINA
                    System.IO.MemoryStream stream3 = new System.IO.MemoryStream(dtOficina, true);
                    stream3.Write(dtOficina, 0, dtOficina.Length);
                    stream3.Position = 0;
                    msg.Attachments.Add(new Attachment(stream3, "TBOFICINA.xlsx"));

                    //EXCEL TBEMPLEADO
                    System.IO.MemoryStream stream4 = new System.IO.MemoryStream(dtEmpleado, true);
                    stream4.Write(dtEmpleado, 0, dtEmpleado.Length);
                    stream4.Position = 0;
                    msg.Attachments.Add(new Attachment(stream4, "TBEMPLEADO.xlsx"));

                }

                /********************************************************************************
                    ATACHAR los 04 TXTs a partir de los String traidos desde el Controlador
                *********************************************************************************/
                if (idRadioCheck == "chck_txt")
                {
                    //https://www.c-sharpcorner.com/UploadFile/mahesh/create-a-text-file-in-C-Sharp/
                    //FORMATO TBBIENES.txt
                    //Primero transformamos el string en Bytes
                    Byte[] byteTbBienes = new UTF8Encoding(true).GetBytes(txtBienes);
                    //Luego se lo trabaja como se hizo con los Excels pero esta vez en formato .txt ya no .xlxs
                    System.IO.MemoryStream stream5 = new System.IO.MemoryStream(byteTbBienes, true);
                    stream5.Write(byteTbBienes, 0, byteTbBienes.Length);
                    stream5.Position = 0;
                    msg.Attachments.Add(new Attachment(stream5, "TBBIENES.txt"));
                    //FORMATO TBBIENESDS.txt
                    Byte[] byteTbBienesDs = new UTF8Encoding(true).GetBytes(txtBienesDs);
                    System.IO.MemoryStream stream6 = new System.IO.MemoryStream(byteTbBienesDs, true);
                    stream6.Write(byteTbBienesDs, 0, byteTbBienesDs.Length);
                    stream6.Position = 0;
                    msg.Attachments.Add(new Attachment(stream6, "TBBIENESDS.txt"));
                    //FORMATO TBOFICINA.txt
                    Byte[] byteTbOficina = new UTF8Encoding(true).GetBytes(txtOficina);
                    System.IO.MemoryStream stream8 = new System.IO.MemoryStream(byteTbOficina, true);
                    stream8.Write(byteTbOficina, 0, byteTbOficina.Length);
                    stream8.Position = 0;
                    msg.Attachments.Add(new Attachment(stream8, "TBOFICINA.txt"));
                    //FORMATO TBEMPLEADO.txt
                    Byte[] byteTbEmpleado = new UTF8Encoding(true).GetBytes(txtEmpleado);
                    System.IO.MemoryStream stream7 = new System.IO.MemoryStream(byteTbEmpleado, true);
                    stream7.Write(byteTbEmpleado, 0, byteTbEmpleado.Length);
                    stream7.Position = 0;
                    msg.Attachments.Add(new Attachment(stream7, "TBEMPLEADO.txt"));


                }

                /********************************************************************************
                     ATACHAR los 08 documentos exportados (Excels y Formato Txt)
                *********************************************************************************/
                if (idRadioCheck == "chck_todos")
                {
                    /*==========================================================================
                        Atachamos los 4 excels y los 4 txt traidos desde el controlador
                    ============================================================================*/
                    //EXCEL TBBIENES
                    System.IO.MemoryStream stream1 = new System.IO.MemoryStream(dtBienes, true);
                    stream1.Write(dtBienes, 0, dtBienes.Length);
                    stream1.Position = 0;
                    msg.Attachments.Add(new Attachment(stream1, "TBBIENES.xlsx"));
                    //EXCEL TBBIENESDS
                    System.IO.MemoryStream stream2 = new System.IO.MemoryStream(dtBienesDs, true);
                    stream2.Write(dtBienesDs, 0, dtBienesDs.Length);
                    stream2.Position = 0;
                    msg.Attachments.Add(new Attachment(stream2, "TBBIENESDS.xlsx"));
                    //EXCEL TBOFICINA
                    System.IO.MemoryStream stream3 = new System.IO.MemoryStream(dtOficina, true);
                    stream3.Write(dtOficina, 0, dtOficina.Length);
                    stream3.Position = 0;
                    msg.Attachments.Add(new Attachment(stream3, "TBOFICINA.xlsx"));
                    //EXCEL TBEMPLEADO
                    System.IO.MemoryStream stream4 = new System.IO.MemoryStream(dtEmpleado, true);
                    stream4.Write(dtEmpleado, 0, dtEmpleado.Length);
                    stream4.Position = 0;
                    msg.Attachments.Add(new Attachment(stream4, "TBEMPLEADO.xlsx"));
                    ////////////////////////////////////////////////////////////////////////////////
                    //FORMATO TBBIENES.txt
                    Byte[] byteTbBienes = new UTF8Encoding(true).GetBytes(txtBienes);
                    System.IO.MemoryStream stream5 = new System.IO.MemoryStream(byteTbBienes, true);
                    stream5.Write(byteTbBienes, 0, byteTbBienes.Length);
                    stream5.Position = 0;
                    msg.Attachments.Add(new Attachment(stream5, "TBBIENES.txt"));
                    //FORMATO TBBIENESDS.txt
                    Byte[] byteTbBienesDs = new UTF8Encoding(true).GetBytes(txtBienesDs);
                    System.IO.MemoryStream stream6 = new System.IO.MemoryStream(byteTbBienesDs, true);
                    stream6.Write(byteTbBienesDs, 0, byteTbBienesDs.Length);
                    stream6.Position = 0;
                    msg.Attachments.Add(new Attachment(stream6, "TBBIENESDS.txt"));
                    //FORMATO TBOFICINA.txt
                    Byte[] byteTbOficina = new UTF8Encoding(true).GetBytes(txtOficina);
                    System.IO.MemoryStream stream8 = new System.IO.MemoryStream(byteTbOficina, true);
                    stream8.Write(byteTbOficina, 0, byteTbOficina.Length);
                    stream8.Position = 0;
                    msg.Attachments.Add(new Attachment(stream8, "TBOFICINA.txt"));
                    //FORMATO TBEMPLEADO.txt
                    Byte[] byteTbEmpleado = new UTF8Encoding(true).GetBytes(txtEmpleado);
                    System.IO.MemoryStream stream7 = new System.IO.MemoryStream(byteTbEmpleado, true);
                    stream7.Write(byteTbEmpleado, 0, byteTbEmpleado.Length);
                    stream7.Position = 0;
                    msg.Attachments.Add(new Attachment(stream7, "TBEMPLEADO.txt"));
                }
          

                ///////////////////////////////////////////////////////////////////////////////////

                ///////////////////////////////////////////////////////////////////////////////////

                //Cuerpo del Mensaje
                StringBuilder datos = ToEmailHtmlMessageBody(idRadioCheck);
                string addresses = strEmailDestino; 

                //Enviar todos los correos de la lista traida del campo "strEmailDestino" de TSPARAMS
                foreach (var addressCorreos in addresses.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    msg.To.Add(addressCorreos);
                }

                //Receptores
                //msg.To.Add(new MailAddress(obj.strCorreo));
                //msg.To.Add(new MailAddress("ereyes@tecflex.com"));
                //msg.CC.Add(new MailAddress("esuyon@tecflex.com"));
                //msg.CC.Add(new MailAddress("programador04@tecflex.com"));

                //Remitente
                msg.From = new MailAddress(ccorreo);

                //Titulo
                //msg.Subject = "Documentos Excel de SisactivoFijo";


                //idRadioCheck --> Segun este valor el mensaje dira que tipo de documentos fueron enviados 
                if (idRadioCheck == "chck_excel")
                {

                    msg.Subject = "Documentos Excel de SisactivoFijo";
                }
                else if (idRadioCheck == "chck_txt")
                {
                    msg.Subject = "Documentos en Formato de Texto de SisactivoFijo";
                }
                else // idRadioCheck == "chck_todos"
                {
                    msg.Subject = "Documentos Excel y Formato de Texto de SisactivoFijo";
                }

                //Cuerpo de correo
                msg.Body = datos.ToString();

                msg.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = host;
                    smtp.Port = Int32.Parse(puerto);
                    smtp.EnableSsl = auth;
                    smtp.UseDefaultCredentials = true;

                    //usuario y clave
                    smtp.Credentials = new NetworkCredential(ccorreo, cpass);

                    //Envio 
                    smtp.Send(msg);

                }

                intResult = 1;
                strMsjUsuario = "Se envió el correo con credenciales.";


            }

            catch (Exception ex)
            {
                intResult = 3;
                strMsjUsuario = "Ocurrió un error al enviar el correo";
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");

            }            

            return intResult;
        }

        //17.1.2 
        private StringBuilder ToEmailHtmlMessageBody(string idRadioCheck)  
        {
            StringBuilder strB = new StringBuilder();

            int intResult = 0;
            string strMsjDB = "";
            string strMsjUsuario = "";

            TEXTO_DEL_CORREO objTexto;

            //idRadioCheck --> Segun este valor el mensaje dira que tipo de documentos fueron enviados 
            if (idRadioCheck == "chck_excel") {

                objTexto = objDao.GetTextoCorreoSisActivo("ENVIAR_SOLO_EXCELS", 1 , 0, false, ref intResult, ref strMsjDB, ref strMsjUsuario);
            }
            else if (idRadioCheck == "chck_txt")
            {
                objTexto = objDao.GetTextoCorreoSisActivo("ENVIAR_SOLO_TXT", 1, 0, false, ref intResult, ref strMsjDB, ref strMsjUsuario);
            }
            else // idRadioCheck == "chck_todos"
            {
                objTexto = objDao.GetTextoCorreoSisActivo("ENVIAR_TODOS_EXCEL_TXT", 1, 0, false, ref intResult, ref strMsjDB, ref strMsjUsuario);
            }

           

            strB.AppendLine("<html>");
            strB.AppendLine("<body>");
            //strB.AppendLine("<img src=cid:logo />");
            strB.AppendLine("<br>");
            strB.AppendLine("<div>");

            strB.AppendLine("<span style='font-size: large;'>" + objTexto.saludo + "</span>");
            strB.AppendLine("</div>");
            strB.AppendLine("<br>");
            strB.AppendLine("<div>");

            strB.AppendLine("</div>");
            strB.AppendLine("<br>");
            strB.AppendLine("<div>");
            strB.AppendLine(objTexto.despedida);
            strB.AppendLine("</div>");

            strB.AppendLine("<br>");
            strB.AppendLine("<br>");
            strB.AppendLine("<br>");
            strB.AppendLine("</div>");

            strB.AppendLine("</div>");
            strB.AppendLine("</body>");
            strB.AppendLine("</html>");

            return strB;
        }

        //17.3 ---> 5.43
        private void ToEmailEnviarCorreo(Session_Movi objSession, CorreoEmp obj, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<EnCorreo> lsCorreoDatos = objDao.obtenerDatosCorreo(objSession, ref intResult, ref strMsjDB, ref strMsjUsuario);
            string host    = lsCorreoDatos[0].strhost;
            string puerto  = lsCorreoDatos[0].strpuerto;
            string ccorreo = lsCorreoDatos[0].strccorreo;
            string cpass   = lsCorreoDatos[0].strcpass;
            string cde     = lsCorreoDatos[0].strremitente;
            bool   auth    = lsCorreoDatos[0].bitAutentificacion;

            MailMessage msg = new MailMessage();

            try
            {

                // Create file attachment
                Attachment ImageAttachment = new Attachment(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\DirLogos\\logo.png");
                // Set the ContentId of the attachment, used in body HTML
                ImageAttachment.ContentId = "logo";
                msg.Attachments.Add(ImageAttachment);

                StringBuilder datos = htmlMessageBodyExcels(obj, "CAMBIODI");

                //receptores
                msg.To.Add(new MailAddress(obj.strCorreo));
                //msg.CC.Add(new MailAddress("programador04@tecflex.com"));

                //Remitente
                msg.From = new MailAddress(ccorreo);

                //Titulo
                ////msg.Subject = "Cambio de Usuario del Sistema de Control de Personal (SISCOP)";

                msg.Subject = "Cambio de Usuario del Sistema de Control de Personal (SISCOP)";

                //Cuerpo de correo
                msg.Body = datos.ToString();

                msg.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = host;
                smtp.Port = Int32.Parse(puerto);
                smtp.EnableSsl = auth;
                smtp.UseDefaultCredentials = true;
                //usuario y clave
                smtp.Credentials = new NetworkCredential(ccorreo, cpass);

                smtp.Send(msg);

                intResult = 1;
                strMsjUsuario = "El documento de identidad fue cambiado satisfactoriamente (correo enviado).";
            }

            catch (Exception ex)
            {
                intResult = 3;
                strMsjUsuario = "Ocurrió un error al enviar el correo";
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                //throw new Exception("Error General (EnviarCorreo)");
            }
        }

        //17.4 ---> 5.41
        //////////private StringBuilder htmlMessageBodyExcels(CorreoEmp obj, string filtro, string adicional = "")
        private StringBuilder htmlMessageBodyExcels(CorreoEmp obj, string filtro, string adicional = "")
        {
            StringBuilder strB = new StringBuilder();

            //////////int intResult = 0;
            //////////string strMsjDB = "";
            //////////string strMsjUsuario = "";

            //////////if (filtro == "REENVIO" && adicional != "")
            //////////{
            //////////    byte[] b = Convert.FromBase64String(adicional);
            //////////    adicional = System.Text.Encoding.UTF8.GetString(b);
            //////////}

            ////////////TEXTOCORREO objTexto = objDao.GetTextoCorreo(filtro, obj.intIdPersonal, 0, false, adicional, ref intResult, ref strMsjDB, ref strMsjUsuario);

            strB.AppendLine("<html>");
            strB.AppendLine("<body>");
            strB.AppendLine("<img src=cid:logo />");
            strB.AppendLine("<br>");
            strB.AppendLine("<div>");
            ////////////strB.AppendLine("<span style='font-size: large;'>" + objTexto.saludo + "</span>");
            strB.AppendLine("<span style='font-size: large;'>" + "saludo de prueba" + "</span>");
            strB.AppendLine("</div>");
            strB.AppendLine("<br>");
            strB.AppendLine("<div>");


            strB.AppendLine("<span>");
            strB.AppendLine("texto de prueba");
            strB.AppendLine("</span>");
            strB.AppendLine("<br>");


            ////////////if (!objTexto.texto1.Equals(""))
            ////////////{
            ////////////    strB.AppendLine("<span>");
            ////////////    strB.AppendLine(objTexto.texto1);
            ////////////    strB.AppendLine("</span>");
            ////////////    strB.AppendLine("<br>");
            ////////////}
            ////////////if (!objTexto.texto2.Equals(""))
            ////////////{
            ////////////    strB.AppendLine("<span>");
            ////////////    strB.AppendLine(objTexto.texto2);
            ////////////    strB.AppendLine("</span>");
            ////////////    strB.AppendLine("<br>");
            ////////////}
            ////////////if (!objTexto.texto3.Equals(""))
            ////////////{
            ////////////    strB.AppendLine("<span>");
            ////////////    strB.AppendLine(objTexto.texto3);
            ////////////    strB.AppendLine("</span>");
            ////////////    strB.AppendLine("<br>");
            ////////////}
            ////////////if (!objTexto.texto4.Equals(""))
            ////////////{
            ////////////    strB.AppendLine("<span>");
            ////////////    strB.AppendLine(objTexto.texto4);
            ////////////    strB.AppendLine("</span>");
            ////////////    strB.AppendLine("<br>");
            ////////////}
            ////////////if (!objTexto.texto5.Equals(""))
            ////////////{
            ////////////    strB.AppendLine("<span>");
            ////////////    strB.AppendLine(objTexto.texto5);
            ////////////    strB.AppendLine("</span>");
            ////////////    strB.AppendLine("<br>");
            ////////////}
            strB.AppendLine("</div>");
            strB.AppendLine("<br>");
            strB.AppendLine("<div>");
            strB.AppendLine("objTexto despedida");
            strB.AppendLine("</div>");

            strB.AppendLine("<br>");
            strB.AppendLine("<br>");
            strB.AppendLine("<br>");
            strB.AppendLine("</div>");
            //////////if (!objTexto.pie1.Equals(""))
            //////////{
            //////////    strB.AppendLine("<span>");
            //////////    strB.AppendLine(objTexto.pie1);
            //////////    strB.AppendLine("</span>");
            //////////    strB.AppendLine("<br>");
            //////////}
            //////////if (!objTexto.pie2.Equals(""))
            //////////{
            //////////    strB.AppendLine("<span>");
            //////////    strB.AppendLine(objTexto.pie2);
            //////////    strB.AppendLine("</span>");
            //////////    strB.AppendLine("<br>");
            //////////}
            //////////if (!objTexto.pie3.Equals(""))
            //////////{
            //////////    strB.AppendLine("<span>");
            //////////    strB.AppendLine(objTexto.pie3);
            //////////    strB.AppendLine("</span>");
            //////////    strB.AppendLine("<br>");
            //////////}
            strB.AppendLine("</div>");
            strB.AppendLine("</body>");
            strB.AppendLine("</html>");

            return strB;
        }

        #endregion

        #region IMPORTAR MASIVO EXCEL 


        /*================================================================================= 
        * 9.7 ELIMINAR TABLA POR TABLA POR TABLA O TODOS JUNTOS
        * =================================================================================*/
        public bool LimpiarTablasExcel(Session_Movi session, bool chckTodos, bool chckEntidad, bool chckLocal, bool chckArea, bool chckOficina, bool chckEmpleado, bool chckEstado, bool chckTipo, bool chckBienes, bool chckTmprodu, ref string strMsjUsuario)
            
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";
                bool estado = false;

                estado = objDao.LimpiarTablasExcel(session, chckTodos, chckEntidad, chckLocal, chckArea, chckOficina, chckEmpleado,  chckEstado, chckTipo, chckBienes, chckTmprodu, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[LimpiarTablasExcel] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return estado;
            }
            //catch (SqlException ex)
            //{
            //    Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
            //    throw new Exception("Ocurrió un error en BD (LimpiarTablasExcel)");
            //}
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (LimpiarTablasExcel)");
            }
        }


        /*================================================================================= 
         * 9.2 GUARDAR RUTA X IP EN LA TABLA TBRUTA DE LA BD: -RegistrarComedorConDni
         * =================================================================================*/
        public bool IRutaDirectorioPorIpMasivoExcel(Session_Movi objSession, string strDesRuta, string strSessionIp, ref string strMsjUsuario)
        {

            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                // using (TransactionScope scope = new TransactionScope())
                //{
                int idEmpresa = objDao.IRutaDirectorioPorIpMasivoExcel(objSession, strDesRuta, strSessionIp, ref intResult, ref strMsjDB, ref strMsjUsuario);

                //  scope.Complete();
                // }

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IRutaDirectorioPorIpMasivoExcel] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                else
                {

                    tudobem = true;
                }


                return tudobem;
            }

            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (IRutaDirectorioPorIpMasivoExcel)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (IRutaDirectorioPorIpMasivoExcel)");
            }

        }


        /*================================================================================= 
         * 9.1 IMPORTAR EXCEL - Los 08 excels en un solo Método
         * =================================================================================*/
        public List<ResultImportExcel> ImportExcelMasivoEntidad(Session_Movi session, string nombreExcel, int idProceso, int cboPlantilla, int cboFormato, bool checkActualizar, string rutaDirectorioExcel, ref string strMsjUsuario)
        {
            List<ResultImportExcel> listObj = new List<ResultImportExcel>();

            try
            {
                int insertadoActualizado = 0;
                string strConInconsistencia = "";

                int regInsertados = 0;
                int regActualizados = 0;
                int regInconsistentes = 0;

                int intResult = 0;
                string strMsjDB = "";
                string RutaMasivoEntidad = rutaDirectorioExcel;
                bool existe = VerificarRuta(RutaMasivoEntidad);

                List<string> arrListInconsistentes = new List<string>();
                //string arrListInconsistentes = "";


                if (existe == true)
                {
                    //Log.AlmacenarLogMensaje("[BL]" + nombreExcel);//PARA PRUEBAS

                    if (File.Exists(RutaMasivoEntidad + "\\" + nombreExcel))
                    {

                        //if (checkActualizar == true)
                        //{
                        //  objDao.LimpiarTablasExcel(session, true, false, false, false, false, false, false, false, false, ref intResult, ref strMsjDB, ref strMsjUsuario);
                        //}

                        DataTable dt = ReadExcelMasivo(nombreExcel, idProceso, RutaMasivoEntidad);

                        //if (checkActualizar == true)
                        //{
                        //    //condicion Flag Limpiar y Cargar
                        //    //objDao.LimpiarTablas_(1,1,1,1,1,1,1,1)
                        //    //objDao.LimpiarTablasExcel(session, chckTodos, chckEntidad, chckLocal, chckArea, chckOficina, chckEmpleado, chckEstado, chckTipo, chckBienes, ref intResult, ref strMsjDB, ref strMsjUsuario);
                        //    objDao.LimpiarTablasExcel(session, true , true, true, true, true, true, true, true, true, ref intResult, ref strMsjDB, ref strMsjUsuario);
                        //}

                        //9.1.1 - TBAREAS
                        if (nombreExcel.Contains("TBAREAS"))
                        {
                            intResult = objDao.ImportExcelMasivoEntidad(session, dt, "TBAREAS", insertadoActualizado, idProceso, cboPlantilla, 
                                cboFormato, checkActualizar, rutaDirectorioExcel, ref intResult, ref strMsjDB, ref strMsjUsuario, ref regInsertados,
                                ref regActualizados, ref regInconsistentes, ref strConInconsistencia, ref arrListInconsistentes);

                            ResultImportExcel ObjBienes = new ResultImportExcel();
                            ObjBienes.intInsertado = regInsertados;
                            ObjBienes.intActualizado = regActualizados;
                            ObjBienes.intInconsistente = regInconsistentes;
                            ObjBienes.strInconsistente = strConInconsistencia;//Mensaje String
                            ObjBienes.strNombreTabla = "TBAREAS";
                            listObj.Add(ObjBienes);
                        }
                        //9.1.2.- TBBIENES
                        else if (nombreExcel.Contains("TBBIENES"))
                        {
                            intResult = objDao.ImportExcelMasivoEntidad(session, dt, "TBBIENES", insertadoActualizado,  idProceso, cboPlantilla, cboFormato, checkActualizar, rutaDirectorioExcel, ref intResult, ref strMsjDB, ref strMsjUsuario, ref regInsertados, ref regActualizados, ref regInconsistentes, ref strConInconsistencia, ref arrListInconsistentes);

                            ResultImportExcel ObjBienes = new ResultImportExcel();
                            ObjBienes.intInsertado = regInsertados;
                            ObjBienes.intActualizado = regActualizados;
                            ObjBienes.intInconsistente = regInconsistentes;
                            ObjBienes.strInconsistente = strConInconsistencia;//Mensaje String

                            //ObjBienes.arrListInconsistentes.AddRange(arrListInconsistentes);
                            //ObjBienes.arrListInconsistentes.Add(arrListInconsistentes);
                            //ObjBienes.arrListInconsistentes.
                            ObjBienes.strNombreTabla = "TBBIENES";
                            listObj.Add(ObjBienes);
                        }
                        //9.1.3 - TBEMPLEADO
                        else if (nombreExcel.Contains("TBEMPLEADO"))
                        {
                            intResult = objDao.ImportExcelMasivoEntidad(session, dt, "TBEMPLEADO", insertadoActualizado,  idProceso, cboPlantilla, cboFormato, checkActualizar, rutaDirectorioExcel, ref intResult, ref strMsjDB, ref strMsjUsuario, ref regInsertados, ref regActualizados, ref regInconsistentes, ref strConInconsistencia, ref arrListInconsistentes);

                            ResultImportExcel ObjBienes = new ResultImportExcel();
                            ObjBienes.intInsertado = regInsertados;
                            ObjBienes.intActualizado = regActualizados;
                            ObjBienes.intInconsistente = regInconsistentes;
                            ObjBienes.strInconsistente = strConInconsistencia;//Mensaje String
                            ObjBienes.strNombreTabla = "TBEMPLEADO";
                            listObj.Add(ObjBienes);
                        }
                        //9.1.4 - ENTIDAD
                        else if (nombreExcel.Contains("TBENTIDAD"))
                        {
                            intResult = objDao.ImportExcelMasivoEntidad(session, dt, "TBENTIDAD", insertadoActualizado, idProceso, cboPlantilla, cboFormato, checkActualizar, rutaDirectorioExcel, ref intResult, ref strMsjDB, ref strMsjUsuario, ref regInsertados, ref regActualizados, ref regInconsistentes, ref strConInconsistencia, ref arrListInconsistentes);

                            //llenar los valos en la lista resultado.
                            ResultImportExcel ObjBienes = new ResultImportExcel();
                            ObjBienes.intInsertado = regInsertados;
                            ObjBienes.intActualizado = regActualizados;
                            ObjBienes.intInconsistente = regInconsistentes;
                            ObjBienes.strInconsistente = strConInconsistencia;//Mensaje String
                            ObjBienes.strNombreTabla = "TBENTIDAD";

                            listObj.Add(ObjBienes);
                        }
                        //9.1.5 - TBAREAS
                        else if (nombreExcel.Contains("TBESTADO"))
                        {
                            intResult = objDao.ImportExcelMasivoEntidad(session, dt, "TBESTADO", insertadoActualizado, idProceso, cboPlantilla, cboFormato, checkActualizar, rutaDirectorioExcel, ref intResult, ref strMsjDB, ref strMsjUsuario, ref regInsertados, ref regActualizados, ref regInconsistentes, ref strConInconsistencia, ref arrListInconsistentes);

                            ResultImportExcel ObjBienes = new ResultImportExcel();
                            ObjBienes.intInsertado = regInsertados;
                            ObjBienes.intActualizado = regActualizados;
                            ObjBienes.intInconsistente = regInconsistentes;
                            ObjBienes.strInconsistente = strConInconsistencia;//Mensaje String
                            ObjBienes.strNombreTabla = "TBESTADO";
                            listObj.Add(ObjBienes);
                        }
                        //9.1.6 - TBLOCAL
                        else if (nombreExcel.Contains("TBLOCAL"))
                        {
                            intResult = objDao.ImportExcelMasivoEntidad(session, dt, "TBLOCAL", insertadoActualizado, idProceso, cboPlantilla, cboFormato, checkActualizar, rutaDirectorioExcel, ref intResult, ref strMsjDB, ref strMsjUsuario, ref regInsertados, ref regActualizados, ref regInconsistentes, ref strConInconsistencia, ref arrListInconsistentes);

                            ResultImportExcel ObjBienes = new ResultImportExcel();
                            ObjBienes.intInsertado = regInsertados;
                            ObjBienes.intActualizado = regActualizados;
                            ObjBienes.intInconsistente = regInconsistentes;
                            ObjBienes.strInconsistente = strConInconsistencia;//Mensaje String
                            ObjBienes.strNombreTabla = "TBLOCAL";
                            listObj.Add(ObjBienes);
                        }
                        //9.1.7 - TBOFICINA
                        else if (nombreExcel.Contains("TBOFICINA"))
                        {
                            intResult = objDao.ImportExcelMasivoEntidad(session, dt, "TBOFICINA", insertadoActualizado, idProceso, cboPlantilla, cboFormato, checkActualizar, rutaDirectorioExcel, ref intResult, ref strMsjDB, ref strMsjUsuario, ref regInsertados, ref regActualizados, ref regInconsistentes, ref strConInconsistencia, ref arrListInconsistentes);

                            ResultImportExcel ObjBienes = new ResultImportExcel();
                            ObjBienes.intInsertado = regInsertados;
                            ObjBienes.intActualizado = regActualizados;
                            ObjBienes.intInconsistente = regInconsistentes;
                            ObjBienes.strInconsistente = strConInconsistencia;//Mensaje String
                            ObjBienes.strNombreTabla = "TBOFICINA";
                            listObj.Add(ObjBienes);
                        }
                        //9.1.8 - TBTIPO
                        else if (nombreExcel.Contains("TBTIPO"))
                        {
                            intResult = objDao.ImportExcelMasivoEntidad(session, dt, "TBTIPO", insertadoActualizado, idProceso, cboPlantilla, cboFormato, checkActualizar, rutaDirectorioExcel, ref intResult, ref strMsjDB, ref strMsjUsuario, ref regInsertados, ref regActualizados, ref regInconsistentes, ref strConInconsistencia, ref arrListInconsistentes);

                            ResultImportExcel ObjBienes = new ResultImportExcel();
                            ObjBienes.intInsertado = regInsertados;
                            ObjBienes.intActualizado = regActualizados;
                            ObjBienes.intInconsistente = regInconsistentes;
                            ObjBienes.strInconsistente = strConInconsistencia;//Mensaje String
                            ObjBienes.strNombreTabla = "TBTIPO";
                            listObj.Add(ObjBienes);
                        }

                    }


                    else
                    {
                        Log.AlmacenarLogMensaje("El excel importado no existe en el Servidor " + nombreExcel);
                        strMsjDB = "Vuelva a seleccionar el archivo a importar e inténtelo nuevamente.";
                    }
                }
                else
                {
                    Log.AlmacenarLogMensaje("Corrija la Ruta de Importación Masiva de Empleados (rutaEmpleadoMasivo del webconfig): " + RutaMasivoEntidad);
                    strMsjDB = "La Ruta del Directorio de Importación Masiva configurado en el Servidor no Existe.";
                }

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ImportExcelMasivoEntidad] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }


            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ImportMasivoEmpleado)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ImportExcelMasivoEntidad)");
            }
            return listObj;
        }



        //9.3 Método para leer el Excel y convertilo en tabla
        public DataTable ReadExcelMasivo(string nombreExcel, int idProceso, string RutaMasivoEntidad)
        {
            string urlRuta = RutaMasivoEntidad + "\\" + nombreExcel;
            DataTable table = new DataTable();
            try
            {
                string strExt = urlRuta.Substring(urlRuta.LastIndexOf("."));
                FileStream stream = File.Open(urlRuta, FileMode.Open, FileAccess.Read);
                IExcelDataReader excelReader;

                if (strExt == ".xls")
                    excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                else
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                var conf = new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };

                DataSet ds = new DataSet();
                ds = excelReader.AsDataSet(conf);
                stream.Close();

                DataTable dtExcelDatos = ds.Tables[0];
                int numCol = dtExcelDatos.Columns.Count;//Numero de columnas del excel
                                                        //tbImport = LlenarTableMasivo(dtExcelDatos, idProceso, nombreExcel);
                                                        //int numCol = dt.Columns.Count;
                                                        //DataTable table = new DataTable();

                //---------------------------------------------------------------
                //01
                if (nombreExcel.Contains("TBAREAS"))
                {
                    table.Columns.Add("local", typeof(string));
                    table.Columns.Add("codigo", typeof(string));
                    table.Columns.Add("descripcion", typeof(string));
                }

                ////////02 falta copiar columnas
                //////if (nombreExcel.Contains("TBBIENES"))
                //////{
                //////    //table.Columns.Add("intIdActivo", typeof(string)); // NO EXISTE EN EL EXCEL
                //////    table.Columns.Add("Descripcion", typeof(string));
                //////    table.Columns.Add("CodActivo", typeof(string));
                //////    table.Columns.Add("CodLocal", typeof(string));
                //////    table.Columns.Add("CodArea", typeof(string));
                //////    table.Columns.Add("CodOficina", typeof(string));

                //////    table.Columns.Add("CodAnterior", typeof(string));
                //////    table.Columns.Add("CodEmpleado", typeof(string));
                //////    table.Columns.Add("CodEstado", typeof(string));
                //////    table.Columns.Add("DesMarca", typeof(string));
                //////    table.Columns.Add("DesModelo", typeof(string));

                //////    table.Columns.Add("CodTipo", typeof(string));
                //////    table.Columns.Add("DesColor", typeof(string));
                //////    table.Columns.Add("DesSerie", typeof(string));
                //////    table.Columns.Add("DesNumMotor", typeof(string));
                //////    table.Columns.Add("DesNumChasis", typeof(string));

                //////    table.Columns.Add("Anio", typeof(string));//cadena
                //////    table.Columns.Add("DesDimension", typeof(string));
                //////    table.Columns.Add("DesPlaca", typeof(string));
                //////    table.Columns.Add("DesObservacion", typeof(string));
                //////    table.Columns.Add("FecCreacion", typeof(string));
                //////    table.Columns.Add("FecModificacion", typeof(string));

                //////}
                //02 
                if (nombreExcel.Contains("TBBIENES"))
                {
                    table.Columns.Add("Descripcion", typeof(string));
                    table.Columns.Add("CodActivo", typeof(string));
                    table.Columns.Add("CodLocal", typeof(string));
                    table.Columns.Add("CodArea", typeof(string));
                    table.Columns.Add("CodOficina", typeof(string));

                    table.Columns.Add("CodAnterior", typeof(string));
                    table.Columns.Add("CodEmpleado", typeof(string));
                    table.Columns.Add("CodEstado", typeof(string));
                    table.Columns.Add("DesMarca", typeof(string));
                    table.Columns.Add("DesModelo", typeof(string));

                    table.Columns.Add("CodTipo", typeof(string));
                    table.Columns.Add("DesColor", typeof(string));
                    table.Columns.Add("DesSerie", typeof(string));
                    table.Columns.Add("DesNumMotor", typeof(string));
                    table.Columns.Add("DesNumChasis", typeof(string));

                    table.Columns.Add("Anio", typeof(string));//cadena
                    table.Columns.Add("DesDimension", typeof(string));
                    table.Columns.Add("DesPlaca", typeof(string));
                    table.Columns.Add("DesObservacion", typeof(string));
                    table.Columns.Add("FecCreacion", typeof(string));
                    table.Columns.Add("FecModificacion", typeof(string));

                }
                //03 
                if (nombreExcel.Contains("TBEMPLEADO"))
                {
                    table.Columns.Add("local", typeof(string));
                    table.Columns.Add("area", typeof(string));
                    table.Columns.Add("codigo", typeof(string));
                    table.Columns.Add("descripcion", typeof(string));
                }
                //04 
                if (nombreExcel.Contains("TBENTIDAD"))
                {
                    table.Columns.Add("codigo", typeof(string));
                    table.Columns.Add("descripcion", typeof(string));
                }
                //05 
                if (nombreExcel.Contains("TBESTADO"))
                {
                    table.Columns.Add("codigo", typeof(string));
                    table.Columns.Add("descripcion", typeof(string));
                }
                //06
                if (nombreExcel.Contains("TBLOCAL"))
                {
                    table.Columns.Add("codigo", typeof(string));
                    table.Columns.Add("descripcion", typeof(string));
                }
                //07 
                if (nombreExcel.Contains("TBOFICINA"))
                {
                    table.Columns.Add("local", typeof(string));
                    table.Columns.Add("area", typeof(string));
                    table.Columns.Add("oficina", typeof(string));
                    table.Columns.Add("descripcion", typeof(string));
                }
                //08
                if (nombreExcel.Contains("TBTIPO"))
                {
                    table.Columns.Add("codigo", typeof(string));
                    table.Columns.Add("descripcion", typeof(string));
                }
                //---------------------------------------------------------------


                //Independiente de la estructura de table
                foreach (DataRow row in dtExcelDatos.Rows)
                {
                    DataRow rows = table.NewRow();

                    //01
                    if (nombreExcel.Contains("TBAREAS"))
                    {
                        rows["local"] = row[0];
                        rows["codigo"] = row[1];
                        rows["descripcion"] = row[2];
                    }
                    //02
                    if (nombreExcel.Contains("TBBIENES"))
                    {
                        rows["Descripcion"] = row[1];
                        rows["CodActivo"] = row[0];
                        rows["CodLocal"] = row[3];
                        rows["CodArea"] = row[4];
                        rows["CodOficina"] = row[5];

                        rows["CodAnterior"] = row[2];
                        rows["CodEmpleado"] = row[6];
                        rows["CodEstado"] = row[7];
                        rows["DesMarca"] = row[8];
                        rows["DesModelo"] = row[9];

                        rows["CodTipo"] = row[11];
                        rows["DesColor"] = row[12];
                        rows["DesSerie"] = row[10];
                        rows["DesNumMotor"] = row[14];
                        rows["DesNumChasis"] = row[15];

                        rows["Anio"] = row[13];
                        rows["DesDimension"] = row[16];
                        rows["DesPlaca"] = row[17];
                        rows["DesObservacion"] = row[18];
                        rows["FecCreacion"] = row[19];
                        rows["FecModificacion"] = row[20];


                        //rows["CodActivo"] = row[0];
                        //rows["Descripcion"] = row[1];
                        //rows["CodAnterior"] = row[2];
                        //rows["CodLocal"] = row[3];
                        //rows["CodArea"] = row[4];
                        //rows["CodOficina"] = row[5];
                        //rows["CodEmpleado"] = row[6];
                        //rows["CodEstado"] = row[7];
                        //rows["DesMarca"] = row[8];
                        //rows["DesModelo"] = row[9];
                        //rows["DesSerie"] = row[10];
                        //rows["CodTipo"] = row[11];
                        //rows["DesColor"] = row[12];
                        //rows["Anio"] = row[13];
                        //rows["DesNumMotor"] = row[14];
                        //rows["DesNumChasis"] = row[15];
                        //rows["DesDimension"] = row[16];
                        //rows["DesPlaca"] = row[17];
                        //rows["DesObservacion"] = row[18];
                        //rows["FecCreacion"] = row[19];
                        //rows["FecModificacion"] = row[20];

                    }
                    //03
                    if (nombreExcel.Contains("TBEMPLEADO"))
                    {
                        rows["local"] = row[0];
                        rows["area"] = row[1];
                        rows["codigo"] = row[2];
                        rows["descripcion"] = row[3];
                    }
                    //04
                    if (nombreExcel.Contains("TBENTIDAD"))
                    {
                        rows["codigo"] = row[0];
                        rows["descripcion"] = row[1];
                    }
                    //05
                    if (nombreExcel.Contains("TBESTADO"))
                    {
                        rows["codigo"] = row[0];
                        rows["descripcion"] = row[1];
                    }
                    //06
                    if (nombreExcel.Contains("TBLOCAL"))
                    {
                        rows["codigo"] = row[0];
                        rows["descripcion"] = row[1];
                    }
                    //07
                    if (nombreExcel.Contains("TBOFICINA"))
                    {
                        rows["local"] = row[0];
                        rows["area"] = row[1];
                        rows["oficina"] = row[2];
                        rows["descripcion"] = row[3];
                    }
                    //08
                    if (nombreExcel.Contains("TBTIPO"))
                    {
                        rows["codigo"] = row[0];
                        rows["descripcion"] = row[1];
                    }


                    table.Rows.Add(rows);
                    //contador++;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return table;
        }

        //5.73
        private bool VerificarRuta(string ruta)
        {
            bool si = false;
            if (System.IO.Directory.Exists(ruta))
            {
                si = true;
            }
            else
            {
                si = false;
            }
            return si;
        }
        #endregion

        #region RENOMBRAR CAMPOS

        //10.1  ListarCargos
        public List<RenombrarCampos> ListarRenombrarCampos(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            List<RenombrarCampos> lista = new List<RenombrarCampos>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarRenombrarCampos(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarRenombrarCampos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }

            }
            //catch (SqlException ex)
            //{
            //    Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
            //    throw new Exception("Ocurrió un error en BD (ListarCargos)");
            //}
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ListarRenombrarCampos)");
            }
            return lista;
        }

        //10.3  ListarCargosEditar
        public List<RenombrarCampos> getRenombrarCamposPorId(long intIdSesion, int intIdMenu, int intIdSoft, string strCodigo, ref string strMsjUsuario)
        {
            List<RenombrarCampos> lista = new List<RenombrarCampos>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.getRenombrarCamposPorId(intIdSesion, intIdMenu, intIdSoft, strCodigo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[getRenombrarCamposPorId] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            //catch (SqlException ex)
            //{
            //    Log.AlmacenarLogError(ex, "CargoBL.cs: SqlException");
            //    throw new Exception("Ocurrió un error en BD (ListarCamposEditar)");
            //}
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (getRenombrarCamposPorId)");
            }
            return lista;
        }

        //10.4
        public bool UpdateCamposRenombrados(Session_Movi objSession, int intTipoOperacion, RenombrarCampos objDatos, ref string strMsjUsuario)
        {

            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                // using (TransactionScope scope = new TransactionScope())
                //{
                int idEmpresa = objDao.UpdateCamposRenombrados(objSession, objDatos, intTipoOperacion, ref intResult, ref strMsjDB, ref strMsjUsuario);

                //  scope.Complete();
                // }

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[RegistrarComedorConDni] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                else
                {

                    tudobem = true;
                }


                return tudobem;
            }
            //catch (TransactionAbortedException ex)
            //{
            //    Log.AlmacenarLogError(ex, "ConsumoBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (RegistrarComedorConDni)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ConsumoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (RegistrarComedorConDni)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ConsumoBL.cs: Exception");
                throw new Exception("Error General (RegistrarComedorConDni)");
            }

        }


        //10.5
        public List<ValidacionPorLongitudDeCampo> MaestroMaximoCaracteres(string strMaestro)
        {
            List<ValidacionPorLongitudDeCampo> lista = new List<ValidacionPorLongitudDeCampo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.MaestroMaximoCaracteres(strMaestro);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[MaestroMaximoCaracteres] => Respuesta del Procedimiento : " + strMsjDB);

                    }
                }
            }
            //catch (SqlException ex)
            //{
            //    Log.AlmacenarLogError(ex, "PeriodoBL.cs: SqlException");
            //    throw new Exception("Ocurrió un error en BD (MaestroMaxCaracteres)");
            //}
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (MaestroMaximoCaracteres)");
            }
            return lista;
        }

        #endregion

        #region Pagina Principal - Dashboard

        //5.2.1.1  -- SAF Tortas
        public List<DashboardTortas> ListarDatosGraficaPie(Session_Movi objSession, string strNombreDeTorta, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<DashboardTortas> listObj = new List<DashboardTortas>();
            try
            {
                listObj = objDao.ListarDatosGraficaPie(objSession, strNombreDeTorta, dttFechaIni, dttFechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarDatosGraficaPie] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarDatosGraficaPie)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ListarDatosGraficaPie)");
            }
            return listObj;
        }
        //5.0
        public List<TSPTAASISTENCIA> ListarTipoBienes(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TSPTAASISTENCIA> listObj = new List<TSPTAASISTENCIA>();

            try
            {
                listObj = objDao.ListarTipoBienes(objSession, intIdPersonal, dttFechaIni, dttFechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarTipoBienes] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarTipoBienes)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ListarTipoBienes)");
            }
            return listObj;
        }
        //5.1
        public List<TSPTAASISTENCIA> ListarAsistenciaDiaria(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TSPTAASISTENCIA> listObj = new List<TSPTAASISTENCIA>();

            try
            {
                listObj = objDao.ListarAsistenciaDiaria(objSession, intIdPersonal, dttFechaIni, dttFechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarAsistenciaDiaria] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarAsistenciaDiaria)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ListarAsistenciaDiaria)");
            }
            return listObj;
        }
        //5.2
        public List<DiaAusen> ListarDiasAusencia(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<DiaAusen> listObj = new List<DiaAusen>();
            try
            {
                listObj = objDao.ListarDiasAusencia(objSession, intIdPersonal, dttFechaIni, dttFechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarDiasAusencia] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarDiasAusencia)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ListarDiasAusencia)");
            }
            return listObj;
        }
        //5.3
        public List<HomeCabe> ListarCabeceras(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<HomeCabe> listObj = new List<HomeCabe>();
            try
            {
                listObj = objDao.ListarCabeceras(objSession, intIdPersonal, dttFechaIni, dttFechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCabeceras] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCabeceras)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ListarCabeceras)");
            }
            return listObj;
        }
        //5.4
        public List<HorasDesc> ListarHorasDescontadas(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<HorasDesc> listObj = new List<HorasDesc>();
            try
            {
                listObj = objDao.ListarHorasDescontadas(objSession, intIdPersonal, dttFechaIni, dttFechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarHorasDescontadas] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarHorasDescontadas)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ListarHorasDescontadas)");
            }
            return listObj;
        }
        //5.5
        public List<HorasDesc> ListarHorasExtras(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<HorasDesc> listObj = new List<HorasDesc>();
            try
            {
                listObj = objDao.ListarHorasExtras(objSession, intIdPersonal, dttFechaIni, dttFechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarHorasExtras] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarHorasExtras)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ListarHorasExtras)");
            }
            return listObj;
        }

        #endregion

        #region Empleado
        //5.6
        public List<TGPER_CON_DET> ListaAsusencias(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, string fechaInicio, string fechaFin, ref string strMsjUsuario)
        {
            List<TGPER_CON_DET> lista = new List<TGPER_CON_DET>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListaAsusencias(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, fechaInicio, fechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListaAsusencias] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListaAsusencias)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ListaAsusencias)");
            }
            return lista;
        }
        //5.7
        public List<TGPER_CON_DET> ListaAsistencias(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, string fechaInicio, string fechaFin, ref string strMsjUsuario)
        {
            List<TGPER_CON_DET> lista = new List<TGPER_CON_DET>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListaAsistencias(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, fechaInicio, fechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListaAsistencias] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListaAsistencias)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ListaAsistencias)");
            }
            return lista;
        }
        //5.8
        public List<TGPER_RESP> ListaPersonalResponsabilidad(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, string fechaInicio, string fechaFin, ref string strMsjUsuario)
        {
            List<TGPER_RESP> lista = new List<TGPER_RESP>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListaPersonalResponsabilidad(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, fechaInicio, fechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListaPersonalResponsabilidad] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListaPersonalResponsabilidad)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ListaPersonalResponsabilidad)");
            }
            return lista;
        }
        //5.9
        public List<PersonalData> ListarPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, int intIdUniOrg, string strfilter, string dttfiltrofch1, string dttfiltrofch2, ref string strMsjUsuario)
        {
            List<PersonalData> lista = new List<PersonalData>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarPersonal(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, intIdUniOrg, strfilter, dttfiltrofch1, dttfiltrofch2, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarPersonal] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarPersonal)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ListarPersonal)");
            }
            return lista;
        }
        //5.10 - 6.6
        public List<TGTipoEN> ListarCombos(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCombos(intIdSesion, intIdMenu, intIdSoft, strEntidad, intIdFiltroGrupo, strGrupo, strSubGrupo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCombos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCombos)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ListarCombos)");
            }
            return lista;
        }
        //5.11
        public List<TGTipoEN> ListarComboJerar(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarComboJerar(intIdSesion, intIdMenu, intIdSoft, strEntidad, intIdFiltroGrupo, strGrupo, strSubGrupo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarComboJerar] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarComboJerar)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ListarComboJerar)");
            }
            return lista;
        }
        //5.12
        public List<Personal> ObtenerEmpleadoPorsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref string strMsjUsuario)
        {
            List<Personal> lista = new List<Personal>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerEmpleadoPorsuPK(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerEmpleadoPorsuPK] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerEmpleadoPorsuPK)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ObtenerEmpleadoPorsuPK)");
            }
            return lista;
        }
        //5.13
        public List<ValidarIdentidad_ENT> ValidarDocIdentidad(int intIdSesion, int intIdMenu, int intIdSoft, int intIdTipDoc, string strNumDoc, ref string strMsjUsuario)
        {

            List<ValidarIdentidad_ENT> lista = new List<ValidarIdentidad_ENT>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ValidarDocIdentidad(intIdSesion, intIdMenu, intIdSoft, intIdTipDoc, strNumDoc, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ValidarDocIdentidad] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ValidarDocIdentidad)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ValidarDocIdentidad)");
            }
            return lista;

          
        }
        //5.14
        public Dictionary<string, string> ReenviarCorreo(Session_Movi objSession, int intIdPersonal, ref string strMsjUsuario)
        {

            Dictionary<string, string> obj = new Dictionary<string, string>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                Personal empleado = new Personal();
                empleado = objDao.ObtenerEmpleadoPorsuPK(objSession.intIdSesion, objSession.intIdMenu, objSession.intIdSoft, intIdPersonal, ref intResult, ref strMsjDB, ref strMsjUsuario).First();
                if (!empleado.bitActivarUsuario)
                {
                    obj.Add("activo", "no");
                }
                else
                {
                    obj.Add("activo", "si");

                    //Codificar contraseña actual para validacion
                    byte[] byt = System.Text.Encoding.UTF8.GetBytes("@" + empleado.strApePaterno.Substring(0, 1).ToUpper() + empleado.strApePaterno.Substring(1).ToLower() + empleado.strNumDoc.Trim());
                    string contrasena = Convert.ToBase64String(byt);

                    Dictionary<string, string> objeto = new Dictionary<string, string>();
                    objeto = objDao.ActivarUsuario(objSession, intIdPersonal, contrasena, ref intResult, ref strMsjDB, ref strMsjUsuario);

                    if (objeto.Count == 0)
                    {
                        obj.Add("mensaje", "No cuenta con correo");

                        return obj;
                    }

                    CorreoEmp objCor = new CorreoEmp();
                    objCor.intIdPersonal = intIdPersonal;
                    objCor.strNomCompleto = objeto["nombres"];
                    objCor.strCorreo = objeto["correo"];
                    objCor.strNumDocNue = objeto["numeroDoc"];

                    reenviarCorreoEmpleado(objSession, objCor, 2, false, objeto["contraOut"], ref intResult, ref strMsjDB, ref strMsjUsuario);
                    obj.Add("mensaje", strMsjUsuario);
                }


                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ReenviarCorreo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ReenviarCorreo)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ReenviarCorreo)");
            }
            return obj;
        }
        //5.15
        public string ActivarUsuario(Session_Movi objSession, int intIdPersonal, ref string strMsjUsuario)
        {
            string salida = "";
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                Personal empleado = new Personal();
                empleado = objDao.ObtenerEmpleadoPorsuPK(objSession.intIdSesion, objSession.intIdMenu, objSession.intIdSoft, intIdPersonal, ref intResult, ref strMsjDB, ref strMsjUsuario).First();
                //Codificar contraseña actual para validacion
                byte[] byt = System.Text.Encoding.UTF8.GetBytes("@" + empleado.strApePaterno.Substring(0, 1).ToUpper() + empleado.strApePaterno.Substring(1).ToLower() + empleado.strNumDoc.Trim());
                string contrasena = Convert.ToBase64String(byt);

                Dictionary<string, string> objeto = new Dictionary<string, string>();
                objeto = objDao.ActivarUsuario(objSession, intIdPersonal, contrasena, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (objeto.Count == 0)
                {
                    salida = "Se activo el usuario, Pero no cuenta con correo";
                    return salida;
                }

                CorreoEmp obj = new CorreoEmp();
                obj.intIdPersonal = intIdPersonal;
                obj.strNomCompleto = objeto["nombres"];
                obj.strCorreo = objeto["correo"];
                obj.strNumDocNue = objeto["numeroDoc"];

                reenviarCorreoEmpleado(objSession, obj, 2, false, objeto["contraOut"], ref intResult, ref strMsjDB, ref strMsjUsuario);
                salida = strMsjUsuario;

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ActivarUsuario] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ActivarUsuario)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ActivarUsuario)");
            }
            return salida;
        }
        //5.16
        public string ValidarEmail(Session_Movi objSession, string numDoc, string correo, ref string strMsjUsuario)
        {
            string salida = "";
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                salida = objDao.ValidarEmail(objSession, numDoc, correo, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (!salida.Equals("no"))
                {
                    CorreoEmp obj = new CorreoEmp();
                    obj.intIdPersonal = Int32.Parse(salida);
                    obj.strCorreo = correo;
                    
                    enviarCorreoValidacion(objSession, obj, ref intResult, ref strMsjDB, ref strMsjUsuario);
                }

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ValidarEmail] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ValidarEmail)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ValidarEmail)");
            }
            return salida;
        }
        //5.17
        public bool EliminarEmpleado(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdPersonal, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";
                bool tudobem = false;

                tudobem = objDao.EliminarEmpleado(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdPersonal, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminarEmpleado] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminarEmpleado)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (EliminarEmpleado)");
            }
        }
        //5.18
        public bool ActualizarEmpleado_T(long intIdSesion, int intIdMenu, int intIdSoft, Personal objDatos, List<TGPERCORRDET> listaDetallesCorreos, List<TGPERTELEFDET> listaDetallesTelefonos, int intIdUsuario, int intIdUsuarModif, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";
                string Msj = "";

                intResult = objDao.UEmpleado_T(intIdSesion, intIdMenu, intIdSoft, objDatos, listaDetallesCorreos, listaDetallesTelefonos, intIdUsuario, intIdUsuarModif, ref intResult, ref strMsjDB, ref strMsjUsuario, ref Msj);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ActualizarEmpleado_T] => Respuesta del Procedimiento : " + strMsjDB);
                        Log.AlmacenarLogMensaje("[ActualizarEmpleado_T] => Respuesta del Procedimiento : " + Msj);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                else
                {
                    tudobem = true;
                }
                return tudobem;
            }
            //catch (TransactionAbortedException ex)
            //{
            //    Log.AlmacenarLogError(ex, "ImportarExcelBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (ActualizarEmpleado_T)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ActualizarEmpleado_T)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ActualizarEmpleado_T)");
            }
        }
        //5.19
        public bool RegistrarOActualizarEmpleado_T(long intIdSesion, int intIdMenu, int intIdSoft, Personal objDatos, MarcaDni ObjMarcaConDni, List<TGPERCORRDET> listaDetallesCorreos, List<TGPERTELEFDET> listaDetallesTelefonos,
            List<TGPERRESPDET> listaDetallesResponsabilidad, List<TGPERMARCDET> listaDetallesMarcadores, List<TGPERCOOR> listaCoor, int intIdUsuario, int intIdUsuarModif, bool activaUsuario, bool desactivaUsuario, bool activarAdmin,
            int intTipoOperacion, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";
                string Msj = "";
                int idPersonal = 0;

                Session_Movi objSession = new Session_Movi();
                objSession.intIdMenu = intIdMenu;
                objSession.intIdSesion = (int)intIdSesion;
                objSession.intIdSoft = intIdSoft;
                objSession.intIdUsuario = 1;

                CorreoEmp obj = new CorreoEmp();
                obj.strNomCompleto = objDatos.strNombres;
                obj.strCorreo = listaDetallesCorreos.Find(x => x.bitFlPrincipal == true).strCorreo;
                obj.strNumDocNue = objDatos.strNumDoc;

                idPersonal = objDao.IUEmpleado_T(intIdSesion, intIdMenu, intIdSoft, objDatos, ObjMarcaConDni, listaDetallesCorreos, listaDetallesTelefonos, listaDetallesResponsabilidad, listaDetallesMarcadores, listaCoor, intIdUsuario, intIdUsuarModif, intTipoOperacion, ref intResult, ref strMsjDB, ref strMsjUsuario, ref Msj);

                if (idPersonal > 0 && intResult > 0)
                {
                    if (activaUsuario || desactivaUsuario)
                    {
                        obj.intIdPersonal = idPersonal;
                        enviarCorreoEmpleado(objSession, obj, intTipoOperacion, desactivaUsuario, ref intResult, ref strMsjDB, ref strMsjUsuario);
                    }
                    if (!activaUsuario && activarAdmin)
                    {
                        obj.intIdPersonal = idPersonal;
                        enviarCorreoActivarAdmin(objSession, obj, intTipoOperacion, desactivaUsuario, "", ref intResult, ref strMsjDB, ref strMsjUsuario);
                    }
                }

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[RegistrarOActualizarEmpleado_T] => Respuesta del Procedimiento : " + strMsjDB);
                        Log.AlmacenarLogMensaje("[RegistrarOActualizarEmpleado_T] => Respuesta de la clase de Datos: " + Msj);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                else
                {
                    tudobem = true;
                }
                return tudobem;
            }
            //catch (TransactionAbortedException ex)
            //{
            //    Log.AlmacenarLogError(ex, "ImportarExcelBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (RegistrarOActualizarEmpleado_T)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (RegistrarOActualizarEmpleado_T)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (RegistrarOActualizarEmpleado_T)");
            }
        }
        //5.20
        public List<TGPERMARCDET> ListarMarcadoresPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPerMarc, ref string strMsjUsuario)
        {

            List<TGPERMARCDET> lista = new List<TGPERMARCDET>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarMarcadoresPersonal(intIdSesion, intIdMenu, intIdSoft, intIdPerMarc, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarMarcadoresPersonal] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarMarcadoresPersonal)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ListarMarcadoresPersonal)");
            }
            return lista;


        }
        //5.21
        public List<TGPERCORRDET> ListarCorreosPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref string strMsjUsuario)
        {

            List<TGPERCORRDET> lista = new List<TGPERCORRDET>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCorreosPersonal(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCorreosPersonal] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCorreosPersonal)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ListarCorreosPersonal)");
            }
            return lista;


        }
        //5.22
        public List<TGPERTELEFDET> ListarTelefonosPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref string strMsjUsuario)
        {

            List<TGPERTELEFDET> lista = new List<TGPERTELEFDET>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarTelefonosPersonal(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarTelefonosPersonal] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarTelefonosPersonal)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ListarTelefonosPersonal)");
            }
            return lista;


        }
        //5.23
        public List<TGPERCOOR> listarCoordenadas(int intIdPersonal, ref string strMsjUsuario)
        {
            List<TGPERCOOR> lista = new List<TGPERCOOR>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.listarCoordenadas(intIdPersonal, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[listarCoordenadas] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (listarCoordenadas)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (listarCoordenadas)");
            }
            return lista;
        }
        //5.24
        public List<TGPERRESPDET> ListarResponsabilidadPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref string strMsjUsuario)
        {

            List<TGPERRESPDET> lista = new List<TGPERRESPDET>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarResponsabilidadPersonal(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[.ListarResponsabilidadPersonal] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (.ListarResponsabilidadPersonal)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (.ListarResponsabilidadPersonal)");
            }
            return lista;


        }

        #endregion Empleado

        #region MarcaEmpleadoDni
        //5.25
        public List<MarcaDni> ObtenerEmpleadoConMarcaDNI(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref string strMsjUsuario)
        {
            List<MarcaDni> lista = new List<MarcaDni>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerEmpleadoConMarcaDNI(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerEmpleadoConMarcaDNI] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerEmpleadoConMarcaDNI)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ObtenerEmpleadoConMarcaDNI)");
            }
            return lista;
        }

        #endregion MarcaEmpleadoDni
       
        //5.33
        public List<EmpleadoMasivo> ListGrupoLiquidacion(Session_Movi session, EmpleadoMasivo lista, ref string strMsjUsuario)
        {
            List<EmpleadoMasivo> listObj = new List<EmpleadoMasivo>();

            try
            {
                int intResult = 0;
                string strMsjDB = "";

                listObj = objDao.ListGrupoLiquidacion(session, lista, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListGrupoLiquidacion] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListGrupoLiquidacion)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ListGrupoLiquidacion)");
            }
            return listObj;
        }

        //5.35
        public List<EmpleadoMasivo> GuardarMasivoEmpleado(Session_Movi session, int idProceso, string nombreExcel, string RutaMasivoEntidad, ref string strMsjUsuario)
        {
            List<EmpleadoMasivo> lista = new List<EmpleadoMasivo>();

            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.GuardarMasivoEmpleado(session, idProceso, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (File.Exists(RutaMasivoEntidad + "\\" + nombreExcel))
                {
                    if (intResult == 1)
                    {
                        //eliminar el archivo excel
                        File.Delete(RutaMasivoEntidad + "\\" + nombreExcel);
                    }
                }
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[GuardarMasivoEmpleado] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (GuardarMasivoEmpleado)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (GuardarMasivoEmpleado)");
            }
            return lista;
        }


        #region CambioDI
        //5.38
        public ValidarIdentidad_DI ValidarDocCambioIdentidad(Session_Movi objSession, int intIdTipDoc, string strNumDoc, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            ValidarIdentidad_DI obj = new ValidarIdentidad_DI();

            try
            {
                obj = objDao.ValidarDocCambioIdentidad(objSession, intIdTipDoc, strNumDoc, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ValidarDocCambioIdentidad] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ValidarDocCambioIdentidad)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ValidarDocCambioIdentidad)");
            }
            return obj;
        }
        //5.39
        public List<CambioDI> ListarCambioDI(Session_Movi objSession, string buscarId, int empresaId, string filtrojer_ini, string filtrojer_fin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<CambioDI> listObj = new List<CambioDI>();

            try
            {
                listObj = objDao.ListarCambioDI(objSession, buscarId, empresaId, filtrojer_ini, filtrojer_fin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCambioDI] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCambioDI)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ListarCambioDI)");
            }
            return listObj;
        }
        //5.40
        public int ActualizarCambioDI(Session_Movi objSession, PersonalCDI personalCDI, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            int intID = 0;

            try
            {
                objDao.ActualizarCambioDI(objSession, personalCDI, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult != 0)
                {
                    CorreoEmp obj = objDao.GetCorreo(personalCDI.intIdPerso, ref intResult, ref strMsjDB, ref strMsjUsuario);
                    if (obj.strCorreo != null)
                    {
                        obj.intIdPersonal = personalCDI.intIdPerso;
                        enviarCorreo(objSession, obj, ref intResult, ref strMsjDB, ref strMsjUsuario);
                    }
                    else
                    {
                        intResult = 2;
                        strMsjUsuario = "No se envió el correo debido a que el usuario no cuenta con un correo registrado";
                    }
                }

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ActualizarCambioDI] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ActualizarCambioDI)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ActualizarCambioDI)");
            }
            return intID;
        }
        //5.41
        private StringBuilder htmlMessageBody(CorreoEmp obj, string filtro, string adicional = "")
        {
            StringBuilder strB = new StringBuilder();

            int intResult = 0;
            string strMsjDB = "";
            string strMsjUsuario = "";

            if (filtro == "REENVIO" && adicional != "")
            {
                byte[] b = Convert.FromBase64String(adicional);
                adicional = System.Text.Encoding.UTF8.GetString(b);
            }

            TEXTOCORREO objTexto = objDao.GetTextoCorreo(filtro, obj.intIdPersonal, 0, false, adicional, ref intResult, ref strMsjDB, ref strMsjUsuario);

            strB.AppendLine("<html>");
            strB.AppendLine("<body>");
            strB.AppendLine("<img src=cid:logo />");
            strB.AppendLine("<br>");
            strB.AppendLine("<div>");
            strB.AppendLine("<span style='font-size: large;'>" + objTexto.saludo + "</span>");
            strB.AppendLine("</div>");
            strB.AppendLine("<br>");
            strB.AppendLine("<div>");
            if (!objTexto.texto1.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.texto1);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.texto2.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.texto2);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.texto3.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.texto3);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.texto4.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.texto4);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.texto5.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.texto5);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            strB.AppendLine("</div>");
            strB.AppendLine("<br>");
            strB.AppendLine("<div>");
            strB.AppendLine(objTexto.despedida);
            strB.AppendLine("</div>");

            strB.AppendLine("<br>");
            strB.AppendLine("<br>");
            strB.AppendLine("<br>");
            strB.AppendLine("</div>");
            if (!objTexto.pie1.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.pie1);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.pie2.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.pie2);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.pie3.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.pie3);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            strB.AppendLine("</div>");
            strB.AppendLine("</body>");
            strB.AppendLine("</html>");

            return strB;
        }
        //5.42
        private StringBuilder htmlMessageBodyEmpleado(CorreoEmp obj, int intFiltro, bool desactivaUsuario)
        {
            StringBuilder strB = new StringBuilder();

            int intResult = 0;
            string strMsjDB = "";
            string strMsjUsuario = "";
            TEXTOCORREO objTexto = objDao.GetTextoCorreo("EMPLEADO", obj.intIdPersonal, intFiltro, desactivaUsuario, "", ref intResult, ref strMsjDB, ref strMsjUsuario);

            strB.AppendLine("<html>");
            strB.AppendLine("<body>");
            strB.AppendLine("<img src=cid:logo />");
            strB.AppendLine("<br>");
            strB.AppendLine("<div>");
            strB.AppendLine("<span style='font-size: large;'>" + objTexto.saludo + "</span>");
            strB.AppendLine("</div>");
            strB.AppendLine("<br>");
            strB.AppendLine("<div>");
            if (!objTexto.texto1.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.texto1);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.texto2.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.texto2);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.texto3.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.texto3);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.texto4.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.texto4);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.texto5.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.texto5);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            strB.AppendLine("</div>");
            strB.AppendLine("<br>");
            strB.AppendLine("<div>");
            strB.AppendLine(objTexto.despedida);
            strB.AppendLine("</div>");

            strB.AppendLine("<br>");
            strB.AppendLine("<br>");
            strB.AppendLine("<br>");
            strB.AppendLine("</div>");
            if (!objTexto.pie1.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.pie1);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.pie2.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.pie2);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.pie3.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.pie3);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            strB.AppendLine("</div>");
            strB.AppendLine("</body>");
            strB.AppendLine("</html>");

            return strB;
        }
        //5.43
        private void enviarCorreo(Session_Movi objSession, CorreoEmp obj, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<EnCorreo> lsCorreoDatos = objDao.obtenerDatosCorreo(objSession, ref intResult, ref strMsjDB, ref strMsjUsuario);
            string host = lsCorreoDatos[0].strhost;
            string puerto = lsCorreoDatos[0].strpuerto;
            string ccorreo = lsCorreoDatos[0].strccorreo;
            string cpass = lsCorreoDatos[0].strcpass;
            string cde = lsCorreoDatos[0].strremitente;
            bool auth = lsCorreoDatos[0].bitAutentificacion;

            MailMessage msg = new MailMessage();

            try
            {

                // Create file attachment
                Attachment ImageAttachment = new Attachment(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\DirLogos\\logo.png");
                // Set the ContentId of the attachment, used in body HTML
                ImageAttachment.ContentId = "logo";
                msg.Attachments.Add(ImageAttachment);

                StringBuilder datos = htmlMessageBody(obj, "CAMBIODI");

                //receptores
                msg.To.Add(new MailAddress(obj.strCorreo));
                //msg.CC.Add(new MailAddress("programador04@tecflex.com"));

                //Remitente
                msg.From = new MailAddress(ccorreo);

                //Titulo
                msg.Subject = "Cambio de Usuario del Sistema de Control de Personal (SISCOP)";

                //Cuerpo de correo
                msg.Body = datos.ToString();

                msg.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = host;
                smtp.Port = Int32.Parse(puerto);
                smtp.EnableSsl = auth;
                smtp.UseDefaultCredentials = true;
                //usuario y clave
                smtp.Credentials = new NetworkCredential(ccorreo, cpass);

                smtp.Send(msg);

                intResult = 1;
                strMsjUsuario = "El documento de identidad fue cambiado satisfactoriamente (correo enviado).";
            }

            catch (Exception ex)
            {
                intResult = 3;
                strMsjUsuario = "Ocurrió un error al enviar el correo";
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                //throw new Exception("Error General (EnviarCorreo)");
            }
        }
        //5.44
        private int enviarCorreoEmpleado(Session_Movi objSession, CorreoEmp obj, int intTipoOperacion, bool desactivaUsuario, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<EnCorreo> lsCorreoDatos = objDao.obtenerDatosCorreo(objSession, ref intResult, ref strMsjDB, ref strMsjUsuario);
            string host = lsCorreoDatos[0].strhost;
            string puerto = lsCorreoDatos[0].strpuerto;
            string ccorreo = lsCorreoDatos[0].strccorreo;
            string cpass = lsCorreoDatos[0].strcpass;
            string cde = lsCorreoDatos[0].strremitente;
            bool auth = lsCorreoDatos[0].bitAutentificacion;

            MailMessage msg = new MailMessage();

            try
            {

                // Create file attachment
                Attachment ImageAttachment = new Attachment(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\DirLogos\\logo.png");
                // Set the ContentId of the attachment, used in body HTML
                ImageAttachment.ContentId = "logo";
                msg.Attachments.Add(ImageAttachment);

                StringBuilder datos = htmlMessageBodyEmpleado(obj, intTipoOperacion, desactivaUsuario);

                //receptores
                msg.To.Add(new MailAddress(obj.strCorreo));
                //msg.To.Add(new MailAddress("ereyes@tecflex.com"));
                //msg.CC.Add(new MailAddress("esuyon@tecflex.com"));
                //msg.CC.Add(new MailAddress("programador04@tecflex.com"));

                //Remitente
                msg.From = new MailAddress(ccorreo);

                if (desactivaUsuario)
                {
                    //Titulo
                    msg.Subject = "Desactivación de Usuario";
                }
                else
                {
                    //Titulo
                    msg.Subject = "Activación de Usuario";
                }


                //Cuerpo de correo
                msg.Body = datos.ToString();

                msg.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = host;
                    smtp.Port = Int32.Parse(puerto);
                    smtp.EnableSsl = auth;
                    smtp.UseDefaultCredentials = true;
                    //usuario y clave
                    smtp.Credentials = new NetworkCredential(ccorreo, cpass);

                    smtp.Send(msg);
                }

                intResult = 1;
                if (intTipoOperacion == 1)
                {
                    strMsjUsuario = "Se Activó el usuario satisfactoriamente (correo enviado).";
                }
                else
                {
                    if (desactivaUsuario)
                    {
                        strMsjUsuario = "Se inactivó el usuario satisfactoriamente (correo enviado).";
                    }
                    else
                    {
                        strMsjUsuario = "Se reactivó el usuario satisfactoriamente (correo enviado).";
                    }
                }

            }

            catch (Exception ex)
            {
                intResult = 3;
                strMsjUsuario = "Ocurrió un error al enviar el correo";
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                //throw new Exception("Error General (EnviarCorreo)");
            }
            return intResult;
        }
        //5.45
        private int enviarCorreoActivarAdmin(Session_Movi objSession, CorreoEmp obj, int intTipoOperacion, bool desactivaUsuario, string strAdicional, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<EnCorreo> lsCorreoDatos = objDao.obtenerDatosCorreo(objSession, ref intResult, ref strMsjDB, ref strMsjUsuario);
            string host = lsCorreoDatos[0].strhost;
            string puerto = lsCorreoDatos[0].strpuerto;
            string ccorreo = lsCorreoDatos[0].strccorreo;
            string cpass = lsCorreoDatos[0].strcpass;
            string cde = lsCorreoDatos[0].strremitente;
            bool auth = lsCorreoDatos[0].bitAutentificacion;

            MailMessage msg = new MailMessage();

            try
            {

                // Create file attachment
                Attachment ImageAttachment = new Attachment(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\DirLogos\\logo.png");
                // Set the ContentId of the attachment, used in body HTML
                ImageAttachment.ContentId = "logo";
                msg.Attachments.Add(ImageAttachment);

                StringBuilder datos = htmlMessageBody(obj, "ACTIVARADMIN", strAdicional);

                //receptores
                msg.To.Add(new MailAddress(obj.strCorreo));

                //Remitente
                msg.From = new MailAddress(ccorreo);

                msg.Subject = "Cambio de Rol";

                //Cuerpo de correo
                msg.Body = datos.ToString();

                msg.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = host;
                    smtp.Port = Int32.Parse(puerto);
                    smtp.EnableSsl = auth;
                    smtp.UseDefaultCredentials = true;
                    //usuario y clave
                    smtp.Credentials = new NetworkCredential(ccorreo, cpass);

                    smtp.Send(msg);
                }

                intResult = 1;
                strMsjUsuario = "Se cambió el rol de usuario satisfactoriamente (correo enviado).";

            }

            catch (Exception ex)
            {
                intResult = 3;
                strMsjUsuario = "Ocurrió un error al enviar el correo Cambio de Rol";
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                //throw new Exception("Error General (EnviarCorreo)");
            }
            return intResult;
        }
        //5.46
        private int reenviarCorreoEmpleado(Session_Movi objSession, CorreoEmp obj, int intTipoOperacion, bool desactivaUsuario, string strAdicional, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<EnCorreo> lsCorreoDatos = objDao.obtenerDatosCorreo(objSession, ref intResult, ref strMsjDB, ref strMsjUsuario);
            string host = lsCorreoDatos[0].strhost;
            string puerto = lsCorreoDatos[0].strpuerto;
            string ccorreo = lsCorreoDatos[0].strccorreo;
            string cpass = lsCorreoDatos[0].strcpass;
            string cde = lsCorreoDatos[0].strremitente;
            bool auth = lsCorreoDatos[0].bitAutentificacion;

            MailMessage msg = new MailMessage();

            try
            {

                // Create file attachment
                Attachment ImageAttachment = new Attachment(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\DirLogos\\logo.png");
                // Set the ContentId of the attachment, used in body HTML
                ImageAttachment.ContentId = "logo";
                msg.Attachments.Add(ImageAttachment);

                StringBuilder datos = htmlMessageBody(obj, "REENVIO", strAdicional);

                //receptores
                //////////msg.To.Add(new MailAddress(obj.strCorreo));
                //msg.To.Add(new MailAddress("ereyes@tecflex.com"));
                //msg.CC.Add(new MailAddress("esuyon@tecflex.com"));
                msg.To.Add(new MailAddress("programador05@tecflex.com"));

                //Remitente
                msg.From = new MailAddress(ccorreo);

                //Titulo
                msg.Subject = "Re: Credenciales de usuario";

                //Cuerpo de correo
                msg.Body = datos.ToString();

                msg.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = host;
                    smtp.Port = Int32.Parse(puerto);
                    smtp.EnableSsl = auth;
                    smtp.UseDefaultCredentials = false;//true
                    //usuario y clave
                    smtp.Credentials = new NetworkCredential(ccorreo, cpass);

                    smtp.Send(msg);
                }

                intResult = 1;
                strMsjUsuario = "Se envió el correo con credenciales.";

            }

            catch (Exception ex)
            {
                intResult = 3;
                strMsjUsuario = "Ocurrió un error al enviar el correo";
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
               
            }
            return intResult;
        }
        //5.47
        private int enviarCorreoValidacion(Session_Movi objSession, CorreoEmp obj, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<EnCorreo> lsCorreoDatos = objDao.obtenerDatosCorreo(objSession, ref intResult, ref strMsjDB, ref strMsjUsuario);
            string host = lsCorreoDatos[0].strhost;
            string puerto = lsCorreoDatos[0].strpuerto;
            string ccorreo = lsCorreoDatos[0].strccorreo;
            string cpass = lsCorreoDatos[0].strcpass;
            string cde = lsCorreoDatos[0].strremitente;
            bool auth = lsCorreoDatos[0].bitAutentificacion;

            MailMessage msg = new MailMessage();

            try
            {

                // Create file attachment
                Attachment ImageAttachment = new Attachment(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\DirLogos\\logo.png");
                // Set the ContentId of the attachment, used in body HTML
                ImageAttachment.ContentId = "logo";
                msg.Attachments.Add(ImageAttachment);

                StringBuilder datos = htmlMessageBody(obj, "VALIDACION");

                //receptores
                msg.To.Add(new MailAddress(obj.strCorreo));
                //msg.To.Add(new MailAddress("ereyes@tecflex.com"));
                //msg.CC.Add(new MailAddress("esuyon@tecflex.com"));
                //msg.CC.Add(new MailAddress("programador04@tecflex.com"));

                //Remitente
                msg.From = new MailAddress(ccorreo);

                //Titulo
                msg.Subject = "Restablecimiento de contraseña";

                //Cuerpo de correo
                msg.Body = datos.ToString();

                msg.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = host;
                    smtp.Port = Int32.Parse(puerto);
                    smtp.EnableSsl = auth;
                    smtp.UseDefaultCredentials = true;
                    //usuario y clave
                    smtp.Credentials = new NetworkCredential(ccorreo, cpass);

                    smtp.Send(msg);
                }

                intResult = 1;
                strMsjUsuario = "Se envió el correo de restablecimiento de contraseña.";
            }

            catch (Exception ex)
            {
                intResult = 3;
                strMsjUsuario = "Ocurrió un error al enviar el correo de restablecimiento";
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                //throw new Exception("Error General (EnviarCorreo)");
            }
            return intResult;
        }
        #endregion

        #region Papeleta - Permisos - Ausentismos
        //5.50
        public List<Ausentismos> ListarAusentismoDet(Session_Movi objSession, int intIdPerHor, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario)
        {
            List<Ausentismos> lista = new List<Ausentismos>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarAusentismoDet(objSession, intIdPerHor, filtrojer_ini, filtrojer_fin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarAusentismoDet] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarAusentismoDet)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ListarAusentismoDet)");
            }
            return lista;
        }
        //5.51
        public List<string> EliminarAusentismo(Session_Movi objSession, int intIdPerCon, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                List<string> listRutaDoc = new List<string>();
                listRutaDoc = objDao.EliminarAusentismo(objSession, intIdPerCon, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminarAusentismo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return listRutaDoc;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminarAusentismo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (EliminarAusentismo)");
            }
        }
        //5.52
        public Ausentismo ObtenerAusentismoPorPK(Session_Movi objSession, int intId, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            Ausentismo obj = new Ausentismo();
            try
            {
                obj = objDao.ObtenerAusentismoPorPK(objSession, intId, ref intResult, ref strMsjDB, ref strMsjUsuario);
                obj.listDocumentos = objDao.ObtenerDocumentosAusentismo(objSession, intId, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerAusentismoPorPK] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerAusentismoPorPK)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ObtenerAusentismoPorPK)");
            }
            return obj;
        }
        //5.53
        public int UAusentismos(Session_Movi objSession, Ausentismo objDatos, bool flgDESM, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            try
            {
                int result = 0;

                result = objDao.UAusentismos(objSession, objDatos, flgDESM, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[UAusentismos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }

                return result;
            }
            //catch (TransactionAbortedException ex)
            //{
            //    Log.AlmacenarLogError(ex, "ImportarExcelBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (UAusentismos)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (UAusentismos)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (UAusentismos)");
            }
        }
        //5.54
        public List<int> IAusentismos(Session_Movi objSession, string intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            try
            {
                List<int> listPapeletas = new List<int>();

                listPapeletas = objDao.IAusentismos(objSession, intIdProceso, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IAusentismos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return listPapeletas;
            }
            //catch (TransactionAbortedException ex)
            //{
            //    Log.AlmacenarLogError(ex, "ImportarExcelBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (IAusentismos)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "HGM270421.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (IAusentismos)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "HGM270421.cs: Exception");
                throw new Exception("Error General (IAusentismos)");
            }
        }
        //5.55
        public int EAusentismos(Session_Movi objSession, string intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            try
            {
                int id = 0;

                id = objDao.EAusentismos(objSession, intIdProceso, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EAusentismos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return id;
            }
         
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "HGM270421.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EAusentismos)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "HGM270421.cs: Exception");
                throw new Exception("Error General (EAusentismos)");
            }
        }
        //5.56
        public List<EmpleadoObs> PreIAusentismos(Session_Movi objSession, Ausentismo objDatos, List<int> listPersonal, bool flgDESM, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            try
            {
                List<EmpleadoObs> listPersonalObs = new List<EmpleadoObs>();

                DataTable tb = SerealizeDetalleEmpleado(listPersonal);
                listPersonalObs = objDao.PreIAusentismos(objSession, objDatos, flgDESM, dttFechaIni, dttFechaFin, tb, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[PreIAusentismos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return listPersonalObs;
            }

            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "HGM270421.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (PreIAusentismos)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "HGM270421.cs: Exception");
                throw new Exception("Error General (PreIAusentismos)");
            }
        }
       
        
        //5.57
        public int RegistrarDocumentos(string pathTotal, List<int> listPapeletas, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            try
            {
                int intId = 0;

                DataTable tb = SerealizeDetallePapeleta(listPapeletas);
                intId = objDao.RegistrarDocumentos(pathTotal, tb, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[RegistrarDocumentos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }

                return intId;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "HGM270421.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (RegistrarDocumentos)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "HGM270421.cs: Exception");
                throw new Exception("Error General (RegistrarDocumentos)");
            }
        }
        //5.58
        public int RegistrarDocumentosEdit(string pathTotal, int intIdPapeleta, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            try
            {
                int intID = 0;
                objDao.RegistrarDocumentosEdit(pathTotal, intIdPapeleta, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[RegistrarDocumentos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return intID;
            }

            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "HGM270421.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (RegistrarDocumentos)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "HGM270421.cs: Exception");
                throw new Exception("Error General (RegistrarDocumentos)");
            }
        }
        //5.59
        public List<string> ComprobarDocumentos(Session_Movi objSession, int intIdPapeleta, List<string> listPapeletas, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<string> listEliminados = new List<string>();
            try
            {
                DataTable tb = SerealizeDetalleNomDocumento(listPapeletas);
                listEliminados = objDao.ComprobarDocumentos(objSession, intIdPapeleta, tb, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ComprobarDocumentos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("", ex);
                //Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ComprobarDocumentos)");
            }
            catch (Exception ex)
            {
                Console.WriteLine("", ex);
                //Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ComprobarDocumentos)");
            }
            return listEliminados;
        }
        //5.60
        public bool GetHabGeo(ref string strMsjUsuario)
        {
            try
            {
                bool estado = false;
                int intResult = 0;
                string strMsjDB = "";

                estado = objDao.GetHabGeo(ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[GetHabGeo] => Respuesta del Procedimiento : " + strMsjDB);
                    }

                }
                return estado;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("", ex);
                //Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (GetHabGeo)");
            }
            catch (Exception ex)
            {
                Console.WriteLine("", ex);
                //Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (GetHabGeo)");
            }

        }
        //5.61
        private DataTable SerealizeDetalleUsuarioPerfil(List<TT_TGPERS_HORARIO_DET> listaDetalleHorAsigEmp, int intIdHorario, DateTime dttFecAsig)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdPersonal", typeof(int));
            table.Columns.Add("intIdSoftw", typeof(int));
            table.Columns.Add("intIdHorario", typeof(int));
            table.Columns.Add("dttFecAsig", typeof(DateTime));
            table.Columns.Add("bitFlEliminado", typeof(bool));
            table.Columns.Add("IntIdUsuarReg", typeof(int));
            table.Columns.Add("dttFeRegistro", typeof(DateTime));



            foreach (var item in listaDetalleHorAsigEmp)
            {
                DataRow rows = table.NewRow();
                rows["intIdPersonal"] = item.intIdPerHorario;
                rows["intIdSoftw"] = item.intIdSoftw;
                rows["intIdHorario"] = intIdHorario;
                rows["dttFecAsig"] = dttFecAsig;
                rows["bitFlEliminado"] = item.bitFlEliminado;
                rows["IntIdUsuarReg"] = item.IntIdUsuarReg;
                if (item.dttFeRegistro == null)
                {
                    rows["dttFeRegistro"] = DBNull.Value;
                }
                else
                {
                    rows["dttFeRegistro"] = item.dttFeRegistro;
                }


                table.Rows.Add(rows);
            }

            return table;
        }
        //5.62
        private DataTable SerealizeDetalleEmpleado(List<int> listaEmpleado)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdPersonal", typeof(int));

            foreach (var item in listaEmpleado)
            {
                DataRow rows = table.NewRow();
                rows["intIdPersonal"] = item;
                table.Rows.Add(rows);
            }

            return table;
        }
        //5.63
        private DataTable SerealizeDetallePapeleta(List<int> listaEmpleado)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdPerConcepto", typeof(int));

            foreach (var item in listaEmpleado)
            {
                DataRow rows = table.NewRow();
                rows["intIdPerConcepto"] = item;
                table.Rows.Add(rows);
            }

            return table;
        }
        //5.64
        private DataTable SerealizeDetalleNomDocumento(List<string> listDocumento)
        {
            DataTable table = new DataTable();
            table.Columns.Add("strNomDocumento", typeof(string));

            foreach (var item in listDocumento)
            {
                DataRow rows = table.NewRow();
                rows["strNomDocumento"] = item;
                table.Rows.Add(rows);
            }

            return table;
        }
        //5.65
        private DataTable SerealizeRuta(List<string> listRuta)
        {
            DataTable table = new DataTable();
            table.Columns.Add("strRuta", typeof(string));

            foreach (var item in listRuta)
            {
                DataRow rows = table.NewRow();
                rows["strRuta"] = item;
                table.Rows.Add(rows);
            }

            return table;
        }

        #endregion

        #region Asig. Horarios
        //5.67
        public List<AsigHorarioData> ListarAsigHor(Session_Movi objSession, int intActivoFilter, string strfilter, int IntIdEmp, string dttfiltrofch1, string dttfiltrofch2, ref string strMsjUsuario)
        {
            List<AsigHorarioData> lista = new List<AsigHorarioData>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarAsigHor(objSession, intActivoFilter, strfilter, IntIdEmp, dttfiltrofch1, dttfiltrofch2, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarAsigHor] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("", ex);
                //Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarAsigHor)");
            }

            catch (Exception ex)
            {
                Console.WriteLine("", ex);
                //Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ListarAsigHor)");
            }
            return lista;
        }
        //5.68
        public List<AsigHorario> ListarAsigHorDet(Session_Movi objSession, int intIdPerHor, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario)
        {

            List<AsigHorario> lista = new List<AsigHorario>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarAsigHorDet(objSession, intIdPerHor, filtrojer_ini, filtrojer_fin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarAsigHorDet] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("", ex);
                //Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarAsigHorDet)");
            }

            catch (Exception ex)
            {
                Console.WriteLine("", ex);
                //Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
                throw new Exception("Error General (ListarAsigHorDet)");
            }
            return lista;
        }
        //5.69
        public bool EliminarAsigHor(Session_Movi objSession, int intIdPerHor, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objDao.EliminarAsigHor(objSession, intIdPerHor, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminarAsigHor] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("", ex);
                //Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminarAsigHor)");
            }
            catch (Exception ex)
            {
                Console.WriteLine("", ex);
                //Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception"); 
                throw new Exception("Error General (EliminarAsigHor)");
            }
        }


        //5.70
        public int IUAsigHor(Session_Movi objSession, int intIdPerHor, int intIdHorario, DateTime dttFecAsig, ref string strMsjUsuario)
        {
            try
            {


                int intResult = 0;
                string strMsjDB = "";

                // using (TransactionScope scope = new TransactionScope())
                //{



                int idUnid = objDao.IUAsigHor(objSession, intIdPerHor, intIdHorario, dttFecAsig, ref intResult, ref strMsjDB, ref strMsjUsuario);



                //  scope.Complete();
                // }

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUAsigHor] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                else
                {

                    idUnid = 0;
                }


                return idUnid;
            }
         
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");//ImportarExcelBL.cs ImportarExcelBL HGM 27.04.21
                throw new Exception("Ocurrió un error en BD (IUAsigHor)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");//ImportarExcelBL.cs ImportarExcelBL HGM 27.04.21
                throw new Exception("Error General (IUAsigHor)");
            }
        }
        
        
        //5.71
        public List<EmpleadoObs> IUREGAsigHor(Session_Movi objSession, List<TT_TGPERS_HORARIO_DET> listaDetalleHorAsigEmp, int intIdHorario, DateTime dttFecAsig, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<EmpleadoObs> lista = new List<EmpleadoObs>();
            try
            {
                DataTable tb = SerealizeDetalleUsuarioPerfil(listaDetalleHorAsigEmp, intIdHorario, dttFecAsig);
                lista = objDao.IUREGAsigHor(objSession, tb, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUREGAsigHor] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }

            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException"); //ImportarExcelBL.cs  HGM 27.04.21
                throw new Exception("Ocurrió un error en BD (IUREGAsigHor)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception"); //ImportarExcelBL.cs ImportarExcelBL HGM 27.04.21
                throw new Exception("Error General (IUREGAsigHor)");
            }
            return lista;
        }
        //5.72
        public List<int> IUREGAsigHorPost(Session_Movi objSession, string intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            try
            {
                List<int> listHorarios = new List<int>();

                listHorarios = objDao.IUREGAsigHorPost(objSession, intIdProceso, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUREGAsigHorPost] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return listHorarios;
            }
 
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException"); //HGM 27.04.21
                throw new Exception("Ocurrió un error en BD (IUREGAsigHorPost)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");//HGM 27.04.21
                throw new Exception("Error General (IUREGAsigHorPost)");
            }
        }

        #endregion








    }
}
