using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Inventory
    {
        private Dictionary<string, int> playerInventory = new Dictionary<string, int>();

        //Items categories
        private List<string> aquaJams = new List<string>() { "Aqua Jam (Hydro I)", "Anfi Jam (Hydro II)", "Nepht Jam (Hydro III)" };
        private List<string> pyroJams = new List<string>() { "Igna Jam (Pyro I)", "Hesta Jam (Pyro II)", "Hephe Jam (Pyro III)" };
        private List<string> dendroJams = new List<string>() { "Natura Jam (Dendro I)", "Ninphe Jam (Dendro II)", "Demetra Jam (Dendro III)" };

        private List<string> consumables = new List<string>() { "Athena Potion (Poción de daño)", "Sephe Potion (Poción de vida)" };
        
        public Dictionary<string, int> PlayerInventory { get => playerInventory; set => playerInventory = value; }
        public List<string> AquaJams { get => aquaJams; set => aquaJams = value; }
        public List<string> PyroJams { get => pyroJams; set => pyroJams = value; }
        public List<string> DendroJams { get => dendroJams; set => dendroJams = value; }
        public List<string> Consumables { get => consumables; set => consumables = value; }

        public Inventory() 
        {
            AddItems();
        }
        public void AddItems() 
        {
            playerInventory.Add("Athena Potion (Poción de daño)", 2); //Pocion de daño
            playerInventory.Add("Sephe Potion (Poción de vida)", 2); //Pocion de vida

            playerInventory.Add("Aqua Jam (Hydro I)", 0); //Agua 1
            playerInventory.Add("Anfi Jam (Hydro II)", 0); //2
            playerInventory.Add("Nepht Jam (Hydro III)", 0); //3

            playerInventory.Add("Igna Jam (Pyro I)", 0); //Fuego 1
            playerInventory.Add("Hesta Jam (Pyro II)", 0); //2
            playerInventory.Add("Hephe Jam (Pyro III)", 0); //3

            playerInventory.Add("Natura Jam (Dendro I)", 0); //Naturaleza 1
            playerInventory.Add("Ninphe Jam (Dendro II)", 0); //2
            playerInventory.Add("Demetra Jam (Dendro III)", 0); //3
            
        }
    }
}
