using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class Categoria
    {
        public int CategoriaId { get; set; }
        public string DescripcionCorta { get; set; }
        public string DescripcionLarga { get; set; }

    }
}
