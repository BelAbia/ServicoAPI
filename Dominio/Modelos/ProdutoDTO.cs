﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dominio.Modelos.TipoEnum;

namespace Dominio.Modelos
{
    public class ProdutoDTO
    {
        public double PrecoMedio { get; set; }
        public Tipo Tipo { get; set; }
        public int Quantidade { get; set; }
    }
}
