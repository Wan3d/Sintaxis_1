using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sintaxis_1
{
    public class Lenguaje : Sintaxis
    {
        public Lenguaje() : base()
        {
            log.WriteLine("Constructor lenguaje");
        }
        public Lenguaje(string nombre) : base(nombre)
        {
            log.WriteLine("Constructor lenguaje");
        }
        public void libreria()
        {
            match("#");
            match("include");
            match("<");
            match(Tipos.Identificador);
            match(">");

        }
    }
}