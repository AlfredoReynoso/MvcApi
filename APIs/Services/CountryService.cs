using APIs.Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace APIs.Services
{
    //public class CountryService
    //{
    //    private readonly HttpClient _httpClient;

    //    public CountryService()
    //    {
    //        _httpClient = new HttpClient();
    //        _httpClient.BaseAddress = new System.Uri("https://restcountries.com/v3.1/");
    //    }
    //    public async Task<List<Paises.Country>> GetAllCountriesAsync()
    //    {
    //        HttpResponseMessage resp = await _httpClient.GetAsync("all");
    //        if (resp.IsSuccessStatusCode)
    //        {
    //            string json = await resp.Content.ReadAsStringAsync();
    //            List<Paises.Country> countries = JsonConvert.DeserializeObject<List<Paises.Country>>(json);
    //            return countries;
    //        }
    //        else
    //        {
    //            throw new Exception($"Error al obtener países: {resp.StatusCode} - {resp.ReasonPhrase}");
    //        }
    //    }
    //}
}