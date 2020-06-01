using System;
using System.IO;
using System.Security.Permissions;
using System.Threading;
using static Dosificador.ListaCanonica;

namespace Dosificador
{
    class Program
    {
        static void Main(string[] args)
        {
            //int timeExecution = 20;




            /*Thread RunWatcher = new Thread(() => Run());
            RunWatcher.Start();*/

            Thread DosificadorThread = new Thread(() => Dosificador());
            DosificadorThread.Start();



            //Thread th1 = new Thread(() => moverArchivos("Solicitud_de_Graduacion(SOLGRA)"));
            //th1.Start();
            //Thread.Sleep(20);
            //th1.Abort();
            //th1.Join();


            //Thread th3 = new Thread(() => moverArchivos("Solicitud_de_Matricula_Academica(SOLMAAC)"));
            //th3.Start();
            //Thread.Sleep(20);
            //th3.Abort();
            //th3.Join();


            //Thread th4 = new Thread(() => moverArchivos("Solicitud_de_Matricula_Financiera(SOLMAFI)"));
            //th4.Start();
            //Thread.Sleep(20);
            //th4.Abort();
            //th4.Join();
        }

        private static void Dosificador()
        {
            int cantDocuments = 100;
            GeneralHelper Row = new GeneralHelper();

            SOLCANMAHelper helperSOLCANMA = new SOLCANMAHelper();
            SOLCREESHelper helperSOLCREES = new SOLCREESHelper();
            SOLGRAHelper helperSOLGRA = new SOLGRAHelper();
            SOLIHelper helperSOLI = new SOLIHelper();
            SOLMAACHelper helperSOLMAAC = new SOLMAACHelper();
            SOLMAFIHelper helperSOLMAFI = new SOLMAFIHelper();

            for (int i = 1; i <= cantDocuments; i++)
            {
                int RandomNumber = Row.generateNumber(1, 6);
                switch (RandomNumber)
                {
                    case 1:
                        helperSOLCANMA.createSOLCANMA(i);
                        Console.WriteLine("createSOLCANMA");
                        Thread.Sleep(TimeSpan.FromSeconds(0.5));
                        break;
                    case 2:
                        helperSOLCREES.createSOLCREES(i);
                        Console.WriteLine("createSOLCREES");
                        Thread.Sleep(TimeSpan.FromSeconds(0.5));
                        break;
                    case 3:
                        helperSOLGRA.createSOLGRA(i);
                        Console.WriteLine("createSOLGRA");
                        Thread.Sleep(TimeSpan.FromSeconds(0.5));
                        break;
                    case 4:
                        helperSOLI.createSOLI(i);
                        Console.WriteLine("createSOLI");
                        Thread.Sleep(TimeSpan.FromSeconds(0.5));
                        break;
                    case 5:
                        helperSOLMAAC.createSOLMAAC(i);
                        Console.WriteLine("createSOLMAAC");
                        Thread.Sleep(TimeSpan.FromSeconds(0.5));
                        break;
                    case 6:
                        helperSOLMAFI.createSOLMAFI(i);
                        Console.WriteLine("createSOLMAFI");
                        Thread.Sleep(TimeSpan.FromSeconds(0.5));
                        break;
                }
            }
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private static void Run()
        {
            string args = "../../Documentos/Regados/";


            // Create a new FileSystemWatcher and set its properties.
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = @args;
                watcher.Filter = "*.csv";

                watcher.Created += OnChanged;
                
                watcher.EnableRaisingEvents = true;

                // Wait for the user to quit the program.
                Console.WriteLine("Press 'q' to quit the sample.");
                while (Console.Read() != 'q') ;
            }
        }

        // Define the event handlers.
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            ReadTypeFile(e.FullPath);
        }


    static void ReadTypeFile(string fullpath)
        {
            var lines = File.ReadAllLines(@fullpath);
            var campos = lines[0].Split(';');
            
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
            string[] inputsCanonicos = new string[] { 
                "cod_solicitud",
                "cedula",
                "nombres",
                "apellidos",
                "tipo_solicitud",
                "fecha_solicitud",
                "estado",
                "documento_origen"};
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
