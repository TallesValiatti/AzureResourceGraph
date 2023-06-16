using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;
using ResourceGraphApp.Shared;

namespace ResourceGraphApp.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class CloudResourcesController : ControllerBase
{
    private readonly IDownstreamWebApi _downstreamWebApi;
    
    public CloudResourcesController(IDownstreamWebApi downstreamWebApi)
    {
        _downstreamWebApi = downstreamWebApi;
    }

    [HttpGet]
    [AuthorizeForScopes(ScopeKeySection = "ResourceGraphAPI:Scopes")]
    public async Task<IActionResult> GetAsync()
    {
       
        var value = await _downstreamWebApi.PostForUserAsync<CloudRegion, object>(
            "ResourceGraphAPI",
            "/providers/Microsoft.ResourceGraph/resources?api-version=2021-03-01",
            new
            {
                subscriptions = new List<string> { "<YOU-SUBSCRIPTION-ID>" },
                query = "Resources | summarize qtd=count() by location"
            });

        return Ok(value);
    }
}