using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class PeliculaCompleta
    {
    
        public int PeliculaId { get; set; }
        public string NombrePelicula { get; set; }
        public decimal Duracion { get; set; }
        public int? CategoriaId { get; set; }

        public string DescripcionCorta { get; set; }
        public string DescripcionLarga { get; set; }
    }
}
