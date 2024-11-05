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
            Librerias();
            Variables();
            Main();
        }
        //Librerias -> using ListaLibrerias; Librerias?

        private void Librerias()
        {
            match("using");
            ListaLibrerias();
            match(";");
            Librerias();
        }

        //Variables -> tipo_dato Lista_identificadores; Variables?

        private void Variables()
        {

        }
        //ListaLibrerias -> identificador (.ListaLibrerias)?
        private void ListaLibrerias()
        {

        }
        //ListaIdentificadores -> identificador (,ListaIdentificadores)?
        private void ListaIdentificadores()
        {

        }
        //BloqueInstrucciones -> { listaIntrucciones? }
        private void BloqueInstrucciones()
        {
        }
        //ListaInstrucciones -> Instruccion ListaInstrucciones?
        private void ListaInstrucciones()
        {
        }

        //Instruccion -> Console | If | While | do | For | Variables | Asignación
        private void Instruccion()
        {
        }
        //Asignacion -> Identificador = Expresion;
        private void Asignacion()
        {
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
        private void Console()
        {

        }
        //Main -> static void Main(string[] args) BloqueInstrucciones 
        private void Main()
        {
        }
        // Expresion -> Termino MasTermino
        private void Expresion()
        {

        }
        //MasTermino -> (OperadorTermino Termino)?
        private void MasTermino()
        {

        }
        //Termino -> Factor PorFactor
        private void Termino()
        {

        }
        //PorFactor -> (OperadorFactor Factor)?
        private void PorFactor()
        {

        }
        //Factor -> numero | identificador | (Expresion)
        private void Factor()
        {

        }
        /*SNT = Producciones = Invocar el metodo
        ST  = Tokens (Contenido | Classification) = Invocar match    Variables -> tipo_dato Lista_identificadores; Variables?*/
    }
}