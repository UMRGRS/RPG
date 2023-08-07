using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    internal class Jugador : Personaje
    {
        private string nombre;
        private float vidaActual;
        private float danoActual;
        private int lvl;
        private int xP = 0;
        private int xP_sig_LV = 30;
        private float shieldDefense = 3;
        private int shieldElement = 0;
        private int armorElement = 0;
        private float swordDamage = 3;
        private float bowDamage = 2;
        public string Nombre { get => nombre; set => nombre = value; }
        public int LVL { get => lvl; set => lvl = value; }
        public int XP { get => xP; set => xP = value; }
        public int XP_sig_LV { get => xP_sig_LV; set => xP_sig_LV = value; }
        public float Shield { get => shieldDefense; set => shieldDefense = value; }
        public float SwordDamage { get => swordDamage; set => swordDamage = value; }
        public float BowDamage { get => bowDamage; set => bowDamage = value; }
        public float VidaActual { get => vidaActual; set => vidaActual = value; }
        public float DanoActual { get => danoActual; set => danoActual = value; }
        public int ShieldElement { get => shieldElement; set => shieldElement = value; }
        public int ArmorElement { get => armorElement; set => armorElement = value; }

        public Jugador(float vida, float dano, float armadura, int lvl):base (vida,dano,armadura)
        {
            this.lvl = lvl;
            danoActual = dano;
        }
        public void AumentarEstadisticas()
        {
            Vida += 1;
            Dano += 1;
            Armadura += 1;
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
            vidaActual = Vida;
            danoActual = Dano;
        }
        public override void RecibirDano(float dano)
        {
            vidaActual -= dano;
        }
        
    }
}
