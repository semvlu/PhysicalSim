using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid
{
    class Cylinder:Shape3D,IRollable
    {
        new private static int amount;
        private double radius;
        private double height;

        public Cylinder() : base() { geo = ShapeType.Geo.CYLINDER; radius = 0;height=0; amount++; }
        public Cylinder(double r, double h,ShapeType.Material m) : base(m) { geo = ShapeType.Geo.CYLINDER; radius = r; height=h;amount++; }
        new public static int Amount { get { return amount; } }
        public double Radius { get { return radius; } set { if (value < 0) radius = 0; else radius = value; } }
        public double Height { get { return height; } set { if (value < 0) height = 0; else height = value; } }

        public override double Volume() { return height * Math.PI * Math.Pow(radius, 2); }
        public override string ShapeProperty()
        {
            string s = string.Format("{0,8}", "Cylinder");
            s += "\t";
            s += string.Format("{0,8:F2}", radius);
            s += "\t";
            s += string.Format("{0,8:F2}", height);
            s += "\t";
            s += Property();
            return s;
        }

        public double Distance() { return radius * height; }
        public string RollShapeProperty()
        {
            return ShapeProperty() + string.Format("{0,8:F2}", Distance());
        }
    }
}
