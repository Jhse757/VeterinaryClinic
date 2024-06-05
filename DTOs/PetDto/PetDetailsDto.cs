using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Models.Enums;

namespace VeterinaryClinic.DTOs
{
    public class PetDetailsDto
    {
        [Key]
        public int Id { get; set; }
        public string Names { get; set; }

        [Column(TypeName = "enum('Cat','Dog', Other)")]
        public Species Specie { get; set; }
        public string Race { get; set; }
        public DateTime DateBirth { get; set; }
        public int Owner_Id { get; set; }
        public string Photo { get; set; }
    }
}