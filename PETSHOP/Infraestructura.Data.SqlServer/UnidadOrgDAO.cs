using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.Data.SqlServer
{
    public class UnidadOrgDAO : Conexion
    {
        //4.1
        public List<Ubigeo> LlenarUbigeoInverso(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUbigeo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Ubigeo> listDetCar = new List<Ubigeo>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGUNIDORG_Q07", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdUbigeo", intIdUbigeo);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ubigeo objOrg = new Ubigeo();

                        objOrg.intIdPais = reader.GetInt32(0);
                        objOrg.intIdUbigeo = reader.GetInt32(1);
                        objOrg.intIdUbiSup = reader.GetInt32(2);
                        objOrg.strCoUbigeo = reader.GetString(3);
                        listDetCar.Add(objOrg);
                    }
                }
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listDetCar;
        }
        //1.10 - 4.2 <Pendiente corregir para que "ListarCampoJerarquía / UnidadOrgBL.cs" no se le llame desde dos contratos diferentes.>
        public List<JerarquiaOrg> ListarCampoJerarquía(long intIdSesion, int intIdMenu, int intIdSoft, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<JerarquiaOrg> lista = new List<JerarquiaOrg>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGJERARQORG_Q06", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        JerarquiaOrg obj = new JerarquiaOrg();
                        obj.IntIdJerOrg = reader.GetInt32(0);
                        obj.strNomJerOrg = reader.GetString(1);

                        lista.Add(obj);
                    }
                    reader.Close();
                }
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return lista;
        }
        //4.3
        public List<UnidadOrg> ListarCampoUnidSup(long intIdSesion, int intIdMenu, int intIdSoft, int intIdJerOrg, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<UnidadOrg> lista = new List<UnidadOrg>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGUNIDORG_Q04", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdJerOrg",intIdJerOrg);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UnidadOrg obj = new UnidadOrg();
                        obj.intIdUniOrg = reader.GetInt32(0);
                        obj.strDescripcion = reader.GetString(1);

                        lista.Add(obj);

                    }
                    reader.Close();
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        //4.4
        public List<Personal> ListarResponsable(long intIdSesion, int intIdMenu, int intIdSoft, string strfiltroPersonal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Personal> lista = new List<Personal>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPERSONAL_Q04", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@strfiltroPersonal", strfiltroPersonal);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Personal obj = new Personal();
                        obj.strNombres = reader.GetString(0);
                        obj.strApePaterno = reader.GetString(1);
                        obj.strApeMaterno = reader.GetString(2);
                        obj.intIdPersonal = reader.GetInt32(3);
                        obj.strNumDoc = reader.GetString(4);
                        lista.Add(obj);

                    }
                    reader.Close();
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        //4.5
        public List<Ubigeo> ListarUbigeo(long intIdSesion, int intIdMenu, int intIdSoft, int intcodPais, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Ubigeo> lista = new List<Ubigeo>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGUBIGEO_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intCodPais", intcodPais);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ubigeo obj = new Ubigeo();
                        obj.strCoUbigeo = reader.GetString(0);
                        obj.intIdPais = reader.GetInt32(1);
                        obj.strDesUbigeo = reader.GetString(2);
                        lista.Add(obj);

                    }
                    reader.Close();
                }
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        //4.6
        public List<TGTipoEN> ListarDirecFiscal(long intIdSesion, int intIdMenu, int intIdSoft, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGTIPO_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TGTipoEN obj = new TGTipoEN();
                        obj.intidTipo = reader.GetInt32(0);
                        obj.strAbreviatura = reader.GetString(1);
                        lista.Add(obj);

                    }
                    reader.Close();
                }
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        //4.7
        public List<RepLegal> ListarRepLegal(long intIdSesion, int intIdMenu, int intIdSoft, string strfiltroLegal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<RepLegal> lista = new List<RepLegal>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TAREPLEGAL_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@strfiltroLegal", strfiltroLegal);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RepLegal obj = new RepLegal();
                        obj.strNombres = reader.GetString(0);
                        obj.strApePaterno = reader.GetString(1);
                        obj.strApeMaterno = reader.GetString(2);
                        obj.IntIdRepLeg = reader.GetInt32(3);
                        obj.strNumDoc = reader.GetString(4);
                        lista.Add(obj);

                    }
                    reader.Close();
                }
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        //4.8
        public List<Paises> ListarPaises(long intIdSesion, int intIdMenu, int intIdSoft, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Paises> lista = new List<Paises>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPAIS_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Paises obj = new Paises();
                        obj.IntIdPais = reader.GetInt32(0);
                        obj.strDesPais = reader.GetString(1);

                        lista.Add(obj);

                    }
                    reader.Close();
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //4.9
        public List<Ubigeo> ListarProvincias(long intIdSesion, int intIdMenu, int intIdSoft, string stridPaisDep, string strCoDep, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Ubigeo> lista = new List<Ubigeo>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGUBIGEO_Q02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@stridPaisDep", stridPaisDep);
                param.Add("@strCoDep", strCoDep);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ubigeo obj = new Ubigeo();
                        obj.strCoUbigeo = reader.GetString(0);
                        obj.strDesUbigeo = reader.GetString(1);
                        lista.Add(obj);

                    }
                    reader.Close();
                }
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //4.10
        public List<UnidadOrgData> ListarUnidadOrg(long intIdSesion, int intIdMenu, int intIdSoft, string strfilter, int intfiltrojer, int intActivoFilter, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<UnidadOrgData> lista = new List<UnidadOrgData>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGUNIDORG_Q05", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);


                param.Add("@strfilter", strfilter);
                param.Add("@intfiltrojer", intfiltrojer);
                param.Add("@intActivoFilter", intActivoFilter);


                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UnidadOrgData obj = new UnidadOrgData();
                        Estado objEstado = new Estado();
                        obj.strCodigo = reader.GetString(0);
                        obj.strDescripcion = reader.GetString(1);
                        obj.strNomJerOrg = reader.GetString(2);
                        if (reader.GetValue(3) != DBNull.Value)
                            obj.strDescripcionSup = reader.GetString(3);
                        else
                            obj.strDescripcionSup = "";

                        obj.bitFlActivo = reader.GetBoolean(4);
                        objEstado.strEstadoActivo = reader.GetString(5);
                        obj.intIdUniOrg = reader.GetInt32(6);
                        obj.intIdUniOrgSup = reader.GetInt32(7);
                        obj.strDirLogo = reader.GetString(8);
                        obj.intIdPerResp = reader.GetInt32(9);
                        obj.strRuc = reader.GetString(10);
                        obj.intIdRepLeg = reader.GetInt32(11);
                        obj.intIdUbigeo = reader.GetInt32(14);

                        obj.FlActivo = objEstado;
                        lista.Add(obj);

                    }
                    reader.Close();
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //4.11
        public List<Ubigeo> ListarDistrict(long intIdSesion, int intIdMenu, int intIdSoft,  string strCoDep ,string stridpaisProv, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Ubigeo> lista = new List<Ubigeo>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGUBIGEO_Q03", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@strCoDep", strCoDep);
                param.Add("@stridpaisProv", stridpaisProv);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ubigeo obj = new Ubigeo();
                        obj.strDesUbigeo = reader.GetString(0); 
                        obj.intIdPais = reader.GetInt32(1);
                        obj.intIdUbigeo = reader.GetInt32(2);

                        lista.Add(obj);

                    }
                    reader.Close();
                }
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        //4.12
        public List<JerCampDet> ListarFiltroCampJer(long intIdSesion, int intIdMenu, int intIdSoft, string filtro, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<JerCampDet> lista = new List<JerCampDet>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGJER_CAMPO_DET_Q02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@filtro", filtro);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        JerCampDet obj = new JerCampDet();
                        obj.bitObligatorio = reader.GetBoolean(1);
                        obj.strCoCampo = reader.GetString(0);

                        lista.Add(obj);

                    }
                    reader.Close();
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        //4.13
        public int IUUnidadOrg_T(long intIdSesion, int intIdMenu, int intIdSoft, UnidadOrg objDatos, int intIdUsuario, int intTipoOperacion, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            int IntIdUnidOrgOut = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGUNIDORG_IU01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@IntIdJerOrg", objDatos.intIdJerOrg);
                param.Add("@strCodigo", objDatos.strCodigo);
                param.Add("@strDescripcion", objDatos.strDescripcion);
                param.Add("@IntIdUniOrgSup", objDatos.intIdUniOrgSup);
                param.Add("@IntIdPerResp", objDatos.intIdPerResp);
                param.Add("@IntIdRepLeg", objDatos.intIdRepLeg);
                if (objDatos.intIdUbigeo == 0)
                {
                    param.Add("@intIdUbigeo", null);
                }
                else
                {
                    param.Add("@intIdUbigeo", objDatos.intIdUbigeo);
                }
                param.Add("@strRuc", objDatos.strRuc);
                param.Add("@IntidTipoVia", objDatos.intidTipoVia);
                param.Add("@strDirFiscal", objDatos.strDirFiscal);
                param.Add("@imgLogo", objDatos.strDirLogo);
                param.Add("@strUOCampo1", objDatos.strUOCampo1);
                param.Add("@strUOCampo2", objDatos.strUOCampo2);
                param.Add("@strUOCampo3", objDatos.strUOCampo3);
                param.Add("@strUOCampo4", objDatos.strUOCampo4);
                param.Add("@strUOCampo5", objDatos.strUOCampo5);
                param.Add("@bitFlActivo", objDatos.bitFlActivo);
                param.Add("@bitFlPrincipal", objDatos.bitFlPrincipal);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update
                //Parámetros de Salida
                if (intTipoOperacion == 1)
                {
                    param.Add("@IntIdUniOrg", 0);
                }
                else
                {
                    param.Add("@IntIdUniOrg", objDatos.intIdUniOrg);
                }

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                //int result = cmd.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                IntIdUnidOrgOut = Convert.ToInt32(cmd.Parameters["@IntIdUniOrg"].Value.ToString());
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return IntIdUnidOrgOut;
        }
        //4.14
        public bool EliminmarUnidadOrg(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdUniOrg, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGUNIDORG_D02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdUsuario", intIdUsuario);

                param.Add("@intIdUniOrg", intIdUniOrg);
                //Parámetros de Salida                              
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                exito = Transaction(cn, cmd);

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return exito;
        }
        //4.15
        public List<UnidadOrg> ConsultarDetalleUndOrgCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUndOrg, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<UnidadOrg> listDetCar = new List<UnidadOrg>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGUNIDORG_Q06", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);



                param.Add("@intIdUO", intIdUndOrg);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        UnidadOrg obj = new UnidadOrg();
                        obj.intIdUniOrg = reader.GetInt32(0);
                        obj.intIdJerOrg = reader.GetInt32(1);
                        obj.strCodigo = reader.GetString(2);
                        obj.strDescripcion = reader.GetString(3);
                        obj.intIdUniOrgSup = reader.GetInt32(4);
                        obj.intIdRepLeg = reader.GetInt32(5);
                        obj.intIdPerResp = reader.GetInt32(6);
                        obj.intIdUbigeo = reader.GetInt32(7);
                        obj.strRuc = reader.GetString(8);
                        obj.intidTipoVia = reader.GetInt32(9);
                        obj.strDirFiscal = reader.GetString(10);
                        obj.strDirLogo = reader.GetString(11);
                        obj.strUOCampo1 = reader.GetString(12);
                        obj.strUOCampo2 = reader.GetString(13);
                        obj.strUOCampo3 = reader.GetString(14);
                        obj.strUOCampo4 = reader.GetString(15);
                        obj.strUOCampo5 = reader.GetString(16);
                        listDetCar.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listDetCar;
        }
        //4.16
        public List<UnidadOrg> ConsultarUndJerarxUndOrg(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUndOrg, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<UnidadOrg> listDetCar = new List<UnidadOrg>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGMARCADOR_Q11", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);



                param.Add("@IntIdUniOrg", intIdUndOrg);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UnidadOrg objOrg = new UnidadOrg();

                        objOrg.intIdJerOrg = reader.GetInt32(0);
                        listDetCar.Add(objOrg);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listDetCar;
        }
        //4.17
        public List<CamposAdicionales2> ListarCamposAdicionalesUO(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intidJerOrg, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<CamposAdicionales2> lista = new List<CamposAdicionales2>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGLISTAR_CAMPOS_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                //--------
                param.Add("@strNoEntidad", strEntidad);
                param.Add("@intidJerOrg", intidJerOrg);
                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CamposAdicionales2 obj = new CamposAdicionales2();
                    obj.strNoEntidad = reader.GetString(0);
                    obj.strNomCampo = reader.GetString(1);
                    obj.strTitulo = reader.GetString(2);

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //4.18
        public List<UnidadOrg> ObtenerOrganizacionporsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int IntIdUniOrg, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<UnidadOrg> listDetCar = new List<UnidadOrg>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGUNIDORG_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);



                param.Add("@IntIdUniOrg", IntIdUniOrg);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        UnidadOrg obj = new UnidadOrg();
                        obj.intIdUniOrg = reader.GetInt32(0);
                        obj.strCodigo = reader.GetString(1);
                        obj.strDescripcion = reader.GetString(2);
                        obj.strNomJerOrg = reader.GetString(3);
                        obj.intIdUniOrgSup = reader.GetInt32(4);
                        obj.strDescripcionSup = reader.GetString(5);
                        obj.intIdPerResp = reader.GetInt32(6);
                        obj.intIdRepLeg = reader.GetInt32(7);
                        obj.intIdUbigeo = reader.GetInt32(8);
                        obj.intextra1 = reader.GetInt32(9);
                        obj.intextra2 = reader.GetInt32(10);
                        obj.intextra3 = reader.GetInt32(11);
                        obj.strRuc = reader.GetString(12);
                        obj.intidTipoVia = reader.GetInt32(13);
                        obj.strDirLogo = reader.GetString(14);
                        obj.strDirFiscal = reader.GetString(15);
                        obj.strUOCampo1 = reader.GetString(16);
                        obj.strUOCampo2 = reader.GetString(17);
                        obj.strUOCampo3 = reader.GetString(18);
                        obj.strUOCampo4 = reader.GetString(19);
                        obj.strUOCampo5 = reader.GetString(20);
                    
                        obj.bitFlActivo = reader.GetBoolean(21);
                        obj.bitFlPrincipal = reader.GetBoolean(22);

                        listDetCar.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listDetCar;
        }
        //4.19
        public List<Ubigeo> ObtenerUbigeosyListas(long intIdSesion, int intIdMenu, int intIdSoft, int intidTipo, int intidUbigeo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Ubigeo> listDetCar = new List<Ubigeo>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGUBIGEO_Q04", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);



                param.Add("@intidTipo", intidTipo);
                param.Add("@intidUbigeo", intidUbigeo);

                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Ubigeo obj = new Ubigeo();
                        obj.intIdUbigeo = reader.GetInt32(0);
                        obj.intIdTipUbig = reader.GetInt32(1);
                        obj.strDesUbigeo = reader.GetString(2);
                        obj.strCoUbigeo = reader.GetString(3);
                       
                     

                        listDetCar.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listDetCar;
        }
        
        
        
        //Parece no ser usado - Pendiente Depurar.
        public List<DetalleUnidadOrg> ConsultarDetalleUnidad_xCod(long intIdSesion, int intIdMenu, int intIdSoft, int IntIdCampo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<DetalleUnidadOrg> listDetUnid = new List<DetalleUnidadOrg>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCAMPOSUO_IU01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);

                param.Add("@IntIdCampo", IntIdCampo);

                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DetalleUnidadOrg obj = new DetalleUnidadOrg();
                        obj.IntIdCampo = reader.GetInt32(1);
                        obj.strCoCampo = reader.GetString(2);
                        obj.strDesCampo = reader.GetString(3);
                        obj.strNomCampo = reader.GetString(4);
                        obj.strTipoDato = reader.GetString(5);
                        obj.strLongitud = reader.GetString(6);
                        obj.bitFlActivo = reader.GetBoolean(7);
                        listDetUnid.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listDetUnid;
        }

    }

}