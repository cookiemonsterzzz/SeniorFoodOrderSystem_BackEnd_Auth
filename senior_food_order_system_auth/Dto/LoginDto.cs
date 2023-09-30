namespace senior_food_order_system_auth.Dto
{
    public class LoginDto
    {
        public required string PhoneNo { get; set; } = string.Empty;

        public required string Password { get; set; } = string.Empty;
    }
}

