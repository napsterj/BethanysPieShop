using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels
{
    public class DetailsViewModel
    {
        public Pie Pie { get; }

        public DetailsViewModel(Pie pie)
        {
            Pie = pie;
        }
    }
}
