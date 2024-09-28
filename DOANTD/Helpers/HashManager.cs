using System;
using BCrypt.Net; // Sử dụng thư viện BCrypt.Net

namespace DOANTD.Helpers
{
    public class HashManager
    {
        // Hàm băm mật khẩu
      
            public static string HashPassword(string input)
            {
                string salt = "$2a$" + 13 + "$" + "/8Wncr26eAmxD1l6cAF9F8";
                return DevOne.Security.Cryptography.BCrypt.BCryptHelper.HashPassword(input, salt);
            }

            public static bool VerifyPassword(string input, string hashedPassword) => DevOne.Security.Cryptography.BCrypt.BCryptHelper.CheckPassword(input, hashedPassword);
        }
    }