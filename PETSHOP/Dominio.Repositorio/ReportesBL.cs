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
    public class ReportesBL
    {
        private ReportesDAO objDao = new ReportesDAO();




        //30.1 GenerarArchivosExcel List<TablasGenerarExcel>
        public List<TMPRODU_EXPORTAR> GenerarListaExportarInventario(Session_Movi objSession, string strArchivoExportado, ref string strMsjUsuario)
        {
            List<TMPRODU_EXPORTAR> lista = new List<TMPRODU_EXPORTAR>();
            string nombreDelSp = "";
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.GenerarListaExportarInventario(objSession, strArchivoExportado, ref intResult, ref strMsjDB, ref strMsjUsuario, ref nombreDelSp);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[GenerarListaExportar] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (GenerarListaExportar)");
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232015)
                {
                    Exception ex_null = new Exception("---> Error generado en el SP: " + nombreDelSp);
                    Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception" + " ( " + ex_null + " )");
                    throw new Exception("Error General (GenerarListaExportar)");

                }
                else
                {
                    Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                    throw new Exception("Error General (GenerarListaExportar)");

                }
            }
            return lista;
        }




        //16.7 ----> HG 21.06.21  //ReporteDiario
        public List<ReporteExcelExportado> ReporteExcelExportado(Session_Movi session, List<int> listExcel, bool bitCosto, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario, int intIdTipServ, int intIdTipMen, int intIdMarcador)
        {
            List<ReporteExcelExportado> lista = new List<ReporteExcelExportado>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                //No se necesitará
                DataTable tb = SerealizePersonal(listExcel);

                lista = objDao.ReporteExcelExportado(session, tb, bitCosto, filtrojer_ini, filtrojer_fin, ref intResult, ref strMsjDB, ref strMsjUsuario, intIdTipServ, intIdTipMen, intIdMarcador);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ReporteDiarioComedor] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ReporteDiarioComedor)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                throw new Exception("Error General (ReporteDiarioComedor)");
            }
            return lista;
        }


        #region EXPORTAR EXCEL (Sisactivofijo)


        //16.1 GENERAR Y ENVIAR EXCELS POR MAIL
        public List<TablasGenerarExcel> ToEmailGenerarArchivosExcel(Session_Movi objSession, string strExcelExportado, ref string strMsjUsuario)
        {
            List<TablasGenerarExcel> lista = new List<TablasGenerarExcel>();
            string nombreDelSp = "";
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ToEmailGenerarArchivosExcel(objSession, strExcelExportado, ref intResult, ref strMsjDB, ref strMsjUsuario, ref nombreDelSp);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ToEmailGenerarArchivosExcel] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ToEmailGenerarArchivosExcel)");
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232015)
                {
                    Exception ex_null = new Exception("---> Error generado en el SP: " + nombreDelSp);
                    Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception" + " ( " + ex_null + " )");
                    throw new Exception("Error General (ToEmailGenerarArchivosExcel)");

                }
                else
                {
                    Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                    throw new Exception("Error General (ToEmailGenerarArchivosExcel)");

                }
            }
            return lista;
        }


        //16.7 GENERAR LISTAS DE 08 TABLAS PARA GENRAR EXCEL DE CADA UNO
        public List<TablasExcelsConDataSQL> GenerarExcelsConDataSQLListas(Session_Movi objSession, string strNombreExcelConDataSQL, ref string strMsjUsuario)
        {
            List<TablasExcelsConDataSQL> lista = new List<TablasExcelsConDataSQL>();
            string nombreDelSp = "";
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.GenerarExcelsConDataSQLListas(objSession, strNombreExcelConDataSQL, ref intResult, ref strMsjDB, ref strMsjUsuario, ref nombreDelSp);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[GenerarExcelsConDataSQLListas] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (GenerarExcelsConDataSQLListas)");
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232015)
                {
                    Exception ex_null = new Exception("---> Error generado en el SP: " + nombreDelSp);
                    Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception" + " ( " + ex_null + " )");
                    throw new Exception("Error General (GenerarExcelsConDataSQLListas)");

                }
                else
                {
                    Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                    throw new Exception("Error General (GenerarExcelsConDataSQLListas)");

                }
            }
            return lista;
        }


        //12.1
        public List<TablasGenerarExcel> GenerarArchivosExcel(Session_Movi objSession, string strExcelExportado, ref string strMsjUsuario)
        {
            List<TablasGenerarExcel> lista = new List<TablasGenerarExcel>();
            string nombreDelSp = "";
            try
            {
                int intResult = 0;
                string strMsjDB = "";
                
                

                lista = objDao.GenerarArchivosExcel(objSession, strExcelExportado, ref intResult, ref strMsjDB, ref strMsjUsuario, ref nombreDelSp);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[GenerarArchivosExcel] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (GenerarArchivosExcel)");
            }
            catch (Exception ex)
            {
                if(ex.HResult == -2146232015) {
                    Exception ex_null = new Exception( "---> Error generado en el SP: " + nombreDelSp );
                    Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception" +" ( "+ ex_null + " )");
                    throw new Exception("Error General (GenerarArchivosExcel)");

                }
                else
                {
                    Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                    throw new Exception("Error General (GenerarArchivosExcel)");

                }
            }
            return lista;
        }

        //12.5 REPORTE DE EXCELS EXPORTADOS
        public List<ReporteExcelsExportados> ReporteDeExcelsExportados(Session_Movi objSession, string strExcelExportado, ref string strMsjUsuario)
        {
            List<ReporteExcelsExportados> lista = new List<ReporteExcelsExportados>();
            string nombreDelSp = "";
            try
            {
                int intResult = 0;
                string strMsjDB = "";



                lista = objDao.ReporteDeExcelsExportados(objSession, strExcelExportado, ref intResult, ref strMsjDB, ref strMsjUsuario, ref nombreDelSp);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ReporteDeExcelsExportados] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ReporteDeExcelsExportados)");
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232015)
                {
                    Exception ex_null = new Exception("---> Error generado en el SP: " + nombreDelSp);
                    Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception" + " ( " + ex_null + " )");
                    throw new Exception("Error General (ReporteDeExcelsExportados)");

                }
                else
                {
                    Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                    throw new Exception("Error General (ReporteDeExcelsExportados)");

                }
            }
            return lista;
        }

        //12.6 Archivos de Texto
        public List<TablasGenerarTxt> GenerarArchivosTxt(Session_Movi objSession, string strTxtExportado, ref string strMsjUsuario)
        {
            List<TablasGenerarTxt> lista = new List<TablasGenerarTxt>();
            string nombreDelSp = "";
            try
            {
                int intResult = 0;
                string strMsjDB = "";



                lista = objDao.GenerarArchivosTxt(objSession, strTxtExportado, ref intResult, ref strMsjDB, ref strMsjUsuario, ref nombreDelSp);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[GenerarArchivosExcel] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (GenerarArchivosExcel)");
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232015)
                {
                    Exception ex_null = new Exception("---> Error generado en el SP: " + nombreDelSp);
                    Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception" + " ( " + ex_null + " )");
                    throw new Exception("Error General (GenerarArchivosExcel)");

                }
                else
                {
                    Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                    throw new Exception("Error General (GenerarArchivosExcel)");

                }
            }
            return lista;
        }


        #endregion


        public List<Planilla> ListarCampoPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUniOrg, ref string strMsjUsuario)
        {
            List<Planilla> lista = new List<Planilla>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCampoPlanilla(intIdSesion, intIdMenu, intIdSoft, intIdUniOrg, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCampoPlanilla] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCampoPlanilla)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                throw new Exception("Error General (ListarCampoPlanilla)");
            }
            return lista;
        }

        //7.2
        public List<TGTipoEN> ListarCampoFizcalizacion(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCampoFizcalizacion(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCampoFizcalizacion] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCampoFizcalizacion)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                throw new Exception("Error General (ListarCampoFizcalizacion)");
            }
            return lista;
        }
        //7.3
        public List<Reporte> ConsultaReporte(Session_Movi session, int cboUniOrg, string filtroCalculo, int cboPlanilla, int cboCategoria, bool cesado, int estado, List<int> listGrupoLiq, ref string strMsjUsuario)
        {
            List<Reporte> lista = new List<Reporte>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                DataTable tb = SerealizeGrupoLiq(listGrupoLiq);

                lista = objDao.ConsultaReporte(session, cboUniOrg, filtroCalculo, cboPlanilla, cboCategoria, cesado, estado, tb, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ConsultaReporte] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ConsultaReporte)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                throw new Exception("Error General (ConsultaReporte)");
            }
            return lista;
        }
        //7.4
        public List<ReporteOficial> ReporteOficial(Session_Movi session, List<int> listEmpleados, bool marca, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario)
        {
            List<ReporteOficial> lista = new List<ReporteOficial>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                DataTable tb = SerealizePersonal(listEmpleados);

                lista = objDao.ReporteOficial(session, tb, marca, filtrojer_ini, filtrojer_fin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ReporteOficial] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ReporteOficial)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                throw new Exception("Error General (ReporteOficial)");
            }
            return lista;
        }
        //7.5
        public List<ReporteDiario> ReporteDiario(Session_Movi session, List<int> listEmpleados, bool marca, int estado, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario)
        {
            List<ReporteDiario> lista = new List<ReporteDiario>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                DataTable tb = SerealizePersonal(listEmpleados);

                lista = objDao.ReporteDiario(session, tb, marca, estado, filtrojer_ini, filtrojer_fin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ReporteDiario] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ReporteDiario)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                throw new Exception("Error General (ReporteDiario)");
            }
            return lista;
        }
        //7.6
        public List<ReporteResumenTotal> ReporteResumenTotal(Session_Movi session, List<int> listEmpleados, int intPeriodo, ref string strMsjUsuario)
        {
            List<ReporteResumenTotal> lista = new List<ReporteResumenTotal>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                DataTable tb = SerealizePersonal(listEmpleados);

                lista = objDao.ReporteResumenTotal(session, tb, intPeriodo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ReporteResumenTotal] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ReporteResumenTotal)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                throw new Exception("Error General (ReporteResumenTotal)");
            }
            return lista;
        }
        //7.7
        public List<ReporteFalta> ReporteFalta(Session_Movi session, List<int> listEmpleados, int intPeriodo, ref string strMsjUsuario)
        {
            List<ReporteFalta> lista = new List<ReporteFalta>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                DataTable tb = SerealizePersonal(listEmpleados);

                lista = objDao.ReporteFalta(session, tb, intPeriodo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ReporteFalta] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ReporteFalta)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                throw new Exception("Error General (ReporteFalta)");
            }
            return lista;
        }
        //7.8
        public List<ReportePuntualidad> ReportePuntualidad(Session_Movi session, List<int> listEmpleados, int intPeriodo, int tipo, ref string strMsjUsuario)
        {
            List<ReportePuntualidad> lista = new List<ReportePuntualidad>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                DataTable tb = SerealizePersonal(listEmpleados);

                lista = objDao.ReportePuntualidad(session, tb, intPeriodo, tipo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ReportePuntualidad] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ReportePuntualidad)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                throw new Exception("Error General (ReportePuntualidad)");
            }
            return lista;
        }
        //7.9
        public List<ReporteTardanza> ReporteTardanza(Session_Movi session, List<int> listEmpleados, int intPeriodo, ref string strMsjUsuario)
        {
            List<ReporteTardanza> lista = new List<ReporteTardanza>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                DataTable tb = SerealizePersonal(listEmpleados);

                lista = objDao.ReporteTardanza(session, tb, intPeriodo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ReporteTardanza] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ReporteTardanza)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                throw new Exception("Error General (ReporteTardanza)");
            }
            return lista;
        }
        //7.10
        public List<ReporteRecordGeneral> ReporteRecordGeneral(Session_Movi session, List<int> listEmpleados, int intPeriodo, int tipo, ref string strMsjUsuario)
        {
            List<ReporteRecordGeneral> lista = new List<ReporteRecordGeneral>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                DataTable tb = SerealizePersonal(listEmpleados);

                lista = objDao.ReporteRecordGeneral(session, tb, intPeriodo, tipo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ReporteRecordGeneral] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ReporteRecordGeneral)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                throw new Exception("Error General (ReporteRecordGeneral)");
            }
            return lista;
        }
        //7.11
        public List<ReporteAusencia> ReporteAusencia(Session_Movi session, List<int> listEmpleados, List<int> listConceptos, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario)
        {
            List<ReporteAusencia> lista = new List<ReporteAusencia>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                DataTable tb = SerealizePersonal(listEmpleados);
                DataTable tb2 = SerealizeConcepto(listConceptos);

                lista = objDao.ReporteAusencia(session, tb, tb2, filtrojer_ini, filtrojer_fin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ReporteAusencia] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ReporteAusencia)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                throw new Exception("Error General (ReporteAusencia)");
            }
            return lista;
        }
        //7.12
        public List<ReporteAsistencia> ReporteAsistencia(Session_Movi session, List<int> listEmpleados, int intMarcador, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario)
        {
            List<ReporteAsistencia> lista = new List<ReporteAsistencia>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                DataTable tb = SerealizePersonal(listEmpleados);

                lista = objDao.ReporteAsistencia(session, tb, intMarcador, filtrojer_ini, filtrojer_fin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ReporteAsistencia] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ReporteAsistencia)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                throw new Exception("Error General (ReporteAsistencia)");
            }
            return lista;
        }
        //7.13
        public List<ReporteM> GetReportes(Session_Movi session, ref string strMsjUsuario)
        {
            List<ReporteM> lista = new List<ReporteM>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.GetReportes(session, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[GetReportes] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (GetReportes)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                throw new Exception("Error General (GetReportes)");
            }
            return lista;
        }


        #region COMEDOR
        //7.14 - HG 05.03.21 //ReporteDiario
        public List<ReporteDiarioComedor> ReporteDiarioComedor(Session_Movi session, List<int> listEmpleados, bool bitCosto, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario, int intIdTipServ, int intIdTipMen, int intIdMarcador)
        {
            List<ReporteDiarioComedor> lista = new List<ReporteDiarioComedor>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                DataTable tb = SerealizePersonal(listEmpleados);

                lista = objDao.ReporteDiarioComedor(session, tb, bitCosto, filtrojer_ini, filtrojer_fin, ref intResult, ref strMsjDB, ref strMsjUsuario, intIdTipServ, intIdTipMen, intIdMarcador);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ReporteDiarioComedor] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ReporteDiarioComedor)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                throw new Exception("Error General (ReporteDiarioComedor)");
            }
            return lista;
        }

        //7.15 - HG 08.03.21 //de ReporteResumenTotal
        public List<ReporteTotalComedor> ReporteTotalComedor(Session_Movi session, List<int> listEmpleados, int intPeriodo, bool bitCosto, ref string strMsjUsuario, int intIdTipServ, int intIdTipMen, int intIdMarcador)
        {
            List<ReporteTotalComedor> lista = new List<ReporteTotalComedor>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                DataTable tb = SerealizePersonal(listEmpleados);

                lista = objDao.ReporteTotalComedor(session, tb, intPeriodo, bitCosto, ref intResult, ref strMsjDB, ref strMsjUsuario, intIdTipServ, intIdTipMen, intIdMarcador);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ReporteTotalComedor] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ReporteTotalComedor)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                throw new Exception("Error General (ReporteTotalComedor)");
            }
            return lista;
        }
        //7.16 - 16.03.2021
        public List<ReporteDiarioConcesionaria> ReporteDiarioConcesionaria(Session_Movi session, List<int> listEmpleados, int idConcesionaria, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario, int intIdTipServ, int intIdTipMen, int intIdMarcador)
        {
            List<ReporteDiarioConcesionaria> lista = new List<ReporteDiarioConcesionaria>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                DataTable tb = SerealizePersonal(listEmpleados);

                lista = objDao.ReporteDiarioConcesionaria(session, tb, idConcesionaria, filtrojer_ini, filtrojer_fin, ref intResult, ref strMsjDB, ref strMsjUsuario, intIdTipServ, intIdTipMen, intIdMarcador);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ReporteDiarioConcesionaria] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ReporteDiarioConcesionaria)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                throw new Exception("Error General (ReporteDiarioConcesionaria)");
            }
            return lista;
        }
        //7.17
        public List<ReporteTotalConcesionaria> ReporteTotalConcesionaria(Session_Movi session, List<int> listEmpleados, int intPeriodo, int idConcesionaria, ref string strMsjUsuario, int intIdTipServ, int intIdTipMen, int intIdMarcador)
        {
            List<ReporteTotalConcesionaria> lista = new List<ReporteTotalConcesionaria>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                DataTable tb = SerealizePersonal(listEmpleados);

                lista = objDao.ReporteTotalConcesionaria(session, tb, intPeriodo, idConcesionaria, ref intResult, ref strMsjDB, ref strMsjUsuario, intIdTipServ, intIdTipMen, intIdMarcador);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ReporteTotalConcesionaria] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ReporteTotalConcesionaria)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReportesBL.cs: Exception");
                throw new Exception("Error General (ReporteTotalConcesionaria)");
            }
            return lista;
        }
        #endregion COMEDOR

        //7.18
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
        //7.19
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
        //7.20
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
        //7.21
        private DataTable SerealizeConcepto(List<int> listConceptos)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdConcepto", typeof(int));

            foreach (var item in listConceptos)
            {
                DataRow rows = table.NewRow();
                rows["intIdConcepto"] = item;
                table.Rows.Add(rows);
            }

            return table;
        }

    }
}
