using System.IO;
class Logger
{
    private string logDirectory = @"C:\Logs";
    private string logFilePath;

    public Logger()
    {
        // Set file path to create log file
        logFilePath = Path.Combine(logDirectory, $"EOD_{DateTime.Now:ddMMyyyy}.txt");
        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }
    }

    public void LogTransaction(string transactionType, string details)
    {
        try
        {
            // Determine log format
            string logEntry = $"{DateTime.Now:HH:mm:ss} - {transactionType}- {details}{Environment.NewLine}";

            // Write to log file
            File.AppendAllText(logFilePath, logEntry);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during logging: {ex.Message}");
        }
    }
}
