using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuestionServiceWebApi;
using PairingTest.Domain.Model;
using System.Collections.Generic;
using PairingTest.Unit.Tests.QuestionServiceWebApi.Stubs;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi
{
    [TestClass]
    public class QuestionRepositoryTests
    {
        [TestMethod]
        public void ShouldGetExpectedQuestionnaire()
        {
            // Arrange
            var questionRepository = new QuestionRepository();

            // Act
            var questionnaire = questionRepository.GetQuestionnaire();
            var zeroIds = questionnaire.Questions.Count(q => q.Id == 0);

            // Assert
            Assert.IsTrue(questionnaire.Id != 0);
            Assert.IsTrue(zeroIds == 0);
            Assert.AreEqual<string>("Geography Questions", questionnaire.QuestionnaireTitle);
            Assert.AreEqual<string>("What is the capital of Cuba?", questionnaire.Questions[0].Title);
            Assert.AreEqual<string>("What is the capital of France?", questionnaire.Questions[1].Title);
            Assert.AreEqual<string>("What is the capital of Poland?", questionnaire.Questions[2].Title);
            Assert.AreEqual<string>("What is the capital of Germany?", questionnaire.Questions[3].Title);
        }

        [TestMethod]
        public void ShouldGetExpectedQuestionnaireFromMock()
        {
            // Arrange
            var questionRepository = new MockQuestionRepository();

            // Act
            var questionnaire = questionRepository.GetQuestionnaire();
            var zeroIds = questionnaire.Questions.Count(q => q.Id == 0);

            // Assert
            Assert.IsTrue(questionnaire.Id != 0);
            Assert.IsTrue(zeroIds == 0);
            Assert.AreEqual<string>("Geography Questions", questionnaire.QuestionnaireTitle);
            Assert.AreEqual<string>("What is the capital of Italy?", questionnaire.Questions[0].Title);
            Assert.AreEqual<string>("What is the capital of UK?", questionnaire.Questions[1].Title);
        }


        [TestMethod]
        public void ShouldSubmitCompletedQuestionnaire()
        {
            // Arrange
            var questionRepository = new QuestionRepository();
            Questionnaire quest = new Questionnaire()
            {
                Id = 1,
                QuestionnaireTitle = "Geography Questions",
                Questions = new List<Question>()
                {
                    new Question() {Id=1, Title= "What is the capital of Cuba?", Answer="Havana" },
                    new Question() {Id=2, Title=  "What is the capital of France?", Answer="Paris" },
                    new Question() {Id=3, Title=  "What is the capital of Poland?", Answer="Warsaw" },
                    new Question() {Id=4, Title=  "What is the capital of Germany?", Answer="Berlin" }
                }
            };

            // Act
            var result = questionRepository.SubmitQuestionnaire(quest);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldFailCompletedQuestionnaire_WrongId()
        {
            // Arrange
            var questionRepository = new QuestionRepository();
            Questionnaire quest = new Questionnaire()
            {
                Id = 0,
                QuestionnaireTitle = "Geography Questions",
                Questions = new List<Question>()
                {
                    new Question() {Id=1, Title= "What is the capital of Cuba?", Answer="Havana" },
                    new Question() {Id=2, Title=  "What is the capital of France?", Answer="Paris" },
                    new Question() {Id=3, Title=  "What is the capital of Poland?", Answer="Warsaw" },
                    new Question() {Id=4, Title=  "What is the capital of Germany?", Answer="Berlin" }
                }
            };

            // Act
            var result = questionRepository.SubmitQuestionnaire(quest);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldFailCompletedQuestionnaire_WrongQuestionId()
        {
            // Arrange
            var questionRepository = new QuestionRepository();
            Questionnaire quest = new Questionnaire()
            {
                Id = 0,
                QuestionnaireTitle = "Geography Questions",
                Questions = new List<Question>()
                {
                    new Question() {Id=1, Title= "What is the capital of Cuba?", Answer="Havana" },
                    new Question() {Id=0, Title=  "What is the capital of France?", Answer="Paris" },
                    new Question() {Id=3, Title=  "What is the capital of Poland?", Answer="Warsaw" },
                    new Question() {Id=4, Title=  "What is the capital of Germany?", Answer="Berlin" }
                }
            };

            // Act
            var result = questionRepository.SubmitQuestionnaire(quest);

            //Assert
            Assert.IsFalse(result);
        }
    }
}