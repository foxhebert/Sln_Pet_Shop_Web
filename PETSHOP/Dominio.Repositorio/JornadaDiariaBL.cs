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
    public class JornadaDiariaBL
    {

        private JornadaDiariaDAO objDao = new JornadaDiariaDAO();
        //2.15
        public List<JornadaxHorario> ListarJornadaHorario(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            List<JornadaxHorario> lista = new List<JornadaxHorario>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarJornadaHorario(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarJornada] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarJornada)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaBL.cs: Exception");
                throw new Exception("Error General (ListarJornada)");
            }
            return lista;
        }
        //2.61
        public List<JornadaData> ListarJornada(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, int filtroTipoServ, ref string strMsjUsuario)
        {
            List<JornadaData> lista = new List<JornadaData>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarJornada(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, filtroTipoServ, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarJornada] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarJornada)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaBL.cs: Exception");
                throw new Exception("Error General (ListarJornada)");
            }
            return lista;
        }
        //2.62
        public bool EliminmarJornada(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdJornada, ref string strMsjUsuario)
        {

            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objDao.EliminmarJornada(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdJornada, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminmarJornada] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminmarJornada)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaBL.cs: Exception");
                throw new Exception("Error General (EliminmarJornada)");
            }
        }
        //2.63
        public bool IUJornada_T(long intIdSesion, int intIdMenu, int intIdSoft, int intTipoOperacion, Jornada objDatos, List<Intervalos> listaIntervalos, int intIdUsuario, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";
                string Msj = "";

                intResult = objDao.IUJornada_T(intIdSesion, intIdMenu, intIdSoft, intTipoOperacion, objDatos, listaIntervalos, intIdUsuario, ref intResult, ref strMsjDB, ref strMsjUsuario, ref Msj);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUJornada_T] => Respuesta del Procedimiento : " + strMsjDB);
                        Log.AlmacenarLogMensaje("[IUJornada_T] => Respuesta del Procedimiento : " + Msj);
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
            //    Log.AlmacenarLogError(ex, "JornadaDiariaBL.cs: SqlException");
            //    throw new Exception("Ocurrió un error de Transacción (IUJornada_T)");
            //}
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (IUJornada_T)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaBL.cs: Exception");
                throw new Exception("Error General (IUJornada_T)");
            }
        }
        //2.64
        public List<Jornada> ObtenerJornadaPorsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int intIdJornada, ref string strMsjUsuario)
        {
            List<Jornada> lista = new List<Jornada>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerJornadaPorsuPK(intIdSesion, intIdMenu, intIdSoft, intIdJornada, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerJornadaPorsuPK] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerJornadaPorsuPK)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaBL.cs: Exception");
                throw new Exception("Error General (ObtenerJornadaPorsuPK)");
            }
            return lista;
        }
        //2.65
        public List<Intervalos> ListarIntervalos(long intIdSesion, int intIdMenu, int intIdSoft, int intfiltrojer, ref string strMsjUsuario)
        {
            List<Intervalos> lista = new List<Intervalos>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarIntervalos(intIdSesion, intIdMenu, intIdSoft, intfiltrojer, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarIntervalos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarIntervalos)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaBL.cs: Exception");
                throw new Exception("Error General (ListarIntervalos)");
            }
            return lista;
        }


    }
}
