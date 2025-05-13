using LoDo.MAUI.Services.Interfaces;
using Refit;

namespace LoDo.MAUI.Services.Implementations;

public class ApiService
{
    public ILoDoApi LoDoApi { get;  private set; }

    public ApiService(ILoDoApi lodoApi)
    {
        LoDoApi = lodoApi;
        var handler = new LoDo.MAUI.Helpers.Http.AuthenticatedHttpClientHandler("testuser", "testpass");

        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("http://app.ldomination.com:8081/api")
        };

        LoDoApi = RestService.For<ILoDoApi>(httpClient);
    }
}