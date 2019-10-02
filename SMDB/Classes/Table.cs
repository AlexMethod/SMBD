using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMDB.Classes
{
    public class Table
    {
        public string Name = "";
        public int IDTable = 0;
        public List<Attribute> attributes = new List<Attribute>();
        public List<Registry> registries = new List<Registry>();

        public Table(string name, int idTable,bool isNew = true)
        {
            Name = name; IDTable = idTable;
            if (isNew)
            {
                FileHandler.createFile(name);
                byte[] bytes = FileHandler.intToBytes(idTable);
                FileHandler.writeOnFile(name, bytes, 0);
            }
            
        }

        public void Rename(string newName)
        {
            FileHandler.fileMove(Name, newName);
            Name = newName;
        }

        public void Delete()
        {
            FileHandler.deleteFile(Name);
        }

    }
}
