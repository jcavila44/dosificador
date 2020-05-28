using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dosificador
{
    class SOLMAAC
    {
        string tipo_solicitud;
        int cod_solicitud;
        string nombres;
        string apellidos;
        string programa_academico;
        int num_documento;
        int cedula;
        string celular;
        string correo_institucional;
        string correo_personal;
        string asunto;
        string observaciones;
        int cod_asignatura;
        string nom_asignatura;
        string documento_origen;
        string fecha_solicitud;
        string estado;

        public string Tipo_solicitud { get => tipo_solicitud; set => tipo_solicitud = value; }
        public int Cod_solicitud { get => cod_solicitud; set => cod_solicitud = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Programa_academico { get => programa_academico; set => programa_academico = value; }
        public int Num_documento { get => num_documento; set => num_documento = value; }
        public int Cedula { get => cedula; set => cedula = value; }
        public string Celular { get => celular; set => celular = value; }
        public string Correo_institucional { get => correo_institucional; set => correo_institucional = value; }
        public string Correo_personal { get => correo_personal; set => correo_personal = value; }
        public string Asunto { get => asunto; set => asunto = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public int Cod_asignatura { get => cod_asignatura; set => cod_asignatura = value; }
        public string Nom_asignatura { get => nom_asignatura; set => nom_asignatura = value; }
        public string Documento_origen { get => documento_origen; set => documento_origen = value; }
        public string Fecha_solicitud { get => fecha_solicitud; set => fecha_solicitud = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
