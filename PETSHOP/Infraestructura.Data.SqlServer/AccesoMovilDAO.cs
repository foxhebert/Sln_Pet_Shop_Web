using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace Infraestructura.Data.SqlServer
{
    public class AccesoMovilDAO : Conexion
    {


        #region MOVIL y BD - INVENTARIOWEB

        //40.1 LISTA LA TABLA TMPRODU HASTA EL MOVIL
        public List<TMPRODU_MOVIL> ListarTablaTmProdu(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, string strTerminal, ref int intResult,ref string strMsjDB, ref string strMsjUsuario, ref string nombreDelSp)
        {
            List<TMPRODU_MOVIL> lista = new List<TMPRODU_MOVIL>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_LISTAR_TMPRODU_MOVIL_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                nombreDelSp = cmd.CommandText;
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);             
                param.Add("@intIdMenu", intIdMenu);     
                param.Add("@intIdSoft", intIdSoft);   
                //---------------------------------------------------------
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@strTerminal", strTerminal);
                //---------------------------------------------------------
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TMPRODU_MOVIL obj = new TMPRODU_MOVIL();

                     if (!reader.IsDBNull(0))
                    {
                        obj.strCoProdu = reader.GetString(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        obj.strDeProdu = reader.GetString(1);
                    }

                    lista.Add(obj);

                }
                reader.Close();

                intResult     = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB      = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        //40.2 LISTA LA TABLA TMPRODU HASTA EL MOVIL CON PARAMETRO
        public List<TMPRODU_MOVIL> ListarTablaTmProduII(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, string strTerminal, string strCoProdu, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string nombreDelSp)
        {
            List<TMPRODU_MOVIL> lista = new List<TMPRODU_MOVIL>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_LISTAR_TMPRODU_MOVIL_Q02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                nombreDelSp = cmd.CommandText;
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                //---------------------------------------------------------
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@strTerminal", strTerminal);
                param.Add("@strCoProdu", strCoProdu);
                //---------------------------------------------------------
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TMPRODU_MOVIL obj = new TMPRODU_MOVIL();

                    if (!reader.IsDBNull(0))
                    {
                        obj.strCoProdu = reader.GetString(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        obj.strDeProdu = reader.GetString(1);
                    }

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        //40.3 INSERTAR/ACTUALIZAR TMINVENTARIO DESDE MOVIL
        public bool InsertarActualizarTmInventarioMovil(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int id, string nvcNoAlmac, 
            string nvcNoUbica, string nvcCoCampoAux, string nvcCoProdu, int intNuRegis, string intNuTermi,
            string dttFeRegis, int intFLNuevo, int intFLRepetido, string deleted_at, string created_at, string updated_at, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool Rpta = false;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_REGISTRAR_ACTUALIZAR_TMINVENTARIO", cn); //TSP_TBBIENES_MOVIL_IU00 TSP_TCCONSUMO_GESTION_U01
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdUsuario", intIdUsuario);
                //---------------------------------------------------------
                //01
                if (id == 0)
                    param.Add("@id", 0 );
                else
                    param.Add("@id", id);
                //02
                if (nvcNoAlmac == null)
                    param.Add("@nvcNoAlmac", DBNull.Value);
                else
                    param.Add("@nvcNoAlmac", nvcNoAlmac);
                //03
                if (nvcNoUbica == null)
                    param.Add("@nvcNoUbica", DBNull.Value);
                else
                    param.Add("@nvcNoUbica", nvcNoUbica);
                //04
                if (nvcCoCampoAux == null)
                    param.Add("@nvcCoCampoAux", DBNull.Value);
                else
                    param.Add("@nvcCoCampoAux", nvcCoCampoAux);
                //05
                if (nvcCoProdu == null)
                    param.Add("@nvcCoProdu", DBNull.Value);
                else
                    param.Add("@nvcCoProdu", nvcCoProdu);
                //06
                if (intNuRegis == 0)
                    param.Add("@intNuRegis", DBNull.Value);
                else
                    param.Add("@intNuRegis", intNuRegis);
                //07
                if (intNuTermi == null)
                    param.Add("@intNuTermi", DBNull.Value);
                else
                    param.Add("@intNuTermi", intNuTermi);
                //08
                if (dttFeRegis == null)
                    param.Add("@dttFeRegis", DBNull.Value);
                else
                    param.Add("@dttFeRegis", dttFeRegis);
                //09
                if (intFLNuevo == 0)
                    param.Add("@intFLNuevo", DBNull.Value);
                else
                    param.Add("@intFLNuevo", intFLNuevo);
                //10
                if (intFLRepetido == 0)
                    param.Add("@intFLRepetido", DBNull.Value);
                else
                    param.Add("@intFLRepetido", intFLRepetido);
                //11
                if (deleted_at == null)
                    param.Add("@deleted_at", DBNull.Value);
                else
                    param.Add("@deleted_at", deleted_at);
                //12
                if (created_at == null)
                    param.Add("@created_at", DBNull.Value);
                else
                    param.Add("@created_at", created_at);
                //13
                if (updated_at == null)
                    param.Add("@updated_at", DBNull.Value);
                else
                    param.Add("@updated_at", updated_at);







                /******
                //param.Add("@intIdCargo", (object)objDatos.intIdCargo ?? DBNull.Value);
                //param.Add("@TT_TBBIENES", tblistaBienes);
                param.Add("@id"             ,id             );     
                param.Add("@nvcNoAlmac"     ,nvcNoAlmac     );
                param.Add("@nvcNoUbica"     ,nvcNoUbica	    );
                param.Add("@nvcCoCampoAux"  ,nvcCoCampoAux  ); //NULL
                param.Add("@nvcCoProdu"     ,nvcCoProdu	    );
                param.Add("@intNuRegis"     ,intNuRegis	    );
                param.Add("@intNuTermi"     ,intNuTermi	    );
                param.Add("@dttFeRegis"     ,dttFeRegis	    );
                param.Add("@intFLNuevo"     ,intFLNuevo	    );
                param.Add("@intFLRepetido"  ,intFLRepetido  );
                param.Add("@deleted_at"     ,deleted_at	    );
                param.Add("@created_at"     ,created_at	    );
                param.Add("@updated_at"     ,updated_at     );
                //param.Add("strCoProdu", strCoProdu);
                //param.Add("strDeProdu", strDeProdu);
                //Parámetros de Salida
                ****/


                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();
                Rpta = true;
                //intIdConsumoOut = Convert.ToInt32(cmd.Parameters["@intIdConsumo"].Value.ToString());
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return Rpta;
        }


        /**
        //15.1 -- Desde UpdateGC(5.87)
        //public bool ObtenerBienesInventariados(Session_Movi objSession, int intTipoOperacion, DataTable tblistaConsumoSelects, int bitFlConsumido, int evento, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        public bool ObtenerBienesInventariados(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, DataTable tblistaBienes, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool Rpta = false;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_REGISTRAR_BIENES_INVENTARIADOS", cn); //TSP_TBBIENES_MOVIL_IU00 TSP_TCCONSUMO_GESTION_U01
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion); //objSession.intIdSesion               
                param.Add("@intIdMenu", intIdMenu);     //1 objSession.intIdMenu.ToString()
                param.Add("@intIdSoft", intIdSoft);     //3 objSession.intIdSoft
                param.Add("@intIdUsuario", intIdUsuario);//objSession.intIdUsuario
                //---------------------------------------------------------
                param.Add("@TT_TBBIENES", tblistaBienes);

                //Parámetros de Salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();
                Rpta = true;
                //intIdConsumoOut = Convert.ToInt32(cmd.Parameters["@intIdConsumo"].Value.ToString());
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return Rpta;
        }
        */

        #endregion



        #region Del Movil a la BD

        //15.1 -- Desde UpdateGC(5.87)
        //public bool ObtenerBienesInventariados(Session_Movi objSession, int intTipoOperacion, DataTable tblistaConsumoSelects, int bitFlConsumido, int evento, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        public bool ObtenerBienesInventariados(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, DataTable tblistaBienes, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            bool Rpta = false;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_REGISTRAR_BIENES_INVENTARIADOS", cn); //TSP_TBBIENES_MOVIL_IU00 TSP_TCCONSUMO_GESTION_U01
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion); //objSession.intIdSesion               
                param.Add("@intIdMenu", intIdMenu);     //1 objSession.intIdMenu.ToString()
                param.Add("@intIdSoft", intIdSoft);     //3 objSession.intIdSoft
                param.Add("@intIdUsuario", intIdUsuario);//objSession.intIdUsuario
                //---------------------------------------------------------
                param.Add("@TT_TBBIENES", tblistaBienes);

                //Parámetros de Salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();
                Rpta = true;
                //intIdConsumoOut = Convert.ToInt32(cmd.Parameters["@intIdConsumo"].Value.ToString());
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return Rpta;
        }


        #endregion



        //13.1 TBBIENES - MOVIL  ---- de public List<RstaListMarcaEntity> ListarMarcasAcceso//TSP_TGLISTMARCA_MOVIL_Q01
        public List<TbBienesMov> ListarTablaTbBienes(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, string strTerminal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string nombreDelSp) 
        {
            List<TbBienesMov> lista = new List<TbBienesMov>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TBBIENES_MOVIL_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                nombreDelSp = cmd.CommandText;
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion); //objSession.intIdSesion               
                param.Add("@intIdMenu", intIdMenu);     //1 objSession.intIdMenu.ToString()
                param.Add("@intIdSoft", intIdSoft);     //3 objSession.intIdSoft
                //---------------------------------------------------------
                param.Add("@intIdUsuario", intIdUsuario);//objSession.intIdUsuario
                param.Add("@strTerminal", strTerminal);
                //---------------------------------------------------------
                param.Add("@intResult", 0);//0
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TbBienesMov obj = new TbBienesMov();

                    if (!reader.IsDBNull(0))
                    {
                        obj.intIdActivo = reader.GetInt32(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        obj.strDescripcion = reader.GetString(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        obj.strCodActivo = reader.GetString(2);
                    }
                    if (!reader.IsDBNull(3))
                    {
                        obj.intIdLocal = reader.GetInt32(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        obj.intIdArea = reader.GetInt32(4);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        obj.intIdOficina = reader.GetInt32(5);
                    }
                    if (!reader.IsDBNull(6))
                    {
                        obj.strCodAnterior = reader.GetString(6);
                    }
                    if (!reader.IsDBNull(7))
                    {
                        obj.intIdResponsable = reader.GetInt32(7);
                    }
                    if (!reader.IsDBNull(8))
                    {
                        obj.intIdEstado = reader.GetInt32(8);
                    }
                    if (!reader.IsDBNull(9))
                    {
                        obj.strDescMarca = reader.GetString(9);
                    }
                    if (!reader.IsDBNull(10))
                    {
                        obj.strDescModelo = reader.GetString(10);
                    }
                    if (!reader.IsDBNull(11))
                    {
                        obj.intIdTipo = reader.GetInt32(11);
                    }
                    if (!reader.IsDBNull(12))
                    {
                        obj.strDescColor = reader.GetString(12);
                    }
                    if (!reader.IsDBNull(13))
                    {
                        obj.strDescSerie = reader.GetString(13);
                    }
                    if (!reader.IsDBNull(14))
                    {
                        obj.strDescNumMotor = reader.GetString(14);
                    }
                    if (!reader.IsDBNull(15))
                    {
                        obj.strDescNumChasis = reader.GetString(15);
                    }
                    if (!reader.IsDBNull(16))
                    {
                        obj.intAnio = reader.GetInt32(16);
                    }
                    if (!reader.IsDBNull(17))
                    {
                        obj.strDescDimension = reader.GetString(17);
                    }
                    if (!reader.IsDBNull(18))
                    {
                        obj.strDescPlaca = reader.GetString(18);
                    }
                    if (!reader.IsDBNull(19))
                    {
                        obj.strDescObservacion = reader.GetString(19);
                    }
                    if (!reader.IsDBNull(20))
                    {
                        obj.strFlag = reader.GetString(20);
                    }
                    if (!reader.IsDBNull(21))
                    {
                        obj.strPda = reader.GetString(21);
                    }
                    if (!reader.IsDBNull(22))
                    {
                        obj.dttFeCrea = reader.GetDateTime(22);
                        //obj.dttFeCrea = reader.GetString(22);
                    }
                    if (!reader.IsDBNull(23))
                    {
                        obj.dttFeModi= reader.GetDateTime(23); //
                        //obj.dttFeModi= DateTime.SpecifyKind(reader.GetDateTime(23), DateTimeKind.Utc); //.ToString("dd/MM/yyyy")
                        //obj.dttFeModi = reader.GetString(23);
                    }

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        //13.2 TBOFICINA - MOVIL
        public List<TbOficinaMov> ListarTablaTbOficina(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, string strTerminal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string nombreDelSp)
        {
            List<TbOficinaMov> lista = new List<TbOficinaMov>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TBOFICINA_MOVIL_Q00", cn);//TSP_TGLISTMARCA_MOVIL_Q01
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                nombreDelSp = cmd.CommandText;
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);               
                param.Add("@intIdMenu", intIdMenu);     
                param.Add("@intIdSoft", intIdSoft);     
                //---------------------------------------------------------
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@strTerminal", strTerminal);
                //---------------------------------------------------------
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TbOficinaMov obj = new TbOficinaMov();             
                    
                    if (!reader.IsDBNull(0))
                    {
                        obj.intIdOficina = reader.GetInt32(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        obj.intIdLocal = reader.GetInt32(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        obj.intIdArea = reader.GetInt32(2);
                    }
                    if (!reader.IsDBNull(3))
                    {
                        obj.strCodOficina = reader.GetString(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        obj.strDescOficina = reader.GetString(4);
                    }

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        //13.3 TBEMPLEADO - MOVIL
        public List<TbEmpleadoMov> ListarTablaTbEmpleado(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, string strTerminal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string nombreDelSp)
        {
            List<TbEmpleadoMov> lista = new List<TbEmpleadoMov>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TBEMPLEADO_MOVIL_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                nombreDelSp = cmd.CommandText;
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                //---------------------------------------------------------
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@strTerminal", strTerminal);
                //---------------------------------------------------------
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TbEmpleadoMov obj = new TbEmpleadoMov();

                    if (!reader.IsDBNull(0))
                    {
                        obj.intIdEmpleado = reader.GetInt32(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        obj.intIdLocal = reader.GetInt32(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        obj.intIdArea = reader.GetInt32(2);
                    }
                    if (!reader.IsDBNull(3))
                    {
                        obj.strCodEmpleado = reader.GetString(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        obj.strDescEmpleado = reader.GetString(4);
                    }

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        //13.4 TBENTIDAD - MOVIL
        public List<TbEntidadMov> ListarTablaTbEntidad(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, string strTerminal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string nombreDelSp)
        {
            List<TbEntidadMov> lista = new List<TbEntidadMov>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TBENTIDAD_MOVIL_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                nombreDelSp = cmd.CommandText;
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                //---------------------------------------------------------
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@strTerminal", strTerminal);
                //---------------------------------------------------------
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TbEntidadMov obj = new TbEntidadMov();

                    if (!reader.IsDBNull(0))
                    {
                        obj.intIdEntidad = reader.GetInt32(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        obj.strCodEntidad = reader.GetString(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        obj.strDescEntidad = reader.GetString(2);
                    }

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        //13.5 TBLOCAL - MOVIL
        public List<TbLocalMov> ListarTablaTbLocal(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, string strTerminal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string nombreDelSp)
        {
            List<TbLocalMov> lista = new List<TbLocalMov>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TBLOCAL_MOVIL_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                nombreDelSp = cmd.CommandText;
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                //---------------------------------------------------------
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@strTerminal", strTerminal);
                //---------------------------------------------------------
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TbLocalMov obj = new TbLocalMov();

                    if (!reader.IsDBNull(0))
                    {
                        obj.intIdLocal = reader.GetInt32(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        obj.strCodLocal = reader.GetString(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        obj.strDescLocal = reader.GetString(2);
                    }

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        //13.6 TBAREAS - MOVIL
        public List<TbAreasMov> ListarTablaTbAreas(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, string strTerminal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string nombreDelSp)
        {
            List<TbAreasMov> lista = new List<TbAreasMov>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TBAREAS_MOVIL_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                nombreDelSp = cmd.CommandText;
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                //---------------------------------------------------------
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@strTerminal", strTerminal);
                //---------------------------------------------------------
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TbAreasMov obj = new TbAreasMov();

                    if (!reader.IsDBNull(0))
                    {
                        obj.intIdArea = reader.GetInt32(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        obj.intIdLocal = reader.GetInt32(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        obj.strCodArea = reader.GetString(2);
                    }
                    if (!reader.IsDBNull(3))
                    {
                        obj.strDescArea = reader.GetString(3);
                    }

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        //13.7 TBESTADO - MOVIL
        public List<TbEstadoMov> ListarTablaTbEstado(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, string strTerminal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string nombreDelSp)
        {
            List<TbEstadoMov> lista = new List<TbEstadoMov>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TBESTADO_MOVIL_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                nombreDelSp = cmd.CommandText;
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                //---------------------------------------------------------
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@strTerminal", strTerminal);
                //---------------------------------------------------------
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TbEstadoMov obj = new TbEstadoMov();

                    if (!reader.IsDBNull(0))
                    {
                        obj.intIdEstado = reader.GetInt32(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        obj.strCodEstado = reader.GetString(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        obj.strDescEstado = reader.GetString(2);
                    }

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        //13.8 TBTIPO - MOVIL
        public List<TbTipoMov> ListarTablaTbTipo(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, string strTerminal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string nombreDelSp)
        {
            List<TbTipoMov> lista = new List<TbTipoMov>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TBTIPO_MOVIL_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                nombreDelSp = cmd.CommandText;
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                //---------------------------------------------------------
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@strTerminal", strTerminal);
                //---------------------------------------------------------
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TbTipoMov obj = new TbTipoMov();

                    if (!reader.IsDBNull(0))
                    {
                        obj.intIdTipo = reader.GetInt32(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        obj.strCodTipo = reader.GetString(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        obj.strDescTipo = reader.GetString(2);
                    }

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }


        //16.1 //TbParamsMovil   //ListarTablaTbTipo //ListarParametrosMovil
        public List<TbParamsMovil> ListarParametrosMovil(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, /*string strTerminal,*/ ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string nombreDelSp)
        {
            List<TbParamsMovil> lista = new List<TbParamsMovil>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TBPARAMS_MOVIL_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                nombreDelSp = cmd.CommandText;
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                //---------------------------------------------------------
                param.Add("@intIdUsuario", intIdUsuario);
                //param.Add("@strTerminal", strTerminal);
                //---------------------------------------------------------
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TbParamsMovil obj = new TbParamsMovil();

                    if (!reader.IsDBNull(0))
                    {
                        obj.prmSalidaApp = reader.GetString(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        obj.prmAddOfic = reader.GetString(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        obj.prmAddResp = reader.GetString(2);
                    }
                    if (!reader.IsDBNull(3))
                    {
                        obj.prmFilUbica = reader.GetString(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        obj.prmOpcOpera = reader.GetString(4);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        obj.prmAreaxLocal = reader.GetString(5);
                    }
                    if (!reader.IsDBNull(6))
                    {
                        obj.prmModaTrab = reader.GetString(6);
                    }
                    if (!reader.IsDBNull(7))
                    {
                        obj.prmOutExcelxLocal = reader.GetString(7);
                    }
                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }


        //16.2 ---> TbConceptosMovil   ---> ListarConceptosMovil()
        public List<TbConceptosMovil> ListarConceptosMovil(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string nombreDelSp)
        {
            List<TbConceptosMovil> lista = new List<TbConceptosMovil>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSCONCEPTO_MOVIL_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                nombreDelSp = cmd.CommandText;
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                //---------------------------------------------------------
                param.Add("@intIdUsuario", intIdUsuario);
                //---------------------------------------------------------
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TbConceptosMovil obj = new TbConceptosMovil();

                    if (!reader.IsDBNull(0))
                    {
                        obj.cptActivo = reader.GetString(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        obj.cptDescripcion = reader.GetString(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        obj.cptLocal = reader.GetString(2);
                    }
                    if (!reader.IsDBNull(3))
                    {
                        obj.cptArea = reader.GetString(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        obj.cptOficina = reader.GetString(4);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        obj.cptAnterior = reader.GetString(5);
                    }
                    if (!reader.IsDBNull(6))
                    {
                        obj.cptResponsable = reader.GetString(6);
                    }
                    if (!reader.IsDBNull(7))
                    {
                        obj.cptEstado = reader.GetString(7);
                    }
                    if (!reader.IsDBNull(8))
                    {
                        obj.cptMarca = reader.GetString(8);
                    }
                    if (!reader.IsDBNull(9))
                    {
                        obj.cptModelo = reader.GetString(9);
                    }

                    //-----------------------------------------------
                    if (!reader.IsDBNull(10))
                    {
                        obj.cptTipo = reader.GetString(10);
                    }
                    if (!reader.IsDBNull(11))
                    {
                        obj.cptColor = reader.GetString(11);
                    }
                    if (!reader.IsDBNull(12))
                    {
                        obj.cptSerie = reader.GetString(12);
                    }
                    if (!reader.IsDBNull(13))
                    {
                        obj.cptNumMotor = reader.GetString(13);
                    }
                    if (!reader.IsDBNull(14))
                    {
                        obj.cptNumChasis = reader.GetString(14);
                    }
                    if (!reader.IsDBNull(15))
                    {
                        obj.cptAnio = reader.GetString(15);
                    }
                    if (!reader.IsDBNull(16))
                    {
                        obj.cptDimension = reader.GetString(16);
                    }
                    if (!reader.IsDBNull(17))
                    {
                        obj.cptPlaca = reader.GetString(17);
                    }
                    if (!reader.IsDBNull(18))
                    {
                        obj.cptObservacion = reader.GetString(18);
                    }

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }


        public List<RstaValidPersonalEntity> ValidarPersonaAcceso(string strNumDocumento, string dtHoraMarca, string dtFechaMarca, string strTerminal, string strTipoAcceso)
        {
            List<RstaValidPersonalEntity> lista = new List<RstaValidPersonalEntity>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPERSONAL_MOVIL_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@strNumDocumento", strNumDocumento);
                param.Add("@dtHoraMarca", dtHoraMarca);
                param.Add("@dtFechaMarca", dtFechaMarca);
                param.Add("@strTerminal", strTerminal);
                param.Add("@strTipoAcceso", strTipoAcceso);
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RstaValidPersonalEntity obj = new RstaValidPersonalEntity();

                    obj.intEstado = reader.GetInt32(0);
                    obj.strMensaje = reader.GetString(1);
                    obj.strNombres = reader.GetString(2);
                    obj.strApePaterno = reader.GetString(3);
                    obj.strApeMaterno = reader.GetString(4);
                    obj.strIdPersonal = reader.GetString(5);
                    //18012021
                    obj.bitFoto = reader.GetInt32(6);

                    lista.Add(obj);

                }
                reader.Close();
            }
            return lista;
        }

        public List<RstaInsertMarcaEntity> InsertarMarcaAcceso(string strNumDocumento, string strTipoAcceso, string dtHoraMarca, string dtFechaMarca, string strTerminal, string strFotoAcceso, string strReporte_dir, string strDireccion)
        {
            List<RstaInsertMarcaEntity> lista = new List<RstaInsertMarcaEntity>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TAASISTENCIA_MOVIL_I01", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                //byte[] byteFoto = Encoding.ASCII.GetBytes(strFotoAcceso);
                //cmd.Parameters.Add("IMAGEN", SqlDbType.VarBinary).Value = imagen;

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@strNumDocumento", strNumDocumento);
                param.Add("@strTipoAcceso", strTipoAcceso);
                param.Add("@dtHoraMarca", dtHoraMarca);
                param.Add("@dtFechaMarca", dtFechaMarca);
                param.Add("@strTerminal", strTerminal);
                param.Add("@strFotoAcceso", strFotoAcceso);
                param.Add("@strReporte_dir", strReporte_dir);
                param.Add("@strDireccion", strDireccion);
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RstaInsertMarcaEntity obj = new RstaInsertMarcaEntity();

                    obj.strMensaje = reader.GetString(0);
                    obj.iEstado = reader.GetInt32(1);
                    obj.idAsistencia = reader.GetInt32(2);

                    lista.Add(obj);

                }
                reader.Close();
            }
            return lista;
        }

        public List<RstaInsertImgEntity> InsertarImagenAcceso(int intIdAsistencia, string strFotoAcceso)
        {
            List<RstaInsertImgEntity> lista = new List<RstaInsertImgEntity>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TAASISTENCIA_MOVIL_U01", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                string strRutaArchivos = ConfigurationManager.AppSettings["RutaArchivos"];
                byte[] imgPrueba = File.ReadAllBytes(strRutaArchivos + strFotoAcceso + ".jpg");
                string rutaFota = strRutaArchivos + strFotoAcceso + ".jpg";

                //************
                string encoded = Convert.ToBase64String(imgPrueba);
                //************

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdAsistencia", intIdAsistencia);
                param.Add("@strFotoAcceso", imgPrueba);
                param.Add("@strRutaFoto", rutaFota);

                param.Add("@strFotoAcceso2", encoded);

                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RstaInsertImgEntity obj = new RstaInsertImgEntity();

                    obj.strMensaje = reader.GetString(0);
                    obj.intEstado = reader.GetInt32(1);

                    lista.Add(obj);

                }
                reader.Close();
            }
            return lista;
        }

        public List<RstaListMarcaEntity> ListarMarcasAcceso(string strTerminal, string strFotocheck, string strFecha)
        {
            List<RstaListMarcaEntity> lista = new List<RstaListMarcaEntity>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGLISTMARCA_MOVIL_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@strTerminal", strTerminal);
                param.Add("@strFotocheck", strFotocheck);
                param.Add("@fecha_filtro", strFecha);
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                //var dataTable = new DataTable();
                //dataTable.Load(reader);

                //byte[] a = (byte[])dataTable.Rows[0]["foto"];
                ////byte[] a = Encoding.ASCII.GetBytes(dataTable.Rows[0]["foto"].ToString());

                //string strFoto = Convert.ToBase64String(a, 0, a.Length,
                //                Base64FormattingOptions.InsertLineBreaks);
                while (reader.Read())//reader.Read()
                {
                    RstaListMarcaEntity obj = new RstaListMarcaEntity();
                    // byte[] yaps = reader.GetSqlBytes(8).Buffer; ;

                    //byte[] b = source.ToArray();
                    //MemoryStream ms = new MemoryStream(b);
                    //Image img = Image.FromStream(ms);
                    //return img.Source.ToString();

                    //string stringFromSQL = "0x6100730064006600";
                    //List<byte> byteList = new List<byte>();

                    //string hexPart = reader.GetString(8).Substring(2);
                    //for (int i = 0; i < hexPart.Length / 2; i++)
                    //{
                    //    string hexNumber = hexPart.Substring(i * 2, 2);
                    //    byteList.Add((byte)Convert.ToInt32(hexNumber, 16));
                    //}

                    //byte[] original = byteList.ToArray();

                    obj.idpersonal = reader.GetString(0);
                    obj.fotocheck = reader.GetString(1);
                    obj.tipo_acceso = reader.GetString(2);
                    obj.Num_marcador = reader.GetString(3);
                    obj.hora = reader.GetString(4);
                    obj.fecha = reader.GetString(5);
                    obj.personal = reader.GetString(6);
                    obj.estado = reader.GetString(7);
                    obj.foto = reader.GetString(8);
                    //obj.foto = yaps;
                    //obj.fotoConverted = strFoto;

                    lista.Add(obj);

                }
                reader.Close();

            }
            return lista;
        }

        public string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public List<RstaListaCoordEntity> ListarCoordAcceso(int intIdPersonal)
        {
            List<RstaListaCoordEntity> lista = new List<RstaListaCoordEntity>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TGLISTCOORD_MOVIL_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdPersonal", intIdPersonal);
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RstaListaCoordEntity obj = new RstaListaCoordEntity();

                    obj.idPersonal = reader.GetInt32(0);
                    obj.bitFlGeoArea = reader.GetInt32(1);
                    obj.MINI = reader.GetDecimal(2);
                    obj.MAXI = reader.GetDecimal(3);

                    lista.Add(obj);

                }
                reader.Close();

            }
            return lista;
        }

        public List<RstaConexion> ValidarConexionAcceso()
        {
            List<RstaConexion> lista = new List<RstaConexion>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_VALIDAR_CONEXION_Movil", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RstaConexion obj = new RstaConexion();

                    obj.estado = reader.GetString(0);
                    obj.mensaje = reader.GetString(1);

                    lista.Add(obj);

                }
                reader.Close();

            }
            return lista;
        }

        public List<RstaListConceptos> ListarConceptosAcceso(string strFotocheck, string strfiltro_fech, string strSerie)
        {
            List<RstaListConceptos> lista = new List<RstaListConceptos>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_CONCEPTO_DET_Movil_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@strFoctocheck", strFotocheck);
                param.Add("@filtro_fech", strfiltro_fech);
                param.Add("@strSerie", strSerie);
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RstaListConceptos obj = new RstaListConceptos();

                    obj.intIdPerConcepto = reader.GetInt32(0);
                    obj.strEmpleado = reader.GetString(1);
                    obj.strEmpleadoLista = reader.GetString(2);
                    obj.rangoHora = reader.GetString(3);
                    obj.strCoConcepto = reader.GetString(4);
                    obj.strDesConcepto = reader.GetString(5);
                    obj.dttFecha = reader.GetString(6);
                    obj.strDeTipo = reader.GetString(7);
                    obj.intIdConcepto = reader.GetInt32(8);

                    lista.Add(obj);

                }
                reader.Close();

            }
            return lista;
        }

        public List<RstaListComboConcepto> ListarComboConceptosAcceso(string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo)
        {
            List<RstaListComboConcepto> lista = new List<RstaListComboConcepto>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGLISTAR_COMBOS_Movil_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@strEntidad", strEntidad);
                param.Add("@intIdFiltroGrupo", intIdFiltroGrupo);
                param.Add("@strGrupo", strGrupo);
                param.Add("@strSubGrupo", strSubGrupo);
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RstaListComboConcepto obj = new RstaListComboConcepto();

                    obj.intIdConcepto = reader.GetInt32(0);
                    obj.strDesConcepto = reader.GetString(1);
                    obj.strCoTipo = reader.GetString(2);
                    obj.bitFlDescontable = reader.GetInt32(3);

                    lista.Add(obj);

                }
                reader.Close();

            }
            return lista;
        }

        public List<RstaListComboSustenta> ListarComboSustentaAcceso(string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo)
        {
            List<RstaListComboSustenta> lista = new List<RstaListComboSustenta>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGLISTAR_COMBOS_Movil_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@strEntidad", strEntidad);
                param.Add("@intIdFiltroGrupo", intIdFiltroGrupo);
                param.Add("@strGrupo", strGrupo);
                param.Add("@strSubGrupo", strSubGrupo);
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RstaListComboSustenta obj = new RstaListComboSustenta();

                    obj.intIdEntidad = reader.GetInt32(0);
                    obj.strDeEntidad = reader.GetString(1);

                    lista.Add(obj);

                }
                reader.Close();

            }
            return lista;
        }

        public List<RstaInsertConcepto> InsertaConceptoAcceso(string strTerminal, string strFotocheck, string strDeConcepto, string strFecIni, string strFecFin,
                            string strHoraIni, string strHoraFin, string strObs, int intEspeValorada, int bitSustentado, string strCitt, string strEmitEn, string strEmitPor, int intDiaSgtIni, int intDiaSgtFin, string strNomFoto)
        {
            List<RstaInsertConcepto> lista = new List<RstaInsertConcepto>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_CONCEPTO_DET__Movil_I01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                string rutaFota = "";
                if (strNomFoto != "")
                {
                    string strRutaArchivos = ConfigurationManager.AppSettings["RutaFotoPermiso"];
                    rutaFota = strRutaArchivos;
                    //string strFotoPermiso = strNomFoto + ".jpg";
                }


                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@strTerminal", strTerminal);
                param.Add("@strFotocheck", strFotocheck);
                param.Add("@strDeConcepto", strDeConcepto);
                param.Add("@strFecIni", strFecIni);
                param.Add("@strFecFin", strFecFin);
                param.Add("@strHoraIni", strHoraIni);
                param.Add("@strHoraFin", strHoraFin);
                param.Add("@strObs", strObs);
                param.Add("@intEspeValorada", intEspeValorada);
                param.Add("@bitSustentado", bitSustentado);
                param.Add("@strCitt", strCitt);
                param.Add("@strEmitEn", strEmitEn);
                param.Add("@strEmitPor", strEmitPor);
                param.Add("@intDiaSgtIni", intDiaSgtIni);
                param.Add("@intDiaSgtFin", intDiaSgtFin);
                param.Add("@strNomFoto", strNomFoto);
                param.Add("@strRutaFoto", rutaFota);
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RstaInsertConcepto obj = new RstaInsertConcepto();

                    obj.strRespuesta = reader.GetString(0);

                    lista.Add(obj);

                }
                reader.Close();

            }
            return lista;
        }

        public List<RstaDeleteConcepto> EliminarPapeletaAcceso(int intIdPerConcepto)
        {
            List<RstaDeleteConcepto> lista = new List<RstaDeleteConcepto>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_CONCEPTO_DET_Movil_D01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdPerConcepto", intIdPerConcepto);
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RstaDeleteConcepto obj = new RstaDeleteConcepto();

                    obj.strRespuesta = reader.GetString(0);

                    lista.Add(obj);

                }
                reader.Close();

            }
            return lista;
        }

    }
}
