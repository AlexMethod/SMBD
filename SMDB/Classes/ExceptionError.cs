using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMDB.Classes
{
    public class ExceptionError : Exception
    {
        public string Message;
        public string Type;

        public ExceptionError(string message,string type)
        {
            Message = message; Type = type;
        }

        public void showMessage()
        {
            System.Windows.Forms.MessageBox.Show(Message, Type, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }
}
