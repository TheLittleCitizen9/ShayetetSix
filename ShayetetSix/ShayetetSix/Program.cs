using System;

namespace ShayetetSix
{
    class Program
    {
        static void Main(string[] args)
        {
            ShayetetMenu shayetetMenu = new ShayetetMenu();
            shayetetMenu.AddAction("1", "Add missle", null);
            shayetetMenu.Main();


        }
    }
}
