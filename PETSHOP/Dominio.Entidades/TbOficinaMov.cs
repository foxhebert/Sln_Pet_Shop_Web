using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TbOficinaMov
    {
        //MODELO DE TBOFICINA       
        [DataMember] public int    intIdOficina   { get; set; }
        [DataMember] public int    intIdLocal     { get; set; }
        [DataMember] public int    intIdArea      { get; set; }
        [DataMember] public string strCodOficina  { get; set; }
        [DataMember] public string strDescOficina { get; set; }

    }
}