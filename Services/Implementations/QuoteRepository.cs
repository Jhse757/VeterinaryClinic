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
    public class QuoteRepository : IQuoteRepository
    {
        // Contexto de la base de datos
        private readonly AplicationDbContext _context;
        public QuoteRepository(AplicationDbContext context)
        {
            _context = context;
        }

        #region Metodo ListAllQuote: Lista todas las citas
        public async Task<IEnumerable<IQuote>> ListAllQuote()
        {
            // Buscamos los objetos en la base de datos
            var quotes = await _context.Quotes.ToListAsync();

            // verificamos la cantidad de objetos o si es nulo
            if (quotes == null && quotes.Any())
            {
                // Retorna una coleccion vacia
                return Enumerable.Empty<IQuote>();
            }
            // Retorna la coleccion con los objetos encontrados
            return quotes;
        }
        #endregion
    }
}