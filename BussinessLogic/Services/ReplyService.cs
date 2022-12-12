using AutoMapper;
using BussinessLogic.DTOs;
using BussinessLogic.Intefraces;
using Data.Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Services
{
    public class ReplyService : IReplyService
    {
        private readonly WebForumDbContext context;
        private readonly IMapper mapper;

        public ReplyService(WebForumDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task AddReplyAsync(ReplyDto reply)
        {
            await context.Replies.AddAsync(mapper.Map<Reply>(reply));
            await context.SaveChangesAsync();
        }

        public ICollection<ReplyDto> GetRepliesByQuestionId(int id)
        {
            var replies = context.Replies.Where(x => x.QuestionId == id).ToList();

            return mapper.Map<ICollection<ReplyDto>>(replies);
        }
    }
}
