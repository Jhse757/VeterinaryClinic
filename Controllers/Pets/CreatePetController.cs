using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.DTOs;
using VeterinaryClinic.Models.Enums;
using VeterinaryClinic.Services.Implementations;
using VeterinaryClinic.Services.Interfaces;

namespace VeterinaryClinic.Controllers.Pets
{
    [ApiController]
    [Route("api/pets")]
    public class CreatePetController : ControllerBase
    {
        // Inyeccion de dependencias
        private readonly IPetRepository _petRepository;
        public CreatePetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreatePetAsync([FromBody] PetCreateDto petCreateDto)
        {
            // Verifica que el objeto no sea nulo
            if (petCreateDto == null)
            {
                return BadRequest("El objeto de la mascota esta nulo");
            }

            // Enviamos los datos al repositorio
            var addedPet = await _petRepository.CreatePet(petCreateDto);

            // Verifica que el objeto no sea nulo
            if (addedPet == null)
            {
                // retorna si no se agrego a la DB
                return StatusCode(500, "Se produjo un error al crear el la mascota");
            }

            // Retorna el objeto agregado
            return Ok(addedPet);
        }
    }
}