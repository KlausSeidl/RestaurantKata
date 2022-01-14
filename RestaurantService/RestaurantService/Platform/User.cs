using System;
using RestaurantService.Services.Mail;

namespace RestaurantService.Platform
{
    public class User
    {
        public Guid Id { get; set; }
        public MailAddress Email { get; set; }
    }
}