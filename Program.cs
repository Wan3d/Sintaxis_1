using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sintaxis_1
{
    public class Program : Token
    {
        static void Main(string[] args)
        {
            try
            {
                using (Lenguaje lexico = new("prueba.cpp"))
                {
                    lexico.Programa();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}