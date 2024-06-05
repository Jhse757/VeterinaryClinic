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

        #region Metodo ListAllVet: Lista todos los veterinarios
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

        #region Metodo ListVetById: Lista veterinario por Id
        public async Task<IVet> ListVetById(int id)
        {
            // Busca el objeto a listar en la base de datos
            var vet = await _context.Vets.FindAsync(id);

            // Verifica si el objeto es nulo y devuelve null si no se encuentra
            if (vet == null)
            {
                return null;
            }

            // Devuelve el objeto encontrado
            return vet;   
        }
        #endregion
    }
}
