using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
    public class Consumo
    {
        [DataMember] public int     intIdConsumo    { get; set; } //int
        [DataMember] public int     intIdAsistencia { get; set; } //int
        [DataMember] public int     intIdPersonal   { get; set; } //int
        [DataMember] public string  strFotocheck    { get; set; } //varchar
        [DataMember] public string  strNombres      { get; set; } //varchar
        [DataMember] public string  strApePaterno   { get; set; } //varchar 
        [DataMember] public int     intIdReglaNeg   { get; set; } //int
        [DataMember] public string  dttHora         { get; set; } //
        [DataMember] public string  dttFecha        { get; set; } //varchar
        [DataMember] public string  dttFechaHora    { get; set; } //varchar
        [DataMember] public int     intIdServicio   { get; set; } //int
        [DataMember] public int     intIdTipServ    { get; set; } //int
        [DataMember] public int     intCantidad     { get; set; } //
        [DataMember] public decimal monCostoServ    { get; set; } //
        [DataMember] public int     bitFlConsumido  { get; set; } //
        [DataMember] public string  strObservacion  { get; set; } //
        [DataMember] public bool    bitFlEliminado  { get; set; } //
        [DataMember] public int     intIdUsuarReg   { get; set; } //
        [DataMember] public string  dttFeRegistro   { get; set; } //
        [DataMember] public int     intIdUsuarModif { get; set; } //
        [DataMember] public string  dttFeModif      { get; set; } //
        [DataMember] public bool    bitFlCancelado  { get; set; } //

        [DataMember] public string  imgFoto              { get; set; }  
        [DataMember] public string  strNombresCompletos  { get; set; } //Nombres Concatenados

        //AÑADIDO TOMA CONSUMOS HG 10.03.21 18:54PM
        [DataMember] public string strTipoServicio       { get; set; } //varchar
        [DataMember] public int    intTipoPeriodoConsumo { get; set; } //int
        [DataMember] public int    intCantMaxConsumo     { get; set; } //int  
        [DataMember] public bool   bitMarcaDNI           { get; set; } //bit
        [DataMember] public string strHorarioAtencion { get; set; } //varchar 
        [DataMember] public int CantS { get; set; } //int  
        [DataMember] public decimal TotalS { get; set; } //
        [DataMember] public int CantC { get; set; } //int  
        [DataMember] public decimal TotalC { get; set; } //
        [DataMember] public string Sim { get; set; } //varchar 
        [DataMember] public bool bitTodosTS { get; set; }


        //GESTION DE CONSUMOS
        [DataMember] public string strNumDoc         { get; set; } 
        [DataMember] public string strDesTipServicio { get; set; }
        [DataMember] public string strDesTipMenu     { get; set; }
        [DataMember] public string strDesEmp         { get; set; }
        [DataMember] public string strDesMarcador    { get; set; } 
        [DataMember] public string strUsuarAutor     { get; set; } 
        [DataMember] public string dttFeHoraAutor    { get; set; } 
        [DataMember] public string strUsuarDesha     { get; set; } 
        [DataMember] public string dttFeHoraDesha    { get; set; }
        [DataMember] public string strDescripcion { get; set; }//añadido 22.03.2021
        [DataMember] public string strClase          { get; set; }//añadido 22.03.2021
        [DataMember] public string strPrecio         { get; set; }//añadido 22.03.2021
        [DataMember] public int FlCancelado       { get; set; } //añadido 23.03.2021
        [DataMember] public string strCantidad { get; set; } //añadido 23.03.2021
    }
}
