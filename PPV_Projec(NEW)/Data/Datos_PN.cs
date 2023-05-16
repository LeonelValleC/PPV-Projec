using PPV_Projec_NEW_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPV_Projec_NEW_.Data
{
    public class Datos_PN
    {
        public IEnumerable<PN> Consult()
        {
            using (PPVdbEntities contexto = new PPVdbEntities())
            {
                return contexto.PNs.AsNoTracking().ToList();

            }
        }
    }
}