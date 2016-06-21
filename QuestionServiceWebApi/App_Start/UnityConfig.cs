using Microsoft.Practices.Unity;
using PairingTest.Common.Abstract;
using QuestionServiceWebApi.Infrastructure;
using QuestionServiceWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace QuestionServiceWebApi
{
    /// <summary>
    /// Contains static Unity configurations for dependency injection
    /// </summary>
    public class UnityConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IQuestionRepository, QuestionRepository>();
            container.RegisterType<ILogger, Logger>();
            config.DependencyResolver = new UnityResolver(container);

        }
    }
}