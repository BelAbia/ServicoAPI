using Dominio.Modelos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            .NotNull()
            .NotEmpty()
            .WithMessage("O tipo do produto deve ser informado.");

            RuleFor(produto => produto.PrecoUnitario)
            .NotNull()
            .NotEmpty()
            .WithMessage("O preço unitário do produto deve ser informado.");
        }
    }
}