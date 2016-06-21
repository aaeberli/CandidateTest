using AutoMapper;
using PairingTest.Data.DTO;
using PairingTest.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PairingTest.Web.App_Start
{
    public class MapperConfig
    {
        /// <summary>
        /// Contains static Automapper configurations for object-to-object mapping
        /// </summary>
        internal static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<QuestionnaireDTO, QuestionnaireViewModel>();
                cfg.CreateMap<QuestionDTO, QuestionViewModel>();
                cfg.CreateMap<QuestionnaireViewModel, QuestionnaireDTO>();
                cfg.CreateMap<QuestionViewModel, QuestionDTO>();
            });
        }
    }
}