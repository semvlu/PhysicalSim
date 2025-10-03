using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid
{
    class Cube:Shape3D
    {
        new private static int amount;
        private double side;

        public Cube() : base() { geo = ShapeType.Geo.CUBE; side = 0; amount++; }
        public Cube(double s, ShapeType.Material m) : base(m) { geo = ShapeType.Geo.CUBE; side = s; amount++; }
        new public static int Amount { get { return amount; } }
        public double Side { get { return side; } set { if (value < 0) side = 0; else side = value; } }
        public override double Volume() { return Math.Pow(side, 3); }
        public override string ShapeProperty()
        {
            string s = string.Format("{0,8}", "Cube");
            s += "\t";
            s += string.Format("{0,8:F2}", side);
            s += "\t";
            s += string.Format("{0,8}", "");
            s += "\t";
            s += Property();
            return s;
        }
    }
}
