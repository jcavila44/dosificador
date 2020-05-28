using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dosificador
{
    class SOLI
    {
        string tipo_solicitud;
        int cod_solicitud;
        string Nombres;
        string Apellidos;
        string sede;
        string carrera_aspira;
        int puntaje_icfes;
        string colegio_proviene;
        bool homologacion;

        public string Tipo_solicitud { get => tipo_solicitud; set => tipo_solicitud = value; }
        public int Cod_solicitud { get => cod_solicitud; set => cod_solicitud = value; }
        public string Nombres1 { get => Nombres; set => Nombres = value; }
        public string Apellidos1 { get => Apellidos; set => Apellidos = value; }
        public string Sede { get => sede; set => sede = value; }
        public string Carrera_aspira { get => carrera_aspira; set => carrera_aspira = value; }
        public int Puntaje_icfes { get => puntaje_icfes; set => puntaje_icfes = value; }
        public string Colegio_proviene { get => colegio_proviene; set => colegio_proviene = value; }
        public bool Homologacion { get => homologacion; set => homologacion = value; }
    }
}
