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
    public class MarcadorBL
    {
        private MarcadorDAO objDao = new MarcadorDAO();
        public List<Marcador> ListarMarcador(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, ref string strMsjUsuario)
        {
            List<Marcador> lista = new List<Marcador>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarMarcador(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarMarcador] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: SqlException");
                //4.51 Cambiar ListarPlanilla por ListarMarcador HG 16.04.21
                throw new Exception("Ocurrió un error en BD (ListarMarcador)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: Exception");
                //4.51 Cambiar ListarPlanilla por ListarMarcador HG 16.04.21
                throw new Exception("Error General (ListarMarcador)");
            }
            return lista;
        }

        public List<TGTipoEN> ListarCampoTipoFuncionalidad(long intIdSesion, int intIdMenu, int intIdSoft,  ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCampoTipoFuncionalidad(intIdSesion, intIdMenu, intIdSoft,  ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCampoTipoFuncionalidad] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCampoTipoFuncionalidad)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: Exception");
                throw new Exception("Error General (ListarCampoTipoFuncionalidad)");
            }
            return lista;
        }

        public List<TGTipoEN> ListarCampoTipoMarcador(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCampoTipoMarcador(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCampoTipoMarcador] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCampoTipoMarcador)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: Exception");
                throw new Exception("Error General (ListarCampoTipoMarcador)");
            }
            return lista;
        }

        public List<TGTipoEN> ListarCampoTipoComu(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCampoTipoComu(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCampoTipoComu] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCampoTipoComu)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: Exception");
                throw new Exception("Error General (ListarCampoTipoComu)");
            }
            return lista;
        }

        public bool InsertarMarcador(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, Marcador objDatos, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";

                int idUnid = objDao.InsertarMarcador(intIdSesion, intIdMenu, intIdSoft, objDatos, intIdUsuario, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[InsertarMarcador] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "MarcadorBL.cs");
            //    //4.53 Remover InsertarMarcador_IU01 y añadir InsertarMarcador HG 16.04.21
            //    throw new Exception("Ocurrió un error de Transacción (InsertarMarcador)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: SqlException");
                //4.53 Remover InsertarMarcador_IU01 y añadir InsertarMarcador HG 16.04.21
                throw new Exception("Ocurrió un error en BD (InsertarMarcador)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: Exception");
                //4.53 Remover InsertarMarcador_IU01 y añadir InsertarMarcador HG 16.04.21
                throw new Exception("Error General (InsertarMarcador)");
            }
        }

        public bool EliminmarMarcador(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdMarcador, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objDao.EliminmarMarcador(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdMarcador, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminmarMarcador] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs");
                throw new Exception("Ocurrió un error en BD (EliminmarMarcador)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs");
                throw new Exception("Error General (EliminmarMarcador)");
            }
        }

        public List<Marcador> ObtenerValidacionesMarcador(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<Marcador> lista = new List<Marcador>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerValidacionesMarcador(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerValidacionesMarcador] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs");
                throw new Exception("Ocurrió un error en BD (ObtenerValidacionesMarcador)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs");
                throw new Exception("Error General (ObtenerValidacionesMarcador)");
            }
            return lista;
        }

        public List<CamposAdicionales2> ListarCamposMarcadores(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<CamposAdicionales2> lista = new List<CamposAdicionales2>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCamposMarcadores(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCamposMarcadores] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCamposMarcadores)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: Exception");
                throw new Exception("Error General (ListarCamposMarcadores)");
            }
            return lista;
        }

        public bool ActualizarMarcador(long intIdSesion, int intIdMenu, int intIdSoft, Marcador objDatos, int intIdUsuario, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                    tudobem = objDao.ActualizarMarcador(intIdSesion, intIdMenu, intIdSoft, objDatos, intIdUsuario, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ActualizarMarcador] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "MarcadorBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (ActualizarMarcador)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ActualizarMarcador)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: Exception");
                throw new Exception("Error General (ActualizarMarcador)");
            }
        }


        public List<Marcador> ConsultarDetalleMarcadorxCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdMarcador,ref string strMsjUsuario)
        {
            List<Marcador> lista = new List<Marcador>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ConsultarDetalleMarcadorxCod(intIdSesion, intIdMenu, intIdSoft, intIdMarcador, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ConsultarDetalleMarcadorxCod] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ConsultarDetalleMarcadorxCod)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: Exception");
                throw new Exception("Error General (ConsultarDetalleMarcadorxCod)");
            }
            return lista;
        }



    }

}
