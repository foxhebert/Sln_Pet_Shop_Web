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
    public class TipoPersonDAO : Conexion
    {
        public List<TipoPerson> ListarTipoPerson(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TipoPerson> lista = new List<TipoPerson>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGTIPOPERSON_Q04", cn);
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
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TipoPerson obj = new TipoPerson();
                    Estado objEstado = new Estado();
                    obj.strDesTiPers = reader.GetString(1);
                    obj.strCoTiPers = reader.GetString(0);
                    obj.strDescripcion = reader.GetString(2);
                    obj.strNomJerOrg = reader.GetString(3);
                    obj.bitFlActivo = reader.GetBoolean(4);
                    objEstado.strEstadoActivo = reader.GetString(5);
                    obj.IntIdTiPers = reader.GetInt32(6);
                    obj.strTiPersCampo1 = reader.GetString(7);
                    obj.strTiPersCampo2 = reader.GetString(8);
                    obj.strTiPersCampo3 = reader.GetString(9);
                    obj.strTiPersCampo4 = reader.GetString(10);
                    obj.strTiPersCampo5 = reader.GetString(11);
                    obj.IntIdUniOrg = reader.GetInt32(12);


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
        public int InsertarTipoPersonal(long intIdSesion, int intIdMenu, int intIdSoft, TipoPerson objDatos, int intIdUsuario, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            int IntIdTiPersOut = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGTIPOPERSON_IU01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);//parametros de entrada
                param.Add("@strCoTiPers", objDatos.strCoTiPers);
                param.Add("@strDesTiPers", objDatos.strDesTiPers);
                param.Add("@IntIdUniOrg", objDatos.IntIdUniOrg);
                param.Add("@strTiPersCampo1", objDatos.strTiPersCampo1);
                param.Add("@strTiPersCampo2", objDatos.strTiPersCampo2);
                param.Add("@strTiPersCampo3", objDatos.strTiPersCampo3);
                param.Add("@strTiPersCampo4", objDatos.strTiPersCampo4);
                param.Add("@strTiPersCampo5", objDatos.strTiPersCampo5);
                param.Add("@bitFlActivo", objDatos.bitFlActivo);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@intTipoOperacion", 1);//1: insert, 2: update
                //Parámetros de Salida
                param.Add("@IntIdTiPers", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();
                IntIdTiPersOut = Convert.ToInt32(cmd.Parameters["@IntIdTiPers"].Value.ToString());
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return IntIdTiPersOut;
        }

        public bool EliminmarTipo(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdTipo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGTIPOPERSON_D02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@IntIdTiPers", intIdTipo);
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

        public List<CamposAdicionales2> ListarCamposAdicionalesTipoPerson(long intIdSesion, int intIdMenu, int intIdSoft, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<CamposAdicionales2> lista = new List<CamposAdicionales2>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGTIPOPERSON_Q06", cn);
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

        public List<TipoPerson> ObtenerValidacionesTipoPerson(long intIdSesion, int intIdMenu, int intIdSoft, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TipoPerson> lista = new List<TipoPerson>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGTIPOPERSON_Q07", cn);
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

                    TipoPerson obj = new TipoPerson();

                    obj.strCoTiPers = reader.GetString(0);
                    obj.IntIdTiPers = reader.GetInt32(1);


                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        public bool ActualizarTipoPersonal(long intIdSesion, int intIdMenu, int intIdSoft, TipoPerson objDatos, int intIdUsuario, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGTIPOPERSON_IU01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);//parametros de entrada
                param.Add("@strCoTiPers", objDatos.strCoTiPers);
                param.Add("@strDesTiPers", objDatos.strDesTiPers);
                param.Add("@IntIdUniOrg", objDatos.IntIdUniOrg);
                param.Add("@strTiPersCampo1", objDatos.strTiPersCampo1);
                param.Add("@strTiPersCampo2", objDatos.strTiPersCampo2);
                param.Add("@strTiPersCampo3", objDatos.strTiPersCampo3);
                param.Add("@strTiPersCampo4", objDatos.strTiPersCampo4);
                param.Add("@strTiPersCampo5", objDatos.strTiPersCampo5);
                param.Add("@bitFlActivo", objDatos.bitFlActivo);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@intTipoOperacion", 2);//1: insert, 2: update
                //Parámetros de Salida
                param.Add("@IntIdTiPers", objDatos.IntIdTiPers);
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

        public List<TipoPerson> ConsultarDetalleTipoPerxCod(long intIdSesion, int intIdMenu, int intIdSoft, int IntIdTiPers, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TipoPerson> listDetCar = new List<TipoPerson>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGTIPOPERSON_Q08", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);



                param.Add("@IntIdTiPers", IntIdTiPers);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        TipoPerson obj = new TipoPerson();
                        obj.IntIdTiPers = reader.GetInt32(0);
                        obj.strCoTiPers = reader.GetString(1);
                        obj.strDesTiPers = reader.GetString(2);
                        obj.IntIdUniOrg = reader.GetInt32(3);
                        obj.strTiPersCampo1 = reader.GetString(4);
                        obj.strTiPersCampo2 = reader.GetString(5);
                        obj.strTiPersCampo3 = reader.GetString(6);
                        obj.strTiPersCampo4 = reader.GetString(7);
                        obj.strTiPersCampo5 = reader.GetString(8);
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
