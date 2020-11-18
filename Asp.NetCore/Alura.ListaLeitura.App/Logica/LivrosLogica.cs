using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosLogica
    {
        private static string CarregaLista(IEnumerable<Livro> livros)
        {
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("lista");
            foreach (var livro in livros)
            {
                conteudoArquivo = conteudoArquivo
                    .Replace("#NOVO-ITEM", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM");
            }
            return conteudoArquivo.Replace("#NOVO-ITEM", "");
        }

        public static Task LivrosParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("para-ler");

            foreach (var livro in _repo.ParaLer.Livros)
            {
                conteudoArquivo = conteudoArquivo
                    .Replace("#NOVO-ITEM", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM");
            }
            conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM", "");

            return context.Response.WriteAsync(conteudoArquivo);
        }

        public static Task LivrosLendo(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("lendo");

            foreach (var livro in _repo.Lendo.Livros)
            {
                conteudoArquivo = conteudoArquivo
                    .Replace("#NOVO-ITEM", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM");
            }
            conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM", "");

            return context.Response.WriteAsync(conteudoArquivo);
        }

        public static Task LivrosLidos(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("lidos");

            foreach (var livro in _repo.Lidos.Livros)
            {
                conteudoArquivo = conteudoArquivo
                    .Replace("#NOVO-ITEM", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM");
            }
            conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM", "");

            return context.Response.WriteAsync(conteudoArquivo);
        }
    }
}
