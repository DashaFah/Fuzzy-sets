using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        bool butlock1 = false;
        bool butlock2 = false;
        bool unilock = false;
        static public float x;
        static public bool oper;

        public Form1()
        {
            InitializeComponent();
            if (unilock == false) textBox2.Enabled = false;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (unilock == false)
            {
                listBox5.Items.Add(textBox1.Text);
                Program.Uni();
                textBox1.Clear();
            }
            else {
                if (butlock1 == false)
                {
                    if (Program.U.Contains(textBox1.Text) == false)
                    {
                        string message = "Нет такого элемента";
                        var result = MessageBox.Show(message);
                    }
                    else
                    {
                        float FloatChance = Convert.ToSingle(textBox2.Text);
                        if (FloatChance < 0 || FloatChance > 1)
                        {
                            string message = "Неверная функция принадлежности. Введите число от 0 до 1(вкл)";
                            var result = MessageBox.Show(message);
                        }
                        else
                        {

                            listBox1.Items.Add(textBox1.Text);
                            listBox2.Items.Add(textBox2.Text);
                            Program.First();
                            textBox1.Clear();
                            textBox2.Clear();
                        }
                    }
                }
                else
                {
                    if (Program.U.Contains(textBox1.Text) == false)
                    {
                        string message = "Нет такого элемента";
                        var result = MessageBox.Show(message);
                    }
                    else
                    {
                        listBox3.Items.Add(textBox2.Text);
                        listBox4.Items.Add(textBox1.Text);
                        Program.Second();
                        textBox1.Clear();
                        textBox2.Clear();
                    } 
                }
            }
        }

        public void addnulls()
        {
            for (int i = 0; i < Program.U.Count; i++)
            {
                int index = listBox1.FindStringExact(Program.U[i]);
                if (index == ListBox.NoMatches)
                {
                    Program.Element el;
                    el.value = Program.U[i];
                    el.chance = 0;
                    Program.F.Add(el);
                }
            }
            for (int j = 0; j < Program.U.Count; j++)
            {
                int index = listBox4.FindStringExact(Program.U[j]);
                if (index == ListBox.NoMatches)
                {
                    Program.Element el;
                    el.value = Program.U[j];
                    el.chance = 0;
                    Program.S.Add(el);
                }
            }
        }


        private void uniLock_Click(object sender, EventArgs e)
        {
            uniLock.Enabled = false;
            unilock = true;
            textBox2.Enabled = true;
        }

        private void Lock1_Click(object sender, EventArgs e)
        {
            if (butlock1 == false)
            {
                butlock1 = true;
                Lock1.Enabled = false;
            }
        }

        private void Lock2_Click(object sender, EventArgs e)
        {
            if (butlock2 == false)
            {
                butlock2 = true;
                Lock2.Enabled = false;
                
            }
        }

        private void Dop_Click(object sender, EventArgs e)
        {
            if (butlock1 == true)
            {
                listBox4.Enabled = false;
                listBox3.Enabled = false;
                addnulls();
                Program.Dop();
                for (int i = 0; i < Program.Itogo.Count; i++)
                {
                    Program.Element el = Program.Itogo[i];
                    listBox7.Items.Add(el.value);
                    listBox8.Items.Add(el.chance);
                }
                Panel1_Paint(Panel1 , Program.F, listBox1);
                Panel1_Paint(Panel3, Program.Itogo, listBox7);
            }
            else
            {
                string message = "Ты тупой";
                var result = MessageBox.Show(message);
            }
        }

        private void Per_Click(object sender, EventArgs e)
        {
            if (butlock1 == true && butlock2 == true)
            {
                addnulls();
                Program.Per();
                for (int i = 0; i < Program.Itogo.Count; i++)
                {
                    Program.Element el = Program.Itogo[i];
                    if (el.chance != 0)
                    {
                        listBox7.Items.Add(el.value);
                        listBox8.Items.Add(el.chance);
                    }
                }
                Panel1_Paint(Panel1, Program.F, listBox1);
                Panel1_Paint(Panel2, Program.S, listBox4);
                Panel1_Paint(Panel3, Program.Itogo, listBox7);

            }
            else
            {
                string message = "Ты тупой";
                var result = MessageBox.Show(message);
            }
        }

        private void Ob_Click(object sender, EventArgs e)
        {
            if (butlock1 == true && butlock2 == true)
            {
                addnulls();
                Program.Ob();
                for (int i = 0; i < Program.Itogo.Count; i++)
                {
                    Program.Element el = Program.Itogo[i];
                    if (el.chance != 0)
                    {
                        listBox7.Items.Add(el.value);
                        listBox8.Items.Add(el.chance);
                    }
                }
                Panel1_Paint(Panel1, Program.F, listBox1);
                Panel1_Paint(Panel2, Program.S, listBox4);
                Panel1_Paint(Panel3, Program.Itogo, listBox7);
            }
            else
            {
                string message = "Ты тупой";
                var result = MessageBox.Show(message);
            }
        }

        private void Step_Click(object sender, EventArgs e)
        {
            if (butlock1 == true)
            {
                addnulls();
                listBox4.Enabled = false;
                listBox3.Enabled = false;
                bool oper = true;
                Form2 form = new Form2();
                form.ShowDialog();
                Program.Step(x);
                for (int i = 0; i < Program.Itogo.Count; i++)
                {
                    Program.Element el = Program.Itogo[i];
                    if (el.chance != 0)
                    {
                        listBox7.Items.Add(el.value);
                        listBox8.Items.Add(el.chance);
                    }
                }
                Panel1_Paint(Panel1, Program.F, listBox1);
                Panel1_Paint(Panel3, Program.Itogo, listBox7);
            }
            else
            {
                string message = "Ты тупой";
                var result = MessageBox.Show(message);
            }
        }

        private void UmnCh_Click(object sender, EventArgs e)
        {
            if (butlock1 == true)
            {
                listBox4.Enabled = false;
                listBox3.Enabled = false;
                addnulls();
                bool oper = false;
                Form2 form = new Form2();
                form.ShowDialog();
                bool cando = Program.UmnCh(x);
                if (cando)
                {
                    for (int i = 0; i < Program.Itogo.Count; i++)
                    {
                        Program.Element el = Program.Itogo[i];
                        if (el.chance != 0)
                        {
                            listBox7.Items.Add(el.value);
                            listBox8.Items.Add(el.chance);
                        }
                    }
                    Panel1_Paint(Panel1, Program.F, listBox1);
                    Panel1_Paint(Panel3, Program.Itogo, listBox7);
                }
            }
            else
            {
                string message = "Ты тупой";
                var result = MessageBox.Show(message);
            }
        }

        private void Umn_Click(object sender, EventArgs e)
        {
            if (butlock1 == true && butlock2 == true)
            {
                Program.Umn();
                    for (int i = 0; i < Program.Itogo.Count; i++)
                    {
                        Program.Element el = Program.Itogo[i];
                        if (el.chance != 0)
                        {
                            listBox7.Items.Add(el.value);
                            listBox8.Items.Add(el.chance);
                        }
                    }
                Panel2.Enabled = false;
                Panel1_Paint(Panel1, Program.F, listBox1);
                Panel1_Paint(Panel3, Program.Itogo, listBox7);
            }
            else
            {
                string message = "Ты тупой";
                var result = MessageBox.Show(message);
            }
        }

        private void Panel1_Paint(Panel panel, List <Program.Element> L, ListBox B)
        {
            Graphics g = panel.CreateGraphics();
            //Panel1.BackColor = Color.White;
            g.TranslateTransform(20, (panel.Height-20));
            Pen pen = new Pen(Color.DarkRed, 0.5f);
            Pen penCO = new Pen(Color.Green, 1f);
            g.DrawLine(penCO, new Point(-5000, 0), new Point(5000, 0));
            g.DrawLine(penCO, new Point(0, -5000), new Point(0, 5000));
            List<Point> p = new List<Point>();
            //Point poss0 = new Point(0, 0);
            //p.Add(poss0);
                //Program.Element el = Program.F[i];
                for (int j = 0; j < Program.U.Count; j++)
                {
                    int StepX = (panel.Width - 30) / Program.U.Count;
                    int StepY = (panel.Height-30) / 10;
                    int index = B.FindStringExact(Program.U[j]);
                    if (index == ListBox.NoMatches)
                    {
                        int y = 0;
                        int x = j * StepX;
                        DrawStringY(g, 0, y); //Посмотрим, что будет дальше, а вообще, надо определять, показывать ноль или один
                        DrawStringX(g, Program.U[j], x);
                        Point poss = new Point(x, y);
                        p.Add(poss);
                    }
                    else
                    {
                        Program.Element el = L[index];
                        float floaty = el.chance * -10 * StepY;
                        int y = Convert.ToInt32(floaty);
                        int x = j * StepX;
                        DrawStringY(g, el.chance, y);
                        DrawStringX(g, Program.U[j], x);
                        Point poss = new Point(x, y);
                        p.Add(poss);
                    }
                }                
            
            Point[] parr = p.ToArray();
            g.DrawCurve(pen, parr, 0.0f);
        }


        public void DrawStringY(Graphics g, float String, float y)
        {
            string StringString = Convert.ToString(String); 
            string drawString = StringString;
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 7);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            float X = -17;
            float Y = y;
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            g.DrawString(drawString, drawFont, drawBrush, X, Y, drawFormat);
        }

        public void DrawStringX(Graphics g, string String, float x)
        {
            string drawString = String;
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 7);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            float X = x;
            float Y = 5;
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            g.DrawString(drawString, drawFont, drawBrush, X, Y, drawFormat);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }

            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            if (e.KeyChar == ',')
            {
                if (textBox1.Text.IndexOf(',') != -1)
                {
                    // запятая уже есть в поле редактирования
                    e.Handled = true;
                }
                return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    button1.Focus();
                    button1_Click(sender, e);
                }
                return;
            }

            e.Handled = true;
        }

    }

}


