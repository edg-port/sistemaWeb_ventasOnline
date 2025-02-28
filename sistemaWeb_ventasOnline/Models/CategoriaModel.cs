namespace sistemaWeb_ventasOnline.Models;

public class CategoriaModel
{
    public CategoriaModel()
    {
        categoriaNombre = "";
    }
        public int idCategoria { get; set; }
        public string categoriaNombre { get; set; }
        public ICollection<ProductoModel>? Producto { get; set; }
}