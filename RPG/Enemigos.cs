using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    internal class Enemigos:Personaje
    {
        private int elemento;
        private int xP_drop;
        private int rango;
        private int x=1;
        public int Elemento { get => elemento; set => elemento = value; }
        public int XP_drop { get => xP_drop; set => xP_drop = value; }
        public int Rango { get => rango; set => rango = value; }
        public Enemigos(float vida, float dano, float armadura, int elemento, int xP_drop, int rango):base(vida,dano,armadura)
        {
            this.elemento = elemento;
            this.xP_drop = xP_drop;
            this.rango = rango;
            CalcularEstadisticas();
        }
        public void CalcularEstadisticas()
        {
            Vida *= (rango / x);
            Dano *= (rango / x);
            Armadura *= (rango / x);
        }
        public override void RecibirDano(float dano)
        {
            base.RecibirDano(dano);
            if (Vida<=0)
            {
                //recompesa
            }
        }
    }
}
