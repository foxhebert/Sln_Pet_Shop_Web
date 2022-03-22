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
   public class CalculoManualBL
    {
        private CalculoManualDAO objDao = new CalculoManualDAO();

        public List<GrupoLiquidacion> ListarGrupoLiqxPeriodo(Session_Movi session, List<int> listaPeriodo, ref string strMsjUsuario)
        {
            List<GrupoLiquidacion> lista = new List<GrupoLiquidacion>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                DataTable tb = SerealizePeriodo(listaPeriodo);
                lista = objDao.ListarGrupoLiqxPeriodo(session, tb, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarGrupoLiqxPeriodo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Ocurrió un error en BD (ListarGrupoLiqxPeriodo)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Error General (ListarGrupoLiqxPeriodo)");
            }
            return lista;
        }

        public List<Planilla> ListarCampoPlanillaAbierta(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<Planilla> lista = new List<Planilla>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCampoPlanillaAbierta(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCampoPlanillaAbierta] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Ocurrió un error en BD (ListarCampoPlanillaAbierta)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Error General (ListarCampoPlanillaAbierta)");
            }
            return lista;
        }

        public List<Periodo> ListarCampoPeriodoxPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPlanilla, ref string strMsjUsuario)
        {
            List<Periodo> lista = new List<Periodo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCampoPeriodoxPlanilla(intIdSesion, intIdMenu, intIdSoft,intIdPlanilla, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCampoPeriodoxPlanilla] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Ocurrió un error en BD (ListarCampoPeriodoxPlanilla)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Error General (ListarCampoPeriodoxPlanilla)");
            }
            return lista;
        }

        public List<CalculoPersonal> GetListarPersonal(Session_Movi session, int intIdPlanilla, string strFiltroCalculo, List<int> listaGrupoLiq, ref string strMsjUsuario)
        {
            List<CalculoPersonal> lista = new List<CalculoPersonal>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                DataTable tb = SerealizeGrupoLiq(listaGrupoLiq);
                lista = objDao.GetListarPersonal(session, intIdPlanilla, strFiltroCalculo, tb, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[GetListarPersonal] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Ocurrió un error en BD (GetListarPersonal)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Error General (GetListarPersonal)");
            }
            return lista;
        }

        public int Calcular(Session_Movi session, int intIdPeriodos, List<int> listPersonal, int intIdPlanilla, int intIdProc)
        {
            int id = 0;
            try
            {
                DataTable tb = SerealizeIdentificador(listPersonal);
                id = objDao.Calcular(session, intIdPeriodos, tb, intIdPlanilla, intIdProc);
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Ocurrió un error en BD (GetListarPersonal)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Error General (GetListarPersonal)");
            }
            return id;
        }

        public List<Periodo> getPeriodoxPlanilla(Session_Movi session, int intIdPlanilla, bool bitCerrado, ref string strMsjUsuario)
        {
            List<Periodo> lista = new List<Periodo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.getPeriodoxPlanilla(session, intIdPlanilla, bitCerrado, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[getPeriodoxPlanilla] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Ocurrió un error en BD (getPeriodoxPlanilla)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Error General (getPeriodoxPlanilla)");
            }
            return lista;
        }

        public int updatePeriodo(Session_Movi session, List<int> listPeriodos, bool bitCerrado, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            int id = 0;

            try
            {
                DataTable tb = SerealizePeriodo(listPeriodos);
                objDao.updatePeriodo(session, tb, bitCerrado, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[GetListarPersonal] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Ocurrió un error en BD (GetListarPersonal)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Error General (GetListarPersonal)");
            }
            return id;
        }

        public List<CalculoPersonal> GuardarCalculo(Session_Movi session, int intIdProceso, string strFiltroCalculo, int intIdPlanilla, List<int> listaGrupoLiq,  ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<CalculoPersonal> list = new List<CalculoPersonal>();

            try
            {
                DataTable tb = SerealizeGrupoLiq(listaGrupoLiq);
                list = objDao.GuardarCalculo(session, intIdProceso, strFiltroCalculo, intIdPlanilla, tb, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[GuardarCalculo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Ocurrió un error en BD (GuardarCalculo)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Error General (GuardarCalculo)");
            }
            return list;
        }

        public int LimpiarTemporal(Session_Movi session, int intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            int id = 0;

            try
            {
                objDao.LimpiarTemporal(session, intIdProceso, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[LimpiarTemporal] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Ocurrió un error en BD (LimpiarTemporal)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Error General (LimpiarTemporal)");
            }
            return id;
        }

        public List<CalculoPersonal> getPersonalCalculo(Session_Movi session, int intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<CalculoPersonal> list = new List<CalculoPersonal>();

            try
            {
                list = objDao.getPersonalCalculo(session, intIdProceso, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[getPersonalCalculo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Ocurrió un error en BD (getPersonalCalculo)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Error General (getPersonalCalculo)");
            }
            return list;
        }

        public List<CalculoPersonal> getPersonalNoProc(Session_Movi session, int intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<CalculoPersonal> list = new List<CalculoPersonal>();

            try
            {

                list = objDao.getPersonalNoProc(session, intIdProceso, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[getPersonalNoProc] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Ocurrió un error en BD (getPersonalNoProc)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Error General (getPersonalNoProc)");
            }
            return list;
        }

        public List<CalculoPersonal> getExportEmpleados(Session_Movi session, List<int> list, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<CalculoPersonal> listOutput = new List<CalculoPersonal>();

            try
            {
                DataTable tb = SerealizePeriodo(list);
                listOutput = objDao.getExportEmpleados(session, tb, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[getExportEmpleados] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Ocurrió un error en BD (getExportEmpleados)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Error General (getExportEmpleados)");
            }
            return listOutput;
        }

        public int validarPeriodo(Session_Movi session, List<int> list)
        {
            int salida = 0;

            try
            {
                DataTable tb = SerealizePeriodo(list);
                salida = objDao.validarPeriodo(session, tb);
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Ocurrió un error en BD (validarPeriodo)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CalculoManualBL.cs");
                throw new Exception("Error General (validarPeriodo)");
            }
            return salida;
        }
               
        private DataTable SerealizePeriodo(List<int> listaPeriodo)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdPeriodo", typeof(int));

            foreach (var item in listaPeriodo)
            {
                DataRow rows = table.NewRow();
                rows["intIdPeriodo"] = item;
                table.Rows.Add(rows);
            }

            return table;
        }

        private DataTable SerealizePersonal(List<int> listPersonal)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdPersonal", typeof(int));

            foreach (var item in listPersonal)
            {
                DataRow rows = table.NewRow();
                rows["intIdPersonal"] = item;
                table.Rows.Add(rows);
            }

            return table;
        }

        private DataTable SerealizeGrupoLiq(List<int> listaGrupoLiq)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdGrupoLiq", typeof(int));

            foreach (var item in listaGrupoLiq)
            {
                DataRow rows = table.NewRow();
                rows["intIdGrupoLiq"] = item;
                table.Rows.Add(rows);
            }

            return table;
        }

        private DataTable SerealizeIdentificador(List<int> listPersonal)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdTabla", typeof(int));

            foreach (var item in listPersonal)
            {
                DataRow rows = table.NewRow();
                rows["intIdTabla"] = item;
                table.Rows.Add(rows);
            }

            return table;
        }

    }
}
