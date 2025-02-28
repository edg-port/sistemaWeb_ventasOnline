namespace  sistemaWeb_ventasOnline.Models;

public class ProductoModel
{
    public ProductoModel()
    {
        nombre = " ";
        
    }

        public int idProducto { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public int idCategoria { get; set; }
        public CategoriaModel? CategoriaModel { get; set; }
        public ICollection<DetalleModel>? Detalle { get; set; }

}
