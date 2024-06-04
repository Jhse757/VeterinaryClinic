using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Data;
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
    }
}