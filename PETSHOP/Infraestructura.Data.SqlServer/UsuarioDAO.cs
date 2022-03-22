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
    public class UsuarioDAO : Conexion
    {
        //3.8
        public List<TG_USUARIO> ListarUsuarios(long intIdSesion, int intIdMenu, int intIdSoft, int intActivo, string strDescripcion, int intTipoFiltro, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TG_USUARIO> lista = new List<TG_USUARIO>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSUSUARIO_Q02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intActivo", intActivo);
                param.Add("@strFiltro", strDescripcion);
                param.Add("@intTipoFiltro", intTipoFiltro);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TG_USUARIO obj = new TG_USUARIO();

                    obj.intIdUsuar = reader.GetInt32(0);
                    obj.strUsUsuar = reader.GetString(1);
                    obj.strNoUsuar = reader.GetString(2);
                    obj.strstrDesPerfil = reader.GetString(3);
                    obj.strDesEmp = reader.GetString(4);
                    obj.strEstadoActivo = reader.GetString(5);

                    lista.Add(obj);
                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return lista;
        }
        //3.9
        public bool EliminarUsuario(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdUsu, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSUSUARIO_D02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@intIdUsu", intIdUsu);
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
        //3.10
        public int IUsuario_T(long intIdSesion, int intIdMenu, int intIdSoft, TG_USUARIO objDatos, int intIdUsuario, int intTipoOperacion, List<TSUSUAR_PERFI> listaDetallesUsuarioPerfil, List<TT_TSUSUAR_FILTRO> listaDetallesUsuarioFiltro, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string Msj)
        {
            int intIdUsuarioOut = 0;
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
                            SqlCommand cmd = new SqlCommand("TSP_TSUSUARIO_IU01", cn);
                            cmd.Transaction = trans;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = timeSQL;

                            //Codificar contraseña actual para validación
                            //byte[] byt = System.Text.Encoding.UTF8.GetBytes(objDatos.strCoPassw);
                            //string strcontraseña2 = Convert.ToBase64String(byt);
                            string strcontraseña2 = EncriptarPassword(objDatos.strCoPassw);//encapsulado 15.04.2021 ES

                            Dictionary<string, object> param = new Dictionary<string, object>();
                            param.Add("@intIdSesion", intIdSesion);
                            param.Add("@intIdMenu", intIdMenu);
                            param.Add("@intIdSoft", intIdSoft);
                            if (intTipoOperacion == 1)
                            {
                                param.Add("@intIdUsuar", 0);
                            }
                            else
                            {
                                param.Add("@intIdUsuar", objDatos.intIdUsuar);
                            }
                            param.Add("@bitTipoUsuar", objDatos.bitTipoUsuar);
                            param.Add("@strUsUsuar", objDatos.strUsUsuar);
                            param.Add("@strCoPassw", strcontraseña2);
                            param.Add("@strNoUsuar", objDatos.strNoUsuar);
                            param.Add("@bitFlAdmin", objDatos.bitFlAdmin);
                            param.Add("@bitPrimerPassw", objDatos.bitPrimerPassw);
                            param.Add("@tinFlEstado", objDatos.tinFlEstado);
                            param.Add("@strMotivoEst", objDatos.strMotivoEst);
                            param.Add("@dttFchBloqueo", objDatos.dttFchBloqueo);
                            param.Add("@dttFchUltPass", objDatos.dttFchUltPass);
                            param.Add("@dttFchCaduca", objDatos.dttFchCaduca);
                            param.Add("@intIdPersonal", objDatos.intIdPersonal);
                            param.Add("@bitFlActivo", objDatos.bitFlActivo);
                            param.Add("@intIdUsuario", intIdUsuario);
                            param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update
                            //Parámetros de Salida
                            param.Add("@intResult", 0);
                            param.Add("@strMsjDB", "");
                            param.Add("@strMsjUsuario", "");

                            AsignarParametros(cmd, param);
                            cmd.ExecuteNonQuery();

                            intIdUsuarioOut = Convert.ToInt32(cmd.Parameters["@intIdUsuar"].Value.ToString());
                            intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                            strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                            strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

                            if (intIdUsuarioOut > 0 && intResult > 0)
                            {
                                //----- TABLA 1: Asignación de perfil ------------------------------------------------
                                DataTable tb1 = SerealizeDetalleUsuarioPerfil(listaDetallesUsuarioPerfil, intIdUsuarioOut);
                               
                                SqlCommand cmd1 = new SqlCommand("TSP_TSUSUAR_PERFI_IU03", cn);
                                cmd1.Transaction = trans;
                                cmd1.CommandType = CommandType.StoredProcedure;
                                cmd1.CommandTimeout = timeSQL;
                                Dictionary<string, object> param1 = new Dictionary<string, object>();
                                param1.Add("@intIdSesion", intIdSesion);
                                param1.Add("@intIdMenu", intIdMenu);
                                param1.Add("@intIdSoft", intIdSoft);
                                param1.Add("@tt_TSUSUAR_PERFI", tb1);

                                param1.Add("@intResult", 0);
                                param1.Add("@strMsjDB", "");
                                param1.Add("@strMsjUsuario", "");

                                AsignarParametros(cmd1, param1);
                                cmd1.ExecuteNonQuery();
                                intResult = Convert.ToInt32(cmd1.Parameters["@intResult"].Value.ToString());
                                strMsjDB = cmd1.Parameters["@strMsjDB"].Value.ToString();
                                strMsjUsuario = cmd1.Parameters["@strMsjUsuario"].Value.ToString();

                                int c = listaDetallesUsuarioFiltro.ToList().Count();
                                if (intIdUsuarioOut > 0 && intResult > 0 && c > 0) //SI SOLO SI tiene filtros.
                                {
                                    //----- TABLA 2: Asignación de filtros ------------------------------------------------
                                    DataTable tb2 = SerealizeDetalleUsuarioFiltro(listaDetallesUsuarioFiltro, intIdUsuarioOut);

                                    SqlCommand cmd2 = new SqlCommand("TSP_TSUSUAR_FILTRO_IU02", cn);
                                    cmd2.Transaction = trans;
                                    cmd2.CommandType = CommandType.StoredProcedure;
                                    cmd2.CommandTimeout = timeSQL;
                                    Dictionary<string, object> param2 = new Dictionary<string, object>();
                                    param2.Add("@intIdSesion", intIdSesion);
                                    param2.Add("@intIdMenu", intIdMenu);
                                    param2.Add("@intIdSoft", intIdSoft);
                                    param.Add("@tt_TSUSUAR_FILTRO", tb2);

                                    param2.Add("@intResult", 0);
                                    param2.Add("@strMsjDB", "");
                                    param2.Add("@strMsjUsuario", "");

                                    AsignarParametros(cmd2, param2);
                                    cmd2.ExecuteNonQuery();
                                    intResult = Convert.ToInt32(cmd2.Parameters["@intResult"].Value.ToString());
                                    strMsjDB = cmd2.Parameters["@strMsjDB"].Value.ToString();
                                    strMsjUsuario = cmd2.Parameters["@strMsjUsuario"].Value.ToString();

                                    if (intResult == 0)
                                    {
                                        trans.Rollback();//añadido 14.04.2021
                                        if (intTipoOperacion == 1)
                                        {
                                            Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TSUSUAR_FILTRO_IU02";
                                        }
                                        else
                                        {
                                            Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TSUSUAR_FILTRO_IU02";
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
                                            Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TSUSUAR_PERFI_IU03";
                                        }
                                        else
                                        {
                                            Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TSUSUAR_PERFI_IU03";
                                        }
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
                                        Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TSUSUARIO_IU01";
                                    }
                                    else
                                    {
                                        Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TSUSUARIO_IU01";
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
        //3.11
        public List<TG_USUARIO> ObtenerRegistroUsuario(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuar, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TG_USUARIO> listaUsuario = new List<TG_USUARIO>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSUSUARIO_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdUsuar", intIdUsuar);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TG_USUARIO obj = new TG_USUARIO();
                        //decodificar
                        string strcontraseña2 = DesencriptarPassword(reader.GetString(2));//encapsulado 15.04.2021 ES

                        obj.intIdUsuar = reader.GetInt32(0);
                        obj.strUsUsuar = reader.GetString(1);
                        obj.strCoPassw = strcontraseña2;
                        obj.strNoUsuar = reader.GetString(3);
                        obj.intIdPerfil = reader.GetInt32(4);
                        obj.bitFlActivo = reader.GetBoolean(5);

                        listaUsuario.Add(obj);
                    }

                }
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listaUsuario;
        }
        //3.12
        //Añadido 06.07.21
        public List<TG_USUARIO> ValidarUsuario(long intIdSesion, int intIdMenu, int intIdSoft, string strusuario, string strcontraseña, string strIpHost, string strCoSoft, ref int Valida, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TG_USUARIO> listaUsuario = new List<TG_USUARIO>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_LOGIN_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                //Codificar contraseña actual para validacion
                //byte[] byt = System.Text.Encoding.UTF8.GetBytes(strcontraseña);
                //string strcontraseña2 = Convert.ToBase64String(byt);
                string strcontraseña2 = EncriptarPassword(strcontraseña);//encapsulado 15.04.2021 ES

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@strUsUsuar", strusuario);
                param.Add("@strCoPassw", strcontraseña2);
                param.Add("@strCoSoft", strCoSoft);
                //Añadido 07.07.21 10:11AM HGM
                param.Add("@strIpHost", strIpHost);
                //salida
                param.Add("@Valida", 5);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TG_USUARIO obj = new TG_USUARIO();
                        obj.intIdUsuar = reader.GetInt32(0);
                        if (!reader.IsDBNull(1))
                        {
                            obj.strNoUsuar = reader.GetString(1);
                        }
                        if (!reader.IsDBNull(2))
                        {
                            obj.intIdPerfil = reader.GetInt32(2);
                        }
                        if (!reader.IsDBNull(3))
                        {
                            obj.strNomPerfil = reader.GetString(3);
                        }
                        if (!reader.IsDBNull(4))
                        {
                            obj.intIdSesion = reader.GetInt32(4);
                        }
                        if (!reader.IsDBNull(5))
                        {
                            obj.strUserName = reader.GetString(5);
                        }
                        if (!reader.IsDBNull(6))
                        {
                            obj.intIdSoft = reader.GetInt32(6);
                        }
                        if (!reader.IsDBNull(7))
                        {
                            obj.intCodValida = reader.GetInt32(7);
                        }
                        if (!reader.IsDBNull(8))
                        {
                            obj.strDetalleValida = reader.GetString(8);
                        }
                        if (!reader.IsDBNull(9))
                        {
                            obj.imgFoto = reader.GetString(9);
                        }
                        if (!reader.IsDBNull(10))
                        {
                            obj.intIdPersonal = reader.GetInt32(10);
                        }
                        listaUsuario.Add(obj);
                    }
                }

                Valida = Convert.ToInt32(cmd.Parameters["@Valida"].Value.ToString());
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listaUsuario;
        }
        //3.13
        public bool ActualizarPasswrMx(long intIdSesion, int intIdMenu, int intIdSoft, string strUsUsuar, string strCoPassw, string strNwPassw, int intIdUsuario, ref string strEstado, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_ACTUALIZAR_PASSWORD_U01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                //Clave actual
                //byte[] byt = System.Text.Encoding.UTF8.GetBytes(strCoPassw);
                //string strcontraseña2 = Convert.ToBase64String(byt);
                string strcontraseña2 = EncriptarPassword(strCoPassw);//encapsulado 15.04.2021 ES

                //Clave nueva
                byte[] bytNueva = System.Text.Encoding.UTF8.GetBytes(strNwPassw);
                string strContrasenaNueva = Convert.ToBase64String(bytNueva);

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);//parametros de entrada

                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@strUsUsuar", strUsUsuar);
                param.Add("@strCoPassw", strcontraseña2);
                param.Add("@strNwPassw", strContrasenaNueva);

                param.Add("@strEstado", "");
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();

                strEstado = cmd.Parameters["@strEstado"].Value.ToString();
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return Convert.ToBoolean(intResult);
        }
        //3.14
        public bool RestablecerContra(Session_Movi objSession, string strNwPassw, int intIdPersonal, ref string strEstado, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_RESTABLECER_PASSWORD_U01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                //byte[] byt = System.Text.Encoding.UTF8.GetBytes(strNwPassw);
                //string strcontrasena = Convert.ToBase64String(byt);
                string strcontraseña2 = EncriptarPassword(strNwPassw);//encapsulado 15.04.2021 ES

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);//parametros de entrada
                param.Add("@intIdUsuario", objSession.intIdUsuario);

                param.Add("@strCoPassw", strcontraseña2);
                param.Add("@intIdPersonal", intIdPersonal);                

                param.Add("@strEstado", "");
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();

                strEstado = cmd.Parameters["@strEstado"].Value.ToString();
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return Convert.ToBoolean(intResult);
        }
        //3.15
        private DataTable SerealizeDetalleUsuarioFiltro(List<TT_TSUSUAR_FILTRO> listaDetallesUsuarioFiltro, int intIdUsuar)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdUsFiltro", typeof(int));
            table.Columns.Add("intIdUsuar", typeof(int));
            table.Columns.Add("intIdEmp", typeof(int));
            table.Columns.Add("intIdLocal", typeof(int));
            table.Columns.Add("intIdArea", typeof(int));
            table.Columns.Add("bitFlActivo", typeof(bool));
            table.Columns.Add("bitFlEliminado", typeof(bool));

            foreach (var item in listaDetallesUsuarioFiltro)
            {
                DataRow rows = table.NewRow();
                rows["intIdUsFiltro"] = item.intIdUsFiltro;
                rows["intIdUsuar"] = intIdUsuar;
                rows["intIdEmp"] = item.intIdEmp;
                rows["intIdLocal"] = item.intIdLocal;
                rows["intIdArea"] = item.intIdArea;
                rows["bitFlActivo"] = item.bitFlActivo;
                rows["bitFlEliminado"] = item.bitFlEliminado;

                table.Rows.Add(rows);
            }
            return table;
        }
        //3.16
        private DataTable SerealizeDetalleUsuarioPerfil(List<TSUSUAR_PERFI> listaDetallesUsuarioPerfil, int intIdUsuar)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdUsPerf", typeof(int));
            table.Columns.Add("intIdUsuar", typeof(int));
            table.Columns.Add("intIdPerfil", typeof(int));
            table.Columns.Add("bitFlPrincipal", typeof(bool));
            table.Columns.Add("bitFlActivo", typeof(bool));
            table.Columns.Add("bitFlEliminado", typeof(bool));

            foreach (var item in listaDetallesUsuarioPerfil)
            {
                DataRow rows = table.NewRow();
                rows["intIdUsPerf"] = item.intIdUsPerf;
                rows["intIdUsuar"] = intIdUsuar;
                rows["intIdPerfil"] = item.intIdPerfil;
                rows["bitFlPrincipal"] = item.bitFlPrincipal;
                rows["bitFlActivo"] = item.bitFlActivo;
                rows["bitFlEliminado"] = item.bitFlEliminado;

                table.Rows.Add(rows);
            }
            return table;
        }
        //3.20
        public string EncriptarPassword(string strCoPassw)
        {
            //Codificar contraseña actual para validación
            string strcontraseña = "";
            byte[] byt = System.Text.Encoding.UTF8.GetBytes(strCoPassw);
            strcontraseña = Convert.ToBase64String(byt);
            return strcontraseña;
        }
        //3.21 ----> Lo cambiamos de private a public 02.07.21
        public string DesencriptarPassword(string strCoPassw)
        {
            string strcontraseña = "";
            byte[] b = Convert.FromBase64String(strCoPassw);
            strcontraseña = System.Text.Encoding.UTF8.GetString(b);
            return strcontraseña;
        }

        /*****
        //3.22.3  ----> 02.07.21
        public string DesencriptarPassword(string strCoPassw)
        {
            string strcontraseña = "";
            byte[] b = Convert.FromBase64String(strCoPassw);
            strcontraseña = System.Text.Encoding.UTF8.GetString(b);
            return strcontraseña;
        }
        *****/

    }
}

