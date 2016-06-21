using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.Data.DTO
{
    /// <summary>
    /// DTO Mapping a single Question
    /// </summary>
  public  class QuestionDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Answer { get; set; }
    }
}
