using Dominio.Entidades;
using Dominio.Entidades.Sistema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;


namespace Infraestructura.Data.SqlServer
{
    
   public class TSConfiDAO:Conexion
    {

        #region SAF Mant. Configuracion

        //11.1 listar Configuraciones para mostrarse en la ventana de Configuración.
        public List<TSParamsSaf> ListarConfigInicialSaf(Session_Movi objSession, string strCoConfi, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TSParamsSaf> listaConf = new List<TSParamsSaf>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSPARAMS_Q00", cn); //TSP_TSCONFI_Q01 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                //param.Add("@strCoConfi", strCoConfi);

                //salida
                param.Add("@intResult", 1);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TSParamsSaf obj = new TSParamsSaf();

                        obj.prmSalidaApp     = reader.GetString(0);
                        obj.prmAddOfic       = reader.GetString(1);
                        obj.prmAddResp       = reader.GetString(2);
                        obj.prmFilUbica      = reader.GetString(3);
                        obj.prmOpcOpera      = reader.GetString(4);
                        obj.prmAreaxLocal    = reader.GetString(5);
                        obj.prmModaTrab      = reader.GetString(6);
                        obj.prmOutExcelxLocal= reader.GetString(7);
                        obj.prmImpresora     = reader.GetString(8);

                        //obj.intIdConfi = reader.GetInt32(0);
                        //obj.strCoConfi = reader.GetString(1);
                        //obj.strValorConfi = reader.GetString(2);
                        //obj.tipoControl = reader.GetString(3);
                        //obj.bitFlActivo = reader.GetBoolean(4);

                        listaConf.Add(obj);
                    }
                }
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listaConf;
        }

        //11.2 Actualizar configuraciones de la Ventana de Configuración.  --UpdateDetalleConfig
        public bool ActualizarDetalleConfigSaf(Session_Movi objSession, string prmSalidaApp, string prmAddOfic, string prmAddResp, string prmFilUbica, string prmOpcOpera, string prmAreaxLocal, string prmModaTrab, string prmOutExcelxLocal, string prmImpresora, string strEmailDestino, string strParametro, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool tudobem = false;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSPARAMS_U00", cn); 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                //--------------------------------------------------
                param.Add("@prmSalidaApp", prmSalidaApp);
                param.Add("@prmAddOfic", prmAddOfic);
                param.Add("@prmAddResp", prmAddResp);
                param.Add("@prmFilUbica", prmFilUbica);
                param.Add("@prmOpcOpera", prmOpcOpera);
                param.Add("@prmAreaxLocal", prmAreaxLocal);
                param.Add("@prmModaTrab", prmModaTrab);
                param.Add("@prmOutExcelxLocal", prmOutExcelxLocal);
                param.Add("@prmImpresora", prmImpresora);
                param.Add("@strEmailDestino", strEmailDestino);
                param.Add("@strParametro", strParametro);
                //--------------------------------------------------

                //Parámetros de Salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

                tudobem = true;
            }
            return tudobem;
        }

        //11.3
        public bool GuardarConexionBaseDatosSqlSaf(Session_Movi objSession, string strServidor, string strBaseDatos, string strUsuario, string strContrasenia, string strAutenticacion, string strDirExcelCarga, string strExcelGenerado, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool todobien = false;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSPARAMS_CONEXION_BD_I00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                //Encriptar Clave Contraseña
                byte[] byt = System.Text.Encoding.UTF8.GetBytes(strContrasenia);
                string strNwPassw = Convert.ToBase64String(byt);

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                //Parámetros de Entrada
                //--------------------------------------------------
                param.Add("@strServidor", strServidor);
                param.Add("@strBaseDatos", strBaseDatos);
                param.Add("@strUsuario", strUsuario);
                param.Add("@strContrasenia", strNwPassw);
                param.Add("@strAutenticacion", strAutenticacion);
                param.Add("@strDirExcelCarga", strDirExcelCarga);
                param.Add("@strExcelGenerado", strExcelGenerado);
                //--------------------------------------------------
                //Parámetros de Salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

                todobien = true;
            }
            return todobien;
        }

        //11.4 
        public List<TSParamsSaf> ListarConfigConexionBaseDeDatos(Session_Movi objSession, string strCoConfi, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TSParamsSaf> listaConf = new List<TSParamsSaf>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSPARAMS_CONEXION_Q00", cn); //TSP_TSCONFI_Q01 //TSP_TSPARAMS_Q00
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                //param.Add("@strCoConfi", strCoConfi);

                //salida
                param.Add("@intResult", 1);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TSParamsSaf obj = new TSParamsSaf();

                        byte[] b = Convert.FromBase64String(reader.GetString(3));
                        string strcontraseñaDesenciptada = System.Text.Encoding.UTF8.GetString(b);

                        obj.strServidor       =  reader.GetString(0);
                        obj.strBaseDatos      =  reader.GetString(1);
                        obj.strUsuario        =  reader.GetString(2);
                        obj.strContrasenia    =  strcontraseñaDesenciptada;
                        obj.strAutenticacion  =  reader.GetString(4);
                        obj.strDirExcelCarga  =  reader.GetString(5);
                        obj.strExcelGenerado  =  reader.GetString(6);


                        //obj.prmSalidaApp =  reader.GetString(0);
                        //obj.prmAddOfic =    reader.GetString(1);
                        //obj.prmAddResp =    reader.GetString(2);
                        //obj.prmFilUbica =   reader.GetString(3);
                        //obj.prmOpcOpera =   reader.GetString(4);
                        //obj.prmAreaxLocal = reader.GetString(5);
                        //obj.prmModaTrab =   reader.GetString(6);
                        //obj.prmOutExcelxLocal = reader.GetString(7);
                        //obj.prmImpresora = reader.GetString(8);

                        //obj.intIdConfi = reader.GetInt32(0);
                        //obj.strCoConfi = reader.GetString(1);
                        //obj.strValorConfi = reader.GetString(2);
                        //obj.tipoControl = reader.GetString(3);
                        //obj.bitFlActivo = reader.GetBoolean(4);

                        listaConf.Add(obj);
                    }
                }
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listaConf;
        }


        #endregion


        //8.5
        public TSConfi ConsultarTSConfi_xCod(long intIdSesion,int intIdMenu,int intIdSoft,string strCoConfi, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            TSConfi objConfi = null;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSCONFI_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@strCoConfi", strCoConfi);
                //salida
                param.Add("@intResult", 1);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    objConfi = new TSConfi();
                    objConfi.intIdConfi = reader.GetInt32(0);
                    objConfi.strCoConfi = reader.GetString(1);
                    objConfi.strDesConfi = reader.GetString(2);
                    objConfi.strValorConfi = reader.GetString(3);
                    objConfi.strPosibValor = reader.GetString(4);
                }
                reader.Close();
                
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return objConfi;
        }

        //1.16 listar Configuraciones para mostrarse en la ventana de Configuración.
        public List<TSConfi> ListarConfig(Session_Movi objSession, string strCoConfi, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TSConfi> listaConf= new List<TSConfi>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSCONFI_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@strCoConfi", strCoConfi);
                //salida
                param.Add("@intResult", 1);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TSConfi obj = new TSConfi();

                        obj.intIdConfi = reader.GetInt32(0);
                        obj.strCoConfi = reader.GetString(1);
                        obj.strValorConfi = reader.GetString(2);
                        obj.tipoControl = reader.GetString(3);
                        obj.bitFlActivo = reader.GetBoolean(4);

                        listaConf.Add(obj);
                    }
                }
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listaConf;
        }

        //1.17 Actualizar configuraciones de la ventana de Configuración.
        public bool UpdateDetalleConfig(Session_Movi objSession, DataTable tt_config, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool tudobem = false;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSCONFI_U01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@TT_TSCONFI", tt_config);
                //Parámetros de Salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

                tudobem = true;
            }
            return tudobem;
        }
   
        //método de prueba 13.04.2021
        public EN_TMEncuesta Datos_EnviarRespuesta_Encuesta_JSql(string JSON)
        {
            EN_TMEncuesta obj = new EN_TMEncuesta();
            string strRespuesta = "";
            //int IDTEMP = 0;
            try
            {
                var deserealize = new JavaScriptSerializer();
                List<EN_TMEncuesta> listaBoletos = deserealize.Deserialize<List<EN_TMEncuesta>>(JSON);
                EN_TMEncuesta objBol = null;

                DataTable dt = new DataTable();
                dt.Columns.Add("ID_ENCUESTA_PREGUNTA_OPCION_RESPUESTA", typeof(string));
                dt.Columns.Add("ID_ENCUESTA_PREGUNTA", typeof(string));
                dt.Columns.Add("NOM_ENCUESTA_PREGUNTA_OPCION", typeof(string));
                //IDTEMP = Convert.ToInt32(DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second);

                using (SqlConnection cn = new SqlConnection(cadCnx))
                {
                    cn.Open();
                    using (SqlTransaction trans = cn.BeginTransaction())
                    {
                        try
                        {
                            for (int i = 0; i < listaBoletos.Count; i++)
                            {
                                objBol = new EN_TMEncuesta();
                                objBol = listaBoletos[i];

                                DataRow rows = dt.NewRow();
                                rows[0] = objBol.ID_ENCUESTA_PREGUNTA_OPCION_RESPUESTA;
                                rows[1] = objBol.ID_ENCUESTA_PREGUNTA;
                                rows[2] = objBol.NOM_ENCUESTA_PREGUNTA_OPCION;
                                SqlDataReader reader;
                                using (SqlCommand cmd = new SqlCommand("USP_TECFLEX_ENCUESTA_PREGUNTA_OPCION_RESPUESTA_REGISTRAR", cn))
                                {
                                    cmd.Transaction = trans;
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.Add("ID_ENCUESTA_PREGUNTA_OPCION_RESPUESTA", SqlDbType.Int).Value = int.Parse(objBol.ID_ENCUESTA_PREGUNTA_OPCION_RESPUESTA);
                                    cmd.Parameters.Add("ID_ENCUESTA_PREGUNTA", SqlDbType.TinyInt).Value = int.Parse(objBol.ID_ENCUESTA_PREGUNTA);
                                    cmd.Parameters.Add("NOM_ENCUESTA_PREGUNTA_OPCION", SqlDbType.VarChar).Value = objBol.NOM_ENCUESTA_PREGUNTA_OPCION;

                                    reader = cmd.ExecuteReader();
                                    if (reader.HasRows)
                                    {
                                        while (reader.Read())
                                        {
                                            obj.IND_OPERACION = reader.GetInt32(0);
                                            obj.FEC_ENCUESTA_COMPLETADA = reader.GetString(1);
                                        }
                                        cmd.Dispose();
                                    }
                                    reader.Close();
                                }
                                //cn.Close();
                            }
                        }
                        catch (Exception ex)
                        {
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
                strRespuesta = "No se pudo completar la insercion de las respuestas: " + ex.Message;
                //if (Context.Trace.IsEnabled)
                //    Context.Trace.Warn("Método Datos_EnviarRespuesta_Encuesta_JSql", strRespuesta);

                //throw new SoapException(strRespuesta, SoapException.ClientFaultCode);
            }
            return obj;
        }


        //CAMBIOS AÑADIDOS JULIO - ESUYON
        #region CAMBIOSJULIO
        public List<TSConfi> ListarCliWeb(ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TSConfi> listaConf = new List<TSConfi>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSCLI_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                //salida
                param.Add("@intResult", 1);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TSConfi obj = new TSConfi();
                        obj.strValorConfi = reader.GetString(0);
                        listaConf.Add(obj);
                    }
                }
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listaConf;
        }

        public bool ICliWeb(string IPCli, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool tudobem = false;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSCLI_I00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@IPCli", IPCli);
                //Parámetros de Salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

                tudobem = true;
            }
            return tudobem;
        }

        #endregion CAMBIOSJULIO


    }
}
