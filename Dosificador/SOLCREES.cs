using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dosificador
{
    class SOLCREES
    {
        string tipo_solicitud;
        int cod_solicitud;
        int identificacion;
        string tipo_identificacion;
        string nombres;
        string apellidos;
        int edad;
        string carrera;
        bool homologacion;
        int semestre_Inicio;
        string correo;
        string sede;
        string jornada;

        public string Tipo_solicitud { get => tipo_solicitud; set => tipo_solicitud = value; }
        public int Cod_solicitud { get => cod_solicitud; set => cod_solicitud = value; }
        public int Identificacion { get => identificacion; set => identificacion = value; }
        public string Tipo_identificacion { get => tipo_identificacion; set => tipo_identificacion = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Carrera { get => carrera; set => carrera = value; }
        public bool Homologacion { get => homologacion; set => homologacion = value; }
        public int Semestre_Inicio { get => semestre_Inicio; set => semestre_Inicio = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Sede { get => sede; set => sede = value; }
        public string Jornada { get => jornada; set => jornada = value; }
    }
}
