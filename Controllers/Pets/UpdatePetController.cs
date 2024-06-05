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
    [Route("api/pets")]
    public class UpdatePetController : ControllerBase
    {
        // Inyeccion de dependencias
        private readonly IPetRepository _petRepository;
        public UpdatePetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        [HttpPatch]
        [Route("update")]
        public async Task<IActionResult> UpdatePetAsync([FromQuery] int id, [FromBody] PetUpdateDto petUpdateDto)
        {
            // Verificamos que el objeto extista en la base de datos
            var pet = await _petRepository.ListPetById(id);
            if (pet == null)
            {
                return NotFound($"No se encontró una mascota con el ID {id}.");
            }

            // Actualizar los campos que no sean nulos en el DTO
            if (petUpdateDto.Names != null) pet.Names = petUpdateDto.Names;
            if (petUpdateDto.Specie != null) pet.Specie = petUpdateDto.Specie;
            if (petUpdateDto.Race != null) pet.Race = petUpdateDto.Race;
            if (petUpdateDto.DateBirth != null) pet.DateBirth = petUpdateDto.DateBirth;
            if (petUpdateDto.Owner_Id != null) pet.Owner_Id = petUpdateDto.Owner_Id;
            if (petUpdateDto.Photo != null) pet.Photo = petUpdateDto.Photo;

            // Enviamos los datos al repositorio
            var result = await _petRepository.UpdatePet(pet);

            if (!result)
            {
                // retorna hubo un error actualizando el objeto
                return StatusCode(500, "Error actualizando la mascota.");
            }
            // retorna el objeto de actualizo con exito
            return Ok("Mascota actualizada exitosamente.");
        }   
    }
}