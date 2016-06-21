using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PairingTest.Data.DTO
{
    /// <summary>
    /// DTO mapping the whole Questionnaire
    /// </summary>
    public class QuestionnaireDTO
    {
        public int Id { get; set; }
        public string QuestionnaireTitle { get; set; }
        public IList<QuestionDTO> Questions { get; set; }
    }
}