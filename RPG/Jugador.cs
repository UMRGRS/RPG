using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    internal class Jugador : Personaje
    {
        private string nombre;
        private int lvl;
        private int xP = 0;
        private int xP_sig_LV = 30;
        private float shield;
        private float swordDamage = 3;
        private float bowDamage = 2;
        private float statsUpgrade = 1;
        public string Nombre { get => nombre; set => nombre = value; }
        public int LVL { get => lvl; set => lvl = value; }
        public int XP { get => xP; set => xP = value; }
        public int XP_sig_LV { get => xP_sig_LV; set => xP_sig_LV = value; }
        public float Shield { get => shield; set => shield = value; }
        public float SwordDamage { get => swordDamage; set => swordDamage = value; }
        public float BowDamage { get => bowDamage; set => bowDamage = value; }

        public Jugador(float vida, float dano, float armadura, int lvl):base (vida,dano,armadura)
        {
            this.lvl = lvl;
        }
        public void AumentarEstadisticas()
        {
            Vida += statsUpgrade;
            Dano += statsUpgrade;
            Armadura += statsUpgrade;
        }
        
        public void AñadirXP()
        {
            xP += xP_sig_LV;
            
            if(xP >= xP_sig_LV)
            {
                lvl += 1;
                AumentarEstadisticas();
            }
        }
        public void Derrota()
        {
            xP -= 5;
        }
        public override void RecibirDano(float dano)
        {
            base.RecibirDano(dano);
            if (Vida <= 0)
            {
                Derrota();
            }
        }

    }
}
