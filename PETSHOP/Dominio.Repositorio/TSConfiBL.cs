
using Dominio.Entidades.Sistema;
using Dominio.Entidades;
using Dominio.Repositorio.Util;
using Infraestructura.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Transactions;
using System.Net.Mail;
using System.Text;


namespace Dominio.Repositorio
{
    public class TSConfiBL
    {

        public  List<TSParamsSaf> listParams; //static

        private TSConfiDAO objDao = new TSConfiDAO();

        private UsuarioDAO objUser = new UsuarioDAO(); 

        #region SAF Mant. Configuracion

        //11.1 ListarConfig
        public List<TSParamsSaf> ListarConfigInicialSaf(Session_Movi objSession, string strCoConfi, ref string strMsjUsuario)
        {
            List<TSParamsSaf> lista = new List<TSParamsSaf>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarConfigInicialSaf(objSession, strCoConfi, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarConfigInicialSaf] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarConfigInicialSaf)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: Exception");
                throw new Exception("Error General (ListarConfigInicialSaf)");
            }
            return lista;
        }

        //11.2 ActualizarConfig
        public bool ActualizarDetalleConfigSaf(Session_Movi objSession, string prmSalidaApp, string prmAddOfic, string prmAddResp, string prmFilUbica, string prmOpcOpera, string prmAreaxLocal, string prmModaTrab, string prmOutExcelxLocal, string prmImpresora, string strEmailDestino, string strParametro, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";

                tudobem = objDao.ActualizarDetalleConfigSaf(objSession, prmSalidaApp,  prmAddOfic, prmAddResp, prmFilUbica, prmOpcOpera, prmAreaxLocal, prmModaTrab, prmOutExcelxLocal, prmImpresora, strEmailDestino, strParametro, ref intResult, ref strMsjDB, ref strMsjUsuario);

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ActualizarDetalleConfigSaf)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: Exception");
                throw new Exception("Error General (ActualizarDetalleConfigSaf)");
            }
        }


        //11.3
        public bool GuardarConexionBaseDatosSqlSaf(Session_Movi objSession, string strServidor, string strBaseDatos, string strUsuario, string strContrasenia
                                                  , string strAutenticacion, string strDirExcelCarga, string strExcelGenerado, ref string strMsjUsuario)



        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";

                tudobem = objDao.GuardarConexionBaseDatosSqlSaf(objSession, strServidor, strBaseDatos, strUsuario, strContrasenia, strAutenticacion, strDirExcelCarga, strExcelGenerado, ref intResult, ref strMsjDB, ref strMsjUsuario);

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (GuardarConexionBaseDatosSqlSaf)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: Exception");
                throw new Exception("Error General (GuardarConexionBaseDatosSqlSaf)");
            }
        }


        //11.4
        public List<TSParamsSaf> ListarConfigConexionBaseDeDatos(Session_Movi objSession, string strCoConfi, ref string strMsjUsuario)
        {
            List<TSParamsSaf> lista = new List<TSParamsSaf>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarConfigConexionBaseDeDatos(objSession, strCoConfi, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarConfigConexionBaseDeDatos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarConfigConexionBaseDeDatos)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: Exception");
                throw new Exception("Error General (ListarConfigConexionBaseDeDatos)");
            }

            ////////Guarda los valores de cadena de conexión
            ////// string _server   = listParams[0].strServidor   ;    //192.168.1.45,1433;
            ////// string _user_id  = listParams[0].strBaseDatos  ;     //food;
            ////// string _password = listParams[0].strUsuario    ;     //tecflex;
            ////// string _database = listParams[0].strContrasenia;     //BDACTIVOFIJOWEB

            return lista;
        }

        #endregion


        //8.5
        public TSConfi ConsultarTSConfi_xCod(long intIdSesion, int intIdMenu, int intIdSoft, string strCoConfi,ref string strMsjUsuario)
        {
            try
            {
                TSConfi objConf = null;
                int intResult = 0;
                string strMsjDB = "";

                objConf = objDao.ConsultarTSConfi_xCod(intIdSesion, intIdMenu, intIdSoft, strCoConfi, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ConsultarTSConfi_xCod] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return objConf;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ConsultarTSConfi_xCod)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: Exception");
                throw new Exception("Error General (ConsultarTSConfi_xCod)");
            }
        }
        
        //1.16 y 3.22 hgm
        public List<TSConfi> ListarConfig(Session_Movi objSession, string strCoConfi, ref string strMsjUsuario)
        {
            List<TSConfi> lista = new List<TSConfi>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarConfig(objSession, strCoConfi, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarConfig] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarConfig)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: Exception");
                throw new Exception("Error General (ListarConfig)");
            }
            return lista;
        }

        //1.17
        public bool ActualizarConfig(Session_Movi objSession, List<TSConfi> detalleConfig, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";

                DataTable tb = SerealizeDetalleConfig(detalleConfig);
                tudobem = objDao.UpdateDetalleConfig(objSession, tb, ref intResult, ref strMsjDB, ref strMsjUsuario);

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ActualizarConfig)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: Exception");
                throw new Exception("Error General (ActualizarConfig)");
            }
        }

        //1.18
        private DataTable SerealizeDetalleConfig(List<TSConfi> listaDetalles)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdConfi", typeof(int));
            table.Columns.Add("strCoConfi", typeof(string));
            table.Columns.Add("strValorConfi", typeof(string));
            // table.Columns.Add("TipoControl", typeof(int));
            table.Columns.Add("TipoControl", typeof(string));
            table.Columns.Add("bitFlActivo", typeof(bool));

            foreach (var item in listaDetalles)
            {
                DataRow rows = table.NewRow();
                rows["intIdConfi"] = item.intIdConfi;
                rows["strCoConfi"] = item.strCoConfi;
                rows["strValorConfi"] = item.strValorConfi;
                rows["TipoControl"] = item.tipoControl;
                rows["bitFlActivo"] = item.bitFlActivo;

                table.Rows.Add(rows);
            }

            return table;
        }

        //Método de Pruebas con Transacciones 13.04.2021
        public EN_TMEncuesta Datos_EnviarRespuesta_Encuesta_JSql(string JSON)
        {

            EN_TMEncuesta lista = new EN_TMEncuesta();
            try
            {
                lista = objDao.Datos_EnviarRespuesta_Encuesta_JSql(JSON);
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarConfig)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: Exception");
                throw new Exception("Error General (ListarConfig)");
            }
            return lista;
        }

        ///////////////////////////////////////////////////////////////
        // 3.22.1.- METODO PARA OBTENER SERVER Y VALIDAR LOGUEO ---> Añadido ---> 02.07.21
        ///////////////////////////////////////////////////////////////
        public string ObtenerServer()
        {
            string strMsjUsuario = "";
            //obtener datos de configuraciónBD
            List<TSConfi> lista = new List<TSConfi>();
            Session_Movi  objSession = new Session_Movi();
            UsuarioDAO    objUser = new UsuarioDAO();

            objSession.intIdSesion = 1;
            objSession.intIdSoft   = 1;
            objSession.intIdMenu   = 1;

            string IDEncrypt = "";
            string IP = "";
            string MAC = "";
            string NameRed = "";
            try
            {
                //OBTENER IP ACTIVA
                //-------------------------------------------------
                // Get the list of network interfaces for the local computer.
                var adapters = NetworkInterface.GetAllNetworkInterfaces();
                for (int i = 0; i < adapters.Count(); i++)
                {
                    //Log.AlmacenarLogMensaje("Adapter " + i.ToString() + ": " + adapters[i].Description.ToString() + "| " + adapters[i].NetworkInterfaceType.ToString() + "| " + adapters[i].OperationalStatus.ToString() + "| " + adapters[i].SupportsMulticast.ToString());

                }

                string Host = Dns.GetHostName();
                //Log.AlmacenarLogMensaje("HostName: " + Host);
                if (adapters != null)
                {
                    //Log.AlmacenarLogMensaje("Adapter no es nulo");

                    var A = (from adapter in adapters
                             let properties = adapter.GetIPProperties()
                             from address in properties.UnicastAddresses
                             where adapter.OperationalStatus == OperationalStatus.Up
                             //&& adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet //añadido manualmente 02.07.2021
                             && address.Address.AddressFamily == AddressFamily.InterNetwork
                             && !address.Equals(IPAddress.Loopback)
                             && address.DuplicateAddressDetectionState == DuplicateAddressDetectionState.Preferred
                             && properties.GatewayAddresses.Count >= 1 //añadido 06.07.2021
                             //&& address.AddressPreferredLifetime != UInt32.MaxValue //se comenta porque no funciona en la 45
                             select address.Address);
                    var B = (from adapter in adapters
                             let properties = adapter.GetIPProperties()
                             from address in properties.UnicastAddresses
                             where adapter.OperationalStatus == OperationalStatus.Up
                             //&& adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet //añadido manualmente 02.07.2021
                             && address.Address.AddressFamily == AddressFamily.InterNetwork
                             && !address.Equals(IPAddress.Loopback)
                             && address.DuplicateAddressDetectionState == DuplicateAddressDetectionState.Preferred
                             && properties.GatewayAddresses.Count >= 1 //añadido 06.07.2021
                             //&& address.AddressPreferredLifetime != UInt32.MaxValue //se comenta porque no funciona en la 45
                             select adapter.GetPhysicalAddress());
                    var C = (from adapter in adapters
                             let properties = adapter.GetIPProperties()
                             from address in properties.UnicastAddresses
                             where adapter.OperationalStatus == OperationalStatus.Up
                             //&& adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet //añadido manualmente 02.07.2021
                             && address.Address.AddressFamily == AddressFamily.InterNetwork
                             && !address.Equals(IPAddress.Loopback)
                             && address.DuplicateAddressDetectionState == DuplicateAddressDetectionState.Preferred
                             //&& address.AddressPreferredLifetime != UInt32.MaxValue //se comenta porque no funciona en la 45
                             select adapter.Description);


                    if (A != null && A.Count() > 0)
                    {
                        ////Log.AlmacenarLogMensaje("Objeto Adapter si tiene redes");

                        for (int i = 0; i < A.Count(); i++)
                        {
                            //////Log.AlmacenarLogMensaje("A: " + A.ElementAt(i).ToString() + "| Total Redes: " + A.Count());

                            if (i == 0)
                            {
                                //Nota: si en caso el adapters tiene más de una coincidencia se toma la primera diferente de 127.0.0.1
                                IP = A.ElementAt(i).ToString();
                                MAC = B.ElementAt(i).ToString();
                                NameRed = C.ElementAt(i).ToString();
                                //////Log.AlmacenarLogMensaje(NameRed + " | " + MAC + " | " + IP);
                            }

                        }
                    }
                    else
                    {
                        Log.AlmacenarLogMensaje("Objeto Adapter no tiene redes" + " | Total Redes: " + A.Count());
                    }

                }
                ////-----------------------------------------
                //ManagementObjectSearcher ComSerial = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");//Win32_BaseBoard (placa madre)/ Win32_BIOS
                //foreach (ManagementObject wmi in ComSerial.Get())
                //{
                //    try
                //    {
                //        var MainBoard = wmi.GetPropertyValue("SerialNumber").ToString();
                //    }
                //    catch { }
                //}
                ////--------------------------------------------
                ///



                if (IP != null && IP != "")
                {
                    /********** reutilizamos sin cambios el ListarConfig() del //1.16 **********/
                    lista = ListarConfig(objSession, "%_SERVICE", ref strMsjUsuario);

                    for (int i = 0; i < lista.Count(); i++)
                    {
                        if (lista[i].strCoConfi == "ID_SERVICE")
                        {
                            IDEncrypt = lista[i].strValorConfi;
                        }
                    }
                    string IPDesencrypt = "";
                    string MACDesencrypt = "";
                    string Sufi_ = "";

                    ///////////////////////////////////////////////////////////////
                    //// 3.22.1.- INTENTOS DE LOGUEOS
                    ///////////////////////////////////////////////////////////////
                    //if (IDEncrypt != "" && IDEncrypt != null)
                        if (1 > 2)
                        {

                        string IDDesencrypt = objUser.DesencriptarPassword(IDEncrypt);

                        string[] IDs = IDDesencrypt.Substring(0, 15).Split('X');
                        MACDesencrypt = IDDesencrypt.Substring(16, 12);
                        Sufi_ = IDDesencrypt.Substring(28, (IDDesencrypt.Length - 28));
                        int Sum_ = 0;
                        foreach (string Id in IDs)
                        {
                            IPDesencrypt = IPDesencrypt + Convert.ToInt32(Id).ToString() + '.';
                            Sum_ = Sum_ + Convert.ToInt32(Id);
                        }
                        IPDesencrypt = IPDesencrypt.Substring(0, (IPDesencrypt.Length - 1));
                        //string MACDesencrypt = objUser.DesencriptarPassword(MACEncrypt).Substring(4);//quitar los 4 primeros dígitos de los cuales 3 equivalen a intNumImp de TSSOFTWARE Ejemplo:"123|"
                        //string IPDesencrypt = objUser.DesencriptarPassword(IPEncrypt).Substring(4);//quitar los 4 primeros dígitos de los cuales 3 equivalen a intNumImp de TSSOFTWARE Ejemplo:"123|"

                        if (MAC == MACDesencrypt && IP == IPDesencrypt && Sufi_ == Sum_.ToString())
                        {
                            strMsjUsuario = "";
                        }
                        else
                        {
                            strMsjUsuario = "Servidor no Autorizado.";
                        }
                    }
                    else
                    {
                        //Enviar correo a Tecflex para soporte.
                        string strMsjDB = "";
                        string strTipo = "REGSERVER";
                        int intResult = 0;
                        string CorreoDestino = "";
                        string Cliente = "";

                        lista = ListarConfig(objSession, "%_CBX", ref strMsjUsuario);

                        for (int i = 0; i < lista.Count(); i++)
                        {
                            if (lista[i].strCoConfi == "EMAIL_CBX")
                            {
                                CorreoDestino = lista[i].strValorConfi; //esuyon@tecflex.com;roxanasuyonc@gmail.com
                            }
                            if (lista[i].strCoConfi == "OC_RUCCLI_CBX")
                            {
                                Cliente = lista[i].strValorConfi; //542121554|10456350912
                            }
                        }

                        string CliDesencriptado = objUser.DesencriptarPassword(Cliente);

                        string[] subs = CliDesencriptado.Split('|');

                        CorreoEmp obj = new CorreoEmp();
                        obj.intIdPersonal = 0;
                        obj.strOC = subs[0];//OC---> Orden de Compra
                        obj.strRUC = subs[1]; //RUC
                        obj.strDestinos = "gonzales.hebert@gmail.com"; // CorreoDestino;//destinatarios --> Soporte Tecnico esuyon@tecflex.com;


                        string[] subsIP = IP.Split('.');
                        string sCadena = "";
                        int Sum = 0;
                        foreach (string subIP in subsIP)
                        {
                            sCadena = sCadena + (Convert.ToInt32(subIP) + 1000).ToString().Substring(1, 3) + "X";
                            Sum = Sum + Convert.ToInt32(subIP);
                        }
                        sCadena = sCadena + MAC + Sum; // IP:15 dígitos + MAC: 12 dígitos + Sufijo (n dígitos)
                        obj.strCadena = sCadena;

                        if (sCadena != null && sCadena != "")
                        {   //enviarCorreo
                            enviarCorreoObtenerServerLogin_SAF(objSession, obj, strTipo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                        }

                        if (intResult == 1)
                        {
                            strMsjUsuario = "Servidor sin Licencia registrada (se envió correo a Tecflex SAC)";
                        }
                        else
                        {
                            strMsjUsuario = "Servidor sin Licencia registrada.";
                        }


                    }
                }
                else
                {
                    strMsjUsuario = "Servidor no tiene Serial";
                }


                return strMsjUsuario;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerServer)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: Exception");
                throw new Exception("Error General (ObtenerServer)");
            }
        }

        ///////////////////////////////////////////////////////////////
        // 3.22.2.- ENVIO DE CORREO A SOPORTE TECNICO ---> Copiado del //5.43
        ///////////////////////////////////////////////////////////////
        private ImportarExcelDAO objDao_ = new ImportarExcelDAO();
        private void enviarCorreoObtenerServerLogin_SAF(Session_Movi objSession, CorreoEmp obj, string strTipo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            //Datos del Servidor de Correo
            List<EnCorreo> lsCorreoDatos = objDao_.obtenerDatosCorreo(objSession, ref intResult, ref strMsjDB, ref strMsjUsuario);
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
                //UsuarioBL UserBL = new UsuarioBL();
                //StringBuilder datos = UserBL.htmlMessageBodyObtenerServerLogin_SAF(obj, strTipo);
                StringBuilder datos = htmlMessageBodyObtenerServerLogin_SAF(obj, strTipo);
                //receptores Tecflex
                string[] subs = obj.strDestinos.Split(';');
                foreach (string sub in subs)
                {
                    msg.To.Add(new MailAddress(sub));
                }
                msg.CC.Add(new MailAddress("sisactivofijo@gmail.com"));//cambiar correo  -->  siscopweb@gmail.com

                //Remitente
                msg.From = new MailAddress(ccorreo);

                //Titulo
                msg.Subject = "Generar Licencia";

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
                strMsjUsuario = "El correo con la solicitud fue enviado correctamente.";
            }

            catch (Exception ex)
            {
                intResult = 3;
                strMsjUsuario = "Ocurrió un error al enviar el correo";
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: Exception");
            }
        }

        ///////////////////////////////////////////////////////////////
        // 3.22.3.- OBTENER EL CUERPO DEL CORREO ---> Copiado del//3.17
        ///////////////////////////////////////////////////////////////
        private ImportarExcelDAO objDaoImpExc = new ImportarExcelDAO();
        public StringBuilder htmlMessageBodyObtenerServerLogin_SAF(CorreoEmp obj, string filtro)//private cambiado a public 01.07.2021
        {
            StringBuilder strB = new StringBuilder();

            int intResult = 0;
            string strMsjDB = "";
            string strMsjUsuario = "";
            TEXTOCORREO objTexto = new TEXTOCORREO();

            //Obtener el texto del correo como objeto
            objTexto = objDaoImpExc.GetTextoCorreoObj(filtro, obj, 0, false, "", ref intResult, ref strMsjDB, ref strMsjUsuario);






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

        ///////////////////////////////////////////////////////////////
        // 3.23.1.- ----> 04.07.21
        ///////////////////////////////////////////////////////////////
        // 13:07   CTRL + 1 "Generar Token de Prueba"  int Oper = 3
        public string GenerarServerEncriptado(Session_Movi objSesion, ref int intRpta, string sCadena, int Oper)//1: Encriptar // 2: Registrar //3: ?? Toquen de prueba
        {
            string strMsjUsuario = "";
            try
            {
                Session_Movi objSession = new Session_Movi();
                UsuarioDAO objUser = new UsuarioDAO();

                objSession.intIdSesion = 1;
                objSession.intIdSoft = 6;// 1;   6 para sisactivofijo
                objSession.intIdMenu = 1;
                string IDServidor = "";
                string Suma_ = "";
                bool Valida = false;
                bool EsQA = false;//añadido 06.07.2021

                /*********************************************************************
                         "Oper == 2"  GENERA EL ENCIPTADO DE LA CADENA
                **********************************************************************/
                if (Oper == 2) //Registrar (obtener la Suma)
                {
                    strMsjUsuario = ValidaServer(sCadena, Oper);//Validando si es igual a la del Servidor Actual.

                    if (strMsjUsuario != "")
                    {
                        strMsjUsuario = "Token Incorrecto";
                        Valida = false;
                    }
                    else
                    {
                        //--------------------------------------------------------------------------------------------------
                        IDServidor = sCadena;
                        sCadena = objUser.DesencriptarPassword(sCadena);
                        //Token de Licencia estándar:29-32 [ 16 + 12 + (1-4) e iniciando con números.
                        //Token de Licencia Prueba:41-44 [ 12 + 16 + 12 + (1-4) e iniciando con Q__A, donde los 2 primeros digitos son la cantidad de dias seguido de DDMMAAAA de prueba están en medio.

                        if (sCadena.Substring(0, 1) == "Q")
                        {//Token de Licencia Prueba:41-44 [ 12 + 16 + 12 + (1-4) e iniciando con Q__A, donde los 2 primeros digitos son la cantidad de dias seguido de DDMMAAAA de prueba están en medio.
                            EsQA = true;
                            sCadena = sCadena.Substring(12, (sCadena.Length - 12));//quitandole los primeros 12 digitos
                        }
                        //------------------------------------------
                        //sCadena = objUser.DesencriptarPassword(sCadena);
                        Suma_ = sCadena.Substring(28, sCadena.Length - 28);
                        Valida = true;
                    }
                }

                /*********************************************************************
                         "Oper == 1" "Oper == 3" 
                **********************************************************************/
                else  //Solo Encriptar
                {
                    List<TSConfi> lista = new List<TSConfi>();
                    Suma_ = sCadena.Substring(28, sCadena.Length - 28);
                    if (Oper == 3)//QA ---_>  DE PRUEBA
                    {
                        string D = "07"; //Duracion
                        //--------------------------------------------------------------------------

                        lista = ListarConfig(objSession, "%_SERVICE", ref strMsjUsuario);

                        for (int i = 0; i < lista.Count(); i++)
                        {
                            if (lista[i].strCoConfi == "DUR_SERVICE")
                            {
                                //D = (Convert.ToInt32(objUser.DesencriptarPassword(lista[i].strValorConfi))+100).ToString().Substring(1,2);
                                D = (Convert.ToInt32(lista[i].strValorConfi) + 100).ToString().Substring(1, 2);
                                break;
                            }
                        }
                        //--------------------------------------------------------------------------

                        string[] DT = DateTime.Now.ToString().Split(' ');//Dato en duro
                        string[] DT_ = DT[0].Split('/');
                        D = D + (Convert.ToUInt32(DT_[0]) + 100).ToString().Substring(1, 2) + (Convert.ToUInt32(DT_[1]) + 100).ToString().Substring(1, 2) + DT_[2];
                        IDServidor = objUser.EncriptarPassword("Q" + D + "A" + sCadena);//le sumamos a la cadena los dias de prueba
                    }
                    else
                    {
                        IDServidor = objUser.EncriptarPassword(sCadena);
                    }
                    Valida = true;

                    //--------------------------------------------------------------------------------------------------------
                    //Enviar correo a Tecflex para soporte 06.07.2021
                    string strMsjDB = "";
                    string strTipo = "TOKEN";
                    int intResult = 0;
                    string CorreoDestino = "";
                    string Cliente = "";
                    //List<TSConfi> lista = new List<TSConfi>();
                    lista = ListarConfig(objSession, "%_CBX", ref strMsjUsuario);

                    for (int i = 0; i < lista.Count(); i++)
                    {
                        if (lista[i].strCoConfi == "EMAIL_CBX")//El/los emails a donde se enviarán
                        {
                            CorreoDestino = lista[i].strValorConfi; //"sisactivofijo@gmail.com";
                        }
                        if (lista[i].strCoConfi == "OC_RUCCLI_CBX")//Ruc del cliente encriptado
                        {
                            Cliente = lista[i].strValorConfi;
                        }
                    }

                    string CliDesencriptado = objUser.DesencriptarPassword(Cliente);

                    string[] subs = CliDesencriptado.Split('|');
                    CorreoEmp obj = new CorreoEmp();
                    obj.intIdPersonal = 0;
                    obj.strOC = subs[0];//OC
                    obj.strRUC = subs[1]; //RUC
                    obj.strDestinos = CorreoDestino;//destinatarios
                    obj.strCadena = sCadena;// ID;
                    obj.strCadena2 = IDServidor;// token;

                    if (sCadena != null && sCadena != "")
                    {
                        //enviarCorreo(objSession, obj, strTipo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                        enviarCorreoTOKEN(objSession, obj, strTipo, ref intResult, ref strMsjDB, ref strMsjUsuario); ///03:20pm
                    }

                    if (intResult == 1)
                    {
                        strMsjUsuario = "Token generado (se envió correo a Tecflex SAC)";
                    }
                    else
                    {
                        strMsjUsuario = "No se pudo enviar correo del nuevo token";
                    }
                    //--------------------------------------------------------------------------------------------------------
                }


                ////--------------------------------------------------------------
                bool rpta = false;
                if (Valida)
                {
                    if (Oper == 2) // Registrar
                    {
                        List<TSConfi> detalleConfig = new List<TSConfi>();
                        TSConfi o1 = new TSConfi();
                        o1.intIdConfi = 0;
                        o1.strCoConfi = "ID_SERVICE";
                        o1.strValorConfi = IDServidor;
                        o1.tipoControl = "N";
                        o1.bitFlActivo = true;
                        detalleConfig.Add(o1);

                        TSConfi o2 = new TSConfi();
                        o2.intIdConfi = 0;
                        o2.strCoConfi = "PCK_SERVICE";
                        o2.strValorConfi = Suma_;
                        o2.tipoControl = "N";
                        o2.bitFlActivo = true;
                        detalleConfig.Add(o2);

                        //añadido 06.07.2021 - INICIO
                        TSConfi o3 = new TSConfi();
                        o3.intIdConfi = 0;
                        o3.strCoConfi = "HAB_SERVICE";
                        if (EsQA)
                        {
                            o3.strValorConfi = "1";
                        }
                        else
                        {
                            o3.strValorConfi = "0";
                        }
                        o3.tipoControl = "N";
                        o3.bitFlActivo = true;
                        detalleConfig.Add(o3);
                        //añadido 06.07.2021 - FIN

                        rpta = ActualizarConfig(objSesion, detalleConfig, ref strMsjUsuario);
                    }
                    else
                    {
                        rpta = true;
                    }

                    if (rpta)
                    {
                        intRpta = 1;
                        if (Oper == 2) //Registrar
                        {
                            strMsjUsuario = Suma_;
                        }
                        //else
                        //{
                        //    strMsjUsuario = IDServidor;
                        //}
                    }
                    else
                    {
                        intRpta = 0;
                        if (Oper == 2) //Registrar
                        {
                            strMsjUsuario = "No se pudo registrar Token";
                        }
                        else
                        {
                            strMsjUsuario = "No se pudo generar Token";
                        }
                    }
                }
                else
                {
                    intRpta = 0;
                }

                return strMsjUsuario;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (GenerarServerEncriptado)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: Exception");
                throw new Exception("Error General (GenerarServerEncriptado)");
            }
        }


        /*********************************************************************
                 ENVIAR CORREO CON EL TOQKEN/ LA LICENCIA GENERADA
        *********************************************************************/
        private void enviarCorreoTOKEN(Session_Movi objSession, CorreoEmp obj, string strTipo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            //Datos del Servidor de Correo
            List<EnCorreo> lsCorreoDatos = objDao_.obtenerDatosCorreo(objSession, ref intResult, ref strMsjDB, ref strMsjUsuario);
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
                UsuarioBL UserBL = new UsuarioBL();
                StringBuilder datos = htmlMessageBodyTOKEN(obj, strTipo); //objDaoImpExc.

                //receptores Tecflex
                string[] subs = obj.strDestinos.Split(';');
                foreach (string sub in subs)
                {
                    msg.To.Add(new MailAddress(sub));
                }
                //msg.CC.Add(new MailAddress("soporte@tecflex.com"));//cambiar correo

                //Remitente
                msg.From = new MailAddress(ccorreo);

                //Titulo
                if (strTipo == "TOKEN")
                {
                    msg.Subject = "Generar Token";
                }
                else
                {
                    msg.Subject = "Generar Licencia";
                }


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
                strMsjUsuario = "El correo con la solicitud fue enviado correctamente.";
            }

            catch (Exception ex)
            {
                intResult = 0;//modificado 06.07.2021
                strMsjUsuario = "Ocurrió un error al enviar el correo";
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: Exception");
            }
        }

        /*********************************************************************
                CUERPO DEL CORREO CON TOQKEN/LICENCIA GENERADA
        *********************************************************************/
        public StringBuilder htmlMessageBodyTOKEN(CorreoEmp obj, string filtro)//private cambiado a public 01.07.2021
        {
            StringBuilder strB = new StringBuilder();

            int intResult = 0;
            string strMsjDB = "";
            string strMsjUsuario = "";
            TEXTOCORREO objTexto = new TEXTOCORREO();
            //if (filtro == "REGSERVER" || filtro == "TOKEN")//modificado 06.07.2021
            //{
            //    objTexto = objDao.GetTextoCorreoObj(filtro, obj, 0, false, "", ref intResult, ref strMsjDB, ref strMsjUsuario);
            //}
            //else
            //{
            //    objTexto = objDao.GetTextoCorreo(filtro, obj.intIdPersonal, 0, false, "", ref intResult, ref strMsjDB, ref strMsjUsuario);
            //}

            if (filtro == "REGSERVER" || filtro == "TOKEN")//modificado 06.07.2021
            {
                objTexto = objDaoImpExc.GetTextoCorreoObj(filtro, obj, 0, false, "", ref intResult, ref strMsjDB, ref strMsjUsuario);
            }
            else
            {
                objTexto = objDaoImpExc.GetTextoCorreo(filtro, obj.intIdPersonal, 0, false, "", ref intResult, ref strMsjDB, ref strMsjUsuario);
            }

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




        ///////////////////////////////////////////////////////////////
        // 3.25
        ///////////////////////////////////////////////////////////////
        public string ValidaServer(string Cadena, int Oper)//string Cadena, int Oper: 0 = Validación LOGIN | 1 = Registrar Token
        {
            string strMsjUsuario = "";
            //obtener datos de configuraciónBD
            Session_Movi objSession = new Session_Movi();
            UsuarioDAO objUser = new UsuarioDAO();

            objSession.intIdSesion = 1;
            objSession.intIdSoft = 6;// 1;
            objSession.intIdMenu = 1;

            //Variables para:
            string IDEncrypt = "";
            string IP = "";
            string MAC = "";
            bool EsQA = false; //añadido 05.07.2021
            bool ValidaQA = false; //añadido 05.07.2021
            string strMsjValidaQA = ""; //añadido 05.07.2021

            //string NameRed = "";
            try
            {
                #region Encapsulado_

                ////OBTENER IP ACTIVA

                #endregion Encapsulado_

                ObtServer(ref IP, ref MAC);//  Denuelve el IP y la MAC de mi pc

                if (IP != null && IP != "")
                {
                    string IPDesencrypt = "";
                    string MACDesencrypt = "";
                    string Sufi_ = "";
                    int Sum_ = 0;

                    if (Oper == 0)
                    {
                        //obtener valor de ID desde BD
                        List<TSConfi> lista = new List<TSConfi>();
                        lista = ListarConfig(objSession, "%_SERVICE", ref strMsjUsuario);

                        for (int i = 0; i < lista.Count(); i++)
                        {
                            if (lista[i].strCoConfi == "ID_SERVICE")
                            {
                                IDEncrypt = lista[i].strValorConfi;
                            }
                        }
                    }
                    else
                    {//Obtener valor de input de la ventana
                        IDEncrypt = Cadena;
                    }

                    //VALIDA A FECHA DE PERIODO (DE PRUEBA) QUE ESTA DENTRO DE LA CADNA ENCPTADA QUE SE INGRESO EN EL INPUT
                    if (IDEncrypt != "" && IDEncrypt != null)
                    {
                        string IDDesencrypt = objUser.DesencriptarPassword(IDEncrypt);
                        //Token de Licencia estándar:29-32 [ 16 + 12 + (1-4) e iniciando con números.
                        //Token de Licencia Prueba:41-44 [ 12 + 16 + 12 + (1-4) e iniciando con Q__A, donde los 2 primeros digitos son la cantidad de dias seguido de DDMMAAAA de prueba están en medio.

                        if (IDDesencrypt.Substring(0, 1) == "Q")
                        {//Token de Licencia Prueba:41-44 [ 12 + 16 + 12 + (1-4) e iniciando con Q__A, donde los 2 primeros digitos son la cantidad de dias seguido de DDMMAAAA de prueba están en medio.
                            EsQA = true;
                            int Dias = Convert.ToInt32(IDDesencrypt.Substring(1, 2)) + 1;//extrayendo la cantidad de días
                            string FecIni = IDDesencrypt.Substring(3, 8);//extrayendo la fechaInicio
                            string Fec = FecIni.Substring(0, 2) + "/" + FecIni.Substring(2, 2) + "/" + FecIni.Substring(4, 4);
                            DateTime DateIni = DateTime.ParseExact(Fec, "dd/MM/yyyy", null);
                            DateTime DateFin = DateIni.AddDays(Dias);
                            DateTime DateNow = DateTime.Now;

                            if (DateNow <= DateFin && DateNow >= DateIni)
                            {
                                ValidaQA = true;//Dependiendo de la fecha devuelve un true 
                            }
                            else
                            {
                                ValidaQA = false;
                                strMsjValidaQA = "El Periodo de Prueba caducó el " + DateFin.ToString();
                            }

                            IDDesencrypt = IDDesencrypt.Substring(12, (IDDesencrypt.Length - 12));//quitandole los primeros 12 digitos
                        }
                        else
                        {//Token de Licencia estándar:29-32 [ 16 + 12 + (1-4) e iniciando con números.

                        }

                        //Licencia  HGM 
                        if (IDDesencrypt.Length >= 29)
                        {
                            string[] IDs = IDDesencrypt.Substring(0, 15).Split('X');
                            MACDesencrypt = IDDesencrypt.Substring(16, 12);
                            Sufi_ = IDDesencrypt.Substring(28, (IDDesencrypt.Length - 28));

                            foreach (string Id in IDs)
                            {
                                IPDesencrypt = IPDesencrypt + Convert.ToInt32(Id).ToString() + '.';
                                Sum_ = Sum_ + Convert.ToInt32(Id);
                            }
                            IPDesencrypt = IPDesencrypt.Substring(0, (IPDesencrypt.Length - 1));  ///OK
                        }

                        if (MACDesencrypt != "" && IPDesencrypt != "" && Sufi_ != "")
                        {
                            int Sufi_int = Int16.Parse(Sufi_);

                            //if (MAC == MACDesencrypt && IP == IPDesencrypt && Sufi_int == Sum_)//Sufi_ == Sum_.ToString() COMENTADO MSHGM CON OLO
                            if (MAC == MACDesencrypt && IP == IPDesencrypt)//Sufi_ == Sum_.ToString() COMENTADO MSHGM CON OLO
                            {
                                strMsjUsuario = "";
                            }
                            else
                            {
                                strMsjUsuario = "Servidor no Autorizado.";
                            }
                        }
                        else
                        {
                            strMsjUsuario = "Token erróneo";
                        }
                    }
                    else
                    {
                        if (Oper == 0)
                        {
                            //Enviar correo a Tecflex para soporte.
                            string strMsjDB = "";
                            string strTipo = "REGSERVER";
                            int intResult = 0;
                            string CorreoDestino = "";
                            string Cliente = "";
                            List<TSConfi> lista = new List<TSConfi>();
                            lista = ListarConfig(objSession, "%_CBX", ref strMsjUsuario);

                            for (int i = 0; i < lista.Count(); i++)
                            {
                                if (lista[i].strCoConfi == "EMAIL_CBX")
                                {
                                    CorreoDestino = lista[i].strValorConfi;
                                }
                                if (lista[i].strCoConfi == "OC_RUCCLI_CBX")
                                {
                                    Cliente = lista[i].strValorConfi;
                                }
                            }

                            string CliDesencriptado = objUser.DesencriptarPassword(Cliente);

                            string[] subs = CliDesencriptado.Split('|');
                            CorreoEmp obj = new CorreoEmp();
                            obj.intIdPersonal = 0;
                            obj.strOC = subs[0];//OC
                            obj.strRUC = subs[1]; //RUC
                            obj.strDestinos = CorreoDestino;//destinatarios
                            string[] subsIP = IP.Split('.');
                            string sCadena = "";
                            int Sum = 0;
                            foreach (string subIP in subsIP)
                            {
                                sCadena = sCadena + (Convert.ToInt32(subIP) + 1000).ToString().Substring(1, 3) + "X";
                                Sum = Sum + Convert.ToInt32(subIP);
                            }
                            sCadena = sCadena + MAC + Sum; // IP:15 dígitos + MAC: 12 dígitos + Sufijo (n dígitos)
                            obj.strCadena = sCadena;

                            if (sCadena != null && sCadena != "")
                            {
                                //enviarCorreo(objSession, obj, strTipo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                                enviarCorreoObtenerServerLogin_SAF(objSession, obj, strTipo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                            }

                            if (intResult == 1)
                            {
                                strMsjUsuario = "Servidor sin Licencia registrada (se envió correo a Tecflex SAC)";
                            }
                            else
                            {
                                strMsjUsuario = "Servidor sin Licencia registrada.";
                            }
                        }
                    }
                }
                else
                {
                    if (IP == "")
                    {
                        //strMsjUsuario = "No se ha Identificado ninguna IP, Conéctese a una Red de Internet";
                        strMsjUsuario = "Conéctese a una Red de Internet";
                    }
                    else
                    {
                        strMsjUsuario = "Servidor no tiene Serial";
                    }
                        
                }

                //Validación Complementaria de QA: Periodo de Prueba ---- DE PRUEBA
                if (EsQA)
                {
                    if (strMsjUsuario == "" && ValidaQA == false)
                    {
                        strMsjUsuario = strMsjValidaQA;
                    }
                }


                return strMsjUsuario;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerServer)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: Exception");
                throw new Exception("Error General (ObtenerServer)");
            }
        }



        ///////////////////////////////////////////////////////////////
        // 3.25 ENCAPSULADO
        ///////////////////////////////////////////////////////////////
        public void ObtServer(ref string IP, ref string MAC)
        {
            try
            {
                //OBTENER IP ACTIVA
                //-------------------------------------------------
                // Get the list of network interfaces for the local computer.
                var adapters = NetworkInterface.GetAllNetworkInterfaces();
                for (int i = 0; i < adapters.Count(); i++)
                {
                    Log.AlmacenarLogMensaje("Adapter " + i.ToString() + ": " + adapters[i].Description.ToString() + "| " + adapters[i].NetworkInterfaceType.ToString() + "| " + adapters[i].OperationalStatus.ToString() + "| " + adapters[i].SupportsMulticast.ToString());

                }

                string Host = Dns.GetHostName();
                //Log.AlmacenarLogMensaje("HostName: " + Host);// ejemplo ----> "DESKTOP-0H9M62B"

                if (adapters != null)
                {
                    //Log.AlmacenarLogMensaje("Adapter no es nulo");

                    var A = (from adapter in adapters
                             let properties = adapter.GetIPProperties()
                             from address in properties.UnicastAddresses
                             where adapter.OperationalStatus == OperationalStatus.Up
                             //&& adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet //añadido manualmente 02.07.2021
                             && address.Address.AddressFamily == AddressFamily.InterNetwork
                             && !address.Equals(IPAddress.Loopback)
                             && address.DuplicateAddressDetectionState == DuplicateAddressDetectionState.Preferred
                             && properties.GatewayAddresses.Count >= 1 //añadido 06.07.2021
                             //&& address.AddressPreferredLifetime != UInt32.MaxValue //se comenta porque no funciona en la 45 
                             select address.Address);
                    var B = (from adapter in adapters
                             let properties = adapter.GetIPProperties()
                             from address in properties.UnicastAddresses
                             where adapter.OperationalStatus == OperationalStatus.Up
                             //&& adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet //añadido manualmente 02.07.2021
                             && address.Address.AddressFamily == AddressFamily.InterNetwork
                             && !address.Equals(IPAddress.Loopback)
                             && address.DuplicateAddressDetectionState == DuplicateAddressDetectionState.Preferred
                             && properties.GatewayAddresses.Count >= 1 //añadido 06.07.2021
                             //&& address.AddressPreferredLifetime != UInt32.MaxValue //se comenta porque no funciona en la 45 
                             select adapter.GetPhysicalAddress());

                    if (A != null && A.Count() > 0)
                    {
                        //Log.AlmacenarLogMensaje("Objeto Adapter si tiene redes");

                        for (int i = 0; i < A.Count(); i++)
                        {
                            //Log.AlmacenarLogMensaje("A: " + A.ElementAt(i).ToString() + "| Total Redes: " + A.Count());

                            if (i == 0)
                            {
                                //Nota: si en caso el adapters tiene más de una coincidencia se toma la primera diferente de 127.0.0.1
                                IP  = A.ElementAt(i).ToString();
                                MAC = B.ElementAt(i).ToString();
                                //NameRed = C.ElementAt(i).ToString();
                                Log.AlmacenarLogMensaje(MAC + " | " + IP);
                            }

                        }
                    }
                    else
                    {
                        Log.AlmacenarLogMensaje("Objeto Adapter no tiene redes" + " | Total Redes: " + A.Count());//La aplicacion necesita conectarse al internet
                    }

                }
                #region Comment Prueba
                ////-----------------------------------------
                //ManagementObjectSearcher ComSerial = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");//Win32_BaseBoard (placa madre)/ Win32_BIOS

                //foreach (ManagementObject wmi in ComSerial.Get())
                //{
                //    try
                //    {
                //        var MainBoard = wmi.GetPropertyValue("SerialNumber").ToString();
                //    }
                //    catch { }
                //}
                ////--------------------------------------------
                ///
                #endregion Comment Prueba
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtServer)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: Exception");
                throw new Exception("Error General (ObtServer)");
            }
        }


        public void ClientesQA(ref string IP, ref bool rpta, ref string Msg_)
        {
            int intResult = 0;
            string strMsjDB = "";
            try
            {
                Session_Movi objSession = new Session_Movi();
                UsuarioDAO objUser = new UsuarioDAO();
                objSession.intIdSesion = 1;
                objSession.intIdSoft = 6;// 1;
                objSession.intIdMenu = 1;

                string strMsjUsuario = "";
                string sCadena = "";
                int TopeCliWeb = 10;
                string IDEncrypt = "";

                //--------------------------------------------------------------------------
                List<TSConfi> lista = new List<TSConfi>();
                lista = ListarConfig(objSession, "%_SERVICE", ref strMsjUsuario);

                for (int i = 0; i < lista.Count(); i++)
                {
                    if (lista[i].strCoConfi == "PCK_SERVICE")
                    {
                        //TopeCliWeb = Convert.ToInt32(objUser.DesencriptarPassword(lista[i].strValorConfi));
                        TopeCliWeb = Convert.ToInt32(lista[i].strValorConfi);
                    }
                    if (lista[i].strCoConfi == "ID_SERVICE")
                    {
                        IDEncrypt = lista[i].strValorConfi;
                    }
                }

                //--------------------------------------------------------------------------
                lista = ListarCliWeb(ref strMsjUsuario);

                if (lista.Count() > 0)
                {
                    if (lista.Count() < TopeCliWeb)
                    {
                        for (int i = 0; i < lista.Count(); i++)
                        {
                            sCadena = lista[i].strValorConfi;
                            if (sCadena != "")
                            {
                                sCadena = objUser.DesencriptarPassword(sCadena);

                                if (sCadena == IP)
                                {
                                    rpta = true;
                                    break;
                                }
                            }
                        }

                        if (!rpta)
                        {
                            sCadena = objUser.EncriptarPassword(IP);
                            rpta = objDao.ICliWeb(sCadena, ref intResult, ref strMsjDB, ref strMsjUsuario);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < lista.Count(); i++)
                        {
                            sCadena = lista[i].strValorConfi;
                            if (sCadena != "")
                            {
                                sCadena = objUser.DesencriptarPassword(sCadena);

                                if (sCadena == IP)
                                {
                                    rpta = true;
                                    break;
                                }
                            }
                        }

                        if (!rpta)
                        {
                            string IDDesencrypt = objUser.DesencriptarPassword(IDEncrypt);
                            if (IDDesencrypt.Substring(0, 1) == "Q")
                            {
                                Msg_ = "Cliente NO Autorizado (Licencia de Prueba solo permite " + TopeCliWeb.ToString() + " clientes)";
                            }
                            else
                            {
                                Msg_ = "Cliente NO Autorizado (Licencia solo permite " + TopeCliWeb.ToString() + " clientes)";
                            }

                        }
                    }
                }
                else
                {
                    sCadena = objUser.EncriptarPassword(IP);
                    rpta = objDao.ICliWeb(sCadena, ref intResult, ref strMsjDB, ref strMsjUsuario);
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ClientesQA)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: Exception");
                throw new Exception("Error General (ClientesQA)");
            }
        }


        //LISTAR CLI
        public List<TSConfi> ListarCliWeb(ref string strMsjUsuario)
        {
            List<TSConfi> lista = new List<TSConfi>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCliWeb(ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCliWeb] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCliWeb)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TSConfiBL.cs: Exception");
                throw new Exception("Error General (ListarCliWeb)");
            }
            return lista;
        }




    }
}
