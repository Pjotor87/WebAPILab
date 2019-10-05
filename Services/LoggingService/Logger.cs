using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace Services
{
    public class Logger : ILogger
    {
        public string FilePath { get; set; }
        public Encoding EncodingSetting { get; set; }
        public bool UseDateTimePrefix { get; set; }
        public string DateTimeFormat { get; set; }

        #region Constructor

        private const string CONFIG_KEY = "LogFilePath";
        private const bool DEFAULT_USEDATETIMEPREFIX = false;
        private const string DEFAULT_DATETIMEFORMAT = null;

        public Logger(bool useDateTimePrefix = DEFAULT_USEDATETIMEPREFIX, string dateTimeFormat = DEFAULT_DATETIMEFORMAT)
        {
            this.Construct(ConfigurationManager.AppSettings[CONFIG_KEY], Encoding.Default, useDateTimePrefix, dateTimeFormat);
        }

        public Logger(Encoding encoding, bool useDateTimePrefix = DEFAULT_USEDATETIMEPREFIX, string dateTimeFormat = DEFAULT_DATETIMEFORMAT)
        {
            this.Construct(ConfigurationManager.AppSettings[CONFIG_KEY], encoding, useDateTimePrefix, dateTimeFormat);
        }

        public Logger(string filePath, bool useDateTimePrefix = DEFAULT_USEDATETIMEPREFIX, string dateTimeFormat = DEFAULT_DATETIMEFORMAT)
        {
            this.Construct(filePath, Encoding.Default, useDateTimePrefix, dateTimeFormat);
        }

        public Logger(string filePath, Encoding encoding, bool useDateTimePrefix = DEFAULT_USEDATETIMEPREFIX, string dateTimeFormat = DEFAULT_DATETIMEFORMAT)
        {
            this.Construct(filePath, encoding, useDateTimePrefix, dateTimeFormat);
        }

        private void Construct(string filePath, Encoding encoding, bool useDateTimePrefix = DEFAULT_USEDATETIMEPREFIX, string dateTimeFormat = DEFAULT_DATETIMEFORMAT)
        {
            this.FilePath = filePath;
            this.EncodingSetting = encoding;
            this.UseDateTimePrefix = useDateTimePrefix;
            this.DateTimeFormat = dateTimeFormat;
        }
        #endregion

        public void Log(string message)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(this.FilePath));
            File.AppendAllText(this.FilePath, $"{this.PrepareLogMessage(message)}");
        }

        public void Log(Exception ex)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(this.FilePath));
            File.AppendAllText(this.FilePath, $"{this.PrepareLogMessage(ex.ToString())}");
        }

        public void Log(Exception ex, string message)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(this.FilePath));
            File.AppendAllText(this.FilePath, $"{this.PrepareLogMessage(message)}{Environment.NewLine}{this.PrepareLogMessage(ex.ToString())}");
        }

        protected string PrepareLogMessage(string str)
        {
            if (UseDateTimePrefix)
            {
                if (!string.IsNullOrEmpty(this.DateTimeFormat))
                    return $"{DateTime.Now.ToString(this.DateTimeFormat)} {str}";
                else
                    return $"{DateTime.Now.ToString()} {str}";
            }
            else
                return str;
        }
    }
}