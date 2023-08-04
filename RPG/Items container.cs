using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Items_container
    {
        Dictionary<string, int> items = new Dictionary<string, int>();
        public void AddItems() 
        {
            items.Add("Health potion", 0);
        }
    }
}
