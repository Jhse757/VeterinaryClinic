using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VeterinaryClinic.DTOs
{
    public class OwnerCreateDto
    {
        [Required]
        public string Names { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}