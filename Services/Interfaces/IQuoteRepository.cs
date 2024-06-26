using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Models.Interfaces;

namespace VeterinaryClinic.Services.Interfaces
{
    public interface IQuoteRepository
    {
        Task<IEnumerable<IQuote>> ListAllQuote();
    }
}