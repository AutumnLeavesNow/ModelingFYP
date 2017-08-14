using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MLApp;

namespace ModelingFYP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowCount = 10;
            dataGridView2.RowCount = 1;
            dataGridView3.RowCount = 1;
            double[] xx = { 3, 21, 3, 1.2, 3, 7.6, 5, 23.2, 2.4, 3.2 };
            double[] xxx = { 2.4, 1, 5.6, 2.3, 9, 1.4, 4.7, 9.6, 12, 0, 7 };
            for (int i=0; i<10;i++)
            {
                //double x1 = (double)i*0.5 - 5;
                //double x2 = (double)(25-i)*0.2+2;
                dataGridView1.Rows[i].Cells[0].Value = xx[i];
                dataGridView1.Rows[i].Cells[1].Value = xxx[i];
                dataGridView1.Rows[i].Cells[2].Value = Myfunc.Func1(xx[i], xxx[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int m = dataGridView1.RowCount;
            
            double[] X1 = new double[m];
            double[] X2 = new double[m];
            double[] Y = new double[m];
            MLApp.MLApp matlab = new MLApp.MLApp();
            matlab.Execute(@"cd C:\Users\Admin\Desktop\ModelingFYP");
            object result = null;
            double[] res1, res2;
            for (int i=0; i<m; i++)
            {
                X1[i] = Double.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                X2[i] = Double.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                //  Y[i] = Myfunc.Func1(X1[i], X2[i]);
                Y[i]= Double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
            }
            
            Lin mylin = new Lin(X1, X2, Y);
            res1 = mylin.DoWork();
            Quad myq = new Quad(X1, X2, Y);
            for (int i=0; i<3; i++)
            {
                dataGridView2.Rows[0].Cells[i].Value = res1[i];
            }
            res2 = myq.DoWork();
            for (int i = 0; i < 6; i++)
            {
                dataGridView3.Rows[0].Cells[i].Value = res2[i];
            }

            matlab.Feval("scatter", 0, out result, X1,X2, Y, res1[0], res1[1], res1[2], res2[0], res2[1], res2[2],
                res2[3], res2[4], res2[5]);
        }
    }
}
