using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class OrderPositionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OrderPositions
        public async Task<ActionResult> Index()
        {
            var orderPositions = db.OrderPositions.Include(o => o.Order).Include(o => o.Product);
            return View(await orderPositions.ToListAsync());
        }

        // GET: OrderPositions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderPosition orderPosition = await db.OrderPositions.FindAsync(id);
            if (orderPosition == null)
            {
                return HttpNotFound();
            }
            return View(orderPosition);
        }

        // GET: OrderPositions/Create
        public ActionResult Create()
        {
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Address");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            return View();
        }

        // POST: OrderPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ProductId,OrderId,Count")] OrderPosition orderPosition)
        {
            if (ModelState.IsValid)
            {
                db.OrderPositions.Add(orderPosition);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Address", orderPosition.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", orderPosition.ProductId);
            return View(orderPosition);
        }

        // GET: OrderPositions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderPosition orderPosition = await db.OrderPositions.FindAsync(id);
            if (orderPosition == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Address", orderPosition.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", orderPosition.ProductId);
            return View(orderPosition);
        }

        // POST: OrderPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProductId,OrderId,Count")] OrderPosition orderPosition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderPosition).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Address", orderPosition.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", orderPosition.ProductId);
            return View(orderPosition);
        }

        // GET: OrderPositions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderPosition orderPosition = await db.OrderPositions.FindAsync(id);
            if (orderPosition == null)
            {
                return HttpNotFound();
            }
            return View(orderPosition);
        }

        // POST: OrderPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OrderPosition orderPosition = await db.OrderPositions.FindAsync(id);
            db.OrderPositions.Remove(orderPosition);
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
