using System;
using CoworkingApp.Data;
using CoWorkingApp.App.Enumerations;
using CoWorkingApp.App.Logic;
using CoWorkingApp.Data.Tools;


namespace CoworkingApp.App
{
    class Program
    {
        static UserData UserDataService {get;set;} = new UserData();
        static UserService UserLogicService {get;set;} = new UserService(UserDataService);
        
        static void Main(string[] args)
        {
            
            string roleSelected = "";
            Console.WriteLine("\nBienvenido al CoWorking!\n");   
            while (roleSelected!="1" && roleSelected!="2")
            {
                Console.WriteLine("1 = Administrados; 2 = Usuario ");   
                roleSelected = Console.ReadLine();    
            }       
            
            if(Enum.Parse<UserRole>(roleSelected) == UserRole.Admin){

                bool loginResult = false;
                
                while (!loginResult)
                {
                    
                    Console.WriteLine("Ingrese correo:");
                    var userLogin = Console.ReadLine();
                    Console.WriteLine("Ingrese contraseña:");
                    var passwordLogin = EncryptData.GetPassword();

                    loginResult = UserDataService.Login(userLogin,passwordLogin);

                    if (!loginResult) Console.WriteLine("Correo/Contraseña incorrectos, vuelva a intentarlo!");
                }
                

                string menuAdminSelected = "";
                while (menuAdminSelected!="1" && menuAdminSelected!="2")
                {
                    Console.WriteLine("1 = Administración de Puestos; 2 = Administración de Usuarios ");   
                    menuAdminSelected = Console.ReadLine();    
                } 
                if (Enum.Parse<MenuAdmin>(menuAdminSelected) == MenuAdmin.AdministracionPuestos)
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

                    AdminPuestos menuAdminPuestosSelected = Enum.Parse<AdminPuestos>(menuPuestosSelected);
                    
                    switch (menuAdminPuestosSelected)
                    {
                        case AdminPuestos.Crear:
                            Console.WriteLine("Opción: crear puesto");
                        break;
                        case AdminPuestos.Editar:
                            Console.WriteLine("Opción: editar puesto");
                        break;
                        case AdminPuestos.Eliminar:
                            Console.WriteLine("Opción: eliminar puesto");
                        break;
                        case AdminPuestos.Bloquear:
                            Console.WriteLine("Opción: bloquear puesto");
                        break;
                    } 
                }else if (Enum.Parse<MenuAdmin>(menuAdminSelected)==MenuAdmin.AdministracionUsuarios)
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

                    AdminUser menuAdminUsuarioSelected = Enum.Parse<AdminUser>(menuUsuarioSelected);
                    
                    //dependiendo de la op que haya escogido el usuario, se ejecutará una acción determinada
                    UserLogicService.ExecuteAction(menuAdminUsuarioSelected);
                    
                }
            }else if(Enum.Parse<UserRole>(roleSelected) == UserRole.User)
            {
                string menuUsuarioSelected = "";
                
                while(menuUsuarioSelected!="1" &&
                      menuUsuarioSelected!="2" &&
                      menuUsuarioSelected!="3" &&
                      menuUsuarioSelected!="4" )
                {
                    Console.WriteLine("1= Reservar puesto; 2= Cancelar reserva; 3= Ver historial de reservas; 4= Cambiar contraseña");
                    menuUsuarioSelected = Console.ReadLine();

                }

                MenuUser menuUserSelected = Enum.Parse<MenuUser>(menuUsuarioSelected);

                switch(menuUserSelected)
                {
                    case MenuUser.ReservarPuesto:
                        Console.WriteLine("Opción: Reservar puesto");
                    break;
                    case MenuUser.CancelarReserva:
                        Console.WriteLine("Opción: Cancelar reserva");
                    break;
                    case MenuUser.HistorialReservas:
                        Console.WriteLine("Opción: Ver historial de reservas");
                    break;
                    case MenuUser.CambiarPassword:
                        Console.WriteLine("Opción: Cambiar contraseña");
                    break;
                }
                
            }
        }
    
        
    }
}
