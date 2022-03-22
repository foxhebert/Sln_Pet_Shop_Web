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
    public class PLanillaBL

    {
        private PlanillaDAO objDao = new PlanillaDAO();
        public List<Planilla> ListarPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            List<Planilla> lista = new List<Planilla>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarPlanilla(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        //4.71 Corregir ListarPlanillas HG 16.04.21
                        Log.AlmacenarLogMensaje("[ListarPlanillas] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PlanillaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarPlanilla)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PlanillaBL.cs: Exception");
                throw new Exception("Error General (ListarPlanilla)");
            }
            return lista;
        }

        public bool InsertarPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, Planilla objDatos, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                int idUnid = objDao.InsertarPlanilla(intIdSesion, intIdMenu, intIdSoft, objDatos, intIdUsuario, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[InsertarPlanilla] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "PlanillaBL.cs");
            //    //4.70 Corregir InsertarPlanilla_IU01 por InsertarPlanilla HG 16.04.21
            //    throw new Exception("Ocurrió un error de Transacción (InsertarPlanilla)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PlanillaBL.cs: SqlException");
                //4.70 Corregir InsertarPlanilla_IU01 por InsertarPlanilla HG 16.04.21
                throw new Exception("Ocurrió un error en BD (InsertarPlanilla)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PlanillaBL.cs: Exception");
                //4.70 Corregir InsertarPlanilla_IU01 por InsertarPlanilla HG 16.04.21
                throw new Exception("Error General (InsertarPlanilla)");
            }
        }

        public bool EliminmarPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int IdPlanilla, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objDao.EliminmarPlanilla(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, IdPlanilla, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminmarPlanilla] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PlanillaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminmarPlanilla)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PlanillaBL.cs: Exception");
                throw new Exception("Error General (EliminmarPlanilla)");
            }
        }

        public List<Planilla> ObtenerValidacionesPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<Planilla> lista = new List<Planilla>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerValidacionesPlanilla(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerValidacionesPlanilla] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PlanillaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerValidacionesPlanilla)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PlanillaBL.cs: Exception");
                throw new Exception("Error General (ObtenerValidacionesPlanilla)");
            }
            return lista;
        }

        public List<CamposAdicionales2> ListarCamposAdicionalesPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<CamposAdicionales2> lista = new List<CamposAdicionales2>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCamposAdicionalesPlanilla(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCamposAdicionalesPlanilla] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PlanillaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCamposAdicionalesPlanilla)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PlanillaBL.cs: Exception");
                throw new Exception("Error General (ListarCamposAdicionalesPlanilla)");
            }
            return lista;
        }

        public bool ActualizarPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, Planilla objDatos, int intIdUsuario, ref string strMsjUsuario)
        {

            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

              //  using (TransactionScope scope = new TransactionScope())
              //  {
                    tudobem = objDao.ActualizarPlanilla(intIdSesion, intIdMenu, intIdSoft, objDatos, intIdUsuario, ref intResult, ref strMsjDB, ref strMsjUsuario);

                 //  scope.Complete();
             //   }

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ActualizarPlanilla] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "PlanillaBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (ActualizarPlanilla)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PlanillaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ActualizarPlanilla)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PlanillaBL.cs: Exception");
                throw new Exception("Error General (ActualizarPlanilla)");
            }
        }


        public List<Planilla> ConsultarDetallePlanillaxCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPlanilla,ref string strMsjUsuario)
        {
            List<Planilla> lista = new List<Planilla>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";
               
                lista = objDao.ConsultarDetallePlanillaxCod(intIdSesion, intIdMenu, intIdSoft, intIdPlanilla, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ConsultarDetallePlanillaxCod] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PlanillaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ConsultarDetallePlanillaxCod)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PlanillaBL.cs: Exception");
                throw new Exception("Error General (ConsultarDetallePlanillaxCod)");
            }
            return lista;
        }
    }
}
