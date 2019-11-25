using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMDB.Classes;

namespace SMDB
{
    public class Query
    {
       
        public List<string> Columns { get; set; }
        public Table Table { get; set; }
        public string Column { get; set; }
        public string DT { get; set; }
        public string Operation { get; set; }
        public dynamic Value { get; set; }
        public bool isWhere;

    }
}
