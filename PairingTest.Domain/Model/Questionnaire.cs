using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PairingTest.Domain.Model
{
    /// <summary>
    /// Questionnaire class
    /// </summary>
    public class Questionnaire
    {
        [Required]
        public int Id { get; set; }
        public string QuestionnaireTitle { get; set; }
        [Required]
        public IList<Question> Questions { get; set; }
    }
}