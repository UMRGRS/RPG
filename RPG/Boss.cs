using System;

namespace RPG
{
    internal class Boss : Enemigos
    {
        private readonly Random ran = new Random();
        public Boss(string name, float health, float damage, float armor, int element, int xP_drop, int rango) : base(name, health, damage, armor, element, xP_drop, rango)
        {
            ChangeElement();
        }
        public void ChangeElement()
        {
            Elemento = ran.Next(1, 4);
        }
    }
}
