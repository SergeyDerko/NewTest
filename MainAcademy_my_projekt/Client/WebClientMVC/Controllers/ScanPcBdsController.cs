using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using TestWcfDB.SergeyDerko;
using TestWcfTypes.SergeyDerko;
using WebClientMVC.Models;

namespace WebClientMVC.Controllers
{
    public class ScanPcBdsController : Controller
    {
        private readonly ScanPcContext _db = new ScanPcContext();
        [HttpPost]
        public ActionResult AjaxGetData()
        {
            ScanPcModel.StartScanPcModel();
            ViewBag.Hdd = ScanPcModel.Hdd != null ? ScanPcModel.Hdd : "Ошибка инициализации данных (смотри логи сайта)";
            ViewBag.Cpu = ScanPcModel.Cpu != null ? ScanPcModel.Cpu : "Ошибка инициализации данных (смотри логи сайта)";
            ViewBag.Video = ScanPcModel.Video != null ? ScanPcModel.Video : "Ошибка инициализации данных (смотри логи сайта)";
            ViewBag.Memory = ScanPcModel.Memory != null ? ScanPcModel.Memory : "Ошибка инициализации данных (смотри логи сайта)";
            return Json(new {ViewBag.Hdd, ViewBag.Cpu, ViewBag.Video, ViewBag.Memory }, JsonRequestBehavior.AllowGet);
        }
        // GET: ScanPcBds
        public ActionResult Index(int? page)
        {
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(_db.ScanPcBds.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: ScanPcBds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScanPcBd scanPcBd = _db.ScanPcBds.Find(id);
            if (scanPcBd == null)
            {
                return HttpNotFound();
            }
            return View(scanPcBd);
        }

        // GET: ScanPcBds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScanPcBds/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScanPcId,Hdd,Cpu,Memory,Video")] ScanPcBd scanPcBd)
        {
            if (ModelState.IsValid)
            {
                _db.ScanPcBds.Add(scanPcBd);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scanPcBd);
        }

        // GET: ScanPcBds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScanPcBd scanPcBd = _db.ScanPcBds.Find(id);
            if (scanPcBd == null)
            {
                return HttpNotFound();
            }
            return View(scanPcBd);
        }

        // POST: ScanPcBds/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScanPcId,Hdd,Cpu,Memory,Video")] ScanPcBd scanPcBd)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(scanPcBd).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scanPcBd);
        }

        // GET: ScanPcBds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScanPcBd scanPcBd = _db.ScanPcBds.Find(id);
            if (scanPcBd == null)
            {
                return HttpNotFound();
            }
            return View(scanPcBd);
        }

        // POST: ScanPcBds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScanPcBd scanPcBd = _db.ScanPcBds.Find(id);
            _db.ScanPcBds.Remove(scanPcBd);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
