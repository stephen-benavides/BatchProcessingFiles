using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;

namespace source.Utility;
public class Logger
{
    private readonly string _logFilePath;
    public Logger(string destinationPath)
    {
        var logFileName = DateTime.Now.ToString("MMddyyyy") + "_log.txt";
        _logFilePath = destinationPath + "\\Logs\\" + logFileName;
        var logDirectory = Path.GetDirectoryName(_logFilePath);

        if(!Directory.Exists(logDirectory)){
            //Create new log folder 
            Directory.CreateDirectory(logDirectory);
        }
    }

    //Generic Log Message 
    private void Log(string message){
        try{
            //Ensure thread safety - only 1 threat can access the file and log at the time 
            lock(_logFilePath){
                using(StreamWriter writer = new StreamWriter(_logFilePath, true)){
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
        }
        catch(Exception ex){
            Console.WriteLine($"An error ocurred while logging: {ex.Message}");
        }
    }

    //Type of Log Messages 
    public void LogError(string message){
        Log($"ERROR: {message}");
    }
    public void LogInfo(string message){
        Log($"INFO: {message}");
    }
    public void LogWarning(string message){
        Log($"WARNING: {message}");
    }
}
