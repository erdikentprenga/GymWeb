using System;
using System.Collections.Generic;

namespace GymWeb.Entities;

public partial class Subscription
{
    public int Id { get; set; }

    public int Code { get; set; }

    public string? Description { get; set; }

    public int NumberOfMonths { get; set; }

    public int WeekFrequency { get; set; }

    public int NumberOfSessions { get; set; }

    public decimal Price { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<MembersSubscription> MembersSubscriptions { get; set; } = new List<MembersSubscription>();
}
