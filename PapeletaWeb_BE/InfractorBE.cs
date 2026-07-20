using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapeletaWeb_BE
{
    public class InfractorBE
    {
        public String Cod_Infractor { get; set; }
        public String Dni { get; set; }
        public String Ape_Paterno { get; set; }
        public String Ape_Materno { get; set; }
        public String Nombres { get; set; }
        public String Correo { get; set; }
        public String Direccion { get; set; }
        public String Cod_Ubigeo { get; set; }
        public String Sexo { get; set; }
        public DateTime Fec_Nacimiento { get; set; }
        public Byte[] Foto { get; set; }
        public String Nro_Brevete { get; set; }
        public String Tipo_Brevete { get; set; }
        public DateTime Fec_Registro { get; set; }
        public String Usu_Registro { get; set; }
        public DateTime? Fec_Ult_Modificacion { get; set; }
        public String Usu_Ult_Modificacion { get; set; }
        public String Estado { get; set; }

        // Calculados (igual que en VW_INFRACTOR)
        public String SexoTexto { get; set; }          // MASCULINO / FEMENINO
        public String EstadoTexto { get; set; }         // ACTIVO / INACTIVO
        public String Departamento { get; set; }
        public String Provincia { get; set; }
        public String Distrito { get; set; }
    }
}
