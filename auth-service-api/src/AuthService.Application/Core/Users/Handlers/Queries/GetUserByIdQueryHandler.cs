﻿using AuthService.Application.Core.Users.Queries;
using AuthService.Application.Notifications;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Application.Core.Users.Handlers.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GenericResponse>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly NotificationContext _notification;

        public GetUserByIdQueryHandler(UserManager<IdentityUser> userManager, NotificationContext notification)
        {
            _userManager = userManager;
            _notification = notification;
        }

        public async Task<GenericResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
            {
                _notification.AddNotification("User not found", $"User with id {request.Id} not found!");

                return new GenericResponse
                {
                    Notifications = _notification.Notifications,
                };
            }

            return new GenericResponse
            {
                Result = user,
            };
        }
    }
}
