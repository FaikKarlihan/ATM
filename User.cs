class User
{
    public string UserName {get; set;}
    public string Password {get; set;}
    public int Balance {get; set;}
    public bool loginStatus {get;set;}
    public int wrongLoginAttempt {get;set;}
    public bool blockStatus {get; set;}
    public User(string username, string password)
    {
        UserName = username;
        Password = password;
        Balance = 1000;
        loginStatus = false;
        wrongLoginAttempt = 0;
    }
    public void blocking()
    {
        blockStatus = true; 
        loginStatus = false;
    }
}