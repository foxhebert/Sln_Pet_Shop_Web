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
    public class ClienteDAO : Conexion
    {

        public List<Cliente> ListarClientes(long intIdSesion, int intIdMenu, int intIdSoft, int intEstado, string strBusqueda, int intCentroAlm, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TMCLIENTE_Q02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);

                param.Add("@intActivo", intEstado);
                param.Add("@strFiltro", strBusqueda);
                param.Add("@intIdCentroAlm", intCentroAlm);

                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Cliente obj = new Cliente();
                    Estado objEstado = new Estado();
                    CentroAlmacenamiento objCentroAlm = new CentroAlmacenamiento();

                    obj.intIdCliente = reader.GetInt32(0);
                    obj.strCoCliente = reader.GetString(1);
                    obj.strDesCliente = reader.GetString(2);
                    obj.strLPNRaiz = reader.GetString(3);
                    obj.strDesCentroAlm = reader.GetString(4);

                    objEstado.bitFlActivo = reader.GetBoolean(10);
                    objEstado.strEstadoActivo = reader.GetString(11);

                    if (!reader.IsDBNull(5))
                    {
                        obj.strClienteCampo1 = reader.GetString(5);
                    }
                    if (!reader.IsDBNull(6))
                    {
                        obj.strClienteCampo2 = reader.GetString(6);
                    }
                    if (!reader.IsDBNull(7))
                    {
                        obj.strClienteCampo3 = reader.GetString(7);
                    }
                    if (!reader.IsDBNull(8))
                    {
                        obj.strClienteCampo4 = reader.GetString(8);
                    }
                    if (!reader.IsDBNull(9))
                    {
                        obj.strClienteCampo5 = reader.GetString(9);
                    }
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

        public int InsertarOrUpdateCliente(long intIdSesion, int intIdMenu, int intIdSoft, Cliente objDatos, int intIdUsuario, int intIdUsuarModif, int intTipoOperacion, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            int intIdClienteOut = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TMCLIENTE_IU01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);//parametros de entrada


                param.Add("@strCoCliente", objDatos.strCoCliente);
                param.Add("@strDesCliente", objDatos.strDesCliente);
                param.Add("@strLPNRaiz", objDatos.strLPNRaiz);
                param.Add("@intIdCentroAlm", objDatos.intIdCentroAlm);
                param.Add("@strClienteCampo1", (object)objDatos.strClienteCampo1 ?? DBNull.Value);
                param.Add("@strClienteCampo2", (object)objDatos.strClienteCampo2 ?? DBNull.Value);
                param.Add("@strClienteCampo3", (object)objDatos.strClienteCampo3 ?? DBNull.Value);
                param.Add("@strClienteCampo4", (object)objDatos.strClienteCampo4 ?? DBNull.Value);
                param.Add("@strClienteCampo5", (object)objDatos.strClienteCampo5 ?? DBNull.Value);

                param.Add("@bitFlActivo", objDatos.bitFlActivo);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update

                //Parámetros de Salida
                if (intTipoOperacion == 1)
                {
                    param.Add("@intIdCliente", 0);
                }
                else
                {
                    param.Add("@intIdCliente", objDatos.intIdCliente);
                }


                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();
                intIdClienteOut = Convert.ToInt32(cmd.Parameters["@intIdCliente"].Value.ToString());
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return intIdClienteOut;
        }

        public bool EliminarCliente(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdCliente, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TMCLIENTE_D02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdUsuario", intIdUsuario);

                param.Add("@intIdCliente", intIdCliente);
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

        public List<Cliente> ListarClientesPorId(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdCliente, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TMCLIENTE_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);

                param.Add("@intIdCliente", intIdCliente);

                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Cliente obj = new Cliente();
                    Estado objEstado = new Estado();
                    CentroAlmacenamiento objCentroAlm = new CentroAlmacenamiento();

                    obj.intIdCliente = reader.GetInt32(0);
                    obj.strCoCliente = reader.GetString(1);
                    obj.strDesCliente = reader.GetString(2);
                    obj.strLPNRaiz = reader.GetString(3);
                    obj.intIdCentroAlm = reader.GetInt32(4);
                    obj.strDesCentroAlm = reader.GetString(5);

                    objEstado.bitFlActivo = reader.GetBoolean(11);
                    objEstado.strEstadoActivo = reader.GetString(12);

                    if (!reader.IsDBNull(6))
                    {
                        obj.strClienteCampo1 = reader.GetString(6);
                    }
                    if (!reader.IsDBNull(7))
                    {
                        obj.strClienteCampo2 = reader.GetString(7);
                    }
                    if (!reader.IsDBNull(8))
                    {
                        obj.strClienteCampo3 = reader.GetString(8);
                    }
                    if (!reader.IsDBNull(9))
                    {
                        obj.strClienteCampo4 = reader.GetString(9);
                    }
                    if (!reader.IsDBNull(10))
                    {
                        obj.strClienteCampo5 = reader.GetString(10);
                    }


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

        public List<MaestroCaracteres> MaestroMaxCaracteres(string strTableName)
        {
            List<MaestroCaracteres> lista = new List<MaestroCaracteres>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_MAESTROS_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("@strMaestro", strTableName);

                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    MaestroCaracteres obj = new MaestroCaracteres();

                    obj.strColumnName = reader.GetString(0);
                    obj.intMaxLength = reader.GetInt32(1);
                    lista.Add(obj);
                }
                reader.Close();

            }
            return lista;
        }

        public List<Cliente> ListarComboCliente(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGLISTAR_COMBOS_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);

                param.Add("@strEntidad", strEntidad);
                param.Add("@intIdFiltroGrupo", intIdFiltroGrupo);

                param.Add("@strGrupo", strGrupo);
                param.Add("@strSubGrupo", strSubGrupo);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cliente obj = new Cliente();

                    obj.intIdCliente = reader.GetInt32(0);
                    obj.strCoCliente = reader.GetString(1);
                    obj.strDesCliente = reader.GetString(2);
                    lista.Add(obj);

                }

                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
    }
}
