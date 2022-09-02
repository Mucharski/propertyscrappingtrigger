using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Scrapping;

public class App
{
    private static readonly HttpClient Client = new();

    [FunctionName("WebScrappingTrigger")]
    public static async Task TriggerAsync([TimerTrigger("0 0 8-18/4 * * *")] TimerInfo myTimer,
        ILogger log)
    {
        await Client.GetAsync(new Uri("https://propertyscrapping.azurewebsites.net/scrapper/imovelweb"));
    }

    [FunctionName("FunctionMessageTrigger")]
    public static async Task TriggerMessageAsync([TimerTrigger("0 0 8-18/4 * * *")] TimerInfo myTimer,
        ILogger log)
    {
        await Client.GetAsync(new Uri("https://propertyscrapping.azurewebsites.net/function/trigger"));
    }
}