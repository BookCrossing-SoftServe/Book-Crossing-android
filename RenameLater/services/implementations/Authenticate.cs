using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using RenameLater.models;
using RenameLater.models.response;
using RenameLater.services.interfaces;

namespace RenameLater.services.implementations
{
    public class Authenticate : IAuthenticate
    {
        private readonly HttpRequests _httpRequests;
        public async Task<LoggedUser> VerifyCredentialsAsync(LoginModel loginModel)
        {
            var token = await _httpRequests.GetToken(loginModel);
            if (token==null)
            {
                throw new InvalidCredentialException();
            }
            return token;
        }

        public Authenticate(HttpRequests httpRequests)
        {
            this._httpRequests = httpRequests;
        }
    }
}
