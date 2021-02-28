using System;
using CoWorkingApp.App.Enumerations;
using CoworkingApp.Data;
using CoWorkingApp.Models;
using CoWorkingApp.Data.Tools;

namespace CoWorkingApp.App.Logic
{
    public class UserService
    {
        private UserData userData {get;set;}

        public UserService(UserData userData){
            this.userData = userData;

        }

        public void  ExecuteAction(AdminUser menuAdminUsuarioSelected){
            switch (menuAdminUsuarioSelected)
                    {
                        case AdminUser.Crear:
                            User newUser = new User();
                            Console.WriteLine("Escriba el nombre: ");
                            newUser.Name = Console.ReadLine();
                            Console.WriteLine("Escriba el apellido: ");
                            newUser.LastName = Console.ReadLine();
                            Console.WriteLine("Escriba el email: ");
                            newUser.Email = Console.ReadLine();
                            Console.WriteLine("Escriba la contraseña: ");
                            newUser.PassWord = EncryptData.GetPassword();
                            userData.CreateUser(newUser);
                            Console.WriteLine("Usuario creado con éxito!");

                        break;
                        case AdminUser.Editar:
                            
                        break;
                        case AdminUser.Eliminar:
                            
                        break;
                        case AdminUser.CambiarPassword:
                            
                        break;
                    } 
        }
    }


}