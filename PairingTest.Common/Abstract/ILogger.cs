using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.Common.Abstract
{
    /// <summary>
    /// Defines a simple logging interface
    /// </summary>
    public interface ILogger
    {
        void LogError(Exception ex);

        void LogInfo(string message);
    }
}
