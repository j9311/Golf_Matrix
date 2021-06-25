using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GolfMatrix.Data;
using GolfMatrix.Models;
using Microsoft.AspNetCore.Authorization;

namespace GolfMatrix.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Course.ToListAsync());
        }

        // GET: Courses/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // POST: Courses/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View("Index", await _context.Course.Where(j => j.CourseName.Contains(SearchPhrase)).ToListAsync());
        }

        // POST: Courses/ShowSearchResultsSG
        public async Task<IActionResult> ShowSearchResultsSG(String SearchPhrase)
        {
            return View("Index", await _context.Course.Where(j => j.RelSGTLs.Contains(SearchPhrase)).ToListAsync());
        }

        // POST: Courses/ShowSearchResultsGrassType
        public async Task<IActionResult> ShowSearchResultsGrassType(String SearchPhrase)
        {
            return View("Index", await _context.Course.Where(j => j.GrassType.Contains(SearchPhrase)).ToListAsync());
        }

        // POST: Courses/ShowSearchResultsCourseNotes
        public async Task<IActionResult> ShowSearchResultsCourseNotes(String SearchPhrase)
        {
            return View("Index", await _context.Course.Where(j => j.CourseNotes.Contains(SearchPhrase)).ToListAsync());
        }

        // POST: Courses/ShowSearchResultsCourseNotes
        public async Task<IActionResult> ShowSearchResultsTop6(String SearchPhrase)
        {
            return View("Index", await _context.Course.Where(j => j.CourseTop6.Contains(SearchPhrase)).ToListAsync());
        }



        // GET: Courses/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,CourseName,CourseLength,TournamentName,RelSGTLs,GrassType,Par5Count,Par4Count,Par3Count,CourseNotes,Date,Outcomes,CourseTop6,CourseMap,WeatherConsiderations,StatSheet")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Edit/5

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,CourseName,CourseLength,TournamentName,RelSGTLs,GrassType,Par5Count,Par4Count,Par3Count,CourseNotes,Date,Outcomes,CourseTop6,CourseMap,WeatherConsiderations,StatSheet")] Course course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.CourseId))
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
            return View(course);
        }

        // GET: Courses/Delete/5

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Course.FindAsync(id);
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.CourseId == id);
        }
    }
}
