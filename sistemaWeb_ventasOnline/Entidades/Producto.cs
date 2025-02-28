using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using sistemaWeb_ventasOnline.Models;

namespace sistemaWeb_ventasOnline.Entidades
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; } //Llave primaria
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        [ForeignKey("Categoria")]
        public int idCategoria { get; set; } //Llave foranea
        
        public Categoria? Categoria { get; set; } //Propiedad de navegacion
        public ICollection<Detalle>? Detalle { get; set; } //Navegacion inversa
    }
}