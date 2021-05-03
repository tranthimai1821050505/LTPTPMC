using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LTPTPMC.Models;
using LTPTPMC.Models.ExcelProcess;

namespace LTPTPMC.Controllers
{
    public class DemoesController : Controller
    {
        private LTPTPMCDbContext db = new LTPTPMCDbContext();
        ReadExcel excel = new ReadExcel();

        // GET: Demoes
        public ActionResult Index()
        {
            return View(db.Demos.ToList());
        }

        // GET: Demoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demo demo = db.Demos.Find(id);
            if (demo == null)
            {
                return HttpNotFound();
            }
            return View(demo);
        }

        // GET: Demoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Demoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Demo demo)
        {
            if (ModelState.IsValid)
            {
                db.Demos.Add(demo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(demo);
        }

        // GET: Demoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demo demo = db.Demos.Find(id);
            if (demo == null)
            {
                return HttpNotFound();
            }
            return View(demo);
        }

        // POST: Demoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Demo demo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(demo);
        }

        // GET: Demoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demo demo = db.Demos.Find(id);
            if (demo == null)
            {
                return HttpNotFound();
            }
            return View(demo);
        }

        // POST: Demoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Demo demo = db.Demos.Find(id);
            db.Demos.Remove(demo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            //save file to server
            string _FileName = "Demo.xlsx";
            //duong dan luu file
            string _path = Path.Combine(Server.MapPath("~/Uploads/Excels"), _FileName);
            //luu file len server
            file.SaveAs(_path);
            //doc du lieu tu file excel
            //DataTable dt = excel.ReadDataFromExcelFile(_path);
            //CopyDataByBulk(dt);
            CopyDataByBulk(excel.ReadDataFromExcelFile(_path));
            return View("Index");
        }
        private void CopyDataByBulk(DataTable dt)
        {
            //lay ket noi voi database luu trong file webconfig
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LTPTPMC"].ConnectionString);
            SqlBulkCopy bulkcopy = new SqlBulkCopy(con);
            bulkcopy.DestinationTableName = "Demos";
            bulkcopy.ColumnMappings.Add(0, "Id");
            bulkcopy.ColumnMappings.Add(1, "Name");
            con.Open();
            bulkcopy.WriteToServer(dt);
            con.Close();
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
