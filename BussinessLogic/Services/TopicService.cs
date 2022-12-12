using AutoMapper;
using BussinessLogic.DTOs;
using BussinessLogic.Intefraces;
using Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Services
{
    public class TopicService : ITopicService
    {
        private readonly WebForumDbContext context;
        private readonly IMapper mapper;

        public TopicService(WebForumDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ICollection<TopicDto> GetTopics()
        {
            var topics = context.Topics.ToList();

            return mapper.Map<ICollection<TopicDto>>(topics);    
        }
    }
}
