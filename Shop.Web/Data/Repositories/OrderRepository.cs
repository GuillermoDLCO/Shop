namespace Shop.Web.Data.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Helpers;
    using Microsoft.EntityFrameworkCore;

    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;

        public OrderRepository(DataContext context, IUserHelper userHelper) : base(context)
        {
            this.context = context;
            this.userHelper = userHelper;
        }

        public async Task<IQueryable<Order>> GetOrdersAsync(string userName)
        {
            var user = await this.userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return null;
            }

            if (await this.userHelper.IsUserInRoleAsync(user, "Admin"))
            {
                return this.context.Orders
                    //select * from Order inner join OrderDetail inner join Product
                    //Ordenados descendentemente por fecha de orden, lo nuevo primero
                    .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                    .OrderByDescending(o => o.OrderDate);
            }

            //Si no es admin
            //select * from Order inner join OrderDetail inner join Product
            //solo del usuario
            //Ordenados descendentemente por fecha de orden, lo nuevo primero
            return this.context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Where(o => o.User == user)
                .OrderByDescending(o => o.OrderDate);
        }
    }

}
