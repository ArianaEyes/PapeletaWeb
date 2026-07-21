using System;

namespace PapeletaWeb_BE
{
    public class PoliciaBE
    {
        public string Cod_Policia { get; set; }

        public string Paterno { get; set; }

        public string Materno { get; set; }

        public string Nombre { get; set; }

        public string Dni { get; set; }

        public string Cod_Ubigeo { get; set; }

        public int Cod_Rango { get; set; }

        public string Sexo { get; set; }

        public string Estado { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public byte[] Foto { get; set; }

        public string Usu_Registro { get; set; }

        public string Usu_Ult_Modificacion { get; set; }

        public string SexoTexto { get; set; }

        public string Rango { get; set; }

        public string Departamento { get; set; }

        public string Provincia { get; set; }

        public string Distrito { get; set; }

        public string EstadoTexto { get; set; }

        public string Id_Depa { get; set; }

        public string Id_Prov { get; set; }

        public string Id_Dist { get; set; }
    }
}