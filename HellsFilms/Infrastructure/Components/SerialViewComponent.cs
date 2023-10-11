using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HellsFilms.Infrastructure.Components
{
	public class SerialViewComponent: ViewComponent
	{
		private readonly DataContext _context;

	public SerialViewComponent(DataContext context)
	{
		_context = context;
	}

	public async Task<IViewComponentResult> InvokeAsync() => View(await _context.HellsFilmsSerials.ToListAsync());
	}
}
