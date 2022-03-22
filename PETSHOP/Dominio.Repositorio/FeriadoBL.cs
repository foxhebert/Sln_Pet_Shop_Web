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
    public class FeriadoBL
    {
        private FeriadoDAO objDao = new FeriadoDAO();

        //2.1
        public List<TSPTAASISTENCIA> ObtenerAsistenciaXFecha(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario)
        {
            List<TSPTAASISTENCIA> lista = new List<TSPTAASISTENCIA>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerAsistenciaXFecha(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, filtrojer_ini, filtrojer_fin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerAsistenciaXFecha] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerAsistenciaXFecha)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: Exception");
                throw new Exception("Error General (ObtenerAsistenciaXFecha)");
            }
            return lista;
        }
        //2.2
        public List<Feriado> ListarFeriados(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, string intfiltrojer1, string intfiltrojer2, ref string strMsjUsuario)
        {
            List<Feriado> lista = new List<Feriado>();
            try
            {
               int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarFeriados(intIdSesion, intIdMenu, intIdSoft,  intActivoFilter,  strfilter,  intfiltrojer1,  intfiltrojer2, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarFeriados] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarFeriados)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: Exception");
                throw new Exception("Error General (ListarFeriados)");
            }
            return lista;
        }
        //2.3
        public bool EliminmarFeriado(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdFeriado, ref string strMsjUsuario)
        {

            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objDao.EliminmarFeriado(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdFeriado, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminmarFeriado] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminmarFeriado)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: Exception");
                throw new Exception("Error General (EliminmarFeriado)");
            }
        }
        //2.4
        public bool IUFeriado_T(long intIdSesion, int intIdMenu, int intIdSoft, Feriado objDatos, List<TGFER_UNIORG_DET> listaOrgxFer, int intIdUsuario, int intTipoOperacion, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";
                string Msj = "";

                intResult = objDao.IUFeriado_T(intIdSesion, intIdMenu, intIdSoft, objDatos, listaOrgxFer, intIdUsuario, intTipoOperacion, ref intResult, ref strMsjDB, ref strMsjUsuario, ref Msj);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUFeriado_T] => Respuesta del Procedimiento : " + strMsjDB);
                        Log.AlmacenarLogMensaje("[IUFeriado_T] => Respuesta del Procedimiento : " + Msj);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                else
                {
                    tudobem = true;
                }
                return tudobem;
            }
            //catch (TransactionAbortedException ex)
            //{
            //    Log.AlmacenarLogError(ex, "FeriadoBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (IUFeriado_T)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (IUFeriado_T)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: Exception");
                throw new Exception("Error General (IUFeriado_T)");
            }
        }
        //2.5
        public List<Feriado> ObtenerRegistroFeriado(long intIdSesion, int intIdMenu, int intIdSoft, int intIdFeriado, ref string strMsjUsuario)
        {
            List<Feriado> lista = new List<Feriado>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerRegistroFeriado(intIdSesion, intIdMenu, intIdSoft, intIdFeriado, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerRegistroFeriado] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerRegistroFeriado)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: Exception");
                throw new Exception("Error General (ObtenerRegistroFeriado)");
            }
            return lista;
        }
        //2.6
        public List<TGFER_UNIORG_DET> ObtenerRegistroReglaDetalleDeOrgixFer(long intIdSesion, int intIdMenu, int intIdSoft, int intIdFeriado, ref string strMsjUsuario)
        {
            List<TGFER_UNIORG_DET> lista = new List<TGFER_UNIORG_DET>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerRegistroReglaDetalleDeOrgixFer(intIdSesion, intIdMenu, intIdSoft, intIdFeriado, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerRegistroReglaDetalleDeOrgixFer] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerRegistroReglaDetalleDeOrgixFer)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: Exception");
                throw new Exception("Error General (ObtenerRegistroReglaDetalleDeOrgixFer)");
            }
            return lista;
        }
        //2.7
        public List<TGTipoEN> ListarCampRecur(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCampRecur(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCampRecur] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCampRecur)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: Exception");
                throw new Exception("Error General (ListarCampRecur)");
            }
            return lista;
        }
        //2.8
        public List<TGTipoEN> ListarCampRegi(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCampRegi(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarRegimen] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarRegimen)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: Exception");
                throw new Exception("Error General (ListarRegimen)");
            }
            return lista;
        }


    }
}
