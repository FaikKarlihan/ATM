class AtmInterface
{
    public void ATM(string username)
    {
        string activeUser = username;
        Transactions transactions = Transactions.Instance;
        string? reply;
        bool logOut = false;
        while (!logOut)
        {
            Console.Clear();
            Console.WriteLine("Welcome to ATM application!\nPlease select the action you want to take...\n");
            Console.WriteLine("Cash Withdrawal(1)\nTransfer(2)\nBill Payment(3)\nBalance Inquiry(4)\nDeposit(5)\nEnd Of Day(6)\nLog Out(0)");
            reply = Console.ReadLine();

            switch (reply)
            {
                case "1":
                transactions.CashWithdrawal(activeUser);
                break;

                case "2":
                transactions.Transfer(activeUser);
                break;

                case "3":
                transactions.BillPayment(activeUser);
                break;

                case "4":
                transactions.BalanceInquiry(activeUser);
                break;

                case "5":
                transactions.Deposit(activeUser);
                break;

                case "6":
                transactions.EndOfDay();
                break;

                case "0":
                logOut = transactions.LogOut(activeUser); //returns true
                break;

                default:
                break;
            }
        }   
    }
}