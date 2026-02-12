using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Mantoan.Models;

namespace Mission06_Mantoan.Controllers;

public class HomeController : Controller
{
    public MovieContext _context;

    public HomeController(MovieContext temp)
    {
        _context = temp;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnow()
    {
        return View();
    }

    public IActionResult AddMovie()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AddMovie(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("AddMovie"); 
        }

        return View(movie);
    }
    public IActionResult ViewMovies()
    {
        var Movies = _context.Movies
            .OrderBy(x => x.Title).ToList();
        return View(Movies);
    }
}