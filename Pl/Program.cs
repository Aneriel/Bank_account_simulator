using System;
using System.IO;
using System.Text;
string link = @"accounts.txt";
if (File.Exists(link)) {
    Console.WriteLine("Plik istnieje");
} else
{
    
    using (FileStream fs = File.Create(link))
    {

    }
}

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
    string login = Console.ReadLine();
    Console.WriteLine($"Podaj hasło");
haslo:
    string psswd = Console.ReadLine();
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
else if (ifAcc == "2")
{
accDataRepair:
    Console.Clear();
    Console.WriteLine("Witamy w kreatorze tworzenia konta, Podaj dane osobiste o które zostaniesz poproszony/a");
    Console.Write("Imię:");
rename:
    string newAccName = Console.ReadLine();
    if (string.IsNullOrEmpty(newAccName))
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
    if (string.IsNullOrEmpty(newAccSurname))
    {
        Console.WriteLine("Zakładka nazwisko nie może być pusta, spróbuj ponownie");
        Console.WriteLine("Naciśnij enter by kontynuować");
        Console.ReadLine();
        Console.Clear();
        Console.Write("Proszę ponownie podać nazwisko:");
        goto resurname;
    }
    Console.WriteLine("(Data urodzenia powinna być w formacie DD-MM-RRRR)");
    Console.Write("Data Urodzenia:");
rebirthdate:
    string newAccBirthdate = Console.ReadLine();
    if (string.IsNullOrEmpty(newAccBirthdate))
    {
        Console.WriteLine("Zakładka Data urodzenia nie może być pusta, spróbuj ponownie");
        Console.WriteLine("Naciśnij enter by kontynuować");
        Console.ReadLine();
        Console.Clear();
        Console.Write("(Data urodzenia powinna być w formacie DD-MM-RRRR)");
        Console.Write("Proszę ponownie podać Datę urodzenia:");
        goto rebirthdate;
    }
notSure:
    Console.Clear();
    Console.WriteLine("Twoje dane osobowe to:");
    Console.WriteLine($"{newAccName}, {newAccSurname}, urodzona dnia {newAccBirthdate}");
    Console.WriteLine("Czy dane są poprawne?");
    Console.WriteLine("1. Tak");
    Console.WriteLine("2. Nie");
    string confirmation = Console.ReadLine();

    if (confirmation == "1" || confirmation.ToLower() == "tak")
    {

    }
    else if (confirmation == "2" || confirmation.ToLower() == "nie")
    {
        Console.WriteLine("Czy na pewno chcesz poprawić informacje dotyczące konta? (Czynności nie można cofnąć)");
        Console.WriteLine("Żeby potwierdzić wpisz TAK");
        confirmation = Console.ReadLine();
        if (confirmation == "TAK")
        {
            Console.Clear();
            goto accDataRepair;
        }
        else
        {
            goto notSure;
        }

    }
}
else if (ifAcc == "0")
{
    Console.WriteLine("Dziękujemy za skorzystanie z aplikacji naszego banku i życzymy miłego dnia");
    Console.WriteLine("By zamknąc naciśnij enter");
    Console.ReadLine();
}
else
{
    Console.WriteLine("Niepoprawna odpowiedź");
    Console.Clear();
    goto begining;
}





/*zapisz kod
 * try
{
    using (FileStream fs = File.Create(link))
    {
        byte[] info = new UTF8Encoding(true).GetBytes("dane testowe");
        fs.Write(info,0,info.Length);
    }
}catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
*/
