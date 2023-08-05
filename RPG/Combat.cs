using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    internal class Combat
    {
        //Cada turno todos los slimes en pantalla atacaran al jugador
        private readonly Random ran = new Random(); //Clase para generar numeros random
        private readonly ContenedorEnemigos enemies = new ContenedorEnemigos();
        public Enemigos[] SpawnEnemies(int lvl) 
        {
            //Dependiendo del nivel del jugador usamos una lista de enemigos
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
            //Generamos un numereo aleatorio entre 0 y 12 si ese numero es menor al nivel del jugador aparece un slime extra
            //Siempre aparece un slime por defecto
            int enemiesQuantity = 1;
            for (int i = 0; i < 2; i++) 
            {
                int spawnOrNot = ran.Next(1, 12);
                if (spawnOrNot < lvl) 
                {
                    enemiesQuantity++;
                }
            }
            //Creamos un arreglo para guardar los enemigos a los cuales el jugador se va a enfrentar
            Enemigos[] selectedEnemies = new Enemigos[enemiesQuantity];
            //Un numero aleatorio entre 1 y 3 selecciona al slime que aparecera de la lista de enemigos disponibles
            for (int i = 0; i < selectedEnemies.Length; i++) 
            {
                int index = ran.Next(0, enemigos.Length);
                selectedEnemies[i] = enemigos[index];
            }
            return selectedEnemies;
        }
    }
}
