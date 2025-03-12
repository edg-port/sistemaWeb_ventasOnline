using Microsoft.AspNetCore.Mvc;
using sistemaWeb_ventasOnline.Models;

namespace sistemaWeb_ventasOnline.Controllers
{
    public class ReportesController : Controller
    {
        public IActionResult ReporteVentas()
        {
            // Simulación de datos desde la base de datos
            var reporte = new List<ReporteVentasViewModel>
            {
                new ReporteVentasViewModel 
                {
                    FechaCompra = new DateTime(2025, 2, 12),
                    NombreCliente = "Sergio A Perez Gonzalez",
                    IdProducto = 1,
                    Categoria = "Aretes",
                    NombreProducto = "Magic Rainbow",
                    Precio = 160.00m,
                    Cantidad = 2,
                    Total = 320.00m
                },
                new ReporteVentasViewModel 
                {
                    FechaCompra = new DateTime(2025, 2, 11),
                    NombreCliente = "Pedro Chavez Garza",
                    IdProducto = 4,
                    Categoria = "Libretas",
                    NombreProducto = "Shugo Chara Sketchbook",
                    Precio = 200.00m,
                    Cantidad = 1,
                    Total = 200.00m
                },
                new ReporteVentasViewModel 
                {
                    FechaCompra = new DateTime(2025, 2, 10),
                    NombreCliente = "Javier Prado Garcia",
                    IdProducto = 5,
                    Categoria = "Dijes y Llaveros",
                    NombreProducto = "Hamster Feast",
                    Precio = 110.00m,
                    Cantidad = 3,
                    Total = 330.00m
                }
            };

            return View(reporte);
        }
    }
}
