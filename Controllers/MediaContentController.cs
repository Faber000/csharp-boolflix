using csharp_boolflix.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace csharp_boolflix.Controllers
{
    public class MediaContentController : Controller
    {
        private readonly ILogger<MediaContentController> _logger;

        public MediaContentController(ILogger<MediaContentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            using (BoolflixDbContext context = new BoolflixDbContext())
            {

                FilmSerie filmSerie = new FilmSerie();

                filmSerie.Films = context.Films.Include("MediaInfo").ToList();
                filmSerie.TvSeries = context.TvSeries.Include("MediaInfo").ToList();
                filmSerie.Genres = context.Genres.ToList();
                filmSerie.Actors = context.Actors.ToList();

                return View("Index", filmSerie);
            }
        }

        [HttpGet]
        public IActionResult Create(string type)
        {
            using (BoolflixDbContext context = new BoolflixDbContext())
            {

                FilmSerieToInsert filmSerie = new FilmSerieToInsert();

                filmSerie.Genres = context.Genres.ToList();

                ViewData["Type"] = type;

                return View("Create", filmSerie);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FilmSerieToInsert formData)
        {
            using (BoolflixDbContext context = new BoolflixDbContext())
            {
                if (formData.Film != null)
                {
                    Film newFilm = new Film();

                    newFilm.Title = formData.Film.Title;
                    newFilm.Description = formData.Film.Description;
                    newFilm.Duration = formData.Film.Duration;

                    MediaInfo mediaInfo = new MediaInfo();

                    List<Genre> genresList = new List<Genre>();

                    mediaInfo.Generes = genresList;

                    newFilm.MediaInfo = mediaInfo;

                    newFilm.MediaInfo.Year = formData.Film.MediaInfo.Year;

                    newFilm.MediaInfo.Generes = context.Genres.Where(genre => formData.SelectedGenres.Contains(genre.Id)).ToList<Genre>();

                    context.Films.Add(newFilm);


                    context.SaveChanges();

                    return RedirectToAction("Index");
                }

                else
                {
                    TVSeries newSerie = new TVSeries();

                    newSerie.Title = formData.TvSerie.Title;
                    newSerie.Description = formData.TvSerie.Description;
                    newSerie.Duration = formData.TvSerie.Duration;
                    newSerie.SeasonCount = formData.TvSerie.SeasonCount;

                    MediaInfo mediaInfo = new MediaInfo();

                    newSerie.MediaInfo = mediaInfo;

                    newSerie.MediaInfo.Year = formData.TvSerie.MediaInfo.Year;

                    context.TvSeries.Add(newSerie);

                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
                
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}