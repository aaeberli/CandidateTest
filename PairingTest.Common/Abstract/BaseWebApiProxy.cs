using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace PairingTest.Common.Abstract
{
    /// <summary>
    /// Base class wrapping calls to a WebAPI service
    /// </summary>
    public abstract class BaseWebApiProxy : IWebApiProxy
    {
        public HttpResponseMessage ResponseMessage { get; private set; }
        public bool Success { get { return ResponseMessage.IsSuccessStatusCode; } }

        public string SessionID { get; set; }

        private const string JSON = "application/json";

        private string _baseUrl;
        private string _rightUrl;

        private HttpMessageHandler _httpMessageHandler;

        public BaseWebApiProxy(HttpMessageHandler httpMessageHandler)
        {
            _httpMessageHandler = httpMessageHandler;
            try
            {
                _baseUrl = ensureSeparator(ConfigurationManager.AppSettings["BaseWebAPIurl"]);
            }
            catch (Exception)
            {
                _baseUrl = "localhost/";
            }
        }

        /// <summary>
        /// Sets base info for every call
        /// </summary>
        /// <param name="controllerName">WebAPI Controller name</param>
        /// <param name="actionName">Controller's Action name</param>
        /// <param name="value">Any parameters</param>
        /// <returns></returns>
        protected BaseWebApiProxy Set(string controllerName, string actionName, string value = null)
        {
            _rightUrl = composeURL(controllerName, actionName, value);
            return this;
        }

        /// <summary>
        /// Ensures correct base URL
        /// </summary>
        /// <param name="url">URL to check</param>
        /// <returns></returns>
        private string ensureSeparator(string url)
        {
            return url.EndsWith("/") ? url : url + "/";
        }

        /// <summary>
        /// Composes the URL with Controller and Action name
        /// </summary>
        /// <param name="controllerName">WebAPI Controller name</param>
        /// <param name="actionName">Controller's Action name</param>
        /// <param name="value">Any parameters</param>
        /// <returns></returns>
        private string composeURL(string controllerName, string actionName, string value)
        {
            if (value == null)
                return string.Format("{0}/{1}", controllerName, actionName);
            else
                return string.Format("{0}/{1}/{2}", controllerName, actionName, value);
        }

        /// <summary>
        /// Initializes the HttpClient object
        /// </summary>
        /// <param name="client">HttpClient object</param>
        private void Init(HttpClient client)
        {
            if (_rightUrl == null) throw new NullReferenceException("Url not properly initialized");
            client.BaseAddress = new Uri(_baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JSON));
            //client.Timeout = new TimeSpan(0, 5, 0);
            if (SessionID != null)
                client.DefaultRequestHeaders.Add("SessionID", SessionID);
        }

        /// <summary>
        /// Performs a HTTP Post with a result
        /// </summary>
        /// <typeparam name="TOut">Output Type</typeparam>
        /// <typeparam name="TIn">Input Type</typeparam>
        /// <param name="inputParams">Input object</param>
        /// <returns>Output object</returns>
        public virtual async Task<TOut> Post<TOut, TIn>(TIn inputParams)
        {
            TOut returnValue = default(TOut);

            using (var client = new HttpClient(_httpMessageHandler, false))
            {
                Init(client);
                ResponseMessage = await client.PostAsync(_rightUrl, inputParams, JsonMediaTypeFormatterFactory.Get(JsonMediaTypeFormatterMode.TypeNameHandlingAll));
                //ResponseMessage = await client.PostAsJsonAsync(_rightUrl, inputParams);

                if (!ResponseMessage.IsSuccessStatusCode)
                {
                    var responseErrorPhrase = ResponseMessage.ReasonPhrase;
                    ResponseMessage.Dispose();

                    throw new Exception(responseErrorPhrase);
                }

                var mediaTypeFormatters = new MediaTypeFormatter[] { JsonMediaTypeFormatterFactory.Get(JsonMediaTypeFormatterMode.TypeNameHandlingAll) };
                returnValue = await ResponseMessage.Content.ReadAsAsync<TOut>(mediaTypeFormatters);


                //if (ResponseMessage.IsSuccessStatusCode)
                //    return await ResponseMessage.Content.ReadAsAsync<TOut>(new MediaTypeFormatter[] { JsonMediaTypeFormatterFactory.Get(JsonMediaTypeFormatterMode.TypeNameHandlingAll) });
                //else throw new Exception(ResponseMessage.ReasonPhrase);
            }
            ResponseMessage.Dispose();

            return returnValue;
        }

        /// <summary>
        /// Performs a HTTP Post without a result
        /// </summary>
        /// <typeparam name="TIn">Input Type</typeparam>
        /// <param name="inputParams">Input object</param>
        /// <returns>Output object</returns>
        public virtual async Task Post<TIn>(TIn inputParams)
        {
            using (var client = new HttpClient(_httpMessageHandler, false))
            {
                Init(client);
                ResponseMessage = await client.PostAsync(_rightUrl, inputParams, JsonMediaTypeFormatterFactory.Get(JsonMediaTypeFormatterMode.TypeNameHandlingAll));

                ResponseMessage.Dispose();
            }
        }

        /// <summary>
        /// Performs a HTTP Get
        /// </summary>
        /// <typeparam name="TOut">Output Type</typeparam>
        /// <returns>Output object</returns>
        public virtual async Task<TOut> Get<TOut>()
        {
            using (var client = new HttpClient(_httpMessageHandler, false))
            {
                Init(client);
                ResponseMessage = await client.GetAsync(_rightUrl);

                var returnValue = ResponseMessage.IsSuccessStatusCode ? await ResponseMessage.Content.ReadAsAsync<TOut>() : default(TOut);

                ResponseMessage.Dispose();

                return returnValue;
            }
        }

    }
}

