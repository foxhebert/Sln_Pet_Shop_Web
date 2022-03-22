using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{

    [DataContract]
    public class TGTipoEN {

        [DataMember] public int intidTipo { get; set; }
        [DataMember] public string strCoTipo { get; set; }
        [DataMember] public string strAbreviatura { get; set; }
        [DataMember] public string strDeTipo { get; set; }
        [DataMember] public string strGrupo { get; set; }
        [DataMember] public string strSubGrupo { get; set; }
        [DataMember] public int intNuOrden { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public DateTime dttFeRegistro { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public DateTime dttFeModif { get; set; }
        [DataMember] public int intextra1 { get; set; }
        [DataMember] public string strextra1 { get; set; }
        [DataMember] public string strextra2 { get; set; }


        //HGM Añadido para Mant. Perfil sin el vue - Cargado de menus Editar Perfil 09.08.21
        [DataMember] public string strCoMenuRela { get; set; }
        



    }
}
