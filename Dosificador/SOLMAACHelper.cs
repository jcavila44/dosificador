using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dosificador
{
    class SOLMAACHelper
    {
        GeneralHelper Row = new GeneralHelper();

        public void createSOLMAAC(int numberFile)
        {
            string[] columns = {
                "tipo_solicitud",
                "cod_solicitud",
                "nombres",
                "apellidos",
                "programa_academico",
                "num_documento",
                "celular",
                "correo_institucional",
                "correo_personal",
                "asunto",
                "observaciones",
                "cod_asignatura",
                "nom_asignatura",
                "fecha_solicitud",
                "estado",
                "cedula",
                };

            string[] SOLMAACinfo =
            {
                "SOLMAAC",
                Row.generateNumber(0000, 9999, true),
                Row.generateName(),
                Row.generateLastName(),
                Row.generatePrograma(),
                Row.generateNumber(100000000,999999999, true),
                Row.generateNumber(30000000,39999999, true),
                "test@test.com",
                "test@test.com",
                generateAsunto(),
                "testtesttesttesttest",
                Row.generateNumber(0000,9999, true),
                generateAsignatura(),
                Row.generateNumber(1, 31, true) + "-" + Row.generateNumber(1, 12, true) + "-2020",
                Row.generateEstado(),
                Row.generateNumber(111111111, 999999999, true)
            };

            var csv = new StringBuilder();
            string format = "{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15}";
            var newLine = string.Format(format, columns);
            var newLine2 = string.Format(format, SOLMAACinfo);
            csv.AppendLine(newLine);
            csv.AppendLine(newLine2);

            string filePath = "../../Documentos/Regados/SOLMAAC-" + numberFile + ".csv";

            File.AppendAllText(@filePath, csv.ToString());
        }

        public string generateAsunto(){
            string[] Asunto = {
                "Matricula academica",
                "Queja",
                "Peticion",
            };


            int number = Row.generateNumber(0, 2);
            return Asunto[number];
        }
        
        public string generateAsignatura(){
            string[] Asunto = {
               "Lectoescritura musical",
                "Rítmica - Métrica",
                "Lectura sobre el teclado",
                "Historia de la Música",
                "Repertorio",
                "Armonía",
                "Contrapunto",
                "Análisis",
                "Acústica",
                "Músicas Populares y Tradicionales",
                "Introducción a la Universidad",
                "Musicología",
                "Música y tecnología",
                "Composición",
                "Composición",
                "Instrumentación",
                "Taller Armonía",
                "Teoría y Composición",
            };


            int number = Row.generateNumber(0, 17);
            return Asunto[number];
        }

        public void TransformXMLSOLMAAC(string FileRoute, string nameFile)
        {
            var lines = File.ReadAllLines(@FileRoute);
            string datos;
            var campos = lines[0].Split(';');

            string[] tagsAperturaArray = new string[campos.Length];
            string[] tagsCierreArray = new string[campos.Length];

            for (int i = 0; i < campos.Length - 1; i++)
            {
                tagsAperturaArray[i] = "<" + campos[i] + ">";
                tagsCierreArray[i] = "</" + campos[i] + ">";

            }

            datos = "<SOLMAAC>";
            var info = lines[1].Split(';');
            for (int j = 0; j < campos.Length - 1; j++)
            {
                datos += "\n\t" + tagsAperturaArray[j] + info[j] + tagsCierreArray[j];
            }
            datos += "</SOLMAAC>";

            using (StreamWriter w = File.AppendText(@"../../Documentos/XML_SOLMAAC/" + nameFile + ".xml"))
            {
                w.WriteLine(datos);
            }
        }

    }
}
