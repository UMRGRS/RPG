using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Sword 
    {
        private float swordDamage;
        private int swordElement = 0;

        public float SwordDamage { get => swordDamage; set => swordDamage = value; }
        public int SwordElement { get => swordElement; set => swordElement = value; }
    }
    public class Bow 
    {
        private float bowDamage;
        private int bowElement = 0;

        public float BowDamage { get => bowDamage; set => bowDamage = value; }
        public int BowElement { get => bowElement; set => bowElement = value; }
    }
    public class Shield 
    {
        private float shieldDefense;
        private int shieldElement = 0;

        public float ShieldDefense { get => shieldDefense; set => shieldDefense = value; }
        public int ShieldElement { get => shieldElement; set => shieldElement = value; }
    }
    internal class Jugador : Personaje
    {
        private string nombre;
        private float actualHealth;
        private float actualDamage;
        private int lvl;
        private int xP = 0;
        private int xP_sig_LV = 30;
        public string Nombre { get => nombre; set => nombre = value; }
        public int LVL { get => lvl; set => lvl = value; }
        public int XP { get => xP; set => xP = value; }
        public int XP_sig_LV { get => xP_sig_LV; set => xP_sig_LV = value; }
        public float VidaActual { get => actualHealth; set => actualHealth = value; }
        public float DanoActual { get => actualDamage; set => actualDamage = value; }

        public Jugador(float health, float damage, float armor, int lvl):base (health, damage, armor)
        {
            this.lvl = lvl;
            actualDamage = damage;
            actualHealth = health;
        }
        public void AumentarEstadisticas()
        {
            Vida += 1;
            BaseDamage += 1;
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
            actualHealth = Vida;
            actualDamage = BaseDamage;
        }
        public override void RecibirDano(float dano)
        {
            actualHealth -= dano;
        }
    }
}
