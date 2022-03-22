//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace BODESOFT.Models
//{
//    public class CorreoEmp
//    {
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Dominio.Entidades
    namespace BODESOFT.Models
{
    public class CorreoEmp
    {
        public int    intIdPersonal { get; set; }
        public string strNomCompleto { get; set; }
        public string strCorreo { get; set; }
        public string strNumDocNue { get; set; }

        //VALIDACION LOGUEO SERVER
        public string strOC { get; set; }
        public string strRUC { get; set; }
        public string strCadena { get; set; }
        public string strDestinos { get; set; }



    }
}


