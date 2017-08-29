using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EquipmentManagementSystem;

namespace EquipmentManagementSystem.Controllers
{
    public class EquipmentsController : Controller
    {
        private JAOEntities db = new JAOEntities();

        // GET: Equipments
        public async Task<ActionResult> Index()
        {
            var equipments = db.equipments.Include(e => e.equ_category);
            return View(await equipments.ToListAsync());
        }

        // GET: Equipments/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            equipment equipment = await db.equipments.FindAsync(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        // GET: Equipments/Create
        public ActionResult Create()
        {
            ViewBag.equ_cat_id = new SelectList(db.equ_category, "equ_cat_id", "equ_cat_name");
            return View();
        }

        // POST: Equipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "equ_id,equ_name,equ_cat_id,equ_description,equ_amount,equ_status")] equipment equipment)
        {
            if (ModelState.IsValid)
            {
                db.equipments.Add(equipment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.equ_cat_id = new SelectList(db.equ_category, "equ_cat_id", "equ_cat_name", equipment.equ_cat_id);
            return View(equipment);
        }

        // GET: Equipments/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            equipment equipment = await db.equipments.FindAsync(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.equ_cat_id = new SelectList(db.equ_category, "equ_cat_id", "equ_cat_name", equipment.equ_cat_id);
            return View(equipment);
        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "equ_id,equ_name,equ_cat_id,equ_description,equ_amount,equ_status")] equipment equipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.equ_cat_id = new SelectList(db.equ_category, "equ_cat_id", "equ_cat_name", equipment.equ_cat_id);
            return View(equipment);
        }

        // GET: Equipments/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            equipment equipment = await db.equipments.FindAsync(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            equipment equipment = await db.equipments.FindAsync(id);
            db.equipments.Remove(equipment);
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
