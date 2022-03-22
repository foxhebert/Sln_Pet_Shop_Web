using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TbConceptosMovil
    {
            //MODELO DE TBCONCEPTO
            [DataMember] public string cptActivo       { get; set; } 
            [DataMember] public string cptDescripcion  { get; set; } 
            [DataMember] public string cptLocal        { get; set; } 
            [DataMember] public string cptArea         { get; set; } 
            [DataMember] public string cptOficina      { get; set; } 
            [DataMember] public string cptAnterior     { get; set; } 
            [DataMember] public string cptResponsable  { get; set; } 
            [DataMember] public string cptEstado       { get; set; } 
            [DataMember] public string cptMarca        { get; set; } 
            [DataMember] public string cptModelo       { get; set; } 

            [DataMember] public string cptTipo         { get; set; } 
            [DataMember] public string cptColor        { get; set; } 
            [DataMember] public string cptSerie        { get; set; } 
            [DataMember] public string cptNumMotor     { get; set; } 
            [DataMember] public string cptNumChasis    { get; set; } 
            [DataMember] public string cptAnio         { get; set; } 
            [DataMember] public string cptDimension    { get; set; } 
            [DataMember] public string cptPlaca        { get; set; } 
            [DataMember] public string cptObservacion  { get; set; }


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
 