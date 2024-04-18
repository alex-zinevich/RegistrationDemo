using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using RegistrationDemo.Database;
using RegistrationDemo.User.Api.Handler;

namespace RegistrationDemo.User.Api.Config.Autofac;

public class WebAutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterMediatR(typeof(GetCountriesListQuery).Assembly);
		
        builder.RegisterType<UserRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.RegisterType<CountryRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
    }
}