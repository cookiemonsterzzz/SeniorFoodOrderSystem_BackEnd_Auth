using System;
namespace senior_food_order_system_auth.Models
{
    public class LoginDto
    {
        public required string PhoneNo { get; set; } = string.Empty;

        public required string Password { get; set; } = string.Empty;
    }
}

