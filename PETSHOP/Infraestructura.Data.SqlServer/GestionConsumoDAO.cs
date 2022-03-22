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
    public class GestionConsumoDAO : Conexion
    {
        #region GESTION_DE_CONSUMO
        //5.83
        public List<Consumo> ListarGestionConsumo(Session_Movi objSession, string dttFiltroFchI, string dttFiltroFchF, string strDescripcion, int intConsumido, int intTipoServ, int intTipoMenu, int IntIdEmp, int intIdMarcador, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Consumo> lista = new List<Consumo>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {

                SqlCommand cmd = new SqlCommand("TSP_TCCONSUMO_GESTION_Q00", cn);   //SqlCommand cmd = new SqlCommand("TSP_TGEMPRESA_Q02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                //param.Add("@intIdMenu", objSession.IntIdMenu);
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);

                //Filtros                
                //param.Add("@dttFiltroFchI", dttFiltroFchI);
                //param.Add("@dttFiltroFchF", dttFiltroFchF);
                param.Add("@dttFiltroFchI", Convert.ToString(dttFiltroFchI)); //Convert para fechas
                param.Add("@dttFiltroFchF", Convert.ToString(dttFiltroFchF));
                param.Add("@strFiltro", strDescripcion);
                param.Add("@intConsumido", intConsumido);
                param.Add("@intTipoServ", intTipoServ);
                param.Add("@intTipoMenu", intTipoMenu);
                param.Add("@IntIdEmp", IntIdEmp);
                param.Add("@intIdMarcador", intIdMarcador);

                //salida             
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Consumo obj = new Consumo();
                    obj.intIdConsumo = reader.GetInt32(0);
                    obj.strFotocheck = reader.GetString(1);
                    obj.strNombresCompletos = reader.GetString(2);
                    obj.strNumDoc = reader.GetString(3);
                    obj.strDescripcion = reader.GetString(4);
                    //obj.strDesTipMenu = reader.GetString(5);//comentado 23.03.2021
                    obj.strCantidad= reader.GetString(5);
                    obj.bitFlConsumido = reader.GetInt32(6);//= reader.GetBoolean(6),
                    obj.dttFechaHora = reader.GetString(7);
                    obj.strDesEmp = reader.GetString(8);
                    obj.strDesMarcador = reader.GetString(9); //strDesMarcador
                    //obj.strUsuarAutor = reader.GetString(10); //comentado 23.03.2021
                    //obj.dttFeHoraAutor = reader.GetString(11);//comentado 23.03.2021
                    //obj.strUsuarDesha = reader.GetString(12);//comentado 23.03.2021
                    //obj.dttFeHoraDesha = reader.GetString(13);//comentado 23.03.2021
                    obj.imgFoto = reader.GetString(10);//14
                    obj.strHorarioAtencion = reader.GetString(12);//AÑADIDO 07.04.2021

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //5.84
        public int UpdateGestionConsumo(Session_Movi objSession, int intTipoOperacion, Consumo objDatos, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            int intIdConsumoOut = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TCCONSUMO_GESTION_U00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                //param.Add("@intIdMenu", objSession.IntIdMenu);
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);//parametros de entrada
                param.Add("@bitFlConsumido", objDatos.bitFlConsumido);
                param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update

                //Parámetros de Salida
                param.Add("@intIdConsumo", objDatos.intIdConsumo);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();
                intIdConsumoOut = Convert.ToInt32(cmd.Parameters["@intIdConsumo"].Value.ToString());
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return intIdConsumoOut;
        }
        //5.85
        public int UpdateGestionMasivoConsumo(Session_Movi objSession, int intTipoOperacion, DataTable tb, /*Consumo objDatos,*/ ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            int intIdConsumoOut = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TCCONSUMO_GESTION_UM0", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                //param.Add("@intIdMenu", objSession.IntIdMenu);
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@TT_Consumos", tb);
                //////////param.Add("@bitFlConsumido", objDatos.bitFlConsumido);
                param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update

                //Parámetros de Salida
                param.Add("@intIdConsumo", 1);//param.Add("@intIdConsumo", objDatos.intIdConsumo);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();
                intIdConsumoOut = Convert.ToInt32(cmd.Parameters["@intIdConsumo"].Value.ToString());
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return intIdConsumoOut;
        }
        //5.86
        public List<Consumo> ListarConsumosXid(Session_Movi objSession, int intId, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Consumo> lista = new List<Consumo>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TCCONSUMO_Q01", cn);   //SqlCommand cmd = new SqlCommand("TSP_TGEMPRESA_Q02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                //param.Add("@intIdMenu", objSession.IntIdMenu);
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intId", intId);

                //salida             
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Consumo obj = new Consumo();
                    obj.intIdConsumo = reader.GetInt32(0);
                    obj.intCantidad = reader.GetInt32(1);
                    obj.strDescripcion = reader.GetString(2);
                    obj.strClase = reader.GetString(3);
                    obj.strPrecio = reader.GetString(4);
                    obj.bitFlConsumido = reader.GetInt32(5);//= reader.GetBoolean(6),
                    obj.FlCancelado = reader.GetInt32(6);//= reader.GetBoolean(6),

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //5.87
        public bool UpdateGC(Session_Movi objSession, int intTipoOperacion, DataTable tblistaConsumoSelects, int bitFlConsumido, int evento, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            bool Rpta = false;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TCCONSUMO_GESTION_U01", cn); //nuevo SP
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);//parametros de entrada
                param.Add("@TT_TCCONSUMO", tblistaConsumoSelects);
                param.Add("@bitFlConsumido", bitFlConsumido); 
                param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update
                param.Add("@intevento", evento);//0: Up sobre idAsistencia, 1: Up sobre idConsumo 

                //Parámetros de Salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();
                Rpta = true;
                //intIdConsumoOut = Convert.ToInt32(cmd.Parameters["@intIdConsumo"].Value.ToString());
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return Rpta;
        }

        #endregion GESTION_DE_CONSUMO



    }
}



