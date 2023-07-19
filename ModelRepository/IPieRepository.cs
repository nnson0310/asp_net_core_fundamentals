using BethanysPieShop.Models;

namespace BethanysPieShop.ModelRepository
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        Pie? GetPieById(int pieId);
        IEnumerable<Pie> SearchPies(string searchQuery);
        IEnumerable<Pie> SearchPieByName(string pieName);
    }
}
