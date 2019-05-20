namespace Shop.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using Helpers;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private Random random;

        //Se le inyecta la conexion a la base de datos, y el IUserHelper
        //en lugar de userManager
        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        //Es el q va a alimentar a la base de datos
        public async Task SeedAsync()
        {
            //Espera a que la base de datos este creada, en caso q la este creando
            await this.context.Database.EnsureCreatedAsync();

            //Busca si ya hay un usuario con ese correo
            var user = await this.userHelper.GetUserByEmailAsync("guillermo.dlco@outlook.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Guillermo",
                    LastName = "De La Cruz",
                    Email = "guillermo.dlco@outlook.com",
                    UserName = "guillermo.dlco@outlook.com",
                    PhoneNumber = "979301935"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

            //Si no hay ningun producto los crea
            if (!this.context.Products.Any())
            {
                this.AddProduct("iPhone X", user);
                this.AddProduct("Magic Watch", user);
                this.AddProduct("iWatched Series 4", user);
                await this.context.SaveChangesAsync();
            }
        }

        //Se agrega tambien el usuario
        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(100),
                IsAvailabe = true,
                Stock = this.random.Next(100),
                User = user
            });
        }
    }

}
