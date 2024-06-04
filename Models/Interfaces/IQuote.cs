using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Models.Enums;

namespace VeterinaryClinic.Models.Interfaces
{
    public interface IQuote
    {
        int Id { get; set; }
        DateTime Date { get; set; }
        int Pet_Id { get; set; }        
        int Vet_Id { get; set; }        
        string Descrition { get; set; }
        Status Status { get; set; }
    }
}