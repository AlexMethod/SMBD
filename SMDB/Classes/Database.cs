using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMDB.Classes
{
    public class Database
    {
        public string Name = "";
        public string Path = "";
        public List<Table> tables = new List<Table>();

        public Database(string name,string path, bool isNew = true)
        {
            Name = name; Path = path;
            if (isNew)
            {
                FileHandler.createDirectory(path);
                string metadata = path + "\\" + ".db";
                FileHandler.createFile(metadata);
            }
            else
            {
                SetTables();
            }
        }

        public void Delete()
        {
            if (isDB())
            {
                FileHandler.deleteDirectory(Path);
            }
        }

        public void Rename(string newName)
        {
            if (isDB() && newName!= null && newName.Length > 0 )
            {
                string origin = Path;
                string destiny = Path.Replace(Name, newName);
                string[] files = FileHandler.getFilesDirectory(Path);
                string[] newFiles = new string[files.Length];

                for (int i = 0; i < files.Length; i++)
                {
                    string newFile = files[i].Replace(Name, newName);
                    newFiles[i] = newFile;
                }
                FileHandler.deleteDirectory(origin);
                FileHandler.createDirectory(destiny);
                FileHandler.createFiles(newFiles);

                Name = newName;
                Path = destiny;
                SetTables();
            }
        }

        public void SetTables()
        {
            tables = new List<Table>();
            string[] files = FileHandler.getFilesDirectory(Path);
            string[] stringTables = Array.FindAll(files, x => x.Split('.')[1] == "dbtable");
            for(
                
                int i = 0; i < stringTables.Length; i++)
            {
                int indexCurrentTable = FileHandler.bytesToInt(FileHandler.readFromFile(stringTables[i],4,0));
                Table table = new Table(stringTables[i], indexCurrentTable, false);
                tables.Add(table);
            }
        }

        public bool isDB()
        {
            bool response = false;
            string[] files = FileHandler.getFilesDirectory(Path);
            foreach (string file in files)
            {
                string filename = file.Split('.')[1];
                if (filename == "db")
                {
                    response = true;
                    break;
                }
            }
            return response;
        }

        public int GetNextIDTable()
        {
            int Max = tables.Count > 0 ? tables.Max(x => x.IDTable) + 1 : 0;
            return Max;
        }
    }
}
