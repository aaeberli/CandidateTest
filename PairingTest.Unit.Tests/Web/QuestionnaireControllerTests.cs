using PairingTest.Web.Controllers;
using PairingTest.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairingTest.Unit.Tests.Web.Stubs;
using System.Net.Http;
using AutoMapper;
using PairingTest.Data.DTO;
using System.Collections.Generic;

namespace PairingTest.Unit.Tests.Web
{
    [TestClass]
    public class QuestionnaireControllerTests
    {
        [TestInitialize]
        public void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<QuestionnaireDTO, QuestionnaireViewModel>();
                cfg.CreateMap<QuestionDTO, QuestionViewModel>();
                cfg.CreateMap<QuestionnaireViewModel, QuestionnaireDTO>();
                cfg.CreateMap<QuestionViewModel, QuestionDTO>();
            });
        }

        [TestMethod]
        public void ShouldGetQuestions()
        {
            //Arrange
            var expectedTitle = "Geography Questions";
            var questionnaireController = new QuestionnaireController(new QuestionServiceClient(new HttpClientHandler()));

            //Act
            var result = (QuestionnaireViewModel)questionnaireController.Index().Result.ViewData.Model;

            //Assert
            Assert.AreEqual<string>(expectedTitle, result.QuestionnaireTitle);
        }

        [TestMethod]
        public void ShouldSubmitQuestions()
        {
            //Arrange
            var questionnaireController = new QuestionnaireController(new QuestionServiceClient(new HttpClientHandler()));
            QuestionnaireViewModel vm= new QuestionnaireViewModel
            {
                Id = 1,
                QuestionnaireTitle = "Geography Questions",
                Questions = new List<QuestionViewModel>
                {
                    new QuestionViewModel() {Id=1, Title= "What is the capital of Cuba?" },
                    new QuestionViewModel() {Id=2, Title=  "What is the capital of France?" },
                    new QuestionViewModel() {Id=3, Title=  "What is the capital of Poland?" },
                    new QuestionViewModel() {Id=4, Title=  "What is the capital of Germany?" }
                }
            };
            //Act
            var result = (bool)questionnaireController.Submit(vm).Result.ViewData.Model;

            //Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void ShouldFailSubmitQuestions_WrongId()
        {
            //Arrange
            var questionnaireController = new QuestionnaireController(new QuestionServiceClient(new HttpClientHandler()));
            QuestionnaireViewModel vm = new QuestionnaireViewModel
            {
                Id = 0,
                QuestionnaireTitle = "Geography Questions",
                Questions = new List<QuestionViewModel>
                {
                    new QuestionViewModel() {Id=1, Title= "What is the capital of Cuba?" },
                    new QuestionViewModel() {Id=2, Title=  "What is the capital of France?" },
                    new QuestionViewModel() {Id=3, Title=  "What is the capital of Poland?" },
                    new QuestionViewModel() {Id=4, Title=  "What is the capital of Germany?" }
                }
            };
            //Act
            var result = (bool)questionnaireController.Submit(vm).Result.ViewData.Model;

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldFailSubmitQuestions_WrongQuestionId()
        {
            //Arrange
            var questionnaireController = new QuestionnaireController(new QuestionServiceClient(new HttpClientHandler()));
            QuestionnaireViewModel vm = new QuestionnaireViewModel
            {
                Id = 1,
                QuestionnaireTitle = "Geography Questions",
                Questions = new List<QuestionViewModel>
                {
                    new QuestionViewModel() {Id=1, Title= "What is the capital of Cuba?" },
                    new QuestionViewModel() {Id=2, Title=  "What is the capital of France?" },
                    new QuestionViewModel() {Id=0, Title=  "What is the capital of Poland?" },
                    new QuestionViewModel() {Id=4, Title=  "What is the capital of Germany?" }
                }
            };
            //Act
            var result = (bool)questionnaireController.Submit(vm).Result.ViewData.Model;

            //Assert
            Assert.IsFalse(result);
        }
    }
}