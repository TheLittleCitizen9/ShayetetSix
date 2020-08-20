using System;

namespace ShayetetSix
{
    class Program
    {
        static void Main(string[] args)
        {
            ShayetetMenu shayetetMenu = new ShayetetMenu();
            shayetetMenu.AddAction("1", "Add missle", null, true);
            shayetetMenu.AddAction("2", "Launch missles", null, true);
            shayetetMenu.AddAction("3", "Print missles' inventory", null);
            shayetetMenu.AddAction("4", "Remove missle", null, true);
            shayetetMenu.AddAction("5", "Exit", null);
            shayetetMenu.Main();

        }
    }
}
