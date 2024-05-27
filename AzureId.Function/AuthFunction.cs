using AzureId.Function.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;

namespace AzureId.Function;

public class AuthFunction
{
    [Function("Login")]
    public IActionResult Login([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        try
        {
            string loginUrl = HttpHelper.PrepareLoginUrl();
            return new RedirectResult(loginUrl);
        }
        catch
        {
            return new StatusCodeResult(500);
        }
    }

    [Function("HandleCallback")]
    public async Task<IActionResult> HandleCallback([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        try
        {
            string? authorizationCode = req.Query["code"];
            if (authorizationCode == null) return new BadRequestObjectResult("Could not found the code");

            var tokenEndpoint = HttpHelper.PrepareTokenUrl();
            var tokenResponse = await HttpHelper.SendRequestAsync(tokenEndpoint, HttpHelper.PrepareFormUrlForToken(authorizationCode));

            return new OkObjectResult(tokenResponse);
        }
        catch
        {
            return new StatusCodeResult(500);
        }
    }
}
