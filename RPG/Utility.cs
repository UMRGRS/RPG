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
    }
}
