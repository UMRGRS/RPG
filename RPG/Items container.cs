using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Items_container
    {
        //Recuerda añadir los objetos de forma cantidad,nombre.
        //Primero añade los trozos de slime en este orden, trozos de fuefo, trozos de agua, trozos de naturaleza
        //Si no entiendes algo mandame mensaje
        Dictionary<string, int> items = new Dictionary<string, int>();
        public void AddItems() 
        {
            items.Add("Athena Potion", 0); //Posion de daño
            items.Add("Sephe Potion", 0); //Posion de vida
            items.Add("Igna Jam", 0); //Fuego 1
            items.Add("Hesta Jam", 0);      //2
            items.Add("Hephe Jam", 0);      //3
            items.Add("Natura Jam", 0); //Naturaleza 1
            items.Add("Ninphe Jam", 0);            //2
            items.Add("Demetra Jam", 0);           //3
            items.Add("Aqua Jam", 0); //Agua 1
            items.Add("Anfi Jam", 0);      //2
            items.Add("Nepht Jam", 0);     //3
        }
    }
}
