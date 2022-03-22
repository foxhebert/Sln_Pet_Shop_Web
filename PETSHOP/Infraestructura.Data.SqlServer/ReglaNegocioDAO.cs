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
     public class ReglaNegocioDAO : Conexion
    {
        //2.54
        public List<ReglaNegocio> ListarReglaNegocio(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<ReglaNegocio> lista = new List<ReglaNegocio>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGREGLANEG_Q02", cn);
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

                    ReglaNegocio obj = new ReglaNegocio();

                    obj.intIdReglaNeg = reader.GetInt32(0);
                    obj.strCoRegNeg = reader.GetString(1);
                    obj.strDesRegNeg = reader.GetString(2);
                    obj.intextra2 = reader.GetInt32(4);
                    obj.strDescUO = reader.GetString(5);
                    obj.strJerOrg = reader.GetString(6);
                    obj.intextra1 = reader.GetInt32(7);
                    obj.strRegNegCampo1 = reader.GetString(9);
                    obj.strRegNegCampo2 = reader.GetString(10);
                    obj.strRegNegCampo3 = reader.GetString(11);
                    obj.strRegNegCampo4 = reader.GetString(12);
                    obj.strRegNegCampo5 = reader.GetString(13);
                    obj.bitFlActivo = reader.GetBoolean(14);
                    obj.bitFlPrincipal = reader.GetBoolean(15);
                    obj.strEstado = reader.GetString(16);


                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //2.55
        public int IUNegocio_T(long intIdSesion, int intIdMenu, int intIdSoft, ReglaNegocio objDatos, List<TGREGNEG_DET> listaReglaNegDet, List<TGREG_NEG_CONFIG_HORAS> listaReglaNegHEDet, int intTipoOperacion, int intIdUsuario, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string Msj)
        {
            int intIdReglaNegOut = 0;
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
                            SqlCommand cmd = new SqlCommand("TSP_TGREGLANEG_IU01", cn);
                            cmd.Transaction = trans;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = timeSQL;
                            Dictionary<string, object> param = new Dictionary<string, object>();
                            param.Add("@intIdSesion", intIdSesion);
                            param.Add("@intIdMenu", intIdMenu);
                            param.Add("@intIdSoft", intIdSoft);//parametros de entrada
                            param.Add("@strCoRegNeg", objDatos.strCoRegNeg);
                            param.Add("@strDesRegNeg", objDatos.strDesRegNeg);
                            param.Add("@IntIdUniOrg", objDatos.IntIdUniOrg);
                            param.Add("@bitFlInterna", objDatos.bitFlInterna);
                            param.Add("@bitFlActivo", objDatos.bitFlActivo);
                            param.Add("@bitFlPrincipal", objDatos.bitFlPrincipal);

                            if (objDatos.strRegNegCampo1 == null)
                                param.Add("@strRegNegCampo1", DBNull.Value);
                            else
                                param.Add("@strRegNegCampo1", objDatos.strRegNegCampo1);

                            if (objDatos.strRegNegCampo2 == null)
                                param.Add("@strRegNegCampo2", DBNull.Value);
                            else
                                param.Add("@strRegNegCampo2", objDatos.strRegNegCampo2);

                            if (objDatos.strRegNegCampo3 == null)
                                param.Add("@strRegNegCampo3", DBNull.Value);
                            else
                                param.Add("@strRegNegCampo3", objDatos.strRegNegCampo3);

                            if (objDatos.strRegNegCampo4 == null)
                                param.Add("@strRegNegCampo4", DBNull.Value);
                            else
                                param.Add("@strRegNegCampo4", objDatos.strRegNegCampo4);

                            if (objDatos.strRegNegCampo5 == null)
                                param.Add("@strRegNegCampo5", DBNull.Value);
                            else
                                param.Add("@strRegNegCampo5", objDatos.strRegNegCampo5);

                            param.Add("@intIdUsuario", intIdUsuario);

                            param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update
                            param.Add("@intIdReglaNeg", objDatos.intIdReglaNeg);
                            param.Add("@intResult", 1);//0);
                            param.Add("@strMsjDB", "");
                            param.Add("@strMsjUsuario", "");
                            AsignarParametros(cmd, param);
                            //int result = cmd.ExecuteNonQuery();
                            cmd.ExecuteNonQuery();
                            intIdReglaNegOut = Convert.ToInt32(cmd.Parameters["@intIdReglaNeg"].Value.ToString());
                            intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                            strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                            strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

                            if (intIdReglaNegOut > 0 && intResult > 0)
                            {
                                //----- TABLA 1: detalles de la regla ----------------------------------------------------------------
                                //Detalle de Regla ok
                                DataTable tb = SerealizeDetalleRegladeNegocio(listaReglaNegDet, intIdReglaNegOut);

                                SqlCommand cmd1 = new SqlCommand("TSP_TGREGNEG_DET_IU02", cn);//TSP_TGREGNEG_DET_IU02
                                cmd1.Transaction = trans;
                                cmd1.CommandType = CommandType.StoredProcedure;
                                cmd1.CommandTimeout = timeSQL;
                                Dictionary<string, object> param1 = new Dictionary<string, object>();
                                param1.Add("@intIdSesion", intIdSesion);
                                param1.Add("@intIdMenu", intIdMenu);
                                param1.Add("@intIdSoft", intIdSoft);
                                param1.Add("@tt_TGREGNEG_DET", tb);
                                param1.Add("@intResult", 0);
                                param1.Add("@strMsjDB", "");
                                param1.Add("@strMsjUsuario", "");

                                AsignarParametros(cmd1, param1);
                                cmd1.ExecuteNonQuery();
                                intResult = Convert.ToInt32(cmd1.Parameters["@intResult"].Value.ToString());
                                strMsjDB = cmd1.Parameters["@strMsjDB"].Value.ToString();
                                strMsjUsuario = cmd1.Parameters["@strMsjUsuario"].Value.ToString();

                                //----- TABLA 2: detalles de los subsidios de la regla-------------------------------------------------------
                                if (intIdReglaNegOut > 0 && intResult > 0)
                                {
                                    DataTable tb2 = SerealizeDetalleRegladeNegocioCongig_Horas(listaReglaNegHEDet, intIdReglaNegOut);

                                    SqlCommand cmd2 = new SqlCommand("TSP_TGREGLANEG_HE_DET_IU02", cn);
                                    cmd2.Transaction = trans;
                                    cmd2.CommandType = CommandType.StoredProcedure;
                                    cmd2.CommandTimeout = timeSQL;
                                    Dictionary<string, object> param2 = new Dictionary<string, object>();
                                    param2.Add("@intIdSesion", intIdSesion);
                                    param2.Add("@intIdMenu", intIdMenu);
                                    param2.Add("@intIdSoft", intIdSoft);
                                    param2.Add("@tt_TGREGLANEG_HE_DET", tb2);

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
                                            Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGREGLANEG_HE_DET_IU02";
                                        }
                                        else
                                        {
                                            Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGREGLANEG_HE_DET_IU02";
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
                                            Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGREGNEG_DET_IU02";
                                        }
                                        else
                                        {
                                            Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGREGNEG_DET_IU02";
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
                                        Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGREGLANEG_IU01";
                                    }
                                    else
                                    {
                                        Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGREGLANEG_IU01";
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
        //2.56
        public bool EliminmarReglaNegocio(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdReglaNeg, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGREGLANEG_D02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@intIdReglaNeg", intIdReglaNeg);
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
        //2.57
        public List<TGREGNEG_DET> ObtenerRegistroReglaNedocio(long intIdSesion, int intIdMenu, int intIdSoft, int intIdReglaNeg, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGREGNEG_DET> listDetCar = new List<TGREGNEG_DET>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGREGNEG_DET_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);



                param.Add("@intIdReglaNeg", intIdReglaNeg);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        TGREGNEG_DET obj = new TGREGNEG_DET();
                        obj.intIdRegNegDet = reader.GetInt32(0);
                        obj.intIdReglaNeg = reader.GetInt32(1);
                        obj.strCoReglaDet = reader.GetString(2);
                        obj.strDesReglaDet = reader.GetString(3);
                        obj.strValorRegla = reader.GetString(4);
                        obj.strPosibValor = reader.GetString(5);
                        obj.bitFlActivo = reader.GetBoolean(6);
                        obj.strEstadoActivo = reader.GetString(7);

                        listDetCar.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listDetCar;
        }
        //2.58
        public List<TGREG_NEG_CONFIG_HORAS> ObtenerRegistroReglaDetalleDeNedocioHE(long intIdSesion, int intIdMenu, int intIdSoft, int intIdReglaNeg, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGREG_NEG_CONFIG_HORAS> listDetCar = new List<TGREG_NEG_CONFIG_HORAS>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGREGLANEG_HE_DET_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);



                param.Add("@intIdReglaNeg", intIdReglaNeg);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        TGREG_NEG_CONFIG_HORAS obj = new TGREG_NEG_CONFIG_HORAS();
                        obj.intIdRegNegHE = reader.GetInt32(0);
                        obj.intIdReglaNeg = reader.GetInt32(1);
                        obj.intIdConceptoDiurno = reader.GetInt32(2);
                        obj.intIdConceptoNocturno = reader.GetInt32(3);
                        obj.timeTiempo = reader.GetString(4);
                        obj.strTipoDia = reader.GetString(5);
                        obj.intTipoDia = reader.GetInt32(6);
                        obj.strDesConcepto1 = reader.GetString(7);
                        obj.strDesConcepto2 = reader.GetString(8);



                        listDetCar.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listDetCar;
        }
        //2.59
        private DataTable SerealizeDetalleRegladeNegocio(List<TGREGNEG_DET> listaReglaNegDet, int intIdReglaNeg)
        {
            DataTable table = new DataTable();

            table.Columns.Add("intIdRegNegDet", typeof(int));
            table.Columns.Add("intIdReglaNeg", typeof(int));
            table.Columns.Add("strCoReglaDet", typeof(string));
            table.Columns.Add("strDesReglaDet", typeof(string));
            table.Columns.Add("strValorRegla", typeof(string));
            table.Columns.Add("strPosibValor", typeof(string));
            table.Columns.Add("bitFlActivo", typeof(bool));



            foreach (var item in listaReglaNegDet)
            {
                DataRow rows = table.NewRow();
                rows["intIdRegNegDet"] = item.intIdRegNegDet;
                rows["intIdReglaNeg"] = intIdReglaNeg;
                rows["strCoReglaDet"] = item.strCoReglaDet;
                rows["strDesReglaDet"] = item.strDesReglaDet;
                rows["strValorRegla"] = item.strValorRegla;
                rows["strPosibValor"] = item.strPosibValor;
                rows["bitFlActivo"] = item.bitFlActivo;


                table.Rows.Add(rows);
            }

            return table;
        }
        //2.60
        private DataTable SerealizeDetalleRegladeNegocioCongig_Horas(List<TGREG_NEG_CONFIG_HORAS> listaConfigHoras, int intIdReglaNeg)
        {
            DataTable table = new DataTable();

            table.Columns.Add("intIdRegNegHE", typeof(int));
            table.Columns.Add("intIdReglaNeg", typeof(int));
            table.Columns.Add("intIdConceptoDiurno", typeof(int));
            table.Columns.Add("intIdConceptoNocturno", typeof(int));
            table.Columns.Add("intTiempo", typeof(int));
            table.Columns.Add("timeTiempo", typeof(string));
            table.Columns.Add("intSecuencia", typeof(int));
            table.Columns.Add("intTipoDia", typeof(int));
            table.Columns.Add("intTipoHorario", typeof(int));
            table.Columns.Add("bitFlEliminado", typeof(bool));
            table.Columns.Add("intIdUsuarReg", typeof(int));


            foreach (var item in listaConfigHoras)
            {
                DataRow rows = table.NewRow();
                if (item.intIdRegNegHE == 0)
                    rows["intIdRegNegHE"] = DBNull.Value;
                else
                    rows["intIdRegNegHE"] = item.intIdRegNegHE;


                if (intIdReglaNeg == 0)
                    rows["intIdReglaNeg"] = DBNull.Value;
                else
                    rows["intIdReglaNeg"] = intIdReglaNeg;

                rows["intIdConceptoDiurno"] = item.intIdConceptoDiurno;
                rows["intIdConceptoNocturno"] = item.intIdConceptoNocturno;



                rows["intTiempo"] = item.intTiempo;


                rows["timeTiempo"] = item.timeTiempo;
                rows["intSecuencia"] = item.intSecuencia;

                if (item.intTipoDia == 0)
                    rows["intTipoDia"] = DBNull.Value;
                else
                    rows["intTipoDia"] = item.intTipoDia;

                if (item.intTipoHorario == 0)
                    rows["intTipoHorario"] = DBNull.Value;
                else
                    rows["intTipoHorario"] = item.intTipoHorario;


                rows["bitFlEliminado"] = item.bitFlEliminado;
                rows["intIdUsuarReg"] = item.intIdUsuarReg;


                table.Rows.Add(rows);
            }

            return table;
        }


    }
}
