using PPV_Projec_NEW_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPV_Projec_NEW_.Data
{
    public class Datos_PPVs
    {
        public IEnumerable<PPV> Consult()
        {
            using (PPVdbEntities contexto = new PPVdbEntities()) {                   
                return contexto.PPVs.AsNoTracking().ToList() ;
            
            }
        }


    }
}