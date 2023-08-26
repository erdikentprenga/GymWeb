using System;
using System.Collections.Generic;

namespace GymWeb.Entities;

public partial class Member
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public DateTime Birthday { get; set; }

    public string? Email { get; set; }

    public DateTime RegistrationDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<MembersSubscription> MembersSubscriptions { get; set; } = new List<MembersSubscription>();
}
