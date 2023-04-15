using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WriteDownOnlineApi.Domain.Interface.Core;
using WriteDownOnlineApi.Infra.Repositories.Core;

namespace WriteDownOnlineApi.Infra.CrossCutting
{
    public static class NativeInjection
    {
        public static IServiceCollection InjetarDependenciasExtensions(this IServiceCollection services)
        {
            //Injetando repositórios
            //services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            //Adicionando Banco de dados
            services.AddScoped<IUnitOfWork<DbContext>, UnitOfWork<DbContext>>();
            services.AddDbContextFactory<DbContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IDapperUtil, DapperUtil>();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.SecurePolicy = CookieSecurePolicy.None;
                options.Cookie.SameSite = SameSiteMode.None;
            });

            return services;
        }
    }
}
