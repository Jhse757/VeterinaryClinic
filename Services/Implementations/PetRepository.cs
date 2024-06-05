using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.Data;
using VeterinaryClinic.DTOs;
using VeterinaryClinic.Models.Enums;
using VeterinaryClinic.Models.Interfaces;
using VeterinaryClinic.Services.Interfaces;

namespace VeterinaryClinic.Services.Implementations
{
    public class PetRepository : IPetRepository
    {
        // Contexto de la base de datos
        private readonly AplicationDbContext _context;
        public PetRepository(AplicationDbContext context)
        {
            _context = context;
        }

        #region Metodo CreatePet: Crea una nueva mascotas
        public async Task<IPet> CreatePet(PetCreateDto petCreateDto)
        {
            try
            {
                // Mapea el DTO a la entidad Paciente
                var pet = new Pet
                {
                    Names = petCreateDto.Names,
                    Specie = petCreateDto.Specie,
                    Race = petCreateDto.Race,
                    DateBirth = petCreateDto.DateBirth,
                    Owner_Id = petCreateDto.Owner_Id,
                    Photo = petCreateDto.Photo,
                };

                // Añadir el nuevo objeto al contexto de la base de datos
                _context.Pets.Add(pet);

                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();

                // Retorna el objeto creado
                return pet;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar crear la mascota.", ex);
            }
        }
        #endregion

        #region Metodo ListAllPets: Lista todas las mascotas
        public async Task<IEnumerable<IPet>> ListAllPets()
        {
            // Buscamos los objetos en la base de datos
            var pets = await _context.Pets.ToListAsync();

            // verificamos la cantidad de objetos o si es nulo
            if (pets == null && pets.Any())
            {
                // Retorna una coleccion vacia
                return Enumerable.Empty<IPet>();
            }
            // Retorna la coleccion con los objetos encontrados
            return pets;
        }
        #endregion

        #region Metodo ListPetById: Lista mascotas por Id
        public async Task<IPet> ListPetById(int id)
        {
            // Busca el objeto a listar en la base de datos
            var pet = await _context.Pets.FindAsync(id);

            // Verifica si el objeto es nulo y devuelve null si no se encuentra
            if (pet == null)
            {
                return null;
            }

            // Devuelve la mascota encontrada
            return pet;   
        }
        #endregion

        #region Metodo UpdatePet: Actualiza mascotas
        public async Task<bool> UpdatePet(IPet pet)
        {
            // Busca el objeto a actualizar en la base de datos
            var existingpet = await _context.Pets.FindAsync(pet.Id);
            
            // Verifica si el obejto es nulo
            if (existingpet == null)
            {
                return false;
            }

            // Cambiar el estado del objeto a "Inactive"
            existingpet.Status = Status.Inactive;

            // Guarda los cambios en la base de datos
            await _context.SaveChangesAsync();

            // Devuelve true si el objeto fue actualizado
            return true;
        }
        #endregion
    }
}