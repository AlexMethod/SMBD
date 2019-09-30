using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMDB.Classes
{
    public class Attribute
    {
        public long AA = -1; //Attribute Address
        public string Name = ""; //Name
        public char DT = 'N'; //Data Type
        public int Length = 0; //Length
        public char[] KT = new char[2] { 'N','A' }; //Key Type
        public int FK = 0; //Foreing Key
        public long NAA = -1; //Next Attribute Address

    }
}
