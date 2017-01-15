using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetCustomExceptions
{
    class MyCustomException<T> : ApplicationException
    {
        public MyCustomException(string message) : base(message)
        {

        }

        public MyCustomException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public bool DisplayStuf(int a, int b)
        {

            return a > b ? true : false;
        }

        public T MyExcProp { get; set; }
        private T myExcProp;

    }
}
