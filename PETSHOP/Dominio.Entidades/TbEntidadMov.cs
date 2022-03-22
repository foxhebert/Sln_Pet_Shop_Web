using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TbEntidadMov
    {
        //MODELO DE TBENTIDAD       
        [DataMember] public int    intIdEntidad   { get; set; }
        [DataMember] public string strCodEntidad  { get; set; }
        [DataMember] public string strDescEntidad { get; set; }     
        
    }
}