using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMDB.Classes
{
    public class Attribute_
    {
        public string TableName;
        public string TableShortName;
        public long AA; //Address Attribute
        public string Name; //Name // N bytes 30 max
        public string DT; //Data Type  4 bytes
        public int Length; //Length //4 bytes
        public string KT; //Key Type 
        public int FK; //Foreing Key



        public Attribute_(string tablename,string tableshortname,string name,string dt,int length,string kt, int fk)
        {
            TableName = tablename; TableShortName = tableshortname;
            Name = name; DT = dt; Length = length; KT = kt; FK = fk;

            byte[] bAA = FileHandler.longToBytes(FileHandler.getFileLength(TableName));
            string auxName = Name.PadRight(30, '\0');
            byte[] bName = FileHandler.stringToBytes(auxName); //30 bytes
            byte[] bDT = DT == "INT" ? (FileHandler.intToBytes(1)) : DT == "FLOAT" ? (FileHandler.intToBytes(2)) : DT == "STRING" ? (FileHandler.intToBytes(3)) : throw new ExceptionError("An Error Has occurred", "DT error");
            byte[] bLength = FileHandler.intToBytes(Length);
            byte[] bKT = KT == "NA" ? (FileHandler.intToBytes(0)) : KT == "PK" ? (FileHandler.intToBytes(1)) : KT == "FK" ? (FileHandler.intToBytes(2)) : throw new ExceptionError("An Error has occurred", "KT error");
            byte[] bFK = FileHandler.intToBytes(FK);

            FileHandler.writeOnFile(TableName, bAA, FileHandler.getFileLength(TableName));
            FileHandler.writeOnFile(TableName, bName, FileHandler.getFileLength(TableName));
            FileHandler.writeOnFile(TableName, bDT, FileHandler.getFileLength(TableName));
            FileHandler.writeOnFile(TableName, bLength, FileHandler.getFileLength(TableName));
            FileHandler.writeOnFile(TableName, bKT, FileHandler.getFileLength(TableName));
            FileHandler.writeOnFile(TableName, bFK, FileHandler.getFileLength(TableName));
        }

        public Attribute_(string tablename,string tableshortname,long startIndex)
        {
            TableName = tablename; TableShortName = tableshortname;
            AA = startIndex;
            int tamAA = 8, tamName = 30, tamDT = 4, tamLength = 4, tamKT = 4;
            byte[] bAA = FileHandler.readFromFile(TableName, 8, AA);
            byte[] bName = FileHandler.readFromFile(TableName, 30, AA + tamAA);
            byte[] bDT = FileHandler.readFromFile(TableName,4, AA + tamAA + tamName);
            byte[] bLength = FileHandler.readFromFile(TableName, 4, AA + tamAA + tamName + tamDT);
            byte[] bKT = FileHandler.readFromFile(TableName, 4, AA + tamAA + tamName + tamDT + tamLength);
            byte[] bFK = FileHandler.readFromFile(TableName, 4, AA + tamAA + tamName + tamDT + tamLength + tamKT);

            Name = FileHandler.bytesToString(bName);
            int iDT = FileHandler.bytesToInt(bDT);
            DT = iDT == 1 ? "INT" : iDT == 2 ? "FLOAT" : iDT == 3 ? "STRING" : throw new ExceptionError("An Error has occurred", "DT get Data error");
            Length = FileHandler.bytesToInt(bLength);
            int iKT = FileHandler.bytesToInt(bKT);
            KT = iKT == 0 ? "NA" : iKT == 1 ? "PK" : iKT == 2 ? "FK" : throw new ExceptionError("An Error has occurred", "KT get Data error");
            FK = FileHandler.bytesToInt(bFK);

        }

    }
}
