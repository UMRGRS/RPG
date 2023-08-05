using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;

namespace RPG
{
    //Está clase son solo menus, cada uno de ellos se comunica con todas las demas clases para ejecutar las funciones necesarias
    internal class Menus
    {
        private readonly Utility utility = new Utility();
        private Jugador player1;
        private Enemigos[] inCombatEnemies;
        public void StartGame() 
        {
            int opc = 2;
            player1 = new Jugador(10, 2, 0.5f, 1);
            while (opc == 2) 
            {
                Console.WriteLine("Introduce el nombre de tu personaje");
                player1.Nombre = Console.ReadLine(); 
                Console.Clear();
                Console.WriteLine($"¿Seguro de que quieres usar {player1.Nombre} como nombre?");
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
                    Combat startCombat = new Combat();
                    inCombatEnemies = startCombat.SpawnEnemies(player1.LVL);
                    foreach (var enemy in inCombatEnemies) 
                    {
                        Console.WriteLine(enemy.Nombre);
                    }
                    CombatMenu();
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
            Console.Clear();
            Console.WriteLine($"Te encuentras con {inCombatEnemies.Length} slimes");
            Console.WriteLine("1. Atacar");
            Console.WriteLine("2. Items");
            Console.WriteLine("3. Bloquear");
            Console.WriteLine("4. Huir");
            int opc = utility.CheckValidOption(1, 4);
            switch (opc)
            {
                case 1:
                    //Desplegar una lista con los enemigos en el campo y dejar al jugador seleccionar a cual atacar
                    break;
                case 2:
                    //Desplegar menu con todas las pociones que el jugador tiene en su inventario, no slimes no atacaran si consumes un item
                    break;
                case 3:
                    //Activar el metodo calcular daño solo para el jugador usando la defensa de su escudo
                    break;
                case 4:
                    //Mejorar si hay tiempo a un sistema de probabilidad de escape
                    Console.Clear();
                    Console.WriteLine("Escapaste con exito");
                    MainMenu();
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
