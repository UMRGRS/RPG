using System;

namespace RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Solo es program, aqui deben existir solo estas tres lineas :b
            Menus main = new Menus();
            main.StartGame();
            Console.ReadKey();
        }
    }
}
