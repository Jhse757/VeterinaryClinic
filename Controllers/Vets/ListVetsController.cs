using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.Services.Interfaces;

namespace VeterinaryClinic.Controllers.Vets
{   
    [ApiController]
    [Route("api/vets")]
    public class ListVetsController : ControllerBase
    {
        // Inyeccion de dependencias
        private readonly IVetRepository _vetRepository;
        public ListVetsController(IVetRepository vetRepository)
        {
            _vetRepository = vetRepository;
        }
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> ListAllVetsAsync()
        {
            // Enviamos los datos al repositorio
            var vets = await _vetRepository.ListAllVets();
            if (vets == null || !vets.Any())
            {
                // retorna si la respuesta esta vacia
                return NotFound("No se encontraron veterinarios.");
            }
            // Retorna la coleccion
            return Ok(vets); 
        }

        [HttpGet]
        public async Task<IActionResult> ListVetByIdAsync([FromQuery] int id)
        {
            // Enviamos los datos al repositorio
            var vet = await _vetRepository.ListVetById(id);
            if (vet == null)
            {
                // retorna si la respuesta esta vacia
                return NotFound($"No se encontro el veterinario con el Id {id}.");
            }
            // Retorna la coleccion
            return Ok(vet); 
        }
    }
}