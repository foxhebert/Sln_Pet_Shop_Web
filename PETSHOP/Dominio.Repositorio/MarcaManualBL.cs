using Dominio.Entidades;
using Dominio.Repositorio.Util;
using Infraestructura.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Dominio.Repositorio
{
    public class MarcaManualBL
    {

        private MarcaManualDAO objDao = new MarcaManualDAO();
        //2.67
        public List<AsigHorarioData> GetEmpleados(Session_Movi objSession, int intActivoFilter, string strfilter, int IntIdEmp, string dttfiltrofch1, string dttfiltrofch2, ref string strMsjUsuario)
        {
            List<AsigHorarioData> lista = new List<AsigHorarioData>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.GetEmpleados(objSession, intActivoFilter, strfilter, IntIdEmp, dttfiltrofch1, dttfiltrofch2, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[GetEmpleados] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "MarcaManualBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (GetEmpleados)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "MarcaManualBL.cs: Exception");
                throw new Exception("Error General (GetEmpleados)");
            }
            return lista;
        }
        //2.68
        public List<AsistenciaData> GetAsistencias(Session_Movi objSession, int intIdPersonal, string dttfiltrofch1, string dttfiltrofch2, ref string strMsjUsuario)
        {
            List<AsistenciaData> lista = new List<AsistenciaData>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.GetAsistencias(objSession, intIdPersonal, dttfiltrofch1, dttfiltrofch2, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[GetAsistencias] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "MarcaManualBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (GetAsistencias)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "MarcaManualBL.cs: Exception");
                throw new Exception("Error General (GetAsistencias)");
            }
            return lista;
        }
        //2.69
        public bool EliminarMarca(Session_Movi objSession, long intIdAsistencia, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";
                bool result = false;

                result = objDao.EliminarMarca(objSession, intIdAsistencia, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminarMarca] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return result;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "MarcaManualBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminarMarca)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "MarcaManualBL.cs: Exception");
                throw new Exception("Error General (EliminarMarca)");
            }
        }
        //2.70
        public List<Dictionary<string, string>> Guardar(Session_Movi objSession, Asistencia objAsistencia, List<Dictionary<string, string>> listaFechas, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                DataTable tb = SerealizeDetalleMarcaManual(listaFechas);
                List<Dictionary<string, string>> salida = objDao.Guardar(objSession, objAsistencia, tb, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[Guardar] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return salida;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "MarcaManualBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (Guardar)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "MarcaManualBL.cs: Exception");
                throw new Exception("Error General (Guardar)");
            }
        }
        //2.71
        public Dictionary<string, string> GetMarcasHorario(Session_Movi objSession, int intIdPersonal, ref string strMsjUsuario)
        {
            Dictionary<string, string> objeto = new Dictionary<string, string>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                objeto = objDao.GetMarcasHorario(objSession, intIdPersonal, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[GetMarcasHorario] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "MarcaManualBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (GetMarcasHorario)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "MarcaManualBL.cs: Exception");
                throw new Exception("Error General (GetMarcasHorario)");
            }
            return objeto;
        }
        //2.72
        public Asistencia getAsistenciaXID(Session_Movi objSession, int intIdAsistencia, ref string strMsjUsuario)
        {
            Asistencia objeto = new Asistencia();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                objeto = objDao.getAsistenciaXID(objSession, intIdAsistencia, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[getAsistenciaXID] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "MarcaManualBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (getAsistenciaXID)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "MarcaManualBL.cs: Exception");
                throw new Exception("Error General (getAsistenciaXID)");
            }
            return objeto;
        }
        //2.73
        public bool ActualizarMarca(Session_Movi objSession, Asistencia objAsistencia, ref string strMsjUsuario)
        {
            bool salida = false;
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                if (objAsistencia.intDiaSgt == 1)
                {
                    string formato = "yyyy-MM-dd";
                    objAsistencia.dttFecha = DateTime.Parse(objAsistencia.dttFechaHora).AddDays(-1).ToString(formato) + " 00:00:00";
                }
                else
                {
                    objAsistencia.dttFecha = objAsistencia.dttFechaHora.Substring(0, 10) + " 00:00:00";
                }

                salida = objDao.ActualizarMarca(objSession, objAsistencia, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ActualizarMarca] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "MarcaManualBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ActualizarMarca)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "MarcaManualBL.cs: Exception");
                throw new Exception("Error General (ActualizarMarca)");
            }
            return salida;
        }
        //2.74
        public Dictionary<string, string> GetUltimaMarca(Session_Movi objSession, int intIdPersonal, ref string strMsjUsuario)
        {
            Dictionary<string, string> objeto = new Dictionary<string, string>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                objeto = objDao.GetUltimaMarca(objSession, intIdPersonal, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[GetUltimaMarca] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "MarcaManualBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (GetUltimaMarca)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "MarcaManualBL.cs: Exception");
                throw new Exception("Error General (GetUltimaMarca)");
            }
            return objeto;
        }
        //2.75
        private string getNombre(string nombre)
        {
            if (nombre == "dateEntrada")
            {
                return "Entrada";
            }
            else if (nombre == "dateSalida")
            {
                return "Salida";
            }
            else if (nombre == "dateSalidaRe")
            {
                return "Salida Refrigerio";
            }
            else if (nombre == "dateEntradaRe")
            {
                return "Entrada Refrigerio";
            }
            else if (nombre == "dateEntradaHE")
            {
                return "Entrada Hora Extra";
            }
            else if (nombre == "dateSalidaHE")
            {
                return "Salida Hora Extra";
            }
            return "";
        }
        //2.76
        private DataTable SerealizeDetalleMarcaManual(List<Dictionary<string, string>> listaFechas)
        {
            DataTable table = new DataTable();

            table.Columns.Add("dttFecha", typeof(DateTime));
            table.Columns.Add("dttFechaHora", typeof(DateTime));
            table.Columns.Add("intIdTipoMarca", typeof(int));

            table.Columns.Add("biFlDiaSgt", typeof(bool));
            table.Columns.Add("bitFlRepetido", typeof(bool));
            table.Columns.Add("strRepetido", typeof(string));
            table.Columns.Add("tinIdTMarcacion", typeof(int));

            string formato = "yyyy-MM-dd";

            foreach (var item in listaFechas)
            {
                if (item["value"] != "0")
                {
                    DataRow rows = table.NewRow();

                    string fecha = item["value"].Substring(1);
                    bool diaSgt = Convert.ToBoolean(Int32.Parse(item["value"].Substring(0, 1)));
                    int codigo = Int32.Parse(item["codigo"]);

                    if (diaSgt)
                    {
                        rows["dttFecha"] = DateTime.Parse(fecha).AddDays(-1).ToString(formato) + " 00:00:00";
                    }
                    else
                    {
                        rows["dttFecha"] = fecha.Substring(0, 10) + " 00:00:00";
                    }
                    rows["dttFechaHora"] = fecha;
                    rows["intIdTipoMarca"] = codigo;


                    rows["biFlDiaSgt"] = diaSgt;

                    rows["bitFlRepetido"] = false;
                    rows["strRepetido"] = "";
                    if (item["fecha"] != "")
                    {
                        rows["bitFlRepetido"] = true;
                        rows["strRepetido"] = item["fecha"];
                    }

                    if (item["key"] == "dateEntrada" || item["key"] == "dateEntradaRe" || item["key"] == "dateEntradaHE")
                    {
                        rows["tinIdTMarcacion"] = 1;
                    }
                    else { rows["tinIdTMarcacion"] = 2; }

                    table.Rows.Add(rows);
                }
            }

            return table;
        }

    }
}
