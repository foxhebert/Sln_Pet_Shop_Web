using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data.SqlServer
{
    public class MarcaManualDAO : Conexion
    {
        //2.67
        public List<AsigHorarioData> GetEmpleados(Session_Movi objSession, int intActivoFilter, string strfilter, int IntIdEmp, string dttfiltrofch1, string dttfiltrofch2, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<AsigHorarioData> lista = new List<AsigHorarioData>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPERS_HORARIO_DET_Q02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);


                param.Add("@intActivo", intActivoFilter);
                param.Add("@strfilter", strfilter);
                param.Add("@intIdEmp", IntIdEmp);
                param.Add("@dttfiltrofch1", Convert.ToString(dttfiltrofch1));
                param.Add("@dttfiltrofch2", Convert.ToString(dttfiltrofch2));
                param.Add("@intIdUsuario", objSession.intIdUsuario);
                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AsigHorarioData obj = new AsigHorarioData();

                    obj.intIdPerHorario = reader.GetInt32(0);
                    obj.strCoPersonal = reader.GetString(1);
                    obj.strNombres = reader.GetString(2);
                    obj.strNumDoc = reader.GetString(3);
                    obj.dttFechAsig = reader.GetString(4);
                    obj.strDesEmp = reader.GetString(5);
                    obj.strEstado = reader.GetString(6);
                    obj.strFotoCheck = reader.GetString(7);

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //2.68
        public List<AsistenciaData> GetAsistencias(Session_Movi objSession, int intIdPersonal, string dttfiltrofch1, string dttfiltrofch2, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<AsistenciaData> lista = new List<AsistenciaData>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TAASISTENCIA_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);


                param.Add("@intIdPersonal", intIdPersonal);
                param.Add("@dttFechaDesde", dttfiltrofch1);
                param.Add("@dttFechaHasta", dttfiltrofch2);
                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AsistenciaData obj = new AsistenciaData();
                    obj.intIdAsistencia = reader.GetInt64(0);
                    obj.intIdPersonal = reader.GetInt32(1);
                    obj.dttFechaHora = reader.GetString(2);
                    obj.strMarcador = reader.GetString(4);
                    obj.strTipoMarca = reader.GetString(3);
                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //2.69
        public bool EliminarMarca(Session_Movi objSession, long intIdAsistencia, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool result = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TAASISTENCIA_D02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdUsuario", objSession.intIdUsuario);
                param.Add("@intIdAsistencia", intIdAsistencia);
                //Parámetros de Salida                              
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                result = Transaction(cn, cmd);

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return result;
        }
        //2.70
        public List<Dictionary<string, string>> Guardar(Session_Movi objSession, Asistencia objAsistencia, DataTable tb, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TAASISTENCIA_I01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdUsuario", objSession.intIdUsuario);
                //Parametros fechas
                //param.Add("@intIdAsistencia", objAsistencia.intIdAsistencia);
                param.Add("@intIdPersonal", objAsistencia.intIdPersonal);
                param.Add("@strFotocheck", objAsistencia.strFotoCheck);
                param.Add("@intIdMarcador", objAsistencia.intIdMarcador);
                param.Add("@intIdMotivo", objAsistencia.intIdMotivo);
                param.Add("@strAsistCampo1", objAsistencia.strAsistCampo1);
                param.Add("@strAsistCampo2", objAsistencia.strAsistCampo2);
                param.Add("@strAsistCampo3", objAsistencia.strAsistCampo3);
                param.Add("@strAsistCampo4", objAsistencia.strAsistCampo4);
                param.Add("@strAsistCampo5", objAsistencia.strAsistCampo5);
                param.Add("@TT_TAMARCAMANUAL", tb);
                //Parámetros de Salida                              
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                //result = Transaction(cn, cmd);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Dictionary<string, string> obj = new Dictionary<string, string>();
                    obj["key"] = reader.GetString(7);
                    obj["value"] = reader.GetString(8);
                    result.Add(obj);
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return result;
        }
        //2.71
        public Dictionary<string, string> GetMarcasHorario(Session_Movi objSession, int intIdPersonal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            Dictionary<string, string> objeto = new Dictionary<string, string>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_DASHBOARD_Q03", cn);//TSP_TAASISTENCIA_Q03TSP_DASHBOARD_CABECERA_Q00
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);

                param.Add("@intIdPersonal", intIdPersonal);
                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objeto.Add("HI", reader.GetString(0));
                    objeto.Add("SD", reader.GetString(1));
                    objeto.Add("ID", reader.GetString(2));
                    objeto.Add("HS", reader.GetString(3));
                    objeto.Add("IE", reader.GetString(4));
                    objeto.Add("SE", reader.GetString(5));

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return objeto;
        }
        //2.72
        public Asistencia getAsistenciaXID(Session_Movi objSession, int intIdAsistencia, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            Asistencia objeto = new Asistencia();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TAASISTENCIA_Q04", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);

                param.Add("@intIdAsistencia", intIdAsistencia);
                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objeto.intIdAsistencia = reader.GetInt64(0);
                    objeto.intIdPersonal = reader.GetInt32(1);
                    objeto.intDiaSgt = reader.GetInt32(3);
                    objeto.dttFechaHora = reader.GetString(4);
                    objeto.intIdMarcador = reader.GetInt32(8);
                    if (!reader.IsDBNull(9))
                    {
                        objeto.intIdMotivo = reader.GetInt32(9);
                    }
                    if (!reader.IsDBNull(30))
                    {
                        objeto.bitFlRepetido = reader.GetBoolean(30);
                    }
                    if (!reader.IsDBNull(31))
                    {
                        objeto.strRepetido = reader.GetString(31);
                    }
                    if (!reader.IsDBNull(32))
                    {
                        objeto.intIdTipoMarca = reader.GetInt32(32);
                    }
                    objeto.intModomarca = reader.GetInt32(33);
                    if (!reader.IsDBNull(34))
                    {
                        objeto.strRutaFoto = reader.GetString(34);
                    }
                    if (!reader.IsDBNull(35))
                    {
                        objeto.strCodTipoMarca = reader.GetString(35);
                    }
                    if (!reader.IsDBNull(36))
                    {
                        objeto.strDireccion_marca = reader.GetString(36);
                    }

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return objeto;
        }
        //2.73
        public bool ActualizarMarca(Session_Movi objSession, Asistencia objAsistencia, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool result = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TAASISTENCIA_U01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdUsuario", objSession.intIdUsuario);

                param.Add("@strFotocheck", objAsistencia.strFotoCheck);
                param.Add("@intTipoIngreso", objAsistencia.intTipoIngreso);
                param.Add("@tinIdTMarcacion", objAsistencia.tinIdTMarcacion);
                param.Add("@strMotivo", "");
                param.Add("@biFlMarcaForzada", objAsistencia.biFlMarcaForzada);
                param.Add("@strIncidencia", objAsistencia.strIncidencia);
                param.Add("@intIdGrupo", objAsistencia.intIdGrupo);
                param.Add("@intIdCultivo", objAsistencia.intIdCultivo);
                param.Add("@intIdActividad", objAsistencia.intIdActividad);
                param.Add("@intIdSubActividad", objAsistencia.intIdSubActividad);
                param.Add("@bitFlFicticio", objAsistencia.bitFlFicticio);
                param.Add("@strActualizado", 0);
                param.Add("@strAsistCampo1", objAsistencia.strAsistCampo1);
                param.Add("@strAsistCampo2", objAsistencia.strAsistCampo2);
                param.Add("@strAsistCampo3", objAsistencia.strAsistCampo3);
                param.Add("@strAsistCampo4", objAsistencia.strAsistCampo4);
                param.Add("@strAsistCampo5", objAsistencia.strAsistCampo5);

                param.Add("@intIdAsistencia", objAsistencia.intIdAsistencia);
                param.Add("@intIdPersonal", objAsistencia.intIdPersonal);
                param.Add("@intIdMarcador", objAsistencia.intIdMarcador);
                param.Add("@intIdMotivo", objAsistencia.intIdMotivo);
                param.Add("@intIdTipoMarca", objAsistencia.intIdTipoMarca);
                param.Add("@dttFecha", objAsistencia.dttFecha);
                param.Add("@dttFechaHora", objAsistencia.dttFechaHora);
                param.Add("@bitFlRepetido", objAsistencia.bitFlRepetido);
                param.Add("@strRepetido", objAsistencia.strRepetido);
                //param.Add("@intTipoOperacion", 2);
                //Parámetros de Salida                              
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                result = Transaction(cn, cmd);

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return result;
        }
        //2.74
        public Dictionary<string, string> GetUltimaMarca(Session_Movi objSession, int intIdPersonal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            Dictionary<string, string> objeto = new Dictionary<string, string>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TAASISTENCIA_Q05", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);

                param.Add("@intIdPersonal", intIdPersonal);
                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objeto.Add("HI", reader.GetString(0));
                    objeto.Add("SD", reader.GetString(1));
                    objeto.Add("ID", reader.GetString(2));
                    objeto.Add("HS", reader.GetString(3));
                    objeto.Add("IE", reader.GetString(4));
                    objeto.Add("SE", reader.GetString(5));
                    if (!reader.IsDBNull(6))
                    {
                        objeto.Add("Fecha", reader.GetString(6));
                    }
                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return objeto;
        }
        //2.77
        public bool validarAsistencia(Session_Movi objSession, Asistencia objAsistencia, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool result = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TAASISTENCIA_V01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdAsistencia", objAsistencia.intIdAsistencia);
                param.Add("@intIdPersonal", objAsistencia.intIdPersonal);
                param.Add("@strFotocheck", objAsistencia.strFotoCheck);
                param.Add("@dttFecha", objAsistencia.dttFecha);
                param.Add("@dttFechaHora", objAsistencia.dttFechaHora);
                param.Add("@intTipoIngreso", objAsistencia.intTipoIngreso);
                param.Add("@tinIdTMarcacion", objAsistencia.tinIdTMarcacion);
                param.Add("@intIdMarcador", objAsistencia.intIdMarcador);
                param.Add("@intIdMotivo", objAsistencia.intIdMotivo);
                param.Add("@biFlMarcaForzada", objAsistencia.biFlMarcaForzada);
                param.Add("@strIncidencia", objAsistencia.strIncidencia);
                param.Add("@intIdGrupo", objAsistencia.intIdGrupo);
                param.Add("@intIdCultivo", objAsistencia.intIdCultivo);
                param.Add("@intIdActividad", objAsistencia.intIdActividad);
                param.Add("@intIdSubActividad", objAsistencia.intIdSubActividad);
                param.Add("@bitFlFicticio", objAsistencia.bitFlFicticio);
                param.Add("@strActualizado", 0);
                param.Add("@strAsistCampo1", objAsistencia.strAsistCampo1);
                param.Add("@strAsistCampo2", objAsistencia.strAsistCampo2);
                param.Add("@strAsistCampo3", objAsistencia.strAsistCampo3);
                param.Add("@strAsistCampo4", objAsistencia.strAsistCampo4);
                param.Add("@strAsistCampo5", objAsistencia.strAsistCampo5);
                param.Add("@intIdUsuario", objSession.intIdUsuario);
                //Parámetros de Salida                              
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                result = Transaction(cn, cmd);

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return result;
        }
    }
}
