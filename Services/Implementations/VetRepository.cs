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
    public class VetRepository : IVetRepository
    {
        private readonly AplicationDbContext _context;
        public VetRepository(AplicationDbContext context)
        {
            _context = context;
        }

        #region Metodo ListAllOwner: Lista todos los veterinarios
        public async Task<IEnumerable<IVet>> ListAllVets()
        {
            // Buscamos los objetos en la base de datos
            var vets = await _context.Vets.ToListAsync();

            // verificamos la cantidad de objetos o si es nulo
            if (vets == null && vets.Any())
            {
                // Retorna una coleccion vacia
                return Enumerable.Empty<IVet>();
            }
            // Retorna la coleccion con los objetos encontrados
            return vets;
        }
        #endregion    
    }
}
