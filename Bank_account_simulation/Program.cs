// See https://aka.ms/new-console-template for more information
using System.Linq.Expressions;
restart:
Console.WriteLine("Witaj drogi kliencie, czy posiadasz już konto w naszym banku?");
begining:
Console.WriteLine("Wybierz opcje wpisując liczbę 1, 2 lub 0");
Console.WriteLine("1. Zaloguj się na swoje konto");
Console.WriteLine("2. Utwórz konto");
Console.WriteLine("0. Zamknij aplikację bankową");
string ifAcc = Console.ReadLine();
if (ifAcc == "1")
{
    Console.Clear();
    Console.WriteLine("Witamy w systemie logowania naszego banku");
    Console.WriteLine("Podaj Numer konta:");
    String login = Console.ReadLine();
    Console.WriteLine($"Podaj hasło");
haslo:
    String psswd = Console.ReadLine();
    if (psswd == "17772")
    {
        Console.WriteLine("Hasło się zgadza");
    }
    else
    {
        Console.WriteLine("hasło niepoprawne, spróbuj ponownie");
        goto haslo;
        
    }
    bool loggedIn = true;
}
else if(ifAcc == "2")
{
    Console.Clear();
    Console.WriteLine("Witamy w kreatorze tworzenia konta, Podaj dane osobiste o które zostaniesz poproszony/a");
    Console.Write("Imię:");
    rename:
    string newAccName = Console.ReadLine();
    if(String.IsNullOrEmpty(newAccName))
    {
        Console.WriteLine("Zakładka imię nie może być pusta, spróbuj ponownie");
        Console.WriteLine("Naciśnij enter by kontynuować");
        Console.ReadLine();
        Console.Clear();
        Console.Write("Proszę ponownie podać imię:");
        goto rename;
    }
    Console.Write("Nazwisko:");
    resurname:
    string newAccSurname = Console.ReadLine();
    if (String.IsNullOrEmpty(newAccSurname))
    {
        Console.WriteLine("Zakładka nazwisko nie może być pusta, spróbuj ponownie");
        Console.WriteLine("Naciśnij enter by kontynuować");
        Console.ReadLine();
        Console.Clear();
        Console.Write("Proszę ponownie podać nazwisko:");
        goto resurname;
    }
    Console.Write("(Data urodzenia powinna być w formacie DD-MM-RRRR)");
    Console.WriteLine("Data Urodzenia:");
    rebirthdate:
    string newAccBirthdate = Console.ReadLine();
    if (String.IsNullOrEmpty(newAccBirthdate))
    {
        Console.WriteLine("Zakładka Data urodzenia nie może być pusta, spróbuj ponownie");
        Console.WriteLine("Naciśnij enter by kontynuować");
        Console.ReadLine();
        Console.Clear();
        Console.Write("(Data urodzenia powinna być w formacie DD-MM-RRRR)");
        Console.Write("Proszę ponownie podać Datę urodzenia:");
        goto rebirthdate;
    }
    Console.Clear();
    Console.WriteLine("Twoje dane osobowe to:");
    Console.WriteLine($"{newAccName},{newAccSurname}{newAccBirthdate}");
    Console.WriteLine("Czy dane są poprawne?");
    Console.WriteLine("1. Tak");
    Console.WriteLine("2. Nie");
    string confirmation = Console.ReadLine();
    if(confirmation == "1") 
    {
        Console.WriteLine("Dodawanie danych do bazy");
    }
    else
    {
        Console.WriteLine("Czy na pewno chcesz poprawić informacje dotyczące konta? (Czynności nie można cofnąć)");
        Console.WriteLine("1. Tak");
        Console.WriteLine("2. NIe");
        confirmation = Console.ReadLine();
        if()
    Console.Clear();

    goto restart;
}




