using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

static void Main(string[] args)
{
  int b = Console.ReadLine();
  int a = (3 + 5) * 8 - (10 - 2*b) / b; // 61
  a--;
  a+=40;
  a*=2;
  a--;
  a-=99;

  int n = 5;

  for(b = 100; a < n; a++) {
    b++;
    while( b != 5 ) {
      if(n == 5) {
        Console.WriteLine("5 es igual a " + n + " " + a + " " + b );
      } else {
        Console.WriteLine("5 es diferente a " + n);
      }
    }
  }

  if(a % 2 != 0) {
    Console.WriteLine("Es impar " + a);
    if(b == 2) {
      Console.WriteLine("b es igual a 2");
    } else if( b > 3) {
      Console.WriteLine("b es mayor a 3 y vale " + b);
    }
    else {
      Console.WriteLine("b no es igual a 2 y vale " + b);
    }
  } else {
    Console.WriteLine("Es impar");
  }
}