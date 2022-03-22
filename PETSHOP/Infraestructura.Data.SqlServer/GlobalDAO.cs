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
   public class GlobalDAO : Conexion
    {
        //5.31
        public List<CombosGlobal> ListarComboGeneral(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<CombosGlobal> lista = new List<CombosGlobal>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGLISTAR_COMBOS_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
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
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CombosGlobal obj = new CombosGlobal();

                    obj.intId = reader.GetInt32(0);
                    obj.strCodigo = reader.GetString(1);
                    obj.strDescripcion = reader.GetString(2);
                    lista.Add(obj);
                }

                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //5.32
        public List<CamposAdicionalesGlobal> ListarCamposAdicionales(long intIdSesion, int intIdMenu, int intIdSoft, string strNoEntidad, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<CamposAdicionalesGlobal> lista = new List<CamposAdicionalesGlobal>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGLISTAR_CAMPOS_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@strNoEntidad", strNoEntidad);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CamposAdicionalesGlobal obj = new CamposAdicionalesGlobal();
                    obj.strTablaEntid = reader.GetString(0);
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

        //5.74
        public List<MaestroCaracteres> MaestroMaxCaracteres(string strTableName)
        {
            List<MaestroCaracteres> lista = new List<MaestroCaracteres>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_MAESTROS_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
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


        #region Tipo
        //1.13
        public List<TGTipo> ListarTGTipo(Session_Movi objSession, string strGrupo, string strSubGrupo, int IntIdTipo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGTipo> lista = new List<TGTipo>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGTIPO_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@strGrupo", strGrupo);
                param.Add("@strSubGrupo", strSubGrupo);
                param.Add("@intId", IntIdTipo);
                param.Add("@intResult", 1);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TGTipo obj = new TGTipo();

                    obj.IntIdTipo      = reader.GetInt32(0);
                    obj.strCoTipo      = reader.GetString(1);
                    obj.strDeTipo      = reader.GetString(2);
                    obj.strAbreviatura = reader.GetString(3);
                    obj.DeSubGrupo     = reader.GetString(4);
                    obj.strSubGrupo    = reader.GetString(5);


                    lista.Add(obj);

                }

                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //1.14
        public int IUTGTipo(Session_Movi objSession, TGTipo objDatos, int intTipoOperacion, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            int intIdOut = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGTIPO_IU01", cn);//TSP_TCSERVICIO_IU01
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                //param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);//parametros de entrada
                //-------------
                param.Add("@IntIdTipo",      objDatos.IntIdTipo);
                param.Add("@strCoTipo",      objDatos.strCoTipo);
                param.Add("@strDeTipo",      objDatos.strDeTipo);
                param.Add("@strAbreviatura", objDatos.strAbreviatura);
                param.Add("@strGrupo",       ""); //param.Add("@strGrupo",       objDatos.strGrupo);
                param.Add("@strSubGrupo",    objDatos.strSubGrupo);
                //-------------
                param.Add("@intIdUsuario", objSession.intIdUsuario);
                param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update
                param.Add("@intResult", 1);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();
                intIdOut = Convert.ToInt32(cmd.Parameters["@IntIdTipo"].Value.ToString());
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return intIdOut;
        }
        //1.15
        public bool EliminarTGTipo(Session_Movi objSession, int IntIdTipo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGTIPO_D02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                //param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdUsuario", objSession.intIdUsuario);
                param.Add("@IntIdTipo", IntIdTipo);
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

        #endregion Tipo
    }
}
