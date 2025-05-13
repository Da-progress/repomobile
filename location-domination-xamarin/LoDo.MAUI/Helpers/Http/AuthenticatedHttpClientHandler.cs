using System.Diagnostics;
using System.Text;
#if ANDROID
using Android.Util;
#endif
namespace LoDo.MAUI.Helpers.Http;

public class AuthenticatedHttpClientHandler : HttpClientHandler
{
    private readonly string _authHeader;

    public AuthenticatedHttpClientHandler(string username, string password)
    {
        // Encode username:password in Base64
        string credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
        _authHeader = $"Basic {credentials}";
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        request.Headers.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", _authHeader.Substring(6));
#if ANDROID
        Log.WriteLine(LogPriority.Debug ,"LODO", $"Request: {request.Method} {request.RequestUri}");
        if (request.Content != null)
        {
            var content = await request.Content.ReadAsStringAsync();
            Log.WriteLine(LogPriority.Debug ,"LODO", $"Request Content: {content}");
        }
#endif
        var response = await base.SendAsync(request, cancellationToken);
#if ANDROID
        Log.WriteLine(LogPriority.Debug ,"LODO",$"Response: {response.StatusCode}");
        if (response.Content != null)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            Log.WriteLine(LogPriority.Debug ,"LODO",$"Response Content: {responseContent}");
        }
#endif
        return response;
    }
}