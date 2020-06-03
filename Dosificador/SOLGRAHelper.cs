using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dosificador
{
    class SOLGRAHelper
    {
        GeneralHelper Row = new GeneralHelper();

        public void createSOLGRA(int numberFile)
        {
            string[] columns = {
                "tipo_solicitud",
                "cod_solicitud",
                "tipo_ceremonia",
                "nombres",
                "apellidos",
                "sede",
                "carrera", 
                "celular",
                "correo",
                "estado",
                "fecha_solicitud",
                "cedula"
            };

            string[] SOLGRA =
            {
                "SOLGRA",
                Row.generateNumber(0000, 9999, true),
                "TestTypeCeremony",
                Row.generateName(),
                Row.generateLastName(),
                Row.generateSede(),
                Row.generatePrograma(),
                Row.generateNumber(310000000,319999999, true),
                "test@test.com",
                Row.generateEstado(true),
                Row.generateNumber(1, 31, true) + "-" + Row.generateNumber(1, 12, true) + "-2020",
                Row.generateNumber(111111111,999999999, true),
            };

            var csv = new StringBuilder();
            string format = "{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};";
            var newLine = string.Format(format, columns);
            var newLine2 = string.Format(format, SOLGRA);
            csv.AppendLine(newLine);
            csv.AppendLine(newLine2);

            string filePath = "../../Documentos/Regados/SOLGRA-" + numberFile + ".csv";

            File.AppendAllText(@filePath, csv.ToString());
        }

        public void TransformXMLSOLGRA(string FileRoute, string nameFile)
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

            datos = "<SOLGRA>";
            var info = lines[1].Split(';');
            for (int j = 0; j < campos.Length - 1; j++)
            {
                datos += "\n\t" + tagsAperturaArray[j] + info[j] + tagsCierreArray[j];
            }
            datos += "</SOLGRA>";

            using (StreamWriter w = File.AppendText(@"../../Documentos/XML_SOLGRA/" + nameFile + ".xml"))
            {
                w.WriteLine(datos);
            }
        }
    }
}
