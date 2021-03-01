using System;
using CoWorkingApp.App.Enumerations;
using CoworkingApp.Data;
using CoWorkingApp.Models;
using CoWorkingApp.Data.Tools;
using CoWorkingApp.Models.Enumerations;

namespace CoWorkingApp.App.Logic
{
    public class DeskService
    {
        private DeskData deskData {get;set;}

        public DeskService(DeskData deskData){
            this.deskData = deskData;

        }

        public void ExecuteAction(AdminPuestos adminDeskAction)
        {
            switch (adminDeskAction)
                    {
                        case AdminPuestos.Crear:
                            Desk newDesk = new Desk();
                            Console.WriteLine("Ingrese código del puesto, Ejemplo: A-001");
                            newDesk.Code = Console.ReadLine();
                            Console.WriteLine("Ingrese descripción:");
                            newDesk.Description = Console.ReadLine();
                            deskData.CreateDesk(newDesk);
                            Console.WriteLine("Puesto creado con éxito!");

                        break;
                        case AdminPuestos.Editar:
                            Console.WriteLine("Ingrese puesto: ");
                            var deskFound = deskData.FindDesk(Console.ReadLine());
                            while(deskFound == null)
                            {
                                Console.WriteLine("Puesto no válido. Vuelva a ingresar puesto: ");
                                deskFound = deskData.FindDesk(Console.ReadLine());
                            }
                            Console.WriteLine("Ingrese código del puesto, Ejemplo: A-001");
                            deskFound.Code = Console.ReadLine();
                            Console.WriteLine("Ingrese descripción del puesto:");
                            deskFound.Description = Console.ReadLine();
                            Console.WriteLine("Ingrese estado del puesto, 1 = Activo, 2 = Inactivo, 3 = Bloquear :");
                            deskFound.DeskStatus = Enum.Parse<DeskStatus>(Console.ReadLine());
                            deskData.EditDesk(deskFound);
                            Console.WriteLine("Puesto editado con éxito!");

                        break;
                        case AdminPuestos.Eliminar:
                            Console.WriteLine("Ingrese puesto: ");
                            var deskDelete = deskData.FindDesk(Console.ReadLine());

                            while(deskDelete == null)
                            {
                                Console.WriteLine("Puesto no válido. Vuelva a ingresar puesto: ");
                                deskDelete = deskData.FindDesk(Console.ReadLine());
                            }

                            deskData.DeleteDesk(deskDelete.DeskId);

                            Console.WriteLine("Puesto eliminado con éxito!");

                        break;
                        case AdminPuestos.Bloquear:
                        
                            Console.WriteLine("Ingrese puesto: ");
                            var deskBlock = deskData.FindDesk(Console.ReadLine());

                            while(deskBlock == null)
                            {
                                Console.WriteLine("Puesto no válido. Vuelva a ingresar puesto: ");
                                deskBlock = deskData.FindDesk(Console.ReadLine());
                            }
                            deskBlock.DeskStatus = DeskStatus.Blocked;

                            deskData.EditDesk(deskBlock);

                            Console.WriteLine("Puesto bloqueado con éxito!");
                        break;
                    } 
        }

    }

}