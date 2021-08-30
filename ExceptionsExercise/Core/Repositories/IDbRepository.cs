using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsExercise
{
    interface IDbRepository
    { 
        public List<Person> Fetch();
        public void Insert(Person person);
        public void Delete(Person person);
        public void Update(Person person);
    }
}

