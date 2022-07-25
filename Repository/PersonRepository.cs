using Domain.Interfaces;
using Domain.Persons;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class PersonRepository : IPersonRepository
    {
        public async Task<Person> Insert(Person person)
        {
            using (var db = new ApplicationDbContext())
            {
                await db.Persons.AddAsync(person);
                await db.SaveChangesAsync();
            }
            return person;
        }

        public async Task<Person> Get(string name)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Persons.FirstOrDefaultAsync(x => x.Name == name);
            }
        }

        public async Task Update(Person person)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Persons.Update(person);
                await db.SaveChangesAsync();
            }
        }

        public async Task Delete(Person person)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Persons.Remove(person);
                await db.SaveChangesAsync();
            }
        }
    }
}
