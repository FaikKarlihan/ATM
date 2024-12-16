class Invoice // epey bi bak
{
    public string invoiceName{get;set;}
    public int invoiceAmount{get;set;}
    public int ID {get;set;}
    public Invoice(string type,int amount,int ID)
    {
        invoiceName = type;
        invoiceAmount = amount;
        this.ID = ID;
    }
}