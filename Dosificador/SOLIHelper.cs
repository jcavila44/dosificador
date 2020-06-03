using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dosificador
{
    class SOLIHelper
    {
        GeneralHelper Row = new GeneralHelper();

        public void createSOLI(int numberFile)
        {
            string[] columns = {
                "tipo_solicitud",
                "cod_solicitud",
                "Nombres",
                "Apellidos",
                "sede",
                "carrera_aspira",
                "puntaje_icfes",
                "colegio_proviene",
                "homologacion"
                };

            string[] SOLI =
            {
                "SOLI",
                Row.generateNumber(0000, 9999, true),
                Row.generateName(),
                Row.generateLastName(),
                Row.generateSede(),
                Row.generatePrograma(),
                Row.generateNumber(100,500, true),
                "colegio Prueba",
                "Si"
            };

            var csv = new StringBuilder();
            string format = "{0};{1};{2};{3};{4};{5};{6};{7};{8};";
            var newLine = string.Format(format, columns);
            var newLine2 = string.Format(format, SOLI);
            csv.AppendLine(newLine);
            csv.AppendLine(newLine2);

            string filePath = "../../Documentos/Regados/SOLI-" + numberFile + ".csv";

            File.AppendAllText(@filePath, csv.ToString());
        }

        public void TransformXMLSOLI(string FileRoute, string nameFile)
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

            datos = "<SOLI>";
            var info = lines[1].Split(';');
            for (int j = 0; j < campos.Length - 1; j++)
            {
                datos += "\n\t" + tagsAperturaArray[j] + info[j] + tagsCierreArray[j];
            }
            datos += "</SOLI>";

            using (StreamWriter w = File.AppendText(@"../../Documentos/XML_SOLI/" + nameFile + ".xml"))
            {
                w.WriteLine(datos);
            }
        }
    }
}
