using LinqToDB.Mapping;
using static Dominio.Modelos.TipoEnum;

namespace Dominio.Modelos
{
    [Table("Produto")]
    public class Produto
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }

        [Column("Nome"), NotNull]
        public string Nome { get; set; }

        [Column("Tipo"), NotNull]
        public Tipo Tipo { get; set; }

        [Column("PrecoUnitario"), NotNull]
        public double PrecoUnitario { get; set; }
    }
}