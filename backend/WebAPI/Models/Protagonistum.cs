using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class Protagonistum
    {
        public Protagonistum()
        {
            PeliculaProtagonista = new HashSet<PeliculaProtagonistum>();
        }

        public int ProtagonistaId { get; set; }
        public string NombreProtagonista { get; set; }

        public virtual ICollection<PeliculaProtagonistum> PeliculaProtagonista { get; set; }
    }
}
