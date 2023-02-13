using System;
using Autofac;
using Upd8.Application.Services;
using Upd8.Domain.Interfaces.Repositories;
using Upd8.Domain.Interfaces.Services;
using Upd8.Infra.Data.Repositories;

namespace Upd8.Infra.CrossCutting.IOC
{
	public class AutofacModule : Module
	{
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
        }
    }
}

