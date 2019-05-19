namespace Shop.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;

    public class SeedDb
    {
        private readonly DataContext context;
        private Random random;

        //Se le inyecta la conexion a la base de datos
        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        //Es el q va a alimentar a la base de datos
        public async Task SeedAsync()
        {
            //Espera a que la base de datos este creada, en caso q la este creando
            await this.context.Database.EnsureCreatedAsync();

            //Si no hay ningun producto los crea
            if (!this.context.Products.Any())
            {
                this.AddProduct("iPhone X");
                this.AddProduct("Magic Watch");
                this.AddProduct("iWatched Series 4");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(100),
                IsAvailabe = true,
                Stock = this.random.Next(100)
            });
        }
    }

}
