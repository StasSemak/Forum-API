using BussinessLogic.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Validators
{
    public class ReplyValidator : AbstractValidator<ReplyDto>
    {
        public ReplyValidator()
        {
            RuleFor(x => x.Text)
                .NotNull()
                .NotEmpty()
                .Length(1, 500);
        }
    }
}
