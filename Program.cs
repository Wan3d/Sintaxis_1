using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sintaxis_1
{
    class Program : Token
    {
        static void Main(string[] args)
        {
            try
            {
                using (Sintaxis lexico = new Sintaxis("prueba.cpp"))
                {
                    /*while (!lexico.finArchivo())
                    {
                        lexico.nextToken();
                    }
                    lexico.log.WriteLine("\n-----------------------------------\n");
                    lexico.log.WriteLine("Líneas del archivo: " + lexico.linea);*/
                    lexico.match("#");
                    lexico.match("include");
                    lexico.match("<");
                    lexico.match(Tipos.Identificador);
                    lexico.match(">");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}