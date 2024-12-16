while (true)
{
    string? username, password;
    Console.Clear();
    Console.WriteLine("Press a key to log in or 'q' to close the application...\n"); 
    if (char.ToLower(Console.ReadKey().KeyChar) == 'q')
    {
        Environment.Exit(0);
    }

    LogIn login = new LogIn();
    Logger logger = new Logger();

    while (true)
    {
        Console.Clear();
        Console.Write("User Name: ");
        username = Console.ReadLine().Trim();
        if(login.isTheUserBlocked(username))
        {
            Console.WriteLine("The user is blocked, please call customer service...Press any key");
            Console.ReadKey();
            break;
        }
        Console.Write("Password: ");
        password = Console.ReadLine();


        if (username!=null && password!=null)
        {
            if (login.TryLogIn(username, password))
            {
                AtmInterface newAtm = new AtmInterface();
                newAtm.ATM(username);
                break;
            }
            else
            {
                Console.WriteLine("Login failed! Please try again...Enter 'q' to exit");
                login.WrongLoginAttempt(username);
                logger.LogTransaction("Login Attempt",$"Name:{username} Password:{password}");
                
                if (char.ToLower(Console.ReadKey().KeyChar) == 'q')
                {
                    Environment.Exit(0);
                }
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid name and password!...Enter 'q' to exit");
            if (char.ToLower(Console.ReadKey().KeyChar) == 'q')
            {
                Environment.Exit(0);
            }
        }
    }
}