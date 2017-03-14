using ReadLoger.Service_References.ServiceReference;

namespace WebClientMVC.Models
{
    public class ReadLogModel
    {
        public string AddClass()
        {
             ReadLogClient read = new ReadLogClient();
             ReadLog readLogVcf = read.ReadServiseLog();
             string infoLog = readLogVcf.ReadLogInServise;
             return infoLog;
        }
        
        
    }
}