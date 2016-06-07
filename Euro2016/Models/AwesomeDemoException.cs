using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Euro2016.Models
{
    public class AwesomeDemoException : Exception
    {
        public AwesomeDemoException()
        {
        }

        public AwesomeDemoException(string message)
            : base(message)
        {
        }
    }
}