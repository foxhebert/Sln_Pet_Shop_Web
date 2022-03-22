using Dominio.Entidades;
using Dominio.Repositorio.Util;
using Infraestructura.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Dominio.Repositorio
{
    public class PeriodoBL
    {
        private PeriodoDAO objDao = new PeriodoDAO();
        //6.1
        public List<PeriodoData> ListPeriodoPago(Session_Movi session, string filtroPeriodo, int filtroActivo, int filtroSituacion, string filtrojer_ini, string filtrojer_fin, int intIdPlanilla, ref string strMsjUsuario)
        {
            List<PeriodoData> lista = new List<PeriodoData>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListPeriodoPago(session, filtroPeriodo, filtroActivo, filtroSituacion, filtrojer_ini, filtrojer_fin, intIdPlanilla, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListPeriodoPago] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PeriodoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListPeriodoPago)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PeriodoBL.cs: Exception");
                throw new Exception("Error General (ListPeriodoPago)");
            }
            return lista;
        }
        //6.2
        public bool EliminarPeriodo(Session_Movi session, int intIdPeriodo, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";
                bool estado = false;

                estado = objDao.EliminarPeriodo(session, intIdPeriodo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminarPeriodo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return estado;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PeriodoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminarPeriodo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PeriodoBL.cs: Exception");
                throw new Exception("Error General (EliminarPeriodo)");
            }
        }
        //6.3
        public Periodo ObtenerPeriodoPorsuPK(Session_Movi session, int intIdPeriodo, ref string strMsjUsuario)
        {
            Periodo obj = new Periodo();
            try
            {
                int intResult = 0;
                string strMsjDB = "";
                //bool estado = false;

                obj = objDao.ObtenerPeriodoPorsuPK(session, intIdPeriodo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerPeriodoPorsuPK] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PeriodoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerPeriodoPorsuPK)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PeriodoBL.cs: Exception");
                throw new Exception("Error General (ObtenerPeriodoPorsuPK)");
            }
            return obj;
        }
        //6.4
        public int IUperiodo(Session_Movi session, Periodo periodo, int intTipoOperacion, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            int codID = 0;
            try
            {
                codID = objDao.IUperiodo(session, periodo, intTipoOperacion, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUperiodo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PeriodoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (IUperiodo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PeriodoBL.cs: Exception");
                throw new Exception("Error General (IUperiodo)");
            }
            return codID;
        }
        //6.5
        public List<ValidacionesxLongitud> MaestroMaxCaracteres(string strMaestro)
        {
            List<ValidacionesxLongitud> lista = new List<ValidacionesxLongitud>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.MaestroMaxCaracteres(strMaestro);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[MaestroMaxCaracteres] => Respuesta del Procedimiento : " + strMsjDB);

                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PeriodoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (MaestroMaxCaracteres)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PeriodoBL.cs: Exception");
                throw new Exception("Error General (MaestroMaxCaracteres)");
            }
            return lista;
        }
    }

}
