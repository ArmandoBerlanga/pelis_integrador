using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class PeliculaProtagonistum
    {
        public int PeliculaId { get; set; }
        public int ProtagonistaId { get; set; }

        public virtual PeliculaId Pelicula { get; set; }
        public virtual Protagonistum Protagonista { get; set; }
    }
}
