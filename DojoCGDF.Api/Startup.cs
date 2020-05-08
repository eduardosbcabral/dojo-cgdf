using DojoCGDF.Core.Domain.Services;
using DojoCGDF.Core.Infrastructure;
using DojoCGDF.Core.Infrastructure.Config.Seeds;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DojoCGDF.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DojoCGDFDbContext>(opt => opt.UseInMemoryDatabase("DojoCGDF"));

            services.AddScoped<IPublicacaoService, PublicacaoService>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Dojô CGDF",
                        Version = "v1",
                        Description = "API utilizada no dojô da CGDF"
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DojoCGDFDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API DOJO CGDF V1");
            });

            // Recuperando o contexto que foi injetado por parametro
            // e adicionando os dados no banco em memória
            Dados.Adicionar(context);

            // Verifica qual rota deve ser utilizada para a URL.
            // Adiciona metadados para serem usados
            // nos próximos middlewares
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Utilizar os endpoints das controllers criadas
                endpoints.MapControllers();
            });
        }
    }
}
