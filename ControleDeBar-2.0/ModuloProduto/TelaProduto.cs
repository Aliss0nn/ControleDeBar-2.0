namespace ControleDeBar.ConsoleApp.ModuloProduto
{
    public class TelaProduto : TelaBase<RepositorioProduto, Produto>
    {

        public TelaProduto(RepositorioProduto repositorioProduto)
        {
            this.repositorioBase = repositorioProduto;
            nomeEntidade = "Produto";
            sufixo = "s";
        }

        protected override void MostrarTabela(List<Produto> registros)
        {
            registros.Sort((x, y) => y.id.CompareTo(x.id));                                                                          

            foreach (Produto produto in registros)
            {
                Console.Write(produto.id + ", " + produto.nome + ", " + produto.preco);
                Console.WriteLine();
            }
        }

        protected override Produto ObterRegistro()
        {
            Console.WriteLine("Digite o nome do produto");
            string nomeProduto = Console.ReadLine();

            Console.WriteLine("Digite o valor do produto ");
            decimal precoProduto = Convert.ToDecimal(Console.ReadLine());

            return new Produto(nomeProduto, precoProduto);
        }


    }
}
