using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using sistemaWeb_ventasOnline.Models;

namespace sistemaWeb_ventasOnline.Entidades
{
    public class Detalle
    {
        [Key]
        public int idDetalle { get; set; } //Llave primaria
        [ForeignKey("Producto")]
        public int idProducto { get; set; } //Llave foranea 
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public Producto? Producto { get; set; } //Propiedad de navegacion
        public ICollection<Orden>? Orden { get; set; } //Navegacion inversa
    }
}