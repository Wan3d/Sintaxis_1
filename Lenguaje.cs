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
            ListaInstrucciones();
            match("}");
        }
        //ListaInstrucciones -> Instruccion ListaInstrucciones?
        private void ListaInstrucciones()
        {
            Instruccion();
            if (getContenido() != "}")
            {
                ListaInstrucciones();
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
            }
        }
        //Asignacion -> Identificador = Expresion;
        private void Asignacion()
        {
            match(Tipos.Identificador);
            match("=");
            Expresion();
            match(";");
        }
        /*If -> if (Condicion) bloqueInstrucciones | instruccion
        (else bloqueInstrucciones | instruccion)?*/
        private void If()
        {

        }
        //Condicion -> Expresion operadorRelacional Expresion
        private void Condicion()
        {

        }
        //While -> while(Condicion) bloqueInstrucciones | instruccion
        private void While()
        {

        }
        /*Do -> do 
            bloqueInstrucciones | intruccion 
        while(Condicion);*/
        private void Do()
        {
        }
        /*For -> for(Asignacion; Condicion; Asignacion) 
        BloqueInstrucciones | Intruccion*/
        private void For()
        {

        }
        //Console -> Console.(WriteLine|Write) (cadena concatenaciones?);
        private void console()
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
            match("[]");
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
            if (getClasificacion() == Tipos.OperadorTermino) ;
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