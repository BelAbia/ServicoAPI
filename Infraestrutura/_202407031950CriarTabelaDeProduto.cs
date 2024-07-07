using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dominio.Modelos.TipoEnum;

namespace Infraestrutura
{
    [Migration(202407031950)]
    public class _202407031950CriarTabelaDeProduto : Migration
    {
        public override void Up()
        {
            Create.Table("Produto")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Nome").AsString()
                .WithColumn("Tipo").AsString()
                .WithColumn("PrecoUnitario").AsDouble();

            Insert.IntoTable("Produto").Row(new { Nome = "Serviço A", Tipo = (int)Tipo.Servico, PrecoUnitario = 20.00 });
            Insert.IntoTable("Produto").Row(new { Nome = "Material A", Tipo = (int)Tipo.Material, PrecoUnitario = 80.00 });
            Insert.IntoTable("Produto").Row(new { Nome = "Serviço B", Tipo = (int)Tipo.Servico, PrecoUnitario = 100.00 });
            Insert.IntoTable("Produto").Row(new { Nome = "Material B", Tipo = (int)Tipo.Material, PrecoUnitario = 150.00 });
        }

        public override void Down()
        {
            Delete.Table("Produto");
        }

    }
}
