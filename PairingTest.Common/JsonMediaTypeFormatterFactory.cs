using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.Common
{

    public enum JsonMediaTypeFormatterMode
    {
        TypeNameHandlingAll
    }

    /// <summary>
    /// Simple Factory for JsonMediaTypeFormatter
    /// </summary>
    public static class JsonMediaTypeFormatterFactory
    {

        /// <summary>
        /// Returns the requested JsonMediaTypeFormatter for WebAPI client
        /// </summary>
        /// <param name="mode">JsonMediaTypeFormatterMode</param>
        /// <returns>JsonMediaTypeFormatter</returns>
        public static JsonMediaTypeFormatter Get(JsonMediaTypeFormatterMode mode)
        {
            JsonMediaTypeFormatter formatter;
            switch (mode)
            {
                case JsonMediaTypeFormatterMode.TypeNameHandlingAll:
                    formatter = new JsonMediaTypeFormatter();
                    formatter.SerializerSettings = new JsonSerializerSettings { TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All };
                    break;
                default:
                    formatter = new JsonMediaTypeFormatter();
                    break;
            }
            return formatter;
        }

    }
}
