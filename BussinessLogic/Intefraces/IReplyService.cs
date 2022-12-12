using BussinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Intefraces
{
    public interface IReplyService
    {
        Task AddReplyAsync(ReplyDto reply);

        ICollection<ReplyDto> GetRepliesByQuestionId(int id);
    }
}
