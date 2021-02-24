using System;

namespace CoWorkingApp.Models
{
    public class Desk
    {
        public Guid DeskId { get;set; }
        public string Code { get;set; }
        public string Description { get;set; }
        public float CostHour { get;set; }
    
    }
}