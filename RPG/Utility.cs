using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    internal class Utility
    {
        public int CheckValidOption(int bottom, int top) 
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
            if(opt < bottom || opt > top) 
            {
                Console.WriteLine("Opcion invalida, seleciona otra");
                CheckValidOption(bottom, top);
            }
            return opt;
        }
    }
}
