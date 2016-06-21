using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuestionServiceWebApi;
using PairingTest.Domain.Model;
using PairingTest.Unit.Tests.QuestionServiceWebApi.Stubs;
using QuestionServiceWebApi.Controllers;
using AutoMapper;
using PairingTest.Data.DTO;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi
{
    [TestClass]
    public class QuestionsControllerTests
    {
        [TestInitialize]
        public void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Questionnaire, QuestionnaireDTO>();
                cfg.CreateMap<Question, QuestionDTO>();
                cfg.CreateMap<QuestionnaireDTO, Questionnaire>();
                cfg.CreateMap<QuestionDTO, Question>();
            });
        }

        [TestMethod]
        public void ShouldGetQuestions()
        {
            //Arrange
            var expectedTitle = "Geography Questions";
            var expectedQuestions = new Questionnaire() { QuestionnaireTitle = expectedTitle };
            var fakeQuestionRepository = new MockQuestionRepository() { ExpectedQuestions = expectedQuestions };
            var fakeLogger = new FakeLogger();
            var questionsController = new QuestionsController(fakeQuestionRepository, fakeLogger);

            //Act
            var questions = questionsController.Get();

            //Assert
            Assert.AreEqual<string>(expectedTitle, questions.QuestionnaireTitle);
        }
    }
}