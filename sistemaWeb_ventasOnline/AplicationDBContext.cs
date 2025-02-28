using Microsoft.EntityFrameworkCore;
using sistemaWeb_ventasOnline.Entidades;

namespace sistemaWeb_ventasOnline;

public class AplicacionDBContext : DbContext
{
    public AplicacionDBContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Categoria> Categoria { get; set; }
    public DbSet<Cupon> Cupon { get; set; }
    public DbSet<Detalle> Detalle { get; set; }
    public DbSet<Orden> Orden { get; set; }
    public DbSet<Producto> Producto { get; set; }
    public DbSet<Usuario> Usuario { get; set; }
}