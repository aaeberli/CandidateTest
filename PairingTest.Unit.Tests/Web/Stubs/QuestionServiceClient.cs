using PairingTest.Common.Abstract;
using PairingTest.Data.DTO;
using PairingTest.Web.Abstract;
using System.Net.Http;
using System.Threading.Tasks;

namespace PairingTest.Unit.Tests.Web.Stubs
{
    public class QuestionServiceClient : BaseWebApiProxy, IServiceClient
    {
        public QuestionServiceClient(HttpMessageHandler httpMessageHandler)
            : base(httpMessageHandler)
        {

        }

        public async Task<QuestionnaireDTO> Questions_Get()
        {
            return await Set("Questions", "Get").Get<QuestionnaireDTO>();
        }

        public async Task<bool> Questions_Submit(QuestionnaireDTO DTO)
        {
            return await Set("Questions", "Post").Post<bool, QuestionnaireDTO>(DTO);
        }

    }
}