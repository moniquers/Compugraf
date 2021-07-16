using Compugraf.Application.ViewModel;
using Compugraf.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Compugraf.Application.Service
{
    public interface IPersonService
    {
        Task<PersonVm> AddPerson(CreatePersonVm personVm);
        Task DeletePerson(long id);
        Task<List<PersonVm>> GetAllPerson();
        Task<PersonVm> GetPersonById(long id);
        Task<long> UpdatePerson(CreatePersonVm personVm, long id);
    }
}
