namespace AzureId.Function.Helpers;
public static class EnviromentHelper
{
    public static void GetEnviromentsVariables(out string? redirectUri, out string? clientId, out string? clientSecret, out string scope)
    {
        redirectUri = Environment.GetEnvironmentVariable("CALLBACK_URL");
        clientId = Environment.GetEnvironmentVariable("CLIENT_ID");
        clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
        scope = "openid email profile";
    }  
}
