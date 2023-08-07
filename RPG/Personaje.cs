using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    internal class Personaje
    {
        private float health;
        private float baseDamage;
        private float armor;
        public float Vida { get => health; set => health = value; }
        public float BaseDamage { get => baseDamage; set => baseDamage = value; }
        public float Armadura { get => armor; set => armor = value; }
        public Personaje(float health, float baseDamage, float armor)
        {
            this.health = health;
            this.baseDamage = baseDamage;
            this.armor = armor;
        }
        //Reducimos la vida del personaje 
        public virtual void RecibirDano(float damage) 
        {
            health -= damage;
        }
    }
}
