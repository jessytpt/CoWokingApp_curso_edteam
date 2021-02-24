using System;

namespace CoWorkingApp.Models
{
    public class Reservation
    {
        public Guid ReservationId { get;set; }
        public string ReservationDate { get;set; }
        public Guid DeskId { get;set; }
        public Guid UserId { get;set; }

        public string StartTime {get;set;}
        public string EndTime {get;set;}
        public float TotalCost {get;set; }
    
    }
}