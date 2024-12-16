using static Methods;
using System.IO;
class Transactions
{
    Logger logger = new Logger();
    int getAmount;
    private static Transactions? _instance;
    public List<User> users{get;set;} = new List<User>();
    public List<Invoice> invoiceTypes{get;set;} = new List<Invoice>();
    public static Transactions Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Transactions();
            }
            return _instance;
        }
    }
    public Transactions()
    {
        users.Add(new User("Noah","0000"));
        users.Add(new User("David","1111"));
        users.Add(new User("Michael","2222"));
        users.Add(new User("Joshua","3333"));
        users.Add(new User("Gabriel","4444"));

        invoiceTypes.Add(new Invoice("Telephone",getRandom(),1));
        invoiceTypes.Add(new Invoice("Electric",getRandom(),2));
        invoiceTypes.Add(new Invoice("Natural Gas",getRandom(),3));
        invoiceTypes.Add(new Invoice("Water",getRandom(),4));
    }

    public void CashWithdrawal(string activeUser)
    {
        foreach (var user in users)
        {
            if (activeUser.Equals(user.UserName))
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"Current balance: {user.Balance}\n");
                    Console.WriteLine("Please select the amount you want to withdraw.  Enter 'q' to exit\n");
                    getAmount = GetAmount();
                    if (getAmount==0) // case 'q'
                    {
                        break;
                    }
                    if (getAmount<=user.Balance)
                    {
                        user.Balance -= getAmount;
                        Console.WriteLine($"Withdrawal is successful. Current balance: {user.Balance}");
                        logger.LogTransaction("Withdrawal",$"User:{user.UserName} Amount:{getAmount}");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient balance! Please select a valid quantity.");
                        Console.ReadKey();
                    }                    
                }
            }
        }
    }
    public void Transfer(string activeUser)
    {
        string? targetAcc;
        foreach (var user in users)
        {
            Console.Clear();
            Console.WriteLine("Please enter the amount you want to transfer. Enter 'q' to exit");

            if (activeUser.Equals(user.UserName))
            {
                while (true)
                {
                    getAmount = GetAmount();
                    if (getAmount==0) // case 'q'
                    {
                        break;
                    }
                    if (getAmount <= user.Balance)
                    {
                        User targetuser = TargetAcc();
                        if (targetuser==null)
                        {
                            break;
                        }
                        targetuser.Balance += getAmount;
                        user.Balance -= getAmount;
                        Console.WriteLine($"The transfer process is successful.\nCurrent balance: {user.Balance}");

                        logger.LogTransaction("Transfer",$"User:{user.UserName} Amount:{getAmount} Target Account:{targetuser.UserName}");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Insufficient balance! Please choose another amount. Enter 'q' to exit");
                    }
                }
                
            }
        }
    }
    public void BillPayment(string activeUser)
    {
        foreach (var user in users)
        {
            if (activeUser.Equals(user.UserName))
            {
                var (invoiceAmount, targetArea) = getInvoice(user.Balance);
                if (invoiceAmount==00) // case 'q'
                {
                    break;
                }
                if (user.Balance >= invoiceAmount)
                {
                    user.Balance -= invoiceAmount;
                    Console.WriteLine("Payment transaction successful");
                    Console.Write($"Current balance: {user.Balance}");
                    logger.LogTransaction("Payment",$"User:{user.UserName} Amount:{invoiceAmount} Target:{targetArea}");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Insufficient balance!");
                    Console.ReadKey();
                    break;
                }
            }
        }
        
    }
    public void BalanceInquiry(string activeUser)
    {
        Console.Clear();
        foreach (var user in users)
        {
            if (activeUser.Equals(user.UserName))
            {
                Console.WriteLine($"Current balance: {user.Balance}");
                Console.ReadKey();
            }
        }
    }
    public void Deposit(string activeUser)
    {
        Console.Clear();   
        foreach (var user in users)
        {
            if (activeUser.Equals(user.UserName))
            {
                Console.WriteLine($"Current balance: {user.Balance}");
                Console.WriteLine("Please enter the amount you want to deposit");
                getAmount = GetAmount();

                user.Balance += getAmount;
                Console.Clear();
                Console.WriteLine("The deposit is successful.");
                Console.WriteLine($"Current balance: {user.Balance}");
                logger.LogTransaction("Deposit",$"User:{user.UserName} Amount:{getAmount}");
                Console.ReadKey();
                break;
            }
        }
    }
    public void EndOfDay()
    {
        bool again = true;
        while (again)
        {
            string? reply;
            Console.Clear();
            Console.WriteLine("Show logs(1)\nClear logs(2)\nDelete today's log file(3)\nCancel(0)");
            reply=Console.ReadLine();
            switch (reply)
            {
                case "1":
                showLogs();
                break;

                case "2":
                clearLogs();
                break;

                case "3":
                deleteLogFiles();
                break;

                case "0":
                again = false;
                break;

                default:
                break;
            }           
        }
    }
    public bool LogOut(string activeUser)
    {
        foreach (var user in users)
        {
            if (activeUser.Equals(user.UserName))
            {
                user.loginStatus=false;
            }
        }
        return true;
    }
}