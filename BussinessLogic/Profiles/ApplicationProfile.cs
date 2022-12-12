using BussinessLogic.DTOs;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Profiles
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(x => x.Id, o => o.Ignore());
            CreateMap<UserDto, User>();

            CreateMap<Question, QuestionDto>()
                .ForMember(x => x.UserName, o => o.MapFrom(s => s.User.UserName))
                .ForMember(x => x.TopicName, o => o.MapFrom(s => s.Topic.Name));
            CreateMap<QuestionDto, Question>();
            
            CreateMap<Reply, ReplyDto>()
                .ForMember(x => x.UserName, o => o.MapFrom(s => s.User.UserName));
            CreateMap<ReplyDto, Reply>();

            CreateMap<Topic, TopicDto>();
        }
    }
}
