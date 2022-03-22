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
    public class JerarquiaOrgDAO : Conexion
    {
        //1.1
        public List<JerarquiaOrg> ListarJerarquiaOrg(long intIdSesion, int intIdMenu, int intIdSoft, string strfilter, int intActivoFilter, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<JerarquiaOrg> lista = new List<JerarquiaOrg>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGJERARQORG_Q07", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@strfilter", strfilter);
                param.Add("@intActivoFilter", intActivoFilter);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    JerarquiaOrg obj = new JerarquiaOrg();
                    Estado objEstado = new Estado();
                    obj.IntIdJerOrg = reader.GetInt32(0);
                    obj.strCoIntJO = reader.GetString(1);
                    obj.strCoJerOrg = reader.GetString(2);
                    obj.strNomJerOrg = reader.GetString(3);
                    obj.intNivelJer = reader.GetString(4);
                    objEstado.bitFlActivo = reader.GetBoolean(5);
                    objEstado.strEstadoActivo = reader.GetString(6);
                    if (!reader.IsDBNull(6))
                        obj.strCoJerPadre = reader.GetString(7);
                
                    obj.strNomJerPadre = reader.GetString(8);
                    obj.strJerarCampo1 = reader.GetString(9);
                    obj.strJerarCampo2 = reader.GetString(10);
                    obj.strJerarCampo3 = reader.GetString(11);
                    obj.strJerarCampo4 = reader.GetString(12);
                    obj.strJerarCampo5 = reader.GetString(13);
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
        //1.2
        public List<JerarquiaOrg> ListarJerarquíaSuperior_xNivel(long intIdSesion, int intIdMenu, int intIdSoft, int intNivelJer, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<JerarquiaOrg> lista = new List<JerarquiaOrg>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGJERARQORG_Q04", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intNivelJer", intNivelJer);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    JerarquiaOrg obj = new JerarquiaOrg();
                    obj.strCoIntJO = reader.GetString(0);
                    obj.strNomJerOrg = reader.GetString(1);

                    lista.Add(obj);
                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return lista;
        }
        //1.3
        public List<int> ListarNivelJerarquico(long intIdSesion, int intIdMenu, int intIdSoft, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<int> lista = new List<int>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGJERARQORG_Q05", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(reader.GetInt32(0));
                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return lista;
        }
        //1.4
        public int GetNumJeraquia(ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            int numero = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSCONFIG_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                numero = Int32.Parse(cmd.ExecuteScalar().ToString());
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return numero;
        }
        //1.5
        public JerarquiaOrg ConsultarJerarquiaOrg(long intIdSesion, int intIdMenu, int intIdSoft, int IntIdJerOrg, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            JerarquiaOrg objJer = null;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGJERARQORG_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@IntIdJerOrg", IntIdJerOrg);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    objJer = new JerarquiaOrg();
                    Estado objEstado = new Estado();
                    objJer.strCoIntJO = reader.GetString(1);
                    objJer.strCoJerOrg = reader.GetString(2);
                    objJer.strNomJerOrg = reader.GetString(3);
                    objJer.intNivelJer = reader.GetString(4);
                    if (!reader.IsDBNull(5))
                        objJer.strCoJerPadre = reader.GetString(5);
                    objEstado.bitFlActivo = reader.GetBoolean(11);
                    objJer.FlActivo = objEstado;
                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return objJer;
        }
        //1.6
        public List<DetalleJerarquiaOrg> ConsultarDetalleJerarquia_xCod(long intIdSesion, int intIdMenu, int intIdSoft, string strCoIntJO, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<DetalleJerarquiaOrg> listDetJer = new List<DetalleJerarquiaOrg>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGJER_CAMPO_DET_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@strCoIntJO", strCoIntJO);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DetalleJerarquiaOrg obj = new DetalleJerarquiaOrg();
                        obj.IntIdJerOrg = reader.GetInt32(1);
                        obj.strCoIntJO = reader.GetString(2);
                        obj.intIdCampo = reader.GetInt32(3);
                        obj.strCoCampo = reader.GetString(4);
                        obj.bitObligatorio = reader.GetBoolean(5);
                        listDetJer.Add(obj);
                    }
                }
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listDetJer;
        }
        //1.7
        public int IUJerarquiaOrg_T(long intIdSesion, int intIdMenu, int intIdSoft, JerarquiaOrg objDatos, List<DetalleJerarquiaOrg> detalle, int intIdUsuario, int intTipoOperacion, ref string strCoIntJO, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string Msj)
        {
            int IntIdJerOrgOut = 0;
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
                            SqlCommand cmd = new SqlCommand("TSP_TGJERARQORG_IU01", cn);
                            cmd.Transaction = trans;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = timeSQL;
                            Dictionary<string, object> param = new Dictionary<string, object>();
                            param.Add("@intIdSesion", intIdSesion);
                            param.Add("@intIdMenu", intIdMenu);
                            param.Add("@intIdSoft", intIdSoft);
                            param.Add("@IntIdJerOrg", objDatos.IntIdJerOrg);

                            if (objDatos.strCoIntJO == null)
                                param.Add("@strCoIntJO", "");
                            else
                                param.Add("@strCoIntJO", objDatos.strCoIntJO);
                            param.Add("@strCoJerOrg", objDatos.strCoJerOrg);
                            param.Add("@strNomJerOrg", objDatos.strNomJerOrg);
                            param.Add("@intNivelJer", objDatos.intNivelJer);
                            param.Add("@strCoJerPadre", objDatos.strCoJerPadre);
                            param.Add("@strJerarCampo1", objDatos.strJerarCampo1);
                            param.Add("@strJerarCampo2", objDatos.strJerarCampo2);
                            param.Add("@strJerarCampo3", objDatos.strJerarCampo3);
                            param.Add("@strJerarCampo4", objDatos.strJerarCampo4);
                            param.Add("@strJerarCampo5", objDatos.strJerarCampo5);
                            param.Add("@bitFlActivo", objDatos.FlActivo.bitFlActivo);
                            param.Add("@intIdUsuario", intIdUsuario);
                            param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update
                            //Parámetros de Salida
                            param.Add("@intResult", 0);
                            param.Add("@strMsjDB", "");
                            param.Add("@strMsjUsuario", "");
                            AsignarParametros(cmd, param);
                            cmd.ExecuteNonQuery();

                            IntIdJerOrgOut = Convert.ToInt32(cmd.Parameters["@IntIdJerOrg"].Value.ToString());
                            intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                            strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                            strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
                            strCoIntJO = cmd.Parameters["@strCoIntJO"].Value.ToString();

                            if (IntIdJerOrgOut > 0 && intResult > 0)
                            {
                                //----- TABLA 1: detalles de la jerarquia ----------------------------------------------------------------
                                  DataTable tb = SerealizeDetalleJerarquia(detalle, IntIdJerOrgOut, strCoIntJO);

                                SqlCommand cmd1 = new SqlCommand("TSP_TGJER_CAMPO_DET_IU02", cn);
                                cmd1.Transaction = trans;
                                cmd1.CommandType = CommandType.StoredProcedure;
                                cmd1.CommandTimeout = timeSQL;
                                Dictionary<string, object> param1 = new Dictionary<string, object>();
                                param1.Add("@intIdSesion", intIdSesion);
                                param1.Add("@intIdMenu", intIdMenu);
                                param1.Add("@intIdSoft", intIdSoft);
                                param1.Add("@tt_TGJER_CAMPO_DET", tb);
                                param1.Add("@intIdUsuario", intIdUsuario);

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
                                        Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGJER_CAMPO_DET_IU02";
                                    }
                                    else
                                    {
                                        Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGJER_CAMPO_DET_IU02";
                                    }
                                }
                            }
                            else
                            {
                                if (!strMsjDB.Equals("") && strMsjUsuario.Equals(""))
                                {
                                    trans.Rollback();//añadido 14.04.2021
                                    if (intTipoOperacion == 1)
                                    {
                                        Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGJERARQORG_IU01";
                                    }
                                    else
                                    {
                                        Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGJERARQORG_IU01";
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
                                Msj = "No se pudo completar la inserción";
                            }
                            else
                            {
                                Msj = "No se pudo completar la actualización";
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
        //1.8
        public bool EliminarJerarquiaOrg(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int IntIdJerOrg, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGJERARQORG_D02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@IntIdJerOrg", IntIdJerOrg);
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

        #region métodos privados
        //1.10
        private DataTable SerealizeDetalleJerarquia(List<DetalleJerarquiaOrg> listaDet, int IntIdJerOrg, string strCoIntJO)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdJerCampo", typeof(int));
            table.Columns.Add("IntIdJerOrg", typeof(int));
            table.Columns.Add("strCoIntJO", typeof(string));
            table.Columns.Add("intIdCampo", typeof(int));
            table.Columns.Add("strCoCampo", typeof(string));
            table.Columns.Add("bitObligatorio", typeof(bool));

            foreach (var item in listaDet)
            {
                DataRow rows = table.NewRow();
                rows["intIdJerCampo"] = item.intIdJerCampo;
                rows["IntIdJerOrg"] = IntIdJerOrg;
                rows["strCoIntJO"] = strCoIntJO;
                rows["intIdCampo"] = item.intIdCampo;
                rows["strCoCampo"] = item.strCoCampo;
                rows["bitObligatorio"] = item.bitObligatorio;
                table.Rows.Add(rows);
            }
            return table;
        }
        #endregion métodos privados

    }
}
