using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Weapon 
    {
        private float weaponDamage;
        private int weaponElement = 0;
        private int tier = 1;
        public float WeaponDamage { get => weaponDamage; set => weaponDamage = value; }
        public int WeaponElement { get => weaponElement; set => weaponElement = value; }
        public int Tier { get => tier; set => tier = value; }

        public Weapon(float weaponDamage) 
        {
            this.weaponDamage = weaponDamage;
        }
        public void AddStats(float weaponDamage, int element, int tier) 
        {
            this.weaponDamage += weaponDamage;
            weaponElement = element;
            this.tier = tier;
        }
    }
    public class DefensiveItem
    {
        private float defense;
        private int element = 0;
        private int tier = 1;
        public float Defense { get => defense; set => defense = value; }
        public int Element { get => element; set => element = value; }
        public int Tier { get => tier; set => tier = value; }

        public DefensiveItem(float defense)
        {
            this.defense = defense;
        }
        public void AddStats(float defense, int element,int tier)
        {
            this.defense += defense;
            this.element = element;
            this.tier = tier;
        }
    }
    internal class Jugador : Personaje
    {
        //Equipment
        private Weapon sword;
        private Weapon bow;
        private DefensiveItem shield;
        private DefensiveItem fullArmor;

        //Stats
        private string name;
        private float damageModifier = 0;
        private float actualHealth;
        private int lvl;
        
        //Experience
        private int xP = 0;
        private int xP_sig_LV = 30;
        
        public string Name { get => name; set => name = value; }
        public int LVL { get => lvl; set => lvl = value; }
        public int XP { get => xP; set => xP = value; }
        public int XP_sig_LV { get => xP_sig_LV; set => xP_sig_LV = value; }
        public float ActualHealth { get => actualHealth; set => actualHealth = value; }
        public float DamageModifier { get => damageModifier; set => damageModifier = value; }
        public Weapon Sword { get => sword; set => sword = value; }
        public Weapon Bow { get => bow; set => bow = value; }
        public DefensiveItem Shield { get => shield; set => shield = value; }
        public DefensiveItem FullArmor { get => fullArmor; set => fullArmor = value; }

        public Jugador(float health, float swordDamage, float bowDamage, float shieldDefense, float armorDefense, int lvl):base (health)
        {
            this.lvl = lvl;
            actualHealth = health;
            sword = new Weapon(swordDamage);
            bow = new Weapon(bowDamage);
            Shield = new DefensiveItem(shieldDefense);
            fullArmor = new DefensiveItem(armorDefense);
        }
        public void AumentarEstadisticas()
        {
            Health += 1;
        }
        public void AñadirXP(int xp)
        {
            xP += xp;
            if(xP >= xP_sig_LV)
            {
                xP -= xP_sig_LV;
                lvl += 1;
                AumentarEstadisticas();
            }
        }
        public void Derrota(int xpLost)
        {
            xP -= xpLost;
            if (xP < 0) 
            {
                xP = 0;
            }
            ResetStats();
        }
        public void ResetStats() 
        {
            actualHealth = Health;
            damageModifier = 0;
        }
        public override void RecibirDano(float damage)
        {
            actualHealth -= damage;
        }
    }
}
