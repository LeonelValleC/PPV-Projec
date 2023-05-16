using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PPV_Projec_NEW_.Models;

namespace PPV_Projec_NEW_.Controllers
{
    public class PPVsController : Controller
    {
        private PPVdbEntities db = new PPVdbEntities();

        // GET: PPVs
        public ActionResult Index()
        {
            var pPVs = db.PPVs.Include(p => p.Client1).Include(p => p.MFG).Include(p => p.PN1).Include(p => p.user).Include(p => p.user1).Include(p => p.user2).Include(p => p.Vendor1);
            return View(pPVs.ToList());
        }

        // GET: PPVs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PPV pPV = db.PPVs.Find(id);
            if (pPV == null)
            {
                return HttpNotFound();
            }
            return View(pPV);
        }

        // GET: PPVs/Create
        public ActionResult Create()
        {
            ViewBag.client = new SelectList(db.Clients, "id_client", "clientID");
            ViewBag.id_mfg = new SelectList(db.MFGs, "id_mfg", "mfg1");
            ViewBag.pn = new SelectList(db.PNs, "id_pn", "pn1");
            ViewBag.buyer = new SelectList(db.users, "id_user", "name");
            ViewBag.first_auth = new SelectList(db.users, "id_user", "name");
            ViewBag.last_auth = new SelectList(db.users, "id_user", "name");
            ViewBag.vendor = new SelectList(db.Vendors, "id_vendor", "vendorID");
            return View();
        }

        // POST: PPVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_ppv,wo,po,qty,av_price,new_price,buyer,reason,times,OtherChange,elaborate,leadtime,explanation,change_unit,change_unit_perc,current_total,new_total,total_increase,first_auth,last_auth,date_ppv,first_date,last_date,first_approval,last_approval,pn,client,vendor,first_note,last_note,salesOrder,salesOrder_num,note,void,id_mfg")] PPV pPV)
        {
            if (ModelState.IsValid)
            {
                db.PPVs.Add(pPV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.client = new SelectList(db.Clients, "id_client", "clientID", pPV.client);
            ViewBag.id_mfg = new SelectList(db.MFGs, "id_mfg", "mfg1", pPV.id_mfg);
            ViewBag.pn = new SelectList(db.PNs, "id_pn", "pn1", pPV.pn);
            ViewBag.buyer = new SelectList(db.users, "id_user", "name", pPV.buyer);
            ViewBag.first_auth = new SelectList(db.users, "id_user", "name", pPV.first_auth);
            ViewBag.last_auth = new SelectList(db.users, "id_user", "name", pPV.last_auth);
            ViewBag.vendor = new SelectList(db.Vendors, "id_vendor", "vendorID", pPV.vendor);
            return View(pPV);
        }

        // GET: PPVs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PPV pPV = db.PPVs.Find(id);
            if (pPV == null)
            {
                return HttpNotFound();
            }
            ViewBag.client = new SelectList(db.Clients, "id_client", "clientID", pPV.client);
            ViewBag.id_mfg = new SelectList(db.MFGs, "id_mfg", "mfg1", pPV.id_mfg);
            ViewBag.pn = new SelectList(db.PNs, "id_pn", "pn1", pPV.pn);
            ViewBag.buyer = new SelectList(db.users, "id_user", "name", pPV.buyer);
            ViewBag.first_auth = new SelectList(db.users, "id_user", "name", pPV.first_auth);
            ViewBag.last_auth = new SelectList(db.users, "id_user", "name", pPV.last_auth);
            ViewBag.vendor = new SelectList(db.Vendors, "id_vendor", "vendorID", pPV.vendor);
            return View(pPV);
        }

        // POST: PPVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_ppv,wo,po,qty,av_price,new_price,buyer,reason,times,OtherChange,elaborate,leadtime,explanation,change_unit,change_unit_perc,current_total,new_total,total_increase,first_auth,last_auth,date_ppv,first_date,last_date,first_approval,last_approval,pn,client,vendor,first_note,last_note,salesOrder,salesOrder_num,note,void,id_mfg")] PPV pPV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pPV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.client = new SelectList(db.Clients, "id_client", "clientID", pPV.client);
            ViewBag.id_mfg = new SelectList(db.MFGs, "id_mfg", "mfg1", pPV.id_mfg);
            ViewBag.pn = new SelectList(db.PNs, "id_pn", "pn1", pPV.pn);
            ViewBag.buyer = new SelectList(db.users, "id_user", "name", pPV.buyer);
            ViewBag.first_auth = new SelectList(db.users, "id_user", "name", pPV.first_auth);
            ViewBag.last_auth = new SelectList(db.users, "id_user", "name", pPV.last_auth);
            ViewBag.vendor = new SelectList(db.Vendors, "id_vendor", "vendorID", pPV.vendor);
            return View(pPV);
        }

        // GET: PPVs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PPV pPV = db.PPVs.Find(id);
            if (pPV == null)
            {
                return HttpNotFound();
            }
            return View(pPV);
        }

        // POST: PPVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PPV pPV = db.PPVs.Find(id);
            db.PPVs.Remove(pPV);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
