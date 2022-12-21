using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BethanysPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly BethanysPieShopContext _bethanysPieShopContext;

        public PieRepository(BethanysPieShopContext bethanysPieShopContext)
        {
            _bethanysPieShopContext = bethanysPieShopContext;
        }

        public IEnumerable<Pie> AllPies => _bethanysPieShopContext.Pies
                                                .Include(ct => ct.Category);


        public IEnumerable<Pie> PiesOfTheWeek => _bethanysPieShopContext.Pies
                                                        .Include(ct => ct.Category).Where(p => p.IsPieOfTheWeek);
                                                        

        public Pie? GetPieById(int pieId) => _bethanysPieShopContext.Pies.FirstOrDefault(p => p.PieId == pieId) ;

        public Pie SearchPie(string searchQuery) {
            throw new NotImplementedException();
        }        
    }
}
