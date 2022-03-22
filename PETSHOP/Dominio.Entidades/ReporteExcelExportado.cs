using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
    public class ReporteExcelExportado
    {
        

        //MODELO DE TBBIENES PARA REPORTE CRYSTALREPORT
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
        [DataMember] public string   strEtiqueta        { get; set; }//25





        ////[DataMember] public int     IdPersonal   { get; set; }
        ////[DataMember] public string  Cod_Personal { get; set; }
        ////[DataMember] public string  Persona      { get; set; }
        ////[DataMember] public string  Fotochek     { get; set; }
        ////[DataMember] public string  Dsc_Empresa  { get; set; }
        ////[DataMember] public string  Ruc          { get; set; }
        ////[DataMember] public DateTime?  rHora        { get; set; }
        ////[DataMember] public string  sDesServicio { get; set; }
        ////[DataMember] public int     NumConsumos  { get; set; }
        ////[DataMember] public decimal dcCosto      { get; set; }
        ////[DataMember] public string  Moneda       { get; set; }
        ////[DataMember] public DateTime DTTFecha { get; set; } //11.03.2021
        ////[DataMember] public decimal dcSubsidiado { get; set; } //11.03.2021


    }
}
