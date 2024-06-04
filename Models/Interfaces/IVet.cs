using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Models.Enums;

namespace VeterinaryClinic.Models.Interfaces
{
    public interface IVet
    {
        int Id { get; set; }
        string Names { get; set; }
        string LastName { get; set; }        
        string Email { get; set; }
        string Address { get; set; }
        string Phone { get; set; }
        Status Status { get; set; }
    }
}