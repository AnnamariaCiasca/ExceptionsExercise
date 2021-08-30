using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsExercise
{
    class PersonListRepository : IPersonRepository
    {
        static List<Person> people = new List<Person>
        {
            new Person("annamaria", "axy6566", null),
            new Person("utente01", "uze5445", null),
        };

        public void Delete(Person person)
        {
            people.Remove(person);
        }

        public List<Person> Fetch()
        {
            return people;
        }

        public void Insert(Person person)
        {
            people.Add(person);
        }

        public void Update(Person person)
        {
            Insert(person);
        }

        public List<Person> GetByUsername(string username)
        {
            return people.Where(p => p.Username == username).ToList();
        }

        public List<Person> GetById(int? id)
        {
            return people.Where(p => p.Id == id).ToList();
        }

        public List<Person> GetByUsernameAndPassword(string username, string password)
        {
            return people.Where(p => p.Username == username && p.Password == password ).ToList();
        }
    }
}


