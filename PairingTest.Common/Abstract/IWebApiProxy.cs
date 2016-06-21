using System.Threading.Tasks;
namespace PairingTest.Common.Abstract
{
    /// <summary>
    /// Defines base WebAPI client's methods
    /// </summary>
    public interface IWebApiProxy
    {
        /// <summary>
        /// Defines a HTTP Post with a result
        /// </summary>
        /// <typeparam name="TOut">Output Type</typeparam>
        /// <typeparam name="TIn">Input Type</typeparam>
        /// <param name="inputParams">Input object</param>
        /// <returns>Output object</returns>
        Task<TOut> Post<TOut, TIn>(TIn inputParams);

        /// <summary>
        /// Performs a HTTP Post with a result
        /// </summary>
        /// <typeparam name="TIn">Input Type</typeparam>
        /// <param name="inputParams">Input object</param>
        /// <returns>Output object</returns>
        Task Post<TIn>(TIn inputParams);

        /// <summary>
        /// Performs a HTTP Get
        /// </summary>
        /// <typeparam name="TOut">Output Type</typeparam>
        /// <returns>Output object</returns>
        Task<TOut> Get<TOut>();
    }
}


