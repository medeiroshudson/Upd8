using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Upd8.Infra.CrossCutting.IOC;

namespace Upd8.Api.Extensions
{
    public static class ConfigureAutofac
    {
        public static IHostBuilder AddAutofacModule(this WebApplicationBuilder builder)
        {
            return builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacModule());
                });
        }
    }
}

