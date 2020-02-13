using System;
using System.IO;

namespace Homework__2
{
    class Cmd : ICmd
    {

        public string ChangeDirectoryBack(string fullNameDirectory)
        {
            string temp = @"\";
            int count = 1;
            for(int i = fullNameDirectory.Length - 2; i > 3; i--)
            {
                if (fullNameDirectory[i] == temp[0]) break;
                count++;
            }
            fullNameDirectory = fullNameDirectory.Substring(0, fullNameDirectory.Length - count);
            return fullNameDirectory;
        }

        public string ChangeDirectoryForward(string fullNameDirectory, string nameDir)
        {
            string temp = fullNameDirectory;
            temp += nameDir;
            temp += @"\";
            DirectoryInfo dirInfo = new DirectoryInfo(temp);
            if (dirInfo.Exists)
            {
                fullNameDirectory += nameDir;
                fullNameDirectory += @"\";
            }
            else
            {
                Console.WriteLine("Системе не удается найти указанный путь.");
            }
            
            return fullNameDirectory;
        }

        public void MakeDirectory(string fullNameDirectory, string nameDirectory)
        {
            fullNameDirectory += nameDirectory;
            DirectoryInfo dirInfo = new DirectoryInfo(fullNameDirectory);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            else
            {
                Console.WriteLine("Подпапка или файл " + nameDirectory + " уже существует.");
            }
        }

        public void RemoveDirectory(string fullNameDirectory, string nameDirectory)
        {
            fullNameDirectory += nameDirectory;
            DirectoryInfo dirInfo = new DirectoryInfo(fullNameDirectory);
            if (dirInfo.Exists && nameDirectory.Length > 0)
            {
                Directory.Delete(fullNameDirectory, true);
            }
            else
            {
                Console.WriteLine("Не удается найти указанный файл.");
            }
        }
    }
}
