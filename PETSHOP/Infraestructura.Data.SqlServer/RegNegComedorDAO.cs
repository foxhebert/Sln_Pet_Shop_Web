using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Infraestructura.Data.SqlServer
{
    public class RegNegComedorDAO : Conexion
    {
        #region Depurar
        ////02.- IUNegocioCom
        //public int IUNegocioCom(Session_Movi objSession, int intTipoOperacion, ReglaNegocio objDatos, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        //{

        //    int intIdReglaNegOut = 0;
        //    using (SqlConnection cn = new SqlConnection(cadCnx))
        //    {
        //        SqlCommand cmd = new SqlCommand("TSP_TGREGLANEG_IU00", cn);//TSP_TGREGLANEG_IU01
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cn.Open();
        //        Dictionary<string, object> param = new Dictionary<string, object>();
        //        param.Add("@intIdSesion", objSession.intIdSesion);
        //        //param.Add("@intIdMenu", objSession.IntIdMenu);
        //        //Añadido hg.10.02.21_miercoles
        //        param.Add("@intIdMenu", objSession.intIdMenu.ToString());
        //        param.Add("@intIdSoft", objSession.intIdSoft);//parametros de entrada
        //        param.Add("@strCoRegNeg", objDatos.strCoRegNeg);
        //        param.Add("@strDesRegNeg", objDatos.strDesRegNeg);

        //        if (objDatos.IntIdUniOrg == 0)
        //            param.Add("@IntIdUniOrg", DBNull.Value);
        //        else
        //            param.Add("@IntIdUniOrg", objDatos.IntIdUniOrg);

        //        param.Add("@bitFlInterna", objDatos.bitFlInterna);
        //        param.Add("@bitFlActivo", objDatos.bitFlActivo);

        //        if (objDatos.strRegNegCampo1 == null)
        //            param.Add("@strRegNegCampo1", DBNull.Value);
        //        else
        //            param.Add("@strRegNegCampo1", objDatos.strRegNegCampo1);

        //        if (objDatos.strRegNegCampo2 == null)
        //            param.Add("@strRegNegCampo2", DBNull.Value);
        //        else
        //            param.Add("@strRegNegCampo2", objDatos.strRegNegCampo2);


        //        if (objDatos.strRegNegCampo3 == null)
        //            param.Add("@strRegNegCampo3", DBNull.Value);
        //        else
        //            param.Add("@strRegNegCampo3", objDatos.strRegNegCampo3);


        //        if (objDatos.strRegNegCampo4 == null)
        //            param.Add("@strRegNegCampo4", DBNull.Value);
        //        else
        //            param.Add("@strRegNegCampo4", objDatos.strRegNegCampo4);


        //        if (objDatos.strRegNegCampo5 == null)
        //            param.Add("@strRegNegCampo5", DBNull.Value);
        //        else
        //            param.Add("@strRegNegCampo5", objDatos.strRegNegCampo5);


        //        param.Add("@intIdUsuario", objSession.intIdUsuario);
        //        param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update
        //        //Parámetros de Salida
        //        param.Add("@intIdReglaNeg", objDatos.intIdReglaNeg);
        //        param.Add("@intResult", 0);//0);
        //        param.Add("@strMsjDB", "");
        //        param.Add("@strMsjUsuario", "");
        //        AsignarParametros(cmd, param);
        //        int result = cmd.ExecuteNonQuery();
        //        intIdReglaNegOut = Convert.ToInt32(cmd.Parameters["@intIdReglaNeg"].Value.ToString());
        //        intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
        //        strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
        //        strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
        //    }
        //    return intIdReglaNegOut;
        //}

        ////03.- UpdateTablaDetalleREGNEG    
        //public bool UpdateTablaDetalleREGNEG(Session_Movi objSession, DataTable TT_TGREGNEG_DET,
        //                                ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        //{
        //    bool tudobem = false;

        //    using (SqlConnection cn = new SqlConnection(cadCnx))
        //    {
        //        SqlCommand cmd = new SqlCommand("TSP_TGREGNEG_DET_IU00", cn);//TSP_TGREGNEG_DET_IU02
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cn.Open();

        //        Dictionary<string, object> param = new Dictionary<string, object>();
        //        param.Add("@intIdSesion", objSession.intIdSesion);
        //        //param.Add("@intIdMenu", objSession.IntIdMenu);
        //        //Añadido hg.10.02.21_miercoles
        //        param.Add("@intIdMenu", objSession.intIdMenu.ToString());
        //        param.Add("@intIdSoft", objSession.intIdSoft);
        //        param.Add("@tt_TGREGNEG_DET", TT_TGREGNEG_DET);


        //        //Parámetros de Salida
        //        param.Add("@intResult", 0);
        //        param.Add("@strMsjDB", "");
        //        param.Add("@strMsjUsuario", "");

        //        AsignarParametros(cmd, param);
        //        int result = cmd.ExecuteNonQuery();

        //        intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
        //        strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
        //        strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

        //        tudobem = true;
        //    }

        //    return tudobem;
        //}
        ////04.- UpdateTablaTGREGLANEG_SUBSIDIO_DET
        //public bool UpdateTablaTGREGLANEG_SUBSIDIO_DET(Session_Movi objSession, DataTable TT_TGREGLANEG_SUBSIDIO_DET, int inst,
        //                              ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        //{
        //    bool tudobem = false;

        //    using (SqlConnection cn = new SqlConnection(cadCnx))
        //    {
        //        SqlCommand cmd = new SqlCommand("TSP_TGREGLANEG_SUBSIDIO_DET_IU00", cn);//TSP_TGREGLANEG_SUBSIDIO_DET_IU03
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cn.Open();

        //        Dictionary<string, object> param = new Dictionary<string, object>();
        //        param.Add("@intIdSesion", objSession.intIdSesion);
        //        //param.Add("@intIdMenu", objSession.IntIdMenu);
        //        //Añadido hg.10.02.21_miercoles
        //        param.Add("@intIdMenu", objSession.intIdMenu.ToString());
        //        param.Add("@intIdSoft", objSession.intIdSoft);
        //        param.Add("@tt_TGREGLANEG_SUBSIDIO_DET", TT_TGREGLANEG_SUBSIDIO_DET);
        //        param.Add("@intIdRegla", inst);

        //        //Parámetros de Salida
        //        param.Add("@intResult", 0);
        //        param.Add("@strMsjDB", "");
        //        param.Add("@strMsjUsuario", "");

        //        AsignarParametros(cmd, param);
        //        int result = cmd.ExecuteNonQuery();

        //        intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
        //        strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
        //        strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

        //        tudobem = true;
        //    }

        //    return tudobem;
        //}
        ////05.- UpdateTablaTGREGLANEG_SERV_DET
        //public bool UpdateTablaTGREGLANEG_SERV_DET(Session_Movi objSession, DataTable TT_TGREGLANEG_SERV_DET,
        //                            ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        //{
        //    bool tudobem = false;

        //    using (SqlConnection cn = new SqlConnection(cadCnx))
        //    {
        //        SqlCommand cmd = new SqlCommand("TSP_TGREGLANEG_SERV_DET_IU00", cn);//TSP_TGREGLANEG_SERV_DET_IU04
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cn.Open();

        //        Dictionary<string, object> param = new Dictionary<string, object>();
        //        param.Add("@intIdSesion", objSession.intIdSesion);
        //        //param.Add("@intIdMenu", objSession.IntIdMenu);
        //        //Añadido hg.10.02.21_miercoles
        //        param.Add("@intIdMenu", objSession.intIdMenu.ToString());
        //        param.Add("@intIdSoft", objSession.intIdSoft);
        //        param.Add("@tt_TGREGLANEG_SERV_DET", TT_TGREGLANEG_SERV_DET);

        //        //Parámetros de Salida
        //        param.Add("@intResult", 0);
        //        param.Add("@strMsjDB", "");
        //        param.Add("@strMsjUsuario", "");

        //        AsignarParametros(cmd, param);
        //        int result = cmd.ExecuteNonQuery();

        //        intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
        //        strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
        //        strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

        //        tudobem = true;
        //    }

        //    return tudobem;
        //}
        #endregion Depurar

        //2.37
        public List<ReglaNegocio> ListarRegNegCom(Session_Movi objSession, string strfilter, int intActivoFilter, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<ReglaNegocio> lista = new List<ReglaNegocio>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGREGLANEG_COM_Q00", cn);//TSP_TGREGLANEG_COM_Q02
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);

                //param.Add("@intIdMenu", objSession.IntIdMenu);
                //Añadido hg.10.02.21_miercoles
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);


                param.Add("@strfilter", strfilter);
                param.Add("@intActivo", intActivoFilter);


                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReglaNegocio obj = new ReglaNegocio();

                        obj.intIdReglaNeg = reader.GetInt32(0);
                        obj.strCoRegNeg = reader.GetString(1);
                        obj.strDesRegNeg = reader.GetString(2);
                        obj.strTipoConsu = reader.GetString(3);
                        obj.strContSub = reader.GetString(4);
                        obj.strDesEstado = reader.GetString(5);

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
        //2.38
        public int IUNegocioCom_T(Session_Movi objSession, int intTipoOperacion, ReglaNegocio objDatos, List<TGREGNEG_DET> listaReglaNegDet, List<TGREGLANEG_SUBSIDIO_DET> listaDetSubsi, List<TGREGLANEG_SERV_DET> listaDetServ, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string Msj)
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
                            SqlCommand cmd = new SqlCommand("TSP_TGREGLANEG_IU00", cn);//TSP_TGREGLANEG_IU01
                            cmd.Transaction = trans;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = timeSQL;
                            Dictionary<string, object> param = new Dictionary<string, object>();
                            param.Add("@intIdSesion", objSession.intIdSesion);
                            param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                            param.Add("@intIdSoft", objSession.intIdSoft);//parametros de entrada
                            param.Add("@strCoRegNeg", objDatos.strCoRegNeg);
                            param.Add("@strDesRegNeg", objDatos.strDesRegNeg);

                            if (objDatos.IntIdUniOrg == 0)
                                param.Add("@IntIdUniOrg", DBNull.Value);
                            else
                                param.Add("@IntIdUniOrg", objDatos.IntIdUniOrg);

                            param.Add("@bitFlInterna", objDatos.bitFlInterna);
                            param.Add("@bitFlActivo", objDatos.bitFlActivo);

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

                            param.Add("@intIdUsuario", objSession.intIdUsuario);
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
                                DataTable tb = SerealizeDetalleRegladeNegocio_(listaReglaNegDet, intIdReglaNegOut);

                                SqlCommand cmd1 = new SqlCommand("TSP_TGREGNEG_DET_IU00", cn);//TSP_TGREGNEG_DET_IU02
                                cmd1.Transaction = trans;
                                cmd1.CommandType = CommandType.StoredProcedure;
                                cmd1.CommandTimeout = timeSQL;
                                Dictionary<string, object> param1 = new Dictionary<string, object>();
                                param1.Add("@intIdSesion", objSession.intIdSesion);
                                param1.Add("@intIdMenu", objSession.intIdMenu.ToString());
                                param1.Add("@intIdSoft", objSession.intIdSoft);
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
                                    DataTable tb2 = SerealizeDetalleRegladeNegocioSubsidio_(listaDetSubsi, intIdReglaNegOut);

                                    SqlCommand cmd2 = new SqlCommand("TSP_TGREGLANEG_SUBSIDIO_DET_IU00", cn);//TSP_TGREGLANEG_SUBSIDIO_DET_IU03
                                    cmd2.Transaction = trans;
                                    cmd2.CommandType = CommandType.StoredProcedure;
                                    cmd2.CommandTimeout = timeSQL;
                                    Dictionary<string, object> param2 = new Dictionary<string, object>();
                                    param2.Add("@intIdSesion", objSession.intIdSesion);
                                    param2.Add("@intIdMenu", objSession.intIdMenu.ToString());
                                    param2.Add("@intIdSoft", objSession.intIdSoft);
                                    param2.Add("@tt_TGREGLANEG_SUBSIDIO_DET", tb2);
                                    param2.Add("@intIdRegla", intIdReglaNegOut);
                                    param2.Add("@intResult", 0);
                                    param2.Add("@strMsjDB", "");
                                    param2.Add("@strMsjUsuario", "");

                                    AsignarParametros(cmd2, param2);
                                    cmd2.ExecuteNonQuery();

                                    intResult = Convert.ToInt32(cmd2.Parameters["@intResult"].Value.ToString());
                                    strMsjDB = cmd2.Parameters["@strMsjDB"].Value.ToString();
                                    strMsjUsuario = cmd2.Parameters["@strMsjUsuario"].Value.ToString();

                                    //----- TABLA 3: detalles de los servicios de la regla------------------------------------------------------
                                    if (intIdReglaNegOut > 0 && intResult > 0)
                                    {
                                        DataTable tb3 = SerealizeDetalleRegladeNegocioServicio_(listaDetServ, intIdReglaNegOut);

                                        SqlCommand cmd3 = new SqlCommand("TSP_TGREGLANEG_SERV_DET_IU00", cn);//TSP_TGREGLANEG_SERV_DET_IU04
                                        cmd3.Transaction = trans;
                                        cmd3.CommandType = CommandType.StoredProcedure;
                                        cmd3.CommandTimeout = timeSQL;
                                        Dictionary<string, object> param3 = new Dictionary<string, object>();
                                        param3.Add("@intIdSesion", objSession.intIdSesion);
                                        param3.Add("@intIdMenu", objSession.intIdMenu.ToString());
                                        param3.Add("@intIdSoft", objSession.intIdSoft);
                                        param3.Add("@tt_TGREGLANEG_SERV_DET", tb3);
                                        param3.Add("@intResult", 0);
                                        param3.Add("@strMsjDB", "");
                                        param3.Add("@strMsjUsuario", "");

                                        AsignarParametros(cmd3, param3);
                                        cmd3.ExecuteNonQuery();

                                        intResult = Convert.ToInt32(cmd3.Parameters["@intResult"].Value.ToString());
                                        strMsjDB = cmd3.Parameters["@strMsjDB"].Value.ToString();
                                        strMsjUsuario = cmd3.Parameters["@strMsjUsuario"].Value.ToString();

                                        if (intResult == 0)
                                        {
                                            trans.Rollback();//añadido 14.04.2021
                                            if (intTipoOperacion == 1)
                                            {
                                                Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGREGLANEG_SERV_DET_IU00";
                                            }
                                            else
                                            {
                                                Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGREGLANEG_SERV_DET_IU00";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (!strMsjDB.Equals(""))
                                        {
                                            trans.Rollback();//añadido 14.04.2021
                                            if (intTipoOperacion == 1)
                                            {
                                                Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGREGLANEG_SUBSIDIO_DET_IU00";
                                            }
                                            else
                                            {
                                                Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGREGLANEG_SUBSIDIO_DET_IU00";
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
                                            Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGREGNEG_DET_IU00";
                                        }
                                        else
                                        {
                                            Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGREGNEG_DET_IU00";
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
                                        Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGREGLANEG_IU00";
                                    }
                                    else
                                    {
                                        Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGREGLANEG_IU00";
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
        //2.39
        public bool EliminmarReglaNegocioCom(Session_Movi objSession, int intIdReglaNeg, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGREGLANEG_D00", cn);//TSP_TGREGLANEG_D02
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                //param.Add("@intIdMenu", objSession.IntIdMenu);
                //Añadido hg.10.02.21_miercoles
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdUsuario", objSession.intIdUsuario);
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
        //2.40
        public List<ReglaNegocio> ObtenerRegistroReglaNegocioCom(Session_Movi objSession, int intIdReglaNeg, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<ReglaNegocio> listDetCar = new List<ReglaNegocio>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGREGLANEG_Q00", cn);//TSP_TGREGLANEG_Q01
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                //param.Add("@intIdMenu", objSession.IntIdMenu);
                //Añadido hg.10.02.21_miercoles
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);



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

                        ReglaNegocio obj = new ReglaNegocio();
                        obj.intIdReglaNeg = reader.GetInt32(0);
                        obj.strCoRegNeg = reader.GetString(1);
                        obj.strDesRegNeg = reader.GetString(2);
                        obj.bitFlActivo = reader.GetBoolean(10);


                        listDetCar.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listDetCar;
        }
        //2.41
        public List<TGREGNEG_DET> ObtenerRegistroReglaNedocioDetCom(Session_Movi objSession, int intIdReglaNeg, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGREGNEG_DET> listDetCar = new List<TGREGNEG_DET>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGREGNEG_DET_Q01", cn);//TSP_TGREGNEG_DET_Q01
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                //param.Add("@intIdMenu", objSession.IntIdMenu);
                //Añadido hg.10.02.21_miercoles
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);



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
        //2.42
        public List<TGREGLANEG_SUBSIDIO_DET> ObtenerRegistroReglaNedocioSubsiCom(Session_Movi objSession, int intIdReglaNeg, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGREGLANEG_SUBSIDIO_DET> listDetCar = new List<TGREGLANEG_SUBSIDIO_DET>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGREGLANEG_SUBSIDIO_DET_Q01", cn);// TGREGLANEG_SUBSIDIO_DET_Q01
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                //param.Add("@intIdMenu", objSession.IntIdMenu);
                //Añadido hg.10.02.21_miercoles
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);



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

                        TGREGLANEG_SUBSIDIO_DET obj = new TGREGLANEG_SUBSIDIO_DET();

                        obj.IntIdReglaNegSubsDet = reader.GetInt32(0);
                        obj.IntIdReglaNeg = reader.GetInt32(1);
                        obj.IntIdEmp = reader.GetInt32(2);
                        obj.strDeEmpresa = reader.GetString(3);
                        obj.intidtipoMenu = reader.GetInt32(4);
                        obj.strDeTipoMenu = reader.GetString(5);
                        obj.nmPorcentaje = reader.GetDecimal(6);
                        obj.intIdTipServ = reader.GetInt32(7);
                        obj.strDeTipoServ = reader.GetString(8);

                        listDetCar.Add(obj);


                        //IntIdReglaNegSubsDet
                        //IntIdReglaNeg
                        //IntIdEmp
                        //strDeEmpresa
                        //intidtipoMenu
                        //strDeTipoMenu
                        //nmPorcentaje
                        //intIdTipServ
                        //strDeTipoServ       
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listDetCar;
        }
        //2.43
        public List<TGREGLANEG_SERV_DET> ObtenerRegistroReglaNedocioServCom(Session_Movi objSession, int intIdReglaNeg, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGREGLANEG_SERV_DET> listDetCar = new List<TGREGLANEG_SERV_DET>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGREGLANEG_SERV_DET_Q01", cn);// TGREGLANEG_SERV_DET_Q01
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                //param.Add("@intIdMenu", objSession.IntIdMenu);
                //Añadido hg.10.02.21_miercoles
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);



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

                        TGREGLANEG_SERV_DET obj = new TGREGLANEG_SERV_DET();

                        obj.IntIdReglaNeg = reader.GetInt32(0);
                        obj.intIdServicio = reader.GetInt32(1);
                        obj.strCoServicio = reader.GetString(2);
                        obj.strDesServicio = reader.GetString(3);
                        obj.strDesTipoServicio = reader.GetString(4);
                        obj.strDesMenu = reader.GetString(5);

                        //obj.IntIdReglaNeg = reader.GetInt32(0);
                        //obj.intIdServicio = reader.GetInt32(1);

                        listDetCar.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listDetCar;
        }
        //2.44
        private DataTable SerealizeDetalleRegladeNegocio_(List<TGREGNEG_DET> listaReglaNegDet, int intIdReglaNeg)
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
        //2.45
        private DataTable SerealizeDetalleRegladeNegocioSubsidio_(List<TGREGLANEG_SUBSIDIO_DET> listaDetSubsi, int intIdReglaNeg)
        {
            DataTable table = new DataTable();

            table.Columns.Add("IntIdReglaNegSubsDet", typeof(int));
            table.Columns.Add("intIdReglaNeg", typeof(int));
            table.Columns.Add("IntIdEmp", typeof(int));
            table.Columns.Add("nmPorcentaje", typeof(decimal));
            table.Columns.Add("intidtipoMenu", typeof(int));

            table.Columns.Add("bitFlEliminado", typeof(bool));
            table.Columns.Add("intIdUsuarReg", typeof(int));
            table.Columns.Add("dttFeReg", typeof(DateTime));
            table.Columns.Add("intIdUsuarModif", typeof(int));
            table.Columns.Add("dttFeModif", typeof(DateTime));


            foreach (var item in listaDetSubsi)
            {
                DataRow rows = table.NewRow();
                if (item.IntIdReglaNegSubsDet == 0)
                    rows["IntIdReglaNegSubsDet"] = DBNull.Value;
                else
                    rows["IntIdReglaNegSubsDet"] = item.IntIdReglaNegSubsDet;


                if (intIdReglaNeg == 0)
                    rows["intIdReglaNeg"] = DBNull.Value;
                else
                    rows["intIdReglaNeg"] = intIdReglaNeg;

                rows["IntIdEmp"] = item.IntIdEmp;
                rows["nmPorcentaje"] = item.nmPorcentaje;
                rows["intidtipoMenu"] = item.intidtipoMenu;
                rows["bitFlEliminado"] = item.bitFlEliminado;
                rows["intIdUsuarReg"] = item.intIdUsuarReg;
                rows["dttFeReg"] = item.dttFeReg;
                if (item.intIdUsuarModif == 0)
                    rows["intIdUsuarModif"] = DBNull.Value;
                else
                    rows["intIdUsuarModif"] = item.intIdUsuarModif;
                if (item.dttFeModif == null)
                    rows["dttFeModif"] = DBNull.Value;
                else
                    rows["dttFeModif"] = item.dttFeModif;


                table.Rows.Add(rows);
            }

            return table;
        }
        //2.46
        private DataTable SerealizeDetalleRegladeNegocioServicio_(List<TGREGLANEG_SERV_DET> listaDetServ, int intIdReglaNeg)
        {
            DataTable table = new DataTable();


            table.Columns.Add("intIdReglaNeg", typeof(int));
            table.Columns.Add("intIdServicio", typeof(int));
            table.Columns.Add("bitFlEliminado", typeof(bool));
            table.Columns.Add("intIdUsuarReg", typeof(int));
            table.Columns.Add("dttFeReg", typeof(DateTime));
            table.Columns.Add("intIdUsuarModif", typeof(int));
            table.Columns.Add("dttFeModif", typeof(DateTime));


            foreach (var item in listaDetServ)
            {
                DataRow rows = table.NewRow();


                if (intIdReglaNeg == 0)
                    rows["intIdReglaNeg"] = DBNull.Value;
                else
                    rows["intIdReglaNeg"] = intIdReglaNeg;

                rows["intIdServicio"] = item.intIdServicio;
                rows["bitFlEliminado"] = item.bitFlEliminado;
                rows["intIdUsuarReg"] = item.intIdUsuarReg;

                if (item.dttFeReg == null)
                    rows["dttFeReg"] = DBNull.Value;
                else
                    rows["dttFeReg"] = item.dttFeReg;


                if (item.intIdUsuarModif == 0)
                    rows["intIdUsuarModif"] = DBNull.Value;
                else
                    rows["intIdUsuarModif"] = item.intIdUsuarModif;
                if (item.dttFeModif == null)
                    rows["dttFeModif"] = DBNull.Value;
                else
                    rows["dttFeModif"] = item.dttFeModif;


                table.Rows.Add(rows);
            }

            return table;
        }

    }
}
