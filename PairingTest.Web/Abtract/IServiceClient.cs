using PairingTest.Data.DTO;
using System.Threading.Tasks;

namespace PairingTest.Web.Abstract
{
    /// <summary>
    /// Defines the structure of the WebAPI client
    /// </summary>
    public interface IServiceClient
    {
        /// <summary>
        /// Gets the whole questionnaire
        /// </summary>
        /// <returns>The Questionnaire</returns>
        Task<QuestionnaireDTO> Questions_Get();

        /// <summary>
        /// Submits the compiled questionnaire
        /// </summary>
        /// <param name="DTO"></param>
        /// <returns>Returns result from submitting</returns>
        Task<bool> Questions_Submit(QuestionnaireDTO DTO);
    }
}