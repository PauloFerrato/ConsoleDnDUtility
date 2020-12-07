using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleDnDUtility
{
    class InputManager
    {
///        <summary> Requires the user a number from one to tops using the string question, tops being inclusive </summary>
        public static byte AskOneToTops(string question, int tops)
        {
            Console.WriteLine(question);

            while (true)
            {
                bool invalid = false;
                string answer = Console.ReadLine();
                byte value = 0;
                try
                {
                    value = Convert.ToByte(answer);
                    if (value <= tops && value > 0) return value;
                    else invalid = true;
                }
                catch
                {
                    invalid = true;
                }
                if (invalid) Console.WriteLine("Entrada inválida. " + question);
            }
        }

        public static void AskForNext()
        {
            string question = "Por favor, insira sua próxima ação: " +
                "\n1 - Sortear um nome" +
                "\n2 - Adicionar" +
                "\n3 - Mostrar Tudo" +
                "\n4 - Remover Algo" +
                "\n5 - Sair";

            byte value = AskOneToTops(question, 5);

            switch (value)
            {
                case 1:
                    Controller.Instance.PickAName();
                    break;
                case 2:
                    Controller.Instance.AddElement();
                    break;
                case 3:
                    Controller.Instance.ShowAll();
                    break;
                case 4:
                    Controller.Instance.RemoveElement();
                    break;
                case 5:
                    Controller.End();
                    break;
            }
        }
    }
}
