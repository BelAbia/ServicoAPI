using LinqToDB.Data;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelos;

namespace Infraestrutura
{
    public class ProdutoDb : DataConnection
    {
        public ProdutoDb(DataOptions<ProdutoDb> options)
            : base(options.Options)
        {

        }

        public ITable<Produto> Produto => this.GetTable<Produto>();
    }
}