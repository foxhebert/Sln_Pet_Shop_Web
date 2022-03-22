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

using System.IO;
using System.Net;
using System.Net.Mail;

namespace Dominio.Repositorio
{
    public class ConsumoBL

    {
        private ConsumoDAO objConsumo = new ConsumoDAO();


        #region TOMA_DE_CONSUMO

        //5.75 -OBTENER TOMA DE CONSUMO    - web socket   
        public List<Consumo> ObtenerRegistroConsumo(Session_Movi objSession, int IntIdAsistencia, ref string strMsjUsuario)
        {
            List<Consumo> lista = new List<Consumo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objConsumo.ObtenerRegistroConsumo(objSession, IntIdAsistencia, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerRegistroConsumo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ConsumoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerRegistroConsumo)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ConsumoBL.cs: Exception");
                throw new Exception("Error General (ObtenerRegistroConsumo)");
            }
            return lista;
        }
        //5.76
        public bool RegistrarConsumo(Session_Movi objSession, int intTipoOperacion, Consumo objDatos, bool bitTodosTS, ref string strMsjUsuario, ref int intValida)
        {
            try
            {
                bool todookey = false;

                int intResult = 0;
                string strMsjDB = "";


                int idEmpresa = objConsumo.RegistrarConsumo(objSession, intTipoOperacion, objDatos, bitTodosTS, ref intResult, ref strMsjDB, ref strMsjUsuario, ref intValida);


                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[RegistrarConsumo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                else
                {

                    todookey = true;
                }


                return todookey;
            }
            //catch (TransactionAbortedException ex)
            //{
            //    Log.AlmacenarLogError(ex, "ConsumoBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (RegistrarConsumo)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ConsumoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (RegistrarConsumo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ConsumoBL.cs: Exception");
                throw new Exception("Error General (RegistrarConsumo)");
            }
        }
        //5.77
        public bool AnularServicioRegistrado(Session_Movi objSession, int intIdAsistencia, int intIdServicio, ref string strMsjUsuario, ref int intValida)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objConsumo.AnularServicioRegistrado(objSession, intIdAsistencia, intIdServicio, ref intResult, ref strMsjDB, ref strMsjUsuario, ref intValida);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminarConsumo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ConsumoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminarConsumo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ConsumoBL.cs: Exception");
                throw new Exception("Error General (EliminarConsumo)");
            }
        }
        //5.78
        public List<Consumo> ListarConsumo(Session_Movi objSession, ref string strMsjUsuario)
        {
            List<Consumo> lista = new List<Consumo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objConsumo.ListarConsumo(objSession, /*intActivo,*//* strDescripcion, *//*intTipoEmp,*/ ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarConsumo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ConsumoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarConsumo)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ConsumoBL.cs: Exception");
                throw new Exception("Error General (ListarConsumo)");
            }
            return lista;
        }
        //5.79
        public List<TGREGLANEG_SERV_DET> ListarReglaNegocioServicio(Session_Movi objSession, int intIdAsistencia, ref string strMsjUsuario)
        {
            List<TGREGLANEG_SERV_DET> lista = new List<TGREGLANEG_SERV_DET>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objConsumo.ListarReglaNegocioServicio(objSession, intIdAsistencia, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarReglaNegocioServicio] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ConsumoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarReglaNegocioServicio)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ConsumoBL.cs: Exception");
                throw new Exception("Error General (ListarReglaNegocioServicio)");
            }
            return lista;
        }
        //5.80
        public bool RegistrarComedorConDni(Session_Movi objSession, int intTipoOperacion, ComedorMarcaConDni objDatos, ref string strMsjUsuario)
        {

            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                // using (TransactionScope scope = new TransactionScope())
                //{
                int idEmpresa = objConsumo.RegistrarComedorConDni(objSession, objDatos, intTipoOperacion, ref intResult, ref strMsjDB, ref strMsjUsuario);

                //  scope.Complete();
                // }

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[RegistrarComedorConDni] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "ConsumoBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (RegistrarComedorConDni)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ConsumoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (RegistrarComedorConDni)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ConsumoBL.cs: Exception");
                throw new Exception("Error General (RegistrarComedorConDni)");
            }

        }
        
        //5.81
        public List<TGREGLANEG_SERV_DET> ListarServicioComplementario(Session_Movi objSession, int intIdAsistencia, ref string strMsjUsuario)
        {
            List<TGREGLANEG_SERV_DET> lista = new List<TGREGLANEG_SERV_DET>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objConsumo.ListarServicioComplementario(objSession, intIdAsistencia, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarServicioComplementario] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ConsumoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarServicioComplementario)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ConsumoBL.cs: Exception");
                throw new Exception("Error General (ListarServicioComplementario)");
            }
            return lista;
        }

        #endregion TOMA_DE_CONSUMO
    }
}
