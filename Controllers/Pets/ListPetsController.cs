using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.Services.Interfaces;

namespace VeterinaryClinic.Controllers.Pets
{   
    [ApiController]
    [Route("api/pets")]
    public class ListPetsController : ControllerBase
    {
        private readonly IPetRepository _petRepository;
        public ListPetsController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> ListAllPetsAsync()
        {
            // Enviamos los datos al repositorio
            var pets = await _petRepository.ListAllPets();
            if (pets == null || !pets.Any())
            {
                // retorna si la respuesta esta vacia
                return NotFound("No se encontraron mascotas.");
            }
            // Retorna la coleccion
            return Ok(pets); 
        }
        
    }
}