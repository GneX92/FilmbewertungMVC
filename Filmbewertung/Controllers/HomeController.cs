using Filmbewertung.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Filmbewertung.Controllers
{
    public class HomeController : Controller
    {
        private readonly NETDBContext context = new NETDBContext();

        public IActionResult Index()
        {
            return View(context.Film);
        }

        [HttpPost]
        public IActionResult Wertung(FilmAbstimmung eineBewertung)
        {
            // Bewertung für den ausgewählten Film in der Datenbank speichern
            context.FilmAbstimmung.Add(eineBewertung);
            context.SaveChanges();

            // Gewähltes Film-Objekt aus der Liste suchen
            Film film = context.Film.Find(eineBewertung.FilmId);

            return View(film);
        }

    }
}