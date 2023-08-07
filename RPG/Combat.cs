using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    //Test
    internal class Combat
    {
        //Hay que crear varios nombres para cada tipo de slime y diferenciarlos
        //Cada turno todos los slimes en pantalla atacaran al jugador
        private readonly Random ran = new Random(); //Clase para generar numeros random

         private readonly Utility utility = new Utility();

        public List<Enemigos> SpawnEnemies(int lvl) 
        {
            
            //En base al nivel del jugador hacemos aparecer slimes de nivel mas alto o bajo
            List <Enemigos> activeEnemies;
            if (lvl < 4)
            {
                activeEnemies = SelectEnemies(1, lvl);
            }
            else if (lvl > 4 && lvl < 9)
            {
                activeEnemies = SelectEnemies(2, lvl);
            }
            else 
            {
                activeEnemies = SelectEnemies(3, lvl);
            }
            return activeEnemies;
        }
        private List<Enemigos> SelectEnemies(int enemyLvl, int lvl) 
        {
            //Generamos un numero aleatorio entre 0 y 12 si ese numero es menor al nivel del jugador aparece un slime extra
            //Siempre aparece un slime por defecto
            int enemiesQuantity = 1;
            for (int i = 0; i < 2; i++) 
            {
                int spawnOrNot = ran.Next(1, 13);
                if (spawnOrNot < lvl) 
                {
                    enemiesQuantity++;
                }
            }
            //Creamos un arreglo para guardar los enemigos a los cuales el jugador se va a enfrentar
            List <Enemigos> selectedEnemies = new List<Enemigos>();
            //Un numero aleatorio entre 1 y 3 selecciona al slime que aparecera de la lista de enemigos disponibles
            for (int i = 0; i < enemiesQuantity; i++) 
            {
                int enemyElement = ran.Next(1, 4);
                selectedEnemies.Add(new Enemigos(utility.SelecNombres(enemyElement), 1, 1, 1, enemyElement, 1, enemyLvl));
            }
            return selectedEnemies;
        }
        
    }
}
