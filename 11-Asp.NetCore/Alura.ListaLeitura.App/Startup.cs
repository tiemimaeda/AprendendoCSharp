using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        //injeta serviço de roteamento 
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddRouting();
            services.AddMvc();
        }

        //mapeia a lógica de roteamento
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();

            //var builder = new RouteBuilder(app);
            ////builder.MapRoute("{controller}/{action}", RoteamentoPadrao.TratamentoPadrao);

            //builder.MapRoute("Livros/ParaLer", LivrosLogica.ParaLer);
            //builder.MapRoute("Livros/Lendo", LivrosLogica.Lendo);
            //builder.MapRoute("Livros/Lidos", LivrosLogica.Lidos);
            //builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", CadastroLogica.NovoLivro);
            //builder.MapRoute("Livros/Detalhes/{id:int}", CadastroLogica.Detalhes);
            //builder.MapRoute("Cadastro/ExibeFormulario", CadastroLogica.ExibeFormulario);
            //builder.MapRoute("Cadastro/Incluir", CadastroLogica.Incluir);

            //var rotas = builder.Build();

           // app.UseRouter(rotas);
        }

       
        
    }
}