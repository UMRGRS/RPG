using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    internal class Utility
    {
        //Checador universal para opciones numericas
        //Argumento 1 = primer opcion
        //Argumento 2 = ultima opcion
        public int CheckValidOption(int firstOption, int lastOption) 
        {
            int opt = 0;
            for(int i = 0; i < 1; i++) 
            {
                try
                {
                    opt = int.Parse(Console.ReadLine());
                }
                catch
                {

                    Console.WriteLine("Opcion invalida, seleciona otra");
                    i--;
                }
            }
            if(opt < firstOption || opt > lastOption) 
            {
                Console.WriteLine("Opcion invalida, seleciona otra");
                CheckValidOption(firstOption, lastOption);
            }
            return opt;
        }
       /* public string SelecNombres(int elemento) 
        {
            List<string> naturaNames = new List<string> { "Nomi", "Goby", "Drida" };
            List<string> ignaNames = new List<string> { "Fefe", "Sasa", "Dracus" };
            List<string> aquaNames = new List<string> { "Sere", "Tito", "Nide" };

            if (elemento == 1)
            {

            }
            if (elemento == 2)
            {

            }
            if (elemento == 3)
            {

            }
        }*/
    }
}
