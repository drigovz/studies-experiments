using ProductsCleanArch.Application.Notifications;
using System.Collections.Generic;

namespace ProductsCleanArch.Application.Products.Core
{
    public class ResponseCommand
    {
        public dynamic Result { get; set; } = default;

        public IEnumerable<Notification> Errors { get; set; }
    }
}
