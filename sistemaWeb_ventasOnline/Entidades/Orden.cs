using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using sistemaWeb_ventasOnline.Models;

namespace sistemaWeb_ventasOnline.Entidades
{
    public class Orden
    {
        [Key]
        public int idOrden { get; set; } //Llave primaria 
        [ForeignKey("Usuario")]
        public int idUsuario { get; set; } //Llave foranea 
        public DateTime fechaOrden { get; set; }
        public decimal total { get; set; }
        [ForeignKey("Cupon")]
        public int idCupon { get; set; } //Llave foranea 
        [ForeignKey("Detalle")]
        public int idDetalle { get; set; } //Llave foranea 
        public Detalle? Detalle { get; set; } //Propiedad de navegacion
        public Cupon? Cupon { get; set; } //Propiedad de navegacion
        public Usuario? Usuario { get; set; } //Propiedad de navegacion
    }
}