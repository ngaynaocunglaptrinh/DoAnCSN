using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using DOANTD.Database;

namespace DOANTD.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public UserController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public async Task<ActionResult> ShowPasswordHash(string username)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                return HttpNotFound("User not found.");
            }

            // In ra mật khẩu đã băm
            ViewBag.HashedPassword = user.Password; // Mật khẩu đã băm
            return View();
        }
      
    }

}