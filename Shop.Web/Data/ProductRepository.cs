namespace Shop.Web.Data
{
    using Entities;

    //Hereda de GenericRepository e implementa la interfaz IProductRepository
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        //Inyecta el data context y se lo pasa al constructor de la clase super GenericRepository
        public ProductRepository(DataContext context) : base(context)
        {
        }
    }

}
