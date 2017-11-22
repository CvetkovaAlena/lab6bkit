using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace лаба6
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited
    = false)]
    public class AttributeClass : Attribute
    {
        public AttributeClass() { }
        public AttributeClass(string str)
        {
            Description = str;
        }
        public string Description
        {
            set;
            get;
        }
    }
}