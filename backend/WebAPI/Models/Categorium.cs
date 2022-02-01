using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            PeliculaIds = new HashSet<PeliculaId>();
        }

        public int CategoriaId { get; set; }
        public string DescripcionCorta { get; set; }
        public string DescripcionLarga { get; set; }

        public virtual ICollection<PeliculaId> PeliculaIds { get; set; }
    }
}
