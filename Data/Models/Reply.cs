using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
