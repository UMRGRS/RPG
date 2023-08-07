using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG
{
    //Está clase son solo menus, cada uno de ellos se comunica con todas las demas clases para ejecutar las funciones necesarias
    internal class Menus
    {
        private readonly Utility utility = new Utility();
        private Jugador player1;
        private List<Enemigos> inCombatEnemies;
        public void StartGame() 
        {
            int opc = 2;
            player1 = new Jugador(10, 2, 0.5f, 12);
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
        private void MainMenu()
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
                    CombatMenu();
                    break;
                case 2:
                    Console.Clear();
                    InventoryMeu();
                    break;
                case 3:
                    Console.Clear();
                    CraftingMenu();
                    break;
                case 4:
                    Console.Clear();
                    EquipmentAndStatsMenu();
                    break;
                case 5:
                    Console.Clear();
                    Dungeon();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Ocurrio un error intenta de nuevo");
                    MainMenu();
                    break;
            }
        }
        private void CombatMenu() 
        {
            if (inCombatEnemies.Count() == 0)
            {
                Console.Clear();
                VictoryMenu();
                MainMenu();
            }
            Console.Clear();
            Console.WriteLine($"Te encuentras con {inCombatEnemies.Count()} slimes");
            Console.WriteLine($"Tu vida: {player1.VidaActual}");
            Console.WriteLine("1. Atacar");
            Console.WriteLine("2. Items");
            Console.WriteLine("3. Bloquear");
            Console.WriteLine("4. Huir");
            int opc = utility.CheckValidOption(1, 4);
            switch (opc)
            {
                case 1:
                    //Desplegar una lista con los enemigos en el campo y dejar al jugador seleccionar a cual atacar
                    Console.WriteLine("Selecciona a quien atacar");
                    for (int i = 0; i < inCombatEnemies.Count(); i++) 
                    {
                        Console.WriteLine($"{i + 1}. {inCombatEnemies[i].Nombre}, Vida {inCombatEnemies[i].Vida}");
                    }
                    Console.WriteLine($"{inCombatEnemies.Count() + 1}. Regresar");
                    int opc1 = utility.CheckValidOption(1, inCombatEnemies.Count() + 1);
                    if (opc1 == inCombatEnemies.Count() + 1)
                    {
                        Console.Clear();
                        CombatMenu();
                    }
                    else
                    {
                        inCombatEnemies[opc - 1].RecibirDano(2);
                        CheckIfAlive(inCombatEnemies[opc - 1]);
                        CombatMenu();
                    }
                    break;
                case 2:
                    //Desplegar menu con todas las pociones que el jugador tiene en su inventario, slimes no atacaran si consumes un item
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
        private void InventoryMeu() 
        { 
            //Recuperar la informacion de la clase inventario y desplegarla aqui
        }
        private void CraftingMenu() 
        { 
            //Desplegar menu para crear objetos
        }
        private void EquipmentAndStatsMenu() 
        { 
            //Despliega los objetos equipados y las stats del jugador
        }
        private void Dungeon() 
        { 
            //Inicia la mazmorra
        }
        private void CheckIfAlive(Enemigos enemyToCheck) 
        {
            if (enemyToCheck.Vida <= 0) 
            {
                inCombatEnemies.Remove(enemyToCheck);
            }
        }
        private void VictoryMenu() 
        {
            Console.WriteLine("Derrotaste a todos los enemigos!");
        }
    }
}
