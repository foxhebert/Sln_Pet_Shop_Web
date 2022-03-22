using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TablasExcelsConDataSQL
    {

        //TBBIENES
        [DataMember] public string intIdActivo           { get; set; }
        [DataMember] public string strDescripcion        { get; set; }
        [DataMember] public string strCodActivo          { get; set; }
        //[DataMember] public string intIdLocal            { get; set; }
        //[DataMember] public string intIdArea             { get; set; }
        //[DataMember] public string intIdOficina          { get; set; }
        [DataMember] public string strCodAnterior        { get; set; }
        [DataMember] public string intIdResponsable      { get; set; }
        //[DataMember] public string intIdEstado           { get; set; }
        [DataMember] public string strDescMarca          { get; set; }
        [DataMember] public string strDescModelo         { get; set; }
        //[DataMember] public string intIdTipo             { get; set; }
        [DataMember] public string strDescColor          { get; set; }
        [DataMember] public string strDescSerie          { get; set; }
        [DataMember] public string strDescNumMotor       { get; set; }
        [DataMember] public string strDescNumChasis      { get; set; }
        [DataMember] public string intAnio               { get; set; }
        [DataMember] public string strDescDimension      { get; set; }
        [DataMember] public string strDescPlaca          { get; set; }
        [DataMember] public string strDescObservacion    { get; set; }
        [DataMember] public string strFlag               { get; set; }
        [DataMember] public string strPda                { get; set; }
        [DataMember] public string dttFeCrea             { get; set; }
        [DataMember] public string dttFeModi             { get; set; }
        [DataMember] public string strEtiqueta           { get; set; }

        //OFICINA       
        [DataMember] public string intIdOficina	         { get; set; }
        //[DataMember] public string intIdLocal	         { get; set; }
        //[DataMember] public string intIdArea	         { get; set; }
        [DataMember] public string strCodOficina	     { get; set; }
        [DataMember] public string strDescOficina        { get; set; }

        //EMPLEADO             
        [DataMember] public string intIdEmpleado         { get; set; }
        //[DataMember] public string intIdLocal            { get; set; }
        //[DataMember] public string intIdArea             { get; set; }
        [DataMember] public string strCodEmpleado        { get; set; }
        [DataMember] public string strDescEmpleado       { get; set; }

        //LOCAL                
        [DataMember] public string intIdLocal            { get; set; }
        [DataMember] public string strCodLocal           { get; set; }
        [DataMember] public string strDescLocal          { get; set; }

        //AREA                
        [DataMember] public string intIdArea             { get; set; }
        //[DataMember] public string intIdLocal            { get; set; }
        [DataMember] public string strCodArea            { get; set; }
        [DataMember] public string strDescArea           { get; set; }

        //ESTADO              
        [DataMember] public string intIdEstado           { get; set; }
        [DataMember] public string strCodEstado          { get; set; }
        [DataMember] public string strDescEstado         { get; set; }

        //TIPO            
        [DataMember] public string intIdTipo             { get; set; }
        [DataMember] public string strCodTipo            { get; set; }
        [DataMember] public string strDescTipo           { get; set; }

        //ENTIDAD         
        [DataMember] public string intIdEntidad          { get; set; }
        [DataMember] public string strCodEntidad         { get; set; }
        [DataMember] public string strDescEntidad        { get; set; }



    }
}
