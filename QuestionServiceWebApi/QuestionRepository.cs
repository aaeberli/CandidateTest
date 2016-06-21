using System.Collections.Generic;
using QuestionServiceWebApi.Interfaces;
using PairingTest.Domain.Model;
using System.Linq;

namespace QuestionServiceWebApi
{
    public class QuestionRepository : IQuestionRepository
    {
        /// <summary>
        /// Gets the whole questionnaire
        /// </summary>
        /// <returns></returns>
        public Questionnaire GetQuestionnaire()
        {
            return new Questionnaire
            {
                Id = 1,
                QuestionnaireTitle = "Geography Questions",
                Questions = new List<Question>
                {
                    new Question() {Id=1, Title= "What is the capital of Cuba?" },
                    new Question() {Id=2, Title=  "What is the capital of France?" },
                    new Question() {Id=3, Title=  "What is the capital of Poland?" },
                    new Question() {Id=4, Title=  "What is the capital of Germany?" }
                }
            };
        }

        /// <summary>
        /// Submits the whole compiled questionnaire
        /// </summary>
        /// <param name="quest">Compiled questionnaire</param>
        /// <returns></returns>
        public bool SubmitQuestionnaire(Questionnaire quest)
        {
            if (ValidQuestionnaire(quest))
            {
                // Here should go some code to store the questionnaire
                return true;
            }
            else return false;
        }

        private bool ValidQuestionnaire(Questionnaire quest)
        {
            return quest.Id != 0
                  && quest.Questions.Count(q => q.Id == 0) == 0;
        }
    }
}