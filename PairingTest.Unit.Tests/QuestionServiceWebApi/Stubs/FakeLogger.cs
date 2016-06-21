using PairingTest.Common.Abstract;
using System;
using System.Diagnostics;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi.Stubs
{
    internal class FakeLogger : ILogger
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
