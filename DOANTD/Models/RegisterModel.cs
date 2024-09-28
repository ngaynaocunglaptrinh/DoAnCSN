using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOANTD.Models
{

        public class RegisterModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        

         // Thêm thuộc tính cho loại tài khoản
        public AccountType AccountType { get; set; }
          }

                public enum AccountType
                {
                   User,
                  Business
                }




    }