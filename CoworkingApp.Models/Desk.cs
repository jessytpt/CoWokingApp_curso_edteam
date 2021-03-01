using System;
using CoWorkingApp.Models.Enumerations;
namespace CoWorkingApp.Models
{
    public class Desk
    {
        public Guid DeskId { get;set; } = Guid.NewGuid();
        public string Code { get;set; }
        public string Description { get;set; }
        public DeskStatus DeskStatus { get;set; } = DeskStatus.Active;
        
        // public float CostHour { get;set; }
    
    }
}