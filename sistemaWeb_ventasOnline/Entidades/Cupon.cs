using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using sistemaWeb_ventasOnline.Models;

namespace sistemaWeb_ventasOnline.Entidades
{
    public class Cupon
    {
        [Key]
         public int idCupon { get; set; } //Llave primaria 
        public string codigo { get; set; }
        public decimal descuento { get; set; }
        public DateTime fechaExpiracion { get; set; }
        public int usoMaximo { get; set; }
        public int usosActuales { get; set; }
        public ICollection<Orden>? Orden { get; set; } //Navegacion inversa
    }
}