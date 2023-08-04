using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Jugador : Personaje
    {
        private string nombre;
        private int lvl;
        private int xP;
        private int xP_sig_LV;
        private float x1;
        private int x;
        public string Nombre { get => nombre; set => nombre = value; }
        public int LVL { get => lvl; set => lvl = value; }
        public int XP { get => xP; set => xP = value; }
        public int XP_sig_LV { get => xP_sig_LV; set => xP_sig_LV = value; }
        public Jugador(float vida, float dano, float armadura,string nombre, int lvl, int xP, int xP_sig_LV, float x1):base (vida,dano,armadura)
        {
            this.nombre = nombre;
            this.lvl = lvl;
            this.xP = xP;
            this.xP_sig_LV = xP_sig_LV;
            this.x1 = x1;
        }
        public void AumentarEstadisticas()
        {
            Vida += x1;
            Dano += x1;
            Armadura += x1;
        }
        
        public void AñadirXP()
        {
            xP += xP_sig_LV;
            
            if(xP >= xP_sig_LV)
            {
                lvl += 1;
                AumentarEstadisticas();
            }
        }
        public void Derrota()
        {
            xP -= x;
        }
        public override void RecibirDano(float dano)
        {
            base.RecibirDano(dano);
            if (Vida<= 0)
            {
                Derrota();
            }
        }

    }
}
