using AutoMapper;
using PairingTest.Data.DTO;
using PairingTest.Domain.Model;

namespace QuestionServiceWebApi
{
    /// <summary>
    /// Contains static Automapper configurations for object-to-object mapping
    /// </summary>
    public class MapperConfig
    {
        internal static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Questionnaire, QuestionnaireDTO>();
                cfg.CreateMap<Question, QuestionDTO>();
                cfg.CreateMap<QuestionnaireDTO, Questionnaire>();
                cfg.CreateMap<QuestionDTO, Question>();
            });
        }
    }
}