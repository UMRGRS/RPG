using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    internal class Enemigos:Personaje
    {
        //Variables
        private string name;
        private int element;
        private int xP_drop;
        private int rango;

        //Modifiers
        private readonly float lifeModifier = 2;
        private readonly float damageModifier = 2;
        private readonly float armorModifier = 0.5f;
        public int Elemento { get => element; set => element = value; }
        public int XP_drop { get => xP_drop; set => xP_drop = value; }
        public int Rango { get => rango; set => rango = value; }
        public string Nombre { get => name; set => name = value; }

        public Enemigos(string name, float health, float damage, float armor, int element, int xP_drop, int rango): base (health, damage, armor)
        {
            this.name = name;
            this.element = element;
            this.xP_drop = xP_drop;
            this.rango = rango;
            CalcularEstadisticas();
        }
        //Calculamos las estadisticas del enemigo en base a su rango
        public void CalcularEstadisticas()
        {
            Health *= lifeModifier * rango;
            BaseDamage *= damageModifier * rango;
            Armor *= armorModifier * rango;
        }
        public override void RecibirDano(float dano)
        {
            base.RecibirDano(dano);
        }
    }
}
