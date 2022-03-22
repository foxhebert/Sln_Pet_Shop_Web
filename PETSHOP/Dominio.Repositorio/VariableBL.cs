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

namespace Dominio.Repositorio
{
    public class VariableBL
    {
        private VariableDAO objDao = new VariableDAO();
        //2.17
        public List<TGTipoEN> ListarTipoVar(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarTipoVar(intIdSesion, intIdMenu, intIdSoft,ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[v] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarTipoVar)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: Exception");
                throw new Exception("Error General (ListarTipoVar)");
            }
            return lista;
        }
        //2.18
        public List<TGTipoEN> ListarTipoUM(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarTipoUM(intIdSesion, intIdMenu, intIdSoft,  strEntidad,  intIdFiltroGrupo,  strGrupo,  strSubGrupo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarTipoUM] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarTipoUM)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: Exception");
                throw new Exception("Error General (ListarTipoUM)");
            }
            return lista;
        }
        //2.19
        public List<VariableData> ListarConcepto(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            List<VariableData> lista = new List<VariableData>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarConcepto(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarConcepto] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ConceptoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarConcepto)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ConceptoBL.cs: Exception");
                throw new Exception("Error General (ListarConcepto)");
            }
            return lista;
        }
        //2.20
        public List<TGTipoEN> ListarTipoRedondeo(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarTipoRedondeo(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarTipoRedondeo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarTipoRedondeo)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: Exception");
                throw new Exception("Error General (ListarTipoRedondeo)");
            }
            return lista;

        }
        //2.21
        public List<TGTipoEN> ListarAplicaPor(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarAplicaPor(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarAplicaPor] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarAplicaPor)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: Exception");
                throw new Exception("Error General (ListarAplicaPor)");
            }
            return lista;
        }
        //2.22
        public List<TGTipoEN> ListarForRedondeo(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarForRedondeo(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarForRedondeo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarForRedondeo)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: Exception");
                throw new Exception("Error General (ListarForRedondeo)");
            }
            return lista;
        }
        //2.23
        public List<Jornada> ListarHorarioEspecifico(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<Jornada> lista = new List<Jornada>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarHorarioEspecifico(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarHorarioEspecifico] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarHorarioEspecifico)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: Exception");
                throw new Exception("Error General (ListarHorarioEspecifico)");
            }
            return lista;
        }
        //2.24
        public List<Concepto> ListarHorasExtras(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<Concepto> lista = new List<Concepto>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarHorasExtras(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarHorasExtras] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarHorasExtras)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: Exception");
                throw new Exception("Error General (ListarHorasExtras)");
            }
            return lista;
        }
        //2.25
        public bool EliminmarConcepto(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdConcepto, ref string strMsjUsuario)
        {

            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objDao.EliminmarConcepto(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdConcepto, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {   //2.56 Corregir EliminmarVariable por EliminmarConcepto HG 19.04.21
                        Log.AlmacenarLogMensaje("[EliminmarConcepto] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: SqlException");
                //2.56 Corregir EliminmarVariable por EliminmarConcepto HG 19.04.21
                throw new Exception("Ocurrió un error en BD (EliminmarConcepto)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: Exception");
                //2.56 Corregir EliminmarVariable por EliminmarConcepto HG 19.04.21
                throw new Exception("Error General (EliminmarConcepto)");
            }
        }
        //2.26
        public bool IUVariable_T(long intIdSesion, int intIdMenu, int intIdSoft, Concepto objDatos, List<Concepto> listaConcepto, List<TGJOR_BON_DET> listaDetaBoni, int intIdUsuario, int intTipoOperacion, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";
                string Msj = "";

                intResult = objDao.IUVariable_T(intIdSesion, intIdMenu, intIdSoft, objDatos, listaConcepto, listaDetaBoni, intIdUsuario, intTipoOperacion, ref intResult, ref strMsjDB, ref strMsjUsuario, ref Msj);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUVariable_T] => Respuesta del Procedimiento : " + strMsjDB);
                        Log.AlmacenarLogMensaje("[IUVariable_T] => Respuesta del Procedimiento : " + Msj);
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
            //    Log.AlmacenarLogError(ex, "VariableBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (IUVariable_T)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (IUVariable_T)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: Exception");
                throw new Exception("Error General (IUVariable_T)");
            }
        }
        //2.27
        public List<CamposAdicionales2> ListarCamposAdicionales(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, ref string strMsjUsuario)
        {
            List<CamposAdicionales2> lista = new List<CamposAdicionales2>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCamposAdicionales(intIdSesion, intIdMenu, intIdSoft, strEntidad, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        //2.58 Corregir ListarCamposAdicionalesConcepto por ListarCamposAdicionales HG 19.04.21
                        Log.AlmacenarLogMensaje("[ListarCamposAdicionales] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: SqlException");
                //2.58 Corregir ListarCamposAdicionalesConcepto por ListarCamposAdicionales HG 19.04.21
                throw new Exception("Ocurrió un error en BD (ListarCamposAdicionales)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: Exception");
                //2.58 Corregir ListarCamposAdicionalesConcepto por ListarCamposAdicionales HG 19.04.21
                throw new Exception("Error General (ListarCamposAdicionales)");
            }
            return lista;
        }
        //2.28
        public List<Concepto> ObtenerConceptoPorsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int intIdConcepto, ref string strMsjUsuario)
        {
            List<Concepto> lista = new List<Concepto>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerConceptoPorsuPK(intIdSesion, intIdMenu, intIdSoft, intIdConcepto, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerConceptoPorsuPK] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerConceptoPorsuPK)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: Exception");
                throw new Exception("Error General (ObtenerConceptoPorsuPK)");
            }
            return lista;
        }
        //2.29
        public List<Concepto> ListarPrioritariosdeHorasExtras(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref string strMsjUsuario)
        {
            List<Concepto> lista = new List<Concepto>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarPrioritariosdeHorasExtras(intIdSesion, intIdMenu, intIdSoft, strEntidad, intIdFiltroGrupo, strGrupo, strSubGrupo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarPrioritariosdeHorasExtras] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarPrioritariosdeHorasExtras)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: Exception");
                throw new Exception("Error General (ListarPrioritariosdeHorasExtras)");
            }
            return lista;
        }
        //2.30
        public List<Concepto> ListarHorarioEspecificos(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intId, int intUso, string strGrupo, string strSubGrupo, ref string strMsjUsuario)
        {
            List<Concepto> lista = new List<Concepto>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarHorarioEspecificos(intIdSesion, intIdMenu, intIdSoft,  strEntidad,  intId,  intUso,  strGrupo,  strSubGrupo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarHorarioEspecificos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarHorarioEspecificos)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "VariableBL.cs: Exception");
                throw new Exception("Error General (ListarHorarioEspecificos)");
            }
            return lista;
        }

    }
}

