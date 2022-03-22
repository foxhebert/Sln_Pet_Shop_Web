using Dominio.Entidades;
using Dominio.Repositorio.Util;
using Infraestructura.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Threading.Tasks;


namespace Dominio.Repositorio
{
   public class UnidadOrgBL
    {
        private UnidadOrgDAO objDao = new UnidadOrgDAO();
        
        //4.1
        public List<Ubigeo> LlenarUbigeoInverso(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUbigeo, ref string strMsjUsuario)
        {
            List<Ubigeo> lista = new List<Ubigeo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.LlenarUbigeoInverso(intIdSesion, intIdMenu, intIdSoft, intIdUbigeo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[LlenarUbigeoInverso] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (LlenarUbigeoInverso)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: Exception");
                throw new Exception("Error General (LlenarUbigeoInverso)");
            }
            return lista;
        }
        //1.10 - 4.2 <Pendiente corregir para que "ListarCampoJerarquía / UnidadOrgBL.cs" no se le llame desde dos contratos diferentes.>
        public List<JerarquiaOrg> ListarCampoJerarquía(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<JerarquiaOrg> lista = new List<JerarquiaOrg>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCampoJerarquía(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCampoJerarquía] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCampoJerarquía)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: Exception");
                throw new Exception("Error General (ListarCampoJerarquía)");
            }
            return lista;
        }
        //4.3
        public List<UnidadOrg> ListarCampoUnidSup(long intIdSesion, int intIdMenu, int intIdSoft, int intIdJerOrg, ref string strMsjUsuario)
        {
            List<UnidadOrg> lista = new List<UnidadOrg>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCampoUnidSup(intIdSesion, intIdMenu, intIdSoft, intIdJerOrg, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCampoUnidSup] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCampoUnidSup)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: Exception");
                throw new Exception("Error General (ListarCampoUnidSup)");
            }
            return lista;
        }
        //4.4
        public List<Personal> ListarResponsable(long intIdSesion, int intIdMenu, int intIdSoft, string strfiltroPersonal, ref string strMsjUsuario)
        {
            List<Personal> lista = new List<Personal>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";
                lista = objDao.ListarResponsable(intIdSesion, intIdMenu, intIdSoft, strfiltroPersonal,  ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarResponsable] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarResponsable)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: Exception");
                throw new Exception("Error General (ListarResponsable)");
            }
            return lista;
        }
        //4.5
        public List<Ubigeo> ListarUbigeo(long intIdSesion, int intIdMenu, int intIdSoft, int intcodPais,  ref string strMsjUsuario){
            List<Ubigeo> lista = new List<Ubigeo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarUbigeo(intIdSesion, intIdMenu, intIdSoft, intcodPais, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarUbigeo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarUbigeo)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: Exception");
                throw new Exception("Error General (ListarUbigeo)");
            }
            return lista;
        }
        //4.6
        public List<TGTipoEN> ListarDirecFiscal(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario ) {
            List<TGTipoEN> lista = new List<TGTipoEN>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarDirecFiscal(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarDirecFiscal] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarDirecFiscal)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: Exception");
                throw new Exception("Error General (ListarDirecFiscal)");
            }
            return lista;
        }
        //4.7
        public List<RepLegal> ListarRepLegal(long intIdSesion, int intIdMenu, int intIdSoft, string strfiltroLegal, ref string strMsjUsuario)
        {

            List<RepLegal> lista = new List<RepLegal>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarRepLegal(intIdSesion, intIdMenu, intIdSoft, strfiltroLegal, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarRepLegal] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarRepLegal)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: Exception");
                throw new Exception("Error General (ListarRepLegal)");
            }
            return lista;
        }
        //4.8
        public List<Paises> ListarPaises(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario) {
        List<Paises> lista = new List<Paises>();
        try
        { 
            int intResult = 0;
            string strMsjDB = "";

            lista = objDao.ListarPaises(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
            if (intResult == 0)
            {
                if (!strMsjDB.Equals(""))
                {
                    Log.AlmacenarLogMensaje("[ListarPaises] => Respuesta del Procedimiento : " + strMsjDB);
                    if (strMsjUsuario.Equals(""))
                        strMsjUsuario = strMsjDB;
                }

            }

        }
        catch (SqlException ex)
        {
            Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: SqlException");
            throw new Exception("Ocurrió un error en BD (ListarPaises)");
        }

        catch (Exception ex)
        {
            Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: Exception");
            throw new Exception("Error General (ListarPaises)");
        }
        return lista;
    }
        //4.9
        public List<Ubigeo> ListarProvincias(long intIdSesion, int intIdMenu, int intIdSoft, string stridPaisDep, string strCoDep, ref string strMsjUsuario)
        {
            List<Ubigeo> lista = new List<Ubigeo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarProvincias(intIdSesion, intIdMenu, intIdSoft, stridPaisDep, strCoDep, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarProvincias] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarProvincias)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: Exception");
                throw new Exception("Error General (ListarProvincias)");
            }
            return lista;
        }
        //4.10
        public List<UnidadOrgData> ListarUnidadOrg(long intIdSesion, int intIdMenu, int intIdSoft, string strfilter, int intfiltrojer, int intActivoFilter, ref string strMsjUsuario)
        {
            List<UnidadOrgData> lista = new List<UnidadOrgData>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarUnidadOrg(intIdSesion, intIdMenu, intIdSoft, strfilter, intfiltrojer, intActivoFilter, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarUnidadOrg] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarUnidadOrg)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: Exception");
                throw new Exception("Error General (ListarUnidadOrg)");
            }
            return lista;
        }
        //4.11
        public List<Ubigeo> ListarDistrict(long intIdSesion, int intIdMenu, int intIdSoft, string strCoDep, string stridpaisProv, ref string strMsjUsuario)
        {
            List<Ubigeo> lista = new List<Ubigeo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarDistrict(intIdSesion, intIdMenu, intIdSoft, strCoDep, stridpaisProv, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarDistrict] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarDistrict)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: Exception");
                throw new Exception("Error General (ListarDistrict)");
            }
            return lista;
        }
        //4.12
        public List<JerCampDet> ListarFiltroCampJer(long intIdSesion, int intIdMenu, int intIdSoft, string filtro, ref string strMsjUsuario)
        {
            List<JerCampDet> lista = new List<JerCampDet>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarFiltroCampJer(intIdSesion, intIdMenu, intIdSoft, filtro, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarFiltroCampJer] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarFiltroCampJer)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: Exception");
                throw new Exception("Error General (ListarFiltroCampJer)");
            }
            return lista;
        }
        //4.13
        public bool IUUnidadOrg_T(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, UnidadOrg objDatos, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";

                intResult = objDao.IUUnidadOrg_T(intIdSesion, intIdMenu, intIdSoft, objDatos, intIdUsuario, intTipoOperacion, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUUnidadOrg_T] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "UnidadOrgBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (InsertarUnidadOrg_IU01)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (IUUnidadOrg_T)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: Exception");
                throw new Exception("Error General (IUUnidadOrg_T)");
            }
        }
        //4.14
        public bool EliminmarUnidadOrg(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int IntIdJerOrg, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";
                bool tudobem = false;
                tudobem = objDao.EliminmarUnidadOrg(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, IntIdJerOrg, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminmarUnidadOrg] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminmarUnidadOrg)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: Exception");
                throw new Exception("Error General (EliminmarUnidadOrg)");
            }
        }
        //4.15
        public List<UnidadOrg> ConsultarDetalleUndOrgCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUndOrg, ref string strMsjUsuario)
        {
            List<UnidadOrg> lista = new List<UnidadOrg>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ConsultarDetalleUndOrgCod(intIdSesion, intIdMenu, intIdSoft, intIdUndOrg, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ConsultarDetalleUndOrgCod] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ConsultarDetalleUndOrgCod)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: Exception");
                throw new Exception("Error General (ConsultarDetalleUndOrgCod)");
            }
            return lista;
        }
        //4.16
        public List<UnidadOrg> ConsultarUndJerarxUndOrg(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUndOrg, ref string strMsjUsuario)
        {
            List<UnidadOrg> lista = new List<UnidadOrg>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ConsultarUndJerarxUndOrg(intIdSesion, intIdMenu, intIdSoft, intIdUndOrg, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ConsultarUndJerarxUndOrg] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ConsultarUndJerarxUndOrg)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: Exception");
                throw new Exception("Error General (ConsultarUndJerarxUndOrg)");
            }
            return lista;
        }
        //4.17
        public List<CamposAdicionales2> ListarCamposAdicionalesUO(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intidJerOrg, ref string strMsjUsuario)
        {
            List<CamposAdicionales2> lista = new List<CamposAdicionales2>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCamposAdicionalesUO(intIdSesion, intIdMenu, intIdSoft, strEntidad, intidJerOrg, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCamposAdicionalesUO] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCamposAdicionalesUO)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: Exception");
                throw new Exception("Error General (ListarCamposAdicionalesUO)");
            }
            return lista;
        }
        //4.18
        public List<UnidadOrg> ObtenerOrganizacionporsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int IntIdUniOrg, ref string strMsjUsuario)
        {
            List<UnidadOrg> lista = new List<UnidadOrg>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerOrganizacionporsuPK(intIdSesion, intIdMenu, intIdSoft, IntIdUniOrg, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerOrganizacionporsuPK] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerOrganizacionporsuPK)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: Exception");
                throw new Exception("Error General (ObtenerOrganizacionporsuPK)");
            }
            return lista;
        }
        //4.19
        public List<Ubigeo> ObtenerUbigeosyListas(long intIdSesion, int intIdMenu, int intIdSoft, int intidTipo, int intidUbigeo, ref string strMsjUsuario)
        {
            List<Ubigeo> lista = new List<Ubigeo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerUbigeosyListas(intIdSesion, intIdMenu, intIdSoft, intidTipo, intidUbigeo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerUbigeosyListas] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerUbigeosyListas)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "UnidadOrgBL.cs: Exception");
                throw new Exception("Error General (ObtenerUbigeosyListas)");
            }
            return lista;
        }


    }

}