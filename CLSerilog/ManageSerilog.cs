using Microsoft.Extensions.Configuration.UserSecrets;
using Serilog;
namespace CLSerilog
{
    public class ManageSerilog
    {
        private string sMsg = string.Empty;
       
        private  readonly ILogger _log = Log.ForContext(typeof(ManageSerilog));

        public  void LogVerbose(string utenteLoggato, string nameSpace, string message)
        {
            sMsg = string.Format("{0} {1} - {2}", utenteLoggato, nameSpace, message);
            _log.Verbose(sMsg);
        }

        public void LogDebug(string utenteLoggato, string nameSpace, string message)
        {
            sMsg = string.Format("{0} {1} - {2}", utenteLoggato, nameSpace, message);
            _log.Error(sMsg);
        }

        public void LogInformation(string utenteLoggato, string nameSpace, string message)
        {
            sMsg = string.Format("{0} {1} - {2}", utenteLoggato, nameSpace, message);
            _log.Information(sMsg);
        }

        public void LogWarning(string utenteLoggato, string nameSpace, string message)
        {
            sMsg = string.Format("{0} {1} - {2}", utenteLoggato, nameSpace, message);
            _log.Warning(sMsg);
        }

        public  void LogError(string utenteLoggato, string nameSpace, string message)
        {
            sMsg = string.Format("{0} {1} - {2}", utenteLoggato, nameSpace, message);
            _log.Error(sMsg);
        }

        public void LogError(string utenteLoggato, string nameSpace, Exception ex)
        {

            string sErr = string.Empty;
            if (ex.InnerException != null)
            {
                sMsg = string.Format("Source: {0}{4}Message: {1}{4}StackTrace: {2}{4}InnerException: {3}{4}", ex.Source, ex.Message, ex.StackTrace, ex.InnerException.Message, System.Environment.NewLine);
            }
            else
            {
                sErr = string.Format("Source: {0}{3}Message: {1}{3}StackTrace: {2}{3}", ex.Source, ex.Message, ex.StackTrace, System.Environment.NewLine);
            }
            sMsg = string.Format("{0} {1} - {2}", utenteLoggato, nameSpace, sErr);
            _log.Error(sMsg);
        }

        public void LogFatal(string utenteLoggato, string nameSpace, string message)
        {
            sMsg = string.Format("{0} {1} - {2}", utenteLoggato, nameSpace, message);
            _log.Fatal(sMsg);
        }

        public void LogFatal(string utenteLoggato, string nameSpace, Exception ex)
        {

            string sErr = string.Empty;
            if (ex.InnerException != null)
            {
                sMsg = string.Format("Source: {0}{4}Message: {1}{4}StackTrace: {2}{4}InnerException: {3}{4}", ex.Source, ex.Message, ex.StackTrace, ex.InnerException.Message, System.Environment.NewLine);
            }
            else
            {
                sErr = string.Format("Source: {0}{3}Message: {1}{3}StackTrace: {2}{3}", ex.Source, ex.Message, ex.StackTrace, System.Environment.NewLine);
            }
            sMsg = string.Format("{0} {1} - {2}", utenteLoggato, nameSpace, sErr);
            _log.Fatal(sMsg);
        }
    }
}
