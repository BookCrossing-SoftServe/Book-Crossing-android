using System;
using System.Collections.Generic;
using System.Text;

namespace RenameLater.models
{
    public class LoginModel
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public LoginModel(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }
    }
}
