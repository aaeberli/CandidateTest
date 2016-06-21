using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PairingTest.Web.Models
{
    /// <summary>
    /// ViewModel for Questionnaire
    /// </summary>
    public class QuestionnaireViewModel
    {
        [Required]
        public int Id { get; set; }
        public string QuestionnaireTitle { get; set; }
        [Required]
        public IList<QuestionViewModel> Questions { get; set; }
    }
}