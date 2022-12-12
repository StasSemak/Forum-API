using BussinessLogic.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Validators
{
    public class QuestionValidator : AbstractValidator<QuestionDto>
    {
        public QuestionValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .Length(1, 100);
            RuleFor(x => x.Text)
                .NotNull()
                .Length(1, 500);
        }
    }
}
