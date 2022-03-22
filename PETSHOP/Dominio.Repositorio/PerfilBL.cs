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
    public class PerfilBL
    {
        private PerfilDAO objPerfil = new PerfilDAO();

        #region Mant. Perfil
        //3.2
        public List<TS_PERFIL> ListarPerfil(long intIdSesion, int intIdMenu, int intIdSoft, int intActivo, string strDescripcion, ref string strMsjUsuario)
        {
            List<TS_PERFIL> lista = new List<TS_PERFIL>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objPerfil.ListarPerfil(intIdSesion, intIdMenu, intIdSoft, intActivo, strDescripcion, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarPerfil] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PerfilBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarPerfil)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PerfilBL.cs: Exception");
                throw new Exception("Error General (ListarPerfil)");
            }
            return lista;
        }
        //3.3
        public List<TS_MENU> ListarMenuSubMenus(long intIdSesion, int intIdMenu, int intIdSoft, int intActivo, string strDescripcion, ref string strMsjUsuario)
        {
            List<TS_MENU> lista = new List<TS_MENU>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objPerfil.ListarMenuSubMenus(intIdSesion, intIdMenu, intIdSoft, intActivo, strDescripcion, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarMenuSubMenus] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PerfilBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarMenuSubMenus)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PerfilBL.cs: Exception");
                throw new Exception("Error General (ListarMenuSubMenus)");
            }
            return lista;
        }
        //3.4 IUPerfil_T
        public bool InsertarOrUpdatePerfil(long intIdSesion, int intIdMenu, int intIdSoft, TS_PERFIL objDatos, List<TT_TSPERFIL_MENU> listaDetallesPerfil, int intIdUsuario, int intTipoOperacion, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";
                string Msj = "";

                int Rpta = objPerfil.IUPerfil_T(intIdSesion, intIdMenu, intIdSoft, objDatos, intIdUsuario, intTipoOperacion, listaDetallesPerfil,ref intResult, ref strMsjDB, ref strMsjUsuario, ref Msj);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[InsertarOrUpdatePerfil] => Respuesta del Procedimiento : " + strMsjDB);
                        Log.AlmacenarLogMensaje("[InsertarOrUpdatePerfil] => Respuesta de la clase de Datos: " + Msj);
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
                Log.AlmacenarLogError(ex, "PerfilBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (InsertarOrUpdatePerfil)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PerfilBL.cs: Exception");
                throw new Exception("Error General (InsertarOrUpdatePerfil)");
            }
        }
        //3.5
        public bool EliminarPerfil(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdPerfil, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objPerfil.EliminarPerfil(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdPerfil, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminarPerfil] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PerfilBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminarPerfil)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PerfilBL.cs: Exception");
                throw new Exception("Error General (EliminarPerfil)");
            }
        }
        //3.6
        public List<TS_PERFIL> ObtenerRegistroPerfil(long intIdSesion, int intIdMenu, int intIdSoft, int IntIdPerfil, ref string strMsjUsuario)
        {
            List<TS_PERFIL> lista = new List<TS_PERFIL>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objPerfil.ObtenerRegistroPerfil(intIdSesion, intIdMenu, intIdSoft, IntIdPerfil, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerRegistroPerfil] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PerfilBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerRegistroPerfil)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PerfilBL.cs: Exception");
                throw new Exception("Error General (ObtenerRegistroPerfil)");
            }
            return lista;
        }

        #endregion Mant. Perfil
       //3.19
        public List<TS_MENU_PADRE> MenuPorUsuario(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuar, int intIdPerfil, ref string strMsjUsuario)
        {
            List<TS_MENU> lista = new List<TS_MENU>();
            List<TS_MENU_PADRE> listaMenu = new List<TS_MENU_PADRE>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objPerfil.MenuPorUsuario(intIdSesion, intIdMenu, intIdSoft, intIdUsuar, intIdPerfil, ref intResult, ref strMsjDB, ref strMsjUsuario);

                var padre = "";
                TS_MENU_PADRE padreMenu = new TS_MENU_PADRE();
                //obtengo el ultimo registro
                TS_MENU ultimo = lista.Last();

                foreach (TS_MENU element in lista)
                {
                    if (padre == "")
                    {
                        padre = element.strNomMenu;
                        padreMenu = new TS_MENU_PADRE();
                        List<TS_MENU> listaMenuHijo = new List<TS_MENU>();
                        padreMenu.menu = listaMenuHijo;
                        padreMenu.strMenu = padre;
                        padreMenu.strNomFormu = element.strNomFormu;

                        //Añadido HGM 13.07.21
                        padreMenu.strCoMenuRela = element.strCoMenuRela;
                    }
                    else if (padre != element.strNomMenu)
                    {
                        //se agrega el menu a la lista antes de crear otro
                        listaMenu.Add(padreMenu);

                        padre = element.strNomMenu;
                        padreMenu = new TS_MENU_PADRE();
                        List<TS_MENU> listaMenuHijo = new List<TS_MENU>();
                        padreMenu.menu = listaMenuHijo;
                        padreMenu.strMenu = padre;
                        padreMenu.strNomFormu = element.strNomFormu;

                        //Añadido HGM 13.07.21
                        padreMenu.strCoMenuRela = element.strCoMenuRela;
                    }

                    TS_MENU obj = new TS_MENU();
                    obj.intIdMenu = element.intIdMenu;
                    obj.strCoMenu = element.strCoMenu;
                    obj.strSubMenu = element.strSubMenu;
                    obj.strCoMenuRela = element.strCoMenuRela;
                    obj.strNomMenu = element.strNomMenu;
                    obj.intIsSelecc = element.intIsSelecc;
                    obj.strDesFormu = element.strDesFormu;

                    padreMenu.menu.Add(obj);

                    //se valida si es el ultimo ciclo del foreach para agregar el menu
                    if (element == ultimo)
                    {
                        //se agrega el menu a la lista
                        listaMenu.Add(padreMenu);
                    }

                }

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[MenuPorUsuario] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PerfilBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (MenuPorUsuario)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PerfilBL.cs: Exception");
                throw new Exception("Error General (MenuPorUsuario)");
            }
            return listaMenu;
        }

    }
}
