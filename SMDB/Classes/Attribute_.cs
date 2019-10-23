using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMDB.Classes
{
    public class Attribute_
    {
        public static int TamAttribute = 58;
        public string TableName;
        public string TableShortName;
        public long AA; //Address Attribute 8 bytes
        public string Name; //Name // N bytes 30 max
        public string DT; //Data Type  4 bytes
        public int Length; //Length //4 bytes
        public string KT; //Key Type 4 bytes
        public int FK; //Foreing Key 4 bytes
        public int Status; // 4 bytes



        public Attribute_(string tablename,string tableshortname,string name,string dt,int length,string kt, int fk,long RewritableAA=0)
        {
            
            TableName = tablename; TableShortName = tableshortname;
            Name = name; DT = dt; Length = length; KT = kt; FK = fk;
            AA = RewritableAA == 0 ? FileHandler.getFileLength(TableName) : RewritableAA;

            byte[] bAA = FileHandler.longToBytes(AA);
            string auxName = Name.PadRight(30, '\0');
            byte[] bName = FileHandler.stringToBytes(auxName); //30 bytes
            byte[] bDT = DT == "INT" ? (FileHandler.intToBytes(1)) : DT == "FLOAT" ? (FileHandler.intToBytes(2)) : DT == "STRING" ? (FileHandler.intToBytes(3)) : throw new ExceptionError("An Error Has occurred", "DT error");
            byte[] bLength = FileHandler.intToBytes(Length);
            byte[] bKT = KT == "NA" ? (FileHandler.intToBytes(0)) : KT == "PK" ? (FileHandler.intToBytes(1)) : KT == "FK" ? (FileHandler.intToBytes(2)) : throw new ExceptionError("An Error has occurred", "KT error");
            byte[] bFK = FileHandler.intToBytes(FK);
            byte[] bStatus = FileHandler.intToBytes(1);

            FileHandler.writeOnFile(TableName, bAA, AA);
            FileHandler.writeOnFile(TableName, bName, AA + 8);
            FileHandler.writeOnFile(TableName, bDT, AA + 38);
            FileHandler.writeOnFile(TableName, bLength, AA + 42);
            FileHandler.writeOnFile(TableName, bKT, AA + 46);
            FileHandler.writeOnFile(TableName, bFK, AA + 50);
            FileHandler.writeOnFile(TableName, bStatus, AA + 54);
        }

        public Attribute_(string tablename,string tableshortname,long startIndex)
        {
            TableName = tablename; TableShortName = tableshortname;
            AA = startIndex;
            byte[] bAA = FileHandler.readFromFile(TableName, 8, AA);
            byte[] bName = FileHandler.readFromFile(TableName, 30, AA + 8);
            byte[] bDT = FileHandler.readFromFile(TableName,4, AA + 38);
            byte[] bLength = FileHandler.readFromFile(TableName, 4, AA + 42);
            byte[] bKT = FileHandler.readFromFile(TableName, 4, AA + 46);
            byte[] bFK = FileHandler.readFromFile(TableName, 4, AA + 50);
            byte[] bStatus = FileHandler.readFromFile(TableName, 4, AA + 54);

            Name = FileHandler.bytesToString(bName).Replace("\0","");
            int iDT = FileHandler.bytesToInt(bDT);
            DT = iDT == 1 ? "INT" : iDT == 2 ? "FLOAT" : iDT == 3 ? "STRING" : throw new ExceptionError("An Error has occurred", "DT get Data error");
            Length = FileHandler.bytesToInt(bLength);
            int iKT = FileHandler.bytesToInt(bKT);
            KT = iKT == 0 ? "NA" : iKT == 1 ? "PK" : iKT == 2 ? "FK" : throw new ExceptionError("An Error has occurred", "KT get Data error");
            FK = FileHandler.bytesToInt(bFK);
            Status = FileHandler.bytesToInt(bStatus);

        }

        public void Delete()
        {
            byte[] cancelado = FileHandler.intToBytes(0);
            FileHandler.writeOnFile(TableName, cancelado, AA + 54);

        }

    }
}
