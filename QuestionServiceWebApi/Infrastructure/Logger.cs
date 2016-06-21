using PairingTest.Common.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace QuestionServiceWebApi.Infrastructure
{
    /// <summary>
    /// Logs errors and infos
    /// </summary>
    public class Logger : ILogger
    {
        public void LogError(Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        public void LogInfo(string message)
        {
            Debug.WriteLine(message);
        }
    }
}