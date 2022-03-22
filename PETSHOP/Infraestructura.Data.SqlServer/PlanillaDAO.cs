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
    public class PlanillaDAO : Conexion
    {

        public List<Planilla> ListarPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Planilla> lista = new List<Planilla>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPLANILLA_Q04", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);

                param.Add("@intActivoFilter", intActivoFilter);
                param.Add("@strfilter", strfilter);
                param.Add("@intfiltrojer", intfiltrojer);


                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult",0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Planilla obj = new Planilla();
                    Estado objEstado = new Estado();
                    obj.strCoPlani = reader.GetString(0);
                    obj.strDesPlani = reader.GetString(1);
                    obj.strDescripcion = reader.GetString(2);
                    obj.strNomJerOrg = reader.GetString(3);
                    obj.bitFlActivo = reader.GetBoolean(4);
                    obj.bitFlPrincipal = reader.GetBoolean(5);
                    objEstado.strEstadoActivo = reader.GetString(6);
                    obj.intIdPlanilla = reader.GetInt32(7);
                    obj.strPlaniCampo1 = reader.GetString(8);
                    obj.strPlaniCampo2 = reader.GetString(9);
                    obj.strPlaniCampo3 = reader.GetString(10);
                    obj.strPlaniCampo4 = reader.GetString(11);
                    obj.strPlaniCampo5 = reader.GetString(12);
                    obj.intIdUniOrg = reader.GetInt32(13);

                    obj.FlActivo = objEstado;
                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        public int InsertarPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, Planilla objDatos, int intIdUsuario, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            int intIdPlanillaOut = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPLANILLA_IU01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);//parametros de entrada

                param.Add("@strCoPlani", objDatos.strCoPlani);
                param.Add("@strDesPlani", objDatos.strDesPlani);
                param.Add("@intIdUniOrg", objDatos.intIdUniOrg);
                param.Add("@strPlaniCampo1", objDatos.strPlaniCampo1);
                param.Add("@strPlaniCampo2", objDatos.strPlaniCampo2);
                param.Add("@strPlaniCampo3", objDatos.strPlaniCampo3);
                param.Add("@strPlaniCampo4", objDatos.strPlaniCampo4);
                param.Add("@strPlaniCampo5", objDatos.strPlaniCampo5);
                param.Add("@bitFlActivo", objDatos.bitFlActivo);
                param.Add("@bitFlPrincipal", objDatos.bitFlPrincipal);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@intTipoOperacion", 1);//1: insert, 2: update
                //Parámetros de Salida
                param.Add("@intIdPlanilla", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();
                intIdPlanillaOut = Convert.ToInt32(cmd.Parameters["@intIdPlanilla"].Value.ToString());
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return intIdPlanillaOut;
        }

        public bool EliminmarPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int IdPlanilla, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPLANILLA_D02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@intIdPlanilla", IdPlanilla);
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

        public List<Planilla> ObtenerValidacionesPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Planilla> lista = new List<Planilla>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPLANILLA_Q05", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
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

                    obj.strCoPlani = reader.GetString(0);
                    obj.intIdPlanilla = reader.GetInt32(1);


                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        public List<CamposAdicionales2> ListarCamposAdicionalesPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<CamposAdicionales2> lista = new List<CamposAdicionales2>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPLANILLA_Q06", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
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
                    CamposAdicionales2 obj = new CamposAdicionales2();
                    obj.strNoEntidad = reader.GetString(0);
                    obj.strNomCampo = reader.GetString(1);
                    obj.strTitulo = reader.GetString(2);

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        public bool ActualizarPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, Planilla objDatos, int intIdUsuario, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPLANILLA_IU01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);//parametros de entrada

                param.Add("@strCoPlani", objDatos.strCoPlani);
                param.Add("@strDesPlani", objDatos.strDesPlani);
                param.Add("@intIdUniOrg", objDatos.intIdUniOrg);
                param.Add("@strPlaniCampo1", objDatos.strPlaniCampo1);
                param.Add("@strPlaniCampo2", objDatos.strPlaniCampo2);
                param.Add("@strPlaniCampo3", objDatos.strPlaniCampo3);
                param.Add("@strPlaniCampo4", objDatos.strPlaniCampo4);
                param.Add("@strPlaniCampo5", objDatos.strPlaniCampo5);
                param.Add("@bitFlActivo", objDatos.bitFlActivo);
                param.Add("@bitFlPrincipal", objDatos.bitFlPrincipal);

                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@intTipoOperacion", 2);//1: insert, 2: update
                //Parámetros de Salida
                param.Add("@intIdPlanilla", objDatos.intIdPlanilla);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();


                exito = true;
            }

            return exito;
        }

        public List<Planilla> ConsultarDetallePlanillaxCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPlanilla, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Planilla> listDetCar = new List<Planilla>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPLANILLA_Q09", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);



                param.Add("@intIdPlanilla", intIdPlanilla);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Planilla obj = new Planilla();
                        obj.intIdPlanilla = reader.GetInt32(0);
                        obj.strCoPlani = reader.GetString(1);
                        obj.strDesPlani = reader.GetString(2);
                        obj.intIdUniOrg = reader.GetInt32(3);
                        obj.strPlaniCampo1 = reader.GetString(4);
                        obj.strPlaniCampo2 = reader.GetString(5);
                        obj.strPlaniCampo3 = reader.GetString(6);
                        obj.strPlaniCampo4 = reader.GetString(7);
                        obj.strPlaniCampo5 = reader.GetString(8);
                        listDetCar.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listDetCar;
        }


    }
}
