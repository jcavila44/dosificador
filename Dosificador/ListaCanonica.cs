using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dosificador
{
    class ListaCanonica
    {
        public class Nodo
        {
            private string rutaFile;
            private string nameFile;
            private string typefile;

            private Nodo siguiente;

            public string RutaFile { get => rutaFile; set => rutaFile = value; }
            public string NameFile { get => nameFile; set => nameFile = value; }
            public string Typefile { get => typefile; set => typefile = value; }
            internal Nodo Siguiente { get => siguiente; set => siguiente = value; }
        }
        public class listaEnlazadaSimple
        {
            Nodo cabeza;

            internal Nodo Cabeza { get => cabeza; set => cabeza = value; }

            public bool listaVacia()
            {
                if (Cabeza == null)
                    return true;
                else
                    return false;
            }

            public void imprimir()
            {

                Nodo recorrido = Cabeza;
                while (recorrido != null)
                {
                    Console.Write(recorrido.RutaFile+ "->");
                    recorrido = recorrido.Siguiente;
                }
                Console.Write("*\n");
            }

            public void agregarElementoAlFinal(string rutaArchivo, string nameFile, string typeFile)
            {
                Nodo Nuevo = new Nodo();
                Nuevo.RutaFile = rutaArchivo;
                Nuevo.NameFile = nameFile;
                Nuevo.Typefile = typeFile;

                if (listaVacia())
                {
                    Cabeza = Nuevo;
                }
                else
                {
                    Nodo Recorrido = Cabeza;
                    while (Recorrido.Siguiente != null)
                    {
                        Recorrido = Recorrido.Siguiente;
                    }
                    Recorrido.Siguiente = Nuevo;
                }

            }

            public void EliminarElementoDesdeLaCabeza()
            {
                if (!listaVacia())
                {
                    Cabeza = Cabeza.Siguiente;
                }
            }
        }
    }
}
