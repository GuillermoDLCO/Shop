namespace Shop.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Shop.Web.Data.Entities;
    using System.Linq;

    //Se hereda de IdentityDbContext que ya incluye las tablas de usuario
    //que maneja la seguridad integrada del .Net Core y va a trabajar con 
    //nuestro modelo de User
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<OrderDetailTemp> OrderDetailTemps { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //El campo price me lo vas a mapear como tipo decimal en sql
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                //18 numero de los cuales 2 se usaran para el decimal
                .HasColumnType("decimal(18,2)");

            /*****/
            //Cuando se vaya a borrar un registro que tenga relacion con otro, no se permita
            //Va a generar un error
            var cascadeFKs = modelBuilder.Model
                .G­etEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restr­ict;
            }
            /****/

            base.OnModelCreating(modelBuilder);
        }


    }
}
