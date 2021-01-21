using GlobalGamesCet49.Dados;
using GlobalGamesCet49.Dados.Entidades;
using GlobalGamesCet49.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace GlobalGamesCet49.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sobre()
        {

            return View();
        }

        public IActionResult Servicos()
        {

            return View();
        }
        // POST: Criação do registo em PedidosDeContacto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Servicos([Bind("Id,Nome,Email,Mensagem")] PedidoDeContacto pedidoDeContacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoDeContacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Inscricoes()
        {

            return View();
        }
        // POST: Criação do registo em Inscricoes
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inscricoes([Bind("Id,Nome,Apelido,Morada,Localidade,CC,DataNasc,FicheiroDeImagem")] InscricaoViewModel view)
        {
            if (ModelState.IsValid)
            {
                // Cria-se uma variavel "caminho" (vazia inicialmente)
                var caminho = string.Empty;

                //Se FicheiroDeImagem - vindo na view - não for nulo e tiver caracteres, é porque foi passado um caminho para o ficheiro
                if (view.FicheiroDeImagem != null && view.FicheiroDeImagem.Length > 0)
                {
                    // temos a string com o caminho para guardar
                    // Path está definido em System.IO
                    // o caminho resultante resulta da concatenação da pasta no servidor com o caminho definido na app e o nome do ficheiro escolhido
                    caminho = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\FotosAvatares",
                        view.FicheiroDeImagem.FileName);
                    // para criar este ficheiro no servidor usa-se uma variavel stream em modo create:
                    using (var stream = new FileStream(caminho, FileMode.Create))
                    {
                        // usando este objecto acabado de definir guarda-se a imagem
                        await view.FicheiroDeImagem.CopyToAsync(stream);
                    }
                    // depois liberta-se o objecto (daí usar-se o "using")
                    // TODO: e combina-se o ficheiro deste lado (ver o que é isto)
                    caminho = $"~/images/FotosAvatares/{view.FicheiroDeImagem.FileName}";
                }

                // para guardar na BD, tem de se converter o InscricaoViewModel recebido em inscricao
                // cria-se um método chamado ToInscricao para fazer a conversão depois de receber a view e o caminho
                var inscricao = this.ToInscricao(view, caminho);
                _context.Add(inscricao);
                await this._context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        private Inscricao ToInscricao(InscricaoViewModel view, string caminho)
        {
            return new Inscricao
            {
                Id = view.Id,
                UrlDaImagem = caminho,
                Nome = view.Nome,
                Apelido = view.Apelido,
                Morada = view.Morada,
                Localidade = view.Localidade,
                CC = view.CC,
                DataNasc = view.DataNasc
            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
