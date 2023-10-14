using System;
using System.Collections.Generic;

namespace senior_food_order_system_auth;

public partial class Food
{
    public Guid Id { get; set; }

    public string FoodName { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public decimal FoodPrice { get; set; }

    public DateTimeOffset? DateTimeCreated { get; set; }

    public DateTimeOffset? DateTimeUpdated { get; set; }

    public bool? IsDeleted { get; set; }

    public Guid StallId { get; set; }

    public virtual ICollection<FoodsCustomization> FoodsCustomizations { get; set; } = new List<FoodsCustomization>();

    public virtual Stall Stall { get; set; } = null!;
}
