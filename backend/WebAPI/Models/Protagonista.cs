using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebAPI.Models
{
    public partial class Protagonista
    {
  
        public int ProtagonistaId { get; set; }
        
        public string NombreProtagonista { get; set; }

    }
}
