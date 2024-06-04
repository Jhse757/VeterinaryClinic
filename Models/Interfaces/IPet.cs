using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Models.Enums;

namespace VeterinaryClinic.Models.Interfaces
{
    public interface IPet
    {
        int Id { get; set; }
        string Names { get; set; }
        Species Specie { get; set; }        
        string Race { get; set; }
        DateTime DateBirth { get; set; }
        int Owner_Id { get; set; }
        string Photo { get; set; }
        Status Status { get; set; }
    }
}