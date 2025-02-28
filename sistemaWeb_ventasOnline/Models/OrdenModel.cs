namespace sistemaWeb_ventasOnline.Models;

public class OrdenModel 
{
        public int idOrden { get; set; }
        public int? idUsuario { get; set; }
        public DateTime fechaOrden { get; set; }
        public decimal total { get; set; }
        public int? idCupon { get; set; }
        public int idDetalle { get; set; }
        public CuponModel? CuponModel { get; set; }
        public DetalleModel? DetalleModel { get; set; }
        public UsuarioModel? UsuarioModel { get; set; }
        public ICollection<CuponModel>? Cupon { get; set; }

}