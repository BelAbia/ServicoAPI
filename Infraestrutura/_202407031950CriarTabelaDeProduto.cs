using Dominio;
using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dominio.TipoEnum;

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

            Insert.IntoTable("Produto").Row(new { Id = 1, Nome = "Serviço A", Tipo = Tipo.Servico, PrecoUnitario = 20.00 });
            Insert.IntoTable("Produto").Row(new { Id = 2, Nome = "Material A", Tipo = Tipo.Material, PrecoUnitario = 80.00 });
            Insert.IntoTable("Produto").Row(new { Id = 3, Nome = "Serviço B", Tipo = Tipo.Servico, PrecoUnitario = 100.00 });
            Insert.IntoTable("Produto").Row(new { Id = 4, Nome = "Material B", Tipo = Tipo.Material, PrecoUnitario = 150.00 });
        }

        public override void Down()
        {
            Delete.Table("Produto");
        }

    }
}
