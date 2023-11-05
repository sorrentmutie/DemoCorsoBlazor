using System.Net.Http.Json;

namespace DemoCorsoBlazor.Core.RandomUser;

public class RandomUserService : IRandomUsers
{
    private readonly IHttpClientFactory httpClientFactory;

    public RandomUserService(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }
    public async Task<RandomUserViewModel?> GetUsersAsync(int count)
    {
        var httpClient = httpClientFactory.CreateClient("httpuser");
        var response = await httpClient.GetAsync($"?results={count}");
        if (response == null) return null;
        if (response.IsSuccessStatusCode)
        {
            var res = await response.Content.ReadFromJsonAsync<RandomUsersResponse>();
            if (res == null) return null;

            RandomUserViewModel vm = new RandomUserViewModel();
            vm.Utenti = res.results.ToList();
            vm.Genere = new ChartViewModel()
            {
                Labels = new List<string> { "Maschi", "Femmine" },
                Values = new List<double> {
                     vm.Utenti.Where(x => x.gender == "male").Count(),
                     vm.Utenti.Where(x => x.gender == "female").Count()
                }
            };
            vm.TotPerNazione = new ChartViewModel();
            vm.TotPerNazione.Labels = vm.Utenti.Select(x => x.location.country).Distinct().ToList();
            vm.TotPerNazione.Values = new List<double>();

            foreach (var nazione in vm.TotPerNazione.Labels)
            {
                vm.TotPerNazione.Values.Add(vm.Utenti?.Where(x => x.location.country == nazione).Count() ?? 0);
            }
            return vm;
        }
        else
        {
            return null;
        }
    }
}
