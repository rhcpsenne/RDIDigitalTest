using FluentValidation;
using RDIDigitalTest.Domain.Entities.CostumerCard;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDIDigitalTest.Domain.Services.Validators
{
    public class CostumerCardValidator : AbstractValidator<CostumerCard>
    {
        public CostumerCardValidator()
        {
            RuleFor(c => c.CostumerId)
                .NotEmpty().WithMessage("CostumerId cannot be empty.");

            RuleFor(c => c.CardNumber)
                .NotEmpty().WithMessage("CardNumber cannot be empty.")
                .Must(c => c.ToString().Length >= 4).WithMessage("Wrong Card Number format.")
                .Must(c => c.ToString().Length <= 16).WithMessage("Wrong Card Number format.");

            RuleFor(c => c.CVV)
                .NotEmpty().WithMessage("CVV cannot be empty.")
                .Must(c => c.ToString().Length <= 5).WithMessage("Wrong CVV format.");
        }
    }
}
