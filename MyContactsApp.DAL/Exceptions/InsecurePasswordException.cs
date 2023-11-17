using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactsApp.DAL.Exceptions
{
    public class InsecurePasswordException : Exception
    {
        public InsecurePasswordException(string message) : base(message)
        {
        }
    }
}
