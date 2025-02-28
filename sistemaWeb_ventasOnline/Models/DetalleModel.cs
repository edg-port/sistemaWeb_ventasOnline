namespace sistemaWeb_ventasOnline.Models;

public class DetalleModel 
{
        public int idDetalle { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public OrdenModel? OrdenModel { get; set; }
}