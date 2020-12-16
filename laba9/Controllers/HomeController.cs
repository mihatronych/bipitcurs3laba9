using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using laba9.Models;

namespace laba9.Controllers
{
    public class HomeController : Controller
    {
        private epiclibraryEntities db = new epiclibraryEntities();

        public ActionResult Index()
        {
            ViewBag.date = new DateTime();
            DataSet ds = new DataSet();
            var outputs = db.Outputs;
            var readers = db.Readers;
            var books = db.Books;

            var col = new List<string>() { "ID", "ID Читателя", "ФИО Читателя" ,
                    "Год рожд. Чит-ля", "Пасспорт Чит-ля",  "ID Кн.", "Название Кн.", "Автор Кн.",
                "Дата издания", "Дата написания", "Дата выдачи", "Последний срок приема", "Дней до просрочки"};
            DataTable table = new DataTable("Outputs");

            foreach (var c in col)
                table.Columns.Add(c);

            foreach (var o in outputs)
            {
                var R = new Readers();
                foreach (var r in readers)
                    if (r.r_id == o.R_id)
                        R = r;
                var B = new Books();
                foreach (var b in books)
                    if (b.b_id == o.B_id)
                        B = b;
                table.Rows.Add(
                    o.o_id,
                    R.r_id,
                    R.r_fio,
                    R.r_dt_birth,
                    R.r_passport,
                    B.b_id,
                    B.b_name,
                    B.b_author,
                    B.b_publ,
                    B.b_born,
                    o.o_dt_out,
                    o.o_dt_in,
                    o.o_dt_in - o.o_dt_out
                    );
            }

            ds.Tables.Add(table);

            return View(ds.Tables["Outputs"]);
        }

        public ActionResult Readers()
        {
            return View(db.Readers.ToList());
        }

        public ActionResult Books()
        {
            return View(db.Books.ToList());
        }

        public ActionResult Outputs()
        {
            ViewBag.date = new DateTime();
            DataSet ds = new DataSet();
            var outputs = db.Outputs;
            var readers = db.Readers;
            var books = db.Books;

            var col = new List<string>() { "ID", "ID Читателя", "ФИО Читателя" ,
                    "Год рожд. Чит-ля", "Пасспорт Чит-ля",  "ID Кн.", "Название Кн.", "Автор Кн.",
                "Дата издания", "Дата написания", "Дата выдачи", "Последний срок приема", "Дней до просрочки"};
            DataTable table = new DataTable("Outputs");

            foreach (var c in col)
                table.Columns.Add(c);
            
            foreach (var o in outputs)
            {
                var R = new Readers();
                foreach (var r in readers)
                    if (r.r_id == o.R_id)
                        R = r;
                var B = new Books();
                foreach (var b in books)
                    if (b.b_id == o.B_id)
                        B = b;
                table.Rows.Add(
                    o.o_id,
                    R.r_id,
                    R.r_fio,
                    R.r_dt_birth,
                    R.r_passport,
                    B.b_id,
                    B.b_name,
                    B.b_author,
                    B.b_publ,
                    B.b_born,
                    o.o_dt_out,
                    o.o_dt_in,
                    o.o_dt_in - o.o_dt_out
                    );
            }

            ds.Tables.Add(table);

            return View(ds.Tables["Outputs"]);

        }

        public ActionResult Journal()
        {
            var outputs = db.Outputs;
            return View(outputs.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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