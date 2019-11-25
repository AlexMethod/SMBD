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
        public static void fileMove(string origin, string destiny)
        {
            File.Move(origin, destiny);
        }
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

        public static void deleteFile(string fileName)
        {
            File.Delete(fileName);
        }

        public static void renameFile(string oldName, string newName)
        {
            File.Move(oldName,newName);
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

        public static void createDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public static string[] getFilesDirectory(string path)
        {
            return Directory.GetFiles(path);
        }

        public static void deleteDirectory(string path)
        {
            Directory.Delete(path, true);
        }
        public static void writeOnFile(string fileName,byte[] bytes,long startIndex)
        {
            BinaryWriter binaryWriter = new BinaryWriter(new FileStream(fileName, FileMode.Open));
            binaryWriter.BaseStream.Seek(startIndex, SeekOrigin.Begin);
            binaryWriter.Write(bytes);
            binaryWriter.Dispose();
            binaryWriter.Close();
        }

        public static byte[] readFromFile(string fileName,int cantToRead,long startIndex)
        {
            BinaryReader binaryReader = new BinaryReader(new FileStream(fileName, FileMode.Open));
            binaryReader.BaseStream.Seek(startIndex, SeekOrigin.Begin);
            byte[] bytes = binaryReader.ReadBytes(cantToRead);
            binaryReader.Dispose();
            binaryReader.Close();
            return bytes;
        }

        public static byte[] intToBytes(int number)
        {
            byte[] intBytes = BitConverter.GetBytes(number).ToArray();
            return intBytes;
        }

        public static byte[] longToBytes(long number)
        {
            byte[] intBytes = BitConverter.GetBytes(number).ToArray();
            return intBytes;
        }

        public static byte[] floatToBytes(float number)
        {
            byte[] intBytes = BitConverter.GetBytes(number).ToArray();
            return intBytes;
        }

        public static float bytesToFloat(byte[] bytes)
        {
            float num = BitConverter.ToSingle(bytes, 0);
            return num;
        }

        public static int bytesToInt(byte[] bytes)
        {
            int num = BitConverter.ToInt32(bytes, 0);
            return num;
        }

        public static long bytesToLong(byte[] bytes)
        {
            long num = BitConverter.ToInt64(bytes, 0);
            return num;
        }

        public static byte[] stringToBytes(string str)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(str);
            return bytes;
        }

        public static string bytesToString(byte[] bytes)
        {
            string str = Encoding.ASCII.GetString(bytes);
            return str;
        }

        public static long getFileLength(string filename)
        {
            FileStream fileStream = openFile(filename);
            long length = fileStream.Length;
            fileStream.Dispose(); fileStream.Close();
            return length;
        }


    }
}
