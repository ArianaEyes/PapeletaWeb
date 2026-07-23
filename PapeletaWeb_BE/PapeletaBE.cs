using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapeletaWeb_BE
{
    public class PapeletaBE
    {
        public string Cod_Papeleta { get; set; }

        public string Cod_Infraccion { get; set; }

        public string Cod_Policia { get; set; }

        public string Cod_Vehiculo { get; set; }

        public DateTime Fecha_Infraccion { get; set; }

        public TimeSpan Hora_Infraccion { get; set; }

        public string Lugar_Infraccion { get; set; }

        public string Referencia { get; set; }

        public string Info_Adicional { get; set; }

        public string Observaciones { get; set; }

        public string Estado_Papeleta { get; set; }

        public DateTime Fec_Registro { get; set; }

        public string Usu_Registro { get; set; }

        public DateTime? Fec_Ult_Modificacion { get; set; }

        public string Usu_Ult_Modificacion { get; set; }
    }
}