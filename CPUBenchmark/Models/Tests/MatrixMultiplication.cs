using System.Diagnostics;

namespace CPUBenchmark.Models;

public class MatrixMultiplication : ICpuTest
{

    public TestResult Run()
    {
        Console.Write("Enter matrix length: ");
        int length = int.Parse(Console.ReadLine());

        var timer = new Stopwatch();

        timer.Start();

        MultiplyMatrix(length);

        timer.Stop();

        return new TestResult
        {
            TestType = TestType.MatrixMultiplication,
            Value = timer.ElapsedMilliseconds
        };
    }

    private void PopulateMatrix(int length, ref double[,] matrix)
    {
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                matrix[i, j] = Random.Shared.NextDouble();
            }
        }
    }
    
    private void MultiplyMatrix(int n)
    {
        double si;
        
        double[,] A = new double[n, n];
        double[,] B = new double[n, n];
        double[,] C = new double[n, n];

       
        PopulateMatrix(n, ref A);
        PopulateMatrix(n, ref B);
        PopulateMatrix(n, ref C);
     
       
        try
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    si = 0;
                    si += A[i, j] + B[j, i];
                    C[i, j] = si;
                }
            }

            // for (int i = 0; i < C.Length; i++)
            // {
            //     for (int j = 0; j < C.Length; j++)
            //     {
            //         Console.Write(C[i, j] + " ");
            //         if (j % 3 == 0)
            //             Console.WriteLine();
            //     }
            // }
        }
        catch (IndexOutOfRangeException)
        {
        }
    }
}
