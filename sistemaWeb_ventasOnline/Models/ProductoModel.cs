using System.ComponentModel.DataAnnotations;

namespace  sistemaWeb_ventasOnline.Models;

public class ProductoModel
{
    public ProductoModel()
    {
        nombre = " ";
        
    }

        public int idProducto { get; set; }
        
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "El nombre no puede contener caracteres especiales.")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
        public decimal precio { get; set; }

        [Required(ErrorMessage = "Debe proporcionar una URL de imagen.")]
        [Url(ErrorMessage = "Debe ingresar una URL válida.")]
        public string? ImagenUrl { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que 0.")]
        public int cantidad { get; set; }
        public int idCategoria { get; set; }
        public CategoriaModel? CategoriaModel { get; set; }
        public ICollection<DetalleModel>? Detalle { get; set; }

}
