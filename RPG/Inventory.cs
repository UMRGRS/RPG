using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace RPG
{
    public class Potions 
    {
        string name;
        List<Components> components = new List<Components>();

        public string Name { get => name; set => name = value; }
        public List<Components> Components { get => components; set => components = value; }
        public Potions(string name, List<Components> components) 
        {
            this.name = name;
            this.components = components;
        }
    }
    public class Upgrades 
    {
        string name;
        List<Components> components = new List<Components>();
        int statQuantity;
        int element;
        int tier;

        public string Name { get => name; set => name = value; }
        public List<Components> Components { get => components; set => components = value; }
        public int StatQuantity { get => statQuantity; set => statQuantity = value; }
        public int Element { get => element; set => element = value; }
        public int Tier { get => tier; set => tier = value; }

        public Upgrades(string name, List<Components> components, int statQuantity, int element, int tier) 
        {
            this.name = name;
            this.statQuantity = statQuantity;
            this.element = element;
            this.tier = tier;
            this.components = components;
        }
    }
    public class Components 
    {
        string component;
        int quantity;

        public string Component { get => component; set => component = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public Components(string component, int quantity) 
        {
            this.component = component;
            this.quantity = quantity;
        }
    }
    internal class Inventory
    {
        private Dictionary<string, int> playerInventory = new Dictionary<string, int>();

        //Slimes jams
        private List<string> aquaJams = new List<string>() { "Aqua Jam (Hydro I)", "Anfi Jam (Hydro II)", "Nepht Jam (Hydro III)" };
        private List<string> pyroJams = new List<string>() { "Igna Jam (Pyro I)", "Hesta Jam (Pyro II)", "Hephe Jam (Pyro III)" };
        private List<string> dendroJams = new List<string>() { "Natura Jam (Dendro I)", "Ninphe Jam (Dendro II)", "Demetra Jam (Dendro III)" };

        //Potions,etc.
        private List<Potions> consumables = new List<Potions>();

        //Upgrades
        private List<Upgrades> swordUpgrades = new List<Upgrades>();
        private List<Upgrades> bowUpgrades = new List<Upgrades>();
        private List<Upgrades> armorUpgrades = new List<Upgrades>();
        private List<Upgrades> shieldUpgrades = new List<Upgrades>();
        public Dictionary<string, int> PlayerInventory { get => playerInventory; set => playerInventory = value; }
        public List<string> AquaJams { get => aquaJams; set => aquaJams = value; }
        public List<string> PyroJams { get => pyroJams; set => pyroJams = value; }
        public List<string> DendroJams { get => dendroJams; set => dendroJams = value; }
        public List<Upgrades> SwordUpgrades { get => swordUpgrades; set => swordUpgrades = value; }
        public List<Upgrades> BowUpgrades { get => bowUpgrades; set => bowUpgrades = value; }
        public List<Upgrades> ArmorUpgrades { get => armorUpgrades; set => armorUpgrades = value; }
        public List<Upgrades> ShieldUpgrades { get => shieldUpgrades; set => shieldUpgrades = value; }
        public List<Potions> Consumables { get => consumables; set => consumables = value; }

        public Inventory() 
        {
            CreateInventory();
            CreatePotions();
            CreateUpgrades();
        }
        private void CreateInventory() 
        {
            playerInventory.Add("Athena Potion (Poción de daño)", 2); //Pocion de daño
            playerInventory.Add("Sephe Potion (Poción de vida)", 2); //Pocion de vida

            playerInventory.Add("Aqua Jam (Hydro I)", 2); //Agua 1
            playerInventory.Add("Anfi Jam (Hydro II)", 0); //2
            playerInventory.Add("Nepht Jam (Hydro III)", 0); //3

            playerInventory.Add("Igna Jam (Pyro I)", 2); //Fuego 1
            playerInventory.Add("Hesta Jam (Pyro II)", 0); //2
            playerInventory.Add("Hephe Jam (Pyro III)", 0); //3

            playerInventory.Add("Natura Jam (Dendro I)", 2); //Naturaleza 1
            playerInventory.Add("Ninphe Jam (Dendro II)", 0); //2
            playerInventory.Add("Demetra Jam (Dendro III)", 0); //3
            
        }
        private void CreatePotions() 
        {
             consumables.Add(new Potions("Athena Potion (Poción de daño)", new List<Components> { new Components("Aqua Jam (Hydro I)", 1), new Components("Igna Jam (Pyro I)", 1) }));
            consumables.Add(new Potions("Sephe Potion (Poción de vida)", new List<Components> { new Components("Aqua Jam (Hydro I)", 1), new Components("Natura Jam (Dendro I)", 1) }));
        }
        private void CreateUpgrades() 
        {
            //Sword
            swordUpgrades.Add(new Upgrades("Espada hydro I", new List<Components> { new Components("Aqua Jam (Hydro I)", 5) }, 5, 1, 2));
            swordUpgrades.Add(new Upgrades("Espada pyro I", new List<Components> { new Components("Igna Jam (Pyro I)", 5) }, 5, 2, 2));
            swordUpgrades.Add(new Upgrades("Espada dendro I", new List<Components> { new Components("Natura Jam (Dendro I)", 5) }, 5, 3, 2));

            swordUpgrades.Add(new Upgrades("Espada hydro II", new List<Components> { new Components("Anfi Jam (Hydro II)", 5) }, 5, 1, 3));
            swordUpgrades.Add(new Upgrades("Espada pyro II", new List<Components> { new Components("Hesta Jam (Pyro II)", 5) }, 5, 2, 3));
            swordUpgrades.Add(new Upgrades("Espada dendro II", new List<Components> { new Components("Ninphe Jam (Dendro II)", 5) }, 5, 3, 3));

            swordUpgrades.Add(new Upgrades("Espada hydro III", new List<Components> { new Components("Nepht Jam (Hydro III)", 5) }, 5, 1, 4));
            swordUpgrades.Add(new Upgrades("Espada pyro III", new List<Components> { new Components("Hephe Jam (Pyro III)", 5) }, 5, 2, 4));
            swordUpgrades.Add(new Upgrades("Espada dendro III", new List<Components> { new Components("Demetra Jam (Dendro III)", 5) }, 5, 3, 4));

            //Bow
            bowUpgrades.Add(new Upgrades("Arco hydro I", new List<Components> { new Components("Aqua Jam (Hydro I)", 5) }, 5, 1, 2));
            bowUpgrades.Add(new Upgrades("Arco pyro I", new List<Components> { new Components("Igna Jam (Pyro I)", 5) }, 5, 2, 2));
            bowUpgrades.Add(new Upgrades("Arco dendro I", new List<Components> { new Components("Natura Jam (Dendro I)", 5) }, 5, 3, 2));

            bowUpgrades.Add(new Upgrades("Arco hydro II", new List<Components> { new Components("Anfi Jam (Hydro II)", 5) }, 5, 1, 3));
            bowUpgrades.Add(new Upgrades("Arco pyro II", new List<Components> { new Components("Hesta Jam (Pyro II)", 5) }, 5, 2, 3));
            bowUpgrades.Add(new Upgrades("Arco dendro II", new List<Components> { new Components("Ninphe Jam (Dendro II)", 5) }, 5, 3, 3));

            bowUpgrades.Add(new Upgrades("Arco hydro III", new List<Components> { new Components("Nepht Jam (Hydro III)", 5) }, 5, 1, 4));
            bowUpgrades.Add(new Upgrades("Arco pyro III", new List<Components> { new Components("Hephe Jam (Pyro III)", 5) }, 5, 2, 4));
            bowUpgrades.Add(new Upgrades("Arco dendro III", new List<Components> { new Components("Demetra Jam (Dendro III)", 5) }, 5, 3, 4));

            //Armor
            armorUpgrades.Add(new Upgrades("Armadura hydro I", new List<Components> { new Components("Aqua Jam (Hydro I)", 5) }, 5, 1, 2));
            armorUpgrades.Add(new Upgrades("Armadura pyro I", new List<Components> { new Components("Igna Jam (Pyro I)", 5) }, 5, 2, 2));
            armorUpgrades.Add(new Upgrades("Armadura dendro I", new List<Components> { new Components("Natura Jam (Dendro I)", 5) }, 5, 3, 2));

            armorUpgrades.Add(new Upgrades("Armadura hydro II", new List<Components> { new Components("Anfi Jam (Hydro II)", 5) }, 5, 1, 3));
            armorUpgrades.Add(new Upgrades("Armadura pyro II", new List<Components> { new Components("Hesta Jam (Pyro II)", 5) }, 5, 2, 3));
            armorUpgrades.Add(new Upgrades("Armadura dendro II", new List<Components> { new Components("Ninphe Jam (Dendro II)", 5) }, 5, 3, 3));

            armorUpgrades.Add(new Upgrades("Armadura hydro III", new List<Components> { new Components("Nepht Jam (Hydro III)", 5) }, 5, 1, 4));
            armorUpgrades.Add(new Upgrades("Armadura pyro III", new List<Components> { new Components("Hephe Jam (Pyro III)", 5) }, 5, 2, 4));
            armorUpgrades.Add(new Upgrades("Armadura dendro III", new List<Components> { new Components("Demetra Jam (Dendro III)", 5) }, 5, 3, 4));

            //Shield
            shieldUpgrades.Add(new Upgrades("Escudo hydro I", new List<Components> { new Components("Aqua Jam (Hydro I)", 5) }, 5, 1, 2));
            shieldUpgrades.Add(new Upgrades("Escudo pyro I", new List<Components> { new Components("Igna Jam (Pyro I)", 5) }, 5, 2, 2));
            shieldUpgrades.Add(new Upgrades("Escudo dendro I", new List<Components> { new Components("Natura Jam (Dendro I)", 5) }, 5, 3, 2));

            shieldUpgrades.Add(new Upgrades("Escudo hydro II", new List<Components> { new Components("Anfi Jam (Hydro II)", 5) }, 5, 1, 3));
            shieldUpgrades.Add(new Upgrades("Escudo pyro II", new List<Components> { new Components("Hesta Jam (Pyro II)", 5) }, 5, 2, 3));
            shieldUpgrades.Add(new Upgrades("Escudo dendro II", new List<Components> { new Components("Ninphe Jam (Dendro II)", 5) }, 5, 3, 3));

            shieldUpgrades.Add(new Upgrades("Escudo hydro III", new List<Components> { new Components("Nepht Jam (Hydro III)", 5) }, 5, 1, 4));
            shieldUpgrades.Add(new Upgrades("Escudo pyro III", new List<Components> { new Components("Hephe Jam (Pyro III)", 5) }, 5, 2, 4));
            shieldUpgrades.Add(new Upgrades("Escudo dendro III", new List<Components> { new Components("Demetra Jam (Dendro III)", 5) }, 5, 3, 4));
        }
    }
}
