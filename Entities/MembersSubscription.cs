using System;
using System.Collections.Generic;

namespace GymWeb.Entities;

public partial class MembersSubscription
{
    public MembersSubscription()
    {
        Member = new Member();
        Subscription= new Subscription();   
    }

    public int Id { get; set; }

    public int MemberId { get; set; }

    public int SubscriptionId { get; set; }

    public decimal OriginalPrice { get; set; }

    public decimal DiscountValue { get; set; }

    public decimal PaidPrice { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int RemainingSessions { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Member Member { get; set; }

    public virtual Subscription Subscription { get; set; }
}
