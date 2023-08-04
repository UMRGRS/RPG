using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Personaje
    {
        private float vida;//0-10
        private float dano;//0-10
        private float armadura;//0-5
        public float Vida { get => vida; set => vida = value; }
        public float Dano { get => dano; set => dano = value; }
        public float Armadura { get => armadura; set => armadura = value; }
        public Personaje(float vida, float dano, float armadura)
        {
            this.vida = vida;
            this.dano = dano;
            this.armadura = armadura;
        }
        public virtual void RecibirDano(float dano) 
        {
            vida -= dano;
        }
    }
}
