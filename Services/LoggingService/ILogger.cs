using System;
using System.Text;

namespace Services.LoggingService
{
    public interface ILogger
    {
        string DateTimeFormat { get; set; }
        Encoding EncodingSetting { get; set; }
        string FilePath { get; set; }
        bool UseDateTimePrefix { get; set; }

        void Log(Exception ex);
        void Log(Exception ex, string message);
        void Log(string message);
    }
}