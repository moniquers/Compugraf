using Compugraf.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Compugraf.Domain.Repository
{
    public interface IPersonRepository
    {
        Task<Person> AddPerson(Person person);
        Task DeletePerson(Person person);
        Task<List<Person>> GetAllPerson();
        Task<Person> GetPersonByCpf(string cpf);
        Task<Person> GetPersonById(long id);
        Task<Person> UpdatePerson(Person person);
    }
}
