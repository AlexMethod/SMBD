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
        public string ShortName = "";
        public int IDTable = 0;
        public List<Attribute_> attributes = new List<Attribute_>();
        public List<Registry> registries = new List<Registry>();

        public Table(string name, int idTable,bool isNew = true)
        {
            Name = name; IDTable = idTable;
            ShortName = Name.Split('\\')[Name.Split('\\').Length - 1].Split('.')[0];
            if (isNew)
            {
                FileHandler.createFile(name);
                byte[] bytes = FileHandler.intToBytes(idTable);
                FileHandler.writeOnFile(name, bytes, 0);
            }
            else
            {
                GetAttributes();
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

        public void GetAttributes()
        {
            long tamFile = FileHandler.getFileLength(Name);
            int tamAttribute = 54;
            int index = 4;
            var operation = ((tamFile - 4) / 54);
            int cantAttributes = unchecked(operation == (int)operation) ? (int)(operation) : 0;

            for (int i = 0; i < cantAttributes; i++)
            {
                Attribute_ attribute = new Attribute_(Name, ShortName, index);
                attributes.Add(attribute);
                index += tamAttribute;
            }

        }

    }
}
