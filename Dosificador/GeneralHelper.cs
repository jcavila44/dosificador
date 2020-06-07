using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Dosificador
{
    class GeneralHelper
    {
        public string generateName()
        {
            string[] name = {
                "Rubiel",
                "Jhon",
                "Alejandra",
                "Jaider",
                "Marlen",
                "Johana",
                "Nai",
                "Luz",
                "Jhon",
                "Mauro",
                "Luis",
                "Yulieth",
                "Daniel",
                "Jeisson",
                "Carlos",
                "Hernado",
                "Jose",
                "Jorge",
                "Jorge",
                "Lina",
                "Liliana",
                "Miller"
            };

            int number = generateNumber(0, 21);
            return name[number];
        }

        public string generateLastName()
        {
            string[] lastName = {
                "Avila",
                "Alvarez",
                "Hincapie",
                "Lopez",
                "Arango",
                "Atehortua",
                "Madrigal",
                "Ayala",
                "Barrientos",
                "Betancur",
                "Bustamante",
                "Cardenas",
                "Cardona",
                "Bustamante",
                "Gaviria",
                "Echeverry",
                "Fernandez",
                "Guzman",
                "Gaviria",
                "Giraldo",
                "Castro",
                "Gomez"
            };

            int number = generateNumber(0, 21);
            return lastName[number];
        }

        public string generateJornada()
        {
            string[] jornada = {
                "Diurna",
                "Nocturna",
                "FinDeSemana"
            };

            int number = generateNumber(0, 2);
            return jornada[number];
        }
        public string generateSede()
        {
            string[] Sede = {
                "Norte",
                "Sur",
            };

            int number = generateNumber(0, 1);
            return Sede[number];
        }

        public string generateEstado()
        {
            string[] Estado = {
                "Pendiente",
                "Revisado",
            };

            int number = generateNumber(0, 1);
            return Estado[number];
        }

        public string generateEstado(bool IsThisSolgra)
        {
            string[] Estado = {
                "Pendiente",
                "Analisis",
                "Denegado",
                "Revisado",
            };

            int number = generateNumber(0, 3);
            return Estado[number];
        }
        
        public string generatePrograma()
        {
            string[] Programa = {
                "programa_academico",
                "Preingeniería",
                "Biología Aplicada",
                "Ingeniería Ambiental",
                "Biología Aplicada",
                "Ingenería Biomédica",
                "Biología Aplicada",
                "Ingeniería Civil",
                "Biología Aplicada",
                "Ingeniería Industrial",
                "Biología Aplicada",
                "Ingeniería en Mecatrónica",
                "Biología Aplicada",
                "Ingeniería en Multimedia",
                "Ingeniería en Telecomunicaciones",
                "Tecnología en Electrónica y Comunicaciones",
                "Administración de Empresas",
                "Ingeniería en Telecomunicaciones",
                "Contaduría Pública",
                "Economía",
                "Tecnología en Contabilidad y Tributaria",
                "Administración de la Seguridad y Salud Ocupacional",
                "Tecnología en Atención Prehospitalaria (APH)",
                "Relaciones Internacionales y Estudios Políticos",
                "Tecnología en Atención Prehospitalaria (APH)",
                "Biología Aplicada",
                "Premédico",
                "Biología Aplicada",
                "Medicina",
                "Biología Aplicada",
                "Contaduría Pública",
                "Tecnología en Gestión y Producción Hortícola",
            };

            int number = generateNumber(0,31);
            return Programa[number];
        }



        public int generateNumber(int MinNumber, int MaxNumber)
        {
            Random random = new Random();
            return random.Next(MinNumber, MaxNumber);
        }
        public string generateNumber(int MinNumber, int MaxNumber, bool isThisString)
        {
            Random random = new Random();
            int number = random.Next(MinNumber, MaxNumber);
            return number.ToString();
        }

        public string[] TransformCanonicoXML(string FileRoute, string nameFile)
        {
            var lines = File.ReadAllLines(@FileRoute);
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
                "documento_origen","estadoSOLMAFI",
            };

            string[] tagsAperturaArray = new string[inputsCanonicos.Length];
            string[] tagsCierreArray = new string[inputsCanonicos.Length];

            for (int i = 0; i < inputsCanonicos.Length - 1; i++)
            {
                tagsAperturaArray[i] = "<" + inputsCanonicos[i] + ">";
                tagsCierreArray[i] = "</" + inputsCanonicos[i] + ">";

            }

            datos = "<CANONICO>";
            var campos = lines[0].Split(';');
            var info = lines[1].Split(';');
            for (int j = 0; j < inputsCanonicos.Length; j++)
            {
                datos += "\n\t" + tagsAperturaArray[j];
                for (int i = 0; i < campos.Length; i++)
                {
                    if (inputsCanonicos[j] == campos[i])
                    {
                        datos += info[i];
                    }
                }
                datos += tagsCierreArray[j];
            }
            datos += "\n\t</CANONICO>";
            string[] InfoFile = { 
                "../../Documentos/XMLCanonicoRegados/Canonico-" + nameFile + ".xml", 
                "Canonico-"+nameFile+".xml" 
            };

            using (StreamWriter w = File.AppendText(@InfoFile[0]))
            {
                w.WriteLine(datos);
            }
            return InfoFile;
        }
    }
}
