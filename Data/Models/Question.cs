using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<Reply> Replies { get; set; }

        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
