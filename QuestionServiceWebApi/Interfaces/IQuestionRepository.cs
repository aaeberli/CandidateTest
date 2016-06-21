using PairingTest.Domain.Model;

namespace QuestionServiceWebApi.Interfaces
{
    public interface IQuestionRepository
    {
        Questionnaire GetQuestionnaire();
        bool SubmitQuestionnaire(Questionnaire quest);
    }
}