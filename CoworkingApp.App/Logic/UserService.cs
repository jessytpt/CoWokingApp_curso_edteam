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
                            Console.WriteLine("Ingrese correo del usuario: ");
                            var userFound = userData.FindUser(Console.ReadLine());
                            while(userFound == null)
                            {
                                Console.WriteLine("Correo no válido. Vuelva a ingresar correo: ");
                                userFound = userData.FindUser(Console.ReadLine());
                            }
                            Console.WriteLine("Escriba el nombre: ");
                            userFound.Name = Console.ReadLine();
                            Console.WriteLine("Escriba el apellido: ");
                            userFound.LastName = Console.ReadLine();
                            Console.WriteLine("Escriba el email: ");
                            userFound.Email = Console.ReadLine();
                            Console.WriteLine("Escriba la contraseña: ");
                            userFound.PassWord = EncryptData.GetPassword();
                            userData.EditUser(userFound);
                            Console.WriteLine("Usuario editado con éxito!");
                        break;
                        case AdminUser.Eliminar:
                            Console.WriteLine("Ingrese correo del usuario: ");
                            var userFoundDelete = userData.FindUser(Console.ReadLine());
                            while(userFoundDelete == null)
                            {
                                Console.WriteLine("Correo no válido. Vuelva a ingresar correo: ");
                                userFoundDelete = userData.FindUser(Console.ReadLine());
                            }

                            Console.WriteLine($"¿Está seguro/a de eliminar a {userFoundDelete.Name} {userFoundDelete.LastName}? SI - NO");

                            if(Console.ReadLine().ToString() == "SI"){

                                userData.DeleteUser(userFoundDelete.UserId);
                                Console.WriteLine("Usurio eliminado con éxito!");
                            } 

                        break;
                        case AdminUser.CambiarPassword:
                            Console.WriteLine("Ingrese correo del usuario: ");
                            var userFoundPasswod = userData.FindUser(Console.ReadLine());
                            while(userFoundPasswod == null)
                            {
                                Console.WriteLine("Correo no válido. Vuelva a ingresar correo: ");
                                userFoundPasswod = userData.FindUser(Console.ReadLine());
                            }
                            Console.WriteLine("Escriba la nueva contraseña: ");
                            userFoundPasswod.PassWord = EncryptData.GetPassword();
                            userData.EditUser(userFoundPasswod);
                            Console.WriteLine("Contraseña cambiada con éxito!");
                        break;
                    } 
        }
    }


}