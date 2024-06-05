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
    public class DeletePetController : ControllerBase
    {
        // Inyeccion de dependencias
        private readonly IPetRepository _petRepository;
        public DeletePetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        [HttpPatch]
        [Route ("delete")]
        public async Task<IActionResult> DeletePetByIdAsync([FromQuery] int id)
        {
            var result = await _petRepository.DeletePetById(id);

            if (!result)
            {
                return NotFound($"No se encontró una mascota con el ID {id}. Verifique que el ID sea correcto.");
            }
            return Ok("la mascota con el ID {id} ha sido eliminado exitosamente.");
        }        
    }
}