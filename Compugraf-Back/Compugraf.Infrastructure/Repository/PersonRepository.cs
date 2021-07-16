using Compugraf.Domain.Model;
using Compugraf.Domain.Repository;
using Compugraf.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Compugraf.Infrastructure.Repository
{
    public class PersonRepository: IPersonRepository
    {

        private readonly DatabaseContext _context;
        private readonly DbSet<Person> _dbSet;

        public PersonRepository(DatabaseContext databaseContext)
        {
            _context = databaseContext;
            _dbSet = _context.Set<Person>();
        }

        public async Task<List<Person>> GetAllPerson()
        {
            var result = await _dbSet.ToListAsync();
            return result;
        }

        public async Task<Person> GetPersonById(long id)
        {
            var result = await _dbSet.SingleOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Person> GetPersonByCpf(string cpf)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.CPF == cpf);
            return result;
        }

        public async Task<Person> AddPerson(Person person)
        {
            var result = await _dbSet.AddAsync(person);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<Person> UpdatePerson(Person person)
        {
            var result = _dbSet.Update(person);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeletePerson(Person person)
        {
            _dbSet.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}
