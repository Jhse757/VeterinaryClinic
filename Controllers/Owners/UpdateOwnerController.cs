using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.DTOs;
using VeterinaryClinic.Models.Interfaces;
using VeterinaryClinic.Services.Interfaces;

namespace VeterinaryClinic.Controllers.Pets
{
    [ApiController]
    [Route("api/owner")]
    public class UpdateOwnerController : ControllerBase
    {
        // Inyeccion de dependencias
        private readonly IOwnerRepository _ownerRepository;
        public UpdateOwnerController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        [HttpPatch]
        [Route("update")]
        public async Task<IActionResult> UpdateOwnerAsync([FromQuery] int id, [FromBody] OwnerUpdateDto ownerUpdateDto)
        {
            // Verificamos que el objeto extista en la base de datos
            var owner = await _ownerRepository.ListOwnerById(id);
            if (owner == null)
            {
                return NotFound($"No se encontró el propietario con el ID {id}.");
            }

            // Actualizar los campos que no sean nulos en el DTO
            if (ownerUpdateDto.Names != null) owner.Names = ownerUpdateDto.Names;
            if (ownerUpdateDto.LastName != null) owner.LastName = ownerUpdateDto.LastName;
            if (ownerUpdateDto.Address != null) owner.Address = ownerUpdateDto.Address;
            if (ownerUpdateDto.Phone != null) owner.Phone = ownerUpdateDto.Phone;

            // Enviamos los datos al repositorio
            var result = await _ownerRepository.UpdateOwner(owner);

            if (!result)
            {
                // retorna hubo un error actualizando el objeto
                return StatusCode(500, "Error actualizando el propietario.");
            }
            // retorna el objeto de actualizo con exito
            return Ok("Propietario actualizada exitosamente.");
        }   
    }
}