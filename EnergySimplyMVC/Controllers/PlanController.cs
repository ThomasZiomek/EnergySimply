using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnergySimplyDAL.EF;
using EnergySimplyDAL.Models;
using EnergySimplyDAL.Repos;

namespace EnergySimplyMVC.Controllers
{
    public class PlanController : Controller
    {
        private EnergySimplyEntities db = new EnergySimplyEntities();

        // tz added:
        private readonly PlanRepo _repo = new PlanRepo();
        // end tz

        // GET: Plan
        public async Task<ActionResult> Index()
        {
            //return View(await db.Plans.ToListAsync());
            return View(await _repo.GetAllAsync());
        }

        // GET: Plan/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Plan plan = await db.Plans.FindAsync(id);
            var plan = await _repo.GetOneAsync(id);

            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // GET: Plan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PlanID,PlanName,PlanFixedCost,PlanVarCost")] Plan plan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Plans.Add(plan);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Unable to create record: { ex.Message}");
            }

            return View(plan);
        }

        // GET: Plan/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = await db.Plans.FindAsync(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Plan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PlanID,PlanName,PlanFixedCost,PlanVarCost")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(plan);
        }

        // GET: Plan/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = await db.Plans.FindAsync(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Plan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Plan plan = await db.Plans.FindAsync(id);
            db.Plans.Remove(plan);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
                // tz added:
                _repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
