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

        public Dictionary<string, int> PlayerInventory { get => playerInventory; set => playerInventory = value; }

        public void AddItems() 
        {
            playerInventory.Add("Athena Potion (Poción de daño)", 0); //Pocion de daño
            playerInventory.Add("Sephe Potion (Poción de vida)", 2); //Pocion de vida
            playerInventory.Add("Igna Jam (Pyro I)", 0); //Fuego 1
            playerInventory.Add("Hesta Jam (Pyro II)", 0); //2
            playerInventory.Add("Hephe Jam (Pyro III)", 0); //3
            playerInventory.Add("Natura Jam (Dendro I)", 0); //Naturaleza 1
            playerInventory.Add("Ninphe Jam (Dendro II)", 0); //2
            playerInventory.Add("Demetra Jam (Dendro III)", 0); //3
            playerInventory.Add("Aqua Jam (Hydro I)", 0); //Agua 1
            playerInventory.Add("Anfi Jam (Hydro II)", 0); //2
            playerInventory.Add("Nepht Jam (Hydro III)", 0); //3
        }
    }
}
