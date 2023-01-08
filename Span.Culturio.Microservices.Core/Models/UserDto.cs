using System;
using FluentValidation;
using Span.Culturio.Microservices.Core.Enums;

namespace Span.Culturio.Microservices.Core.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public RolesEnum RoleId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }

    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .Length(3, 100);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .Length(3, 100);

            RuleFor(x => x.Email)
                .NotEmpty()
                .Length(5, 255)
                .EmailAddress();

            RuleFor(x => x.Username)
                .NotEmpty()
                .Length(3, 100);

            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(10, 100)
                .Matches("[A-Z]").WithMessage("'{PropertyName}' must contain one or more capital letters.")
                .Matches("[a-z]").WithMessage("'{PropertyName}' must contain one or more lowercase letters.")
                .Matches(@"\d").WithMessage("'{PropertyName}' must contain one or more digits.")
                .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("'{ PropertyName}' must contain one or more special characters.");


        }
    }
}

