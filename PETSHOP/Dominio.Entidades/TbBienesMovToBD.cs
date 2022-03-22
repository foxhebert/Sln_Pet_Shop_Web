using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TbBienesMovToBD
    {
        //MODELO DE TBBIENES MOVIL TO BD
        [DataMember] public int    intIdActivo        { get; set; }
        [DataMember] public string strDescripcion     { get; set; }
        [DataMember] public string strCodActivo       { get; set; }
        [DataMember] public int    intIdLocal         { get; set; }
        [DataMember] public int    intIdArea          { get; set; }
        [DataMember] public int    intIdOficina       { get; set; }
        [DataMember] public string strCodAnterior     { get; set; }
        [DataMember] public int    intIdResponsable   { get; set; }
        [DataMember] public int    intIdEstado        { get; set; }
        [DataMember] public string strDescMarca       { get; set; }//10

        [DataMember] public string strDescModelo      { get; set; }
        [DataMember] public int    intIdTipo          { get; set; }
        [DataMember] public string strDescColor       { get; set; }
        [DataMember] public string strDescSerie       { get; set; }
        [DataMember] public string strDescNumMotor    { get; set; }
        [DataMember] public string strDescNumChasis   { get; set; }
        [DataMember] public int    intAnio            { get; set; }
        [DataMember] public string strDescDimension   { get; set; }
        [DataMember] public string strDescPlaca       { get; set; }
        [DataMember] public string strDescObservacion { get; set; }//20

        [DataMember] public string strFlag            { get; set; }
        [DataMember] public string strPda             { get; set; }
        //[DataMember] public string dttFeCrea        { get; set; }
        //[DataMember] public string dttFeModi        { get; set; }
        [DataMember] public DateTime dttFeCrea        { get; set; }
        [DataMember] public DateTime dttFeModi        { get; set; }
        [DataMember] public string strEtiqueta      { get; set; }//25

        //[DataMember] public DateTime? dttFeModif { get; set; }   obj.dttFeModif

    }
}