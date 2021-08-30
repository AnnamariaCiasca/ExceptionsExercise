using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsExercise
{
    class Person
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Id { get; set; }

        public Person()
        {

        }
        public Person(string username, string password, int? id)
        {
            Username = username;
            Password = password;
            Id = id;
        }

        public string Print()
        {
            
            return $"{Username} - {Password}";
        }
    }
}
