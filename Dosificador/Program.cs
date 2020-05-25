using System.IO;
using System.Threading;
using static Dosificador.ListaCanonica;

namespace Dosificador
{
    class Program
    {
        static void Main(string[] args)
        {

            Thread th1 = new Thread(() => moverArchivos("Solicitud_de_Graduacion(SOLGRA)"));
            th1.Start();
            Thread.Sleep(20);
            //th1.Abort();
            //th1.Join();


            Thread th3 = new Thread(() => moverArchivos("Solicitud_de_Matricula_Academica(SOLMAAC)"));
            th3.Start();
            Thread.Sleep(20);
            //th3.Abort();
            //th3.Join();


            Thread th4 = new Thread(() => moverArchivos("Solicitud_de_Matricula_Financiera(SOLMAFI)"));
            th4.Start();
            Thread.Sleep(20);
            //th4.Abort();
            //th4.Join();
        }


        static void moverArchivos(string archivo)
        {
            var origina = "../../Documentos/Regados/" + archivo + ".csv";
            var Destino = "../../Documentos/Comun/" + archivo + ".csv";

            File.Move(@origina, @Destino);

            convertirCSV(archivo);


        }

        static void convertirCSV(string nombreArchivo)
        {

            var lines = File.ReadAllLines(@"../../Documentos/Comun/" + nombreArchivo + ".csv");

            var campos = lines[0].Split(';');

            string[] tagsAperturaArray = new string[campos.Length];
            string[] tagsCierreArray = new string[campos.Length];

            for (int i = 0; i < campos.Length; i++)
            {
                tagsAperturaArray[i] = "<" + campos[i] + ">";
                tagsCierreArray[i] = "</" + campos[i] + ">";

            }


            var columnas = lines[0].Split(';').Length;
            var filas = lines.Length;
            string datos;
            string[] inputsCanonicos = new string[] { "cod_solicitud", "cedula", "nombres", "apellidos", "tipo_solicitud", "fecha_solicitud", "estado", "documento_origen" };
            string[] infoPersona = new string[8];
            string nombreArchivoLimpio = nombreArchivo.Split('(', ')')[1];
            listaEnlazadaSimple listCano = new listaEnlazadaSimple();

            for (int i = 1; i < filas; i++)
            {
                var filaInfo = lines[i].Split(';');

                datos = "<Persona>";

                for (int j = 0; j < filaInfo.Length; j++)
                {
                    datos += "\n\t" + tagsAperturaArray[j] + filaInfo[j] + tagsCierreArray[j];

                    //Comparamos si los campos canonicos elegidos son iguales a los a la posicion de la informacion y luego la almacene en un array
                    for (int k = 0; k < inputsCanonicos.Length; k++)
                    {
                        if (inputsCanonicos[k] == campos[j])
                        {
                            infoPersona[k] = filaInfo[j];
                        }
                    }

                }

                listCano.agregarElementoAlInicio(infoPersona);



                datos += "\n</Persona>";

                string nombreArchivoXMl = nombreArchivo.Split('(', ')')[1] + "_" + i;

                Thread.Sleep(200);

                using (StreamWriter writer = new StreamWriter(@validarUbicacionArchivo(nombreArchivo, nombreArchivoXMl), true))
                {
                    writer.WriteLine(datos);
                    writer.Close();
                }

                string nombreArchivoXMlLimpio = nombreArchivo.Split('(', ')')[1];


                listCano.pasarInfoXmlCanonicoTemp(nombreArchivoXMlLimpio);
            }



            listCano.pasarXMLTempCanonico(nombreArchivoLimpio);

        }


        static string validarUbicacionArchivo(string nombreArchivoruta, string nombreArchivoXMl)
        {
            string response = "";

            switch (nombreArchivoruta)
            {
                case "Solicitud_de_Graduacion(SOLGRA)":
                    response = "../../Documentos/XML_SOLGRA/" + nombreArchivoXMl + ".xml";
                    break;
                case "Solicitud_de_Inscripcion(SOLI)":
                    response = "../../Documentos/XML_SOLI/" + nombreArchivoXMl + ".xml";
                    break;
                case "Solicitud_de_Matricula_Academica(SOLMAAC)":
                    response = "../../Documentos/XML_SOLMAAC/" + nombreArchivoXMl + ".xml";
                    break;
                case "Solicitud_de_Matricula_Financiera(SOLMAFI)":
                    response = "../../Documentos/XML_SOLMAFI/" + nombreArchivoXMl + ".xml";
                    break;

            }

            if (File.Exists(@response))
            {
                File.Delete(@response);
            }

            return response;
        }
    }
}
