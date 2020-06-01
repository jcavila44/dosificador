using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
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
    }
}
