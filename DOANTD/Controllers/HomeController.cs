using System;
using System.Collections.Generic; // Thêm dòng này
using System.Linq;
using System.Web.Mvc;
using DOANTD.Entities;

namespace DOANTD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var jobController = new JobController();
            var jobsResult = jobController.Index() as ViewResult; // Gọi phương thức Index của JobController

            // Kiểm tra nếu jobsResult không null
            if (jobsResult != null)
            {
                var jobList = jobsResult.Model as List<Job>; // Lấy danh sách công việc từ model
                ViewBag.JobList = jobList; // Lưu danh sách công việc vào ViewBag
            }

            return View();
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

        public ActionResult Admin()
        {
            ViewBag.Message = "Your admin page.";
            return View();
        }
    }
}