using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AircraftControlProject.Models;

namespace AircraftControlProject.Controllers
{
    public class AircraftController : Controller
    {
        private ModeloDeDados db = new ModeloDeDados();

        // GET: Aircraft
        public async Task<ActionResult> Index()
        {
            var aircraft = db.Aircraft.Include(a => a.AircraftModel);
            return View(await aircraft.ToListAsync());
        }

        // GET: Aircraft/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aircraft aircraft = await db.Aircraft.FindAsync(id);
            if (aircraft == null)
            {
                return HttpNotFound();
            }
            return View(aircraft);
        }

        // GET: Aircraft/Create
        public ActionResult Create()
        {
            ViewBag.AIRCRAFT_MODEL_ID = new SelectList(db.AircraftModel, "AIRCRAFT_MODEL_ID", "CODE");
            return View();
        }

        // POST: Aircraft/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AIRCRAFT_ID,PREFIX,MAX_DEPARTURE_WEIGHT,MAX_LANDING_WEIGHT,ACTIVE,AIRCRAFT_MODEL_ID")] Aircraft aircraft)
        {
            if (ModelState.IsValid)
            {
                db.Aircraft.Add(aircraft);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AIRCRAFT_MODEL_ID = new SelectList(db.AircraftModel, "AIRCRAFT_MODEL_ID", "CODE", aircraft.AIRCRAFT_MODEL_ID);
            return View(aircraft);
        }

        // GET: Aircraft/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aircraft aircraft = await db.Aircraft.FindAsync(id);
            if (aircraft == null)
            {
                return HttpNotFound();
            }
            ViewBag.AIRCRAFT_MODEL_ID = new SelectList(db.AircraftModel, "AIRCRAFT_MODEL_ID", "CODE", aircraft.AIRCRAFT_MODEL_ID);
            return View(aircraft);
        }

        // POST: Aircraft/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AIRCRAFT_ID,PREFIX,MAX_DEPARTURE_WEIGHT,MAX_LANDING_WEIGHT,ACTIVE,AIRCRAFT_MODEL_ID")] Aircraft aircraft)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aircraft).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AIRCRAFT_MODEL_ID = new SelectList(db.AircraftModel, "AIRCRAFT_MODEL_ID", "CODE", aircraft.AIRCRAFT_MODEL_ID);
            return View(aircraft);
        }

        // GET: Aircraft/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aircraft aircraft = await db.Aircraft.FindAsync(id);
            if (aircraft == null)
            {
                return HttpNotFound();
            }
            return View(aircraft);
        }

        // POST: Aircraft/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Aircraft aircraft = await db.Aircraft.FindAsync(id);
            db.Aircraft.Remove(aircraft);
            await db.SaveChangesAsync();
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
