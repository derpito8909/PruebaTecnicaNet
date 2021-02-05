using System;
using System.Collections.Generic;    
using System.ComponentModel.DataAnnotations;    
using System.Linq;    
using System.Threading.Tasks; 

namespace pruebaTecnica2.Models
{
    public class Terceros
    {
        public int idTercero {get; set;}
        [Required]
        public string cedula {get; set;}
        [Required]
        public string nombres {get; set;}
        [Required]
        public string apellidos { get; set; }
        [Required]
        public string razonSocial { get; set; }
    }
}