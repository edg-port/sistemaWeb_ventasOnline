namespace sistemaWeb_ventasOnline.Models;

public class CuponModel 
{
    public CuponModel()
    {
        codigo = "";
    }
        public int idCupon { get; set; }
        public string codigo { get; set; }
        public decimal descuento { get; set; }
        public DateTime fechaExpiracion { get; set; }
        public int usoMaximo { get; set; }
        public int usosActuales { get; set; }
        public ICollection<OrdenModel>? Orden { get; set; }
}