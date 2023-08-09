﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG
{
    //Está clase son solo menus, cada uno de ellos se comunica con todas las demas clases para ejecutar las funciones necesarias
    internal class Menus:Utility
    {
        //Utility
        private readonly Random ran = new Random();

        //Objects
        private Jugador player1;
        private Inventory playerInventory = new Inventory();

        //Variables
        private List<Enemigos> inCombatEnemies;
        private readonly Dictionary<int, string> elements = new Dictionary<int, string>() { { 0, "Sin elemento" }, { 1, "Hydro" }, { 2, "Pyro" }, { 3, "Dendro" } };
        
        //Call this method to start the game :b
        public void StartGame() 
        {
            int opc = 2;
            player1 = new Jugador(10, 4, 2, 1.5f, 0.5f, 12);
            while (opc == 2) 
            {
                Console.WriteLine("Introduce el nombre de tu personaje");
                player1.Name = Console.ReadLine(); 
                Console.Clear();
                Console.WriteLine($"¿Seguro de que quieres usar {player1.Name} como nombre?");
                Console.WriteLine("1. Si 2. No");
                opc = CheckValidOption(1, 2);
                Console.Clear();
            }
            MainMenu();
        }
        private void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Seleciona una opcion");
            Console.WriteLine("1. Cazar");
            Console.WriteLine("2. Inventario");
            Console.WriteLine("3. Creacion");
            Console.WriteLine("4. Equipo");
            Console.WriteLine("5. Mazmorra");
            int opc = CheckValidOption(1, 5);
            switch (opc) 
            {
                case 1:
                    EnemySpawner startCombat = new EnemySpawner();
                    inCombatEnemies = startCombat.SpawnEnemies(player1.LVL);
                    CombatMenu();
                    break;
                case 2:
                    Console.Clear();
                    InventoryMenu();
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
            Console.Clear();
            int atackingEnemy = ran.Next(1, inCombatEnemies.Count() + 1);
            Console.WriteLine($"Te encuentras con {inCombatEnemies.Count()} slimes");
            Console.WriteLine($"El enemigo numero {atackingEnemy} ({elements[inCombatEnemies[atackingEnemy - 1].Elemento]}) se prepara para atacar");
            Console.WriteLine($"Tu vida: {player1.ActualHealth}");
            Console.WriteLine("1. Atacar");
            Console.WriteLine("2. Items");
            Console.WriteLine("3. Bloquear");
            Console.WriteLine("4. Huir");
            int opc = CheckValidOption(1, 4);
            switch (opc)
            {
                case 1:
                    Fight(atackingEnemy);
                    break;
                case 2:
                    //Abre el inventario de pociones y puedes seleccionar una para consumir
                    CombatInventory();
                    break;
                case 3:
                    //Activar el metodo calcular daño solo para el jugador usando la defensa de su escudo
                    float damage = CalculateDamage(inCombatEnemies[atackingEnemy - 1].BaseDamage, inCombatEnemies[atackingEnemy - 1].Elemento, player1.MyShield.ShieldElement, player1.MyShield.ShieldDefense);
                    player1.RecibirDano(damage);
                    Console.WriteLine($"Te proteges con tu escudo recibes {damage} puntos de daño");
                    Console.WriteLine("Presiona cualquier tecla para continuar");
                    Console.ReadKey();
                    break;
                case 4:
                    //Mejorar si hay tiempo a un sistema de probabilidad de escape
                    Console.Clear();
                    Console.WriteLine("Escapaste con exito");
                    MainMenu();
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Ocurrio un error intenta de nuevo");
                    CombatMenu();
                    return;
            }
            if (player1.ActualHealth <= 0) 
            {
                DefeatMenu();
            }
            //Si la lista de enemigos esta vacia terminas el combate
            else if (inCombatEnemies.Count() == 0)
            {
                Console.Clear();
                VictoryMenu();
                Console.ReadKey();
            }
            else 
            {
                CombatMenu();
            }
        }
        private void InventoryMenu() 
        { 
            //Recuperar la informacion de la clase inventario y desplegarla aqui
        }
        private void CraftingMenu() 
        { 
            //Desplegar menu para crear objetos
        }
        private void EquipmentAndStatsMenu() 
        { 
            //Despliega el daño/defensa de el equipo mas su elemento y las stats del jugador
        }
        private void Dungeon()
        { 
            //Inicia la mazmorra
        }
        private void VictoryMenu() 
        {
            Console.WriteLine("Derrotaste a todos los enemigos!");
            Console.WriteLine("Presiona cualquier tecla para continuar");
            Console.ReadKey();
            player1.ResetStats();
            MainMenu();
        }
        private void DefeatMenu() 
        {
            int xpLost = ran.Next(1, 11);
            player1.Derrota(xpLost);
            Console.WriteLine("Moriste :)");
            Console.WriteLine($"Perdiste {xpLost} puntos de experiencia");
            Console.WriteLine("Presiona cualquier tecla para continuar");
            Console.ReadKey();
            MainMenu();
        }
        //Combat system
        public void Fight(int atackingEnemy) 
        {
            //Desplegar una lista con los enemigos en el campo y dejar al jugador seleccionar a cual atacar
            Console.WriteLine("Selecciona a quien atacar");
            for (int i = 0; i < inCombatEnemies.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {inCombatEnemies[i].Nombre}, Vida {inCombatEnemies[i].Health}");
            }
            int enemyToAtack = CheckValidOption(1, inCombatEnemies.Count());

            //Selecionas el arma que vas a usar para atacar
            Console.WriteLine("Selecciona el arma que usaras");
            Console.WriteLine($"1. Espada daño: {player1.Sword.WeaponDamage} + Bonus de daño {player1.DamageModifier} Elemento: {elements[player1.Sword.WeaponElement]}");
            Console.WriteLine($"2. Arco daño: {player1.Bow.WeaponDamage} + Bonus de daño {player1.DamageModifier} Elemento: {elements[player1.Bow.WeaponElement]} (Probabilidad de evadir todo el daño)");
            int weapon = CheckValidOption(1, 2);
            switch (weapon)
            {
                case 1:
                    player1.RecibirDano(CalculateDamage(inCombatEnemies[atackingEnemy - 1].BaseDamage, inCombatEnemies[atackingEnemy - 1].Elemento, player1.ArmorElement, player1.ArmorElement));
                    AtackEnemy(enemyToAtack, player1.Sword.WeaponDamage);
                    break;
                case 2:
                    //Generas un numero aleatorio, si es menor a 4 no recibes daño
                    int damageOrNot = ran.Next(1, 11);
                    if (damageOrNot < 4)
                    {
                        Console.WriteLine("Esquivaste los ataques enemigos");
                        AtackEnemy(enemyToAtack, player1.Bow.WeaponDamage);
                    }
                    else
                    {
                        player1.RecibirDano(CalculateDamage(inCombatEnemies[atackingEnemy - 1].BaseDamage, inCombatEnemies[atackingEnemy - 1].Elemento, player1.ArmorElement, player1.Armor));
                        AtackEnemy(enemyToAtack, player1.Bow.WeaponDamage);
                    }
                    break;
            }
        }
        private void AtackEnemy(int enemyToAtack, float damage)
        {
            inCombatEnemies[enemyToAtack - 1].RecibirDano(CalculateDamage(damage, 0, inCombatEnemies[enemyToAtack - 1].Elemento, inCombatEnemies[enemyToAtack - 1].Armor, player1.DamageModifier));
            CheckIfAlive(inCombatEnemies[enemyToAtack - 1]);
        }
        private void CheckIfAlive(Enemigos enemyToCheck)
        {
            if (enemyToCheck.Health <= 0)
            {
                player1.AñadirXP(enemyToCheck.XP_drop);
                int itemQuantity = ran.Next(1, 4);
                Console.WriteLine($"Acabaste con {enemyToCheck.Nombre} recibes {enemyToCheck.XP_drop} puntos de experiencia y:");
                for (int i = 0; i <= itemQuantity; i++) 
                {
                    string loot = LootToReceive(enemyToCheck.Rango, enemyToCheck.Elemento);
                    playerInventory.PlayerInventory[loot] += 1;
                    Console.WriteLine(loot);
                }
                Console.WriteLine("Presiona cualquier tecla para continuar");
                Console.ReadKey();
                inCombatEnemies.Remove(enemyToCheck);
            }
        }
        private void CombatInventory() 
        {
            Console.WriteLine("Inventario");
            for (int i = 0; i < playerInventory.Consumables.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {playerInventory.Consumables[i]} Cantidad: {playerInventory.PlayerInventory[playerInventory.Consumables[i]]}");
            }
            Console.WriteLine($"{playerInventory.Consumables.Count() + 1}. Regresar");
            int potion = CheckValidOption(1, playerInventory.Consumables.Count() + 1);
            if (potion == playerInventory.Consumables.Count() + 1)
            {
                CombatMenu();
                return;
            }
            else if (!ConsumePotion(potion))
            {
                Console.WriteLine("No tienes suficientes pociones");
                CombatInventory();
            }
            Console.WriteLine("Presiona cualquier tecla para continuar");
            Console.ReadKey();
        }
        private bool ConsumePotion(int potionToConsume) 
        {
            if (playerInventory.PlayerInventory[playerInventory.Consumables[potionToConsume - 1]] > 0)
            {
                switch (potionToConsume) 
                {
                    case 1:
                        Console.WriteLine("Tu daño aumentó!");
                        player1.DamageModifier += 2;
                        break;
                    case 2:
                        Console.WriteLine("Curas tus heridas");
                        player1.ActualHealth += 2;
                        break;
                }
                playerInventory.PlayerInventory[playerInventory.Consumables[potionToConsume - 1]] -= 1;
                return true;
            }
            else 
            {
                return false;
            }
        }
       
    }
}
