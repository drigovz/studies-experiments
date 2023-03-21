﻿using AuthService.Application.Core.Users.Queries;
using FluentValidation;

namespace AuthService.Application.Core.Users.Validators
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}
