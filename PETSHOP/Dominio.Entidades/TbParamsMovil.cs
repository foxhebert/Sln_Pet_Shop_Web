using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TbParamsMovil
    {
            //MODELO DE TBPARAMS
            [DataMember] public string prmSalidaApp        { get; set; }    
            [DataMember] public string prmAddOfic          { get; set; }
            [DataMember] public string prmAddResp          { get; set; }
            [DataMember] public string prmFilUbica         { get; set; }
            [DataMember] public string prmOpcOpera         { get; set; }
            [DataMember] public string prmAreaxLocal       { get; set; }
            [DataMember] public string prmModaTrab         { get; set; }
            [DataMember] public string prmOutExcelxLocal   { get; set; }

            /*---------------------------------------------------------------
            [DataMember] public string prmImpresora 	   { get; set; } 
            [DataMember] public string strEmailDestino	   { get; set; }
            [DataMember] public string strServidor     	   { get; set; }
            [DataMember] public string strBaseDatos    	   { get; set; }
            [DataMember] public string strUsuario      	   { get; set; }
            [DataMember] public string strContrasenia  	   { get; set; }
            [DataMember] public string strAutenticacion	   { get; set; }
            [DataMember] public string strDirExcelCarga	   { get; set; }
            [DataMember] public string strExcelGenerado	   { get; set; }
            ---------------------------------------------------------------*/


    }
}
 