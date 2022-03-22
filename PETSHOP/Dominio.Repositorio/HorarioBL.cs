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
    public class HorarioBL
    {
        private HorarioDAO objDao = new HorarioDAO();
        //2.10
        public List<HorarioData> ListarHorario(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            List<HorarioData> lista = new List<HorarioData>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarHorario(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarHorario] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "HorarioBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarHorario)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "HorarioBL.cs: Exception");
                throw new Exception("Error General (ListarHorario)");
            }
            return lista;
        }
        //2.11
        public bool IUHorario_T(long intIdSesion, int intIdMenu, int intIdSoft, Horario objDatos, List<HorJor> listaHorariosJor, int intIdUsuario, int intTipoOperacion, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";
                string Msj = "";

                intResult = objDao.IUHorario_T(intIdSesion, intIdMenu, intIdSoft, objDatos, listaHorariosJor, intIdUsuario, intTipoOperacion, ref intResult, ref strMsjDB, ref strMsjUsuario, ref Msj);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUHorario_T] => Respuesta del Procedimiento : " + strMsjDB);
                        Log.AlmacenarLogMensaje("[IUHorario_T] => Respuesta del Procedimiento : " + Msj);
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
            //    Log.AlmacenarLogError(ex, "HorarioBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (IUHorario)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "HorarioBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (IUHorario_T)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "HorarioBL.cs: Exception");
                throw new Exception("Error General (IUHorario_T)");
            }
        }
        //2.12
        public bool EliminmarHorario(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdHorario, ref string strMsjUsuario)
        {

            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objDao.EliminmarHorario(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdHorario, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminmarHorario] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "HorarioBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminmarHorario)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "HorarioBL.cs: Exception");
                throw new Exception("Error General (EliminmarHorario)");
            }
        }
        //2.13
        public List<Horario> ObtenerHorarioPorsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int intIdHorario, ref string strMsjUsuario)
        {
            List<Horario> lista = new List<Horario>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerHorarioPorsuPK(intIdSesion, intIdMenu, intIdSoft, intIdHorario, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerHorarioPorsuPK] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "HorarioBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerHorarioPorsuPK)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "HorarioBL.cs: Exception");
                throw new Exception("Error General (ObtenerHorarioPorsuPK)");
            }
            return lista;
        }
        //2.14
        public List<HorJor> ObtenerHORXJORPorsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int intIdHorario, ref string strMsjUsuario)
        {
            List<HorJor> lista = new List<HorJor>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerHORXJORPorsuPK(intIdSesion, intIdMenu, intIdSoft, intIdHorario, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerHORXJORPorsuPK] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "HorarioBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerHORXJORPorsuPK)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "HorarioBL.cs: Exception");
                throw new Exception("Error General (ObtenerHORXJORPorsuPK)");
            }
            return lista;


        }


    }
}
