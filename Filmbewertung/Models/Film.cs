using System;
using System.Collections.Generic;

namespace Filmbewertung.Models
{
    public partial class Film
    {
        public Film()
        {
            FilmAbstimmung = new HashSet<FilmAbstimmung>();
        }

        public int Id { get; set; }
        public string Titel { get; set; } = null!;

        public virtual ICollection<FilmAbstimmung> FilmAbstimmung { get; set; }
    }
}
