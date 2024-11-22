using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

static void Main(string[] args)
{
    char c;
    int a, b, c, d;
    int i, k;
    float radio, base, area, altura;

    a = (3 + 5) * 8 - (10 - 4) / 2; // 61
    c = 0;
    b = k * a;
    if (1 != 2)
    {
        Console.Write("Ingrese el valor de d = ");
        d = Console.ReadLine();
        if (d % 2 == 0)
        {
            for (i = 0; i < d; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            i = 0;
            do
            {
                Console.Write("-");
                i++;
            } while (i < d);
            i = 0;
            Console.WriteLine();
            while (i < d)
            {
                Console.Write("-");
                i++;
            }
            for (i = d; i >= 0; i--)
            {
                Console.Write(" - ");
            }
            Console.WriteLine();
            for (i = 0; i < d; i += 2)
            {
                for (j = 0; j <= i; j += 1)
                {
                    if (j % 2 == 0)
                        Console.Write("+");
                    else
                        Console.Write("-");
                }
                Console.Write();
            }
        }
    }
}
