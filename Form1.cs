using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mid
{
    public partial class Form1 : Form
    {
        private List<Shape3D> shapes = new List<Shape3D>();
        private List<IRollable> rolls = new List<IRollable>();
        private ShapeType.Material m;
        private delegate bool CompareFunc(Shape3D a, Shape3D b);
        public Form1()
        {
            InitializeComponent();
            cbox_shape.SelectedIndex = 0;
            cbox_sort.SelectedIndex = 0;
            txt_den.Enabled = false;
        }



        private void cbox_shape_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = cbox_shape.SelectedItem.ToString();
            switch (s)
            {
                case "球":
                    lbl_prm1.Text = "半徑";
                    lbl_prm2.Visible = false;
                    txt_prm2.Visible = false;
                    break;
                case "立方體":
                    lbl_prm1.Text = "邊長";
                    lbl_prm2.Visible = false;
                    txt_prm2.Visible = false;
                    break;
                case "圓柱體":
                    lbl_prm1.Text = "半徑";
                    lbl_prm2.Visible = true;
                    lbl_prm2.Text = "高";
                    txt_prm2.Visible = true;
                    break;
                case "金字塔":
                    lbl_prm1.Text = "邊長";
                    lbl_prm2.Visible = true;
                    lbl_prm2.Text = "高";
                    txt_prm2.Visible = true;
                    break;
            }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string s = cbox_shape.SelectedItem.ToString();
            switch (s)
            {
                case "球":
                    shapes.Add(new Ball(double.Parse(txt_prm1.Text), m));
                    break;
                case "立方體":
                    shapes.Add(new Cube(double.Parse(txt_prm1.Text), m));
                    break;
                case "圓柱體":
                    shapes.Add(new Cylinder(double.Parse(txt_prm1.Text), double.Parse(txt_prm2.Text), m));
                    break;
                case "金字塔":
                    shapes.Add(new Pyramid(double.Parse(txt_prm1.Text), double.Parse(txt_prm2.Text), m));
                    break;
            }
            txt_amt.Text = Shape3D.Amount.ToString();
            txt_ball.Text = Ball.Amount.ToString();
            txt_cube.Text = Cube.Amount.ToString();
            txt_cyl.Text = Cylinder.Amount.ToString();
            txt_pyr.Text = Pyramid.Amount.ToString();
            ShowAllShapeInfo(txt_msg);
        }
        private void ShowAllShapeInfo(TextBox msg)
        {
            string info = "";
            foreach (var s in shapes)
                info += s.ShapeProperty() + "\r\n";
            msg.Text = info;
        }

        private void btn_sort_Click(object sender, EventArgs e)
        {
            string s = cbox_sort.SelectedItem.ToString();
            switch (s)
            {
                case "形狀":
                    if (rbt_asc.Checked) bubbleSort(CompareByShapeAsc); else bubbleSort(CompareByShapeDsc);
                    break;
                case "材質":
                    if (rbt_asc.Checked) bubbleSort(CompareByMatAsc); else bubbleSort(CompareByMatDsc);
                    break;
                case "體積":
                    if (rbt_asc.Checked) bubbleSort(CompareByVolAsc); else bubbleSort(CompareByVolDsc);
                    break;
                case "重量":
                    if (rbt_asc.Checked) bubbleSort(CompareByWeiAsc); else bubbleSort(CompareByWeiDsc);
                    break;
                default:
                    break;
            }
            ShowAllShapeInfo(txt_sort);
        }
        private bool CompareByShapeAsc(Shape3D a, Shape3D b) { if (a.Geo > b.Geo) return true; return false; }
        private bool CompareByShapeDsc(Shape3D a, Shape3D b) { if (a.Geo < b.Geo) return true; return false; }
        private bool CompareByMatAsc(Shape3D a, Shape3D b) { if (a.Material > b.Material) return true; return false; }
        private bool CompareByMatDsc(Shape3D a, Shape3D b) { if (a.Material < b.Material) return true; return false; }
        private bool CompareByVolAsc(Shape3D a, Shape3D b) { if (a.Volume() > b.Volume()) return true; return false; }
        private bool CompareByVolDsc(Shape3D a, Shape3D b) { if (a.Volume() < b.Volume()) return true; return false; }
        private bool CompareByWeiAsc(Shape3D a, Shape3D b) { if (a.Weight() > b.Weight()) return true; return false; }
        private bool CompareByWeiDsc(Shape3D a, Shape3D b) { if (a.Weight() < b.Weight()) return true; return false; }

        private void bubbleSort(CompareFunc cmp)
        {
            Shape3D tmp;
            for (int pass = 0; pass < shapes.Count; pass++)
            {
                for (int i = 0; i < shapes.Count - 1; i++)
                {
                    if (cmp(shapes[i], shapes[i + 1]))
                    {
                        tmp = shapes[i];
                        shapes[i] = shapes[i + 1];
                        shapes[i + 1] = tmp;
                    }
                }
            }
        }
        private void btn_roll_Click(object sender, EventArgs e)
        {
            rolls.Clear();
            IRollable r = null;
            foreach (var s in shapes)
            {
                r = s as IRollable;
                if (null != r)
                    rolls.Add(r);
            }
            rolls.Sort(CompareByDistance);
            ShowRollShapeInfo(txt_roll);
        }
        private int CompareByDistance(IRollable a, IRollable b)
        {
            if (a.Distance() > b.Distance()) return -1; return 1;
        }
        private void ShowRollShapeInfo(TextBox msg)
        {
            string info = "";
            foreach (var r in rolls)
                info += r.RollShapeProperty() + "\r\n";
            msg.Text = info;
        }

        private void btn_mat_Click(object sender, EventArgs e)
        {
            MaterialForm mForm = new MaterialForm();
            mForm.Show();
            mForm.matHandler += new MaterialForm.SetMaterialHandler(SetMaterialProperties);
        }

        private void SetMaterialProperties(object sender, SetMaterialEventArgs e)
        {
            m = e.MType;
            txt_mat.Text = MaterialTable.Name(e.MType);
            txt_den.Text = MaterialTable.Density(e.MType).ToString();
        }

    }
}
