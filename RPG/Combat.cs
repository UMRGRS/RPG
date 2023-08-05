using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    internal class Combat
    {
        private readonly Random ran = new Random();
        private readonly ContenedorEnemigos enemies = new ContenedorEnemigos();
        public Enemigos[] SpawnEnemies(int lvl) 
        {
            Enemigos[] activeEnemies;
            if (lvl < 4)
            {
                activeEnemies = SelectEnemies(enemies.EnemigosTier1, lvl);
            }
            else if (lvl > 4 && lvl < 9)
            {
                activeEnemies = SelectEnemies(enemies.EnemigosTier2, lvl);
            }
            else 
            {
                activeEnemies = SelectEnemies(enemies.EnemigosTier3, lvl);
            }
            return activeEnemies;
        }
        private Enemigos[] SelectEnemies(Enemigos[] enemigos, int lvl) 
        {
            int enemiesQuantity = 1;
            for (int i = 0; i < 2; i++) 
            {
                int spawnOrNot = ran.Next(1, 12);
                if (spawnOrNot < lvl) 
                {
                    enemiesQuantity++;
                }
            }
            Enemigos[] selectedEnemies = new Enemigos[enemiesQuantity];
            for (int i = 0; i < selectedEnemies.Length; i++) 
            {
                int index = ran.Next(0, enemigos.Length);
                selectedEnemies[i] = enemigos[index];
            }
            return selectedEnemies;
        }
    }
}
