namespace sistemaWeb_ventasOnline.Models
{
    public class ReporteVentasViewModel
    {
        public DateTime FechaCompra { get; set; }
        public string NombreCliente { get; set; }
        public int IdProducto { get; set; }
        public string Categoria { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}