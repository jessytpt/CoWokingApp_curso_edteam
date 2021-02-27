using System;
using CoWorkingApp.Models;
using System.Linq;
using CoWorkingApp.Data.Tools;
using CoWorkingApp.Data;

namespace CoworkingApp.Data
{
    public class UserData
    {
        private JsonManager<User> jsonManager;

        public UserData()
        {
            jsonManager = new JsonManager<User>();

        }
        public bool CreateAdmin()
        {
            var userCollection = jsonManager.GetCollection();
            if (!userCollection.Any(p=>p.Name == "admin" && 
                                    p.LastName == "admin" &&
                                    p.Email == "admin"))
                                    {
                                        try
                                        {
                                            var adminUser = new User()
                                            {  
                                                UserId = Guid.NewGuid(),
                                                Name = "admin",
                                                LastName = "admin",
                                                Email = "admin", 
                                                PassWord = EncryptData.EncryptText("4dmin")
                                            };
                                            userCollection.Add(adminUser);
                                            jsonManager.SaveCollection(userCollection);   
                                        }
                                        catch 
                                        {
                                            return false;
                                        }                                        
                                        return true;
                                    }
            return true;
        } 
        public bool Login(string User, string Password, bool isAdmin = false){

            var userCollection = jsonManager.GetCollection();
            var passwordEncript = EncryptData.EncryptText(Password);
            var userFound = userCollection.FirstOrDefault(p=>p.Email  == User && p.PassWord == passwordEncript);

            if (isAdmin) User="admin";

            if (userFound != null) return true;

            return false;

        }

        public void Prueba(string a, string b="2" ,string c = "3"){
            Console.WriteLine(a+b+c);            
        }
    }
}