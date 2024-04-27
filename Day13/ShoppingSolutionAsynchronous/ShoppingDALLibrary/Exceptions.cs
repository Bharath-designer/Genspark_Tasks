using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class IdAlreadyFoundException: Exception
    {
        public IdAlreadyFoundException(string msg): base(msg) { }
    }

    public class IdNotFoundException : Exception
    {
        public IdNotFoundException(string msg) : base(msg) { }
    }
}
