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
        public static GeneralHelper Row = new GeneralHelper();
        public static listaEnlazadaSimple PrioridadAlta = new listaEnlazadaSimple();
        public static listaEnlazadaSimple PrioridadMedia = new listaEnlazadaSimple();
        public static listaEnlazadaSimple PrioridadBaja = new listaEnlazadaSimple();

        static void Main(string[] args)
        {
            CrearPathsForDelete();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            Thread RunWatcher = new Thread(() => Run());
            RunWatcher.Start();

            Thread Prioridades = new Thread(() => prioridades());
            Prioridades.Start();

            Thread DosificadorThread = new Thread(() => Dosificador());
            Thread.Sleep(TimeSpan.FromSeconds(3));
            DosificadorThread.Start();
        }
        public static bool CrearPathsForDelete()
        {
            string[] routes =
            {
                @"../../Documentos/Regados/",
                @"../../Documentos/OUT_SOLCANMA/",
                @"../../Documentos/OUT_SOLCREES/",
                @"../../Documentos/OUT_SOLGRA/",
                @"../../Documentos/OUT_SOLI/",
                @"../../Documentos/OUT_SOLMAAC/",
                @"../../Documentos/OUT_SOLMAFI/",
                @"../../Documentos/XML_SOLCANMA/",
                @"../../Documentos/XML_SOLCREES/",
                @"../../Documentos/XML_SOLGRA/",
                @"../../Documentos/XML_SOLI/",
                @"../../Documentos/XML_SOLMAAC/",
                @"../../Documentos/XML_SOLMAFI/",
                @"../../Documentos/XMLCanonicoRegados/"
            };

            foreach (string route in routes)
            {
                DirectoryInfo path = new DirectoryInfo(route);
                VaciarCarpetas(path);
            }
            return true;
        }
        public static void VaciarCarpetas(System.IO.DirectoryInfo directory)
        {
            foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
            foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
        }

        public static void Dosificador()
        {

            int cantDocuments = 20;


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
        private static void prioridades()
        {
            int n = 0;
            while (n < 1)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                sendXmlEverytime();
            }
        }


        private static void sendXmlEverytime()
        {
            if (!PrioridadAlta.listaVacia())
            {
                Console.Write("Prioridad Alta");
                Nodo Cabeza = PrioridadAlta.Cabeza;
                Console.Write(Cabeza.NameFile + "\n");
                moveFile(Cabeza);
                PrioridadAlta.EliminarElementoDesdeLaCabeza();
            }
            else
            {
                if (!PrioridadMedia.listaVacia())
                {
                    Console.WriteLine("Prioridad Media");
                    Nodo Cabeza = PrioridadMedia.Cabeza;
                    Console.Write(Cabeza.NameFile + "\n");
                    moveFile(Cabeza);
                    PrioridadMedia.EliminarElementoDesdeLaCabeza();
                }
                else
                {
                    if (!PrioridadBaja.listaVacia())
                    {
                        Console.WriteLine("Prioridad Baja");
                        Nodo Cabeza = PrioridadBaja.Cabeza;
                        Console.Write(Cabeza.NameFile + "\n");
                        moveFile(Cabeza);
                        PrioridadBaja.EliminarElementoDesdeLaCabeza();
                    }
                }
            }

        }

        public static void moveFile(Nodo Cabeza)
        {
            Console.Write(Cabeza.NameFile + "\n");
            string sourceFile = Cabeza.RutaFile;
            string folderDestination = GetFolderInAgremmetWithFile(Cabeza.Typefile, Cabeza.NameFile);
            File.Move(@sourceFile, @folderDestination);
        }

        public static string GetFolderInAgremmetWithFile(string typeFile, string NameFile)
        {
            string directoryDestination = "";
            switch (typeFile)
            {
                case "SOLMAAC":
                    directoryDestination = "../../Documentos/OUT_SOLMAAC/" + NameFile;
                    break;

                case "SOLI":
                    directoryDestination = "../../Documentos/OUT_SOLI/" + NameFile;
                    break;

                case "SOLGRA":
                    directoryDestination = "../../Documentos/OUT_SOLGRA/" + NameFile;
                    break;

                case "SOLCREES":
                    directoryDestination = "../../Documentos/OUT_SOLCREES/" + NameFile;
                    break;

                case "SOLCANMA":
                    directoryDestination = "../../Documentos/OUT_SOLCANMA/" + NameFile;
                    break;

                case "SOLMAFI":
                    directoryDestination = "../../Documentos/OUT_SOLMAFI/" + NameFile;
                    break;
            }
            return directoryDestination;
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
            string[] infoFile;
            switch (campos[0])
            {
                case "SOLMAAC":
                    helperSOLMAAC.TransformXMLSOLMAAC(@fullpath, nameFile);
                    infoFile = Row.TransformCanonicoXML(@fullpath, nameFile);
                    PrioridadAlta.agregarElementoAlFinal(@infoFile[0], infoFile[1], "SOLMAAC");
                    File.Delete(@fullpath);
                    break;

                case "SOLI":
                    helperSOLI.TransformXMLSOLI(@fullpath, nameFile);
                    infoFile = Row.TransformCanonicoXML(@fullpath, nameFile);
                    PrioridadAlta.agregarElementoAlFinal(@infoFile[0], infoFile[1], "SOLI");
                    File.Delete(@fullpath);
                    break;

                case "SOLGRA":
                    helperSOLGRA.TransformXMLSOLGRA(@fullpath, nameFile);
                    infoFile = Row.TransformCanonicoXML(@fullpath, nameFile);
                    PrioridadMedia.agregarElementoAlFinal(@infoFile[0], infoFile[1], "SOLGRA");
                    File.Delete(@fullpath);
                    break;

                case "SOLCREES":
                    helperSOLCREES.TransformXMLSOLCREES(@fullpath, nameFile);
                    infoFile = Row.TransformCanonicoXML(@fullpath, nameFile);
                    PrioridadMedia.agregarElementoAlFinal(@infoFile[0], infoFile[1], "SOLCREES");
                    File.Delete(@fullpath);
                    break;

                case "SOLCANMA":
                    helperSOLCANMA.TransformXMLSOLCANMA(@fullpath, nameFile);
                    infoFile = Row.TransformCanonicoXML(@fullpath, nameFile);
                    PrioridadBaja.agregarElementoAlFinal(@infoFile[0], infoFile[1], "SOLCANMA");
                    File.Delete(@fullpath);
                    break;

                case "SOLMAFI":
                    helperSOLMAFI.TransformXMLSOLMAFI(@fullpath, nameFile);
                    infoFile = Row.TransformCanonicoXML(@fullpath, nameFile);
                    PrioridadAlta.agregarElementoAlFinal(@infoFile[0], infoFile[1], "SOLMAFI");
                    File.Delete(@fullpath);
                    break;
            }
        }
    }
}
