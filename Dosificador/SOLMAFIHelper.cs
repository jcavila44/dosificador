using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Dosificador
{
    class SOLMAFIHelper
    {
        GeneralHelper Row = new GeneralHelper();

        public void createSOLMAFI(int numberFile)
        {
            string[] columns = {
                "tipo_solicitud",
                "cod_solicitud",
                "nombres",
                "apellidos",
                "semestre",
                "jornada",
                "valorsemestre",
                "concepto",
                "valores_adicionales",
                "fecha_limite_pago",
                "fecha_inicio_recargo1",
                "valor_recargo1",
                "fecha_inicio_recargo2",
                "valor_recargo2",
                "fecha_inicio_recargo3",
                "valor_recargo3",
                "totalApagar_sinrecargo",
                "totalApagar_recargo1",
                "totalApagar_recargo2",
                "totalApagar_recargo3",
                "tipo_solicitud",
                "documento_origen",
                "fecha_solicitud",
                "estado",
                "cedula",
            };

            int valorsemestre = Row.generateNumber(1000000, 4200000);
            int valor_recargo1 = 100000;
            int valor_recargo2 = 100000;
            int valor_recargo3 = 100000;

            int totalApagar_recargo1 = valorsemestre + valor_recargo1;
            int totalApagar_recargo2 = valorsemestre + valor_recargo1 + valor_recargo2;
            int totalApagar_recargo3 = valorsemestre + valor_recargo1 + valor_recargo2 + valor_recargo3;

            string[] SOLMAFIinfo =
            {
                "SOLMAFI",
                Row.generateNumber(0000, 9999, true),
                Row.generateName(),
                Row.generateLastName(),
                Row.generateNumber(1, 12, true),
                Row.generateJornada(),
                Row.generateNumber(1000000, 4200000, true),
                "Valor Semestre",
                Row.generateNumber(20000, 90000, true),
                Row.generateNumber(1, 31, true) + "-" + Row.generateNumber(1, 12, true) + "-2020",
                Row.generateNumber(1, 31, true) + "-" + Row.generateNumber(1, 12, true) + "-2020",
                valor_recargo1.ToString(),
                Row.generateNumber(1, 31, true) + "-" + Row.generateNumber(1, 12, true) + "-2020",
                valor_recargo2.ToString(),
                Row.generateNumber(1, 31, true) + "-" + Row.generateNumber(1, 12, true) + "-2020",
                valor_recargo3.ToString(),
                valorsemestre.ToString(),
                totalApagar_recargo1.ToString(),
                totalApagar_recargo2.ToString(),
                totalApagar_recargo3.ToString(),
                Row.generateNumber(1, 31, true) + "-" + Row.generateNumber(1, 12, true) + "-2020",
                Row.generateEstado(),
                Row.generateNumber(111111111, 999999999, true)
            };

            var csv = new StringBuilder();
            string format = "{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16};{17};{18};{19};{20};{21};{22}";
            var newLine = string.Format(format, columns);
            var newLine2 = string.Format(format, SOLMAFIinfo);
            csv.AppendLine(newLine);
            csv.AppendLine(newLine2);

            string filePath = "../../Documentos/Regados/SOLMAFI-" + numberFile + ".csv";

            File.AppendAllText(@filePath, csv.ToString());
        }

        public void TransformXMLSOLMAFI(string FileRoute, string nameFile)
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

            datos = "<SOLMAFI>";
            var info = lines[1].Split(';');
            for (int j = 0; j < campos.Length - 1; j++)
            {
                datos += "\n\t" + tagsAperturaArray[j] + info[j] + tagsCierreArray[j];
            }
            datos += "</SOLMAFI>";

            using (StreamWriter w = File.AppendText(@"../../Documentos/XML_SOLMAFI/" + nameFile + ".xml"))
            {
                w.WriteLine(datos);
            }
        }
    }
}
