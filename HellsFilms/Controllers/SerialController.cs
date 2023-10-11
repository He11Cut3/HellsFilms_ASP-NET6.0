using HellsFilms.Infrastructure;
using HellsFilms.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HellsFilms.Controllers
{
	public class SerialController : Controller
	{
		private readonly DataContext _context;

		public SerialController(DataContext context)
		{
			_context = context;
		}

		public async Task<HellsFilmsSerial> Load(long id)
		{
			return await _context.HellsFilmsSerials.FirstOrDefaultAsync(p => p.HellsFilmsSerialID == id);
		}

		public async Task<IActionResult> Index()
		{
			var movie = await _context.HellsFilmsSerials.ToListAsync();

			int rowCount = _context.HellsFilmsSerials.Count(); // YourEntity - это название вашей сущности

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
