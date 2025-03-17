using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

public class CountryService
{
    private readonly HttpClient _httpClient;

    public CountryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Country?> GetCountryByName(string name)
    {
        var countries = await _httpClient.GetFromJsonAsync<List<Country>>($"https://restcountries.com/v3.1/name/{name}");
        return countries?.FirstOrDefault();
    }
}

public class Country
{
    public Name Name { get; set; }
    public string[] Continents { get; set; }
    public Dictionary<string, string> Languages { get; set; }
    public ulong Population { get; set; }
    public Dictionary<string, Currency> Currencies { get; set; }
    public Flags Flags { get; set; }
}

public class Name
{
    public string Common { get; set; }
}

public class Currency
{
    public string Name { get; set; }
    public string Symbol { get; set; }
}

public class Flags
{
    public string Png { get; set; }
}
