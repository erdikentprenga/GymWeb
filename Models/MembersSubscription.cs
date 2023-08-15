using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GymWeb.Models
{
    public class MembersSubscription
    {

        public int Id { get; set; }
        public int MemberId {get; set;} 

        public int SubscriptionId { get; set;}
        public decimal OriginalPrice { get; set; }
        public decimal DiscountValue { get; set; }  
        public decimal PaidPrice { get; set; }
         
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int RemainingSessions { get; set; } 

        public string? IsDeleted { get; set; }   


    }
}
