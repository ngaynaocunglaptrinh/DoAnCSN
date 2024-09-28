using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DOANTD.Entities;

namespace DOANTD.Controllers
{
    public class JobController : Controller
    {
        private static List<Job> jobList = new List<Job>(); // Giả lập cơ sở dữ liệu
        private static int nextId = 1; // Biến theo dõi ID tiếp theo

        // GET: Job
        public ActionResult Index()
        {
            return View(jobList);
        }

        // GET: Job/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Job/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Job job)
        {
            if (ModelState.IsValid)
            {
                job.Id = nextId++; // Tạo ID duy nhất
                job.DatePosted = DateTime.Now;
                jobList.Add(job);
                TempData["SuccessMessage"] = "Tin tuyển dụng đã được tạo thành công!";
                return RedirectToAction("Index");
            }
            return View(job);
        }

        // GET: Job/Delete/5
        public ActionResult Delete(int id)
        {
            var job = jobList.FirstOrDefault(j => j.Id == id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var job = jobList.FirstOrDefault(j => j.Id == id);
            if (job != null)
            {
                jobList.Remove(job);
                TempData["SuccessMessage"] = "Tin tuyển dụng đã được xóa thành công!";
            }
            return RedirectToAction("Index");
        }
    }
}