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
                "identificacion",
                "tipo_identificacion",
                "nombres",
                "apellidos",
                "edad",
                "carrera",
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

            string filePath = "../../Documentos/Regados/" + numberFile + ".csv";

            File.AppendAllText(@filePath, csv.ToString());
        }
    }
}
