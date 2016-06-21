using System.Web.Mvc;
using PairingTest.Web.Models;
using PairingTest.Common.Abstract;
using PairingTest.Web.Clients;
using PairingTest.Data.DTO;
using System.Threading.Tasks;
using System.Net.Http;
using AutoMapper;
using PairingTest.Web.Abstract;
using System;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        IServiceClient _client;

        public QuestionnaireController(IServiceClient client)
        {
            if (client == null) throw new NullReferenceException("IServiceClient not initialized");
            _client = client;
        }

        public async Task<ViewResult> Index()
        {
            QuestionnaireDTO result = await _client.Questions_Get();
            QuestionnaireViewModel viewModel = Mapper.Map<QuestionnaireDTO, QuestionnaireViewModel>(result);
            if (viewModel == null) return View("Error");
            return View("View", viewModel);
        }

        [HttpPost]
        public async Task<ViewResult> Submit(QuestionnaireViewModel questionnaire)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                QuestionnaireDTO dto = Mapper.Map<QuestionnaireViewModel, QuestionnaireDTO>(questionnaire);
                result = await _client.Questions_Submit(dto);
                if (result) return View("SubmittedOK", result);
                else return View("SubmittedKO", result);
            }
            else
            {
                return View("Error", result);
            }
        }

    }
}
