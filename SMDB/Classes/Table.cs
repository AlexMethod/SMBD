using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMDB.Classes
{
    class Table
    {
        public int IDTable = 0;
        public List<Attribute> attributes = new List<Attribute>();
        public List<Registry> registries = new List<Registry>();
    }
}
