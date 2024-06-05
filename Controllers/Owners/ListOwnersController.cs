using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.Services.Interfaces;

namespace VeterinaryClinic.Controllers.owner
{   
    [ApiController]
    [Route("api/owner")]
    public class ListOwnersController : ControllerBase
    {
        // Inyeccion de dependencias
        private readonly IOwnerRepository _ownerRepository1;
        public ListOwnersController(IOwnerRepository ownerRepository)
        {
            _ownerRepository1 = ownerRepository;
        }
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> ListAllOwnerAsync()
        {
            // Enviamos los datos al repositorio
            var owner = await _ownerRepository1.ListAllOwner();
            if (owner == null || !owner.Any())
            {
                // retorna si la respuesta esta vacia
                return NotFound("No se encontraron propietarios.");
            }
            // Retorna la coleccion
            return Ok(owner); 
        }

        [HttpGet]
        public async Task<IActionResult> ListAllOwnerByIdAsync([FromQuery] int id)
        {
            // Enviamos los datos al repositorio
            var owner = await _ownerRepository1.ListOwnerById(id);
            if (owner == null)
            {
                // retorna si la respuesta esta vacia
                return NotFound($"No se encontro el propietario con el Id {id}.");
            }
            // Retorna la coleccion
            return Ok(owner); 
        }
    }
}