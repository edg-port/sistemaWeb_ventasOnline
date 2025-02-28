namespace sistemaWeb_ventasOnline.Models;

public class UsuarioModel
{
    public UsuarioModel()
    {
        nombreUsuario = "";
        email = "";
        contraseña = "";
        direccion = "";
        telefono = "";
    }
        public int idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string email { get; set; }
        public string contraseña { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public ICollection<OrdenModel>? Orden { get; set; }
}