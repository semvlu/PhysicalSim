using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid
{
    class Pyramid:Shape3D
    {
        new private static int amount;
        private double side;
        private double height;

        public Pyramid() : base() { geo = ShapeType.Geo.PYRAMID; side = 0; height = 0; amount++; }
        public Pyramid(double s, double h, ShapeType.Material m) : base(m) { geo = ShapeType.Geo.PYRAMID; side = s; height = h; amount++; }
        new public static int Amount { get { return amount; } }
        public double Side { get { return side; } set { if (value < 0) side = 0; else side = value; } }
        public double Height { get { return height; } set { if (value < 0) height = 0; else height = value; } }

        public override double Volume() { return 1.0/3 * height * Math.Pow(side, 2); }
        public override string ShapeProperty()
        {
            string s = string.Format("{0,8}", "Pyramid");
            s += "\t";
            s += string.Format("{0,8:F2}", side);
            s += "\t";
            s += string.Format("{0,8:F2}", height);
            s += "\t";
            s += Property();
            return s;
        }
    }
}
