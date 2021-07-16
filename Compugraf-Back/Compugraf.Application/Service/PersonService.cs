using AutoMapper;
using Compugraf.Application.ViewModel;
using Compugraf.Domain.Model;
using Compugraf.Domain.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;


namespace Compugraf.Application.Service
{
    public class PersonService: IPersonService
    {

        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<List<PersonVm>> GetAllPerson()
        {
            var result = await _personRepository.GetAllPerson();
            var response = _mapper.Map<List<PersonVm>>(result);

            return response;
        }

        public async Task<PersonVm> GetPersonById(long id)
        {
            var result = await _personRepository.GetPersonById(id);
            var response = _mapper.Map<PersonVm>(result);

            return response;
        }

        public async Task<PersonVm> AddPerson(CreatePersonVm personVm)
        {
            var personCpf = await _personRepository.GetPersonByCpf(personVm.CPF);
            if (personCpf != null)
                throw new ArgumentNullException(null, "CPF já cadastrado");

            var person = _mapper.Map<Person>(personVm);
            var result = await _personRepository.AddPerson(person);
            var response = _mapper.Map<PersonVm>(result);

            return response;
        }

        public async Task<long> UpdatePerson(CreatePersonVm personVm, long id)
        {

            var personToUpdate = await _personRepository.GetPersonById(id);
            if (personToUpdate == null)
                throw new ArgumentNullException(null, "Pessoa não encontrada");

            var personCpf = await _personRepository.GetPersonByCpf(personVm.CPF);
            if (personCpf != null && personCpf?.Id != personToUpdate.Id)
                throw new ArgumentNullException(null, "CPF já cadastrado");

            var person = _mapper.Map(personVm, personToUpdate);
            var result = await _personRepository.UpdatePerson(person);

            return result.Id;
        }

        public async Task DeletePerson(long id)
        {
            var person = await _personRepository.GetPersonById(id);

            if (person == null)
                throw new ArgumentNullException(null, "Pessoa não encontrada");

            await _personRepository.DeletePerson(person);
        }

    }
}
