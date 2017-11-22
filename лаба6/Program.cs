
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace лаба6
{
    class Program
    {
        delegate void AreaOrPerimeter(int a, int b, string units);
        static void Area(int width, int height, string units)
        {
            Console.WriteLine("Площадь прямоугольника: " + width * height + " (" +
            units + ")^2");
        }
        static void FindAreaOrPerimeter(int a, int b, string un,
        AreaOrPerimeter p)
        {
            p(a, b, un);
        }
        static void FindAreaOrPerimeterAction(int a, int b, string un,
        Action<int, int, string> f)
        {
            f(a, b, un);
        }
        public static bool GetPropertyAttribute(PropertyInfo checkType, Type
        attributeType, out object attribute)
        {
            bool Result = false;
            attribute = null;
            var isAttribute = checkType.GetCustomAttributes(attributeType,
            false);
            if (isAttribute.Length > 0)
            {
                Result = true;
                attribute = isAttribute[0];
            }
            return Result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Использование делегатов");
            FindAreaOrPerimeter(2, 4, "м", Area);
            FindAreaOrPerimeter(2, 4, "м", (int a, int b, string un) => {
                Console.WriteLine("Периметр прямоугольника: " + ((a + b) * 2) + ' ' + un);
            });
            Console.WriteLine("\n\nUsing of action");
            FindAreaOrPerimeterAction(3, 8, "cm", Area);
            FindAreaOrPerimeterAction(3, 8, "cm", (int a, int b, string un) =>
            { Console.WriteLine("Периметр прямоугольника: " + ((a + b) * 2) + ' ' + un); });
            Type objType = typeof(Box);
            Console.WriteLine("\n\nИнформация о классе:\n");
            Console.WriteLine("Конструкторы:");
            foreach (var constr in objType.GetConstructors())
                Console.WriteLine(constr);
            Console.WriteLine("\nМетоды:");
            foreach (var meth in objType.GetMethods())
                Console.WriteLine(meth);
            Console.WriteLine("\nСвойства:");
            foreach (var prop in objType.GetProperties())
                Console.WriteLine(prop);
            Console.WriteLine("\nСвойства, помеченные атрибутом:");
            foreach (var prop in objType.GetProperties())
            {
                object attrObj;
                if (GetPropertyAttribute(prop, typeof(AttributeClass), out
                attrObj))
                {
                    AttributeClass attr = attrObj as AttributeClass;
                    Console.WriteLine(prop.Name + " - " + attr.Description);
                }
            }
            Console.WriteLine("\nRun method");
            Console.WriteLine("Write method name:");
            string methodName = Console.ReadLine();
            Box box1 = new Box(1, 2, 3);
            Type t = box1.GetType();
            object[] parameters = new object[] { };
            Console.WriteLine(t.InvokeMember(methodName,
            BindingFlags.InvokeMethod, null, box1, parameters));
            Console.ReadLine();
        }
    }
}
