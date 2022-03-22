using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TablasGenerarTxt
    {

         [DataMember] public string Activo          { get; set; }
         [DataMember] public string Descripcion     { get; set; }
         [DataMember] public string Anterior        { get; set; }
         [DataMember] public string CodLocal        { get; set; }
         [DataMember] public string CodArea         { get; set; }
         [DataMember] public string CodOficina      { get; set; }
         [DataMember] public string CodResponsable  { get; set; }
         [DataMember] public string CodEstado       { get; set; }
         [DataMember] public string Marca           { get; set; }
         [DataMember] public string Modelo          { get; set; }
         [DataMember] public string Serie           { get; set; }
         [DataMember] public string CodTipo         { get; set; }
         [DataMember] public string Color           { get; set; }
         [DataMember] public string Anio            { get; set; }
         [DataMember] public string NumMotor        { get; set; }
         [DataMember] public string NumChasis       { get; set; }
         [DataMember] public string Dimension       { get; set; }
         [DataMember] public string Placa           { get; set; }
         [DataMember] public string Observacion     { get; set; }

         //
         [DataMember] public string FecCreacion     { get; set; }
         [DataMember] public string FecModificacion { get; set; }
         [DataMember] public string NumPda          { get; set; }
         [DataMember] public string FlgInventario   { get; set; }

         //TBBIENESDS
         [DataMember] public string DesLocal        { get; set; }
         [DataMember] public string DesArea         { get; set; }
         [DataMember] public string DesOficina      { get; set; }
         [DataMember] public string DesEmpleado     { get; set; }
         [DataMember] public string DesEstado       { get; set; }
                        
         //
         [DataMember] public string DesTipo         { get; set; }
         [DataMember] public string CodEntidad      { get; set; }
         [DataMember] public string DesEntidad      { get; set; }
         [DataMember] public string IntIdLocal      { get; set; }








        




        ////TBOFICINA
        //[DataMember] public string strDescOficina { get; set; }

        ////TBDESCRIPCION
        //[DataMember] public string strDescEmpleado { get; set; }


        //Activo
        //Descripcion
        //Anterior
        //CodLocal
        //CodArea
        //CodOficina
        //CodEmpleado--
        //CodEstado
        //Marca
        //Modelo
        //Serie
        //CodTipo
        //Color
        //Anio
        //NumMotor
        //NumChasis
        //Dimension
        //Placa
        //Observacion

        //DesLocal
        //DesArea
        //DesOficina
        //DesEmpleado
        //DesEstado]





    }
}
