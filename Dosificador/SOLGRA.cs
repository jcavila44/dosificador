using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dosificador
{
    class SOLGRA
    {
        string tipo_solicitud;
        int cod_solicitud;
        string tipo_ceremonia;
        string nombres;
        string apellidos;
        string sede;
        string carrera;
        string celular;
        string correo;
        string profesion;
        string estado;
        string documento_origen;
        string fecha_solicitud;
        int cedula;

        public string Tipo_solicitud { get => tipo_solicitud; set => tipo_solicitud = value; }
        public int Cod_solicitud { get => cod_solicitud; set => cod_solicitud = value; }
        public string Tipo_ceremonia { get => tipo_ceremonia; set => tipo_ceremonia = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Sede { get => sede; set => sede = value; }
        public string Carrera { get => carrera; set => carrera = value; }
        public string Celular { get => celular; set => celular = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Profesion { get => profesion; set => profesion = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Documento_origen { get => documento_origen; set => documento_origen = value; }
        public string Fecha_solicitud { get => fecha_solicitud; set => fecha_solicitud = value; }
        public int Cedula { get => cedula; set => cedula = value; }
    }
}
