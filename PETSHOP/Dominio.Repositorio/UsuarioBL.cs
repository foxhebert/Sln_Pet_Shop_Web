using Dominio.Entidades;
using Dominio.Repositorio.Util;
using Infraestructura.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Dominio.Repositorio
{
    public class UsuarioBL
    {
        private UsuarioDAO objUsuario = new UsuarioDAO();
        private ImportarExcelDAO objDao = new ImportarExcelDAO();
        private TSConfiBL obj_ = new TSConfiBL();

        //3.8
        public List<TG_USUARIO> ListarUsuarios(long intIdSesion, int intIdMenu, int intIdSoft, int intActivo, string strDescripcion, int intTipoFiltro, ref string strMsjUsuario)
        {
            List<TG_USUARIO> lista = new List<TG_USUARIO>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objUsuario.ListarUsuarios(intIdSesion, intIdMenu, intIdSoft, intActivo, strDescripcion, intTipoFiltro, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarUsuarios] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UsuarioBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarUsuarios)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UsuarioBL.cs: Exception");
                throw new Exception("Error General (ListarUsuarios)");
            }
            return lista;
        }
        //3.9
        public bool EliminarUsuario(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdUsu, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objUsuario.EliminarUsuario(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdUsu, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminarUsuario] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UsuarioBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminarUsuario)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UsuarioBL.cs: Exception");
                throw new Exception("Error General (EliminarUsuario)");
            }
        }
        //3.10
        public bool InsertOrUpdateUsuario(long intIdSesion, int intIdMenu, int intIdSoft, TG_USUARIO objDatos, List<TSUSUAR_PERFI> listaDetallesUsuarioPerfil, List<TT_TSUSUAR_FILTRO> listaDetallesUsuarioFiltro, int intIdUsuario, int intTipoOperacion, ref string strMsjUsuario)
        {
            bool tudobem = false;
            int intResult = 0;
            string strMsjDB = "";
            string Msj = "";

            try
                {
                    intResult = objUsuario.IUsuario_T(intIdSesion, intIdMenu, intIdSoft, objDatos, intIdUsuario, intTipoOperacion, listaDetallesUsuarioPerfil, listaDetallesUsuarioFiltro, ref intResult, ref strMsjDB, ref strMsjUsuario, ref Msj);

                    if (intResult == 0)
                    {
                        if (!strMsjDB.Equals(""))
                        {
                            Log.AlmacenarLogMensaje("[InsertOrUpdateUsuario] => Respuesta del Procedimiento : " + strMsjDB);
                        Log.AlmacenarLogMensaje("[InsertOrUpdateUsuario] => Respuesta de la clase de Datos: " + Msj);
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
                    Log.AlmacenarLogError(ex, "UsuarioBL.cs: SqlException");
                    throw new Exception("Ocurrió un error en BD (InsertOrUpdateUsuario)");
                }
                catch (Exception ex)
                {
                    Log.AlmacenarLogError(ex, "UsuarioBL.cs: Exception");
                    throw new Exception("Error General (InsertOrUpdateUsuario)");
                }
        }
        //3.11
        public List<TG_USUARIO> ObtenerRegistroUsuario(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuar, ref string strMsjUsuario)
        {
            List<TG_USUARIO> lista = new List<TG_USUARIO>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objUsuario.ObtenerRegistroUsuario(intIdSesion, intIdMenu, intIdSoft, intIdUsuar, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerRegistroUsuario] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UsuarioBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerRegistroUsuario)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UsuarioBL.cs: Exception");
                throw new Exception("Error General (ObtenerRegistroUsuario)");
            }
            return lista;
        }
        //3.12 
        public List<TG_USUARIO> ValidarUsuario(long intIdSesion, int intIdMenu,  int intIdSoft, string strusuario, string strcontraseña, string strIpHost, string strCoSoft, ref int Valida, ref string strMsjUsuario)
        {
            List<TG_USUARIO> lista = new List<TG_USUARIO>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";


                string Msg_ = "";
                //añadido 05.07.2021
                //---------------------------------------------------------------------
                //Cotejar la existencia de dicha IP dentro de la cadena de Clientes permitidos
                bool rpta = false;
                obj_.ClientesQA(ref strIpHost, ref rpta, ref Msg_);
                //---------------------------------------------------------------------

                if (rpta)//añadido inicio 05.07.2021
                {//añadido fin 05.07.2021

                    //lista = objUsuario.ValidarUsuario(intIdSesion, 0, intIdSoft, strusuario, strcontraseña, strCoSoft, /*strIpHost,*/ ref Valida, ref strMsjUsuario);
                    lista = objUsuario.ValidarUsuario(intIdSesion, 0, intIdSoft, strusuario, strcontraseña, strIpHost,strCoSoft,  ref Valida, ref intResult, ref strMsjDB, ref strMsjUsuario);

                    if (intResult == 0)
                    {
                        if (!strMsjDB.Equals(""))
                        {
                            Log.AlmacenarLogMensaje("[ValidarUsuario] => Respuesta del Procedimiento : " + strMsjDB);
                            if (strMsjUsuario.Equals(""))
                                strMsjUsuario = strMsjDB;
                        }
                    }
                }//añadido inicio 05.07.2021
                else
                {
                    strMsjUsuario = Msg_;
                }//añadido fin 05.07.2021


            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UsuarioBL.cs");
                throw new Exception("Ocurrió un error en BD (ValidarUsuario)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UsuarioBL.cs");
                throw new Exception("Error General (ValidarUsuario)");
            }
            return lista;
        }
        //3.13
        public bool ActualizarPasswrMx(long intIdSesion, int intIdMenu, int intIdSoft, string strUsUsuar, string strCoPassw, string strNwPassw, int intIdUsuario, ref string strEstado, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                // using (TransactionScope scope = new TransactionScope())
                //{
                tudobem = objUsuario.ActualizarPasswrMx(intIdSesion, intIdMenu, intIdSoft, strUsUsuar, strCoPassw, strNwPassw, intIdUsuario, ref strEstado, ref intResult, ref strMsjDB, ref strMsjUsuario);

                //  scope.Complete();
                // }

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ActualizarPasswrMx] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "UsuarioBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (ActualizarPasswrMx)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UsuarioBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ActualizarPasswrMx)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UsuarioBL.cs: Exception");
                throw new Exception("Error General (ActualizarPasswrMx)");
            }
        }
        //3.14
        public bool RestablecerContra(Session_Movi objSession, string strNwPassw, int intIdPersonal, ref string strEstado, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                tudobem = objUsuario.RestablecerContra(objSession, strNwPassw, intIdPersonal, ref strEstado, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (strEstado == "1")
                {
                    CorreoEmp obj = new CorreoEmp();
                    obj.intIdPersonal = intIdPersonal;
                    obj.strCorreo = strMsjUsuario;
                    enviarCorreoValidacion(objSession, obj, ref intResult, ref strMsjDB, ref strMsjUsuario);
                }

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[RestablecerContra] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "UsuarioBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (RestablecerContra)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UsuarioBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (RestablecerContra)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UsuarioBL.cs: Exception");
                throw new Exception("Error General (RestablecerContra)");
            }
        }
        
        //3.17 //////////----> 02.07.21 Lo cambiamos de private a public
        private StringBuilder htmlMessageBody(CorreoEmp obj, string filtro)
        {
            StringBuilder strB = new StringBuilder();

            int intResult = 0;
            string strMsjDB = "";
            string strMsjUsuario = "";
            TEXTOCORREO objTexto = objDao.GetTextoCorreo(filtro, obj.intIdPersonal, 0, false, "", ref intResult, ref strMsjDB, ref strMsjUsuario);

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
        //3.18
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

                StringBuilder datos = htmlMessageBody(obj, "RESTABLECER");

                //receptores
                msg.To.Add(new MailAddress(obj.strCorreo));
                //msg.To.Add(new MailAddress("ereyes@tecflex.com"));
                //msg.CC.Add(new MailAddress("esuyon@tecflex.com"));
                //msg.CC.Add(new MailAddress("programador04@tecflex.com"));

                //Remitente
                msg.From = new MailAddress(ccorreo);

                //Titulo
                msg.Subject = "Confirmación de cambio de contraseña";

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
                strMsjUsuario = "Se Envió el correo de confirmación de cambio de contraseña.";
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

        





    }
}
