using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsExercise
{
    class PersonManager
    {

    
   static PersonAdoRepository personRepository = new PersonAdoRepository();

    //METODI CRUD
    internal static void InsertPerson()     //CREATE

    {

        Person person = new Person();

        person.Username = InsertUsername();
        person.Password = InsertPassword();


            personRepository.Insert(person);
        Console.WriteLine("L'utente è stato inserito correttamente.");
    }


    internal static void ShowPerson()   //READ
    {
        List<Person> people = personRepository.Fetch();
        foreach (var person in people)
            Console.WriteLine(person.Print());
    }


    internal static void UpdatePerson()  //UPDATE
    {
            List<Person> people = personRepository.Fetch();
            int i = 1;

        foreach (var p in people)
        {
            Console.Write($"Seleziona {i} per modificare ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{ p.Print()}");
            i++;
            Console.ForegroundColor = ConsoleColor.White;
        }

        bool isInt;
        int personaScelta;
        do
        {


            isInt = int.TryParse(Console.ReadLine(), out personaScelta);

        } while (!isInt || personaScelta <= 0 || personaScelta > people.Count);

        Console.WriteLine("Hai scelto di modificare");
        Person person = people.ElementAt(personaScelta - 1);
        Console.WriteLine($"{person.Print()}");

     

            if (person.Id == null)
            {
               personRepository.Delete(person);
            }

            bool continuare = true;
            string risposta;
            do
            {
                Console.WriteLine("Vuoi modificare l'username? Rispondi si o no");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                person.Username = InsertUsername();
            }

            do
            {
                Console.WriteLine("Vuoi modificare la password? Rispondi si o no");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                person.Password = InsertPassword();
            }

          

            Console.WriteLine("Modifica avvenuta correttamente");
           personRepository.Update(person);
        }
    


    internal static void DeletePerson()   //DELETE
        {
        List<Person> people = personRepository.Fetch();

        int i = 1;
        foreach (var person in people)
        {

            Console.Write($"Seleziona {i} per eliminare ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{ person.Print()}");
            i++;
            Console.ForegroundColor = ConsoleColor.White;
        }

        bool isInt;
        int personaScelta;
        do
        {

            isInt = int.TryParse(Console.ReadLine(), out personaScelta);

        } while (!isInt || personaScelta <= 0 || personaScelta > people.Count);

       personRepository.Delete(people.ElementAt(personaScelta - 1));
        Console.Write($"Eliminazione avvenuta correttamente ");

    }  




    //METODI DI SUPPORTO
  
    private static string InsertPassword()
    {
        string password = String.Empty;
        do
        {
            Console.WriteLine("Inserisci la password");
            password = Console.ReadLine();

        } while (String.IsNullOrEmpty(password));
        return password;
    }

    private static string InsertUsername()
    {
        string username = String.Empty;
        do
        {
            Console.WriteLine("Inserisci l'Username:");
                username = Console.ReadLine();

        } while (String.IsNullOrEmpty(username));
        return username;
    }



   
}
}