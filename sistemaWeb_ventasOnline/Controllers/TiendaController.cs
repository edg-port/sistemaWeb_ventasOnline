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
        [HttpPost]
        public IActionResult FinalizarCompraDirecta(int id, int cantidad)
        {
            var producto = _context.Producto.FirstOrDefault(p => p.idProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            if (cantidad <= 0 || cantidad > producto.cantidad)
            {
                TempData["Error"] = "Cantidad no válida.";
                return RedirectToAction("CompraDirecta", new { id });
            }

            producto.cantidad -= cantidad;
            _context.SaveChanges();

            TempData["Mensaje"] = "¡Compra realizada con éxito!";
            return RedirectToAction("CompraExitosa");
        }

        public IActionResult CompraExitosa()
        {
            return View();
        }


        // Finalizar compra desde el carrito
       [HttpPost]
        public IActionResult FinalizarCompra()
        {
            List<Producto> carrito = HttpContext.Session.GetObjectFromJson<List<Producto>>("Carrito") ?? new List<Producto>();

            foreach (var item in carrito)
            {
                var producto = _context.Producto.FirstOrDefault(p => p.idProducto == item.idProducto);
                if (producto != null)
                {
                    producto.cantidad -= item.cantidad;
                }
            }

            _context.SaveChanges();

            HttpContext.Session.Remove("Carrito");

            return RedirectToAction("CompraExitosa");
        }
        public IActionResult ActualizarCantidad(int id, int cantidad)
        {
            List<Producto> carrito = HttpContext.Session.GetObjectFromJson<List<Producto>>("Carrito") ?? new List<Producto>();
            var producto = carrito.FirstOrDefault(p => p.idProducto == id);

            if (producto != null)
            {
                producto.cantidad = cantidad;
                HttpContext.Session.SetObjectAsJson("Carrito", carrito);
            }

            decimal subtotal = producto.precio * producto.cantidad;
            decimal total = carrito.Sum(p => p.precio * p.cantidad);

            return Json(new { subtotal = subtotal.ToString("0.00"), total = total.ToString("0.00") });
        }

        public IActionResult EliminarDelCarrito(int id)
        {
            List<Producto> carrito = HttpContext.Session.GetObjectFromJson<List<Producto>>("Carrito") ?? new List<Producto>();
            carrito.RemoveAll(p => p.idProducto == id);
            
            HttpContext.Session.SetObjectAsJson("Carrito", carrito);
            
            decimal total = carrito.Sum(p => p.precio * p.cantidad);
            
            return Json(new { total = total.ToString("0.00") });
        }
    }
}
