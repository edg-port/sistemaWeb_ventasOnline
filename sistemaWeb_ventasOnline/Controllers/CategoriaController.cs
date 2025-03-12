using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistemaWeb_ventasOnline.Entidades;
using System.Threading.Tasks;

namespace sistemaWeb_ventasOnline.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly AplicacionDBContext _context;

        public CategoriasController(AplicacionDBContext context)
        {
            _context = context;
        }

        // LISTAR CATEGORÍAS
        public async Task<IActionResult> ListaCategorias()
        {
            var categorias = await _context.Categoria.ToListAsync();
            return View(categorias);
        }

// GET: Agregar Categoría
[HttpGet]
public IActionResult AgregarCategoria()
{
    return View();
}

// POST: Agregar Categoría
[HttpPost]
public async Task<IActionResult> AgregarCategoria(Categoria categoria)
{
    if (ModelState.IsValid)
    {
        _context.Categoria.Add(categoria);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(ListaCategorias));
    }
    return View(categoria);
}

// GET: Editar Categoría
[HttpGet]
public async Task<IActionResult> EditarCategoria(int id)
{
    var categoria = await _context.Categoria.FindAsync(id);
    if (categoria == null)
        return NotFound();

    return View(categoria);
}

// POST: Editar Categoría
[HttpPost]
public async Task<IActionResult> EditarCategoria(Categoria categoria)
{
    if (ModelState.IsValid)
    {
        _context.Categoria.Update(categoria);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(ListaCategorias));
    }
    return View(categoria);
    }

        // ELIMINAR CATEGORÍA
        [HttpPost]
        public async Task<IActionResult> EliminarCategoria(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria != null)
            {
                _context.Categoria.Remove(categoria);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(ListaCategorias));
        }
    }
}
