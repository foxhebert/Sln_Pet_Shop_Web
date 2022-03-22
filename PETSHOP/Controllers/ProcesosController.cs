using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CBX_Web_PetShopWeb.Models;
//using System.Web.Mvc;
//using Newtonsoft.Json;
using BODESOFT.Models;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Configuration;
using System.IO;
//ENVIO A CORREO
using System.Net.Mail;
using System.Net;

namespace CBX_Web_PetShopWeb.Controllers
{
    public class ProcesosController : Controller
    {




        //CONTROLLOER
        public JsonResult fctEnviarReciboPdfCorreo(string filtroDeReporte, string strEmailDestino)
        {
            CustomResponse result = new CustomResponse();
            //string strMsgUsuario = "";
            bool ventaTodosOkey = true;

            try
            {

                //if (Request.QueryString["email"] != null)
                //{

                    //https://stackoverflow.com/questions/6152979/how-can-i-create-a-new-folder-in-asp-net-using-c
                    //var folder = Server.MapPath("~/App_Data/uploads/random");
                    var folder = Server.MapPath("~/DirTempArchivosPdf");
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    string rutaFile = Server.MapPath("~/" + "DirTempArchivosPdf" + "/" + filtroDeReporte + ".pdf");
                    //System.IO.File.Create(rutaFile).Close();

                    //string c_strEmailDestino = "saracustodioh@gmail.com" + "," + strEmailDestino;
                string c_strEmailDestino = strEmailDestino;

                using (MailMessage mm = new MailMessage("sispetshopweb@gmail.com", c_strEmailDestino))
                    {
       
                        //mm.Subject = "Comprobante de Venta PetShopWeb";
                        //mm.Body = "Archivo Adjunto: " + filtroDeReporte;

                    //mm.Subject = "Crystal Report PDF";
                    mm.Subject = "Comprobante de Venta PetShopWeb";
                    //mm.Body = "Archivo Adjunto: " + filtroDeReporte;


                    StringBuilder strB = new StringBuilder();

                    strB.AppendLine("<html>");
                    strB.AppendLine("<body>");
                    //strB.AppendLine("<img src=cid:logo />");
                    strB.AppendLine("<br>");
                    strB.AppendLine("<div  style='text-align:center; '>");
                    strB.AppendLine("<span style='font-size: large;'>" + "SISTEMA PETSHOP WEB ©2022 " /*objTexto.saludo*/ + "</span>");
                    strB.AppendLine("</div>");


                    strB.AppendLine("<div>");
                    //strB.AppendLine("<img alt='LATAM Pass' border='0' height='80' src='https://ci5.googleusercontent.com/proxy/EudqZB2x45b3erGuOUH7s7zSSxAZ6Ad1WBcW0ceprn8NP8o83NnpujTWP1BQ9j93E-9z4LmISEl3lPYgufmQ9synSZS6_lugaw3mJ2b92lN_88Xz0V6bebYGp4yH4zb4jQeAdjH6HQXBUsSkMbIF3HNnEaXx0Fo4rIWl3HnnrpxBL0_4dTEqfcp0CMIQcUy0DFsZlHsZiAR6BnWwsFY954KAzBA5xbcBs4d8zog7N8qIywAT8Kw=s0-d-e1-ft#http://static.cdn.responsys.net/i2/responsysimages/latam/contentlibrary/pe_/bloques/estaticos/header_latampass/Header_latampass_pe/Files/header_logo_latampass.jpg' title='LATAM Pass' width='369'>");
                    strB.AppendLine("<img alt='LATAM Pass' border='0'  src='https://i.postimg.cc/TwSdV9h6/kekopet-banner.png' title='PETSHOP BANNER' width='500'>");
                    strB.AppendLine("</div>");




                    strB.AppendLine("<div  style='padding-top:5px; text-align:center;' >");
                    strB.AppendLine("<img alt='LATAM Pass' border='0'  src='https://i.postimg.cc/YSVg9TYN/kekopet-baner-main.jpg' title='PETSHOP 02' width='500'>");
                    strB.AppendLine("</div>");

                    strB.AppendLine("<div style='padding-top:27px; text-align:center;' >");
                    strB.AppendLine("<span style='FONT-WEIGHT:normal; BACKGROUND-COLOR: #135ebf; PADDING-BOTTOM:7px;PADDING-TOP:7px;PADDING-LEFT:15px;PADDING-RIGHT:15px;border-radius:8px' bgcolor='#d52b1e' height='20' align='center'>");
                    //strB.AppendLine("<button class="button">Button</button>");
                    //strB.AppendLine("<button title='button title' class='action primary tocart' onclick=' window.open('https://web.facebook.com/kekopet/?_rdc=1&_rdr', '_blank'); return false; ' > Google</button>");
                    //strB.AppendLine(" <a style='FONT-SIZE:13px;TEXT-DECORATION:none;FONT-FAMILY:Arial,Helvetica,sans-serif;COLOR:#ffffff;OUTLINE-WIDTH:medium;OUTLINE-STYLE:none;DISPLAY:block;OUTLINE-COLOR:invert' href='https://web.facebook.com/kekopet/?_rdc=1&_rdr' target='_blank' rel='noreferrer'> Visítenos en Facebook </a> ");
                    strB.AppendLine("<a style='FONT-SIZE:14px;TEXT-DECORATION:none;FONT-FAMILY:Arial,Helvetica,sans-serif;COLOR:#ffffff;OUTLINE-WIDTH:medium;' href='https://web.facebook.com/kekopet/?_rdc=1&_rdr' target='_blank' rel='noreferrer' > Visítenos en Facebook </a>");
                    strB.AppendLine("</span>");
                    strB.AppendLine("</div>");

               

                    strB.AppendLine("<br>");
                    strB.AppendLine("<div>");

                    strB.AppendLine("</div>");
                    strB.AppendLine("<br>");
                    strB.AppendLine("<div  style='padding:5px; text-align:center; font-sixe:18px;' >");
                    //strB.AppendLine(objTexto.despedida);
                    strB.AppendLine("Se adjunta el Comprobante de Venta.");
                    strB.AppendLine("<br />");
                    strB.AppendLine("Gracias por su Compra.");
                    strB.AppendLine("</div>");

                    strB.AppendLine("<br>");
                    strB.AppendLine("<br>");
                    strB.AppendLine("<br>");
                    strB.AppendLine("</div>");

                    strB.AppendLine("</div>");
                    strB.AppendLine("</body>");
                    strB.AppendLine("</html>");


                    mm.Body = strB.ToString();


                    mm.Attachments.Add(new Attachment(rutaFile));
                        mm.IsBodyHtml = true;
                        using (SmtpClient smtp = new SmtpClient())
                        {
                            smtp.Host = "smtp.gmail.com";
                            smtp.UseDefaultCredentials = true;
                            smtp.Credentials = new NetworkCredential
                            {
                                UserName = "sispetshopweb@gmail.com",
                                Password = "Admin123*"
                            };
                            smtp.Port = 587;
                            smtp.EnableSsl = true;
                            smtp.Send(mm);
                        }


                    result.type = "info";
                    result.message = "El Comprobante se envió exitosamente al Correo del cliente.";
                }




                ////}




            }
            catch (Exception ex)
            {
                result.type = "errorInt";
                result.message = "Ocurrió un inconveniente al Enviar Correo";
            }

            //if (ventaTodosOkey == true)
            //{
                return Json(result);
            //}
            //else
            //{
            //    return Json(lstRstVta);
            //}

        }









        #region VISTAS/VENTANAS
        // GET: Procesos
        public ActionResult ViewSpeechRecognition()
        {
            return View();
        }

        public ActionResult PruebaEliminable()
        {
            if (Auth.isAuthenticated())
            {

                return View();
            }

            return RedirectToAction("CerrarSesion", "LoginSiscop");
        }


        // GET: Procesos
        public ActionResult ViewVentas()
        {
            if (Auth.isAuthenticated())
            {
                return View();
            }
            return RedirectToAction("CerrarSesion", "LoginSiscop");
        }

        // GET: Procesos
        public ActionResult ViewPuntoDeVenta()
        {
            if (Auth.isAuthenticated())
            {

                return View();
            }
            return RedirectToAction("CerrarSesion", "LoginSiscop");
        }
        //Gestionar Productos: Ingresar, Guardar, Actualizar Stcok
        public ActionResult ViewGestionProductos()
        {
            if (Auth.isAuthenticated())
            {
                return View();
            }
            return RedirectToAction("CerrarSesion", "LoginSiscop");
        }
        public ActionResult ViewGestionMarca()
        {
            if (Auth.isAuthenticated())
            {
                return View();
            }
            return RedirectToAction("CerrarSesion", "LoginSiscop");
        }
        public ActionResult ViewGestionCategoria()
        {
            if (Auth.isAuthenticated())
            {
                return View();
            }
            return RedirectToAction("CerrarSesion", "LoginSiscop");
        }

        public ActionResult ViewGestionCompras()
        {
            if (Auth.isAuthenticated())
            {
                return View();
            }
            return RedirectToAction("CerrarSesion", "LoginSiscop");
        }

        public ActionResult ViewGestionVentas()
        {
            if (Auth.isAuthenticated())
            {
                return View();
            }
            return RedirectToAction("CerrarSesion", "LoginSiscop");
        }
        #endregion VISTAS/VENTANAS

        #region LISTAR CATEGORIA

        /// <summary>
        /// LISTAR CATEGORIA
        /// </summary>
        //Listar Cotroller
        public JsonResult ListarCategoria(int intIdCategoria, string strActivo, string strFiltro)
        {
            string strMsgUsuario = "";
            int intResult = 0;

            List<TB_CATEGORIA> Lista = new List<TB_CATEGORIA>();

            Lista = ListarGestionarCategoriaBL(intIdCategoria, strActivo, strFiltro, ref intResult, ref strMsgUsuario).ToList();

            return Json(Lista);
        }

        //Listar BL
        public List<TB_CATEGORIA> ListarGestionarCategoriaBL( int intIdCategoria, string strActivo, string strFiltro, ref int intResult, ref string strMsjUsuario)
        {
            List<TB_CATEGORIA> lista = new List<TB_CATEGORIA>();
            string strMsjDB = "";

            lista = ListarGestionarCategoriaDAO( intIdCategoria, strActivo, strFiltro, ref intResult, ref strMsjDB, ref strMsjUsuario);
            if (intResult == 0)
            {
                if (!strMsjDB.Equals(""))
                {
                    if (strMsjUsuario.Equals(""))
                        strMsjUsuario = strMsjDB;
                }

            }
 
            return lista;
        }

        //Listar DAO
        public List<TB_CATEGORIA> ListarGestionarCategoriaDAO(int intIdCategoria, string strActivo, string strFiltro, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TB_CATEGORIA> lista = new List<TB_CATEGORIA>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TB_CATEGORIA_LISTAR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("@strActivo", strActivo);
                param.Add("@strFiltro", strFiltro);
                //param.Add("@intIdCategoria", intIdCategoria);
                //param.Add("@intIdMarcaProducto", intIdMarcaProducto);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //LISTADO NORMAL DE "TODOS LOS REGISTROS" NO POR PK
                    TB_CATEGORIA obj = new TB_CATEGORIA();
                    if (!reader.IsDBNull(0)) { obj.intIdCategoria     = reader.GetInt32(0); };
                    if (!reader.IsDBNull(1)) { obj.strCodigoBarraCate = reader.GetString(1); };
                    if (!reader.IsDBNull(2)) { obj.strCodigoCategoria = reader.GetString(2); };
                    if (!reader.IsDBNull(3)) { obj.strDescCategoria   = reader.GetString(3); }; 
                    if (!reader.IsDBNull(4)) { obj.strActivo          = reader.GetString(4); }; 
                    lista.Add(obj); 

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }


        /// <summary>
        /// OBTENER CATEGORIA
        /// </summary>
        public JsonResult ObtenerRegistroCategoria(int intIdCategoria)
        {
            string strMsgUsuario = "";
            int intResult = 0;
            List<TB_CATEGORIA> Lista = new List<TB_CATEGORIA>();

            Lista = ObtenerRegistroCategoriaBL(intIdCategoria, ref intResult, ref strMsgUsuario).ToList();
            return Json(Lista);
        }

        public List<TB_CATEGORIA> ObtenerRegistroCategoriaBL(int intIdCategoria, ref int intResult, ref string strMsjUsuario)
        {
            List<TB_CATEGORIA> lista = new List<TB_CATEGORIA>();
            try
            {
                string strMsjDB = "";

                lista = ObtenerRegistroCategoriaDAO(intIdCategoria, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        //Log.AlmacenarLogMensaje("[ObtenerRegistroEmpresa] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                throw new Exception("Ocurrió un error en BD (ObtenerRegistroEmpresa)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                throw new Exception("Error General (ObtenerRegistroEmpresa)");
            }
            return lista;
        }

        public List<TB_CATEGORIA> ObtenerRegistroCategoriaDAO(int intIdCategoria, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TB_CATEGORIA> lista = new List<TB_CATEGORIA>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TB_CATEGORIA_Q00_GESCATE_PK", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("@intIdCategoria", intIdCategoria);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    TB_CATEGORIA obj = new TB_CATEGORIA();
                    if (!reader.IsDBNull(0)) { obj.intIdCategoria     = reader.GetInt32(0); };
                    if (!reader.IsDBNull(1)) { obj.strCodigoBarraCate = reader.GetString(1); };
                    if (!reader.IsDBNull(2)) { obj.strCodigoCategoria = reader.GetString(2); };
                    if (!reader.IsDBNull(3)) { obj.strDescCategoria   = reader.GetString(3); };
                    if (!reader.IsDBNull(4)) { obj.strActivo          = reader.GetString(4); }; 
                    lista.Add(obj);

                }
                reader.Close();
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        /// <summary>
        /// ELIMINAR CATEGORIA
        /// </summary>
        public JsonResult EliminarCategoria(int intIdCategoria)
        {
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";

            try
            {
                bool delete = false;           
            
                    delete = EliminarCategoriaBL(intIdCategoria, ref strMsgUsuario);
         
                if (strMsgUsuario.Equals("") && delete)
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
            catch (Exception)
            {
                result.type = "error";
                result.message = "Ocurrió un inconveniente al eliminar el registro";
            }

            return Json(result);
        }

        public bool EliminarCategoriaBL(int intIdCategoria, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = EliminarCategoriaDAO(intIdCategoria,  ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminarCategoria] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                throw new Exception("Ocurrió un error en BD (EliminarEmpresa)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                throw new Exception("Error General (EliminarEmpresa)");
            }
        }

        public bool EliminarCategoriaDAO(int intIdCategoria, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TB_CATEGORIA_ELIMINAR", cn); //TSP_TGEMPRESA_D02
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdCategoria", intIdCategoria);
                //Parámetros de Salida                              
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                exito = Transaction(cn, cmd);
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return exito;
        }

        /// <summary>
        /// INSERT UPDATE CATEGORIA
        /// </summary>
        /// 
        /*
        public JsonResult IUCategoria( int intTipoOperacion, TB_CATEGORIA ObjCategoria)
        {
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";

            try
            {
                bool insert = false;

                    insert = IUCategoriaBL(intTipoOperacion, ObjCategoria, ref strMsgUsuario);
            

                if (strMsgUsuario.Equals("") && insert)
                {
                    result.type = "success";
                    result.message = "El registro se insertó satisfactoriamente.";
                }
                else
                {

                    if (strMsgUsuario.Contains("código"))
                    {
                        result.type = "error";
                        result.message = strMsgUsuario;
                    }
                    else
                    {
                        if (strMsgUsuario.Contains("razón"))
                        {
                            result.type = "info";
                            result.message = strMsgUsuario;
                        }
                        else
                        {
                            if (strMsgUsuario.Contains("ruc"))
                            {
                                result.type = "alert";
                                result.message = strMsgUsuario;
                            }
             
                        }
                    }


                }

            }
            catch (Exception)
            {
                result.type = "errorInt";
                result.message = "Ocurrió un inconveniente al registrar la Variable";
            }

            return Json(result);
        }

        public bool IUCategoriaBL(int intTipoOperacion, TB_CATEGORIA objDatos, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                // using (TransactionScope scope = new TransactionScope())
                //{
                int idEmpresa = IUCategoriaDAO( intTipoOperacion, objDatos, ref intResult, ref strMsjDB, ref strMsjUsuario);

                //  scope.Complete();
                // }

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUEmpresa] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "EmpresaBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (InsertarEmpresa)");
            //}
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                throw new Exception("Ocurrió un error en BD (InsertarEmpresa)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                throw new Exception("Error General (InsertarEmpresa)");
            }
        }
        */

        /*
        public int IUCategoriaDAO( int intTipoOperacion, TB_CATEGORIA objDatos, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            int intIdEmpresaOut = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGEMPRESA_IU01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("@strCoEmp", objDatos.strCoEmp);
                param.Add("@strDesEmp", objDatos.strDesEmp);
                param.Add("@strRuc", objDatos.strRuc);

                if (objDatos.strDirFiscal == null)
                {
                    param.Add("@strDirFiscal", DBNull.Value);
                }
                else
                {
                    param.Add("@strDirFiscal", objDatos.strDirFiscal);
                }

                if (objDatos.imgLogo == null)
                {
                    param.Add("@strLogo", DBNull.Value);
                }
                else
                {
                    param.Add("@strLogo", objDatos.imgLogo);
                }

                //  param.Add("@strDirFiscal", objDatos.strDirFiscal);
                //  param.Add("@strLogo", objDatos.imgLogo);
                param.Add("@intTipoEmp", objDatos.intTipoEmp);
                param.Add("@strEmpresaCampo1", objDatos.strEmpresaCampo1);
                param.Add("@strEmpresaCampo2", objDatos.strEmpresaCampo2);
                param.Add("@strEmpresaCampo3", objDatos.strEmpresaCampo3);
                param.Add("@strEmpresaCampo4", objDatos.strEmpresaCampo4);
                param.Add("@strEmpresaCampo5", objDatos.strEmpresaCampo5);

                param.Add("@bitFlActivo", objDatos.bitFlActivo);
                param.Add("@intIdUsuario", objSession.intIdUsuario);
                param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update
                //Parámetros de Salida
                param.Add("@IntIdEmp", objDatos.IntIdEmp);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();
                intIdEmpresaOut = Convert.ToInt32(cmd.Parameters["@IntIdEmp"].Value.ToString());
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return intIdEmpresaOut;
        }

        */




        /////////// <summary>
        /////////// INSERTAR
        /////////// </summary>
        //////////Insertar
        ////////public JsonResult InsertarCategoria(int intIdCategoria)
        ////////{
        ////////    string strMsgUsuario = "";
        ////////    int intResult = 0;

        ////////    List<TB_CATEGORIA> Lista = new List<TB_CATEGORIA>();

        ////////    Lista = InsertarGestionarCategoriaBL(intIdCategoria, ref intResult, ref strMsgUsuario).ToList();

        ////////    return Json(Lista);
        ////////}

        //////////Insertar BL
        ////////public List<TB_CATEGORIA> InsertarGestionarCategoriaBL(int intIdCategoria, ref int intResult, ref string strMsjUsuario)
        ////////{
        ////////    List<TB_CATEGORIA> lista = new List<TB_CATEGORIA>();
        ////////    string strMsjDB = "";

        ////////    lista = InsertarGestionarCategoriaDAO(intIdCategoria, ref intResult, ref strMsjDB, ref strMsjUsuario);
        ////////    if (intResult == 0)
        ////////    {
        ////////        if (!strMsjDB.Equals(""))
        ////////        {
        ////////            if (strMsjUsuario.Equals(""))
        ////////                strMsjUsuario = strMsjDB;
        ////////        }

        ////////    }
        ////////    return lista;
        ////////}

        //////////Insertar DAO
        ////////public List<TB_CATEGORIA> InsertarGestionarCategoriaDAO(int intIdCategoria, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        ////////{
        ////////    List<TB_CATEGORIA> lista = new List<TB_CATEGORIA>();

        ////////    using (SqlConnection cn = new SqlConnection(cadCnx))
        ////////    {
        ////////        SqlCommand cmd = new SqlCommand("TSP_TB_CATEGORIA_LISTAR", cn);
        ////////        cmd.CommandType = CommandType.StoredProcedure;
        ////////        cn.Open();
        ////////        Dictionary<string, object> param = new Dictionary<string, object>();
        ////////        param.Add("@intResult", 0);
        ////////        param.Add("@strMsjDB", "");
        ////////        param.Add("@strMsjUsuario", "");
        ////////        AsignarParametros(cmd, param);

        ////////        SqlDataReader reader = cmd.ExecuteReader();
        ////////        while (reader.Read())
        ////////        {
        ////////            TB_CATEGORIA obj = new TB_CATEGORIA();
        ////////            if (!reader.IsDBNull(0)) { obj.intIdCategoria = reader.GetInt32(0); };
        ////////            if (!reader.IsDBNull(1)) { obj.strCodigoBarraCate = reader.GetString(1); };
        ////////            if (!reader.IsDBNull(2)) { obj.strCodigoCategoria = reader.GetString(2); };
        ////////            if (!reader.IsDBNull(3)) { obj.strDescCategoria = reader.GetString(3); };
        ////////            if (!reader.IsDBNull(4)) { obj.strActivo = reader.GetString(4); };
        ////////            lista.Add(obj);

        ////////        }
        ////////        reader.Close();

        ////////        intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
        ////////        strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
        ////////        strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

        ////////    }
        ////////    return lista;
        ////////}



        ////public JsonResult ObtenerRegistroEmpresa(Session_Movi objSession, int IntIdEmpre)
        ////{
        ////    string strMsgUsuario = "";
        ////    List<TG_EMPPRESA> detConcepto = new List<TG_EMPPRESA>();
        ////    using (proxy = new PersonalSrvClient())
        ////    {
        ////        detConcepto = proxy.ObtenerRegistroEmpresa(objSession, IntIdEmpre, ref strMsgUsuario).ToList();
        ////    }
        ////    return Json(detConcepto);
        ////}




        #endregion LISTAR CATEGORIA

        #region MARCA

        /// <summary>
        /// LISTAR MARCA
        /// </summary>
        //Listar Cotroller
        public JsonResult ListarMarca(int intIdMarca, string strActivo, string strFiltro)
        {
            string strMsgUsuario = "";
            int intResult = 0;

            List<TB_MARCA> Lista = new List<TB_MARCA>();

            Lista = ListarGestionarMarcaBL(intIdMarca, strActivo, strFiltro, ref intResult, ref strMsgUsuario).ToList();

            return Json(Lista);
        }

        //Listar BL
        public List<TB_MARCA> ListarGestionarMarcaBL(int intIdMarca, string strActivo, string strFiltro, ref int intResult, ref string strMsjUsuario)
        {
            List<TB_MARCA> lista = new List<TB_MARCA>();
            string strMsjDB = "";

            lista = ListarGestionarMarcaDAO(intIdMarca, strActivo, strFiltro, ref intResult, ref strMsjDB, ref strMsjUsuario);
            if (intResult == 0)
            {
                if (!strMsjDB.Equals(""))
                {
                    if (strMsjUsuario.Equals(""))
                        strMsjUsuario = strMsjDB;
                }

            }

            return lista;
        }

        //Listar DAO
        public List<TB_MARCA> ListarGestionarMarcaDAO(int intIdMarca, string strActivo, string strFiltro, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TB_MARCA> lista = new List<TB_MARCA>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TB_MARCA_GESMAR_Q00_LISTAR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("@strActivo", 0);
                param.Add("@strFiltro", strFiltro);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //LISTADO NORMAL DE "TODOS LOS REGISTROS" NO POR PK
                    TB_MARCA obj = new TB_MARCA();
                    if (!reader.IsDBNull(0)) { obj.intIdMarca        = reader.GetInt32(0); };
                    if (!reader.IsDBNull(1)) { obj.strCodigoMarca    = reader.GetString(1); };
                    if (!reader.IsDBNull(2)) { obj.strDescMarca      = reader.GetString(2); };
                    if (!reader.IsDBNull(3)) { obj.strRutaImgMarca   = reader.GetString(3); };
                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }


        /// <summary>
        /// NUEVA MARCA
        /// </summary>
        public JsonResult InsertUpdateMarcaGesMar(TB_MARCA ObjMarca, int intTipoOperacion)
        {
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";

            try
            {
                bool insert = false;

                insert = InsertMarcaBL(intTipoOperacion, ObjMarca, ref strMsgUsuario);


                if (strMsgUsuario.Equals("") && insert && intTipoOperacion == 1)
                {
                    result.type = "success";
                    result.message = "El registro se insertó satisfactoriamente.";
                }
                else if (strMsgUsuario.Equals("") && insert && intTipoOperacion == 2)
                {
                    result.type = "success";
                    result.message = "El registro se actualizó satisfactoriamente.";
                }
                else
                {

                    if (strMsgUsuario.Contains("código"))
                    {
                        result.type = "error";
                        result.message = strMsgUsuario;
                    }
                    else
                    {
                        if (strMsgUsuario.Contains("razón"))
                        {
                            result.type = "info";
                            result.message = strMsgUsuario;
                        }
                        else
                        {
                            if (strMsgUsuario.Contains("ruc"))
                            {
                                result.type = "alert";
                                result.message = strMsgUsuario;
                            }
                            //else if (strMsgUsuario.Contains("razón"))
                            //{
                            //    result.type = "info";
                            //    result.message = strMsgUsuario;
                            //}
                        }
                    }


                }


            }
            catch (Exception)
            {
                result.type = "errorInt";
                result.message = "Ocurrió un inconveniente al registrar";
            }

            return Json(result);
        }

        //BL
        public bool InsertMarcaBL(int intTipoOperacion, TB_MARCA objDatos, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";
                // using (TransactionScope scope = new TransactionScope())
                //{
                int idEmpresa = InsertMarcaDAO(intTipoOperacion, objDatos, ref intResult, ref strMsjDB, ref strMsjUsuario);
                //  scope.Complete();
                // }
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        //Log.AlmacenarLogMensaje("[IUEmpresa] => Respuesta del Procedimiento : " + strMsjDB);
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
                Console.WriteLine(ex.ToString(), "ProcesoController.cs");
                //Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                throw new Exception("Ocurrió un error en BD (InsertarEmpresa)");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "ProcesoController.cs");
                //Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                throw new Exception("Error General (InsertarEmpresa)");
            }
        }

        //DAO
        public int InsertMarcaDAO(int intTipoOperacion, TB_MARCA objDatos, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {


            //intIdMarca
            //strCodigoMarca
            //strMarcaProducto
            //strRutaImagenMarca
            //bitFlEliminado

            //int intIdEmpresaOut = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TB_MARCA_GESMAR_IU00", cn); //TSP_TGEMPRESA_IU01
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();

                //1
                param.Add("@intIdMarca", objDatos.intIdMarca);
                //2
                if (objDatos.strCodigoMarca == null) { param.Add("@strCodigoMarca ", DBNull.Value); }
                else { param.Add("@strCodigoMarca", objDatos.strCodigoMarca); }       
                //3
                if (objDatos.strDescMarca == null) { param.Add("@strDescMarca", DBNull.Value); }
                else { param.Add("@strDescMarca", objDatos.strDescMarca); }
                //4
                if (objDatos.strRutaImgMarca == null) { param.Add("@strRutaImgMarca", DBNull.Value); }
                else { param.Add("@strRutaImgMarca", objDatos.strRutaImgMarca); }
                //5
                param.Add("@bitFlEliminado", objDatos.bitFlEliminado);

                param.Add("@intTipoOperacion", intTipoOperacion); //1: insert, 2: update


                //param.Add("@decPrecioDeVenta", objDatos.decPrecioDeVenta);
                //param.Add("@intCantTotalActual", objDatos.intCantTotalActual);
                //param.Add("@decMontoProducto", objDatos.decMontoProducto);

                //if (objDatos.strMarcaProducto == null) { param.Add("@strMarcaProducto", DBNull.Value); }
                //else { param.Add("@strMarcaProducto", objDatos.strMarcaProducto); }

                //if (objDatos.strRutaImagenMarca == null) { param.Add("@strRutaImagenMarca", DBNull.Value); }
                //else { param.Add("@strRutaImagenMarca", objDatos.strRutaImagenMarca); }

                //if (objDatos.strRutaImagenProducto == null) { param.Add("@strRutaImagenProducto", DBNull.Value); }
                //else { param.Add("@strRutaImagenProducto", objDatos.strRutaImagenProducto); }


                //param.Add("@intIdCategoria", objDatos.intIdCategoria);

                //if (objDatos.strDescCategoria == null) { param.Add("@strDescCategoria", DBNull.Value); }
                //else { param.Add("@strDescCategoria", objDatos.strDescCategoria); }

                //if (objDatos.strPresentacion == null) { param.Add("@strPresentacion", DBNull.Value); }
                //else { param.Add("@strPresentacion", objDatos.strPresentacion); }

                //if (objDatos.strInfoAdicionalProd == null) { param.Add("@strInfoAdicionalProd", DBNull.Value); }
                //else { param.Add("@strInfoAdicionalProd", objDatos.strInfoAdicionalProd); }

                //if (objDatos.decPorcentajeDescto == null) { param.Add("@decPorcentajeDescto", DBNull.Value); }
                //else { param.Add("@decPorcentajeDescto", objDatos.decPorcentajeDescto); }

                //if (objDatos.decMontoProducto == null) { param.Add("@decMontoProducto", DBNull.Value); }
                //else { param.Add("@decMontoProducto", objDatos.decMontoProducto); }
                

                //-------------------------------------------------------------------------
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return intResult;
        }



        /// <summary>
        /// OBTENER MARCA
        /// </summary>
        public JsonResult ObtenerRegistroMarcaPorPk(int intIdMarca)
        {
            string strMsgUsuario = "";
            int intResult = 0;
            List<TB_MARCA> Lista = new List<TB_MARCA>();

            Lista = ObtenerRegistroMarcaBL(intIdMarca, ref intResult, ref strMsgUsuario).ToList();
            return Json(Lista);
        }

        public List<TB_MARCA> ObtenerRegistroMarcaBL(int intIdMarca, ref int intResult, ref string strMsjUsuario)
        {
            List<TB_MARCA> lista = new List<TB_MARCA>();
            try
            {
                string strMsjDB = "";

                lista = ObtenerRegistroMarcaDAO(intIdMarca, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        //Log.AlmacenarLogMensaje("[ObtenerRegistroEmpresa] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                throw new Exception("Ocurrió un error en BD (ObtenerRegistroEmpresa)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                throw new Exception("Error General (ObtenerRegistroEmpresa)");
            }
            return lista;
        }

        public List<TB_MARCA> ObtenerRegistroMarcaDAO(int intIdMarca, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TB_MARCA> lista = new List<TB_MARCA>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TB_MARCA_GESMAR_Q00_PK", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("@intIdMarca", intIdMarca);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    TB_MARCA obj = new TB_MARCA();
                    if (!reader.IsDBNull(0)) { obj.intIdMarca         = reader.GetInt32(0); };
                    if (!reader.IsDBNull(1)) { obj.strCodigoMarca     = reader.GetString(1); };
                    if (!reader.IsDBNull(2)) { obj.strDescMarca       = reader.GetString(2); };
                    if (!reader.IsDBNull(3)) { obj.strRutaImgMarca    = reader.GetString(3); };
                    //if (!reader.IsDBNull(3)) { obj.strDescCategoria   = reader.GetString(3); };
                    //if (!reader.IsDBNull(4)) { obj.strActivo          = reader.GetString(4); };
                    lista.Add(obj);

                }
                reader.Close();
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }


        /// <summary>
        /// ELIMINAR MARCA
        /// </summary>
        public JsonResult EliminarMarcaGesMar(int intIdMarca)
        {
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";

            try
            {
                bool delete = false;

                delete = EliminarMarcaBL(intIdMarca, ref strMsgUsuario);

                if (strMsgUsuario.Equals("") && delete)
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
            catch (Exception)
            {
                result.type = "error";
                result.message = "Ocurrió un inconveniente al eliminar el registro";
            }

            return Json(result);
        }

        public bool EliminarMarcaBL(int intIdMarca, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = EliminarMarcaDAO(intIdMarca, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminarCategoria] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                throw new Exception("Ocurrió un error en BD (EliminarEmpresa)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                throw new Exception("Error General (EliminarEmpresa)");
            }
        }

        public bool EliminarMarcaDAO(int intIdMarca, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("[TSP_TB_MARCA_GESMAR_D00_ELIMINAR]", cn); //TSP_TGEMPRESA_D02
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdMarca", intIdMarca);
                //Parámetros de Salida                              
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                exito = Transaction(cn, cmd);
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return exito;
        }



        #endregion MARCA

        #region INSERT/UPDATE VENTAS "PUNTO DE VENTA" 

        //CONTROLLOER
        public JsonResult InsertUpdateFromPuntoVenta(int intTipoOperacion, string strOperacion, int intIdVentaCabe, TB_VENTA_CABE objVentaCabe, List<TB_PRODUCTOS_VENTA> lstDetalleProducto, List<ResultProcesarVenta> lstRstVta)
        {
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";
            bool ventaTodosOkey = true;

            try
            {

                Dominio.Entidades.Session_Movi objSession = new Dominio.Entidades.Session_Movi();
                objSession.intIdSesion = Auth.intIdSesion();
                objSession.intIdSoft = Auth.intIdSoft();
                //objSession.intIdMenu = intIdMenuGlo;
                objSession.intIdUsuario = Auth.intIdUsuario();



                bool insert = false;
                insert = InsertUpdateFromPuntoVentaBL(intTipoOperacion, strOperacion, objSession, objVentaCabe, lstDetalleProducto, ref lstRstVta, ref intIdVentaCabe,  ref strMsgUsuario);//.ToArray()

                if ( lstRstVta != null)
                {
                    foreach (var item in lstRstVta)
                    {
                        if (item.intRstVendido == 2)
                        {
                            ventaTodosOkey = false;
                        }

                    }
                }
             

                if (strMsgUsuario.Equals("") && insert && ventaTodosOkey == true)
                {
                    result.type = "success";
                    result.message = "La Venta se ha procesado satisfactoriamente.";
                    result.intIdentifier = intIdVentaCabe;
                }
                else
                {

                    if (ventaTodosOkey == false )
                    {
                        result.type = "error";
                        result.message = "Uno de los productos no se ha procesado satisfactoriamente.";
                        result.intIdentifier = intIdVentaCabe;
                    }

                    /*
                    if (strMsgUsuario.Contains("código"))
                    {
                        result.type = "error";
                        result.message = strMsgUsuario;
                    }
                    else
                    {
                        if (strMsgUsuario.Contains("descripción"))
                        {
                            result.type = "externo";
                            result.message = strMsgUsuario;
                        }
                        else
                        {

                        }
                    }
                    */


                }

            }
            catch (Exception ex)
            {
                result.type = "errorInt";
                result.message = "Ocurrió un inconveniente al registrar";
            }

            if (ventaTodosOkey == true)
            {
                return Json(result);
            }
            else
            {
                return Json(lstRstVta);
            }

        }

        //BL
        public bool InsertUpdateFromPuntoVentaBL(int intTipoOperacion, string strOperacion, Dominio.Entidades.Session_Movi objSession, TB_VENTA_CABE objVentaCabe , List<TB_PRODUCTOS_VENTA> listaDetalleProducto, ref List<ResultProcesarVenta> lstRstVta, ref int intIdVentaCabe, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";
                bool boolVenta = false;
                //int intIdVentaCabe = 0;

                if (intTipoOperacion == 1)
                {
                    /////////////////////////////////////////////////////////////////////////
                    ///// SE INSERTA A LA TABLA TB_VENTAS_CABE solo para generar el ID
                    /////////////////////////////////////////////////////////////////////////
                    //intIdVentaCabe = 0;
                    //TB_VENTA_CABE objVentaCabe = new TB_VENTA_CABE();
                    //objVentaCabe.intIdVentaCabe = intIdVentaCabe;
                    //objVentaCabe.strCodVenta = "";

                    //strOperacion = "GENERAR_IDCABE";
                    boolVenta = InsertUpdateCabeceraVenta(objSession, objVentaCabe, intTipoOperacion, strOperacion, ref intIdVentaCabe, ref intResult, ref strMsjDB, ref strMsjUsuario);


                    if (boolVenta == true)
                    {

                        DataTable tb = SerealizeDetalleProducto(listaDetalleProducto, intIdVentaCabe);
                        tudobem = UpdateDetalleProducto(tb, ref lstRstVta, ref intResult, ref strMsjDB, ref strMsjUsuario);

                        strOperacion = "UPDATE_MONTO";

                    }

                }

                if (intTipoOperacion == 2)
                {
                    /////////////////////////////////////////////////////////////////////////
                    ///// SE ACT
                    /////////////////////////////////////////////////////////////////////////
                    intIdVentaCabe = objVentaCabe.intIdVentaCabe ;
                    boolVenta = InsertUpdateCabeceraVenta(objSession, objVentaCabe, intTipoOperacion, strOperacion, ref intIdVentaCabe, ref intResult, ref strMsjDB, ref strMsjUsuario);

              
                }



                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                else
                {
                    tudobem = true;

                    //ACTUALIZAR EL MONTO TOTAL EN LA TABLA TB_VENTAS_CABE
                    //,@strOperacion varchar(50)         --0: Sin Accion, 1: Venta Procesada, 2: Venta No Procesada
                    //TB_VENTA_CABE objVentaCabe = new TB_VENTA_CABE();

                    if (strOperacion == "UPDATE_MONTO")
                    {
                        TB_VENTA_CABE objVentaCabeAux = new TB_VENTA_CABE();
                        objVentaCabeAux.intIdVentaCabe = intIdVentaCabe;
                        objVentaCabeAux.strCodVenta = " ";
                        boolVenta = InsertUpdateCabeceraVenta(objSession, objVentaCabeAux, 2, strOperacion, ref intIdVentaCabe, ref intResult, ref strMsjDB, ref strMsjUsuario);

                    }


                }

                return tudobem;



            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                throw new Exception("Ocurrió un error en BD (InsertarPerfil)");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("Error General (InsertarPerfil)");
            }
        }

        //CONVERTIR EN DATATABLE
        private DataTable SerealizeDetalleProducto(List<TB_PRODUCTOS_VENTA> listaDetalleProducto, int intIdVentaCabe)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdProducto", typeof(int));
            table.Columns.Add("strCodigoBarras", typeof(string));
            table.Columns.Add("strDescProducto", typeof(string));
            table.Columns.Add("decPrecioDeVenta", typeof(string));
            table.Columns.Add("intCantidadVenta", typeof(int));
            table.Columns.Add("decMontoVentaProd", typeof(string));
            table.Columns.Add("intIdVentaCabe", typeof(int));

            foreach (var item in listaDetalleProducto)
            {
                DataRow rows = table.NewRow();
                rows["intIdProducto"]     = item.intIdProducto;
                rows["strCodigoBarras"]   = item.strCodigoBarras;
                rows["strDescProducto"]   = item.strDescProducto;
                rows["decPrecioDeVenta"]  = item.decPrecioDeVenta;
                rows["intCantidadVenta"]  = item.intCantidadVenta;
                rows["decMontoVentaProd"] = item.decMontoVentaProd;
                rows["intIdVentaCabe"]    = intIdVentaCabe;

                table.Rows.Add(rows);
            }

            return table;
        }

        //DAO  SE ACUALIZARA UNO POR UNO DESDE EL LISTADO TRAIDO DESDE EL JS
        public bool UpdateDetalleProducto( DataTable tbProducto, ref List<ResultProcesarVenta> lstRstVta, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            bool Rpta = false;
            int intSoldProduct = 0;
            List<ResultProcesarVenta> lstRstVta1 = new List<ResultProcesarVenta>();

            try
            {

                using (SqlConnection cn = new SqlConnection(cadCnx))
                {

                    cn.Open();
                    using (SqlTransaction trans = cn.BeginTransaction())
                    {
                        try
                        {
                            /******************************                            
                                 9.1.1.- 
                            ******************************/

                            ////9.1.1 -
                            //if (nombreExcel.Contains("TBAREAS"))
                            //{                  

                            for (int i = 0; i < tbProducto.Rows.Count; i++)
                            {
                                string intIdProducto_  = tbProducto.Rows[i][0].ToString();
                                string intCantidVend_  = tbProducto.Rows[i][4].ToString();
                                string decMontoVenta_  = tbProducto.Rows[i][5].ToString();
                                string intIdVentaCabe_ = tbProducto.Rows[i][6].ToString();
                                //intIdVentaCabe_i = tbProducto.Rows[i][6];

                                using (SqlCommand cmd = new SqlCommand("TSP_PNTVNT_TB_VENTAS_IU00_PROCESAR", cn))
                                {
                                    cmd.Transaction = trans;
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    Dictionary<string, object> param = new Dictionary<string, object>();

                                    ////////param.Add("@nombreDocExcel", nombreExcel);
                                    //------------------------------------------------CAMPOS DE CADA TABLA INI
                                    param.Add("@intIdProducto", Convert.ToInt32(intIdProducto_));
                                    param.Add("@intCantidadVentaWeb", intCantidVend_);//int.Parse(intCantidVend_)
                                    decimal decMontoVents = decimal.Parse(decMontoVenta_);
                                    param.Add("@decMontoVentaWeb", decMontoVents);
                                    param.Add("@intIdVentaCabe", intIdVentaCabe_);
                                    //------------------------------------------------CAMPOS DE CADA TABLA FIN
                                    param.Add("@intSoldProduct", 0);
                                    //param.Add("@strConInconsistencia", "");
                                    param.Add("@intResult", 0);
                                    param.Add("@strMsjDB", "");
                                    param.Add("@strMsjUsuario", "");
                                    AsignarParametros(cmd, param);
                                    cmd.ExecuteNonQuery();

                                    intSoldProduct = Convert.ToInt32(cmd.Parameters["@intSoldProduct"].Value.ToString());
                                    ////strConInconsistencia = cmd.Parameters["@strConInconsistencia"].Value.ToString();
                                    intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                                    strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                                    strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

                                }

                             
                               

                                ResultProcesarVenta ObjVenta = new ResultProcesarVenta();
                                //if (intSoldProduct == 1) //--0: Sin Accion, 1: Venta Procesada, 2: Venta No Procesada
                                //{
                                    //regInsertados = ++regInsertados;
                                    //ref List<string> arrListInconsistentes
                                    // Create a List of objects  
                                    // Add more items to the list  
                                    //lstRstVta.Add(new ResultProcesarVenta { intIdProducto = 7 , intRstVendido = intSoldProduct });

                                    ObjVenta.intIdProducto = Convert.ToInt32(intIdProducto_);
                                    ObjVenta.intRstVendido = intSoldProduct;                                    
                                    ObjVenta.intIdVentaCabe = Convert.ToInt32(intIdVentaCabe_);                                    
                                    lstRstVta1.Add(ObjVenta);

                                    lstRstVta = lstRstVta1;
                                //}


                            }
                            //}



                            Rpta = true;
                        }
                        catch (Exception ex)
                        {
                            //Exepcion: Message = "El recuento de transacciones después de EXECUTE indica un número no coincidente de instrucciones BEGIN y COMMIT. Recuento anterior = 1, recuento actual = 0."---> Cuando las tablas TBLOCAL y TBTIPO aun no estan cargadas en la BD
                            Rpta = false;
                            trans.Rollback();
                            throw ex;
                        }
                        trans.Commit();
                    }
                    cn.Close();
                }
            }
            catch (System.Exception ex)
            {
                Rpta = false;
                strMsjDB = "No se pudo completar la insercion de las respuestas: " + ex.Message;
            }
            return Rpta;

            //////////bool tudobem = false;

            //////////using (SqlConnection cn = new SqlConnection(cadCnx))
            //////////{
            //////////    SqlCommand cmd = new SqlCommand("", cn);//TSP_TSPERFIL_MENU_IU02
            //////////    cmd.CommandType = CommandType.StoredProcedure;
            //////////    cn.Open();

            //////////    Dictionary<string, object> param = new Dictionary<string, object>();
            //////////    param.Add("@tt_TB_PRODUCTOS", TB_PRODUCTOS);
            //////////    //Parámetros de Salida
            //////////    param.Add("@intResult", 0);
            //////////    param.Add("@strMsjDB", "");
            //////////    param.Add("@strMsjUsuario", "");

            //////////    AsignarParametros(cmd, param);
            //////////    int result = cmd.ExecuteNonQuery();

            //////////    intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
            //////////    strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
            //////////    strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            //////////    tudobem = true;
            //////////}

            //////////return tudobem;
        }


        //DAO  PARA INSERTAR VENTA CABECERA
        public bool InsertUpdateCabeceraVenta(Dominio.Entidades.Session_Movi objSession, TB_VENTA_CABE objVentaCabe, int intTipoOperacion, string strOperacion, ref int intIdVentaCabe, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            bool Rpta = false;
            //List<ResultProcesarVenta> lstRstVta1 = new List<ResultProcesarVenta>();

            try
            {

                using (SqlConnection cn = new SqlConnection(cadCnx))
                {

                    cn.Open();
                    using (SqlTransaction trans = cn.BeginTransaction())
                    {
                        try
                        {

                            using (SqlCommand cmd = new SqlCommand("[TSP_PNTVNT_TB_VENTA_CABE_IU00]", cn))
                            {
                                cmd.Transaction = trans;
                                cmd.CommandType = CommandType.StoredProcedure;
                                Dictionary<string, object> param = new Dictionary<string, object>();                               
                                
                                param.Add("@intIdUsuario", objSession.intIdUsuario );
                                param.Add("@intIdVentaCabe", objVentaCabe.intIdVentaCabe  /*intIdVentaCabe*/ );
                                param.Add("@strCodVenta", objVentaCabe.strCodVenta /*strCodVenta*/);


                                if (objVentaCabe.strRucCliente == null) { param.Add("@strRucCliente", DBNull.Value); }
                                else { param.Add("@strRucCliente", objVentaCabe.strRucCliente); }

                                if (objVentaCabe.strNomCliente == null) { param.Add("@strNomCliente", DBNull.Value); }
                                else { param.Add("@strNomCliente", objVentaCabe.strNomCliente); }

                                if (objVentaCabe.strApeCliente == null) { param.Add("@strApeCliente", DBNull.Value); }
                                else { param.Add("@strApeCliente", objVentaCabe.strApeCliente); }

                                if (objVentaCabe.strDirCliente == null) { param.Add("@strDirCliente", DBNull.Value); }
                                else { param.Add("@strDirCliente", objVentaCabe.strDirCliente); }

                                if (objVentaCabe.strTelCliente == null) { param.Add("@strTelCliente", DBNull.Value); }
                                else { param.Add("@strTelCliente", objVentaCabe.strTelCliente); }

                                if (objVentaCabe.strMedioDePago == null) { param.Add("@strMedioDePago", DBNull.Value); }
                                else { param.Add("@strMedioDePago", objVentaCabe.strMedioDePago); }





                                //strRucCliente
                                //strNomCliente
                                //strApeCliente
                                //strDirCliente
                                //strTelCliente
                                //strMedioDePago




                                ////////param.Add("@nombreDocExcel", nombreExcel);
                                //------------------------------------------------CAMPOS DE CADA TABLA INI
                                //param.Add("@intIdVentaCabe", Convert.ToInt32(intIdProducto_));
                                //param.Add("@intCantidadVentaWeb", intCantidVend_);//int.Parse(intCantidVend_)
                                //decimal decMontoVents = decimal.Parse(decMontoVenta_);
                                //param.Add("@decMontoVentaWeb", decMontoVents);
                                //------------------------------------------------CAMPOS DE CADA TABLA FIN
                                param.Add("@intTipoOperacion", intTipoOperacion );
                                param.Add("@strOperacion", strOperacion);

                                param.Add("@intResult", 0);
                                param.Add("@strMsjDB", "");
                                param.Add("@strMsjUsuario", "");
                                AsignarParametros(cmd, param);
                                cmd.ExecuteNonQuery();
                                intIdVentaCabe = Convert.ToInt32(cmd.Parameters["@intIdVentaCabe"].Value.ToString());
                                ////strConInconsistencia = cmd.Parameters["@strConInconsistencia"].Value.ToString();
                                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

                            }


                            Rpta = true;
                        }
                        catch (Exception ex)
                        {                           
                            Rpta = false;
                            trans.Rollback();
                            throw ex;
                        }
                        trans.Commit();
                    }
                    cn.Close();
                }
            }
            catch (System.Exception ex)
            {
                Rpta = false;
                strMsjDB = "No se pudo completar la insercion de las respuestas: " + ex.Message;
            }
            return Rpta;


        }




        //////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////


        //5.57
        public int RegistrarDocumentos(string pathTotal, DataTable tb, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            int id = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_CONCEPTO_DET_I02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("@pathTotal", pathTotal);
                param.Add("@TT_PAPELETAS", tb);

                //Parámetros de Salida

                param.Add("@intResult", 1);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                id = (int)cmd.ExecuteNonQuery();

                // intIdEmpresaOut = Convert.ToInt32(cmd.Parameters["@intIdPerHor"].Value.ToString());
                //outputs
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return id;

        }
        //5.57
        public int RegistrarDocumentos(string pathTotal, List<int> listPapeletas, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            try
            {
                int intId = 0;

                DataTable tb = SerealizeDetallePapeleta(listPapeletas);
                intId = RegistrarDocumentos(pathTotal, tb, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        //Log.AlmacenarLogMensaje("[RegistrarDocumentos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }

                return intId;
            }
            catch (SqlException ex)
            {
                //Log.AlmacenarLogError(ex, "HGM270421.cs: SqlException");
                Console.WriteLine(ex);
                throw new Exception("Ocurrió un error en BD (RegistrarDocumentos)");
            }
            catch (Exception ex)
            {
                //Log.AlmacenarLogError(ex, "HGM270421.cs: Exception");
                Console.WriteLine(ex);
                throw new Exception("Error General (RegistrarDocumentos)");
            }
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

        /*================================================================================= 
         * 9.1 IMPORTAR EXCEL - Los 08 excels en un solo Método
         * =================================================================================*/
        public int ImportExcelMasivoEntidad(DataTable tb, string nombreExcel, int insertadoActualizado
                                            //int idProceso, int cboPlantilla, int cboFormato, bool checkActualizar,
                                            //string rutaDirectorioExcel, 
                                            , ref int intResult, ref string strMsjDB,
                                            ref string strMsjUsuario, ref int regInsertados, ref int regActualizados,
                                            ref int regInconsistentes,
                                            ref string strConInconsistencia
                                           //ref List<string> arrListInconsistentes
                                           )
        {
            int Rpta = 0;

            try
            {

                using (SqlConnection cn = new SqlConnection(cadCnx))
                {

                    cn.Open();
                    using (SqlTransaction trans = cn.BeginTransaction())
                    {
                        try
                        {
                            /******************************                            
                                 9.1.1.-TBAREAS  
                            ******************************/

                            ////9.1.1 - TBAREAS
                            //if (nombreExcel.Contains("TBAREAS"))
                            //{
                            for (int i = 0; i < tb.Rows.Count; i++)
                            {
                                string strCodLocal = tb.Rows[i][0].ToString();
                                string strCodArea = tb.Rows[i][1].ToString();
                                string strDescArea = tb.Rows[i][2].ToString();

                                using (SqlCommand cmd = new SqlCommand("TSP_TBAREAS_EXCEL_IA", cn))
                                {
                                    cmd.Transaction = trans;
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    Dictionary<string, object> param = new Dictionary<string, object>();

                                    param.Add("@nombreDocExcel", nombreExcel);
                                    //------------------------------------------------CAMPOS DE CADA TABLA INI
                                    param.Add("@strCodLocal", strCodLocal);
                                    param.Add("@strCodArea", strCodArea);
                                    param.Add("@strDescArea", strDescArea);
                                    //------------------------------------------------CAMPOS DE CADA TABLA FIN
                                    param.Add("@insertadoActualizado", 0);
                                    param.Add("@strConInconsistencia", "");
                                    param.Add("@intResult", 0);
                                    param.Add("@strMsjDB", "");
                                    param.Add("@strMsjUsuario", "");
                                    AsignarParametros(cmd, param);
                                    cmd.ExecuteNonQuery();

                                    insertadoActualizado = Convert.ToInt32(cmd.Parameters["@insertadoActualizado"].Value.ToString());
                                    strConInconsistencia = cmd.Parameters["@strConInconsistencia"].Value.ToString();
                                    intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                                    strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                                    strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

                                }

                                if (insertadoActualizado == 1)
                                {
                                    regInsertados = ++regInsertados;
                                }
                                if (insertadoActualizado == 2)
                                {
                                    regActualizados = ++regActualizados;
                                }
                                if (insertadoActualizado == 3)
                                {
                                    regInconsistentes = ++regInconsistentes;
                                    //MensajesRegistrosNoImportados("[" + regInconsistentes + "] " + nombreExcel + " ---> " + strConInconsistencia, idProceso, rutaDirectorioExcel);//Prueba
                                }

                                //{
                                //    regInconsistentes = ++regInconsistentes;
                                //    MensajesRegistrosNoImportados("[" + regInconsistentes + "] " + nombreExcel + " ---> " + strConInconsistencia, idProceso, rutaDirectorioExcel);
                                //    //ResultImportExcel List = new ResultImportExcel();
                                //    arrListInconsistentes.Add(strConInconsistencia);
                                //}


                            }
                            //}



                            Rpta = 1;
                        }
                        catch (Exception ex)
                        {
                            //Exepcion: Message = "El recuento de transacciones después de EXECUTE indica un número no coincidente de instrucciones BEGIN y COMMIT. Recuento anterior = 1, recuento actual = 0."---> Cuando las tablas TBLOCAL y TBTIPO aun no estan cargadas en la BD
                            Rpta = 0;
                            trans.Rollback();
                            throw ex;
                        }
                        trans.Commit();
                    }
                    cn.Close();
                }
            }
            catch (System.Exception ex)
            {
                Rpta = 0;
                strMsjDB = "No se pudo completar la insercion de las respuestas: " + ex.Message;
            }
            return Rpta;
        }





        //CONTROLLER
        public JsonResult IUProductoController(int intTipoOperacion, TB_PRODUCTOS ObjProducto)
        {
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";

            try
            {
                bool insert = false;

                //using (proxy = new PersonalSrvClient())
                //{
                insert = IUProductoBL(intTipoOperacion, ObjProducto, ref strMsgUsuario);
                //    proxy.Close();
                //}
                /**
                if (strMsgUsuario.Equals("") && insert)
                {
                    result.type = "success";
                    result.message = "El registro se insertó satisfactoriamente.";
                }
                else
                {
                    if (strMsgUsuario.Contains("código"))
                    {
                        result.type = "error";
                        result.message = strMsgUsuario;
                    }
                    else
                    {
                        if (strMsgUsuario.Contains("razón"))
                        {
                            result.type = "info";
                            result.message = strMsgUsuario;
                        }
                        else
                        {
                            if (strMsgUsuario.Contains("ruc"))
                            {
                                result.type = "alert";
                                result.message = strMsgUsuario;
                            }
                            //else if (strMsgUsuario.Contains("razón"))
                            //{
                            //    result.type = "info";
                            //    result.message = strMsgUsuario;
                            //}
                        }
                    }
                }

                **/

            }
            catch (Exception)
            {
                result.type = "errorInt";
                result.message = "Ocurrió un inconveniente al registrar la Variable";
            }

            return Json(result);
        }

        //BL
        public bool IUProductoBL(int intTipoOperacion, TB_PRODUCTOS objDatos, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";
                // using (TransactionScope scope = new TransactionScope())
                //{
                int idEmpresa = IUProductoDAO(intTipoOperacion, objDatos, ref intResult, ref strMsjDB, ref strMsjUsuario);
                //  scope.Complete();
                // }
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        //Log.AlmacenarLogMensaje("[IUEmpresa] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    //Log.AlmacenarLogError(ex, "EmpresaBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (InsertarEmpresa)");
            //}
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString(), "ProcesoController.cs");
                //Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                throw new Exception("Ocurrió un error en BD (InsertarEmpresa)");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "ProcesoController.cs");
                //Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                throw new Exception("Error General (InsertarEmpresa)");
            }
        }

        //DAO
        public int IUProductoDAO(int intTipoOperacion, TB_PRODUCTOS objDatos, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            int intIdEmpresaOut = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TB_PRODUCTOS_IU00", cn); //TSP_TGEMPRESA_IU01
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                ////param.Add("@strCoEmp", objDatos.strCoEmp);
                ////param.Add("@strDesEmp", objDatos.strDesEmp);
                ////param.Add("@strRuc", objDatos.strRuc);

                param.Add("@intIdProducto", objDatos.intIdProducto);
                if (objDatos.strCodigoBarras == null) { param.Add("@strCodigoBarras", DBNull.Value); }
                else { param.Add("@strCodigoBarras", objDatos.strCodigoBarras); }
                if (objDatos.strCodigoProducto == null) { param.Add("@strCodigoProducto", DBNull.Value); }
                else { param.Add("@strCodigoProducto", objDatos.strCodigoProducto); }
                if (objDatos.strDescProducto == null) { param.Add("@strDescProducto", DBNull.Value); }
                else { param.Add("@strDescProducto", objDatos.strDescProducto); }
                param.Add("@intIdMarcaProducto", objDatos.intIdMarcaProducto);
                param.Add("@decPrecioDeVenta", objDatos.decPrecioDeVenta);
                param.Add("@intCantTotalActual", objDatos.intCantTotalActual);
                param.Add("@decMontoProducto", objDatos.decMontoProducto); //
                if (objDatos.strMarcaProducto == null) { param.Add("@strMarcaProducto", DBNull.Value); }
                else { param.Add("@strMarcaProducto", objDatos.strMarcaProducto); }
                if (objDatos.strRutaImagenMarca == null) { param.Add("@strRutaImagenMarca", DBNull.Value); }
                else { param.Add("@strRutaImagenMarca", objDatos.strRutaImagenMarca); }
                if (objDatos.strRutaImagenProducto == null) { param.Add("@strRutaImagenProducto", DBNull.Value); }
                else { param.Add("@strRutaImagenProducto", objDatos.strRutaImagenProducto); }
                if (objDatos.strDescCategoria == null) { param.Add("@strDescCategoria", DBNull.Value); }
                else { param.Add("@strDescCategoria", objDatos.strDescCategoria); }
                if (objDatos.strPresentacion == null) { param.Add("@strPresentacion", DBNull.Value); }
                else { param.Add("@strPresentacion", objDatos.strPresentacion); }

                //if (objDatos.imgLogo == null)
                //{
                //    param.Add("@strLogo", DBNull.Value);
                //}
                //else
                //{
                //    param.Add("@strLogo", objDatos.imgLogo);
                //}
                ////////////  param.Add("@strDirFiscal", objDatos.strDirFiscal);
                ////////////  param.Add("@strLogo", objDatos.imgLogo);
                //////////param.Add("@intTipoEmp", objDatos.intTipoEmp);
                //////////param.Add("@strEmpresaCampo1", objDatos.strEmpresaCampo1);
                //////////param.Add("@strEmpresaCampo2", objDatos.strEmpresaCampo2);
                //////////param.Add("@bitFlActivo", objDatos.bitFlActivo);
                //////////param.Add("@intIdUsuario", objSession.intIdUsuario);
                //////////param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update
                ////////////Parámetros de Salida
                //param.Add("@IntIdEmp", objDatos.IntIdEmp);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();
                //intIdEmpresaOut = Convert.ToInt32(cmd.Parameters["@IntIdEmp"].Value.ToString());
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return intIdEmpresaOut;
        }


        #endregion UPDATE PRODUCTOS                            


        /********************************************************************************************                            
                 METODOS PARA REGISTRAR PRODUCTO DESDE EL FORMULARIO CON INPUTS DINAMICOS
         ********************************************************************************************/
        #region INSERT UPDATE PRODUCTO "GESTPRO"

        //CONTROLLER
        public JsonResult InsertUpdateProductoGestPro(TB_PRODUCTOS ObjProducto, int intTipoOperacion)
        {
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";

            try
            {
                bool insert = false;

                insert = InsertProductoBL(intTipoOperacion, ObjProducto, ref strMsgUsuario);


                if (strMsgUsuario.Equals("") && insert && intTipoOperacion == 1)
                {
                    result.type = "success";
                    result.message = "El registro se insertó satisfactoriamente.";
                }
                else if (strMsgUsuario.Equals("") && insert && intTipoOperacion == 2)
                {
                    result.type = "success";
                    result.message = "El registro se actualizó satisfactoriamente.";
                }
                else
                {

                    if (strMsgUsuario.Contains("código"))
                    {
                        result.type = "error";
                        result.message = strMsgUsuario;
                    }
                    else
                    {
                        if (strMsgUsuario.Contains("razón"))
                        {
                            result.type = "info";
                            result.message = strMsgUsuario;
                        }
                        else
                        {
                            if (strMsgUsuario.Contains("ruc"))
                            {
                                result.type = "alert";
                                result.message = strMsgUsuario;
                            }
                            else
                            {
                                result.type = "info";
                                result.message = strMsgUsuario;
                            }
                        }
                    }


                }


            }
            catch (Exception)
            {
                result.type = "errorInt";
                result.message = "Ocurrió un inconveniente al registrar";
            }

            return Json(result);
        }

        //BL
        public bool InsertProductoBL(int intTipoOperacion, TB_PRODUCTOS objDatos, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";
                // using (TransactionScope scope = new TransactionScope())
                //{
                int idEmpresa = InsertProductoDAO(intTipoOperacion, objDatos, ref intResult, ref strMsjDB, ref strMsjUsuario);
                //  scope.Complete();
                // }
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        //Log.AlmacenarLogMensaje("[IUEmpresa] => Respuesta del Procedimiento : " + strMsjDB);
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
                Console.WriteLine(ex.ToString(), "ProcesoController.cs");
                //Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                throw new Exception("Ocurrió un error en BD (InsertarEmpresa)");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "ProcesoController.cs");
                //Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                throw new Exception("Error General (InsertarEmpresa)");
            }
        }

        //DAO
        public int InsertProductoDAO(int intTipoOperacion, TB_PRODUCTOS objDatos, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            //int intIdEmpresaOut = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TB_PRODUCTOS_GESPRO_IU00", cn); //TSP_TGEMPRESA_IU01
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("@intIdProducto", objDatos.intIdProducto);

                if (objDatos.strCodigoBarras == null) { param.Add("@strCodigoBarras", DBNull.Value); }
                else { param.Add("@strCodigoBarras", objDatos.strCodigoBarras); }

                if (objDatos.strCodigoProducto == null) { param.Add("@strCodigoProducto", DBNull.Value); }
                else { param.Add("@strCodigoProducto", objDatos.strCodigoProducto); }

                if (objDatos.strDescProducto == null) { param.Add("@strDescProducto", DBNull.Value); }
                else { param.Add("@strDescProducto", objDatos.strDescProducto); }

                param.Add("@intIdMarcaProducto", objDatos.intIdMarcaProducto);
                param.Add("@decPrecioDeVenta", objDatos.decPrecioDeVenta);
                param.Add("@intCantTotalActual", objDatos.intCantTotalActual);
                param.Add("@decMontoProducto", objDatos.decMontoProducto);

                if (objDatos.strMarcaProducto == null) { param.Add("@strMarcaProducto", DBNull.Value); }
                else { param.Add("@strMarcaProducto", objDatos.strMarcaProducto); }

                if (objDatos.strRutaImagenMarca == null) { param.Add("@strRutaImagenMarca", DBNull.Value); }
                else { param.Add("@strRutaImagenMarca", objDatos.strRutaImagenMarca); }

                if (objDatos.strRutaImagenProducto == null) { param.Add("@strRutaImagenProducto", DBNull.Value); }
                else { param.Add("@strRutaImagenProducto", objDatos.strRutaImagenProducto); }

             
                param.Add("@intIdCategoria", objDatos.intIdCategoria); 

                if (objDatos.strDescCategoria == null) { param.Add("@strDescCategoria", DBNull.Value); }
                else { param.Add("@strDescCategoria", objDatos.strDescCategoria); }

                if (objDatos.strPresentacion == null) { param.Add("@strPresentacion", DBNull.Value); }
                else { param.Add("@strPresentacion", objDatos.strPresentacion); }

                if (objDatos.strInfoAdicionalProd == null) { param.Add("@strInfoAdicionalProd", DBNull.Value); }
                else { param.Add("@strInfoAdicionalProd", objDatos.strInfoAdicionalProd); }

                if (objDatos.decPorcentajeDescto == null) { param.Add("@decPorcentajeDescto", DBNull.Value); }
                else { param.Add("@decPorcentajeDescto", objDatos.decPorcentajeDescto); }

                //if (objDatos.decMontoProducto == null) { param.Add("@decMontoProducto", DBNull.Value); }
                //else { param.Add("@decMontoProducto", objDatos.decMontoProducto); }

                

                param.Add("@intTipoOperacion", intTipoOperacion); //1: insert, 2: update

                //-------------------------------------------------------------------------
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return intResult;
        }

        #endregion INSERT PRODUCTO "GESTPRO"


        /********************************************************************************************                            
                 METODOS PARA EDITAR PRODUCTO DESDE EL LISTADO PRINCIPAL CON INPUTS DINAMICOS
         ********************************************************************************************/
        #region PRODUCTO X PK EDITAR "GESTPRO"
        //01 
        public JsonResult ObtenerProductoPorPkEditarGestPro(int intIdProducto)
        {
            string strMsgUsuario = "";

            List<TB_PRODUCTOS> lst = new List<TB_PRODUCTOS>();

            lst = ObtenerProductoPorPkBL(intIdProducto, ref strMsgUsuario).ToList();

            return Json(lst);
        }

        //02
        public List<TB_PRODUCTOS> ObtenerProductoPorPkBL(int intIdProducto, ref string strMsjUsuario)
        {
            List<TB_PRODUCTOS> lista = new List<TB_PRODUCTOS>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = ObtenerProductoPorPkDAO(intIdProducto, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        //Log.AlmacenarLogMensaje("[ObtenerRegistroEmpresa] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString(), "ProcesoController.cs");
                //Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                //throw new Exception("Ocurrió un error en BD (ObtenerRegistroEmpresa)");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "ProcesoController.cs");
                //Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                //throw new Exception("Error General (ObtenerRegistroEmpresa)");
            }
            return lista;
        }

        //03
        public List<TB_PRODUCTOS> ObtenerProductoPorPkDAO(int intIdProducto, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TB_PRODUCTOS> lista = new List<TB_PRODUCTOS>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TB_PRODUCTOS_GESPRO_Q00_PK_EDITAR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("@intIdProducto", intIdProducto);

                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //POR PK
                        TB_PRODUCTOS obj = new TB_PRODUCTOS();
                        if (!reader.IsDBNull(0))  { obj.intIdProducto         = reader.GetInt32(0); };
                        if (!reader.IsDBNull(1))  { obj.strCodigoBarras       = reader.GetString(1); };
                        if (!reader.IsDBNull(2))  { obj.strCodigoProducto     = reader.GetString(2); };
                        if (!reader.IsDBNull(3))  { obj.strDescProducto       = reader.GetString(3); };
                        if (!reader.IsDBNull(4))  { obj.intIdMarcaProducto    = reader.GetInt32(4); };
                        if (!reader.IsDBNull(5))  { obj.decPrecioDeVenta      = reader.GetString(5); };
                        if (!reader.IsDBNull(6))  { obj.intCantTotalActual    = reader.GetInt32(6); };
                        if (!reader.IsDBNull(7))  { obj.decMontoProducto      = reader.GetString(7); };
                        if (!reader.IsDBNull(8))  { obj.strRutaImagenMarca    = reader.GetString(8); }
                        if (!reader.IsDBNull(9))  { obj.strRutaImagenProducto = reader.GetString(9); }
                        if (!reader.IsDBNull(10)) { obj.intIdCategoria        = reader.GetInt32(10); }
                        //if (!reader.IsDBNull(10)) { obj.strDescCategoria      = reader.GetString(10); }
                        if (!reader.IsDBNull(11)) { obj.strPresentacion       = reader.GetString(11); }
                        if (!reader.IsDBNull(12)) { obj.strInfoAdicionalProd  = reader.GetString(12); }
                        if (!reader.IsDBNull(13)) { obj.decPorcentajeDescto   = reader.GetString(13); }

                        lista.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return lista;
        }

        #endregion SELECT PRODUCTOS X PK PARTE 2


        #region PRODUCTOS PK 
        //01 
        public JsonResult ObtenerRegistroProductoPorPk(int intIdProducto)
        {
            string strMsgUsuario = "";

            List<TB_PRODUCTOS> det = new List<TB_PRODUCTOS>();

            det = ObtenerRegistroProductoPorPkBL(intIdProducto, ref strMsgUsuario).ToList();

            return Json(det);
        }

        //02
        public List<TB_PRODUCTOS> ObtenerRegistroProductoPorPkBL(int intIdProducto, ref string strMsjUsuario)
        {
            List<TB_PRODUCTOS> lista = new List<TB_PRODUCTOS>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = ObtenerRegistroProductoPorPkDAO(intIdProducto, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        //Log.AlmacenarLogMensaje("[ObtenerRegistroEmpresa] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString(), "ProcesoController.cs");
                //Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                //throw new Exception("Ocurrió un error en BD (ObtenerRegistroEmpresa)");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "ProcesoController.cs");
                //Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                //throw new Exception("Error General (ObtenerRegistroEmpresa)");
            }
            return lista;
        }

        //03
        public List<TB_PRODUCTOS> ObtenerRegistroProductoPorPkDAO(int intIdProducto, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TB_PRODUCTOS> lista = new List<TB_PRODUCTOS>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TB_PRODUCTOS_Q00_PK", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("@intIdProducto", intIdProducto);

                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //POR PK
                        TB_PRODUCTOS obj = new TB_PRODUCTOS();
                        if (!reader.IsDBNull(0)) { obj.intIdProducto         = reader.GetInt32(0); };
                        if (!reader.IsDBNull(1)) { obj.strCodigoBarras       = reader.GetString(1); };
                        if (!reader.IsDBNull(2)) { obj.strCodigoProducto     = reader.GetString(2); };
                        if (!reader.IsDBNull(3)) { obj.strDescProducto       = reader.GetString(3); };
                        if (!reader.IsDBNull(4)) { obj.strMarcaProducto      = reader.GetString(4); };
                        if (!reader.IsDBNull(5)) { obj.decPrecioDeVenta      = reader.GetString(5); };
                        if (!reader.IsDBNull(6)) { obj.intCantTotalActual    = reader.GetInt32(6); };
                        if (!reader.IsDBNull(7)) { obj.decMontoProducto      = reader.GetString(7); };
                        if (!reader.IsDBNull(8)) { obj.strRutaImagenMarca    = reader.GetString(8); }
                        if (!reader.IsDBNull(9)) { obj.strRutaImagenProducto = reader.GetString(9); }
                        if (!reader.IsDBNull(10)) { obj.strDescCategoria     = reader.GetString(10); }
                        if (!reader.IsDBNull(11)) { obj.strPresentacion      = reader.GetString(11); }

                        lista.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return lista;
        }

        #endregion PRODUCTOS PK


        public static string codItemImagen { get; set; }
        //RECIBIR EL NOMBRE DE LA IMAGEN
        public string CodigoItemJsToController(string codItemFromJs)
        {
            string str = String.Empty;
            codItemImagen = codItemFromJs;
            return str;
        }

        public static string srtImagenPreviaCargada { get; set; }
        ////RECIBIR EL NOMBRE DE LA IMAGEN
        //public string ImagenPreviaCargadaController(string codItemFromJs)
        //{
        //    string str = String.Empty;
        //    codItemImagen = codItemFromJs;
        //    return str;
        //}

        public JsonResult UploadImagenProducto()
        {
            string dir = null;

            //https://docs.microsoft.com/en-us/dotnet/api/system.random?view=net-6.0
            // Instantiate random number generator using system-supplied value as seed.
            var rand = new Random();

            //https://www.tutorialsteacher.com/articles/generate-random-numbers-in-csharp
            //Returns a positive random integer within the specified minimum and maximum range (includes min and excludes max).
            int RANDOM = rand.Next(101,999);

            //////foreach (string item in Request.Files)
            //////{
            //////    HttpPostedFileBase file = Request.Files[item] as HttpPostedFileBase;
            //////    //string idProcesoAleatorio = item.
            //////            //string filen_ = file.FileName;

            //////    string filen_ = file.FileName.Substring(file.FileName.IndexOf("/") + 1, file.FileName.Length);
            //////    string fileName =  filen_;// file.FileName;//num.ToString() +  //idP.ToString()
            //////}

            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i]; //Uploaded file 

                //Use the following properties to get file's name, size and MIMEType 
                int fileSize = file.ContentLength;
                string fileName = file.FileName;

                ////string extension = file.FileName.Substring(file.FileName.IndexOf(".") + 1); //logo.png o logo.jpg //Apoyo: https://docs.microsoft.com/en-us/dotnet/api/system.string.substring?view=net-6.0
                ////string fileName = codItemImagen + '.' + extension;
                string mimeType = file.ContentType;
                System.IO.Stream fileContent = file.InputStream; //To save file, use SaveAs method 

                var request = System.Web.HttpContext.Current.Request;

                //request.Url.Scheme gives output as https/http 
                //while request.Url.Authority give us Domain name
                var baseUrl = request.Url.Scheme + "://" + request.Url.Authority;


                ////dir = Server.MapPath("~/") + "images\\productos\\" + fileName;//dir = Server.MapPath("~/") + "DirLogosEmpresa\\" + fileName;
                dir = Server.MapPath("~/") + "images\\productos\\" + "PRE_LOAD_" + RANDOM + "_" + fileName;//dir = Server.MapPath("~/") + "DirLogosEmpresa\\" + fileName;
                baseUrl = "/images/productos/" + "PRE_LOAD_" + RANDOM + "_" + fileName;//baseUrl = "/DirLogosEmpresa/" + fileName;




                /////////////////////////////////////////////////////////////////
                //////string EliminarEstos = "ITEM01418";
                //////string[] Files = Directory.GetFiles(Server.MapPath("~/") + "images\\productos\\");
                //////foreach (string f in Files)
                //////{
                //////    if (f.ToUpper().Contains(EliminarEstos.ToUpper()))
                //////    {
                //////        System.IO.File.Delete(f);
                //////    }
                //////    //ELIMINA TODO DE ESA CARPETA
                //////    //System.IO.File.Delete(f);


                //////       System.IO.File.Move("C:\\Users\\Personal\\Documents\\Visual Studio 2017\\Sln_PetShopWeb\\PETSHOP\\images\\productos\\ITEM000011112.jpg", "C:\\Users\\Personal\\Documents\\Visual Studio 2017\\Sln_PetShopWeb\\PETSHOP\\images\\productos\\ITEM000011113.jpg");
                //////}

                /////////////////////////////////////////////////////////////////
                if (srtImagenPreviaCargada != null)
                {
                    System.IO.File.Delete(Server.MapPath("~/") + "images\\productos\\" + srtImagenPreviaCargada);

                }
                //Guardar el nombre para eliminarlo en la proxima cargada de otra imagen
                srtImagenPreviaCargada = "PRE_LOAD_" + RANDOM + "_" + file.FileName;
                /////////////////////////////////////////////////////////////////

                file.SaveAs(dir); //File will be saved in application root 
                return Json(baseUrl);



            }
            return Json(dir);
        }

        //AL ACCIONAR BOTON GUARDAR O ACTUALIZAR
        public JsonResult ChangeNameImagenProducto(string initialNameImagen , string finalNameImagen)
        {
            string dir = null;
            string nomGuardado = "";

            ////if (initialNameImagen == null) initialNameImagen = "item_default.png";

            if (initialNameImagen != null && initialNameImagen != "") { 
            string extension = initialNameImagen.Substring(initialNameImagen.IndexOf(".") + 1); //logo.png o logo.jpg //Apoyo: https://docs.microsoft.com/en-us/dotnet/api/system.string.substring?view=net-6.0
            string nomCargado  = Server.MapPath("~/") + "images\\productos\\" + initialNameImagen;
             nomGuardado = Server.MapPath("~/") + "images\\productos\\" + finalNameImagen + "." + extension;
            /////////////////////////////////////////////////////////////////
            //////string EliminarEstos = initialNameImagen;
            ////string[] Files = Directory.GetFiles(Server.MapPath("~/") + "images\\productos\\");
            ////foreach (string f in Files)
            ////{

                //Cambiamos el nombre original de la imagen cargada al tipo "ITEM0001"
                //https://stackoverflow.com/questions/3218910/rename-a-file-in-c-sharp
                //System.IO.File.Move(nomCargado, nomGuardado);

                //Primero eliminamos si existe
                if (System.IO.File.Exists(nomGuardado) )
                {
                    //System.IO.File.Copy(oldName, newName, true);
                    //System.IO.File.Delete(oldName);
                    System.IO.File.Delete(nomGuardado);

                }

                if (System.IO.File.Exists(nomCargado))
                {
                    //System.IO.File.Copy(oldName, newName, true);
                    //System.IO.File.Delete(oldName);
                    System.IO.File.Delete(nomGuardado);
                    System.IO.File.Move(nomCargado, nomGuardado); //Cambiamos el nombre del archivo recientemente cargado
                }
                //else
                //{
                //    System.IO.File.Move(nomCargado, nomGuardado); //Cambiamos el nombre del archivo recientemente cargado
                //}

                //Para limpiar/soltar la imagen manipulada anteriormente o previamente(en un editar o un nuevo)
                srtImagenPreviaCargada = null;

            }

            ////System.IO.File.Move("C:\\Users\\Personal\\Documents\\Visual Studio 2017\\Sln_PetShopWeb\\PETSHOP\\images\\productos\\ITEM000011112.jpg", "C:\\Users\\Personal\\Documents\\Visual Studio 2017\\Sln_PetShopWeb\\PETSHOP\\images\\productos\\ITEM000011113.jpg");
            //}

            /////////////////////////////////////////////////////////////////



            return Json(nomGuardado);
        }



        /***************************************************************************************
        *   ViewGestionProductos
        ***************************************************************************************/
        #region LISTADO PRINCIPAL DE PRODUCTOS  "GESTPRO"
        //P01.1.- Listar
        public JsonResult ListarProductosGestPro(string strCodigoBarras, int intIdCategoria, string strVencimiento, int intIdMarcaProducto)
        {
            string strMsgUsuario = "";
            int intResult = 0;

            List<TB_PRODUCTOS> Listar = new List<TB_PRODUCTOS>();

            Listar = ListarGestionarProductosBL(strCodigoBarras, intIdCategoria, strVencimiento, intIdMarcaProducto, ref intResult, ref strMsgUsuario).ToList();

            return Json(Listar);
        }

        //P01.2.- BL
        public List<TB_PRODUCTOS> ListarGestionarProductosBL(string strCodigoBarras, int intIdCategoria, string strVencimiento, int intIdMarcaProducto, ref int intResult, ref string strMsjUsuario)
        {

            List<TB_PRODUCTOS> lista = new List<TB_PRODUCTOS>();
            string strMsjDB = "";

            lista = ListarGestionarProductosDAO(strCodigoBarras, intIdCategoria, strVencimiento, intIdMarcaProducto, ref intResult, ref strMsjDB, ref strMsjUsuario);
            if (intResult == 0)
            {
                if (!strMsjDB.Equals(""))
                {
                    ////Log.AlmacenarLogMensaje("[ListarEmpresa] => Respuesta del Procedimiento : " + strMsjDB);
                    if (strMsjUsuario.Equals(""))
                        strMsjUsuario = strMsjDB;
                }

            }

            ////}
            ////catch (SqlException ex)
            ////{
            ////    Log.AlmacenarLogError(ex, "EmpresaBL.cs");
            ////    throw new Exception("Ocurrió un error en BD (ListarEmpresa)");
            ////}

            ////catch (Exception ex)
            ////{
            ////    Log.AlmacenarLogError(ex, "EmpresaBL.cs");
            ////    throw new Exception("Error General (ListarEmpresa)");
            ////}

            return lista;
        }

        //P01.3.- DAO
        public List<TB_PRODUCTOS> ListarGestionarProductosDAO(string strCodigoBarras, int intIdCategoria, string strVencimiento, int intIdMarcaProducto, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TB_PRODUCTOS> lista = new List<TB_PRODUCTOS>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TB_PRODUCTOS_GESPRO_Q00_LISTADO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                //param.Add("@intIdSesion", objSession.intIdSesion);
                //param.Add("@intIdMenu", objSession.IntIdMenu);
                //param.Add("@intIdSoft", objSession.intIdSoft);
                //param.Add("@intActivo", intActivo);
                //param.Add("@strFiltro", strDescripcion);             
                param.Add("@strVencimiento", strVencimiento);
                param.Add("@strCodigoBarras", strCodigoBarras);
                param.Add("@intIdCategoria", intIdCategoria);
                param.Add("@intIdMarcaProducto", intIdMarcaProducto);

                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //LISTADO NORMAL DE "TODOS LOS REGISTROS" NO POR PK
                    TB_PRODUCTOS obj = new TB_PRODUCTOS();
                    if (!reader.IsDBNull(0)) { obj.intIdProducto        = reader.GetInt32(0); };
                    if (!reader.IsDBNull(1)) { obj.strCodigoBarras      = reader.GetString(1); };
                    if (!reader.IsDBNull(2)) { obj.strCodigoProducto    = reader.GetString(2); };
                    if (!reader.IsDBNull(3)) { obj.strDescProducto      = reader.GetString(3); };
                    if (!reader.IsDBNull(4)) { obj.strMarcaProducto     = reader.GetString(4); };
                    if (!reader.IsDBNull(5)) { obj.decPrecioDeVenta     = reader.GetString(5); };
                    if (!reader.IsDBNull(6)) { obj.intCantTotalActual   = reader.GetInt32(6); };
                    if (!reader.IsDBNull(7)) { obj.decMontoProducto     = reader.GetString(7); };
                    if (!reader.IsDBNull(8)) { obj.strRutaImagenMarca   = reader.GetString(8); }

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        #endregion LISTADO PRINCIPAL DE PRODUCTOS  "GESTPRO"


        #region CombosGeneral
        /***************************************************************************************
         * 2.-  Combos() - Para los filtros
         ***************************************************************************************/


        //2.1.- ListarCombosPersonal_(Metodo N° 5.10)
        public JsonResult ListarCombosGestionar(string strNomTablaEntidad, int intParametroEntero)
        {
            string strMsgUsuario = "";

            List<MD_COMBOS> lista = new List<MD_COMBOS>();
            lista = ListarCombosBL(strNomTablaEntidad, intParametroEntero, ref strMsgUsuario).ToList();


            return Json(lista);
        }



        //2.2.-

        /*================================================================================= 
        * 14.2
        * =================================================================================*/
        public List<MD_COMBOS> ListarCombosBL(string strNomTablaEntidad, int intParametroEntero, ref string strMsjUsuario)
        {
            List<MD_COMBOS> lista = new List<MD_COMBOS>();
            string nombreDelSp = "";
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = ListarTablasEnCombos(strNomTablaEntidad, intParametroEntero, ref intResult, ref strMsjDB, ref strMsjUsuario, ref nombreDelSp);


                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        //Log.AlmacenarLogMensaje("[ListarTablasEnCombos] => Respuesta del Procedimiento : " + strMsjDB);
                        //if (strMsjUsuario.Equals(""))
                        //    strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString(), "ProcesoController.cs");
                //Log.AlmacenarLogError(ex, "ImpresionBL.cs: SqlException");
                //throw new Exception("Ocurrió un error en BD (ListarTablasEnCombos)");
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232015)
                {
                    Console.WriteLine(ex.ToString(), "ProcesoController.cs");
                    //Exception ex_null = new Exception("---> Error generado en el SP: " + nombreDelSp);
                    //Log.AlmacenarLogError(ex, "ImpresionBL.cs: Exception" + " ( " + ex_null + " )");
                    //throw new Exception("Error General (ListarTablasEnCombos)");

                }
                else
                {
                    //Log.AlmacenarLogError(ex, "ImpresionBL.cs: Exception");
                    //throw new Exception("Error General (ListarTablasEnCombos)");

                }
            }
            return lista;
        }



        /*================================================================================= 
         * 14.2 COMBOS ETIQUETAS IMPRESION
         * =================================================================================*/
        public List<MD_COMBOS> ListarTablasEnCombos(string strNomTablaEntidad, int intParametroEntero,
                            ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string nombreDelSp)
        {
            List<MD_COMBOS> lista = new List<MD_COMBOS>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_COMBOS_GENERAL_Q00", cn);  // ESTE SE REUTILIZA EN EL METODO 14.6
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                nombreDelSp = cmd.CommandText;
                Dictionary<string, object> param = new Dictionary<string, object>();

                //param.Add("@intIdSesion", objSession.intIdSesion);
                //param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                //param.Add("@intIdSoft", objSession.intIdSoft);
                //----------------------------------------------------------
                param.Add("@strNomTablaEntidad", strNomTablaEntidad);
                param.Add("@intParametroEntero", intParametroEntero);
                //-----------------------------------------------------------
                //salida             
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    MD_COMBOS obj = new MD_COMBOS();//TablasEnCombo


                    if (!reader.IsDBNull(0))
                    {
                        obj.intIdEntidad = reader.GetInt32(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        obj.strDescEntidad = reader.GetString(1);
                    }



                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }



        //////////2.3.-
        ////////public List<MD_COMBOS> ListarCombosDAO(/*long intIdSesion, int intIdMenu, int intIdSoft,*/ string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        ////////{
        ////////    List<MD_COMBOS> lista = new List<MD_COMBOS>();

        ////////    using (SqlConnection cn = new SqlConnection(cadCnx))
        ////////    {
        ////////        SqlCommand cmd = new SqlCommand("TSP_LISTAR_COMBOS_Q00", cn);
        ////////        cmd.CommandType = CommandType.StoredProcedure;
        ////////        //cmd.CommandTimeout = timeSQL;//21.04.2021
        ////////        cn.Open();

        ////////        Dictionary<string, object> param = new Dictionary<string, object>();
        ////////        //param.Add("@intIdSesion", 1);
        ////////        //param.Add("@intIdMenu", 1);
        ////////        //param.Add("@intIdSoft", 1);

        ////////        param.Add("@strEntidad", strEntidad);
        ////////        //param.Add("@intIdFiltroGrupo", intIdFiltroGrupo);
        ////////        //param.Add("@strGrupo", strGrupo);
        ////////        //param.Add("@strSubGrupo", strSubGrupo);

        ////////        //salida
        ////////        param.Add("@intResult", 0);
        ////////        param.Add("@strMsjDB", "");
        ////////        param.Add("@strMsjUsuario", "");
        ////////        AsignarParametros(cmd, param);

        ////////        SqlDataReader reader = cmd.ExecuteReader();
        ////////        while (reader.Read())
        ////////        {
        ////////            MD_COMBOS obj = new MD_COMBOS();

        ////////            //obj.intidTipo = reader.GetInt32(0);
        ////////            //obj.strDeTipo = reader.GetString(1);

        ////////            //if (strEntidad == "TGCONCEPTO" && strGrupo == "AUSENTISMO" && strSubGrupo == "AUSENTISMO")
        ////////            //{
        ////////            //    obj.strCoTipo = reader.GetString(2);
        ////////            //    obj.bitFlActivo = reader.GetBoolean(3);
        ////////            //}
        ////////            //else if (strEntidad == "TGREPORTE" && strGrupo == "TGREPORTE")
        ////////            //{
        ////////            //    obj.strextra1 = reader.GetString(2);
        ////////            //}
        ////////            //else if ((strEntidad == "TGPERIODO" && strGrupo == "TGPERIODOXANIO") || (strEntidad == "TGPERIODO" && strGrupo == "TGPERIODOXPLANILLA"))
        ////////            //{
        ////////            //    obj.strextra1 = reader.GetString(2);
        ////////            //    obj.strextra2 = reader.GetString(3);
        ////////            //}
        ////////            //else if (strEntidad == "TGUNIDORG" && strGrupo == "JERAR" && strSubGrupo == "REPORTE")
        ////////            //{
        ////////            //    obj.strextra1 = reader.GetString(2);
        ////////            //}
        ////////            //else if (strEntidad == "TGTIPO" && strGrupo == "TGTIPOMARCA")
        ////////            //{
        ////////            //    obj.strextra1 = reader.GetString(2);
        ////////            //}
        ////////            lista.Add(obj);

        ////////        }

        ////////        reader.Close();

        ////////        intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
        ////////        strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
        ////////        strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

        ////////    }
        ////////    return lista;
        ////////}


        #endregion


        /***************************************************************************************
         * 1.-  ViewVentaProductos() Para la pestaña de vender
         ***************************************************************************************/
        public JsonResult ObtenerProductoPorPkPntVnt(int intIdProducto, string strCodigoBarras)
        {
            //////////////////string relativePath = ConfigurationManager.AppSettings["filePath"];
            ////////////////////string combinedPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
            ////////////////////string strRutaDir = ConfigurationManager.AppSettings["rutaFormatos"];
            ////////////////////string rutaDirFormatos = Path.Combine(HttpContext.Request.MapPath(strRutaDir));
            ////////////////////string strRutaDir = ConfigurationManager.AppSettings["rutaFormatos"];
            //////////////////string rutaDirectorio = Path.Combine(HttpContext.Request.MapPath(relativePath));
            //////////////////string[] arreglo = Directory.GetFiles(rutaDirectorio, "*.jpg");
            //////////////////foreach (string i in arreglo)
            //////////////////{
            //////////////////    //if (i.Contains(txtFormatoSplit))
            //////////////////    //{
            //////////////////    //    existe = 1;

            //////////////////    //}

            //////////////////}

            ///////////////////////////////////////////////////////////////
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";
            int intResult = 0;
            List<TB_PRODUCTOS> Listado = new List<TB_PRODUCTOS>();

            try
            {
                Listado = ObtenerProductoPorSuPK_BL(intIdProducto, strCodigoBarras, ref intResult, ref strMsgUsuario).ToList();

                int countList = Listado.Count;


                if (strMsgUsuario.Equals("") && countList > 0)
                {
                    result.type = "success";
                    result.message = "Se encontraron Registros.";

                    return Json(Listado); //EL LISTADO
                }
                else
                {
                    result.type = "info";
                    result.message = "No existe ningún Producto con el código ingresado.";

                    return Json(result); //UN MENsAJE INDICANDO QUE NO HAY LISTADO

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "ProcesoController.cs");
                throw new Exception("Error Controlador Personal"); //UNA EXCEPCION DE ERROR

            }

            //return Json(result);
            /* return Json(Listado);*///Listado  rutaDirectorio

        }

        ////public JsonResult ObtenerAusentismoPorsuPK(Session_Movi objSession, int intId)
        ////{
        ////    string strMsgUsuario = "";

        ////    try
        ////    {
        ////        int intResult = 1;
        ////        string strMsgDB = "";
        ////        //string strMsgUsuario = "";

        ////        return Json(intResult);

        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        //throw new Exception("Error Controlador Personal");
        ////    }

        ////}


        //5.12 BL
        public List<TB_PRODUCTOS> ObtenerProductoPorSuPK_BL(int intIdProducto, string strCodigoBarras, ref int intResult, ref string strMsjUsuario)
        {
            List<TB_PRODUCTOS> lista = new List<TB_PRODUCTOS>();
            //try
            //{
            //int intResult = 0;
            string strMsjDB = "";

            lista = ObtenerProductoPorSuPK_DAO(intIdProducto, strCodigoBarras, ref intResult, ref strMsjDB, ref strMsjUsuario);
            ////////    if (intResult == 0)
            ////////    {
            ////////        //if (!strMsjDB.Equals(""))
            ////////        //{
            ////////        //    Log.AlmacenarLogMensaje("[ObtenerEmpleadoPorsuPK] => Respuesta del Procedimiento : " + strMsjDB);
            ////////        //    if (strMsjUsuario.Equals(""))
            ////////        //        strMsjUsuario = strMsjDB;
            ////////        //}

            ////////    }

            ////////}
            ////////catch (SqlException ex)
            ////////{
            ////////    Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: SqlException");
            ////////    throw new Exception("Ocurrió un error en BD (ObtenerEmpleadoPorsuPK)");
            ////////}

            ////////catch (Exception ex)
            ////////{
            ////////    Log.AlmacenarLogError(ex, "ImportarExcelBL.cs: Exception");
            ////////    throw new Exception("Error General (ObtenerEmpleadoPorsuPK)");
            ////////}
            return lista;
        }

        //5.12 DAO
        public List<TB_PRODUCTOS> ObtenerProductoPorSuPK_DAO(int intIdProducto, string strCodigoBarras, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TB_PRODUCTOS> lista = new List<TB_PRODUCTOS>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_PNTVNT_TB_PRODUCTOS_Q00_PK", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();


                param.Add("@intIdProducto", intIdProducto);
                param.Add("@strCodigoBarras", strCodigoBarras);
                //salida

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {


                        TB_PRODUCTOS obj = new TB_PRODUCTOS();
                        if (!reader.IsDBNull(0)) { obj.intIdProducto         = reader.GetInt32(0); };
                        if (!reader.IsDBNull(1)) { obj.strCodigoBarras       = reader.GetString(1); };
                        if (!reader.IsDBNull(2)) { obj.strCodigoProducto     = reader.GetString(2); };
                        if (!reader.IsDBNull(3)) { obj.strDescProducto       = reader.GetString(3); };
                        if (!reader.IsDBNull(4)) { obj.strMarcaProducto      = reader.GetString(4); };
                        if (!reader.IsDBNull(5)) { obj.decPrecioDeVenta      = reader.GetString(5); };
                        if (!reader.IsDBNull(6)) { obj.intCantTotalActual    = reader.GetInt32(6); };
                        if (!reader.IsDBNull(7)) { obj.decMontoProducto      = reader.GetString(7); };
                        if (!reader.IsDBNull(8)) { obj.strRutaImagenMarca    = reader.GetString(8); }
                        if (!reader.IsDBNull(9)) { obj.strRutaImagenProducto = reader.GetString(9); }
                        if (!reader.IsDBNull(10)) { obj.strDescCategoria     = reader.GetString(10); }
                        if (!reader.IsDBNull(11)) { obj.strPresentacion      = reader.GetString(11); }

                        /***
                        TB_ENTRADAS obj = new TB_ENTRADAS();

                        if (!reader.IsDBNull(0))
                        {
                            obj.intIdEntrada = reader.GetInt32(0);
                        }
                        if (!reader.IsDBNull(1))
                        {
                            obj.strCodigoBarras = reader.GetString(1);
                        }                        
                        if (!reader.IsDBNull(2))
                        {
                            obj.strCodProducto = reader.GetString(2);
                        }
                        if (!reader.IsDBNull(3))
                        {
                            obj.strDesProducto = reader.GetString(3);
                        }
                        if (!reader.IsDBNull(4))
                        {
                            obj.strMarcaProd = reader.GetString(4);
                        }
                        if (!reader.IsDBNull(5))
                        {
                            obj.decPrecioDeVenta = reader.GetDecimal(5);
                        }

                        ****/


                        //intIdEntrada
                        //strCodProducto
                        //strDesProducto
                        //strMarcaProd

                        ////obj.dttFecNacim = reader.GetString(11);
                        ////obj.bitflSexo = reader.GetBoolean(12);
                        ////if (!reader.IsDBNull(14))
                        ////{
                        ////    obj.intIdTipoVia = reader.GetInt32(14);
                        ////}
                        ////obj.strDireccion = reader.GetString(15);
                        ////if (!reader.IsDBNull(16))
                        ////{
                        ////    obj.intIdUbigeo = reader.GetInt32(16);
                        ////}
                        ////if (!reader.IsDBNull(17))
                        ////{
                        ////    obj.imgFoto = reader.GetString(17);
                        ////}                 

                        lista.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return lista;
        }








        /* ======================================= 03.02.2021 ================================= 
         * ======================================= 04.02.2021 ================================= 
         * ======================================= 03.02.2021 =================================  /

        /***************************************************************************************
        *  html: ViewGestionProductos  ***********  MANTENIMIENTO GESTION COMPRA 
        ***************************************************************************************/
        #region LISTADO PRINCIPAL DE COMPRAS "GESCOM"
        //C01.1.- Listar
        public JsonResult ListarComprasGesCom(string strCodigoBarras, int intIdCategoria, string strVencimiento, int intIdMarcaProducto)
        {
            string strMsgUsuario = "";
            int intResult = 0;

            List<TB_COMPRAS> Listar = new List<TB_COMPRAS>();

            Listar = ListarGestionComprasBL(strCodigoBarras, intIdCategoria, strVencimiento, intIdMarcaProducto, ref intResult, ref strMsgUsuario).ToList();

            return Json(Listar);
        }

        //C01.2.- BL
        public List<TB_COMPRAS> ListarGestionComprasBL(string strCodigoBarras, int intIdCategoria, string strVencimiento, int intIdMarcaProducto, ref int intResult, ref string strMsjUsuario)
        {

            List<TB_COMPRAS> lista = new List<TB_COMPRAS>();
            string strMsjDB = "";

            lista = ListarGestionComprasDAO(strCodigoBarras, intIdCategoria, strVencimiento, intIdMarcaProducto, ref intResult, ref strMsjDB, ref strMsjUsuario);
            if (intResult == 0)
            {
                if (!strMsjDB.Equals(""))
                {
                    ////Log.AlmacenarLogMensaje("[ListarEmpresa] => Respuesta del Procedimiento : " + strMsjDB);
                    if (strMsjUsuario.Equals(""))
                        strMsjUsuario = strMsjDB;
                }

            }

            ////}
            ////catch (SqlException ex)
            ////{
            ////    Log.AlmacenarLogError(ex, "EmpresaBL.cs");
            ////    throw new Exception("Ocurrió un error en BD (ListarEmpresa)");
            ////}

            ////catch (Exception ex)
            ////{
            ////    Log.AlmacenarLogError(ex, "EmpresaBL.cs");
            ////    throw new Exception("Error General (ListarEmpresa)");
            ////}

            return lista;
        }

        //C01.3.- DAO
        public List<TB_COMPRAS> ListarGestionComprasDAO(string strCodigoBarras, int intIdCategoria, string strVencimiento, int intIdMarcaProducto, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TB_COMPRAS> lista = new List<TB_COMPRAS>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TB_COMPRAS_Q00_GESCOM_LISTADO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                //param.Add("@intIdSesion", objSession.intIdSesion);
                //param.Add("@intIdMenu", objSession.IntIdMenu);
                //param.Add("@intIdSoft", objSession.intIdSoft);
                //param.Add("@intActivo", intActivo);
                //param.Add("@strFiltro", strDescripcion);             
                param.Add("@strVencimiento", strVencimiento);
                param.Add("@strCodigoBarras", strCodigoBarras);
                param.Add("@intIdCategoria", intIdCategoria);
                param.Add("@intIdMarcaProducto", intIdMarcaProducto);

                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //LISTADO NORMAL DE "TODOS LOS REGISTROS" NO POR PK
                    TB_COMPRAS obj = new TB_COMPRAS();
                    if (!reader.IsDBNull(0)) { obj.intIdCompra          = reader.GetInt32(0); };
                    if (!reader.IsDBNull(1)) { obj.strCodigoCompra      = reader.GetString(1); };
                    if (!reader.IsDBNull(2)) { obj.intIdProducto        = reader.GetInt32(2); };
                    if (!reader.IsDBNull(3)) { obj.strCodigoProducto    = reader.GetString(3); };
                    if (!reader.IsDBNull(4)) { obj.intCantIngresada     = reader.GetInt32(4); };
                    if (!reader.IsDBNull(5)) { obj.decCostoUnitCompra   = reader.GetString(5); };
                    if (!reader.IsDBNull(6)) { obj.decMontoTotCompra    = reader.GetString(6); };
                    if (!reader.IsDBNull(7)) { obj.dttFechaIngreso      = reader.GetString(7); };
                    if (!reader.IsDBNull(8)) { obj.strDescMarcaProd     = reader.GetString(8); };
                    if (!reader.IsDBNull(9)) { obj.strCodigoBarras      = reader.GetString(9); };

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        #endregion LISTADO PRINCIPAL DE COMPRAS  "GESCOM"



        /********************************************************************************************                            
         METODOS PARA REGISTRAR "COMPRA o INGRESO" DESDE EL FORMULARIO CON INPUTS DINAMICOS
        ********************************************************************************************/
        #region INSERT/UPDATE COMPRA o INGRESO "GESCOM"

        //CONTROLLER
        public JsonResult InsertUpdateCompraGesCom(TB_COMPRAS ObjCompra, int intTipoOperacion)
        {
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";

            try
            {
                bool insert = false;

                insert = InsertCompraBL(intTipoOperacion, ObjCompra, ref strMsgUsuario);


                if (strMsgUsuario.Equals("") && insert && intTipoOperacion == 1)
                {
                    result.type = "success";
                    result.message = "El registro se insertó satisfactoriamente.";
                }
                else if (strMsgUsuario.Equals("") && insert && intTipoOperacion == 2)
                {
                    result.type = "success";
                    result.message = "El registro se actualizó satisfactoriamente.";
                }
                else
                {

                    if (strMsgUsuario.Contains("código"))
                    {
                        result.type = "error";
                        result.message = strMsgUsuario;
                    }
                    else
                    {
                        if (strMsgUsuario.Contains("razón"))
                        {
                            result.type = "info";
                            result.message = strMsgUsuario;
                        }
                        else
                        {
                            if (strMsgUsuario.Contains("ruc"))
                            {
                                result.type = "alert";
                                result.message = strMsgUsuario;
                            }
                            else
                            {
                                result.type = "info";
                                result.message = strMsgUsuario;
                            }
                        }
                    }


                }


            }
            catch (Exception)
            {
                result.type = "errorInt";
                result.message = "Ocurrió un inconveniente al registrar";
            }

            return Json(result);
        }

        //BL
        public bool InsertCompraBL(int intTipoOperacion, TB_COMPRAS ObjCompra, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";
                // using (TransactionScope scope = new TransactionScope())
                //{
                int idEmpresa = InsertCompraDAO(intTipoOperacion, ObjCompra, ref intResult, ref strMsjDB, ref strMsjUsuario);
                //  scope.Complete();
                // }
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        //Log.AlmacenarLogMensaje("[IUEmpresa] => Respuesta del Procedimiento : " + strMsjDB);
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
                Console.WriteLine(ex.ToString(), "ProcesoController.cs");
                //Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                throw new Exception("Ocurrió un error en BD (Insertar)");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "ProcesoController.cs");
                //Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                throw new Exception("Error General (Insertar)");
            }
        }

        //DAO
        public int InsertCompraDAO(int intTipoOperacion, TB_COMPRAS objDatos, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            //int intIdEmpresaOut = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TB_COMPRAS_IU00_GESCOM", cn); //TSP_TGEMPRESA_IU01 
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();


                //--------------------------------------------------------------------
                param.Add("@intIdCompra", objDatos.intIdCompra);

                if (objDatos.strCodigoCompra == null) { param.Add("@strCodigoCompra", DBNull.Value); }
                else { param.Add("@strCodigoCompra", objDatos.strCodigoCompra); }

                param.Add("@intIdProducto", objDatos.intIdProducto);

                if (objDatos.strCodigoProducto == null) { param.Add("@strCodigoProducto", DBNull.Value); }
                else { param.Add("@strCodigoProducto", objDatos.strCodigoProducto); }

                param.Add("@intCantIngresada", objDatos.intCantIngresada);
                param.Add("@decCostoUnitCompra", objDatos.decCostoUnitCompra);

                if (objDatos.decMontoTotCompra == null) { param.Add("@decMontoTotCompra", DBNull.Value); }
                else { param.Add("@decMontoTotCompra", objDatos.decMontoTotCompra); }

                if (objDatos.dttFechaIngreso == null) { param.Add("@dttFechaIngreso", DBNull.Value); }
                else { param.Add("@dttFechaIngreso", objDatos.dttFechaIngreso); }

                if (objDatos.dttFechaVencimiento == null) { param.Add("@dttFechaVencimiento", DBNull.Value); }
                else { param.Add("@dttFechaVencimiento", objDatos.dttFechaVencimiento); }

                if (objDatos.strNumDocCompra == null) { param.Add("@strNumDocCompra", DBNull.Value); }
                else { param.Add("@strNumDocCompra", objDatos.strNumDocCompra); }

                if (objDatos.strDesProveedor == null) { param.Add("@strDesProveedor", DBNull.Value); }
                else { param.Add("@strDesProveedor", objDatos.strDesProveedor); }

                //if (objDatos.intStockPrevio == null) { param.Add("@intStockPrevio", DBNull.Value); }
                 param.Add("@intStockPrevio", objDatos.intStockPrevio); 

                param.Add("@intTipoOperacion", intTipoOperacion); //1: insert, 2: update

                //-------------------------------------------------------------------------
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return intResult;
        }

        #endregion INSERT/UPDATE COMPRA o INGRESO "GESCOM"



        #region COMPRRA X PK PARA EDITAR EN "GESCOM"
        //01 
        public JsonResult ObtenerCompraPorPkEditarGesCom(int intIdCompra)
        {
            string strMsgUsuario = "";

            List<TB_COMPRAS> lst = new List<TB_COMPRAS>();

            lst = ObtenerCompraPorPkBLGesCom(intIdCompra, ref strMsgUsuario).ToList();

            return Json(lst);
        }

        //02
        public List<TB_COMPRAS> ObtenerCompraPorPkBLGesCom(int intIdCompra, ref string strMsjUsuario)
        {
            List<TB_COMPRAS> lista = new List<TB_COMPRAS>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = ObtenerCompraPorPkDAOGesCom(intIdCompra, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        //Log.AlmacenarLogMensaje("[ObtenerRegistroEmpresa] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString(), "ProcesoController.cs");
                //Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                //throw new Exception("Ocurrió un error en BD (ObtenerRegistroEmpresa)");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "ProcesoController.cs");
                //Log.AlmacenarLogError(ex, "EmpresaBL.cs");
                //throw new Exception("Error General (ObtenerRegistroEmpresa)");
            }
            return lista;
        }

        //03
        public List<TB_COMPRAS> ObtenerCompraPorPkDAOGesCom(int intIdCompra, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TB_COMPRAS> lista = new List<TB_COMPRAS>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TB_COMPRAS_Q00_GESCOM_PK_EDITAR", cn); 
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("@intIdCompra", intIdCompra);

                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //POR PK
                        TB_COMPRAS obj = new TB_COMPRAS();
                        if (!reader.IsDBNull(0))  { obj.intIdCompra           = reader.GetInt32(0); };
                        if (!reader.IsDBNull(1))  { obj.strCodigoCompra       = reader.GetString(1); };
                        if (!reader.IsDBNull(2))  { obj.intIdProducto         = reader.GetInt32(2); };
                        if (!reader.IsDBNull(3))  { obj.strCodigoProducto     = reader.GetString(3); };
                        if (!reader.IsDBNull(4))  { obj.intCantIngresada      = reader.GetInt32(4); };
                        if (!reader.IsDBNull(5))  { obj.decCostoUnitCompra    = reader.GetString(5); };
                        if (!reader.IsDBNull(6))  { obj.decMontoTotCompra     = reader.GetString(6); };
                        if (!reader.IsDBNull(7))  { obj.dttFechaIngreso       = reader.GetString(7); };
                        if (!reader.IsDBNull(8))  { obj.strDescMarcaProd      = reader.GetString(8); }
                        if (!reader.IsDBNull(9))  { obj.strCodigoBarras       = reader.GetString(9); }
                        if (!reader.IsDBNull(10)) { obj.dttFechaVencimiento   = reader.GetString(10); }
                        if (!reader.IsDBNull(11)) { obj.strNumDocCompra       = reader.GetString(11); }
                        if (!reader.IsDBNull(12)) { obj.strDesProveedor       = reader.GetString(12); }
                        if (!reader.IsDBNull(13)) { obj.intStockPrevio        = reader.GetInt32(13); }
                        //-------------------------------------------------------------------------------
                        if (!reader.IsDBNull(14)) { obj.strDescProducto      = reader.GetString(14); }
                        if (!reader.IsDBNull(15)) { obj.decPrecioDeVenta      = reader.GetString(15); }
                        if (!reader.IsDBNull(16)) { obj.intCantTotalActual    = reader.GetInt32(16); }
                        if (!reader.IsDBNull(17)) { obj.decMontoProducto      = reader.GetString(17); }
                        if (!reader.IsDBNull(18)) { obj.strRutaImagenProducto = reader.GetString(18); }


                        lista.Add(obj);                  
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return lista;
        }

        #endregion PRODUCTO X PK PARA EDITAR COMPRA "GESCOM"



        #region VENTAS "GESVEN"

        //Listar
        public JsonResult ListarVentasGesVen(string strCodigoBarras, int intIdCategoria, string strVencimiento, int intIdMarcaProducto)
        {
            string strMsgUsuario = "";
            int intResult = 0;

            List<TB_VENTA_DETA> Listar = new List<TB_VENTA_DETA>();

            Listar = ListarGestionVentasBL(strCodigoBarras, intIdCategoria, strVencimiento, intIdMarcaProducto, ref intResult, ref strMsgUsuario).ToList();

            return Json(Listar);
        }

        //
        public List<TB_VENTA_DETA> ListarGestionVentasBL(string strCodigoBarras, int intIdCategoria, string strVencimiento, int intIdMarcaProducto, ref int intResult, ref string strMsjUsuario)
        {

            List<TB_VENTA_DETA> lista = new List<TB_VENTA_DETA>();
            string strMsjDB = "";

            lista = ListarGestionVentasDAO(strCodigoBarras, intIdCategoria, strVencimiento, intIdMarcaProducto, ref intResult, ref strMsjDB, ref strMsjUsuario);
            if (intResult == 0)
            {
                if (!strMsjDB.Equals(""))
                {
                    ////Log.AlmacenarLogMensaje("[ListarEmpresa] => Respuesta del Procedimiento : " + strMsjDB);
                    if (strMsjUsuario.Equals(""))
                        strMsjUsuario = strMsjDB;
                }

            }

            ////}
            ////catch (SqlException ex)
            ////{
            ////    Log.AlmacenarLogError(ex, "EmpresaBL.cs");
            ////    throw new Exception("Ocurrió un error en BD (ListarEmpresa)");
            ////}

            ////catch (Exception ex)
            ////{
            ////    Log.AlmacenarLogError(ex, "EmpresaBL.cs");
            ////    throw new Exception("Error General (ListarEmpresa)");
            ////}

            return lista;
        }

        //
        public List<TB_VENTA_DETA> ListarGestionVentasDAO(string strCodigoBarras, int intIdCategoria, string strVencimiento, int intIdMarcaProducto, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TB_VENTA_DETA> lista = new List<TB_VENTA_DETA>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TB_VENTAS_Q00_GESVEN_LISTADO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
            
                param.Add("@strVencimiento", strVencimiento);
                param.Add("@strCodigoBarras", strCodigoBarras);
                param.Add("@intIdCategoria", intIdCategoria);
                param.Add("@intIdMarcaProducto", intIdMarcaProducto);

                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //LISTADO NORMAL DE "TODOS LOS REGISTROS" NO POR PK
                    TB_VENTA_DETA obj = new TB_VENTA_DETA();
                    if (!reader.IsDBNull(0))  { obj.intIdVenta             = reader.GetInt32(0); };
                    if (!reader.IsDBNull(1))  { obj.intIdVentaCabe         = reader.GetInt32(1); };
                    if (!reader.IsDBNull(2))  { obj.intIdProducto          = reader.GetInt32(2); };
                    if (!reader.IsDBNull(3))  { obj.decPrecUnitDeVenta     = reader.GetString(3); };
                    if (!reader.IsDBNull(4))  { obj.intCantidadDeVenta     = reader.GetInt32(4); };
                    if (!reader.IsDBNull(5))  { obj.decMontoTotDeVenta     = reader.GetString(5); };
                    if (!reader.IsDBNull(6))  { obj.decCostoUnitCompra     = reader.GetString(6); };
                    if (!reader.IsDBNull(7))  { obj.decMontoGanancia       = reader.GetString(7); };
                    if (!reader.IsDBNull(8))  { obj.dttDateTimeInserted    = reader.GetString(8); };
                    if (!reader.IsDBNull(9))  { obj.dttDateTimeUpdated     = reader.GetString(9); };

                    if (!reader.IsDBNull(10)) { obj.strCodigoProducto = reader.GetString(10); };
                    if (!reader.IsDBNull(11)) { obj.strCodVenta = reader.GetString(11); };
                    //if (!reader.IsDBNull(10)) { obj.bitFlDeleted           = reader.GetString(10); };
                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        #endregion

















        /***************************************************************************************
        * 1.-  ViewVentaProductos() Para la pestaña de vender
        ***************************************************************************************/
        public JsonResult ObtenerProductoPorPkGesCom(int intIdProducto, string strCodigoBarras)
        {

            ///////////////////////////////////////////////////////////////
            CustomResponse result = new CustomResponse();
            string strMsgUsuario = "";
            int intResult = 0;
            List<TB_PRODUCTOS> Listado = new List<TB_PRODUCTOS>();

            try
            {
                Listado = ObtenerProductoPorSuPKBL(intIdProducto, strCodigoBarras, ref intResult, ref strMsgUsuario).ToList();

                int countList = Listado.Count;


                if (strMsgUsuario.Equals("") && countList > 0)
                {
                    result.type = "success";
                    result.message = "Se encontraron Registros.";

                    return Json(Listado); //EL LISTADO
                }
                else
                {
                    result.type = "info";
                    result.message = "No existe ningún Producto con el código ingresado.";

                    return Json(result); //UN MENsAJE INDICANDO QUE NO HAY LISTADO

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "ProcesoController.cs");
                throw new Exception("Error Controlador Personal"); //UNA EXCEPCION DE ERROR

            }

            //return Json(result);
            /* return Json(Listado);*///Listado  rutaDirectorio

        }



        //5.12 BL
        public List<TB_PRODUCTOS> ObtenerProductoPorSuPKBL(int intIdProducto, string strCodigoBarras, ref int intResult, ref string strMsjUsuario)
        {
            List<TB_PRODUCTOS> lista = new List<TB_PRODUCTOS>();

            string strMsjDB = "";

            lista = ObtenerProductoPorSuPKDAO(intIdProducto, strCodigoBarras, ref intResult, ref strMsjDB, ref strMsjUsuario);

            return lista;
        }

        //5.12 DAO
        public List<TB_PRODUCTOS> ObtenerProductoPorSuPKDAO(int intIdProducto, string strCodigoBarras, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TB_PRODUCTOS> lista = new List<TB_PRODUCTOS>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TB_PRODUCTOS_GESCOM_Q00_PK", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();


                param.Add("@intIdProducto", intIdProducto);
                param.Add("@strCodigoBarras", strCodigoBarras);
                //salida

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {


                        TB_PRODUCTOS obj = new TB_PRODUCTOS();

                        if (!reader.IsDBNull(0)) { obj.intIdProducto      = reader.GetInt32(0); };
                        if (!reader.IsDBNull(1)) { obj.strCodigoBarras    = reader.GetString(1); };
                        if (!reader.IsDBNull(2)) { obj.strCodigoProducto  = reader.GetString(2); };
                        if (!reader.IsDBNull(3)) { obj.strDescProducto    = reader.GetString(3); };
                        if (!reader.IsDBNull(4)) { obj.strMarcaProducto   = reader.GetString(4); };
                        if (!reader.IsDBNull(5)) { obj.decPrecioDeVenta   = reader.GetString(5); };
                        if (!reader.IsDBNull(6)) { obj.intCantTotalActual = reader.GetInt32(6); };
                        if (!reader.IsDBNull(7)) { obj.decMontoProducto   = reader.GetString(7); };
                        if (!reader.IsDBNull(8)) { obj.strRutaImagenMarca = reader.GetString(8); }
                        if (!reader.IsDBNull(9)) { obj.strRutaImagenProducto = reader.GetString(9); }
                        if (!reader.IsDBNull(10)) { obj.strDescCategoria = reader.GetString(10); }
                        if (!reader.IsDBNull(11)) { obj.strPresentacion = reader.GetString(11); }
                        //if (!reader.IsDBNull(12)) { obj.decPriceBefore = reader.GetString(12); }               

                        lista.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return lista;
        }











        #region CONEXION BASE DE DATOS

        //CONEXION BD
        public string cadCnx = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        //////public int timeSQL = Int32.Parse(ConfigurationManager.AppSettings["timeSQL"].ToString());
        protected bool Transaction(SqlConnection cn, SqlCommand cmd)
        {
            int result = 0;
            SqlTransaction objTrans = null;
            try
            {
                objTrans = cn.BeginTransaction();
                cmd.Transaction = objTrans;
                result = cmd.ExecuteNonQuery();
                objTrans.Commit();
                return true;
            }
            catch (Exception)
            {
                objTrans.Rollback();
                return false;
            }

        }

        protected void PoblarParametros(SqlCommand cmd, params object[] parametros)
        {
            // variable es la que controla el indice del vector de
            // parametros
            int indice = 0;
            // descubrir los parametros del SqlCommand enviado
            SqlCommandBuilder.DeriveParameters(cmd);
            // recorerr cada parametro a traves de un foreach
            foreach (SqlParameter oPrm in cmd.Parameters)
            {
                // si el nombre del parametro es distinto de @RETURN_VALUE
                // que estamos en un parámetro de usuario
                if (oPrm.ParameterName != "@RETURN_VALUE")
                {
                    oPrm.Value = parametros[indice];
                    indice++;
                }
            }
        }

        protected void AsignarParametros(SqlCommand cmd, Dictionary<string, object> parametros)
        {
            // descubrir los parametros del SqlCommand enviado
            SqlCommandBuilder.DeriveParameters(cmd);

            foreach (KeyValuePair<string, object> item in parametros)
            {
                if (cmd.Parameters[item.Key].SqlDbType == SqlDbType.Structured)
                {
                    string typeName = cmd.Parameters[item.Key].TypeName;
                    int positionDot = typeName.LastIndexOf(".");
                    positionDot = positionDot > 0 ? positionDot + 1 : 0;
                    cmd.Parameters[item.Key].TypeName = typeName.Substring(positionDot);
                }

                cmd.Parameters[item.Key].Value = item.Value;
            }

        }


        #endregion





//////        using System;
//////using System.Collections.Generic;
//////using System.Linq;
//////using System.Web;
//////using System.Web.Mvc;
//////using System.IO;
//////using WebNavaUtil.wsNavautil;

//////namespace WebNavaUtil.Controllers
//////    {

//////        public class CotizacionController : Controller
//////        {
            ////private wsNavautil.IwsNavautilClient proxy;

            ////public ActionResult NuevoFeriado()
            ////{
            ////    return PartialView("_PartialNuevoFeriado");//_PartialNuevoFeriado
            ////}

            ////// GET: Cotizacion
            ////public ActionResult GenerarCotizacion()
            ////{
            ////    //return View();
            ////    if (Session["NavaUsert"] != null)
            ////    {
            ////        wsNavautil.Usuario usuario = (wsNavautil.Usuario)Session["NavaUsert"];

            ////        DateTime dateStart = DateTime.Now;
            ////        DateTime dateEnd = DateTime.Now;
            ////        var clientes = WSListarCliente(usuario.empresa);
            ////        //var clientes = WSListarCliente(usuario.empresa, dateStart, dateEnd);
            ////        ViewBag.VENDEDOR = new SelectList(WSlistarVendedor(), "codven", "nomven");

            ////        //CONDICION 
            ////        ViewBag.CONDICION = new SelectList(WSlistarCondicion(), "cboCod", "cboDes");
            ////        //TIP DE CAMBIO
            ////        //ViewBag.TIPOCAMBIO = new SelectList(WSlistarTipoCambio(), "cboCod", "cboDes").FirstOrDefault();
            ////        IList<ComboGeneral> list = WSlistarTipoCambio();
            ////        ViewBag.TIPOCAMBIO = list[0].cboDes;

            ////        //AÑADIDO PARA COTIZACION HGM 02.09.2021                
            ////        ViewBag.ALMACEN = new SelectList(WSlistarAlmacen(usuario.empresa), "codalm", "nomalm");
            ////        ViewBag.FAMILIA = new SelectList(WSlistarLinea(usuario.empresa), "codfam", "nomfam");


            ////        //ViewModel mymodel = new ViewModel();
            ////        //mymodel.Teachers = GetTeachers();
            ////        //mymodel.Students = GetStudents();
            ////        var productos = new List<Producto>();

            ////        object[] datos = { clientes, productos };

            ////        //return View(clientes);
            ////        return View(datos);
            ////    }
            ////    else
            ////        return RedirectToAction("LoginNavautil", "Login");

            ////}







            #region cotizaciones


      
            //PREGUARDADO PARA COTIZACION HGM 14.10.2021
            ////////[HttpPost]
            ////////public PartialViewResult getDatosPreGuardado(string strFiltro)
            ////////{
            ////////    Usuario usuario = null;
            ////////    if (Session["NavaUsert"] != null)
            ////////    {
            ////////        usuario = (Usuario)Session["NavaUsert"];

            ////////        Producto obj = null;
            ////////        ViewBag.TIPOENTREGA = new SelectList(WSlistarCombo("TIPOENTREGA", ""), "cboCod", "cboDes");
            ////////        ViewBag.TRANSPORTISTA = new SelectList(WSlistarCombo("TRANSPORTISTA", ""), "cboCod", "cboDes");
            ////////        ViewBag.ATENCION = new SelectList(WSlistarCombo("ATENCION", strFiltro), "cboCod", "cboDes");

            ////////        return PartialView("_partialModalPreGuardado");

            ////////    }
            ////////    else
            ////////        return PartialView("_partialSessionExpired");
            ////////}




            //////////////[HttpPost]
            //////////////public JsonResult jsonFiltrarProductoCotiz(string codSubFam, string desGrupo, string codAlmac, string estado, string codProdu, string descProdu, string tcam, string mone)
            //////////////{
            //////////////    Usuario usuario = null;
            //////////////    if (Session["NavaUsert"] != null)
            //////////////    {
            //////////////        usuario = (Usuario)Session["NavaUsert"];

            //////////////        if (estado.Equals(""))
            //////////////            estado = "1";
            //////////////        List<Producto> listaProdu = wsListarProductoCotiz(usuario.empresa, codSubFam, desGrupo, codAlmac, estado, codProdu, descProdu, tcam, mone);

            //////////////        var json = Json(listaProdu);
            //////////////        json.MaxJsonLength = 500000000;
            //////////////        return json;
            //////////////    }
            //////////////    else
            //////////////        return Json(new { type = "error", message = "session expired" });

            //////////////}

            //////private List<Producto> wsListarProductoCotiz(string empresa, string codSubFam = "", string desGrupo = "", string codAlmac = "", string estado = "", string codProdu = "", string descProdu = "", string tcam = "", string mone = "")
            //////{
            //////    List<Producto> listaProdu = new List<Producto>();
            //////    try
            //////    {
            //////        proxy = new IwsNavautilClient();
            //////        listaProdu = proxy.ListarProdStockCotiz(empresa, codSubFam, "01", desGrupo, codAlmac, estado, codProdu, descProdu, tcam, mone).ToList();
            //////        proxy.Close();
            //////    }
            //////    catch (Exception ex)
            //////    {
            //////        throw new Exception(ex.Message);
            //////    }

            //////    return listaProdu;
            //////}


            //////TRAER IGV PRUEBA
            ////public JsonResult getIgvCotizacion(string strfiltroCombo, string strSegundoFiltro)
            ////{

            ////    List<wsNavautil.ComboGeneral> list = new List<wsNavautil.ComboGeneral>();
            ////    try
            ////    {
            ////        wsNavautil.Usuario usuario = null;
            ////        if (Session["NavaUsert"] != null)
            ////        {
            ////            usuario = (wsNavautil.Usuario)Session["NavaUsert"];
            ////            proxy = new wsNavautil.IwsNavautilClient();
            ////            list = proxy.ListarComboGeneral(usuario.empresa, strfiltroCombo, strSegundoFiltro).ToList();
            ////            proxy.Close();
            ////        }
            ////        else
                
            ////            return Json(list);
            ////    }
            ////    catch (Exception ex)
            ////    {

            ////        throw new Exception(ex.Message);
            ////    }
        


            ////    return Json(list);


            ////}

            ////////TRAER CRRELATIVO
            //////public JsonResult getCorrelativoCotizacion()
            //////{
            //////    string cNroDocu = "";
            //////    List<wsNavautil.Correlativo> list = new List<wsNavautil.Correlativo>();
            //////    try
            //////    {
            //////        wsNavautil.Usuario usuario = null;
            //////        if (Session["NavaUsert"] != null)
            //////        {
            //////            usuario = (wsNavautil.Usuario)Session["NavaUsert"];
            //////            proxy = new wsNavautil.IwsNavautilClient();
            //////            list = proxy.getCorrelativoCotizacion(usuario.empresa, ref cNroDocu).ToList();
            //////            proxy.Close();
            //////        }
            //////        else

            //////            return Json(cNroDocu);
            //////    }
            //////    catch (Exception ex)
            //////    {

            //////        throw new Exception(ex.Message);
            //////    }

            //////    string root = Server.MapPath("~");//
            //////    string parent = Path.GetDirectoryName(root);
            //////    string grandParent = Path.GetDirectoryName(parent);


            //////    url = (System.Web.HttpContext.Current.Request.Url.AbsoluteUri).Replace("/LoginSiscop/LoginSiscop/", "");
            //////    var context = System.Web.HttpContext.Current;
            //////    string ip = String.Empty;

            //////    if (context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            //////        ip = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            //////    else if (!String.IsNullOrWhiteSpace(context.Request.UserHostAddress))
            //////        ip = context.Request.UserHostAddress;

            //////    if (ip == "::1")
            //////        ip = "127.0.0.1";

            //////    strIpHost = ip;



            //////    return Json(cNroDocu);

            //////}

            //CLASE MODELO PARA EL LISTADO DESDE EL JS
            public class listado_cabecera_cotiz
            {
                public string rucCliente { get; set; }
                public string nomCliente { get; set; }
                public string condVenta { get; set; }
                public string moneda { get; set; }
                public string vendedor { get; set; }
                public string codCliente { get; set; }
                public string dirClient { get; set; }
                public string tlfCliente { get; set; }
                public string atteCliente { get; set; }
                public string Observacion { get; set; }
            }

            public static listado_cabecera_cotiz DatosEncabezado;//añadido 02.11.2021
            public JsonResult SetDatosEncabezado(string _rucCliente, string _nomCliente, string _codCliente, string _dirEntCliente, string _tlfCliente, string _atte, string _obser2)
            {
                try
                {
                    listado_cabecera_cotiz ObjCabecera = new listado_cabecera_cotiz();
                    ObjCabecera.rucCliente = _rucCliente;
                    ObjCabecera.nomCliente = _nomCliente;
                    ObjCabecera.codCliente = _codCliente;
                    ObjCabecera.dirClient = _dirEntCliente;
                    ObjCabecera.tlfCliente = _tlfCliente;
                    ObjCabecera.atteCliente = _atte;
                    ObjCabecera.Observacion = _obser2;

                    DatosEncabezado = ObjCabecera;
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
                return Json("");
            }





            #endregion


            public static string url { get; set; }
            public static string texto { get; set; }
            public static string textoConfig { get; set; }
            public static string pieConfig { get; set; }
            public static string strIpHost { get; set; }

            //OBTENER EL IP CON CODIGIGO C# - A Nivel WebSite
            public string GetUserIPAddress()
            {

                url = (System.Web.HttpContext.Current.Request.Url.AbsoluteUri).Replace("/LoginSiscop/LoginSiscop/", "");
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









    //////    }
    //////}






    }
}
