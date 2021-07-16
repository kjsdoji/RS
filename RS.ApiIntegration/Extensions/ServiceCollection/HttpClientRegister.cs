using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RS.Utilities.Constants;
//using RS.Shared.Constants;

namespace RS.ApiIntegration.Extensions.ServiceCollection
{
    public static class HttpClientRegister
    {
        public static void AddCustomHttpClient(this IServiceCollection services, IConfiguration config)
        {
            var configureClient = new Action<IServiceProvider, HttpClient>((provider, client) =>
            {
                var httpContextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
                var sessions = httpContextAccessor
                                            .HttpContext
                                            .Session
                                            .GetString(SystemConstants.AppSettings.Token);
                var languageId = httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
                client.BaseAddress = new Uri(config[SystemConstants.AppSettings.BaseAddress]);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            });

            services.AddHttpClient(SystemConstants.BACK_END_NAMED_CLIENT, configureClient);
        }
    }
}
