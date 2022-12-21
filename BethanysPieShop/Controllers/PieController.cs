using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            PieListViewModel pieListViewModel =
                        new PieListViewModel(_pieRepository.AllPies, "All pies"); 
                        
            return View(pieListViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if(pie is null)
            {
                return NotFound(new { status = $"Sorry ! The pie {id} is not availale at the moment." });
            }

            var pieDetails = new DetailsViewModel(pie);
            return View(pieDetails);
        }
    }
}
 