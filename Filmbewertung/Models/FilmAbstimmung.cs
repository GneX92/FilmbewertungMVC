using System;
using System.Collections.Generic;

namespace Filmbewertung.Models
{
    public partial class FilmAbstimmung
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public string Note { get; set; } = null!;

        public virtual Film Film { get; set; } = null!;
    }
}
