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
    public class AircraftModelsController : Controller
    {
        private ModeloDeDados db = new ModeloDeDados();

        // GET: AircraftModels
        public async Task<ActionResult> Index()
        {
            return View(await db.AircraftModel.ToListAsync());
        }

        // GET: AircraftModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AircraftModel aircraftModel = await db.AircraftModel.FindAsync(id);
            if (aircraftModel == null)
            {
                return HttpNotFound();
            }
            return View(aircraftModel);
        }

        // GET: AircraftModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AircraftModels/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AIRCRAFT_MODEL_ID,CODE,ALTERNATIVE_CODE,MAX_DEPARTURE_WEIGHT,MAX_LANDING_WEIGHT")] AircraftModel aircraftModel)
        {
            if (ModelState.IsValid)
            {
                db.AircraftModel.Add(aircraftModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(aircraftModel);
        }

        // GET: AircraftModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AircraftModel aircraftModel = await db.AircraftModel.FindAsync(id);
            if (aircraftModel == null)
            {
                return HttpNotFound();
            }
            return View(aircraftModel);
        }

        // POST: AircraftModels/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AIRCRAFT_MODEL_ID,CODE,ALTERNATIVE_CODE,MAX_DEPARTURE_WEIGHT,MAX_LANDING_WEIGHT")] AircraftModel aircraftModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aircraftModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(aircraftModel);
        }

        // GET: AircraftModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AircraftModel aircraftModel = await db.AircraftModel.FindAsync(id);
            if (aircraftModel == null)
            {
                return HttpNotFound();
            }
            return View(aircraftModel);
        }

        // POST: AircraftModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AircraftModel aircraftModel = await db.AircraftModel.FindAsync(id);
            db.AircraftModel.Remove(aircraftModel);
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
