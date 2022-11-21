using MySql.Data.MySqlClient;
using Pl;
using System.Globalization;

operations.dbconntest();

string login = "0";
int loggedIn = 0;
restart:

Console.Clear();

Console.WriteLine("Witaj drogi kliencie, czy posiadasz już konto w naszym banku?");
Console.WriteLine("Wybierz opcje wpisując liczbę 1, 2 lub 0");
Console.WriteLine("1. Zaloguj się na swoje konto");
Console.WriteLine("2. Utwórz konto");
Console.WriteLine("0. Zamknij aplikację bankową");
string ifAcc = Console.ReadLine();
if (ifAcc == "1")
{
    string checkLogin = "0";
    string checkPasswd = "0";
    string connStr = "server=localhost;user=root;database=Bank;port=3306;password=";
    MySqlConnection conn = new MySqlConnection(connStr);
login:
    Console.Clear();
    Console.WriteLine("Witamy w systemie logowania naszego banku");
    Console.WriteLine("Podaj Numer konta:");
    login = Console.ReadLine();
    if (string.IsNullOrEmpty(login))
    {
        Console.WriteLine("Login nie może być pusty,sprobuj ponownie");
        Console.ReadLine();
        goto login;
    }
    try
    {
        conn.Open();
        string sql = $"select Account_number,password from clients_login where Account_number = {login}";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.ExecuteNonQuery();
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                checkLogin = reader["Account_number"].ToString();
                checkPasswd = reader["Password"].ToString();
            }

        }

    }
    catch (Exception err)
    {
        Console.WriteLine("Couldn't add new account to the database, check the connection");
        Console.WriteLine(err.ToString());
    }
    conn.Close();
    Console.WriteLine($"Podaj hasło");
haslo:
    var psswd = string.Empty;
    ConsoleKey key;
    do
    {
        var keyInfo = Console.ReadKey(intercept: true);
        key = keyInfo.Key;

        if (key == ConsoleKey.Backspace && psswd.Length > 0)
        {
            Console.Write("\b \b");
            psswd = psswd[0..^1];
        }
        else if (!char.IsControl(keyInfo.KeyChar))
        {
            Console.Write("*");
            psswd += keyInfo.KeyChar;
        }
    } while (key != ConsoleKey.Enter);

    if (psswd == checkPasswd)
    {
        Console.WriteLine();
        Console.WriteLine("Hasło się zgadza");
        Console.ReadLine();
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("hasło bądź numer klienta niepoprawny, spróbuj ponownie");
        goto haslo;

    }
    loggedIn = 1;
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
    Console.WriteLine("(Data urodzenia powinna być w formacie DD/MM/YYYY)");
    Console.Write("Data Urodzenia:");
rebirthdate:
    string birthday = Console.ReadLine();
    if (string.IsNullOrEmpty(birthday))
    {
        Console.WriteLine("Zakładka Data urodzenia nie może być pusta, spróbuj ponownie");
        Console.WriteLine("Naciśnij enter by kontynuować");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("(Data urodzenia powinna być w formacie DD/MM/YYYY)");
        Console.Write("Proszę ponownie podać Datę urodzenia:");
        goto rebirthdate;
    }
    DateTime dt = DateTime.ParseExact(birthday.ToString(), "dd/mm/yyyy", CultureInfo.InvariantCulture);
    string newAccBirthdate = dt.ToString("yyyy-mm-dd", CultureInfo.InvariantCulture);
    Console.WriteLine("Proszę podać płeć:");
    Console.WriteLine("M-Mężczyzna");
    Console.WriteLine("K-Kobieta");
regender:
    string newGender = Console.ReadLine().ToUpper();
    if (string.IsNullOrEmpty(newGender))
    {
        Console.WriteLine("Zakładka Płeć nie może być pusta, spróbuj ponownie");
        Console.WriteLine("Naciśnij enter by kontynuować");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("(Data urodzenia powinna być w formacie DD-MM-RRRR)");
        Console.Write("Proszę ponownie podać Datę urodzenia:");
        goto regender;
    }

notSure:
    Console.Clear();
    string birthType;
    if (newGender == "M")
    {
        birthType = "Urodzony dnia";
    }
    else
    {
        birthType = "Urodzona dnia";
    }
    Console.WriteLine("Twoje dane osobowe to:");
    Console.WriteLine($"{newAccName}, {newAccSurname}, {birthType}, {dt.Date}");
    Console.WriteLine("Czy dane są poprawne?");
    Console.WriteLine("1. Tak");
    Console.WriteLine("2. Nie");
    string confirmation = Console.ReadLine();

    if (confirmation == "1" || confirmation.ToLower() == "tak")
    {
        string connStr = "server=localhost;user=root;database=Bank;port=3306;password=";

        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            Console.Clear();
            conn.Open();
            String startWith = "32";
            Random generator = new Random();
            String r = generator.Next(0, 999967).ToString("D6");
            String accNum = startWith + r;
        repair:
            Console.WriteLine($"Numer twojego konta to: {accNum},zapisz go");
            Console.WriteLine("Proszę ustawić hasło logowania:");
            var pw1 = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pw1.Length > 0)
                {
                    Console.Write("\b \b");
                    pw1 = pw1[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pw1 += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            Console.WriteLine();
            Console.WriteLine("Proszę powtórzyć hasło");
            var pw2 = string.Empty;
            ConsoleKey key2;
            do
            {
                var keyInfo2 = Console.ReadKey(intercept: true);
                key2 = keyInfo2.Key;

                if (key == ConsoleKey.Backspace && pw2.Length > 0)
                {
                    Console.Write("\b \b");
                    pw2 = pw2[0..^1];
                }
                else if (!char.IsControl(keyInfo2.KeyChar))
                {
                    Console.Write("*");
                    pw2 += keyInfo2.KeyChar;
                }
            } while (key2 != ConsoleKey.Enter);

            if (pw1 != pw2)
            {
                Console.WriteLine();
                Console.WriteLine("hasła się nie zgadzają, spróbuj ponownie.");
                Console.WriteLine("by kontynuować naciśnij enter");
                Console.ReadLine();
                Console.Clear();
                goto repair;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Dodawanie nowego konta do bazy danych, proszę czekać...");
                try
                {
                    string sql = $"INSERT INTO clients(Account_number,Name,Surname,Gender,Birth_date)Values(\"{accNum}\",\"{newAccName}\",\"{newAccSurname}\",\"{newGender}\",\"{newAccBirthdate}\");";
                    string sql2 = $"INSERT INTO clients_login(Account_number,Password)Values(\"{accNum}\",\"{pw2}\");";
                    string sql3 = $"INSERT INTO account_balance(Account_number,Account_balance,Currency_type)Values(\"{accNum}\",\"0\",\"Zł\");";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                    MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    Console.WriteLine("Pomyślnie dodano nowe konto, można się zalogować");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Couldn't add new account to the database, check the connection");
                    Console.WriteLine(ex.ToString());
                }
            }




        }
        catch (Exception err)
        {
            Console.WriteLine("Couldn't add new account to the database, check the connection");
            Console.WriteLine(err.ToString());
        }
        conn.Close();
        Console.Read();


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
    Console.WriteLine("By kontynuować naciśnij ENTER:");
    Console.ReadLine();
    Console.Clear();
    goto restart;
}

else if (ifAcc == "0")
{
    Console.WriteLine("Dziękujemy za skorzystanie z aplikacji naszego banku i życzymy miłego dnia");
    Console.WriteLine("By zamknąc naciśnij ENTER");
    Console.ReadLine();
    Environment.Exit(0);
}
else
{
    Console.Clear();
    Console.WriteLine("Niepoprawna odpowiedź");
    Console.WriteLine("By kontynuować naciśnij ENTER");
    Console.ReadLine();
    Console.Clear();
    goto restart;
}
if (loggedIn == 0)
{
    Console.WriteLine("Nie jesteś zalogowany/a");
    Console.WriteLine("By wrócić do menu głównego naciśnij ENTER");
    Console.ReadLine();
    goto restart;
}
else
{
test:
    Console.Clear();
    string connStr = "server=localhost;user=root;database=Bank;port=3306;password=";
    MySqlConnection conn = new MySqlConnection(connStr);
    conn.Open();
    string sql = $"Select clients.Account_number,Name,Surname,account_balance.Account_balance from Clients inner join account_balance on Clients.Account_number = account_balance.Account_number where clients.Account_number = {login};\r\n";
    MySqlCommand cmd = new MySqlCommand(sql, conn);
    cmd.ExecuteNonQuery();
    string Account_number = "0";
    string Name = "0";
    string Surname = "0";
    decimal Account_balance = 0;
    using (MySqlDataReader reader = cmd.ExecuteReader())
    {
        while (reader.Read())
        {
            Account_number = reader["Account_number"].ToString();
            Name = reader["Name"].ToString();
            Surname = reader["Surname"].ToString();
            string Account_balance_string = reader["Account_balance"].ToString();
            Account_balance = Decimal.Parse(Account_balance_string, CultureInfo.InvariantCulture);
        }
        conn.Close();


        decimal balance = 0;
        string currency = "0";
        Console.Clear();
        Console.WriteLine($"Witaj {Name} {Surname}!");
        Console.WriteLine("Co chcesz dzisiaj zrobić?");
        Console.WriteLine("1. Wypłać pieniądze");
        Console.WriteLine("2. Dokonaj wpłaty");
        Console.WriteLine("3. Wyloguj się");
        conn.Open();
        string sql1 = $"Select Account_number,Account_balance, Currency_type from account_balance where account_number = \"{login}\"";
        MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
        cmd1.ExecuteNonQuery();
        using (MySqlDataReader reader1 = cmd1.ExecuteReader())
        {
            while (reader1.Read())
            {
                balance = decimal.Parse(reader1["Account_balance"].ToString());
                currency = reader1["Currency_type"].ToString();
            }
        }
        conn.Close();
        Console.WriteLine($"Stan twojego konta to: {balance}  {currency}");
        string menu = Console.ReadLine();
        if (menu == "1")
        {
            Console.WriteLine($"Aktualny stan twojego konta to {balance} {currency} ile chcesz wypłacić?");
            Console.WriteLine("Naciśnij enter by wrócić, wpisz wartość by wypłacić");
            string income = Console.ReadLine();
            if (string.IsNullOrEmpty(income))
            {
                Console.WriteLine("Dziękujemy za skorzystanie z naszych usług");
                Console.WriteLine("Naciśnij enter by przejść do panelu głównego konta");
                Console.ReadLine();
                goto test;
            }
            else
            {
                Console.Clear();
                decimal minusDec = decimal.Parse(income);
                decimal newBalance = balance - minusDec;
                conn.Open();
                try
                {
                    sql = $"Update account_balance set Account_balance = \'{newBalance}\' where account_number = \'{login}\'";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Wypłacanie środków powiodło się, naciśnij enter by wrócić do panelu głównego konta");
                    Console.ReadLine();
                    goto test;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Nie można przeprowadzić zabiegu, z przyczyn:");
                    Console.WriteLine(ex.ToString());
                    Console.ReadLine();
                    goto test;
                }
            }


        }
        else if (menu == "2")
        {
            Console.WriteLine($"Aktualny stan twojego konta to {balance} {currency} ile chcesz wpłacić?");
            Console.WriteLine("Naciśnij enter by wrócić, wpisz wartość by dopłacić");
            string income = Console.ReadLine();
            if (string.IsNullOrEmpty(income))
            {
                Console.WriteLine("Dziękujemy za skorzystanie z naszych usług");
                Console.WriteLine("Naciśnij enter by przejść do panelu głównego konta");
                Console.ReadLine();
                goto test;
            }
            else
            {
                Console.Clear();
                decimal incomeDec = decimal.Parse(income);
                decimal newBalance = balance + incomeDec;
                conn.Open();
                try
                {
                    sql = $"Update account_balance set Account_balance = \'{newBalance}\' where account_number = \'{login}\'";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Dodawanie środków powiodło się, naciśnij enter by wrócić do panelu głównego konta");
                    Console.ReadLine();
                    goto test;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Nie można przeprowadzić zabiegu, z przyczyn:");
                    Console.WriteLine(ex.ToString());
                    Console.ReadLine();
                    goto test;
                }
            }
        }
        else if (menu == "3")
        {
            Console.Clear();
            Console.WriteLine("Pomyślnie się wylogowano, Dziękujemy za skorzystanie z usług naszego banku");
            Console.WriteLine("Naciśnij Enter by kontynuować");
            Console.ReadLine();
            loggedIn = 0;
            Console.Clear();
            goto restart;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Ta odpowiedź jest niepoprawna, spróbuj ponownie");
            Console.WriteLine("Naciśnij Enter by kontynuować");
            Console.ReadLine();
            goto test;

        }

    }

}
