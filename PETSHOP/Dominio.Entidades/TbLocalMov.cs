using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TbLocalMov
    {
        //MODELO DE TBLOCAL      
        [DataMember] public int    intIdLocal   { get; set; }
        [DataMember] public string strCodLocal  { get; set; }
        [DataMember] public string strDescLocal { get; set; }     

      
    }
}