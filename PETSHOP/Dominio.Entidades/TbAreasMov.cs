using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TbAreasMov
    {
        //MODELO DE TBAREAS     
        [DataMember] public int    intIdArea   { get; set; }
        [DataMember] public int    intIdLocal  { get; set; }
        [DataMember] public string strCodArea  { get; set; }
        [DataMember] public string strDescArea { get; set; }    
        
        
    }
}