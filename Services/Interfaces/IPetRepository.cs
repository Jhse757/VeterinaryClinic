using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.DTOs;
using VeterinaryClinic.Models.Interfaces;

namespace VeterinaryClinic.Services.Interfaces
{
    public interface IPetRepository
    {
        Task<IEnumerable<IPet>> ListAllPets();
        Task<IPet> CreatePet(PetCreateDto petCreateDto);
        Task<IPet> ListPetById(int id);
        Task<bool> UpdatePet(IPet pet);
        Task<bool> DeletePetById(int id);
    }
}