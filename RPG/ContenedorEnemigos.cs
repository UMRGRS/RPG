using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    internal class ContenedorEnemigos
    {
        //Lugar para crear todos los enemigos que deseemos
        //Fire = 1
        //Water = 2;
        //Nature = 3
        private Enemigos[] enemigosTier1 = new Enemigos[3];
        private Enemigos[] enemigosTier2 = new Enemigos[3];
        private Enemigos[] enemigosTier3 = new Enemigos[3];
        public Enemigos[] EnemigosTier1 { get => enemigosTier1; set => enemigosTier1 = value; }
        public Enemigos[] EnemigosTier2 { get => enemigosTier2; set => enemigosTier2 = value; }
        public Enemigos[] EnemigosTier3 { get => enemigosTier3; set => enemigosTier3 = value; }
        public ContenedorEnemigos() 
        {
            CreateArrays();
        }
        private void CreateArrays() 
        {
            enemigosTier1[0] = new Enemigos("Sparks", 1, 1, 1, 1, 1, 1);
            enemigosTier1[1] = new Enemigos("Waterfall", 1, 1, 1, 2, 1, 1);
            enemigosTier1[2] = new Enemigos("Dendro", 1, 1, 1, 3, 1, 1);
            //Use this to check the enemy scaling
            /*foreach (var enemy in enemigosTier1) 
            {
                Console.WriteLine($"{enemy.Nombre},{enemy.Vida},{enemy.Armadura},{enemy.Dano},{enemy.Elemento},{enemy.XP_drop},{enemy.Rango}");
            }*/
            enemigosTier2[0] = new Enemigos("Sparks 2", 1, 1, 1, 1, 1, 2);
            enemigosTier2[1] = new Enemigos("Waterfall 2", 1, 1, 1, 2, 1, 2);
            enemigosTier2[2] = new Enemigos("Dendro 2", 1, 1, 1, 3, 1, 2);

            enemigosTier3[0] = new Enemigos("Sparks 3", 1, 1, 1, 1, 1, 3);
            enemigosTier3[1] = new Enemigos("Waterfall 3", 1, 1, 1, 2, 1, 3);
            enemigosTier3[2] = new Enemigos("Dendro 3", 1, 1, 1, 3, 1, 3);
        }
    }
}
