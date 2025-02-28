using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using sistemaWeb_ventasOnline.Models;

namespace sistemaWeb_ventasOnline.Entidades
{
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; } //Llave primaria 
        public string nombre { get; set; }
        public ICollection<Producto>? Producto { get; set; } //Navegacion inversa
    }
}