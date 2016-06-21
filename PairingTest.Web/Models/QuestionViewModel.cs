using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.Web.Models
{
    /// <summary>
    /// ViewModel for single Question
    /// </summary>
    public class QuestionViewModel
    {
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        [Required]
        public string Answer { get; set; }
    }
}
