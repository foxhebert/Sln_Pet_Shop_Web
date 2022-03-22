using Dominio.Entidades;
using Dominio.Repositorio.Util;
using Infraestructura.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using BIXOLON_SamplePg;
using System.Data;

namespace Dominio.Repositorio
{
    public class ImprimirBL
    {
        private ConsumoDAO objDao = new ConsumoDAO();

        //8.1
        public bool ImpresionTicket(Session_Movi objSession, int intId, int tipo, List<Consumo> listaConsumoSelects, ref string strMsjUsuario)
        {
            bool rpta = false;
            List<Imprimir> datosPrint = new List<Imprimir>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                if (tipo == 1) //Atiende todos los consumos del modal por idconsumo del mismo idAsistencia
                {
                    DataTable tbList = SerealizeList(listaConsumoSelects);

                    datosPrint = objDao.DatosImpresion(objSession, intId, tipo, tbList, ref intResult, ref strMsjDB, ref strMsjUsuario);
                    if (datosPrint.Count > 0)
                        if (BixolonPrint(datosPrint))
                        {
                            strMsjDB = "Se imprimió correctamente";
                            rpta = true;
                        }
                        else
                            strMsjDB = "No se pudo realizar la impresión";
                }
                if (tipo == 0) //Atiende todos los consumos del listado principal de diferentes idAsistencia (lista de idasistencias)
                {
                    DataTable tbList_ = SerealizeList(listaConsumoSelects);
                    tbList_.Clear();
                    int contadorRpta = 0;
                    int totalfilas = listaConsumoSelects.Count();
                    for (int i = 0; i < listaConsumoSelects.Count(); i++)
                    {
                        intId = listaConsumoSelects[i].intIdConsumo;

                        datosPrint = objDao.DatosImpresion(objSession, intId, tipo, tbList_, ref intResult, ref strMsjDB, ref strMsjUsuario);
                        if (datosPrint.Count > 0)
                            if (BixolonPrint(datosPrint))
                            {
                                contadorRpta= contadorRpta + 1;
                             }
                     }

                    if (contadorRpta > 0)
                    {
                        strMsjDB = "Se imprimió correctamente";
                        rpta = true;
                    }
                    else
                        strMsjDB = "No se pudo realizar la impresión";
                }
                if (tipo == 2) //Atiende todos de un idasistencia
                {
                    DataTable tbList = SerealizeList(listaConsumoSelects);
                    tbList.Clear();
                    datosPrint = objDao.DatosImpresion(objSession, intId, tipo, tbList, ref intResult, ref strMsjDB, ref strMsjUsuario);
                    if (datosPrint.Count > 0)
                        if (BixolonPrint(datosPrint))
                        {
                            strMsjDB = "Se imprimió correctamente";
                            rpta = true;
                        }
                        else
                            strMsjDB = "No se pudo realizar la impresión";
                }

                if (rpta == false)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ImprimirTicket] => Respuesta del método : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImprimirBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ImpresionTicket)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImprimirBL.cs: Exception");
                throw new Exception("Error General (ImpresionTicket)");
            }
            return rpta;//pendiente cambiar el tipo de dato de salida.
        }
        //8.2
        private bool BixolonPrint(List<Imprimir> datos)
        {
            bool ok = false;
            try
            {
                string IP = ConfigurationManager.AppSettings["IPPrinter"];
                int PUERTO = Convert.ToInt32(ConfigurationManager.AppSettings["PuertoPrinter"]);

                if (IP.Equals("") && PUERTO == 0)
                    throw new Exception("Falta configurar la dirección IP y puerto para la impresión de Tickets");

                //Microsoft Print to PDF

                //if (BXLAPI.PrinterOpen(BXLAPI.ILan, "Microsoft Print to PDF", PUERTO, 0, 0, 0) != BXLAPI.BXL_SUCCESS)
                if (BXLAPI.PrinterOpen(BXLAPI.ILan, IP, PUERTO, 0, 0, 0) != BXLAPI.BXL_SUCCESS)
                        throw new Exception("Conexión fallida [TCP/IP] para la impresión");

                //pruebas de impresion con datos en duro //INICIO
                string empresa = datos[0].empresa;//"Empresa Prueba";
                string comensal = datos[0].comensal;//"Empresa Prueba";
                string numdoc = datos[0].numdoc;//"Empresa Prueba";
                string tipdoc = datos[0].tipdoc;//"Empresa Prueba";
                string fecha = datos[0].fecha;//"Empresa Prueba";
                string tipServ = datos[0].tipServ;//"Empresa Prueba";
                //FIN

                BXLAPI.TransactionStart();
                BXLAPI.InitializePrinter();
                BXLAPI.SetCharacterSet(BXLAPI.BXL_CS_WPC1252);
                BXLAPI.SetInterChrSet(BXLAPI.BXL_ICS_USA);


                BXLAPI.PrintText("SISFOODWEB" + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_1WIDTH | BXLAPI.BXL_TS_1HEIGHT);
                BXLAPI.PrintText(empresa + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_1WIDTH | BXLAPI.BXL_TS_1HEIGHT);
                BXLAPI.PrintText("\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                //BXLAPI.PrintText(strTipoDocu, BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_1HEIGHT);
                //BXLAPI.PrintText(datos[0].ndocu + " ", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_1WIDTH | BXLAPI.BXL_TS_1HEIGHT);
                BXLAPI.PrintText(tipdoc, BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_1HEIGHT);
                BXLAPI.PrintText(numdoc + " ", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_1WIDTH | BXLAPI.BXL_TS_1HEIGHT);
                BXLAPI.PrintText("    FECHA: " + datos[0].fecha + "\n", BXLAPI.BXL_ALIGNMENT_RIGHT, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_1HEIGHT);

                BXLAPI.PrintText("\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                BXLAPI.PrintText(comensal + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);

                BXLAPI.PrintText("\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                BXLAPI.PrintText(tipServ + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_REVERSE, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);

                //BXLAPI.PrintText(datos[0].nomcli + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                //BXLAPI.PrintText(comentario + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_REVERSE, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                BXLAPI.PrintText(new string('=', 40) + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                BXLAPI.PrintText(" CANTIDAD |   PRECIO  \n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                //BXLAPI.PrintText(" CANTIDAD |   CÓDIGO  |\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                BXLAPI.PrintText(" SERVICIO \n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                //BXLAPI.PrintText(" D E S C R I P C I Ó N \n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                BXLAPI.PrintText(new string('=', 40) + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);

                for (int i = 0; i < datos.Count(); i++)
                {
                    if ((datos[i].cant % 1) == 0)
                        BXLAPI.PrintText(Convert.ToInt32(datos[i].cant) + "  ", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_BOLD, BXLAPI.BXL_TS_1HEIGHT);
                    else
                        BXLAPI.PrintText(datos[i].cant + "  ", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_BOLD, BXLAPI.BXL_TS_1HEIGHT);

                    //int vacias = (15 - datos[i].codf.Length);
                    int vacias = (15 - (datos[i].precio.Length+ datos[i].simbolo.Length));
                    if (vacias < 0)
                        vacias = 0;
                    BXLAPI.PrintText(" " + datos[i].simbolo + datos[i].precio + new string(' ', vacias) + " \n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_REVERSE | BXLAPI.BXL_FT_BOLD, BXLAPI.BXL_TS_1HEIGHT);
                    //BXLAPI.PrintText(" " + datos[i].codf + new string(' ', vacias) + " \n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_REVERSE | BXLAPI.BXL_FT_BOLD, BXLAPI.BXL_TS_1HEIGHT);
                    BXLAPI.PrintText(datos[i].descr + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);

                    //if (!datos[i].rollos.Equals(""))
                    //    BXLAPI.PrintText(datos[i].rollos + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);

                    BXLAPI.PrintText(new string('_', 40) + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                    BXLAPI.PrintText("\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                }

                BXLAPI.CutPaper();

                if (BXLAPI.TransactionEnd(true, 3000 /* 3 seconds */) != BXLAPI.BXL_SUCCESS)
                {
                    // failed to read a response from the printer after sending the print-data.                    
                    throw new Exception("TransactionEnd failed, No se pudo Imprimir la etiqueta");
                }
                ok = true;


            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImprimirBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (BixolonPrint)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImprimirBL.cs: Exception");
                throw new Exception("Error General (BixolonPrint)");
            }
            finally
            {
                BXLAPI.PrinterClose();
            }
            return ok;
        }

        //-- Métodos complementarios: -----------------------------------------------------------------------------------------------------------
        //8.3
        private static string Etiquetas_FormatearTexto(string Texto, int Tamaño)
        {
            string objRetVal = string.Empty;
            try
            {
                objRetVal = Texto.ToUpper().Trim();
                objRetVal = objRetVal.Replace("Á", "A");
                objRetVal = objRetVal.Replace("É", "E");
                objRetVal = objRetVal.Replace("Í", "I");
                objRetVal = objRetVal.Replace("Ó", "O");
                objRetVal = objRetVal.Replace("Ú", "U");
                objRetVal = objRetVal.Replace("Ñ", "N");
                objRetVal = objRetVal.PadRight(Tamaño, ' ');
                objRetVal = objRetVal.Substring(0, Tamaño).Trim();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRetVal;
        }
        //8.4
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
        //-------------------------------------------------------------------------------------------------------------

    }
}
