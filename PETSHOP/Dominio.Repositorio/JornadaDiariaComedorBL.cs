//Jueves
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
    public class JornadaDiariaComedorBL
    {

        private JornadaDiariaComedorDAO objDao = new JornadaDiariaComedorDAO();
        //2.47
        public List<Jornada> ListarJornadaComedor(Session_Movi objSession, int intActivoFilter, string strfilter, int intfiltrojer, int intfiltrojer2, ref string strMsjUsuario)
        {
            List<Jornada> lista = new List<Jornada>();
            try
            {
                int intResult = 0;
                string strMsjDB = "COM";

                lista = objDao.ListarJornadaComedor(objSession, intActivoFilter, strfilter, intfiltrojer, intfiltrojer2, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarJornadaCom] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaComedorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarJornadaCom)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaComedorBL.cs: Exception");
                throw new Exception("Error General (ListarJornadaCom)");
            }
            return lista;
        }
        //2.48
        public List<JornadaxHorario> ListarJornadaComHor(Session_Movi objSession, int intActivoFilter, string strfilter, int intfiltrojer, int intfiltrojer2, ref string strMsjUsuario)
        {
            List<JornadaxHorario> lista = new List<JornadaxHorario>();
            try
            {
                int intResult = 0;
                string strMsjDB = "XCOM";

                lista = objDao.ListarJornadaHorarioCom(objSession, intActivoFilter, strfilter, intfiltrojer, intfiltrojer2, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarJornadaCom] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaComedorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarJornadaCom)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaComedorBL.cs: Exception");
                throw new Exception("Error General (ListarJornadaCom)");
            }
            return lista;
        }
        //2.49
        public bool EliminmarJornadaComedor(Session_Movi objSession, int intIdJornada, ref string strMsjUsuario)
        {

            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objDao.EliminmarJornadaComedorDao(objSession, intIdJornada, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminmarJornadaComedor] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaComedorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminmarJornada)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaComedorBL.cs: Exception");
                throw new Exception("Error General (EliminmarJornada)");
            }
        }
        //2.50
        public bool IUJornadaDiariaComedor_T(Session_Movi objSession, int intTipoOperacion, Jornada objDatos, List<Intervalos> listaIntervalos, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";
                string Msj = "";

                intResult = objDao.IUJornadaDiariaComedor_T(objSession, intTipoOperacion, objDatos, listaIntervalos, ref intResult, ref strMsjDB, ref strMsjUsuario, ref Msj);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUJornadaDiariaComedor_T] => Respuesta del Procedimiento : " + strMsjDB);
                        Log.AlmacenarLogMensaje("[IUJornadaDiariaComedor_T] => Respuesta del Procedimiento : " + Msj);
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
            //    Log.AlmacenarLogError(ex, "JornadaDiariaComedorBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (IUJornadaDiariaComedor_T)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaComedorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (IUJornadaDiariaComedor_T)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaComedorBL.cs: Exception");
                throw new Exception("Error General (IUJornadaDiariaComedor_T)");
            }
        }
        //2.51
        public List<Jornada> ObtenerJornadaComedorPorsuPK(Session_Movi objSession, int intIdJornada, ref string strMsjUsuario)
        {
            List<Jornada> lista = new List<Jornada>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerJornadaComedorPorsuPK(objSession, intIdJornada, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerJornadaComedorPorsuPK] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaComedorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerJornadaComedorPorsuPK)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaComedorBL.cs: Exception");
                throw new Exception("Error General (ObtenerJornadaCOmedorPorsuPK)");
            }
            return lista;
        }
        //2.52
        public List<Intervalos> ListarIntervalosComedor(Session_Movi objSession, int intfiltrojer, ref string strMsjUsuario)
        {
            List<Intervalos> lista = new List<Intervalos>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarIntervalosComedor(objSession, intfiltrojer, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarIntervalosComedor] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaComedorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarIntervalosComedor)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "JornadaDiariaComedorBL.cs: Exception");
                throw new Exception("Error General (ListarIntervalosComedor)");
            }
            return lista;
        }


    }
}
