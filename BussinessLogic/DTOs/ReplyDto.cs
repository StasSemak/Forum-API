using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DTOs
{
    public class ReplyDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }

        public int QuestionId { get; set; }
    }
}
