﻿using System;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
                
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (Form1.oper == true) label1.Text = "Введите степень";
            else label1.Text = "Введите число";
            Form1.x = Convert.ToInt32(textBox1.Text);
            Close();
        }
    }



}
