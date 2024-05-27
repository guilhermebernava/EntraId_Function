namespace AzureId.Function.Helpers;
public static class HttpHelper
{
    public static FormUrlEncodedContent PrepareFormUrlForToken(string authorizationCode)
    {
        string? redirectUri, clientId, clientSecret, scope;
        EnviromentHelper.GetEnviromentsVariables(out redirectUri, out clientId, out clientSecret, out scope);

        return new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("grant_type", "authorization_code"),
            new KeyValuePair<string, string>("code", authorizationCode),
            new KeyValuePair<string, string>("redirect_uri", redirectUri),
            new KeyValuePair<string, string>("client_id", clientId),
            new KeyValuePair<string, string>("client_secret", clientSecret),
            new KeyValuePair<string, string>("scope", scope)
            });
    }

    public static async Task<string> SendRequestAsync(string endpoint, FormUrlEncodedContent content)
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.PostAsync(endpoint, content);

            if (response.IsSuccessStatusCode)
            {
                var tokenResponse = await response.Content.ReadAsStringAsync();
                return tokenResponse;
            }

            throw new Exception("Error in request");
        }
    }

    public static string PrepareLoginUrl()
    {
        return $"https://login.microsoftonline.com/{Environment.GetEnvironmentVariable("TENANT_ID")}/oauth2/v2.0/authorize" +
                                   $"?client_id={Environment.GetEnvironmentVariable("CLIENT_ID")}" +
                                   $"&response_type=code" +
                                   $"&redirect_uri={Environment.GetEnvironmentVariable("CALLBACK_URL")}" +
                                   $"&scope=openid email profile";
    }

    public static string PrepareTokenUrl()
    {
        return $"https://login.microsoftonline.com/{Environment.GetEnvironmentVariable("TENANT_ID")}/oauth2/v2.0/token";      
    }
}
