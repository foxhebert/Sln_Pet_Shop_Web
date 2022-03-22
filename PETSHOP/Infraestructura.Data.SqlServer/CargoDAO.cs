using System;
using Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Infraestructura.Data.SqlServer
{
    public class CargoDAO : Conexion
    {
        public List<Cargo> ListarCargos(long intIdSesion, int intIdMenu, int intIdSoft,int intActivoFilter, string strfilter,int intfiltrojer,  ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Cargo> lista = new List<Cargo>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCARGO_Q04", cn);
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
                   
                    Cargo obj = new Cargo();
                    Estado objEstado = new Estado();
                    obj.strCoCargo = reader.GetString(0);
                    obj.strDesCargo = reader.GetString(1);
                    obj.strDescripcion = reader.GetString(2);
                    obj.strNomJerOrg = reader.GetString(3);
                    obj.bitFlActivo = reader.GetBoolean(4);
                    obj.bitFlPrincipal = reader.GetBoolean(5);
                    objEstado.strEstadoActivo = reader.GetString(6);          
                    obj.intIdCargo = reader.GetInt32(7);
                    obj.strCargoCampo1 = reader.GetString(8);
                    obj.strCargoCampo2 = reader.GetString(9);
                    obj.strCargoCampo3 = reader.GetString(10);
                    obj.strCargoCampo4 = reader.GetString(11);
                    obj.strCargoCampo5 = reader.GetString(12);
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



        public int InsertarCargo(long intIdSesion, int intIdMenu, int intIdSoft, Cargo objDatos, int intIdUsuario, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            int intIdCargoOut = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCARGO_IU01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);//parametros de entrada
                param.Add("@strCoCargo", objDatos.strCoCargo);
                param.Add("@strDesCargo", objDatos.strDesCargo);
                param.Add("@intIdUniOrg", objDatos.intIdUniOrg);
                param.Add("@strCargoCampo1", objDatos.strCargoCampo1);
                param.Add("@strCargoCampo2", objDatos.strCargoCampo2);
                param.Add("@strCargoCampo3", objDatos.strCargoCampo3);
                param.Add("@strCargoCampo4", objDatos.strCargoCampo4);
                param.Add("@strCargoCampo5", objDatos.strCargoCampo5);
                param.Add("@bitFlActivo", objDatos.bitFlActivo);
                param.Add("@bitFlPrincipal", objDatos.bitFlPrincipal);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@intTipoOperacion", 1);//1: insert, 2: update
                //Parámetros de Salida
                param.Add("@IntIdCargo", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();
                intIdCargoOut = Convert.ToInt32(cmd.Parameters["@IntIdCargo"].Value.ToString());
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return intIdCargoOut;
        }
        public bool ActualizarCargo(long intIdSesion, int intIdMenu, int intIdSoft, Cargo objDatos, int intIdUsuario, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCARGO_IU01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);//parametros de entrada
                param.Add("@strCoCargo", objDatos.strCoCargo);
                param.Add("@strDesCargo", objDatos.strDesCargo);
                param.Add("@intIdUniOrg", objDatos.intIdUniOrg);
                param.Add("@strCargoCampo1", objDatos.strCargoCampo1);
                param.Add("@strCargoCampo2", objDatos.strCargoCampo2);
                param.Add("@strCargoCampo3", objDatos.strCargoCampo3);
                param.Add("@strCargoCampo4", objDatos.strCargoCampo4);
                param.Add("@strCargoCampo5", objDatos.strCargoCampo5);
                param.Add("@bitFlActivo", objDatos.bitFlActivo);
                param.Add("@bitFlPrincipal", objDatos.bitFlPrincipal);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@intTipoOperacion", 2);//1: insert, 2: update
                //Parámetros de Salida
                param.Add("@IntIdCargo", objDatos.intIdCargo);
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
        public List<Cargo> ListarCargosEditar(long intIdSesion, int intIdMenu, int intIdSoft, string strfilter,ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Cargo> lista = new List<Cargo>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCARGO_Q05", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
            
                param.Add("@strfilter", strfilter);
              
                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cargo obj = new Cargo();
                    Estado objEstado = new Estado();
                    obj.strCoCargo = reader.GetString(0);
                    obj.strDesCargo = reader.GetString(1);
                    obj.strDescripcion = reader.GetString(2);
                    obj.strNomJerOrg = reader.GetString(3);
                    obj.bitFlActivo = reader.GetBoolean(4);

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
        public bool EliminmarCargo(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdCargo,ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCARGO_D02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@IntIdCargo", intIdCargo);
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
        public List<Cargo> ListarCargosxEstado(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Cargo> lista = new List<Cargo>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCARGO_Q07", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);

                param.Add("@intActivoFilter", intActivoFilter);


                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cargo obj = new Cargo();
                    Estado objEstado = new Estado();
                    obj.strCoCargo = reader.GetString(0);
                    obj.strDesCargo = reader.GetString(1);
                    obj.strDescripcion = reader.GetString(2);
                    obj.strNomJerOrg = reader.GetString(3);
                    obj.bitFlActivo = reader.GetBoolean(4);
                    obj.intIdCargo = reader.GetInt32(5);


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
        public List<Cargo> ListarCargosxDependencia(long intIdSesion, int intIdMenu, int intIdSoft, int intfiltrojer, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Cargo> lista = new List<Cargo>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCARGO_Q08", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);

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
                    Cargo obj = new Cargo();
                    Estado objEstado = new Estado();
                    obj.strCoCargo = reader.GetString(0);
                    obj.strDesCargo = reader.GetString(1);
                    obj.strDescripcion = reader.GetString(2);
                    obj.strNomJerOrg = reader.GetString(3);
                    obj.bitFlActivo = reader.GetBoolean(4);
                    obj.intIdCargo = reader.GetInt32(5);


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
        public List<Cargo> ListarCargosxDescripcion(long intIdSesion, int intIdMenu, int intIdSoft, string strfilter, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Cargo> lista = new List<Cargo>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCARGO_Q09", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);

                param.Add("@strfilter", strfilter);


                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cargo obj = new Cargo();
                    Estado objEstado = new Estado();
                    obj.strCoCargo = reader.GetString(0);
                    obj.strDesCargo = reader.GetString(1);
                    obj.strDescripcion = reader.GetString(2);
                    obj.strNomJerOrg = reader.GetString(3);
                    obj.bitFlActivo = reader.GetBoolean(4);
                    obj.intIdCargo = reader.GetInt32(5);


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
        public List<CamposAdicionales2> ListarCamposAdicionalesCargos(long intIdSesion, int intIdMenu, int intIdSoft, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<CamposAdicionales2> lista = new List<CamposAdicionales2>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCARGO_Q10", cn);
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
        public List<UnidadOrg> ListarCampoUnidOrga(long intIdSesion, int intIdMenu, int intIdSoft, int intIdJerOrg, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<UnidadOrg> lista = new List<UnidadOrg>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCARGO_Q12", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intidJerar", intIdJerOrg);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UnidadOrg obj = new UnidadOrg();
                        obj.intIdUniOrg = reader.GetInt32(0);
                        obj.strDescripcion = reader.GetString(1);

                        lista.Add(obj);

                    }
                    reader.Close();
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        public List<UnidadOrg> ObtenerIDjer(long intIdSesion, int intIdMenu, int intIdSoft, int intidCargo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<UnidadOrg> lista = new List<UnidadOrg>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCARGO_Q13", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);

              
                param.Add("@intidCargo", intidCargo);
               

                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    UnidadOrg obj = new UnidadOrg();
                    JerarquiaOrg objJer = new JerarquiaOrg();

                    objJer.IntIdJerOrg = reader.GetInt32(0);
                    obj.intIdUniOrg = reader.GetInt32(1);

    
                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        public List<Cargo> ObtenerValidaciones(long intIdSesion, int intIdMenu, int intIdSoft, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Cargo> lista = new List<Cargo>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCARGO_Q14", cn);
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

                    Cargo obj = new Cargo();

                    obj.strCoCargo = reader.GetString(0);
                    obj.intIdCargo = reader.GetInt32(1);


                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        public List<Cargo> ConsultarDetalleCargoxCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdCargo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Cargo> listDetCar = new List<Cargo>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCARGO_Q15", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);



                param.Add("@intIdCargo", intIdCargo);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Cargo obj = new Cargo();
                        obj.intIdCargo = reader.GetInt32(0);
                        obj.strCoCargo = reader.GetString(1);
                        obj.strDesCargo = reader.GetString(2);
                        obj.intIdUniOrg = reader.GetInt32(3);
                        obj.strCargoCampo1 = reader.GetString(4);
                        obj.strCargoCampo2 = reader.GetString(5);
                        obj.strCargoCampo3 = reader.GetString(6);
                        obj.strCargoCampo4 = reader.GetString(7);
                        obj.strCargoCampo5 = reader.GetString(8);
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
