using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class TipoEnum
    {
        public enum Tipo
        {
            [Description("Serviço")]
            Servico,
            [Description("Material")]
            Material
        }
    }
}
