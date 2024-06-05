using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.DTOs;
using VeterinaryClinic.Models.Enums;
using VeterinaryClinic.Services.Implementations;
using VeterinaryClinic.Services.Interfaces;

namespace VeterinaryClinic.Controllers.owners
{
    [ApiController]
    [Route("api/owner")]
    public class CreateOwnerController : ControllerBase
    {
        // Inyeccion de dependencias
        private readonly IOwnerRepository _ownerRepository;
        public CreateOwnerController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateOwnerAsync([FromBody] OwnerCreateDto ownerCreateDto)
        {
            // Verifica que el objeto no sea nulo
            if (ownerCreateDto == null)
            {
                return BadRequest("El objeto del propietario esta nulo");
            }

            // Enviamos los datos al repositorio
            var addedowner = await _ownerRepository.CreateOwner(ownerCreateDto);

            // Verifica que el objeto no sea nulo
            if (addedowner == null)
            {
                // retorna si no se agrego a la DB
                return StatusCode(500, "Se produjo un error al crear el propietario");
            }

            // Retorna el objeto agregado
            return Ok(addedowner);
        }
    }
}