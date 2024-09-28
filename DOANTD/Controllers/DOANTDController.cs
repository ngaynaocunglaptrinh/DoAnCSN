using DOANTD.Database;
using DOANTD.Entities;
using DOANTD.Models;
using DOANTD.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;

namespace DOANTD.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ApplicationDbContext _context;
        private readonly DAService daService;

        public AuthController()
        {
            daService = new DAService();
            _context = new ApplicationDbContext();
        }

        // GET: Auth
       
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await daService.Authenticate(model);
                if (result != null && result.IsSuccessful)
                {
                    var loggedInUser = JsonConvert.DeserializeObject<UserModel>(JsonConvert.SerializeObject(result.Data));
                    Session["username"] = loggedInUser.Username;
                    Session["fullName"] = $"{loggedInUser.FirstName} {loggedInUser.LastName}";
                    Session["isAdmin"] = result.IsAdmin;

                    if (result.IsAdmin)
                    {
                        return RedirectToAction("Index", "Admin");
                    }

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = result?.Message ?? "Đã xảy ra lỗi trong quá trình đăng nhập.";
                }
            }
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
       
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            var model = new RegisterModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await daService.Register(model);
                if (result.IsSuccessful)
                {
                    ViewBag.Message = result.Message;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = result.Message;
                    return View(model);
                }
            }
            return View(model);
        }
    }
}