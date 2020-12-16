﻿using GlobalGamesCet49.Dados;
using GlobalGamesCet49.Dados.Entidades;
using GlobalGamesCet49.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
