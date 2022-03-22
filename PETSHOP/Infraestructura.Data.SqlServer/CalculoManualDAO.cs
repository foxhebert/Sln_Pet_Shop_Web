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
    public class CalculoManualDAO : Conexion
    {

        public List<Planilla> ListarCampoPlanillaAbierta(long intIdSesion, int intIdMenu, int intIdSoft, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Planilla> lista = new List<Planilla>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPLANILLA_Q07", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);



                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Planilla obj = new Planilla();
                    Periodo objPer = new Periodo();

                    obj.intIdPlanilla = reader.GetInt32(0);
                    obj.strDesPlani = reader.GetString(1);


                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        public List<Periodo> ListarCampoPeriodoxPlanilla(long intIdSesion, int intIdMenu, int intIdSoft,int intIdPlanilla, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Periodo> lista = new List<Periodo>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPLANILLA_Q08", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);

                param.Add("@intIdPlanilla", intIdPlanilla);

                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Periodo objPer = new Periodo();
                    objPer.intIdPeriodo =  reader.GetInt32(0);
                    objPer.dttFeIniPerio = reader.GetString(1);
                    objPer.dttFeFinPerio = reader.GetString(2);

                    lista.Add(objPer);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        public List<GrupoLiquidacion> ListarGrupoLiqxPeriodo(Session_Movi session, DataTable tb, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<GrupoLiquidacion> lista = new List<GrupoLiquidacion>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGGRUPOLIQ_Q04", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@TT_PERIODOS", tb);

                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    GrupoLiquidacion obj = new GrupoLiquidacion();
                    obj.intIdGrupoLiq = reader.GetInt32(0);
                    obj.strDesGrupoLiq = reader.GetString(1);

                    lista.Add(obj);
                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        public List<CalculoPersonal> GetListarPersonal(Session_Movi session, int intidPlanilla, string strFiltroCalculo, DataTable tb, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<CalculoPersonal> lista = new List<CalculoPersonal>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCALCULO_EMP_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@intidPlanilla", intidPlanilla);
                param.Add("@strFiltroCalculo", strFiltroCalculo);
                param.Add("@TT_GRUPOLIQ", tb);
                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CalculoPersonal obj = new CalculoPersonal();

                    obj.intIdPersonal = reader.GetInt32(0);
                    obj.strCoPersonal = reader.GetString(1);
                    obj.strNomCompleto = reader.GetString(2);
                    obj.strNumDoc = reader.GetString(3);
                    obj.strFotocheck = reader.GetString(4);
                    obj.strDescripcion = reader.GetString(5);
                    obj.strDeTipo = reader.GetString(6);
                    if(!reader.IsDBNull(7))
                        obj.strDesGrupoLiq = reader.GetString(7);

                    obj.dttFecAdmin = reader.GetString(8);
                    obj.dttFecCese = reader.GetString(9);
                    
                    obj.intDiasTrabajados = reader.GetString(10);
                    obj.intDiasFaltas = reader.GetString(11);
                    obj.intHorasAdicionales = reader.GetString(12);
                    obj.intFeriados = reader.GetString(13);
                    obj.intHorasFuera = reader.GetString(14);
                    obj.intTardanza = reader.GetString(15);
                    lista.Add(obj);
                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        public int Calcular(Session_Movi session, int intIdPeriodo, DataTable tb, int intIdPlanilla, int intIdProc)
        {
            int result = 0;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCALCULO_P00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("@intIdPeriodo", intIdPeriodo);
                param.Add("@intIdPlanilla", intIdPlanilla);
                param.Add("@intIdProc", intIdProc);
                param.Add("@INTIDSESSION", session.intIdSesion);
                param.Add("@LSTPERSONAL", tb);

                AsignarParametros(cmd, param);

                result = Convert.ToInt32(cmd.ExecuteScalar());

            }
            return result;
        }

        public List<Periodo> getPeriodoxPlanilla(Session_Movi session, int intIdPlanilla, bool bitCerrado, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Periodo> lista = new List<Periodo>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPERIODO_Q04", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@intIdPlanilla", intIdPlanilla);
                param.Add("@bitCerrado", bitCerrado);

                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Periodo objPer = new Periodo();
                    objPer.intIdPeriodo = reader.GetInt32(0);
                    objPer.intIdPlani = reader.GetInt32(1);
                    objPer.strDesPlani = reader.GetString(2);
                    objPer.strCoPeriodo = reader.GetString(3);
                    objPer.strDesPeriodo = reader.GetString(4);
                    objPer.dttFeIniPerio = reader.GetString(5);
                    objPer.dttFeFinPerio = reader.GetString(6);
                    objPer.dttFeCiePerio = reader.GetString(7);
                    objPer.strMesAnio = reader.GetString(10);

                    lista.Add(objPer);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        public int updatePeriodo(Session_Movi session, DataTable tb, bool bitCerrado, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            int result = 0;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPERIODO_U01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@bitCerrado", bitCerrado);
                param.Add("@TT_PERIODOS", tb);
                //salida
                //param.Add("@TotalRows", 0);
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

        public List<CalculoPersonal> GuardarCalculo(Session_Movi session, int intIdProceso, string strFiltroCalculo, int intIdPlanilla, DataTable tb, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<CalculoPersonal> lista = new List<CalculoPersonal>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCALCULO_I01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);
                param.Add("@intIdUsuario", session.intIdUsuario);

                param.Add("@intIdProceso", intIdProceso);
                param.Add("@intIdPlanilla", intIdPlanilla);
                param.Add("@strFiltroCalculo", strFiltroCalculo);
                param.Add("@TT_GRUPOLIQ", tb);

                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CalculoPersonal obj = new CalculoPersonal();

                    obj.intIdPersonal = reader.GetInt32(0);
                    obj.strCoPersonal = reader.GetString(1);
                    obj.strNomCompleto = reader.GetString(2);
                    obj.strNumDoc = reader.GetString(3);
                    obj.strFotocheck = reader.GetString(4);
                    obj.strDescripcion = reader.GetString(5);
                    obj.strDeTipo = reader.GetString(6);
                    if (!reader.IsDBNull(7))
                        obj.strDesGrupoLiq = reader.GetString(7);

                    obj.dttFecAdmin = reader.GetString(8);
                    obj.dttFecCese = reader.GetString(9);

                    obj.intDiasTrabajados = reader.GetString(10);
                    obj.intDiasFaltas = reader.GetString(11);
                    obj.intHorasAdicionales = reader.GetString(12);
                    obj.intFeriados = reader.GetString(13);
                    obj.intHorasFuera = reader.GetString(14);
                    obj.intTardanza = reader.GetString(15);
                    lista.Add(obj);
                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        public int LimpiarTemporal(Session_Movi session, int intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            int result = 0;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCALCULO_D01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@intIdProceso", intIdProceso);

                //salida
                //param.Add("@TotalRows", 0);
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

        public List<CalculoPersonal> getPersonalCalculo(Session_Movi session, int intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<CalculoPersonal> lista = new List<CalculoPersonal>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCALCULO_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@intIdProceso", intIdProceso);

                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CalculoPersonal obj = new CalculoPersonal();
                    obj.intIdPersonal = reader.GetInt32(0);
                    obj.strCoPersonal = reader.GetString(1);
                    obj.strNomCompleto = reader.GetString(2);
                    obj.strNumDoc = reader.GetString(3);
                    obj.strFotocheck = reader.GetString(4);
                    obj.strDescripcion = reader.GetString(5);
                    obj.strDeTipo = reader.GetString(6);
                    if (!reader.IsDBNull(7))
                        obj.strDesGrupoLiq = reader.GetString(7);

                    obj.dttFecAdmin = reader.GetString(8);
                    obj.dttFecCese = reader.GetString(9);

                    obj.intDiasTrabajados = reader.GetString(10);
                    obj.intDiasFaltas = reader.GetString(11);
                    obj.intHorasAdicionales = reader.GetString(12);
                    obj.intFeriados = reader.GetString(13);
                    obj.intHorasFuera = reader.GetString(14);
                    obj.intTardanza = reader.GetString(15);
                    obj.intIdPeriodo = reader.GetString(16);
                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        public List<CalculoPersonal> getPersonalNoProc(Session_Movi session, int intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<CalculoPersonal> lista = new List<CalculoPersonal>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCALCULO_Q02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@intIdProceso", intIdProceso);

                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CalculoPersonal obj = new CalculoPersonal();
                    obj.intIdPersonal = reader.GetInt32(0);
                    obj.strCoPersonal = reader.GetString(1);
                    obj.strNomCompleto = reader.GetString(2);
                    obj.strNumDoc = reader.GetString(3);
                    obj.strFotocheck = reader.GetString(4);
                    obj.strDescripcion = reader.GetString(5);
                    obj.strDeTipo = reader.GetString(6);
                    if (!reader.IsDBNull(7))
                        obj.strDesGrupoLiq = reader.GetString(7);

                    obj.dttFecAdmin = reader.GetString(8);
                    obj.dttFecCese = reader.GetString(9);

                    obj.intDiasTrabajados = reader.GetString(10);
                    obj.intDiasFaltas = reader.GetString(11);
                    obj.intHorasAdicionales = reader.GetString(12);
                    obj.intFeriados = reader.GetString(13);
                    obj.intHorasFuera = reader.GetString(14);
                    obj.intTardanza = reader.GetString(15);
                    obj.intIdPeriodo = reader.GetString(16);
                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        public List<CalculoPersonal> getExportEmpleados(Session_Movi session, DataTable tb, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<CalculoPersonal> lista = new List<CalculoPersonal>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCALCULO_SinCalculo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);
                param.Add("@intIdUsuario", session.intIdUsuario);

                param.Add("@TT_PERIODOS", tb);

                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CalculoPersonal obj = new CalculoPersonal();
                    obj.intIdPersonal = reader.GetInt32(0);
                    obj.strCoPersonal = reader.GetString(1);
                    obj.strNomCompleto = reader.GetString(2);
                    obj.strNumDoc = reader.GetString(3);
                    obj.strFotocheck = reader.GetString(4);
                    obj.strDescripcion = reader.GetString(5);
                    obj.strDeTipo = reader.GetString(6);
                    if (!reader.IsDBNull(7))
                        obj.strDesGrupoLiq = reader.GetString(7);

                    obj.dttFecAdmin = reader.GetString(8);
                    obj.dttFecCese = reader.GetString(9);

                    obj.intDiasTrabajados = reader.GetString(10);
                    obj.intDiasFaltas = reader.GetString(11);
                    obj.intHorasAdicionales = reader.GetString(12);
                    obj.intFeriados = reader.GetString(13);
                    obj.intHorasFuera = reader.GetString(14);
                    obj.intTardanza = reader.GetString(15);
                    obj.intIdPeriodo = reader.GetString(16);
                    obj.strNoUsuar = reader.GetString(17);
                    obj.dttFeRegistro = reader.GetString(18);
                    obj.intTipo = reader.GetInt32(19);

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        public int validarPeriodo(Session_Movi session, DataTable tb)
        {
            int salida = 0;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCALCULO_validarPeriodo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@TT_PERIODOS", tb);

                AsignarParametros(cmd, param);

                salida = Convert.ToInt32(cmd.ExecuteScalar());

            }
            return salida;
        }
    }
}
