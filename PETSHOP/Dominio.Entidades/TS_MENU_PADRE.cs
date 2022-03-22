using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TS_MENU_PADRE
    {

        [DataMember] public string strMenu { get; set; }
        [DataMember] public List<TS_MENU> menu { get; set; }
        [DataMember] public string strNomFormu { get; set; }

        //Añadido HGM 13.07.21
        [DataMember] public string strCoMenuRela { get; set; }
        
    }
}
