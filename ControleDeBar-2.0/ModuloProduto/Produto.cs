using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloProduto
{
    public class Produto : EntidadeBase<Produto>
    {
        public string nome;
        public decimal preco;

        public Produto(string nome, decimal preco)
        {
            this.nome = nome;
            this.preco = preco;
        }

        public override void AtualizarInformacoes(Produto produtoAtualizado)
        {
            this.nome = produtoAtualizado.nome;
            this.preco = produtoAtualizado.preco;
        }


        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
            {
                erros.Add("O campo \"Nome\" é obrigatorio");
            }
            if (preco == 0)
            {
                erros.Add("O campo \"Preço\" é obrigatorio");
            }

            return erros;
        }
    }


}
