class LogIn
{
    Transactions transactions = Transactions.Instance;
    public bool TryLogIn(string name, string password)
    {
        foreach (var item in transactions.users)
        {
            if (name.Equals(item.UserName) && password.Equals(item.Password))
            {
                item.loginStatus = true;
                return true;
            }
        }
        return false;
    }
    public void WrongLoginAttempt(string username)
    {
        foreach (var item in transactions.users)
        {
            if (username.Equals(item.UserName))
            {
                item.wrongLoginAttempt++;
                if(item.wrongLoginAttempt==3)
                {
                    item.blocking();
                    Console.WriteLine("User blocked due to three incorrect login attempts!");
                }
                
            }
        }
    }
    public bool isTheUserBlocked(string username)
    {
        foreach (var item in transactions.users)
        {
            if (username!=null && username.Equals(item.UserName))
            {
                if (item.blockStatus==true)
                {
                    return true;
                }
            }
        }
        return false;
    }
    
}