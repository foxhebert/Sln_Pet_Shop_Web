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
    public class PerfilDAO : Conexion
    {
        //3.2
        public List<TS_PERFIL> ListarPerfil(long intIdSesion, int intIdMenu, int intIdSoft, int intActivo, string strDescripcion, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TS_PERFIL> lista = new List<TS_PERFIL>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSPERFIL_Q02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intActivo", intActivo);
                param.Add("@strFiltro", strDescripcion);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TS_PERFIL obj = new TS_PERFIL();
                    obj.intIdPerfil = reader.GetInt32(0);
                    obj.strCoPerfil = reader.GetString(1);
                    obj.strDesPerfil = reader.GetString(2);
                    obj.strTipoPerfil = reader.GetString(4);
                    obj.strFlActivo = reader.GetString(6);

                    lista.Add(obj);
                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return lista;
        }
        //3.3
        public List<TS_MENU> ListarMenuSubMenus(long intIdSesion, int intIdMenu, int intIdSoft, int intActivo, string strDescripcion, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TS_MENU> lista = new List<TS_MENU>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSMENU_Q02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intActivo", intActivo);
                param.Add("@strFiltro", strDescripcion);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TS_MENU obj = new TS_MENU();
                    obj.strCoMenu = reader.GetString(0);
                    obj.strNomMenu = reader.GetString(1);
                    obj.strCoMenuRela = reader.GetString(2);
                    obj.intIdMenu = reader.GetInt32(3);
                    obj.contador = reader.GetInt32(4);

                    lista.Add(obj);
                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return lista;
        }
        //3.4
        public int IUPerfil_T(long intIdSesion, int intIdMenu, int intIdSoft, TS_PERFIL objDatos, int intIdUsuario, int intTipoOperacion, List<TT_TSPERFIL_MENU> listaDetallesPerfil, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string Msj)
        {
            int intIdFiltroOut = 0;
            int Rpta_SP = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(cadCnx))
                {
                    cn.Open();
                    using (SqlTransaction trans = cn.BeginTransaction())
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand("TSP_TSPERFIL_IU01", cn);
                            cmd.Transaction = trans;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = timeSQL;
                            Dictionary<string, object> param = new Dictionary<string, object>();
                            param.Add("@intIdSesion", intIdSesion);
                            param.Add("@intIdMenu", intIdMenu);
                            param.Add("@intIdSoft", intIdSoft);
                            if (intTipoOperacion == 1)
                            {
                                param.Add("@IntIdPerfil", 0);
                            }
                            else
                            {
                                param.Add("@IntIdPerfil", objDatos.intIdPerfil);
                            }

                            param.Add("@strCoPerfil", objDatos.strCoPerfil);
                            param.Add("@strDesPerfil", objDatos.strDesPerfil);
                            param.Add("@bitFlActivo", objDatos.bitFlActivo);
                            param.Add("@intIdUsuario", intIdUsuario);
                            param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update
                            //Parámetros de Salida
                            param.Add("@intResult", 0);
                            param.Add("@strMsjDB", "");
                            param.Add("@strMsjUsuario", "");

                            AsignarParametros(cmd, param);
                            cmd.ExecuteNonQuery();

                            intIdFiltroOut = Convert.ToInt32(cmd.Parameters["@IntIdPerfil"].Value.ToString());
                            intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                            strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                            strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

                            if (intIdFiltroOut > 0 && intResult > 0)
                            {
                                //----- TABLA 1: detalle del perfil (lista de menus asignados) ------------------------------------------------
                                DataTable tb = SerealizeDetallePerfil(listaDetallesPerfil, intIdFiltroOut);

                                SqlCommand cmd1 = new SqlCommand("TSP_TSPERFIL_MENU_IU02", cn);
                                cmd1.Transaction = trans;
                                cmd1.CommandType = CommandType.StoredProcedure;
                                cmd1.CommandTimeout = timeSQL;
                                Dictionary<string, object> param1 = new Dictionary<string, object>();
                                param1.Add("@intIdSesion", intIdSesion);
                                param1.Add("@intIdMenu", intIdMenu);
                                param1.Add("@intIdSoft", intIdSoft);
                                param1.Add("@tt_TSPERFIL_MENU", tb);

                                param1.Add("@intResult", 0);
                                param1.Add("@strMsjDB", "");
                                param1.Add("@strMsjUsuario", "");

                                AsignarParametros(cmd1, param1);
                                cmd1.ExecuteNonQuery();
                                intResult = Convert.ToInt32(cmd1.Parameters["@intResult"].Value.ToString());
                                strMsjDB = cmd1.Parameters["@strMsjDB"].Value.ToString();
                                strMsjUsuario = cmd1.Parameters["@strMsjUsuario"].Value.ToString();

                                if (intResult == 0)
                                {
                                    trans.Rollback();//añadido 14.04.2021
                                    if (intTipoOperacion == 1)
                                    {
                                        Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TSPERFIL_MENU_IU02";
                                    }
                                    else
                                    {
                                        Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TSPERFIL_MENU_IU02";
                                    }
                                }
                            }
                            else
                            {
                                if (!strMsjDB.Equals("") && strMsjUsuario.Equals(""))
                                {
                                    trans.Rollback();//añadido 14.04.2021
                                    if (intTipoOperacion == 1) {
                                        Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TSPERFIL_IU01";
                                    }
                                    else
                                    {
                                        Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TSPERFIL_IU01";
                                    }
                                }
                            }
                            Rpta_SP = intResult;
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            throw ex;
                        }

                        //Solo si todos los SP salen 1, se hace commit
                        if (Rpta_SP > 0 && strMsjDB.Equals("") && strMsjUsuario.Equals(""))
                        {
                            trans.Commit();
                        }
                        else
                        {
                            trans.Rollback();
                            if (intTipoOperacion == 1)
                            {
                                Msj = "No se pudo completar la inserción.";
                            }
                            else
                            {
                                Msj = "No se pudo completar la actualización.";
                            }
                        }
                    }
                    cn.Close();
                }
            }
            catch (System.Exception ex)
            {
                if (intTipoOperacion == 1)
                {
                    strMsjDB = "No se pudo completar la inserción, debido al siguiente error: " + ex.Message;
                    Msj = "No se pudo completar la inserción, revisar los logs del Servicio.";
                }
                else
                {
                    strMsjDB = "No se pudo completar la actualización, debido al siguiente error: " + ex.Message;
                    Msj = "No se pudo completar la actualización, revisar los logs del Servicio.";
                }
            }
            return Rpta_SP;//devuelve 1 = ok / 0 = error
        }
        //3.5
        public bool EliminarPerfil(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdPerfil, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSPERFIL_D02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@intIdPerfil", intIdPerfil);
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
        //3.6
        public List<TS_PERFIL> ObtenerRegistroPerfil(long intIdSesion, int intIdMenu, int intIdSoft, int IntIdPerfil, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TS_PERFIL> listaFiltro = new List<TS_PERFIL>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSPERFIL_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@IntIdPerfil", IntIdPerfil);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TS_PERFIL obj = new TS_PERFIL();
                        obj.strCoPerfil = reader.GetString(0);
                        obj.strDesPerfil = reader.GetString(1);
                        obj.bitFlAdmin = reader.GetBoolean(2);
                        obj.bitFlActivo = reader.GetBoolean(4);

                        listaFiltro.Add(obj);
                    }
                }
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listaFiltro;
        }
        //3.7
        private DataTable SerealizeDetallePerfil(List<TT_TSPERFIL_MENU> listaDetallesPerfil, int intIdPerfil)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdPerfM", typeof(int));
            table.Columns.Add("intIdPerfil", typeof(int));
            table.Columns.Add("intIdSoft", typeof(int));
            table.Columns.Add("intIdMenu", typeof(int));
            table.Columns.Add("bitFlEliminado", typeof(bool));

            foreach (var item in listaDetallesPerfil)
            {
                DataRow rows = table.NewRow();
                rows["intIdPerfM"] = item.intIdPerfM;
                rows["intIdPerfil"] = intIdPerfil;
                rows["intIdSoft"] = item.intIdSoft;
                rows["intIdMenu"] = item.intIdMenu;
                rows["bitFlEliminado"] = item.bitFlEliminado;

                table.Rows.Add(rows);
            }
            return table;
        }
        
        //3.19
        public List<TS_MENU> MenuPorUsuario(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuar, int intIdPerfil, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TS_MENU> lista = new List<TS_MENU>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_LOGIN_MENU_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdUsuar", intIdUsuar);
                param.Add("@intIdPerfil", intIdPerfil);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TS_MENU obj = new TS_MENU();
                    obj.intIdMenu = reader.GetInt32(0);
                    obj.strCoMenu = reader.GetString(1);
                    obj.strSubMenu = reader.GetString(2);
                    obj.strCoMenuRela = reader.GetString(3);
                    obj.strNomMenu = reader.GetString(4);
                    obj.intIsSelecc = reader.GetInt32(5);
                    obj.strDesFormu = reader.GetString(6);
                    obj.strNomFormu = reader.GetString(7);

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
