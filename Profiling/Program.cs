using System;
using System.Threading;
using System.Diagnostics;

namespace Profiling
{
    class Program
    {
        delegate void Function(int x);
        delegate void Function2(int n, Function f, int x);
        delegate int[] Function3(int S, int D);

        public static int[] Voraz(int S, int D)
        {
            int[] sol = new int[D];
            for (int i = 0; i < D; i++)
            {
                if (S == 0)
                    sol[i] = 0;
                else if (S < 9)
                {
                    sol[i] = S;
                    S = 0;
                }
                else
                {
                    sol[i] = 9;
                    S -= 9;
                }
            }
            if (S != 0)
                return null;
            return sol;
        }

        public static int[] Voraz2(int S, int D)
		{
            int[] res = new int[D];
            for (int i = D-1; i >= 0; i--)
            {
                int j = 0;
                while (j < S && j < 10)
                {
                    j++;
                }
                S -= j;
                res[i] = j;
            }
            return res;
        }

        public static void PrintArr(int[] arr)
		{
            foreach (int i in arr)
                Console.Write(i);
            Console.WriteLine();
		}

        static void Pyramid(int x)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x-i; j++)
                    Console.Write("_");
                for(int k = 0; k < i+1; k++)
                    Console.Write("o");
                for (int l = 0; l < i; l++)
                    Console.Write("o");
                Console.Write("\n");
            }
        }

        static void Square(int x)
        {
            for(int i = 0; i < x; i++)
            {
                for(int j = 0; j < x; j++)
                    Console.Write("o");
                Console.WriteLine();
            }
        }

        static void Profiling(int n, Function3 f, int S, int D)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < n; i++)
                PrintArr(f(S, D));
            stopwatch.Stop();
            TimeSpan stopwatchElapsed = stopwatch.Elapsed;
            int time = Convert.ToInt32(stopwatchElapsed.TotalMilliseconds);
            Console.WriteLine("\nTotal time to do {0} operations of '{1}'g: {2}ms", n, f.Method, time);
            Console.WriteLine("Time per operation: {0}ms\n", time/n);
        }

        static void Main2(Function2 f)
        {
            int x = 1;
            Console.WriteLine("Hello World!");
            while (x != 0)
            {
                Function f1 = Pyramid;
                f(x, f1, 10);
                if (!Int32.TryParse(Console.ReadLine(), out x))
                    break;
                f(x, Square, 10);
                if (!Int32.TryParse(Console.ReadLine(), out x))
                    break;
            }
        }

        static void Main(string[] args)
        {
            Profiling(10000, Voraz, 28, 4);
            Console.ReadLine();
            Profiling(10000, Voraz2, 28, 4);
        }        
    }
}