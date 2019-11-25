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
        public long DirRegistros;
        public List<Attribute_> attributes = new List<Attribute_>();
        public List<Registry> registries = new List<Registry>();

        public Table(string name, int idTable,bool isNew = true)
        {
            Name = name; IDTable = idTable; DirRegistros = -1;
            ShortName = Name.Split('\\')[Name.Split('\\').Length - 1].Split('.')[0];
            if (isNew)
            {
                FileHandler.createFile(name);
                byte[] bytes = FileHandler.intToBytes(idTable);
                byte[] byteslong = FileHandler.longToBytes(-1);
                FileHandler.writeOnFile(name, bytes, 0);
                FileHandler.writeOnFile(name, byteslong, 4);
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

            long dirRecords = GetDirRecords();
            int index = 12;
            long tamAttributes = dirRecords != -1 ? dirRecords : tamFile;
            var operation = ((tamAttributes - index) / Attribute_.TamAttribute);
            int cantAttributes = unchecked(operation == (int)operation) ? (int)(operation) : 0;

            for (int i = 0; i < cantAttributes; i++)
            {
                Attribute_ attribute = new Attribute_(Name, ShortName, index);
                if(attribute.Status == 1) attributes.Add(attribute);
                index += Attribute_.TamAttribute;
            }
            return attributes;
        }

        public List<Registry> GetRegistries()
        {
            List<Registry> registries = new List<Registry>();

            //
            if (DirRegistros != -1)
            {
                long tamFile = FileHandler.getFileLength(Name);
                //DirRegistros = tamFile;
                int tamRegistry = 8 + attributes.Sum(sum => sum.Length) + 4;
                long tamRegistries = tamFile - DirRegistros;
                var operation = ((tamRegistries) / tamRegistry);
                int cantRegistries = unchecked(operation == (int)operation) ? (int)(operation) : 0;
                long index = DirRegistros;

                for (int i = 0; i < cantRegistries; i++)
                {
                    Registry registry = new Registry(Name, attributes, index);
                    if (registry.Status == 1) registries.Add(registry);
                    index += tamRegistry;
                }
            }


            return registries;
        }

        public long GetRewritableAA()
        {
            List<Attribute_> rewritableAttr = new List<Attribute_>();
            long tamFile = FileHandler.getFileLength(Name);

            long dirRecords = GetDirRecords();
            int index = 12;
            long tamAttributes = dirRecords != -1 ? dirRecords - index : tamFile;
            var operation = ((tamAttributes - index) / Attribute_.TamAttribute);
            int cantAttributes = unchecked(operation == (int)operation) ? (int)(operation) : 0;

            for (int i = 0; i < cantAttributes; i++)
            {
                Attribute_ attribute = new Attribute_(Name, ShortName, index);
                if (attribute.Status == 0) rewritableAttr.Add(attribute);
                index += Attribute_.TamAttribute;
            }
            return rewritableAttr.Count() > 0 ? rewritableAttr.First().AA : 0;
        }

        public long GetDirRecords()
        {
            long result = 0;

            byte[] bytes = FileHandler.readFromFile(Name, 8, 4);
            result = FileHandler.bytesToLong(bytes);
            DirRegistros = result;
            return result;
        }

        public long DirRegistry
        {
            get
            {
                return DirRegistros;
            }
            set
            {
                DirRegistros = value;
                byte[] bytes = FileHandler.longToBytes(value);
                FileHandler.writeOnFile(Name, bytes, 4);
            }
        }

    }
}
