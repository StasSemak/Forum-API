using AutoMapper;
using BussinessLogic.DTOs;
using BussinessLogic.Intefraces;
using Data.Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly WebForumDbContext context;
        private readonly IMapper mapper;

        public QuestionService(WebForumDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task AddQuestionAsync(QuestionDto question)
        {
            await context.Questions.AddAsync(mapper.Map<Question>(question));
            await context.SaveChangesAsync();
        }

        public ICollection<QuestionDto> GetByTitle(string title)
        {
            var questions = context.Questions.Include(x => x.Topic).Include(x => x.User)
                .Where(x => x.Title.Contains(title));

            if (questions == null) throw new Exception("questions not found");

            return mapper.Map<ICollection<QuestionDto>>(questions);
        }
        public ICollection<QuestionDto> GetByUser(string userId)
        {
            var questions = context.Questions.Include(x => x.Topic).Include(x => x.User)
                .Where(x => x.User.Id == userId);

            if (questions == null) throw new Exception("questions not found");

            return mapper.Map<ICollection<QuestionDto>>(questions);
        }

        public ICollection<QuestionDto> GetFiveNewest()
        {
            var questions = context.Questions.Include(x => x.Topic).Include(x => x.User)
                .OrderByDescending(x => x.Time).Take(5).ToList();

            return mapper.Map<ICollection<QuestionDto>>(questions);
        }
    }
}
