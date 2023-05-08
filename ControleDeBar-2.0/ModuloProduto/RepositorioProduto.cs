namespace ControleDeBar.ConsoleApp.ModuloProduto
{
    public class RepositorioProduto : RepositorioBase<Produto>
    {
        public RepositorioProduto(List<Produto> listaProduto)
        {
            this.listaRegistros = listaProduto;
        }

    }
}