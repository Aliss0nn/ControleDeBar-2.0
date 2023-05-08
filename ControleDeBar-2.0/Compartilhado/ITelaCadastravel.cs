namespace ControleDeBar.ConsoleApp.Compartilhado
{
    public interface ITelaCadastravel
    {
        public string ApresentarMenu();

        public void InserirNovoRegistro();

        public void VisualizarRegistros(bool mostrarCabecalho);

        public void EditarRegistro();

        public void ExcluirRegistro();
    }
}

