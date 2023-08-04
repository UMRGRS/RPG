using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    internal class Combat
    {
        private readonly Random ran = new Random();
        ContenedorEnemigos enemies = new ContenedorEnemigos();
        
        public void SelectEnemies(int lvl) 
        {
            //Two random numbers if the number is less than the player's level then 1 more slime appers
            int select = ran.Next(1, 12);

        }
    }
}
