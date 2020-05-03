using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Segun tengo entendido los services nos sirven para los servicios que va a prestar nuestra api(? ó 
// los servicios que vamos a requerir para poder usarlos en nuestra app web
namespace GoingTo_API.Domain.Services
{
    public interface ILocatableService
    {
        Task<IEnumerable<Locatable>> ListAsync(); // Listar los locatables(?
        Task<LocatableResponse> SaveAsync(Locatable locatable);
        Task<LocatableResponse> UpdateAsync(int id, Locatable locatable); //Actualizar un locatable
        Task<LocatableResponse> DeleteAsync(int id); //Eliminar un locatable
        Task<LocatableResponse> GetByIdAsync(int id);//Obtener un locatable

    }
}
