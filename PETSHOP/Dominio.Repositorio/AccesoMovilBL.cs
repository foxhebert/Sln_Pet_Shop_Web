using Dominio.Entidades;
using Dominio.Repositorio.Util;
using Infraestructura.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public class AccesoMovilBL
    {

        private AccesoMovilDAO objDao = new AccesoMovilDAO();

        #region MOVIL INVENTARIOWEB

        //40.1 LISTA LA TABLA TMPRODU(Dos Campos) PARA EL MOVIL
        public List<TMPRODU_MOVIL> ListarTablaTmProdu(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, string strTerminal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TMPRODU_MOVIL> lista = new List<TMPRODU_MOVIL>();
            string nombreDelSp = "";
            try
            {
                //lista = objDao.ListarMarcasAcceso(strTerminal, strFotocheck, strFecha);
                lista = objDao.ListarTablaTmProdu(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, strTerminal, ref intResult, ref strMsjDB, ref strMsjUsuario, ref nombreDelSp);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarTablaTmProdu] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarTablaTmProdu)");
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232015)
                {
                    Exception ex_null = new Exception("---> Error generado en el SP: " + nombreDelSp);
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception" + " ( " + ex_null + " )");
                    throw new Exception("Error General (ListarTablaTmProdu)");
                }
                else
                {
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception");
                    throw new Exception("Error General (ListarTablaTmProdu)");

                }
            }

            return lista;
        }

        //40.2 LISTA LA TABLA TMPRODU HASTA EL MOVIL CON PARAMETRO
        public List<TMPRODU_MOVIL> ListarTablaTmProduII(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, string strTerminal, string strCoProdu, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TMPRODU_MOVIL> lista = new List<TMPRODU_MOVIL>();
            string nombreDelSp = "";
            try
            {
                //lista = objDao.ListarMarcasAcceso(strTerminal, strFotocheck, strFecha);
                lista = objDao.ListarTablaTmProduII(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, strTerminal,strCoProdu, ref intResult, ref strMsjDB, ref strMsjUsuario, ref nombreDelSp);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarTablaTmProdu] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarTablaTmProdu)");
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232015)
                {
                    Exception ex_null = new Exception("---> Error generado en el SP: " + nombreDelSp);
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception" + " ( " + ex_null + " )");
                    throw new Exception("Error General (ListarTablaTmProdu)");
                }
                else
                {
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception");
                    throw new Exception("Error General (ListarTablaTmProdu)");

                }
            }

            return lista;
        }

        //40.3 INSERTAR/ACTUALIZAR TMINVENTARIO DESDE MOVIL
        //public bool InsertarActualizarTmInventarioMovil(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        public bool InsertarActualizarTmInventarioMovil(
            int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, 
            int id, string nvcNoAlmac, string nvcNoUbica, string nvcCoCampoAux, string nvcCoProdu, int intNuRegis, string intNuTermi,
            string dttFeRegis, int intFLNuevo, int intFLRepetido, string deleted_at, string created_at, string updated_at,
            ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                ////int intResult = 0;
                ////string strMsjDB = "";
                //DataTable tbList = SerealizeList(tblistaBienes);
                //tudobem = objDao.InsertarActualizarTmInventarioMovil(intIdSesion, intIdMenu, intIdSoft, intIdUsuario,  ref intResult, ref strMsjDB, ref strMsjUsuario);

                tudobem = objDao.InsertarActualizarTmInventarioMovil(
                       intIdSesion, intIdMenu, intIdSoft, intIdUsuario, id, nvcNoAlmac, nvcNoUbica, nvcCoCampoAux, nvcCoProdu, intNuRegis, intNuTermi,
                       dttFeRegis, intFLNuevo, intFLRepetido, deleted_at, created_at, updated_at, ref intResult, ref strMsjDB, ref strMsjUsuario);



                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[InsertarActualizarTmInventarioMovil] => Respuesta del Procedimiento : " + strMsjDB);
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
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (InsertarActualizarTmInventarioMovil)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception");
                throw new Exception("Error General (InsertarActualizarTmInventarioMovil)");
            }
        }

        #endregion

        #region Movil To BD

        //15.1 -- Desde UpdateGC(5.87)
        //public bool ObtenerBienesInventariados(Session_Movi objSession, int intTipoOperacion, List<Consumo> listaConsumoSelects, int bitFlConsumido, int evento, ref string strMsjUsuario)
        public bool ObtenerBienesInventariados(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, List<TbBienesMovToBD> tblistaBienes, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;

                ////int intResult = 0;
                ////string strMsjDB = "";

                DataTable tbList = SerealizeList(tblistaBienes);

                tudobem = objDao.ObtenerBienesInventariados( intIdSesion, intIdMenu, intIdSoft,  intIdUsuario, tbList, ref intResult, ref strMsjDB, ref strMsjUsuario);
                //tudobem = objDao.ObtenerBienesInventariados(objSession, intTipoOperacion, tbList, bitFlConsumido, evento, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerBienesInventariados] => Respuesta del Procedimiento : " + strMsjDB);
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
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerBienesInventariados)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception");
                throw new Exception("Error General (ObtenerBienesInventariados)");
            }
        }

        //15.1.1
        //private DataTable SerealizeList(List<Consumo> lista)
        private DataTable SerealizeList(List<TbBienesMovToBD> lista)
        {
            DataTable table = new DataTable();
            
            table.Columns.Add("intIdActivo", typeof(int));
            table.Columns.Add("strDescripcion", typeof(string));
            table.Columns.Add("strCodActivo", typeof(string)); //nvarchar
            table.Columns.Add("intIdLocal", typeof(int));//int
            table.Columns.Add("intIdArea", typeof(int));//int
            table.Columns.Add("intIdOficina", typeof(string));//int
            table.Columns.Add("strCodAnterior", typeof(string));//nvarchar
            table.Columns.Add("intIdResponsable", typeof(int));//int
            table.Columns.Add("intIdEstado", typeof(int));//int
            table.Columns.Add("strDescMarca", typeof(string));//nvarchar
            table.Columns.Add("strDescModelo", typeof(string));//nvarchar
            table.Columns.Add("intIdTipo", typeof(int));//int
            table.Columns.Add("strDescColor", typeof(string));//nvarchar
            table.Columns.Add("strDescSerie", typeof(string));//nvarchar
            table.Columns.Add("strDescNumMotor", typeof(string));//nvarchar
            table.Columns.Add("strDescNumChasis", typeof(string));//nvarchar
            table.Columns.Add("intAnio", typeof(int));//int
            table.Columns.Add("strDescDimension", typeof(string));//nvarchar
            table.Columns.Add("strDescPlaca", typeof(string));//nvarchar
            table.Columns.Add("strDescObservacion", typeof(string));//nvarchar
            table.Columns.Add("strFlag", typeof(string));//nvarchar 1
            table.Columns.Add("strPda", typeof(string));//nvarchar 2
            table.Columns.Add("dttFeCrea", typeof(DateTime));//datetime
            table.Columns.Add("dttFeModi", typeof(DateTime));//datetime
            table.Columns.Add("strEtiqueta", typeof(string));//nvarchar 10

            //table.Columns.Add("intIdConsumo", typeof(int));
            //table.Columns.Add("bitFlConsumido", typeof(int));
            //table.Columns.Add("intCantidad", typeof(int));

            foreach (var item in lista)
            {
                DataRow rows = table.NewRow();
               rows["intIdActivo"] = item.intIdActivo; 
               rows["strDescripcion"] = item.strDescripcion;
               rows["strCodActivo"] = item.strCodActivo;
               rows["intIdLocal"] = item.intIdLocal;
               rows["intIdArea"] = item.intIdArea;
               rows["intIdOficina"] = item.intIdOficina;
               rows["strCodAnterior"] = item.strCodAnterior;
               rows["intIdResponsable"] = item.intIdResponsable;
               rows["intIdEstado"] = item.intIdEstado;
               rows["strDescMarca"] = item.strDescMarca;
               rows["strDescModelo"] = item.strDescModelo;
               rows["intIdTipo"] = item.intIdTipo;
               rows["strDescColor"] = item.strDescColor;
               rows["strDescSerie"] = item.strDescSerie;
               rows["strDescNumMotor"] = item.strDescNumMotor;
               rows["strDescNumChasis"] = item.strDescNumChasis;
               rows["intAnio"] = item.intAnio;
               rows["strDescDimension"] = item.strDescDimension;
               rows["strDescPlaca"] = item.strDescPlaca;
               rows["strDescObservacion"] = item.strDescObservacion;
               rows["strFlag"] = item.strFlag;
               rows["strPda"] = item.strPda;
               rows["dttFeCrea"] = item.dttFeCrea;
               rows["dttFeModi"] = item.dttFeModi;
               rows["strEtiqueta"] = item.strEtiqueta;

                //rows["intIdConsumo"] = item.intIdConsumo;
                //rows["bitFlConsumido"] = item.bitFlConsumido;
                //rows["intCantidad"] = item.intCantidad;

                table.Rows.Add(rows);
            }

            return table;
        }

        #endregion




        //13.1 TBBIENES --->ListarMarcasAcceso
        public List<TbBienesMov> ListarTablaTbBienes(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, string strTerminal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {           
            List<TbBienesMov> lista = new List<TbBienesMov>();
            string nombreDelSp = "";
            try
            {
                //lista = objDao.ListarMarcasAcceso(strTerminal, strFotocheck, strFecha);
                lista = objDao.ListarTablaTbBienes(intIdSesion,  intIdMenu,  intIdSoft, intIdUsuario, strTerminal, ref intResult, ref strMsjDB, ref strMsjUsuario, ref nombreDelSp);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarTablaTbBienes] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarTablaTbBienes)");
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232015)
                {
                    Exception ex_null = new Exception("---> Error generado en el SP: " + nombreDelSp);
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception" + " ( " + ex_null + " )");
                    throw new Exception("Error General (ListarTablaTbBienes)");
                }
                else
                {
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception");
                    throw new Exception("Error General (ListarTablaTbBienes)");

                }
            }

            return lista;
        }

        //13.2 TBOFICINA       
        public List<TbOficinaMov> ListarTablaTbOficina(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, string strTerminal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TbOficinaMov> lista = new List<TbOficinaMov>();
            string nombreDelSp = "";
            try
            {
                lista = objDao.ListarTablaTbOficina(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, strTerminal, ref intResult, ref strMsjDB, ref strMsjUsuario, ref nombreDelSp);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarTablaTbOficina] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarTablaTbOficina)");
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232015)
                {
                    Exception ex_null = new Exception("---> Error generado en el SP: " + nombreDelSp);
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception" + " ( " + ex_null + " )");
                    throw new Exception("Error General (ListarTablaTbOficina)");
                }
                else
                {
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception");
                    throw new Exception("Error General (ListarTablaTbOficina)");

                }
            }

            return lista;
        }

        //13.3 TBEMPLEADO     
        public List<TbEmpleadoMov> ListarTablaTbEmpleado(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, string strTerminal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TbEmpleadoMov> lista = new List<TbEmpleadoMov>();
            string nombreDelSp = "";
            try
            {
                lista = objDao.ListarTablaTbEmpleado(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, strTerminal, ref intResult, ref strMsjDB, ref strMsjUsuario, ref nombreDelSp);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarTablaTbEmpleado] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarTablaTbEmpleado)");
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232015)
                {
                    Exception ex_null = new Exception("---> Error generado en el SP: " + nombreDelSp);
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception" + " ( " + ex_null + " )");
                    throw new Exception("Error General (ListarTablaTbEmpleado)");
                }
                else
                {
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception");
                    throw new Exception("Error General (ListarTablaTbEmpleado)");

                }
            }

            return lista;
        }

        //13.4 TBENTIDAD
        public List<TbEntidadMov> ListarTablaTbEntidad(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, string strTerminal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TbEntidadMov> lista = new List<TbEntidadMov>();
            string nombreDelSp = "";
            try
            {
                lista = objDao.ListarTablaTbEntidad(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, strTerminal, ref intResult, ref strMsjDB, ref strMsjUsuario, ref nombreDelSp);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarTablaTbEntidad] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarTablaTbEntidad)");
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232015)
                {
                    Exception ex_null = new Exception("---> Error generado en el SP: " + nombreDelSp);
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception" + " ( " + ex_null + " )");
                    throw new Exception("Error General (ListarTablaTbEntidad)");
                }
                else
                {
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception");
                    throw new Exception("Error General (ListarTablaTbEntidad)");

                }
            }

            return lista;
        }


        //13.5 TBLOCAL
        public List<TbLocalMov> ListarTablaTbLocal(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, string strTerminal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TbLocalMov> lista = new List<TbLocalMov>();
            string nombreDelSp = "";
            try
            {
                lista = objDao.ListarTablaTbLocal(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, strTerminal, ref intResult, ref strMsjDB, ref strMsjUsuario, ref nombreDelSp);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarTablaTbLocal] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarTablaTbLocal)");
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232015)
                {
                    Exception ex_null = new Exception("---> Error generado en el SP: " + nombreDelSp);
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception" + " ( " + ex_null + " )");
                    throw new Exception("Error General (ListarTablaTbLocal)");
                }
                else
                {
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception");
                    throw new Exception("Error General (ListarTablaTbLocal)");

                }
            }

            return lista;
        }


        //13.6 TBAREAS
        public List<TbAreasMov> ListarTablaTbAreas(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, string strTerminal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TbAreasMov> lista = new List<TbAreasMov>();
            string nombreDelSp = "";
            try
            {
                lista = objDao.ListarTablaTbAreas(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, strTerminal, ref intResult, ref strMsjDB, ref strMsjUsuario, ref nombreDelSp);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarTablaTbAreas] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarTablaTbAreas)");
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232015)
                {
                    Exception ex_null = new Exception("---> Error generado en el SP: " + nombreDelSp);
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception" + " ( " + ex_null + " )");
                    throw new Exception("Error General (ListarTablaTbAreas)");
                }
                else
                {
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception");
                    throw new Exception("Error General (ListarTablaTbAreas)");

                }
            }

            return lista;
        }


        //13.7 TBESTADO
        public List<TbEstadoMov> ListarTablaTbEstado(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, string strTerminal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TbEstadoMov> lista = new List<TbEstadoMov>();
            string nombreDelSp = "";
            try
            {
                lista = objDao.ListarTablaTbEstado(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, strTerminal, ref intResult, ref strMsjDB, ref strMsjUsuario, ref nombreDelSp);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarTablaTbEstado] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarTablaTbEstado)");
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232015)
                {
                    Exception ex_null = new Exception("---> Error generado en el SP: " + nombreDelSp);
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception" + " ( " + ex_null + " )");
                    throw new Exception("Error General (ListarTablaTbEstado)");
                }
                else
                {
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception");
                    throw new Exception("Error General (ListarTablaTbEstado)");

                }
            }

            return lista;
        }


        //13.8 TBTIPO
        public List<TbTipoMov> ListarTablaTbTipo(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, string strTerminal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TbTipoMov> lista = new List<TbTipoMov>();
            string nombreDelSp = "";
            try
            {
                lista = objDao.ListarTablaTbTipo(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, strTerminal, ref intResult, ref strMsjDB, ref strMsjUsuario, ref nombreDelSp);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarTablaTbTipo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarTablaTbTipo)");
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232015)
                {
                    Exception ex_null = new Exception("---> Error generado en el SP: " + nombreDelSp);
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception" + " ( " + ex_null + " )");
                    throw new Exception("Error General (ListarTablaTbTipo)");
                }
                else
                {
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception");
                    throw new Exception("Error General (ListarTablaTbTipo)");

                }
            }

            return lista;
        }


        //16.1 //TbParamsMovil   //ListarTablaTbTipo //ListarParametrosMovil
        public List<TbParamsMovil> ListarParametrosMovil(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, /*string strTerminal,*/ ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TbParamsMovil> lista = new List<TbParamsMovil>();
            string nombreDelSp = "";
            try
            {
                lista = objDao.ListarParametrosMovil(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, /*strTerminal,*/ ref intResult, ref strMsjDB, ref strMsjUsuario, ref nombreDelSp);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarParametrosMovil] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarParametrosMovil)");
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232015)
                {
                    Exception ex_null = new Exception("---> Error generado en el SP: " + nombreDelSp);
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception" + " ( " + ex_null + " )");
                    throw new Exception("Error General (ListarParametrosMovil)");
                }
                else
                {
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception");
                    throw new Exception("Error General (ListarParametrosMovil)");

                }
            }

            return lista;
        }


        //16.2 ---> TbConceptosMovil  ---> ListarConceptosMovil()
        public List<TbConceptosMovil> ListarConceptosMovil(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, /*string strTerminal,*/ ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TbConceptosMovil> lista = new List<TbConceptosMovil>();
            string nombreDelSp = "";
            try
            {
                lista = objDao.ListarConceptosMovil(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, /*strTerminal,*/ ref intResult, ref strMsjDB, ref strMsjUsuario, ref nombreDelSp);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarConceptosMovil] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarConceptosMovil)");
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232015)
                {
                    Exception ex_null = new Exception("---> Error generado en el SP: " + nombreDelSp);
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception" + " ( " + ex_null + " )");
                    throw new Exception("Error General (ListarConceptosMovil)");
                }
                else
                {
                    Log.AlmacenarLogError(ex, "AccesoMovilBL.cs: Exception");
                    throw new Exception("Error General (ListarConceptosMovil)");

                }
            }

            return lista;
        }



        public List<RstaValidPersonalEntity> ValidarPersonaAcceso(string strNumDocumento, string dtHoraMarca, string dtFechaMarca, string strTerminal, string strTipoAcceso)
        {
            List<RstaValidPersonalEntity> lista = new List<RstaValidPersonalEntity>();
            try
            {

                lista = objDao.ValidarPersonaAcceso(strNumDocumento, dtHoraMarca, dtFechaMarca, strTerminal, strTipoAcceso);

            }
            catch (SqlException ex)
            {
                throw new Exception("Ocurrió un error en BD " + ex);
            }

            return lista;
        }

        public List<RstaInsertMarcaEntity> InsertarMarcaAcceso(string strNumDocumento, string strTipoAcceso, string dtHoraMarca, string dtFechaMarca, string strTerminal, string strFotoAcceso, string strReporte_dir, string strDireccion)
        {
            List<RstaInsertMarcaEntity> lista = new List<RstaInsertMarcaEntity>();
            try
            {

                lista = objDao.InsertarMarcaAcceso(strNumDocumento, strTipoAcceso, dtHoraMarca, dtFechaMarca, strTerminal, strFotoAcceso, strReporte_dir, strDireccion);

            }
            catch (SqlException ex)
            {
                throw new Exception("Ocurrió un error en BD " + ex);
            }
            //28/12 11.08
            return lista;
        }

        public List<RstaInsertImgEntity> InsertarImagenAcceso(int intIdAsistencia, string strFotoAcceso)
        {
            List<RstaInsertImgEntity> lista = new List<RstaInsertImgEntity>();
            try
            {

                lista = objDao.InsertarImagenAcceso(intIdAsistencia, strFotoAcceso);

            }
            catch (SqlException ex)
            {
                throw new Exception("Ocurrió un error en BD " + ex);
            }

            return lista;
        }

        public List<RstaListMarcaEntity> ListarMarcasAcceso(string strTerminal, string strFotocheck, string strFecha)
        {
            List<RstaListMarcaEntity> lista = new List<RstaListMarcaEntity>();
            try
            {

                lista = objDao.ListarMarcasAcceso(strTerminal, strFotocheck, strFecha);

            }
            catch (SqlException ex)
            {
                throw new Exception("Ocurrió un error en BD " + ex);
            }

            return lista;
        }

        public List<RstaListaCoordEntity> ListarCoordAcceso(int intIdPersonal)
        {
            List<RstaListaCoordEntity> lista = new List<RstaListaCoordEntity>();
            try
            {

                lista = objDao.ListarCoordAcceso(intIdPersonal);

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs");
                throw new Exception("Ocurrió un error en BD " + ex);
            }

            return lista;
        }

        public List<RstaConexion> ValidarConexionAcceso()
        {
            List<RstaConexion> lista = new List<RstaConexion>();
            try
            {

                lista = objDao.ValidarConexionAcceso();

            }
            catch (SqlException ex)
            {
                throw new Exception("Ocurrió un error en BD " + ex);
            }

            return lista;
        }

        //08012021

        public List<RstaListConceptos> ListarConceptosAcceso(string strFotocheck, string strfiltro_fech, string strSerie)
        {
            List<RstaListConceptos> lista = new List<RstaListConceptos>();
            try
            {

                lista = objDao.ListarConceptosAcceso(strFotocheck, strfiltro_fech, strSerie);

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs");
                throw new Exception("Ocurrió un error en BD " + ex);
            }

            return lista;
        }

        public List<RstaListComboConcepto> ListarComboConceptosAcceso(string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo)
        {
            List<RstaListComboConcepto> lista = new List<RstaListComboConcepto>();
            try
            {

                lista = objDao.ListarComboConceptosAcceso(strEntidad, intIdFiltroGrupo, strGrupo, strSubGrupo);

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs");
                throw new Exception("Ocurrió un error en BD " + ex);
            }

            return lista;
        }

        public List<RstaListComboSustenta> ListarComboSustentaAcceso(string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo)
        {
            List<RstaListComboSustenta> lista = new List<RstaListComboSustenta>();
            try
            {

                lista = objDao.ListarComboSustentaAcceso(strEntidad, intIdFiltroGrupo, strGrupo, strSubGrupo);

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs");
                throw new Exception("Ocurrió un error en BD " + ex);
            }

            return lista;
        }

        public List<RstaInsertConcepto> InsertaConceptoAcceso(string strTerminal, string strFotocheck, string strDeConcepto, string strFecIni, string strFecFin,
                            string strHoraIni, string strHoraFin, string strObs, int intEspeValorada, int bitSustentado, string strCitt, string strEmitEn, string strEmitPor, int intDiaSgtIni, int intDiaSgtFin, string strNomFoto)
        {
            List<RstaInsertConcepto> lista = new List<RstaInsertConcepto>();
            try
            {

                lista = objDao.InsertaConceptoAcceso(strTerminal, strFotocheck, strDeConcepto, strFecIni, strFecFin,
                            strHoraIni, strHoraFin, strObs, intEspeValorada, bitSustentado, strCitt, strEmitEn, strEmitPor, intDiaSgtIni, intDiaSgtFin, strNomFoto);

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs");
                throw new Exception("Ocurrió un error en BD " + ex);
            }

            return lista;
        }

        public List<RstaDeleteConcepto> EliminarPapeletaAcceso(int intIdPerConcepto)
        {
            List<RstaDeleteConcepto> lista = new List<RstaDeleteConcepto>();
            try
            {

                lista = objDao.EliminarPapeletaAcceso(intIdPerConcepto);

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs");
                throw new Exception("Ocurrió un error en BD " + ex);
            }

            return lista;
        }

    }
}
