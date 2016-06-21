using System.Web.Http;
using QuestionServiceWebApi.Interfaces;
using PairingTest.Domain.Model;
using PairingTest.Data.DTO;
using AutoMapper;
using System;
using PairingTest.Common.Abstract;

namespace QuestionServiceWebApi.Controllers
{
    public class QuestionsController : ApiController
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor is injected with correct objects by Unity
        /// </summary>
        /// <param name="questionRepository"></param>
        /// <param name="logger"></param>
        public QuestionsController(IQuestionRepository questionRepository, ILogger logger)
        {
            if (questionRepository == null) throw new NullReferenceException("IQuestionRepository not implemented");
            if (logger == null) throw new NullReferenceException("ILogger not implemented");
            _questionRepository = questionRepository;
            _logger = logger;
        }

        /// <summary>
        /// Gets the whole questionnaire
        /// </summary>
        /// <returns></returns>
        public QuestionnaireDTO Get()
        {
            try
            {
                Questionnaire quest = _questionRepository.GetQuestionnaire();
                return Mapper.Map<Questionnaire, QuestionnaireDTO>(quest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return null;
            }
        }

        /// <summary>
        /// Submits the whole compiled questionnaire
        /// </summary>
        /// <param name="compiledQuestionnaire"></param>
        /// <returns></returns>
        public bool Post(QuestionnaireDTO compiledQuestionnaire)
        {
            try
            {
                Questionnaire quest = Mapper.Map<QuestionnaireDTO, Questionnaire>(compiledQuestionnaire);
                return _questionRepository.SubmitQuestionnaire(quest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return false;
            }

        }

    }
}
