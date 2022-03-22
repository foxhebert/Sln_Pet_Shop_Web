using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
    public class TablasEnCombos
    {

        //MODELO DE TBLOCAL      
        [DataMember] public int    intIdLocal   { get; set; }
        [DataMember] public string strCodLocal  { get; set; }
        [DataMember] public string strDescLocal { get; set; }    
        //MODELO DE TBAREAS     
        [DataMember] public int    intIdArea   { get; set; }
        //[DataMember] public int    intIdLocal  { get; set; }
        [DataMember] public string strCodArea  { get; set; }
        [DataMember] public string strDescArea { get; set; }  
        //MODELO DE TBOFICINA       
        [DataMember] public int    intIdOficina   { get; set; }
        //[DataMember] public int    intIdLocal     { get; set; }
        //[DataMember] public int    intIdArea      { get; set; }
        [DataMember] public string strCodOficina  { get; set; }
        [DataMember] public string strDescOficina { get; set; }
        //MODELO DE TBEMPLEADO       
        [DataMember] public int    intIdEmpleado       { get; set; }
        //[DataMember] public int    intIdLocal          { get; set; }
        //[DataMember] public int    intIdArea           { get; set; }  
        [DataMember] public string strCodEmpleado      { get; set; }
        [DataMember] public string strDescEmpleado     { get; set; }
        //MODELO DE TBTIPO
        [DataMember] public int    intIdTipo   { get; set; }
        [DataMember] public string strCodTipo  { get; set; }
        [DataMember] public string strDescTipo { get; set; }


        //GENERAL
        [DataMember] public int    intIdEntidad { get; set; }
        [DataMember] public string strDeEntidad { get; set; }

    }
}
