using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dosificador
{
    class SOLMAFI
    {
        string tipo_solicitud;
        int cod_solicitud;
        string nombres;
        string apellidos;
        int semestre;
        string jornada;
        int valorsemestre;
        string concepto;
        int valores_adicionales;
        string fecha_limite_pago;
        string fecha_inicio_recargo1;
        int valor_recargo1;
        string fecha_inicio_recargo2;
        int valor_recargo2;
        string fecha_inicio_recargo3;
        int valor_recargo3;
        int totalApagar_sinrecargo;
        int totalApagar_recargo1;
        int totalApagar_recargo2;
        int totalApagar_recargo3;
        string documento_origen;
        string fecha_solicitud;
        string estado;
        int cedula;

        public string Tipo_solicitud { get => tipo_solicitud; set => tipo_solicitud = value; }
        public int Cod_solicitud { get => cod_solicitud; set => cod_solicitud = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public int Semestre { get => semestre; set => semestre = value; }
        public string Jornada { get => jornada; set => jornada = value; }
        public int Valorsemestre { get => valorsemestre; set => valorsemestre = value; }
        public string Concepto { get => concepto; set => concepto = value; }
        public int Valores_adicionales { get => valores_adicionales; set => valores_adicionales = value; }
        public string Fecha_limite_pago { get => fecha_limite_pago; set => fecha_limite_pago = value; }
        public string Fecha_inicio_recargo1 { get => fecha_inicio_recargo1; set => fecha_inicio_recargo1 = value; }
        public int Valor_recargo1 { get => valor_recargo1; set => valor_recargo1 = value; }
        public string Fecha_inicio_recargo2 { get => fecha_inicio_recargo2; set => fecha_inicio_recargo2 = value; }
        public int Valor_recargo2 { get => valor_recargo2; set => valor_recargo2 = value; }
        public string Fecha_inicio_recargo3 { get => fecha_inicio_recargo3; set => fecha_inicio_recargo3 = value; }
        public int Valor_recargo3 { get => valor_recargo3; set => valor_recargo3 = value; }
        public int TotalApagar_sinrecargo { get => totalApagar_sinrecargo; set => totalApagar_sinrecargo = value; }
        public int TotalApagar_recargo1 { get => totalApagar_recargo1; set => totalApagar_recargo1 = value; }
        public int TotalApagar_recargo2 { get => totalApagar_recargo2; set => totalApagar_recargo2 = value; }
        public int TotalApagar_recargo3 { get => totalApagar_recargo3; set => totalApagar_recargo3 = value; }
        public string Documento_origen { get => documento_origen; set => documento_origen = value; }
        public string Fecha_solicitud { get => fecha_solicitud; set => fecha_solicitud = value; }
        public string Estado { get => estado; set => estado = value; }
        public int Cedula { get => cedula; set => cedula = value; }
    }
}
