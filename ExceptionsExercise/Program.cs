//Scrivere un programma che consenta di fare login.
//L'utente deve poter inserire il suo username e la sua password.
//Il programma cerca di recuperare i dati dal database 'Utenti'.

//L'entità utente ha:
//- Id
//- Username
//- Password


//Se l'utente è già nel db, comparirà un messaggio: "Login avvenuto con successo".
//Altrimenti: "Impossibile effettuare login"

//(ADO Connected Mode)

//Tenere in considerazione che potrebbe mancare la connessione al db, la stringa di connessione potrebbe essere sbagliata...
//gestendo le eventuali eccezioni (SqlException).
using System;

namespace ExceptionsExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto!");
        }
    }
}
