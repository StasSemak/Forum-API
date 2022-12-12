using BussinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Intefraces
{
    public interface IQuestionService
    {
        Task AddQuestionAsync(QuestionDto question);

        ICollection<QuestionDto> GetByUser(string userId);
        ICollection<QuestionDto> GetByTitle(string title);

        ICollection<QuestionDto> GetFiveNewest();
    }
}
