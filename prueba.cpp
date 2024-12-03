using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

static void Main(string[] args)
{
  int aux = 2;
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
        aux = 5;
        Console.WriteLine("" + aux + " es igual a " + n + " " + a + " " + b);
      } else {
        aux = 5;
        Console.WriteLine("" + aux + " es diferente a " + n);
      }
    }
  }
  if(a % 2 != 0) {
    Console.WriteLine("Es impar " + a);
    if(b == 2) {
      aux = 2;
      Console.WriteLine("b es igual a " + aux);
    } else if( b > 3) {
      aux = 3;
      Console.WriteLine("b es mayor a " + aux + " y vale " + b);
    }
    else {
      aux = 2;
      Console.WriteLine("b no es igual a " + aux + " y vale " + b);
    }
  } else {
    Console.WriteLine("Es impar");
  }
}