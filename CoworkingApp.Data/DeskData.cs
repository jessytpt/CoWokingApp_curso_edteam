using System;
using CoWorkingApp.Models;
using CoWorkingApp.Data;
using System.Linq;

namespace CoworkingApp.Data
{
    public class DeskData
    {
        private JsonManager<Desk> jsonManager;

        public DeskData()
        {
            jsonManager = new JsonManager<Desk>();

        }
        public Desk FindDesk(string code)
        {
            var deskCollection = jsonManager.GetCollection();

            return deskCollection.FirstOrDefault(p => p.Code == code);
        }

        public bool CreateDesk(Desk newDesk)
        {   
            var deskCollection = jsonManager.GetCollection();
            deskCollection.Add(newDesk);
            jsonManager.SaveCollection(deskCollection);
            return true;

        }

        public bool EditDesk(Desk editDesk)
        {
            var deskCollection = jsonManager.GetCollection();
            
            var indexDesk = deskCollection.FindIndex(p => p.DeskId == editDesk.DeskId);
            
            deskCollection[indexDesk] = editDesk;
            
            jsonManager.SaveCollection(deskCollection);
            
            return true;
        }

        public bool DeleteDesk(Guid userId)
        {
            var deskCollection = jsonManager.GetCollection();

            var indexDesk = deskCollection.FindIndex(p => p.DeskId == userId);

            deskCollection.RemoveAt(indexDesk);

            jsonManager.SaveCollection(deskCollection);

            return true;
        }

        
    }
}