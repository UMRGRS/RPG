using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;

namespace RPG
{
    internal class Menus:Utility
    {
        //Utility
        private readonly Random ran = new Random();

        //Objects
        private Jugador player1;
        private Inventory playerInventory = new Inventory();

        //Variables
        private List<Enemigos> inCombatEnemies;
        
        //Elements
        private readonly Dictionary<int, string> elements = new Dictionary<int, string>() { { 0, "Sin elemento" }, { 1, "Hydro" }, { 2, "Pyro" }, { 3, "Dendro" } };

        /// <summary>
        /// Menus
        /// </summary>
        //Call this method to start the game :b
        public void StartGame() 
        {
            int opc = 2;
            player1 = new Jugador(1000, 4, 2, 1.5f, 0.5f, 12);
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
                    CraftingAndEnhancingMenu();
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
        //Inicia un combate y muestra las opciones disponibles
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
                    float damage = CalculateDamage(inCombatEnemies[atackingEnemy - 1].BaseDamage, inCombatEnemies[atackingEnemy - 1].Elemento, player1.Shield.Element, player1.Shield.Defense);
                    player1.RecibirDano(damage);
                    Console.WriteLine($"Te proteges con tu escudo recibes {damage} puntos de daño");
                    Console.WriteLine("Presiona cualquier tecla para continuar");
                    Console.ReadKey();
                    break;
                case 4:
                    //Mejorar si hay tiempo a un sistema de probabilidad de escape
                    Console.Clear();
                    Console.WriteLine("Escapaste con exito");
                    Console.WriteLine(" ");
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
        private void CraftingAndEnhancingMenu() 
        {
            //Desplegar menu para crear objetos
            Console.Clear();
            Console.WriteLine("Selecciona una opcion");
            Console.WriteLine("1. Crear pociones");
            Console.WriteLine("2. Mejorar equipamiento");
            Console.WriteLine("3. Regresar");
            int opc = CheckValidOption(1, 3);
            switch (opc) 
            {
                case 1:
                    CreatePotions();
                    break;
                case 2:
                    EnhanceEquipment();
                    break;
                case 3:
                    MainMenu();
                    break;
            }
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
            Console.Clear();
            Console.WriteLine("Derrotaste a todos los enemigos!");
            Console.WriteLine("Presiona cualquier tecla para continuar");
            Console.ReadKey();
            player1.ResetStats();
            MainMenu();
        }
        private void DefeatMenu() 
        {
            Console.Clear();
            int xpLost = ran.Next(1, 11);
            player1.Derrota(xpLost);
            Console.WriteLine("Moriste :)");
            Console.WriteLine($"Perdiste {xpLost} puntos de experiencia");
            Console.WriteLine("Presiona cualquier tecla para continuar");
            Console.ReadKey();
            MainMenu();
        }
        //Menu de creacion de pociones
        private void CreatePotions() 
        {
            Console.Clear();
            Console.WriteLine("¿Que poción deseas crear?");
            foreach (Potions potion in playerInventory.Consumables) 
            {
                Console.WriteLine($"{playerInventory.Consumables.IndexOf(potion) + 1}. {potion.Name}");
                Console.WriteLine("Necesitas:");
                ShowComponents(potion.Components);
            }
            Console.WriteLine("3. Regresar");
            int potionToCreate = CheckValidOption(1, 3);
            if (potionToCreate == 3)
            {
                MainMenu();
                return;
            }
            else 
            {
                if (CheckMaterials(playerInventory.Consumables[potionToCreate - 1].Components))
                {
                    playerInventory.PlayerInventory[playerInventory.Consumables[potionToCreate - 1].Name] += 1;
                    Console.WriteLine($"Creaste {playerInventory.Consumables[potionToCreate - 1].Name} x 1");
                    Console.WriteLine("Presiona cualquier tecla para continuar");
                    Console.ReadKey();
                    CreatePotions();
                }
                else 
                {
                    Console.WriteLine("No tienes los materiales para crear esa poción prueba con otra o recolecta mas materiales");
                    Console.WriteLine("Presiona cualquier tecla para continuar");
                    Console.ReadKey();
                    CreatePotions();
                }
            }
        }
        //Menu de mejora de equipo
        private void EnhanceEquipment()
        {
            Console.Clear();
            Console.WriteLine("Selecciona el equipo que quieres mejorar");
            Console.WriteLine("1. Espada");
            Console.WriteLine("2. Arco");
            Console.WriteLine("3. Armadura");
            Console.WriteLine("4. Escudo");
            Console.WriteLine("5. Regresar");
            int opc = CheckValidOption(1, 5);
            switch (opc) 
            {
                case 1:
                    ShowUpgrades(playerInventory.HydroSwordUpgrades, playerInventory.PyroSwordUpgrades, playerInventory.DendroSwordUpgrades, player1.Sword.Tier, player1.Sword.WeaponElement, player1.Sword);
                    break;
                case 2:
                    ShowUpgrades(playerInventory.HydroBowUpgrades, playerInventory.PyroBowUpgrades, playerInventory.DendroBowUpgrades, player1.Bow.Tier, player1.Bow.WeaponElement, player1.Bow);
                    break;
                case 3:
                    ShowUpgrades(playerInventory.HydroArmorUpgrades, playerInventory.PyroArmorUpgrades, playerInventory.DendroArmorUpgrades, player1.FullArmor.Tier, player1.FullArmor.Element, new Weapon(0),player1.FullArmor);
                    break;
                case 4:
                    ShowUpgrades(playerInventory.HydroShieldUpgrades, playerInventory.PyroShieldUpgrades, playerInventory.DendroShieldUpgrades, player1.Shield.Tier, player1.Shield.Element, new Weapon(0), player1.Shield);
                    break;
                case 5:
                    CraftingAndEnhancingMenu();
                    return;
            }
        }
        /// <summary>
        /// Crafting system methods
        /// </summary>
        //Shows the upgrades depending on the element of the equipment
        private void ShowUpgrades(List<Upgrades> hydroUpgrades, List<Upgrades> pyroUpgrades, List<Upgrades> dendroUpgrades, int tier, int element, [Optional] Weapon weaponToUpgrade, [Optional] DefensiveItem defensiveItemToUpgrade) 
        {
            Console.Clear();
            int upgradeSelected;
            if (weaponToUpgrade!= null && weaponToUpgrade.Tier == 4 || defensiveItemToUpgrade != null && defensiveItemToUpgrade.Tier == 4) 
            {
                Console.WriteLine("Ya tienes todas las mejoras");
                Console.WriteLine("Presiona cualquier tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                EnhanceEquipment();
                return;
            }
            Console.WriteLine("Mejoras disponibles");
            if (element == 0)
            {
                Console.WriteLine($"1. {hydroUpgrades[tier - 1].Name} Necesitas:");
                ShowComponents(hydroUpgrades[tier - 1].Components);
                Console.WriteLine($"2. {pyroUpgrades[tier - 1].Name} Necesitas:");
                ShowComponents(pyroUpgrades[tier - 1].Components);
                Console.WriteLine($"3. {dendroUpgrades[tier - 1].Name} Necesitas:");
                ShowComponents(dendroUpgrades[tier - 1].Components);
                Console.WriteLine("4. Regresar");
                upgradeSelected = CheckValidOption(1, 4);
                if (upgradeSelected == 4)
                {
                    EnhanceEquipment();
                    return;
                }
                switch (upgradeSelected)
                {
                    case 1:
                        UpgradeStats(hydroUpgrades[tier - 1], weaponToUpgrade, defensiveItemToUpgrade);
                        break;
                    case 2:
                        UpgradeStats(pyroUpgrades[tier - 1], weaponToUpgrade, defensiveItemToUpgrade);
                        break;
                    case 3:
                        UpgradeStats(dendroUpgrades[tier - 1], weaponToUpgrade, defensiveItemToUpgrade);
                        break;
                }
                EnhanceEquipment();
                return;
            }
            Upgrades upgradeToMake = null;
            switch (element)
            {
                case 1:
                    Console.WriteLine($"1. {hydroUpgrades[tier - 1].Name} Necesitas:");
                    upgradeToMake = hydroUpgrades[tier - 1];
                    ShowComponents(hydroUpgrades[tier - 1].Components);
                    break;
                case 2:
                    Console.WriteLine($"1. {pyroUpgrades[tier - 1].Name} Necesitas:");
                    upgradeToMake = pyroUpgrades[tier - 1];
                    ShowComponents(pyroUpgrades[tier - 1].Components);
                    break;
                case 3:
                    Console.WriteLine($"1. {dendroUpgrades[tier - 1].Name} Necesitas:");
                    upgradeToMake = dendroUpgrades[tier - 1];
                    ShowComponents(dendroUpgrades[tier - 1].Components);
                    break;
            }
            Console.WriteLine("2. Regresar");
            upgradeSelected = CheckValidOption(1, 2);
            if (upgradeSelected == 2)
            {
                EnhanceEquipment();
                return;
            }
            else 
            {
                UpgradeStats(upgradeToMake, weaponToUpgrade, defensiveItemToUpgrade);
                EnhanceEquipment();
            }
        }
        private void UpgradeStats(Upgrades upgrade, Weapon weaponToUpgrade, DefensiveItem defensiveItemToUpgrade)
        {
            Console.Clear();
            if (CheckMaterials(upgrade.Components))
            {
                Console.WriteLine($"Creaste {upgrade.Name}");
                Console.WriteLine($"Daño/defensa + {upgrade.StatQuantity} Elemento: {elements[upgrade.Element]}");

                if (weaponToUpgrade != null)
                {
                    weaponToUpgrade.AddStats(upgrade.StatQuantity, upgrade.Element, upgrade.Tier);
                }
                else 
                {
                    defensiveItemToUpgrade.AddStats(upgrade.StatQuantity, upgrade.Element, upgrade.Tier);
                }
                Console.WriteLine("Presiona cualquier tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("No tienes los materiales para mejorar prueba con otra mejora o recolecta mas materiales");
                Console.WriteLine("Presiona cualquier tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //Muestra todos los componentes necesarios para crear un objeto
        private void ShowComponents(List<Components> components) 
        { 
            components.ForEach(delegate (Components comp) { Console.WriteLine($"{comp.Component} x {comp.Quantity} Tienes: {playerInventory.PlayerInventory[comp.Component]}"); });
            Console.WriteLine(" ");
        }
        //Revisa en tu inventario si tienes lo materiales necesarios para crear un objeto
        private bool CheckMaterials(List<Components> components) 
        {
            foreach (Components comp in components) 
            {
                if (playerInventory.PlayerInventory[comp.Component] < comp.Quantity)
                {
                    return false;
                }
            }
            foreach (Components comp in components) 
            {
                playerInventory.PlayerInventory[comp.Component] -= comp.Quantity;
            }
            return true;
        }
        /// <summary>
        /// Combat system methods
        /// </summary>
        public void Fight(int atackingEnemy) 
        {
            //Desplegar una lista con los enemigos en el campo y dejar al jugador seleccionar a cual atacar
            Console.WriteLine(" ");
            Console.WriteLine("Selecciona a quien atacar");
            for (int i = 0; i < inCombatEnemies.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {inCombatEnemies[i].Nombre}, Vida {inCombatEnemies[i].Health}");
            }
            int enemyToAtack = CheckValidOption(1, inCombatEnemies.Count());

            //Selecionas el arma que vas a usar para atacar
            Console.WriteLine(" ");
            Console.WriteLine("Selecciona el arma que usaras");
            Console.WriteLine($"1. Espada daño: {player1.Sword.WeaponDamage} + Bonus de daño {player1.DamageModifier} Elemento: {elements[player1.Sword.WeaponElement]}");
            Console.WriteLine($"2. Arco daño: {player1.Bow.WeaponDamage} + Bonus de daño {player1.DamageModifier} Elemento: {elements[player1.Bow.WeaponElement]} (Probabilidad de evadir todo el daño)");
            int weapon = CheckValidOption(1, 2);
            switch (weapon)
            {
                case 1:
                    player1.RecibirDano(CalculateDamage(inCombatEnemies[atackingEnemy - 1].BaseDamage, inCombatEnemies[atackingEnemy - 1].Elemento, player1.FullArmor.Element, player1.FullArmor.Defense));
                    AtackEnemy(enemyToAtack, player1.Sword.WeaponDamage, player1.Sword.WeaponElement);
                    break;
                case 2:
                    //Generas un numero aleatorio, si es menor a 4 no recibes daño
                    int damageOrNot = ran.Next(1, 11);
                    if (damageOrNot < 4)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Esquivaste los ataques enemigos");
                    }
                    else
                    {
                        player1.RecibirDano(CalculateDamage(inCombatEnemies[atackingEnemy - 1].BaseDamage, inCombatEnemies[atackingEnemy - 1].Elemento, player1.FullArmor.Element, player1.FullArmor.Defense));
                    }
                    AtackEnemy(enemyToAtack, player1.Bow.WeaponDamage, player1.Bow.WeaponElement);
                    break;
            }
        }
        //Ataca a un enemigo y revisa si permanece vivo
        private void AtackEnemy(int enemyToAtack, float damage, int atackerElement)
        {
            float damageDealt = CalculateDamage(damage, atackerElement, inCombatEnemies[enemyToAtack - 1].Elemento, inCombatEnemies[enemyToAtack - 1].Armor, player1.DamageModifier);
            inCombatEnemies[enemyToAtack - 1].RecibirDano(damageDealt);
            CheckIfAlive(inCombatEnemies[enemyToAtack - 1]);
        }
        //Revsita si un enemigo sigue vivo, sino entrega todas las recompensas
        private void CheckIfAlive(Enemigos enemyToCheck)
        {
            if (enemyToCheck.Health <= 0)
            {
                Console.WriteLine(" ");
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
        //Abre el inventario de pociones en combate
        private void CombatInventory() 
        {
            Console.WriteLine("Inventario");
            for (int i = 0; i < playerInventory.Consumables.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {playerInventory.Consumables[i].Name} Cantidad: {playerInventory.PlayerInventory[playerInventory.Consumables[i].Name]}");
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
        //Consume una pocion y ativa sus efectos
        private bool ConsumePotion(int potionToConsume) 
        {
            if (playerInventory.PlayerInventory[playerInventory.Consumables[potionToConsume - 1].Name] > 0)
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
                playerInventory.PlayerInventory[playerInventory.Consumables[potionToConsume - 1].Name] -= 1;
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}
