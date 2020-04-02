using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RenameLater.models;
using RenameLater.models.response;

namespace RenameLater.services.interfaces
{
    public interface IAuthenticate
    { 
        Task<LoggedUser> VerifyCredentialsAsync(LoginModel loginModel);
    }
}
