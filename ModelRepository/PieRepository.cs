using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.ModelRepository
{
    public class PieRepository : IPieRepository
    {
        private readonly BethanysPieShopDbContext _bethanysPieShopDbContext;

        public PieRepository(BethanysPieShopDbContext context)
        {
            _bethanysPieShopDbContext = context;
        }

        public IEnumerable<Pie> AllPies => _bethanysPieShopDbContext.Pies.Include(p => p.Category).ToList();

        public IEnumerable<Pie> PiesOfTheWeek => _bethanysPieShopDbContext.Pies.Where(p => p.IsPieOfTheWeek).ToList();

        public Pie? GetPieById(int pieId)
        {
            return _bethanysPieShopDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            return _bethanysPieShopDbContext.Pies.Where(p => p.AllergyInformation!.Contains(searchQuery)).ToList();
        }

        public IEnumerable<Pie> SearchPieByName(string name)
        {
            return _bethanysPieShopDbContext.Pies.Where(p => p.Name!.Contains(name)).ToList();
        }
    }
}
