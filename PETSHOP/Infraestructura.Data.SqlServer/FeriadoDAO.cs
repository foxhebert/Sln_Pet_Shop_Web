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
    public class FeriadoDAO : Conexion
    {
        //2.1
        public List<TSPTAASISTENCIA> ObtenerAsistenciaXFecha(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, string filtrojer_ini, string filtrojer_fin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TSPTAASISTENCIA> lista = new List<TSPTAASISTENCIA>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TAASISTENCIA_Q02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);

                param.Add("@intIdPersonal", intIdPersonal);
                param.Add("@filtrojer_ini", filtrojer_ini);
                param.Add("@filtrojer_fin", filtrojer_fin);

                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TSPTAASISTENCIA obj = new TSPTAASISTENCIA();

                    obj.anio = reader.GetInt32(0);
                    obj.mes = reader.GetInt32(1);
                    obj.asistencia = reader.GetInt32(2);
                    obj.faltas = reader.GetInt32(3);

                    lista.Add(obj);
                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //2.2
        public List<Feriado> ListarFeriados(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, string intfiltrojer1, string intfiltrojer2, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Feriado> lista = new List<Feriado>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGFERIADO_Q02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);


                param.Add("@intActivoFilter", intActivoFilter);
                param.Add("@strfilter", strfilter);
                param.Add("@intfiltrojer1", intfiltrojer1);
                param.Add("@intfiltrojer2", intfiltrojer2);
                
                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Feriado obj = new Feriado();
                    
                    obj.IntIdFeriado = reader.GetInt32(0);
                    obj.strDeFeriado = reader.GetString(1);
                    obj.bitRegEspecif = reader.GetBoolean(2);
                    obj.intTipoReg = reader.GetInt32(3);
                    obj.bitRegEspecif_desc = reader.GetString(4);
                    obj.bitRecursiv_desc = reader.GetString(9);
                    obj.dttfechaIni = Convert.ToString(reader.GetString(10));
                    obj.bitEspecifica_DESC = reader.GetString(11);
                    obj.bitFlActivo_desc = reader.GetString(19);
                    obj.CAMPO_CONCAT = reader.GetString(20);

                    
                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //2.3
        public bool EliminmarFeriado(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdFeriado, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGFERIADO_D02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@intIdFeriado", intIdFeriado);
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
        //2.4
        public int IUFeriado_T(long intIdSesion, int intIdMenu, int intIdSoft, Feriado objDatos, List<TGFER_UNIORG_DET> listaOrgxFer, int intIdUsuario, int intTipoOperacion, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string Msj)
        {
            int intIdFeriadoOut = 0;
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
                            SqlCommand cmd = new SqlCommand("TSP_TGFERIADO_IU01", cn);
                            cmd.Transaction = trans;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = timeSQL;
                            Dictionary<string, object> param = new Dictionary<string, object>();
                            param.Add("@intIdSesion", intIdSesion);
                            param.Add("@intIdMenu", intIdMenu);
                            param.Add("@intIdSoft", intIdSoft);//parametros de entrada
                            param.Add("@bitRegEspecif", objDatos.bitRegEspecif);
                            param.Add("@strDeFeriado", objDatos.strDeFeriado);
                            param.Add("@intTipoReg", objDatos.intTipoReg);
                            param.Add("@intIdConcepto", objDatos.intIdConcepto);

                            if (objDatos.timeHoraIni == null)
                                param.Add("@timeHoraIni", DBNull.Value);
                            else
                                param.Add("@timeHoraIni", objDatos.timeHoraIni);

                            if (objDatos.timeHoraFin == null)
                                param.Add("@timeHoraFin", DBNull.Value);
                            else
                                param.Add("@timeHoraFin", objDatos.timeHoraFin);

                            param.Add("@bitRecursiv", objDatos.bitRecursiv);
                            param.Add("@intTipoRec", objDatos.intTipoRec);
                            param.Add("@dttfechaIni", objDatos.dttfechaIni);
                            //param.Add("@intDuracion", objDatos.intDuracion);
                            param.Add("@bitEspecifica", objDatos.bitEspecifica);

                            if (objDatos.strFeriaCampo1 == null)
                                param.Add("@strFeriaCampo1", DBNull.Value);
                            else
                                param.Add("@strFeriaCampo1", objDatos.strFeriaCampo1);

                            if (objDatos.strFeriaCampo2 == null)
                                param.Add("@strFeriaCampo2", DBNull.Value);
                            else
                                param.Add("@strFeriaCampo2", objDatos.strFeriaCampo2);

                            if (objDatos.strFeriaCampo3 == null)
                                param.Add("@strFeriaCampo3", DBNull.Value);
                            else
                                param.Add("@strFeriaCampo3", objDatos.strFeriaCampo3);

                            if (objDatos.strFeriaCampo4 == null)
                                param.Add("@strFeriaCampo4", DBNull.Value);
                            else
                                param.Add("@strFeriaCampo4", objDatos.strFeriaCampo4);

                            if (objDatos.strFeriaCampo5 == null)
                                param.Add("@strFeriaCampo5", DBNull.Value);
                            else
                                param.Add("@strFeriaCampo5", objDatos.strFeriaCampo5);

                            param.Add("@bitFlActivo", objDatos.bitFlActivo);
                            param.Add("@intIdUsuario", intIdUsuario);
                            param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update
                            //Parámetros de Salida
                            if (intTipoOperacion == 1)
                            {
                                param.Add("@intIdFeriado", 0);
                            }
                            else
                            {
                                param.Add("@intIdFeriado", objDatos.IntIdFeriado);
                            }
                            param.Add("@intResult", 0);
                            param.Add("@strMsjDB", "");
                            param.Add("@strMsjUsuario", "");

                            AsignarParametros(cmd, param);
                            cmd.ExecuteNonQuery();

                            intIdFeriadoOut = Convert.ToInt32(cmd.Parameters["@intIdFeriado"].Value.ToString());
                            intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                            strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                            strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

                            if (intIdFeriadoOut > 0 && intResult > 0)
                            {
                                //----- TABLA 1: detalle de locales (Unidades Organizacionales) ------------------------------------------------
                                DataTable tb = SerealizeDetalleUnidadOrgFeriado(listaOrgxFer, intIdFeriadoOut);

                                SqlCommand cmd1 = new SqlCommand("TSP_TGFER_UNIORG_DET_IU02", cn);
                                cmd1.Transaction = trans;
                                cmd1.CommandType = CommandType.StoredProcedure;
                                cmd1.CommandTimeout = timeSQL;
                                Dictionary<string, object> param1 = new Dictionary<string, object>();
                                param1.Add("@intIdSesion", intIdSesion);
                                param1.Add("@intIdMenu", intIdMenu);
                                param1.Add("@intIdSoft", intIdSoft);
                                param1.Add("@tt_TGFER_UNIORG_DET", tb);

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
                                        Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGFER_UNIORG_DET_IU02";
                                    }
                                    else
                                    {
                                        Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGFER_UNIORG_DET_IU02";
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
                                        Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGFERIADO_IU01";
                                    }
                                    else
                                    {
                                        Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGFERIADO_IU01";
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
        //2.5
        public List<Feriado> ObtenerRegistroFeriado(long intIdSesion, int intIdMenu, int intIdSoft, int intIdFeriado, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Feriado> listDetCar = new List<Feriado>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGFERIADO_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);



                param.Add("@intIdFeriado", intIdFeriado);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Feriado obj = new Feriado();
                        obj.IntIdFeriado = reader.GetInt32(0);
                        obj.strDeFeriado = reader.GetString(1);
                        obj.intTipoReg = reader.GetInt32(3);
                        obj.intIdConcepto = reader.GetInt32(5);
                        obj.timeHoraIni_desc = reader.GetString(7);
                        obj.timeHoraFin_desc = reader.GetString(8);
                        obj.bitRecursiv = reader.GetBoolean(9);
                        obj.intTipoRec = reader.GetInt32(10);
                        obj.dttfechaIni = reader.GetString(12);
                        obj.bitEspecifica = reader.GetBoolean(13);
                        obj.strFeriaCampo1 = reader.GetString(15);
                        obj.strFeriaCampo2 = reader.GetString(16);
                        obj.strFeriaCampo3 = reader.GetString(17);
                        obj.strFeriaCampo4 = reader.GetString(18);
                        obj.strFeriaCampo5 = reader.GetString(19);
                        obj.bitFlActivo = reader.GetBoolean(20);

                        listDetCar.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listDetCar;
        }
        //2.6
        public List<TGFER_UNIORG_DET> ObtenerRegistroReglaDetalleDeOrgixFer(long intIdSesion, int intIdMenu, int intIdSoft, int intIdFeriado, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGFER_UNIORG_DET> listDetCar = new List<TGFER_UNIORG_DET>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGFER_UNIORG_DET_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);



                param.Add("@intIdFeriado", intIdFeriado);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        TGFER_UNIORG_DET obj = new TGFER_UNIORG_DET();
                        obj.intIdFerUniOrg = reader.GetInt32(0);
                        obj.intIdFeriado = reader.GetInt32(1);
                        obj.intIdUniOrg = reader.GetInt32(2);
                        obj.IntIdJerOrg = reader.GetInt32(3);


                        listDetCar.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listDetCar;
        }
        //2.7
        public List<TGTipoEN> ListarCampRecur(long intIdSesion, int intIdMenu, int intIdSoft, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGFERIADO_Q06", cn);
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
                    TGTipoEN obj = new TGTipoEN();

                    obj.intidTipo = reader.GetInt32(0);
                    obj.strDeTipo = reader.GetString(1);

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //2.8
        public List<TGTipoEN> ListarCampRegi(long intIdSesion, int intIdMenu, int intIdSoft, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGTIPO_Q03", cn);
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
                    TGTipoEN obj = new TGTipoEN();

                    obj.intidTipo = reader.GetInt32(0);
                    obj.strDeTipo = reader.GetString(1);

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //2.9
        private DataTable SerealizeDetalleUnidadOrgFeriado(List<TGFER_UNIORG_DET> listaOrgxFer, int intIdFeriado)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdFerUniOrg", typeof(int));
            table.Columns.Add("intIdFeriado", typeof(int));
            table.Columns.Add("intIdUniOrg", typeof(int));


            foreach (var item in listaOrgxFer)
            {
                DataRow rows = table.NewRow();
                rows["intIdFerUniOrg"] = item.intIdFerUniOrg;
                rows["intIdFeriado"] = intIdFeriado;
                rows["intIdUniOrg"] = item.intIdUniOrg;

                table.Rows.Add(rows);
            }

            return table;
        }


    }
}
