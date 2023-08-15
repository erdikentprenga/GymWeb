namespace GymWeb.Models
{
    public class Subscriptions
    {
        public int Id { get; set; }

        public int Code { get; set; }

        public string? Description { get; set; }

        public DateTime NumberOfMonths { get; set; }  

        public DateTime WeekFrequency { get; set; }

        public int NumberOfSessions { get; set; }   

        public decimal TotalPrice { get; set; }

        public string? IsDeleted { get; set; }





    }
}
