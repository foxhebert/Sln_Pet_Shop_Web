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
    public class GestionConsumoBL

    {
        private GestionConsumoDAO objGestionConsumo = new GestionConsumoDAO();

        //private GestionConsumoDAO objReglaNegocioServicio = new GestionConsumoDAO();


        #region GESTION_DE_CONSUMOS
        //5.83
        public List<Consumo> ListarGestionConsumo(Session_Movi objSession, string dttFiltroFchI, string dttFiltroFchF, string strDescripcion, int intConsumido, int intTipoServ, int intTipoMenu, int IntIdEmp, int intIdMarcador, ref string strMsjUsuario)
        {
            List<Consumo> lista = new List<Consumo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objGestionConsumo.ListarGestionConsumo(objSession, dttFiltroFchI, dttFiltroFchF, strDescripcion, intConsumido, intTipoServ, intTipoMenu, IntIdEmp, intIdMarcador, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarGestionConsumo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GestionConsumoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarGestionConsumo)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GestionConsumoBL.cs: Exception");
                throw new Exception("Error General (ListarGestionConsumo)");
            }
            return lista;
        }
        //5.84
        public bool UpdateGestionConsumo(Session_Movi objSession, int intTipoOperacion, Consumo objDatos, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";


                int idConsumo = objGestionConsumo.UpdateGestionConsumo(objSession, intTipoOperacion, objDatos, ref intResult, ref strMsjDB, ref strMsjUsuario);


                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[UpdateGestionConsumo] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "GestionConsumoBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (ActualizarConsumo)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GestionConsumoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (UpdateGestionConsumo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GestionConsumoBL.cs: Exception");
                throw new Exception("Error General (UpdateGestionConsumo)");
            }
        }
        //5.85
        public bool UpdateGestionMasivoConsumo(Session_Movi objSession, int intTipoOperacion,/* DataTable tb,*/  List<int> listPersonal, /*Consumo objDatos,*/ ref string strMsjUsuario)
        {

            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                DataTable tb = SerealizeDetalleEmpleado(listPersonal);

                int idConsumo = objGestionConsumo.UpdateGestionMasivoConsumo(objSession, intTipoOperacion, tb, /*objDatos,*/ ref intResult, ref strMsjDB, ref strMsjUsuario);


                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[UpdateGestionMasivoConsumo] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "GestionMasivoConsumoBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (ActualizarGestionMasivoConsumo)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GestionConsumoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (UpdateGestionMasivoConsumo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GestionConsumoBL.cs: Exception");
                throw new Exception("Error General (UpdateGestionMasivoConsumo)");
            }
        }
        //5.86
        public List<Consumo> ListarConsumosXid(Session_Movi objSession, int intId, ref string strMsjUsuario)
        {
            List<Consumo> lista = new List<Consumo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objGestionConsumo.ListarConsumosXid(objSession, intId, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarConsumosXid] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GestionConsumoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarConsumosXid)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GestionConsumoBL.cs: Exception");
                throw new Exception("Error General (ListarConsumosXid)");
            }
            return lista;
        }
        //5.87
        public bool UpdateGC(Session_Movi objSession, int intTipoOperacion, List<Consumo> listaConsumoSelects, int bitFlConsumido, int evento, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                DataTable tbList = SerealizeList(listaConsumoSelects);

                tudobem = objGestionConsumo.UpdateGC(objSession, intTipoOperacion, tbList, bitFlConsumido, evento, ref intResult, ref strMsjDB, ref strMsjUsuario);


                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[UpdateGC] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "GestionConsumoBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (ActualizarConsumo)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GestionConsumoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (UpdateGC)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GestionConsumoBL.cs: Exception");
                throw new Exception("Error General (UpdateGC)");
            }
        }
        //5.88
        private DataTable SerealizeDetalleEmpleado(List<int> listaEmpleado)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdConsumo", typeof(int));

            foreach (var item in listaEmpleado)
            {
                DataRow rows = table.NewRow();
                rows["intIdConsumo"] = item;
                table.Rows.Add(rows);
            }

            return table;
        }
        //5.89
        private DataTable SerealizeList(List<Consumo> lista)
        {
            DataTable table = new DataTable();

            table.Columns.Add("intIdConsumo", typeof(int));
            table.Columns.Add("bitFlConsumido", typeof(int));
            table.Columns.Add("intCantidad", typeof(int));

            foreach (var item in lista)
            {
                DataRow rows = table.NewRow();
                rows["intIdConsumo"] = item.intIdConsumo;
                rows["bitFlConsumido"] = item.bitFlConsumido;
                rows["intCantidad"] = item.intCantidad;

                table.Rows.Add(rows);
            }

            return table;
        }

        #endregion GESTION_DE_CONSUMOS
    }
}
