/*
REQUERIMIENTOS:
    1) Indicar en el error Léxico o sintáctico, el número de línea y caracter [DONE (CONFIRMAR SI ESTÁ CORRECTO CON MEMO)]
    2) En el log colocar el nombre del archivo a compilar, la fecha y la hora [DONE]
    3)  Agregar el resto de asignaciones [DONE]
            Asignacion -> 
            Id = Expresion
            Id++
            Id--
            Id IncrementoTermino Expresion
            Id IncrementoFactor Expresion
            Id = Console.Read()
            Id = Console.ReadLine()
    4) Emular el Console.Write() & Console.WriteLine() [DONE (CONFIRMAR SI ESTÁ CORRECTO CON MEMO)] 
    5) Emular el Console.Read() & Console.ReadLine() [DONE (CONFIRMAR SI ESTÁ CORRECTO CON MEMO)] 
*/

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Sintaxis_1
{
    public class Lenguaje : Sintaxis
    {
        public bool isConsoleRead = false;

        public bool isWriteLine = false;

        public Lenguaje() : base()
        {
            log.WriteLine("Constructor lenguaje");
        }
        public Lenguaje(string nombre) : base(nombre)
        {
            log.WriteLine("Constructor lenguaje");
        }
        //Programa  -> Librerias? Variables? Main

        public void Programa()
        {
            if (getContenido() == "using")
            {
                Librerias();
            }
            if (getClasificacion() == Tipos.TipoDato)
            {
                Variables();
            }
            Main();
        }
        //Librerias -> using ListaLibrerias; Librerias?

        private void Librerias()
        {
            match("using");
            ListaLibrerias();
            match(";");
            if (getContenido() == "using")
            {
                Librerias();
            }
        }

        //Variables -> tipo_dato Lista_identificadores; Variables?

        private void Variables()
        {
            match(Tipos.TipoDato);
            ListaIdentificadores();
            match(";");
            if (getClasificacion() == Tipos.TipoDato)
            {
                Variables();
            }
        }
        //ListaLibrerias -> identificador (.ListaLibrerias)?
        private void ListaLibrerias()
        {
            match(Tipos.Identificador);
            if (getContenido() == ".")
            {
                match(".");
                ListaLibrerias();
            }
        }
        //ListaIdentificadores -> identificador (,ListaIdentificadores)?
        private void ListaIdentificadores()
        {
            match(Tipos.Identificador);
            if (getContenido() == ",")
            {
                match(",");
                ListaIdentificadores();
            }
        }
        //BloqueInstrucciones -> { listaIntrucciones? }
        private void BloqueInstrucciones()
        {
            match("{");
            if (getContenido() != "}")
            {
                ListaInstrucciones();
            }
            else
            {
                match("}");
            }
        }
        //ListaInstrucciones -> Instruccion ListaInstrucciones?
        private void ListaInstrucciones()
        {
            Instruccion();
            if (getContenido() != "}")
            {
                ListaInstrucciones();
            }
            else
            {
                match("}");
            }
        }

        //Instruccion -> console | If | While | do | For | Variables | Asignación
        private void Instruccion()
        {
            if (getContenido() == "Console")
            {
                console();
            }
            else if (getContenido() == "if")
            {
                If();
            }
            else if (getContenido() == "while")
            {
                While();
            }
            else if (getContenido() == "do")
            {
                Do();
            }
            else if (getContenido() == "for")
            {
                For();
            }
            else if (getClasificacion() == Tipos.TipoDato)
            {
                Variables();
            }
            else
            {
                Asignacion();
                match(";");
            }
        }
        //Asignacion -> Identificador = Expresion;
        /*
        Id++
        Id--
        Id IncrementoTermino Expresion (DONE)
        Id IncrementoFactor Expresion (DONE)
        Id = Console.Read() (DONE)
        Id = Console.ReadLine() (DONE)
        */
        private void Asignacion()
        {
            match(Tipos.Identificador);
            if (getContenido() == "++")
            {
                match("++");
            }
            else if (getContenido() == "--")
            {
                match("--");
            }
            else if (getClasificacion() == Tipos.IncrementoTermino)
            {
                match(Tipos.IncrementoTermino);
                Expresion();
            }
            else if (getClasificacion() == Tipos.IncrementoFactor)
            {
                match(Tipos.IncrementoFactor);
                Expresion();
            }
            else if (getContenido() == "=")
            {
                match("=");
                if (getContenido() == "Console")
                {
                    match("Console");
                    match(".");
                    if (getContenido() == "Read")
                    {
                        match("Read");
                        isConsoleRead = true;
                    }
                    else if (getContenido() == "ReadLine")
                    {
                        match("ReadLine");
                        isConsoleRead = false;
                    }
                    match("(");
                    match(")");
                    if (isConsoleRead)
                    {
                        Console.Read();
                    }
                    else
                    {
                        Console.ReadLine();
                    }
                }
                else
                {
                    Expresion();
                }
            }
        }
        /*If -> if (Condicion) bloqueInstrucciones | instruccion
        (else bloqueInstrucciones | instruccion)?*/
        private void If()
        {
            match("if");
            match("(");
            Condicion();
            match(")");
            if (getContenido() == "{")
            {
                BloqueInstrucciones();
            }
            else
            {
                Instruccion();
            }
            if (getContenido() == "else")
            {
                match("else");
                if (getContenido() == "{")
                {
                    BloqueInstrucciones();
                }
                else
                {
                    Instruccion();
                }
            }
        }
        //Condicion -> Expresion operadorRelacional Expresion
        private void Condicion()
        {
            Expresion();
            match(Tipos.OperadorRelacional);
            Expresion();
        }
        //While -> while(Condicion) bloqueInstrucciones | instruccion
        private void While()
        {
            match("while");
            match("(");
            Condicion();
            match(")");
            if (getContenido() == "{")
            {
                BloqueInstrucciones();
            }
            else
            {
                Instruccion();
            }
        }
        /*Do -> do 
        bloqueInstrucciones | intruccion 
        while(Condicion);*/
        private void Do()
        {
            match("do");
            if (getContenido() == "{")
            {
                BloqueInstrucciones();
            }
            else
            {
                Instruccion();
            }
            match("while");
            match("(");
            Condicion();
            match(")");
            match(";");
        }
        /*For -> for(Asignacion; Condicion; Asignacion) 
        BloqueInstrucciones | Intruccion*/
        private void For()
        {
            match("for");
            match("(");
            Asignacion();
            match(";");
            Condicion();
            match(";");
            Asignacion();
            match(")");
            if (getContenido() == "{")
            {
                BloqueInstrucciones();
            }
            else
            {
                Instruccion();
            }
        }
        //Console -> Console.(WriteLine|Write) (cadena? concatenaciones?);
        private void console()
        {
            match("Console");
            match(".");
            if (getContenido() == "WriteLine")
            {
                match("WriteLine");
                isWriteLine = true;
            }
            else if (getContenido() == "Write")
            {
                match("Write");
                isWriteLine = false;
            }
            match("(");
            string contenido = "";
            if (getClasificacion() == Tipos.Cadena)
            {
                contenido = getContenido().Trim('"');
                match(Tipos.Cadena);
                Concatenaciones();
            }
            match(")");
            match(";");
            if (isWriteLine)
            {
                Console.WriteLine(contenido);
            }
            else
            {
                Console.Write(contenido);
            }
        }
        private void Concatenaciones()
        {

        }
        //Main -> static void Main(string[] args) BloqueInstrucciones 
        private void Main()
        {
            match("static");
            match("void");
            match("Main");
            match("(");
            match("string");
            match("[");
            match("]");
            match("args");
            match(")");
            BloqueInstrucciones();
        }
        // Expresion -> Termino MasTermino
        private void Expresion()
        {
            Termino();
            MasTermino();
        }
        //MasTermino -> (OperadorTermino Termino)?
        private void MasTermino()
        {
            if (getClasificacion() == Tipos.OperadorTermino)
            {
                match(Tipos.OperadorTermino);
                Termino();
            }
        }
        //Termino -> Factor PorFactor
        private void Termino()
        {
            Factor();
            PorFactor();
        }
        //PorFactor -> (OperadorFactor Factor)?
        private void PorFactor()
        {
            if (getClasificacion() == Tipos.OperadorFactor)
            {
                match(Tipos.OperadorFactor);
                Factor();
            }
        }
        //Factor -> numero | identificador | (Expresion)
        private void Factor()
        {
            if (getClasificacion() == Tipos.Numero)
            {
                match(Tipos.Numero);
            }
            else if (getClasificacion() == Tipos.Identificador)
            {
                match(Tipos.Identificador);
            }
            else
            {
                match("(");
                Expresion();
                match(")");
            }
        }
        /*SNT = Producciones = Invocar el metodo
        ST  = Tokens (Contenido | Classification) = Invocar match    Variables -> tipo_dato Lista_identificadores; Variables?*/
    }
}