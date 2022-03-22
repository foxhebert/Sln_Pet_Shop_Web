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
    public class PeriodoDAO : Conexion
    {
        //6.1
        public List<PeriodoData> ListPeriodoPago(Session_Movi session, string filtroPeriodo, int filtroActivo, int filtroSituacion, string filtrojer_ini, string filtrojer_fin, int intIdPlanilla, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<PeriodoData> lista = new List<PeriodoData>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPERIODO_Q02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@filtroPeriodo", filtroPeriodo);
                param.Add("@filtroActivo", filtroActivo);
                param.Add("@filtroSituacion", filtroSituacion);
                param.Add("@filtrojer_ini", filtrojer_ini);
                param.Add("@filtrojer_fin", filtrojer_fin);
                param.Add("@intIdPlanilla", intIdPlanilla);
                

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    PeriodoData obj = new PeriodoData();
                    //Estado objEstado = new Estado();
                    obj.intIdPeriodo = reader.GetInt32(0);
                    obj.strCoPeriodo = reader.GetString(1);
                    obj.strDesPeriodo = reader.GetString(2);
                    obj.strMesAnio = reader.GetString(3);
                    obj.strDesPlani = reader.GetString(4);
                    obj.strDependencia = reader.GetString(5);
                    obj.strEstadoCerrado = reader.GetString(6);
                    obj.strEstadoActivo = reader.GetString(7);

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //6.2
        public bool EliminarPeriodo(Session_Movi session, int intIdPeriodo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPERIODO_D02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);
                param.Add("@intIdUsuario", session.intIdUsuario);

                param.Add("@intIdPeriodo", intIdPeriodo);

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
        //6.3
        public Periodo ObtenerPeriodoPorsuPK(Session_Movi objSession, int intIdPeriodo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            Periodo obj = new Periodo();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPERIODO_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);

                param.Add("@intIdPeriodo", intIdPeriodo);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        obj.intIdPeriodo = reader.GetInt32(0);
                        obj.intIdPlani = reader.GetInt32(1);
                        obj.strCoPeriodo = reader.GetString(2);
                        obj.strDesPeriodo = reader.GetString(3);
                        obj.dttFeIniPerio = reader.GetString(4);
                        obj.dttFeFinPerio= reader.GetString(5);
                        obj.dttFeCiePerio = reader.GetString(6);
                        obj.intAnioFiscal = reader.GetInt32(7);
                        obj.intMes = reader.GetInt32(8);
                        obj.bitFlProyectado= reader.GetBoolean(9);
                        obj.bitCerrado = reader.GetBoolean(10);
                        if (!reader.IsDBNull(12))
                        {
                            obj.strPeriodoCampo1 = reader.GetString(12);
                        }
                        if (!reader.IsDBNull(13))
                        {
                            obj.strPeriodoCampo2 = reader.GetString(13);
                        }
                        if (!reader.IsDBNull(14))
                        {
                            obj.strPeriodoCampo3 = reader.GetString(14);
                        }
                        if (!reader.IsDBNull(15))
                        {
                            obj.strPeriodoCampo4 = reader.GetString(15);
                        }
                        if (!reader.IsDBNull(16))
                        {
                            obj.strPeriodoCampo5 = reader.GetString(16);
                        }

                        obj.bitFlActivo = reader.GetBoolean(17);
                        obj.intIdUnidadOrg = reader.GetInt32(23);
                        obj.intIdDependencia = reader.GetInt32(24);
                        obj.intCalculado = reader.GetInt32(25); //añadido 25.02.2021
                    }

                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return obj;
        }
        //6.4
        public int IUperiodo(Session_Movi session, Periodo periodo, int intTipoOperacion, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            int result = 0;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPERIODO_IU01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);
                param.Add("@intIdUsuario", session.intIdUsuario);

                //param.Add("@intIdDependencia", periodo.intIdDependencia);
                //param.Add("@intIdUnidadOrg", periodo.intIdUnidadOrg);
                param.Add("@intIdPeriodo", periodo.intIdPeriodo);
                param.Add("@strCoPeriodo", periodo.strCoPeriodo);
                param.Add("@strDesPeriodo", periodo.strDesPeriodo);
                param.Add("@intIdPlani", periodo.intIdPlani);
                param.Add("@bitFlProyectado", periodo.bitFlProyectado);
                param.Add("@bitFlActivo", periodo.bitFlActivo);
                param.Add("@dttFeIniPerio", periodo.dttFeIniPerio);
                param.Add("@dttFeFinPerio", periodo.dttFeFinPerio);
                param.Add("@dttFeCiePerio", periodo.dttFeCiePerio);
                param.Add("@intMes", periodo.intMes);
                param.Add("@intAnioFiscal", periodo.intAnioFiscal);
                //param.Add("@bitCerrado", false);
                param.Add("@bitCerrado", periodo.bitCerrado);//añadido 11/03/2021
                param.Add("@strPeriodoCampo1", periodo.strPeriodoCampo1);
                param.Add("@strPeriodoCampo2", periodo.strPeriodoCampo2);
                param.Add("@strPeriodoCampo3", periodo.strPeriodoCampo3);
                param.Add("@strPeriodoCampo4", periodo.strPeriodoCampo4);
                param.Add("@strPeriodoCampo5", periodo.strPeriodoCampo5);
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
        //6.5 -Añadido hg_10.02.2021_desde_sisfood
        public List<ValidacionesxLongitud> MaestroMaxCaracteres(string strMaestro)
        {

            List<ValidacionesxLongitud> listDetCar = new List<ValidacionesxLongitud>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_MAESTROS_Q00", cn);// cambiado de TSP_MAESTROS_Q01
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@strMaestro", strMaestro);
                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ValidacionesxLongitud obj = new ValidacionesxLongitud();
                        obj.NombreColum = reader.GetString(0);
                        obj.intNumero = reader.GetInt32(1);

                        listDetCar.Add(obj);
                    }
                }
            }
            return listDetCar;
        }
    }
}
