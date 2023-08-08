using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    internal class Utility
    {
        private readonly Random ran = new Random();
        private readonly Inventory inventory = new Inventory();
        
        private readonly List<string> aquaNames = new List<string> {"Sere", "Tito", "Nide" };
        private readonly List<string> ignaNames = new List<string> {"Fefe", "Sasa", "Dracus" };
        private readonly List<string> naturaNames = new List<string> {"Nomi", "Goby", "Drida" };

        private readonly Dictionary<int, int> advantage = new Dictionary<int, int>() { { 1, 2 }, { 2, 3 }, { 3, 1 } };
        private readonly Dictionary<int, int> disadvantage = new Dictionary<int, int>() { { 3, 2 }, { 2, 1 }, { 1, 3 } };

        //Checador universal para opciones numericas
        //Argumento 1 = primer opcion
        //Argumento 2 = ultima opcion
        public int CheckValidOption(int firstOption, int lastOption) 
        {
            int opt = 0;
            for(int i = 0; i < 1; i++) 
            {
                try
                {
                    opt = int.Parse(Console.ReadLine());
                }
                catch
                {

                    Console.WriteLine("Opcion invalida, seleciona otra");
                    i--;
                }
            }
            if(opt < firstOption || opt > lastOption) 
            {
                Console.WriteLine("Opcion invalida, seleciona otra");
                CheckValidOption(firstOption, lastOption);
            }
            return opt;
        }
        //Selector de nombres aleatorioss por elemento
         public string SelecNombres(int elemento) 
         {
            int random = ran.Next(1, 3);
            string nomRegresar;

            if (elemento == 1)
            {
                nomRegresar = aquaNames[random] + " hydro slime";
            }
            else if (elemento == 2)
            {
                nomRegresar = ignaNames[random] + " pyro slime";
            }
            else
            {
                nomRegresar = naturaNames[random] + " dendro slime";
            }
            return nomRegresar;
         }
        //Calculadora de daño
        public float CalculateDamage(float atackerDamage,int atackerElement, int targetElement, float TargetArmor)
        {  
            float damage = atackerDamage - TargetArmor;
            if (advantage.ContainsKey(atackerElement) && advantage[atackerElement] == targetElement)
            {
                damage += 2;
            }
            else if (disadvantage.ContainsKey(atackerElement) && disadvantage[atackerElement] == targetElement)
            {
                damage -= 2;
            }
            else if(targetElement == atackerElement)
            {
                damage *= 0.1f;
            }
            if (damage < 0) 
            {
                return 0;
            }
            return damage;
        }
        //Determinador de botin
        public string LootToReceive(int tierEnemigo, int elemento) 
        {
            string loot = " ";
            int selectedItem = ran.Next(1, tierEnemigo + 1);
            switch (elemento) 
            {
                case 1:
                    loot = inventory.AquaJams[selectedItem - 1];
                    break;
                case 2:
                    loot = inventory.PyroJams[selectedItem - 1];
                    break;
                case 3:
                    loot = inventory.DendroJams[selectedItem - 1];
                    break;
            }
            return loot;
        }
    }
}
