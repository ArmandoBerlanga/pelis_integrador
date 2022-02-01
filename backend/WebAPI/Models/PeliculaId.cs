using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class PeliculaId
    {
        public PeliculaId()
        {
            PeliculaProtagonista = new HashSet<PeliculaProtagonistum>();
        }

        public int PeliculaId1 { get; set; }
        public string NombrePelicula { get; set; }
        public decimal Duracion { get; set; }
        public int? CategoriaId { get; set; }

        public virtual Categorium Categoria { get; set; }
        public virtual ICollection<PeliculaProtagonistum> PeliculaProtagonista { get; set; }
    }
}
