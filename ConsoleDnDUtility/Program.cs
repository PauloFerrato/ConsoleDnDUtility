using System;
using System.Collections.Generic;

namespace ConsoleDnDUtility
{
   
    class Program
    {

        static void Main(string[] args)
        {
            Controller.Setup();
            MainLoop();
        }

        private static void MainLoop()
        {
            while (Controller.InLoop)
            {
                InputManager.AskForNext();
            }
        }
    }
}
