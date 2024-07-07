using Dominio.Modelos;
using FluentValidation;

namespace Dominio.Validacoes
{
    public class ProdutoValidador : AbstractValidator<Produto>
    {
        public ProdutoValidador() 
        {
            RuleFor(produto => produto.Nome)
            .NotNull()
            .NotEmpty()
            .WithMessage("O nome do produto deve ser informado.");

            RuleFor(produto => produto.Tipo)
            .IsInEnum()
            .WithMessage("O tipo do produto não é válido.");

            RuleFor(produto => produto.PrecoUnitario)
            .NotNull()
            .NotEmpty()
            .WithMessage("O preço unitário do produto deve ser informado.");
        }
    }
}