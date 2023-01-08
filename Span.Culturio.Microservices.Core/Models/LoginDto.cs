using System;
using FluentValidation;

namespace Span.Culturio.Microservices.Core.Models
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }

    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .Length(3, 100);

            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(10, 100);
        }
    }
}

