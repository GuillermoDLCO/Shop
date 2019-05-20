namespace Shop.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Shop.Web.Data.Entities;

    //Se hereda de IdentityDbContext que ya incluye las tablas de usuario
    //que maneja la seguridad integrada del .Net Core y va a trabajar con 
    //nuestro modelo de User
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


    }
}
