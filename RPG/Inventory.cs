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
        private List<Upgrades> hydroSwordUpgrades = new List<Upgrades>();
        private List<Upgrades> pyroSwordUpgrades = new List<Upgrades>();
        private List<Upgrades> dendroSwordUpgrades = new List<Upgrades>();

        private List<Upgrades> hydroBowUpgrades = new List<Upgrades>();
        private List<Upgrades> pyroBowUpgrades = new List<Upgrades>();
        private List<Upgrades> dendroBowUpgrades = new List<Upgrades>();

        private List<Upgrades> hydroArmorUpgrades = new List<Upgrades>();
        private List<Upgrades> pyroArmorUpgrades = new List<Upgrades>();
        private List<Upgrades> dendroArmorUpgrades = new List<Upgrades>();

        private List<Upgrades> hydroShieldUpgrades = new List<Upgrades>();
        private List<Upgrades> pyroShieldUpgrades = new List<Upgrades>();
        private List<Upgrades> dendroShieldUpgrades = new List<Upgrades>();
        public Dictionary<string, int> PlayerInventory { get => playerInventory; set => playerInventory = value; }
        public List<string> AquaJams { get => aquaJams; set => aquaJams = value; }
        public List<string> PyroJams { get => pyroJams; set => pyroJams = value; }
        public List<string> DendroJams { get => dendroJams; set => dendroJams = value; }
        public List<Potions> Consumables { get => consumables; set => consumables = value; }
        public List<Upgrades> HydroSwordUpgrades { get => hydroSwordUpgrades; set => hydroSwordUpgrades = value; }
        public List<Upgrades> PyroSwordUpgrades { get => pyroSwordUpgrades; set => pyroSwordUpgrades = value; }
        public List<Upgrades> DendroSwordUpgrades { get => dendroSwordUpgrades; set => dendroSwordUpgrades = value; }
        public List<Upgrades> HydroBowUpgrades { get => hydroBowUpgrades; set => hydroBowUpgrades = value; }
        public List<Upgrades> PyroBowUpgrades { get => pyroBowUpgrades; set => pyroBowUpgrades = value; }
        public List<Upgrades> DendroBowUpgrades { get => dendroBowUpgrades; set => dendroBowUpgrades = value; }
        public List<Upgrades> HydroArmorUpgrades { get => hydroArmorUpgrades; set => hydroArmorUpgrades = value; }
        public List<Upgrades> PyroArmorUpgrades { get => pyroArmorUpgrades; set => pyroArmorUpgrades = value; }
        public List<Upgrades> DendroArmorUpgrades { get => dendroArmorUpgrades; set => dendroArmorUpgrades = value; }
        public List<Upgrades> HydroShieldUpgrades { get => hydroShieldUpgrades; set => hydroShieldUpgrades = value; }
        public List<Upgrades> PyroShieldUpgrades { get => pyroShieldUpgrades; set => pyroShieldUpgrades = value; }
        public List<Upgrades> DendroShieldUpgrades { get => dendroShieldUpgrades; set => dendroShieldUpgrades = value; }

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

            playerInventory.Add("Aqua Jam (Hydro I)", 5); //Agua 1
            playerInventory.Add("Anfi Jam (Hydro II)", 5); //2
            playerInventory.Add("Nepht Jam (Hydro III)", 5); //3

            playerInventory.Add("Igna Jam (Pyro I)", 5); //Fuego 1
            playerInventory.Add("Hesta Jam (Pyro II)", 5); //2
            playerInventory.Add("Hephe Jam (Pyro III)", 5); //3

            playerInventory.Add("Natura Jam (Dendro I)", 5); //Naturaleza 1
            playerInventory.Add("Ninphe Jam (Dendro II)", 5); //2
            playerInventory.Add("Demetra Jam (Dendro III)", 5); //3
            
        }
        private void CreatePotions() 
        {
            consumables.Add(new Potions("Athena Potion (Poción de daño)", new List<Components> { new Components("Aqua Jam (Hydro I)", 1), new Components("Igna Jam (Pyro I)", 1) }));
            consumables.Add(new Potions("Sephe Potion (Poción de vida)", new List<Components> { new Components("Aqua Jam (Hydro I)", 1), new Components("Natura Jam (Dendro I)", 1) }));
        }
        private void CreateUpgrades() 
        {
            //Sword
            hydroSwordUpgrades.Add(new Upgrades("Espada hydro I", new List<Components> { new Components("Aqua Jam (Hydro I)", 5) }, 5, 1, 2));
            hydroSwordUpgrades.Add(new Upgrades("Espada hydro II", new List<Components> { new Components("Anfi Jam (Hydro II)", 5) }, 5, 1, 3));
            hydroSwordUpgrades.Add(new Upgrades("Espada hydro III", new List<Components> { new Components("Nepht Jam (Hydro III)", 5) }, 5, 1, 4));

            pyroSwordUpgrades.Add(new Upgrades("Espada pyro I", new List<Components> { new Components("Igna Jam (Pyro I)", 5) }, 5, 2, 2));
            pyroSwordUpgrades.Add(new Upgrades("Espada pyro II", new List<Components> { new Components("Hesta Jam (Pyro II)", 5) }, 5, 2, 3));
            pyroSwordUpgrades.Add(new Upgrades("Espada pyro III", new List<Components> { new Components("Hephe Jam (Pyro III)", 5) }, 5, 2, 4));

            dendroSwordUpgrades.Add(new Upgrades("Espada dendro I", new List<Components> { new Components("Natura Jam (Dendro I)", 5) }, 5, 3, 2));
            dendroSwordUpgrades.Add(new Upgrades("Espada dendro II", new List<Components> { new Components("Ninphe Jam (Dendro II)", 5) }, 5, 3, 3));
            dendroSwordUpgrades.Add(new Upgrades("Espada dendro III", new List<Components> { new Components("Demetra Jam (Dendro III)", 5) }, 5, 3, 4));

            //Bow
            hydroBowUpgrades.Add(new Upgrades("Arco hydro I", new List<Components> { new Components("Aqua Jam (Hydro I)", 5) }, 5, 1, 2));
            hydroBowUpgrades.Add(new Upgrades("Arco hydro II", new List<Components> { new Components("Anfi Jam (Hydro II)", 5) }, 5, 1, 3));
            hydroBowUpgrades.Add(new Upgrades("Arco hydro III", new List<Components> { new Components("Nepht Jam (Hydro III)", 5) }, 5, 1, 4));

            pyroBowUpgrades.Add(new Upgrades("Arco pyro I", new List<Components> { new Components("Igna Jam (Pyro I)", 5) }, 5, 2, 2));
            pyroBowUpgrades.Add(new Upgrades("Arco pyro II", new List<Components> { new Components("Hesta Jam (Pyro II)", 5) }, 5, 2, 3));
            pyroBowUpgrades.Add(new Upgrades("Arco pyro III", new List<Components> { new Components("Hephe Jam (Pyro III)", 5) }, 5, 2, 4));

            dendroBowUpgrades.Add(new Upgrades("Arco dendro I", new List<Components> { new Components("Natura Jam (Dendro I)", 5) }, 5, 3, 2));
            dendroBowUpgrades.Add(new Upgrades("Arco dendro II", new List<Components> { new Components("Ninphe Jam (Dendro II)", 5) }, 5, 3, 3));
            dendroBowUpgrades.Add(new Upgrades("Arco dendro III", new List<Components> { new Components("Demetra Jam (Dendro III)", 5) }, 5, 3, 4));

            //Armor
            hydroArmorUpgrades.Add(new Upgrades("Armadura hydro I", new List<Components> { new Components("Aqua Jam (Hydro I)", 5) }, 5, 1, 2));
            hydroArmorUpgrades.Add(new Upgrades("Armadura hydro II", new List<Components> { new Components("Anfi Jam (Hydro II)", 5) }, 5, 1, 3));
            hydroArmorUpgrades.Add(new Upgrades("Armadura hydro III", new List<Components> { new Components("Nepht Jam (Hydro III)", 5) }, 5, 1, 4));

            pyroArmorUpgrades.Add(new Upgrades("Armadura pyro I", new List<Components> { new Components("Igna Jam (Pyro I)", 5) }, 5, 2, 2));
            pyroArmorUpgrades.Add(new Upgrades("Armadura pyro II", new List<Components> { new Components("Hesta Jam (Pyro II)", 5) }, 5, 2, 3));
            pyroArmorUpgrades.Add(new Upgrades("Armadura pyro III", new List<Components> { new Components("Hephe Jam (Pyro III)", 5) }, 5, 2, 4));

            dendroArmorUpgrades.Add(new Upgrades("Armadura dendro I", new List<Components> { new Components("Natura Jam (Dendro I)", 5) }, 5, 3, 2));
            dendroArmorUpgrades.Add(new Upgrades("Armadura dendro II", new List<Components> { new Components("Ninphe Jam (Dendro II)", 5) }, 5, 3, 3));
            dendroArmorUpgrades.Add(new Upgrades("Armadura dendro III", new List<Components> { new Components("Demetra Jam (Dendro III)", 5) }, 5, 3, 4));

            //Shield
            hydroShieldUpgrades.Add(new Upgrades("Escudo hydro I", new List<Components> { new Components("Aqua Jam (Hydro I)", 5) }, 5, 1, 2));
            hydroShieldUpgrades.Add(new Upgrades("Escudo hydro II", new List<Components> { new Components("Anfi Jam (Hydro II)", 5) }, 5, 1, 3));
            hydroShieldUpgrades.Add(new Upgrades("Escudo hydro III", new List<Components> { new Components("Nepht Jam (Hydro III)", 5) }, 5, 1, 4));

            pyroShieldUpgrades.Add(new Upgrades("Escudo pyro I", new List<Components> { new Components("Igna Jam (Pyro I)", 5) }, 5, 2, 2));
            pyroShieldUpgrades.Add(new Upgrades("Escudo pyro II", new List<Components> { new Components("Hesta Jam (Pyro II)", 5) }, 5, 2, 3));
            pyroShieldUpgrades.Add(new Upgrades("Escudo pyro III", new List<Components> { new Components("Hephe Jam (Pyro III)", 5) }, 5, 2, 4));

            dendroShieldUpgrades.Add(new Upgrades("Escudo dendro I", new List<Components> { new Components("Natura Jam (Dendro I)", 5) }, 5, 3, 2));
            dendroShieldUpgrades.Add(new Upgrades("Escudo dendro II", new List<Components> { new Components("Ninphe Jam (Dendro II)", 5) }, 5, 3, 3));
            dendroShieldUpgrades.Add(new Upgrades("Escudo dendro III", new List<Components> { new Components("Demetra Jam (Dendro III)", 5) }, 5, 3, 4));
        }
    }
}
