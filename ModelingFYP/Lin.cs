using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;
namespace ModelingFYP
{
    class Lin
    {
        public double[] X1 { get; private set; }
        public double[] X2 { get; private set; }
        public double[] Y { get; private set; }
        private double[,]XMatr { get; set; }
        public Lin (double[] x1, double []x2, double []y)
        {
            X1 = x1;
            X2 = x2;
            Y = y;
        }
        public double [] DoWork ()
        {
            double[] res = new double[3];
            MakeX();
            var MyX = Matrix<double>.Build.DenseOfArray(XMatr);
            var MyY = Vector<double>.Build.DenseOfArray(Y);
            var MyB = (MyX.Transpose() * MyX).Inverse() * (MyX.Transpose() * MyY);
            for (int i = 0; i < 3; i++)
                res[i] = MyB[i];
            return res;
        }
        private void MakeX ()
        {
            XMatr = new double[X1.Length, 3];
            for (int i=0;i<X1.Length;i++)
            {
                XMatr[i, 0] = 1;
                XMatr[i, 1] = X1[i];
                XMatr[i, 2] = X2[i];
            }
            
        }
    }
}
