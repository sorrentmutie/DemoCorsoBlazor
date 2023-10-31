using System.Net.Http.Json;

namespace DemoCorsoBlazor.Core.ReqRes;

public class ReqResService : IReqResData
{
    private readonly IHttpClientFactory httpClientFactory;

    public ReqResService(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<List<User>?> GetSomeData()
    {
        var httpClient = httpClientFactory.CreateClient("reqres");  
        var response = await httpClient.GetAsync("");
        if (response == null) return null;
        if (response.IsSuccessStatusCode)
        {
            var res =  await response.Content.ReadFromJsonAsync<ReqResUser>();
            if(res == null) return null;
            return res.data.ToList();
        }
        else
        {
            return null;
        }
    }

    public async Task<ReqResData?> PostSomeData(ReqResData data)
    {
        var httpClient = httpClientFactory.CreateClient("reqres");
        var response = await httpClient.PostAsJsonAsync("", data);
        if (response == null) return null;
        if(response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<ReqResData>();

        } else
        {
            return null;
        }
    }
}
