using CBX_Web_PetShopWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;

/////////////////////////////DE LAS CARPETAS DEL SERVICE
using Dominio.Repositorio;
using Dominio.Entidades;

namespace CBX_Web_PetShopWeb.Controllers
{
    public class LoginSiscopController : Controller
    {

        //private SeguridadSrvClient Seguridad_tsp; //HGM_COMENTADO_19.08.2021_12:11:14         
        //private PersonalSrvClient proxy;//HGM_COMENTADO_19.08.2021_12:11:14    
        public static string texto { get; set; }
        public static string textoConfig { get; set; }
        public static string pieConfig { get; set; }
        public static string strIpHost { get; set; }

        //////////////////////////////////////////////////////HGM_AÑADIDO_19.08.2021_15:51:08 
        public TSConfiBL objTSConfiBL = new TSConfiBL();
        public UsuarioBL objUsuarioBL = new UsuarioBL();
        public ImportarExcelBL objImportarExcelBL = new ImportarExcelBL();
        public PerfilBL objPerfilBL = new PerfilBL();        
        ////////////////////////////////////////////////////

        // GET: LoginSiscop
        public ActionResult LoginSiscop()
        {
            getNomSoftWeb();
            getVersionWeb();
            //getVersionWs(); //HGM_COMENTADO_19.08.2021_12:06:22 

            if (Auth.isAuthenticated())
            {
                return RedirectToAction("PaginaPrincipal", "Inicio");
            }
            return View();
        }

        //HGM_COMENTADO
        /* 
        public bool ValidarConexWCF()
        {
            string version = "";
            try
            {
                using (Seguridad_tsp = new SeguridadSrvClient())
                {
                    version = Seguridad_tsp.wsVersion();
                    return true; //Si conecta al Servicio
                }
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "LoginSiscopController.cs: Exception");
                version = "No es posible conectar con el Web Service";//añadido 22.04.2021
                return false; //No conecta al Servicio
            }
        }
       */

        //OBTENER EL IP CON CODIGIGO C# - A Nivel WebSite
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

            strIpHost = ip;
            //string ipaddress = Request.UserHostAddress;
            return ip;
        }
        //HGM_OK
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginSiscop(string usuario, string contraseña)
        {
            string strMsgUsuario = "";
            int Valida = 0;
            string strUserNameInput = "";
            string strMensajeError = "";
            string strMsgAlert = "";
            int LoginAttempts = 0;
            int tiempoEspera = 0;

            if (Session["LoginAttempts"] != null)
            {
                LoginAttempts = Convert.ToInt32(Session["LoginAttempts"]);
            }

            string msj = "";
            //using (Seguridad_tsp = new SeguridadSrvClient())//HGM_COMENTADO_19.08.2021_12:11:14 
            //{
            //msj = Seguridad_tsp.ObtenerServer();//Si llega un mensaje....entonces
           /* TSConfiBL objTSConfiBL = new TSConfiBL(); *///HGM_AÑADIDO_19.08.2021_14:31:51 

            msj = objTSConfiBL.ValidaServer("", 0);
            //}


            //Añadido solo para ciertos Ususarios HGM 05.02.22 en el sitema PetshopWeb
            //05.02.22 18:03PM Añadir acceso en el login solo para ciertos usuario en duro y evitar la licencia
            if (   usuario == "sara"
                || usuario == "keko"
                || usuario == "oscar"
                || usuario == "admin"
                )
            {
                msj = "";
            }

            if (msj == "")
            {

                ///////////////////////////////////////////////////////////////////////////
                /*
                //HGM_COMENTADO
                if (ValidarConexWCF())
                {

                    //////YA NO SE VALIDA ESTA CONEXION AL SERVICE EN INVENTARIOWEB
                }
                else
                {
                    Session["LoginAttempts"] = null;
                    Session["LoginTimeAttempts"] = null;
                    return Json(new { codValida = Valida, error = "login", data = tiempoEspera, strMsgAlert = "No es posible conectar con el Servicio Web", strUserNameInput = "", strMensajeError = "" });
                }
                */

                if (LoginAttempts <= 3)
                    {

                        try
                        {
                            List<TG_USUARIO> detConcepto = new List<TG_USUARIO>();
                        //using (Seguridad_tsp = new SeguridadSrvClient())
                        //{
                        //GetUserIPAddress();
                        /*"192.168.1.103",*/
                        //SISCOP detConcepto = Seguridad_tsp.ValidarUsuario_(objSession__, usuario, contraseña, getNomSoftWeb(), ref Valida, ref strMsgUsuario).ToList();

                             UsuarioBL objUsuarioBL = new UsuarioBL();                             
                             detConcepto = objUsuarioBL.ValidarUsuario(3, 1, 6, usuario,  contraseña, GetUserIPAddress(), getNomSoftWeb(),  ref Valida, ref strMsgUsuario).ToList();
                               
                                //detConcepto = Seguridad_tsp.ValidarUsuario_(objSession__, usuario, contraseña, getNomSoftWeb(), ref Valida, ref strMsgUsuario).ToList();
                            //}

                            if (detConcepto.Count() > 0)
                            {
                                strMensajeError = detConcepto[0].strDetalleValida;
                            }


                            if (Valida == 1 || Valida == 5)
                            {
                                int idUsuarioBd = detConcepto[0].intIdUsuar;

                                Session["isAuthenticated"] = "true";
                                Session["intCodValidaSesion"] = Valida;
                                Session["intIdUsuarioSesion"] = detConcepto[0].intIdUsuar;
                                //Session["imgFoto"] = detConcepto[0].imgFoto;
                                //inicio 27.03.2021
                                string DirWebConfig = "";
                                DirWebConfig = System.Configuration.ConfigurationManager.AppSettings["rutaFotoEmpleado"];
                                //ruta = "/DirEmpleadosRuta/";//"~/DirEmpleadosRuta/";

                                var filePath = Server.MapPath(DirWebConfig + detConcepto[0].imgFoto);

                                if (System.IO.File.Exists(filePath))
                                {
                                    Session["imgFoto"] = detConcepto[0].imgFoto;
                                }
                                else
                                {
                                    Session["imgFoto"] = "person_logo.jpg";
                                }
                                //fin
                                Session["imgfotoDefault"] = "person_logo.jpg";
                                Session["strNombreUsuarioSesion"] = detConcepto[0].strNoUsuar;
                                Session["intIdPerfilSesion"] = detConcepto[0].intIdPerfil;
                                Session["strNomPerfilSesion"] = detConcepto[0].strNomPerfil;
                                Session["intIdSesionSesion"] = detConcepto[0].intIdSesion;
                                Session["strUserNameSesion"] = detConcepto[0].strUserName.ToUpper();
                                Session["intIdSoftSesion"] = detConcepto[0].intIdSoft;
                                Session["intCodValidaSesion"] = detConcepto[0].intCodValida;
                                Session["intIdPersonal"] = detConcepto[0].intIdPersonal;

                                Session["jsonUserInfoSesion"] = new
                                {
                                    isAuthenticated = Session["isAuthenticated"],
                                    codValida = Session["intCodValidaSesion"],
                                    idUser = Session["intIdUsuarioSesion"],
                                    imgFoto = Session["imgFoto"],
                                    strNombreUser = Session["strNombreUsuarioSesion"],
                                    intIdPerfil = Session["intIdPerfilSesion"],
                                    strNomPerfil = Session["strNomPerfilSesion"],
                                    intIdSesion = Session["intIdSesionSesion"],
                                    strUserName = Session["strUserNameSesion"],
                                    intIdSoft = Session["intIdSoftSesion"],
                                    intCodValida = Session["intCodValidaSesion"],
                                };
                                MenuPorUsuario();

                                Session["LoginAttempts"] = null;
                                Session["LoginTimeAttempts"] = null;
                                return Json(new { codValida = Valida, error = "", data = Session["jsonUserInfoSesion"], strMsgAlert = "", strUserNameInput = "", strMensajeError = "" });
                                //return RedirectToAction("PaginaPrincipal", "Inicio");
                            }



                        //////////else //añadido 05.07.2021
                        //////////{
                        //////////    Session["LoginAttempts"] = null;
                        //////////    Session["LoginTimeAttempts"] = null;
                        //////////    return Json(new { codValida = Valida, error = "login", data = tiempoEspera, strMsgAlert = strMsgUsuario, strUserNameInput = "", strMensajeError }); //strMensajeError = ""
                        //////////}//añadido fin  05.07.2021 

                          else //añadido 05.07.2021
                          {
                            // Session["LoginAttempts"] = LoginAttempts+1;//MODIFICADO  =NULL
                            Session["LoginTimeAttempts"] = null;
                            // return Json(new { codValida = Valida, error = "login", data = tiempoEspera, strMsgAlert = strMsgUsuario, strUserNameInput = "", strMensajeError = "" });
                            if (Session["LoginAttempts"] != null)
                            {
                                LoginAttempts = Convert.ToInt32(Session["LoginAttempts"]);
                                Session["LoginAttempts"] = ++LoginAttempts;
                                if (LoginAttempts == 2)
                                {
                                    strMsgAlert = "Le quedan 2 intentos.";
                                }
                                else if (LoginAttempts == 3)
                                {
                                    strMsgAlert = "Le queda 1 intento.";
                                }
                                else
                                {
                                    tiempoEspera = Int32.Parse(WebConfigurationManager.AppSettings["tiempoespera"]);
                                    Session["LoginAttempts"] = null;
                                }
                                //return Json(new { codValida = Valida, error = "login", data = tiempoEspera, strMsgAlert = strMsgAlert, strUserNameInput = strUserNameInput, strMensajeError = strMensajeError });
                            }
                            else
                            {
                                Session["LoginAttempts"] = 1;
                                strMsgAlert = "Le quedan 3 intentos.";
                                //return Json(new { codValida = Valida, error = "login", data = tiempoEspera, strMsgAlert = strMsgAlert, strUserNameInput = strUserNameInput, strMensajeError = strMensajeError });
                            }


                          }//añadido fin  05.07.2021


                        }
                        catch (Exception ex)
                        {
                            Log.AlmacenarLogError(ex, "LoginController.cs");
                        }

                }

                    //////if (Session["LoginAttempts"] != null)
                    //////{
                    //////    LoginAttempts = Convert.ToInt32(Session["LoginAttempts"]);
                    //////    Session["LoginAttempts"] = ++LoginAttempts;
                    //////    if (LoginAttempts == 2)
                    //////    {
                    //////        strMsgAlert = "Le quedan 2 intentos.";
                    //////    }
                    //////    else if (LoginAttempts == 3)
                    //////    {
                    //////        strMsgAlert = "Le queda 1 intento.";
                    //////    }
                    //////    else
                    //////    {
                    //////        tiempoEspera = Int32.Parse(WebConfigurationManager.AppSettings["tiempoespera"]);
                    //////        Session["LoginAttempts"] = null;
                    //////    }
                    //////}
                    //////else
                    //////{
                    //////    Session["LoginAttempts"] = 1;
                    //////    strMsgAlert = "Le quedan 3 intentos.";
                    //////}

                    return Json(new { codValida = Valida, error = "login", data = tiempoEspera, strMsgAlert = strMsgAlert, strUserNameInput = strUserNameInput, strMensajeError = strMensajeError });

            }


            //else
            //{
            //    Session["LoginAttempts"] = null;
            //    Session["LoginTimeAttempts"] = null;
            //    return Json(new { codValida = Valida, error = "login", data = tiempoEspera, strMsgAlert = "No es posible conectar con el Servicio Web", strUserNameInput = "", strMensajeError = "" });
            //}

            else
            {
                Session["LoginAttempts"] = null;
                Session["LoginTimeAttempts"] = null;
                return Json(new { codValida = Valida, error = "login", data = tiempoEspera, strMsgAlert = msj, strUserNameInput = "", strMensajeError = "" });
            }

        }



        //HGM_OK
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult CambiarClave(string contraseña, string nuevacontraseña)
        {
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";
            string strEstado = "";

            int tiempoEspera = Convert.ToInt32(WebConfigurationManager.AppSettings["tiempoespera"]);
            int ActulizarClaveAttempts = 0;

            if (Session["ActualizarClaveTime"] != null)
            {
                DateTime CurrentTime = DateTime.UtcNow;
                DateTime LoginTime = Convert.ToDateTime(Session["ActualizarClaveTime"].ToString());
                if (CurrentTime > LoginTime)
                {
                    Session["ActulizarClaveAttempts"] = null;
                    Session["ActualizarClaveTime"] = null;
                }
            }
            if (Session["ActulizarClaveAttempts"] != null)
            {
                ActulizarClaveAttempts = Convert.ToInt32(Session["ActulizarClaveAttempts"]);
            }

            if (ActulizarClaveAttempts <= 3)
            {
                if (Auth.AuthenticatedGeneral()) //HGM PRNDIENTE
                {

                    try
                    {
                        bool insert = false;
                        string strUsUsuar = Session["strUserNameSesion"].ToString();
                        int intIdUsuario = Convert.ToInt32(Session["intIdUsuarioSesion"].ToString());

                        //using (Seguridad_tsp = new SeguridadSrvClient()) //HGM_COMENTADO_19.08.2021_14:23:41 
                        //{
                            //UsuarioBL objUsuBL = new UsuarioBL();  
                            insert = objUsuarioBL.ActualizarPasswrMx(3, 1, 6, strUsUsuar, contraseña, nuevacontraseña, intIdUsuario, ref strEstado, ref strMsgUsuario);
                            //Seguridad_tsp.Close();
                        //}

                        if (strEstado == "1" && insert)
                        {
                            result.type = "success";
                            result.message = "Contraseña actualizada con éxito.";

                            return Json(result);
                        }
                        else if (strEstado == "3")
                        {
                            result.type = "errorNoNoincide";
                            result.message = "La contraseña actual es incorrecta.";
                        }
                        else if (strEstado == "2")
                        {
                            result.type = "errorPassIgual";
                            result.message = "La nueva contraseña ingresada debe ser distinta a la contraseña actual.";
                        }
                        else
                        {
                            result.type = "error";
                            result.message = strMsgUsuario;

                        }

                    }
                    catch (Exception ex)
                    {
                        Log.AlmacenarLogError(ex, "LoginController.cs");
                        result.type = "errorInt";
                        result.message = "Ocurrió un inconveniente al actualizar contraseña por restablecimiento";
                    }
                }
                else
                {
                    result.type = "errorNoLogin";
                    result.message = "Ingrese al login.";
                }
            }

            if (Session["ActulizarClaveAttempts"] != null)
            {
                ActulizarClaveAttempts = Convert.ToInt32(Session["ActulizarClaveAttempts"]);
                Session["ActulizarClaveAttempts"] = ++ActulizarClaveAttempts;
                if (ActulizarClaveAttempts == 2)
                {
                    result.extramsg = "Le quedan 2 intentos.";
                }
                else if (ActulizarClaveAttempts == 3)
                {
                    result.extramsg = "Le queda 1 intento.";
                }
            }
            else
            {
                Session["ActulizarClaveAttempts"] = 1;
                result.extramsg = "Le quedan 3 intentos.";
            }

            if (ActulizarClaveAttempts > 3)
            {
                string timeShow = "" + tiempoEspera;
                if (Session["ActualizarClaveTime"] == null)
                {
                    DateTime CurrentTime = DateTime.UtcNow;
                    Session["ActualizarClaveTime"] = CurrentTime.AddSeconds(tiempoEspera);
                }
                else
                {
                    DateTime currentTimeDiff = DateTime.UtcNow;
                    DateTime loginTimeDiff = Convert.ToDateTime(Session["ActualizarClaveTime"].ToString());

                    TimeSpan diffResult = loginTimeDiff.Subtract(currentTimeDiff);
                    timeShow = diffResult.Seconds.ToString();
                }
                result.extramsg = "Espera " + timeShow + " segundos para volver intentar.";
            }
            return Json(result);
        }
        //HGM_OK
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RestablecerContra(string contrasena, int intIdPersonal)
        {
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";
            string strEstado = "";
            try
            {
                Session_Movi objSession = new Session_Movi();
                objSession.intIdSesion = Auth.intIdSesion();
                objSession.intIdSoft = Auth.intIdSoft();
                objSession.intIdMenu = 0;
                objSession.intIdUsuario = Auth.intIdUsuario();

                bool insert = false;

                //using (Seguridad_tsp = new UsuarioBL())
                //{
                    insert = objUsuarioBL.RestablecerContra(objSession, contrasena, intIdPersonal, ref strEstado, ref strMsgUsuario);
                //    Seguridad_tsp.Close();
                //}

                if (strEstado == "1" && insert)
                {
                    result.type = "success";
                    result.message = "Contraseña actualizada con éxito.";
                    result.extramsg = "1";
                }
                else
                {
                    result.type = "error";
                    result.message = strMsgUsuario;
                    result.extramsg = "0";
                }
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "LoginController.cs");
                result.type = "errorInt";
                result.message = "Ocurrió un inconveniente al actualizar contraseña";
            }

            return Json(result);
        }
        //HGM_OK
        public JsonResult ValidarEmail(string numDoc, string correo)
        {
            Session_Movi objSession = new Session_Movi();
            objSession.intIdSesion = Auth.intIdSesion();
            objSession.intIdSoft = Auth.intIdSoft();
            objSession.intIdMenu = 0;
            objSession.intIdUsuario = Auth.intIdUsuario();

            int ValidarCorreo = 0;

            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";
            string mensaje = "";

            if (Session["ValidarCorreo"] != null)
            {
                ValidarCorreo = Convert.ToInt32(Session["ValidarCorreo"]);
            }
            if (ValidarCorreo <= 3)
            {
                try
                {
                    //using (proxy = new PersonalSrvClient())
                    //{
                        mensaje = objImportarExcelBL.ValidarEmail(objSession, numDoc, correo, ref strMsgUsuario);
                    //    proxy.Close();
                    //}

                    if (mensaje.Equals("no"))
                    {
                        result.type = "info";
                        result.message = strMsgUsuario;
                    }
                    else
                    {
                        result.type = "success";
                        result.message = strMsgUsuario;
                        return Json(result);
                    }
                }
                catch (Exception ex)
                {
                    Log.AlmacenarLogError(ex, "ProcesoController.cs");
                    return new JsonErrorResult(new { msg = RespuestaMensaje.errorGeneral }, HttpStatusCode.MethodNotAllowed);
                }
            }

            if (Session["ValidarCorreo"] != null)
            {
                ValidarCorreo = Convert.ToInt32(Session["ValidarCorreo"]);
                Session["ValidarCorreo"] = ++ValidarCorreo;
                if (ValidarCorreo == 2)
                {
                    result.extramsg = "Le quedan 2 intentos.";
                }
                else if (ValidarCorreo == 3)
                {
                    result.extramsg = "Le queda 1 intento.";
                }
                else
                {
                    result.objeto = 100;
                    result.extramsg = WebConfigurationManager.AppSettings["tiempoespera"];
                    Session["ValidarCorreo"] = null;
                }
            }
            else
            {
                Session["ValidarCorreo"] = 1;
                result.extramsg = "Le quedan 3 intentos.";
            }
            return Json(result);
        }
        //HGM_OK 
        public JsonResult MenuPorUsuario()
        {
            if (Auth.isAuthenticated())
            {
                try
                {
                    int intIdUsuar = Convert.ToInt32(Session["intIdUsuarioSesion"].ToString());
                    string strMsgUsuario = "";

                    List<TS_MENU_PADRE> DetMenu = new List<TS_MENU_PADRE>();
                    //using (Seguridad_tsp = new SeguridadSrvClient())
                    //{
                        DetMenu = objPerfilBL.MenuPorUsuario(Auth.intIdSesion(), 1, Auth.intIdSoft(), intIdUsuar, 0, ref strMsgUsuario).ToList();
                        Session["jsonPerfilMenu"] = DetMenu;
                    //}
                    return Json(DetMenu);
                }
                catch (Exception ex)
                {
                    Log.AlmacenarLogError(ex, "LoginController.cs");
                }


            }
            Session["jsonPerfilMenu"] = null;
            return Json(new { error = 401, msg = "Error no login" });
        }
        //HGM_OK
        public ActionResult RestablecerContrasena(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                texto = "";
            }
            else
            {
                texto = id;
            }

            textoConfig = WebConfigurationManager.AppSettings["textoConfig"].ToString();
            pieConfig = WebConfigurationManager.AppSettings["pieConfig"].ToString();

            if (Auth.isAuthenticated())
            {
                return RedirectToAction("PaginaPrincipal", "Inicio");
            }

            return View();
        }
        //HGM_OK
        public JsonResult GetTexto()
        {
            return Json(texto);
        }
        //HGM_OK
        public JsonResult GetConfig()
        {
            Dictionary<string, string> config = new Dictionary<string, string>();

            config.Add("textoConfig", textoConfig);
            config.Add("pieConfig", pieConfig);

            return Json(config);
        }
        //HGM_OK
        [HttpGet]
        public ActionResult CerrarSesion()
        {
            Session["LoginAttempts"] = null;
            Session["intCodValidaSesion"] = null;
            Session["isAuthenticated"] = null;
            Session["intIdUsuarioSesion"] = null;
            Session["strNombreUsuarioSesion"] = null;
            Session["intIdPerfilSesion"] = null;
            Session["strNomPerfilSesion"] = null;
            Session["intIdSesionSesion"] = null;
            Session["strUserNameSesion"] = null;
            Session["intIdSoftSesion"] = null;
            Session["intCodValidaSesion"] = null;
            Session["jsonUserInfoSesion"] = null;
            Session["jsonPerfilMenu"] = null;
            Session["ActulizarClaveAttempts"] = null;
            Session["LoginAttempts"] = null;
            Session["LoginTimeAttempts"] = null;
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

            //getVersionWs(); //HGM_COMENTADO_19.08.2021_14:52:11 
            getVersionWeb();

            return RedirectToAction("LoginSiscop");
        }
        /*//HGM_COMENTADO_19.08.2021_14:41:24 
        public string getVersionWs()
        {
            string version = "";
            try
            {
                using (Seguridad_tsp = new SeguridadSrvClient())
                {
                    version = Seguridad_tsp.wsVersion();
                }
                //Session["wsVersionSesion"] = version;
            }
            catch (Exception ex)
            {
                //Log.AlmacenarLogError(ex, "LoginController.cs");
                //version = "No es posible conectar con el Web Service";//añadido 22.04.2021

                Log.AlmacenarLogError(ex, "LoginSiscopController.cs");
                version = "Verificar Conexión con Web Service";//añadido 22.04.2021
            }
            
            Session["wsVersionSesion"] = version;//añadido 22.04.2021
            return version;
        }
        */
        //HGM_OK
        public string getVersionWeb()
        {
            string versionweb = "";
            try
            {
                versionweb = WebConfigurationManager.AppSettings["webversion"].ToString();
                Session["webVersionSesion"] = versionweb;
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "LoginController.cs");
            }
            return versionweb;
        }
        //HGM_OK
        public string getNomSoftWeb()
        {
            string nameSoft = "";
            try
            {
                nameSoft = WebConfigurationManager.AppSettings["nomsoft"].ToString();
                Session["webNameSoft"] = nameSoft;
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "LoginController.cs");
            }
            return nameSoft;
        }

        //AÑADIDO 07.04.2021 - INTENTANDO ALMACENAR EL N° DE MARCADOR
        public int setNumMarcadorTomaConsumo(int numMarcador)
        {
            try
            {
                Session["numMarcadorToma"] = numMarcador;
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "LoginController.cs");
            }
            return numMarcador;
        }

        //AÑADIDO 07.04.2021 - INTENTANDO ALMACENAR EL N° DE MARCADOR
        public int getNumMarcadorTomaConsumo()
        {
            int numMarcador = 0;
            try
            {
                //Session["jsonUserInfoSesion"] = new
                //{
                numMarcador = Auth.intNumMarcadorTomaConsumo();  
                //};
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "LoginController.cs");
            }
            return numMarcador;
        }

        /**************************************************************************
           Añadido desde lo desarrollado en siscop  por Elizabeth 05.07.2021 10AM          
        ***************************************************************************/
        //HGM_OK
        public ActionResult RegistrarServerWCF(string llave, int Oper)//public string RegistrarServerWCF(string llave, int Oper)
        {
            CustomResponse result = new CustomResponse();

            Session_Movi objSesion = new Session_Movi();
            objSesion.intIdSesion = 1;
            objSesion.intIdSoft = 1;
            objSesion.intIdMenu = 1;
            int intRpta = 0;
            try
            {
                //using (Seguridad_tsp = new SeguridadSrvClient())
                //{
                    string msj = objTSConfiBL.GenerarServerEncriptado(objSesion, ref intRpta, llave, Oper); //Oper= 0: Encriptar //1: Encriptar y Registrar // 2: Registrar
                    if (intRpta == 1)
                    {
                        result.type = "success";
                    }
                    else
                    {
                        result.type = "errorInt";
                    }

                    result.message = msj;
                //}
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ConfiguracionController.cs");
                result.type = "errorInt";
                result.message = "Ocurrió un inconveniente al RegistrarServerWCF";
            }

            return Json(result);

        }


    }
}
