namespace BethanysPieShop.Models
{
    public interface IPieRepository
    {
        public IEnumerable<Pie> AllPies { get; }
        public IEnumerable<Pie> PiesOfTheWeek { get; }
        Pie? GetPieById(int pieId);        
    }
}
