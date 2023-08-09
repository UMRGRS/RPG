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

        public float WeaponDamage { get => weaponDamage; set => weaponDamage = value; }
        public int WeaponElement { get => weaponElement; set => weaponElement = value; }
        public Weapon(float weaponDamage) 
        {
            this.weaponDamage = weaponDamage;
        }
    }
    public class Shield 
    {
        private float shieldDefense;
        private int shieldElement = 0;

        public float ShieldDefense { get => shieldDefense; set => shieldDefense = value; }
        public int ShieldElement { get => shieldElement; set => shieldElement = value; }
        public Shield(float shieldDefense)
        {
            this.shieldDefense = shieldDefense;
        }
    }
    internal class Jugador : Personaje
    {
        //Equipment
        private Weapon sword;
        private Weapon bow;
        private Shield myShield;

        //Stats
        private string name;
        private float damageModifier = 0;
        private float actualHealth;
        private int armorElement = 0;
        private int lvl;
        
        //Experience
        private int xP = 0;
        private int xP_sig_LV = 30;
        
        public string Name { get => name; set => name = value; }
        public int LVL { get => lvl; set => lvl = value; }
        public int XP { get => xP; set => xP = value; }
        public int XP_sig_LV { get => xP_sig_LV; set => xP_sig_LV = value; }
        public float ActualHealth { get => actualHealth; set => actualHealth = value; }
        public int ArmorElement { get => armorElement; set => armorElement = value; }
        public float DamageModifier { get => damageModifier; set => damageModifier = value; }
        public Weapon Sword { get => sword; set => sword = value; }
        public Weapon Bow { get => bow; set => bow = value; }
        public Shield MyShield { get => myShield; set => myShield = value; }

        public Jugador(float health, float swordDamage, float bowDamage, float shieldDefense, float armorDefense, int lvl):base (health, armorDefense)
        {
            this.lvl = lvl;
            actualHealth = health;
            sword = new Weapon(swordDamage);
            bow = new Weapon(bowDamage);
            myShield = new Shield(shieldDefense);
        }
        public void AumentarEstadisticas()
        {
            Health += 1;
            BaseDamage += 1;
            Armor += 1;
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
