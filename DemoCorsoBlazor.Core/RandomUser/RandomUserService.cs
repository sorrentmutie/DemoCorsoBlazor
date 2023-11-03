using DemoCorsoBlazor.Core.ReqRes;
using System.Net.Http.Json;

namespace DemoCorsoBlazor.Core.RandomUser;

public class RandomUserService : IRandomUsers
{
    private readonly IHttpClientFactory httpClientFactory;

    public RandomUserService(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }
    public async Task<Utente[]?> GetUsersAsync(int count)
    {
        var httpClient = httpClientFactory.CreateClient("httpuser");
        var response = await httpClient.GetAsync($"?results={count}");
        if (response == null) return null;
        if (response.IsSuccessStatusCode)
        {
            var res = await response.Content.ReadFromJsonAsync<RandomUsersResponse>();
            if (res == null) return null;
            return res.results;
        }
        else
        {
            return null;
        }
    }
}
