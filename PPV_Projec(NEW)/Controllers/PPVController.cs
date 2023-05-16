using PPV_Projec_NEW_.Data;
using PPV_Projec_NEW_.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PPV_Projec_NEW_.Controllers
{
    public class PPVController : Controller
    {
        Datos_PPVs ppv = new Datos_PPVs();
        Models.PPVdbEntities TE = new PPVdbEntities();
        // GET: PPV
        public ActionResult Index()
        {
            IEnumerable<PPV> listaPPVs = ppv.Consult();

            return View(listaPPVs);
        }

        //
        // GET: /Emp/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Emp/Create
        [HttpPost]
        public ActionResult Create(Models.PPV ppv)
        {
            try
            {
                
                TE.Database.Connection.Open();
                //TE.PPVs.AddObject(ppv);
                TE.PPVs.Add(ppv);
                TE.SaveChanges();
                //TE.AcceptAllChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}