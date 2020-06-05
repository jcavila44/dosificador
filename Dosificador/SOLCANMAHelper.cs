using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dosificador
{
    class SOLCANMAHelper
    {
        GeneralHelper Row = new GeneralHelper();

        public void createSOLCANMA(int numberFile)
        {
            string[] columns = {
               "tipo_solicitud",
                "cod_solicitud",
                "id_matricula",
                "cedula",
                "nombres", 
                "apellidos",
                "semestre",
                "programa",
                "sede",
                "jornada",
            };

            string[] SOLCANMA =
            {
                "SOLCANMA",
                Row.generateNumber(0000, 9999, true),
                Row.generateNumber(0000, 9999, true),
                Row.generateNumber(111111111, 999999999, true),
                Row.generateName(),
                Row.generateLastName(),
                Row.generateNumber(1, 12, true),
                Row.generatePrograma(),
                Row.generateSede(),
                Row.generateJornada(),
            };

            var csv = new StringBuilder();
            string format = "{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};";
            var newLine = string.Format(format, columns);
            var newLine2 = string.Format(format, SOLCANMA);
            csv.AppendLine(newLine);
            csv.AppendLine(newLine2);

            string filePath = "../../Documentos/Regados/SOLCANMA-" + numberFile + ".csv";

            File.AppendAllText(@filePath, csv.ToString());
        }

        public void TransformXMLSOLCANMA(string FileRoute, string nameFile)
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

            datos = "<SOLCANMA>";
            var info = lines[1].Split(';');
            for (int j = 0; j < campos.Length - 1; j++)
            {
                datos += "\n\t" + tagsAperturaArray[j] + info[j] + tagsCierreArray[j];
            }
            datos += "</SOLCANMA>";

            using (StreamWriter w = File.AppendText(@"../../Documentos/XML_SOLCANMA/" + nameFile + ".xml"))
            {
                w.WriteLine(datos);
            }
        }
    }
}
