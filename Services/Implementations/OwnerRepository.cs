using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.Data;
using VeterinaryClinic.DTOs;
using VeterinaryClinic.Models.Interfaces;
using VeterinaryClinic.Services.Interfaces;

namespace VeterinaryClinic.Services.Implementations
{
    public class OwnerRepository : IOwnerRepository
    {
        // Contexto de la base de datos
        private readonly AplicationDbContext _context;
        public OwnerRepository(AplicationDbContext context)
        {
            _context = context;
        }

        #region Metodo Createowner: Crea un nuevo propietario
        public async Task<IOwner> CreateOwner(OwnerCreateDto ownerCreateDto)
        {
            try
            {
                // Mapea el DTO a la entidad
                var owner = new Owner
                {
                    Names = ownerCreateDto.Names,
                    LastName = ownerCreateDto.LastName,
                    Email = ownerCreateDto.Email,
                    Address = ownerCreateDto.Address,
                    Phone = ownerCreateDto.Phone,
                };

                // Añadir el nuevo objeto al contexto de la base de datos
                _context.Owners.Add(owner);

                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();

                // Retorna el objeto creado
                return owner;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar crear el propietario.", ex);
            }
        }
        #endregion

        #region Metodo ListAllOwner: Lista todos los propietarios
        public async Task<IEnumerable<IOwner>> ListAllOwner()
        {
            // Buscamos los objetos en la base de datos
            var owners = await _context.Owners.ToListAsync();

            // verificamos la cantidad de objetos o si es nulo
            if (owners == null && owners.Any())
            {
                // Retorna una coleccion vacia
                return Enumerable.Empty<IOwner>();
            }
            // Retorna la coleccion con los objetos encontrados
            return owners;
        }
        #endregion
    
        #region Metodo ListOwnerById: Lista propietario por Id
        public async Task<IOwner> ListOwnerById(int id)
        {
            // Busca el objeto a listar en la base de datos
            var owner = await _context.Owners.FindAsync(id);

            // Verifica si el objeto es nulo y devuelve null si no se encuentra
            if (owner == null)
            {
                return null;
            }

            // Devuelve el objeto encontrado
            return owner;   
        }
        #endregion

        #region Metodo UpdateOwner: Actualiza propietarios
        public async Task<bool> UpdateOwner(IOwner owner)
        {
            // Busca el objeto a actualizar en la base de datos
            var existingOwner = await _context.Owners.FindAsync(owner.Id);
            
            // Verifica si el obejto es nulo
            if (existingOwner == null)
            {
                return false;
            }

            // Guarda los cambios en la base de datos
            await _context.SaveChangesAsync();

            // Devuelve true si el objeto fue actualizado
            return true;
        }
        #endregion
    }

}
