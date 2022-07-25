using Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> Insert(Person user);

        Task<Person> Get(string name);

        Task Delete(Person user);

        Task Update(Person user);
    }
}
