using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.Data;
using VeterinaryClinic.Models.Interfaces;
using VeterinaryClinic.Services.Interfaces;

namespace VeterinaryClinic.Services.Implementations
{
    public class PetRepository : IPetRepository
    {
        // Contexto de la base de datos
        private readonly AplicationDbContext _context;
        public PetRepository(AplicationDbContext context)
        {
            _context = context;
        }

        #region Metodo ListAllPets: Lista todas las mascotas
        public async Task<IEnumerable<IPet>> ListAllPets()
        {
            // Buscamos los objetos en la base de datos
            var pets = await _context.Pets.ToListAsync();

            // verificamos la cantidad de objetos o si es nulo
            if (pets == null && pets.Any())
            {
                // Retorna una coleccion vacia
                return Enumerable.Empty<IPet>();
            }
            // Retorna la coleccion con los objetos encontrados
            return pets;
        }
        #endregion
    }
}