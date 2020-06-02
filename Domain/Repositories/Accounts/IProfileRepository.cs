using GoingTo_API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories
{
    public interface IProfileRepository
    {
        Task<IEnumerable<Profile>> ListAsync(); // mostrar 

        Task AddAsync(Profile profile); // agregar

        Task<Profile> FindById(int id); // encontrar y modificar
        void Update(Profile profile);

        void Remove(Profile profile); // eliminar 
    }
}
