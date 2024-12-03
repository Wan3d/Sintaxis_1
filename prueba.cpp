using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

static void Main(string[] args)
{
int a = 2;
int b = 3;
if (a == b)
{
  Console.WriteLine("a es igual a " + b);
}
else if (a != b)
{
  Console.WriteLine("a no es igual a " + b);
  a++;
  if (a == b)
  {
    Console.WriteLine("a ahora es igual a " + b);
  }
}
}