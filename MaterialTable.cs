using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid
{
    public class Element
    {
        public ShapeType.Material Material { get; set; }    
        public string Name { get; set; }    
        public double Density { get; set; }
        public Element() { }
        public Element(ShapeType.Material m, string n, double d) 
        {
            Material = m;
            Name = n;
            Density = d;
        }
    }
    public static class MaterialTable
    {
        public static Element[] elements = {new Element(ShapeType.Material.Al, "鋁", 2.7),
                                            new Element(ShapeType.Material.Fe, "鐵", 7.87),
                                            new Element(ShapeType.Material.Pb, "鉛", 11.3)};
        public static ShapeType.Material Type(string n)
        {
            foreach(var e in elements)
            {
                if(e.Name==n)
                    return e.Material;
            }
            return ShapeType.Material.UNKNOWN;
        }

        public static double Density(string n)
        {
            foreach (var e in elements)
            {
                if (e.Name == n)
                    return e.Density;
            }
            return 0;
        }
        public static double Density(ShapeType.Material m)
        {
            foreach (var e in elements)
            {
                if (e.Material == m)
                    return e.Density;
            }
            return 0;
        }
        public static string Name(ShapeType.Material m)
        {
            foreach (var e in elements)
            {
                if(e.Material==m)
                    return e.Name;
            }
            return "未知";
        }
    }
}
