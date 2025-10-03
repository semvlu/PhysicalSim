using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid
{
    public static class ShapeType
    {
        public enum Geo { UNKNOWN=-1,BALL=0,CUBE,CYLINDER,PYRAMID};
        public enum Material { UNKNOWN=-1,Al=0,Fe,Pb};
    }
    abstract class Shape3D
    {
        protected static int amount;
        protected ShapeType.Geo geo;
        protected ShapeType.Material mat;
        public Shape3D() { amount++; mat=ShapeType.Material.UNKNOWN; }
        public Shape3D(ShapeType.Material m) { amount++; mat=m; }
        public static int Amount { get { return amount; } }
        public ShapeType.Geo Geo { get { return geo; } }
        public ShapeType.Material Material { get { return mat; } }
        public double Density() { return MaterialTable.Density(mat);}
        public abstract double Volume();
        public double Weight() { return Density()*Volume(); }
        public abstract string ShapeProperty();
        public string Property()
        {
            string s = string.Format("{0,8:F2}", Density());
            s+= "\t";
            s+= string.Format("{0,8:F2}", Volume());
            s+="\t";
            s += string.Format("{0,8:F2}", Weight());
            return s;
        }
    }
}
