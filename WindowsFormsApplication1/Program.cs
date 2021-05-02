using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        public static Form1 f1; //Создаем экземпляр класса Form1
 
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(f1 = new Form1());

        }


        public struct Element
        {
            public string value;
            public float chance;
        };

        static public List<string> U = new List<string>();
        static float FloatTextBox2;
        static public List<Element> S = new List<Element>();
        static public List<Element> F = new List<Element>();
        static public List<Element> Itogo = new List<Element>();


        static public void Uni()
            {
                U.Add(f1.textBox1.Text);
                U.Sort();
            }

            static public void First()
            {
                Element e1;

                e1.value = f1.textBox1.Text;
                FloatTextBox2 = Convert.ToSingle(f1.textBox2.Text);
                e1.chance = FloatTextBox2;
                F.Add(e1);

            }

            static public void Second()
            {
                Element e2;
                e2.value = f1.textBox1.Text;
                FloatTextBox2 = Convert.ToSingle(f1.textBox2.Text);
                e2.chance = FloatTextBox2;
                S.Add(e2);
            }
        
        static public void Dop()
        {
            int a = F.Count;
            for (int i = 0; i < a; i++)
            {
                Element el = F[i];
                Element Iel;
                Iel.value = el.value;
                Iel.chance = 1 - el.chance;
                Itogo.Add(Iel);
            }
        }

        static public void Per()
        {
            for (int i = 0; i < F.Count; i++)
            {
                Element el1 = F[i];
                Element Iel;
                int index = f1.listBox4.FindStringExact(el1.value);
                if (index != ListBox.NoMatches)
                {
                    Element el2 = S[index];
                    Iel.value = el1.value;
                    Iel.chance = Math.Min(el1.chance, el2.chance);
                    Itogo.Add(Iel);
                }
                else
                {
                    Itogo.Add(el1);
                }
            }
        }

            static public void Ob()
        {
            for (int i = 0; i < F.Count; i++)
            {
                Element el1 = F[i];
                Element Iel;
                int index = f1.listBox4.FindStringExact(el1.value);
                if (index != ListBox.NoMatches)
                {
                    Element el2 = S[index];
                    Iel.value = el1.value;
                    Iel.chance = Math.Max(el1.chance, el2.chance);
                    Itogo.Add(Iel);
                }
                else
                {                 
                    Itogo.Add(el1);
                }
            }
        }

        static public void Step(double a)
        {
            for (int i = 0; i < F.Count; i++)
            {
                Element el = F[i];
                Element Iel;
                Iel.value = el.value;
                Iel.chance = Convert.ToSingle(Math.Pow(Convert.ToDouble(el.chance), a));
                Itogo.Add(Iel);
            }
        }

        static public bool UmnCh(float a)
        {
            float sup = 0;
            Element Iel;
            for (int i = 0; i < F.Count; i++)
            {
                Element el = F[i];
                if (el.chance > sup) sup = el.chance;
            }

            if (sup * a <= 1)
            {
                for (int j = 0; j < F.Count; j++)
                {
                    Element el = F[j];
                    Iel.value = el.value;
                    Iel.chance = el.chance*a;
                    Itogo.Add(Iel);
                }
                return true;
            }
            else
            {
                string message = "Умножить на данное число невозможно";
                var result = MessageBox.Show(message);
                return false;
            }
        }

        static public void Umn()
        { Element Iel;
            for (int i = 0; i < F.Count; i++)
            {
                Element el = F[i];
                int index = f1.listBox4.FindStringExact(el.value);
                if (index != ListBox.NoMatches)
                {
                    Element el2 = S[index];
                    Iel.chance = el.chance*el2.chance;
                    Iel.value = el.value;
                    Itogo.Add(Iel);
                }
                else
                {
                    Iel.value = el.value;
                    Iel.chance = 0;
                    Itogo.Add(Iel);
                }
            }
        } 
    }


        /*static public ListSort(List <Element> F)
        {
            F.Item root = new F.Item();
            for (Item i = List.Head; i != null; i = i.Next)
            {
                Item c = root;
                while (c.Next != null && c.Next.Data >= i.Data)
                    c = c.Next;

                c.Next = new Item()
                {
                    Data = i.Data,
                    Next = c.Next
                };
            }

            return new List() { Head = root.Next }; ;
        }*/
    }


