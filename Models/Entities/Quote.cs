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
    public class Quote : IQuote
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Pet_Id { get; set; }

        [Required]
        public int Vet_Id { get; set; }
        public string Descrition { get; set; }

        [Column(TypeName = "enum('Active','Inactive')")]
        public Status Status { get; set; }

        // Propiedades de navegación
        public Pet Pet { get; set; }
        public Vet Vet { get; set; }
    }
}