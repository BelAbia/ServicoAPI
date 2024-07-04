using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dominio.TipoEnum;

namespace Dominio
{
    public class ProdutoDTO
    {
        public double PrecoMedio { get; set; }
        public Tipo Tipo {  get; set; }
        public int Quantidade {  get; set; }
    }
}
