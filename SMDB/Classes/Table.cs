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
            ShortName = Name.Split('\\')[Name.Split('\\').Length - 1].Split('.')[0];
        }

        public void Delete()
        {
            FileHandler.deleteFile(Name);
        }

        public List<Attribute_> GetAttributes()
        {
            attributes = new List<Attribute_>();
            long tamFile = FileHandler.getFileLength(Name);
            
            int index = 4;
            var operation = ((tamFile - 4) / Attribute_.TamAttribute);
            int cantAttributes = unchecked(operation == (int)operation) ? (int)(operation) : 0;

            for (int i = 0; i < cantAttributes; i++)
            {
                Attribute_ attribute = new Attribute_(Name, ShortName, index);
                if(attribute.Status == 1) attributes.Add(attribute);
                index += Attribute_.TamAttribute;
            }
            return attributes;
        }

        public long GetRewritableAA()
        {
            List<Attribute_> rewritableAttr = new List<Attribute_>();
            long tamFile = FileHandler.getFileLength(Name);

            int index = 4;
            var operation = ((tamFile - 4) / Attribute_.TamAttribute);
            int cantAttributes = unchecked(operation == (int)operation) ? (int)(operation) : 0;

            for (int i = 0; i < cantAttributes; i++)
            {
                Attribute_ attribute = new Attribute_(Name, ShortName, index);
                if (attribute.Status == 0) rewritableAttr.Add(attribute);
                index += Attribute_.TamAttribute;
            }
            return rewritableAttr.Count() > 0 ? rewritableAttr.First().AA : 0;
        }

        public void SaveRecords()
        {

        }

    }
}
