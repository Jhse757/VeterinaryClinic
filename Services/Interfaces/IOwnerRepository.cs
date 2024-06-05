using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.DTOs;
using VeterinaryClinic.Models.Interfaces;

namespace VeterinaryClinic.Services.Interfaces
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<IOwner>> ListAllOwner();
    }
}