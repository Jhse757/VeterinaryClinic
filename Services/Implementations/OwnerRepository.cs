using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Data;
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
    }
}