﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menus main = new Menus();
            main.StartGame();
            Console.ReadKey();
        }
    }
}
