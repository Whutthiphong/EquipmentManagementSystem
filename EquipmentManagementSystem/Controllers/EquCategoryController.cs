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
    public class EquCategoryController : Controller
    {
        private JAOEntities db = new JAOEntities();

        // GET: EquCategory
        public async Task<ActionResult> Index()
        {
            return View(await db.equ_category.ToListAsync());
        }

        // GET: EquCategory/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            equ_category equ_category = await db.equ_category.FindAsync(id);
            if (equ_category == null)
            {
                return HttpNotFound();
            }
            return View(equ_category);
        }

        // GET: EquCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EquCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "equ_cat_id,equ_cat_name")] equ_category equ_category)
        {
            if (ModelState.IsValid)
            {
                db.equ_category.Add(equ_category);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(equ_category);
        }

        // GET: EquCategory/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            equ_category equ_category = await db.equ_category.FindAsync(id);
            if (equ_category == null)
            {
                return HttpNotFound();
            }
            return View(equ_category);
        }

        // POST: EquCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "equ_cat_id,equ_cat_name")] equ_category equ_category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equ_category).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(equ_category);
        }

        // GET: EquCategory/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            equ_category equ_category = await db.equ_category.FindAsync(id);
            if (equ_category == null)
            {
                return HttpNotFound();
            }
            return View(equ_category);
        }

        // POST: EquCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            equ_category equ_category = await db.equ_category.FindAsync(id);
            db.equ_category.Remove(equ_category);
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
