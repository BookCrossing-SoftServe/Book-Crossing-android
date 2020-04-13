using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestApiClient.models;
using RestApiClient.services.interfaces;
using System.Configuration;
namespace RestApiClient.services.implementations
{
    public class BooksService : IBooksService
    {
        private readonly HttpClient _httpClient;

        public BooksService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
                var response =
                    await _httpClient.GetAsync(String.Concat(ServerConfiguration.Url, ServerConfiguration.Books));

                var jsonResponse = await response.Content.ReadAsStringAsync();
              
                var books = JsonConvert.DeserializeObject<List<BookModel>>(jsonResponse);
                return books;
        }
    }
}
