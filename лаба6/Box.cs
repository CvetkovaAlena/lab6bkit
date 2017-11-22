using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
namespace лаба6
{
    class Box
    {
        int width;
        int height;
        int lenght;
        public Box(int a, int b, int c)
        {
            width = a;
            height = b;
            lenght = c;
        }
        [AttributeClass("Details for width")]
        public int propertywidth
        {
            get { return width; }
            set { this.width = value; }
        }
        [AttributeClass("Details for height")]
        public int propertyheight
        {
            get { return height; }
            set { this.height = value; }
        }
        public int propertylenght
        {
            get { return lenght; }
            set { this.lenght = value; }
        }
        public int Volume()
        {
            return this.width * this.height * this.lenght;
        }
        public int AreaOfSurface()
        {
            return 2 * (this.width * this.height + this.lenght * this.height +
            this.width * this.lenght);
        }
    }
}