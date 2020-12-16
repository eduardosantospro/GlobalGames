using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlobalGamesCet49.Dados;
using GlobalGamesCet49.Dados.Entidades;

namespace GlobalGamesCet49.Controllers
{
    public class PedidosDeContactoController : Controller
    {
        private readonly DataContext _context;

        public PedidosDeContactoController(DataContext context)
        {
            _context = context;
        }

        // GET: PedidosDeContacto
        public async Task<IActionResult> Index()
        {
            return View(await _context.PedidosDeContacto.ToListAsync());
        }

        // GET: PedidosDeContacto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoDeContacto = await _context.PedidosDeContacto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedidoDeContacto == null)
            {
                return NotFound();
            }

            return View(pedidoDeContacto);
        }

        // GET: PedidosDeContacto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PedidosDeContacto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Mensagem")] PedidoDeContacto pedidoDeContacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoDeContacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedidoDeContacto);
        }

        // GET: PedidosDeContacto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoDeContacto = await _context.PedidosDeContacto.FindAsync(id);
            if (pedidoDeContacto == null)
            {
                return NotFound();
            }
            return View(pedidoDeContacto);
        }

        // POST: PedidosDeContacto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Mensagem")] PedidoDeContacto pedidoDeContacto)
        {
            if (id != pedidoDeContacto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidoDeContacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoDeContactoExists(pedidoDeContacto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pedidoDeContacto);
        }

        // GET: PedidosDeContacto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoDeContacto = await _context.PedidosDeContacto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedidoDeContacto == null)
            {
                return NotFound();
            }

            return View(pedidoDeContacto);
        }

        // POST: PedidosDeContacto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidoDeContacto = await _context.PedidosDeContacto.FindAsync(id);
            _context.PedidosDeContacto.Remove(pedidoDeContacto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoDeContactoExists(int id)
        {
            return _context.PedidosDeContacto.Any(e => e.Id == id);
        }
    }
}
