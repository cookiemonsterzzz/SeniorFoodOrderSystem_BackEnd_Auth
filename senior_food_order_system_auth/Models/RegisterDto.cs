
namespace senior_food_order_system_auth.Models
{
    public class RegisterDto
    {
        public required string PhoneNo { get; set; } = string.Empty;

        public required string Password { get; set; } = string.Empty;

        public required string Role { get; set; } = string.Empty;
    }
}

