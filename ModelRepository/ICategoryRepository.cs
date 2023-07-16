using BethanysPieShop.Models;

namespace BethanysPieShop.ModelRepository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
