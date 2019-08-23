using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SMDB.Classes
{
    public static class FileHandler
    {
        public static void createFile(string name)
        {
            try
            {
                FileStream newFile = new FileStream(name, FileMode.Create);
                newFile.Close();

            }
            catch (IOException error)
            {
                Console.WriteLine(error.Message + "\n Cannot create file.");
                throw error;
            }
        }

        public static FileStream openFile(string name)
        {
            try
            {
                FileStream newFile = new FileStream(name, FileMode.Open);
                return newFile;

            }
            catch (IOException error)
            {
                Console.WriteLine(error.Message + "\n Cannot open file.");
                throw error;
            }
        }

        public static FileStream createAndOpen(string name)
        {
            try
            {
                FileStream newFile = new FileStream(name, FileMode.Create);
                return newFile;

            }
            catch (IOException error)
            {
                Console.WriteLine(error.Message + "\n Cannot create file.");
                throw error;
            }
        }

        public static void createFiles(string[] files)
        {
            for (int i = 0; i < files.Length; i++)
            {
                createFile(files[i]);
            }
        }
    }
}
