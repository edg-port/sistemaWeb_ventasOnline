using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistemaWeb_ventasOnline.Entidades;
using System.Linq;

namespace sistemaWeb_ventasOnline.Controllers
{
    public class TiendaController : Controller
    {
        private readonly AplicacionDBContext _context;

        public TiendaController(AplicacionDBContext context)
        {
            _context = context;
        }

        // Página principal con lista de productos
       public IActionResult TiendaProductos(string busqueda, int? categoriaId)
        {
            var productos = _context.Producto.Include(p => p.Categoria).AsQueryable();

            if (!string.IsNullOrEmpty(busqueda))
            {
                productos = productos.Where(p => p.nombre.Contains(busqueda));
            }

            if (categoriaId.HasValue)
            {
                productos = productos.Where(p => p.Categoria.idCategoria == categoriaId);
            }

            var categorias = _context.Categoria.ToList();
            ViewBag.Categorias = categorias;
            ViewBag.Busqueda = busqueda;
            ViewBag.CategoriaSeleccionada = categoriaId;
            
            return View(productos.ToList());
        }

        // Agregar producto al carrito
        public IActionResult AgregarAlCarrito(int id)
        {
            var producto = _context.Producto.FirstOrDefault(p => p.idProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            List<Producto> carrito = HttpContext.Session.GetObjectFromJson<List<Producto>>("Carrito") ?? new List<Producto>();

            var productoExistente = carrito.FirstOrDefault(p => p.idProducto == id);
            if (productoExistente != null)
            {
                productoExistente.cantidad += 1;
            }
            else
            {
                producto.cantidad = 1;
                carrito.Add(producto);
            }

            HttpContext.Session.SetObjectAsJson("Carrito", carrito);

            return Json(new { cantidadTotal = carrito.Sum(p => p.cantidad) });
        }

        public IActionResult Carrito()
        {
            List<Producto> carrito = HttpContext.Session.GetObjectFromJson<List<Producto>>("Carrito") ?? new List<Producto>();
            return View(carrito);
        }

        // Página de compra directa
        public IActionResult CompraDirecta(int id)
        {
            var producto = _context.Producto.FirstOrDefault(p => p.idProducto == id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // Finalizar compra directa
        public IActionResult FinalizarCompraDirecta(int id, int cantidad)
        {
            var producto = _context.Producto.FirstOrDefault(p => p.idProducto == id);
            if (producto != null && producto.cantidad >= cantidad)
            {
                producto.cantidad -= cantidad;
                _context.SaveChanges();
            }

            return RedirectToAction("TiendaProductos");
        }

        // Finalizar compra desde el carrito
        public IActionResult FinalizarCompra()
        {
            List<Producto> carrito = HttpContext.Session.GetObjectFromJson<List<Producto>>("Carrito");

            if (carrito != null && carrito.Count > 0)
            {
                foreach (var item in carrito)
                {
                    var producto = _context.Producto.FirstOrDefault(p => p.idProducto == item.idProducto);
                    if (producto != null && producto.cantidad >= item.cantidad)
                    {
                        producto.cantidad -= item.cantidad;
                    }
                }

                _context.SaveChanges();
                HttpContext.Session.Remove("Carrito"); // Vaciar carrito después de la compra
            }

            return RedirectToAction("TiendaProductos");
        }
    }
}
