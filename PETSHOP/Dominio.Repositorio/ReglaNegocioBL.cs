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
using System.Data;

namespace Dominio.Repositorio
{
    public class ReglaNegocioBL
    {

        private ReglaNegocioDAO objDao = new ReglaNegocioDAO();

         //2.54
        public List<ReglaNegocio> ListarReglaNegocio(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {

            List<ReglaNegocio> lista = new List<ReglaNegocio>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarReglaNegocio(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarReglaNegocio] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReglaNegocioBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarReglaNegocio)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReglaNegocioBL.cs: Exception");
                throw new Exception("Error General (ListarReglaNegocio)");
            }
            return lista;

        }
        //2.55
        public bool IUNegocio_T(long intIdSesion, int intIdMenu, int intIdSoft, ReglaNegocio objDatos, List<TGREGNEG_DET> listaReglaNegDet, List<TGREG_NEG_CONFIG_HORAS> listaReglaNegHEDet, int intTipoOperacion, int intIdUsuario, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 1;
                string strMsjDB = "";
                string Msj = "";

                intResult = objDao.IUNegocio_T(intIdSesion, intIdMenu, intIdSoft, objDatos, listaReglaNegDet, listaReglaNegHEDet, intTipoOperacion, intIdUsuario, ref intResult, ref strMsjDB, ref strMsjUsuario, ref Msj);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUNegocio_T] => Respuesta del Procedimiento : " + strMsjDB);
                        Log.AlmacenarLogMensaje("[IUNegocioCom_T] => Respuesta de la clase de Datos: " + Msj);
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
            //    Log.AlmacenarLogError(ex, "ReglaNegocioBL.cs: SqlException");
            //    throw new Exception("Ocurrió un error de Transacción (IUNegocio_T)");
            //}
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReglaNegocioBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (IUNegocio_T)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReglaNegocioBL.cs: Exception");
                throw new Exception("Error General (IUNegocio_T)");
            }
        }
        //2.56
        public bool EliminmarReglaNegocio(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdReglaNeg, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";
                bool tudobem = false;
                tudobem = objDao.EliminmarReglaNegocio(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdReglaNeg, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminmarReglaNegocio] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReglaNegocioBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminmarReglaNegocio)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReglaNegocioBL.cs: Exception");
                throw new Exception("Error General (EliminmarReglaNegocio)");
            }
        }
        //2.57
        public List<TGREGNEG_DET> ObtenerRegistroReglaNedocio(long intIdSesion, int intIdMenu, int intIdSoft, int intIdReglaNeg, ref string strMsjUsuario)
        {
            List<TGREGNEG_DET> lista = new List<TGREGNEG_DET>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerRegistroReglaNedocio(intIdSesion, intIdMenu, intIdSoft, intIdReglaNeg, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerRegistroReglaNedocio] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReglaNegocioBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerRegistroReglaNedocio)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReglaNegocioBL.cs: Exception");
                throw new Exception("Error General (ObtenerRegistroReglaNedocio)");
            }
            return lista;
        }
        //2.58
        public List<TGREG_NEG_CONFIG_HORAS> ObtenerRegistroReglaDetalleDeNedocioHE(long intIdSesion, int intIdMenu, int intIdSoft, int intIdReglaNeg, ref string strMsjUsuario)
        {
            List<TGREG_NEG_CONFIG_HORAS> lista = new List<TGREG_NEG_CONFIG_HORAS>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerRegistroReglaDetalleDeNedocioHE(intIdSesion, intIdMenu, intIdSoft, intIdReglaNeg, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerRegistroReglaDetalleDeNedocioHE] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReglaNegocioBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerRegistroReglaDetalleDeNedocioHE)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReglaNegocioBL.cs: Exception");
                throw new Exception("Error General (ObtenerRegistroReglaDetalleDeNedocioHE)");
            }
            return lista;
        }

    }
}