namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class RepositorioMesa : RepositorioBase<Mesa>
    {
        public RepositorioMesa(List<Mesa> listaMesa)
        {
            this.listaRegistros = listaMesa;
        }

    }
}
