using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsExercise
{
    interface IPersonRepository : IDbRepository
    {
        public List<Person> GetByUsername(string username);

        public List<Person> GetById(int? id);

        public List<Person> GetByUsernameAndPassword(string username, string password);
    }
}
