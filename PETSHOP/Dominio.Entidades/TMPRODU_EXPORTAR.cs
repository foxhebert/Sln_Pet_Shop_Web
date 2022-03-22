using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TMPRODU_EXPORTAR
    {

        [DataMember] public string strCoProdu   { get; set; } //CODIGO strCoProdu
        [DataMember] public string strDeProdu   { get; set; } //DESCIPCION
        [DataMember] public int    intCantidad  { get; set; } //CANTIDAD

        [DataMember] public string nvcCoProdu   { get; set; } //CANTIDAD
        [DataMember] public int    intNuRegis   { get; set; } //CANTIDAD
        [DataMember] public string nvcNoAlmac   { get; set; } //CANTIDAD
        [DataMember] public string nvcNoUbica   { get; set; } //CANTIDAD
        [DataMember] public string nvcCoCampoAux { get; set; }//CANTIDAD
        [DataMember] public string intNuTermi   { get; set; } //CANTIDAD
        [DataMember] public string dttFeRegis   { get; set; } //CANTIDAD

    }
}
