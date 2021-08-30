using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsExercise
{
    class PersonAdoRepository : IPersonRepository
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                        "Initial Catalog = Utenti;" +
                                        "Integrated Security = true;";
        public void Delete(Person person)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Utente where Id = @id";
                command.Parameters.AddWithValue("@id", person.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Person> Fetch()
        {
            List<Person> people = new List<Person>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Utente";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var username = (string)reader["Username"];
                    var password = (string)reader["Password"];
                    var id = (int)reader["Id"];

                    Person person = new Person(username, password, id);

                    people.Add(person);
                }
            }
            return people;
        }

        public List<Person> GetByUsername(string username)
        {
            List<Person> people = new List<Person>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Utente where Username = @username";
                command.Parameters.AddWithValue("@username", username);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var password = (string)reader["Password"];
                    var id = (int)reader["Id"];

                    Person person = new Person(username, password, id);

                    people.Add(person);
                }
            }
            return people;
        }

        public List<Person> GetByUsernameAndPassword(string username, string password)
        {
            List<Person> people = new List<Person>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Utente where username = @username AND password = @password";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    
                    var id = (int)reader["Id"];

                    Person person = new Person(username, password, id);

                    people.Add(person);
                }
            }
            return people;
        }

        public List<Person> GetById(int? id)
        {
            List<Person> people = new List<Person>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Utente where Id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var username = (string)reader["Username"];
                    var password = (string)reader["Password"];
                    

                    Person person = new Person(username, password, id);

                    people.Add(person);
                }
            }
            return people;
        }



        public void Insert(Person person)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Utente values (@username, @password)";
                command.Parameters.AddWithValue("@username", person.Username);
                command.Parameters.AddWithValue("@password", person.Password);
       
                command.ExecuteNonQuery();
            }
        }

        public void Update(Person person)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Utente set Username = @username, Password = @password, where Id = @id";
                command.Parameters.AddWithValue("@username", person.Username);
                command.Parameters.AddWithValue("@password", person.Password);
                command.Parameters.AddWithValue("@id", person.Id);

                command.ExecuteNonQuery();
            }
        }

       


    }
}