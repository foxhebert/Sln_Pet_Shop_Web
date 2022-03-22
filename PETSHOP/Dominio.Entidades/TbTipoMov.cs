using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TbTipoMov
    {
        //MODELO DE TBTIPO
        [DataMember] public int    intIdTipo   { get; set; }
        [DataMember] public string strCodTipo  { get; set; }
        [DataMember] public string strDescTipo { get; set; }

    }
}