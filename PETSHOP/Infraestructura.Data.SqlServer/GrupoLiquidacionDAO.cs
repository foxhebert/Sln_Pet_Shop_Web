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
    public class GrupoLiquidacionDAO: Conexion
    {
        //6.8
        public List<GrupoLiquidacionData> ListGrupoLiquidacion(Session_Movi session, int filtroUniOrg, int filtroPlanilla, string filtroGrupoLiquidacion, int filtroActivo, int filtroPeriodo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<GrupoLiquidacionData> lista = new List<GrupoLiquidacionData>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGGRUPOLIQ_Q02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);
                
                param.Add("@filtroUniOrg", filtroUniOrg);
                param.Add("@filtroPlanilla", filtroPlanilla);
                param.Add("@filtroGrupoLiquidacion", filtroGrupoLiquidacion);
                param.Add("@filtroActivo", filtroActivo);
                param.Add("@filtroPeriodo", filtroPeriodo);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    GrupoLiquidacionData obj = new GrupoLiquidacionData();
                    obj.intIdGrupoLiq = reader.GetInt32(0);
                    obj.strCoGrupoLiq = reader.GetString(1);
                    obj.strDesGrupoLiq = reader.GetString(2);
                    obj.strDesPeriodo = reader.GetString(4);
                    obj.strEstadoActivo = reader.GetString(12);

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //6.9
        public bool EliminarGrupoLiquidacion(Session_Movi session, int intIdGrupoLiq, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGGRUPOLIQ_D02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);
                param.Add("@intIdUsuario", session.intIdUsuario);

                param.Add("@intIdGrupoLiq", intIdGrupoLiq);

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
        //6.10
        public GrupoLiquidacion ObtenerGrupoLiquidacionPorsuPK(Session_Movi objSession, int intIdGrupoLiq, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            GrupoLiquidacion obj = new GrupoLiquidacion();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGGRUPOLIQ_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);

                param.Add("@intIdGrupoLiq", intIdGrupoLiq);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        obj.intIdGrupoLiq = reader.GetInt32(0);
                        obj.strCoGrupoLiq = reader.GetString(1);
                        obj.strDesGrupoLiq = reader.GetString(2);
                        obj.intIdPeriodo = reader.GetInt32(3);

                        if (!reader.IsDBNull(5))
                        {
                            obj.strGrupoLiqCampo1 = reader.GetString(5);
                        }
                        if (!reader.IsDBNull(6))
                        {
                            obj.strGrupoLiqCampo2 = reader.GetString(6);
                        }
                        if (!reader.IsDBNull(7))
                        {
                            obj.strGrupoLiqCampo3 = reader.GetString(7);
                        }
                        if (!reader.IsDBNull(8))
                        {
                            obj.strGrupoLiqCampo4 = reader.GetString(8);
                        }
                        if (!reader.IsDBNull(9))
                        {
                            obj.strGrupoLiqCampo5 = reader.GetString(9);
                        }

                        obj.bitFlActivo = reader.GetBoolean(11);
                        obj.intIdPlanilla = reader.GetInt32(17);
                        obj.intIdUniOrg = reader.GetInt32(18);
                        obj.intIdJerOrg = reader.GetInt32(19);
                    }

                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return obj;
        }
        //6.11
        public int IUGrupoLiquidacion(Session_Movi session, GrupoLiquidacion GrupoLiquidacion, int intTipoOperacion, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            int result = 0;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGGRUPOLIQ_IU01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);
                param.Add("@intIdUsuario", session.intIdUsuario);

                param.Add("@intIdGrupoLiq", GrupoLiquidacion.intIdGrupoLiq);
                param.Add("@strCoGrupoLiq", GrupoLiquidacion.strCoGrupoLiq);
                param.Add("@strDesGrupoLiq", GrupoLiquidacion.strDesGrupoLiq);
                param.Add("@intIdPeriodo", GrupoLiquidacion.intIdPeriodo);
                param.Add("@strGrupoLiqCampo1", GrupoLiquidacion.strGrupoLiqCampo1);
                param.Add("@strGrupoLiqCampo2", GrupoLiquidacion.strGrupoLiqCampo2);
                param.Add("@strGrupoLiqCampo3", GrupoLiquidacion.strGrupoLiqCampo3);
                param.Add("@strGrupoLiqCampo4", GrupoLiquidacion.strGrupoLiqCampo4);
                param.Add("@strGrupoLiqCampo5", GrupoLiquidacion.strGrupoLiqCampo5);
                param.Add("@bitFlCerrado", false);
                param.Add("@bitFlActivo", GrupoLiquidacion.bitFlActivo);
                param.Add("@intTipoOperacion", intTipoOperacion);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                result = cmd.ExecuteNonQuery();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return result;
        }

    }
}
