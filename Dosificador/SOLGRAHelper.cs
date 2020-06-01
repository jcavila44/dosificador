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

            string filePath = "../../Documentos/Regados/" + numberFile + ".csv";

            File.AppendAllText(@filePath, csv.ToString());
        }
    }
}
