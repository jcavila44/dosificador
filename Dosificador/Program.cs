using System;
using System.IO;
using System.Security.Permissions;
using System.Threading;
using static Dosificador.ListaCanonica;

namespace Dosificador
{
    class Program
    {
            public static SOLCANMAHelper helperSOLCANMA = new SOLCANMAHelper();
            public static SOLCREESHelper helperSOLCREES = new SOLCREESHelper();
            public static SOLGRAHelper helperSOLGRA = new SOLGRAHelper();
            public static SOLIHelper helperSOLI = new SOLIHelper();
            public static SOLMAACHelper helperSOLMAAC = new SOLMAACHelper();
            public static SOLMAFIHelper helperSOLMAFI = new SOLMAFIHelper();

        static void Main(string[] args)
        {
            Thread RunWatcher = new Thread(() => Run());
            RunWatcher.Start();

            Thread DosificadorThread = new Thread(() => Dosificador());
            Thread.Sleep(TimeSpan.FromSeconds(3));
            DosificadorThread.Start();
        }

        public static void Dosificador()
        {
            int cantDocuments = 100;
            GeneralHelper Row = new GeneralHelper();


            for (int i = 1; i <= cantDocuments; i++)
            {
                int RandomNumber = Row.generateNumber(1, 7);
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

            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = @args;
                watcher.Filter = "*.csv";

                watcher.Created += OnChanged;
                
                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Press 'q' to quit the sample.");
                while (Console.Read() != 'q') ;
            }
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            Thread.Sleep(TimeSpan.FromSeconds(0.1));
           ReadTypeFile(e.FullPath, e.Name);
        }


        static void ReadTypeFile(string fullpath, string nameFile)
        {
            Console.WriteLine(@fullpath);
            var lines = File.ReadAllLines(@fullpath);
            var campos = lines[1].Split(';');
            Console.WriteLine(campos[0]);
            switch (campos[0])
            {
                case "SOLMAAC":
                    helperSOLMAAC.TransformXMLSOLMAAC(@fullpath, nameFile);
                    File.Delete(@fullpath);
                    break;

                case "SOLI":
                    helperSOLI.TransformXMLSOLI(@fullpath, nameFile);
                    File.Delete(@fullpath);
                    break;

                case "SOLGRA":
                    helperSOLGRA.TransformXMLSOLGRA(@fullpath, nameFile);
                    File.Delete(@fullpath);
                    break;

                case "SOLCREES":
                    helperSOLCREES.TransformXMLSOLCREES(@fullpath, nameFile);
                    File.Delete(@fullpath);
                    break;

                case "SOLCANMA":
                    helperSOLCANMA.TransformXMLSOLCANMA(@fullpath, nameFile);
                    File.Delete(@fullpath);
                    break;

                case "SOLMAFI":
                    helperSOLMAFI.TransformXMLSOLMAFI(@fullpath, nameFile);
                    File.Delete(@fullpath);
                    break;
            }
            for (int i = 0; i < campos.Length - 1; i++)
            {
                Console.WriteLine(campos[i]);
            }

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
                "tipo_solicitud","cod_solicitud","nombres","apellidos","correo","programa",
                "sede","celular","fecha_solicitud","cedula","jornada","homologacion","semestre",
                "correo_institucional","asunto","observaciones","cod_asignatura","nom_asignatura",
                "estadosolmaac","carrera_aspira","puntaje_icfes","colegio_proviene","tipo_ceremonia",
                "estadosolgra","tipo_identificacion","edad","semestre_Inicio","id_matricula",
                "valorsemestre","concepto","valores_adicionales","fecha_limite_pago","fecha_inicio_recargo1",
                "valor_recargo1","fecha_inicio_recargo2","valor_recargo2","fecha_inicio_recargo3","valor_recargo3",
                "totalApagar_sinrecargo","totalApagar_recargo1","totalApagar_recargo2","totalApagar_recargo3",
                "documento_origen","estadoSOLMAFI"
            };

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
