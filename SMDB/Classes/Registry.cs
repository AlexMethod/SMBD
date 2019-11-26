using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMDB.Classes
{
    public class Registry
    {
        public int Status;
        public int TamRegistry; //Tam registry
        public long AR; //Address registry
        public List<Data> Values;

        public Registry(string TableName,List<Attribute_> attributes, long startIndex)
        {
            Values = new List<Data>();

            byte[] bytesAR = FileHandler.readFromFile(TableName, 8, startIndex);
            AR = FileHandler.bytesToLong(bytesAR);

            long index = startIndex + 8;
            
            foreach(Attribute_ att in attributes)
            {
                byte[] bytes = FileHandler.readFromFile(TableName, att.Length, index);
                string DT = att.DT;
                if (DT == "INT")
                {
                    int Value = FileHandler.bytesToInt(bytes);
                    dynamic dynamicValue = Value;
                    Data data = new Data(Value, att);
                    Values.Add(data);
                    
                }
                else if (DT == "FLOAT")
                {
                    float Value = FileHandler.bytesToFloat(bytes);
                    dynamic dynamicValue = Value;
                    Data data = new Data(Value, att);
                    Values.Add(data);
                }
                else if (DT == "STRING")
                {
                    string Value = FileHandler.bytesToString(bytes);
                    dynamic dynamicValue = Value;
                    Data data = new Data(Value, att);
                    Values.Add(data);
                }
                index += att.Length;
            }

            long dirStatus = startIndex + 8 + attributes.Sum(x => x.Length);
            byte[] bytesStats = FileHandler.readFromFile(TableName, 4, dirStatus);
            Status = FileHandler.bytesToInt(bytesStats);
        }

        public Registry(string TableName,List<Data> datas)
        {
            Values = datas;

            //La direccion del registro
            long TamFile = FileHandler.getFileLength(TableName);
            byte[] Bytes = FileHandler.longToBytes(TamFile);
            FileHandler.writeOnFile(TableName, Bytes, TamFile);

            //Los datos propios del registro
            foreach (Data data in datas)
            {
                long tamFile = FileHandler.getFileLength(TableName);
                string DT = data.Attribute.DT;
                

                if (DT == "INT") {
                    dynamic dynamicValue = data.Value;
                    int Value = Convert.ToInt32(dynamicValue);
                    byte[] bytes = FileHandler.intToBytes(Value);
                    FileHandler.writeOnFile(TableName, bytes, tamFile);
                }
                else if (DT == "FLOAT")
                {
                    dynamic dynamicValue = data.Value;
                    float Value = Convert.ToSingle(dynamicValue);
                    byte[] bytes = FileHandler.floatToBytes(Value);
                    FileHandler.writeOnFile(TableName, bytes, tamFile);
                }
                else if (DT == "STRING")
                {
                    dynamic dynamicValue = data.Value;
                    string Value = dynamicValue;
                    string auxValue = Value.PadRight(data.Attribute.Length, '\0');
                    
                    byte[] bytes = FileHandler.stringToBytes(auxValue);
                    FileHandler.writeOnFile(TableName, bytes, tamFile);
                }
            }

            //El status del registro, al inicio es uno
            byte[] BytesStats = FileHandler.intToBytes(1);
            long TamFileAfterData = FileHandler.getFileLength(TableName);
            FileHandler.writeOnFile(TableName, BytesStats, TamFileAfterData);
        }

        public void Delete(string TableName)
        {
            long DirStatus = AR + 8 + Values.Sum(x => x.Attribute.Length);
            byte[] statusCanceled = FileHandler.intToBytes(0);
            FileHandler.writeOnFile(TableName, statusCanceled, DirStatus);
        }

        public void Update(string TableName,List<Data> datas)
        {
            long startIndex = AR + 8;
            long index = startIndex;
            //Los datos propios del registro
            foreach (Data data in datas)
            {
                string DT = data.Attribute.DT;

                if (DT == "INT")
                {
                    dynamic dynamicValue = data.Value;
                    int Value = Convert.ToInt32(dynamicValue);
                    byte[] bytes = FileHandler.intToBytes(Value);
                    FileHandler.writeOnFile(TableName, bytes, index);
                }
                else if (DT == "FLOAT")
                {
                    dynamic dynamicValue = data.Value;
                    float Value = Convert.ToSingle(dynamicValue);
                    byte[] bytes = FileHandler.floatToBytes(Value);
                    FileHandler.writeOnFile(TableName, bytes, index);
                }
                else if (DT == "STRING")
                {
                    dynamic dynamicValue = data.Value;
                    string Value = dynamicValue;
                    string auxValue = Value.PadRight(data.Attribute.Length, '\0');

                    byte[] bytes = FileHandler.stringToBytes(auxValue);
                    FileHandler.writeOnFile(TableName, bytes, index);
                }

                index += data.Attribute.Length;
            }
        }
    }
}
