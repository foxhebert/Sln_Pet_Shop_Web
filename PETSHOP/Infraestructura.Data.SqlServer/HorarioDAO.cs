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
    public  class HorarioDAO : Conexion
    {
        //2.10
        public List<HorarioData> ListarHorario(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<HorarioData> lista = new List<HorarioData>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGHORARIO_Q02", cn);
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

                    HorarioData obj = new HorarioData();

                    obj.intIdHorario = reader.GetInt32(0);
                    obj.strCoHorario = reader.GetString(1);
                    obj.strDeHorario = reader.GetString(2);
                    obj.strExtra1    = reader.GetString(3);
                    obj.strExtra2    = reader.GetString(4);
                    obj.strExtra3    = reader.GetString(5);
                    obj.strExtra4    = reader.GetString(6);
                   
                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //2.11
        public int IUHorario_T(long intIdSesion, int intIdMenu, int intIdSoft, Horario objDatos, List<HorJor> listaHorariosJor, int intIdUsuario, int intTipoOperacion, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string Msj)
        {

            int intIdHorarioOut = 0;
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
                            SqlCommand cmd = new SqlCommand("TSP_TGHORARIO_IU01", cn);
                            cmd.Transaction = trans;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = timeSQL;
                            Dictionary<string, object> param = new Dictionary<string, object>();
                            param.Add("@intIdSesion", intIdSesion);
                            param.Add("@intIdMenu", intIdMenu);
                            param.Add("@intIdSoft", intIdSoft);
                            param.Add("@strCoHorario", objDatos.strCoHorario);
                            param.Add("@strDeHorario", objDatos.strDeHorario);
                            param.Add("@intTotalDias", objDatos.intTotalDias);
                            param.Add("@intNumDiaIni", objDatos.intNumDiaIni);
                            param.Add("@intIdUniOrg", objDatos.intIdUniOrg);
                            param.Add("@bitFlActivo", objDatos.bitFlActivo);
                            param.Add("@bitFlPrincipal", objDatos.bitFlPrincipal);

                            if (objDatos.strHorarioCampo1 == null)
                                param.Add("@strHorarioCampo1", DBNull.Value);
                            else
                                param.Add("@strHorarioCampo1", objDatos.strHorarioCampo1);

                            if (objDatos.strHorarioCampo2 == null)
                                param.Add("@strHorarioCampo2", DBNull.Value);
                            else
                                param.Add("@strHorarioCampo2", objDatos.strHorarioCampo2);

                            if (objDatos.strHorarioCampo3 == null)
                                param.Add("@strHorarioCampo3", DBNull.Value);
                            else
                                param.Add("@strHorarioCampo3", objDatos.strHorarioCampo3);

                            if (objDatos.strHorarioCampo4 == null)
                                param.Add("@strHorarioCampo4", DBNull.Value);
                            else
                                param.Add("@strHorarioCampo4", objDatos.strHorarioCampo4);

                            if (objDatos.strHorarioCampo5 == null)
                                param.Add("@strHorarioCampo5", DBNull.Value);
                            else
                                param.Add("@strHorarioCampo5", objDatos.strHorarioCampo5);

                            param.Add("@intIdUsuario", intIdUsuario);
                            param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update
                            //Parámetros de Salida
                            if (intTipoOperacion == 1)
                            {
                                param.Add("@intIdHorario", 0);
                            }
                            else
                            {
                                param.Add("@intIdHorario", objDatos.intIdHorario);
                            }
                            param.Add("@intResult", 0);
                            param.Add("@strMsjDB", "");
                            param.Add("@strMsjUsuario", "");

                            AsignarParametros(cmd, param);
                            cmd.ExecuteNonQuery();

                            intIdHorarioOut = Convert.ToInt32(cmd.Parameters["@intIdHorario"].Value.ToString());
                            intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                            strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                            strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

                            if (intIdHorarioOut > 0 && intResult > 0)
                            {
                                //----- TABLA 1: detalle de Jornadas por día del Calendario ------------------------------------------------
                                DataTable tb = SerealizeDetalleHorarios(listaHorariosJor, intIdHorarioOut);

                                SqlCommand cmd1 = new SqlCommand("TSP_TGHOR_JOR_DET_IU02", cn);
                                cmd1.Transaction = trans;
                                cmd1.CommandType = CommandType.StoredProcedure;
                                cmd1.CommandTimeout = timeSQL;
                                Dictionary<string, object> param1 = new Dictionary<string, object>();
                                param1.Add("@intIdSesion", intIdSesion);
                                param1.Add("@intIdMenu", intIdMenu);
                                param1.Add("@intIdSoft", intIdSoft);
                                param1.Add("@tt_TGHOR_JOR_DET", tb);
                                param1.Add("@intIdUsuario", intIdUsuario);
                                param1.Add("@intIdHorario", intIdHorarioOut);

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
                                        Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGHOR_JOR_DET_IU02";
                                    }
                                    else
                                    {
                                        Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGHOR_JOR_DET_IU02";
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
                                        Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGHORARIO_IU01";
                                    }
                                    else
                                    {
                                        Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGHORARIO_IU01";
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
        //2.12
        public bool EliminmarHorario(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdHorario, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGHORARIO_D02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@intIdHorario", intIdHorario);
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
        //2.13
        public List<Horario> ObtenerHorarioPorsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int intIdHorario, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Horario> listDetCar = new List<Horario>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGHORARIO_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);



                param.Add("@intIdHorario", intIdHorario);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Horario obj = new Horario();
                        obj.intIdHorario = reader.GetInt32(0);
                        obj.strCoHorario = reader.GetString(1);
                        obj.strDeHorario = reader.GetString(2);
                        obj.intTotalDias = reader.GetInt32(3);
                        obj.intNumDiaIni = reader.GetInt32(4);
                        obj.intIdUniOrg = reader.GetInt32(5);

                        obj.strHorarioCampo1 = reader.GetString(7);
                        obj.strHorarioCampo2 = reader.GetString(8);
                        obj.strHorarioCampo3 = reader.GetString(9);
                        obj.strHorarioCampo4 = reader.GetString(10);
                        obj.strHorarioCampo5 = reader.GetString(11);
                        obj.bitFlActivo = reader.GetBoolean(12);
                        obj.bitFlPrincipal = reader.GetBoolean(13);
                        obj.intExtra1 = reader.GetInt32(15);


                        listDetCar.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listDetCar;
        }
        //2.14
        public List<HorJor> ObtenerHORXJORPorsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int intIdHorario, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<HorJor> listDetCar = new List<HorJor>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGHOR_JOR_DET_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);



                param.Add("@intIdHorario", intIdHorario);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        HorJor obj = new HorJor();

                        obj.intIdHorJorDet = reader.GetInt32(0);
                        obj.intIdHorario = reader.GetInt32(1);
                        if(!reader.IsDBNull(2))
                            obj.intIdJornada = reader.GetInt32(2);
                        if (!reader.IsDBNull(3))
                            obj.strCodJornada = reader.GetString(3);
                        if (!reader.IsDBNull(4))
                            obj.strColor = reader.GetString(4);
                        obj.intNumDiaIni = reader.GetInt32(5);

                        listDetCar.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listDetCar;
        }

        //2.16
        private DataTable SerealizeDetalleHorarios(List<HorJor> listaHorariosJor, int intIdHorario)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdHorJorDet", typeof(int));
            table.Columns.Add("intIdHorario", typeof(int));
            table.Columns.Add("intIdJornada", typeof(int));
            table.Columns.Add("intNumDiaIni", typeof(int));



            foreach (var item in listaHorariosJor)
            {
                DataRow rows = table.NewRow();
                rows["intIdHorJorDet"] = item.intIdHorJorDet;
                rows["intIdHorario"] = intIdHorario;
                rows["intIdJornada"] = item.intIdJornada;
                rows["intNumDiaIni"] = item.intNumDiaIni;


                table.Rows.Add(rows);
            }

            return table;
        }
    }
}
