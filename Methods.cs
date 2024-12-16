using System.Security.Principal;

static class Methods
{
    public static string? input;
    public static bool ReplyCheck(string reply, params string[] args)
    {
        foreach (string item in args)
        {
            if (reply!=null && reply.Equals(item))
            {
                return true;
            }
        }
        return false;
    }
    public static User TargetAcc()
    {
        Transactions transactions = Transactions.Instance;   
        string targetAcc;
        Console.WriteLine("Please enter the username of the account you want to transfer to.");
        while (true)
        {
            targetAcc = Console.ReadLine().Trim();
            foreach (var user in transactions.users)
            {
                if (targetAcc!=null && targetAcc.Equals(user.UserName))
                {
                    return user;
                }
            }
            Console.Clear();
            Console.WriteLine("User not found! Please try again. Enter 'q' to exit");
            if (char.ToLower(Console.ReadKey().KeyChar) == 'q')
            {
                return null;
            }
        }
    }
    public static int GetAmount()
    {
        while (true)
        {
            Console.WriteLine("--100\n--200\n--300\n--500\n--750\n--1000");
            Console.Write("Amount :");input = Console.ReadLine().Trim();
            if (input!=null && input.ToLower()=="q")
            {
                return 0;
            }
            if (ReplyCheck(input,"100","200","300","500","750","1000")
            && int.TryParse(input, out int amount))
            {
                Console.Clear();
                return amount;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please choose one of the options offered\n");
            }  
        }
    }
    public static int getRandom()
    {
        int[] hundreds = { 100, 200, 300, 400, 500, 600, 700, 800, 900 ,1000};

        Random random = new Random();
        int index = random.Next(0, hundreds.Length);
        return hundreds[index];
    }
    public static (int invoiceAmount, string targetArea) getInvoice(int userBalance)
    {
        Transactions transactions = Transactions.Instance;
        Console.Clear();
        Console.WriteLine($"Please select the area you want to pay in. Enter 'q' to exit.\n");
    
        while (true)
        {
            Console.WriteLine($"Current Balance: {userBalance}\n");
            int i=1;
            foreach (var item in transactions.invoiceTypes)
            {
                Console.WriteLine($"ID-{i}- "+item.invoiceName+$": {item.invoiceAmount}");
                i++;
            }

            input = Console.ReadLine();
            if (input!=null && input.ToLower()=="q")
            {
                 return (0, null);
            }
            if (ReplyCheck(input,"1","2","3","4") && int.TryParse(input, out int id))
            {
                foreach (var item in transactions.invoiceTypes)
                {
                    if (id==item.ID)
                    {
                        int invoiceAmount = item.invoiceAmount;
                        string targetArea = item.invoiceName;
                        item.invoiceAmount -= userBalance;
                        if (item.invoiceAmount<0)
                        {
                            item.invoiceAmount=0;
                        }
                        return (invoiceAmount, targetArea);
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter one of the valid IDs!  Enter 'q' to exit\n");
            }
        }
    }
    public static void showLogs()
    {
        Console.Clear();
        // Log file location
        string logDirectory = @"C:\Logs";
        string logFileName = $"EOD_{DateTime.Now:ddMMyyyy}.txt"; // Bugünün dosyası
        string logFilePath = Path.Combine(logDirectory, logFileName);

        // Check if the file exists
        if (File.Exists(logFilePath))
        {
            try
            {
                // Read and view all logs
                string[] logEntries = File.ReadAllLines(logFilePath);
                Console.WriteLine("Log Records:");
                foreach (var entry in logEntries)
                {
                    Console.WriteLine(entry);
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the log file: {ex.Message}");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("Log file for today could not be found.");
            Console.ReadKey();
        }
    }
    public static void clearLogs()
    {
        Console.Clear();
        string logDirectory = @"C:\Logs";
        string logFileName = $"EOD_{DateTime.Now:ddMMyyyy}.txt";
        string logFilePath = Path.Combine(logDirectory, logFileName);

        // If there is a file, clean it
        if (File.Exists(logFilePath))
        {
            File.WriteAllText(logFilePath, ""); // Clears the file
            Console.WriteLine("The log file has been cleared successfully.");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Log file not found.");
            Console.ReadKey();
        }
    }
    public static void deleteLogFiles()
    {
        Console.Clear();
        string logDirectory = @"C:\Logs";
        string logFileName = $"EOD_{DateTime.Now:ddMMyyyy}.txt";
        string logFilePath = Path.Combine(logDirectory, logFileName);

        // If there is a file, clean it
        if (File.Exists(logFilePath))
        {
            File.Delete(logFilePath); // Deletes file
            Console.WriteLine("The log file has been deleted successfully.");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Log file not found.");
            Console.ReadKey();
        }   
    }
}