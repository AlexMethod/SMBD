using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMDB.Classes
{
    public class Data
    {
        public dynamic Value;
        public Attribute_ Attribute;

        public Data(dynamic value, Attribute_ attribute)
        {
            Value = value;
            Attribute = attribute;
        }
    }
}
