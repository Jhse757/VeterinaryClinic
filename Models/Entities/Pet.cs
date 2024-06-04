using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Models.Enums;

namespace VeterinaryClinic.Models.Interfaces
{
    public class Pet : IPet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Names { get; set; }

        [Column(TypeName = "enum('Cat','Dog')")]
        public Species Specie { get; set; }
        public string Race { get; set; }
        public DateOnly DateBirth { get; set; }
        public int Owner_Id { get; set; }
        public string Photo { get; set; }

        [Column(TypeName = "enum('Active','Inactive')")]
        public Status Status { get; set; }

        // Propiedades de navegación
        public Owner Owner { get; set; }
        public ICollection<Quote> Quotes { get; set; }
    }
}