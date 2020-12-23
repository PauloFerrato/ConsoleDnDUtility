using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleDnDUtility
{
    class Controller
    {
        private readonly static Controller _instance = new Controller();

        private Controller()
        {
            
        }
        public static Controller Instance
        {
            get
            {
                return _instance;
            }
        }

        private List<string> setlementName;
        private List<string> setlementType;

        public static bool InLoop { get { return Instance.inLoop; } }
        private bool inLoop = true;

        public List<string> completeFile;


        public static void Setup()
        {
            Instance.completeFile = FileHandler.ReadFile();
            if (Instance.completeFile == null) Instance.completeFile = new List<string>();
            Instance.setlementName = Instance.PickFromKey(UtilsKeysNAdresses.SETLEMENT_NAME_KEY);
            Instance.setlementType = Instance.PickFromKey(UtilsKeysNAdresses.SETLEMENT_TYPE_KEY);
        }
        public void PickAName()
        {
            var random = new Random();
            string output = "";
            int indexType = random.Next(setlementType.Count);
            int indexName = random.Next(setlementName.Count);

            if (setlementType.Count > 0 && setlementName.Count > 0)
            {
                output = setlementName[indexName] + setlementType[indexType];
            }
            else
            {
                output += "-- Elementos insuficientes. Por favor, garanta que há pelo menos um nome e um tipo antes de tentar novamente --\n";
            }
            Console.WriteLine(output);
        }
        public void RemoveElement()
        {
            Console.WriteLine("O que você gostaria de remover?");
            string toRemove = Console.ReadLine();
            if (setlementName.Contains(toRemove))
            {
                setlementName.Remove(toRemove);
                RemoveFromFile(UtilsKeysNAdresses.SETLEMENT_NAME_KEY + toRemove);
            }
            else if (setlementType.Contains(toRemove))
            {
                setlementType.Remove(toRemove);
                RemoveFromFile(UtilsKeysNAdresses.SETLEMENT_TYPE_KEY + toRemove);
            }
            else
            {
                Console.WriteLine("Entrada inválida. Nada foi removido");
            }
        }
        public void ShowAll()
        {
            Console.WriteLine(GetAllFile());
        }
        public void AddElement()
        {
            string question = "Você irá adicionar que tipo de informação?" +
                "\n1 - Nome" +
                "\n2 - Característica" +
                "\n3 - Cancelar";

            byte value = InputManager.AskOneToTops(question, 3);
            string stringToAdd = "";
            if (value == 1)
            {
                Console.WriteLine("Por favor, insira o novo nome: ");
                stringToAdd = Console.ReadLine();
                AddToSettlementName(stringToAdd);
                Console.WriteLine(stringToAdd + " adicionado aos nomes.");

            }
            else if(value == 2)
            {
                Console.WriteLine("Por favor, insira o novo nome: ");
                stringToAdd = Console.ReadLine();
                AddToSettlementType(stringToAdd);
                Console.WriteLine(stringToAdd + " adicionado às características.");
            }
        }
        private void AddToSettlementName(string stringToAdd)
        {
            if(!setlementName.Contains(stringToAdd))setlementName.Add(stringToAdd);
            AddLine(UtilsKeysNAdresses.SETLEMENT_NAME_KEY + stringToAdd);
        }
        private void AddToSettlementType(string stringToAdd)
        {
            if(!setlementType.Contains(stringToAdd))setlementType.Add(stringToAdd);
            AddLine(UtilsKeysNAdresses.SETLEMENT_TYPE_KEY + stringToAdd);
        }
        private void AddLine(string line)
        {
            if (!completeFile.Contains(line))
            {
                completeFile.Add(line);

                FileHandler.WriteFile(completeFile);
            }
        }
        private void RemoveFromFile(string toRemove)
        {
            foreach (string line in completeFile)
            {
                if (line.Equals(toRemove))
                {
                    completeFile.Remove(line);
                    break;
                }
            }
            FileHandler.WriteFile(completeFile);
        }
        private string GetAllFile()
        {
            string final = "";
            foreach (string line in completeFile)
            {
                string modfiedLine = "";
                if (line.Contains(UtilsKeysNAdresses.SETLEMENT_NAME_KEY)) modfiedLine = line.TrimStart(UtilsKeysNAdresses.SETLEMENT_NAME_KEY);
                if (line.Contains(UtilsKeysNAdresses.SETLEMENT_TYPE_KEY)) modfiedLine = line.TrimStart(UtilsKeysNAdresses.SETLEMENT_TYPE_KEY);
                final += modfiedLine + "\n";
            }
            if (final.Equals("")) final += "-- Não há elementos adicionados --";
            return final;
        }
        public List<string> PickFromKey(char key)
        {
            List<string> target = new List<string>();


            foreach (string line in completeFile)
            {
                if (line.Contains(key))
                {
                    string tempLine = line.Trim(key);

                    if (!target.Contains(tempLine)) target.Add(tempLine);
                }
            }
            return target;
        }

        public static void End()
        {
            Instance.inLoop = false;
        }
    }
}
