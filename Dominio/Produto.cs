using LinqToDB.Mapping;
using static Dominio.TipoEnum;

namespace Dominio
{
    [Table("Produto")]
    public class Produto
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Column("Nome"), NotNull]
        public string Nome { get; set; }

        [Column("Tipo"), NotNull]
        public Tipo Tipo { get; set;}

        [Column("PrecoUnitario"), NotNull]
        public double PrecoUnitario { get; set;}
    }
}