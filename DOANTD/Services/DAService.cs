using DOANTD.Database;
using DOANTD.Helpers;
using DOANTD.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DOANTD.Services
{
    public class DAService
    {
        protected ApplicationDbContext _dbContext;

        public DAService()
        {
            _dbContext = new ApplicationDbContext();
        }

        /// <summary>
        /// Authenticate User Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ResultModel> Authenticate(LoginModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var user = await _dbContext.Users.FirstOrDefaultAsync(i => i.Username == model.Username);

            if (user == null || !HashManager.VerifyPassword(model.Password, user.Password))
            {
                return new ResultModel
                {
                    IsSuccessful = false,
                    Message = "Your username or password is invalid!",
                    Code = (int)HttpStatusCode.Unauthorized
                };
            }

            bool isAdmin = (user.Username == "thuy@gmail.com"); // Kiểm tra nếu là admin

            return new ResultModel
            {
                IsSuccessful = true,
                Data = user,
                Message = isAdmin ? "User logged in successfully! Welcome Admin." : "User logged in successfully!",
                Code = (int)HttpStatusCode.OK,
                IsAdmin = isAdmin // Gán giá trị cho IsAdmin
            };
        }

        public async Task<ResultModel> Register(RegisterModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var isUserExist = await _dbContext.Users.AnyAsync(i => i.Username == model.Username);

            if (!isUserExist)
            {
                var password = HashManager.HashPassword(model.Password);
                var user = new Entities.User
                {
                    Username = model.Username,
                    Password = password,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    AccountType = (Entities.AccountType)model.AccountType // Chuyển đổi enum ở đây
                };

                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();

                return new ResultModel
                {
                    IsSuccessful = true,
                    Data = user,
                    Message = "User successfully registered!",
                    Code = (int)HttpStatusCode.OK
                };
            }
            else
            {
                return new ResultModel
                {
                    IsSuccessful = false,
                    Data = null,
                    Message = "Username already exists!",
                    Code = (int)HttpStatusCode.BadRequest
                };
            }
        }
    }
}