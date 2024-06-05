using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Models.Interfaces;

namespace VeterinaryClinic.Services.Interfaces
{
    public interface IVetRepository
    {
        Task<IEnumerable<IVet>> ListAllVets();
    }
}