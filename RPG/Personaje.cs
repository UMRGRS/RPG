using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    internal class Personaje
    {
        private float vida;
        private float dano;
        private float armadura;
        public float Vida { get => vida; set => vida = value; }
        public float Dano { get => dano; set => dano = value; }
        public float Armadura { get => armadura; set => armadura = value; }
        public Personaje(float vida, float dano, float armadura)
        {
            this.vida = vida;
            this.dano = dano;
            this.armadura = armadura;
        }
        //Reducimos la vida del personaje 
        public virtual void RecibirDano(float dano) 
        {
            vida -= dano;
        }
        public virtual void CalculateDamageTaken(float dano) 
        {
            float totalDamage = Dano - armadura;
        }
    }
}
