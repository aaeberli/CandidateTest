using PairingTest.Common.Abstract;
using PairingTest.Data.DTO;
using PairingTest.Web.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PairingTest.Web.Clients
{
    /// <summary>
    /// Implements the WebAPI client
    /// </summary>
    public class QuestionServiceClient : BaseWebApiProxy, IServiceClient
    {
        public QuestionServiceClient(HttpMessageHandler httpMessageHandler)
            : base(httpMessageHandler)
        {

        }

        /// <summary>
        /// Gets the whole questionnaire
        /// </summary>
        /// <returns>The Questionnaire</returns>
        public async Task<QuestionnaireDTO> Questions_Get()
        {
            return await Set("Questions", "Get").Get<QuestionnaireDTO>();
        }

        /// <summary>
        /// Submits the compiled questionnaire
        /// </summary>
        /// <param name="DTO"></param>
        /// <returns>Returns result from submitting</returns>
        public async Task<bool> Questions_Submit(QuestionnaireDTO DTO)
        {
            return await Set("Questions", "Post").Post<bool, QuestionnaireDTO>(DTO);
        }

    }
}