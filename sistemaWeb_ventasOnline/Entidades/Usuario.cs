using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using sistemaWeb_ventasOnline.Models;

namespace sistemaWeb_ventasOnline.Entidades
{
    public class Usuario
    {
        internal string nombreUsuario;

        [Key]
        public int idUsuario { get; set; } //Llave primaria
        public string nombre { get; set; }
        public string email { get; set; }
        public string contraseña { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public ICollection<Orden>? Orden { get; set; } //Navegacion inversa
    }
}