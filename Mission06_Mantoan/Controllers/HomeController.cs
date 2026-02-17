using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mission06_Mantoan.Models;

namespace Mission06_Mantoan.Controllers;

public class HomeController : Controller
{
    public JoelHiltonMovieCollectionContext _context;

    public HomeController(JoelHiltonMovieCollectionContext temp)
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
        var categories = _context.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();

        ViewBag.CategoryList = new SelectList(categories, "CategoryId", "CategoryName");
        return View();
    }
// POST
    [HttpPost]
    public IActionResult AddMovie(Movie movie)
    {
        
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // If validation fails re-populate the dropdown
        var categories = _context.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();
        ViewBag.CategoryList = new SelectList(categories, "CategoryId", "CategoryName", movie.CategoryId);

        return View(movie);
    }
    public IActionResult ViewMovies()
    {
        //LINQ query to pull info 
        var Movies = _context.Movies
            .Include(m => m.Category)
            .OrderBy(m => m.Title)
            .ToList();
        return View(Movies);
    }
    //Delete
    [HttpPost]
    public IActionResult Delete(int id) //Accepts the ID to delete from the db using .Remove
    {
        var movie = _context.Movies.Find(id);

        if (movie != null)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        return RedirectToAction(nameof(ViewMovies));
    }
 //Get Edit page
 public IActionResult Edit(int id) //Opens an identical page to add Movies with a different title and has the info autopopulated
 {
     var movie = _context.Movies.Find(id);

     if (movie == null)
     {
         return NotFound();
     }

     var categories = _context.Categories
         .OrderBy(c => c.CategoryName)
         .ToList();

     ViewBag.CategoryList =
         new SelectList(categories, "CategoryId", "CategoryName", movie.CategoryId);

     return View(movie);
 }
// Post Edit
    [HttpPost]
    public IActionResult Edit(Movie movie) //posts changes...
    {
        if (ModelState.IsValid)
        {
            _context.Update(movie);
            _context.SaveChanges();
            return RedirectToAction(nameof(ViewMovies));
        }

        var categories = _context.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();

        ViewBag.CategoryList =
            new SelectList(categories, "CategoryId", "CategoryName", movie.CategoryId);

        return View(movie);
    }

}