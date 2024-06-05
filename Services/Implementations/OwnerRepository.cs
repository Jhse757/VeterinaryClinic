using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.Data;
using VeterinaryClinic.DTOs;
using VeterinaryClinic.Models.Interfaces;
using VeterinaryClinic.Services.Interfaces;

namespace VeterinaryClinic.Services.Implementations
{
    public class OwnerRepository : IOwnerRepository
    {
        // Contexto de la base de datos
        private readonly AplicationDbContext _context;
        public OwnerRepository(AplicationDbContext context)
        {
            _context = context;
        }

        #region Metodo ListAllPets: Lista todas las mascotas
        public async Task<IEnumerable<IOwner>> ListAllOwner()
        {
            // Buscamos los objetos en la base de datos
            var owners = await _context.Owners.ToListAsync();

            // verificamos la cantidad de objetos o si es nulo
            if (owners == null && owners.Any())
            {
                // Retorna una coleccion vacia
                return Enumerable.Empty<IOwner>();
            }
            // Retorna la coleccion con los objetos encontrados
            return owners;
        }
        #endregion        
        
    }
}
