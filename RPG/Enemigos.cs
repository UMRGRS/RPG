using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    internal class Enemigos:Personaje
    {
        private string nombre;
        private int elemento;
        private int xP_drop;
        private int rango;
        private readonly float lifeModifier = 2;
        private readonly float damageModifier = 2;
        private readonly float armorModifier = 0.5f;
        public int Elemento { get => elemento; set => elemento = value; }
        public int XP_drop { get => xP_drop; set => xP_drop = value; }
        public int Rango { get => rango; set => rango = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public Enemigos(string nombre, float vida, float dano, float armadura, int elemento, int xP_drop, int rango):base(vida,dano,armadura)
        {
            this.nombre = nombre;
            this.elemento = elemento;
            this.xP_drop = xP_drop;
            this.rango = rango;
            CalcularEstadisticas();
        }
        //Calculamos las estadisticas del enemigo en base a su rango
        public void CalcularEstadisticas()
        {
            Vida *= (lifeModifier * rango);
            Dano *= (damageModifier * rango);
            Armadura *= (armorModifier * rango);
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
