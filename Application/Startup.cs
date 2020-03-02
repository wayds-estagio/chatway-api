using Hubs.Hubs;
using Infrastructure.Context;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Services;

namespace Application {

    public class Startup {

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services.AddSingleton<ContextDB>();

            services.AddSingleton<EmpresaService>();
            services.AddSingleton<UnidadeService>();
            services.AddSingleton<UsuarioService>();
            services.AddSingleton<ChamadoService>();
            services.AddSingleton<MensagemService>();
            services.AddSingleton<ChatService>();
            services.AddSingleton<MensagemPadraoService>();

            services.AddSingleton<EmpresaRepository>();
            services.AddSingleton<UnidadeRepository>();
            services.AddSingleton<UsuarioRepository>();
            services.AddSingleton<ChamadoRepository>();
            services.AddSingleton<MensagemRepository>();
            services.AddSingleton<ChatRepository>();

            services.AddSignalR();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                endpoints.MapHub<ChatWayHub>("/ChatWay");
            });
        }
    }
}