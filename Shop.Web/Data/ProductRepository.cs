namespace Shop.Web.Data
{
    using System.Linq;
    using Entities;
    using Microsoft.EntityFrameworkCore;

    //Hereda de GenericRepository e implementa la interfaz IProductRepository
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DataContext context;

        //Inyecta el data context y se lo pasa al constructor de la clase super GenericRepository
        public ProductRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        //Para poder retornar usuarios
        public IQueryable GetAllWithUsers()
        {
            return this.context.Products.Include(p => p.User).OrderBy(p => p.Name);
        }
    }

}
