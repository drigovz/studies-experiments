﻿using Producer.Application.Notifications;

namespace Producer.Application.Core;

public class BaseResponse
{
    public dynamic Result { get; set; } = default;

    public IEnumerable<Notification> Notifications { get; set; }

}