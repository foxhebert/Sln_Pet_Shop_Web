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
    public class JornadaDiariaDAO : Conexion
    {
        //2.15
        public List<JornadaxHorario> ListarJornadaHorario(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<JornadaxHorario> lista = new List<JornadaxHorario>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGJORNADA_Q02", cn);
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
                param.Add("@strMsjDB", "X");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    JornadaxHorario obj = new JornadaxHorario();

                    obj.intIdJornada = reader.GetInt32(0);
                    obj.strLinea1 = reader.GetString(1);
                    obj.strLinea2 = reader.GetString(2);
                    obj.strLinea3 = reader.GetString(3);
                    obj.strLinea4 = reader.GetString(4);
                    obj.strLinea5 = reader.GetString(5);
                    obj.strLinea6 = reader.GetString(6);
                    obj.strLinea7 = reader.GetString(7);
                    obj.strColor = reader.GetString(8);
                    obj.strTipoServicio = reader.GetString(9);//añadido 25.02.2021

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //2.61
        public List<JornadaData> ListarJornada(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, int filtroTipoServ, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<JornadaData> lista = new List<JornadaData>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGJORNADA_Q02", cn);
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
                param.Add("@filtroTipoServ", filtroTipoServ);//Añadido HG.16.02.21
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    JornadaData obj = new JornadaData();

                    obj.intIdJornada = reader.GetInt32(0);
                    obj.strCodJornada = reader.GetString(2);
                    obj.strDscJornada = reader.GetString(3);
                    obj.EXtra1 = reader.GetString(5);
                    obj.EXtra2 = reader.GetString(7);
                    obj.timeHoraIni = reader.GetTimeSpan(8).ToString(@"hh\:mm");
                    obj.timeHoraFin = reader.GetTimeSpan(9).ToString(@"hh\:mm");
                    obj.EXtra3 = reader.GetString(11);
                    obj.EXtra4 = reader.GetString(12);

                    obj.strTipoServicio = reader.GetString(19);//Añadido_HG.16.02.21

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //2.62
        public bool EliminmarJornada(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdJornada, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGJORNADA_D02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@intIdJornada", intIdJornada);
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
        //2.63
        public int IUJornada_T(long intIdSesion, int intIdMenu, int intIdSoft, int intTipoOperacion, Jornada objDatos, List<Intervalos> listaIntervalos, int intIdUsuario, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string Msj)
        {
            int intIdJornadaOut = 0;
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
                            SqlCommand cmd = new SqlCommand("TSP_TGJORNADA_IU01", cn);
                            cmd.Transaction = trans;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = timeSQL;
                            Dictionary<string, object> param = new Dictionary<string, object>();
                            param.Add("@intIdSesion", intIdSesion);
                            param.Add("@intIdMenu", intIdMenu);
                            param.Add("@intIdSoft", intIdSoft);//parametros de entrada
                            param.Add("@strCodJornada", objDatos.strCodJornada);
                            param.Add("@strDscJornada", objDatos.strDscJornada);
                            param.Add("@intTipoDia", objDatos.intTipoDia);
                            param.Add("@intControlRefri", objDatos.intControlRefri);
                            param.Add("@strColor", objDatos.strColor);
                            if (objDatos.IntIdUniOrg == 0)
                                param.Add("@IntIdUniOrg", DBNull.Value);
                            else
                                param.Add("@IntIdUniOrg", objDatos.IntIdUniOrg);

                            param.Add("@bitFlActivo", objDatos.bitFlActivo);
                            param.Add("@bitDiaSig", objDatos.bitDiaSig);
                            param.Add("@bitPertenecDiaSig", objDatos.bitPertenecDiaSig);
                            if (objDatos.strJornadaCampo1 == null)
                                param.Add("@strJornadaCampo1", DBNull.Value);
                            else
                                param.Add("@strJornadaCampo1", objDatos.strJornadaCampo1);

                            if (objDatos.strJornadaCampo2 == null)
                                param.Add("@strJornadaCampo2", DBNull.Value);
                            else
                                param.Add("@strJornadaCampo2", objDatos.strJornadaCampo2);

                            if (objDatos.strJornadaCampo3 == null)
                                param.Add("@strJornadaCampo3", DBNull.Value);
                            else
                                param.Add("@strJornadaCampo3", objDatos.strJornadaCampo3);

                            if (objDatos.strJornadaCampo4 == null)
                                param.Add("@strJornadaCampo4", DBNull.Value);
                            else
                                param.Add("@strJornadaCampo4", objDatos.strJornadaCampo4);

                            if (objDatos.strJornadaCampo5 == null)
                                param.Add("@strJornadaCampo5", DBNull.Value);
                            else
                                param.Add("@strJornadaCampo5", objDatos.strJornadaCampo5);

                            param.Add("@intIdUsuario", intIdUsuario);
                            param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update
                            param.Add("@intIdJornada", objDatos.intIdJornada);
                            //Parámetros de Salida
                            param.Add("@intResult", 0);
                            param.Add("@strMsjDB", "");
                            param.Add("@strMsjUsuario", "");

                            AsignarParametros(cmd, param);
                            cmd.ExecuteNonQuery();

                            intIdJornadaOut = Convert.ToInt32(cmd.Parameters["@intIdJornada"].Value.ToString());
                            intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                            strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                            strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

                            if (intIdJornadaOut > 0 && intResult > 0)
                            {
                                //----- TABLA 1: detalle de intervalos ------------------------------------------------
                                DataTable tb = SerealizeDetalleIntervalos(listaIntervalos, intIdJornadaOut);

                                SqlCommand cmd1 = new SqlCommand("TSP_TGINTERVALO_IU02", cn);
                                cmd1.Transaction = trans;
                                cmd1.CommandType = CommandType.StoredProcedure;
                                cmd1.CommandTimeout = timeSQL;

                                Dictionary<string, object> param1 = new Dictionary<string, object>();
                                param1.Add("@intIdSesion", intIdSesion);
                                param1.Add("@intIdMenu", intIdMenu);
                                param1.Add("@intIdSoft", intIdSoft);
                                param1.Add("@tt_TGINTERVALO", tb);
                                param1.Add("@intIdUsuario", intIdUsuario);
                                param1.Add("@intIdJornada", intIdJornadaOut);

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
                                        Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGINTERVALO_IU02";
                                    }
                                    else
                                    {
                                        Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGINTERVALO_IU02";
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
                                        Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGJORNADA_IU01";
                                    }
                                    else
                                    {
                                        Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGJORNADA_IU01";
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
        //2.64
        public List<Jornada> ObtenerJornadaPorsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int intIdJornada, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Jornada> listDetCar = new List<Jornada>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGJORNADA_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);



                param.Add("@intIdJornada", intIdJornada);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Jornada obj = new Jornada();
                        obj.intIdJornada = reader.GetInt32(0);
                        obj.strCodJornada = reader.GetString(2);
                        obj.strDscJornada = reader.GetString(3);
                        obj.intTipoDia = reader.GetInt32(4);
                        obj.intControlRefri = reader.GetInt32(5);
                        obj.EXtra1 = reader.GetString(6);
                        obj.strColor = reader.GetString(7);
                        obj.IntIdUniOrg = reader.GetInt32(8);
                        obj.EXtra3 = reader.GetString(9);
                        obj.EXtra2 = reader.GetString(10);
                        obj.bitDiaSig = reader.GetBoolean(11);
                        obj.bitPertenecDiaSig = reader.GetBoolean(12);
                        obj.strJornadaCampo1 = reader.GetString(13);
                        obj.strJornadaCampo2 = reader.GetString(14);
                        obj.strJornadaCampo3 = reader.GetString(15);
                        obj.strJornadaCampo4 = reader.GetString(16);
                        obj.strJornadaCampo5 = reader.GetString(17);
                        obj.bitFlActivo = reader.GetBoolean(18);

                        listDetCar.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listDetCar;
        }
        //2.65
        public List<Intervalos> ListarIntervalos(long intIdSesion, int intIdMenu, int intIdSoft, int intfiltrojer, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Intervalos> lista = new List<Intervalos>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGINTERVALO_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);

                param.Add("@intIdJornada", intfiltrojer);
                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Intervalos obj = new Intervalos();

                    obj.intIdIntervalo = reader.GetInt32(0);

                    obj.strectra1 = reader.GetString(1);
                    obj.strectra2 = reader.GetString(2);
                    obj.strectra3 = reader.GetString(3);
                    obj.strectra4 = reader.GetString(4);
                    obj.intTipoInterval = reader.GetInt32(5);
                    obj.intTurno = reader.GetInt32(6);
                    obj.strectra5 = reader.GetString(7);
                    obj.strectra6 = reader.GetString(8);
                    obj.bitFlHT = reader.GetBoolean(9);
                    obj.intNuOrden = reader.GetInt32(10);
                    obj.strectra7 = reader.GetString(11);
                    obj.strectra8 = reader.GetString(12);


                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //2.66
        private DataTable SerealizeDetalleIntervalos(List<Intervalos> listaIntervalos, int IntidJornada)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdIntervalo", typeof(int));
            table.Columns.Add("intIdJornada", typeof(int));
            table.Columns.Add("intTipoInterval", typeof(int));
            table.Columns.Add("intHoraIni", typeof(int));
            table.Columns.Add("intHoraFin", typeof(int));
            table.Columns.Add("timeHoraIni", typeof(string));
            table.Columns.Add("timeHoraFin", typeof(string));
            table.Columns.Add("intTurno", typeof(int));
            table.Columns.Add("intTolerancia", typeof(int));
            table.Columns.Add("timeTolerancia", typeof(string));
            table.Columns.Add("intDuracion", typeof(int));
            table.Columns.Add("timeDuracion", typeof(string));
            table.Columns.Add("intNuOrden", typeof(int));
            table.Columns.Add("intTiempoMaximo", typeof(int));
            table.Columns.Add("timeTiempoMaximo", typeof(string));
            table.Columns.Add("bitFlHT", typeof(int));
            table.Columns.Add("bitDiaSig", typeof(int));
            table.Columns.Add("intidTipoServ", typeof(int));
            table.Columns.Add("bitFlActivo", typeof(bool));


            foreach (var item in listaIntervalos)
            {
                DataRow rows = table.NewRow();
                rows["intIdIntervalo"] = item.intIdIntervalo;
                rows["intIdJornada"] = IntidJornada;
                rows["intTipoInterval"] = item.intTipoInterval;
                rows["intHoraIni"] = item.intHoraIni;
                rows["timeHoraIni"] = item.timeHoraIni;
                rows["timeHoraFin"] = item.timeHoraFin;
                rows["intTurno"] = item.intTurno;
                rows["intTolerancia"] = item.intTolerancia;
                rows["timeTolerancia"] = item.timeTolerancia;
                rows["intDuracion"] = item.intDuracion;
                rows["timeDuracion"] = item.timeDuracion;
                rows["intNuOrden"] = item.intNuOrden;
                rows["intTiempoMaximo"] = item.intTiempoMaximo;
                rows["timeTiempoMaximo"] = item.timeTiempoMaximo;
                rows["bitFlHT"] = item.bitFlHT;
                rows["bitDiaSig"] = item.bitDiaSig;
                rows["intidTipoServ"] = item.intidTipoServ;
                rows["bitFlActivo"] = item.bitFlActivo;

                table.Rows.Add(rows);
            }

            return table;
        }

    }
}
