using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

static void Main(string[] args)
{
  char a;
  int b;

  if (1 == 2)
  {
    do
    {
      Console.WriteLine(".");
    } while (a < 10);
        a = 10;
    if (1 == 2)
      a = 20;
    else
      a = 30;
  }
  else
  {
    do
    {
      Console.WriteLine(".");
    } while (a < 5);
    a = 40;
    for (a = 0; a < 10; a++)
    {
    }
  }
}
