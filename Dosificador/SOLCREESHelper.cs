using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dosificador
{
    class SOLCREESHelper
    {
        GeneralHelper Row = new GeneralHelper();

        public void createSOLCREES(int numberFile)
        {
            string[] columns = {
                "tipo_solicitud",
                "cod_solicitud",
                "cedula",
                "tipo_identificacion",
                "nombres",
                "apellidos",
                "edad",
                "programa",
                "homologacion",
                "semestre_Inicio",
                "correo",
                "sede",
                "jornada"
            };

            string[] SOLCREES =
            {
                "SOLCREES",
                Row.generateNumber(0000, 9999, true),
                Row.generateNumber(111111111, 999999999, true),
                "TestTypeDocument",
                Row.generateName(),
                Row.generateLastName(),
                Row.generateNumber(18, 60, true),
                Row.generatePrograma(),
                "Si",
                Row.generateNumber(1,12, true),
                "Test@test.com",
                Row.generateSede(),
                Row.generateJornada(),
            };

            var csv = new StringBuilder();
            string format = "{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12}";
            var newLine = string.Format(format, columns);
            var newLine2 = string.Format(format, SOLCREES);
            csv.AppendLine(newLine);
            csv.AppendLine(newLine2);

            string filePath = "../../Documentos/Regados/SOLCREES" + numberFile + ".csv";

            File.AppendAllText(@filePath, csv.ToString());
        }

        public void TransformXMLSOLCREES(string FileRoute, string nameFile)
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

            datos = "<SOLCREES>";
            var info = lines[1].Split(';');
            for (int j = 0; j < campos.Length - 1; j++)
            {
                datos += "\n\t" + tagsAperturaArray[j] + info[j] + tagsCierreArray[j];
            }
            datos += "</SOLCREES>";

            using (StreamWriter w = File.AppendText(@"../../Documentos/XML_SOLCREES/" + nameFile + ".xml"))
            {
                w.WriteLine(datos);
            }
        }
    }
}
