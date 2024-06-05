using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Models.Enums;

namespace VeterinaryClinic.Models.Interfaces
{
    public class Vet : IVet
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Names { get; set; }

        [Required]
        public string LastNames { get; set; }

        [Required]
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        
        [Column(TypeName = "enum('Active','Inactive')")]
        public Status Status { get; set; }
    
        // Propiedades de navegación
        public Collection<Quote> Quotes { get; set; }    
    }
}