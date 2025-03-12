using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistemaWeb_ventasOnline.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace sistemaWeb_ventasOnline.Controllers
{
    public class InventarioController : Controller
    {
        private readonly AplicacionDBContext _context;

        public InventarioController(AplicacionDBContext context)
        {
            _context = context;
        }

        // LISTAR PRODUCTOS
        public IActionResult ListaInventario()
        {
           var productos = _context.Producto.Include(p => p.Categoria).ToList();
            return View(productos);
        }

        // CREAR PRODUCTO (GET)
        public IActionResult AgregarProducto()
        {
            ViewBag.Categorias = new SelectList(_context.Categoria, "idCategoria", "nombre");
            return View();
        }

        // CREAR PRODUCTO (POST)
        [HttpPost]
        public IActionResult AgregarProducto(Producto producto)
        {
            if (ModelState.IsValid)
            {
                
                _context.Producto.Add(producto);
                _context.SaveChanges();
                return RedirectToAction("ListaInventario");
            }
            ViewBag.Categorias = new SelectList(_context.Categoria, "idCategoria", "nombre");
            return View(producto);
        }

        // EDITAR PRODUCTO (GET)
        public IActionResult EditarProducto(int id)
        {
            var producto = _context.Producto.Find(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewBag.Categorias = new SelectList(_context.Categoria, "idCategoria", "nombre", producto.idCategoria);
            return View(producto);
        }

        // EDITAR PRODUCTO (POST)
        [HttpPost]
        public IActionResult EditarProducto(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Producto.Update(producto);
                _context.SaveChanges();
                return RedirectToAction("ListaInventario");
            }
            ViewBag.Categorias = new SelectList(_context.Categoria, "idCategoria", "nombre", producto.idCategoria);
            return View(producto);
        }

        // ELIMINAR PRODUCTO (POST)
         [HttpPost]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            var Inventario = await _context.Producto.FindAsync(id);
            if (Inventario != null)
            {
                _context.Producto.Remove(Inventario);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(ListaInventario));
        }
    }
}
