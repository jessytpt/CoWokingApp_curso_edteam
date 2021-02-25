using System;
using CoworkingApp.Data;

namespace CoworkingApp.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string roleSelected = "";
            Console.WriteLine("\nBienvenido al CoWorking!\n");   
            while (roleSelected!="1" && roleSelected!="2")
            {
                Console.WriteLine("1 = Administrados; 2 = Usuario ");   
                roleSelected = Console.ReadLine();    
            }       
            
            if(roleSelected=="1"){
                string menuAdminSelected = "";
                while (menuAdminSelected!="1" && menuAdminSelected!="2")
                {
                    Console.WriteLine("1 = Administración de Puestos; 2 = Administración de Usuarios ");   
                    menuAdminSelected = Console.ReadLine();    
                } 
                if (menuAdminSelected=="1")
                {
                    string menuPuestosSelected = "";
                    while(menuPuestosSelected!="1" && 
                          menuPuestosSelected!="2" &&
                          menuPuestosSelected!="3" &&
                          menuPuestosSelected!="4" )
                    {
                              Console.WriteLine("Administración de puestos");
                        Console.WriteLine("1=Crear; 2=Editar; 3=Eliminar; 4=Bloquear");
                        menuPuestosSelected = Console.ReadLine();   
                    }
                    
                    switch (menuPuestosSelected)
                    {
                        case "1":
                            Console.WriteLine("Opción: crear puesto");
                        break;
                        case "2":
                            Console.WriteLine("Opción: editar puesto");
                        break;
                        case "3":
                            Console.WriteLine("Opción: eliminar puesto");
                        break;
                        case "4":
                            Console.WriteLine("Opción: bloquear puesto");
                        break;
                    } 
                }else if (menuAdminSelected=="2")
                {
                    string menuUsuarioSelected = "";
                    while(menuUsuarioSelected!="1" && 
                          menuUsuarioSelected!="2" &&
                          menuUsuarioSelected!="3" &&
                          menuUsuarioSelected!="4" )
                    {
                              Console.WriteLine("Administración de usuarios");
                        Console.WriteLine("1=Crear; 2=Editar; 3=Eliminar; 4=Cambiar contraseña");
                        menuUsuarioSelected = Console.ReadLine();   
                    }
                    
                    switch (menuUsuarioSelected)
                    {
                        case "1":
                            Console.WriteLine("Opción: crear usuario");
                        break;
                        case "2":
                            Console.WriteLine("Opción: editar usuario");
                        break;
                        case "3":
                            Console.WriteLine("Opción: eliminar usuario");
                        break;
                        case "4":
                            Console.WriteLine("Opción: cambiar contraseña");
                        break;
                    } 
                }
            }else if(roleSelected=="2")
            {
                
            }
        }
    }
}
