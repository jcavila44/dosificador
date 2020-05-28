using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dosificador
{
    class SOLCANMA
    {
        string tipo_solicitud;
        int cod_solicitud;
        int id_matricula;
        int identificacion;
        string nombres;
        string apellidos;
        string semestre;
        string programa;
        string sede;
        string jornada;

        public string Tipo_solicitud { get => tipo_solicitud; set => tipo_solicitud = value; }
        public int Cod_solicitud { get => cod_solicitud; set => cod_solicitud = value; }
        public int Id_matricula { get => id_matricula; set => id_matricula = value; }
        public int Identificacion { get => identificacion; set => identificacion = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Semestre { get => semestre; set => semestre = value; }
        public string Programa { get => programa; set => programa = value; }
        public string Sede { get => sede; set => sede = value; }
        public string Jornada { get => jornada; set => jornada = value; }
    }
}
