using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.Services.Interfaces;

namespace VeterinaryClinic.Controllers.Quotes
{   
    [ApiController]
    [Route("api/quotes")]
    public class ListQuotesController : ControllerBase
    {
        // Inyeccion de dependencias
        private readonly IQuoteRepository _quoteRepository;
        public ListQuotesController(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> ListAllQuotesAsync()
        {
            // Enviamos los datos al repositorio
            var quotes = await _quoteRepository.ListAllQuote();
            if (quotes == null || !quotes.Any())
            {
                // retorna si la respuesta esta vacia
                return NotFound("No se encontraron mascotas.");
            }
            // Retorna la coleccion
            return Ok(quotes); 
        }
    }
}