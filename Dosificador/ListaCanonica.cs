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

            private string cod_solicitud;
            private string cedula;
            private string nombres;
            private string apellidos;
            private string tipo_solicitud;
            private string fecha_solicitud;
            private string estado;
            private string documento_origen;

            private Nodo siguiente;

            public string Cod_solicitud { get => cod_solicitud; set => cod_solicitud = value; }
            public string Nombres { get => nombres; set => nombres = value; }
            public string Apellidos { get => apellidos; set => apellidos = value; }
            public string Cedula { get => cedula; set => cedula = value; }
            public string Tipo_solicitud { get => tipo_solicitud; set => tipo_solicitud = value; }
            public string Fecha_solicitud { get => fecha_solicitud; set => fecha_solicitud = value; }
            public string Estado { get => estado; set => estado = value; }
            public string Documento_origen { get => documento_origen; set => documento_origen = value; }
            public Nodo Siguiente { get => siguiente; set => siguiente = value; }
        }
        public class listaEnlazadaSimple
        {

            Nodo cabeza;


            public bool listaVacia()
            {
                if (cabeza == null)
                    return true;
                else
                    return false;
            }


            //public void agregarElementoAlInicio(int cod_solicitud, string nombres, string apellidos, int cedula, string tipo_solicitud, string fecha_solicitud, string estado, string documento_origen)
            public void agregarElementoAlInicio(string[] infoPersona)
            {
                Nodo Nuevo = new Nodo();

                Nuevo.Cod_solicitud = infoPersona[0];
                Nuevo.Cedula = infoPersona[1];
                Nuevo.Nombres = infoPersona[2];
                Nuevo.Apellidos = infoPersona[3];
                Nuevo.Tipo_solicitud = infoPersona[4];
                Nuevo.Fecha_solicitud = infoPersona[5];
                Nuevo.Estado = infoPersona[6];
                Nuevo.Documento_origen = infoPersona[7];

                if (listaVacia())
                {
                    cabeza = Nuevo;
                }
                else
                {
                    Nuevo.Siguiente = cabeza;
                    cabeza = Nuevo;
                }
            }

            public void imprimir()
            {

                Nodo recorrido = cabeza;
                while (recorrido != null)
                {
                    //Console.Write(recorrido.Valor + "->");
                    recorrido = recorrido.Siguiente;
                }
                Console.Write("*\n");
            }

            //public void agregarElementoAlFinal(int cod_solicitud, string nombres, string apellidos, int cedula, string tipo_solicitud, string fecha_solicitud, string estado, string documento_origen)
            //{
            public void agregarElementoAlFinal(string[] infoPersona)
            {
                Nodo Nuevo = new Nodo();

                Nuevo.Cod_solicitud = infoPersona[0];
                Nuevo.Cedula = infoPersona[1];
                Nuevo.Nombres = infoPersona[2];
                Nuevo.Apellidos = infoPersona[3];
                Nuevo.Tipo_solicitud = infoPersona[4];
                Nuevo.Fecha_solicitud = infoPersona[5];
                Nuevo.Estado = infoPersona[6];
                Nuevo.Documento_origen = infoPersona[7];

                if (listaVacia())
                {
                    cabeza = Nuevo;
                }
                else
                {
                    Nodo Recorrido = cabeza;
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
                    cabeza = cabeza.Siguiente;
                }
            }

            public void EliminarElementoDesdeElFinal()
            {
                int counter = 0;
                if (!listaVacia())
                {
                    Nodo Recorrido = cabeza;
                    Nodo Referencia = new Nodo();
                    while (Recorrido != null)
                    {
                        if (Recorrido.Siguiente != null)
                        {
                            Referencia = Recorrido;
                        }

                        Recorrido = Recorrido.Siguiente;
                        counter++;

                    }

                    if (counter == 1)
                    {
                        cabeza = null;
                    }
                    else
                    {
                        Referencia.Siguiente = null;
                        Recorrido = Referencia;
                    }

                }

            }



            public void pasarInfoXmlCanonicoTemp(string nombreArchivoXMl)
            {

                Nodo recorrido = cabeza;

                string datos = "";

                while (recorrido != null)
                {
                    datos = "<persona>";
                    datos += "\n\t<cod_solicitud>" + recorrido.Cod_solicitud + "</cod_solicitud>";
                    datos += "\n\t<cedula>" + recorrido.Cedula + "</cedula>";
                    datos += "\n\t<nombres>" + recorrido.Nombres + "</nombres>";
                    datos += "\n\t<apellidos>" + recorrido.Apellidos + "</apellidos>";
                    datos += "\n\t<tipo_solicitud>" + recorrido.Tipo_solicitud + "</tipo_solicitud>";
                    datos += "\n\t<fecha_solicitud>" + recorrido.Fecha_solicitud + "</fecha_solicitud>";
                    datos += "\n\t<estado>" + recorrido.Estado + "</estado>";
                    datos += "\n\t<documento_origen>" + recorrido.Documento_origen + "</documento_origen>";
                    datos += "\n</persona>\n";

                    recorrido = recorrido.Siguiente;
                }


                switch (nombreArchivoXMl)
                {
                    case "SOLMAFI":
                        using (StreamWriter w = File.AppendText(@"../../Documentos/XMLTEMP_SOLMAFI.xml"))
                        {
                            w.WriteLine(datos);
                        }

                        break;
                    case "SOLGRA":
                        using (StreamWriter w = File.AppendText(@"../../Documentos/XMLTEMP_SOLGRA.xml"))
                        {
                            w.WriteLine(datos);
                        }

                        break;
                    case "SOLMAAC":
                        using (StreamWriter w = File.AppendText(@"../../Documentos/XMLTEMP_SOLMAAC.xml"))
                        {
                            w.WriteLine(datos);
                        }

                        break;
                }

            }


            public void pasarXMLTempCanonico(string nombreArchivoXMl)
            {

                switch (nombreArchivoXMl)
                {
                    case "SOLMAFI":
                        var datos = File.ReadAllLines(@"../../Documentos/XMLTEMP_SOLMAFI.xml");

                        using (StreamWriter writer = new StreamWriter(@"../../Documentos/XMLCANONICO.xml", true))
                        {
                            //writer.WriteLine(datos[0]);
                            writer.WriteLine(String.Join(Environment.NewLine, datos));
                            writer.Close();
                            File.Delete(@"../../Documentos/XMLTEMP_SOLMAFI.xml");
                        }

                        break;
                    case "SOLGRA":
                        var datos1 = File.ReadAllLines(@"../../Documentos/XMLTEMP_SOLGRA.xml");

                        using (StreamWriter writer = new StreamWriter(@"../../Documentos/XMLCANONICO.xml", true))
                        {
                            writer.WriteLine(String.Join(Environment.NewLine, datos1));
                            writer.Close();
                            File.Delete(@"../../Documentos/XMLTEMP_SOLGRA.xml");

                        }

                        break;
                    case "SOLMAAC":

                        var datos2 = File.ReadAllLines(@"../../Documentos/XMLTEMP_SOLMAAC.xml");

                        using (StreamWriter writer = new StreamWriter(@"../../Documentos/XMLCANONICO.xml", true))
                        {
                            writer.WriteLine(String.Join(Environment.NewLine, datos2));
                            writer.Close();
                            File.Delete(@"../../Documentos/XMLTEMP_SOLMAAC.xml");

                        }

                        break;
                }

            }


        }
    }
}
