using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.Models.Enums;

namespace VeterinaryClinic.Models.Interfaces
{
    public class Owner : IOwner
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Names { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        [Column(TypeName = "enum('Active','Inactive')")]
        public Status Status { get; set; }
        
        // Propiedades de navegación
        public ICollection<Pet> Pets { get; set; }

    }
}