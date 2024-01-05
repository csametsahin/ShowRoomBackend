using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SR.Core.Utilities.IoC;
using System.Diagnostics;

namespace SR.Core.DependencyResolver
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<Stopwatch>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }
    }
}
