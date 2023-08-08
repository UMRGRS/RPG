using System.Runtime.InteropServices;

namespace RPG
{
    internal class Personaje
    {
        private float health;
        private float baseDamage;
        private float armor;
        public float Health { get => health; set => health = value; }
        public float BaseDamage { get => baseDamage; set => baseDamage = value; }
        public float Armor { get => armor; set => armor = value; }
        public Personaje(float health, float armor, [Optional] float baseDamage)
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