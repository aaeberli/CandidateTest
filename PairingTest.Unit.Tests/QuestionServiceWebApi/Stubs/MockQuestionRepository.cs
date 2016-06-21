using System;
using PairingTest.Domain.Model;
using QuestionServiceWebApi;
using QuestionServiceWebApi.Interfaces;
using System.Collections.Generic;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi.Stubs
{
    public class MockQuestionRepository : IQuestionRepository
    {
        public Questionnaire ExpectedQuestions { get; set; }
        public Questionnaire GetQuestionnaire()
        {
            return new Questionnaire
            {
                Id = 1,
                QuestionnaireTitle = "Geography Questions",
                Questions = new List<Question>
                {
                    new Question() {Id=1, Title= "What is the capital of Italy?" },
                    new Question() {Id=2, Title=  "What is the capital of UK?" },
                }
            };
        }

        public bool SubmitQuestionnaire(Questionnaire quest)
        {
            return true;
        }
    }
}