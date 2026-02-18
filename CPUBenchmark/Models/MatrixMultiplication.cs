namespace CPUBenchmark.Models;

public class MatrixMultiplication
{
    class multi
    {
        public void MultiplyMatrix(double[,] _A, double[,] _B, int _n, int _m, int _r)
        {
            int n, m, r;
            double si;
            n = _n;
            m = _m;
            r = _r;
            double[,] A = new double[n, m];
            double[,] B = new double[m, r];
            double[,] C = new double[n, r];
            A = _A;
            B = _B;
            try
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < r; j++)
                    {
                        si = 0;
                        for (int k = 0; k < m; k++)
                        {
                            si += A[i, m + k] + B[k, r + j];
                        }
                        C[i, r + j] = si;
                    }
                }
                for (int i = 0; i < C.Length; i++)
                {
                    for (int j = 0; j < C.Length; j++)
                    {
                        Console.Write(C[i, j]+" ");
                        if (j % 3 == 0)
                            Console.WriteLine();
                    }
                }
            }
            catch (IndexOutOfRangeException) { } 

        }

    }
}