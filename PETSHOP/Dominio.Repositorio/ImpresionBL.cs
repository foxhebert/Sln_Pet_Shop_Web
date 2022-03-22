using Dominio.Entidades;
using Dominio.Repositorio.Util;
using Infraestructura.Data.SqlServer;
using System;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Configuration;
using ExcelDataReader;


namespace Dominio.Repositorio
{
    public class ImpresionBL
    {
        private ImpresionDAO objDao = new ImpresionDAO();

        //private ImportarExcelDAO objDao = new ImportarExcelDAO();
        //private UsuarioDAO objUsuario = new UsuarioDAO();


        #region IMPRESION ETIQUETAS

        /*================================================================================= 
        * 14.1 de ListarConsumo
        * =================================================================================*/
        public List<TablaTbBienes> ListarTbBienesEtiquetas(Session_Movi objSession, int Local, int Area, int Oficina, string codOficina, int Responsable, int TipoBien, string ActivoSerie,
               int NumColumnEtiquet, int CantEtiquetsImp, string AnioInventario, string Impresora, ref string strMsjUsuario)//Session_Movi objSession, string strExcelExportado, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string nombreDelSp
        {
            List<TablaTbBienes> lista = new List<TablaTbBienes>();
            string nombreDelSp = "";
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarTbBienesEtiquetas(objSession, Local, Area, Oficina, codOficina, Responsable, TipoBien, ActivoSerie,
                                   NumColumnEtiquet, CantEtiquetsImp, AnioInventario, Impresora,
                                   ref intResult, ref strMsjDB, ref strMsjUsuario, ref nombreDelSp);


                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarTbBienesEtiquetas] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImpresionBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarTbBienesEtiquetas)");
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232015)
                {
                    Exception ex_null = new Exception("---> Error generado en el SP: " + nombreDelSp);
                    Log.AlmacenarLogError(ex, "ImpresionBL.cs: Exception" + " ( " + ex_null + " )");
                    throw new Exception("Error General (ListarTbBienesEtiquetas)");

                }
                else
                {
                    Log.AlmacenarLogError(ex, "ImpresionBL.cs: Exception");
                    throw new Exception("Error General (ListarTbBienesEtiquetas)");

                }
            }
            return lista;
        }

        /*================================================================================= 
        * 14.2
        * =================================================================================*/
        public List<TablasEnCombos> ListarTablasEnCombos(Session_Movi objSession, string strNomTablaEntidad, ref string strMsjUsuario)
        {
            List<TablasEnCombos> lista = new List<TablasEnCombos>();
            string nombreDelSp = "";
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarTablasEnCombos(objSession, strNomTablaEntidad, ref intResult, ref strMsjDB, ref strMsjUsuario, ref nombreDelSp);


                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarTablasEnCombos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImpresionBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarTablasEnCombos)");
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232015)
                {
                    Exception ex_null = new Exception("---> Error generado en el SP: " + nombreDelSp);
                    Log.AlmacenarLogError(ex, "ImpresionBL.cs: Exception" + " ( " + ex_null + " )");
                    throw new Exception("Error General (ListarTablasEnCombos)");

                }
                else
                {
                    Log.AlmacenarLogError(ex, "ImpresionBL.cs: Exception");
                    throw new Exception("Error General (ListarTablasEnCombos)");

                }
            }
            return lista;
        }



        /*================================================================================= 
         * 14.3
         * =================================================================================*/
        public string ObtenerAnioServer(ref string anioDelServ, ref string strMsjUsuario)
        {            
            //string anioDelServ = "";

            anioDelServ = DateTime.Now.Year.ToString();// DateTime.Now.Date.ToString();

            return anioDelServ;
        }

        
        /*================================================================================= 
        * 14.6
        * =================================================================================*/
        public List<TablasEnCombos> GetRutaFormatoFromTbBienesById(Session_Movi objSession, int intIdFormato, string strNomTablaEntidad, ref string strMsjUsuario)
        {
            List<TablasEnCombos> lista = new List<TablasEnCombos>();
            string nombreDelSp = "";
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.GetRutaFormatoFromTbBienesById(objSession, intIdFormato, strNomTablaEntidad, ref intResult, ref strMsjDB, ref strMsjUsuario, ref nombreDelSp);


                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[GetRutaFormatoFromTbBienesById] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImpresionBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (GetRutaFormatoFromTbBienesById)");
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232015)
                {
                    Exception ex_null = new Exception("---> Error generado en el SP: " + nombreDelSp);
                    Log.AlmacenarLogError(ex, "ImpresionBL.cs: Exception" + " ( " + ex_null + " )");
                    throw new Exception("Error General (GetRutaFormatoFromTbBienesById)");

                }
                else
                {
                    Log.AlmacenarLogError(ex, "ImpresionBL.cs: Exception");
                    throw new Exception("Error General (GetRutaFormatoFromTbBienesById)");

                }
            }
            return lista;
        }


        #endregion




    }
}
