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
        Dictionary<int, string> items = new Dictionary<int, string>();
        public void AddItems() 
        {
            items.Add(1, "Trozo de slime de fuego");
        }
    }
}
