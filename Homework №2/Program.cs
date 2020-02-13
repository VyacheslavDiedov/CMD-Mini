using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework__2
{
    class Program
    {
        static void Main(string[] args)
        {
            Run(new Cmd());
        }

        public static void Run(ICmd doCmd)
        {
            Console.WriteLine("Microsoft Windows [Version 10.0.18363.592]");
            Console.WriteLine("(c) Корпорация Майкрософт (Microsoft Corporation), 2020. Все права защищены.\n");
            NameDirectory nameDirectory = new NameDirectory();
            nameDirectory.FullNameDirectory = @"E:\Test cmd\";
            while (true)
            {
                Console.Write(nameDirectory.FullNameDirectory + ">");
                string controlСonsole = Console.ReadLine();
                if (controlСonsole.Length < 3) continue;
                if (controlСonsole == "exit") return;
                if (controlСonsole == "help")
                {
                    Console.WriteLine("CD \t\t Вывод имени либо смена текущей папки.");
                    Console.WriteLine("MD \t\t Создает каталог.");
                    Console.WriteLine("RD \t\t Удаляет каталог.");
                    Console.WriteLine("help \t\t Выводит справочную информацию о командах Windows.");
                    Console.WriteLine("exit \t\t Завершает работу программы CMD.EXE (интерпретатора командных строк).\n");
                    continue;
                }
                string command = "";
                string nameDir = "";
                for(int i = 3; i < controlСonsole.Length; i++)
                {
                    nameDir += new string(controlСonsole[i], 1);
                }
                command += (new string(controlСonsole[0], 1) + new string(controlСonsole[1], 1));
                switch (command)
                {
                    case "md":
                        doCmd.MakeDirectory(nameDirectory.FullNameDirectory, nameDir);
                        break;
                    case "rd":
                        doCmd.RemoveDirectory(nameDirectory.FullNameDirectory, nameDir);
                        break;
                    case "cd":
                        if (controlСonsole[3] == '.' && controlСonsole[4] == '.')
                        {
                            nameDirectory.FullNameDirectory = doCmd.ChangeDirectoryBack(nameDirectory.FullNameDirectory);
                        }
                        else
                        {
                            nameDirectory.FullNameDirectory = doCmd.ChangeDirectoryForward(nameDirectory.FullNameDirectory, nameDir);
                        }
                        break;
                    default: 
                        Console.WriteLine(command + " не является внутренней или внешней");
                        Console.WriteLine("командой, исполняемой программой или пакетным файлом.");
                        break;
                }
                Console.WriteLine();
            }
        }  
    }

    interface ICmd
    {
        string ChangeDirectoryBack(string fullNameDirectory);

        string ChangeDirectoryForward(string fullNameDirectory, string nameDir);

        void MakeDirectory(string fullNameDirectory, string nameDir);

        void RemoveDirectory(string fullNameDirectory, string nameDir);
    }

    class NameDirectory
    {
        public string FullNameDirectory;
    }
}
