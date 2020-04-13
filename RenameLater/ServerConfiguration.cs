using System.IO;
using Microsoft.Extensions.Configuration;

namespace RestApiClient
{
    public static class ServerConfiguration
    {
        public static string Url = "https://bookcrossingbackend-dev-as.azurewebsites.net/";
        public static string Login = "api/Login";
        public static string Books = "api/books";
        public static string Requests = "api/requests";
    }

 

}
