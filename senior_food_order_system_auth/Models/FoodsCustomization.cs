using System;
using System.Collections.Generic;

namespace senior_food_order_system_auth;

public partial class FoodsCustomization
{
    public Guid Id { get; set; }

    public string FoodCustomizationName { get; set; } = null!;

    public decimal FoodCustomizationPrice { get; set; }

    public DateTimeOffset? DateTimeCreated { get; set; }

    public DateTimeOffset? DateTimeUpdated { get; set; }

    public bool? IsDeleted { get; set; }

    public Guid FoodId { get; set; }

    public virtual Food Food { get; set; } = null!;
}
