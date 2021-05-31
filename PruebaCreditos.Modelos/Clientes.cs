using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCreditos.Modelos 
{
    public class Clientes : IdentityUser
    {
        [Required]
        public string Cedula { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        public virtual List<Credito> Credito { get; set; }
    }
}
