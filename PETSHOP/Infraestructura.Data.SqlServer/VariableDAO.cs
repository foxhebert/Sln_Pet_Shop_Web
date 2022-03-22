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
    public class VariableDAO : Conexion
    {
        //2.17
        public List<TGTipoEN> ListarTipoVar(long intIdSesion, int intIdMenu, int intIdSoft, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCONCEPTO_Q04", cn);
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
        //2.18
        public List<TGTipoEN> ListarTipoUM(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGLISTAR_COMBOS_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
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
        //2.19
        public List<VariableData> ListarConcepto(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<VariableData> lista = new List<VariableData>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCONCEPTO_Q02", cn);
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

                    VariableData obj = new VariableData();

                    obj.strCoConcepto = reader.GetString(0);
                    obj.strDesConcepto = reader.GetString(1);
                    obj.intIdConcepto = reader.GetInt32(2);
                    obj.strDeTipotipo = reader.GetString(3);
                    obj.strDeTipoum = reader.GetString(4);
                    obj.strActivo = reader.GetString(5);
                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //2.20
        public List<TGTipoEN> ListarTipoRedondeo(long intIdSesion, int intIdMenu, int intIdSoft, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCONCEPTO_Q07", cn);
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
        //2.21
        public List<TGTipoEN> ListarAplicaPor(long intIdSesion, int intIdMenu, int intIdSoft, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCONCEPTO_Q08", cn);
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
        //2.22
        public List<TGTipoEN> ListarForRedondeo(long intIdSesion, int intIdMenu, int intIdSoft, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCONCEPTO_Q09", cn);
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
        //2.23
        public List<Jornada> ListarHorarioEspecifico(long intIdSesion, int intIdMenu, int intIdSoft, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Jornada> lista = new List<Jornada>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCONCEPTO_Q10", cn);
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
                    Jornada obj = new Jornada();

                    obj.intIdJornada = reader.GetInt32(0);
                    obj.strDscJornada = reader.GetString(1);

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //2.24
        public List<Concepto> ListarHorasExtras(long intIdSesion, int intIdMenu, int intIdSoft, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Concepto> lista = new List<Concepto>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCONCEPTO_Q11", cn);
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
                    Concepto obj = new Concepto();

                    obj.intIdConcepto = reader.GetInt32(0);
                    obj.strCoConcepto = reader.GetString(2);
                    obj.strDesConcepto = reader.GetString(1);

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //2.25
        public bool EliminmarConcepto(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdConcepto, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCONCEPTO_D02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@intIdConcepto", intIdConcepto);
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
        //2.26
        public int IUVariable_T(long intIdSesion, int intIdMenu, int intIdSoft, Concepto objDatos, List<Concepto> listaConcepto, List<TGJOR_BON_DET> listaDetaBoni, int intIdUsuario, int intTipoOperacion, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string Msj)
        {
            int intIdVariableOut = 0;
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
                            SqlCommand cmd = new SqlCommand("TSP_TGCONCEPTO_IU01", cn);
                            cmd.Transaction = trans;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = timeSQL;
                            Dictionary<string, object> param = new Dictionary<string, object>();
                            param.Add("@intIdSesion", intIdSesion);
                            param.Add("@intIdMenu", intIdMenu);
                            param.Add("@intIdSoft", intIdSoft);//parametros de entrada
                            param.Add("@intIdUsuario", intIdUsuario);

                            param.Add("@intTipoConcepto", objDatos.intTipoConcepto);
                            param.Add("@bitInternoSis", objDatos.bitInternoSis);
                            param.Add("@strCoConcepto", objDatos.strCoConcepto);
                            param.Add("@strDesConcepto", objDatos.strDesConcepto);
                            if (objDatos.bitReqMarca == 0) //null
                                param.Add("@bitReqMarca", DBNull.Value);
                            else
                                param.Add("@bitReqMarca", objDatos.bitReqMarca);
                            param.Add("@strCoPlaniExp", objDatos.strCoPlaniExp);
                            param.Add("@strCoPDT", objDatos.strCoPDT);
                            param.Add("@intTipoUM", objDatos.intTipoUM);
                            param.Add("@bitAplTodosDias", objDatos.bitAplTodosDias);
                            param.Add("@bitAplDiaLabor", objDatos.bitAplDiaLabor);
                            param.Add("@bitAplDiaDescanso", objDatos.bitAplDiaDescanso);
                            param.Add("@bitAplDiaFeriado", objDatos.bitAplDiaFeriado);
                            param.Add("@bitAplDiaSabado", objDatos.bitAplDiaSabado);
                            param.Add("@bitAplDiaDomingo", objDatos.bitAplDiaDomingo);
                            param.Add("@bitFlActivo", objDatos.bitFlActivo);
                            param.Add("@intIdTipRegimen", objDatos.intIdTipRegimen);
                            param.Add("@bitClasifica", objDatos.bitClasifica);
                            param.Add("@smlTipoRedondeo", objDatos.smlTipoRedondeo);
                            param.Add("@smlAplicaRedond", objDatos.smlAplicaRedond);
                            param.Add("@intTiempoRedond", objDatos.intTiempoRedond);
                            param.Add("@smlFormaRedond", objDatos.smlFormaRedond);
                            param.Add("@bitFlHT", objDatos.bitFlHT);
                            param.Add("@bitFlDT", objDatos.bitFlDT);
                            param.Add("@bitFlHTE", objDatos.bitFlHTE);
                            param.Add("@bitFlGenerarHA", objDatos.bitFlGenerarHA);
                            param.Add("@bitFlUtilidades", objDatos.bitFlUtilidades);
                            param.Add("@bitFlCTS", objDatos.bitFlCTS);
                            param.Add("@bitExportPlani", objDatos.bitExportPlani);
                            param.Add("@bitFlSubsidio", objDatos.bitFlSubsidio);
                            param.Add("@bitFlDiaNoLabNiSub", objDatos.bitFlDiaNoLabNiSub);
                            param.Add("@intTiempoRTardanza", objDatos.intTiempoRTardanza);
                            param.Add("@tinFlCompensacion", objDatos.tinFlCompensacion);
                            param.Add("@tinPrioridadHE", objDatos.tinPrioridadHE);
                            if (objDatos.intIdTipBoni == 0)
                                param.Add("@intIdTipBoni", DBNull.Value);
                            else
                                param.Add("@intIdTipBoni", objDatos.intIdTipBoni);

                            param.Add("@intHoraIni", objDatos.intHoraIni);
                            param.Add("@intHoraFin", objDatos.intHoraFin);
                            param.Add("@timeHoraIni", objDatos.timeHoraIni);          //AGREGADOS
                            param.Add("@timeHoraFin", objDatos.timeHoraFin);          //AGREGADOS    
                            param.Add("@intTolerancia", objDatos.intTolerancia);
                            param.Add("@intTiempoMin", objDatos.intTiempoMin);
                            param.Add("@timeTolerancia", objDatos.timeTolerancia);     //AGREGADOS
                            param.Add("@timeTiempoMin", objDatos.timeTiempoMin);       //AGREGADOS
                            param.Add("@bitSustentacion", objDatos.bitSustentacion);
                            param.Add("@intUsoMaximo", objDatos.intUsoMaximo);
                            param.Add("@strConceptoCampo1", objDatos.strConceptoCampo1);
                            param.Add("@strConceptoCampo2", objDatos.strConceptoCampo2);
                            param.Add("@strConceptoCampo3", objDatos.strConceptoCampo3);
                            param.Add("@strConceptoCampo4", objDatos.strConceptoCampo4);
                            param.Add("@strConceptoCampo5", objDatos.strConceptoCampo5);
                            param.Add("@bitFlGrati", objDatos.bitFlGrati);
                            param.Add("@bitFlDescontable", objDatos.bitFlDescontable);
                            param.Add("@bitJornadaEspecif", objDatos.bitJornadaEspecif);
                            param.Add("@bitHoraIni", objDatos.bitHoraIni);
                            param.Add("@bitHoraFin", objDatos.bitHoraFin);
                            param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update
                            //Parámetros de Salida
                            if (intTipoOperacion == 1)
                            {
                                param.Add("@intIdConcepto", 0);
                            }
                            else
                            {
                                param.Add("@intIdConcepto", objDatos.intIdConcepto);
                            }
                            param.Add("@intResult", 0);
                            param.Add("@strMsjDB", "");
                            param.Add("@strMsjUsuario", "");

                            AsignarParametros(cmd, param);
                            cmd.ExecuteNonQuery();

                            intIdVariableOut = Convert.ToInt32(cmd.Parameters["@intIdConcepto"].Value.ToString());
                            intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                            strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                            strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

                            if (intIdVariableOut > 0 && intResult > 0)
                            {
                                if (objDatos.intTipoConcepto == 32)
                                {
                                    //----- TABLA 1: detalle de Concepto ------------------------------------------------
                                    DataTable tb = SerealizeDetalleConcepto(listaConcepto);

                                    SqlCommand cmd1 = new SqlCommand("TSP_TGCONCEPTO_U01", cn);
                                    cmd1.Transaction = trans;
                                    cmd1.CommandType = CommandType.StoredProcedure;
                                    cmd1.CommandTimeout = timeSQL;
                                    Dictionary<string, object> param1 = new Dictionary<string, object>();
                                    param1.Add("@intIdSesion", intIdSesion);
                                    param1.Add("@intIdMenu", intIdMenu);
                                    param1.Add("@intIdSoft", intIdSoft);
                                    param1.Add("@tt_TGCONCEPTO_PRIO", tb);

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
                                            Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGCONCEPTO_U01";
                                        }
                                        else
                                        {
                                            Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGCONCEPTO_U01";
                                        }
                                    }
                                }

                                if (objDatos.intTipoConcepto == 33)
                                {
                                    //----- TABLA 2: detalle de Concepto ------------------------------------------------
                                    DataTable tb2 = SerealizeDetalleCJornadaBoni(listaDetaBoni, intIdVariableOut);

                                    SqlCommand cmd2 = new SqlCommand("TSP_TGJOR_BON_DET_IU02", cn);
                                    cmd2.Transaction = trans;
                                    cmd2.CommandType = CommandType.StoredProcedure;
                                    cmd2.CommandTimeout = timeSQL;
                                    Dictionary<string, object> param2 = new Dictionary<string, object>();
                                    param2.Add("@intIdSesion", intIdSesion);
                                    param2.Add("@intIdMenu", intIdMenu);
                                    param2.Add("@intIdSoft", intIdSoft);
                                    param2.Add("@tt_TGJOR_BON_DET", tb2);

                                    param2.Add("@intIdUsuario", intIdUsuario);
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
                                            Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGJOR_BON_DET_IU02";
                                        }
                                        else
                                        {
                                            Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGJOR_BON_DET_IU02";
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
                                        Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGCONCEPTO_IU01";
                                    }
                                    else
                                    {
                                        Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGCONCEPTO_IU01";
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
        //2.27
        public List<CamposAdicionales2> ListarCamposAdicionales(long intIdSesion, int intIdMenu, int intIdSoft,string  strEntidad, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<CamposAdicionales2> lista = new List<CamposAdicionales2>();
           
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
               
                SqlCommand cmd = new SqlCommand("TSP_TGLISTAR_CAMPOS_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);

                //salida @strNoEntidad 
                param.Add("@strNoEntidad", strEntidad);
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CamposAdicionales2 obj = new CamposAdicionales2();
                    obj.strNoEntidad = reader.GetString(0);
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
        //2.28
        public List<Concepto> ObtenerConceptoPorsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int intIdConcepto, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Concepto> listDetCar = new List<Concepto>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCONCEPTO_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);



                param.Add("@intIdConcepto", intIdConcepto);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Concepto obj = new Concepto();
                        obj.intIdConcepto = reader.GetInt32(0);
                        obj.intTipoConcepto = reader.GetInt32(2);
                        obj.strDeTipotipo = reader.GetString(3);
                        obj.bitInternoSis = reader.GetBoolean(4);
                        obj.strCoConcepto = reader.GetString(5);
                        obj.strDesConcepto = reader.GetString(6);
                        obj.bitReqMarca = reader.GetInt32(7);
                        obj.strCoPlaniExp = reader.GetString(8);
                        obj.strCoPDT = reader.GetString(9);
                        obj.intTipoUM = reader.GetInt32(10);
                        obj.strDeTipoum = reader.GetString(11);
                        obj.bitAplTodosDias = reader.GetBoolean(12);
                        obj.bitAplDiaLabor = reader.GetBoolean(13);
                        obj.bitAplDiaDescanso = reader.GetBoolean(14);
                        obj.bitAplDiaFeriado = reader.GetBoolean(15);
                        obj.bitAplDiaSabado = reader.GetBoolean(16);
                        obj.bitAplDiaDomingo = reader.GetBoolean(17);
                        obj.intIdTipRegimen = reader.GetInt32(18);
                        obj.strDeTipoReg = reader.GetString(19);
                        obj.bitClasifica = reader.GetBoolean(20);
                        obj.smlTipoRedondeo = reader.GetInt16(21);
                        obj.smlAplicaRedond = reader.GetInt16(22);
                        obj.intTiempoRedond = reader.GetInt32(23);
                        obj.smlFormaRedond = reader.GetInt16(24);
                        obj.bitFlHT = reader.GetBoolean(25);
                        obj.bitFlDT = reader.GetBoolean(26);
                        obj.bitFlHTE = reader.GetBoolean(27);
                        obj.bitFlGenerarHA = reader.GetBoolean(28);
                        obj.bitFlUtilidades = reader.GetBoolean(29);
                        obj.bitFlCTS = reader.GetBoolean(30);
                        obj.bitExportPlani = reader.GetBoolean(31);
                        obj.bitFlSubsidio = reader.GetBoolean(32);
                        obj.bitFlDiaNoLabNiSub = reader.GetBoolean(33);
                        obj.intTiempoRTardanza = reader.GetInt32(34);
                        obj.tinFlCompensacion = reader.GetByte(35);
                        obj.tinPrioridadHE = reader.GetByte(36);
                        obj.intIdTipBoni = reader.GetInt32(37);
                        obj.strDeTipoBoni = reader.GetString(38);
                        obj.intHoraIni = reader.GetInt32(39);
                        obj.intHoraFin = reader.GetInt32(40);
                        obj.timeHoraIni = Convert.ToString(reader.GetTimeSpan(41));
                        obj.timeHoraFin = Convert.ToString(reader.GetTimeSpan(42));
                        obj.intTolerancia = reader.GetInt32(43);
                        obj.intTiempoMin = reader.GetInt32(44);
                        obj.timeTolerancia = Convert.ToString(reader.GetTimeSpan(45));
                        obj.timeTiempoMin = Convert.ToString(reader.GetTimeSpan(46));
                        obj.bitSustentacion = reader.GetBoolean(47);
                        obj.intUsoMaximo = reader.GetInt32(48);
                        obj.strConceptoCampo1 = reader.GetString(49);
                        obj.strConceptoCampo2 = reader.GetString(50);
                        obj.strConceptoCampo3 = reader.GetString(51);
                        obj.strConceptoCampo4 = reader.GetString(52);
                        obj.strConceptoCampo5 = reader.GetString(53);
                        obj.bitFlActivo = reader.GetBoolean(54);
                        obj.bitFlGrati = reader.GetBoolean(56);
                        obj.bitFlDescontable = reader.GetBoolean(57);
                        obj.bitJornadaEspecif = reader.GetBoolean(58);
                        obj.bitHoraIni = reader.GetBoolean(63);
                        obj.bitHoraFin = reader.GetBoolean(64);

                        listDetCar.Add(obj);
                    }

                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listDetCar;
        }
        //2.29
        public List<Concepto> ListarPrioritariosdeHorasExtras(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad,int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Concepto> lista = new List<Concepto>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGLISTAR_COMBOS_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
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
                    Concepto obj = new Concepto();

                    obj.intIdConcepto = reader.GetInt32(0);
                    obj.strCoConcepto = reader.GetString(1);
                    obj.strDesConcepto = reader.GetString(2);
                    obj.tinPrioridadHE = reader.GetByte(3);

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //2.30
        public List<Concepto> ListarHorarioEspecificos(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad,int intId ,int intUso, string strGrupo,string strSubGrupo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Concepto> lista = new List<Concepto>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGLISTAR_DET_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);

                param.Add("@strEntidad", strEntidad);
                param.Add("@intId", intId);

                param.Add("@intUso", intUso);
                param.Add("@strGrupo", strGrupo);
                param.Add("@strSubGrupo", strSubGrupo);

                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Concepto obj = new Concepto();

                    obj.intIdConcepto = reader.GetInt32(0);
                    obj.intIdTipBoni = reader.GetInt32(1);
                    obj.intIdTipRegimen = reader.GetInt32(2);

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //2.31
        private DataTable SerealizeDetalleConcepto(List<Concepto> listaConcepto)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdConcepto", typeof(int));
            table.Columns.Add("tinPrioridadHE", typeof(int));

            foreach (var item in listaConcepto)
            {
                DataRow rows = table.NewRow();
                rows["intIdConcepto"] = item.intIdConcepto;
                rows["tinPrioridadHE"] = item.tinPrioridadHE;

                table.Rows.Add(rows);
            }
            return table;
        }
        //2.32
        private DataTable SerealizeDetalleCJornadaBoni(List<TGJOR_BON_DET> listaDetaBoni, int intIdConcepto)
            //private DataTable SerealizeDetalleCJornadaBoni(List<TGJOR_BON_DET> listaDetaBoni, int intIdJorBonDet, int intIdConcepto, int intIdJornada, int intIdUniOrg, DateTime? dttFecAsig)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdJorBonDet", typeof(int));
            table.Columns.Add("intIdConcepto", typeof(int));
            table.Columns.Add("intIdJornada", typeof(int));
            table.Columns.Add("intIdUniOrg", typeof(int));
            table.Columns.Add("dttFecAsig", typeof(DateTime));

            foreach (var item in listaDetaBoni)
            {
                DataRow rows = table.NewRow();
                if (item.intIdJorBonDet == 0)
                    rows["intIdJorBonDet"] = DBNull.Value;
                else
                    rows["intIdJorBonDet"] = item.intIdJorBonDet;
                //if (item.intIdConcepto == 0)
                //    rows["intIdConcepto"] = DBNull.Value;
                //else
                //    rows["intIdConcepto"] = item.intIdConcepto;
                if (intIdConcepto == 0)
                    rows["intIdConcepto"] = DBNull.Value;
                else
                    rows["intIdConcepto"] = intIdConcepto;

                if (item.intIdUniOrg == 0)
                    rows["intIdUniOrg"] = DBNull.Value;
                else
                    rows["intIdUniOrg"] = item.intIdUniOrg;

                if (item.intIdJornada == 0)
                    rows["intIdJornada"] = DBNull.Value;
                else
                    rows["intIdJornada"] = item.intIdJornada;

                if (item.dttFecAsig == null)
                    rows["dttFecAsig"] = DBNull.Value;
                else
                    rows["dttFecAsig"] = item.dttFecAsig;

                table.Rows.Add(rows);
            }
            return table;
        }


    }
}
