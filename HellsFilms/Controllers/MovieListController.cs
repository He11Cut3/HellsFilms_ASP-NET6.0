using HellsFilms.Infrastructure;
using HellsFilms.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HellsFilms.Controllers
{
    public class MovieListController : Controller
    {
        private readonly DataContext _context;

        public MovieListController(DataContext context)
        {
            _context = context;
        }

		public async Task<HellsFilmsMovie> Load(long id)
		{
			return await _context.HellsFilmsMovies.FirstOrDefaultAsync(p => p.HellsFilmsMovieID == id);
		}

		public async Task<IActionResult> Index()
        {
            var movie = await _context.HellsFilmsMovies.ToListAsync();

			int rowCount = _context.HellsFilmsMovies.Count(); // YourEntity - это название вашей сущности

			ViewBag.RowCount = rowCount;

			return View(movie);
        }
		public async Task<IActionResult> Details(long id)
		{

			var product = await Load(id);

			if (product == null)
			{
				return NotFound(); // Если продукт с указанным id не найден, возвращаем HTTP 404
			}

			return View(product);
		}


	}
}
