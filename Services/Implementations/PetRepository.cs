using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.Data;
using VeterinaryClinic.DTOs;
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
    }
}