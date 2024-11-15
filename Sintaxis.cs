using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sintaxis_1
{
    public class Sintaxis : Lexico
    {
        public int columna = 1;
        public Sintaxis() : base()
        {
            nextToken();
        }
        public Sintaxis(string nombre) : base(nombre)
        {
            nextToken();
            columna++;
        }
        public void match(string contenido)
        {
            if (contenido == getContenido())
            {
                nextToken();
            }
            else
            {
                throw new Error("Sintaxis. Se espera un " + contenido, log, linea);
            }
        }
        public void match(Tipos clasificacion)
        {
            if (clasificacion == getClasificacion())
            {
                nextToken();
            }
            else
            {
                throw new Error("Sintaxis. Se espera un " + clasificacion, log, linea);
            }
        }
    }
}