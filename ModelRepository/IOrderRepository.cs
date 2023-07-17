using BethanysPieShop.Models;

namespace BethanysPieShop.ModelRepository
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
