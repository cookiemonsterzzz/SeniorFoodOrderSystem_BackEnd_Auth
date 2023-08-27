namespace senior_food_order_system_auth;

public partial class User
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = string.Empty!;

    public string PhoneNo { get; set; } = null!;

    public string Passcode { get; set; } = string.Empty!;

    public string RoleType { get; set; } = string.Empty;

    public DateTimeOffset? DateTimeCreated { get; set; } = DateTimeOffset.Now;

    public DateTimeOffset? DateTimeUpdated { get; set; } = DateTimeOffset.Now;
}
