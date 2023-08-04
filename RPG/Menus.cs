using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Menus
    {
        private readonly Utility utility = new Utility();
        public void StartGame() 
        {
            int opc = 2;
            //Crear el objeto del jugador
            while (opc == 2) 
            {
                Console.WriteLine("Introduce el nombre de tu personaje");
                //Sustituir por jugador.nombre = Console.ReadLine();
                string uwu = Console.ReadLine(); 
                Console.Clear();
                Console.WriteLine($"¿Seguro de que quieres usar {uwu} como nombre?");
                Console.WriteLine("1. Si 2. No");
                opc = utility.CheckValidOption(1, 2);
                Console.Clear();
            }
            MainMenu();
        }
        public void MainMenu()
        {
            Console.WriteLine("Seleciona una opcion");
            Console.WriteLine("1. Cazar");
            Console.WriteLine("2. Inventario");
            Console.WriteLine("3. Creacion");
            Console.WriteLine("4. Equipo");
            Console.WriteLine("5. Mazmorra");
            int opc = utility.CheckValidOption(1, 5);
            switch (opc) 
            {
                case 1:
                    //Iniciar una batalla
                    break;
                case 2:
                    //Abrir el inventario
                    break;
                case 3:
                    //Abrir el menu de creacion de objetos
                    break;
                case 4:
                    //Abrir el menu de equipo
                    break;
                case 5:
                    //Iniciar una mazmorra
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Ocurrio un error intenta de nuevo");
                    MainMenu();
                    break;
            }
        }
        public void CombatMenu() 
        {
            Console.WriteLine("Te encuentras con x slimes");
            Console.WriteLine("1. Atacar");
            Console.WriteLine("2. Items");
            Console.WriteLine("3. Bloquear");
            Console.WriteLine("4. Huir");
            int opc = utility.CheckValidOption(1, 4);
            switch (opc)
            {
                case 1:
                    //Ataca a un slime
                    break;
                case 2:
                    //Consumir items
                    break;
                case 3:
                    //Cambiar a modo defensivo
                    break;
                case 4:
                    //Escapa de la batalla
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Ocurrio un error intenta de nuevo");
                    CombatMenu();
                    break;
            }
        }
        public void InventoryMeu() 
        { 
            //Recuperar la informacion de la clase inventario y desplegarla aqui
        }
        public void CraftingMenu() 
        { 
            //Desplegar menu para crear objetos
        }
        public void EquipmentMenu() 
        { 
            //Despliega los objetos equipados
        }
        public void Dungeon() 
        { 
            //Inicia la mazmorra
        }
    }
}
