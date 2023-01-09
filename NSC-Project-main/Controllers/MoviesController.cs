using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NSC_project.Data;
using NSC_project.Models;
using NSC_project.Models.NSCViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSC_project.Controllers
{
    public class MoviesController : Controller
    {
        private readonly NSC_projectContext _context;

        public MoviesController(NSC_projectContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return _context.Movie != null ?
                        View(await _context.Movie.ToListAsync()) :
                        Problem("Entity set 'NSC_projectContext.Movie'  is null.");
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Details/5
        //// 
        public async Task<IActionResult> Ticket(int? id, int? theaterId, int? auditoriumId)
        {

            var viewModel = new TicketData();
            viewModel.Movies = await _context.Movie
                .Where(m => m.Id == id)
                  .Include(m => m.Screenings)
                  .Include(m => m.Screenings)
                    .ThenInclude(m => m.Theater)
                    .ThenInclude(m => m.TheaterAddress)
                  .Include(m => m.Screenings)
                    .ThenInclude(m => m.Auditorium)
                  .Include(m => m.Screenings)
                    .ThenInclude(m => m.Auditorium)
                        .ThenInclude(m => m.Seats)
                  .AsNoTracking()
                  .OrderBy(m => m.Title)
                  .ToListAsync();


            ViewData["MovieID"] = id.Value;

            if (id != null)
            {
                Movie movie = viewModel.Movies.Single();
                viewModel.Screenings = movie.Screenings;
                viewModel.TheaterAddresses = await _context.TheaterAddress.ToListAsync();
                viewModel.Theaters = viewModel.Screenings.Select(m => m.Theater);
            }

            if (theaterId != null)
            {
                ViewData["theaterId"] = theaterId.Value;
                viewModel.Auditoriums = viewModel.Screenings.Where(x => x.TheaterId == theaterId).Select(a => a.Auditorium);
                // viewModel.Auditoriums = viewModel.Theaters.Where(x => x.Id == theaterId).Single().Auditoriums;

            }

            if (auditoriumId != null)
            {
                ViewData["auditoriumId"] = auditoriumId.Value;
                var screening = await _context.Screening
               .Include(s => s.ReservedSeats)
               .Include(s => s.Auditorium)
                   .ThenInclude(s => s.Seats)
               .AsNoTracking()
               .FirstOrDefaultAsync(m => m.Id == id);
                PopulateAssignedCourseData(screening, auditoriumId);
            }

            return View(viewModel);
        }

        private void PopulateAssignedCourseData(Screening screening, int? auditoriumId)
        {
            var allSeats = _context.Seat.Where(s => s.AuditoriumId == auditoriumId);
            var reservedSeats = new HashSet<int>(screening.ReservedSeats.Select(r => r.SeatId));
            var viewModel = new List<SeatData>();
            foreach (var seat in allSeats)
            {
                viewModel.Add(new SeatData
                {
                    SeatID = seat.Id,
                    Number = seat.Number,
                    Assigned = reservedSeats.Contains(seat.Id)
                });
            }
            ViewData["Seats"] = viewModel;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTicket([Bind("Id,Title,Director,Actor,Duration_min,Opening_date,Genre,Description,Image")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }


        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Director,Actor,Duration_min,Opening_date,Genre,Description,Image")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Director,Actor,Duration_min,Opening_date,Genre,Description,Image")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movie == null)
            {
                return Problem("Entity set 'NSC_projectContext.Movie'  is null.");
            }
            var movie = await _context.Movie.FindAsync(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return (_context.Movie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
