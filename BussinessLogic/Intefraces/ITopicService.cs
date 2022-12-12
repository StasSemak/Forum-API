using BussinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Intefraces
{
    public interface ITopicService
    {
        ICollection<TopicDto> GetTopics();
    }
}
